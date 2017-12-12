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

namespace UDMTrackerSimple
{
    public partial class FrmAlertViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private string m_sGroupKey = "";
        private CMySqlLogReader m_cReader = null;

        private CErrorInfo m_cErrorInfo = null;

        
        #endregion


        #region Intialize/Dispose

        public FrmAlertViewer(string sGroupKey, CMySqlLogReader cReader)
        {
            InitializeComponent();

            m_sGroupKey = sGroupKey;
            m_cReader = cReader;
        }

        #endregion


        #region Public Properties

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methdos

        private void ShowErrorAnalysisViewer()
        {
            //FrmErrorAnalysisViewer frmViewer = new FrmErrorAnalysisViewer();
            //frmViewer.Project = m_cProject;
            //frmViewer.Reader = m_cReader;
            //frmViewer.Monitor = m_cMonitor;
            //frmViewer.GroupLog = m_cErrorInfo.GroupLog;
            //frmViewer.MonitorErrorInfo = m_cMonitorErrorInfo;
            //frmViewer.ErrorInfo = m_cErrorInfo;

            //frmViewer.Show();
        }


        //private void CreateErrorInfo(string sErrorMessage)
        //{
        //    m_cErrorInfo = new CErrorInfo();
        //    m_cErrorInfo.ErrorID = CProjectManager.Project.ErrorIDCur++;
        //    m_cErrorInfo.ErrorType = m_cMonitorErrorInfo.ErrorType.ToString();
        //    m_cErrorInfo.ErrorMessage = sErrorMessage;
        //    m_cErrorInfo.GroupKey = m_cMonitorErrorInfo.GroupKey;
        //    m_cErrorInfo.Value = m_cMonitorErrorInfo.Value;
        //    m_cErrorInfo.ErrorTime = DateTime.Now;
        //    m_cErrorInfo.SymbolKey = m_cMonitorErrorInfo.Symbol.Key;
        //    m_cErrorInfo.CycleStart = m_cGroupLog.CycleStart;
        //    m_cErrorInfo.CycleEnd = m_cGroupLog.CycleEnd;
        //    m_cErrorInfo.GroupLog = m_cGroupLog;

        //    CProjectManager.Project.ErrorInfoS.Add(m_cErrorInfo);
        //    GenerateErrorInfoLog();

        //    CProjectManager.ErrorLogTable.ShowGrid();
        //    CProjectManager.ErrorGrid.UpdateView(m_cErrorInfo);
        //}

        //private void GenerateErrorInfoLog()
        //{
        //    if (m_cWriter != null && m_cWriter.IsConnected)
        //        m_cWriter.WriteErrorInfo(m_cErrorInfo);
        //}

        //private void GenerateErrorLog()
        //{
        //    List<CStep> lstStep = m_cProject.GetStepList(m_cMonitorErrorInfo.Symbol.Key);
        //    if (lstStep == null || lstStep.Count == 0)
        //        return;

        //    CStep cStep = lstStep[0];
        //    CTimeLogS cLogS = GetInstantTimeLogS(cStep);

        //    m_cErrorInfo.ErrorLogS = cLogS;

        //    if (m_cWriter != null && m_cWriter.IsConnected)
        //        m_cWriter.WriteErrorLogS(m_cErrorInfo.ErrorID, cLogS);
        //}

        //private CTimeLogS GetInstantTimeLogS(CStep cStep)
        //{
        //    CTimeLogS cLogS = null;

        //    this.Cursor = Cursors.WaitCursor;
        //    {
        //        List<CTag> lstTag = GetTagList(cStep);

        //        //foreach (CTag cTag in lstTag)
        //        //{
        //        //    CTagStepRole cRole;
        //        //    for (int i = 0; i < cTag.StepRoleS.Count; i++)
        //        //    {
        //        //        cRole = cTag.StepRoleS[i];
        //        //        if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
        //        //            lstTag.AddRange(GetSubTagList(cTag));
        //        //    }
        //        //}

        //        if (m_cMonitor != null && m_cMonitor.IsRunning && lstTag.Count > 0)
        //            cLogS = m_cMonitor.ReadInstant(lstTag);

        //        lstTag.Clear();

        //        if (cLogS == null)
        //            cLogS = new CTimeLogS();
        //    }
        //    this.Cursor = Cursors.Default;

        //    return cLogS;
        //}

        //private List<CTag> GetTagList(CStep cStep)
        //{
        //    List<CTag> lstTag = new List<CTag>();

        //    CTag cTag;
        //    for (int i = 0; i < cStep.RefTagS.Count; i++)
        //    {
        //        cTag = cStep.RefTagS[i];
        //        if (cTag.DataType == EMDataType.Bool)
        //            lstTag.Add(cTag);
        //    }

        //    return lstTag;
        //}

        //private List<CTag> GetSubTagList(CTag cCoilTag)
        //{
        //    List<CTag> lstTotalTag = new List<CTag>();
        //    List <CStep> lstStep = m_cProject.GetCoilStepList(cCoilTag);

        //    foreach (CStep cStep in lstStep)
        //    {
        //        List<CTag> lstTag = GetTagList(cStep);
        //        lstTotalTag.AddRange(lstTag);

        //        foreach (CTag cTag in lstTag)
        //        {
        //            CTagStepRole cRole;
        //            for (int i = 0; i < cTag.StepRoleS.Count; i++)
        //            {
        //                cRole = cTag.StepRoleS[i];
        //                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
        //                    lstTotalTag.AddRange(GetSubTagList(cTag));
        //            }
        //        }
        //    }

        //    return lstTotalTag;
        //}

        #endregion


        #region Event Methods

        private void FrmAlertViewer_Load(object sender, EventArgs e)
        {
        }

        private void lblGroup_Click(object sender, EventArgs e)
        {
            tmrTimer.Stop();
            
            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //{
            //    //GenerateErrorLog();
            //    //ShowErrorAnalysisViewer(m_cGroupLog, m_cErrorInfo);
            //}
            //SplashScreenManager.CloseForm(false);

            this.Close();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            tmrTimer.Stop();

            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //{
            //    GenerateErrorLog();
            //    //ShowErrorAnalysisViewer(m_cGroupLog, m_cErrorInfo);
            //}
            //SplashScreenManager.CloseForm(false);

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
