using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;

namespace UDMLadderTracker
{
    public delegate void UEventHandlerHideButtonClicked();
    public delegate void UEventHandlerErrorCauseTagDoubleClicked(object sender, CTag cCauseTag, CErrorInfo cInfo);
    public delegate void UEventHandlerErrorLogGridDoubleClick(object sender, CErrorInfo cErrorInfo);

    public partial class UCErrorCauseAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        public event UEventHandlerHideButtonClicked UEventHideButtonClick = null;
        public event UEventHandlerErrorCauseTagDoubleClicked UEventErrorCauseTagDoubleClick = null;

        private CTagS m_cCauseTagS = null;
        private CErrorInfo m_cErrorInfo = null;

        private Thread m_Thread = null;

        private delegate void UpdateDoworkCallback();
        private delegate void UpdateCauseTagSCallback(CTagS cTagS, CErrorInfo cInfo);

        public UCErrorCauseAnalysis()
        {
            InitializeComponent();
        }

        public CTagS CauseTagS
        {
            get { return m_cCauseTagS; }
            set { m_cCauseTagS = value; }
        }

        public CErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; }
        }

        public void ShowCauseTagS(CTagS cCauseTagS, CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateCauseTagSCallback cUpdate = new UpdateCauseTagSCallback(ShowCauseTagS);
                this.Invoke(cUpdate, new object[] {cCauseTagS, cInfo});
            }
            else
            {
                grdCauseTag.DataSource = null; 

                m_cCauseTagS = cCauseTagS;
                m_cErrorInfo = cInfo;

                if (m_cCauseTagS == null || m_cCauseTagS.Count == 0)
                    return;

                grdCauseTag.DataSource = m_cCauseTagS.Values.ToList();
                grdCauseTag.RefreshDataSource();
            }
        }

        public void ClearGrid()
        {
            grdCauseTag.DataSource = null;
            grdCauseTag.RefreshDataSource();
        }

        private void DoWork()
        {
            if (this.InvokeRequired)
            {
                UpdateDoworkCallback cUpdate = new UpdateDoworkCallback(DoWork);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                try
                {
                    bool bOK = true;

                    int iHandle = grvCauseTag.FocusedRowHandle;
                    if (iHandle < 0)
                        return;

                    object oData = grvCauseTag.GetRow(iHandle);

                    if (UEventErrorCauseTagDoubleClick != null)
                        UEventErrorCauseTagDoubleClick(this, (CTag)oData, m_cErrorInfo);
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
                }
                Application.DoEvents();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (UEventHideButtonClick != null)
                UEventHideButtonClick();
        }

        private void grvCauseTag_DoubleClick(object sender, EventArgs e)
        {
            bool bOK = true;

            int iHandle = grvCauseTag.FocusedRowHandle;
            if (iHandle < 0)
                return;

            if (m_Thread != null && m_Thread.ThreadState != ThreadState.Stopped)
            {
                m_Thread.Abort();

                m_Thread = null;
            }

            m_Thread = new Thread(new ThreadStart(DoWork));
            m_Thread.Start();
        }
    }
}
