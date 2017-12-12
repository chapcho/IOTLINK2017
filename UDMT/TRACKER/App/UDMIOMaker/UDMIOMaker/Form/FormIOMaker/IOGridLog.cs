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

namespace NewIOMaker.Form.FormIOMaker
{
    public partial class IOGridLog : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _FrmMain;

        public IOGridLog(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;
            _FrmMain.EventLogInput += _FrmMain_EventLogInput;
            IOLogGrid.MouseUp += IOLogGrid_MouseUp;
            btnIOListLogExport.ItemClick += btnIOListLogExport_ItemClick;
        }

        void btnIOListLogExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string Path = dlgSaveFile.FileName;
            if (Path == string.Empty)
                return;

            IOLogGrid.ExportToCsv(Path);
        }

        void IOLogGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupIOExport.ShowPopup(CurrentPoint);
            }
        }

        void _FrmMain_EventLogInput(Event.LogEventArgs e)
        {
            if (e.IOLog!=null)
                IOLogGrid.DataSource = e.IOLog;          
        }
    }
}
