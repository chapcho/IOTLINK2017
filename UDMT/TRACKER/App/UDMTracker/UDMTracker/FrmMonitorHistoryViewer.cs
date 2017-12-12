using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTracker
{
    public partial class FrmMonitorHistoryViewer : Form
    {

        #region Member Variables

        private CMonitorLogS _monitorLogS = null;
        private CMySqlLogReader _dbReader = null;

        #endregion

        #region Public Properties

        public FrmMonitorHistoryViewer()
        {
            InitializeComponent();
            
        }

        public CMonitorLogS MonitorLogS
        {
            get { return _monitorLogS; }
            set { _monitorLogS = value; }
        }
        public CMySqlLogReader DBReader
        {
            get { return _dbReader; }
            set { _dbReader = value; }
        }

        #endregion


        public void Clear()
        {
            exGrdMonitorHistory.DataSource = null;
            exGrdMonitorHistory.Refresh();
        }

        public void Showtable()
        {
            Clear();

            if (_monitorLogS != null)
            {
                exGrdMonitorHistory.DataSource = _monitorLogS;
                exGrdMonitorHistory.Refresh();
            }
        }

        #region Private Methods

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CMonitorLogS cLogS = _dbReader.GetMonitorLogS(dtFrom, dtTo);
            if (cLogS != null)
            {
                MonitorLogS = cLogS;

                Showtable();
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// 참조 : http://stackoverflow.com/questions/19133396/how-to-color-selected-rows-in-gridview-in-c-sharp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDetectionHistory_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if ((e.State & DevExpress.XtraGrid.Views.Base.GridRowCellState.Selected) != 0)
            {
                e.HighPriority = true;
                e.Appearance.BackColor = Color.LightCyan;
            }
        }

    }
}
