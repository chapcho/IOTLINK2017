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
using NewIOMaker.Form.Form_IOMaker.Menu;
using NewIOMaker.Form.Form_IOMaker.Grid;
using NewIOMaker.Form.Form_Common;

namespace NewIOMaker.Form.Form_IOMaker
{
    public partial class IOMenu : DevExpress.XtraEditors.XtraUserControl
    {
        protected IOHome _home;
        protected Sheet _sheet;
        protected IOImportGrid _ioImportGrid; 
  
        public IOMenu()
        {
            InitializeComponent();
            this.Load += IOMenu_Load;
            dockPanel1.Options.ShowCloseButton = false;
            // Handling the QueryControl event that will populate all automatically generated Documents
            this.windowsUIView2.QueryControl += windowsUIView2_QueryControl;
        }

        void IOMenu_Load(object sender, EventArgs e)
        {
            _home = new IOHome();

            dockPanel1.Controls.Add(_home);
            _home.Dock = DockStyle.Fill;


            _ioImportGrid = new NewIOMaker.Form.Form_IOMaker.Grid.IOImportGrid(_home);
            _sheet = new Sheet(_ioImportGrid);
        
        }

        // Assigning a required content for each auto generated Document
        void windowsUIView2_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == document7)
                e.Control = _ioImportGrid;


            if (e.Document == document10)
                e.Control = _home;


            if (e.Document == document13)
                e.Control = _sheet; 

        }



    }
}
