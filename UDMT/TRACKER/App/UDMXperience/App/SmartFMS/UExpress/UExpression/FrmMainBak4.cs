using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UExpression
{
	public partial class FrmMainBak4 : Form
	{
		public FrmMainBak4()
		{
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			DataTable dtTmp = new DataTable("Temp");
			dtTmp.Columns.Add("col2");
			dtTmp.Columns.Add("col3");
			dtTmp.Columns.Add("col4");
			dtTmp.Columns.Add("col5");

			for (int i = 0; i < 5; i++)
			{
				DataRow dtRow = dtTmp.NewRow();
				dtRow["col2"] = "Line" + (i + 1);
				dtRow["col3"] = "12" + i;
				dtRow["col4"] = "21" + i;
				dtRow["col5"] = "43" + i;

				dtTmp.Rows.Add(dtRow);
			}

			dtTmp.AcceptChanges();

			gridControl1.DataSource = dtTmp;
		}
	}
}
