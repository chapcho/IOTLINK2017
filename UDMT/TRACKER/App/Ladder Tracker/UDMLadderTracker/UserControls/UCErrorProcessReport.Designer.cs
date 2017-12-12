namespace UDMLadderTracker
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            this.pnlErrorChart = new DevExpress.XtraEditors.PanelControl();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlPieChart = new DevExpress.XtraEditors.PanelControl();
            this.ErrorPieChart = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnChartClear = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.grdProcess = new DevExpress.XtraGrid.GridControl();
            this.grvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMostError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).BeginInit();
            this.pnlErrorChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPieChart)).BeginInit();
            this.pnlPieChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlErrorChart
            // 
            this.pnlErrorChart.Controls.Add(this.pnlChart);
            this.pnlErrorChart.Controls.Add(this.splitterControl2);
            this.pnlErrorChart.Controls.Add(this.pnlPieChart);
            this.pnlErrorChart.Controls.Add(this.panelControl2);
            this.pnlErrorChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlErrorChart.Location = new System.Drawing.Point(0, 0);
            this.pnlErrorChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlErrorChart.Name = "pnlErrorChart";
            this.pnlErrorChart.Size = new System.Drawing.Size(770, 482);
            this.pnlErrorChart.TabIndex = 0;
            // 
            // pnlChart
            // 
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(242, 38);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(526, 442);
            this.pnlChart.TabIndex = 31;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(236, 38);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(6, 442);
            this.splitterControl2.TabIndex = 33;
            this.splitterControl2.TabStop = false;
            // 
            // pnlPieChart
            // 
            this.pnlPieChart.Controls.Add(this.ErrorPieChart);
            this.pnlPieChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPieChart.Location = new System.Drawing.Point(2, 38);
            this.pnlPieChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPieChart.Name = "pnlPieChart";
            this.pnlPieChart.Size = new System.Drawing.Size(234, 442);
            this.pnlPieChart.TabIndex = 32;
            // 
            // ErrorPieChart
            // 
            this.ErrorPieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorPieChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.ErrorPieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ErrorPieChart.Location = new System.Drawing.Point(2, 2);
            this.ErrorPieChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ErrorPieChart.Name = "ErrorPieChart";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Error";
            series1.View = pieSeriesView1;
            this.ErrorPieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ErrorPieChart.Size = new System.Drawing.Size(230, 438);
            this.ErrorPieChart.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Controls.Add(this.btnChartClear);
            this.panelControl2.Controls.Add(this.lblTitle);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(766, 36);
            this.panelControl2.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(634, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChartClear
            // 
            this.btnChartClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChartClear.Location = new System.Drawing.Point(699, 2);
            this.btnChartClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChartClear.Name = "btnChartClear";
            this.btnChartClear.Size = new System.Drawing.Size(65, 32);
            this.btnChartClear.TabIndex = 2;
            this.btnChartClear.Text = "Clear";
            this.btnChartClear.Click += new System.EventHandler(this.btnChartClear_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(174, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Error Statistic Chart";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(770, 0);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 482);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // grdProcess
            // 
            this.grdProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProcess.Location = new System.Drawing.Point(776, 28);
            this.grdProcess.LookAndFeel.SkinName = "Office 2013";
            this.grdProcess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdProcess.MainView = this.grvProcess;
            this.grdProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProcess.Name = "grdProcess";
            this.grdProcess.Size = new System.Drawing.Size(365, 454);
            this.grdProcess.TabIndex = 4;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(776, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(365, 28);
            this.panelControl1.TabIndex = 31;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(91, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Error Grid";
            // 
            // UCErrorProcessReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdProcess);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.pnlErrorChart);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCErrorProcessReport";
            this.Size = new System.Drawing.Size(1141, 482);
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).EndInit();
            this.pnlErrorChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPieChart)).EndInit();
            this.pnlPieChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlErrorChart;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnChartClear;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraGrid.GridControl grdProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colMostError;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl pnlPieChart;
        private DevExpress.XtraCharts.ChartControl ErrorPieChart;

    }
}
