using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace NewIOMaker.Form.FormCommon
{
    public partial class FormPDF : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormPDF(string Manual)
        {
            InitializeComponent();          

            string path = string.Empty;

            try
            {
                if (Manual == "HMI")
                {
                    path = Application.StartupPath + "\\Manual\\표준작화_메뉴얼.pdf";
                    pdfViewer1.LoadDocument(path);
                }

                if (Manual == "IOMaker")
                {
                    path = Application.StartupPath + "\\Manual\\IOMakerV2.5.pdf";
                    pdfViewer1.LoadDocument(path);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("IOMakerV2.5.pdf or 표준작화_메뉴얼.pdf 파일 경로를 못찾았습니다."+ ex);
            }


        }
    }
}