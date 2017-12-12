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

namespace UDMDDEA
{
    public partial class FrmOpcConfig : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        COPCConfig m_cOpcConfig = null;
        Dictionary<string, List<string>> m_dicChannel = new Dictionary<string, List<string>>();
        List<string> m_lstServer = new List<string>();

        #endregion


        #region Initialize

        public FrmOpcConfig(COPCConfig cOpcConfig)
        {
            InitializeComponent();
            m_cOpcConfig = cOpcConfig;
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

        protected void ShowDeviceList(string sServer)
        {
            cmbChannelList.Properties.Items.Clear();
            for (int i = 0; i < m_dicChannel[sServer].Count; i++)
                cmbChannelList.Properties.Items.Add(m_dicChannel[sServer][i]);

            if (m_lstServer.Contains(m_cOpcConfig.ServerName))
            {
                string sSeverName = m_cOpcConfig.ServerName;
                int iFind = m_dicChannel[sSeverName].Where(b => b == m_cOpcConfig.ChannelDevice).Count();

                cmbServerList.SelectedIndex = cmbServerList.Properties.Items.IndexOf(sSeverName);
                if (iFind > 0)
                    cmbChannelList.SelectedIndex = cmbChannelList.Properties.Items.IndexOf(m_cOpcConfig.ChannelDevice);
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
                MessageBox.Show("설치된 OPC Server가 없습니다.");
                this.Close();
            }

            for (int i =0; i<m_lstServer.Count; i++)
                cmbServerList.Properties.Items.Add(m_lstServer[i]);
            if (m_cOpcConfig.ServerName != "")
            {
                string sFind = m_lstServer.Find(b => b == m_cOpcConfig.ServerName);
                if(sFind == null || sFind == "")
                    cmbServerList.SelectedIndex = -1;
                else
                    cmbServerList.SelectedIndex = cmbServerList.Properties.Items.IndexOf(m_cOpcConfig.ServerName);
            }
            else
                cmbServerList.SelectedIndex = -1;
        }

        #endregion


        #region Form Event Method

        private void FrmOpcConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmbServerList.SelectedItem == null) return;
            if (cmbServerList.SelectedItem.ToString() == "") return;
            if (cmbChannelList.SelectedItem == null) return;

            m_cOpcConfig.UpdateRate = (int)spnUpdateRate.Value;

            if (m_cOpcConfig.ServerName != cmbServerList.SelectedItem.ToString())
                m_cOpcConfig.ServerName = cmbServerList.SelectedItem.ToString();

            if (m_cOpcConfig.ChannelDevice != cmbChannelList.SelectedItem.ToString())
                m_cOpcConfig.ChannelDevice = cmbChannelList.SelectedItem.ToString();
        }
        
        private void FrmOpcConfig_Load(object sender, EventArgs e)
        {
            spnUpdateRate.Value = m_cOpcConfig.UpdateRate;
                        
            GetServerList();

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

            ShowDeviceList(sSelectServer);
        }

        #endregion
    }
}