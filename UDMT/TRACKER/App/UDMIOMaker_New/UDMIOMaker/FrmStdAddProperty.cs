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
    public partial class FrmStdAddProperty : DevExpress.XtraEditors.XtraForm
    {
        private CStd m_cStd = new CStd();

        public FrmStdAddProperty()
        {
            InitializeComponent();
        }

        public string CurrentName
        {
            set { m_cStd.CurrentName = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CProjectManager.StdS.ContainsKey(m_cStd.CurrentName))
                {
                    XtraMessageBox.Show("기존 이름에 해당하는 심볼 표준 항목은 이미 존재합니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CProjectManager.StdS.Add(m_cStd.CurrentName, m_cStd);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("StdAddProperty OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmStdAddProperty_Load(object sender, EventArgs e)
        {
            exStdProperty.SelectedObject = m_cStd;
            exStdProperty.Refresh();
        }
    }
}