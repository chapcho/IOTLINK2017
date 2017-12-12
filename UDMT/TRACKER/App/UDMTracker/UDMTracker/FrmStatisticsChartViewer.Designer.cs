namespace UDMTracker
{
	partial class FrmStatisticsChartViewer
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatisticsChartViewer));
			this.exChart = new DevExpress.XtraCharts.ChartControl();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.ucCheckNavBarControl1 = new UDMTracker.UCCheckNavBarControl(this.components);
			this.grRecoveryTimeInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.itemRecoveryMean = new DevExpress.XtraNavBar.NavBarItem();
			this.itemRecoveryMin = new DevExpress.XtraNavBar.NavBarItem();
			this.itemRecoveryMax = new DevExpress.XtraNavBar.NavBarItem();
			this.grCycleTimeInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.itemCycleMean = new DevExpress.XtraNavBar.NavBarItem();
			this.itemCycleMin = new DevExpress.XtraNavBar.NavBarItem();
			this.itemCycleMax = new DevExpress.XtraNavBar.NavBarItem();
			this.itemCycleStd = new DevExpress.XtraNavBar.NavBarItem();
			this.itemCycleCp = new DevExpress.XtraNavBar.NavBarItem();
			this.itemCycleCpk = new DevExpress.XtraNavBar.NavBarItem();
			this.grIdleTimeInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.itemIdleMean = new DevExpress.XtraNavBar.NavBarItem();
			this.itemIdleMin = new DevExpress.XtraNavBar.NavBarItem();
			this.itemIdleMax = new DevExpress.XtraNavBar.NavBarItem();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucCheckNavBarControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucCheckNavBarControl1.CheckEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// exChart
			// 
			this.exChart.AllowDrop = true;
			this.exChart.AppearanceNameSerializable = "Light";
			this.exChart.AutoLayout = false;
			xyDiagram1.AxisX.NumericScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
			xyDiagram1.AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Manual;
			xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.exChart.Diagram = xyDiagram1;
			this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
			this.exChart.Legend.UseCheckBoxes = true;
			this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.exChart.Location = new System.Drawing.Point(0, 0);
			this.exChart.Name = "exChart";
			this.exChart.PaletteName = "Nature Colors";
			sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
			sideBySideBarSeriesLabel1.ShowForZeroValues = true;
			series1.Label = sideBySideBarSeriesLabel1;
			series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
			series1.Name = "Series 1";
			this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.exChart.Size = new System.Drawing.Size(608, 704);
			this.exChart.TabIndex = 1;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.ucCheckNavBarControl1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.exChart);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(927, 704);
			this.splitContainerControl1.SplitterPosition = 314;
			this.splitContainerControl1.TabIndex = 2;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// ucCheckNavBarControl1
			// 
			this.ucCheckNavBarControl1.ActiveGroup = this.grRecoveryTimeInfo;
			this.ucCheckNavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCheckNavBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grCycleTimeInfo,
            this.grIdleTimeInfo,
            this.grRecoveryTimeInfo});
			this.ucCheckNavBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.itemCycleMean,
            this.itemCycleMin,
            this.itemCycleMax,
            this.itemCycleStd,
            this.itemCycleCp,
            this.itemCycleCpk,
            this.itemIdleMean,
            this.itemIdleMin,
            this.itemIdleMax,
            this.itemRecoveryMean,
            this.itemRecoveryMin,
            this.itemRecoveryMax});
			this.ucCheckNavBarControl1.Location = new System.Drawing.Point(0, 0);
			this.ucCheckNavBarControl1.Name = "ucCheckNavBarControl1";
			this.ucCheckNavBarControl1.OptionsNavPane.ExpandedWidth = 314;
			this.ucCheckNavBarControl1.Size = new System.Drawing.Size(314, 704);
			this.ucCheckNavBarControl1.TabIndex = 1;
			this.ucCheckNavBarControl1.Text = "ucCheckNavBarControl1";
			this.ucCheckNavBarControl1.CheckedChaged += new UDMTracker.UCCheckNavBarControl.NavBarStateEventHandler(this.ucCheckNavBarControl1_CheckedChaged);
			// 
			// grRecoveryTimeInfo
			// 
			this.grRecoveryTimeInfo.Caption = "RecoveryTime Info";
			this.grRecoveryTimeInfo.Expanded = true;
			this.grRecoveryTimeInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemRecoveryMean),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemRecoveryMin),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemRecoveryMax)});
			this.grRecoveryTimeInfo.Name = "grRecoveryTimeInfo";
			// 
			// itemRecoveryMean
			// 
			this.itemRecoveryMean.Caption = "Mean";
			this.itemRecoveryMean.Name = "itemRecoveryMean";
			// 
			// itemRecoveryMin
			// 
			this.itemRecoveryMin.Caption = "Minimum";
			this.itemRecoveryMin.Name = "itemRecoveryMin";
			// 
			// itemRecoveryMax
			// 
			this.itemRecoveryMax.Caption = "Maximum";
			this.itemRecoveryMax.Name = "itemRecoveryMax";
			// 
			// grCycleTimeInfo
			// 
			this.grCycleTimeInfo.Caption = "CycleTime Info";
			this.grCycleTimeInfo.Expanded = true;
			this.grCycleTimeInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleMean),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleMin),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleMax),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleStd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleCp),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemCycleCpk)});
			this.grCycleTimeInfo.Name = "grCycleTimeInfo";
			// 
			// itemCycleMean
			// 
			this.itemCycleMean.Caption = "Mean";
			this.itemCycleMean.Name = "itemCycleMean";
			// 
			// itemCycleMin
			// 
			this.itemCycleMin.Caption = "Minimum";
			this.itemCycleMin.Name = "itemCycleMin";
			// 
			// itemCycleMax
			// 
			this.itemCycleMax.Caption = "Maximum";
			this.itemCycleMax.Name = "itemCycleMax";
			// 
			// itemCycleStd
			// 
			this.itemCycleStd.Caption = "Standard.Dev";
			this.itemCycleStd.Name = "itemCycleStd";
			// 
			// itemCycleCp
			// 
			this.itemCycleCp.Caption = "Cp";
			this.itemCycleCp.Name = "itemCycleCp";
			// 
			// itemCycleCpk
			// 
			this.itemCycleCpk.Caption = "Cpk";
			this.itemCycleCpk.Name = "itemCycleCpk";
			// 
			// grIdleTimeInfo
			// 
			this.grIdleTimeInfo.Caption = "IdleTime Info";
			this.grIdleTimeInfo.Expanded = true;
			this.grIdleTimeInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemIdleMean),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemIdleMin),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itemIdleMax)});
			this.grIdleTimeInfo.Name = "grIdleTimeInfo";
			// 
			// itemIdleMean
			// 
			this.itemIdleMean.Caption = "Mean";
			this.itemIdleMean.Name = "itemIdleMean";
			// 
			// itemIdleMin
			// 
			this.itemIdleMin.Caption = "Minimum";
			this.itemIdleMin.Name = "itemIdleMin";
			// 
			// itemIdleMax
			// 
			this.itemIdleMax.Caption = "Maximum";
			this.itemIdleMax.Name = "itemIdleMax";
			// 
			// FrmStatisticsChartViewer
			// 
			this.ClientSize = new System.Drawing.Size(927, 704);
			this.Controls.Add(this.splitContainerControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmStatisticsChartViewer";
			this.Text = "CycleTime Statistics Chart";
			this.Load += new System.EventHandler(this.FrmStatisticsChartViewer_Load);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucCheckNavBarControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ucCheckNavBarControl1.CheckEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraCharts.ChartControl exChart;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private UCCheckNavBarControl ucCheckNavBarControl1;
		private DevExpress.XtraNavBar.NavBarGroup grCycleTimeInfo;
		private DevExpress.XtraNavBar.NavBarGroup grIdleTimeInfo;
		private DevExpress.XtraNavBar.NavBarGroup grRecoveryTimeInfo;
		private DevExpress.XtraNavBar.NavBarItem itemCycleMean;
		private DevExpress.XtraNavBar.NavBarItem itemCycleMin;
		private DevExpress.XtraNavBar.NavBarItem itemCycleMax;
		private DevExpress.XtraNavBar.NavBarItem itemCycleStd;
		private DevExpress.XtraNavBar.NavBarItem itemCycleCp;
		private DevExpress.XtraNavBar.NavBarItem itemCycleCpk;
		private DevExpress.XtraNavBar.NavBarItem itemIdleMean;
		private DevExpress.XtraNavBar.NavBarItem itemIdleMin;
		private DevExpress.XtraNavBar.NavBarItem itemIdleMax;
		private DevExpress.XtraNavBar.NavBarItem itemRecoveryMean;
		private DevExpress.XtraNavBar.NavBarItem itemRecoveryMin;
		private DevExpress.XtraNavBar.NavBarItem itemRecoveryMax;
	}
}