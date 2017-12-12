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

namespace UDMLadderTracker
{
    public partial class UCErrorReport : DevExpress.XtraEditors.XtraUserControl
    {
        private CPlcProcS m_cProcessS = null;
        private CErrorInfoS m_cErrorInfoS = null;
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        private delegate void UpdateErrorReportCallback();


        public CPlcProcS ProcessS
        {
            get { return m_cProcessS; }
            set { m_cProcessS = value; }
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

                foreach (CErrorInfo cInfo in m_cErrorInfoS)
                {
                    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                    {
                        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                        if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                            cErrorSum.lstErrorInfo.Add(cInfo);
                    }
                    else
                    {
                        cErrorSum = new CErrorInfoSummary();
                        cErrorSum.GroupKey = cInfo.GroupKey;
                        cErrorSum.lstErrorInfo.Add(cInfo);

                        m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                    }
                }
            }
        }

        public UCErrorReport()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            tabMain.TabPages.Clear();
            ErrorPieChart.Series["Error"].Points.Clear();
            grdTotal.DataSource = null;
            grdTotal.RefreshDataSource();
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
            tabMain.TabPages.Clear();

            XtraTabPage tp = null;
            UCErrorProcessReport ucProcessReport = null;
            int iCount = 0;

            if (m_cProcessS == null)
                return;

            foreach (CPlcProc cProcess in m_cProcessS.Values)
            {
                tp = new XtraTabPage();
                ucProcessReport = new UCErrorProcessReport();
                ucProcessReport.Dock = DockStyle.Fill;

                if (m_lstErrorInfoSum.ContainsKey(cProcess.Name))
                    ucProcessReport.ErrorInfoSum = m_lstErrorInfoSum[cProcess.Name];

                tp.Name = "tp" + iCount.ToString();
                iCount++;
                tp.Tag = ucProcessReport;
                tp.Text = cProcess.Name;
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

                if (DicErrorInfoS.Count == 0)
                {
                    cErrorView = null;
                    return;
                }

                cErrorView.MostError = DicErrorInfoS.ElementAt(iMostIndex).Key;
                lstErrorView.Add(cErrorView);
            }

            grdTotal.DataSource = lstErrorView;
            grdTotal.RefreshDataSource();
        }

        private void UCErrorReport_Load(object sender, EventArgs e)
        {

        }

        private void ErrorPieChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            CErrorInfoSummary cValue = (CErrorInfoSummary)e.SeriesPoint.Tag;
            e.LabelText = e.SeriesPoint.Argument + string.Format(", {0}", cValue.lstErrorInfo.Count);
        }
    }

    public partial class CErrorView
    {
        private string m_sGroupKey = string.Empty;
        private int m_iErrorCount = 0;
        private string m_sMostError = string.Empty;


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
