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
    public partial class FrmReplace : DevExpress.XtraEditors.XtraForm
    {
        private string m_sBefore = string.Empty;
        private string m_sAfter = string.Empty;


        public FrmReplace()
        {
            InitializeComponent();
        }

        public string BeforeText
        {
            get { return m_sBefore; }
            set { m_sBefore = value; }
        }

        public string AfterText
        {
            get { return m_sAfter;}
            set { m_sAfter = value; }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAfter.Text == string.Empty || txtAfter.Text == string.Empty)
                {
                    XtraMessageBox.Show("변경하고자 하는 요소에 대한 내용이 비어있습니다.\r\n 입력 후 바꾸기 작업을 진행해주세요.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_sBefore = txtBefore.Text;
                m_sAfter = txtAfter.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Replace  Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}