using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Monitor.Plc.Source.OPC;

namespace UDMTracker
{
	public partial class FrmOPCProperty : Form
	{

		#region Member Variables

		protected COPCConfig m_cOPCConfig = null;

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

			m_cOPCConfig.ServerName = cOPCConfigView.ServerName;
			m_cOPCConfig.UpdateRate = cOPCConfigView.UpdateRate;
		}

		#endregion


		#region Event Methods

		private void FrmOPCProperty_Load(object sender, EventArgs e)
		{
			ucOPCProperty.OPCConfig = m_cOPCConfig;
			ucOPCProperty.ShowProperty();
		}

		#endregion

		private void btnOK_Click(object sender, EventArgs e)
		{
            if (ucOPCProperty.OPCConfig.ChannelDevice == "")
                ucOPCProperty.OPCConfig.ChannelDevice = "DV9:";

            ucOPCProperty.OPCConfig.Use = true;
			ApplyOPCConfigProperty(ucOPCProperty.OPCConfig);

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
