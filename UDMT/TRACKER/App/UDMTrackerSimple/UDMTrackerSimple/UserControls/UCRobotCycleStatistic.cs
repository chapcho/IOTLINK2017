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
using UDM.Common;
using UDM.General.Statistics;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCRobotCycleStatistic : DevExpress.XtraEditors.XtraUserControl
    {
        private CTag m_cTag = null;
        private CTimeLogS m_cTimeLogS = null;

        private CRobotStatisticView m_cStaticView = null;
        List<CRobotStatisticView> m_lstStatistic = new List<CRobotStatisticView>(); 

        public UCRobotCycleStatistic()
        {
            InitializeComponent();
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS;}
            set { m_cTimeLogS = value; }
        }

        public void Clear()
        {
            exChart.Series["Min"].Points.Clear();
            exChart.Series["Max"].Points.Clear();
            exChart.Series["Avr"].Points.Clear();

            exCycleChart.Series["Cycle"].Points.Clear();
            exCycleChart.Series["Average"].Points.Clear();

            grdRobot.DataSource = null;
        }

        public void UpdateView(CTimeLogS cTimeLogS)
        {
            m_cTimeLogS = cTimeLogS;

            SetRobotCycleStatistic();

            if (m_cStaticView != null)
            {
                if (chkAbnormalFilter.Checked)
                    SetAllCycle(m_cStaticView.Average, true);
                else
                    SetAllCycle(m_cStaticView.Average, false);
            }
        }

        private void SetRobotCycleStatistic()
        {
            m_lstStatistic.Clear();

            if (m_cTag == null || m_cTimeLogS == null || m_cTimeLogS.Count == 0)
                return;

            lblTitle.Text = m_cTag.Description;

            exChart.Series["Min"].Points.Clear();
            exChart.Series["Max"].Points.Clear();
            exChart.Series["Avr"].Points.Clear();

            bool bOn = false;
            DateTime dtOnTime = DateTime.MinValue;
            CRobotStatisticView cView = null;
            List<double> lstStatistic = new List<double>();

            foreach (CTimeLog cLog in m_cTimeLogS)
            {
                if (cLog.Value == 1)
                {
                    bOn = true;
                    dtOnTime = cLog.Time;
                }

                if (bOn && cLog.Value == 0)
                {
                    cView = new CRobotStatisticView();
                    cView.StartTime = dtOnTime;
                    cView.Cycle = cLog.Time.Subtract(dtOnTime).TotalSeconds;
                    m_lstStatistic.Add(cView);
                    lstStatistic.Add(cView.Cycle);

                    bOn = false;
                }
                Application.DoEvents();
            }

            if (m_lstStatistic.Count == 0)
                return;

            List<CRobotStatisticView> lstView = new List<CRobotStatisticView>();

            m_cStaticView = new CRobotStatisticView();
            m_cStaticView.Average = CStatics.Mean(lstStatistic);
            m_cStaticView.Min = lstStatistic.Min();
            m_cStaticView.Max = lstStatistic.Max();

            lstView.Add(m_cStaticView);

            SeriesPoint cPoint = null;

            cPoint = new SeriesPoint(m_cTag.Description, new double[] { m_cStaticView.Average } );
            exChart.Series["Avr"].Points.Add(cPoint);

            cPoint = new SeriesPoint(m_cTag.Description, new double[] { m_cStaticView.Min });
            exChart.Series["Min"].Points.Add(cPoint);

            cPoint = new SeriesPoint(m_cTag.Description, new double[] { m_cStaticView.Max });
            exChart.Series["Max"].Points.Add(cPoint);

            grdRobot.DataSource = null;
            grdRobot.DataSource = lstView;
            grdRobot.RefreshDataSource();
        }

        private void SetAllCycle(double dAverage, bool bAbnormal)
        {
            if (m_lstStatistic == null || m_lstStatistic.Count == 0)
                return;

            txtAverage.EditValue = dAverage;

            exCycleChart.Series["Cycle"].Points.Clear();
            exCycleChart.Series["Average"].Points.Clear();

            SeriesPoint cPoint = null;
            SeriesPoint cAveragePoint = null;
            int iSeriesCount = 0;

            for (int i = 0; i < m_lstStatistic.Count; i ++)
            {
                if (i == 0)
                    dtpkFrom.EditValue = m_lstStatistic[i].StartTime;
                else if (i == m_lstStatistic.Count - 1)
                    dtpkTo.EditValue = m_lstStatistic[i].StartTime;

                if (bAbnormal && !(m_lstStatistic[i].Cycle > dAverage))
                    continue;

                cAveragePoint = new SeriesPoint(++iSeriesCount, new double[] { dAverage });
                cPoint = new SeriesPoint(iSeriesCount, new double[] { Math.Round(m_lstStatistic[i].Cycle, 2) });
                cPoint.Tag = m_lstStatistic[i];

                if (m_lstStatistic[i].Cycle > dAverage)
                {
                    cPoint.Color = Color.Red;
                    cPoint.ToolTipHint = "Start Time : " + m_lstStatistic[i].StartTime + "\r\nCycle : " + m_lstStatistic[i].Cycle + "\r\nOver Time : " +
                                         Math.Round(m_lstStatistic[i].Cycle - dAverage, 2) + "";
                    cAveragePoint.ToolTipHint = "Average : " + dAverage ;
                }
                else
                {
                    cPoint.Color = Color.DodgerBlue;
                    cPoint.ToolTipHint = "Start Time : " + m_lstStatistic[i].StartTime + "\r\nCycle : " + m_lstStatistic[i].Cycle ;
                    cAveragePoint.ToolTipHint = "Average : " + dAverage;
                }

                exCycleChart.Series["Average"].Points.Add(cAveragePoint);
                exCycleChart.Series["Cycle"].Points.Add(cPoint);
                Application.DoEvents();
            }
        }

        private void UCRobotCycleStatistic_Load(object sender, EventArgs e)
        {
            SetRobotCycleStatistic();

            if(m_cStaticView != null)
                SetAllCycle(m_cStaticView.Average, false);
        }

        private void exCycleChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void chkAbnormalFilter_CheckedChanged(object sender, EventArgs e)
        {
            string sValue = txtAverage.EditValue.ToString();
            double dValue = Convert.ToDouble(sValue);

            if (chkAbnormalFilter.Checked)
                SetAllCycle(dValue, true);
            else
                SetAllCycle(dValue, false);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string sValue = txtAverage.EditValue.ToString();
            double dValue = Convert.ToDouble(sValue);

            if(chkAbnormalFilter.Checked)
                SetAllCycle(dValue, true);
            else
                SetAllCycle(dValue, false);
        }

        private void exCycleChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hitinfo = this.exCycleChart.CalcHitInfo(e.Location);

            string sAverage = txtAverage.EditValue.ToString();
            double dAverage = Convert.ToDouble(sAverage);

            if (hitinfo.InSeries)
            {
                SeriesPoint cPoint = hitinfo.SeriesPoint;

                if (cPoint == null || cPoint.Tag == null || cPoint.Tag.GetType() != typeof(CRobotStatisticView))
                    return;

                CRobotStatisticView cView = (CRobotStatisticView)cPoint.Tag;

                if (cView.Cycle < dAverage)
                    return;

                FrmDeviceDetailViewer frmView = new FrmDeviceDetailViewer();
                frmView.Time = cView.StartTime;
                frmView.Show();
            }
        }
    }

    public partial class CRobotStatisticView
    {
        private double dMin = 0;
        private double dMax = 0;
        private double dAvr = 0;
        private double dCycle = 0;
        private DateTime dtFrom = DateTime.MinValue;

        public double Cycle
        {
            get { return Math.Round(dCycle, 2);}
            set { dCycle = value; }
        }

        public DateTime StartTime
        {
            get { return dtFrom; }
            set { dtFrom = value; }
        }

        public double Min
        {
            get { return Math.Round(dMin, 2); }
            set { dMin = value; }
        }

        public double Max
        {
            get { return Math.Round(dMax, 2); }
            set { dMax = value; }
        }

        public double Average
        {
            get { return Math.Round(dAvr, 2); }
            set { dAvr = value; }
        }
    }
}
