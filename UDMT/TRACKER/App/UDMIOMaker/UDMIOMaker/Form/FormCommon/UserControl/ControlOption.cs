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
using NewIOMaker.Form.Form_TagGenerator;
using NewIOMaker.Form.FormIOMaker;

namespace NewIOMaker.Form.FormCommon.UserControl
{
    public partial class ControlOption : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _FrmMain;
        protected TagGridLog _logGrid;
        protected TagGridAlarm _alarmGrid;
        protected IOGridLog _ioLogGrid;
        protected ControlBackupGrid _BackupGrid;


        public ControlOption(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            _FrmMain.EventPageClick += _FrmMain_EventPageClick;
            OptionSpliter.SplitterPosition = OptionSpliter.Height;

            _logGrid = new TagGridLog(_FrmMain);
            _ioLogGrid = new IOGridLog(_FrmMain);
            _BackupGrid = new ControlBackupGrid(_FrmMain);

            IOListLog.Controls.Add(_ioLogGrid);
            BackupLog.Controls.Add(_BackupGrid);
            MappingLog.Controls.Add(_logGrid);


            _logGrid.Dock = DockStyle.Fill;
            _ioLogGrid.Dock = DockStyle.Fill;
            _BackupGrid.Dock = DockStyle.Fill;

        }

        void _FrmMain_EventPageClick(Enums.EMCommonPageInfo sender)
        {
            OptionSpliter.SplitterPosition = OptionSpliter.Width / 3;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }

    }
}
