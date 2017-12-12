using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model.History;
using DevExpress.XtraScheduler;
using UDM.Log;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;

namespace UDMLadderTracker
{
    public partial class UCErrorLogTable : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = new CErrorInfoS();
        private CErrorInfo m_cErrorInfoCur = null;

        private delegate void UpdateSchedulerCallback();
        private delegate void UpdateSchedulerCallback2(DateTime dtEnd);

        #region Initialize/Dispose

        public UCErrorLogTable()
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
        
        public void ShowGrid()
        {
            if (this.InvokeRequired)
            {
                UpdateSchedulerCallback cUpdate = new UpdateSchedulerCallback(ShowGrid);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                dateEditMax.EditValue = DateTime.Now;

                if (m_cErrorInfoS == null)
                    return;

                if (m_cErrorInfoS.Count == 0)
                    ucErrorReport.ShowErrorReport();

                UpdateRange();
            }
        }

        public void Clear()
        {
            if (m_cErrorInfoS == null)
                return;
            grdError.DataSource = null;
            grdError.RefreshDataSource();

            ucErrorReport.Clear();
        }

        public void UpdateRange(DateTime dtEnd)
        {
            if (this.InvokeRequired)
            {
                UpdateSchedulerCallback2 cUpdate = new UpdateSchedulerCallback2(UpdateRange);
                this.Invoke(cUpdate, new object[] {dtEnd});
            }
            else
            {
                dateEditMax.EditValue = dtEnd;

                DateTime dtTo = DateTime.MinValue;

                if (radioDaily.Checked)
                    dtTo = dtEnd.AddDays(-1);
                else if (radioWeekly.Checked)
                    dtTo = dtEnd.AddDays(-7);
                else if (radioMonthly.Checked)
                    dtTo = dtEnd.AddMonths(-1);

                dateEditMin.EditValue = dtTo;

                if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                    return;

                this.grdError.DataSource = null;
                this.grdError.DataSource =
                    m_cErrorInfoS.GetErrorInfoS(dtTo, dtEnd).Where(x => x.IsVisible == true).ToList();
                this.grdError.RefreshDataSource();
                this.grvError.ExpandAllGroups();

                CErrorInfoS cErrorInfoS = new CErrorInfoS();
                cErrorInfoS.AddRange(
                    m_cErrorInfoS.GetErrorInfoS(dtTo, dtEnd)
                        .Where(x => x.DetailErrorMessage == string.Empty)
                        .ToList());

                ucErrorReport.ErrorInfoS = cErrorInfoS;
                ucErrorReport.ShowErrorReport();
            }
        }

        public void ExportExcelFromGridView(string sPath)
        {
            grdError.ExportToXlsx(sPath); 
        }

        public void ShowPrintPreview()
        {
            grdError.ShowPrintPreview();
        }

        #endregion

        #region Private Methods

        private void UpdateRange()
        {
            if (this.InvokeRequired)
            {
                UpdateSchedulerCallback updateRange = new UpdateSchedulerCallback(UpdateRange);
                this.Invoke(updateRange, new object[] { });
            }
            else
            {
                if (m_cErrorInfoS == null || m_cErrorInfoS.Count == 0)
                    return;

                DateTime dtStart = Convert.ToDateTime(dateEditMin.EditValue);
                DateTime dtEnd = Convert.ToDateTime(dateEditMax.EditValue);
                
                this.grdError.DataSource = null;
                this.grdError.DataSource =
                    m_cErrorInfoS.GetErrorInfoS(dtStart, dtEnd).Where(x => x.IsVisible == true).ToList();
                this.grdError.RefreshDataSource();
                this.grvError.ExpandAllGroups();

                CErrorInfoS cErrorInfoS = new CErrorInfoS();
                cErrorInfoS.AddRange(
                    m_cErrorInfoS.GetErrorInfoS(dtStart, dtEnd)
                        .Where(x => x.DetailErrorMessage == string.Empty)
                        .ToList());

                ucErrorReport.ErrorInfoS = cErrorInfoS;

                ucErrorReport.ShowErrorReport();

                cErrorInfoS.Clear();
                cErrorInfoS = null;
            }
        }

        #endregion

        private void dateEditMin_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime dtMin = (DateTime) dateEditMin.EditValue;
            //DateTime dtMax = DateTime.MinValue;

            //if (radioDaily.Checked)
            //    dtMax = dtMin.AddDays(1);
            //else if (radioWeekly.Checked)
            //    dtMax = dtMin.AddDays(7);
            //else if (radioMonthly.Checked)
            //    dtMax = dtMin.AddMonths(1);

            //dateEditMax.EditValue = dtMax;
        }

        private void dateEditMax_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dtMax = (DateTime) dateEditMax.EditValue;
            DateTime dtMin = DateTime.MinValue;

            if (radioDaily.Checked)
                dtMin = dtMax.AddDays(-1);
            else if (radioWeekly.Checked)
                dtMin = dtMax.AddDays(-7);
            else if (radioMonthly.Checked)
                dtMin = dtMax.AddMonths(-1);

            dateEditMin.EditValue = dtMin;
        }

        private void btnDateNow_Click(object sender, EventArgs e)
        {
            UpdateRange(DateTime.Now);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "*.xlsx|*.xlsx";
            DialogResult dlgResult = dlgSave.ShowDialog();
            if (dlgResult == DialogResult.OK)
                ExportExcelFromGridView(dlgSave.FileName);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (m_cErrorInfoS.Count == 0)
                m_cErrorInfoS.AddRange(CMultiProject.LogReader.GetErrorInfoS(CMultiProject.ProjectID));

            UpdateRange();
        }

        private void grvError_DoubleClick(object sender, EventArgs e)
        {
            bool bOK = true;

            int iHandle = grvError.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = grvError.GetRow(iHandle);
            if ((oData.GetType() == typeof(CErrorInfo)))
                bOK = GenerateMonitorErrorInfo((CErrorInfo)oData);

            if (!bOK)
                return;

            SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
            {
                ShowErrorAnalysisViewer((CErrorInfo)oData);
            }
            SplashScreenManager.CloseForm(false);

        }


        private bool GenerateMonitorErrorInfo(CErrorInfo cErrorInfo)
        {
            bool bOK = true;

            m_cErrorInfoCur = cErrorInfo;
            SetErrorInfoErrorLog(cErrorInfo);

            return bOK;
        }

        private void SetErrorInfoErrorLog(CErrorInfo cErrorInfo)
        {
            if (cErrorInfo.ErrorLogS != null)
                return;

            CTimeLogS cErrorLogS = CMultiProject.LogReader.GetErrorLogS(cErrorInfo.ErrorID);

            if (cErrorLogS != null && cErrorLogS.Count != 0)
                cErrorInfo.ErrorLogS = cErrorLogS;
            else
                Console.WriteLine("해당 Error Information에 대한 ErrorLog가 존재하지 않습니다.");
        }

        private void ShowErrorAnalysisViewer(CErrorInfo cErrorInfo)
        {
            if (cErrorInfo.ErrorType == "CycleOver")
            {
                CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                CPlcProc cProcess = CMultiProject.PlcProcS[cErrorInfo.GroupKey];

                FrmErrorAnalysisViewer frmViewer = new FrmErrorAnalysisViewer();
                frmViewer.ErrorInfo = cErrorInfo;
                frmViewer.Tag = cTag;
                frmViewer.PlcLogicData = CMultiProject.GetPlcLogicData(cTag);
                frmViewer.Process = cProcess;
                frmViewer.TopMost = true;
                frmViewer.ShowDialog();
            }
            if (cErrorInfo.ErrorType == "Interlock")
            {
                CTag cInterlockTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                CPlcLogicData cData = CMultiProject.GetPlcLogicData(cInterlockTag);

                FrmErrorDiagramViewer frmViewer = new FrmErrorDiagramViewer();
                frmViewer.ErrorInfo = cErrorInfo;
                frmViewer.InterlockTag = cInterlockTag;
                frmViewer.PlcLogicData = cData;
                frmViewer.TopMost = true;
                frmViewer.ShowDialog();
            }
        }

        private void radioDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDaily.Checked)
            {
                radioMonthly.Checked = false;
                radioWeekly.Checked = false;

                DateTime dtTo = (DateTime) dateEditMax.EditValue;
                dateEditMin.EditValue = dtTo.AddDays(-1);
            }
        }

        private void radioWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWeekly.Checked)
            {
                radioDaily.Checked = false;
                radioMonthly.Checked = false;

                DateTime dtTo = (DateTime)dateEditMax.EditValue;
                dateEditMin.EditValue = dtTo.AddDays(-7);
            }

        }

        private void radioMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonthly.Checked)
            {
                radioDaily.Checked = false;
                radioWeekly.Checked = false;

                DateTime dtTo = (DateTime)dateEditMax.EditValue;

                DateTime dtTime = new DateTime(dtTo.Year, dtTo.Month, 1);

                dateEditMin.EditValue = dtTime;
            }
        }

        private void UCErrorLogTable_Load(object sender, EventArgs e)
        {
            dateEditMax.EditValue = DateTime.Now;
        }

        #region Event Methods

        #endregion
    }
}
