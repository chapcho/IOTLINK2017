using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NewIOMaker.Form.FormCommon;
using NewIOMaker.Event;
using NewIOMaker.Form.FormIOMaker;
using UDM.Export;

namespace NewIOMaker.Form.Form_IOMaker
{
    public partial class IOMenu : DevExpress.XtraEditors.XtraUserControl
    {
        public event delIOMakerMenuEvent EventIOImportClick;
        public event delIOMakerExportEvent EventIOALLClick;
        public event delIOMakerExportEvent EventIOIOClick;
        public event delIOMakerExportEvent EventIODummyClick;
        public event delIOMakerExportEvent EventIOLinkClick;

        public event delLogInputEvent EventLogInput;

        protected FormMain _FrmMain;
        protected Sheet _sheet;
        protected IOGrid _ioImportGrid;

        public IOMenu(FormMain FrmMain)
        {
            InitializeComponent();
     
            _FrmMain = FrmMain;
            _FrmMain.EventIOImportClick += _FrmMain_EventIOImportClick;
            _FrmMain.EventIOLinkClick += _FrmMain_EventIOLinkClick;
            _FrmMain.EventIODummyClick += _FrmMain_EventIODummyClick;
            _FrmMain.EventIOIOClick += _FrmMain_EventIOIOClick;
            _FrmMain.EventIOALLClick += _FrmMain_EventIOALLClick;
            _FrmMain.FormClosing += _FrmMain_FormClosing;
            IOGriddockPanel.CustomButtonClick += dockPanel1_CustomButtonClick;

            IOGriddockPanel.Options.ShowCloseButton = false;
            
          
            try
            {
                _sheet = new Sheet(this);
                _ioImportGrid = new IOGrid(this, _sheet);

                IOGriddockPanel.Controls.Add(_ioImportGrid);
                ExcelViewer.Controls.Add(_sheet);
                _ioImportGrid.Dock = DockStyle.Fill;
                _sheet.Dock = DockStyle.Fill;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            _ioImportGrid.EventLogInput += _ioImportGrid_EventLogInput;

            
        }

        void _FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _sheet.sheetcontrol = null;
                _sheet = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void _ioImportGrid_EventLogInput(LogEventArgs e)
        {
            EventLogInput(e);
        }

        void dockPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            IOGriddockPanel.HideSliding();
        }

        void _FrmMain_EventIOALLClick(object sender)
        {
            EventIOALLClick(sender);
        }

        void _FrmMain_EventIOIOClick(object sender)
        {
            EventIOIOClick(sender);
        }

        void _FrmMain_EventIODummyClick(object sender)
        {
            EventIODummyClick(sender);
        }

        void _FrmMain_EventIOLinkClick(object sender)
        {
            EventIOLinkClick(sender);
        }

        void _FrmMain_EventIOImportClick(object sender)
        {
            EventIOImportClick(sender);
        }
  
    }
}
