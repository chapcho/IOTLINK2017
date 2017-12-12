using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDMTrackerSimple
{
	public partial class UCCircleGauge2Row : UserControl
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public UCCircleGauge2Row()
		{
			InitializeComponent();

            exGauge.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblTitle.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblTopText.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblTopCaption.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblBottomCaption.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblBottomText.MouseWheel += new MouseEventHandler(All_MouseWheel);
            pnlDetail.MouseWheel += new MouseEventHandler(All_MouseWheel);
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

		public string TopLabelCaption
		{
			get { return lblTopCaption.Text; }
			set { lblTopCaption.Text = value; }
		}

		public string TopLabelText
		{
			get { return lblTopText.Text; }
			set { lblTopText.Text = value; }
		}

		public string BottomLabelCaption
		{
			get { return lblBottomCaption.Text; }
			set { lblBottomCaption.Text = value; }
		}

		public string BottomLabelText
		{
			get { return lblBottomText.Text; }
			set { lblBottomText.Text = value; }
		}

		public float MaxValue
		{
			get { return exBaseRange.MaxValue; }
			set { exBaseRange.MaxValue = value; }
		}

		public float Value
		{
			get { return exBaseRange.Value; }
			set { exBaseRange.Value = value; }
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

		private void UCCircleGauge2_Load(object sender, EventArgs e)
		{
		    try
		    {
		        OnResize(null);
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

		protected override void OnResize(EventArgs e)
		{
		    try
		    {
		        base.OnResize(e);

		        pnlDetail.Width = this.Width/2;
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

		private void pnlDetail_Resize(object sender, EventArgs e)
		{
		    try
		    {
		        float nSize = (pnlDetail.Width > pnlDetail.Height) ? pnlDetail.Height : pnlDetail.Width;
		        FontFamily fontFamily = lblTopCaption.Font.FontFamily;
		        float nFontSize = (float) nSize/100f;
		        if (nFontSize < 0.1f)
		            nFontSize = 0.1f;

		        Font fontCaption = new Font(fontFamily, nFontSize*8.25f, FontStyle.Bold);
		        Font fontValue = new Font(fontFamily, nFontSize*11.25f, FontStyle.Bold);
		        lblTitle.Font = fontCaption;
		        lblTopCaption.Font = fontCaption;
		        lblBottomCaption.Font = fontCaption;

		        lblTopText.Font = fontValue;
		        lblBottomText.Font = fontValue;
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

	    private void All_MouseDown(object sender, MouseEventArgs e)
	    {
	        try
	        {
	            base.OnMouseDown(e);
	        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
	    }

        private void All_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

	    private void All_MouseUp(object sender, MouseEventArgs e)
	    {
	        try
	        {
	            base.OnMouseUp(e);
	        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
	    }

        private void All_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseWheel(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

		#endregion

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblBottomText_Click(object sender, EventArgs e)
        {

        }

        private void lblBottomCaption_Click(object sender, EventArgs e)
        {

        }
	}
}
