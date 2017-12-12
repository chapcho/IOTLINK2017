using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public partial class FrmStdSetting : DevExpress.XtraEditors.XtraForm
    {
        public FrmStdSetting()
        {
            InitializeComponent();
        }

        private bool SaveStdLibrary()
        {
            bool bOK = true;
            try
            {
                if (CProjectManager.StdS.IsEdit)
                    grdStd.ExportToCsv(CProjectManager.StdLibraryPath);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Save StdL", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private void FrmStdSetting_Load(object sender, EventArgs e)
        {
            grdStd.DataSource = CProjectManager.StdS.Values.ToList();
            grdStd.RefreshDataSource();
        }

        private void grvStd_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnLibraryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmStdAddProperty frmAdd = new FrmStdAddProperty();
                frmAdd.TopMost = true;

                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    CProjectManager.StdS.IsEdit = true;

                    grdStd.DataSource = null;
                    grdStd.DataSource = CProjectManager.StdS.Values.ToList();
                    grdStd.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Library Add Std Setting Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CStd cStd = (CStd) grvStd.GetRow(iRowHandle);

                if (cStd == null)
                    return;

                CProjectManager.StdS.Remove(cStd.CurrentName);
                CProjectManager.StdS.IsEdit = true;

                grdStd.DataSource = null;
                grdStd.DataSource = CProjectManager.StdS.Values.ToList();
                grdStd.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("StdSetting Delete Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (CProjectManager.StdS.IsEdit && XtraMessageBox.Show("변경된 라이브러리를 적용하고자 합니다.\r\n진행하시겠습니까?", "표준화 적용",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveStdLibrary();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("StdSetting Apply Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}