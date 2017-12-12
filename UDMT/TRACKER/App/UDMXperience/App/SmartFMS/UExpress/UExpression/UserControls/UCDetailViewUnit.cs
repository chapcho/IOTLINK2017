using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UExpression
{
	public partial class UCDetailViewUnit : UserControl
	{
		#region Member Variables
		private string m_sName = string.Empty;
		#endregion

		#region Properties
		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}
		#endregion

		#region Initialize/Dispose
		public UCDetailViewUnit()
		{
			InitializeComponent();
		}
		#endregion

		private void UCDetailViewUnit_Paint(object sender, PaintEventArgs e)
		{

		}

		#region Public Methods
		#endregion

		#region Private Methods
		#endregion
	}
}
