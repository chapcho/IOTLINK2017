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
using TrackerProject;

namespace UDMOptimizer
{
    public delegate void UEventHandlerCreateFlowChart();
    public partial class FrmModel : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private bool m_bDragDropReady = false;
        private bool m_bFirstSetting = false;
        private CPlcLogicData m_cNewData = null;
        private FrmLadderView m_frmLadderView = null;
        private bool m_bMasterPatternEdit = false;

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerCreateFlowChart UEventFlowChart = null;

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

        #endregion

        #region Private Method

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
                trnNode = exTreeList.Nodes.Add(new object[] {CMultiProject.PlcLogicDataS[who.Key].PlcName, cPLCConfig.PLCMaker, cPLCConfig.CollectType});

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
                //if(cProcess.PlcLogicDataS.ContainsKey(sPLCID))
                //    lstRemovePlcProcess.Add(cProcess.Name);
            }

            foreach (string sProcessKey in lstRemovePlcProcess)
                CMultiProject.PlcProcS.Remove(sProcessKey);

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
            CShowWaitForm.ShowForm("Update", string.Format("Process Update"), "Start...", true);
            {
                ucProcessTree.Clear();

                if (CMultiProject.PlcProcS.Count != 0)
                {
                    ucProcessTree.ShowTree();
                    TabTable.SelectedTabPage = tpProcess;

                    IsSaveExcute = true;
                }
            }
            CShowWaitForm.CloseForm();
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
                if (CMultiProject.UserDeviceS.ContainsKey(cTag.Key))
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

        private void UpdatePLCProgram(string sPlcID)
        {
            CPlcLogicData cData = CMultiProject.PlcLogicDataS[sPlcID];
            CPlcLogicData cNewData = null;
            List<CPLCUpdateView> lstView = null;

            if (cData == null)
                return;

            CShowWaitForm.ShowForm("Update", string.Format("Update PLC Program"), "Start...", true);
            {
                cNewData = GetNewPlcLogicData(cData.Maker, cData.PlcChannel, sPlcID);

                if (cNewData != null)
                {
                    foreach (var who in cNewData.TagS)
                        who.Value.Creator = sPlcID;

                    m_cNewData = cNewData;

                    lstView = CheckTagInformationRealtedPLC(sPlcID);
                    CheckDataRelatedPLCLogicDataS(cData, cNewData, lstView);
                }
            }
            CShowWaitForm.CloseForm();

            //if (cNewData != null)
            //{
            //    FrmUpdateResult frmResult = new FrmUpdateResult();
            //    frmResult.lstView = lstView;
            //    frmResult.TopMost = true;

            //    if (frmResult.ShowDialog() == DialogResult.OK)
            //    {
            //        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //        {
            //            UpdateTagInformationRealtedPLC(sPlcID);
            //            UpdateDataRelatedPLCLogicDataS(cData, cNewData);

            //            UpdateFrmModel();
            //        }
            //        SplashScreenManager.CloseForm(false);
            //    }
            //}
        }

        private void UpdateFrmModel()
        {
            SetUsedCoil();

            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            ucProcessTree.Clear();
            ucProcessTree.ShowTree();
        }

        private List<CPLCUpdateView> CheckTagInformationRealtedPLC(string sPLCID)
        {
            List<CPLCUpdateView> lstView = new List<CPLCUpdateView>();

            CheckProjectBaseInfo(lstView);
            CheckProcess(lstView, sPLCID);

            return lstView;
        }

        public void UpdateTagInformationRealtedPLC(string sPLCID)
        {
            UpdateProjectBaseInfo();
            UpdateProcess(sPLCID);
        }

        private void UpdateProjectBaseInfo()
        {
            UpdateUserDevice();

            //TeamInfo
        }

        private void UpdateUserDevice()
        {
            List<string> lstRemoveKey = new List<string>();

            if (CMultiProject.UserDeviceS.Count == 0)
                return;

            //UserDevice
            foreach (var who in CMultiProject.UserDeviceS)
            {
                if (!IsContainNewData(who.Key))
                    lstRemoveKey.Add(who.Key);
                else
                    who.Value.Tag = m_cNewData.TagS[who.Key];
            }

            foreach (string sKey in lstRemoveKey)
                CMultiProject.UserDeviceS.Remove(sKey);
        }

        private void UpdateProcess(string sPLCID)
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                UpdateCycleStartEndConditionS(who.Value);
                UpdateRecipeWordS(who.Value);
            }
        }

        private void UpdateCycleStartEndConditionS(CPlcProc cProcess)
        {
            /*
            List<int> lstRemoveIndex = new List<int>();

            //Cycle Start
            foreach (var who in cProcess.CycleStartConditionS)
            {
                if (!IsContainNewData(who.Key))
                    lstRemoveIndex.Add(cProcess.CycleStartConditionS.IndexOf(who));
            }

            foreach (int iIndex in lstRemoveIndex)
                cProcess.CycleStartConditionS.RemoveAt(iIndex);

            lstRemoveIndex.Clear();
            cProcess.StartCompareCondition = null;

            if (cProcess.CycleStartConditionS.Count != 0)
                cProcess.StartCompareCondition = cProcess.CycleStartConditionS.First();

            foreach (var who in cProcess.CycleEndConditionS)
            {
                if (!IsContainNewData(who.Key))
                    lstRemoveIndex.Add(cProcess.CycleEndConditionS.IndexOf(who));
            }

            foreach (int iIndex in lstRemoveIndex)
                cProcess.CycleEndConditionS.RemoveAt(iIndex);

            lstRemoveIndex.Clear();
            cProcess.EndCompareCondition = null;

            if (cProcess.CycleEndConditionS.Count != 0)
                cProcess.EndCompareCondition = cProcess.CycleEndConditionS.First();

            if (cProcess.IsErrorMonitoring)
            {
                if (cProcess.CycleCheckTag != null)
                {
                    string sKey = cProcess.CycleCheckTag.Key;
                    cProcess.CycleCheckTag = null;

                    if (IsContainNewData(sKey))
                        cProcess.CycleCheckTag = m_cNewData.TagS[sKey];
                }
            }*/
        }

        private void UpdateRecipeWordS(CPlcProc cProcess)
        {
            List<string> lstAddKey = new List<string>();

            //if (cProcess.RecipeWordS.Count == 0 || cProcess.SelectRecipeWord == null)
            //    return;

            //string sKey = cProcess.SelectRecipeWord.Key;
            //cProcess.SelectRecipeWord = null;

            //if (!IsContainNewData(sKey))
            //{
            //    cProcess.RecipeWordS.Clear();
            //    return ;
            //}
             //else
             //   cProcess.SelectRecipeWord = m_cNewData.TagS[sKey];

            foreach (var who in cProcess.RecipeWordS)
            {
                if (IsContainNewData(who.Key))
                    lstAddKey.Add(who.Key);
            }

            cProcess.RecipeWordS.Clear();

            foreach (string sAddKey in lstAddKey)
                cProcess.RecipeWordS.Add(sAddKey, m_cNewData.TagS[sAddKey]);
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

            return bOK;
        }

        private bool IsContainNewData(string sTagKey)
        {
            bool bOK = true;

            if (!m_cNewData.TagS.ContainsKey(sTagKey) || !CMultiProject.TotalTagS.ContainsKey(sTagKey))
                return false;

            CTag cTag = CMultiProject.TotalTagS[sTagKey];
            CTag cNewTag = m_cNewData.TagS[sTagKey];

            if (cTag.Address != cNewTag.Address)
                bOK = false;
            if (cTag.Description != cNewTag.Description)
                bOK = false;
            if (cTag.Name != cNewTag.Name)
                bOK = false;

            return bOK;
        }

        private bool CheckProcess(List<CPLCUpdateView> lstView, string sPLCID)
        {
            bool bOK = true;
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

                bOK = CheckRecipeWordS(who.Value, lstView);

                if (!bOK)
                    bSuccess = false;

                if(bSuccess)
                {
                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 0;
                    cView.Sender = who.Value.Name;
                    cView.Message = "Update Successs!!!";

                    lstView.Add(cView);
                }
            }

            return bOK;
        }

        private bool CheckCycleStartEndConditionS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;
            /*
            //Cycle Start
            foreach (var who in cProcess.CycleStartConditionS)
            {
                if (!IsContainNewData(who.Key))
                {
                    CTag cTag = CMultiProject.TotalTagS[who.Key];

                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = cProcess.Name;
                    cView.Message = string.Format("Cycle 시작 조건 \'Address = {0}, Description = {1}\'가 존재하지 않습니다.", who.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);
                    
                    lstView.Add(cView);
                    bOK = false;
                }
            }

            foreach (var who in cProcess.CycleEndConditionS)
            {
                if (!IsContainNewData(who.Key))
                {
                    CTag cTag = CMultiProject.TotalTagS[who.Key];

                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = cProcess.Name;
                    cView.Message = string.Format("Cycle 끝 조건 \'Address = {0}, Description = {1}\'가 존재하지 않습니다.", who.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                    lstView.Add(cView);
                    bOK = false;
                }
            }

            if (cProcess.IsErrorMonitoring)
            {
                if (cProcess.CycleCheckTag != null)
                {
                    string sKey = cProcess.CycleCheckTag.Key;

                    if (!IsContainNewData(sKey))
                    {
                        cView = new CPLCUpdateView();
                        cView.ImageIndex = 1;
                        cView.Sender = cProcess.Name;
                        cView.Message = string.Format("Cycle Check Tag \'Address = {0}, Description = {1}\'가 존재하지 않습니다.", CMultiProject.TotalTagS[sKey].Address, CMultiProject.TotalTagS[sKey].Description == string.Empty ? CMultiProject.TotalTagS[sKey].Name : CMultiProject.TotalTagS[sKey].Description);

                        lstView.Add(cView);
                        bOK = false;
                    }
                }
            }
            */
            return bOK;
        }

        private bool CheckRecipeWordS(CPlcProc cProcess, List<CPLCUpdateView> lstView)
        {
            bool bOK = true;
            CPLCUpdateView cView = null;

            //if (cProcess.RecipeWordS.Count == 0 || cProcess.SelectRecipeWord == null)
            //    return true;

            string sKey = "";//cProcess.SelectRecipeWord.Key;

            if (!IsContainNewData(sKey))
            {
                CTag cTag = CMultiProject.TotalTagS[sKey];

                cView = new CPLCUpdateView();
                cView.ImageIndex = 1;
                cView.Sender = cProcess.Name;
                cView.Message = string.Format("Recipe Word \'Address : {0}, Description : {1}\'가 존재하지 않습니다.", cTag.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                lstView.Add(cView);
                return false;
            }

            foreach (var who in cProcess.RecipeWordS)
            {
                if (!IsContainNewData(who.Key))
                {
                    CTag cTag = CMultiProject.TotalTagS[who.Key];

                    cView = new CPLCUpdateView();
                    cView.ImageIndex = 1;
                    cView.Sender = cProcess.Name;
                    cView.Message = string.Format("Recipe Word \'Address : {0}, Description = {1}\'가 존재하지 않습니다.", cTag.Address, cTag.Description == string.Empty ? cTag.Name : cTag.Description);

                    lstView.Add(cView);
                    bOK = false;
                }
            }

            return bOK;
        }

        private void CheckDataRelatedPLCLogicDataS(CPlcLogicData cData, CPlcLogicData cNewData, List<CPLCUpdateView> lstView)
        {
            CPLCUpdateView cView = null;

            if (cData.TagS.Count != cNewData.TagS.Count)
            {
                cView = new CPLCUpdateView();
                cView.ImageIndex = 2;
                cView.Sender = "TAG";
                cView.Message = string.Format("태그 개수 변경 : {0} -> {1}", cData.TagS.Count.ToString("n0"), cNewData.TagS.Count.ToString("n0"));

                lstView.Add(cView);
            }

            if (cData.StepS.Count != cNewData.StepS.Count)
            {
                cView = new CPLCUpdateView();
                cView.ImageIndex = 2;
                cView.Sender = "STEP";
                cView.Message = string.Format("스텝 개수 변경 : {0} -> {1}", cData.StepS.Count.ToString("n0"), cNewData.StepS.Count.ToString("n0"));

                lstView.Add(cView);
            }
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
            }
            else
            {
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel, sPlcID);
                if (cTagS == null)
                    return null;

                cData.TagS = cTagS;
                cData.StepS = GetUsedStep(cLogic.StepS, cData.TagS);
            }

            CStepExtract.SplitStepS(cData.StepS, cData.TagS);
            cData.Compose();

            return cData;
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
                    sDeleteTag = string.Format("수집 불가능한 Tag : {0}ea", lstResult.Count);
                    XtraMessageBox.Show(sDeleteTag);

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

                if (cTag.Description == string.Empty)
                    cTag.Description = cTag.Name;

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
        
        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(cLogic.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = cLogic.StepS[who.StepKey];

                        if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
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


        private string GetByteAddress(string sHeader, string sAddress)
        {
            string[] saSplitDot = sAddress.Split('.');
            return saSplitDot[0].Replace(sHeader, "");
        }

        private int GetMajorNumber(string sHeader, string sAddress, bool bMajor)
        {
            string[] saSplitDot = sAddress.Split('.');
            string sMajor = saSplitDot[0].Replace(sHeader, "");
            if (bMajor == false)
                return Convert.ToInt32(saSplitDot[1]);
            return Convert.ToInt32(sMajor);
        }

        private int SetBundleTagS(string sHeader, Dictionary<string, List<CBundleTag>> dicDestiTag, CBundleTag cBaseTag, int iPrevMajor)
        {
            int iValue = cBaseTag.MajorNumber;
            string sReadAddress = GetByteAddress(sHeader, cBaseTag.Tag.Address);

            if (dicDestiTag.Count == 0)
            {
                dicDestiTag.Add(sReadAddress, new List<CBundleTag>());
                dicDestiTag[sReadAddress].Add(cBaseTag);
                iPrevMajor = cBaseTag.MajorNumber;
            }
            else
            {
                if ((iPrevMajor + 3) < iValue)
                {
                    dicDestiTag.Add(sReadAddress, new List<CBundleTag>());
                    dicDestiTag[sReadAddress].Add(cBaseTag);
                    iPrevMajor = cBaseTag.MajorNumber;
                }
                else
                    dicDestiTag[sReadAddress].Add(cBaseTag);
            }

            return iPrevMajor;
        }


        /// <summary>
        /// BitTag 생성 및 Sort
        /// </summary>
        /// <param name="lstTag"></param>
        /// <param name="sHeader"></param>
        /// <returns></returns>
        private List<CBitTag> CreateBitTag(List<CTag> lstTag, string sHeader)
        {
            List<CBitTag> lstResult = new List<CBitTag>();

            for (int i = 0; i < lstTag.Count; i++)
            {
                CBitTag cTag = new CBitTag();

                cTag.Tag = lstTag[i];
                cTag.MajorNumber = GetMajorNumber(sHeader, cTag.Tag.Address, true);
                cTag.MinorNumber = GetMajorNumber(sHeader, cTag.Tag.Address, false);

                lstResult.Add(cTag);
            }

            lstResult.Sort(new CBitTagComparer());
            return lstResult;
        }

        private List<CByteTag> CreateByteTag(List<CBitTag> lstBitTag, string sHeader)
        {
            List<CByteTag> lstResult = new List<CByteTag>();
            if (lstBitTag.Count == 0) return lstResult;

            int iBaseAddress = lstBitTag[0].MajorNumber;
            CByteTag cByteTag = new CByteTag();
            cByteTag.BitTagList.Add(lstBitTag[0]);
            cByteTag.MajorString = GetByteAddress(sHeader, lstBitTag[0].Tag.Address);
            cByteTag.MaskValue = (byte)(0x1 << lstBitTag[0].MinorNumber);
            cByteTag.MajorNumber = iBaseAddress;

            for (int i = 1; i < lstBitTag.Count; i++)
            {
                if (iBaseAddress != lstBitTag[i].MajorNumber)
                {
                    lstResult.Add(cByteTag);
                    iBaseAddress = lstBitTag[i].MajorNumber;
                    cByteTag = new CByteTag();
                    cByteTag.BitTagList.Add(lstBitTag[i]);
                    cByteTag.MajorString = GetByteAddress(sHeader, lstBitTag[i].Tag.Address);
                    cByteTag.MaskValue = (byte)(0x1 << lstBitTag[i].MinorNumber);
                    cByteTag.MajorNumber = iBaseAddress;
                }
                else
                {
                    cByteTag.BitTagList.Add(lstBitTag[i]);
                    cByteTag.MaskValue += (byte)(0x1 << lstBitTag[i].MinorNumber);
                }
            }
            if (cByteTag.BitTagList.Count > 0)
            {
                lstResult.Add(cByteTag);
            }

            return lstResult;
        }

        private List<CDwordTag> CreateDWordTag(List<CByteTag> lstByteTag, string sHeader)
        {
            List<CDwordTag> lstResult = new List<CDwordTag>();

            if (lstByteTag.Count == 0) return lstResult;

            CDwordTag cDwordTag = new CDwordTag(); ;
            int iBaseNumber = lstByteTag[0].MajorNumber;
            lstByteTag[0].Used = true;
            cDwordTag.Byte1 = lstByteTag[0];
            cDwordTag.MajorNumber = lstByteTag[0].MajorNumber;
            cDwordTag.ReadMajor = lstByteTag[0].MajorString;
            cDwordTag.ReadAddress = sHeader + lstByteTag[0].MajorString;

            for (int i = 1; i < lstByteTag.Count; i++)
            {
                if (iBaseNumber + 3 < lstByteTag[i].MajorNumber)
                {
                    lstResult.Add(cDwordTag);
                    iBaseNumber = lstByteTag[i].MajorNumber;

                    cDwordTag = new CDwordTag();
                    lstByteTag[i].Used = true;
                    cDwordTag.Byte1 = lstByteTag[i];
                    cDwordTag.MajorNumber = lstByteTag[i].MajorNumber;
                    cDwordTag.ReadMajor = lstByteTag[i].MajorString;
                    cDwordTag.ReadAddress = sHeader + lstByteTag[i].MajorString;
                }
                else
                {
                    //워드 위치 분석
                    if (iBaseNumber + 1 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte2 = lstByteTag[i];
                    }
                    else if (iBaseNumber + 2 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte3 = lstByteTag[i];
                    }
                    else if (iBaseNumber + 3 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte4 = lstByteTag[i];
                    }
                    else
                    {
                        int a = 0;
                    }

                }
            }

            if (cDwordTag.Byte1.Used || cDwordTag.Byte2.Used || cDwordTag.Byte3.Used || cDwordTag.Byte4.Used)
            {
                lstResult.Add(cDwordTag);
            }

            return lstResult;
        }

        #endregion

        #region Public Method

        #endregion

        #region Event Methods

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

                CreateTreeNodeS();

                if (CMultiProject.PlcProcS.Count != 0)
                    ucProcessTree.ShowTree();

                SetUsedCoil();

                grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();

                m_frmLadderView = new FrmLadderView();
                m_frmLadderView.TopMost = true;
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
                bool bOK = false;

                if (CMultiProject.PlcProcS.Count == 0)
                    return;

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

        #endregion

        #region Button Event
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

                    CMultiProject.Create(sName);
                    CMultiProject.ProjectPath = "";

                    exTreeList.Nodes.Clear();
                    ucProcessTree.Clear();

                    grdTotalTagS.DataSource = null;
                    grdTotalTagS.RefreshDataSource();

                    btnAddPlc_ItemClick(null, null);

                    if (IsChangePlcList)
                    {
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

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            try
            {

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
                    CPlcConfig cConfig = (CPlcConfig)trnNode.Tag;
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
                    cTag = (CTag)grvTotalTagS.GetRow(arrRow[i]);

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

                //UpdatePLCProgram(cPLCConfig.PlcID);
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

        private void btnTagTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            Dictionary<string, CAllBitDevice> dicAllBitData = new Dictionary<string, CAllBitDevice>();
            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                CAllBitDevice cAllBitDevice = new CAllBitDevice();
                dicAllBitData.Add(who.Key, cAllBitDevice);
                CTagS cTagS = who.Value.TagS;

                List<CTag> lstInputTag = cTagS.Values.Where(b => b.Address.Contains("I") && b.DataType == EMDataType.Bool).ToList();
                List<CTag> lstOutputTag = cTagS.Values.Where(b => b.Address.Contains("Q") && b.DataType == EMDataType.Bool).ToList();
                List<CTag> lstM_Tag = cTagS.Values.Where(b => b.Address.Contains("M") && b.DataType == EMDataType.Bool).ToList();

                if (lstInputTag != null)
                {
                    List<CBitTag> lstInputBitTag = CreateBitTag(lstInputTag, "I");
                    List<CByteTag> lstByteTag = CreateByteTag(lstInputBitTag, "I");
                    List<CDwordTag> lstDWordTag = CreateDWordTag(lstByteTag, "ID");
                    cAllBitDevice.InputDWordTagList = lstDWordTag;
                }
                if (lstOutputTag != null)
                {
                    List<CBitTag> lstOutputBitTag = CreateBitTag(lstOutputTag, "Q");
                    List<CByteTag> lstByteTag = CreateByteTag(lstOutputBitTag, "Q");
                    List<CDwordTag> lstDWordTag = CreateDWordTag(lstByteTag, "QD");
                    cAllBitDevice.OutputDWordTagList = lstDWordTag;
                }
                if (lstM_Tag != null)
                {
                    List<CBitTag> lstM_BitTag = CreateBitTag(lstM_Tag, "M");
                    List<CByteTag> lstByteTag = CreateByteTag(lstM_BitTag, "M");
                    List<CDwordTag> lstDWordTag = CreateDWordTag(lstByteTag, "MD");
                    cAllBitDevice.M_DWordTagList = lstDWordTag;
                }
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
                if (UEventMessage != null)
                    UEventMessage("FrmModel",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }
        #endregion

        #region Grid / Tree Event
        private void grvTotalTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
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

        private void grvTotalTagS_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
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

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;
                if (trnNode != null)
                {
                    CPlcConfig cConfig = (CPlcConfig)trnNode.Tag;

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

        #endregion



        #endregion
    }

    #region CLASS

    public class CPLCUpdateView
    {
        public int ImageIndex { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }

    }

    public class CBundleTagS
    {
        #region Member Veriables

        private Dictionary<string, List<CBundleTag>> m_dicInBundleTag = new Dictionary<string, List<CBundleTag>>();
        private Dictionary<string, List<CBundleTag>> m_dicOutBundleTag = new Dictionary<string, List<CBundleTag>>();
        private Dictionary<string, List<CBundleTag>> m_dicMBundleTag = new Dictionary<string, List<CBundleTag>>();
        private int m_iDWordValue = -1;
        private byte m_n1stByte = 0x0;
        private byte m_n2ndByte = 0x0;
        private byte m_n3rdByte = 0x0;
        private byte m_n4thByte = 0x0;

        #endregion


        #region Properties

        public Dictionary<string, List<CBundleTag>> InputTagS
        {
            get { return m_dicInBundleTag; }
            set { m_dicInBundleTag = value; }
        }

        public Dictionary<string, List<CBundleTag>> OutputTagS
        {
            get { return m_dicOutBundleTag; }
            set { m_dicOutBundleTag = value; }
        }

        public Dictionary<string, List<CBundleTag>> M_TagS
        {
            get { return m_dicMBundleTag; }
            set { m_dicMBundleTag = value; }
        }

        public int DWordValue
        {
            get { return m_iDWordValue; }
            set { m_iDWordValue = value; }
        }

        public byte SplitByte1st
        {
            get { return m_n1stByte; }
            set { m_n1stByte = value; }
        }

        public byte SplitByte2nd
        {
            get { return m_n1stByte; }
            set { m_n1stByte = value; }
        }

        public byte SplitByte3rd
        {
            get { return m_n1stByte; }
            set { m_n1stByte = value; }
        }

        public byte SplitByte4th
        {
            get { return m_n1stByte; }
            set { m_n1stByte = value; }
        }

        #endregion
    }

    public enum EMSymbolType
    {
        Input,
        Output,
        Memory_M
    }

    public class CBundleTag
    {
        public CTag Tag { get; set; }
        public int MajorNumber { get; set; }

        public int MinorNumber { get; set; }

        public bool CurrentValue { get; set; }
    }

    public class CBundleTagComparer : IComparer<CBundleTag>
    {
        public int Compare(CBundleTag x, CBundleTag y)
        {
            int iValue = x.MajorNumber.CompareTo(y.MajorNumber);

            return iValue;
        }
    }

    public class CBundleTagMinurComparer : IComparer<CBundleTag>
    {
        public int Compare(CBundleTag x, CBundleTag y)
        {
            int iValue = x.MinorNumber.CompareTo(y.MinorNumber);

            return iValue;
        }
    }
        
    public class CBitTagComparer : IComparer<CBitTag>
    {
        public int Compare(CBitTag x, CBitTag y)
        {
            int iValue = x.MajorNumber.CompareTo(y.MajorNumber);

            return iValue;
        }
    }

    public class CBitTag
    {
        #region Member Variables

        #endregion

        #region Properties

        public CTag Tag { get; set; }
        public int MajorNumber { get; set; }

        public int MinorNumber { get; set; }

        public bool CurrentValue { get; set; }
        
        #endregion
    }

    public class CByteTag
    {
        #region Member Veriables

        private byte m_nMaskValue = 0;
        private string m_sMajorString = "";
        private int m_iMajorNumber = 0;
        private List<CBitTag> m_lstBitTag = new List<CBitTag>();
        private byte m_nCurrentValue = 0;
        private bool m_bUsed = false;

        #endregion


        #region Properties

        public byte MaskValue
        {
            get { return m_nMaskValue; }
            set { m_nMaskValue = value; }
        }

        public string MajorString
        {
            get { return m_sMajorString; }
            set { m_sMajorString = value; }
        }

        public int MajorNumber
        {
            get { return m_iMajorNumber; }
            set { m_iMajorNumber = value; }
        }

        public List<CBitTag> BitTagList
        {
            get { return m_lstBitTag; }
            set { m_lstBitTag = value; }
        }

        public byte CurrentValue
        {
            get { return m_nCurrentValue; }
            set { m_nCurrentValue = value; }
        }

        public bool Used
        {
            get { return m_bUsed; }
            set { m_bUsed = value; }
        }

        #endregion

    }

    public class CDwordTag
    {
        #region Member Veriavles

        private string m_sReadMajor = "";
        private string m_sReadAddress = "";
        private int m_iMajorNumber = 0;
        private CByteTag m_cByte1 = new CByteTag();
        private CByteTag m_cByte2 = new CByteTag();
        private CByteTag m_cByte3 = new CByteTag();
        private CByteTag m_cByte4 = new CByteTag();
        private int m_iCurrentValue = -1;
        
        #endregion


        #region Properties

        public int MajorNumber
        {
            get { return m_iMajorNumber; }
            set { m_iMajorNumber = value; }
        }

        public string ReadMajor
        {
            get { return m_sReadMajor; }
            set { m_sReadMajor = value; }
        }

        public string ReadAddress
        {
            get { return m_sReadAddress; }
            set { m_sReadAddress = value; }
        }

        public CByteTag Byte1
        {
            get { return m_cByte1; }
            set { m_cByte1 = value; }
        }

        public CByteTag Byte2
        {
            get { return m_cByte2; }
            set { m_cByte2 = value; }
        }

        public CByteTag Byte3
        {
            get { return m_cByte3; }
            set { m_cByte3 = value; }
        }

        public CByteTag Byte4
        {
            get { return m_cByte4; }
            set { m_cByte4 = value; }
        }

        public int CurrentValue
        {
            get { return m_iCurrentValue; }
        }

        #endregion


        #region Private Method
        private byte SplitByte(int iPos, int iReadValue, byte nMask)
        {
            byte nResult = 0;

            if (iPos == 1)
                nResult = (byte)((iReadValue & 0xFF000000) >> 24);
            else if (iPos == 2)
                nResult = (byte)((iReadValue & 0x00FF0000) >> 16);
            else if (iPos == 3)
                nResult = (byte)((iReadValue & 0x0000FF00) >> 8);
            else
                nResult = (byte)((iReadValue & 0x000000FF));
            
            return (byte)(nResult & nMask);
        }

        private UDM.Log.CTimeLogS GetTimeLogSChangeTag(CByteTag cBaseTag, byte nReadValue, string sReadTime)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            if (cBaseTag.CurrentValue != nReadValue)
            {
                cBaseTag.CurrentValue = nReadValue;
                foreach (CBitTag cTag in cBaseTag.BitTagList)
                {
                    byte nValue = (byte)(nReadValue & (0x1 << cTag.MinorNumber));
                    bool bReadValue = false;
                    if (nValue == 1) bReadValue = true;
                    if (cTag.CurrentValue != bReadValue)
                    {
                        cTag.CurrentValue = bReadValue;

                        //로그 생성
                        UDM.Log.CTimeLog cLog = new UDM.Log.CTimeLog();
                        cLog.Time = UDM.General.CTypeConverter.ToDateTime(sReadTime);
                        cLog.Key = cTag.Tag.Key;
                        cLog.Value = (int)nValue;
                        cLog.SValue = nValue.ToString();

                        cLogS.Add(cLog);
                    }
                }
            }
            return cLogS;
        }

        #endregion


        #region Public Method

        public UDM.Log.CTimeLogS GetTimeLogSChangedTag(int iReadValue, string sReadTime)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            if (m_iCurrentValue == iReadValue)
                return cLogS;
            m_iCurrentValue = iReadValue;

            byte nData1 = SplitByte(1, iReadValue, m_cByte1.MaskValue);
            byte nData2 = SplitByte(2, iReadValue, m_cByte2.MaskValue);
            byte nData3 = SplitByte(3, iReadValue, m_cByte3.MaskValue);
            byte nData4 = SplitByte(4, iReadValue, m_cByte4.MaskValue);

            //값 분석을 통해 변경된 값은 TimeLog를 만들어 Return

            if (m_cByte1.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte1, nData1, sReadTime));
            if (m_cByte2.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte2, nData2, sReadTime));
            if (m_cByte3.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte3, nData3, sReadTime));
            if (m_cByte4.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte4, nData4, sReadTime));

            return cLogS;
        }

        #endregion

    }

    public class CAllBitDevice
    {
        #region Member Veriables

        private List<CDwordTag> m_lstInputDWordTag = new List<CDwordTag>();
        private List<CDwordTag> m_lstOutputDWordTag = new List<CDwordTag>();
        private List<CDwordTag> m_lstM_DWordTag = new List<CDwordTag>();

        #endregion


        #region Properties

        public List<CDwordTag> InputDWordTagList
        {
            get { return m_lstInputDWordTag; }
            set { m_lstInputDWordTag = value; }
        }

        public List<CDwordTag> OutputDWordTagList
        {
            get { return m_lstOutputDWordTag; }
            set { m_lstOutputDWordTag = value; }
        }

        public List<CDwordTag> M_DWordTagList
        {
            get { return m_lstM_DWordTag; }
            set { m_lstM_DWordTag = value; }
        }

        #endregion
    }

    #endregion
}
