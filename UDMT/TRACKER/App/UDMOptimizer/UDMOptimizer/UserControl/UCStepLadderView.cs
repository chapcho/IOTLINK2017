using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Diagnostics;
using DevExpress.XtraTreeList;
using UDM.Log.Csv;
using System.IO;
using DevExpress.XtraTab;
using UDM.Log.DB;

namespace UDMOptimizer
{
    public delegate void UEventHandlerSendTags(CPlcConfig cConfig, CTagS cTags);
    public delegate void UEventHandlerSendAddTagS(CPlcConfig cConfig, CTagS cTags);
    public delegate void UEventHandlerSendRemoveTagS(CPlcConfig cConfig, CTagS cTags);
    public delegate void UEventHandlerSendCloseSPD(string sPlc);
    public enum EMTrackerLogType
    {
        ContinueLog,
        SubDepthLog
    }

    public partial class UCStepLadderView : UserControl
    {
        #region Member Variables

        protected const int IMG_INDEX_PLC = 0;
        protected const int IMG_INDEX_PROGRAM = 1;
        protected const int IMG_INDEX_STEPS = 2;

        private bool m_bRun = false;
        private int m_iLadderID = 0;
        private string m_sSPDStatus = "";
        private string m_sRunStatus = "";

        private CTagS m_cAllTagS = new CTagS();
        private CStepS m_cAllStepS = new CStepS();
        private CTimeLogS m_cTimeLogs = null;
        private CTimeLogS m_cBeforeTimeLogs = null;
        private CTimeLogS m_cGetTimeLogS = null;
        private CPlcConfigS m_cMainPlcConfigS = new CPlcConfigS();
        private Dictionary<CPlcConfig, CTagS> m_dicLadderTagS = new Dictionary<CPlcConfig, CTagS>();
        private Dictionary<string, string> m_dicSPDStatus = new Dictionary<string, string>();

        private CMySqlLogWriter m_cLogWriter = null;
        private CMySqlLogReader m_cLogReader = null;

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerSendTags UEventSendTagS = null;
        public event UEventHandlerSendAddTagS UEventSendAddTagS = null;
        public event UEventHandlerSendRemoveTagS UEventSendRemoveTagS = null;
        public event UEventHandlerSendCloseSPD UEventCloseSPD = null;

        protected delegate void ShowStepLadderListCallBack(EMTrackerLogType emLogType, CTimeLogS cLogS);
        #endregion

        #region Initialize
        public UCStepLadderView()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public bool IsRunning
        {
            get { return m_bRun; }
            set { m_bRun = value; }
        }

        #endregion

        #region Private Method

        private void CreateTreeNodeS()
        {
            try
            {
                SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
                {
                    exTreeStepAll.Nodes.Clear();
                    exTreeStepY.Nodes.Clear();

                    TreeListNode trnPlcNodeAll = null;
                    TreeListNode trnPrgNodeAll = null;
                    TreeListNode trnStepNodeAll = null;

                    TreeListNode trnPlcNodeY = null;
                    TreeListNode trnPrgNodeY = null;
                    TreeListNode trnStepNodeY = null;

                    if (CMultiProject.PlcLogicDataS.Count == 0)
                        return;

                    foreach (CPlcLogicData cPlcLogic in CMultiProject.PlcLogicDataS.Values)
                    {
                        List<IGrouping<string, CStep>> lstPrograms = cPlcLogic.StepS.Values.OrderBy(x => x.Program).GroupBy(x => x.Program).ToList();

                        trnPlcNodeAll = exTreeStepAll.Nodes.Add(new object[] { cPlcLogic.PlcName });
                        trnPlcNodeAll.ImageIndex = IMG_INDEX_PLC;
                        trnPlcNodeAll.SelectImageIndex = IMG_INDEX_PLC;

                        trnPlcNodeY = exTreeStepY.Nodes.Add(new object[] { cPlcLogic.PlcName });
                        trnPlcNodeY.ImageIndex = IMG_INDEX_PLC;
                        trnPlcNodeY.SelectImageIndex = IMG_INDEX_PLC;

                        foreach (IGrouping<string, CStep> lstProgram in lstPrograms)
                        {
                            List<CStep> lstProgramSteps = lstProgram.OrderBy(x => x.StepIndex).ToList();

                            trnPrgNodeAll = CreateTreeNode(trnPlcNodeAll, lstProgram.Key, null, IMG_INDEX_PROGRAM, null);
                            trnPrgNodeY = CreateTreeNode(trnPlcNodeY, lstProgram.Key, null, IMG_INDEX_PROGRAM, null);

                            foreach (CStep cStep in lstProgramSteps)
                            {
                                if (cStep.CoilS.Count == 0 || cStep.CoilS.GetFirstCoil().ContentS.Count == 0)
                                    continue;

                                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
                                    continue;

                                CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                                trnStepNodeAll = CreateTreeNode(trnPrgNodeAll, cTag.Address, cTag.Description, IMG_INDEX_STEPS, cStep);

                                if (cTag != null && cTag.Address.Contains("Y")) // 추후 수정 필요 
                                    trnStepNodeY = CreateTreeNode(trnPrgNodeY, cTag.Address, cTag.Description, IMG_INDEX_STEPS, cStep);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sStep, string sInstruction, int iImageIndex, object oTag)
        {
            TreeListNode trnNode = null;
            try
            {
                trnNode = trnParent.Nodes.Add(new object[] { sStep, sInstruction });
                trnNode.ImageIndex = iImageIndex;
                trnNode.SelectImageIndex = iImageIndex;

                if (oTag != null)
                    trnNode.Tag = oTag;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return trnNode;
        }

        private void SetLadderStep(CStep cStep, int iStepLevel, bool bView)
        {
            if (m_bRun) return;

            try
            {
                if (cStep != null)
                {
                    Panel pnlLadder = (Panel)tabLadder.SelectedTabPage.Controls[0];
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlLadder.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep)pnlLadder.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                            lstRemove.Add(ucView);
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                    {
                        pnlLadder.Controls.Remove(lstRemove[i]);
                    }

                    CCoil cLadderCoil = cStep.CoilS.GetFirstCoil();
                    CTag cLadderTag = cLadderCoil.ContentS[0].Tag;

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.AutoScroll = true;
                    ucStep.ScaleDefault = 1f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel;
                    ucStep.IsViewStep = bView;

                    if (cLadderTag != null)
                    {
                        ucStep.StepName =
                           string.Format("CPU : {0} / Program : {1} / Network : {2} / Coil : {3} ( {4} )",
                               cLadderTag.Channel, cStep.Program, cStep.StepIndex, cLadderTag.Address, cLadderTag.Description);
                    }
                    else
                    {
                        ucStep.StepName =
                             string.Format("Program : {0} / Network : {1} / Coil : {2}",
                                 cStep.Program, cStep.StepIndex, cStep.Instruction);
                    }
                    pnlLadder.Controls.Add(ucStep);
                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;

                    if (!m_cAllStepS.ContainsKey(cStep.Key))
                        m_cAllStepS.Add(cStep.Key, cStep);

                    //// 수집 중 Tag 추가
                    //if(m_bRun)
                    //{
                    //    CTagS cSendTagS = GetLadderStepTagList(cStep);

                    //    GetLadderAllTagList(m_cAllStepS);

                    //    if (UEventSendAddTagS != null)
                    //        UEventSendAddTagS(m_cMainPlcConfig, cSendTagS);
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;

            CStep cStep = null;

            try
            {
                List<CStep> lstStep = cLogic.StepS.Where(b => b.Value.Address == cTag.Address).Select(b => b.Value).ToList();

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
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return cStep;
        }

        private CTagS GetRemoveTagList(CStep cGetStep)
        {
            if (cGetStep == null)
                return null;

            CTagS cRemoveTagS = new CTagS();

            try
            {
                if (cGetStep.RefTagS == null || cGetStep.RefTagS.Count == 0) return null;

                for (int i = 0; i < cGetStep.RefTagS.Count; i++)
                {
                    CTag cRefTag = cGetStep.RefTagS[i];

                    if (!m_cAllTagS.ContainsKey(cRefTag.Key))
                    {
                        cRemoveTagS.Add(cRefTag);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return cRemoveTagS;
        }

        private void GetLadderAllTagList(CStepS cGetStepS)
        {
            if (cGetStepS == null)
                return;

            try
            {
                m_cAllTagS = new CTagS();
                m_cMainPlcConfigS = new CPlcConfigS();
                m_dicLadderTagS = new Dictionary<CPlcConfig, CTagS>();

                foreach(CStep cStep in m_cAllStepS.Values)
                {
                    CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;
                    CPlcConfig cConfig = CMultiProject.PlcConfigS[cTag.Creator];

                    for (int i = 0; i < cStep.RefTagS.Count; i++)
                    {
                        CTag cRefTag = cStep.RefTagS[i];

                        if (!m_dicLadderTagS.ContainsKey(cConfig))
                        {
                            m_dicLadderTagS.Add(cConfig, new CTagS());
                            m_cMainPlcConfigS.Add(cConfig.PlcID, cConfig);
                        }

                        if (!m_dicLadderTagS[cConfig].ContainsValue(cRefTag))
                            m_dicLadderTagS[cConfig].Add(cRefTag);
                    }
                }

                foreach (CStep cStep in cGetStepS.Values)
                {
                    if (cStep.RefTagS == null || cStep.RefTagS.Count == 0) continue;

                    for (int i = 0; i < cStep.RefTagS.Count; i++)
                    {
                        CTag cRefTag = cStep.RefTagS[i];
                        if (!m_cAllTagS.ContainsKey(cRefTag.Key))
                            m_cAllTagS.Add(cRefTag);
                    }
                }

                string sTagCnt = "";
                foreach (KeyValuePair<CPlcConfig, CTagS> kv in m_dicLadderTagS)
                {
                    string sPlc = kv.Key.PlcID.Replace("Tracker,", "");
                    sTagCnt += "[" + sPlc + " : " + kv.Value.Count.ToString() + "]  ";
                }

                txtTagSCount.Caption = "[수집 Tag Count : " + m_cAllTagS.Count + "] : " + sTagCnt;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void CreateBeforeTimeLogS()
        {
            m_cBeforeTimeLogs = new CTimeLogS();

            int iValue = -1;

            foreach(CTag cTag in m_cAllTagS.Values)
            {
                CTimeLog cLog = new CTimeLog();
                cLog.Time = DateTime.Now;
                cLog.Key = cTag.Key;
                cLog.Value = iValue;

                m_cBeforeTimeLogs.Add(cLog);
            }
        }

        private void DeleteLadderView()
        {
            try
            {
                Panel pnlLadder = (Panel)tabLadder.SelectedTabPage.Controls[0];

                if (pnlLadder.Controls == null || pnlLadder.Controls.Count == 0) return;

                UCLadderStep ucSelLadder = (UCLadderStep)pnlLadder.Controls[pnlLadder.Controls.Count-1];

                if (ucSelLadder == null || ucSelLadder.Step == null) return;

                pnlLadder.Controls.Remove(ucSelLadder);

                if (m_cAllStepS.ContainsKey(ucSelLadder.Step.Key))
                    m_cAllStepS.Remove(ucSelLadder.Step.Key);

                if (pnlLadder.Controls == null || pnlLadder.Controls.Count == 0)
                    tabLadder.TabPages.Remove(tabLadder.SelectedTabPage);

                //CTagS cRemoveTagS = GetRemoveTagList(ucSelLadder.Step);
                //if (UEventSendRemoveTagS != null)
                //    UEventSendRemoveTagS(m_cMainPlcConfig, cRemoveTagS);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void ClearLadderView()
        {
            try
            {
                Panel pnlLadder = (Panel)tabLadder.SelectedTabPage.Controls[0];

                if (pnlLadder.Controls == null || pnlLadder.Controls.Count == 0)
                    return;

                DialogResult dlgResult = XtraMessageBox.Show("모든 Step을 삭제하시겠습니까?", "Real Time Ladder View", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    return;

                ClearLadderData();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void ClearLadderData()
        {
            //pnlLadder.Controls.Clear();
            tabLadder.TabPages.Clear();

            m_cAllTagS.Clear();
            m_cAllStepS.Clear();
            m_cMainPlcConfigS.Clear();
            m_dicLadderTagS.Clear();
        }

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private CTimeLogS CreateTimeLogS(CTimeLogS cGetLogS)
        {
            CTimeLogS cLogS = new CTimeLogS();
            try
            {
                if (cGetLogS == null || cGetLogS.Count == 0)
                    return m_cBeforeTimeLogs;

                if (m_cBeforeTimeLogs == null || m_cBeforeTimeLogs.Count == 0)
                    return cGetLogS;

                cLogS = m_cBeforeTimeLogs;

                foreach (CTimeLog cGetLog in cGetLogS)
                {
                    List<CTimeLog> lstTimeLog = cLogS.Where(x => x.Key == cGetLog.Key).ToList();

                    if (lstTimeLog.Count > 0)
                    {
                        foreach (CTimeLog cTimeLog in cLogS)
                        {
                            if (cTimeLog.Key == cGetLog.Key)
                            {
                                if (cTimeLog.Value != cGetLog.Value)
                                {
                                    cTimeLog.Value = cGetLog.Value;
                                    cTimeLog.Time = cGetLog.Time;
                                }
                            }
                        }
                    }
                    else
                    {
                        cLogS.Add(cGetLog);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return cLogS;
        }

        protected void ShowStepLadderList(EMTrackerLogType emLogType, CTimeLogS cLogS)
        {
            if (cLogS == null) return;
            if (this.tabLadder.InvokeRequired) //tabLadder > pnlLadder
            {
                ShowStepLadderListCallBack d = new ShowStepLadderListCallBack(ShowStepLadderList);
                this.Invoke(d, new object[] { cLogS });
            }
            else
            {
                try
                {
                    if (cLogS != null)
                    {
                        if (m_cGetTimeLogS != null)
                            m_cGetTimeLogS.Clear();
                        
                        m_cGetTimeLogS = (CTimeLogS)cLogS.Clone();
                        m_cTimeLogs = CreateTimeLogS(m_cGetTimeLogS);
                        m_cBeforeTimeLogs = m_cTimeLogs;

                        //Log Write
                        CreateLadderTimeLogS(m_cGetTimeLogS);

                        foreach(XtraTabPage tp in tabLadder.TabPages)
                        {
                            Panel pnlLadder = (Panel)tp.Controls[0];
                     
                            foreach (Control con in pnlLadder.Controls)
                            {
                                UCLadderStep ucLadder = (UCLadderStep)con;

                                if (ucLadder.Step != null)
                                {
                                    ucLadder.SymbolLogS = m_cTimeLogs;
                                    ucLadder.Refresh();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Tag", ex.Message);
                }
            }
        }

        #region Log Function
        private bool ConnectLogWriter()
        {
            bool bOK = false;

            m_cLogWriter = new CMySqlLogWriter();

            bOK = m_cLogWriter.Connect();

            if (!bOK)
            {
                UpdateSystemMessage("LogWriter", "DB연결에 실패했습니다.");
                return false;
            }

            return bOK;
        }

        private bool DisconnectLogWriter()
        {
            bool bOK = false;

            bOK = m_cLogWriter.Disconnect();
            m_cLogWriter.Dispose();
            m_cLogWriter = null;

            return bOK;
        }

        private bool ConnectLogReader()
        {
            bool bOK = false;

            m_cLogReader = new CMySqlLogReader();

            bOK = m_cLogReader.Connect();

            if (!bOK)
            {
                UpdateSystemMessage("LogWriter", "DB연결에 실패했습니다.");
                return false;
            }

            return bOK;
        }

        private bool DisconnectLogReader()
        {
            bool bOK = false;

            bOK = m_cLogReader.Disconnect();
            m_cLogReader.Dispose();
            m_cLogReader = null;

            return bOK;
        }

        private void CreateLadderViewInfo()
        {
            string sMainStepKey = "";
            string sStepKeyS = "";
            string sPlcID = "";
            try
            {
                bool bOK = ConnectLogReader();

                if(bOK)
                    m_iLadderID = m_cLogReader.GetLadderViewLadderID(CMultiProject.ProjectID);

                bOK = ConnectLogWriter();

                if (bOK)
                    bOK = m_cLogWriter.WriteLadderInfo(CMultiProject.ProjectID, m_iLadderID);

                if (bOK)
                {
                    foreach (XtraTabPage tp in tabLadder.TabPages)
                    {
                        sStepKeyS = "";
                        CStep cStep = (CStep)tp.Tag;
                        sMainStepKey = cStep.Key;

                        CCoil cCoil = cStep.CoilS.GetFirstCoil();
                        string sTagAddr = cCoil.RefTagS.GetBaseAddress();
                        string sTagDesc = cCoil.RefTagS.GetBaseDescription();

                        CPlcConfig cConfig = CMultiProject.PlcConfigS[cCoil.RefTagS.GetFirstTag().Creator];
                        sPlcID = cConfig.PlcID;

                        Panel pnlLadder = (Panel)tp.Controls[0];
                        foreach (Control con in pnlLadder.Controls)
                        {
                            UCLadderStep ucLadder = (UCLadderStep)con;
                            sStepKeyS += ucLadder.Step.Key + ";";
                        }

                        bOK = m_cLogWriter.WriteLadderDetailInfo(CMultiProject.ProjectID, m_iLadderID, sMainStepKey, sTagAddr +" : " + sTagDesc, sStepKeyS, sPlcID);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DisconnectLogReader();
            }
        }

        private void CreateLadderTimeLogS(CTimeLogS cGetLogS)
        {
            if (cGetLogS == null) return;

            try
            {
                if (m_cLogWriter.IsConnected)
                    m_cLogWriter.WriteLadderViewTimeLogS(CMultiProject.ProjectID, m_iLadderID, cGetLogS);
            }
            catch (Exception ex)
            {
            }
        }

        private void UpdateCollectEndTime()
        {
            try
            {
                if (m_cLogWriter.IsConnected)
                    m_cLogWriter.WriteLadderViewInfo_CollectEndTime(CMultiProject.ProjectID, m_iLadderID);

            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #endregion

        #region Public Method

        public void Clear()
        {
            if (m_bRun)
                btnCollectStop_ItemClick(null, null); // 수집중이니 멈추고 새로운 프로젝트 Open 하라는 팝업으로 변경 ?

            RefreshLadderView();
        }

        public void RefreshLadderView()
        {
            if (m_bRun) return;

            exTreeStepAll.Nodes.Clear();
            exTreeStepY.Nodes.Clear();
            ClearLadderData();
            CreateTreeNodeS();
        }

        public void Stop()
        {
            if (m_bRun)
                btnCollectStop_ItemClick(null, null);
        }

        public void SetLadderViewTimeLogS(EMTrackerLogType emLogType, CTimeLogS cLogS)
        {
            ShowStepLadderList(emLogType, cLogS);
        }

        public void SetLadderViewSPDStatus(string sPlcID, string sStatus)
        {
            try
            {
                if(sStatus != null && sStatus != "")
                {
                    string sSPDStatus = "";

                    if (m_dicSPDStatus.ContainsKey(sPlcID))
                        m_dicSPDStatus.Remove(sPlcID);

                    m_dicSPDStatus.Add(sPlcID, sStatus);

                    foreach (KeyValuePair<string, string> kv in m_dicSPDStatus)
                    {
                        string sPlc = kv.Key.Replace("Tracker,", "");
                        sSPDStatus += "[" + sPlc + " : " + kv.Value + "]  ";
                    }

                    txtSPDStatus.Caption = "[실시간 Ladder View 수집 상태] : " + sSPDStatus;

                    if (sStatus.Equals("Error"))
                    {
                        UpdateSystemMessage("Real Time Ladder View", "수집이 종료되었습니다.");
                        btnCollectStop_ItemClick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Form Event

        private void exTreeStep_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_bRun)
                {
                    XtraMessageBox.Show("수집 중 입니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TreeList treeList = (TreeList)sender;

                TreeListNode trnNode = treeList.FocusedNode;

                if (trnNode != null && trnNode.Tag != null)
                {
                    CStep cStep = (CStep)trnNode.Tag;
                    CTag cMainTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                    XtraTabPage tp = new XtraTabPage();
                    tp.Name = "tp" + cMainTag.Key;
                    tp.Text = cMainTag.Key + " : " + cMainTag.Description;
                    tp.Tag = cStep;
                    tp.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;   

                    foreach(XtraTabPage tabPage in tabLadder.TabPages)
                    {
                        if (tp.Name == tabPage.Name)
                        {
                            XtraMessageBox.Show("이미 추가 된 접점입니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            return;
                        }
                    }

                    tabLadder.TabPages.Add(tp);
                    tabLadder.SelectedTabPage = tp;

                    Panel pnlLadder = new Panel();
                    pnlLadder.AutoScroll = true;
                    pnlLadder.VerticalScroll.Enabled = true;
                    tp.Controls.Add(pnlLadder);
                    pnlLadder.Dock = DockStyle.Fill;

                    SetLadderStep(cStep, 0, true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void UCStepLadderView_Load(object sender, EventArgs e)
        {
            CreateTreeNodeS();
        }

        private void ucStep_UEventSelectedCellData(CTag cLadderSelTag, int iStepLevel, CTimeLogS cLogS)
        {
            try
            {
                // 수집 중 Tag 추가 불가
                if (m_bRun) 
                {
                    XtraMessageBox.Show("수집 중 입니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
             
                if (cLadderSelTag == null) return;
                
                CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cLadderSelTag.Creator];
                CStep cStep = GetMasterStep(cLadderSelTag, cLogic);

                if (cStep != null)
                {
                    Panel pnlLadder = (Panel)tabLadder.SelectedTabPage.Controls[0];

                    UCLadderStep ucFirstLadder = (UCLadderStep)pnlLadder.Controls[pnlLadder.Controls.Count - 1]; //첫번째 Ladder
                    UCLadderStep ucSelLadder = (UCLadderStep)this.ActiveControl; // 선택한 Ladder

                    if (ucFirstLadder.Step != ucSelLadder.Step)  //선택한 Ladder가 첫번째 Ladder가 아니면 선택한 Ladder 위쪽 Ladder 모두 삭제
                    {
                        int iCnt = 0;

                        for (int i = 0; i < pnlLadder.Controls.Count; i++)
                        {
                            UCLadderStep ucTempLadder = (UCLadderStep)pnlLadder.Controls[i];
                            if (ucTempLadder.Step == ucSelLadder.Step)
                                iCnt = i;
                        }

                        while (pnlLadder.Controls.Count - 1 != iCnt)
                        {
                            UCLadderStep ucRemoveLadder = (UCLadderStep)pnlLadder.Controls[pnlLadder.Controls.Count - 1];
                            pnlLadder.Controls.Remove(ucRemoveLadder);

                            if (m_cAllStepS.ContainsKey(ucRemoveLadder.Step.Key))
                                m_cAllStepS.Remove(ucRemoveLadder.Step.Key);
                        }
                    }
                    SetLadderStep(cStep, iStepLevel, true);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void btnCollectStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_cAllStepS == null || m_cAllStepS.Count == 0)
                {
                    XtraMessageBox.Show("수집 대상이 없습니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
                {
                    m_sRunStatus = "";

                    GetLadderAllTagList(m_cAllStepS);

                    foreach (CPlcConfig cConfig in m_cMainPlcConfigS.Values)
                    {
                        Process pro = new Process();
                        pro.StartInfo.FileName = Application.StartupPath + "\\UDMSPDSingle.exe";
                        pro.StartInfo.Arguments = "Tracker," + cConfig.PlcID;
                        m_bRun = pro.Start();
                        m_sRunStatus += m_bRun.ToString();
                    }

                    btnCollectStart.Enabled = false;
                    btnCollectStop.Enabled = true;
                    btnDeleteLadder.Enabled = false;
                    btnClearLadder.Enabled = false;
                    btnRefresh.Enabled = false;

                    tmrStartSPD.Start();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void tmrStartSPD_Tick(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
                {
                    tmrStartSPD.Stop();
                    tmrStartSPD.Enabled = false;

                    if (m_sRunStatus.Contains("False"))
                    {
                        UpdateSystemMessage("수집 시작 실패", "실시간 Ladder View 수집을 시작하지 못했습니다.");
                        XtraMessageBox.Show("실시간 Ladder View 수집을 시작하지 못했습니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        m_bRun = false;

                        // 실행 된 SPD Single 종료
                        foreach (CPlcConfig cConfig in m_cMainPlcConfigS.Values)
                        {
                            string sPlcID = "Tracker," + cConfig.PlcID;

                            if (UEventCloseSPD != null)
                                UEventCloseSPD(sPlcID);
                        }
                        
                        SplashScreenManager.CloseForm(false);

                        btnCollectStop.Enabled = false;
                        btnCollectStart.Enabled = true;
                        btnDeleteLadder.Enabled = true;
                        btnClearLadder.Enabled = true;
                        btnRefresh.Enabled = true;
                        return;
                    }

                    m_bRun = true;

                    if (m_cBeforeTimeLogs != null)
                        m_cBeforeTimeLogs.Clear();

                    if (m_cGetTimeLogS != null)
                        m_cGetTimeLogS.Clear();

                    if (m_cTimeLogs != null)
                        m_cTimeLogs.Clear();

                    CreateBeforeTimeLogS();
                    CreateLadderViewInfo();

                    UpdateSystemMessage("수집 시작", "실시간 Ladder View 수집을 시작합니다.");

                    foreach (KeyValuePair<CPlcConfig,CTagS> kv in m_dicLadderTagS)
                    {
                        CPlcConfig cConfig = kv.Key;
                        CTagS cAllTagS = kv.Value;

                        if (UEventSendTagS != null)
                            UEventSendTagS(cConfig, cAllTagS);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnCollectStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!m_bRun) return;

                m_bRun = false;

                SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);

                UpdateSystemMessage("수집 종료", "실시간 Ladder View 수집을 종료합니다.");

                foreach(CPlcConfig cConfig in m_cMainPlcConfigS.Values)
                {
                    string sPlcID = "Tracker," + cConfig.PlcID;

                    if (UEventCloseSPD != null)
                        UEventCloseSPD(sPlcID);
                }

                if (!m_bRun)
                {
                    UpdateCollectEndTime();
                    DisconnectLogWriter();

                    if (m_dicLadderTagS != null)
                        m_dicLadderTagS.Clear();

                    if (m_dicSPDStatus != null)
                        m_dicSPDStatus.Clear();

                    btnCollectStop.Enabled = false;
                    btnCollectStart.Enabled = true;
                    btnDeleteLadder.Enabled = true;
                    btnClearLadder.Enabled = true;
                    btnRefresh.Enabled = true;

                    txtSPDStatus.Caption = "[실시간 Ladder View 수집 상태] : STOP";
                    //txtTagSCount.Caption = "수집 Tag Count : ";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void mnuDeleteLadder_Click(object sender, EventArgs e)
        {
            DeleteLadderView();
        }

        private void mnuClearLadder_Click(object sender, EventArgs e)
        {
            ClearLadderView();
        }

        private void btnDeleteLadder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteLadderView();
        }

        private void btnClearLadder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearLadderView();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bRun)
            {
                XtraMessageBox.Show("수집 중 입니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RefreshLadderView();
        }

        private void tabLadder_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabControl tabControl = (XtraTabControl)sender;
            XtraTabPage tabPage = tabControl.SelectedTabPage;
            Panel pnlLadder = (Panel)tabPage.Controls[0];

            foreach(Control con in pnlLadder.Controls)
            {
                UCLadderStep ucLadder = (UCLadderStep)con;
                if(ucLadder.Step != null)
                {
                    if (m_cAllStepS.ContainsKey(ucLadder.Step.Key))
                        m_cAllStepS.Remove(ucLadder.Step.Key);
                }
            }
            tabLadder.TabPages.Remove(tabLadder.SelectedTabPage);
        }

        private void btnLogView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        #endregion
    }
}


