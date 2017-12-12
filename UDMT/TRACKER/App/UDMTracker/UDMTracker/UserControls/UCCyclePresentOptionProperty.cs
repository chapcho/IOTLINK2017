using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTracker
{
	public partial class UCCyclePresentOptionProperty : DevExpress.XtraEditors.XtraUserControl
	{

		#region Member Variables

		private CCyclePresentOption m_cOption = null;

		#endregion


		#region Initialize/Dispose

		public UCCyclePresentOptionProperty()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public CCyclePresentOption Option
		{
			get { return m_cOption; }
			set { m_cOption = value; }
		}

		#endregion


		#region Pubilc Methods

		public void ShowProperty()
		{
			exProperty.SelectedObject = m_cOption;
			exProperty.Refresh();
		}

		public void Clear()
		{

		}

		public void SetUseFilterEditable(bool bEditable)
		{
			rowUseFilter.Properties.ReadOnly = !bEditable;
		}

		public void SetUseFistActiveEditable(bool bEditable)
		{
			rowUseFirstActive.Properties.ReadOnly = !bEditable;
		}

		public void SetMinimumActiveCountEditable(bool bEditable)
		{
			rowMinimumActiveCount.Properties.ReadOnly = !bEditable;
		}

		public void SetMinimumLogCountEditable(bool bEditable)
		{
			rowMinimumLogCount.Properties.ReadOnly = !bEditable;
		}

		#endregion


		#region Private Methods


		#endregion


		#region Event Methdos

		private void UCCyclePresentOptionProperty_Load(object sender, EventArgs e)
		{

		}

		#endregion
	}
}
