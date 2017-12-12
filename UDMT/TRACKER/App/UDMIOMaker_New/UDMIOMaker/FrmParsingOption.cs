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
    public partial class FrmParsingOption : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bUnderbar = false;
        private bool m_bBar = false;
        private bool m_bSpace = false;

        public FrmParsingOption()
        {
            InitializeComponent();
        }

        public bool UnderBarOption
        {
            get { return m_bUnderbar; }
            set { m_bUnderbar = value; }
        }

        public bool BarOption
        {
            get { return m_bBar; }
            set { m_bBar = value; }
        }

        public bool SpaceOption
        {
            get { return m_bSpace; }
            set { m_bSpace = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkUnderbar.Checked && !chkBar.Checked && !chkSpace.Checked)
                {
                    XtraMessageBox.Show("파싱 옵션을 적어도 하나는 선택하셔야 합니다.\r\n 다시 선택해 주세요.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (chkUnderbar.Checked)
                    m_bUnderbar = true;
                if (chkBar.Checked)
                    m_bBar = true;
                if (chkSpace.Checked)
                    m_bSpace = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Pasing Option OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
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
