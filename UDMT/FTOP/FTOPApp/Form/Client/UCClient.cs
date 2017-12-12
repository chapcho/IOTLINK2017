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
    public partial class UCClient : UserControl
    {

        public WidgetView View;

        private UCPLCRegister _regiser;
        private UCClientStatusDB _statusDB;
        private UCClientStatusOPC _statusOPC;
        private UCClientLog _log;


        public UCClient(string LayoutPath, string LogPath)
        {
            InitializeComponent();

            View = widgetView1;

            _log = new UCClientLog();
            _regiser = new UCPLCRegister(_log, LogPath);
            _statusDB = new UCClientStatusDB(_regiser);
            _statusOPC = new UCClientStatusOPC(_regiser);

            this.widgetView1.QueryControl += widgetView1_QueryControl;

            try
            {
                widgetView1.RestoreLayoutFromXml(LayoutPath);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };     
        }

        // Assigning a required content for each auto generated Documen
        private void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Document == uCPLCRegisterDocument)
                e.Control = _regiser;

            if (e.Document == uCClientStatusDBDocument)
                e.Control = _statusDB;
            if (e.Document == uCClientStatusOPCDocument)
                e.Control = _statusOPC;

            if (e.Document == uCClientLogDocument)
                e.Control = _log;
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

    }
}
