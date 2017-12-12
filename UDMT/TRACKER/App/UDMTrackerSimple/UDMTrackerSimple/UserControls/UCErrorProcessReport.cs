using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
using UDM.Log;
using UDMTrackerSimple.UserControls;

namespace UDMTrackerSimple
{
    public partial class UCErrorProcessReport : DevExpress.XtraEditors.XtraUserControl
    {
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private CErrorInfoSummary m_cErrorInfoSum = null;

        private delegate void UpdateProcessReportCallback(CErrorInfoSummary cInfoSummary);

        public UCErrorProcessReport()
        {
            InitializeComponent();

            ucError.PanelFilter = false;
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
            if (this.InvokeRequired)
            {
                UpdateProcessReportCallback cUpdate = new UpdateProcessReportCallback(SetProcessErrorInfo);
                this.Invoke(cUpdate, new object[] {cErrorInfoSum});
            }
            else
            {
                if (cErrorInfoSum == null)
                    return;

                m_cErrorInfoSum = cErrorInfoSum;

                SetGroupElementChart();
                SetErrorChart();
                SetErrorGrid();
                SetErrorDetailGrid();
            }
        }

        private void SetErrorDetailGrid()
        {
            List<int> lstErrorID = new List<int>();

            foreach (var who in m_cErrorInfoSum.lstErrorInfo)
            {
                if(!lstErrorID.Contains(who.ErrorID))
                    lstErrorID.Add(who.ErrorID);
            }

            CErrorInfoS cInfoS = CMultiProject.LogReader.GetErrorInfoS(CMultiProject.ProjectID, lstErrorID);

            if (cInfoS == null)
                return;

            ucError.UpdateView(cInfoS);
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
                if (who.Key == string.Empty)
                    continue;

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

        private void UCErrorProcessReport_Load(object sender, EventArgs e)
        {
            try
            {
                sptMain.SplitPosition = (int)(this.Width * 0.3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
