using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Flow;
using UDM.Project;

namespace UDMTracker
{
    public partial class FrmCycleLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Varialbes

        private bool m_bVerified = false;
        private CProject m_cProject = null;
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Initialize/Dispose

        public FrmCycleLogViewer()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods

		public void ShowChart(CGroupLog cLog)
		{
			cmbGroup.EditValue = exEditorGroup.Items[exEditorGroup.Items.IndexOf(cLog.Key)];
			ShowAnalysisResult(cLog);

			ucGroupLogTable.Clear();
			cLog.TimeLogS = null;
			CGroup cGroup = m_cProject.GroupS[cLog.Key];
			CGroupLogS cLogS = new CGroupLogS();
			cLogS.Add(cLog);

			if (cLogS == null || cLogS.Count == 0)
				return;

			ucGroupLogTable.GroupLogS = cLogS;
			ucGroupLogTable.ShowTable();
		}

        public void Clear()
        {
            ucResultViewer.Clear();
            ucGroupLogTable.Clear();
        }

        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (m_cProject == null)
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
            {
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;

                m_bVerified = false;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
                dtpkTo.EditValue = (DateTime)dtLast;
            }
        }

        private void ShowGroupList()
        {   
            cmbGroup.EditValue = null;
            exEditorGroup.Items.Clear();

            string sGroup;
            for (int i = 0; i < m_cProject.GroupS.Count; i++)
            {
                sGroup = m_cProject.GroupS[i].Key;
                exEditorGroup.Items.Add(sGroup);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private void ShowGroupLogTable(string sGroup, DateTime dtFrom, DateTime dtTo)
        {
            ucGroupLogTable.Clear();

            CGroup cGroup = m_cProject.GroupS[sGroup];
            CGroupLogS cLogS = m_cReader.GetGroupLogS(cGroup.Key, dtFrom, dtTo);

            if (cLogS == null || cLogS.Count == 0)
                return;

            ucGroupLogTable.GroupLogS = cLogS;
            ucGroupLogTable.ShowTable();
        }

        private void ShowAnalysisResult(CGroupLog cGroupLog)
        {
            if (m_cProject.GroupS.ContainsKey(cGroupLog.Key) == false)
                return;

            CGroup cGroup = m_cProject.GroupS[cGroupLog.Key];
            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cGroup, cGroupLog);
            if (cItemS == null || cItemS.Count == 0)
                return;

            CFlowCompareResultS cResultS = m_cProject.MasterPatternS.Compare(cGroup.Key, cGroupLog.Recipe, cItemS, true);
            if (cResultS == null)
            {
                cResultS = new CFlowCompareResultS();
                cResultS.FlowItemS = cItemS;
            }

            cResultS.Key = cGroup.Key;
            if (cResultS.MasterFlow != null)
                cResultS.MasterFlow.Normalize(cGroupLog.CycleStart);

            ucResultViewer.ShowChart(cResultS);
        }

        #endregion


        #region Event Methods

        private void FrmCycleLogViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();
            ShowGroupList();
        }

		private void btnShowCycleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (m_bVerified == false)
				return;

			string sGroup = cmbGroup.EditValue.ToString();
			DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;

			ShowGroupLogTable(sGroup, dtFrom, dtTo);
		}

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            Clear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucResultViewer.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucResultViewer.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucResultViewer.ItemUp();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucResultViewer.ItemDown();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucGroupLogTable_UEventRowDoubleClicked(object sender, UDM.Log.CGroupLog cLog)
        {
            if (m_bVerified == false)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowAnalysisResult(cLog);
            }
            SplashScreenManager.CloseForm(false);
        }

        #endregion
    }
}