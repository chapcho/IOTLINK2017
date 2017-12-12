namespace UDM.Project
{
	partial class UCGroupStateChartUnit
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
			this.exChart = new DevExpress.XtraCharts.ChartControl();
			this.pnlTitle = new DevExpress.XtraEditors.PanelControl();
			this.lblStatus = new DevExpress.XtraEditors.LabelControl();
			this.pnlSplitter = new System.Windows.Forms.Panel();
			this.txtCycleTime = new DevExpress.XtraEditors.TextEdit();
			this.lblGroupName = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTitle)).BeginInit();
			this.pnlTitle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtCycleTime.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// exChart
			// 
			this.exChart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
			this.exChart.CrosshairOptions.ShowArgumentLine = false;
			xyDiagram1.AxisX.GridLines.Visible = true;
			xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
			xyDiagram1.AxisX.NumericScaleOptions.GridAlignment = DevExpress.XtraCharts.NumericGridAlignment.Custom;
			xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisX.VisualRange.Auto = false;
			xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
			xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "1";
			xyDiagram1.AxisX.VisualRange.MinValueSerializable = "-10";
			xyDiagram1.AxisX.VisualRange.SideMarginsValue = 0D;
			xyDiagram1.AxisX.WholeRange.Auto = false;
			xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
			xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "1";
			xyDiagram1.AxisX.WholeRange.MinValueSerializable = "-10";
			xyDiagram1.AxisX.WholeRange.SideMarginsValue = 0D;
			xyDiagram1.AxisY.ScaleBreakOptions.Style = DevExpress.XtraCharts.ScaleBreakStyle.Straight;
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.exChart.Diagram = xyDiagram1;
			this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exChart.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.exChart.Legend.MarkerVisible = false;
			this.exChart.Legend.TextVisible = false;
			this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.exChart.Location = new System.Drawing.Point(0, 27);
			this.exChart.Name = "exChart";
			this.exChart.PaletteBaseColorNumber = 1;
			this.exChart.PaletteName = "Optra";
			this.exChart.PaletteRepository.Add("Optra", new DevExpress.XtraCharts.Palette("Optra", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Lime, System.Drawing.Color.Lime)}));
			sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
			sideBySideBarSeriesLabel1.Indent = 5;
			sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
			sideBySideBarSeriesLabel1.ShowForZeroValues = true;
			sideBySideBarSeriesLabel1.TextPattern = "{V:0.00}";
			series1.Label = sideBySideBarSeriesLabel1;
			series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
			series1.Name = "Series1";
			sideBySideBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
			sideBySideBarSeriesView1.ColorEach = true;
			series1.View = sideBySideBarSeriesView1;
			this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.exChart.Size = new System.Drawing.Size(479, 223);
			this.exChart.TabIndex = 1;
			this.exChart.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.exChart_ObjectSelected);
			this.exChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.exChart_CustomDrawSeriesPoint);
			// 
			// pnlTitle
			// 
			this.pnlTitle.Appearance.BackColor = System.Drawing.Color.White;
			this.pnlTitle.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
			this.pnlTitle.Appearance.BorderColor = System.Drawing.Color.White;
			this.pnlTitle.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.pnlTitle.Appearance.Options.UseBackColor = true;
			this.pnlTitle.Appearance.Options.UseBorderColor = true;
			this.pnlTitle.Controls.Add(this.lblStatus);
			this.pnlTitle.Controls.Add(this.pnlSplitter);
			this.pnlTitle.Controls.Add(this.txtCycleTime);
			this.pnlTitle.Controls.Add(this.lblGroupName);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this.pnlTitle.LookAndFeel.UseDefaultLookAndFeel = false;
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Padding = new System.Windows.Forms.Padding(5, 2, 5, 3);
			this.pnlTitle.Size = new System.Drawing.Size(479, 27);
			this.pnlTitle.TabIndex = 6;
			// 
			// lblStatus
			// 
			this.lblStatus.Appearance.BackColor = System.Drawing.Color.Silver;
			this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblStatus.Location = new System.Drawing.Point(360, 5);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(50, 16);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "WAIT";
			// 
			// pnlSplitter
			// 
			this.pnlSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlSplitter.Location = new System.Drawing.Point(410, 5);
			this.pnlSplitter.Name = "pnlSplitter";
			this.pnlSplitter.Size = new System.Drawing.Size(2, 16);
			this.pnlSplitter.TabIndex = 3;
			// 
			// txtCycleTime
			// 
			this.txtCycleTime.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtCycleTime.EditValue = "0.00";
			this.txtCycleTime.Location = new System.Drawing.Point(412, 5);
			this.txtCycleTime.Name = "txtCycleTime";
			this.txtCycleTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.txtCycleTime.Properties.Appearance.Options.UseFont = true;
			this.txtCycleTime.Properties.Appearance.Options.UseTextOptions = true;
			this.txtCycleTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtCycleTime.Properties.ReadOnly = true;
			this.txtCycleTime.Size = new System.Drawing.Size(59, 22);
			this.txtCycleTime.TabIndex = 1;
			// 
			// lblGroupName
			// 
			this.lblGroupName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.lblGroupName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblGroupName.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblGroupName.Location = new System.Drawing.Point(8, 5);
			this.lblGroupName.Name = "lblGroupName";
			this.lblGroupName.Size = new System.Drawing.Size(94, 16);
			this.lblGroupName.TabIndex = 0;
			this.lblGroupName.Text = "S141";
			// 
			// UCGroupStateChartUnit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exChart);
			this.Controls.Add(this.pnlTitle);
			this.Name = "UCGroupStateChartUnit";
			this.Size = new System.Drawing.Size(479, 250);
			this.Load += new System.EventHandler(this.UCGroupStateChartUnit_Load);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTitle)).EndInit();
			this.pnlTitle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtCycleTime.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraCharts.ChartControl exChart;
		private DevExpress.XtraEditors.PanelControl pnlTitle;
		private DevExpress.XtraEditors.LabelControl lblGroupName;
		private DevExpress.XtraEditors.LabelControl lblStatus;
		private DevExpress.XtraEditors.TextEdit txtCycleTime;
		private System.Windows.Forms.Panel pnlSplitter;
	}
}
