using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace FTOPApp
{
    public partial class FrmDcomSetting : DevExpress.XtraEditors.XtraForm
    {
        public OPCAutomation.OPCServer Opcserver;
        public bool IsDCOMUsed = false;
        public string RemoteAddress = "172.18.8.22";


        public FrmDcomSetting(bool isDCOMused , string remoteAddress )
        {
            InitializeComponent();

            checkDCOM.EditValue = isDCOMused;
            textDCOMAddress.Text = remoteAddress;

            this.Load += FrmDcomSetting_Load;

        }

        private void FrmDcomSetting_Load(object sender, EventArgs e)
        {
            btnCommTest.Click += btnCommTest_Click;
            btnDCOMConfiguration.Click += btnDCOMConfiguration_Click;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDCOMConfiguration_Click(object sender, EventArgs e)
        {
            var systemPath = @"C:\Windows\System32";
            Process.Start(systemPath + "\\dcomcnfg.exe");
        }

        private void btnCommTest_Click(object sender, EventArgs e)
        {
            try
            {
                Opcserver = new OPCAutomation.OPCServer();
                Opcserver.Connect("OPCsoft.OPCWorkX.V12_1", textDCOMAddress.Text);
                labelStatus.Text = "연결 성공 -> OPC ServerStatus : " + Opcserver.CurrentTime;
                labelTime.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                labelStatus.Text = "연결 실패 -> HRESULT : " + ex.HResult;
                labelTime.Text = DateTime.Now.ToString();
            }
        }
    }
}