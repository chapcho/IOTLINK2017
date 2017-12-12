using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;
using UDM.Monitor.Plc;

namespace UDMTracker
{
    public partial class FrmAlertViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private string m_sGroupKey = "";
        private CProject m_cProject = null;
        private CMySqlLogReader m_cReader = null;
        private CGroupLog m_cGroupLog = null;
        private CMonitorErrorInfo m_cErrorInfo = null;
        private CMonitor m_cMonitor = null;
        

        private delegate void UpdateErrorInfoCallback(CMonitorErrorInfo cInfo);
        
        #endregion


        #region Intialize/Dispose

        public FrmAlertViewer(string sGroupKey, CProject cProject, CMySqlLogReader cReader, CGroupLog cGroupLog, CMonitorErrorInfo cErrorInfo, CMonitor cMonitor)
        {
            InitializeComponent();

            m_sGroupKey = sGroupKey;
            m_cProject = cProject;
            m_cReader = cReader;
            m_cGroupLog = cGroupLog;
            m_cErrorInfo = cErrorInfo;
            m_cMonitor = cMonitor;
        }

        #endregion


        #region Public Properties

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        public CGroupLog GroupLog
        {
            get { return m_cGroupLog; }
            set { m_cGroupLog = value; }
        }

        public CMonitorErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; ShowErrorInfo(value); }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methdos

        private void ShowErrorInfo(CMonitorErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorInfoCallback cbUpdateError = new UpdateErrorInfoCallback(ShowErrorInfo);
                this.Invoke(cbUpdateError, new object[] { cErrorInfo });
            }
            else
            {
                if (cErrorInfo == null)
                {
                    lblGroup.Text = "";
                    lblMessage.Text = "";
                    return;
                }

                lblGroup.Text = cErrorInfo.GroupKey;

                string sMessage = "";
                if (cErrorInfo.ErrorType == EMMonitorGroupErrorType.CycleTime)
                {
                    sMessage = "[CycleTime] " + cErrorInfo.Symbol.Description;
                }
                else if (cErrorInfo.ErrorType == EMMonitorGroupErrorType.Trend)
                {
                    sMessage = "[Trend] " + cErrorInfo.Symbol.Description;
                }
                else if (cErrorInfo.ErrorType == EMMonitorGroupErrorType.Abnormal)
                {
                    sMessage = "[Abnormal] " + cErrorInfo.Symbol.Description;
                }
                else
                {
                    sMessage = "[None]" + cErrorInfo.Symbol.Description;
                }

                lblMessage.Text = sMessage;

                tmrTimer.Start();
            }
        }

        private void ShowErrorAnalysisViewer(CGroupLog cLog, CMonitorErrorInfo cInfo)
        {
            FrmErrorAnalysisViewer frmViewer = new FrmErrorAnalysisViewer();
            frmViewer.Project = m_cProject;
            frmViewer.Reader = m_cReader;
            frmViewer.Monitor = m_cMonitor;
            frmViewer.GroupLog = cLog;
            frmViewer.ErrorInfo = cInfo;
            
            frmViewer.Show();
        }

        #endregion


        #region Event Methods

        private void FrmAlertViewer_Load(object sender, EventArgs e)
        {
            ShowErrorInfo(m_cErrorInfo);

            
        }

        private void lblGroup_Click(object sender, EventArgs e)
        {
            tmrTimer.Stop();
            
             SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowErrorAnalysisViewer(m_cGroupLog, m_cErrorInfo);
            }
            SplashScreenManager.CloseForm(false);

            this.Close();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            tmrTimer.Stop();

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowErrorAnalysisViewer(m_cGroupLog, m_cErrorInfo);
            }
            SplashScreenManager.CloseForm(false);

            this.Close();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            Color cColor1 = pnlBackGround.Appearance.BackColor;
            Color cColor2 = pnlBackGround.Appearance.BackColor2;

            pnlBackGround.Appearance.BackColor = cColor2;
            pnlBackGround.Appearance.BackColor2 = cColor1;

            pnlBackGround.Refresh();
        }

        #endregion

        
    }
}
