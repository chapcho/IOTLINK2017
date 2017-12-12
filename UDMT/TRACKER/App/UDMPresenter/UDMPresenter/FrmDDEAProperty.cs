using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.DDEA;

namespace UDMPresenter
{
    public partial class FrmDDEAProperty : Form
    {
        protected bool m_bRSeries = false;
        protected UCConnectSetMxCom4 ucConnectSetMxCom4 = null;
        protected CProject m_cProject = null;
        protected CDDEAConfigMS m_cConfig = null;

        #region Iniitalize

        public FrmDDEAProperty()
        {
            InitializeComponent();           
        }

        #endregion


        #region Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public bool IsConnectionCheck
        {
            get { return ucConnectionTest.ConnectSuccess; }
            set { ucConnectionTest.ConnectSuccess = value; }
        }

        public int RSeriesSelectedIndex
        {
            get { return ucConnectSetMxCom4.SelectedIndex; }
            set { ucConnectSetMxCom4.SelectedIndex = value; }
        }

        public double ScanTime
        {
            get { return ucConnectionTest.ScanTime; }
        }

        #endregion


        #region Form Event

        private void FrmDDEAProperty_Load(object sender, EventArgs e)
        {
            if (m_cProject == null)
            {
                this.Close();
                return;
            }
            if (m_cProject.PLCConfig == null)
                m_cProject.PLCConfig = new CDDEAConfigMS();
            m_cConfig = m_cProject.PLCConfig;
            txtProjectName.Text = m_cProject.Name;
            txtLogPath.Text = m_cProject.SaveLogPath;
            spnLogFileSaveTime.Value = m_cProject.SaveLogFileTime;
            
            m_bRSeries = CheckRSeries();
            if (m_bRSeries == false)
            {
                cmbMxComp.SelectedIndex = 0;
            }
            else
            {
                if (m_cProject.PLCConfig.MelsecCpuType == EMPlcConnettionType.Melsec_Normal)
                    cmbMxComp.SelectedIndex = 0;
                else
                    cmbMxComp.SelectedIndex = 1;
            }

            ucConnectionTest.UEventConnect += new UEventHandlerConnect(ucConnectionTest_UEventConnect);
            ucConnectionTest.PLCType = m_cConfig.MelsecCpuType;
            ucConnectSetting.GetConfig(m_cConfig);
            //if (m_cConfig != null)
            //{
            //    ucConnectSetting.GetConfig(m_cConfig);
                
            //}
            ucConnectionTest.Config = m_cConfig;
            if (m_bRSeries)
                ucConnectSetMxCom4.Config = m_cConfig;
            txtLogPath.Text = m_cProject.SaveLogPath;
            spnLogFileSaveTime.Value = m_cProject.SaveLogFileTime;
            txtProjectName.Text = m_cProject.Name;
           
        }

        void ucConnectionTest_UEventConnect(object sender)
        {
            if (m_cConfig.MelsecCpuType == EMPlcConnettionType.Melsec_RSeries)
            {
                ucConnectionTest.Config.MxCom4SelectedIndex = ucConnectSetMxCom4.SelectedIndex;
            }
            else
            {
                m_cConfig = ucConnectSetting.SetConfig(m_cConfig);
            }
            ucConnectionTest.Config = m_cConfig;
        }

        #endregion

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.SelectedPath = m_cProject.SaveLogPath;
            DialogResult dlgResult = dlgFolder.ShowDialog();
            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            m_cProject.SaveLogPath = dlgFolder.SelectedPath;
            txtLogPath.Text = m_cProject.SaveLogPath;
        }

        private void FrmDDEAProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_cProject.SaveLogFileTime = (int)spnLogFileSaveTime.Value;
            m_cProject.Name = txtProjectName.Text;
            m_cProject.PLCConfig = ucConnectSetting.SetConfig(m_cConfig);
            if (ucConnectionTest.TestRunning)
                ucConnectionTest.TestStop();

            ucConnectionTest.UEventConnect -= new UEventHandlerConnect(ucConnectionTest_UEventConnect);
        }

        protected bool CheckRSeries()
        {
            try
            {
                ucConnectSetMxCom4 = new UCConnectSetMxCom4();
                ucConnectSetMxCom4.Dock = DockStyle.Fill;
                tpMxComp4.Controls.Add(ucConnectSetMxCom4);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                tabSetting.TabPages.Remove(tpMxComp4);
                return false;
            }

            return true;
        }

        private void cmbMxComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMxComp.SelectedIndex == -1) return;
            if (m_bRSeries == false)
            {
                cmbMxComp.SelectedIndex = 0;
                return;
            }
            else
            {
                if (cmbMxComp.SelectedIndex == 0)
                    m_cConfig.MelsecCpuType = EMPlcConnettionType.Melsec_Normal;
                else
                    m_cConfig.MelsecCpuType = EMPlcConnettionType.Melsec_RSeries;
            }
        }

    }
}
