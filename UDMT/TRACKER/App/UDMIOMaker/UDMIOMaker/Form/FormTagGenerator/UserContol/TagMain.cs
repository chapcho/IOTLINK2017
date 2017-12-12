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
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using NewIOMaker.Form.Form_Common;
using NewIOMaker.Event.Event_TagGenerator;
using NewIOMaker.Form.Form_TagGenerator.Menu;

namespace NewIOMaker.Form.Form_TagGenerator
{
    
    public partial class TagMain : DevExpress.XtraEditors.XtraUserControl
    {
        DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction closeAppAction = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction()
        {
            Caption = "Confirm",
            Description = "Quit the IOMaker?"
        };

        protected delegate void delMainFormClosing(object sender, FormClosingEventArgs e);
        protected event delMainFormClosing EventMainFormClosing;
        public event delGridIHMIDataConfirm EventHMIInput;

        public DataTable _HMIdb = new DataTable();
        public DataTable _PLCdb = new DataTable();
        protected TagGrid _tagGrid;
        protected TagGridLog _tagLog;
        protected TagGridAlarm _tagAlarm;
    
        #region Intialize/Dispose


        public TagMain()
        {
            InitializeComponent();

            closeAppAction.Commands.Add(FlyoutCommand.OK);
            closeAppAction.Commands.Add(FlyoutCommand.Cancel);

            dockPanel1.Options.ShowCloseButton = false;
            dockPanel3.Options.ShowCloseButton = false;
       
            this.EventMainFormClosing += Control_Tag_Main_EventMainFormClosing;
            this.Load += Control_Tag_Main_Load;
            this.Load += TagMain_Load;
            this.panelContainer1.CustomButtonClick += panelContainer1_CustomButtonClick;
           
        }

        void panelContainer1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            dockPanel1.HideSliding();
            dockPanel2.HideSliding();
            dockPanel3.HideSliding();
        }

        void TagMain_Load(object sender, EventArgs e)
        {
            Home home = new Home();
            navigationHome.Controls.Add(home);
            home.Dock = DockStyle.Fill;

            PLC plc = new PLC();
            navigationPLC.Controls.Add(plc);
            plc.Dock = DockStyle.Fill;

            HMI hmi = new HMI(this);
            navigationHMI.Controls.Add(hmi);
            hmi.Dock = DockStyle.Fill;

            Tool tool = new Tool();
            navigationTool.Controls.Add(tool);
            tool.Dock = DockStyle.Fill;

            _tagGrid = new TagGrid(this, plc, hmi, tool);
            _tagGrid.ImportAfterEvent += _tagGrid_ImportAfterEvent;

            _tagLog = new TagGridLog(this, _tagGrid);
            dockPanel3.Controls.Add(_tagLog);
            _tagLog.Dock = DockStyle.Fill;

            _tagAlarm = new TagGridAlarm(_tagGrid);
            dockPanel2.Controls.Add(_tagAlarm);
            _tagAlarm.Dock = DockStyle.Fill;
        }

        void _tagGrid_ImportAfterEvent(string temp)
        {
            dockPanel1.HideSliding();
            dockPanel2.HideSliding();

            EventHMIInput(temp);
        }

         #endregion

        public void Control_Tag_Main_EventMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (windowsUIView1.ShowFlyoutDialog(flyout1) != System.Windows.Forms.DialogResult.OK) e.Cancel = true;
        }

        void Control_Tag_Main_Load(object sender, EventArgs e)
        {
            flyout1.Action = closeAppAction;
        }

        #region Public Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
