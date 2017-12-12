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
using UDM.Monitor.Plc.Source.OPC;

namespace UDMPresenter
{
    public partial class FrmPlcSetWizard : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private bool m_bPLCConfigCheck = false;
        private bool m_bPLCConvertCheck = false;
        private bool m_bChangFlag = false;
        private CProject m_cProject = null;

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

        public CProject Project
        {
            set { m_cProject = value; }
        }

        #endregion



        private void ConfigOPC()
        {
            FrmOpcConfig frmProperty = new FrmOpcConfig();
            m_cProject.OpcConfig.LsOpc = chkLSMaker.Checked;
            frmProperty.Project = m_cProject;
            frmProperty.ShowDialog();
        }

        private void ConfigMelsec()
        {
            FrmDDEAProperty frmMelsec = new FrmDDEAProperty();
            frmMelsec.Project = m_cProject;
            frmMelsec.ShowDialog();
        }

        private void ConfigLs()
        {
            FrmLsPlcConfig frmLs = new FrmLsPlcConfig();
            frmLs.Project = m_cProject;
            frmLs.ShowDialog();
        }

        private bool ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker, false);
            if (chkLSMaker.Checked && chkDDEA.Checked)
                cLogic.LsDDEAConnect = true;
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
                m_cProject.TagS = cLogic.GlobalTags;
                m_cProject.StepS = cLogic.StepS;
                CStepExtract.SplitStepS(m_cProject.StepS, m_cProject.TagS);
            }
            else
            {
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel);
                if (cTagS == null)
                    return false;

                m_cProject.TagS = cTagS;
                m_cProject.StepS = GetUsedStep(cLogic.StepS, m_cProject.TagS);
            }

            m_cProject.StepS.Compose(m_cProject.TagS);
            m_cProject.PlcMaker = emPLCMaker;
            return true;
        }


        private bool ImportMelsecPLC(string sChannel)
        {
            CUDLImport cMelsecLogic = new CUDLImport(UDM.Common.EMPLCMaker.Mitsubishi, false);

            if (!cMelsecLogic.FileOpenCheck)
                return false;

            cMelsecLogic.Channel = sChannel;
            bool bOK = cMelsecLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import Melsec Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            m_cProject.TagS = cMelsecLogic.GlobalTags;
            m_cProject.StepS = cMelsecLogic.StepS;

            CStepExtract.SplitStepS(m_cProject.StepS, m_cProject.TagS);

            m_cProject.StepS.Compose(m_cProject.TagS);
            m_cProject.PlcMaker = UDM.Common.EMPLCMaker.Mitsubishi;
            return true;
        }

        private bool ImportLogic()
        {
            CUDLImport cLogic = new CUDLImport(UDM.Common.EMPLCMaker.ALL, false);
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

            m_cProject.TagS = cLogic.GlobalTags;
            m_cProject.StepS = cLogic.StepS;
            CStepExtract.SplitStepS(m_cProject.StepS, m_cProject.TagS);
            m_cProject.PlcMaker = EMPLCMaker.Rockwell;
            m_cProject.StepS.Compose(m_cProject.TagS);

            return true;
        }

        private bool ValidateTag(CTagS cTagS)
        {
            if (cTagS.Count == 0) return false;

            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = new COPCConfig();
            cOPCServer.Config.Use = true;
            cOPCServer.Config.ServerName = m_cProject.OpcConfig.ServerName;
            cOPCServer.Config.ChannelDevice = m_cProject.OpcConfig.ChannelDevice;
            cOPCServer.Config.UpdateRate = m_cProject.OpcConfig.UpdateRate;
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

        private void CreateStepTagList(CProject cProject)
        {
            List<CTag> lstTag = new List<CTag>();
            CStepS cStepS = cProject.StepS;
            CTagS cTagS = cProject.TagS;
            cProject.StepTagList.Clear();

            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    for (int k = 0; k < cStep.CoilS[i].RefTagS.KeyList.Count; k++)
                    {
                        string sKey = cStep.CoilS[i].RefTagS.KeyList[k];
                        if (cTagS.ContainsKey(sKey))
                        {
                            CStepTagList cStepTagList = new CStepTagList();
                            cStepTagList.StepKey = who.Key;
                            cStepTagList.Program = cStep.Program;
                            cStepTagList.StepNumber = cStep.CoilS[i].StepIndex;
                            cStepTagList.NetworkNumber = cStep.StepIndex;
                            cStepTagList.CoilTag = cTagS[sKey];
                            cStepTagList.Command = cStep.CoilS[i].Command;
                            for (int u = 0; u < cStep.RefTagS.KeyList.Count; u++)
                            {
                                sKey = cStep.RefTagS.KeyList[u];
                                if (cTagS.ContainsKey(sKey))
                                {
                                    cStepTagList.ContactTagList.Add(cTagS[sKey]);
                                }
                            }
                            if (cProject.StepTagList.Contains(cStepTagList) == false)
                                cProject.StepTagList.Add(cStepTagList);
                        }
                    }
                }
            }
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

        private void wizardControl_CancelClick(object sender, CancelEventArgs e)
        {
            if (wizardControl.SelectedPage != wizardPageEnd)
            {
                DialogResult dlgResult = MessageBox.Show("설정을 취소하시겠습니까?", "Add PLC Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }

        private void btnPLCConfig_Click(object sender, EventArgs e)
        {
            if (chkDDEA.Checked && chkLSMaker.Checked)
            {
                m_cProject.CollectorType = UDM.Monitor.Plc.Source.EMSourceType.LS;
                ConfigLs();
            }
            else if (chkDDEA.Checked && chkMelsecMaker.Checked)
            {
                m_cProject.CollectorType = UDM.Monitor.Plc.Source.EMSourceType.DDEA;
                ConfigMelsec();
            }
            else
            {
                m_cProject.OpcConfig.LsOpc = chkLSMaker.Checked;
                m_cProject.CollectorType = UDM.Monitor.Plc.Source.EMSourceType.OPC;
                ConfigOPC();
            }
            m_bPLCConfigCheck = true;
        }

        private void btnLogicConvert_Click(object sender, EventArgs e)
        {
            //Check PlcName
            bool bFind = CProjectManager.CheckSameProject(txtPlcName.Text);
            if (bFind)
            {
                MessageBox.Show("같은 이름이 존재합니다. 다시 입력해 주세요");
                return;
            }
            m_cProject.Name = txtPlcName.Text;
            string sChannel = "";
            if (chkOPC.Checked == true)
            {
                sChannel = m_cProject.OpcConfig.ChannelDevice;
            }
            else
                sChannel = GetUserInputText("Input Tag Header", "Please enter text below...");

            if (sChannel == "") return;

            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

            bool bOK = false;

            if (chkLSMaker.Checked)
                bOK = ImportPLC(UDM.Common.EMPLCMaker.LS, sChannel);
            else if (chkMelsecMaker.Checked)
                bOK = ImportMelsecPLC(sChannel);
            else if (chkSiemensMaker.Checked)
                bOK = ImportPLC(UDM.Common.EMPLCMaker.Siemens, sChannel);
            else
                bOK = ImportLogic();

            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            if (bOK)
            {
                foreach (var who in m_cProject.TagS)
                {
                    who.Value.Creator = m_cProject.Name;
                }
                m_bPLCConvertCheck = true;
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

            txtPlcName.Text = m_cProject.Name;
        }

        private void wizardPage2_PageInit(object sender, EventArgs e)
        {
            if (chkDDEA.Checked)
                txtPLCConnectMethod.Text = chkDDEA.Text;
            else if (chkOPC.Checked)
                txtPLCConnectMethod.Text = chkOPC.Text;
        }

        private void wizardControl_FinishClick(object sender, CancelEventArgs e)
        {
            CreateStepTagList(m_cProject);
            CProjectManager.AddProject(m_cProject);
            m_bChangFlag = true;
        }

        private void wizardControl_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            //if (wizardControl.SelectedPage == wizardPageConvert)
            //{
            //    if (sPlcID == "")
            //    {
            //        sPlcID = CMultiProject.CreatePlcId();
            //        m_cPlcConfig.PlcID = sPlcID;
            //        m_cPlcLogicData.PLCID = sPlcID;
            //    }

            //}
        }

        private void wizardControl_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (wizardControl.SelectedPage == wizardPageConfig && m_bPLCConfigCheck == false )
            {
                MessageBox.Show("설정이 완료되지 않았습니다.");
                e.Cancel = true;
            }
            else if (wizardControl.SelectedPage == wizardPageConvert && txtPlcName.Text == "")
            {
                MessageBox.Show("PLC Name을 입력해 주세요");
                e.Cancel = true;
            }
            else if (wizardControl.SelectedPage == wizardPageConvert && m_bPLCConvertCheck == false)
            {
                MessageBox.Show("설정이 완료되지 않았습니다.");
                e.Cancel = true;
            }
        }

        private void btnPlcAdd_Click(object sender, EventArgs e)
        {
            CreateStepTagList(m_cProject);
            CProjectManager.AddProject(m_cProject);
            m_cProject = new CProject();

            m_bPLCConfigCheck = false;
            m_bPLCConvertCheck = false;

            txtPLCConnectMethod.Text = "";
            txtPLCMaker.Text = "";
            txtPlcName.Text = "";

            wizardControl.SelectedPage = wizardPageStart;
            m_bChangFlag = true;

            FrmInputDialog dlgInput = new FrmInputDialog("Input Text", "Please input new project name below..");
            dlgInput.ShowDialog();

            string sText = dlgInput.InputText;
            if (sText == "") return;

            if (CProjectManager.CheckSameProject(sText))
            {
                MessageBox.Show("같은 Name이 존재합니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            m_cProject.Name = sText;

        }

        private void chkLSMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLSMaker.Checked)
                m_cProject.PlcMaker = EMPLCMaker.LS;
        }

        private void chkMelsecMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMelsecMaker.Checked)
                m_cProject.PlcMaker = EMPLCMaker.Mitsubishi;
        }

        private void chkABMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkABMaker.Checked)
                m_cProject.PlcMaker = EMPLCMaker.Rockwell;
        }

        private void chkSiemensMaker_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSiemensMaker.Checked)
                m_cProject.PlcMaker = EMPLCMaker.Siemens;
        }
    }
}