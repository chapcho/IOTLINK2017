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
	public partial class UCSample : UserControl
	{
		private DataTable m_dtSample = null;

		public DataTable Data
		{
			get { return m_dtSample; }
			set { m_dtSample = value; SetDataSource(value); }
		}

		public UCSample()
		{
			InitializeComponent();
		}

		private void SetDataSource(DataTable dtData)
		{
			this.gridControl1.DataSource = Data;
		}
	}
}
