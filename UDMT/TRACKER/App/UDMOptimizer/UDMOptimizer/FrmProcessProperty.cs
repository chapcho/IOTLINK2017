using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerProject;

namespace UDMOptimizer
{
    public delegate void UEventProcessPropertyEdit();

    public partial class FrmProcessProperty : DevExpress.XtraEditors.XtraForm
    {
        private CPlcProc m_cProcess = null;

        public FrmProcessProperty()
        {
            InitializeComponent();
        }

        public CPlcProc Process
        {
            get { return m_cProcess; }
            set { SetProcessProperty(value);}
        }

        private void SetProcessProperty(CPlcProc cProcess)
        {
            m_cProcess = cProcess;

            ucProcessProperty.Process = cProcess;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProcessProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}