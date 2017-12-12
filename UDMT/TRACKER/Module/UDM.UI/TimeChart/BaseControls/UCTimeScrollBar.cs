using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCTimeScrollBar : Panel
	{

		#region Member Varaibles

		protected UCTimeLine m_ucTimeLine = null;

		#endregion


		#region Initialize/Dispose

		public UCTimeScrollBar()
		{
			InitializeComponent();
			InitVariables();
		}

		public UCTimeScrollBar(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			InitVariables();
		}

		#endregion


		#region Public Properties

		public UCTimeLine TimeLine
		{
			get { return m_ucTimeLine; }
			set { SetTimeLine(value); }
		}

		#endregion


		#region Public Methods

		public new void BeginUpdate()
		{

		}

		public new void EndUpdate()
		{
			UpdateLayout();
		}

		public void UpdateLayout()
		{
			this.Refresh();
		}

		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{

		}

		protected void SetTimeLine(UCTimeLine ucTimeLine)
		{
			if (m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventTimeScrollChanged -= m_ucTimeLine_UEventTimeScrollChanged;
			}

			m_ucTimeLine = ucTimeLine;
			if(m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventTimeScrollChanged += m_ucTimeLine_UEventTimeScrollChanged;
			}
		}

		#endregion

		#region Util


		#endregion

		#region Drawing

		protected void DrawLayout(Graphics g)
		{
			g.DrawRectangle(Pens.Gray, 0, 0, this.Width - 1, this.Height - 1);
		}

		#endregion

		#endregion


		#region Event Methods

		#region Override

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		#endregion

		#region Others

		protected void m_ucTimeLine_UEventTimeScrollChanged(object sender)
		{
			scbRange.BeginUpdate();
			{
				scbRange.Maximum = m_ucTimeLine.ScrollMaxValue;
				scbRange.Minimum = m_ucTimeLine.ScrollMinValue;
				scbRange.LargeChange = m_ucTimeLine.ScrollLargeChange;
				scbRange.Value = m_ucTimeLine.ScrollValue;
			}
			scbRange.EndUpdate();
		}

		protected void scbRange_Scroll(object sender, ScrollEventArgs e)
		{
			if (m_ucTimeLine == null)
				return;

			m_ucTimeLine.ScrollValue = scbRange.Value;
		}

		#endregion

		#endregion
	}
}
