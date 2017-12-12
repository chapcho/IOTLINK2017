using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;

namespace UDM.UI.MessageDialog
{
    public enum eMessageDialogLevel
    {
        QUESTION,
        WARNING,
        ERROR,
        INFO,
        KEYIN,
        SELECTOR,
    };

    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        private string m_sHeader = string.Empty;
        private string m_sTitle = string.Empty;
        private string m_sSelectedText = string.Empty;
        private int m_nSelectedIndex = -1;


        public FrmMessage(string MessageDialog, eMessageDialogLevel MessageDialogLevel/*= Constructor for "MessageDialogID"*/)
        {
            InitializeComponent();
            InitializeUI(MessageDialogLevel);

            this.Text = MessageDialogLevel.ToString();
            contentLabel.Text = MessageDialog;

            this.ShowDialog();
        }

        public FrmMessage(string MessageDialog, string DefaultKeyInText/*= Constructor for "KeyIn"*/)
        {
            InitializeComponent();
            InitializeUI(eMessageDialogLevel.KEYIN);

            this.Text = eMessageDialogLevel.KEYIN.ToString();
            contentLabel.Text = MessageDialog;
            txtInput.Text = DefaultKeyInText;

            this.ShowDialog();
        }

        public FrmMessage(List<string> MessageDialog, eMessageDialogLevel MessageDialogLevel /*= Constructor for "Selector"*/)
        {
            if (MessageDialog.Count == 0)
                throw new Exception();

            InitializeComponent();
            InitializeUI(MessageDialogLevel);

            this.Text = MessageDialogLevel.ToString();

            foreach (String strValue in MessageDialog)
            {
                listBox_Select.Items.Add(strValue);
            }

            if (listBox_Select.Items.Count > 0)
                listBox_Select.SelectedIndex = 0;

            this.ShowDialog();
        }


        #region Public Properties

        public string Header
        {
            get { return m_sHeader; }

            set { m_sHeader = value; this.Text = m_sHeader; }
        }

        public string Title
        {
            get { return m_sTitle; }

            set { m_sTitle = value; contentLabel.Text = m_sTitle; }
        }

        public string InputText
        {
            get { return txtInput.Text; }

        }

        public string SelectedText
        {
            get { return m_sSelectedText; }

        }

        public int SelectedIndex
        {
            get { return m_nSelectedIndex; }

        }

        #endregion

        private void InitializeUI(eMessageDialogLevel MessageDialogLevel)
        {

            listBox_Select.Visible = false;
            txtInput.Visible = false;

            if (MessageDialogLevel == eMessageDialogLevel.INFO)
            {
                pictureInfo.Visible = true;
                buttonOK.Visible = true;
                this.ActiveControl = buttonOK;
            }

            if (MessageDialogLevel == eMessageDialogLevel.WARNING)
            {
                pictureWarning.Visible = true;
                buttonOK.Visible = true;
                this.ActiveControl = buttonOK;
            }

            if (MessageDialogLevel == eMessageDialogLevel.ERROR)
            {
                pictureError.Visible = true;
                buttonOK.Visible = true;
                this.ActiveControl = buttonOK;
            }

            if (MessageDialogLevel == eMessageDialogLevel.QUESTION)
            {
                pictureQuestion.Visible = true;
                buttonOK.Visible = true;
                buttonCancel.Visible = true;
                this.ActiveControl = buttonOK;
            }

            if (MessageDialogLevel == eMessageDialogLevel.KEYIN)
            {
                pictureInput.Visible = true;
                buttonOK.Visible = true;
                buttonCancel.Visible = true;
                txtInput.Visible = true;
                txtInput.Focus();
                this.ActiveControl = txtInput;
            }

            if (MessageDialogLevel == eMessageDialogLevel.SELECTOR)
            {
                buttonOK.Visible = false;
                buttonCancel.Visible = false;
                contentLabel.Visible = false;

                pictureSelector.Visible = true;
                listBox_Select.Visible = true;

                this.ActiveControl = listBox_Select;
            }
        }

        

        private void FrmMessageDialog_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void FrmMessageDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
                buttonOK.PerformClick();

            if (this.Text == eMessageDialogLevel.SELECTOR.ToString() && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter))
            {
                if (listBox_Select.SelectedItems.Count == 0)
                    listBox_Select.SelectedIndex = 0;

                m_nSelectedIndex = listBox_Select.SelectedIndex;
                m_sSelectedText = listBox_Select.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void listBox_Select_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            m_nSelectedIndex = listBox_Select.SelectedIndex;
            m_sSelectedText = listBox_Select.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonOK_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text == eMessageDialogLevel.KEYIN.ToString())
            {
                if (InputText == string.Empty)
                {
                    FrmMessage frmMessageDialog = new FrmMessage("Please key In Message", eMessageDialogLevel.WARNING);
                    return;
                }
            }

            if (this.Text == eMessageDialogLevel.SELECTOR.ToString())
            {
                if (listBox_Select.SelectedItems.Count == 0)
                    listBox_Select.SelectedIndex = 0;

                m_nSelectedIndex = listBox_Select.SelectedIndex;
                m_sSelectedText = listBox_Select.SelectedItem.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_CheckedChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
      
    }
}
