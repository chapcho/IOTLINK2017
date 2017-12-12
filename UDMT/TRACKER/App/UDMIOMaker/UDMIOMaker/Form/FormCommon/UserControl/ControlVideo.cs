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
    public partial class ControlVideo : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlVideo()
        {
            InitializeComponent();

            MediaPlayer1.Dock = DockStyle.Fill;

        }

        public void RunVideo(string value)
        {
            string path = Application.StartupPath;

            if (value == "Tag")
            {
                try
                {
                    MediaPlayer1.URL = path + "\\Video\\NewIOMaker_Mapping.avi";
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ex" + ex);
                }
            }
            if (value == "IO")
            {
                try
                {
                    MediaPlayer1.URL = path + "\\Video\\NewIOMakerIOList.avi";
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ex" + ex);
                }

            }
            if (value == "MC")
            {
                try
                {
                    MediaPlayer1.URL = path + "\\Video\\IOMakerMultiCopy.avi";
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ex" + ex);
                }
            }
            if (value == "Verification")
            {
                try
                {
                    MediaPlayer1.URL = path + "\\Video\\IOMakerVerification.wmv";
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ex" + ex);
                }
            }
            
        }
    }
}
