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

namespace UDMLadderTracker
{
    public partial class UCErrorCategory : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = null;
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();
        private CErrorInfoSummary m_cErrorInfoSummary = null;

        public delegate void UEventHandlerErrorChartClearButtonClicked(object sender);
        public delegate void UEventHandlerErrorChartRefreshButtonClick(object sender, CErrorInfoS cErrorInfoS);

        public event UEventHandlerErrorChartClearButtonClicked UEventErrorChartClearButtonClicked;
        public event UEventHandlerErrorChartRefreshButtonClick UEventErrorChartRefreshButtonClicked;


        public UCErrorCategory()
        {
            InitializeComponent();
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

                SetGroupChart();
            }
        }

        public CErrorInfoSummary ErrorInfoSummary
        {
            get { return m_cErrorInfoSummary; }
            set
            {
                m_cErrorInfoSummary = value;
                SetGroupElementChart();
            }
        }

        public void ClearChart()
        {
            ErrorPieChart.Series["Error"].Points.Clear();
            m_lstErrorInfoSum.Clear();
        }

        public void UpdateError()
        {
            CErrorInfoSummary cErrorSum = null;

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

            SetGroupChart();
        }

        public void UpdateError(CErrorInfo cInfo)
        {
            CErrorInfoSummary cErrorSum = null;

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

            SetGroupChart();
        }

        private void SetGroupChart()
        {
            Series cSeries = ErrorPieChart.Series["Error"];
            SeriesPoint cPoint = null;

            if (m_lstErrorInfoSum.Count == 0)
                return;

            cSeries.Points.Clear();
            cSeries.LegendPointOptions.PointView = PointView.Argument;
            cSeries.LegendTextPattern = "{A}";

            foreach(var who in m_lstErrorInfoSum)
            {
                cPoint = new SeriesPoint(who.Key, new double[] {who.Value.ErrorCount});

                cSeries.Points.Add(cPoint);

            }
        }

        private void SetGroupElementChart()
        {
            Dictionary<string, CErrorInfoS> DicErrorInfo = new Dictionary<string, CErrorInfoS>();
            Series cSeries = ErrorPieChart.Series["Error"];
            SeriesPoint cPoint = null;

            if (m_cErrorInfoSummary == null)
                return;

            DicErrorInfo = m_cErrorInfoSummary.GetErrorReportValue();

            cSeries.Points.Clear();

            foreach (var who in DicErrorInfo)
            {
                cPoint = new SeriesPoint(who.Key, new double[] {who.Value.Count});
                cSeries.Points.Add(cPoint);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ErrorPieChart.Series["Error"].Points.Clear();

            if (UEventErrorChartClearButtonClicked != null)
                UEventErrorChartClearButtonClicked(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetGroupChart();

            if (UEventErrorChartRefreshButtonClicked != null)
                UEventErrorChartRefreshButtonClicked(this, m_cErrorInfoS);
        }

    }
}
