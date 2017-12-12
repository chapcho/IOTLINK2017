using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using UDM.UDLImport;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;
using TrackerSPD.LS;
using TrackerSPD.OPC;
using UDM.Flow;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerCreateFlowChart();
    public delegate void UEventHandlerClearFlowChart();
    public partial class FrmModel : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private bool m_bDragDropReady = false;
        private bool m_bFirstSetting = false;
        private CPlcLogicData m_cNewData = null;
        private FrmLadderView m_frmLadderView = null;
        private bool m_bMasterPatternEdit = false;
        private int m_iMainSplitPos = 0;
        private int m_iTreeSplitPos = 0;

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerCreateFlowChart UEventFlowChart = null;
        public event UEventHandlerClearFlowChart UEventClearFlowChart = null;

        #endregion


        #region Initialize

        public FrmModel()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool IsSaveExcute { get; set; }

        public bool IsChangePlcList { get; set; }

        public bool IsMasterPatternEdit
        {
            get { return m_bMasterPatternEdit; }
            set { m_bMasterPatternEdit = value; }
        }

        #endregion


        #region Private Method

        private void ucProcessTree_CandidateKeyDoubleClicked(string sProcess, bool bExpand)
        {
            try
            {
                if (!bExpand)
                {
                    grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                    grdTotalTagS.RefreshDataSource();
                }
                else
                {
                    CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];

                    if (cProcess.CollectCandidateTagS == null)
                    {
                        cProcess.CollectCandidateTagS = new CCollectTagS();
                        return;
                    }

                    List<string> lstKey = cProcess.CollectCandidateTagS.Keys.ToList();

                    grdTotalTagS.DataSource =
                        CMultiProject.TotalTagS.Where(x => lstKey.Contains(x.Key)).Select(x => x.Value).ToList();
                    grdTotalTagS.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
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

        private List<string> ParseLine(string sLine, bool bLower)
        {
            string[] saToken = sLine.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (saToken == null)
                return null;

            List<string> lstLine = new List<string>();
            for (int i = 0; i < saToken.Length; i++)
            {
                if (bLower)
                    lstLine.Add(saToken[i].ToLower());
                else
                    lstLine.Add(saToken[i]);
            }

            return lstLine;
        }

        public CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

            int[] iaRowIndex = grvTotalTagS.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CTag)grvTotalTagS.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        cTagS.Add(cTag.Key, cTag);
                }
            }

            return cTagS;
        }

        private void CreateTreeNodeS()
        {
            TreeListNode trnNode = null;
            CPlcConfig cPLCConfig = null;

            if (CMultiProject.PlcConfigS.Count == 0)
                return;

            RemoveTreeNodeS();

            foreach (var who in CMultiProject.PlcConfigS)
            {
                cPLCConfig = who.Value;
                trnNode = exTreeList.Nodes.Add(new object[] { CMultiProject.PlcLogicDataS[who.Key].PlcName, cPLCConfig.PLCMaker, cPLCConfig.CollectType, CMultiProject.PlcLogicDataS[who.Key].PLCID});

                trnNode.ImageIndex = 0;
                trnNode.SelectImageIndex = 0;
                trnNode.Tag = cPLCConfig;
            }
        }
        
        private void RemoveTreeNodeS()
        {
            exTreeList.Nodes.Clear();
        }

        private void RemoveTreeNode(TreeListNode trnNode)
        {
            CPlcConfig cPLCConfig = null;
            string sPLCID = string.Empty;

            exTreeList.Nodes.Remove(trnNode);

            cPLCConfig = (CPlcConfig) trnNode.Tag;
            if (cPLCConfig == null)
                return;

            sPLCID = cPLCConfig.PlcID;

            CMultiProject.PlcLogicDataS.Remove(sPLCID);
            CMultiProject.PlcConfigS.Remove(sPLCID);
            List<string> lstRemovePlcProcess = new List<string>();

            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                if(cProcess.PlcLogicDataS.ContainsKey(sPLCID))
                    lstRemovePlcProcess.Add(cProcess.Name);
            }

            foreach (string sProcessKey in lstRemovePlcProcess)
            {
                CMultiProject.PlcProcS.Remove(sProcessKey);

                if (CMultiProject.MasterPatternS != null && CMultiProject.MasterPatternS.ContainsKey(sProcessKey))
                    CMultiProject.MasterPatternS.Remove(sProcessKey);
            }

            List<CTag> lstRemoveRobotTag = CMultiProject.ProjectInfo.RobotCycleTagS.Values.Where(b=>b.Creator == sPLCID).ToList();
            foreach (CTag tag in lstRemoveRobotTag)
                CMultiProject.ProjectInfo.RobotCycleTagS.Remove(tag.Key);

            List<CUserDevice> lstRemoveUserDevice = CMultiProject.UserDeviceS.Values.Where(b => b.Tag.Creator == sPLCID).ToList();

            foreach (CUserDevice dev in lstRemoveUserDevice)
                CMultiProject.UserDeviceS.Remove(dev.Tag.Key);

            ucProcessTree.Clear();
            ucProcessTree.ShowTree();

            CMultiProject.TotalTagS.Clear();
            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                CMultiProject.TotalTagS.AddRange(who.Value.TagS);
            }

            SetUsedCoil();

            grdTotalTagS.DataSource = null;
            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            grdRobotCycle.DataSource = null;
            grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
            grdRobotCycle.RefreshDataSource();

            grdUserAll.DataSource = null;
            grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
            grdUserAll.RefreshDataSource();
        }

        private void ConfigOPC(CPlcConfig cConfig)
        {
            FrmOPCProperty frmProperty = new FrmOPCProperty();
            frmProperty.Editable = true;
            frmProperty.OPCConfig = cConfig.OPCConfig;
            frmProperty.ShowDialog();
            if(frmProperty.IsChanged)
            {
                IsChangePlcList = true; // PLC 변경 시 IsChangePlcList 변경
            }
        }

        private void ConfigMelsec(CPlcConfig cConfig)
        {
            FrmDDEAProperty frmMelsec = new FrmDDEAProperty(cConfig.MelsecConfig);
            frmMelsec.ShowDialog();
            if (frmMelsec.IsDataChange)
            {
                cConfig.MelsecConfig = frmMelsec.Config;
                IsChangePlcList = true; // PLC 변경 시 IsChangePlcList 변경
            }

        }

        private void ConfigLs(CPlcConfig cConfig)
        {
            FrmLsPlcConfig frmLs = new FrmLsPlcConfig(cConfig.LsConfig);
            frmLs.ShowDialog();
            if (frmLs.ChangeConfig)
            {
                frmLs.LsConfig.Use = true;
                cConfig.LsConfig = frmLs.LsConfig;
                IsChangePlcList = true; // PLC 변경 시 IsChangePlcList 변경
            }

        }

        private void ucProcessTree_ProcessDoubleClicked(object sender, string sProcessKey)
        {
            //FrmCycleSelection frmProess = new FrmCycleSelection();

            //frmProess.PageSelect = true;
            //frmProess.SelectedPageName = sProcessKey;
            //frmProess.ShowDialog();
        }

        private void UpdateProcessTree()
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                ucProcessTree.Clear();

                if (CMultiProject.PlcProcS.Count != 0)
                {
                    ucProcessTree.ShowTree();
                    TabTable.SelectedTabPage = tpProcess;

                    IsSaveExcute = true;
                }
            }
            SplashScreenManager.CloseDefaultSplashScreen();
        }

        private void InitFilter()
        {
            txtDescriptionFilter.EditValue += "이상\r\n";
            txtDescriptionFilter.EditValue += "NG\r\n";
            txtDescriptionFilter.EditValue += "에러\r\n";
            txtDescriptionFilter.EditValue += "FAULT\r\n";
            txtDescriptionFilter.EditValue += "ABNORMAL\r\n";
            txtDescriptionFilter.EditValue += "ERROR\r\n";
            txtDescriptionFilter.EditValue += "ERR\r\n";
            txtDescriptionFilter.EditValue += "안전\r\n";
            txtDescriptionFilter.EditValue += "SAFE\r\n";
            txtDescriptionFilter.EditValue += "비상\r\n";
            txtDescriptionFilter.EditValue += "WARNING\r\n";
            txtDescriptionFilter.EditValue += "ALARM\r\n";
            txtDescriptionFilter.EditValue += "OVER\r\n";
            txtDescriptionFilter.EditValue += "TRIP\r\n";
            txtDescriptionFilter.EditValue += "트립\r\n";
            txtDescriptionFilter.EditValue += "고장\r\n";
            txtDescriptionFilter.EditValue += "OFF\r\n";
            txtDescriptionFilter.EditValue += "과부하\r\n";
            txtDescriptionFilter.EditValue += "STOP\r\n";
            txtDescriptionFilter.EditValue += "UNMATC\r\n";
            txtDescriptionFilter.EditValue += "불일치\r\n";
            txtDescriptionFilter.EditValue += "GATE\r\n";
            txtDescriptionFilter.EditValue += "비기동\r\n";
            txtDescriptionFilter.EditValue += "비가동\r\n";
            txtDescriptionFilter.EditValue += "차단\r\n";
            //txtDescriptionFilter.EditValue += "교환\r\n";
            txtDescriptionFilter.EditValue += "불량\r\n";
            //txtDescriptionFilter.EditValue += "부하\r\n";
            //txtDescriptionFilter.EditValue += "감지\r\n";
            //txtDescriptionFilter.EditValue += "확인\r\n";
            //txtDescriptionFilter.EditValue += "체크\r\n";
            //txtDescriptionFilter.EditValue += "CHK\r\n";
            txtDescriptionFilter.EditValue += "정상\r\n";
            txtDescriptionFilter.EditValue += "지연\r\n";
            txtDescriptionFilter.EditValue += "NORMAL\r\n";
            txtDescriptionFilter.EditValue += "STOP";
            txtDescriptionFilter.EditValue += "AUX";

            CMultiProject.AbnormalFilter = GetAbnormalFilter();
        }

        private List<string> GetAbnormalFilter()
        {
            List<string> lstAbnormalFilter = ParseLine(txtDescriptionFilter.EditValue.ToString(), false);

            return lstAbnormalFilter;
        }

        private void FrmCycleSelection_UpdateSystemMessage(string sSender, string sMessage)
        {
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private void SetUsedCoil()
        {
            if (CMultiProject.TotalTagS.Count == 0)
                return;

            foreach (CTag cTag in CMultiProject.TotalTagS.Values)
            {
                if (cTag.StepRoleS != null)
                {
                    if (cTag.StepRoleS.Count != 0)
                    {
                        cTag.UseOnlyInLogic = true;
                        foreach (CTagStepRole cRole in cTag.StepRoleS)
                        {
                            if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                            {
                                cTag.IsHMIMapping = true;
                                break;
                            }
                        }
                    }
                    else //Not Used
                        cTag.UseOnlyInLogic = false;
                }
            }
        }

        private bool CheckTagRole(CTag cTag)
        {
            bool bOK = true;
            string sMessage = string.Empty;

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.KeySymbolS.ContainsKey(cTag.Key))
                {
                    sMessage = string.Format("해당 {0} 태그는 {1} 공정의 KeySymbol에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address, who.Value.Name);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                    break;
                }

                //if (who.Value.SubKeySymbolS.ContainsKey(cTag.Key))
                //{
                //    sMessage = string.Format("해당 {0} 태그는 {1} 공정의 SubKeySymbol에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address, who.Value.Name);
                //    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    bOK = false;
                //    break;
                //}

                if (who.Value.AbnormalSymbolS.ContainsKey(cTag.Key))
                {
                    sMessage = string.Format("해당 {0} 태그는 {1} 공정의 AbnormalSymbol에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address, who.Value.Name);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                    break;
                }

                if (who.Value.RecipeWordS.ContainsKey(cTag.Key))
                {
                    sMessage = string.Format("해당 {0} 태그는 {1} 공정의 RecipeWordS에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address, who.Value.Name);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                    break;
                }
            }

            if (bOK)
            {
                if (CMultiProject.ProjectInfo.RobotCycleTagS.ContainsKey(cTag.Key))
                {
                    sMessage = string.Format("해당 {0} 태그는 RobotCycle 태그에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }
                else if (CMultiProject.UserDeviceS.ContainsKey(cTag.Key))
                {
                    sMessage = string.Format("해당 {0} 태그는 UserDevice 태그에 포함되어있는 태그이기 때문에 지울 수 없습니다.", cTag.Address);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                }
            }

            return bOK;
        }

        private Dictionary<string, CTagS> GetTagSDistributedPlc(int[] arrRows)
        {
            Dictionary<string, CTagS> dicTagS = new Dictionary<string, CTagS>();
            object obj = null;
            CTagS cTagS = null;
            CTag cTag = null;

            for (int i = 0; i < arrRows.Length; i++)
            {
                obj = grvTotalTagS.GetRow(arrRows[i]);

                if (obj.GetType() != typeof(CTag))
                    continue;

                cTag = (CTag)obj;

                if (dicTagS.ContainsKey(cTag.Creator))
                {
                    cTagS = dicTagS[cTag.Creator];
                    cTagS.Add(cTag.Key, cTag);
                }
                else
                {
                    cTagS = new CTagS();
                    cTagS.Add(cTag.Key, cTag);
                    dicTagS.Add(cTag.Creator, cTagS);
                }
            }

            return dicTagS;
        }

        private void ValidateTag(int[] arrRows)
        {
            try
            {
                Dictionary<string, CTagS> dicTagS = GetTagSDistributedPlc(arrRows);
                List<string> lstErrorTagKey = new List<string>();
                CPlcConfig cConfig = null;

                foreach (var who in dicTagS)
                {
                    if (CMultiProject.PlcConfigS.ContainsKey(who.Key))
                    {
                        cConfig = CMultiProject.PlcConfigS[who.Key];

                        if (cConfig.CollectType.Equals(EMCollectType.OPC))
                            lstErrorTagKey.AddRange(ValidateOPC(cConfig, who.Value));
                    }
                }

                if (lstErrorTagKey.Count > 0)
                {
                    XtraMessageBox.Show("선택하신 " + arrRows.Length.ToString("n0") + "개의 태그 중 " + lstErrorTagKey.Count.ToString("n0") + "개의 태그가 수집 불가합니다.", "Validate Check", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    FrmTagValidateErrorView frmView = new FrmTagValidateErrorView();
                    frmView.lstErrorTagKey = lstErrorTagKey;
                    frmView.ShowDialog();

                    frmView.Dispose();
                    frmView = null;
                }
                else
                    XtraMessageBox.Show("선택하신 모든 태그가 수집 유효합니다.", "Validate Check", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                dicTagS.Clear();
                dicTagS = null;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private List<string> ValidateOPC(CPlcConfig cConfig, CTagS cTagS)
        {
            List<string> lstError = new List<string>();

            try
            {
                COPCServer cOPCServer = new COPCServer();
                cOPCServer.Config = new COPCConfig();
                cOPCServer.Config.Use = true;
                cOPCServer.Config.ABOpc = cConfig.OPCConfig.ABOpc;
                cOPCServer.Config.LsOpc = cConfig.OPCConfig.LsOpc;
                cOPCServer.Config.ServerName = cConfig.OPCConfig.ServerName;
                cOPCServer.Config.ChannelDevice = cConfig.OPCConfig.ChannelDevice;
                cOPCServer.Config.UpdateRate = cConfig.OPCConfig.UpdateRate;

                bool bOK = cOPCServer.Connect();

                if (bOK)
                {
                    List<string> lstResult = cOPCServer.ValidateItemS(cTagS.Values.ToList());
                    if (lstResult != null && lstResult.Count != 0)
                        lstError.AddRange(lstResult);
                }
                else
                    XtraMessageBox.Show("OPC Server가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);


                cOPCServer.Disconnect();
                cOPCServer.Dispose();
                cOPCServer = null;
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel ValidateOPC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return lstError;
        }

        private bool CheckErrorMonitoringProcess()
        {
            bool bOK = false;
            string sProcess = string.Empty;

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.TotalAbnormalSymbolKey != string.Empty && who.Value.CycleCheckTag == null)
                {
                    bOK = true;
                    sProcess += string.Format("{0},", who.Key);
                }
            }

            if (bOK)
                XtraMessageBox.Show(
                    "ERROR TAG가 등록된 공정은 ERROR RST TAG가 반드시 등록되어야 합니다.\r\n\'" + sProcess +
                    "\' 공정의 ERROR RST TAG가 등록되지 않았습니다.\r\nERROR RST TAG를 등록해주세요!!", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            return bOK;
        }

        private void UpdatePLCProgram(string sPlcID)
        {
            try
            {
                CPlcLogicData cData = CMultiProject.PlcLogicDataS[sPlcID];
                CPlcLogicData cNewData = null;
                List<CPLCUpdateView> lstView = null;

                if (cData == null)
                    return;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    cNewData = GetNewPlcLogicData(cData.Maker, cData.PlcChannel, sPlcID);

                    if (cNewData != null)
                    {
                        foreach (var who in cNewData.TagS)
                            who.Value.Creator = sPlcID;

                        m_cNewData = cNewData;
                        m_cNewData.PlcChannel = cData.PlcChannel;
                        m_cNewData.PLCID = sPlcID;
                        m_cNewData.PlcName = cData.PlcName;

                        lstView = CheckTagInformationRealtedPLC(sPlcID);
                        CheckDataRelatedPLCLogicDataS(cData, cNewData, lstView);
                        //CheckStepInformationRelatedPLC(sPlcID, lstView);
                    }
                }
                SplashScreenManager.CloseForm(false);

                if (cNewData != null)
                {
                    FrmUpdateResult frmResult = new FrmUpdateResult();
                    frmResult.lstView = lstView;
                    frmResult.TopMost = true;

                    if (frmResult.ShowDialog() == DialogResult.OK)
                    {
                        SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                        {
                            UpdateDataRelatedPLCLogicDataS(cData, cNewData);
                            UpdateTagInformationRealtedPLC();

                            UpdateFrmModel();
                        }
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UpdateFrmModel()
        {
            grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
            grdRobotCycle.RefreshDataSource();

            SetUsedCoil();

            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
            grdUserAll.RefreshDataSource();

            ucProcessTree.Clear();
            ucProcessTree.ShowTree();
        }

        private void CheckStepInformationRelatedPLC(string sPlcID, List<CPLCUpdateView> lstView )
        {
            CPLCUpdateView cView = null;

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (!who.Value.PlcLogicDataS.ContainsKey(sPlcID))
                    continue;

                if (who.Value.TotalAbnormalSymbolKey == string.Empty)
                    continue;

                int iOldCount = who.Value.AbnormalSymbolS.Count;

                if (m_cNewData.TagS.ContainsKey(who.Value.TotalAbnormalSymbolKey))
                {
                    CPlcProc cProcess = new CPlcProc();

                    CTagS cTagS = new CTagS();
                    cTagS.Add(m_cNewData.TagS[who.Value.TotalAbnormalSymbolKey]);
                    cProcess.AbnormalFilter = CMultiProject.AbnormalFilter;
                    cProcess.AddAbnormalSymbolS(cTagS);
                    cProcess.UpdateKeySymbolS();

                    int iNewCount = cProcess.AbnormalSymbolS.Count;

                    if (iOldCount != iNewCount)
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 2;
                        cView.Sender = who.Value.Name;
                        cView.Message = string.Format("Abnormal Symbol 개수 변경 : {0}개 -> {1}개", iOldCount, iNewCount);

                        lstView.Add(cView);
                    }

                    cProcess.Clear();
                    cProcess = null;
                }
                else
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = who.Value.Name;
                    cView.Message = string.Format("Abnormal Symbol 삭제!, Address : {0}, Description {1}", CMultiProject.TotalTagS[who.Value.TotalAbnormalSymbolKey].Address, CMultiProject.TotalTagS[who.Value.TotalAbnormalSymbolKey].Description);

                    lstView.Add(cView);
                }
            }
        }

        private List<CPLCUpdateView> CheckTagInformationRealtedPLC(string sPLCID)
        {
            List<CPLCUpdateView> lstView = new List<CPLCUpdateView>();

            try
            {
                CPLCUpdateView cView = null;

                CheckProjectBaseInfo(lstView);
                CheckProcess(lstView, sPLCID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return lstView;
        }

        public void UpdateTagInformationRealtedPLC()
        {
            UpdateProjectBaseInfo();
            UpdateProcess();
        }

        private void UpdateProjectBaseInfo()
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            UpdateUserDevice();
            UpdateRobotCycle();

            //TeamInfo
        }

        private void UpdateUserDevice()
        {
            if (CMultiProject.UserDeviceS.Count == 0)
                return;

            List<string> lstKey = CMultiProject.UserDeviceS.Keys.ToList();

            CMultiProject.UserDeviceS.Clear();
            //UserDevice
            foreach (string sKey in lstKey)
            {
                if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    CMultiProject.UserDeviceS.Add(sKey, new CUserDevice(CMultiProject.TotalTagS[sKey]));
            }
        }

        private void UpdateRobotCycle()
        {
            List<string> lstAddKey = new List<string>();

            if (CMultiProject.ProjectInfo.RobotCycleTagS == null || CMultiProject.ProjectInfo.RobotCycleTagS.Count == 0)
                return;

            List<string> lstKey = CMultiProject.ProjectInfo.RobotCycleTagS.Keys.ToList();

            CMultiProject.ProjectInfo.RobotCycleTagS.Clear();

            foreach (string sKey in lstKey)
            {
                if(CMultiProject.TotalTagS.ContainsKey(sKey))
                    CMultiProject.ProjectInfo.RobotCycleTagS.Add(sKey, CMultiProject.TotalTagS[sKey]);
            }
        }

        private void UpdateProcess()
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                //if (!who.Value.PlcLogicDataS.ContainsKey(sPLCID))
                //    continue;

                UpdateCycleStartEndConditionS(who.Value);
                //UpdateChartTagS(who.Value);
                UpdateKeySymbolS(who.Value);
                UpdateAbnormalSymbolS(who.Value);
                UpdateRecipeWordS(who.Value);
                UpdateMasterPatternS(who.Value);
                //UpdateFlowChartItemS(who.Value);
            }
        }

        private void UpdateCycleStartEndConditionS(CPlcProc cProcess)
        {
            List<int> lstRemoveIndex = new List<int>();

            //Cycle Start
            foreach (var who in cProcess.CycleStartConditionS)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(who.Key))
                    lstRemoveIndex.Add(cProcess.CycleStartConditionS.IndexOf(who));
            }

            foreach (int iIndex in lstRemoveIndex)
                cProcess.CycleStartConditionS.RemoveAt(iIndex);

            lstRemoveIndex.Clear();
            //cProcess.StartCompareCondition = null;

            //if (cProcess.CycleStartConditionS.Count != 0)
            //    cProcess.StartCompareCondition = cProcess.CycleStartConditionS.First();

            foreach (var who in cProcess.CycleEndConditionS)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(who.Key))
                    lstRemoveIndex.Add(cProcess.CycleEndConditionS.IndexOf(who));
            }

            foreach (int iIndex in lstRemoveIndex)
                cProcess.CycleEndConditionS.RemoveAt(iIndex);

            lstRemoveIndex.Clear();
            //cProcess.EndCompareCondition = null;

            //if (cProcess.CycleEndConditionS.Count != 0)
            //    cProcess.EndCompareCondition = cProcess.CycleEndConditionS.First();

            if (cProcess.CycleCheckTag != null)
            {
                string sKey = cProcess.CycleCheckTag.Key;
                cProcess.CycleCheckTag = null;

                if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    cProcess.CycleCheckTag = CMultiProject.TotalTagS[sKey];
            }
        }

        private void UpdateChartTagS(CPlcProc cProcess)
        {
            List<string> lstAddKey = new List<string>();

            if (cProcess.ChartViewTagS == null)
            {
                cProcess.ChartViewTagS = new CTagS();
                return;
            }

            foreach (var who in cProcess.ChartViewTagS)
            {
                if (IsContainNewData(who.Key))
                    lstAddKey.Add(who.Key);
            }

            cProcess.ChartViewTagS.Clear();

            foreach (string sKey in lstAddKey)
                cProcess.ChartViewTagS.Add(m_cNewData.TagS[sKey]);
        }

        private void UpdateKeySymbolS(CPlcProc cProcess)
        {
            CKeySymbol cKeySymbol = null;

            if (cProcess.IsErrorMonitoring || cProcess.KeySymbolS.Count == 0)
                return;

            List<string> lstKeySymbolS = cProcess.KeySymbolS.Keys.ToList();

            cProcess.KeySymbolS.Clear();
            if(cProcess.ChartViewTagS != null)
                cProcess.ChartViewTagS.Clear();
            else
                cProcess.ChartViewTagS = new CTagS();

            foreach (string sKeySymbol in lstKeySymbolS)
            {
                if (CMultiProject.TotalTagS.ContainsKey(sKeySymbol))
                {
                    cKeySymbol = new CKeySymbol(CMultiProject.TotalTagS[sKeySymbol]);
                    cProcess.KeySymbolS.Add(sKeySymbol, cKeySymbol);

                    if (!cProcess.ChartViewTagS.ContainsKey(sKeySymbol))
                        cProcess.ChartViewTagS.Add(sKeySymbol, CMultiProject.TotalTagS[sKeySymbol]);
                }
            }

            cProcess.UpdateKeySymbolS();
        }

        private void UpdateAbnormalSymbolS(CPlcProc cProcess)
        {
            if (cProcess.AbnormalSymbolS.Count == 0 || cProcess.TotalAbnormalSymbolKey == string.Empty)
                return;

            string sTotalAbnormalKey = cProcess.TotalAbnormalSymbolKey;

            if (!CMultiProject.TotalTagS.ContainsKey(sTotalAbnormalKey))
                cProcess.RemoveAbnormalInfo();
            else
            {
                cProcess.AbnormalFilter = CMultiProject.AbnormalFilter;
                cProcess.AbnormalSymbolS.Clear();

                cProcess.ComposeAbnormalSymbolS(CMultiProject.TotalTagS[sTotalAbnormalKey]);
                cProcess.UpdateAbnormalSymbolS();
                CMultiProject.UpdatePlcProcHierarchyAbnormalSymbolS();
            }
        }

        private void UpdateRecipeWordS(CPlcProc cProcess)
        {
            List<string> lstAddKey = new List<string>();

            if (cProcess.RecipeWordS.Count != 0)
            {
                foreach (var who in cProcess.RecipeWordS)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(who.Key))
                        lstAddKey.Add(who.Key);
                }

                cProcess.RecipeWordS.Clear();

                foreach (string sAddKey in lstAddKey)
                    cProcess.RecipeWordS.Add(sAddKey, CMultiProject.TotalTagS[sAddKey]);
            }

            if (cProcess.SelectRecipeWord == null)
                return;

            string sKey = cProcess.SelectRecipeWord.Key;
            cProcess.SelectRecipeWord = null;

            if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                return ;
             else
                cProcess.SelectRecipeWord = CMultiProject.TotalTagS[sKey];
        }

        private void UpdateMasterPatternS(CPlcProc cProcess)
        {
            List<string> lstRemoveKey = new List<string>();

            if (CMultiProject.MasterPatternS.Count == 0 || !CMultiProject.MasterPatternS.ContainsKey(cProcess.Name))
                return;

            CMasterPattern cPattern = CMultiProject.MasterPatternS[cProcess.Name];

            foreach (var recipe in cPattern)
            {
                foreach (var shape in recipe.Value)
                {
                    foreach (var Item in shape.FlowItemS)
                    {
                        if (!CMultiProject.TotalTagS.ContainsKey(Item.Key))
                            lstRemoveKey.Add(Item.Key);
                    }

                    m_bMasterPatternEdit = true;

                    foreach (string sKey in lstRemoveKey)
                        shape.FlowItemS.Remove(sKey);

                    lstRemoveKey.Clear();
                }
            }
        }

        private void UpdateFlowChartItemS(CPlcProc cProcess)
        {
            List<int> lstRemoveIndex = new List<int>();

            if (cProcess.RecipeFlowItemS == null || cProcess.RecipeFlowItemS.Count == 0)
                return;

            foreach (var who in cProcess.RecipeFlowItemS)
            {
                foreach (var who2 in who.Value)
                {
                    if (!IsContainNewData(who2.Value.Key))
                        lstRemoveIndex.Add(who2.Key);
                }

                foreach (int iIndex in lstRemoveIndex)
                    who.Value.Remove(iIndex);

                lstRemoveIndex.Clear();
            }
        }

        private bool CheckProjectBaseInfo(List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            bOK = CheckUserDevice(lstView);

            if (bOK)
            {
                cView = new CPLCUpdateView();
                cView.ImageIndex = 0;
                cView.Sender = "User Device";
                cView.Message = "Update Success!!!";
                lstView.Add(cView);
            }

            bOK = CheckRobotCycle(lstView);

            if (bOK)
            {
                cView = new CPLCUpdateView();
                cView.ImageIndex = 0;
                cView.Sender = "Robot Cycle";
                cView.Message = "Update Success!!!";
                lstView.Add(cView);
            }

            cView = null;

            //TeamInfo

            return bOK;
        }

        private bool CheckUserDevice(List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (CMultiProject.UserDeviceS.Count == 0)
                return false;

            //UserDevice
            foreach (var who in CMultiProject.UserDeviceS)
            {
                if (!IsContainNewData(who.Key))
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = "User Device";
                    cView.Message =
                        string.Format("기존 User Device \'Address : {0}, Description : {1}\'에 대한 태그가 존재하지 않습니다.",
                            who.Value.Address, who.Value.Name);
                    lstView.Add(cView);
                    bOK = false;
                }
            }

            cView = null;

            return bOK;
        }

        private bool IsContainNewData(string sTagKey)
        {
            bool bOK = true;

            if (!CMultiProject.TotalTagS.ContainsKey(sTagKey))
                bOK = false;
            else
            {
                CTag cTag = CMultiProject.TotalTagS[sTagKey];
                string sPlcChannel = cTag.Channel;
                string sNewPlcChannel = m_cNewData.PlcChannel;

                if (sPlcChannel != sNewPlcChannel)
                    bOK = true;
                else
                {
                    if (!m_cNewData.TagS.ContainsKey(sTagKey))
                        bOK = false;
                }
            }

            return bOK;
        }

        private bool IsOnlyContainNewData(string sTagKey)
        {
            bool bOK = false;

            if (m_cNewData.TagS.ContainsKey(sTagKey))
                bOK = true;

            return bOK;
        }

        private bool CheckRobotCycle(List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (CMultiProject.ProjectInfo.RobotCycleTagS == null || CMultiProject.ProjectInfo.RobotCycleTagS.Count == 0)
                return false;

            //Robot Cycle
            foreach (var who in CMultiProject.ProjectInfo.RobotCycleTagS)
            {
                if (!IsContainNewData(who.Key))
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = "Robot Cycle";
                    cView.Message =
                        string.Format("기존 Robot Cycle \'Address : {0}, Description : {1}\'에 대한 태그가 존재하지 않습니다.",
                            who.Value.Address,
                            who.Value.Description == string.Empty ? who.Value.Name : who.Value.Description);
                    lstView.Add(cView);

                    bOK = false;
                }
            }

            cView = null;

            return bOK;
        }

        private bool CheckProcess(List<CPLCUpdateView> lstView, string sPLCID)
        {
            bool bOK = true;
            try
            {
                bool bSuccess = true;
                CPLCUpdateView cView = null;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    bSuccess = true;

                    //if (!who.Value.PlcLogicDataS.ContainsKey(sPLCID))
                    //    continue;

                    bOK = CheckCycleStartEndConditionS(who.Value, lstView);

                    if (!bOK)
                        bSuccess = false;

                    bOK = CheckKeySymbolS(who.Value, lstView);

                    if (!bOK)
                        bSuccess = false;

                    bOK = CheckAbnormalSymbolS(who.Value, lstView);

                    if (!bOK)
                        bSuccess = false;

                    bOK = CheckRecipeWordS(who.Value, lstView);

                    if (!bOK)
                        bSuccess = false;

                    bOK = CheckMasterPatternS(who.Value, lstView);

                    if (!bOK)
                        bSuccess = false;

                    //bOK = CheckFlowChartItemS(who.Value, lstView);

                    //if (!bOK)
                    //    bSuccess = false;

                    if (bSuccess)
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 0;
                        cView.Sender = who.Value.Name;
                        cView.Message = "Update Successs!!!";

                        lstView.Add(cView);
                    }
                }

                cView = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private bool CheckCycleStartEndConditionS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            //Cycle Start
            foreach (var who in cProcess.CycleStartConditionS)
            {
                if (!IsContainNewData(who.Key))
                {
                    if (CMultiProject.TotalTagS.ContainsKey(who.Key))
                    {
                        CTag cTag = CMultiProject.TotalTagS[who.Key];

                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle 시작 조건 \'Address = {0}, Description = {1}\'가 존재하지 않습니다.",
                            who.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                        cTag = null;
                    }
                    else
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle 시작 조건 \'Key = {0}\'가 존재하지 않습니다.", who.Key);
                    }

                    lstView.Add(cView);
                    bOK = false;
                }
            }

            foreach (var who in cProcess.CycleEndConditionS)
            {
                if (!IsContainNewData(who.Key))
                {
                    if (CMultiProject.TotalTagS.ContainsKey(who.Key))
                    {
                        CTag cTag = CMultiProject.TotalTagS[who.Key];

                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle 끝 조건 \'Address = {0}, Description = {1}\'가 존재하지 않습니다.",
                            who.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                        cTag = null;
                    }
                    else
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle 끝 조건 \'Key = {0}\'가 존재하지 않습니다.", who.Key);
                    }

                    lstView.Add(cView);
                    bOK = false;
                }
            }


            if (cProcess.CycleCheckTag != null)
            {
                string sKey = cProcess.CycleCheckTag.Key;

                if (!IsContainNewData(sKey))
                {
                    if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message =
                            string.Format("Cycle Check Tag \'Address = {0}, Description = {1}\'가 존재하지 않습니다.",
                                CMultiProject.TotalTagS[sKey].Address,
                                CMultiProject.TotalTagS[sKey].Description == string.Empty
                                    ? CMultiProject.TotalTagS[sKey].Name
                                    : CMultiProject.TotalTagS[sKey].Description);
                    }
                    else
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle Check Tag \'Key = {0}\'가 존재하지 않습니다.", sKey);
                    }

                    lstView.Add(cView);
                    bOK = false;
                }
            }


            cView = null;

            return bOK;
        }

        private bool CheckKeySymbolS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (cProcess.IsErrorMonitoring || cProcess.KeySymbolS.Count == 0)
                return true;

            List<string> lstKeySymbolS = cProcess.KeySymbolS.Keys.ToList();

            foreach (string sKeySymbol in lstKeySymbolS)
            {
                if (!IsContainNewData(sKeySymbol))
                {
                    if (CMultiProject.TotalTagS.ContainsKey(sKeySymbol))
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Key Symbol \'Address = {0}, Description = {1}\'가 존재하지 않습니다.",
                            CMultiProject.TotalTagS[sKeySymbol].Address,
                            CMultiProject.TotalTagS[sKeySymbol].Description == string.Empty
                                ? CMultiProject.TotalTagS[sKeySymbol].Name
                                : CMultiProject.TotalTagS[sKeySymbol].Description);
                    }
                    else
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Key Symbol \'Key = {0}\'가 존재하지 않습니다.", sKeySymbol);
                    }

                    lstView.Add(cView);
                    bOK = false;
                }
            }

            return bOK;
        }

        private bool CheckAbnormalSymbolS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (cProcess.AbnormalSymbolS.Count == 0)
                return true;

            string sTotalAbnormalKey = cProcess.TotalAbnormalSymbolKey;

            if (sTotalAbnormalKey == string.Empty)
            {
                cProcess.RemoveAbnormalInfo();
                return true;
            }

            int iOldCount = cProcess.AbnormalSymbolS.Count;

            if (!IsContainNewData(sTotalAbnormalKey))
            {
                if (CMultiProject.TotalTagS.ContainsKey(sTotalAbnormalKey))
                {
                    CTag cTag = CMultiProject.TotalTagS[sTotalAbnormalKey];

                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = cProcess.Name;
                    cView.Message =
                        string.Format(
                            "새로운 PLC 프로그램에 Total Abnormal Symbol \'Address = {0}, Description = {1}\'가 존재하지 않습니다.",
                            cTag.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                    cTag = null;
                }
                else
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = cProcess.Name;
                    cView.Message = string.Format("Total Abnormal Symbol \'Key = {0}\'가 존재하지 않습니다.", sTotalAbnormalKey);
                }

                lstView.Add(cView);
                bOK = false;
            }
            else if(m_cNewData.TagS.ContainsKey(sTotalAbnormalKey))
            {
                CPlcProc cTempProcess = new CPlcProc();

                CTagS cTagS = new CTagS();
                cTagS.Add(m_cNewData.TagS[sTotalAbnormalKey]);
                cTempProcess.AbnormalFilter = CMultiProject.AbnormalFilter;
                cTempProcess.AddAbnormalSymbolS(cTagS);
                cTempProcess.UpdateKeySymbolS();

                int iNewCount = cTempProcess.AbnormalSymbolS.Count;

                if (iOldCount != iNewCount)
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 2;
                    cView.Sender = cProcess.Name;
                    cView.Message = string.Format("Abnormal Symbol 개수 변경 : {0}개 -> {1}개", iOldCount, iNewCount);

                    lstView.Add(cView);
                    bOK = false;
                }

                cTempProcess.Clear();
                cTempProcess = null;
            }

            return bOK;
        }

        private bool CheckRecipeWordS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (cProcess.RecipeWordS.Count != 0)
            {
                foreach (var who in cProcess.RecipeWordS)
                {
                    if (!IsContainNewData(who.Key))
                    {
                        if (CMultiProject.TotalTagS.ContainsKey(who.Key))
                        {
                            CTag cTag = CMultiProject.TotalTagS[who.Key];

                            cView = new CPLCUpdateView();
                            cView.ImageIndex = 1;
                            cView.Sender = cProcess.Name;
                            cView.Message = string.Format(
                                "Recipe Word \'Address : {0}, Description = {1}\'가 존재하지 않습니다.", cTag.Address,
                                cTag.Description == string.Empty ? cTag.Name : cTag.Description);
                        }
                        else
                        {
                            cView = new CPLCUpdateView();
                            cView.ImageIndex = 1;
                            cView.Sender = cProcess.Name;
                            cView.Message = string.Format("Recipe Word \'Key = {0}\'가 존재하지 않습니다.", who.Key);
                        }

                        lstView.Add(cView);
                        bOK = false;
                    }
                }
            }

            if (cProcess.SelectRecipeWord != null)
            {
                string sKey = cProcess.SelectRecipeWord.Key;

                if (!IsContainNewData(sKey))
                {
                    if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    {
                        CTag cTag = CMultiProject.TotalTagS[sKey];

                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Recipe Word \'Address : {0}, Description : {1}\'가 존재하지 않습니다.",
                            cTag.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);
                    }
                    else
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Recipe Word \'Key = {0}\'가 존재하지 않습니다.", sKey);
                    }

                    lstView.Add(cView);
                    bOK = false;
                }
            }

            return bOK;
        }

        private bool CheckMasterPatternS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (CMultiProject.MasterPatternS.Count == 0 || !CMultiProject.MasterPatternS.ContainsKey(cProcess.Name))
                return true;

            CMasterPattern cPattern = CMultiProject.MasterPatternS[cProcess.Name];

            foreach (var recipe in cPattern)
            {
                foreach (var shape in recipe.Value)
                {
                    foreach (var Item in shape.FlowItemS)
                    {
                        if (!IsContainNewData(Item.Key))
                        {
                            if (CMultiProject.TotalTagS.ContainsKey(Item.Key))
                            {
                                CTag cTag = CMultiProject.TotalTagS[Item.Key];

                                cView = new CPLCUpdateView();
                                cView.ImageIndex = 1;
                                cView.Sender = cProcess.Name;
                                cView.Message =
                                    string.Format(
                                        "Master Pattern \'Recipe : {0}, 형태 : {1}, Address : {2}, Description : {3}\'가 존재하지 않습니다.",
                                        recipe.Key, shape.Key, cTag.Address,
                                        cTag.Description == string.Empty ? cTag.Name : cTag.Description);
                            }
                            else
                            {
                                cView = new CPLCUpdateView();
                                cView.ImageIndex = 1;
                                cView.Sender = cProcess.Name;
                                cView.Message =
                                    string.Format(
                                        "Master Pattern \'Recipe : {0}, 형태 : {1}, Key : {2}\'가 존재하지 않습니다.", recipe.Key, shape.Key, Item.Key);
                            }

                            lstView.Add(cView);
                            bOK = false;
                        }
                    }
                }
            }

            return bOK;
        }

        private bool CheckFlowChartItemS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            if (cProcess.RecipeFlowItemS == null || cProcess.RecipeFlowItemS.Count == 0)
                return true;

            foreach (var who in cProcess.RecipeFlowItemS)
            {
                foreach (var who2 in who.Value)
                {
                    if (!IsContainNewData(who2.Value.Key))
                    {
                        if (CMultiProject.TotalTagS.ContainsKey(who2.Value.Key))
                        {
                            CTag cTag = CMultiProject.TotalTagS[who2.Value.Key];

                            cView = new CPLCUpdateView();
                            cView.ImageIndex = 1;
                            cView.Sender = cProcess.Name;
                            cView.Message =
                                string.Format(
                                    "Flow Item \'Recipe : {0}, Address : {1}, Description : {2}\'가 존재하지 않습니다.", who.Key,
                                    cTag.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);
                        }
                        else
                        {
                            cView = new CPLCUpdateView();
                            cView.ImageIndex = 1;
                            cView.Sender = cProcess.Name;
                            cView.Message =
                                string.Format(
                                    "Flow Item \'Recipe : {0}, Key : {1}\'가 존재하지 않습니다.", who.Key, who2.Value.Key);
                        }

                        lstView.Add(cView);
                        bOK = false;
                    }
                }
            }

            return bOK;
        }

        private void CheckDataRelatedPLCLogicDataS(CPlcLogicData cData, CPlcLogicData cNewData,
            List<CPLCUpdateView> lstView)
        {
            CPLCUpdateView cView = null;

            cView = new CPLCUpdateView();
            cView.ImageIndex = 2;
            cView.Sender = "TAG";
            cView.Message = string.Format("PLC : \'{0}\' 태그 개수 : {1} -> {2}", cData.PlcName, cData.TagS.Count.ToString("n0"),
                cNewData.TagS.Count.ToString("n0"));

            lstView.Add(cView);

            cView = new CPLCUpdateView();
            cView.ImageIndex = 2;
            cView.Sender = "STEP";
            cView.Message = string.Format("PLC : \'{0}\' 스텝 개수 : {1} -> {2}", cData.PlcName, cData.StepS.Count.ToString("n0"),
                cNewData.StepS.Count.ToString("n0"));

            lstView.Add(cView);
        }

        private void UpdateDataRelatedPLCLogicDataS(CPlcLogicData cData, CPlcLogicData cNewData)
        {
            cData.TagS.Clear();
            cData.StepS.Clear();
            CMultiProject.TotalTagS.Clear();

            cData.TagS = cNewData.TagS;
            cData.StepS = cNewData.StepS;

            foreach (var who in CMultiProject.PlcLogicDataS)
                CMultiProject.TotalTagS.AddRange(who.Value.TagS);
        }

        private CPlcLogicData GetNewPlcLogicData(EMPLCMaker emPLCMaker, string sChannel, string sPlcID)
        {
            CPlcLogicData cData = null;

            CUDLImport cLogic = new CUDLImport(emPLCMaker, false);

            if (emPLCMaker.Equals(EMPLCMaker.LS))
                cLogic.LsDDEAConnect = false;

            if (!cLogic.FileOpenCheck)
                return null;

            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                XtraMessageBox.Show("Can't Convert Logic", "Import " + emPLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            cData = new CPlcLogicData();

            if (emPLCMaker != EMPLCMaker.Siemens)
            {
                cData.TagS = cLogic.GlobalTags;
                cData.StepS = cLogic.StepS;

                if(emPLCMaker.ToString().Contains("Mitsubishi"))
                    SetMelsecContactTimerCounterConstant(cData);
            }
            else
            {
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel, sPlcID);
                if (cTagS == null)
                    return null;

                cData.TagS = cTagS;
                cData.StepS = cLogic.StepS;
                //cData.StepS = GetUsedStep(cLogic.StepS, cData.TagS);

                SetSiemensContactTimerConstant(cData);
            }

            CStepExtract.SplitStepS(cData.StepS, cData.TagS);
            cData.Compose();

            return cData;
        }

        private void SetMelsecContactTimerCounterConstant(CPlcLogicData cData)
        {
            try
            {
                CStepS cContactStepS = new CStepS();
                CStep cContactStep = null;
                CContent cConstantContent = null;

                foreach (
                    CTag cTag in
                        cData.TagS.Values.Where(x => x.Address.StartsWith("T") || x.Address.StartsWith("C")))
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
                                if (!cData.StepS.ContainsKey(cTagStepRole.StepKey))
                                    continue;

                                CStep cCoilStep = cData.StepS[cTagStepRole.StepKey];
                                CCoil cCoil = GetCoil(cCoilStep.CoilS, cTag.Key);

                                if (cCoil == null) continue;

                                if (cCoil.ContentS != null && cCoil.ContentS.Count > 1)
                                    cConstantContent = cCoil.ContentS[1];

                                if (cTagStepRole.RoleType == EMStepRoleType.Both && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                                {
                                    cContactStep = cData.StepS[cTagStepRole.StepKey];
                                    cContactStepS.Add(cContactStep);
                                }
                            }
                            else if (cTagStepRole.RoleType == EMStepRoleType.Contact && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                            {
                                cContactStep = cData.StepS[cTagStepRole.StepKey];
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
            }
        }

        private void SetSiemensContactTimerConstant(CPlcLogicData cData)
        {
            try
            {
                CStepS cContactStepS = new CStepS();
                CStep cContactStep = null;
                CContent cConstantContent = null;

                foreach (
                    CTag cTag in
                        cData.TagS.Values.Where(x => x.Address.StartsWith("T")))
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
                                if (!cData.StepS.ContainsKey(cTagStepRole.StepKey))
                                    continue;

                                CStep cCoilStep = cData.StepS[cTagStepRole.StepKey];
                                CCoil cCoil = GetCoil(cCoilStep.CoilS, cTag.Key);

                                if (cCoil == null) continue;

                                if (cCoil.ContentS != null && cCoil.ContentS.Count > 1)
                                    cConstantContent = cCoil.ContentS[1];

                                if (cTagStepRole.RoleType == EMStepRoleType.Both && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                                {
                                    cContactStep = cData.StepS[cTagStepRole.StepKey];
                                    cContactStepS.Add(cContactStep);
                                }
                            }
                            else if (cTagStepRole.RoleType == EMStepRoleType.Contact && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                            {
                                cContactStep = cData.StepS[cTagStepRole.StepKey];
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

        private bool ValidateTag(CTagS cTagS, string sPLCID)
        {
            if (cTagS.Count == 0) return false;

            CPlcConfig cConfig = CMultiProject.PlcConfigS[sPLCID];

            if (cConfig == null)
                return false;

            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = cConfig.OPCConfig;
            cOPCServer.Config.Use = true;

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
                    }
                    //sDeleteTag = string.Format("수집 불가능한 Tag : {0}ea", lstResult.Count);
                    //XtraMessageBox.Show(sDeleteTag);

                    if (cTagS.Count == 0)
                        XtraMessageBox.Show("변환된 Tag가 없습니다. OPC 설정이나 입력한 Channel.Device정보가 틀렸을 수 있습니다.\r\n확인하세요.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private CTagS GetUsedTagS(CTagS cTagS, string sChannel, string sPLCID)
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


                cTag.Channel = sChannel;

                if (cTag.Description == string.Empty)
                    cTag.Description = cTag.Name;
                else
                    cTag.Description = string.Format("{0} ({1})", cTag.Name, cTag.Description);

                cRetTagS.Add(cTag);
            }

            bool bOK = ValidateTag(cRetTagS, sPLCID);
            if (!bOK) return null;

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

        private void FrmMasterPatternUpdate_MasterPatternGenerateEvent(bool bOK)
        {
            try
            {
                if (bOK)
                {
                    CMultiProject.MasterStep = EMMonitorModeType.UpdateEnd;

                    m_bMasterPatternEdit = true;

                    ShowEditMasterPattern();

                    //if (UEventFlowChart != null)
                    //    UEventFlowChart();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void ShowEditMasterPattern()
        {
            FrmMasterPatternEditor frmEditor = new FrmMasterPatternEditor();
            frmEditor.TopMost = true;
            frmEditor.Show();
        }

        private bool CheckContainCoilTag(CCoil cCoil, CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cCoil.ContentS)
            {
                if (who.Tag != null && who.Tag.Key == cTag.Key)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckProcessSelctRecipeWord()
        {
            bool bOK = true;

            try
            {
                string sProcess = string.Empty;
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.RecipeWordS.Count > 0 && who.Value.SelectRecipeWord == null)
                    {
                        sProcess += string.Format("{0},", who.Key);
                        bOK = false;
                    }
                }

                if (!bOK)
                {
                    sProcess = sProcess.Substring(0, sProcess.Length - 1);

                    if (
                        XtraMessageBox.Show(
                            "\'" + sProcess +
                            "\' 공정의 Recipe Word 중 View Recipe Word가 선택되지 않았습니다.\r\nView Recipe Word가 선택되어야 해당 공정의 생산 Recipe를 직접 모니터링 할 수 있습니다.\r\n그래도 창을 종료하시겠습니까?",
                            "Exclamation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        bOK = true;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel", ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }


        #endregion


        #region Public Method

        #endregion


        #region Form Event

        private void FrmModel_Load(object sender, EventArgs e)
        {
            try
            {
                IsChangePlcList = false;
                IsSaveExcute = false;

                if (CMultiProject.ProjectName == "")
                {
                    string sName = GetUserInputText("Input Project Name", "Please enter text below...");
                    if (sName != "")
                    {
                        CMultiProject.Create(sName);
                        btnAddPlc_ItemClick(null, null);
                    }
                    else
                    {
                        XtraMessageBox.Show("Name 입력이 없습니다. 창을 닫습니다.", "UDM Tracker", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        this.Close();
                    }
                }

                if (CMultiProject.MasterPatternS == null)
                    CMultiProject.MasterPatternS = new CMasterPatternS();

                if (CMultiProject.LearningStep == EMMonitorModeType.None)
                    m_bFirstSetting = true;

                CreateTreeNodeS();
                InitFilter();

                if (CMultiProject.PlcProcS.Count != 0)
                    ucProcessTree.ShowTree();

                grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
                grdRobotCycle.RefreshDataSource();

                SetUsedCoil();

                grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();

                grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                grdUserAll.RefreshDataSource();

                m_frmLadderView = new FrmLadderView();
                m_frmLadderView.TopMost = true;

                chkRecipeUpdate.Checked = CMultiProject.IsAutoUpdateRecipe;
                spnCycleCount.EditValue = CMultiProject.RecipeUpdateCount;
                chkAbnormalPriority.Checked = CMultiProject.IsApplyAbnormalPriority;
                spnCollectDepth.EditValue = CMultiProject.ProjectInfo.CollectSymbolSubDepth;
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    cProcess.CollectSubDepth = CMultiProject.ProjectInfo.CollectSymbolSubDepth;

                ucProcessTree.UEventCandidateKeyDoubleClicked += ucProcessTree_CandidateKeyDoubleClicked;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CheckErrorMonitoringProcess())
                {
                    e.Cancel = true;
                    return;
                }

                bool bOK = false;

                if (!CheckProcessSelctRecipeWord())
                {
                    e.Cancel = true;
                    return;
                }

                if (CMultiProject.PlcProcS.Count > 0)
                {
                    foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    {
                        if (cProcess.IsErrorMonitoring)
                            continue;

                        if (cProcess.KeySymbolS != null && cProcess.KeySymbolS.Count != 0 &&
                            cProcess.CycleStartConditionS.Count > 0 && cProcess.CycleEndConditionS.Count > 0)
                            bOK = true;
                        else if (cProcess.CollectCandidateTagS != null && cProcess.CollectCandidateTagS.Count != 0 &&
                                 cProcess.CycleStartConditionS.Count > 0 && cProcess.CycleEndConditionS.Count > 0)
                            bOK = true;
                        else
                        {
                            bOK = false;
                            break;
                        }
                    }

                    if (bOK)
                        CMultiProject.LearningStep = EMMonitorModeType.UpdateEnd;
                    else
                    {
                        if (!m_bFirstSetting)
                        {
                            DialogResult dlgResult = XtraMessageBox.Show("아직 설정이 완료되지 않은 Process가 있습니다. 이대로 종료하시겠습니까?",
                                "UDM Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgResult == System.Windows.Forms.DialogResult.No)
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                        else
                        {
                            bool bCollectTagExist = false;
                            string sOptimizeProcess = string.Empty;
                            string sProcess = string.Empty;
                            foreach (var who in CMultiProject.PlcProcS)
                            {
                                if (who.Value.IsErrorMonitoring)
                                    continue;

                                if (who.Value.CollectCandidateTagS != null && who.Value.CollectCandidateTagS.Count > 0)
                                {
                                    if (who.Value.CycleStartConditionS.Count == 0 ||
                                        who.Value.CycleEndConditionS.Count == 0)
                                    {
                                        bCollectTagExist = true;
                                        sOptimizeProcess = string.Format("{0},", who.Key);
                                    }
                                }

                                if (who.Value.KeySymbolS == null || who.Value.KeySymbolS.Count == 0)
                                    sProcess += string.Format("{0},", who.Key);
                            }

                            if (bCollectTagExist)
                            {
                                sOptimizeProcess = sOptimizeProcess.Substring(0, sOptimizeProcess.Length - 1);

                                DialogResult dlgResult =
                                    XtraMessageBox.Show("\'" +
                                                        sOptimizeProcess +
                                                        "\'공정의 CANDIDATE KEY는 정의 되었으나 CYCLE START/END가 정의되지 않았습니다.\r\n해당 공정의 CYCLE START/END가 정의되어야 수집 최적화 작업이 진행 가능합니다.\r\n이대로 종료하시겠습니까?",
                                        "UDM Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlgResult == System.Windows.Forms.DialogResult.No)
                                    e.Cancel = true;
                            }
                            else
                            {
                                if (sProcess != string.Empty)
                                {
                                    sProcess = sProcess.Substring(0, sProcess.Length - 1);

                                    DialogResult dlgResult =
                                        XtraMessageBox.Show("\'" +
                                                            sProcess +
                                                            "공정\'의 Key Symbol이 정의되지 않았습니다.\r\n해당 공정의 Key Symbol이 정의되어야 PLC 데이터 수집이 가능합니다.\r\n이대로 종료하시겠습니까?",
                                            "UDM Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dlgResult == System.Windows.Forms.DialogResult.No)
                                        e.Cancel = true;
                                }
                            }
                        }
                    }
                }

                if (ucProcessTree.IsProcessEdit)
                    this.IsSaveExcute = true;

                if (CMultiProject.MasterPatternS == null)
                    CMultiProject.MasterPatternS = new CMasterPatternS();

                if (CMultiProject.MasterPatternS.Count ==
                    CMultiProject.PlcProcS.Where(x => x.Value.IsErrorMonitoring == false).Count())
                    CMultiProject.MasterStep = EMMonitorModeType.UpdateEnd;
                else
                    CMultiProject.MasterStep = EMMonitorModeType.None;

                if (m_bMasterPatternEdit)
                {
                    if (UEventFlowChart != null)
                        UEventFlowChart();
                }

                if (m_frmLadderView != null)
                {
                    m_frmLadderView.Dispose();
                    m_frmLadderView = null;
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("현재 프로젝트 정보를 모두 Clear합니다.\r\nClear하게 되면 모든 프로젝트의 정보가 지워집니다.\r\n그래도 Clear 작업을 진행하시겠습니까?", "Project Clear",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string sName = GetUserInputText("Input Project Name", "Please enter text below...");
                if (sName != "")
                {
                    IsChangePlcList = false;
                    IsSaveExcute = false;

                    if (UEventClearFlowChart != null)
                        UEventClearFlowChart();

                    CMultiProject.Create(sName);
                    CMultiProject.ProjectPath = "";
                    chkRecipeUpdate.Checked = CMultiProject.IsAutoUpdateRecipe;
                    spnCycleCount.EditValue = CMultiProject.RecipeUpdateCount;
                    chkAbnormalPriority.Checked = CMultiProject.IsApplyAbnormalPriority;
                    spnCollectDepth.EditValue = CMultiProject.ProjectInfo.CollectSymbolSubDepth;

                    exTreeList.Nodes.Clear();
                    ucProcessTree.Clear();

                    grdTotalTagS.DataSource = null;
                    grdTotalTagS.RefreshDataSource();

                    grdUserAll.DataSource = null;
                    grdUserAll.RefreshDataSource();

                    grdRobotCycle.DataSource = null;
                    grdRobotCycle.RefreshDataSource();

                    btnAddPlc_ItemClick(null, null);

                    if (IsChangePlcList)
                    {
                        if (CMultiProject.LearningStep == EMMonitorModeType.None)
                            m_bFirstSetting = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show("취소되었습니다.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnFilterApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //CMultiProject.AddressFilter = GetAddressFilter();
                CMultiProject.AbnormalFilter = GetAbnormalFilter();
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnAddPlc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmPlcSetWizard frmWizard = new FrmPlcSetWizard();
                frmWizard.UEventMessage += FrmCycleSelection_UpdateSystemMessage;
                frmWizard.ShowDialog();

                if (CMultiProject.PlcLogicDataS.Count > 0 && frmWizard.ChangeFlag)
                {
                    CMultiProject.TotalTagS.Clear();
                    CMultiProject.PlcIDList.Clear();
                    foreach (var who in CMultiProject.PlcLogicDataS)
                    {
                        CMultiProject.TotalTagS.AddRange(who.Value.TagS);
                        CMultiProject.PlcIDList.Add(who.Key);
                    }

                    SetUsedCoil();

                    grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                    grdTotalTagS.RefreshDataSource();

                    //PLC Node 추가
                    if (CMultiProject.PlcConfigS.Count != 0)
                    {
                        CreateTreeNodeS();
                        TabTable.SelectedTabPage = tpPLC;
                    }
                    IsSaveExcute = true;
                    IsChangePlcList = true;
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }

        }

        private void grvUserAll_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void grdUserAll_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdUserAll_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof (CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                    if (cTagS != null)
                    {
                        List<CUserDevice> lstViewData = new List<CUserDevice>();
                        if (grdUserAll.DataSource != null)
                            lstViewData = (List<CUserDevice>) grdUserAll.DataSource;

                        CTag cTag;
                        for (int i = 0; i < cTagS.Count; i++)
                        {
                            cTag = cTagS[i];

                            if (CMultiProject.UserDeviceS.ContainsKey(cTag.Key) == false)
                            {
                                CUserDevice cUser = new CUserDevice();
                                cUser.Tag = cTag;

                                CMultiProject.UserDeviceS.Add(cTag.Key, cUser);
                                lstViewData.Add(cUser);
                            }
                        }
                        grdUserAll.DataSource = lstViewData;
                        grdUserAll.RefreshDataSource();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdRobotCycle_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdRobotCycle_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof (CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                    if (cTagS != null)
                    {
                        if (CMultiProject.ProjectInfo.RobotCycleTagS == null)
                            CMultiProject.ProjectInfo.RobotCycleTagS = new CTagS();
                        CMultiProject.ProjectInfo.RobotCycleTagS.AddRange(cTagS);

                        grdRobotCycle.DataSource = null;
                        grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
                        grdRobotCycle.RefreshDataSource();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvRobotCycle_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabUserSet.SelectedTabPageIndex == 0)
                {
                    int[] iaRowIndex = grvUserAll.GetSelectedRows();
                    if (iaRowIndex != null)
                    {
                        for (int i = 0; i < iaRowIndex.Length; i++)
                        {
                            CUserDevice cDevice = (CUserDevice) grvUserAll.GetRow(iaRowIndex[i]);
                            if (CMultiProject.UserDeviceS.ContainsKey(cDevice.Tag.Key))
                                CMultiProject.UserDeviceS.Remove(cDevice.Tag.Key);
                        }
                        grdUserAll.DataSource = null;
                        grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                        grdUserAll.RefreshDataSource();
                    }
                }
                else
                {
                    int[] iaRowIndex = grvRobotCycle.GetSelectedRows();
                    if (iaRowIndex != null)
                    {
                        for (int i = 0; i < iaRowIndex.Length; i++)
                        {
                            CTag cRobotTag = (CTag) grvRobotCycle.GetRow(iaRowIndex[i]);
                            if (CMultiProject.ProjectInfo.RobotCycleTagS.ContainsKey(cRobotTag.Key))
                                CMultiProject.ProjectInfo.RobotCycleTagS.Remove(cRobotTag.Key);

                        }
                        grdRobotCycle.DataSource = null;
                        grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
                        grdRobotCycle.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void grvTotalTagS_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                if (grvTotalTagS.FocusedColumn == colAddress)
                {
                    TextEdit edit = grvTotalTagS.ActiveEditor as TextEdit;
                    edit.Properties.CharacterCasing = CharacterCasing.Upper;
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_bDragDropReady)
            {
                CTagS cTagS = GetSelectedTagS();
                if (cTagS == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                grdTotalTagS.DoDragDrop(cTagS, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void grvTotalTagS_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                m_bDragDropReady = false;

                GridView exView = sender as GridView;
                GridHitInfo exHitInfo = exView.CalcHitInfo(new Point(e.X, e.Y));
                if (exHitInfo.InColumnPanel)
                    return;

                if (Control.ModifierKeys != Keys.None)
                    return;

                m_bDragDropReady = true;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            /*if (e.Column == colGroup)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].GroupKey + ";";

                e.Value = sText;
            }
            else if (e.Column == colGroupRoleType)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].RoleType.ToString() + ";";

                e.Value = sText;
            }
            else if (e.Column == colStepRoleType)
            {
                if (e.Row == null)
                    return;

                CTag cTag = (CTag)e.Row;
                if (cTag.IsEndContact())
                    e.Value = "Contact";
                else
                    e.Value = "Coil";
            }*/
        }

        private void grdTotalTagS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdTotalTagS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof (CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                    if (cTagS != null)
                    {
                        List<CTag> lstViewData = (List<CTag>) grdTotalTagS.DataSource;

                        CTag cTag;
                        for (int i = 0; i < cTagS.Count; i++)
                        {
                            cTag = cTagS[i];
                            if (CMultiProject.TotalTagS.ContainsKey(cTag.Key) == false)
                            {
                                CMultiProject.TotalTagS.Add(cTag.Key, cTag);
                                lstViewData.Add(cTag);
                            }
                        }

                        grdTotalTagS.RefreshDataSource();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;
                if (trnNode != null)
                {
                    CPlcConfig cConfig = (CPlcConfig) trnNode.Tag;

                    if (cConfig != null)
                    {
                        if (cConfig.CollectType == EMCollectType.DDEA)
                            ConfigMelsec(cConfig);
                        else if (cConfig.CollectType == EMCollectType.LSDDE)
                            ConfigLs(cConfig);
                        else if (cConfig.CollectType == EMCollectType.OPC)
                            ConfigOPC(cConfig);
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuPLCChangeConfig_Click(object sender, EventArgs e)
        {
            exTreeList_MouseDoubleClick(null, null);
        }

        private void mnuDeletePLC_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (
                    XtraMessageBox.Show("선택하신 " + trnNode.GetDisplayText(colPLCName) + " PLC를 제거하시겠습니까?", "Delete PLC",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (trnNode != null)
                {
                    RemoveTreeNode(trnNode);
                    IsChangePlcList = true; // PLC 삭제 시 IsChangePlcList 변경
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnProcessSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmCycleSelection frmProcess = new FrmCycleSelection();
                frmProcess.UEventMessage += FrmCycleSelection_UpdateSystemMessage;
                frmProcess.ShowDialog();

                UpdateProcessTree();

                frmProcess.UEventMessage -= FrmCycleSelection_UpdateSystemMessage;
                frmProcess.Dispose();
                frmProcess = null;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuRenamePLC_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;
                string sPLCID = string.Empty;
                string sNewPLCName = string.Empty;

                if (trnNode != null)
                {
                    CPlcConfig cConfig = (CPlcConfig) trnNode.Tag;
                    sPLCID = cConfig.PlcID;

                    if (cConfig != null)
                    {
                        sNewPLCName = GetUserInputText("Input PLC Name", "Please enter text below...");

                        if (sNewPLCName != string.Empty)
                        {
                            CMultiProject.PlcLogicDataS[sPLCID].PlcName = sNewPLCName;
                            trnNode.SetValue(colPLCName, sNewPLCName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnRecipeSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmCarType frmRecipe = new FrmCarType();
                frmRecipe.ShowDialog();
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnProcessAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmInputProcess frmProcess = new FrmInputProcess();
                frmProcess.ShowDialog();

                UpdateProcessTree();
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView) sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            //GridHitInfo info = view.CalcHitInfo(pt);
            //object oData = view.GetRow(info.RowHandle);
            //if (oData == null) return;
            //if (oData.GetType() != typeof(CTag)) return;
            //CTag cTag = (CTag)oData;

            //if (cTag == null)
            //    return;

            //FrmLadderView frmLadder = new FrmLadderView();
            //frmLadder.MasterTag = cTag;
            //frmLadder.LogicData = CMultiProject.PlcLogicDataS[cTag.Creator];
            //frmLadder.TopMost = true;
            //frmLadder.Show();
        }

        private void btnErrorMonitoringAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string sName = GetUserInputText("이상 신호 Monitoring", "Monitoring 할 이상 신호에 대한 이름을 설정하세요.");

                if (sName != string.Empty)
                {
                    if (!CMultiProject.PlcProcS.ContainsKey(sName))
                    {
                        CPlcProc cErrorProcess = new CPlcProc();
                        cErrorProcess.Name = sName;
                        cErrorProcess.IsErrorMonitoring = true;

                        CMultiProject.PlcProcS.Add(cErrorProcess.Name, cErrorProcess);

                        UpdateProcessTree();
                    }
                    else
                        XtraMessageBox.Show("해당 이름은 이미 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTagAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTagAddProperty frmTagProperty = new FrmTagAddProperty();
                DialogResult dlgResult = frmTagProperty.ShowDialog();

                if (dlgResult == DialogResult.OK)
                {
                    CTag cTag = frmTagProperty.Tag;

                    CMultiProject.TotalTagS.Add(cTag.Key, cTag);
                    CMultiProject.PlcLogicDataS[frmTagProperty.PlcID].TagS.Add(cTag.Key, cTag);

                    grdTotalTagS.DataSource = null;
                    grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                    grdTotalTagS.RefreshDataSource();
                }

                frmTagProperty.Dispose();
                frmTagProperty = null;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnTagDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] arrRow = grvTotalTagS.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                    return;

                string sMessage = string.Format("선택하신 {0}개의 태그를 제거하시겠습니까?", arrRow.Length);
                if (XtraMessageBox.Show(sMessage, "Delete Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                    return;

                CTag cTag = null;
                for (int i = 0; i < arrRow.Length; i++)
                {
                    cTag = (CTag) grvTotalTagS.GetRow(arrRow[i]);

                    if (CheckTagRole(cTag))
                    {
                        CMultiProject.TotalTagS.Remove(cTag.Key);
                        CMultiProject.PlcLogicDataS[cTag.Creator].TagS.Remove(cTag.Key);
                    }
                }
                grdTotalTagS.DataSource = null;
                grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnValidateCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int[] arrRows = grvTotalTagS.GetSelectedRows();

                if (arrRows == null || arrRows.Length < 1)
                    return;

                if (arrRows.Length > 0)
                {
                    if (
                        XtraMessageBox.Show("선택하신 " + arrRows.Length.ToString("n0") + "개의 태그에 대한 수집 유효성 검사를 진행하시겠습니까?",
                            "Validate Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                ValidateTag(arrRows);
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnUpdatePLCProgram_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (trnNode == null)
                    return;

                if (
                    XtraMessageBox.Show("선택하신 " + trnNode.GetDisplayText(colPLCName) + " PLC의 프로그램을 Update 하시겠습니까?", "Update PLC Program",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                CPlcConfig cPLCConfig = (CPlcConfig)trnNode.Tag;
                if (cPLCConfig == null)
                    return;

                UpdatePLCProgram(cPLCConfig.PlcID);
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell) && cTag.Address.Contains(".DN"))
            {
                string sKey = cTag.Key.Replace(".DN", string.Empty);

                if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    cTag = CMultiProject.TotalTagS[sKey];
            }

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if(cLogic.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(cLogic.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = cLogic.StepS[who.StepKey];
                        
                        if(cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                            lstStep.Add(cStep);
                    }
                }
            }

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.ShowDialog();

                    if (frmSelector.IsSelectStep)
                    {
                        cStep = frmSelector.GetSelectedStep();
                    }

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            else
            {

                XtraMessageBox.Show("해당 접점은 출력 접점으로 사용되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return cStep;
        }

        private void btnViewMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CMultiProject.MasterPatternS == null || CMultiProject.MasterPatternS.Count == 0)
                {
                    XtraMessageBox.Show("Master Pattern이 생성되지 않았습니다.\r\nMaster Pattern을 먼저 생성해 주세요.",
                        "View Master Pattern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmMasterPatternEditor frmEditor = new FrmMasterPatternEditor();
                frmEditor.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnCreateMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CMultiProject.MasterPatternS == null)
                    CMultiProject.MasterPatternS = new CMasterPatternS();

                FrmMasterPatternCycleSelector frmEditor = new FrmMasterPatternCycleSelector();
                frmEditor.ShowDialog();

                if (frmEditor.IsMasterPatternEdit)
                    m_bMasterPatternEdit = true;

                frmEditor.Dispose();
                frmEditor = null;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void cboSelectedCreateMaster_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //object obj = cboSelectedCreateMaster.EditValue;

                //if (obj == null)
                //    return;

                //string sName = (string)obj;



                //if (XtraMessageBox.Show("\'" + sName + "\'공정의 Master Pattern을 생성하시겠습니까?", "개별 공정 MasterPattern 생성", MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question) == DialogResult.No)
                //    return;

                //CMultiProject.SystemLog.WriteLog("\'" + sName + "\'공정 MastarPattern", "생성요청");

                //FrmMasterPatternUpdate frmMasterpattern = new FrmMasterPatternUpdate();
                //frmMasterpattern.UMasterPatternGenerateEvent += FrmMasterPatternUpdate_MasterPatternGenerateEvent;
                //frmMasterpattern.IsIndividual = true;
                //frmMasterpattern.IndividualProcessName = sName;
                //frmMasterpattern.TopMost = true;

                //frmMasterpattern.SetDescription("\'" + sName + "\' 공정 Master Pattern 자동 생성 중입니다.");
                //frmMasterpattern.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnAllCreateMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                {
                    XtraMessageBox.Show("공정이 존재하지 않습니다.\r\n공정 설정 및 공정 데이터 수집을 먼저 진행해주세요.", "UDM Tracker",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (XtraMessageBox.Show("Master Pattern을 생성하시겠습니까?\r\n기존 Master Pattern이 존재하더라도 새롭게 Master Pattern을 생성합니다.", "MasterPattern 생성", MessageBoxButtons.YesNo,
MessageBoxIcon.Question)
== DialogResult.No)
                    return;

                CMultiProject.SystemLog.WriteLog("MastarPattern", "생성요청");

                FrmMasterPatternUpdate frmMasterpattern = new FrmMasterPatternUpdate();
                frmMasterpattern.UMasterPatternGenerateEvent += FrmMasterPatternUpdate_MasterPatternGenerateEvent;
                frmMasterpattern.SetDescription("Master Pattern 자동 생성 중입니다.");
                frmMasterpattern.TopMost = true;
                frmMasterpattern.ShowDialog();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnLadderView_Click_1(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvTotalTagS.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvTotalTagS.GetRow(iRowHandle);

                if (obj.GetType() != typeof(CTag))
                    return;

                CTag cTag = (CTag)obj;

                if (cTag == null) return;
                CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];
                CStep cStep = GetMasterStep(cTag, cLogic);

                if (cStep == null)
                    return;

                if (!m_frmLadderView.IsLoad)
                {
                    m_frmLadderView.Show();
                    m_frmLadderView.IsLoad = true;
                }

                m_frmLadderView.SetLadderStep(cLogic, cStep, 0, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnLadderView_Click Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAbnormalStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmAbnormalTreeViewer frmView = new FrmAbnormalTreeViewer();
                frmView.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnAbnormalStructure_ItemClick Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMasterPatternClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CMultiProject.MasterPatternS == null)
                    return;

                if (
                    XtraMessageBox.Show("기존에 생성된 마스터 패턴을 모두 지우시겠습니까?", "Master Pattern Clear", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                CMultiProject.MasterPatternS.Clear();
                CMultiProject.MasterStep = EMMonitorModeType.None;
                m_bMasterPatternEdit = true;

                if (CMultiProject.MasterPatternS.Count == 0)
                    XtraMessageBox.Show("지우기 성공!!!", "Master Pattern Clear", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("지우기 실패!!!", "Master Pattern Clear", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnMasterPatternClear_ItemClick Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnManualMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMasterPatternCycleSelector frmEditor = new FrmMasterPatternCycleSelector();
            frmEditor.ShowDialog();

            if (frmEditor.IsMasterPatternEdit)
                m_bMasterPatternEdit = true;
        }

        #endregion

        private void chkRecipeUpdate_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            CMultiProject.IsAutoUpdateRecipe = chkRecipeUpdate.Checked;
        }

        private void spnCycleCount_EditValueChanged(object sender, EventArgs e)
        {
            if (spnCycleCount.EditValue == null)
                return;

            int iValue = Convert.ToInt32(spnCycleCount.EditValue.ToString());
            CMultiProject.RecipeUpdateCount = iValue;
        }

        private void chkAbnormalPriority_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            CMultiProject.IsApplyAbnormalPriority = chkAbnormalPriority.Checked;
        }

        private void btnNonDetectTimeSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmDetectingTimeProperty frmView = new FrmDetectingTimeProperty();
                frmView.ShowDialog();

                frmView.Dispose();
                frmView = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowDefaultWaitForm();
            //{
            //    //SetSiemensContactTimerConstant();
            //    //RefreshKeySymbolAllSubDepth();
            //}
            //SplashScreenManager.CloseDefaultWaitForm();

            foreach (CTag cTag in CMultiProject.TotalTagS.Values)
            {
                if(cTag.Description != cTag.Name)
                    cTag.Description = string.Format("{0} ({1})", cTag.Name, cTag.Description);
            }
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

        private void RefreshKeySymbolAllSubDepth()
        {
            try
            {
                CKeySymbol cSymbol = null;
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    foreach (var who in cProcess.KeySymbolS)
                    {
                        cSymbol = who.Value;
                        cSymbol.AllSubDepthTagKeyList.Clear();
                    }
                    cProcess.ComposeKeySymbolS();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDepthApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (spnCollectDepth.EditValue == null)
                    return;

                int iDepth = Convert.ToInt32(spnCollectDepth.EditValue);

                if (
                    XtraMessageBox.Show(
                        "해당 " + iDepth +
                        " Depth의 수준으로 수집 Depth를 설정하시겠습니까?\r\n설정하시면 기존 KeySymbol의 수집 Depth도 자동으로 Update 됩니다.", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    spnCollectDepth.EditValue = CMultiProject.ProjectInfo.CollectSymbolSubDepth;
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    CMultiProject.ProjectInfo.CollectSymbolSubDepth = iDepth;
                    foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    {
                        cProcess.CollectSubDepth = iDepth;
                        cProcess.ComposeKeySymbolS();
                    }
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkFilterAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterAddress.Checked) //사용자가 주소를 입력하면 해당 주소에 맞는 것만 Filter 되어 AllTag Grid에 표시됨
            {
                FrmAllTagUserAddressFilter frmAddressFilter = new FrmAllTagUserAddressFilter();
                frmAddressFilter.ShowDialog();

                if (frmAddressFilter.FilterTagList != null && frmAddressFilter.FilterTagList.Count > 0)
                {
                    grdTotalTagS.DataSource = frmAddressFilter.FilterTagList;
                    grdTotalTagS.RefreshDataSource();
                }
            }
            else
            {
                grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
            }
        }

        private void btnRobotAllClear_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("All Clear? (Robot Cycle Symbol)", "Robot Cycle Symbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                if(CMultiProject.ProjectInfo.RobotCycleTagS != null)
                    CMultiProject.ProjectInfo.RobotCycleTagS.Clear();

                grdRobotCycle.DataSource = null;
                grdRobotCycle.RefreshDataSource();
            }
        }

        private void btnUserDeviceAllClear_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("All Clear? (User Device Symbol)", "User Device Symbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                if(CMultiProject.UserDeviceS != null)
                    CMultiProject.UserDeviceS.Clear();

                grdUserAll.DataSource = null;
                grdUserAll.RefreshDataSource();
            }
        }


        private void sptModelMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptModelMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptModelMain.SplitterPosition;
                sptModelMain.SplitterPosition = 0;
            }
            else
                sptModelMain.SplitterPosition = m_iMainSplitPos;
        }

        private void sptTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptTree.SplitterPosition > 0)
            {
                m_iTreeSplitPos = sptTree.SplitterPosition;
                sptTree.SplitterPosition = 0;
            }
            else
                sptTree.SplitterPosition = m_iTreeSplitPos;
        }

        private void btnShowAllTag_Click(object sender, EventArgs e)
        {
            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();
        }


    }

    public class CPLCUpdateView
    {
        public int ImageIndex { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }

    }
}
