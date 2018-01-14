using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOTL.Project;
using IOTL.Common.Serialize;

namespace IOTLManager.UserControls
{
    public partial class UCConfigIOTLinkManager : UserControl
    {
        
        private CProject cProject = new CProject();

        public UCConfigIOTLinkManager()
        {
            InitializeComponent();
        }

        private void btnCompServerLogFind_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            try
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    this.txtCompServerLogFolder.Text = fbd.SelectedPath;
                }
                else
                {
                    this.txtCompServerLogFolder.Text = "C:\\Log";
                }
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private bool ValidationServerConfig()
        {
            bool bRet = false;

            bRet = true;

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

            cProject.CompServerIPAddress = this.txtCompServerIPAddress.Text;
            cProject.CompServerTcpPort = Convert.ToUInt16(this.txtCompServerPort.Text);
            cProject.CompServerInitialDatabaseName = this.txtCompServerDBName.Text;
            cProject.CompServerLogDirectory = this.txtCompServerLogFolder.Text;
            cProject.CompServerDBPort = Convert.ToUInt16(this.txtCompServerDBPort.Text);
            cProject.CompServerDBLoginUserId = this.txtCompServerDBUserID.Text;
            cProject.CompServerDBLoginUserPw = this.txtCompServerDBUserPw.Text;

            try
            {
                cProject.Save(Application.StartupPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            CProject savedConfig = new CProject();
            try
            {
                bool bOk = cProject.Open(Application.StartupPath, out savedConfig);
                if(bOk)
                {
                    cProject = savedConfig;
                    ReloadSystemConfig(cProject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ReloadSystemConfig(CProject savedConfig)
        {
            this.txtCompServerIPAddress.Text = savedConfig.CompServerIPAddress;
            this.txtCompServerPort.Text = savedConfig.CompServerTcpPort.ToString();
            this.txtCompServerDBName.Text = savedConfig.CompServerInitialDatabaseName;
            this.txtCompServerDBPort.Text = savedConfig.CompServerDBPort.ToString();
            this.txtCompServerDBUserID.Text = savedConfig.CompServerDBLoginUserId;
            this.txtCompServerDBUserPw.Text = savedConfig.CompServerDBLoginUserPw;
            this.txtCompServerLogFolder.Text = savedConfig.CompServerLogDirectory;
        }
    }
}
