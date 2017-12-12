using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.UDLImport;
using TrackerCommon;
using TrackerSPD.OPC;

namespace UDMLadderTracker
{
    public partial class FrmPlcSetWizard : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private bool m_bPLCConfigCheck = false;
        private bool m_bPLCConvertCheck = false;
        private bool m_bChangFlag = false;
        private bool m_bNextFlag = false;
        
        private CPlcConfig m_cPlcConfig = new CPlcConfig();
        private CPlcLogicData m_cPlcLogicData = new CPlcLogicData();
        private string sPlcID = "";

        #endregion


        #region Initialize

        public FrmPlcSetWizard()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool ChangeFlag
        {
            get { return m_bChangFlag; }
        }

        #endregion


        #region Private Method

        private void ConfigOPC()
        {
            FrmOPCProperty frmProperty = new FrmOPCProperty();
            frmProperty.Editable = true;
            m_cPlcConfig.OPCConfig.LsOpc = chkLSMaker.Checked;
            frmProperty.OPCConfig = m_cPlcConfig.OPCConfig;
            frmProperty.ShowDialog();
        }

        private void ConfigMelsec()
        {
            FrmDDEAProperty frmMelsec = new FrmDDEAProperty(m_cPlcConfig.MelsecConfig);
            frmMelsec.ShowDialog();
            if (frmMelsec.IsDataChange)
                m_cPlcConfig.MelsecConfig = frmMelsec.Config;

        }

        private void ConfigLs()
        {
            FrmLsPlcConfig frmLs = new FrmLsPlcConfig(m_cPlcConfig.LsConfig);
            frmLs.ShowDialog();
            if (frmLs.ChangeConfig)
            {
                frmLs.LsConfig.Use = true;
                m_cPlcConfig.LsConfig = frmLs.LsConfig;
            }

        }

        private bool ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker);

            if (!cLogic.FileOpenCheck)
                return false;
            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import " + emPLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (emPLCMaker != EMPLCMaker.Siemens)
            {
                m_cPlcLogicData.TagS = cLogic.GlobalTags;
                m_cPlcLogicData.StepS = cLogic.StepS;
            }
            else
            {
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel);
                if (cTagS == null)
                    return false;

                m_cPlcLogicData.TagS = cTagS;
                m_cPlcLogicData.StepS = GetUsedStep(cLogic.StepS, m_cPlcLogicData.TagS);
            }

            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);
            m_cPlcLogicData.Compose();
            m_cPlcLogicData.Maker = emPLCMaker;
            return true;
        }

        private bool ImportMelsecPLC(string sChannel)
        {
            CUDLImport cMelsecLogic = new CUDLImport(UDM.Common.EMPLCMaker.Mitsubishi);

            if (!cMelsecLogic.FileOpenCheck)
                return false;

            cMelsecLogic.Channel = sChannel;
            bool bOK = cMelsecLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import Melsec Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            m_cPlcLogicData.TagS = cMelsecLogic.GlobalTags;
            m_cPlcLogicData.StepS = cMelsecLogic.StepS;

            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);

            m_cPlcLogicData.Compose();
            m_cPlcLogicData.Maker = UDM.Common.EMPLCMaker.Mitsubishi;
            return true;
        }

        private bool ImportLogic()
        {
            CUDLImport cLogic = new CUDLImport(UDM.Common.EMPLCMaker.ALL);
            string sChannel = string.Empty;

            if (!cLogic.FileOpenCheck)
                return false;

            if (cLogic.PLCMaker != UDM.Common.EMPLCMaker.LS)
            {
                sChannel = GetUserInputText("Input " + cLogic.PLCMaker.ToString() + " Tag Header", "Please enter text below...");
                cLogic.Channel = sChannel;
            }

            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            m_cPlcLogicData.TagS = cLogic.GlobalTags;
            m_cPlcLogicData.StepS = cLogic.StepS;
            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);
            m_cPlcLogicData.Maker = EMPLCMaker.Rockwell;
            m_cPlcLogicData.Compose();

            return true;
        }

        private bool ValidateTag(CTagS cTagS)
        {
            if (cTagS.Count == 0) return false;

            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = new COPCConfig();
            cOPCServer.Config.Use = true;
            cOPCServer.Config.ServerName = m_cPlcConfig.OPCConfig.ServerName;
            cOPCServer.Config.ChannelDevice = m_cPlcConfig.OPCConfig.ChannelDevice;
            cOPCServer.Config.UpdateRate = m_cPlcConfig.OPCConfig.UpdateRate;
            bool bCheck = false;
            bool bOK = cOPCServer.Connect();
            if (bOK)
            {
                List<string> lstResult = cOPCServer.ValidateItemS(cTagS.Values.ToList());
                if (lstResult != null && lstResult.Count != 0)
                {
                    string sDeleteTag = "";
                    //삭제 구문
                    for (int i = 0; i < lstResult.Count; i++)
                    {
                        if (cTagS.ContainsKey(lstResult[i]))
                            cTagS.Remove(lstResult[i]);
                        //sDeleteTag += string.Format("{0}, ", lstResult[i]);
                    }
                    //sDeleteTag += string.Format("\r\n\r\n제외 Tag : {0}ea", lstResult.Count);
                    sDeleteTag = string.Format("수집 불가능한 Tag : {0}ea", lstResult.Count);
                    MessageBox.Show(sDeleteTag);

                    if (cTagS.Count == 0)
                        MessageBox.Show("변환된 Tag가 없습니다. OPC 설정이나 입력한 Channel.Device정보가 틀렸을 수 있습니다.\r\n확인하세요.", "UDM Tracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        bCheck = true;
                }
                else if (lstResult.Count == 0)
                    bCheck = true;
            }

            cOPCServer.Disconnect();
            cOPCServer.Dispose();
            cOPCServer = null;

            return bCheck;
        }

        private CTagS GetUsedTagS(CTagS cTagS, string sChannel)
        {
            CTagS cRetTagS = new CTagS();
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                if (cTag.Address == "") continue;
                if (cTag.Address.Contains("FC") || cTag.Address.Contains("FB") || cTag.Address.Contains("SFB") || cTag.Address.Contains("SFC"))
                    continue;
                //if (cTag.Address.Contains("DB")) continue;
                if (cTag.DataType == EMDataType.Block) continue;
                if (cTag.DataType == EMDataType.Date_And_Time) continue;
                if (cTag.DataType == EMDataType.Int) cTag.DataType = EMDataType.Word;

                if (cTag.Address.Contains("T")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MD")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MW")) cTag.DataType = EMDataType.Word;
                else if (cTag.Address.Contains("MB")) cTag.DataType = EMDataType.Byte;

                cTag.Key = cTag.Key;
                cTag.Channel = sChannel;
                cTag.Description = cTag.Description;

                cRetTagS.Add(cTag);
            }

            bool bOK = ValidateTag(cRetTagS);
            if (bOK == false) return null;
            return cRetTagS;
        }

        private CStepS GetUsedStep(CStepS cStepS, CTagS cTagS)
        {
            CStepS cRetStepS = new CStepS();
            CTagS cUsedTagS = new CTagS();
            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    foreach (CContent cont in cStep.CoilS[i].ContentS)
                    {
                        if (cont.Tag == null) continue;

                        if (cTagS.ContainsKey(cont.Tag.Key))
                        {
                            if (cUsedTagS.ContainsKey(cont.Tag.Key) == false) cUsedTagS.Add(cont.Tag);

                            if (cRetStepS.ContainsKey(who.Key) == false)
                                cRetStepS.Add(who.Key, cStep);
                        }
                    }
                }
                foreach (CContact cont in cStep.ContactS)
                {
                    for (int i = 0; i < cont.RefTagS.KeyList.Count; i++)
                    {
                        if (cTagS.ContainsKey(cont.RefTagS.KeyList[i]))
                        {
                            if (cUsedTagS.ContainsKey(cont.RefTagS.KeyList[i]) == false) cUsedTagS.Add(cTagS[cont.RefTagS.KeyList[i]]);
                        }
                    }
                }
            }
            cTagS = cUsedTagS;

            return cRetStepS;
        }

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        #endregion


        #region Form Event Method

        private void btnPlcAdd_Click(object sender, EventArgs e)
        {
            m_cPlcLogicData.PlcName = txtPlcName.Text;
            CMultiProject.PlcLogicDataS.Add(m_cPlcLogicData.PLCID, m_cPlcLogicData);
            CMultiProject.PlcConfigS.Add(m_cPlcConfig.PlcID, m_cPlcConfig);
            m_cPlcLogicData = new CPlcLogicData();
            m_cPlcConfig = new CPlcConfig();

            m_bPLCConfigCheck = false;
            m_bPLCConvertCheck = false;
            sPlcID = "";

            txtPLCConnectMethod.Text = "";
            txtPLCMaker.Text = "";
            txtPlcName.Text = "";
            btnLogicConvert.Enabled = true;
            wizardControl.SelectedPage = wizardPageStart;
            m_bChangFlag = true;
        }

        private void btnPLCConfig_Click(object sender, EventArgs e)
        {
            if (chkDDEA.Checked && chkLSMaker.Checked)
            {
                ConfigLs();
                m_cPlcConfig.CollectType = EMCollectType.LSDDE;
                m_cPlcLogicData.CollectType = EMCollectType.LSDDE;
            }
            else if (chkDDEA.Checked && chkMelsecMaker.Checked)
            {
                ConfigMelsec();
                m_cPlcConfig.CollectType = EMCollectType.DDEA;
                m_cPlcLogicData.CollectType = EMCollectType.DDEA;
            }
            else
            {
                ConfigOPC();
                m_cPlcConfig.CollectType = EMCollectType.OPC;
                m_cPlcLogicData.CollectType = EMCollectType.OPC;
            }
            m_bPLCConfigCheck = true;
        }

        private void btnLogicConvert_Click(object sender, EventArgs e)
        {
            string sChannel = "";
            if (CMultiProject.PlcLogicDataS.Where(b => b.Value.PlcName == txtPlcName.Text).Count() > 0)
            {
                MessageBox.Show("같은 PLC Name이 존재 합니다. 다시 입력해 주세요");
                return;
            }
            if (chkOPC.Checked == true)
            {
                if (m_cPlcLogicData.CollectType != EMCollectType.OPC) return;
                sChannel = m_cPlcConfig.OPCConfig.ChannelDevice;
            }
            else
            {
                //sChannel = GetUserInputText("Input Tag Header", "Please enter text below...");
                sChannel = m_cPlcLogicData.PLCID;
            }

            if (sChannel == "")
            {
                MessageBox.Show("같은 Channel/Device 입력이 없습니다.");
                return;
            }

            if (CMultiProject.PlcLogicDataS.Values.Where(b => b.PlcChannel == sChannel).Count() > 0)
            {
                MessageBox.Show("같은 Channel/Device가 존재 합니다. 다시 입력해 주세요");
                return;
            }
            m_cPlcLogicData.PlcChannel = sChannel;

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

            bool bOK = false;

            if (chkLSMaker.Checked)
                bOK = ImportPLC(UDM.Common.EMPLCMaker.LS, sChannel);
            else if (chkMelsecMaker.Checked)
                bOK = ImportMelsecPLC(sChannel);
            else if (chkSiemensMaker.Checked)
                bOK = ImportPLC(UDM.Common.EMPLCMaker.Siemens, sChannel);
            else
                bOK = ImportLogic();

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            if (bOK)
            {
                foreach (var who in m_cPlcLogicData.TagS)
                {
                    who.Value.Creator = m_cPlcLogicData.PLCID;
                }
                m_bPLCConvertCheck = true;
                btnLogicConvert.Enabled = false;
            }
            else
            {
                MessageBox.Show("Logic Import Fail!!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.BringToFront();
        }

        private void wizardControl_FinishClick(object sender, CancelEventArgs e)
        {
            m_cPlcLogicData.PlcName = txtPlcName.Text;
            CMultiProject.PlcLogicDataS.Add(m_cPlcLogicData.PLCID, m_cPlcLogicData);
            CMultiProject.PlcConfigS.Add(m_cPlcConfig.PlcID, m_cPlcConfig);
            m_bChangFlag = true;
            btnLogicConvert.Enabled = true;
        }

        private void wizardControl_CancelClick(object sender, CancelEventArgs e)
        {
            if (wizardControl.SelectedPage != wizardPageEnd)
            {
                DialogResult dlgResult = MessageBox.Show("설정을 취소하시겠습니까?", "Add PLC Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
                else
                    return;
            }
        }

        private void wizardControl_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardControl.SelectedPage == wizardPageConfig && m_bPLCConfigCheck == false)
            {
                MessageBox.Show("설정이 완료되지 않았습니다.");
            }
            else if (wizardControl.SelectedPage == wizardPageConvert && txtPlcName.Text == "")
            {
                MessageBox.Show("PLC Name을 입력해 주세요");
            }
            else if (wizardControl.SelectedPage == wizardPageConvert && m_bPLCConvertCheck == false)
            {
                MessageBox.Show("설정이 완료되지 않았습니다.");
            }
            m_bNextFlag = true;
        }

        private void wizardPageStart_PageInit(object sender, EventArgs e)
        {
            if (chkLSMaker.Checked)
            {
                m_cPlcLogicData.Maker = EMPLCMaker.LS;
                m_cPlcConfig.PLCMaker = EMPLCMaker.LS;
            }
            else if (chkSiemensMaker.Checked)
            {
                m_cPlcLogicData.Maker = EMPLCMaker.Siemens;
                m_cPlcConfig.PLCMaker = EMPLCMaker.Siemens;
            }
            else if (chkABMaker.Checked)
            {
                m_cPlcLogicData.Maker = EMPLCMaker.Rockwell;
                m_cPlcConfig.PLCMaker = EMPLCMaker.Rockwell;
            }
            else
            {
                m_cPlcLogicData.Maker = EMPLCMaker.Mitsubishi;
                m_cPlcConfig.PLCMaker = EMPLCMaker.Mitsubishi;
            }
        }

        private void wizardPageConnect_PageInit(object sender, EventArgs e)
        {
            if (chkDDEA.Checked)
            {
                if (chkLSMaker.Checked)
                {
                    m_cPlcLogicData.CollectType = EMCollectType.LSDDE;
                    m_cPlcConfig.CollectType = EMCollectType.LSDDE;
                }
                else
                {
                    m_cPlcLogicData.CollectType = EMCollectType.DDEA;
                    m_cPlcConfig.CollectType = EMCollectType.DDEA;
                }
            }
            else
            {
                m_cPlcConfig.CollectType = EMCollectType.OPC;
                m_cPlcLogicData.CollectType = EMCollectType.OPC;
            }
            if (chkABMaker.Checked || chkSiemensMaker.Checked)
            {
                chkDDEA.Enabled = false;
                chkOPC.Checked = true;
            }
            else
            {
                chkDDEA.Enabled = true;
                chkDDEA.Checked = true;
            }
        }

        private void wizardPage3_PageInit(object sender, EventArgs e)
        {
            if (chkLSMaker.Checked)
                txtPLCMaker.Text = chkLSMaker.Text;
            else if (chkMelsecMaker.Checked)
                txtPLCMaker.Text = chkMelsecMaker.Text;
            else if (chkABMaker.Checked)
                txtPLCMaker.Text = chkABMaker.Text;
            else if (chkSiemensMaker.Checked)
                txtPLCMaker.Text = chkSiemensMaker.Text;
        }

        private void wizardPage2_PageInit(object sender, EventArgs e)
        {
            if (chkDDEA.Checked)
                txtPLCConnectMethod.Text = chkDDEA.Text;
            else if (chkOPC.Checked)
                txtPLCConnectMethod.Text = chkOPC.Text;
        }

        private void wizardControl_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            if (wizardControl.SelectedPage == wizardPageConvert)
            {
                if (sPlcID == "")
                {
                    sPlcID = CMultiProject.CreatePlcId();
                    m_cPlcConfig.PlcID = sPlcID;
                    m_cPlcLogicData.PLCID = sPlcID;
                }
            }
        }

        private void wizardControl_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {

            if (m_bNextFlag && wizardControl.SelectedPage == wizardPageConfig && m_bPLCConfigCheck == false)
            {
                e.Cancel = true;
            }
            else if (m_bNextFlag && wizardControl.SelectedPage == wizardPageConvert && txtPlcName.Text == "")
            {
                e.Cancel = true;
            }
            else if (m_bNextFlag && wizardControl.SelectedPage == wizardPageConvert && m_bPLCConvertCheck == false)
            {
                e.Cancel = true;
            }
            m_bNextFlag = false;
        }

        private void chkLSMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLSMaker.Checked)
                m_cPlcConfig.PLCMaker = EMPLCMaker.LS;
        }

        private void chkMelsecMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMelsecMaker.Checked)
                m_cPlcConfig.PLCMaker = EMPLCMaker.Mitsubishi;
        }

        private void chkABMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkABMaker.Checked)
                m_cPlcConfig.PLCMaker = EMPLCMaker.Rockwell;
        }

        private void chkSiemensMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSiemensMaker.Checked)
                m_cPlcConfig.PLCMaker = EMPLCMaker.Siemens;
        }

        #endregion


    }
}