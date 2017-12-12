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

namespace UDMTrackerSimple.UserControls
{
    public partial class UCErrorLogGrid : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = new CErrorInfoS();

        Thread m_Thread = null;
        private int m_iSplitPos = 0;

        private delegate void UpdateErrorInfoSCallback(CErrorInfoS cErrorInfoS);
        private delegate void UpdateErrorInfoCallback(CErrorInfo cErrorInfo);
        private delegate void UpdateShowErrorCallback();
        private delegate void UpdateFilterCallback(bool bAbnormal, bool bUnknown);

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

        public bool IsAllowCellMerge
        {
            get { return grvError.OptionsView.AllowCellMerge; }
            set { grvError.OptionsView.AllowCellMerge = value; }
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

                //if (pnlRawData.Visible)
                //{
                //    pnlRawData.Visible = false;
                //    sptMain.Visible = false;
                //}

                this.grdError.DataSource = null;
                //this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();
                this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true || x.ErrorType.Contains("CycleOver")).ToList(); // 무언정지 포함

                this.grdError.RefreshDataSource();
            }
        }

        public void SetFilterView(bool bAbnormal, bool bUnknown)
        {
            if (this.InvokeRequired)
            {
                UpdateFilterCallback cUpdate = new UpdateFilterCallback(SetFilterView);
                this.Invoke(cUpdate, new object[] {bAbnormal, bUnknown});
            }
            else
            {
                if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                    return;

                grdError.DataSource = null;

                if (bAbnormal && !bUnknown)
                    grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();
                else if (!bAbnormal && bUnknown)
                    grdError.DataSource = m_cErrorInfoS.Where(x => x.ErrorMessage.Contains("Cycle Over")).ToList();
                else if (!bAbnormal && !bUnknown)
                    grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true || x.ErrorMessage.Contains("Cycle Over")).ToList();

                grdError.RefreshDataSource();
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

                //if (pnlRawData.Visible)
                //{
                //    pnlRawData.Visible = false;
                //    sptMain.Visible = false;
                //}

                this.grdError.DataSource = null;
                //this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();
                this.grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true || x.ErrorType.Contains("CycleOver")).OrderBy(x => x.ErrorTime).ToList(); // 무언정지 포함

                this.grdError.RefreshDataSource();
            }
        }

        public void ClearGrid()
        {
            if (m_cErrorInfoS == null)
                return;

            m_cErrorInfoS.Clear();
            grdError.DataSource = null;
            grdError.RefreshDataSource();
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

        public void ExportExcelRawData()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateShowErrorCallback cUpdate = new UpdateShowErrorCallback(ExportExcelRawData);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                        return;

                    DialogResult dlgResult = XtraMessageBox.Show("해당 " + m_cErrorInfoS.Count + "개의 Error 정보를 Export하시겠습니까?",
                        "Error Report Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlgResult == DialogResult.No)
                        return;

                    grdRawData.DataSource = m_cErrorInfoS;
                    grdRawData.RefreshDataSource();

                    SaveFileDialog dlgSave = new SaveFileDialog();
                    dlgSave.Filter = "*.xlsx|*.xlsx";
                    dlgResult = dlgSave.ShowDialog();

                    if (dlgResult == DialogResult.OK)
                    {
                        SplashScreenManager.ShowDefaultWaitForm();
                        {
                            SetErrorRecoveryTime();
                            grdRawData.ExportToXlsx(dlgSave.FileName);
                        }
                        SplashScreenManager.CloseDefaultWaitForm();
                    }

                    dlgSave.Dispose();
                    dlgSave = null;

                    grdRawData.DataSource = null;
                    grdRawData.RefreshDataSource();

                    XtraMessageBox.Show("Export Error Raw Data Success!!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void SetErrorRecoveryTime()
        {
            try
            {
                CPlcProc cProcess = null;
                CTimeLogS cLogS = null;
                CCycleInfoS cCycleInfoS = null;
                CTimeLog cLog = null;

                if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                    return;

                foreach (var who in m_cErrorInfoS)
                {
                    if (!CMultiProject.PlcProcS.ContainsKey(who.GroupKey))
                        continue;

                    if (who.RecoveryTime != -1)
                        continue;

                    cProcess = CMultiProject.PlcProcS[who.GroupKey];

                    if (cProcess.CycleCheckTag != null)
                    {
                        //if (cProcess.IsErrorMonitoring)
                        //{
                        cLogS = CMultiProject.LogReader.GetTimeLogS(cProcess.CycleCheckTag.Key, who.ErrorTime);

                        if (cLogS != null && cLogS.Count > 0)
                        {
                            cLog = cLogS.First();
                            who.RecoveryTime = Math.Abs(Math.Round(cLog.Time.Subtract(who.ErrorTime).TotalSeconds, 2));
                        }
                    }
                    //}
                    //else
                    //{
                    //    cCycleInfoS = CMultiProject.LogReader.GetCycleInfoS(CMultiProject.ProjectID, who.GroupKey, who.CycleID + 1);

                    //    if(cCycleInfoS != null && cCycleInfoS.Count > 0 )
                    //        who.RecoveryTime = Math.Abs(Math.Round(cCycleInfoS.First().Value.CycleStart.Subtract(who.ErrorTime).TotalSeconds, 2));
                    //}

                    if(cLogS != null)
                        cLogS.Clear();

                    if (cCycleInfoS != null)
                        cCycleInfoS.Clear();

                    cCycleInfoS = null;
                    cLogS = null;
                    cLog = null;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


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
            //pnlRawData.Visible = false;
            //sptMain.Visible = false;
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

        }

        private void ucErrorCauseGrid_CauseTagDoubleClick(object sender, CTag cCauseTag, CErrorInfo cInfo)
        {
            if (UErrorCauseTagDoubleClickEvent != null)
                UErrorCauseTagDoubleClickEvent(sender, cCauseTag, cInfo);
        }

        #endregion



    }
}
