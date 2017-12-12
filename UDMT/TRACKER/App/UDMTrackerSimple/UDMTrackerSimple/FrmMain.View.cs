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
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    partial class FrmMain
    {

        #region Member Variables

        #endregion


        #region Private Methods
        
        #endregion


        #region Event Methods

        private void btnViewSymbolLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmSymbolLogViewer frmViwer = new FrmSymbolLogViewer();
                frmViwer.Reader = m_cReader;
                frmViwer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnViewCycleLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmCycleLogViewer frmViwer = new FrmCycleLogViewer();
                frmViwer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnViewLogicDiagram_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmLogicDiagram frmViewer = new FrmLogicDiagram();
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

		private void btnViewProductFlowChart_ItemClick(object sender, ItemClickEventArgs e)
		{
            //FrmProductFlowChart frmViewer = new FrmProductFlowChart();
            //frmViewer.Reader = m_cReader;
            //frmViewer.Show();
		}

        private void btnViewProcessTimeChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmProcessTimeChart frmViewer = new FrmProcessTimeChart();
                frmViewer.Reader = m_cReader;
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnViewStatisticsTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmStatisticsViewer frmViewer = new FrmStatisticsViewer();
                frmViewer.Reader = m_cReader;
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnRobotCycleView_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmRobotCycleViewer frmViewer = new FrmRobotCycleViewer();
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnUserDeviceView_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmUserDeviceViewer2 frmViewer = new FrmUserDeviceViewer2();
                frmViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnViewNewCycleLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmNewCycleLogViewer frmViewer = new FrmNewCycleLogViewer();
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.View",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnMoveTopScreen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (tabView.DocumentGroups.Count == 1)
                    return;

                 Document doc = tabView.ActiveDocument as Document;

                tabView.BeginUpdate();
                {
                    if (doc != null)
                        tabView.Controller.Dock(doc, tabView.DocumentGroups.First());
                }
                tabView.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMoveBottomScreen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Document doc = tabView.ActiveDocument as Document;

                if (doc == null)
                    return;

                tabView.BeginUpdate();
                {
                    if (tabView.DocumentGroups.Count == 1)
                        tabView.Controller.CreateNewDocumentGroup(doc);
                    else if (tabView.DocumentGroups.Count == 2)
                        tabView.Controller.Dock(doc, tabView.DocumentGroups.Last());
                }
                tabView.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SaveMainLayout();

                XtraMessageBox.Show("Layout Save Success!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                XtraMessageBox.Show("Layout Save Fail!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLayoutLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                LoadMainLayout();

                XtraMessageBox.Show("Layout Load Success!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                XtraMessageBox.Show("Layout Load Fail!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLayoutReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("Do you want to proceed with Layout Reset?", "Question", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                tabView.DocumentGroupProperties.ShowTabHeader = true;

                Document doc = null;
                foreach (BaseDocument basedoc in tabView.Documents)
                {
                    doc = basedoc as Document;

                    if(doc != null)
                        tabView.Controller.Dock(doc, tabView.DocumentGroups.First());
                }

                XtraMessageBox.Show("Layout Reset Success!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                XtraMessageBox.Show("Layout Reset Fail!!!", "Layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}
