﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Flow;
using UDM.UI.TimeChart;
using DevExpress.XtraGrid.Views.Grid;
using TrackerCommon;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmCycleLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member VarialbesucChart

        private int m_iSplitPos = 0;
        private int m_iSelectedRowHandle = -99;
        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;
        private CCycleAnalyzedData m_cCycleAnalyzedDataCurrent = null;

        #endregion


        #region Initialize/Dispose

        public FrmCycleLogViewer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void ClearChart()
        {
            ucChart.Clear();
            InitChart();
        }

        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
            {
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;

                m_bVerified = false;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
                dtpkTo.EditValue = (DateTime)dtLast;
            }
        }

        private void InitChart()
        {
            CColumnItem cColumn = null;
            
            ucChart.GanttTree.ColumnS.Clear();

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);
        }

        private void ShowGroupList()
        {   
            cmbGroup.EditValue = null;
            exEditorGroup.Items.Clear();

            string sProcess;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                sProcess = CMultiProject.PlcProcS.ElementAt(i).Key;
                exEditorGroup.Items.Add(sProcess);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private void ShowRecipeWord(string sProcess, CCycleAnalyDataList cDataList)
        {
            if (CMultiProject.PlcProcS.ContainsKey(sProcess) == false) return;
            ucRecipeView.Clear();

            CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
            ucRecipeView.RecipeTagS = cProcess.RecipeWordS;
            ucRecipeView.SetAnalyzeData(CMultiProject.CycleAnalyDataS[sProcess].CycleAnalyzedData);
            ucRecipeView.SetRecipeWord(cProcess.RecipeWordS);
        }
 
        private void ShowCycleLogTable()
        {
            ClearChart();

            string sKey = cmbGroup.EditValue.ToString();

            if (CMultiProject.CycleAnalyDataS.ContainsKey(sKey) == false)
                return;

            grdCycleData.DataSource = CMultiProject.CycleAnalyDataS[sKey];
            grdCycleData.RefreshDataSource();
            //grvCycleData.BestFitColumns();
            m_cCycleAnalyzedDataCurrent = CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData;
        }

        private void ShowLog(CGanttItem cGanttParent, CFlowItemS cFlowItemS, Color cColor)
        {
            if (cFlowItemS == null || cFlowItemS.Count == 0)
                return;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            List<CGanttBar> lstBar;

            for (int i = 0; i < cFlowItemS.Count; i++)
            {
                cFlowItem = cFlowItemS[i];

                cGanttItem = (CGanttItem)cGanttParent.ItemS.FindHasData(cFlowItem.Key);

                if (cGanttItem == null)
                {
                    cGanttItem = new CGanttItem(new object[] { cFlowItem.Key, cFlowItem.Description });
                    cGanttItem.Data = cFlowItem.Key;
                    cGanttParent.ItemS.Add(cGanttItem);
                }

                lstBar = CreateBarList(cFlowItem, cColor, true);
                cGanttItem.BarS.AddRange(lstBar);
                lstBar.Clear();

                if (cFlowItem.SubFlow != null)
                    ShowLog(cGanttItem, cFlowItem.SubFlow.FlowItemS, cColor);
            }
        }

        private List<CGanttBar> CreateBarList(CFlowItem cItem, Color cColor, bool bPositiveOffset)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cItem.TimeNodeS.Count; i++)
            {
                cNode = cItem.TimeNodeS[i];
                cBar = CreateBar(cNode, cColor);

                if (bPositiveOffset)
                    cBar.OffSet = 3;
                else
                    cBar.OffSet = -3;

                lstBar.Add(cBar);
            }

            return lstBar;
        }

        private CGanttBar CreateBar(CTimeNode cNode, Color cColor)
        {
            CGanttBar cBar = new CGanttBar();
            cBar.StartTime = cNode.Start;
            cBar.EndTime = cNode.End;
            cBar.Data = cNode;
            cBar.Color = cColor;
            cBar.Height = 6;

            return cBar;
        }

        private void RegisterTimeChartEventS()
        {
            ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
        }


        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            if (cCol.Name == "colSeriesScale")
            {
                float nScale = 1f;
                bool bOK = float.TryParse(oValue.ToString(), out nScale);
                CSeriesItem cItem = (CSeriesItem)cRow;
                CSeriesPoint cPoint;
                for (int i = 0; i < cItem.PointS.Count; i++)
                {
                    cPoint = cItem.PointS[i];
                    cPoint.Value = (float)cPoint.Data * nScale;
                }

                ucChart.SeriesTree.UpdateLayout();
            }
            else if (cCol.Name == "colSeriesColor")
            {
                CSeriesItem cItem = (CSeriesItem)cRow;

                cItem.Color = (Color)oValue;
                ucChart.SeriesTree.UpdateLayout();
            }
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucChart.TimeLine.TimeIndicatorS.Count == 0) return;
            else if (ucChart.TimeLine.TimeIndicatorS.Count == 1)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            else
            {
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);

            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucChart.TimeLine.UpdateLayout();

            if (ucChart.TimeLine.TimeIndicatorS.Count > 0)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
            {
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
            else
            {
                txtInterval.Text = "0";
            }
        }

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            txtWordValue.Text = "";
            txtWordValue.Text = cBar.Text;
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
            {

                ucChart.TimeLine.TimeIndicatorS.Clear();
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan =
                    ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();

                ucChart.TimeLine.UpdateLayout();
            }
        }

        private Color GetColor()
        {
            Random rand = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[rand.Next(names.Length)];
            Color randColor = Color.FromKnownColor(randomColorName);

            return randColor;
        }

        private void CreateStepSubDepthItem(CStep cStep, CTag cCoilTag, CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cSubNodeS = null;
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(cStep.RefTagS.KeyList, dtFrom, dtTo);
                CTag cTag = null;
                bool bShowBarText = false;

                if (cTotalLogS == null || cTotalLogS.Count == 0)
                    return;

                CTagS cTotalTagS = CMultiProject.TotalTagS;

                foreach (string sKey in cStep.RefTagS.KeyList)
                {
                    if (sKey == cCoilTag.Key)
                        continue;
                    if (cTotalTagS.ContainsKey(sKey) == false)
                    {
                        Console.WriteLine(string.Format("{0} 가 없습니다.Logic 변환 오류 가능성 높음", sKey));
                        continue;
                    }
                    cTag = cTotalTagS[sKey];
                    cItem = CreateGanttItem(cTag);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                    if (cLogS != null)
                    {
                        cSubNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                        if (cSubNodeS == null)
                            cSubNodeS = new CTimeNodeS();
                    }
                    else
                        cSubNodeS = new CTimeNodeS();

                    if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                        bShowBarText = true;

                    lstBar = CreateBarList(cSubNodeS, Color.LightBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    cParentItem.ItemS.Add(cItem);

                    lstBar.Clear();
                    lstBar = null;
                    cLogS.Clear();
                }
            }
            ucChart.EndUpdate();
        }

        private void ShowGanttChart(List<string> lstKey, DateTime dtFrom, DateTime dtTo, CTimeLogS cTotalLogS)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cNodeS = null;
                CTimeLogS cLogS = new CTimeLogS();
                bool bShowBarText = false;

                for (int i = 0; i < lstKey.Count; i++)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(lstKey[i]) == false)
                        continue;
                    cLogS.Clear();
                    CTag cTag = CMultiProject.TotalTagS[lstKey[i]];

                    cItem = CreateGanttItem(cTag);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                    if (cLogS != null && cLogS.Count > 0)
                    {
                        cLogS.UpdateTimeRange();

                        if (i == 0)
                            dtFirstVisible = cLogS.FirstTime;
                        else
                        {
                            if (dtFirstVisible > cLogS.FirstTime)
                                dtFirstVisible = cLogS.FirstTime;
                        }

                        cNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                        if (cNodeS == null)
                            cNodeS = new CTimeNodeS();
                    }
                    else
                        continue;
                    //cNodeS = new CTimeNodeS();

                    if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                        bShowBarText = true;

                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    ucChart.GanttTree.ItemS.Add(cItem);

                    //if (bCoilTagShow)
                        ShowSubItemChart(cItem, dtFrom, dtTo);

                    lstBar.Clear();
                    lstBar = null;
                }

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShowSeriesChart(List<string> lstTagKey, DateTime dtFrom, DateTime dtTo)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CSeriesItem cItem;
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                float nAxisMax = 0f;
                float nAxisMin = 0f;

                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstTagKey, dtFrom, dtTo);

                if (cTotalLogS == null || cTotalLogS.Count == 0)
                    return;

                CTagS cTotalTagS = CMultiProject.TotalTagS;

                foreach (string sKey in lstTagKey)
                {
                    nMax = -1;
                    nMax = -1;
                    if (cTotalTagS.ContainsKey(sKey) == false) continue;
                    CTag cTag = cTotalTagS[sKey];

                    if (cTag == null || cTag.DataType == EMDataType.Bool)
                        continue;

                    cItem = new CSeriesItem(null);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                    cItem.Color = GetColor();
                    for (int j = 0; j < cLogS.Count; j++)
                    {
                        cLog = cLogS[j];

                        if (j == 0)
                        {
                            dtFirstVisible = cLog.Time;

                            nMax = cLog.Value;
                            nMin = cLog.Value;
                        }
                        else if (cLog.Value > nMax)
                            nMax = cLog.Value;
                        else if (nMin > cLog.Value)
                            nMin = cLog.Value;

                        if (cLog.Value > nAxisMax)
                            nAxisMax = cLog.Value;
                        else if (cLog.Value < nAxisMin)
                            nAxisMin = cLog.Value;

                        cPoint = new CSeriesPoint(cLog.Time, cLog.Value);
                        cPoint.Data = cLog.Value;
                        cItem.PointS.Add(cPoint);
                    }
                    cItem.Values = new object[] { sKey, cTotalTagS[sKey].Description, nMin, nMax, cItem.Color, 1f };

                    ucChart.SeriesTree.ItemS.Add(cItem);

                    cLogS.Clear();
                }

                ucChart.SeriesChart.Axis.Maximum = nAxisMax;
                ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

                //spnAxisMin.EditValue = nAxisMin;
                //spnAxisMax.EditValue = nAxisMax;

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
                cLogS.Clear();
            }
            ucChart.EndUpdate();
        }

        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
            cItem.Data = cTag;

            return cItem;
        }

        private List<CGanttBar> CreateBarList(CTimeNodeS cNodeS, Color cColor, bool bShowBarText)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cNodeS.Count; i++)
            {
                cNode = cNodeS[i];
                cBar = CreateBar(cNode, cColor);
                if (bShowBarText)
                    cBar.Text = cNode.Value.ToString();
                lstBar.Add(cBar);
            }

            return lstBar;
        }

        private void ShowSubItemChart(CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            CTag cCoilTag = (CTag)cParentItem.Data;
            List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cCoilTag);
            CStep cStep = null;

            if (lstCoilStep == null || lstCoilStep.Count == 0)
                return;
            else
                cStep = lstCoilStep[0];

            CreateStepSubDepthItem(cStep, cCoilTag, cParentItem, dtFrom, dtTo);
        }

        #endregion


        #region Event Methods

        private void FrmCycleLogViewer_Load(object sender, EventArgs e)
        {
            try
            {
                m_bVerified = VerifyParameter();
                if (m_bVerified == false)
                {
                    this.Close();
                    return;
                }

                InitComponent();
                InitChart();
                ShowGroupList();

                RegisterTimeChartEventS();
                ucChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
                ucChart.GanttChart.ContextMenuStrip = cntxSelectedBar;

                m_iSplitPos = sptMin.SplitterPosition;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCycleLogViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

		private void btnShowCycleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            //if (m_bVerified == false)
            //    return;

            //if (cmbGroup.EditValue == null)
            //    return;

            //string sGroup = cmbGroup.EditValue.ToString();
            //DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            //DateTime dtTo = (DateTime)dtpkTo.EditValue;

            //ShowCycleLogTable();
            //ShowRecipeWord(sGroup);
		}

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ClearChart();
            ucRecipeView.Clear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucChart.TimeLine.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucChart.TimeLine.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void FrmCycleLogViewer_Resize(object sender, EventArgs e)
        {
        }

        private void ucRecipeView_Load(object sender, EventArgs e)
        {

        }

        private void grvCycleData_DoubleClick(object sender, EventArgs e)
        {
            //int iHandle = grvCycleData.FocusedRowHandle;
            //if (iHandle < 0)
            //    return;

            //object oData = grvCycleData.GetRow(iHandle);
            //if ((oData.GetType() == typeof(CCycleAnalyData)))
            //{
            //    m_iSelectedRowHandle = iHandle;
            //    ClearChart();
            //    CCycleAnalyData cCycleAnalyData = (CCycleAnalyData)oData;
            //    string sGroup = cmbGroup.EditValue.ToString();
            //    DateTime dtFrom = cCycleAnalyData.StartTime;
            //    DateTime dtTo = cCycleAnalyData.EndTime;
            //    CPlcProc cProc = CMultiProject.PlcProcS[cCycleAnalyData.ProcessKey];
                
            //    List<string>lstAllTag = new List<string>();
            //    lstAllTag.AddRange(cProc.RecipeWordS.Select(b=>b.Key).ToList());
            //    lstAllTag.AddRange(cProc.ProcessTagS.Select(b=>b.Key).ToList());

            //    CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstAllTag, dtFrom, dtTo);

            //    if (cTotalLogS == null || cTotalLogS.Count == 0)
            //    {
            //        MessageBox.Show(string.Format("해당기간에 로그가 존재하지 않습니다."));
            //        return;
            //    }

            //    List<string> lstSort = new List<string>();
            //    lstSort.AddRange(cProc.RecipeWordS.Select(b=>b.Key).ToList());
            //    for (int i = 0; i < cTotalLogS.Count; i++)
            //    {
            //        CTimeLog cLog = cTotalLogS[i];
            //        if (lstSort.Contains(cLog.Key) == false && cLog.Value != 0)
            //        {
            //            lstSort.Add(cLog.Key);
            //        }
            //    }
            //    dtpkFrom.EditValue = cCycleAnalyData.StartTime;
            //    dtpkTo.EditValue = cCycleAnalyData.EndTime;

            //    //Cycle 간격 확인용
            //    ucChart.TimeLine.TimeIndicatorS.Clear();
            //    ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cCycleAnalyData.StartTime, Color.Red));
            //    ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cCycleAnalyData.EndTime, Color.Red));

            //    dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            //    dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

            //    ucChart.TimeLine.UpdateLayout();
                
            //    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //    {
            //        ShowGanttChart(lstSort, dtFrom, dtTo, cTotalLogS);
            //    }
            //    SplashScreenManager.CloseForm(false);
            //}
        }

        private void cmbGroup_EditValueChanged(object sender, EventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (cmbGroup.EditValue == null)
                return;

            string sGroup = cmbGroup.EditValue.ToString();
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            ShowCycleLogTable();
            ShowRecipeWord(sGroup, CMultiProject.CycleAnalyDataS[sGroup]);

        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.SeriesTree.GetSelectedItemList();

            foreach (CRowItem item in lstSelectItem)
                ucChart.SeriesTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        private void mnuSeriesChartView_Click(object sender, EventArgs e)
        {
            List<string> lstTagKey = new List<string>();
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;
            CTag cTag;

            foreach (CRowItem item in lstSelectItem)
            {
                cTag = (CTag)item.Data;

                if (!lstTagKey.Contains(cTag.Key))
                    lstTagKey.Add(cTag.Key);
            }

            if (lstTagKey.Count != 0)
                ShowSeriesChart(lstTagKey, dtFrom, dtTo);
        }

        private void mnuSubLadderView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucChart.GanttChart.FocusedBar == null) return;

                CRowItem cItem = ucChart.GanttChart.FocusedBar.Item;
                if (cItem.Data != null)
                {
                    CTag cTag = (CTag)cItem.Data;
                    if (cTag == null)
                    {
                        MessageBox.Show("선택한 접점에 문제가 있습니다");
                        return;
                    }
                    DateTime dtStart = ucChart.GanttChart.FocusedBar.StartTime;
                    DateTime dtEnd = ucChart.GanttChart.FocusedBar.EndTime;
                    List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cTag);
                    CStep cStep = null;

                    if (lstCoilStep == null || lstCoilStep.Count == 0)
                    {
                        MessageBox.Show("하위 조건이 존재하지 않습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (lstCoilStep.Count == 1)
                        cStep = lstCoilStep[0];
                    else
                    {
                        FrmStepSelector frmSelector = new FrmStepSelector();
                        frmSelector.StepList = lstCoilStep;
                        frmSelector.ShowDialog();

                        if (frmSelector.IsSelectStep)
                        {
                            cStep = frmSelector.GetSelectedStep();
                        }
                        frmSelector.Dispose();
                        frmSelector = null;
                    }

                    if (cStep == null)
                    {
                        MessageBox.Show("선택한 접점의 Step을 찾을 수 없습니다.");
                        return;
                    }

                    CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];

                    CTimeLogS cBarLogS = m_cReader.GetTimeLogS(dtStart.AddMinutes(-5) , dtStart.AddMinutes(5));
                    if (cBarLogS == null || cBarLogS.Count == 0)
                    {
                        MessageBox.Show("해당기간 로그가 존재하지 않습니다.");
                        return;
                    }
                    FrmLadderLogView frmLadderLogView = new FrmLadderLogView();

                    frmLadderLogView.ReaderDB = m_cReader;
                    frmLadderLogView.TimeLogS = cBarLogS;
                    frmLadderLogView.StartTime = dtStart;
                    frmLadderLogView.EndTime = dtEnd;

                    frmLadderLogView.Show();

                    frmLadderLogView.SetLadderStep(cLogic, cStep, 0, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuSubDepthView_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstSelectItem.Count > 1 || lstSelectItem.Count == 0) return;

            lstSelectItem[0].ItemS.Clear();

            CTag cCoilTag = (CTag)lstSelectItem[0].Data;
            List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cCoilTag);
            CStep cStep = null;

            if (lstCoilStep == null || lstCoilStep.Count == 0)
            {
                MessageBox.Show("하위 조건이 존재하지 않습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (lstCoilStep.Count == 1)
                cStep = lstCoilStep[0];
            else
            {
                FrmStepSelector frmSelector = new FrmStepSelector();
                frmSelector.StepList = lstCoilStep;
                frmSelector.ShowDialog();

                if (frmSelector.IsSelectStep)
                {
                    cStep = frmSelector.GetSelectedStep();
                }
                frmSelector.Dispose();
                frmSelector = null;
            }

            if (cStep == null)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CreateStepSubDepthItem(cStep, cCoilTag, (CGanttItem)lstSelectItem[0], dtFrom, dtTo);
        }

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            foreach (CRowItem item in lstSelectItem)
                ucChart.GanttTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        private void grvCycleData_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            
        }

        private void grvCycleData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (m_iSelectedRowHandle == e.RowHandle)
                {
                    e.Appearance.BackColor = Color.Lime;
                    e.Appearance.BackColor = Color.Lime;
                    e.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Duration"]);
                    TimeSpan tsVlaue = TimeSpan.MinValue;
                    bool bOK = TimeSpan.TryParse(category, out tsVlaue);
                    if (bOK)
                    {
                        if (m_cCycleAnalyzedDataCurrent.Average < tsVlaue)
                        {
                            e.Appearance.BackColor = Color.DarkRed;
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void sptMin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMin.SplitterPosition > 0)
                sptMin.SplitterPosition = 0;
            else
                sptMin.SplitterPosition = m_iSplitPos;
        }

        private void sptMin_SplitterMoved(object sender, EventArgs e)
        {
            m_iSplitPos = sptMin.SplitterPosition;
        }

    }
}