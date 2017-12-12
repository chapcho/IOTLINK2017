using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FTOPApp
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        
        
        public string ServerLayoutPath = Application.StartupPath + "\\ServerLayout.xml";
        public string ClientLayoutPath = Application.StartupPath + "\\ClientLayout.xml";
        public string FTOPLogPath = Application.StartupPath + "\\FOTPSystemLog";

        public string AppName = "F-TOP ( Factory-Total Operating Package )";
        public string AppClientName = "F-TOP ( Client Mode )";
        public string AppServerName = "F-TOP ( Server Mode )";
        public string AppObserverName = "F-TOP ( Observer Mode )";
        public string AppVersion = "V1.0";

        private UCClient _client;
        private UCServer _server;

        protected int LodingTime = 1500;

        public FrmMain()
        {        
            InitializeComponent();
            Thread.Sleep(LodingTime);

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _client = new UCClient(ClientLayoutPath, FTOPLogPath);
            _server = new UCServer(ServerLayoutPath, FTOPLogPath);

            btnClient.ItemClick += (o, s) => { RunClient(); };
            btnServer.ItemClick += (o, s) => { RunServer(); };
            btnObserver.ItemClick += (o, s) => { RunObserver(); };

            this.Text = AppName + "  "+ AppVersion;
            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.View.SaveLayoutToXml(ServerLayoutPath);
            _client.View.SaveLayoutToXml(ClientLayoutPath);    
        }

        private void RunClient()
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(_client);

            _client.Dock = DockStyle.Fill;
            this.Text = AppClientName;
        }

        private void RunServer()
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(_server);

            _server.Dock = DockStyle.Fill;
            this.Text = AppServerName;
        }

        private void RunObserver()
        {
            var FrmOb = new FrmObserver(FTOPLogPath);

            FrmOb.Show();
        }
    }
}
