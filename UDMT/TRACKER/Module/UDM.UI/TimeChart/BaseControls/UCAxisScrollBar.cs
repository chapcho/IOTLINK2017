using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCAxisScrollBar : Panel
	{
		
		#region Member Varaibles

		protected UCSeriesChart m_ucSeriesChart = null;

		#endregion


		#region Initalize/Dispose

		public UCAxisScrollBar()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCAxisScrollBar(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public UCSeriesChart SeriesChart
		{
			get { return m_ucSeriesChart; }
			set { SetItemTree(value);}
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{

		}

		protected void SetItemTree(UCSeriesChart ucSeriesChart)
		{
			if (m_ucSeriesChart != null)
			{
				m_ucSeriesChart.UEventAxisScrollChanged -= m_ucSeriesChart_UEventAxisScrollChanged;
			}

			m_ucSeriesChart = ucSeriesChart;
			if (m_ucSeriesChart != null)
			{
				m_ucSeriesChart.UEventAxisScrollChanged += m_ucSeriesChart_UEventAxisScrollChanged;
			}
		}

		#endregion

		#region Util


		#endregion

		#endregion


		#region Event Methods

		protected void m_ucSeriesChart_UEventAxisScrollChanged(object sender)
		{
			if (m_ucSeriesChart == null || m_ucSeriesChart.Axis == null)
				return;

			
			scbItem.BeginUpdate();
			{
				scbItem.Maximum = m_ucSeriesChart.AxisScrollMaxValue;;
				scbItem.Minimum = m_ucSeriesChart.AxisScrollMinValue;
				scbItem.LargeChange = m_ucSeriesChart.AxisScrollLargeChange;
				scbItem.Value = scbItem.Maximum - m_ucSeriesChart.AxisScrollValue;
			}
			scbItem.EndUpdate();
		}

		protected void scbItem_Scroll(object sender, ScrollEventArgs e)
		{
			if (m_ucSeriesChart == null)
				return;

			m_ucSeriesChart.AxisScrollValue = scbItem.Maximum - scbItem.Value;
		}

		#endregion
	}
}
