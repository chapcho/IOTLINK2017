using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraSpellChecker.Parser;
using UDM.Log;

namespace UDMLadderTracker.UserControls
{
    public partial class UCErrorStatisticChart : DevExpress.XtraEditors.XtraUserControl
    {
        private string m_sGroupKey = string.Empty;
        private CErrorInfoSummary m_cErrorInfoSummary = new CErrorInfoSummary();

        private delegate void UpdateChartGroupCallback();

        public UCErrorStatisticChart()
        {
            InitializeComponent();
        }

        public ChartControl Chart
        {
            get { return ErrorChart; }
        }

        public CErrorInfoSummary ErrorInfoSummary
        {
            get { return m_cErrorInfoSummary; }
            set
            {
                m_cErrorInfoSummary = value;
                SetSeriesPoint();
            }
        }

        public string ProcessKey
        {
            get { return m_sGroupKey; }
            set
            {
                m_sGroupKey = value;
                SetChart();
            }
        }

        public void SetDetailErrorChart(CErrorInfoSummary cErrorInfoSum)
        {
            if (cErrorInfoSum == null)
                return;

            m_sGroupKey = cErrorInfoSum.GroupKey;
            m_cErrorInfoSummary = cErrorInfoSum;

                Dictionary<string, CErrorInfoS> SeriesPointValue = new Dictionary<string, CErrorInfoS>();
                Series cSeries = null;
                SeriesPoint cPoint = null;
                SideBySideBarSeriesLabel exLabel = null;

                SeriesPointValue = m_cErrorInfoSummary.GetErrorReportValue();

                ErrorChart.Series.Clear();

                ErrorChart.BeginInit();
                {
                    cSeries = new Series();
                    ((BarSeriesView) cSeries.View).ColorEach = true;

                    foreach (var who in SeriesPointValue)
                    {
                        ((System.ComponentModel.ISupportInitialize)(cSeries)).BeginInit();
                        {
                            cPoint = new SeriesPoint(who.Key, new double[] { who.Value.Count });
                            cPoint.Tag = who.Value;
                            cPoint.ToolTipHint = "Message : [" + who.Key + "]\r\nAddress : " + who.Value[0].SymbolKey +
                                                 "\r\nCount : " + who.Value.Count + "";

                            cSeries.Points.Add(cPoint);

                            exLabel = new SideBySideBarSeriesLabel();
                            exLabel.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
                            cSeries.Label = exLabel;
                            cSeries.LabelsVisibility = DefaultBoolean.True;
                        }
                        ((System.ComponentModel.ISupportInitialize)(cSeries)).EndInit();
                    }

                    ErrorChart.Series.Add(cSeries);
                }
                ErrorChart.EndInit();

            ErrorChart.Legend.Visibility = DefaultBoolean.False;

                XYDiagram diagram = (XYDiagram)ErrorChart.Diagram;
                diagram.AxisY.Visibility = DefaultBoolean.False;
                diagram.AxisX.Title.Visibility = DefaultBoolean.True;
                diagram.AxisX.Title.Text = m_sGroupKey;
        }

        private void SetChart()
        {
            if (this.InvokeRequired)
            {
                UpdateChartGroupCallback cUpdate = new UpdateChartGroupCallback(SetChart);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                Series cSeries = new Series();
                ErrorChart.Series.Add(cSeries);

                XYDiagram diagram = (XYDiagram)ErrorChart.Diagram;
                diagram.AxisY.Visibility = DefaultBoolean.False;
                diagram.AxisX.Title.Visibility = DefaultBoolean.False;
            }
        }

        private void SetSeriesPoint()
        {
            if (m_cErrorInfoSummary == null)
                return;

            if (this.InvokeRequired)
            {
                UpdateChartGroupCallback cUpdate = new UpdateChartGroupCallback(SetSeriesPoint);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                Dictionary<string, CErrorInfoS> SeriesPointValue = new Dictionary<string, CErrorInfoS>();
                Series cSeries = null;
                SeriesPoint cPoint = null;
                SideBySideBarSeriesLabel exLabel = null;

                SeriesPointValue = m_cErrorInfoSummary.GetErrorReportValue();

                ErrorChart.Series.Clear();

                ErrorChart.BeginInit();
                {
                    foreach (var who in SeriesPointValue)
                    {
                        cSeries = new Series();
                        ((System.ComponentModel.ISupportInitialize)(cSeries)).BeginInit();
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {who.Value.Count});
                            cPoint.Tag = who.Value;
                            cPoint.ToolTipHint = "Message : [" + who.Key + "]\r\nAddress : " + who.Value[0].SymbolKey +
                                                 "\r\nCount : " + who.Value.Count + "";

                            cSeries.Points.Add(cPoint);

                            exLabel = new SideBySideBarSeriesLabel();
                            exLabel.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
                            cSeries.Label = exLabel;
                            cSeries.LabelsVisibility = DefaultBoolean.True;
                        }
                        ((System.ComponentModel.ISupportInitialize)(cSeries)).EndInit();

                        ErrorChart.Series.Add(cSeries);
                    }
                }
                ErrorChart.EndInit();
            }
        }

        private void UCErrorStatisticChart_Load(object sender, EventArgs e)
        {

        }

        private void ErrorChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void ErrorChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            CErrorInfoS cErrorInfoS = null;

            SeriesPoint cPoint = e.SeriesPoint;

            if (cPoint == null)
                return;

            if (cPoint.Tag.GetType() != typeof (CErrorInfoS))
                return;

            cErrorInfoS = (CErrorInfoS)cPoint.Tag;

            e.LabelText = cErrorInfoS[0].ErrorMessage + "\r\n Count : " + cErrorInfoS.Count;
        }
    }
}
