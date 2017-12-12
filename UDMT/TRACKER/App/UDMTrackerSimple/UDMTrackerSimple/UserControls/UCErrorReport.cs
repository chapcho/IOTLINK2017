using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCErrorReport : DevExpress.XtraEditors.XtraUserControl
    {
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private CPlcProcS m_cProcessS = null;
        private CErrorInfoS m_cErrorInfoS = null;
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        private delegate void UpdateErrorReportCallback();


        public CPlcProcS ProcessS
        {
            get { return m_cProcessS; }
            set { m_cProcessS = value; }
        }

        public DateTime From
        {
            get { return m_dtFrom; }
            set { m_dtFrom = value; }
        }

        public DateTime To
        {
            get { return m_dtTo; }
            set { m_dtTo = value; }
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set
            {
                m_cErrorInfoS = value;
                CErrorInfoSummary cErrorSum = null;
                m_lstErrorInfoSum.Clear();

                if (m_cErrorInfoS == null)
                    return;

                //16.09.20 Error Satistic 수정
                List<IGrouping<int, CErrorInfo>> lstGroupErrorInfoSum = m_cErrorInfoS.GroupBy(x => x.ErrorID).ToList();

                foreach (IGrouping<int, CErrorInfo> grpErrorSum in lstGroupErrorInfoSum)
                {
                    CErrorInfo cInfo = grpErrorSum.ElementAt(0);

                    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                    {
                        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                        if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                        {
                            cErrorSum.lstErrorInfo.Add(cInfo);
                        }
                    }
                    else
                    {
                        cErrorSum = new CErrorInfoSummary();
                        cErrorSum.GroupKey = cInfo.GroupKey;
                        cErrorSum.lstErrorInfo.Add(cInfo);

                        m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                    }
                }

                //foreach (CErrorInfo cInfo in m_cErrorInfoS)
                //{
                //    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                //    {
                //        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                //        if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                //            cErrorSum.lstErrorInfo.Add(cInfo);
                //    }
                //    else
                //    {
                //        cErrorSum = new CErrorInfoSummary();
                //        cErrorSum.GroupKey = cInfo.GroupKey;
                //        cErrorSum.lstErrorInfo.Add(cInfo);

                //        m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                //    }
                //}
            }
        }

        public UCErrorReport()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            if (tabMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage tpPage in tabMain.TabPages)
                {
                    if (tpPage.Controls.Count == 0)
                        continue;

                    if (tpPage.Controls[0].GetType() == typeof(UCErrorProcessReport))
                        tpPage.Controls[0].Dispose();

                    //tpPage.Dispose();
                }

                tabMain.TabPages.Clear();
            }
            ErrorPieChart.Series["Error"].Points.Clear();
            grdTotal.DataSource = null;
            grdTotal.RefreshDataSource();

            foreach (var who in m_lstErrorInfoSum)
            {
                if(who.Value.lstErrorInfo != null && who.Value.lstErrorInfo.Count > 0)
                    who.Value.lstErrorInfo.Clear();

                if(who.Value.lstErrorInfoNoRedundancy != null && who.Value.lstErrorInfoNoRedundancy.Count > 0)
                    who.Value.lstErrorInfoNoRedundancy.Clear();
            }

            m_lstErrorInfoSum.Clear();
        }

        public void ShowErrorReport()
        {
            if (this.InvokeRequired)
            {
                UpdateErrorReportCallback cUpdate = new UpdateErrorReportCallback(ShowErrorReport);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                if (CMultiProject.PlcProcS != null)
                    m_cProcessS = CMultiProject.PlcProcS;

                SetGroupChart();
                SetTotalGrid();

                InitTabPageS();
            }
        }

        private void InitTabPageS()
        {
            if (tabMain.TabPages.Count > 0)
            {
                foreach (XtraTabPage tpPage in tabMain.TabPages)
                {
                    if (tpPage.Controls.Count == 0)
                        continue;

                    if (tpPage.Controls[0].GetType() == typeof(UCErrorProcessReport))
                        tpPage.Controls[0].Dispose();
                }

                tabMain.TabPages.Clear();
            }

            XtraTabPage tp = null;
            UCErrorProcessReport ucProcessReport = null;
            int iCount = 0;

            if (m_cProcessS == null)
                return;

            foreach (CPlcProc cProcess in m_cProcessS.Values)
            {
                if (!m_lstErrorInfoSum.ContainsKey(cProcess.Name) || m_lstErrorInfoSum[cProcess.Name].ErrorCount == 0)
                    continue;

                tp = new XtraTabPage();
                ucProcessReport = new UCErrorProcessReport();
                ucProcessReport.Dock = DockStyle.Fill;

                if (m_lstErrorInfoSum.ContainsKey(cProcess.Name))
                {
                    ucProcessReport.From = m_dtFrom;
                    ucProcessReport.To = m_dtTo;
                    ucProcessReport.ErrorInfoSum = m_lstErrorInfoSum[cProcess.Name];
                }

                tp.Name = "tp" + iCount.ToString();
                iCount++;
                tp.Tag = ucProcessReport;
                tp.Text = cProcess.Name;
                tp.Appearance.Header.Font = new Font("Tahoma", 15, FontStyle.Bold);
                tp.Appearance.HeaderActive.Font = new Font("Tahoma", 15, FontStyle.Bold);
                tp.Appearance.HeaderDisabled.Font = new Font("Tahoma", 15, FontStyle.Bold);
                tp.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 15, FontStyle.Bold);

                tabMain.TabPages.Add(tp);
                tp.Controls.Add(ucProcessReport);
            }
        }

        private void SetGroupChart()
        {
            ErrorPieChart.Series["Error"].Points.Clear();

            Series cSeries = ErrorPieChart.Series["Error"];
            SeriesPoint cPoint = null;

            if (m_lstErrorInfoSum.Count == 0)
                return;

            cSeries.Points.Clear();
            cSeries.LegendPointOptions.PointView = PointView.Argument;
            cSeries.LegendTextPattern = "{A}";

            foreach (var who in m_lstErrorInfoSum)
            {
                cPoint = new SeriesPoint(who.Key, new double[] { who.Value.lstErrorInfo.Count });
                cPoint.ToolTipHint = "Process : [" + who.Key + "]\r\nError Count : " + who.Value.lstErrorInfo.Count + "]";
                cPoint.Tag = who.Value;

                cSeries.Points.Add(cPoint);
            }
        }

        private void SetTotalGrid()
        {
            List<CErrorView> lstErrorView = new List<CErrorView>();
            CErrorView cErrorView = null;
            Dictionary<string, CErrorInfoS> DicErrorInfoS = null;
            int iMostIndex = 0;
            int iMaxError = 0;

            foreach (var who in m_lstErrorInfoSum)
            {
                cErrorView = new CErrorView();

                cErrorView.GroupKey = who.Key;
                cErrorView.ErrorCount = who.Value.lstErrorInfo.Count;

                DicErrorInfoS = who.Value.GetErrorReportValue();

                for (int i = 0; i < DicErrorInfoS.Count; i++)
                {
                    if (i == 0)
                    {
                        iMaxError = DicErrorInfoS.ElementAt(i).Value.Count;
                        iMostIndex = i;
                    }
                    else
                    {
                        if (iMaxError < DicErrorInfoS.ElementAt(i).Value.Count)
                        {
                            iMaxError = DicErrorInfoS.ElementAt(i).Value.Count;
                            iMostIndex = i;
                        }
                    }
                }

                cErrorView.MostError = DicErrorInfoS.ElementAt(iMostIndex).Key;
                lstErrorView.Add(cErrorView);
            }

            grdTotal.DataSource = lstErrorView;
            grdTotal.RefreshDataSource();
        }

        private void TotalGridDoubleClick()
        {
            if (this.InvokeRequired)
            {
                UpdateErrorReportCallback cUpdate = new UpdateErrorReportCallback(TotalGridDoubleClick);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                int iRowHandle = grvTotal.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvTotal.GetRow(iRowHandle);

                if (obj == null || obj.GetType() != typeof(CErrorView))
                    return;

                CErrorView cView = (CErrorView)obj;

                XtraTabPage tpPage = tabMain.TabPages.SingleOrDefault(x => x.Text == cView.GroupKey);

                if (tpPage != null)
                    tabMain.SelectedTabPage = tpPage;
            }
        }

        private void UCErrorReport_Load(object sender, EventArgs e)
        {

        }

        private void ErrorPieChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            CErrorInfoSummary cValue = (CErrorInfoSummary)e.SeriesPoint.Tag;
            e.LabelText = e.SeriesPoint.Argument + string.Format(", {0}", cValue.lstErrorInfo.Count);
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

        private int m_iSplitPos = 0;

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }
    }

    public partial class CErrorView
    {
        private string m_sGroupKey = string.Empty;
        private int m_iErrorCount = 0;
        private string m_sMostError = string.Empty;
        private string m_sRecentError = string.Empty;
        private DateTime m_dtRecentTime = DateTime.MinValue;

        public DateTime RecentTime
        {
            get { return m_dtRecentTime; }
            set { m_dtRecentTime = value; }
        }

        public string RecentError
        {
            get { return m_sRecentError; }
            set { m_sRecentError = value; }
        }
        public string GroupKey
        {
            get { return m_sGroupKey;}
            set { m_sGroupKey = value; }
        }

        public int ErrorCount
        {
            get { return m_iErrorCount;}
            set { m_iErrorCount = value; }
        }

        public string MostError
        {
            get { return m_sMostError;}
            set { m_sMostError = value; }
        }
    }
}
