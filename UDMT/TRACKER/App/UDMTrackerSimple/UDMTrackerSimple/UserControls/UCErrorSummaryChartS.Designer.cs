namespace UDMTrackerSimple
{
    partial class UCErrorSummaryChartS
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
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.ErrorPieChart = new DevExpress.XtraCharts.ChartControl();
            this.grdTotal = new DevExpress.XtraGrid.GridControl();
            this.grvTotal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMostError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabLine = new DevExpress.XtraTab.XtraTabControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.sptError = new UDM.UI.MySplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptError)).BeginInit();
            this.sptError.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorPieChart
            // 
            this.ErrorPieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorPieChart.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            this.ErrorPieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ErrorPieChart.Location = new System.Drawing.Point(0, 0);
            this.ErrorPieChart.Name = "ErrorPieChart";
            this.ErrorPieChart.RuntimeHitTesting = true;
            series2.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series2.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Error";
            series2.View = pieSeriesView2;
            this.ErrorPieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.ErrorPieChart.Size = new System.Drawing.Size(303, 215);
            this.ErrorPieChart.TabIndex = 2;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle2.Text = "라인 별 이상 발생 현황";
            this.ErrorPieChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            this.ErrorPieChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ErrorPieChart_CustomDrawSeriesPoint);
            // 
            // grdTotal
            // 
            this.grdTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTotal.Location = new System.Drawing.Point(0, 0);
            this.grdTotal.LookAndFeel.SkinName = "Office 2013";
            this.grdTotal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTotal.MainView = this.grvTotal;
            this.grdTotal.Name = "grdTotal";
            this.grdTotal.Size = new System.Drawing.Size(303, 108);
            this.grdTotal.TabIndex = 4;
            this.grdTotal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotal});
            // 
            // grvTotal
            // 
            this.grvTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvTotal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colMostError,
            this.colErrorCount});
            this.grvTotal.GridControl = this.grdTotal;
            this.grvTotal.Name = "grvTotal";
            this.grvTotal.OptionsBehavior.Editable = false;
            this.grvTotal.OptionsBehavior.ReadOnly = true;
            this.grvTotal.OptionsCustomization.AllowColumnMoving = false;
            this.grvTotal.OptionsDetail.AllowZoomDetail = false;
            this.grvTotal.OptionsDetail.EnableMasterViewMode = false;
            this.grvTotal.OptionsDetail.SmartDetailExpand = false;
            this.grvTotal.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvTotal.OptionsView.ShowGroupPanel = false;
            this.grvTotal.OptionsView.ShowIndicator = false;
            this.grvTotal.RowHeight = 30;
            this.grvTotal.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colErrorCount, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvTotal.DoubleClick += new System.EventHandler(this.grvTotal_DoubleClick);
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceCell.Options.UseFont = true;
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colGroup.AppearanceHeader.Options.UseFont = true;
            this.colGroup.AppearanceHeader.Options.UseForeColor = true;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "라인";
            this.colGroup.FieldName = "GroupKey";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.OptionsColumn.AllowMove = false;
            this.colGroup.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGroup.OptionsColumn.ReadOnly = true;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 100;
            // 
            // colMostError
            // 
            this.colMostError.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceCell.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colMostError.AppearanceHeader.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Options.UseForeColor = true;
            this.colMostError.Caption = "이상 多 공정";
            this.colMostError.FieldName = "MostError";
            this.colMostError.Name = "colMostError";
            this.colMostError.OptionsColumn.AllowEdit = false;
            this.colMostError.OptionsColumn.AllowMove = false;
            this.colMostError.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMostError.OptionsColumn.ReadOnly = true;
            this.colMostError.Visible = true;
            this.colMostError.VisibleIndex = 2;
            this.colMostError.Width = 112;
            // 
            // colErrorCount
            // 
            this.colErrorCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceCell.Options.UseFont = true;
            this.colErrorCount.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colErrorCount.AppearanceHeader.Options.UseFont = true;
            this.colErrorCount.AppearanceHeader.Options.UseForeColor = true;
            this.colErrorCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.Caption = "이상 개수";
            this.colErrorCount.FieldName = "ErrorCount";
            this.colErrorCount.Name = "colErrorCount";
            this.colErrorCount.OptionsColumn.AllowEdit = false;
            this.colErrorCount.OptionsColumn.AllowMove = false;
            this.colErrorCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colErrorCount.OptionsColumn.FixedWidth = true;
            this.colErrorCount.OptionsColumn.ReadOnly = true;
            this.colErrorCount.Visible = true;
            this.colErrorCount.VisibleIndex = 1;
            this.colErrorCount.Width = 80;
            // 
            // tabLine
            // 
            this.tabLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLine.Location = new System.Drawing.Point(0, 0);
            this.tabLine.Name = "tabLine";
            this.tabLine.Size = new System.Drawing.Size(562, 333);
            this.tabLine.TabIndex = 2;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.sptError);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.tabLine);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(875, 333);
            this.sptMain.SplitterPosition = 303;
            this.sptMain.TabIndex = 3;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // sptError
            // 
            this.sptError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptError.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptError.Horizontal = false;
            this.sptError.Location = new System.Drawing.Point(0, 0);
            this.sptError.Name = "sptError";
            this.sptError.Panel1.Controls.Add(this.ErrorPieChart);
            this.sptError.Panel1.Text = "Panel1";
            this.sptError.Panel2.Controls.Add(this.grdTotal);
            this.sptError.Panel2.Text = "Panel2";
            this.sptError.Size = new System.Drawing.Size(303, 333);
            this.sptError.SplitterPosition = 108;
            this.sptError.TabIndex = 4;
            this.sptError.Text = "splitContainerControl1";
            this.sptError.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptError_MouseDoubleClick);
            // 
            // UCErrorSummaryChartS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptMain);
            this.Name = "UCErrorSummaryChartS";
            this.Size = new System.Drawing.Size(875, 333);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptError)).EndInit();
            this.sptError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl ErrorPieChart;
        private DevExpress.XtraGrid.GridControl grdTotal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colMostError;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
        private DevExpress.XtraTab.XtraTabControl tabLine;
        private UDM.UI.MySplitContainerControl sptMain;
        private UDM.UI.MySplitContainerControl sptError;
    }
}
