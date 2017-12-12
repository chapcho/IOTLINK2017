using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class FrmUpdateResult : DevExpress.XtraEditors.XtraForm
    {
        private List<CPLCUpdateView> m_lstView = null;

        public FrmUpdateResult()
        {
            InitializeComponent();
        }

        public List<CPLCUpdateView> lstView
        {
            get { return m_lstView; }
            set { m_lstView = value; }
        }

        private void exGridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmUpdateResult_Load(object sender, EventArgs e)
        {
            if (m_lstView == null)
                return;

            exGridMain.DataSource = m_lstView;
            exGridMain.RefreshDataSource();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmUpdateResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                if (
                    XtraMessageBox.Show("PLC 프로그램에 대한 업데이트를 진행하지 않으시겠습니까?", "PLC Update", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}