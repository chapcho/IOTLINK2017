using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class FrmLogTable : DevExpress.XtraEditors.XtraForm
    {
        private CTimeLogS m_cLogS = null;

        public FrmLogTable()
        {
            InitializeComponent();
        }

        public CTimeLogS LogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }

        private void FrmLogTable_Load(object sender, EventArgs e)
        {
            if (m_cLogS == null)
                return;

            grdLog.DataSource = m_cLogS;
            grdLog.RefreshDataSource();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cLogS == null)
                    return;

                DateTime dtFrom = (DateTime) dtpkFrom.EditValue;
                DateTime dtTo = (DateTime) dtpkTo.EditValue;

                if (dtFrom > dtTo)
                {
                    XtraMessageBox.Show("Range Fail!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                grdLog.DataSource = m_cLogS.Where(x => x.Time >= dtFrom && x.Time <= dtTo).ToList();
                grdLog.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (m_cLogS == null)
                return;

            grdLog.DataSource = m_cLogS;
            grdLog.RefreshDataSource();
        }

        private void grvLog_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }


    }
}