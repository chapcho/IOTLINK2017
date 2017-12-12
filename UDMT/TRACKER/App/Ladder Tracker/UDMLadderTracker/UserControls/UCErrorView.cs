using System;
using System.Collections.Generic;
using System.Threading;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Log;
using UDMLadderTracker.UserControls;


namespace UDMLadderTracker
{
    public partial class UCErrorView : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = null;
        private CPlcProcS m_cProcessS = null;
        
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        private delegate void UpdateErrorCallBack(CErrorInfo cErrorInfo);
        private delegate void UpdateErrorCallBack2(CErrorInfoSummary cErrorInfoSum);

        private Thread m_Thread = null;

        private UCErrorCardView m_ucError = new UCErrorCardView();
        private UCErrorDetail m_ucErrorDetail = new UCErrorDetail();

        public UCErrorView()
        {
            InitializeComponent();
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set { m_cErrorInfoS = value;}
        }

        public CPlcProcS ProcessS
        {
            get { return m_cProcessS; }
            set { m_cProcessS = value; }
        }

        public void SetErrorView(CErrorInfoS cErrorInfoS, CPlcProcS cProcessS)
        {
            m_cErrorInfoS = cErrorInfoS;
            m_cProcessS = cProcessS;

            m_ucErrorDetail.UpdateView(m_cErrorInfoS);
            m_ucError.ErrorInfoS = m_cErrorInfoS;
            m_ucError.SetView(m_cProcessS);
        }

        public void ClearControl()
        {
            m_ucError.ClearControls();
            m_ucErrorDetail.ClearGrid();
            m_ucErrorDetail.ClearAnalysis();
        }

        public void UpdateView(CErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorCallBack cUpdate = new UpdateErrorCallBack(UpdateView);
                this.Invoke(cUpdate, new object[] { cErrorInfo });
            }
            else
            {
                m_ucError.UpdateError(cErrorInfo);
                m_ucErrorDetail.UpdateView(m_cErrorInfoS);
            }
        }

        private void UCErrorView_Load(object sender, EventArgs e)
        {
            m_ucError.UEventErrorGroupClicked += ucError_UEventErrorGroupClick;
        }

        private void widgetError_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
            {
                string sControlType = e.Document.ControlTypeName;

                switch (sControlType)
                {
                    case "UDMTrackerSimple.UCErrorCardView":
                        e.Control = m_ucError;
                        break;
                    case "UDMTrackerSimple.UCErrorDetail":
                        e.Control = m_ucErrorDetail;
                        break;
                }
            }
        }

        private void ucError_UEventErrorGroupClick(object sender, CErrorInfoSummary cErrorInfoSum)
        {
            if (cErrorInfoSum == null)
                return;

            CErrorInfoS cErrorInfoS = new CErrorInfoS();
            cErrorInfoS.AddRange(cErrorInfoSum.lstErrorInfo);
            cErrorInfoS.SetTimeRange();

            m_ucErrorDetail.UpdateView(cErrorInfoS);
            m_ucErrorDetail.ClearAnalysis();
        }

    }
}
