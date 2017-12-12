using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.Widget;

namespace FTOPApp
{
    public partial class UCServer : UserControl
    {
        public WidgetView View;

        private UCServerStatusCPS _statusCPS;
        private UCServerStatusDB _statusDB;
        private UCServerStatusMES _statusMES;

        private UCDBSender _senderDB;
        private UCServerLog _log;

        public UCServer(string LayoutPath, string LogPath)
        {
            InitializeComponent();

            View = widgetView1;

            _log = new UCServerLog();
            _senderDB = new UCDBSender(_log, LogPath);

            _statusCPS = new UCServerStatusCPS();
            _statusDB = new UCServerStatusDB();
            _statusMES = new UCServerStatusMES();

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.widgetView1.QueryControl += widgetView1_QueryControl;

            try
            {
                widgetView1.RestoreLayoutFromXml(LayoutPath);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };                  
        }

        // Assigning a required content for each auto generated Document
        
        private void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == uCServerStatusCPSDocument)
                e.Control = _statusCPS;
            if (e.Document == uCDBSenderDocument)
                e.Control = _senderDB;
            if (e.Document == uCServerStatusDBDocument)
                e.Control = _statusDB;
            if (e.Document == uCServerStatusMESDocument)
                e.Control = _statusMES;
            if (e.Document == uCServerLogDocument)
                e.Control = _log;
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

    }
}
