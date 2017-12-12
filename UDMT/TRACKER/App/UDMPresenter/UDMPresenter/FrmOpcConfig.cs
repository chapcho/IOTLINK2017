using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Monitor.Plc.Source.OPC;

namespace UDMPresenter
{
    public partial class FrmOpcConfig : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        protected CProject m_cProject = null;

        Dictionary<string, List<string>> m_dicChannel = new Dictionary<string, List<string>>();
        List<string> m_lstServer = new List<string>();

        #endregion


        #region Initialize

        public FrmOpcConfig()
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

        #endregion


        #region Protected Method

        protected List<string> GetOPCServerList()
        {
            COPCServer cOPCServer = new COPCServer();
            List<string> lstServer = cOPCServer.GetOPCServerList();

            cOPCServer.Dispose();
            cOPCServer = null;

            return lstServer;
        }

        protected void GetOPCChannelList()
        {
            COPCServer cOPCServer = new COPCServer();
            m_dicChannel = cOPCServer.GetOPCChannelList();

            cOPCServer.Dispose();
            cOPCServer = null;

            return;
        }

        protected void GetServerList()
        {
            COPCServer cOPCServer = new COPCServer();
            m_lstServer = cOPCServer.GetOPCServerList();

            cOPCServer.Dispose();
            cOPCServer = null;
        }

        private void ShowDeviceList(string sServer)
        {
            cmbChannelList.Properties.Items.Clear();
            for (int i = 0; i < m_dicChannel[sServer].Count; i++)
                cmbChannelList.Properties.Items.Add(m_dicChannel[sServer][i]);

            if (m_lstServer.Contains(CProjectManager.SelectedProject.OpcConfig.ServerName))
            {
                string sSeverName = CProjectManager.SelectedProject.OpcConfig.ServerName;
                int iFind = m_dicChannel[sSeverName].Where(b => b == CProjectManager.SelectedProject.OpcConfig.ChannelDevice).Count();

                cmbServerList.SelectedIndex = cmbServerList.Properties.Items.IndexOf(sSeverName);
                if (iFind > 0)
                    cmbChannelList.SelectedIndex = cmbChannelList.Properties.Items.IndexOf(CProjectManager.SelectedProject.OpcConfig.ChannelDevice);
                else
                    cmbChannelList.SelectedIndex = 0;
            }
            else
                cmbChannelList.SelectedIndex = 0;
        }

        private void ShowServerList()
        {
            cmbServerList.Properties.Items.Clear();

            if(m_lstServer.Count == 0)
            {
                this.Close();
                MessageBox.Show("설치된 OPC Server가 없습니다.");
            }

            for (int i =0; i<m_lstServer.Count; i++)
                cmbServerList.Properties.Items.Add(m_lstServer[i]);
            if (CProjectManager.SelectedProject.OpcConfig.ServerName != "")
            {
                string sFind = m_lstServer.Find(b => b == CProjectManager.SelectedProject.OpcConfig.ServerName);
                if(sFind == null || sFind == "")
                    cmbServerList.SelectedIndex = -1;
                else
                    cmbServerList.SelectedIndex = cmbServerList.Properties.Items.IndexOf(CProjectManager.SelectedProject.OpcConfig.ServerName);
            }
            else
                cmbServerList.SelectedIndex = -1;
        }

        private void ChangeChannel()
        {
            foreach (var who in CProjectManager.SelectedProject.TagS)
                who.Value.Channel = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;
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

        private void FrmOpcConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmbServerList.SelectedItem == null) return;
            if (cmbServerList.SelectedItem.ToString() == "") return;
            if (cmbChannelList.SelectedItem == null) return;

            m_cProject.SaveLogFileTime = (int)spnLogFileSaveTime.Value;
            m_cProject.OpcConfig.UpdateRate = (int)spnUpdateRate.Value;
            m_cProject.Name = txtProjectName.Text;
            if (m_cProject.OpcConfig.ServerName != cmbServerList.SelectedItem.ToString())
                m_cProject.OpcConfig.ServerName = cmbServerList.SelectedItem.ToString();

            if (m_cProject.OpcConfig.ChannelDevice != cmbChannelList.SelectedItem.ToString())
            {
                m_cProject.OpcConfig.ChannelDevice = cmbChannelList.SelectedItem.ToString();
                ChangeChannel();
            }
            if (m_cProject.OpcConfig.ServerName == "" || m_cProject.OpcConfig.ChannelDevice == "")
            {
                MessageBox.Show("설정이 없습니다.");
                e.Cancel = true;
            }
        }

        private void FrmOpcConfig_Load(object sender, EventArgs e)
        {
            spnUpdateRate.Value = m_cProject.OpcConfig.UpdateRate;

            txtLogPath.Text = m_cProject.SaveLogPath;
            spnLogFileSaveTime.Value = m_cProject.SaveLogFileTime;
            txtProjectName.Text = m_cProject.Name;
            if (m_cProject.OpcConfig.LsOpc)
            {
                if (m_cProject.OpcConfig.ChannelDevice == "")
                {
                    cmbChannelList.Properties.Items.Clear();
                    cmbChannelList.Properties.Items.Add(m_cProject.OpcConfig.ChannelDevice);
                    cmbChannelList.SelectedIndex = 0;
                }
            }
            GetServerList();
            //GetOPCChannelList();
            ShowServerList();
        }

        private void cmbServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServerList.SelectedIndex == -1) return;

            string sSelectServer = cmbServerList.SelectedItem.ToString();
            if (m_dicChannel.ContainsKey(sSelectServer) == false)
            {
                COPCServer cOPCServer = new COPCServer();
                List<string> lstChannel = cOPCServer.GetChannelList(sSelectServer);

                cOPCServer.Dispose();
                cOPCServer = null;
                m_dicChannel.Add(sSelectServer, lstChannel);
            }

            if (m_cProject.OpcConfig.LsOpc)
            {
                if (m_cProject.OpcConfig.ServerName != sSelectServer)
                    m_cProject.OpcConfig.ChannelDevice = "";
                if (m_cProject.OpcConfig.ChannelDevice == "")
                {
                    FrmInputDialog frmInput = new FrmInputDialog("Input Device", "연결할 Device를 입력하세요");
                    frmInput.ShowDialog();
                    if (frmInput.InputText != "")
                    {
                        cmbChannelList.Properties.Items.Clear();
                        cmbChannelList.Properties.Items.Add(frmInput.InputText);
                        cmbChannelList.SelectedIndex = 0;
                    }
                }
                else
                    cmbChannelList.SelectedIndex = 0;
            }
            else
                ShowDeviceList(sSelectServer);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = new COPCConfig();
            cOPCServer.Config.ServerName = cmbServerList.SelectedItem.ToString();
            cOPCServer.Config.ChannelDevice = cmbChannelList.SelectedItem.ToString();
            cOPCServer.Config.UpdateRate = (int)spnUpdateRate.Value;

            cOPCServer.Config.Use = true;

            bool bOK = cOPCServer.Connect();
            if (bOK == false)
                MessageBox.Show("연결실패");
            else
                MessageBox.Show("연결성공");
        }
    }
}