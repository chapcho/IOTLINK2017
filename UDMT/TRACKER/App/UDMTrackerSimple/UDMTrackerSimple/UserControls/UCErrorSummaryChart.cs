using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using TrackerCommon;
using UDM.Log;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using UDM.Common;

namespace UDMTrackerSimple
{
    public partial class UCErrorSummaryChart : DevExpress.XtraEditors.XtraUserControl
    {
        private List<CErrorInfoSummary> m_lstInfoSum = null;
        private string m_sPlcName = string.Empty;

        public string PlcName
        {
            get { return m_sPlcName; }
            set { m_sPlcName = value; }
        }

        public List<CErrorInfoSummary> ErrorInfoSumS
        {
            get { return m_lstInfoSum; }
            set
            {
                m_lstInfoSum = value;
                SetView();
            }
        }

        public UCErrorSummaryChart()
        {
            InitializeComponent();
        }

        public void SetView()
        {
            try
            {
                if (m_lstInfoSum == null || m_lstInfoSum.Count == 0)
                    return;

                Series cSeries = null;
                SeriesPoint cPoint = null;
                SideBySideBarSeriesLabel exLabel = null;

                ErrorChart.Series.Clear();

                ErrorChart.BeginInit();
                {
                    cSeries = new Series();
                    ((BarSeriesView)cSeries.View).ColorEach = true;

                    foreach (CErrorInfoSummary cInfoSum in m_lstInfoSum)
                    {
                        if (cInfoSum.TotalErrorCount == 0)
                            continue;

                        //Cycle Over같은 것은 어떻게???
                        string sGroupKey = cInfoSum.GroupKey;

                        //if (CMultiProject.PlcProcS.ContainsKey(cInfoSum.GroupKey) && CMultiProject.PlcProcS[cInfoSum.GroupKey].TotalAbnormalSymbolKey != string.Empty)
                        //{
                        //    CTag cTag = CMultiProject.TotalTagS[CMultiProject.PlcProcS[cInfoSum.GroupKey].TotalAbnormalSymbolKey];

                        //    if (cTag != null)
                        //        sGroupKey = cTag.GetDescription();

                        //    cTag = null;
                        //}

                        ((System.ComponentModel.ISupportInitialize)(cSeries)).BeginInit();
                        {
                            cPoint = new SeriesPoint(sGroupKey, new double[] { cInfoSum.TotalErrorCount });
                            cPoint.ToolTipHint = string.Format("공정 : {0}\r\n개수 : {1}", sGroupKey, cInfoSum.TotalErrorCount);
                            cPoint.Tag = sGroupKey;

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
                diagram.AxisX.Title.Text = m_sPlcName;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            m_lstInfoSum = null;
            ErrorChart.Series.Clear();
        }

        private void ErrorChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            try
            {
                foreach (CrosshairElement element in e.CrosshairElements)
                {
                    SeriesPoint exPoint = element.SeriesPoint;
                    element.LabelElement.Text = exPoint.ToolTipHint;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCErrorSummaryChart", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ErrorChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            SeriesPoint cPoint = e.SeriesPoint;

            if (cPoint == null)
                return;

            e.LabelText = cPoint.Tag.ToString() + "\r\n Count : " + cPoint.Values[0];
        }


    }
}
