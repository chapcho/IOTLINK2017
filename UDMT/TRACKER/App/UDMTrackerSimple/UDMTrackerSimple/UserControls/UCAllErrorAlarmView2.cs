using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCAllErrorAlarmView2 : UserControl
    {
        #region Member Variables

        private List<CErrorView> m_lstErrorView = new List<CErrorView>();
        private Dictionary<string, CErrorInfoSummary> m_dicErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        public UEventHandlerMonitorPanelDoubleClicked UEventPanelDoubleClick;
        public UEventHandlerMonitorPanelClicked UEventPanelClick;
        public UEventHandlerMonitorAllPanelDoubleClicked UEventAllPanelDoubleClick;

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateErrorViewCallback(CErrorInfo cInfo);
        private delegate void UpdateErrorViewCallback2(CErrorInfo cInfo, int iPriority);
        private int m_iMainSplitPos = 0;
        private int m_iErrorSplitPos = 0;

        #endregion

        public UCAllErrorAlarmView2()
        {
            InitializeComponent();
        }

        public void Run()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(Run);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    ucErrorAlarmView.Run();
                    ucErrorPanelS.ClearPanelS();

                    ErrorPieChart.Series["Error"].Points.Clear();

                    foreach (CErrorView cView in m_lstErrorView)
                    {
                        cView.ErrorCount = 0;
                        cView.RecentTime = DateTime.MinValue;
                        cView.RecentError = string.Empty;
                    }

                    grdLine.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                ucErrorAlarmView.Stop();
                ucErrorPanelS.ClearPanelS();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                ucErrorAlarmView.ClearControls();
                //ucErrorAlarmView.Dispose();
                ucErrorPanelS.ClearPanelS();
                //ucErrorPanelS.Dispose();

                ErrorPieChart.Series["Error"].Points.Clear();
                m_lstErrorView.Clear();
                m_dicErrorInfoSum.Clear();

                grdLine.DataSource = null;
                grdLine.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearView()
        {
            try
            {
                ucErrorAlarmView.ClearControls();
                ucErrorPanelS.ClearPanelS();

                ErrorPieChart.Series["Error"].Points.Clear();
                m_lstErrorView.Clear();
                m_dicErrorInfoSum.Clear();

                grdLine.DataSource = null;
                grdLine.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                ClearView();
                InitChartView();
                SetProcessErrorViewS();
                SetChartView();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorViewCallback cUpdate = new UpdateErrorViewCallback(UpdateError);
                    this.Invoke(cUpdate, new object[] { cErrorInfo });
                }
                else
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                        return;

                    SetChartView();
                    if (cErrorInfo.ErrorType != "CycleOver")
                        ucErrorAlarmView.UpdateProcessError(cErrorInfo.GroupKey, cErrorInfo.ErrorMessage);
                    else
                        ucErrorAlarmView.UpdateProcessError(cErrorInfo.GroupKey, cErrorInfo.DetailErrorMessage);

                    ucErrorPanelS.UpdateErrorListPanelS(cErrorInfo);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorViewCallback2 cUpdate = new UpdateErrorViewCallback2(UpdateError);
                    this.Invoke(cUpdate, new object[] { cErrorInfo, iPriority });
                }
                else
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                        return;

                    SetChartView();
                    ucErrorAlarmView.UpdateProcessError(cErrorInfo.GroupKey, cErrorInfo.ErrorMessage, iPriority);
                    ucErrorPanelS.UpdateErrorListPanelS(cErrorInfo);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOverError(string sProcessKey)
        {
            //ucErrorAlarmView.UpdateCycleOverError(sProcessKey);
        }

        public void ClearError(string sProcessKey)
        {
            try
            {
                ucErrorPanelS.ClearErrorListPanelS(sProcessKey);
                ucErrorAlarmView.ClearPlcError(sProcessKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearAllError()
        {
            try
            {
                ucErrorAlarmView.ClearAllError();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void InitChartView()
        {
            try
            {
                m_dicErrorInfoSum.Clear();


                CErrorInfoSummary cInfoSum = null;
                foreach (string sKey in CMultiProject.PlcProcS.Keys)
                {
                    if (m_dicErrorInfoSum.ContainsKey(sKey))
                        continue;

                    cInfoSum = new CErrorInfoSummary();
                    cInfoSum.GroupKey = sKey;
                    
                    m_dicErrorInfoSum.Add(sKey, cInfoSum);
                }

            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetProcessErrorViewS()
        {
            try
            {
                m_lstErrorView.Clear();

                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                    return;

                List<string> lstProcessName = new List<string>();
                CErrorView cView = null;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    lstProcessName.Add(who.Key);

                    cView = new CErrorView();
                    cView.GroupKey = who.Key;
                    cView.MostError = string.Empty;
                    cView.ErrorCount = 0;

                    m_lstErrorView.Add(cView);
                }

                grdLine.DataSource = m_lstErrorView;
                grdLine.RefreshDataSource();
                colProcess.BestFit();

                ucErrorAlarmView.SetProcessView(lstProcessName);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetChartView()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetChartView);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (CMultiProject.ErrorInfoS == null || CMultiProject.ErrorInfoS.Count == 0)
                        return;

                    foreach (CErrorInfoSummary cInfoSummary in m_dicErrorInfoSum.Values)
                    {
                        cInfoSummary.TotalErrorCount = 0;
                        cInfoSummary.RecentErrorTime = DateTime.MinValue;
                        cInfoSummary.RecentErrorMessage = string.Empty;
                    }

                    List<IGrouping<int, CErrorInfo>> lstGroupErrorInfoSum = CMultiProject.ErrorInfoS.GroupBy(x => x.ErrorID).ToList();

                    CErrorInfoSummary cInfoSum = null;
                    foreach (IGrouping<int, CErrorInfo> grpErrorSum in lstGroupErrorInfoSum)
                    {

                        CErrorInfo cInfo = null;
                        if(grpErrorSum.Count() > 1)
                             cInfo = grpErrorSum.ElementAt(1);
                        else
                            cInfo = grpErrorSum.ElementAt(0);

                        if (!m_dicErrorInfoSum.ContainsKey(cInfo.GroupKey))
                            continue;

                        cInfoSum = m_dicErrorInfoSum[cInfo.GroupKey];
                        cInfoSum.TotalErrorCount++; //각 공정 별 Error Count

                        if (cInfoSum.RecentErrorTime < cInfo.ErrorTime)
                        {
                            cInfoSum.RecentErrorTime = cInfo.ErrorTime;

                            if(cInfo.ErrorType != "CycleOver")
                                cInfoSum.RecentErrorMessage = cInfo.ErrorMessage;
                            else
                                cInfoSum.RecentErrorMessage = cInfo.DetailErrorMessage;
                        }

                        cInfo = null;
                    }

                    cInfoSum = null;
                    lstGroupErrorInfoSum = null;

                    System.Threading.Thread.Sleep(1);

                    SetStatisticGrid();
                    SetStatisticChart();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetStatisticGrid()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetStatisticGrid);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (CMultiProject.ErrorInfoS == null || CMultiProject.ErrorInfoS.Count == 0)
                        return;

                    CErrorInfoSummary cInfoSum = null;
                    CErrorView cView = null;
                    foreach (var who in m_dicErrorInfoSum)
                    {
                        cView = m_lstErrorView.SingleOrDefault(x => x.GroupKey == who.Key);

                        if (cView == null)
                            continue;

                        cView.ErrorCount = who.Value.TotalErrorCount;
                        cView.RecentError = who.Value.RecentErrorMessage;
                        cView.RecentTime = who.Value.RecentErrorTime;
                    }

                    grdLine.DataSource = m_lstErrorView.Where(x => x.ErrorCount > 0).ToList();
                    grdLine.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetStatisticChart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetStatisticChart);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    ErrorPieChart.Series["Error"].Points.Clear();

                    Series cSeries = ErrorPieChart.Series["Error"];
                    SeriesPoint cPoint = null;

                    if (m_lstErrorView.Count == 0)
                        return;

                    cSeries.Points.Clear();
                    cSeries.LegendPointOptions.PointView = PointView.Argument;
                    cSeries.LegendTextPattern = "{A}";

                    foreach (var who in m_lstErrorView)
                    {
                        cPoint = new SeriesPoint(who.GroupKey, new double[] { who.ErrorCount });
                        cPoint.ToolTipHint = "Process : [" + who.GroupKey + "]\r\nError Count : " + who.ErrorCount + "]";
                        cPoint.Tag = who;

                        cSeries.Points.Add(cPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_UEventErrorPanelDoubleClicked()
        {
            try
            {
                if (UEventPanelDoubleClick != null)
                    UEventPanelDoubleClick();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_UEventErrorPanelClicked(string sProcessKey)
        {
            try
            {
                if (UEventPanelClick != null)
                    UEventPanelClick(sProcessKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_UEventErrorAllPanelDoubleClicked(string sProcessKey)
        {
            try
            {
                if (UEventAllPanelDoubleClick != null)
                    UEventAllPanelDoubleClick(sProcessKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnErrorClear_Click(object sender, EventArgs e)
        {
            try
            {
                ucErrorAlarmView.ClearAllError();
                ucErrorPanelS.ClearPanelS();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCAllErrorAlarmView2_Load(object sender, EventArgs e)
        {
            try
            {
                ucErrorAlarmView.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                ucErrorAlarmView.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                ucErrorAlarmView.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                ucErrorPanelS.UEventErrorDoubleClicked += ucWidget_UEventErrorPanelDoubleClicked;
                m_iErrorSplitPos = sptErrorInfo.SplitterPosition;
                m_iMainSplitPos = sptMain.SplitterPosition;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

        }

        private void grvLine_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ErrorPieChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            try
            {
                CErrorView cValue = (CErrorView)e.SeriesPoint.Tag;
                e.LabelText = e.SeriesPoint.Argument + string.Format(", {0}", cValue.ErrorCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iMainSplitPos;
        }

        private void sptErrorInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptErrorInfo.SplitterPosition > 0)
            {
                m_iErrorSplitPos = sptErrorInfo.SplitterPosition;
                sptErrorInfo.SplitterPosition = 0;
            }
            else
                sptErrorInfo.SplitterPosition = m_iErrorSplitPos;
        }


    }
}
