using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTLManager.UserControls
{
    public partial class UCConfigIOTLinkManager : UserControl
    {
        public UCConfigIOTLinkManager()
        {
            InitializeComponent();
        }

        private void btnCompServerLogFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "*.cfg||(*.cfg)";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("...");
            }
        }

        private bool ValidationServerConfig()
        {
            bool bRet = false;


            if(!bRet)
            {
                MessageBox.Show("설정 정보를 확인하세요!");
            }
            return bRet;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if(!ValidationServerConfig())
            {
                return;
            }
        }
    }
}
