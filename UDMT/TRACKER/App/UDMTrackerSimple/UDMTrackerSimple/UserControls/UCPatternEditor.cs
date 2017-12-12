using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.UI.TimeChart;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerGenerateMasterPattern(string sProcess, CCycleInfoS cCycleInfoS);
    public delegate void UEventHandlerDeleteMasterPattern();
    public delegate void UEventHandlerChangeMasterPattern(bool bChanged);

    public partial class UCPatternEditor : DevExpress.XtraEditors.XtraUserControl, IDisposable
    {
        private CPlcProc m_cProcess = null;
        private CCycleInfoS m_cCycleInfoS = null;
        public event UEventHandlerGenerateMasterPattern UEventGenerateMasterPattern = null;
        public event UEventHandlerDeleteMasterPattern UEventDeleteMasterPattern = null;
        public event UEventHandlerChangeMasterPattern UEventChangeMasterPattern = null;


        #region Initialize/Dispose

        public UCPatternEditor()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            m_cProcess = null;

            ucChart.Clear();

            if (m_cCycleInfoS != null)
            {
                m_cCycleInfoS.Clear();
                m_cCycleInfoS = null;
            }
        }

        #endregion

        public CPlcProc Process
        {
            get { return m_cProcess; }
            set { m_cProcess = value; }
        }

        public CCycleInfoS CycleInfoS
        {
            get { return m_cCycleInfoS; }
            set { m_cCycleInfoS = value; }
        }

        private void InitMasterPatternInfo()
        {
            if (m_cProcess == null)
                return;

            cboRecipe.EditValue = null;
            cboShape.EditValue = null;
            cboRecipe.Properties.Items.Clear();
            cboShape.Properties.Items.Clear();

            string sName = m_cProcess.Name;

            if (CMultiProject.MasterPatternS == null)
                return;

            if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                return;

            List<string> lstRecipe = CMultiProject.MasterPatternS[sName].Keys.ToList();

            foreach (string sRecipe in lstRecipe)
                cboRecipe.Properties.Items.Add(sRecipe);

            if(lstRecipe.Count > 0)
                cboRecipe.EditValue = lstRecipe.First();
        }

        public void UpdateMasterPatternView(string sRecipe)
        {
            if (m_cProcess == null)
                return;

            cboRecipe.EditValue = null;
            cboShape.EditValue = null;
            cboRecipe.Properties.Items.Clear();
            cboShape.Properties.Items.Clear();

            string sName = m_cProcess.Name;

            if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                return;

            List<string> lstRecipe = CMultiProject.MasterPatternS[sName].Keys.ToList();

            foreach (string sValue in lstRecipe)
                cboRecipe.Properties.Items.Add(sValue);

            cboRecipe.EditValue = sRecipe;

            ucChart.Clear();

            if(CMultiProject.MasterPatternS[sName][sRecipe].Count > 0)
                ShowMasterPatternChart(sRecipe, 0);
        }

        private void InitProcessInfo()
        {
            if (m_cProcess == null)
                return;

            grdCycleStartConditionS.DataSource = null;
            grdCycleStartConditionS.DataSource = m_cProcess.CycleStartConditionS;
            grvCycleStartConditionS.BestFitColumns();
            grdCycleStartConditionS.RefreshDataSource();

            grdCycleEndConditionS.DataSource = null;
            grdCycleEndConditionS.DataSource = m_cProcess.CycleEndConditionS;
            grvCycleEndConditionS.BestFitColumns();
            grdCycleEndConditionS.RefreshDataSource();

            grdKeySymbolS.DataSource = null;
            grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
            grvKeySymbolS.BestFitColumns();
            grdKeySymbolS.RefreshDataSource();
        }

        private void InitChart()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;

            ucChart.GanttTree.ContextMenuStrip = cntxGanttTree;
        }

        private void InitInterval()
        {
            txtInterval.Text = "";
            dtpkIndicator1.EditValue = "00:00:00.000";
            dtpkIndicator2.EditValue = "00:00:00.000";
        }

        public void InitCycleGrid()
        {
            if (m_cCycleInfoS == null || m_cCycleInfoS.Count == 0)
                return;

            //CCycleInfo cInfo = null;
            //int iCount = 0;
            //for (int i = m_cCycleInfoS.Count - 1; i > 0; i--)
            //{
            //    if (iCount < 20)
            //        iCount++;
            //    else
            //        break;

            //    cInfo = m_cCycleInfoS.ElementAt(i).Value;
            //    cInfo.IsSelected = true;
            //}

            grdCycle.DataSource = m_cCycleInfoS.Values.ToList();
            grdCycle.RefreshDataSource();
        }

        public void ClearEditor()
        {
            try
            {
                ucChart.Clear();
                InitInterval();

                if(m_cCycleInfoS != null)
                    m_cCycleInfoS.Clear();

                m_cCycleInfoS = null;
                grdCycle.DataSource = null;
                grdCycle.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPatternEditor", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetManualMasterPatternItem(string sRecipe, int iShape)
        {
            int[] arrRow = grvKeySymbolS.GetSelectedRows();

            if (arrRow.Length <= 0)
            {
                XtraMessageBox.Show("선택된 Key Symbol이 존재하지 않습니다!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<CKeySymbol> lstSelectedSymbol = new List<CKeySymbol>();
            CKeySymbol cSymbol = null;
            foreach (int iRowHandle in arrRow)
            {
                if (grvKeySymbolS.GetRow(iRowHandle).GetType() != typeof (CKeySymbol))
                    continue;

                cSymbol = (CKeySymbol) grvKeySymbolS.GetRow(iRowHandle);

                if (cSymbol == null)
                    continue;

                lstSelectedSymbol.Add(cSymbol);
            }

            if (lstSelectedSymbol.Count == 0)
                return;

            CFlow cFlow = CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe][iShape];

            CGanttItem cGanttRecipe = (CGanttItem)ucChart.GanttTree.ItemS.FindHasData(sRecipe);
            
            if (cGanttRecipe == null)
                return;

            CGanttItem cGanttIndex = null;//(CGanttItem)cGanttRecipe.ItemS.FindHasData(iShape);

            foreach (var who in cGanttRecipe.ItemS)
            {
                cGanttIndex = (CGanttItem) who;

                if (cGanttIndex == null)
                    continue;

                CFlowItem cItem = null;
                CGanttItem cGanttItem = null;
                CTag cTag = null;
                foreach (CKeySymbol cKeySymbol in lstSelectedSymbol)
                {
                    if (cKeySymbol.Tag != null)
                        cTag = cKeySymbol.Tag;
                    else if (CMultiProject.TotalTagS.ContainsKey(cKeySymbol.TagKey))
                        cTag = CMultiProject.TotalTagS[cKeySymbol.TagKey];
                    else continue;

                    if (cFlow.FlowItemS.ContainsKey(cTag.Key))
                        continue;

                    cItem = new CFlowItem();
                    cItem.Key = cTag.Key;
                    cItem.Group = m_cProcess.Name;
                    cItem.Description = cTag.GetDescription();
                    cItem.First = cFlow.First;
                    cItem.Last = cFlow.Last;
                    cItem.IsManualAdd = true;

                    cFlow.FlowItemS.Add(cItem.Key, cItem);

                    cGanttItem = new CGanttItem(new object[] {cItem.Key, cItem.Description});
                    cGanttItem.Data = cItem;
                    cGanttIndex.ItemS.Add(cGanttItem);
                }

                ucChart.Refresh();

                arrRow = null;
                lstSelectedSymbol.Clear();
                lstSelectedSymbol = null;
                cSymbol = null;
                cFlow = null;
                cGanttRecipe = null;
                cGanttIndex = null;
                cItem = null;
                cGanttItem = null;
                cTag = null;
            }
        }

        private void SetMasterPattern(string sRecipe, int iShape)
        {
            CFlow cFlow = CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe][iShape];
            //CRowItem cRecipe = ucChart.GanttTree.ItemS.FindHasData(sRecipe);

            //if (cRecipe == null || cRecipe.ItemS.Count < 1)
            //    return;

            //CRowItem cIndex = cRecipe.ItemS.First();
            //List<CRowItem> lstSelectItem = cIndex.ItemS;

            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

            CFlowItemS cFlowItemS = new CFlowItemS();
            CFlowItem cFlowItem = null;
            CGanttItem cGanttItem = null;
            foreach (CRowItem cItem in lstSelectItem)
            {
                if (cItem.Data != null && cItem.Data.GetType() == typeof (CFlowItem))
                {
                    cFlowItem = (CFlowItem) cItem.Data;

                    if (!cFlowItemS.ContainsKey(cFlowItem.Key))
                        cFlowItemS.Add(cFlowItem.Key, cFlowItem);

                    if (cFlowItem.IsManualAdd)
                    {
                        if (cFlowItem.TimeNodeS == null)
                            cFlowItem.TimeNodeS = new CTimeNodeS();

                        cGanttItem = (CGanttItem) cItem;

                        CTimeNode cNode = null;
                        foreach (CGanttBar cBar in cGanttItem.BarS)
                        {
                            cNode = new CTimeNode();
                            cNode.Start = cBar.StartTime;
                            cNode.End = cBar.EndTime;
                            cNode.Key = cFlowItem.Key;

                            cFlowItem.TimeNodeS.Add(cNode);
                        }
                    }
                }
            }

            if (cFlowItemS.Count != 0)
            {
                if(cFlow.FlowItemS != null)
                    cFlow.FlowItemS.Clear();

                cFlow.FlowItemS = null;

                cFlow.FlowItemS = cFlowItemS;
                XtraMessageBox.Show("해당 마스터 패턴 형태 저장 완료!!!", "마스터 패턴", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            lstSelectItem.Clear();
            lstSelectItem = null;
        }

        private void DeleteMasterPattern(string sRecipe, int iShape)
        {
            if (CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe].Count == 1)
                CMultiProject.MasterPatternS[m_cProcess.Name].Remove(sRecipe);
            else
                CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe].RemoveAt(iShape);

            XtraMessageBox.Show("해당 마스터 패턴 형태 제거 완료!!!", "마스터 패턴", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ucChart.Clear();
            InitMasterPatternInfo();

            txtFrequency.EditValue = null;
        }

        private void ShowMasterPatternChart(string sRecipe, int iShape)
        {
            //ucChart.Clear();

            ucChart.BeginUpdate();
            {
                // Draw Recipe
                CGanttItem cGanttRecipe = (CGanttItem)ucChart.GanttTree.ItemS.FindHasData(sRecipe);
                if (cGanttRecipe == null)
                {
                    ucChart.Clear();

                    cGanttRecipe = new CGanttItem(new string[] { sRecipe, "" });
                    cGanttRecipe.Data = sRecipe;
                    ucChart.GanttTree.ItemS.Add(cGanttRecipe);
                }

                // Draw Index
                CGanttItem cGanttIndex = (CGanttItem)cGanttRecipe.ItemS.FindHasData(iShape);
                if (cGanttIndex == null)
                {
                    cGanttIndex = new CGanttItem(new string[] { iShape.ToString(), "" });
                    cGanttIndex.Data = iShape;
                    cGanttRecipe.ItemS.Add(cGanttIndex);
                    cGanttRecipe.Expand();
                }

                CFlow cFlow = CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe][iShape];

                ShowFlow(cGanttIndex, cFlow, Color.DodgerBlue, false);

                cGanttIndex.Expand();

                ucChart.TimeLine.FirstVisibleTime = cFlow.First;
                ucChart.TimeLine.RangeFrom = cFlow.First;
                if (cFlow.Last > ucChart.TimeLine.RangeTo)
                    ucChart.TimeLine.RangeTo = cFlow.Last;

            }
            ucChart.EndUpdate();
        }

        private void ShowFlow(CGanttItem cGanttParent, CFlow cFlow, Color cColor, bool bExpand)
        {
            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            List<CGanttBar> lstBar;
            for (int i = 0; i < cFlow.FlowItemS.Count; i++)
            {
                cFlowItem = cFlow.FlowItemS[i];

                cGanttItem = new CGanttItem(new object[] { cFlowItem.Key, cFlowItem.Description });
                cGanttItem.Data = cFlowItem;
                cGanttParent.ItemS.Add(cGanttItem);

                lstBar = CreateBarList(cFlowItem, cColor);
                cGanttItem.BarS.AddRange(lstBar);
                lstBar.Clear();

                if (cFlowItem.SubFlow != null)
                    ShowFlow(cGanttItem, cFlowItem.SubFlow, Color.LightBlue, false);
            }

            if (bExpand)
                cGanttParent.Expand();
        }

        private List<CGanttBar> CreateBarList(CFlowItem cItem, Color cColor)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cItem.TimeNodeS.Count; i++)
            {
                cNode = cItem.TimeNodeS[i];
                cBar = CreateBar(cNode, cColor);
                lstBar.Add(cBar);
            }

            return lstBar;
        }

        private CGanttBar CreateBar(CTimeNode cNode, Color cColor)
        {
            CGanttBar cBar = new CGanttBar();
            cBar.StartTime = cNode.Start;
            cBar.EndTime = cNode.End;
            //cBar.Data = cNode;
            cBar.Color = cColor;

            return cBar;
        }

        private CTagS GetSortTagS(CTagS cTagS, CCycleInfo cInfo)
        {
            CTagS cSortTagS = new CTagS();

            CTimeLogS cLogS = CMultiProject.LogReader.GetTimeLogS(cTagS.Keys.ToList(), cInfo.CycleStart, cInfo.CycleEnd);

            if (cLogS == null || cLogS.Count == 0)
                return null;

            CTimeLogS cOnLogS = new CTimeLogS();

            foreach (var who in cTagS)
            {

                CTimeLogS cSumLogS = cLogS.GetTimeLogS(who.Key, 1);
                if(cSumLogS != null && cSumLogS.Count > 0)
                    cOnLogS.AddRange(cSumLogS);
            }

            cOnLogS.Sort();

            foreach (var who in cOnLogS)
            {
                if(m_cProcess.ChartViewTagS.ContainsKey(who.Key))
                    cSortTagS.Add(m_cProcess.ChartViewTagS[who.Key]);
            }

            cLogS.Clear();
            cLogS = null;

            cOnLogS.Clear();
            cOnLogS = null;

            return cSortTagS;
        }

        private void ShowGanttChart(CCycleInfoS cCycleInfoS, DateTime dtTotalFrom, DateTime dtTotalTo)
        {
            DateTime dtFirstVisible = DateTime.MinValue;
            CGanttItem cItem = null;
            List<CGanttBar> lstBar = null;
            CTimeNodeS cNodeS = null;
            CTimeLogS cTotalLogS = new CTimeLogS();
            CTimeLogS cLogS = null;
            bool bFirst = true;

            ucChart.Clear();
            InitInterval();

            CTagS cTagS = m_cProcess.KeySymbolS.GetTagS();

            if (cTagS == null || cTagS.Count == 0)
                return;

            CTagS cSortTagS = GetSortTagS(cTagS, cCycleInfoS.First().Value);

            if (cSortTagS == null)
                cSortTagS = cTagS;

            if (cSortTagS.Count == 0)
                cSortTagS = cTagS;

            ucChart.BeginUpdate();
            {
                foreach (CTag cTag in cSortTagS.Values)
                {
                    cItem = CreateGanttItem(cTag);

                    foreach (CCycleInfo cCycleInfo in cCycleInfoS.Values)
                    {
                        cLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, cCycleInfo.CycleStart, cCycleInfo.CycleEnd);

                        if (cLogS == null || cLogS.Count == 0)
                            continue;

                        if (cLogS.Count == 1)
                        {
                            CTimeLogS cTempLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, cCycleInfo.CycleEnd);
                            if (cTempLogS != null)
                            {
                                CTimeLog cTempLog = cTempLogS.GetFirstLog(cTag.Key, cLogS[0].Time);

                                if (cTempLog != null)
                                    cLogS.Add(cTempLog);
                            }
                            cTempLogS.Clear();
                            cTempLogS = null;
                        }

                        if (cLogS.Count == 2 && cLogS.First().Value == 0 && cLogS.Last().Value == 1)
                        {
                            CTimeLogS cTempLogS = CMultiProject.LogReader.GetLimitTimeLogS(cTag.Key, cLogS.Last().Time, 1, 0);
                            if (cTempLogS != null)
                            {
                                CTimeLog cTempLog = cTempLogS.GetFirstLog(cTag.Key, cLogS[1].Time, 0);

                                if (cTempLog != null)
                                    cLogS.Add(cTempLog);
                            }

                            cLogS.RemoveAt(0);

                            cTempLogS.Clear();
                            cTempLogS = null;
                        }

                        if (bFirst)
                        {
                            dtFirstVisible = cLogS.FirstTime;
                            bFirst = false;
                        }
                        else
                        {
                            if (dtFirstVisible > cLogS.FirstTime)
                                dtFirstVisible = cLogS.FirstTime;
                        }

                        cTotalLogS.AddRange(cLogS);

                        cLogS.Clear();
                        cLogS = null;
                    }

                    if (cTotalLogS.Count > 0)
                    {
                        cTotalLogS.UpdateTimeRange();

                        cNodeS = new CTimeNodeS(cTag, cTotalLogS, dtTotalFrom, dtTotalTo);
                        if(cNodeS == null)
                            cNodeS = new CTimeNodeS();
                    }
                    else
                        cNodeS = new CTimeNodeS();

                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue);
                    cItem.BarS.AddRange(lstBar);
                    ucChart.GanttTree.ItemS.Add(cItem);

                    lstBar.Clear();
                    lstBar = null;

                    cTotalLogS.Clear();

                    if (cNodeS != null)
                    {
                        cNodeS.Clear();
                        cNodeS = null;
                    }
                }

                cTotalLogS.Clear();
                cTotalLogS = null;

                ucChart.TimeLine.RangeFrom = dtTotalFrom;
                ucChart.TimeLine.RangeTo = dtTotalTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtTotalFrom;
            }
            ucChart.EndUpdate();


            Console.WriteLine(ucChart.GanttTree.ItemS.Count);

            cTagS.Clear();
            cTagS = null;
            cSortTagS.Clear();
            cSortTagS = null;
        }

        private List<CGanttBar> CreateBarList(CTimeNodeS cNodeS, Color cColor)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cNodeS.Count; i++)
            {
                cNode = cNodeS[i];
                cBar = CreateBar(cNode, cColor);
                lstBar.Add(cBar);
            }

            return lstBar;
        }

        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
            cItem.Data = cTag;

            return cItem;
        }


        private bool CheckSelectedCycle()
        {
            bool bOK = true;

            if (m_cCycleInfoS.Where(x => x.Value.IsSelected == true).Count() < 1)
            {
                XtraMessageBox.Show("마스터 패턴을 만들기 위해 선택된 사이클이 존재하지 않습니다.\r\n사이클을 선택해주세요.", "Cycle Check",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cCycleInfoS.Where(x => x.Value.IsSelected == true).Count() < 5)
            {
                if (
                    XtraMessageBox.Show(
                        "마스터 패턴을 생성하기 위한 사이클의 개수가 너무 적습니다.\r\n마스터 패턴을 생성하기 위한 최소 사이클의 개수는 5개입니다.\r\n그래도 마스터 패턴을 생성하시겠습니까?",
                        "Cycle Check", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return false;
            }

            return bOK;
        }


        private void UCPatternEditor_Load(object sender, EventArgs e)
        {
            try
            {
                InitMasterPatternInfo();
                InitChart();
                InitInterval();
                InitCycleGrid();
                InitProcessInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ucChart.Clear();
                InitInterval();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                ucChart.TimeLine.ZoomIn();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                ucChart.TimeLine.ZoomOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                if (m_cCycleInfoS == null || m_cCycleInfoS.Count == 0)
                {
                    XtraMessageBox.Show("해당 공정의 사이클 로그 데이터가 존재하지 않습니다.\r\n수집을 다시 진행해 주세요.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!CheckSelectedCycle())
                    return;

                if (UEventGenerateMasterPattern != null)
                    UEventGenerateMasterPattern(m_cProcess.Name, m_cCycleInfoS);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMasterPatternShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                string sName = m_cProcess.Name;

                if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                {
                    XtraMessageBox.Show("해당 공정의 Master Pattern이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof (string))
                    return;

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof (int))
                    return;

                string sRecipe = (string) cboRecipe.EditValue;
                int iShape = (int) cboShape.EditValue;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    ShowMasterPatternChart(sRecipe, iShape);
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCycleAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                int[] arrRow = grvCycle.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                    return;

                object obj = null;
                CCycleInfo cInfo = null;
                foreach (int iRowHandle in arrRow)
                {
                    obj = grvCycle.GetRow(iRowHandle);

                    if (obj == null || obj.GetType() != typeof (CCycleInfo))
                        continue;

                    cInfo = (CCycleInfo) obj;
                    cInfo.IsSelected = true;
                }

                grdCycle.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCycleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                int[] arrRow = grvCycle.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                    return;

                object obj = null;
                CCycleInfo cInfo = null;
                foreach (int iRowHandle in arrRow)
                {
                    obj = grvCycle.GetRow(iRowHandle);

                    if (obj == null || obj.GetType() != typeof(CCycleInfo))
                        continue;

                    cInfo = (CCycleInfo)obj;
                    cInfo.IsSelected = false;
                }

                grdCycle.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCycleShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                int[] arrRow = grvCycle.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                    return;

                object obj = null;
                CCycleInfoS cInfoS = new CCycleInfoS();
                CCycleInfo cInfo = null;
                foreach (int iRowHandle in arrRow)
                {
                    obj = grvCycle.GetRow(iRowHandle);

                    if (obj == null || obj.GetType() != typeof (CCycleInfo))
                        continue;

                    cInfo = (CCycleInfo)obj;
                    if(!cInfoS.ContainsKey(cInfo.CycleID))
                        cInfoS.Add(cInfo.CycleID, cInfo);
                }

                if (cInfoS.Count == 0)
                    return;

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MinValue;

                List<int> lstKey = cInfoS.Keys.ToList();
                dtFrom = cInfoS[lstKey.Min()].CycleStart;
                dtTo = cInfoS[lstKey.Max()].CycleEnd;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    ShowGanttChart(cInfoS, dtFrom, dtTo);
                }
                SplashScreenManager.CloseDefaultWaitForm();

                cInfoS.Clear();
                cInfoS = null;

                lstKey.Clear();
                lstKey = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

                if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                    ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);

                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
                ucChart.TimeLine.UpdateLayout();

                if (ucChart.TimeLine.TimeIndicatorS.Count > 0)
                    dtpkIndicator1.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[0].Time;

                if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                {
                    dtpkIndicator2.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[1].Time;

                    TimeSpan tsSpan =
                        ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                    txtInterval.Text = nInterval.ToString();
                }
                else
                {
                    txtInterval.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            try
            {
                if (ucChart.TimeLine.TimeIndicatorS.Count == 0) return;
                else if (ucChart.TimeLine.TimeIndicatorS.Count == 1)
                    dtpkIndicator1.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[0].Time;
                else
                {
                    dtpkIndicator1.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[0].Time;
                    dtpkIndicator2.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[1].Time;

                    TimeSpan tsSpan =
                        ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                    txtInterval.Text = nInterval.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            try
            {
                MouseEventArgs mouseEvent = (MouseEventArgs) e;
                if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    ucChart.TimeLine.TimeIndicatorS.Clear();
                    ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
                    ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

                    dtpkIndicator1.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[0].Time;
                    dtpkIndicator2.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[1].Time;

                    TimeSpan tsSpan =
                        ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                    txtInterval.Text = nInterval.ToString();

                    ucChart.TimeLine.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboShape.Properties.Items.Clear();

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof (string))
                    return;

                string sName = m_cProcess.Name;
                string sRecipe = (string) cboRecipe.EditValue;

                CFlowS cFlowS = CMultiProject.MasterPatternS[sName][sRecipe];
                for (int i = 0; i < cFlowS.Count; i++)
                    cboShape.Properties.Items.Add(i);

                if (cFlowS.Count > 0)
                    cboShape.EditValue = cboShape.Properties.Items[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvCycle_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                var View = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                if (e.Column.FieldName != "IsSelected")
                {
                    bool bSelected = (bool) View.GetRowCellValue(e.RowHandle, View.Columns["IsSelected"]);

                    if (bSelected && e.Appearance.BackColor != Color.Orange)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                        e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMasterPatternDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CMultiProject.MasterPatternS.ContainsKey(m_cProcess.Name))
                {
                    XtraMessageBox.Show("해당 공정의 마스터 패턴은 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (
                    XtraMessageBox.Show("해당 공정의 마스터 패턴을 초기화 하시겠습니까?\r\n초기화 하면 기존의 마스터 패턴은 모두 지워집니다.",
                        "Master Pattern 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                CMultiProject.MasterPatternS.Remove(m_cProcess.Name);
                ucChart.Clear();
                InitMasterPatternInfo();
                txtFrequency.EditValue = null;

                if (UEventDeleteMasterPattern != null)
                    UEventDeleteMasterPattern();

                XtraMessageBox.Show("마스터 패턴 초기화 성공!!!", "Master Pattern 초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("마스터 패턴 초기화 실패!!!", "Master Pattern 초기화", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvCycle_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvCycle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvCycle.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvCycle.GetRow(iRowHandle);
                if (obj == null || obj.GetType() != typeof (CCycleInfo))
                    return;

                CCycleInfoS cInfoS = new CCycleInfoS();
                CCycleInfo cInfo = (CCycleInfo) obj;
                cInfoS.Add(cInfo.CycleID, cInfo);

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    ShowGanttChart(cInfoS, cInfo.CycleStart, cInfo.CycleEnd);
                }
                SplashScreenManager.CloseDefaultWaitForm();

                cInfoS.Clear();
                cInfoS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvCycle_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int iSelectedCount = grvCycle.GetSelectedRows().Length;
                txtCount.Text = iSelectedCount.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvCycle_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    int iSelectedCount = grvCycle.GetSelectedRows().Length;
                    txtCount.Text = iSelectedCount.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                if (lstSelectItem.Count == 0)
                    return;

                bool bMasterPattern = false;
                CRowItem cFirstItem = lstSelectItem.First();

                if (cFirstItem.Data.GetType() != typeof (CTag) && cFirstItem.Data.GetType() != typeof (CFlowItem))
                    return;

                if (cFirstItem.Data.GetType() == typeof (CTag))
                    bMasterPattern = false;
                else
                    bMasterPattern = true;

                if (!bMasterPattern)
                {
                    DialogResult dlgResult =
                        XtraMessageBox.Show("선택하신 " + lstSelectItem.Count + "개의 Gantt Item을 제거하시겠습니까?",
                            "Delete Gantt Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlgResult == DialogResult.No)
                        return;
                }
                else
                {
                    DialogResult dlgResult =
                        XtraMessageBox.Show("선택하신 " + lstSelectItem.Count + "개의 MasterPattern Item을 제거하시겠습니까?",
                            "Delete MasterPattern Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlgResult == DialogResult.No)
                        return;
                }

                CRowItem cShapeItem = null;
                CRowItem cRecipeItem = null;

                string sRecipe = string.Empty;
                int iShape = 0;
                CFlow cFlow = null;
                CFlowItem cFlowItem = null;
                ucChart.BeginUpdate();
                foreach (CRowItem item in lstSelectItem)
                {
                    if (bMasterPattern)
                    {
                        cShapeItem = item.Parent;
                        cRecipeItem = cShapeItem.Parent;

                        sRecipe = (string) cRecipeItem.Data;
                        iShape = (int) cShapeItem.Data;

                        cFlow = CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe][iShape];

                        cFlowItem = (CFlowItem) item.Data;
                        cFlow.FlowItemS.Remove(cFlowItem.Key);
                    }

                    ucChart.GanttTree.ItemS.Remove(item);
                }
                ucChart.EndUpdate();

                cFlow = null;
                cFlowItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("PatterEdit Setting Error : " +
                                  string.Format("Method : {0}, Message : {1}",
                                      System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void btnShapeSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                string sName = m_cProcess.Name;

                if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                {
                    XtraMessageBox.Show("해당 공정의 Master Pattern이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof (string))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof (int))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sRecipe = (string)cboRecipe.EditValue;
                int iShape = (int)cboShape.EditValue;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    SetMasterPattern(sRecipe, iShape);
                }
                SplashScreenManager.CloseDefaultWaitForm();

                if (UEventChangeMasterPattern != null)
                    UEventChangeMasterPattern(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnShapeRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                string sName = m_cProcess.Name;

                if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                {
                    XtraMessageBox.Show("해당 공정의 Master Pattern이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof(string))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof(int))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sRecipe = (string)cboRecipe.EditValue;
                int iShape = (int)cboShape.EditValue;

                if (
                    XtraMessageBox.Show(string.Format("해당 \'{0}\' 공정의 레시피 : {1}, 형태 : {2} 의 마스터 패턴을 지우시겠습니까?",m_cProcess.Name, sRecipe, iShape),
                        "마스터 패턴", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    DeleteMasterPattern(sRecipe, iShape);
                }
                SplashScreenManager.CloseDefaultWaitForm();

                if (UEventChangeMasterPattern != null)
                    UEventChangeMasterPattern(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCreateFlowChart_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                string sName = m_cProcess.Name;

                if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                {
                    XtraMessageBox.Show("해당 공정의 Master Pattern이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof(string))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof(int))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sRecipe = (string)cboRecipe.EditValue;
                int iShape = (int)cboShape.EditValue;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtFrequency.EditValue = null;

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof(string))
                    return;

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof(int))
                    return;

                string sRecipe = (string)cboRecipe.EditValue;
                int iShape = (int)cboShape.EditValue;

                CFlow cFlow = CMultiProject.MasterPatternS[m_cProcess.Name][sRecipe][iShape];

                if (cFlow.Frequency == 0)
                    txtFrequency.EditValue = 1;
                else
                    txtFrequency.EditValue = cFlow.Frequency;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMasterPatternEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasterPatternEdit.Checked)
                ucChart.GanttChart.IsEditable = true;
            else
                ucChart.GanttChart.IsEditable = false;
        }

        private void btnKeySymbolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                string sName = m_cProcess.Name;

                if (!CMultiProject.MasterPatternS.ContainsKey(sName))
                {
                    XtraMessageBox.Show("해당 공정의 Master Pattern이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (cboRecipe.EditValue == null || cboRecipe.EditValue.GetType() != typeof (string))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShape.EditValue == null || cboShape.EditValue.GetType() != typeof (int))
                {
                    XtraMessageBox.Show("선택된 마스터 패턴 형태가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sRecipe = (string) cboRecipe.EditValue;
                int iShape = (int) cboShape.EditValue;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    SetManualMasterPatternItem(sRecipe, iShape);
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuSetRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                if (lstSelectItem.Count == 0)
                    return;

                foreach (CRowItem cFirstItem in lstSelectItem)
                {
                    if (cFirstItem.Data.GetType() != typeof (CFlowItem))
                        continue;

                    if (cFirstItem.Data == null || cFirstItem.Data.GetType() != typeof (CFlowItem))
                        continue;

                    CFlowItem cFlowItem = (CFlowItem) cFirstItem.Data;
                    cFlowItem.RecipeElement = true;
                }

                lstSelectItem.Clear();
                lstSelectItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void munRstRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                if (lstSelectItem.Count == 0)
                    return;

                foreach (CRowItem cFirstItem in lstSelectItem)
                {
                    if (cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    if (cFirstItem.Data == null || cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    CFlowItem cFlowItem = (CFlowItem)cFirstItem.Data;
                    cFlowItem.RecipeElement = false;
                }

                lstSelectItem.Clear();
                lstSelectItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuSetCondi_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                if (lstSelectItem.Count == 0)
                    return;

                foreach (CRowItem cFirstItem in lstSelectItem)
                {
                    if (cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    if (cFirstItem.Data == null || cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    CFlowItem cFlowItem = (CFlowItem)cFirstItem.Data;
                    cFlowItem.ConditionElement = true;
                }

                lstSelectItem.Clear();
                lstSelectItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuRstCondi_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                if (lstSelectItem.Count == 0)
                    return;

                foreach (CRowItem cFirstItem in lstSelectItem)
                {
                    if (cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    if (cFirstItem.Data == null || cFirstItem.Data.GetType() != typeof(CFlowItem))
                        continue;

                    CFlowItem cFlowItem = (CFlowItem)cFirstItem.Data;
                    cFlowItem.ConditionElement = false;
                }

                lstSelectItem.Clear();
                lstSelectItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }
}
