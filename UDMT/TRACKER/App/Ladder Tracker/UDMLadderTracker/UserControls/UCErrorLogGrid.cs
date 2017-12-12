using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;
using UDM.Log.DB;
using UDM.Common;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace UDMLadderTracker.UserControls
{
    public partial class UCErrorLogGrid : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = new CErrorInfoS();

        Thread m_Thread = null;

        private delegate void UpdateErrorInfoSCallback(CErrorInfoS cErrorInfoS);
        private delegate void UpdateErrorInfoCallback(CErrorInfo cErrorInfo);
        private delegate void UpdateShowErrorCallback();

        public event UEventHandlerErrorLogGridDoubleClick UErrorLogGridDoubleClickEvent;
        public event UEventHandlerErrorCauseTagDoubleClicked UErrorCauseTagDoubleClickEvent;

        #region Initialize/Dispose

        public UCErrorLogGrid()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set { m_cErrorInfoS = value; }
        }

        #endregion

        #region Public Methods

        public void UpdateView(CErrorInfoS cErrorInfoS)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorInfoSCallback updateErrorInfoS = new UpdateErrorInfoSCallback(UpdateView);
                this.Invoke(updateErrorInfoS, new object[] { cErrorInfoS });
            }
            else
            {
                m_cErrorInfoS = cErrorInfoS;

                if (pnlCauseError.Visible)
                {
                    pnlCauseError.Visible = false;
                    sptMain.Visible = false;
                }

                this.grdError.DataSource = null;
                this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();

                this.grdError.RefreshDataSource();
            }
        }

        public void UpdateView(CErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorInfoCallback updateErrorInfo = new UpdateErrorInfoCallback(UpdateView);
                this.Invoke(updateErrorInfo, new object[] { cErrorInfo });
            }
            else
            {
                CErrorInfoS cErrorInfoS = new CErrorInfoS();

                if (m_cErrorInfoS == null)
                {
                    cErrorInfoS.Add(cErrorInfo);
                    m_cErrorInfoS = cErrorInfoS;
                }
                else if (m_cErrorInfoS.Count != 0)
                    m_cErrorInfoS.Add(cErrorInfo);

                if (pnlCauseError.Visible)
                {
                    pnlCauseError.Visible = false;
                    sptMain.Visible = false;
                }

                this.grdError.DataSource = null;
                this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();

                this.grdError.RefreshDataSource();
            }
        }

        public void ClearGrid()
        {
            if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                return;

            m_cErrorInfoS.Clear();

            ucErrorCause.ClearGrid();
        }

        public void ExportGridView(string sPath)
        {
            grdError.ExportToXlsx(sPath);            
        }

        public void ShowPrintPreview()
        {
            grdError.ShowPrintPreview();
        }

        public void ShowError()
        {
            grvError_DoubleClick(null, null);
        }

        #endregion

        #region Private Methods

        private void ShowErrorAnalysisViewer(CErrorInfo cErrorInfo)
        {
            if (UErrorLogGridDoubleClickEvent != null)
                UErrorLogGridDoubleClickEvent(this, cErrorInfo);
        }

        private void DoWork()
        {
            if (this.InvokeRequired)
            {
                UpdateShowErrorCallback cUpdate = new UpdateShowErrorCallback(DoWork);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                try
                {
                    SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
                    {
                        int iHandle = grvError.FocusedRowHandle;

                        object oData = grvError.GetRow(iHandle);
                        CErrorInfo cInfo = (CErrorInfo)oData;

                        ShowErrorAnalysisViewer((CErrorInfo)oData);

                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : {0} [{1}]", e.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); e.Data.Clear();
                }
                finally
                {
                    if (m_Thread != null && m_Thread.ThreadState == ThreadState.Running)
                    {
                        m_Thread.Join();

                        while (m_Thread.IsAlive)
                            m_Thread.Abort();

                        m_Thread = null;
                    }

                    SplashScreenManager.CloseForm(false);
                }
            }
        }

        private void ucErrorCauseAnalysis_HideButtonClickEvent()
        {
            pnlCauseError.Visible = false;
            sptMain.Visible = false;
        }

        #endregion

        #region Event Methods

        private void grvError_DoubleClick(object sender, EventArgs e)
        {
            bool bOK = true;

            int iHandle = grvError.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = grvError.GetRow(iHandle);
            if ((oData.GetType() != typeof(CErrorInfo)))
                return;

            if (m_Thread != null && m_Thread.ThreadState != ThreadState.Stopped)
            {
                m_Thread.Abort();

                m_Thread = null;
            }

            m_Thread = new Thread(new ThreadStart(DoWork));
            m_Thread.Start();
        }

        private void UCErrorLogGrid_Load(object sender, EventArgs e)
        {
            ucErrorCause.UEventHideButtonClick += ucErrorCauseAnalysis_HideButtonClickEvent;
            ucErrorCause.UEventErrorCauseTagDoubleClick += ucErrorCauseGrid_CauseTagDoubleClick;
        }

        private void ucErrorCauseGrid_CauseTagDoubleClick(object sender, CTag cCauseTag, CErrorInfo cInfo)
        {
            if (UErrorCauseTagDoubleClickEvent != null)
                UErrorCauseTagDoubleClickEvent(sender, cCauseTag, cInfo);
        }

        #endregion


    }
}
