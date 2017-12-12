namespace UDMTrackerSimple
{
    partial class UCErrorProcessReport
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
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            this.pnlErrorChart = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl4 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.grdProcess = new DevExpress.XtraGrid.GridControl();
            this.grvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMostError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlPieChart = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.ErrorPieChart = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnChartClear = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            this.ucError = new UDMTrackerSimple.UCErrorDetail();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).BeginInit();
            this.pnlErrorChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPieChart)).BeginInit();
            this.pnlPieChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlErrorChart
            // 
            this.pnlErrorChart.Controls.Add(this.splitterControl4);
            this.pnlErrorChart.Controls.Add(this.pnlChart);
            this.pnlErrorChart.Controls.Add(this.grdProcess);
            this.pnlErrorChart.Controls.Add(this.splitterControl2);
            this.pnlErrorChart.Controls.Add(this.pnlPieChart);
            this.pnlErrorChart.Controls.Add(this.panelControl2);
            this.pnlErrorChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlErrorChart.Location = new System.Drawing.Point(0, 0);
            this.pnlErrorChart.Name = "pnlErrorChart";
            this.pnlErrorChart.Size = new System.Drawing.Size(459, 448);
            this.pnlErrorChart.TabIndex = 0;
            // 
            // splitterControl4
            // 
            this.splitterControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl4.Location = new System.Drawing.Point(143, 265);
            this.splitterControl4.Name = "splitterControl4";
            this.splitterControl4.Size = new System.Drawing.Size(314, 5);
            this.splitterControl4.TabIndex = 35;
            this.splitterControl4.TabStop = false;
            // 
            // pnlChart
            // 
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(143, 30);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(314, 240);
            this.pnlChart.TabIndex = 31;
            // 
            // grdProcess
            // 
            this.grdProcess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdProcess.Location = new System.Drawing.Point(143, 270);
            this.grdProcess.LookAndFeel.SkinName = "Office 2013";
            this.grdProcess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdProcess.MainView = this.grvProcess;
            this.grdProcess.Name = "grdProcess";
            this.grdProcess.Size = new System.Drawing.Size(314, 176);
            this.grdProcess.TabIndex = 34;
            this.grdProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProcess});
            // 
            // grvProcess
            // 
            this.grvProcess.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMostError,
            this.colErrorCount});
            this.grvProcess.GridControl = this.grdProcess;
            this.grvProcess.Name = "grvProcess";
            this.grvProcess.OptionsBehavior.Editable = false;
            this.grvProcess.OptionsBehavior.ReadOnly = true;
            this.grvProcess.OptionsCustomization.AllowColumnMoving = false;
            this.grvProcess.OptionsDetail.AllowZoomDetail = false;
            this.grvProcess.OptionsDetail.EnableMasterViewMode = false;
            this.grvProcess.OptionsDetail.SmartDetailExpand = false;
            this.grvProcess.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvProcess.OptionsView.ShowGroupPanel = false;
            this.grvProcess.OptionsView.ShowIndicator = false;
            this.grvProcess.RowHeight = 30;
            this.grvProcess.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colErrorCount, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colMostError
            // 
            this.colMostError.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceCell.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colMostError.AppearanceHeader.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Options.UseForeColor = true;
            this.colMostError.Caption = "Error Message";
            this.colMostError.FieldName = "MostError";
            this.colMostError.Name = "colMostError";
            this.colMostError.OptionsColumn.FixedWidth = true;
            this.colMostError.Visible = true;
            this.colMostError.VisibleIndex = 1;
            this.colMostError.Width = 260;
            // 
            // colErrorCount
            // 
            this.colErrorCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceCell.Options.UseFont = true;
            this.colErrorCount.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colErrorCount.AppearanceHeader.Options.UseFont = true;
            this.colErrorCount.AppearanceHeader.Options.UseForeColor = true;
            this.colErrorCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.Caption = "Count";
            this.colErrorCount.FieldName = "ErrorCount";
            this.colErrorCount.Name = "colErrorCount";
            this.colErrorCount.OptionsColumn.FixedWidth = true;
            this.colErrorCount.Visible = true;
            this.colErrorCount.VisibleIndex = 0;
            this.colErrorCount.Width = 69;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(138, 30);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 416);
            this.splitterControl2.TabIndex = 33;
            this.splitterControl2.TabStop = false;
            this.splitterControl2.Visible = false;
            // 
            // pnlPieChart
            // 
            this.pnlPieChart.Controls.Add(this.splitterControl3);
            this.pnlPieChart.Controls.Add(this.ErrorPieChart);
            this.pnlPieChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPieChart.Location = new System.Drawing.Point(2, 30);
            this.pnlPieChart.Name = "pnlPieChart";
            this.pnlPieChart.Size = new System.Drawing.Size(136, 416);
            this.pnlPieChart.TabIndex = 32;
            this.pnlPieChart.Visible = false;
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl3.Location = new System.Drawing.Point(2, 160);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(132, 5);
            this.splitterControl3.TabIndex = 2;
            this.splitterControl3.TabStop = false;
            // 
            // ErrorPieChart
            // 
            this.ErrorPieChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.ErrorPieChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.ErrorPieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ErrorPieChart.Location = new System.Drawing.Point(2, 2);
            this.ErrorPieChart.Name = "ErrorPieChart";
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Error";
            series2.View = pieSeriesView2;
            this.ErrorPieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.ErrorPieChart.Size = new System.Drawing.Size(132, 158);
            this.ErrorPieChart.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Controls.Add(this.btnChartClear);
            this.panelControl2.Controls.Add(this.lblTitle);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(455, 28);
            this.panelControl2.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(339, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChartClear
            // 
            this.btnChartClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChartClear.Location = new System.Drawing.Point(396, 2);
            this.btnChartClear.Name = "btnChartClear";
            this.btnChartClear.Size = new System.Drawing.Size(57, 24);
            this.btnChartClear.TabIndex = 2;
            this.btnChartClear.Text = "Clear";
            this.btnChartClear.Visible = false;
            this.btnChartClear.Click += new System.EventHandler(this.btnChartClear_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(141, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Error Statistic Chart";
            // 
            // sptMain
            // 
            this.sptMain.Location = new System.Drawing.Point(459, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(5, 448);
            this.sptMain.TabIndex = 1;
            this.sptMain.TabStop = false;
            // 
            // ucError
            // 
            this.ucError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucError.Location = new System.Drawing.Point(464, 0);
            this.ucError.Name = "ucError";
            this.ucError.PanelFilter = false;
            this.ucError.Size = new System.Drawing.Size(725, 448);
            this.ucError.TabIndex = 34;
            // 
            // UCErrorProcessReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucError);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.pnlErrorChart);
            this.Name = "UCErrorProcessReport";
            this.Size = new System.Drawing.Size(1189, 448);
            this.Load += new System.EventHandler(this.UCErrorProcessReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).EndInit();
            this.pnlErrorChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPieChart)).EndInit();
            this.pnlPieChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlErrorChart;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnChartClear;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl pnlPieChart;
        private DevExpress.XtraCharts.ChartControl ErrorPieChart;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private UCErrorDetail ucError;
        private DevExpress.XtraGrid.GridControl grdProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colMostError;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
        private DevExpress.XtraEditors.SplitterControl splitterControl4;

    }
}
