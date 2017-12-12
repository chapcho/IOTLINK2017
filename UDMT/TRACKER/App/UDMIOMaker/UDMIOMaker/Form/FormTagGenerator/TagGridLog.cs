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

namespace NewIOMaker.Form.Form_TagGenerator
{
    public partial class TagGridLog : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _FrmMain;

        public TagGridLog(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            _FrmMain.EventLogInput += _FrmMain_EventLogInput;

            exGridLog.MouseUp += exGridLog_MouseUp;
            btnExportTagLog.ItemClick += btnExportTagLog_ItemClick;
        }

        void btnExportTagLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string Path = dlgSaveFile.FileName;
            if (Path == string.Empty)
                return;

            exGridLog.ExportToCsv(Path);

        }

        void exGridLog_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                PopupTagLog.ShowPopup(CurrentPoint);
            }
        }

        void _FrmMain_EventLogInput(Event.LogEventArgs e)
        {
            if (e.TagLog != null)
                exGridLog.DataSource = e.TagLog;
        }

          
    }
}
