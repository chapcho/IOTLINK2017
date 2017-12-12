namespace UDMTracker
{
	partial class FrmDailyReport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraCharts.SimpleDiagram simpleDiagram1 = new DevExpress.XtraCharts.SimpleDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
			DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("Normal Count", new object[] {
            ((object)(19D))}, 0);
			DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("Error Count", new object[] {
            ((object)(4D))}, 1);
			DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView(new int[0]);
			DevExpress.XtraCharts.SeriesTitle seriesTitle1 = new DevExpress.XtraCharts.SeriesTitle();
			DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
			DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("Normal Count", new object[] {
            ((object)(16D))}, 0);
			DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("Error Count", new object[] {
            ((object)(2D))}, 1);
			DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
			DevExpress.XtraCharts.SeriesTitle seriesTitle2 = new DevExpress.XtraCharts.SeriesTitle();
			DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel3 = new DevExpress.XtraCharts.PieSeriesLabel();
			DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("Normal Count", new object[] {
            ((object)(64D))}, 0);
			DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("Error Count", new object[] {
            ((object)(23D))}, 1);
			DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
			DevExpress.XtraCharts.SeriesTitle seriesTitle3 = new DevExpress.XtraCharts.SeriesTitle();
			DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel4 = new DevExpress.XtraCharts.PieSeriesLabel();
			DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("Normal Count", new object[] {
            ((object)(16D))}, 0);
			DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("Error Count", new object[] {
            ((object)(8D))}, 1);
			DevExpress.XtraCharts.PieSeriesView pieSeriesView4 = new DevExpress.XtraCharts.PieSeriesView();
			DevExpress.XtraCharts.SeriesTitle seriesTitle4 = new DevExpress.XtraCharts.SeriesTitle();
			DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel5 = new DevExpress.XtraCharts.PieSeriesLabel();
			DevExpress.XtraCharts.PieSeriesView pieSeriesView5 = new DevExpress.XtraCharts.PieSeriesView();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.xrDetailHeader = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.xrDate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrGroup1 = new DevExpress.XtraReports.UI.XRChart();
			((System.ComponentModel.ISupportInitialize)(this.xrGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrGroup1,
            this.xrDetailHeader,
            this.xrDate,
            this.xrLine1});
			this.Detail.HeightF = 1200F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 100F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 100F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.StylePriority.UseBorderColor = false;
			this.BottomMargin.StylePriority.UseForeColor = false;
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// xrDetailHeader
			// 
			this.xrDetailHeader.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold);
			this.xrDetailHeader.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.xrDetailHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrDetailHeader.Name = "xrDetailHeader";
			this.xrDetailHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrDetailHeader.SizeF = new System.Drawing.SizeF(246.875F, 50F);
			this.xrDetailHeader.StylePriority.UseFont = false;
			this.xrDetailHeader.StylePriority.UseForeColor = false;
			this.xrDetailHeader.Text = "Summary";
			// 
			// xrLine1
			// 
			this.xrLine1.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.xrLine1.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 19.95834F);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new System.Drawing.SizeF(626.9999F, 26.04166F);
			this.xrLine1.StylePriority.UseBorderColor = false;
			this.xrLine1.StylePriority.UseForeColor = false;
			// 
			// xrDate
			// 
			this.xrDate.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.xrDate.LocationFloat = new DevExpress.Utils.PointFloat(450.8928F, 17.95832F);
			this.xrDate.Name = "xrDate";
			this.xrDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrDate.SizeF = new System.Drawing.SizeF(176.1071F, 24.55357F);
			this.xrDate.StylePriority.UseForeColor = false;
			this.xrDate.Text = "2015.08.26 06:00 - 27 05:00";
			// 
			// xrGroup1
			// 
			this.xrGroup1.BorderColor = System.Drawing.Color.Black;
			this.xrGroup1.Borders = DevExpress.XtraPrinting.BorderSide.None;
			simpleDiagram1.Dimension = 2;
			simpleDiagram1.EqualPieSize = true;
			simpleDiagram1.LayoutDirection = DevExpress.XtraCharts.LayoutDirection.Vertical;
			this.xrGroup1.Diagram = simpleDiagram1;
			this.xrGroup1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
			this.xrGroup1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
			this.xrGroup1.Legend.EquallySpacedItems = false;
			this.xrGroup1.Legend.UseCheckBoxes = true;
			this.xrGroup1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.xrGroup1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.45454F);
			this.xrGroup1.Name = "xrGroup1";
			pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
			pieSeriesLabel1.TextPattern = "{A}[{V}] : {VP:0.00%}";
			series1.Label = pieSeriesLabel1;
			series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
			series1.Name = "Group1";
			series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2});
			pieSeriesView1.ExplodeMode = DevExpress.XtraCharts.PieExplodeMode.UsePoints;
			pieSeriesView1.RuntimeExploding = false;
			pieSeriesView1.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
			pieSeriesView1.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle1});
			series1.View = pieSeriesView1;
			pieSeriesLabel2.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
			pieSeriesLabel2.TextPattern = "{A}[{V}] : {VP:0.00%}";
			series2.Label = pieSeriesLabel2;
			series2.Name = "Group2";
			series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint3,
            seriesPoint4});
			pieSeriesView2.RuntimeExploding = false;
			pieSeriesView2.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
			pieSeriesView2.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle2});
			series2.View = pieSeriesView2;
			pieSeriesLabel3.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
			pieSeriesLabel3.TextPattern = "{A}[{V}] : {VP:0.00%}";
			series3.Label = pieSeriesLabel3;
			series3.Name = "Group3";
			series3.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint5,
            seriesPoint6});
			pieSeriesView3.RuntimeExploding = false;
			pieSeriesView3.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
			pieSeriesView3.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle3});
			series3.View = pieSeriesView3;
			pieSeriesLabel4.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
			pieSeriesLabel4.TextPattern = "{A}[{V}] : {VP:0.00%}";
			series4.Label = pieSeriesLabel4;
			series4.Name = "Group4";
			series4.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint7,
            seriesPoint8});
			pieSeriesView4.RuntimeExploding = false;
			pieSeriesView4.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
			pieSeriesView4.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle4});
			series4.View = pieSeriesView4;
			this.xrGroup1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
			pieSeriesLabel5.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
			this.xrGroup1.SeriesTemplate.Label = pieSeriesLabel5;
			pieSeriesView5.RuntimeExploding = false;
			pieSeriesView5.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
			this.xrGroup1.SeriesTemplate.View = pieSeriesView5;
			this.xrGroup1.SizeF = new System.Drawing.SizeF(626.9999F, 497.159F);
			// 
			// FrmDailyReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
			this.PageHeight = 1169;
			this.PageWidth = 827;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Version = "14.2";
			((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesLabel5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pieSeriesView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xrGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.XRLabel xrDate;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLabel xrDetailHeader;
		private DevExpress.XtraReports.UI.XRChart xrGroup1;
	}
}
