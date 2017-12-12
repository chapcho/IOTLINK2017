using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCSummary : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = null;
        private CPlcProcS m_cProcessS = null;
        private CCycleInfoS m_cCycleInfoS = null;

        private UCCycleCardView m_ucCycleView = null;
        private UCErrorCardView m_ucErrorView = null;
        private UCErrorCategory m_ucErrorChart = null;
        private UCMaintenance m_ucMaintenance = null;
        private UCConnect m_ucConnect = null;

        private delegate void UpdateSummaryViewCallback();

        public UCSummary()
        {
            InitializeComponent();
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set { m_cErrorInfoS = value; }
        }

        public CPlcProcS ProcessS
        {
            get { return m_cProcessS;}
            set { m_cProcessS = value; }
        }

        public CCycleInfoS CycleInfoS
        {
            get { return m_cCycleInfoS; }
            set { m_cCycleInfoS = value; }
        }

        public void Run()
        {
            //m_ucCycleView.MonitorViewer = m_cMonitorViwer;
            m_ucCycleView.Run();
        }

        public void Stop()
        {
            m_ucCycleView.Stop();   
        }

        public void ClearControl()
        {
            if(m_ucCycleView != null)
                m_ucCycleView.ClearControls();

            if(m_ucErrorChart != null)
                m_ucErrorChart.ClearChart();

            if (m_ucErrorView != null)
            {
                m_ucErrorView.ClearControls();
                m_ucErrorView.UEventErrorGroupClicked -= ucSummary_UEventErrorGroupClick;
            }
        }

        public void UpdateCycle()
        {
            if (this.InvokeRequired)
            {
                UpdateSummaryViewCallback cUpdate = new UpdateSummaryViewCallback(UpdateCycle);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                m_ucCycleView.UpdateView();
                m_ucErrorView.UpdateCycle();
            }
        }

        public void UpdateError()
        {
            if (this.InvokeRequired)
            {
                UpdateSummaryViewCallback cUpdate = new UpdateSummaryViewCallback(UpdateError);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                m_ucErrorView.UpdateError();
                m_ucErrorChart.UpdateError();
            }
        }

        public void InitComponent()
        {
            if (m_ucCycleView != null && m_ucErrorView != null && m_ucErrorChart != null && m_ucConnect != null &&
                m_ucMaintenance != null)
            {
                m_ucCycleView.SetView(m_cProcessS, m_cCycleInfoS);

                m_ucErrorView.ErrorInfoS = m_cErrorInfoS;
                m_ucErrorView.SetView(m_cProcessS, m_cCycleInfoS);
                m_ucErrorChart.ErrorInfoS = m_cErrorInfoS;

                m_ucErrorView.UEventErrorGroupClicked += ucSummary_UEventErrorGroupClick;
            }
        }

        private void widgetSummary_QueryControl(object sender,
            DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
            {
                string sControlType = e.Document.ControlTypeName;

                switch (sControlType)
                {
                    case "UDMTrackerSimple.UCCycleCardView" :
                        m_ucCycleView = new UCCycleCardView();
                        e.Control = m_ucCycleView;
                        break;
                    case "UDMTrackerSimple.UCErrorCardView":
                        m_ucErrorView = new UCErrorCardView();
                        e.Control = m_ucErrorView;
                        break;
                    case "UDMTrackerSimple.UCErrorCategory":
                        m_ucErrorChart = new UCErrorCategory();
                        e.Control = m_ucErrorChart;
                        break;
                    case "UDMTrackerSimple.UCConnect" :
                        m_ucConnect = new UCConnect();
                        e.Control = m_ucConnect;
                        break;
                    case "UDMTrackerSimple.UCMaintenance" :
                        m_ucMaintenance = new UCMaintenance();
                        e.Control = m_ucMaintenance;
                        break;
                }
            }
            InitComponent();
        }

        private void UCSummary_Load(object sender, EventArgs e)
        {

        }

        private void ucSummary_UEventErrorGroupClick(object sender, CErrorInfoSummary cErrorInfoSum)
        {
            if (cErrorInfoSum == null)
                return;

            m_ucErrorChart.ErrorInfoSummary = cErrorInfoSum;
        }

    }
}

