﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrackerSPD.OPC;

namespace UDMTrackerSimple
{
	public partial class FrmOPCProperty : Form
	{

		#region Member Variables

		protected COPCConfig m_cOPCConfig = null;
        protected bool isChanged = false;

		#endregion


		#region Intialize/Dispose

		public FrmOPCProperty()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public bool Editable
		{
			get { return ucOPCProperty.Editable; }
			set { ucOPCProperty.Editable = value; }
		}

		public COPCConfig OPCConfig
		{
			get { return m_cOPCConfig; }
			set { m_cOPCConfig = value; }
		}

        public bool IsChanged
        {
            get { return isChanged; }
            set { isChanged = value; }
        }
		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		protected COPCConfig CreateViewOPCConfigProperty(COPCConfig cOPCConfig)
		{
			COPCConfig cOPCConfigView = new COPCConfig();
			if (cOPCConfig == null)
				return cOPCConfigView;

			cOPCConfigView.ServerName = cOPCConfig.ServerName;
			cOPCConfigView.UpdateRate = cOPCConfig.UpdateRate;

			return cOPCConfigView;
		}

		protected void ApplyOPCConfigProperty(COPCConfig cOPCConfigView)
		{
			if (m_cOPCConfig == null || cOPCConfigView == null)
				return;

            // OPC Config 변경시
            if (m_cOPCConfig.ServerName != cOPCConfigView.ServerName || m_cOPCConfig.ChannelDevice != cOPCConfigView.ChannelDevice)
            {
                isChanged = true;
            }

			m_cOPCConfig.ServerName = cOPCConfigView.ServerName;
            m_cOPCConfig.ChannelDevice = cOPCConfigView.ChannelDevice;
			m_cOPCConfig.UpdateRate = cOPCConfigView.UpdateRate;
		}

		#endregion


		#region Event Methods

		private void FrmOPCProperty_Load(object sender, EventArgs e)
		{
			ucOPCProperty.OPCConfig = m_cOPCConfig;
			ucOPCProperty.ShowProperty();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			ApplyOPCConfigProperty(ucOPCProperty.OPCConfig);

		    if (ucOPCProperty.OPCConfig.ChannelDevice == string.Empty && ( m_cOPCConfig.LsOpc || m_cOPCConfig.ABOpc))
		    {
                FrmInputDialog frmView = new FrmInputDialog("OPC Channel Device", "Channel Device를 입력하세요.");
		        frmView.ShowDialog();

		        string sChannel = frmView.InputText;
                m_cOPCConfig.ChannelDevice = sChannel;
		    }

		    this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void FrmOPCProperty_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucOPCProperty.OPCServerClear();
        }

        #endregion

	}
}
