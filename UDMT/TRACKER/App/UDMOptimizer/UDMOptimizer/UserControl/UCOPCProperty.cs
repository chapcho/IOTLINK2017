using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrackerSPD.OPC;


namespace UDMOptimizer
{
	public partial class UCOPCProperty : UserControl
	{

		#region Member Variables

		protected bool m_bEditable = false;
		protected COPCConfig m_cOPCConfig = null;
        protected string m_sSelectedServer = "";
        Dictionary<string, List<string>> m_dicChannel = new Dictionary<string, List<string>>();
        protected COPCServer m_cOPCServer = new COPCServer();
		#endregion


		#region Initialize/Dispose

		public UCOPCProperty()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public bool Editable
		{
			get { return m_bEditable; }
			set { SetEditable(value); }
		}

		public COPCConfig OPCConfig
		{
			get { return m_cOPCConfig; }
			set { m_cOPCConfig = value; }
		}

		#endregion


		#region Public Methods

		public void ShowProperty()
		{
			//Clear();
            if (m_cOPCConfig.ServerName != "")
                m_sSelectedServer = m_cOPCConfig.ServerName;
            
			List<string> lstServer = GetOPCServerList();
			cmbServerList.Properties.Items.Clear();
            int iServerIndex = -1;
            for (int i = 0; i < lstServer.Count; i++)
            {
                if (lstServer[i] == m_sSelectedServer && m_sSelectedServer != "")
                    iServerIndex = i;

                if (!cmbServerList.Properties.Items.Contains(lstServer[i]))
                    cmbServerList.Properties.Items.Add(lstServer[i]);
            }
            cmbServerList.SelectedIndex = iServerIndex;
            if (iServerIndex != -1)
                GetOPCDeviceList(m_sSelectedServer);
			if (lstServer.Contains(m_cOPCConfig.ServerName) == false)
				m_cOPCConfig.ServerName = "";

			exProperty.SelectedObject = m_cOPCConfig;
			if (m_cOPCConfig == null)
				return;

			exProperty.Refresh();
		}

		public void Clear()
		{
			m_cOPCConfig = null;

			exProperty.SelectedObject = null;

			exProperty.Refresh();
		}

        public void OPCServerClear()
        {
            if (m_cOPCServer == null) return;
            m_cOPCServer.Dispose();
            m_cOPCServer = null;

        }

		#endregion


		#region Private Methods

		protected void SetEditable(bool bEditable)
		{
			m_bEditable = bEditable;
			
			exProperty.Enabled = bEditable;
		}

		protected List<string> GetOPCServerList()
		{
			List<string> lstServer = m_cOPCServer.GetOPCServerList();
            if (lstServer.Count == 0)
                MessageBox.Show("설치된 OPC Server가 없습니다.", "OPC Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);

            for (int i = 0; i < lstServer.Count; i++)
            {
                if(!m_dicChannel.ContainsKey(lstServer[i]))
                    m_dicChannel.Add(lstServer[i], new List<string>());
            }
			return lstServer;
		}

        protected List<string> GetOPCDeviceList(string sServer)
        {
            List<string> lstDevice = new List<string>();

            if (m_dicChannel.ContainsKey(sServer) == false)
                return null;

            if (m_dicChannel[sServer].Count == 0)
            {
                lstDevice = m_cOPCServer.GetChannelList(sServer);

                if (lstDevice.Count == 0 || m_dicChannel[sServer] == null)
                    return null;

                m_dicChannel[sServer] = lstDevice;
            }
            else
                lstDevice = m_dicChannel[sServer];

            cmbChannelList.Properties.Items.Clear();
            int iChannelIndex = -1;
            for (int i = 0; i < lstDevice.Count; i++)
            {
                if (m_cOPCConfig.ChannelDevice != "" && m_cOPCConfig.ChannelDevice == lstDevice[i])
                    iChannelIndex = i;
                cmbChannelList.Properties.Items.Add(lstDevice[i]);
            }
            cmbChannelList.SelectedIndex = iChannelIndex;
            return lstDevice;
        }

		#endregion


		#region Event Methods

		private void UCOPCConfig_Load(object sender, EventArgs e)
		{
            
		}

		#endregion
        
        private void exEditorOPCServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void exEditorChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_sSelectedServer = cmbServerList.SelectedItem.ToString();

            cmbChannelList.Properties.Items.Clear();

            GetOPCDeviceList(m_sSelectedServer);
            m_cOPCConfig.ServerName = m_sSelectedServer;
        }

        private void cmbChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChannelList.SelectedIndex == -1) return;
            //if (m_cOPCConfig.LsOpc) return;
            string sChannel = cmbChannelList.SelectedItem.ToString();

            if (m_dicChannel.ContainsKey(m_sSelectedServer))
            {
                if (m_dicChannel[m_sSelectedServer].Contains(sChannel))
                    m_cOPCConfig.ChannelDevice = sChannel;
                else
                    m_cOPCConfig.ChannelDevice = "";
            }
            else
            {
                MessageBox.Show("OPC Server를 찾을 수 없습니다.", "OPC Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_cOPCConfig.ChannelDevice = "";
            }
        }
	}
}
