using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;


namespace UDM.UI
{
    public partial class FrmProcess: Form
    {
        public event EventHandler<EventArgs> Canceled;

        public FrmProcess(string Message)
        {
            InitializeComponent();

            this.Text = "Processing";

            if (Message.Contains("_"))
                progressPanel1.Caption = Message.Split('_')[1];
            else 
                progressPanel1.Caption = Message;

            this.Show();
        }

        public void EndProcessing()
        {
            this.Close();
        }

        public void SetProcessing(string strProcessRatio)
        {
            progressPanel1.Description = strProcessRatio + " %";
        }

        public void SetMessage(string sMessage)
        {
            progressPanel1.Caption = sMessage;
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void buttonX_Message_Cancel_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;

            if (ea != null)
                ea(this, e);

        }

        private void FrmMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EventHandler<EventArgs> ea = Canceled;

                if (ea != null)
                    ea(this, e);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



    }
}
