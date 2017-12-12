using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using DevExpress.XtraEditors;

namespace NewIOMaker.Form.FormCommon.UserControl
{
    public partial class ControlInfo : DevExpress.XtraEditors.XtraUserControl
    {

        private FormMain _frmMain;
        private ControlVideo _video;

        public ControlInfo(FormMain FormMain)
        {
            InitializeComponent();

            _frmMain = FormMain;

            _video = new ControlVideo();
            xtraTabPage2.Controls.Add(_video);
            _video.Dock = DockStyle.Fill;
            
            _frmMain.EventMenuInformationClick += _FrmMain_EventMenuInformationClick;
            ribbonControl1.Minimized = true;
            ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;

            
        }

        void _FrmMain_EventMenuInformationClick(object sender)
        {
            var path = string.Empty;
            try
            {
                switch (sender.ToString())
                {
                    case "HMI":
                        path = Application.StartupPath + "\\Manual\\표준작화_메뉴얼.pdf";
                        pdfViewer1.LoadDocument(path);
                        xtraTabControl1.SelectedTabPageIndex = 0;
                        break;
                    case "IOMaker":                
                        path = Application.StartupPath + "\\Manual\\IOMakerV2.5.pdf";
                        pdfViewer1.LoadDocument(path);
                        xtraTabControl1.SelectedTabPageIndex = 0;
                        break;
                    case "Tag":
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        _video.RunVideo("Tag");
                        break;
                    case "IO":
                        _video.RunVideo("IO");
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        break;
                    case "Multi":
                        _video.RunVideo("MC");
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        break;
                    case "Verification":
                        _video.RunVideo("Verification");
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        break;
                    case "Pdf":
                        xtraTabControl1.SelectedTabPageIndex = 0;
                        break;
                    case "Video":
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("PDF or AVI 파일 경로를 못찾았습니다." + ex);
            }
        }

    }
}
