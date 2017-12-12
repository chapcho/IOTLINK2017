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
	public partial class UCMonitorState : UserControl
	{
		#region Member Variables
		private int m_nOpacity = 100;

		#endregion

		#region Properties
		public int Opacity
		{
			get { return m_nOpacity; }
			set { m_nOpacity = value; SetOpacity(); }
		}
		#endregion

		#region Initalize/Dispose
		public UCMonitorState()
		{
			InitializeComponent();
		}
		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private void SetBackColor(Color bColor)
		{
			this.BackColor = Color.FromArgb(m_nOpacity, BackColor);
		}

		private void SetOpacity()
		{
			this.BackColor = Color.FromArgb(m_nOpacity, BackColor);
		}
		#endregion

		#region Events

		private void UCMonitorState_BackColorChanged(object sender, EventArgs e)
		{
			SetBackColor(DefaultBackColor);
		}
		#endregion
	}
}
