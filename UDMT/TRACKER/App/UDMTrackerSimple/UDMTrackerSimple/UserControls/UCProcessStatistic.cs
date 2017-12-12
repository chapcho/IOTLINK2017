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

namespace UDMTrackerSimple
{
    public partial class UCProcessStatistic : DevExpress.XtraEditors.XtraUserControl
    {
        private CStatisticsViewRow m_cStatisticView = null;

        public UCProcessStatistic()
        {
            InitializeComponent();
        }

        public CStatisticsViewRow StatisticView
        {
            get { return m_cStatisticView; }
            set { m_cStatisticView = value; }
        }

        private void SetCycleInfo()
        {
            if (m_cStatisticView == null)
                return;

            string sGroupKey = m_cStatisticView.GroupInfo.GroupKey;

            lblTitle.Text = sGroupKey;

            SeriesPoint cNormalPoint;
            SeriesPoint cErrorPoint;
            CCycleInfoView cView = m_cStatisticView.CycleInfoView;
            int iTotalCount = cView.TotalCount;
            int iErrorCount = cView.ErrorCount;

            exPieChart.Series["Cycle"].Points.Clear();

            //Cycle Count Pie Chart
            cNormalPoint = new SeriesPoint(sGroupKey, new double[] { iTotalCount - iErrorCount });
            cErrorPoint = new SeriesPoint(sGroupKey, new double[] { iErrorCount });

            exPieChart.Series["Cycle"].Points.Add(cNormalPoint);
            exPieChart.Series["Cycle"].Points.Add(cErrorPoint);

            lblTotalCount.Text = iTotalCount.ToString();

            //Cycle Grid
            List<CCycleInfoView> lstCycleInfo = new List<CCycleInfoView>();
            lstCycleInfo.Add(cView);

            grdCycleInfo.DataSource = null;
            grdCycleInfo.DataSource = lstCycleInfo;
            grdCycleInfo.RefreshDataSource();

            //Cycle Bar Chart
            exCycleChart.Series["Avr"].Points.Clear();
            exCycleChart.Series["Min"].Points.Clear();
            exCycleChart.Series["Max"].Points.Clear();
            exCycleChart.Series["Std"].Points.Clear();
            exCycleChart.Series["Cp"].Points.Clear();
            exCycleChart.Series["Cpk"].Points.Clear();

            SeriesPoint cPoint;

            cPoint = new SeriesPoint(sGroupKey, new double[] {cView.Mean});
            exCycleChart.Series["Avr"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Minimum });
            exCycleChart.Series["Min"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Maximum });
            exCycleChart.Series["Max"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.StandardDev });
            exCycleChart.Series["Std"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Cp });
            exCycleChart.Series["Cp"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Cpk });
            exCycleChart.Series["Cpk"].Points.Add(cPoint);
        }

        private void SetIdleInfo()
        {
            if (m_cStatisticView == null)
                return;

            string sGroupKey = m_cStatisticView.GroupInfo.GroupKey;
            CIdleInfo cView = m_cStatisticView.IdleInfo;

            //Idle Info Grid
            List<CIdleInfo> lstIdleInfo = new List<CIdleInfo>();
            lstIdleInfo.Add(cView);

            grdIdleInfo.DataSource = null;
            grdIdleInfo.DataSource = lstIdleInfo;
            grdIdleInfo.RefreshDataSource();

            //Idle Info Chart
            exIdleChart.Series["Avr"].Points.Clear();
            exIdleChart.Series["Min"].Points.Clear();
            exIdleChart.Series["Max"].Points.Clear();

            SeriesPoint cPoint;

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Mean });
            exIdleChart.Series["Avr"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Minimum });
            exIdleChart.Series["Min"].Points.Add(cPoint);

            cPoint = new SeriesPoint(sGroupKey, new double[] { cView.Maximum });
            exIdleChart.Series["Max"].Points.Add(cPoint);
        }

        private void UCProcessStatistic_Load(object sender, EventArgs e)
        {
            SetCycleInfo();
            SetIdleInfo();
        }

        private void exPieChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            var PointValue = e.SeriesPoint.Values[0];

            e.LabelText = PointValue.ToString();
        }

        private void chkStd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStd.Checked)
                exCycleChart.Series["Std"].Visible = true;
            else
                exCycleChart.Series["Std"].Visible = false;
        }

        private void chkCp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCp.Checked)
                exCycleChart.Series["Cp"].Visible = true;
            else
                exCycleChart.Series["Cp"].Visible = false;
        }

        private void chkCpk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCpk.Checked)
                exCycleChart.Series["Cpk"].Visible = true;
            else
                exCycleChart.Series["Cpk"].Visible = false;
        }



    }
}
