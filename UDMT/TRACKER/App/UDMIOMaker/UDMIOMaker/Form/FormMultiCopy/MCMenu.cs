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
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Event;

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCMenu : DevExpress.XtraEditors.XtraUserControl
    {
        //public event delMultiKeyListUpdate EventKeyUpdate;
        //public event delMultiKeyListUpdate EventKeyload;
        public event delMultiCopyKey EventSelectKey;
        public event delMultiCopyUseImport EventUseImportClick;
        protected FormMain _FrmMain;
        protected MCOP _Operation;
        protected MCKey _Key;
        protected MCKeyList _KeyList;
        protected CommonMessage _cMessage = new CommonMessage();

        public DataTable _KeyDB = new DataTable();
        public event delMultiCopyRunorStop EventRunAfter;
        public event delMultiCopyRunorStop EventStopAfter;

        protected string _run = "Run";
        protected string _stop = "Stop";
        protected string _useImport = "[    Use Import File    ]";
        protected string _noUseImport = "[    No Use Import File    ]";

        #region Initialize/Dispose

        public MCMenu(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            dockPanel2.Options.ShowCloseButton = false;
            this.btnRun.ElementClick += btnRun_ElementClick;
            this.btnStop.ElementClick += btnStop_ElementClick;

            _FrmMain.EventMCStopClick += _FrmMain_EventMCStopClick;
            _FrmMain.EventMCKeyListClick += _FrmMain_EventMCKeyListClick;
            _FrmMain.EventMCKeyGeneratorClick += _FrmMain_EventMCKeyGeneratorClick;

            _Key = new MCKey(this);
            _KeyList = new MCKeyList(this, _Key);
            _Operation = new MCOP(this, _KeyList);

            KeyListdockPanel.Options.ShowCloseButton = false;
            KeyListdockPanel.Controls.Add(_KeyList);
            dockPanel2.Controls.Add(_Key);

            this.Controls.Add(_Operation);
            _KeyList.Dock = DockStyle.Fill;
            _Key.Dock = DockStyle.Fill;
            _Operation.Dock = DockStyle.Fill;
            _KeyList.EventKeySelctAfter += _KeyList_EventKeySelctAfter;
            _Key.EventGenerateKeyClick +=_Key_EventGenerateKeyClick;
 
            UseImportFile.Caption = _noUseImport;
            UseImportFile.ElementClick += UseImportFile_ElementClick;
        }

        void UseImportFile_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (UseImportFile.Caption == _useImport)
            {
                UseImportFile.Caption = _noUseImport;
                UseImportFile.Appearance.BackColor = Color.Empty;
                EventUseImportClick("Use");
            }              
            else
            {
                UseImportFile.Caption = _useImport;
                UseImportFile.Appearance.BackColor = Color.FromArgb(155, 187, 89);
                EventUseImportClick("UnUse");
            }
               
        }

        void _KeyList_EventKeySelctAfter(string SelectKey, Dictionary<string, List<string>> dicKey)
        {
            UserKeyCategory.Caption = "[   Current Key  :  " + SelectKey + "   ]   ";
            UserKeyCategory.Appearance.BackColor = Color.FromArgb(155, 187, 89);
        }

        void _FrmMain_EventMCKeyGeneratorClick(object sender)
        {

        }

        void _FrmMain_EventMCKeyListClick(object sender)
        {
            KeyListdockPanel.Show();
        }

        void _FrmMain_EventMCStopClick(object sender)
        {
            MenuChangeFuntion(_stop);
        }

        void _FrmMain_EventMCRunClick(object sender)
        {
            
        }

        void btnStop_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MenuChangeFuntion(_stop);
        }

        void btnRun_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MenuChangeFuntion(_run);
        }


        void _Key_EventGenerateKeyClick(object sender1, object sender2)
        {
            dockPanel2.HideSliding();

            EventSelectKey(sender1, sender2);   
        }

        #endregion

        private void dockPanel2_Click(object sender, EventArgs e)
        {
            dockPanel2.HideSliding();
        }

        #region Public Methods

        #region Run Menu

        protected void MenuChangeFuntion(string Value)
        {
            if (Value == _run)
            {
                tileNavPane1.Appearance.BackColor = Color.FromArgb(227, 108, 9);
                btnDefault.Caption = "RUNNING                 ";
                EventRunAfter();
            }
            else if (Value == _stop)
            {
                tileNavPane1.Appearance.BackColor = Color.Empty;
                btnDefault.Caption = "READY                 ";
                EventStopAfter();
            }
        }

        #endregion

        #endregion

    }
}
