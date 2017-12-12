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
	public partial class FrmMainBak6 : Form
	{
		public FrmMainBak6()
		{
			InitializeComponent();
			// Handling the QueryControl event that will populate all automatically generated Documents
			this.widgetView1.QueryControl += widgetView1_QueryControl;
		}

		// Assigning a required content for each auto generated Document
		
		// Assigning a required content for each auto generated Document
		

		// Assigning a required content for each auto generated Document
		void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
		{

			if (e.Document == uCCurrentInfoDocument)
				e.Control = new UExpression.UserControls.UCCurrentInfo();
			if (e.Document == uCMonitorStateDocument)
				e.Control = new UExpression.UCMonitorState();
			if (e.Document == uCClockDocument)
				e.Control = new UExpression.UCClock();
			if (e.Control == null)
				e.Control = new System.Windows.Forms.Control();
		}
	}
}
