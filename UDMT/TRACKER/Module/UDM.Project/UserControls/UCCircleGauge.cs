using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.Project
{
	public partial class UCCircleGauge : UserControl
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public UCCircleGauge()
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

		public string CircleText
		{
			get { return exLabel.Text; }
			set { exLabel.Text = value; }
		}

		public float MaxValue
		{
			get { return exBaseRange.MaxValue; }
			set { exBaseRange.MaxValue = value; }
		}

		public float Value
		{
			get { return exBaseRange.Value; }
			set { exBaseRange.MaxValue = value; }
		}
		
		public Color MaxBarColor
		{
			get { return ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)(exRangeBar.AppearanceRangeBar.BackgroundBrush)).Color; }
			set { ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)(exRangeBar.AppearanceRangeBar.BackgroundBrush)).Color = value; }
		}

		public Color ValueBarColor
		{
			get { return ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)(exRangeBar.AppearanceRangeBar.ContentBrush)).Color; }
			set { ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)(exRangeBar.AppearanceRangeBar.ContentBrush)).Color = value; }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods


		#endregion


		#region Event Methods

		private void UCCircleGauge_Load(object sender, EventArgs e)
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
