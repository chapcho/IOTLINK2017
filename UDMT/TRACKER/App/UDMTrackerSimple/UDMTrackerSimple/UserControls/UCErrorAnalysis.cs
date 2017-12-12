using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.Tree;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;
using UDM.LogicViewer;

namespace UDMTrackerSimple
{
    public partial class UCErrorAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private bool m_bVerified = false;
        private bool m_bFirst = true;
        private CMySqlLogReader m_cReader = null;
        private CLogicDiagram m_cDiagram = null;
        private CPlcLogicData m_cLogicData = null;
        private CErrorInfo m_cErrorInfo = null;

        private CPlcProc m_cProcess = null;
        private CTag m_cTag = null;

        private delegate void UpdateErrorAnlaysisCallback(CErrorInfo cInfo);
        private delegate void UpdateErrorAnlaysisCallback2(CErrorInfo cErrorInfo, CCycleInfo cCycleInfo);
        private delegate void UpdateErrorCauseCallback(CTag cTag, CErrorInfo cInfo);

        #endregion

        public UCErrorAnalysis()
        {
            InitializeComponent();
        }

        #region Public Properties
        
        public CErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; }
        }

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods

        public void ShowErrorAnalysis(CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorAnlaysisCallback cUpdate = new UpdateErrorAnlaysisCallback(ShowErrorAnalysis);
                this.Invoke(cUpdate, new object[] {cInfo});
            }
            else
            {
                Clear();

                if (cInfo == null)
                    return;

                m_cReader = CMultiProject.LogReader;

                if (m_cReader != null && !m_cReader.IsConnected)
                    m_cReader.Connect();

                m_cErrorInfo = cInfo;
                CheckErroInfoLogS();

                m_cProcess = CMultiProject.PlcProcS[cInfo.GroupKey];
                m_cTag = CMultiProject.TotalTagS[cInfo.SymbolKey];

                if (m_cTag == null)
                    return;

                if (m_cProcess != null)
                {
                    //InitDetecting();
                    ShowChart();
                }

                m_cLogicData = CMultiProject.GetPlcLogicData(m_cTag);


                InitDiagram();
                ShowDiagram(false);
            }
        }

        public void ShowErrorDiagram(CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorAnlaysisCallback cUpdate = new UpdateErrorAnlaysisCallback(ShowErrorDiagram);
                this.Invoke(cUpdate, new object[] {cInfo});
            }
            else
            {
                Clear();

                if (cInfo == null)
                    return;

                m_cReader = CMultiProject.LogReader;

                if (m_cReader != null && !m_cReader.IsConnected)
                    m_cReader.Connect();

                m_cErrorInfo = cInfo;
                CheckErroInfoLogS();

                m_cTag = CMultiProject.TotalTagS[cInfo.SymbolKey];

                if (m_cTag == null)
                    return;

                m_cLogicData = CMultiProject.GetPlcLogicData(m_cTag);
                m_cReader = CMultiProject.LogReader;

                if (m_cReader != null && !m_cReader.IsConnected)
                    m_cReader.Connect();

                //분석
                AnalyzeError();
                InitDiagram();
                ShowDiagram(true);
            }
        }

        private CStep GetStepList(CTag cTag, bool bInterlock)
        {
            CStep cStep = null;

            List<CStep> lstStep = m_cLogicData.StepS.Where(b => b.Value.Address == cTag.Address).Select(b => b.Value).ToList();
            if (lstStep == null || lstStep.Count == 0)
            {
                //MessageBox.Show("하위 조건 정보가 없습니다.");
                return null;
            }

            if (bInterlock)
            {
                if (m_cErrorInfo.ErrorLogS == null || m_cErrorInfo.ErrorLogS.Count == 0)
                {
                    //MessageBox.Show("하위 조건 정보가 없습니다.");
                    return null;
                }
            }
            if (lstStep.Count == 0) return null;

            //if (lstStep.Count == 1)
            //    cStep = lstStep[0];
            if (lstStep[0].Instruction.Contains("RST") && lstStep.Count > 1)
                cStep = lstStep[1];
            else
                cStep = lstStep[0];

            return cStep;
        }
        List<string> m_lstStepKey = new List<string>();
        private CTag LastCoil(CTag cTag)
        {
            CTag cFindTag = null;
            CStep cSubStep = GetStepList(cTag, false);
            if (cSubStep == null) return cFindTag;
            if (m_lstStepKey.Contains(cSubStep.Key) == false)
                m_lstStepKey.Add(cSubStep.Key);
            else
                return cFindTag;
            CTimeLogS cFindLogS = m_cErrorInfo.ErrorLogS.GetTimeLogS(cTag.Key);
            List<string> lstTag = new List<string>();
            if (cFindLogS != null && cFindLogS.Count > 0)
            {
                for (int i = 0; i < cFindLogS.Count; i++)
                {
                    if (cFindLogS[i].Value > 0)
                    {
                        foreach (CContact cContact in cSubStep.ContactS)
                        {
                            if (cContact.ContactType != EMContactType.Bit) continue;
                            if (cContact.ContentS.Count == 0) continue;
                            cFindTag = LastCoil(cContact.ContentS[0].Tag);
                            if (cFindTag != null)
                                lstTag.Add(cFindTag.Key);
                        }
                        if (lstTag.Count == 0)
                            return cTag;
                        else
                        {
                            return CMultiProject.TotalTagS[lstTag[0]];
                        }
                    }
                }
            }

            return cFindTag;
        }

        private void AnalyzeError()
        {
            CAbnormalSymbol cSymbol = null;
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.AbnormalSymbolS.IsContainKey(m_cErrorInfo.SymbolKey))
                {
                    cSymbol = who.Value.AbnormalSymbolS.GetAbnormalSymbol(m_cErrorInfo.SymbolKey);
                    break;
                }
            }

            if (cSymbol == null)
                return;

            //CSubCoilS cCoilS = cSymbol.SubCoil.GetLastSubCoilS(m_cErrorInfo.ErrorLogS);

            //int iCount = cCoilS.Count;


            //CStep cStep = GetStepList(m_cTag, false);
            //if (cStep == null)
            //{
            //    MessageBox.Show("하위 조건 정보가 없습니다.");
            //    return;
            //}
            //m_lstStepKey.Clear();
            //m_lstStepKey.Add(cStep.Key);
            //foreach (CContact cContact in cStep.ContactS)
            //{
            //    if (cContact.ContactType != EMContactType.Bit) continue;
            //    if (cContact.ContentS.Count == 0) continue;
            //    CTag cTag = cContact.ContentS[0].Tag;
            //    //if (cTag.Description.Contains("이상") == false) continue;
            //    CTag cFindTag = LastCoil(cTag);
            //    if (cFindTag != null)
            //    {
            //        MessageBox.Show(string.Format("Text : {0}", cFindTag.Description));
            //    }
            //}
        }

        public void ShowErrorCauseDiagram(CTag cCauseTag, CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorCauseCallback cUpdate = new UpdateErrorCauseCallback(ShowErrorCauseDiagram);
                this.Invoke(cUpdate, new object[] { cCauseTag, cInfo });
            }
            else
            {
                m_cErrorInfo = cInfo;
                CheckErroInfoLogS();

                m_cLogicData = CMultiProject.GetPlcLogicData(m_cTag);
                m_cReader = CMultiProject.LogReader;

                if (m_cReader != null && !m_cReader.IsConnected)
                    m_cReader.Connect();

                InitDiagram();

                List<CStep> lstStep = CMultiProject.GetStepList(cCauseTag.Key);

                if (lstStep == null || lstStep.Count == 0)
                    return;

                bool bInterlock = false;

                if (m_cErrorInfo.ErrorType != "CycleOver")
                    bInterlock = true;

                CTimeLogS cLogS;
                foreach (CStep cStep in lstStep)
                {
                    cLogS = m_cErrorInfo.ErrorLogS.GetTimeLogS(cStep.CoilS.First().RefTagS.KeyList);

                    if (cLogS == null || cLogS.Count == 0)
                        continue;

                    ShowDiagram(cStep, bInterlock);
                }
            }
        }

        public void Clear()
        {
            exTreeGX.Nodes.Clear();
            ucFlowResultViewer.Clear();
            ucLogicDiagramS.ClearTabs();
        }

        #endregion


        #region Private Methods

        private void CheckErroInfoLogS()
        {
            if (m_cErrorInfo.ErrorLogS != null && m_cErrorInfo.ErrorLogS.Count != 0)
                return;

            m_cErrorInfo.ErrorLogS = m_cReader.GetErrorLogS(m_cErrorInfo.ErrorID);
        }

        private CCycleInfo GetErrorCycleInfo()
        {
            CCycleInfo cInfo = null;

            CCycleInfoS cInfoS = m_cReader.GetCycleInfoS(m_cErrorInfo.ProjectID, m_cErrorInfo.GroupKey, m_cErrorInfo.CycleID);

            if (cInfoS == null || cInfoS.Count == 0)
                return null;

            foreach (var who in cInfoS)
            {
                if (who.Value.CycleType == EMCycleRunType.Error || who.Value.CycleType == EMCycleRunType.ErrorEnd)
                {
                    if (who.Value.CycleStart < m_cErrorInfo.ErrorTime && who.Value.CycleEnd > m_cErrorInfo.ErrorTime)
                    {
                        cInfo = who.Value;
                        break;
                    }
                }
            }

            return cInfo;
        }

        private bool VerifyParameter()
        {
            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ShowChart()
        {
            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(m_cProcess.Name, m_cProcess.KeySymbolS, m_cErrorInfo.CycleStart, m_cErrorInfo.ErrorTime, m_cErrorInfo.ErrorLogS, true);
            if (cItemS == null || cItemS.Count == 0)
                return;

            CFlowCompareResultS cResultS = CMultiProject.MasterPatternS.Compare(m_cErrorInfo.GroupKey, m_cErrorInfo.CurrentRecipe, cItemS, true);
            if (cResultS == null)
            {
                cResultS = new CFlowCompareResultS();
                cResultS.FlowItemS = cItemS;
            }

            cResultS.Key = m_cProcess.Name;
            if (cResultS.MasterFlow != null)
                cResultS.MasterFlow.Normalize(m_cErrorInfo.CycleStart);

            ucFlowResultViewer.ShowChart(cResultS);
        }

        private void InitDiagram()
        {
            if (m_cLogicData != null)
            {
                if (m_cDiagram != null)
                {
                    m_cDiagram.UEventDrawDiagram -= new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
                    m_cDiagram.Dispose();
                    m_cDiagram = null;
                }

                m_cDiagram = new CLogicDiagram(m_cLogicData.StepS, m_cLogicData.TagS, ucLogicDiagramS);
                m_cDiagram.UEventDrawDiagram += new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
            }
        }

        private void ShowDiagram(bool bInterlock)
        {
            CStep cStep = GetStepList(m_cTag, bInterlock);
            if (cStep == null)
            {
                MessageBox.Show("하위 조건 정보가 없습니다.");
                return;
            }

            CTimeLogS cLogS = m_cErrorInfo.ErrorLogS;
            m_cDiagram.ShowDiagram(cStep, cLogS, true, true, true, bInterlock);
        }

        private void ShowDiagram(CStep cStep, bool bInterlock)
        {
            CTimeLogS cLogS = m_cErrorInfo.ErrorLogS;
            m_cDiagram.ShowDiagram(cStep, cLogS, true, true, true, bInterlock);
        }

        private void InitDetecting()
        {
            InitTreeGX();
        }

        private void InitTreeGX()
        {
            exTreeGX.Nodes.Clear();

            if (m_cErrorInfo.SymbolKey == string.Empty)
                return;
            Node BaseNode = new Node();
            BaseNode = SettingTextNode(m_cErrorInfo.GroupKey);
            Node nodeRoot = null;
            Node nodeChild = null;

            List<CNodeRank> lstNodeRank = new List<CNodeRank>();

            nodeRoot = SettingNode(m_cTag);
            exTreeGX.Nodes.AddRange(new Node[] { BaseNode });
            BaseNode.Nodes.AddRange(new Node[] { nodeRoot });

            CKeySymbol cSymbol = m_cProcess.KeySymbolS[m_cTag.Key];

            if (cSymbol != null)
            {
                foreach (CTag cSubTag in cSymbol.FirstTagList)
                {
                    nodeChild = SettingNode(cSubTag);
                    nodeRoot.Nodes.AddRange(new Node[] {nodeChild});
                }
            }

            nodeRoot.Expanded = true;

            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(m_cProcess.Name, m_cProcess.KeySymbolS, m_cErrorInfo.CycleStart, m_cErrorInfo.ErrorTime, m_cErrorInfo.ErrorLogS, true);
            CFlowCompareResultS cResultS = CMultiProject.MasterPatternS.Compare(m_cErrorInfo.GroupKey, m_cErrorInfo.CurrentRecipe, cItemS, true);

            GroupComparePattern(nodeRoot, cResultS, lstNodeRank);
        }

        private CTimeLogS GetTotalTimeLogS(DateTime dtFrom, DateTime dtTo)
        {
            CTimeLogS cLogS = new CTimeLogS();
            CTimeLogS cTempLogS = null;

            cTempLogS = m_cReader.GetTimeLogS(m_cProcess.KeySymbolS.Keys.ToList(), dtFrom, dtTo);

            if(cTempLogS != null && cTempLogS.Count != 0)
                cLogS.AddRange(cTempLogS);

            //foreach (CKeySymbol cSymbol in m_cProcess.KeySymbolS.Values)
            //{
            //    if (cSymbol.SubDepthTagList != null && cSymbol.SubDepthTagList.Count != 0)
            //    {
            //        foreach (CTag cTag in cSymbol.SubDepthTagList)
            //        {
            //            cTempLogS = m_cReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);
                        
            //            if(cTempLogS != null && cTempLogS.Count != 0)
            //                cLogS.AddRange(cTempLogS);
            //        }
            //    }
            //    System.Threading.Thread.Sleep(1);
            //}

            return cLogS;
        }

        private Node SettingTextNode(string sText)
        {
            Node node = new Node();
            node.CellLayout = eCellLayout.Vertical;
            node.Name = sText;
            node.DragDropEnabled = false;
            ElementStyle styleRootBlock = GetDefaultNodeStyle(CHighlightRankingColor.Normal);
            node.Style = styleRootBlock;
            Cell cellNodeGroup = CellStyleSetting();
            Cell cellText = CellStyleSetting();
            cellNodeGroup.Text = "Group";
            cellText.Text = sText;
            node.Cells.Add(cellNodeGroup);
            node.Cells.Add(cellText);
            node.Expanded = true;
            return node;
        }

        private Node SettingNode(CTag cTag)
        {
            Node node = new Node();

            node.CellLayout = eCellLayout.Vertical;
            node.Name = cTag.Key;
            node.DragDropEnabled = false;
            ElementStyle styleRootBlock = GetDefaultNodeStyle(CHighlightRankingColor.Normal);
            node.Style = styleRootBlock;

            Cell cellText = CellStyleSetting();
            Cell cellAddress = CellStyleSetting();
            Cell cellDescription = CellStyleSetting();
            if (cTag.IsEndContact())
                cellText.Text = "[Contact]";
            else
                cellText.Text = "[Coil]";
            cellAddress.Text = cTag.Address;
            cellDescription.Text = cTag.Description;
            node.Cells.Add(cellText);
            node.Cells.Add(cellAddress);
            node.Cells.Add(cellDescription);

            return node;
        }

        private void GroupComparePattern(Node node, CFlowCompareResultS cResultS, List<CNodeRank> lstNodeRank)
        {
            // Rank //
            //1. Sub Node가 Missing일 때 발현 순서
            //2. Missing이 아닐 때 MasterPattern 시점과 가장 근접한 시점의 시작지점을 갖은 Node


            CFlow cMasterFlow = cResultS.MasterFlow;
            CFlowItemS cFlowItemS = cMasterFlow.FlowItemS;
            //Group Master Pattern의 시작 시간(Error 시점)
            DateTime dtMasterStart = DateTime.MinValue;
            DateTime dtMasterEnd = DateTime.MinValue;
            DateTime dtCoilStart = DateTime.MinValue;


            CFlowItem cFlowItem = cFlowItemS[node.Name];
            CTimeNodeS cItemNodeS = cFlowItemS[node.Name].TimeNodeS;

            for (int i = 0; i < cItemNodeS.Count; i++)
            {
                if (dtMasterStart == DateTime.MinValue)
                    dtMasterStart = cItemNodeS[i].Start;
                else if (dtMasterStart <= cItemNodeS[i].Start)
                    dtMasterStart = cItemNodeS[i].Start;

                if (dtMasterEnd == DateTime.MinValue)
                    dtMasterEnd = cItemNodeS[i].End;
                else if (dtMasterEnd <= cItemNodeS[i].End)
                    dtMasterEnd = cItemNodeS[i].End;
            }

            if (m_cErrorInfo.ErrorLogS != null || m_cErrorInfo.ErrorLogS.Count != 0)
            {
                for (int i = m_cErrorInfo.ErrorLogS.Count - 1; i >= 0; i--)
                {
                    CTimeLog cTimeLog = m_cErrorInfo.ErrorLogS[i];
                    if (cTimeLog.Key.Equals(node.Name))
                    {
                        dtCoilStart = cTimeLog.Time;
                        break;
                    }
                }
            }

            if (dtCoilStart != DateTime.MinValue)
                ComparePattern(node, dtCoilStart, cMasterFlow, lstNodeRank);
            else
                lstNodeRank = ComparePattern(node, dtMasterStart, cMasterFlow, lstNodeRank);

            if (cFlowItem.SubFlow != null)
                for (int i = 0; i < node.Nodes.Count; i++)
                    if (dtCoilStart != DateTime.MinValue)
                        lstNodeRank = ComparePattern(node.Nodes[i], dtCoilStart, cFlowItem.SubFlow, lstNodeRank);
                    else
                        lstNodeRank = ComparePattern(node.Nodes[i], dtMasterStart, cFlowItem.SubFlow, lstNodeRank);

            HighLightNode(lstNodeRank);
        }

        private List<CNodeRank> ComparePattern(Node node, DateTime dtRoleTime, CFlow cMasterFlow, List<CNodeRank> lstNodeRank)
        {
            CFlowItemS cFlowItemS = cMasterFlow.FlowItemS;

            //Group Master Pattern의 시작 시간(Error 시점)
            DateTime dtMasterStart = DateTime.MinValue;
            DateTime dtMasterEnd = DateTime.MinValue;
            DateTime dtError = DateTime.MinValue;

            CFlowItem cFlowItem = cFlowItemS[node.Name];
            CTimeNodeS cItemNodeS = cFlowItemS[node.Name].TimeNodeS;
            CTimeLog cTimeLog = null;

            string sMasterState = "";
            string sLogState = "";

            Cell cellCurrentValue = new Cell();
            Cell cellMasterValue = new Cell();
            Cell cellMatchResult = new Cell();

            cellCurrentValue = CellStyleSetting();
            cellMasterValue = CellStyleSetting();
            cellMatchResult = CellStyleSetting();


            cellMasterValue.Text = "Pattern value : ";
            cellCurrentValue.Text = "Current Value : ";

            for (int i = 0; i < cItemNodeS.Count; i++)
            {
                if (dtMasterStart == DateTime.MinValue)
                    dtMasterStart = cItemNodeS[i].Start;
                else if (dtMasterStart <= cItemNodeS[i].Start)
                    dtMasterStart = cItemNodeS[i].Start;

                if (dtMasterEnd == DateTime.MinValue)
                    dtMasterEnd = cItemNodeS[i].End;
                else if (dtMasterEnd <= cItemNodeS[i].End)
                    dtMasterEnd = cItemNodeS[i].End;

                if (cItemNodeS[i].Start <= dtRoleTime)
                {
                    sMasterState = "On";
                }
                else if (cItemNodeS[i].End <= dtRoleTime)
                {
                    sMasterState = "Off";
                }
                else
                {
                    sMasterState = "None";
                }
            }
            if (sMasterState == "")
                sMasterState = "None";
            cellMasterValue.Text = cellMasterValue.Text + sMasterState;
            // Master Pattern과 Log를 비교하여 Match or Non-Match 확인
            // 이 때 비교 중심은 해당 시점의 Log Value가 0인지 아닌지
            DateTime dtFrom = dtMasterStart;
            DateTime dtTo = dtMasterEnd;

            if (m_cErrorInfo.ErrorLogS == null || m_cErrorInfo.ErrorLogS.Count == 0)
            {
                //None
                sLogState = "None";
            }
            else
            {
                for (int i = m_cErrorInfo.ErrorLogS.Count - 1; i >= 0; i--)
                {
                    cTimeLog = m_cErrorInfo.ErrorLogS[i];
                    if (cTimeLog.Key.Equals(node.Name))
                    {

                        if (cTimeLog.Time >= dtRoleTime)
                        {
                            if (cTimeLog.Value == 0)
                            {
                                sLogState = "On";
                                dtError = cTimeLog.Time;
                            }
                            else if (cTimeLog.Value == 1)
                            {
                                sLogState = "None";
                                dtError = cTimeLog.Time;
                            }
                        }
                        else
                        {
                            if (cTimeLog.Value == 0)
                            {
                                if (sMasterState == "On")
                                {
                                    if (sLogState == "None")
                                    {
                                        sLogState = "Off";
                                        dtError = cTimeLog.Time;
                                    }

                                }
                            }
                            if (cTimeLog.Value == 1)
                            {
                                if (sLogState == "" || sLogState == "None")
                                {
                                    sLogState = "On";
                                    dtError = cTimeLog.Time;
                                }
                            }
                        }
                    }
                }
            }

            if (sLogState == "")
            {
                sLogState = "None";
                dtError = DateTime.MinValue;
            }

            cellCurrentValue.Text = cellCurrentValue.Text + sLogState;

            node.Cells.Add(cellCurrentValue);
            node.Cells.Add(cellMasterValue);
            node.Cells.Add(cellMatchResult);

            if (sMasterState != sLogState)
            {
                CNodeRank cNodeRank = new CNodeRank();
                if (node.Name != m_cErrorInfo.SymbolKey)
                {
                    cNodeRank.Node = node;
                    cNodeRank.TimeInfo = dtError;
                    cNodeRank.Status = sLogState;
                    lstNodeRank.Add(cNodeRank);
                }
                else
                {
                    node.Style.BackColor = CHighlightRankingColor.SRank;
                }
            }

            return lstNodeRank;
        }

        private void HighLightNode(List<CNodeRank> lstNodeRank)
        {
            if (lstNodeRank.Count == 0)
                return;

            double nTotalSnd = -1;
            double nResult = -1;
            double nSub = 0.001;
            SortedList<double, Node> lstNode = new SortedList<double, Node>();
            for (int i = 0; i < lstNodeRank.Count; i++)
            {
                if (lstNodeRank[i].TimeInfo == DateTime.MinValue)
                    nResult = 0;
                else
                {
                    nTotalSnd = m_cErrorInfo.CycleStart.Subtract(lstNodeRank[i].TimeInfo).TotalSeconds;
                    if (nResult == -1)
                        nResult = nTotalSnd;
                }


                if (lstNode.ContainsKey(nResult))
                {
                    nResult = nResult + nSub;
                    lstNode.Add(nResult, lstNodeRank[i].Node);
                    nSub = nSub + 0.001;
                }
                else
                {
                    lstNode.Add(nResult, lstNodeRank[i].Node);
                }
            }

            int iRound = lstNode.Count - 1;

            for (int i = 0; i <= iRound; i++)
            {
                if (i == 0)
                {
                    lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.SRank;
                }
                else if (i != 0 && i < 3)
                {
                    lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.ARank;
                }
                else
                {
                    lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.BRank;
                }
            }
        }

        private Cell CellStyleSetting()
        {
            Cell cellRow = new Cell();
            ElementStyle style = new ElementStyle();
            style = new DevComponents.Tree.ElementStyle();
            style.TextColor = Color.Black;
            cellRow.StyleNormal = style;
            return cellRow;
        }

        private ElementStyle GetDefaultNodeStyle(Color Highlihgt)
        {
            ElementStyle style = new ElementStyle();
            style.BackColor = Highlihgt;
            style.BackColor2 = System.Drawing.Color.White;
            style.BackColorGradientAngle = 90;
            style.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderBottomWidth = 1;
            style.BorderColor = System.Drawing.Color.DarkGray;
            style.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderLeftWidth = 1;
            style.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderRightWidth = 1;
            style.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderTopWidth = 1;
            style.CornerDiameter = 4;
            style.CornerType = DevComponents.Tree.eCornerType.Rounded;
            style.Description = "Blue";
            style.Name = "Default";
            style.PaddingBottom = 1;
            style.PaddingLeft = 1;
            style.PaddingRight = 1;
            style.PaddingTop = 1;
            style.TextColor = System.Drawing.Color.Black;


            return style;
        }

        #endregion

        private void FrmErrorAnalysisViewer_Load(object sender, EventArgs e)
        {

        }

        private void btnChartZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomIn();
        }

        private void btnChartZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomOut();
        }

        private void btnChartItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemUp();
        }

        private void btnChartItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemDown();
        }

        private void btnDiagramZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDiagramZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDiagramMaximize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(true);
        }

        private void btnDiagramMinimize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(false);
        }

        private void m_cDiagram_UEventDrawDiagram(Node selectNode, CLDRung cLDRung, DateTime dtCurrent)
        {
            if (m_bFirst)
            {
                m_bFirst = false;
                return;
            }

            if (cLDRung == null)
                return;

            cLDRung.TimeLogS = m_cErrorInfo.ErrorLogS;
        }

        private void btnDiagramClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucLogicDiagramS.ClearTabs();
        }

        private void btnPatternClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.Clear();
        }

    }

    class CHighlightRankingColor
    {
        public static Color Normal = Color.YellowGreen;
        public static Color SRank = Color.Red;
        public static Color ARank = Color.OrangeRed;
        public static Color BRank = Color.Orange;
    }

    class CNodeRank
    {
        public DateTime TimeInfo;
        public Node Node;
        public string Status;
    }
}
