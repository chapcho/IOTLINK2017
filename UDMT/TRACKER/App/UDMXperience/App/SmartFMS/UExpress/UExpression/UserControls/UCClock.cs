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
	public partial class UCClock : DevExpress.XtraEditors.XtraUserControl
	{
		System.Globalization.CultureInfo m_cCulture = new System.Globalization.CultureInfo("en-US");

		public UCClock()
		{
			InitializeComponent();
		}

		private void UCClock_Load(object sender, EventArgs e)
		{
			DateTime dtNow = DateTime.Now;
			lblDate.Text = dtNow.ToString("yyyy/MM/dd(ddd)", m_cCulture).ToUpper();
			lblTime.Text = dtNow.ToString("HH:mm:ss");

			tmrTimer.Start();
		}

		private void tmrTimer_Tick(object sender, EventArgs e)
		{
			DateTime dtNow = DateTime.Now;
			lblDate.Text = dtNow.ToString("yyyy/MM/dd(ddd)", m_cCulture).ToUpper();
			lblTime.Text = dtNow.ToString("HH:mm:ss");

			lblDate.Refresh();
			lblTime.Refresh();
		}
		private void UCClock_Paint(object sender, PaintEventArgs e)
		{
			this.Dock = DockStyle.Fill;
		}
	}
}
