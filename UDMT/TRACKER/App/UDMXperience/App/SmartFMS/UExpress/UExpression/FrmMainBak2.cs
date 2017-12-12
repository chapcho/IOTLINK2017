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
	public partial class FrmMainBak2 : Form
	{
		public FrmMainBak2()
		{
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{

			Color colorTransparent = Color.FromArgb(100, Color.White);
			panel2.BackColor = colorTransparent;
			panel3.BackColor = colorTransparent;
			panel4.BackColor = colorTransparent;

			Color MonitorColor = Color.FromArgb(100, label7.BackColor);
			label7.BackColor = MonitorColor;
			panel5.BackColor = MonitorColor;

			//circular 값 변경
			circularGauge1.RangeBars["devConsumptionBar"].ArcScale.MaxValue = 1111;
			circularGauge1.RangeBars["devConsumptionBar"].Value = 90;
			circularGauge1.Labels["lblConsumption"].Text = "90";
			
		}
	}
}
