using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log.DB;
using UDM.Log;
using UDM.Log.Csv;

namespace UDMTracker
{
    partial class FrmMain
    {

        #region Member Variables

        #endregion


        #region Private Methods
        
        private void ImportLog()
        {
            string[] saPath;
            DialogResult dlgResult;

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Multiselect = true;
            dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.InitialDirectory = ucProjectManager.Project.Path;
            dlgResult = dlgOpenFile.ShowDialog();
            if (dlgResult == DialogResult.Cancel) return;
            saPath = dlgOpenFile.FileNames;

            CCsvLogReader cLogReader = new CCsvLogReader();
            bool bOK = cLogReader.Open(saPath);
            if (bOK)
            {
                m_cTimeLogS = cLogReader.ReadTimeLogS();
                UpdateSystemMessage("Import Log", "Log Import Success!");
            }

            if (!bOK)
                MessageBox.Show("Can't open log files!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion


        #region Event Methods

        private void btnImportLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            ImportLog();
            SplashScreenManager.CloseForm(false);
        }

        private void btnViewSymbolLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSymbolLogViewer frmViwer = new FrmSymbolLogViewer();
            frmViwer.Project = ucProjectManager.Project;
            frmViwer.Reader = m_cReader;
            frmViwer.Show();
        }

        private void btnViewCycleLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCycleLogViewer frmViwer = new FrmCycleLogViewer();
            frmViwer.Project = ucProjectManager.Project;
            frmViwer.Reader = m_cReader;
            frmViwer.Show();
        }

        private void btnViewLogicDiagram_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLogicDiagram frmViewer = new FrmLogicDiagram();
            frmViewer.Project = ucProjectManager.Project;
            frmViewer.LogReader = m_cReader;
            frmViewer.Show();
        }

		private void btnViewProductFlowChart_ItemClick(object sender, ItemClickEventArgs e)
		{
			FrmProductFlowChart frmViewer = new FrmProductFlowChart();
			frmViewer.Project = ucProjectManager.Project;
			frmViewer.Reader = m_cReader;
			frmViewer.Show();
		}

        private void btnViewProcessTimeChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmProcessTimeChart frmViewer = new FrmProcessTimeChart();
            frmViewer.Project = ucProjectManager.Project;
            frmViewer.Reader = m_cReader;
            frmViewer.Show();
        }

        private void btnViewStatisticsTable_ItemClick(object sender, ItemClickEventArgs e)
        {
			FrmStatisticsViewer frmViewer = new FrmStatisticsViewer();
			frmViewer.Project = ucProjectManager.Project;
			frmViewer.Reader = m_cReader;
			frmViewer.Show();
        }

        #endregion
    }
}
