using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmAddPLC : DevExpress.XtraEditors.XtraForm
    {
        private string m_sText = string.Empty;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        public FrmAddPLC()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get { return m_sText; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
        }

        private void SetPLCList()
        {
            cboPLCMaker.Properties.Items.Clear();

            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Developer);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Works2);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Works3);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Rockwell);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Siemens);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == string.Empty)
            {
                XtraMessageBox.Show("PLC Name is Empty!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboPLCMaker.EditValue == null)
            {
                XtraMessageBox.Show("PLC Maker is Empty!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_sText = txtInput.Text;
            m_emPLCMaker = (EMPLCMaker) cboPLCMaker.EditValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmAddPLC_Load(object sender, EventArgs e)
        {
            SetPLCList();

            txtInput.Focus();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(this, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                btnOK_Click(this, EventArgs.Empty);
        }
    }
}