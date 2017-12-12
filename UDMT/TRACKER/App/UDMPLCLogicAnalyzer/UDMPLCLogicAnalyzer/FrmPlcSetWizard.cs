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
using System.Text.RegularExpressions;

namespace UDMPLCLogicAnalyzer
{
    public partial class FrmPlcSetWizard : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private bool m_bPLCConvertCheck = false;
        private bool m_bChangFlag = false;
        private bool m_bNextFlag = false;
        private CPlcLogicData m_cPlcLogicData = new CPlcLogicData();
        private string m_sPlcID = "";

        public event UEventHandlerMessage UEventMessage = null;
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

        private bool ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker, false);

            if (emPLCMaker.Equals(EMPLCMaker.LS))
                cLogic.LsDDEAConnect = false;

            if (!cLogic.FileOpenCheck)
                return false;
            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                XtraMessageBox.Show("Can't Convert Logic", "Import " + emPLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //m_cPlcLogicData.StepS = GetUsedStep(cLogic.StepS, m_cPlcLogicData.TagS);
                m_cPlcLogicData.StepS = cLogic.StepS;
            }

            if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensContactTimerConstant();

            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);
            m_cPlcLogicData.Compose();

            // Contact 으로 쓰인 Timer, Counter에 상수 값 Setting
            //SetContactTimerCounterConstant();

            if(m_cPlcLogicData.TagS.Count != 0)
                m_cPlcLogicData.Maker = m_cPlcLogicData.TagS.First().Value.PLCMaker;

            return true;
        }

        private CCoil GetCoil(CCoilS cCoilS, string sTagKey)
        {
            CCoil cCoil = null;

            foreach (var who in cCoilS)
            {
                if (who.RefTagS.ContainsKey(sTagKey))
                {
                    cCoil = who;
                    break;
                }
            }

            return cCoil;
        }

        private void SetMelsecContactTimerCounterConstant()
        {
            try
            {
                CStepS cContactStepS = new CStepS();
                CStep cContactStep = null;
                CContent cConstantContent = null;

                foreach (
                    CTag cTag in
                        m_cPlcLogicData.TagS.Values.Where(x => x.Address.StartsWith("T") || x.Address.StartsWith("C")))
                {
                    cContactStepS.Clear();
                    cContactStep = null;
                    cConstantContent = null;

                    if (cTag.StepRoleS != null && cTag.StepRoleS.Count > 0)
                    {
                        foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        {
                            if (cTagStepRole.RoleType == EMStepRoleType.Both ||
                                cTagStepRole.RoleType == EMStepRoleType.Coil)
                            {
                                if (!m_cPlcLogicData.StepS.ContainsKey(cTagStepRole.StepKey))
                                    continue;

                                CStep cCoilStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                CCoil cCoil = GetCoil(cCoilStep.CoilS, cTag.Key);

                                if (cCoil == null) continue;

                                if (cCoil.ContentS != null && cCoil.ContentS.Count > 1)
                                    cConstantContent = cCoil.ContentS[1];

                                if (cTagStepRole.RoleType == EMStepRoleType.Both && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                                {
                                    cContactStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                    cContactStepS.Add(cContactStep);
                                }
                            }
                            else if (cTagStepRole.RoleType == EMStepRoleType.Contact && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                            {
                                cContactStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                cContactStepS.Add(cContactStep);
                            }
                        }
                    }

                    if (cConstantContent != null && cContactStepS.Count > 0)
                    {
                        foreach (CStep cStep in cContactStepS.Values)
                        {
                            foreach (CContact cContact in cStep.ContactS)
                            {
                                if (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF")
                                    || cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF"))
                                {
                                    foreach (CContent cContent in cContact.ContentS)
                                    {
                                        if (cContent.Tag != null && cContent.Tag == cTag)
                                        {
                                            cContact.ContentS.Add(cConstantContent);

                                            if (cConstantContent.Tag != null)
                                            {
                                                cContact.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                                cStep.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                cConstantContent = null;
                cContactStep = null;
                cContactStepS.Clear();
                cContactStepS = null;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void SetSiemensContactTimerConstant()
        {
            try
            {
                CStepS cContactStepS = new CStepS();
                CStep cContactStep = null;
                CContent cConstantContent = null;

                foreach (
                    CTag cTag in
                        m_cPlcLogicData.TagS.Values.Where(x => x.Address.StartsWith("T")))
                {
                    cContactStepS.Clear();
                    cContactStep = null;
                    cConstantContent = null;

                    if (cTag.StepRoleS != null && cTag.StepRoleS.Count > 0)
                    {
                        foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        {
                            if (cTagStepRole.RoleType == EMStepRoleType.Both ||
                                cTagStepRole.RoleType == EMStepRoleType.Coil)
                            {
                                if (!m_cPlcLogicData.StepS.ContainsKey(cTagStepRole.StepKey))
                                    continue;

                                CStep cCoilStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                CCoil cCoil = GetCoil(cCoilStep.CoilS, cTag.Key);

                                if (cCoil == null) continue;

                                if (cCoil.ContentS != null && cCoil.ContentS.Count > 1)
                                    cConstantContent = cCoil.ContentS[1];

                                if (cTagStepRole.RoleType == EMStepRoleType.Both && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                                {
                                    cContactStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                    cContactStepS.Add(cContactStep);
                                }
                            }
                            else if (cTagStepRole.RoleType == EMStepRoleType.Contact && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                            {
                                cContactStep = m_cPlcLogicData.StepS[cTagStepRole.StepKey];
                                cContactStepS.Add(cContactStep);
                            }
                        }
                    }

                    if (cConstantContent != null && cContactStepS.Count > 0)
                    {
                        foreach (CStep cStep in cContactStepS.Values)
                        {
                            foreach (CContact cContact in cStep.ContactS)
                            {
                                if (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF")
                                    || cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF"))
                                {
                                    foreach (CContent cContent in cContact.ContentS)
                                    {
                                        if (cContent.Tag != null && cContent.Tag == cTag)
                                        {
                                            cContact.ContentS.Add(cConstantContent);

                                            if (cConstantContent.Tag != null)
                                            {
                                                cContact.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                                cStep.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                cConstantContent = null;
                cContactStep = null;
                cContactStepS.Clear();
                cContactStepS = null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                ex.Data.Clear();
            }
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

            m_cPlcLogicData.TagS = cMelsecLogic.GlobalTags;
            m_cPlcLogicData.StepS = cMelsecLogic.StepS;

            // Contact 으로 쓰인 Timer, Counter에 상수 값 Setting
            SetMelsecContactTimerCounterConstant();

            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);
            m_cPlcLogicData.Compose();

            if (m_cPlcLogicData.TagS.Count != 0)
                m_cPlcLogicData.Maker = m_cPlcLogicData.TagS.First().Value.PLCMaker;

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

            m_cPlcLogicData.TagS = cLogic.GlobalTags;
            m_cPlcLogicData.StepS = cLogic.StepS;
            CStepExtract.SplitStepS(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS);
            m_cPlcLogicData.Maker = EMPLCMaker.Rockwell;
            m_cPlcLogicData.Compose();

            return true;
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

                cTag.Channel = sChannel;

                if (cTag.Description == string.Empty)
                    cTag.Description = cTag.Name;
                else
                    cTag.Description = string.Format("{0} ({1})", cTag.Name, cTag.Description);

                cRetTagS.Add(cTag);
            }

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
            try
            {
                FrmPlcSetWizard_Load(null, null);
                m_cPlcLogicData.PlcName = txtPlcName.Text;
                CProject.PLCLogicDataS.Add(m_cPlcLogicData.PLCID, m_cPlcLogicData);
                
                m_cPlcLogicData = new CPlcLogicData();

                m_bPLCConvertCheck = false;
                m_sPlcID = "";

                txtPLCMaker.Text = "";
                txtPlcName.Text = "";
                btnLogicConvert.Enabled = true;
                wizardControl.SelectedPage = wizardPageStart;
                m_bChangFlag = true;

                FrmPlcSetWizard_Load(null, null);
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnLogicConvert_Click(object sender, EventArgs e)
        {
            try
            {
                string sChannel = "";
                if (CProject.PLCLogicDataS.Where(b => b.Value.PlcName == txtPlcName.Text).Count() > 0)
                {
                    MessageBox.Show("같은 PLC Name이 존재 합니다. 다시 입력해 주세요");
                    return;
                }

                sChannel = m_sPlcID;

                if (CProject.PLCLogicDataS.Values.Where(b => b.PlcChannel == sChannel).Count() > 0)
                {
                    MessageBox.Show("같은 Channel/Device가 존재 합니다. 다시 입력해 주세요");
                    return;
                }
                m_cPlcLogicData.PlcChannel = sChannel;

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);

                bool bOK = false;

                if (chkLSMaker.Checked)
                {
                    bOK = ImportPLC(UDM.Common.EMPLCMaker.LS, sChannel);
                    m_cPlcLogicData.Maker = UDM.Common.EMPLCMaker.LS;
                }
                else if (chkMelsecMaker.Checked)
                {
                    bOK = ImportMelsecPLC(sChannel);
                }
                else if (chkSiemensMaker.Checked)
                {
                    bOK = ImportPLC(UDM.Common.EMPLCMaker.Siemens, sChannel);
                    m_cPlcLogicData.Maker = UDM.Common.EMPLCMaker.Siemens;
                }
                else
                {
                    bOK = ImportPLC(UDM.Common.EMPLCMaker.Rockwell, sChannel);
                    m_cPlcLogicData.Maker = UDM.Common.EMPLCMaker.Rockwell;
                }

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
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardControl_FinishClick(object sender, CancelEventArgs e)
        {
            try
            {
                m_cPlcLogicData.PlcName = txtPlcName.Text;
                CProject.PLCLogicDataS.Add(m_cPlcLogicData.PLCID, m_cPlcLogicData);
                m_bChangFlag = true;
                btnLogicConvert.Enabled = true;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardControl_CancelClick(object sender, CancelEventArgs e)
        {
            try
            {
                if (wizardControl.SelectedPage != wizardPageEnd)
                {
                    DialogResult dlgResult = XtraMessageBox.Show("설정을 취소하시겠습니까?", "Add PLC Information",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                        if (CProject.PLCLogicDataS.ContainsKey(m_cPlcLogicData.PLCID))
                            CProject.PLCLogicDataS.Remove(m_cPlcLogicData.PLCID);
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardControl_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            try
            {
                if (wizardControl.SelectedPage == wizardPageConvert && txtPlcName.Text == "")
                {
                    MessageBox.Show("PLC Name을 입력해 주세요");
                }
                else if (wizardControl.SelectedPage == wizardPageConvert && m_bPLCConvertCheck == false)
                {
                    MessageBox.Show("설정이 완료되지 않았습니다.");
                }
                m_bNextFlag = true;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardPageStart_PageInit(object sender, EventArgs e)
        {
            try
            {
                if (chkLSMaker.Checked)
                {
                    m_cPlcLogicData.Maker = EMPLCMaker.LS;
                }
                else if (chkSiemensMaker.Checked)
                {
                    m_cPlcLogicData.Maker = EMPLCMaker.Siemens;
                }
                else if (chkABMaker.Checked)
                {
                    m_cPlcLogicData.Maker = EMPLCMaker.Rockwell;
                }
                else
                {
                    m_cPlcLogicData.Maker = EMPLCMaker.Mitsubishi;
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardPage3_PageInit(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardControl_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            try
            {
                if (wizardControl.SelectedPage == wizardPageConvert)
                {
                    
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void wizardControl_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            try
            {
                if (m_bNextFlag && wizardControl.SelectedPage == wizardPageConvert && txtPlcName.Text == "")
                {
                    e.Cancel = true;
                }
                else if (m_bNextFlag && wizardControl.SelectedPage == wizardPageConvert && m_bPLCConvertCheck == false)
                {
                    e.Cancel = true;
                }
                m_bNextFlag = false;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmPlcWizard",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion

        private void FrmPlcSetWizard_Load(object sender, EventArgs e)
        {
            if (m_sPlcID == "")
            {
                m_sPlcID = CProject.CreatePlcId();
                m_cPlcLogicData.PLCID = m_sPlcID;
            }
                
            listPLC.Items.Clear();
            
            ShowInitData(CProject.PLCLogicDataS);
            
            txtPlcName.Text = m_sPlcID;
        }

        private void ShowInitData(CPlcLogicDataS cLogicS)
        {
            if (cLogicS.Count > 0)
            {
                switch (cLogicS.Values.First().Maker)
                {
                    case EMPLCMaker.Siemens:
                        chkSiemensMaker.Checked = true;
                        break;
                    case EMPLCMaker.Rockwell:
                        chkABMaker.Checked = true;
                        break;
                    case EMPLCMaker.LS:
                        chkLSMaker.Checked = true;
                        break;
                    default:
                        chkMelsecMaker.Checked = true;
                        break;
                }
                foreach (var who in cLogicS)
                {
                    listPLC.Items.Add(string.Format("▶ {0}", who.Key));
                }
            }
        }
    }
}