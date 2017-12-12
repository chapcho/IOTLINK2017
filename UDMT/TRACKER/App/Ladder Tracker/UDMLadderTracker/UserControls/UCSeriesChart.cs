using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace UDMLadderTracker
{
	public partial class UCSeriesChart : UserControl
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public UCSeriesChart()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public string TitleText
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		#endregion


		#region Public Methods

		public void AddPoint(double nValue, Color cColor, object oData)
		{

			try
			{
				if (exChart.Series[0].Points.Count > 9)
					exChart.Series[0].Points.RemoveAt(0);

				SeriesPoint exPoint = null;
				for (int i = 0; i < exChart.Series[0].Points.Count; i++)
				{
					exPoint = exChart.Series[0].Points[i];
					exPoint.NumericalArgument -= 1;
				}

				exPoint = new SeriesPoint(-1, nValue);
				exPoint.Tag = oData;
				exPoint.Color = cColor;
				exChart.Series[0].Points.Add(exPoint);
			}
			catch(System.Exception ex)
			{
				ex.Data.Clear();
			}

			exChart.Refresh();
		}

		public void Clear()
		{
			exChart.Series[0].Points.Clear();
		}
		
		#endregion


		#region Private Methods


		#endregion


		#region Event Methods

		private void UCBarChart_Load(object sender, EventArgs e)
		{

		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			float nSize = (pnlMain.Width > pnlMain.Height) ? pnlMain.Height : pnlMain.Width;
			FontFamily fontFamily = lblTitle.Font.FontFamily;
			float nFontSize = (float)nSize / 100f;
			if (nFontSize < 0.1f)
				nFontSize = 0.1f;

			Font fontCaption = new Font(fontFamily, nFontSize * 8.25f, FontStyle.Bold);
			lblTitle.Font = fontCaption;
		}

		#endregion
	}
}
