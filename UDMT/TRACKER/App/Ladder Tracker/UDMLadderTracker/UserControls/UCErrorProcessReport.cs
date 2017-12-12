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
using UDM.Log;
using UDMLadderTracker.UserControls;

namespace UDMLadderTracker
{
    public partial class UCErrorProcessReport : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoSummary m_cErrorInfoSum = null;

        public UCErrorProcessReport()
        {
            InitializeComponent();
        }

        public CErrorInfoSummary ErrorInfoSum
        {
            get { return m_cErrorInfoSum; }
            set { SetProcessErrorInfo(value); }
        }

        public void ClearControls()
        {
            if (pnlErrorChart.Controls != null && pnlErrorChart.Controls.Count > 0)
                pnlErrorChart.Controls.Clear();

            grdProcess.DataSource = null;
        }

        private void SetProcessErrorInfo(CErrorInfoSummary cErrorInfoSum)
        {
            if (cErrorInfoSum == null)
                return;

            m_cErrorInfoSum = cErrorInfoSum;

            SetGroupElementChart();
            SetErrorChart();
            SetErrorGrid();
        }

        private void SetErrorChart()
        {
            if (pnlChart.Controls != null && pnlChart.Controls.Count > 0)
                pnlChart.Controls.Clear();

            UCErrorStatisticChart ucViewer = new UCErrorStatisticChart();
            ucViewer.Dock = DockStyle.Fill;
            ucViewer.SetDetailErrorChart(m_cErrorInfoSum);

            pnlChart.Controls.Add(ucViewer);
        }

        private void SetErrorGrid()
        {
            Dictionary<string, int> DicMergedCategory = null;

            DicMergedCategory = m_cErrorInfoSum.GetMergedCategoryErrorInfo();

            CErrorView cErrorView = null;
            List<CErrorView> lstErrorView = new List<CErrorView>();

            foreach (var who in DicMergedCategory)
            {
                cErrorView = new CErrorView();
                cErrorView.ErrorCount = who.Value;
                cErrorView.MostError = who.Key;

                lstErrorView.Add(cErrorView);
            }

            grdProcess.DataSource = lstErrorView;
            grdProcess.RefreshDataSource();
        }

        private void SetGroupElementChart()
        {
            Dictionary<string, CErrorInfoS> DicErrorInfo = new Dictionary<string, CErrorInfoS>();
            Series cSeries = ErrorPieChart.Series["Error"];
            SeriesPoint cPoint = null;

            if (m_cErrorInfoSum == null)
                return;

            DicErrorInfo = m_cErrorInfoSum.GetErrorReportValue();

            cSeries.Points.Clear();

            foreach (var who in DicErrorInfo)
            {
                cPoint = new SeriesPoint(who.Key, new double[] { who.Value.Count });
                cSeries.Points.Add(cPoint);
            }

            ErrorPieChart.Update();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (m_cErrorInfoSum == null)
                return;

            SetErrorChart();
            SetGroupElementChart();
        }

        private void btnChartClear_Click(object sender, EventArgs e)
        {
            pnlChart.Controls.Clear();
            ErrorPieChart.Series["Error"].Points.Clear();
        }
    }
}
