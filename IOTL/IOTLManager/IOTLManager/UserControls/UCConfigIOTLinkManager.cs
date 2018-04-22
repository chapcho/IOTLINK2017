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
        private CProject m_cProject = new CProject();

        public UCConfigIOTLinkManager()
        {
            InitializeComponent();
        }

        public CProject ServerConfig
        {
            get
            {
                if (!string.IsNullOrEmpty(m_cProject.CompServerDBLoginUserId)) return m_cProject;
                else return null;
            }
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

            m_cProject.CompServerIPAddress = this.txtCompServerIPAddress.Text;
            m_cProject.CompServerTcpPort = Convert.ToUInt16(this.txtCompServerPort.Text);
            m_cProject.CompServerDBAddr = this.txtCompServerDBAddr.Text;
            m_cProject.CompServerInitialDatabaseName = this.txtCompServerDBName.Text;
            m_cProject.CompServerLogDirectory = this.txtCompServerLogFolder.Text;
            m_cProject.CompServerDBPort = Convert.ToUInt16(this.txtCompServerDBPort.Text);
            m_cProject.CompServerDBLoginUserId = this.txtCompServerDBUserID.Text;
            m_cProject.CompServerDBLoginUserPw = this.txtCompServerDBUserPw.Text;

            try
            {
                m_cProject.Save(Application.StartupPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            if(MessageBox.Show("Config Saved. ReStart Application.","IOTLManager") == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if(LoadSystemConfig())
            {
                ReloadSystemConfig(m_cProject);
            }
        }

        public bool LoadSystemConfig()
        {
            bool bOk = false;

            CProject savedConfig = new CProject();
            try
            {
                bOk = m_cProject.Open(Application.StartupPath, out savedConfig);
                if (bOk)
                {
                    m_cProject = savedConfig;
                    ReloadSystemConfig(m_cProject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bOk;
        }

        private void ReloadSystemConfig(CProject savedConfig)
        {
            this.txtCompServerIPAddress.Text = savedConfig.CompServerIPAddress;
            this.txtCompServerPort.Text = savedConfig.CompServerTcpPort.ToString();
            this.txtCompServerDBName.Text = savedConfig.CompServerInitialDatabaseName;
            this.txtCompServerDBAddr.Text = savedConfig.CompServerDBAddr;
            this.txtCompServerDBPort.Text = savedConfig.CompServerDBPort.ToString();
            this.txtCompServerDBUserID.Text = savedConfig.CompServerDBLoginUserId;
            this.txtCompServerDBUserPw.Text = savedConfig.CompServerDBLoginUserPw;
            this.txtCompServerLogFolder.Text = savedConfig.CompServerLogDirectory;
        }
    }
}
