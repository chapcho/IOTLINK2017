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

namespace NewIOMaker.Form.FormCommon.UserControl
{
    public partial class ControlBackupGrid : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _FrmMain;

        public ControlBackupGrid(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            _FrmMain.EventLogInput += _FrmMain_EventLogInput;
            BackupGrid.MouseUp += BackupGrid_MouseUp;
            btnBackupExport.ItemClick += btnBackupExport_ItemClick;
        }

        void btnBackupExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string Path = dlgSaveFile.FileName;
            if (Path == string.Empty)
                return;

            BackupGrid.ExportToCsv(Path);
        }

        void BackupGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {                
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupBackup.ShowPopup(CurrentPoint);
            }
        }

        void _FrmMain_EventLogInput(Event.LogEventArgs e)
        {
            if (e.BackupLog != null)
                BackupGrid.DataSource = e.BackupLog;
            
        }
    }
}
