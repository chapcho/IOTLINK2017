using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public partial class FrmInputDialog : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private string m_sText = string.Empty;
        private int m_iModuleNumber = -1;

        #endregion


        #region Initialize/Dispose

        public FrmInputDialog(string sTitle, string sMessage)
        {
            InitializeComponent();

			lblTitle.Text = sTitle;
			lblMessage.Text = sMessage;
        }

        #endregion


        #region Public Properties

        public string InputText
        {
            get { return m_sText; }
        }

        public int ModuleNumber
        {
            get { return m_iModuleNumber;}
            set { spnModule.Value = value; }
        }

        public bool IsModuleVisible
        {
            set { SetModule(value); }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Mehtods

        private void SetModule(bool bOK)
        {
            if (bOK)
            {
                lblModule.Visible = true;
                spnModule.Visible = true;
            }
            else
            {
                lblModule.Visible = false;
                spnModule.Visible = false;
            }
        }

        #endregion


        #region Event Methods

        private void FrmInputDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_sText = txtInput.Text;

            if (CProjectManager.LogicDataS.ContainsKey(m_sText))
            {
                XtraMessageBox.Show("PLC Name Redundancy!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_iModuleNumber = (int) spnModule.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(this, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                btnOK_Click(this, EventArgs.Empty);
        }

        #endregion
    }
}