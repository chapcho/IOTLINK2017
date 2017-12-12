using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.Tile;

namespace UDMTracker
{
	public partial class FrmTileItemDetailView : Form
	{
		#region Member Variables
		protected CGroupInfoS m_cGroupInfoS = null;
		protected bool m_bSingleButton = false;
		private UCTileItemDetailView m_ucDetailView = new UCTileItemDetailView();
		protected string m_sItemName = string.Empty;
		#endregion

		#region Properties
		public CGroupInfoS GroupInfoS
		{
			get { return m_cGroupInfoS; }
			set { m_cGroupInfoS = value; }
		}

		public bool IsSingleButton
		{
			get { return m_bSingleButton; }
			set { m_bSingleButton = value; }
		}

		public int RowCount
		{
			get { return this.RowCount; }
			set { this.RowCount = value; }
		}

		public string ItemName
		{
			get { return m_sItemName; }
			set { m_sItemName = value; }
		}

		public string btnText
		{
			get { return btnErr1.Text; }
			set { btnErr1.Text = value; }
		}
		#endregion

		#region Initialize/Dispose
		public FrmTileItemDetailView()
		{
			InitializeComponent();
		}

		#endregion

		#region Form Methods
		private void FrmDetailView_Load(object sender, System.EventArgs e)
		{
			ucTileItemDetailView.Hide();
			tblPanel.Dock = DockStyle.Fill;
			ChangeButtonText();

			m_ucDetailView.GroupInfo = GroupInfoS[ItemName];
		}
		#endregion

		private void btnErr1_Click(object sender, EventArgs e)
		{
			tblPanel.Hide();
			btnErr1.Hide();

			this.Controls.Add(m_ucDetailView);
			m_ucDetailView.DiagramOn = true;
			m_ucDetailView.Dock = DockStyle.Fill;
			m_ucDetailView.Show();
		}

		private void btnErr2_Click(object sender, EventArgs e)
		{
			tblPanel.Hide();
			btnErr1.Hide();

			this.Controls.Add(m_ucDetailView);
			m_ucDetailView.DiagramOn = true;
			m_ucDetailView.Dock = DockStyle.Fill;
			m_ucDetailView.Show();
		}

		#region Public Methods
		#endregion

		#region Private Methods
		private void ChangeButtonText()
		{
			string sMessage = string.Empty;


			sMessage = "신호지연";

			this.btnErr1.Text = sMessage;
		}
		#endregion
	}
}
