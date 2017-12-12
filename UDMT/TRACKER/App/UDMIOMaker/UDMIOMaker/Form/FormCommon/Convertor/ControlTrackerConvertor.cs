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
using UDM.UDLImport;
using UDM.Common;

namespace NewIOMaker.Form.FormCommon.Convertor
{
    public partial class ControlTrackerConvertor : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _frmMain;

        public ControlTrackerConvertor(FormMain frmMain)
        {
            InitializeComponent();

            _frmMain = frmMain;

            _frmMain.EventPageClick += _frmMain_EventPageClick;

            abImport.LinkClicked += abImport_LinkClicked;
            abExport.LinkClicked += abExport_LinkClicked;
        }

        void abExport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string sPath = dlgSaveFile.FileName;

            if (sPath == string.Empty)
                return;

            gridView2.ExportToCsv(sPath);
        }

        void abImport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                CUDLImport udlImport = new CUDLImport();
                udlImport.MakeGlobelAndLocalTags();

                gridControl1.DataSource = udlImport.GlobalTags.Values;
                gridControl2.DataSource = udlImport.GlobalTags.Values;

                gridView1.BestFitColumns();
                gridView2.BestFitColumns();

                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception.." + ex);
                MessageBox.Show("Not Supported ...");
            }
        }

        void _frmMain_EventPageClick(Enums.EMCommonPageInfo sender)
        {
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }


    }
}
