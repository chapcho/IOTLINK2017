namespace UDM.Project
{
	partial class UCSeriesChart
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
			DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
			this.pnlMain = new DevExpress.XtraEditors.PanelControl();
			this.exChart = new DevExpress.XtraCharts.ChartControl();
			this.lblTitle = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
			this.pnlMain.Appearance.Options.UseBackColor = true;
			this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlMain.Controls.Add(this.exChart);
			this.pnlMain.Controls.Add(this.lblTitle);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
			this.pnlMain.Size = new System.Drawing.Size(493, 257);
			this.pnlMain.TabIndex = 0;
			// 
			// exChart
			// 
			this.exChart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
			this.exChart.CrosshairOptions.ShowArgumentLine = false;
			xyDiagram1.AxisX.GridLines.Visible = true;
			xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
			xyDiagram1.AxisX.NumericScaleOptions.GridAlignment = DevExpress.XtraCharts.NumericGridAlignment.Custom;
			xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
			xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisX.VisualRange.Auto = false;
			xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
			xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "0";
			xyDiagram1.AxisX.VisualRange.MinValueSerializable = "-10";
			xyDiagram1.AxisX.VisualRange.SideMarginsValue = 0D;
			xyDiagram1.AxisX.WholeRange.Auto = false;
			xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
			xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "0";
			xyDiagram1.AxisX.WholeRange.MinValueSerializable = "-10";
			xyDiagram1.AxisX.WholeRange.SideMarginsValue = 0.5D;
			xyDiagram1.AxisY.ScaleBreakOptions.Style = DevExpress.XtraCharts.ScaleBreakStyle.Straight;
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.exChart.Diagram = xyDiagram1;
			this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exChart.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.exChart.Legend.MarkerVisible = false;
			this.exChart.Legend.TextVisible = false;
			this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.exChart.Location = new System.Drawing.Point(5, 5);
			this.exChart.Name = "exChart";
			this.exChart.PaletteBaseColorNumber = 1;
			this.exChart.PaletteName = "Optra";
			this.exChart.PaletteRepository.Add("Optra", new DevExpress.XtraCharts.Palette("Optra", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Lime, System.Drawing.Color.Lime)}));
			series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
			sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
			sideBySideBarSeriesLabel1.Indent = 5;
			sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
			sideBySideBarSeriesLabel1.ShowForZeroValues = true;
			sideBySideBarSeriesLabel1.TextPattern = "{V:0.00}";
			series1.Label = sideBySideBarSeriesLabel1;
			series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
			series1.Name = "exSeriesBar";
			sideBySideBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
			sideBySideBarSeriesView1.Color = System.Drawing.Color.YellowGreen;
			sideBySideBarSeriesView1.ColorEach = true;
			series1.View = sideBySideBarSeriesView1;
			this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.exChart.Size = new System.Drawing.Size(483, 239);
			this.exChart.TabIndex = 2;
			// 
			// lblTitle
			// 
			this.lblTitle.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblTitle.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblTitle.Location = new System.Drawing.Point(5, 244);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(483, 13);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Text = "Gauge Title";
			// 
			// UCSeriesChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlMain);
			this.Name = "UCSeriesChart";
			this.Size = new System.Drawing.Size(493, 257);
			this.Load += new System.EventHandler(this.UCBarChart_Load);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl pnlMain;
		private DevExpress.XtraCharts.ChartControl exChart;
		private DevExpress.XtraEditors.LabelControl lblTitle;
	}
}
