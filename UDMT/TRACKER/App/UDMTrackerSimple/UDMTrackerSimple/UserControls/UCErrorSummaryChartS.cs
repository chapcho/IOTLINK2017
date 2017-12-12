using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using UDM.Log;
using TrackerCommon;
using DevExpress.XtraCharts;
using UDM.Common;
using System.Threading;

namespace UDMTrackerSimple
{
    public partial class UCErrorSummaryChartS : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iMainSplitPos = 0;
        private int m_iErrorSplitPos = 0;
        private Dictionary<string, CErrorInfoSummary> m_dicErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();
        private List<CErrorView> m_lstPlcErrorView = new List<CErrorView>();
        private CErrorInfoS m_cErrorInfoS = null;

        private delegate void UpdateNoneParameterCallback();

        public UCErrorSummaryChartS()
        {
            InitializeComponent();
            m_cErrorInfoS = CMultiProject.ErrorInfoS;
        }

        public void SetPlcViewS(List<string> lstPlcName )
        {
            try
            {
                Clear();
                InitLineErrorView();

                CErrorView cView = null;
                XtraTabPage tpPage = null;
                UCErrorSummaryChart ucChart = null;
                foreach (string sPlcName in lstPlcName)
                {
                    cView = new CErrorView();
                    cView.GroupKey = sPlcName;
                    cView.ErrorCount = 0;
                    cView.MostError = string.Empty;

                    m_lstPlcErrorView.Add(cView);

                    tpPage = new XtraTabPage();
                    tpPage.Text = sPlcName;
                    tpPage.Appearance.Header.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    tpPage.Appearance.HeaderActive.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    tpPage.Appearance.HeaderDisabled.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    tpPage.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 15, FontStyle.Bold);

                    ucChart = new UCErrorSummaryChart();
                    ucChart.Name = sPlcName;
                    ucChart.PlcName = sPlcName;
                    ucChart.Dock = DockStyle.Fill;

                    tpPage.Controls.Add(ucChart);
                    tabLine.TabPages.Add(tpPage);
                }

                grdTotal.DataSource = m_lstPlcErrorView;
                grdTotal.RefreshDataSource();
                AdjustGridHeight();

                SetLineErrorView();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                m_lstPlcErrorView.Clear();
                m_dicErrorInfoSum.Clear();

                XtraTabPage tpPage = null;
                UCErrorSummaryChart ucChart = null;

                while (tabLine.TabPages.Count > 0)
                {
                    tpPage = tabLine.TabPages.First();

                    if (tpPage.Controls.Count == 0 || tpPage.Controls[0].GetType() != typeof(UCErrorSummaryChart))
                        break;

                    ucChart = (UCErrorSummaryChart)tpPage.Controls[0];
                    ucChart.Clear();
                    ucChart.Dispose();

                    tpPage.Dispose();
                    tabLine.TabPages.Remove(tpPage);
                }

                ucChart = null;
                tpPage = null;
                tabLine.TabPages.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Run()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(Run);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    ErrorPieChart.Series["Error"].Points.Clear();

                    foreach (CErrorView cView in m_lstPlcErrorView)
                    {
                        cView.ErrorCount = 0;
                        cView.MostError = string.Empty;
                    }

                    grdTotal.RefreshDataSource();

                    UCErrorSummaryChart ucChart = null;
                    foreach (XtraTabPage tpPage in tabLine.TabPages)
                    {
                        if (tpPage.Controls.Count > 0 && tpPage.Controls[0].GetType() == typeof(UCErrorSummaryChart))
                        {
                            ucChart = (UCErrorSummaryChart)tpPage.Controls[0];
                            ucChart.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError()
        {
            try
            {
                SetLineErrorView();
            }
            catch(Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void InitLineErrorView()
        {
            try
            {
                m_dicErrorInfoSum.Clear();

                if (CMultiProject.PlcLogicDataS == null || CMultiProject.PlcLogicDataS.Count == 0)
                    return;

                CErrorInfoSummary cInfoSum = null;
                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    {
                        if (cProcess.PlcLogicDataS == null)
                            cProcess.PlcLogicDataS = new CPlcLogicDataS();

                        if (cProcess.PlcLogicDataS.ContainsKey(who.Key))
                        {
                            cInfoSum = new CErrorInfoSummary();
                            cInfoSum.GroupKey = cProcess.Name;
                            cInfoSum.PlcName = who.Value.PlcName;

                            if(!m_dicErrorInfoSum.ContainsKey(cProcess.Name))
                                m_dicErrorInfoSum.Add(cProcess.Name, cInfoSum);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLineErrorView()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetLineErrorView);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                        return;

                    foreach (CErrorInfoSummary cInfoSummary in m_dicErrorInfoSum.Values)
                        cInfoSummary.TotalErrorCount = 0;

                    List<IGrouping<int, CErrorInfo>> lstGroupErrorInfoSum = m_cErrorInfoS.GroupBy(x => x.ErrorID).ToList();

                    CErrorInfoSummary cInfoSum = null;
                    foreach (IGrouping<int, CErrorInfo> grpErrorSum in lstGroupErrorInfoSum)
                    {
                        CErrorInfo cInfo = grpErrorSum.ElementAt(0);

                        if (!m_dicErrorInfoSum.ContainsKey(cInfo.GroupKey))
                            continue;

                        cInfoSum = m_dicErrorInfoSum[cInfo.GroupKey];
                        cInfoSum.TotalErrorCount++; //각 공정 별 Error Count

                        cInfo = null;
                    }

                    cInfoSum = null;
                    lstGroupErrorInfoSum = null;

                    Thread.Sleep(1);

                    SetLineGridAndChart();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLineGridAndChart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetLineGridAndChart);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                        return;

                    int iCompare = 0;
                    int iTotalPlcErrorCount = 0;
                    string sCompare = string.Empty;
                    string sPlcName = string.Empty;
                    List<CErrorInfoSummary> lstPlcInfo = null;
                    XtraTabPage tpPage = null;
                    UCErrorSummaryChart ucChart = null;
                    foreach (var who in CMultiProject.PlcLogicDataS)
                    {
                        sCompare = string.Empty;
                        iCompare = 0;
                        iTotalPlcErrorCount = 0;
                        sPlcName = who.Value.PlcName;
                        lstPlcInfo = m_dicErrorInfoSum.Values.Where(x => x.PlcName == sPlcName).ToList();

                        if (lstPlcInfo == null || lstPlcInfo.Count == 0)
                            continue;

                        foreach (CErrorInfoSummary cInfoSum in lstPlcInfo)
                        {
                            if (iCompare < cInfoSum.TotalErrorCount)
                            {
                                iCompare = cInfoSum.TotalErrorCount;
                                sCompare = cInfoSum.GroupKey;
                            }
                            iTotalPlcErrorCount += cInfoSum.TotalErrorCount;
                        }

                        CErrorView cView = null;
                        cView = m_lstPlcErrorView.SingleOrDefault(x => x.GroupKey == sPlcName);

                        if (cView != null)
                        {
                            //if (CMultiProject.PlcProcS.ContainsKey(sCompare) && CMultiProject.PlcProcS[sCompare].TotalAbnormalSymbolKey != string.Empty)
                            //{
                            //    CTag cTag = CMultiProject.TotalTagS[CMultiProject.PlcProcS[sCompare].TotalAbnormalSymbolKey];

                            //    if (cTag != null)
                            //        sCompare = cTag.GetDescription();

                            //    cTag = null;
                            //}

                            cView.MostError = sCompare;
                            cView.ErrorCount = iTotalPlcErrorCount;
                            grdTotal.RefreshDataSource();
                        }

                        SetErrorPieChart();

                        tpPage = tabLine.TabPages.SingleOrDefault(x => x.Text == sPlcName);

                        if (tpPage == null)
                            continue;

                        ucChart = (UCErrorSummaryChart)tpPage.Controls[0];
                        ucChart.ErrorInfoSumS = lstPlcInfo;
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetErrorPieChart()
        {
            ErrorPieChart.Series["Error"].Points.Clear();

            Series cSeries = ErrorPieChart.Series["Error"];
            SeriesPoint cPoint = null;

            if (m_lstPlcErrorView.Count == 0)
                return;

            cSeries.Points.Clear();
            cSeries.LegendPointOptions.PointView = PointView.Argument;
            cSeries.LegendTextPattern = "{A}";

            foreach (var who in m_lstPlcErrorView)
            {
                cPoint = new SeriesPoint(who.GroupKey, new double[] { who.ErrorCount });
                cPoint.ToolTipHint = "Process : [" + who.GroupKey + "]\r\nError Count : " + who.ErrorCount + "]";
                cPoint.Tag = who;

                cSeries.Points.Add(cPoint);
            }
        }

        private void TotalGridDoubleClick()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(TotalGridDoubleClick);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                int iRowHandle = grvTotal.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvTotal.GetRow(iRowHandle);

                if (obj == null || obj.GetType() != typeof (CErrorView))
                    return;

                CErrorView cView = (CErrorView) obj;

                XtraTabPage tpPage = tabLine.TabPages.SingleOrDefault(x => x.Text == cView.GroupKey);

                if (tpPage != null)
                    tabLine.SelectedTabPage = tpPage;
            }
        }

        private int GetRowHeight(int iRowHandle)
        {
            GridViewInfo viewInfo = grvTotal.GetViewInfo() as GridViewInfo;
            return viewInfo.CalcRowHeight(CreateGraphics(), iRowHandle, 0);
        }

        private void AdjustGridHeight()
        {
            try
            {
                int iHeight = 0;
                int iRowCount = grvTotal.RowCount + 1;

                iHeight = iRowCount * 32;
                //int iRowHandle = 0;
                //for (int i = 0; i < grvTotal.RowCount; i++)
                //{
                //    iRowHandle = grvTotal.GetVisibleRowHandle(i);
                //    iHeight += GetRowHeight(iRowHandle);
                //}

                grdTotal.Height = iHeight;
                grdTotal.Refresh();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChartS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ErrorPieChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            CErrorView cValue = (CErrorView)e.SeriesPoint.Tag;
            e.LabelText = e.SeriesPoint.Argument + string.Format(", {0}", cValue.ErrorCount);
        }

        private void grvTotal_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TotalGridDoubleClick();
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

        private void sptError_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptError.SplitterPosition > 0)
            {
                m_iErrorSplitPos = sptError.SplitterPosition;
                sptError.SplitterPosition = 0;
            }
            else
                sptError.SplitterPosition = m_iErrorSplitPos;
        }
    }
}
