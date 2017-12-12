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
using NewIOMaker.Form.FormCommon;
using NewIOMaker.Event;
using NewIOMaker.Form.FormTagGenerator;

namespace NewIOMaker.Form.Form_TagGenerator
{
    
    public partial class TagMain : DevExpress.XtraEditors.XtraUserControl
    {

        public DataTable _HMIdb = new DataTable();
        public DataTable _PLCdb = new DataTable();
        public DataTable _KeyList = new DataTable();

        protected FormMain _FrmMain;
        protected TagGrid _tagGrid;
        protected TagGridLog _tagLog;
        protected TagGridAlarm _tagAlarm;
        public int _FrmMainSize;

        #region Event

        public event delGridIHMIDataConfirm DataInputEvent;
        public event delTagGeneratorMenuEvent EventPLCAddClick;
        public event delTagGeneratorMenuEvent EventNewPLCClick;
        public event delTagGeneratorMenuEvent EventNewHMIClick;
        public event delTagGeneratorMenuEvent EventPLCImportClick;
        public event delTagGeneratorMenuEvent EventHMIImportClick;
        public event delTagHMIExportMenuEvent EventHMIExportAllClick;
        public event delTagHMIExportMenuEvent EventHMIExportPartClick;
        public event delTagGeneratorColorEvent EventColorMappingClick;
        public event delTagGeneratorColorEvent EventColorConvertingClick;
        public event delTagGeneratorColorEvent EventColorInsertingClick;
        public event delTagGeneratorMenuEvent EventFilterClick;
        public event delTagGeneratorMenuEvent EventEditerClick;
        public event delTagGeneratorMenuEvent EventFilterGellayClick;
        public event delTagGeneratorMenuEvent EventEditerGellayClick;

        public event delTagGeneratorOpenSaveEvent EventOpenSaveClick;
        public event delBackupCallEvent EventBackCallAlarm;
        public event delBackupCallEvent EventBackupBtnClick;
        public event delBackupTimeEvent EventBackupTimeAction;

        public event delMultiKeyListUpdate EventKeyUpdate;
        public event delLogInputEvent EventLogInput;

        #endregion

        #region Intialize/Dispose

        public TagMain(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            _FrmMainSize = FrmMain.Width;
            _tagGrid = new TagGrid(this);

            this.Controls.Add(_tagGrid);
            _tagGrid.Dock = DockStyle.Fill;
            _tagGrid.DataInputEvent += _tagGrid_DataInputEvent;
            _tagGrid.EventBackupTimeAction += _tagGrid_EventBackupTimeAction;
            _tagGrid.EventLogInput += _tagGrid_EventLogInput;
                              
            _FrmMain.EventPLCImportClick += _FrmMain_EventPLCImportClick;
            _FrmMain.EventHMIImportClick += _FrmMain_EventHMIImportClick;
            _FrmMain.EventHMIExportAllClick += _FrmMain_EventHMIExportAllClick;
            _FrmMain.EventHMIExportPartClick += _FrmMain_EventHMIExportPartClick;
            _FrmMain.EventColorMappingClick += _FrmMain_EventColorMappingClick;
            _FrmMain.EventColorConvertingClick += _FrmMain_EventColorConvertingClick;
            _FrmMain.EventColorInsertingClick += _FrmMain_EventColorInsertingClick;
            _FrmMain.EventOpenSaveClick += _FrmMain_EventOpenSaveClick;
            _FrmMain.EventNewPLCClick += _FrmMain_EventNewPLCClick;
            _FrmMain.EventNewHMIClick += _FrmMain_EventNewHMIClick;
            _FrmMain.EventFilterClick += _FrmMain_EventFilterClick;
            _FrmMain.EventEditerClick += _FrmMain_EventEditerClick;
            _FrmMain.EventFilterGellayClick += _FrmMain_EventFilterGellayClick;
            _FrmMain.EventEditerGellayClick += _FrmMain_EventEditerGellayClick;
            _FrmMain.EventKeyUpdate += _FrmMain_EventKeyUpdate;
            _FrmMain.EventBackCallAlarm += _FrmMain_EventBackCallAlarm;
            _FrmMain.EventBackupBtnClick += _FrmMain_EventBackupBtnClick;
            _FrmMain.EventPLCAddClick += _FrmMain_EventPLCAddClick;
        }

        void _FrmMain_EventPLCAddClick(object sender)
        {
            EventPLCAddClick(sender);
        }

        void _tagGrid_EventLogInput(LogEventArgs e)
        {
            EventLogInput(e);
        }

        void _tagGrid_EventBackupTimeAction(object sender)
        {
            EventBackupTimeAction(sender);
        }

        void _tagGrid_DataInputEvent(string Temp)
        {
            DataInputEvent(Temp);
        }

        void _FrmMain_EventBackupBtnClick(object sender)
        {
            EventBackupBtnClick(sender);
        }

        void _FrmMain_EventBackCallAlarm(object sender)
        {
            EventBackCallAlarm(sender);
        }

        void _FrmMain_EventKeyUpdate(DataTable KeyDB)
        {
            EventKeyUpdate(KeyDB);
        }

        void _FrmMain_EventEditerGellayClick(object sender)
        {
            EventEditerGellayClick(sender);
        }

        void _FrmMain_EventEditerClick(object sender)
        {
            EventEditerClick(sender);
        }

        void _FrmMain_EventFilterGellayClick(object sender)
        {
            EventFilterGellayClick(sender);
        }

        void _FrmMain_EventFilterClick(object sender)
        {
            EventFilterClick(sender);
        }

        void _FrmMain_EventNewHMIClick(object sender)
        {
            EventNewHMIClick(sender);
        }

        void _FrmMain_EventNewPLCClick(object sender)
        {
            EventNewPLCClick(sender);
        }

        void _FrmMain_EventOpenSaveClick(string option)
        {
            EventOpenSaveClick(option);
            _KeyList = _tagGrid.Keydb;
        }

        void _FrmMain_EventHMIExportPartClick(string part)
        {
            EventHMIExportPartClick(part);
        }

        void _FrmMain_EventHMIExportAllClick(string part)
        {
            EventHMIExportAllClick(part);
        }

        void _FrmMain_EventColorInsertingClick(Color color)
        {
            EventColorInsertingClick(color);
        }

        void _FrmMain_EventColorConvertingClick(Color color)
        {
            EventColorConvertingClick(color);
        }

        void _FrmMain_EventColorMappingClick(Color color)
        {
            EventColorMappingClick(color);
        }

        void _FrmMain_EventHMIImportClick(object sender)
        {
            EventHMIImportClick(sender);
        }

        void _FrmMain_EventPLCImportClick(object sender)
        {
            EventPLCImportClick(sender);
        }


        #endregion


    }
}
