using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMPresenter
{
    public partial class FrmAddChannel : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddChannel()
        {
            InitializeComponent();
        }

        public string Channel
        {
            get { return txtInput.Text; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "") return;
            this.Close();
            //m_cProject = new CProject();
            
            //if (cmbConnectionType.SelectedIndex == 0) m_cProject.CollectorType = UDM.Monitor.Plc.Source.EMSourceType.DDEA;
            //else m_cProject.CollectorType = UDM.Monitor.Plc.Source.EMSourceType.OPC;
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConnectionType.SelectedIndex == 0)
            {
                txtInput.Enabled = false;
            }
            else
            {
                txtInput.Enabled = true;
            }
        }
    }
}