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

namespace UDMLadderTracker
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
            FrmSymbolLogViewer frmViwer = new FrmSymbolLogViewer();
            frmViwer.Reader = m_cReader;
            frmViwer.Show();
        }

        private void btnViewCycleLog_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnViewLogicDiagram_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLogicDiagram frmViewer = new FrmLogicDiagram();
            frmViewer.Show();
        }

		private void btnViewProductFlowChart_ItemClick(object sender, ItemClickEventArgs e)
		{
            //FrmProductFlowChart frmViewer = new FrmProductFlowChart();
            //frmViewer.Reader = m_cReader;
            //frmViewer.Show();
		}

        private void btnViewProcessTimeChart_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnViewStatisticsTable_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnRobotCycleView_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRobotCycleViewer frmViewer = new FrmRobotCycleViewer();
            frmViewer.ShowDialog();
        }

        private void btnUserDeviceView_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUserDeviceViewer frmViewer = new FrmUserDeviceViewer();
            frmViewer.ShowDialog();
        }

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #endregion
    }
}
