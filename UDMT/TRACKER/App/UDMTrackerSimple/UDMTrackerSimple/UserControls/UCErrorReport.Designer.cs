namespace UDMTrackerSimple
{
    partial class UCErrorReport
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
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grdTotal = new DevExpress.XtraGrid.GridControl();
            this.grvTotal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMostError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.ErrorPieChart = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptMain
            // 
            this.sptMain.Appearance.BackColor = System.Drawing.Color.White;
            this.sptMain.Appearance.Options.UseBackColor = true;
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.LookAndFeel.SkinName = "Office 2013";
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sptMain.Panel1.Controls.Add(this.grdTotal);
            this.sptMain.Panel1.Controls.Add(this.splitterControl1);
            this.sptMain.Panel1.Controls.Add(this.ErrorPieChart);
            this.sptMain.Panel1.Controls.Add(this.panelControl1);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.tabMain);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1190, 391);
            this.sptMain.SplitterPosition = 364;
            this.sptMain.TabIndex = 0;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // grdTotal
            // 
            this.grdTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTotal.Location = new System.Drawing.Point(0, 221);
            this.grdTotal.LookAndFeel.SkinName = "Office 2013";
            this.grdTotal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTotal.MainView = this.grvTotal;
            this.grdTotal.Name = "grdTotal";
            this.grdTotal.Size = new System.Drawing.Size(360, 166);
            this.grdTotal.TabIndex = 3;
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
            this.colGroup.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceCell.Options.UseFont = true;
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colGroup.AppearanceHeader.Options.UseFont = true;
            this.colGroup.AppearanceHeader.Options.UseForeColor = true;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "Group";
            this.colGroup.FieldName = "GroupKey";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.FixedWidth = true;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 51;
            // 
            // colMostError
            // 
            this.colMostError.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceCell.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMostError.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colMostError.AppearanceHeader.Options.UseFont = true;
            this.colMostError.AppearanceHeader.Options.UseForeColor = true;
            this.colMostError.Caption = "Most Error";
            this.colMostError.FieldName = "MostError";
            this.colMostError.Name = "colMostError";
            this.colMostError.OptionsColumn.FixedWidth = true;
            this.colMostError.Visible = true;
            this.colMostError.VisibleIndex = 2;
            this.colMostError.Width = 260;
            // 
            // colErrorCount
            // 
            this.colErrorCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.colErrorCount.VisibleIndex = 1;
            this.colErrorCount.Width = 65;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 216);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(360, 5);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // ErrorPieChart
            // 
            this.ErrorPieChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.ErrorPieChart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.ErrorPieChart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.RightToLeft;
            this.ErrorPieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ErrorPieChart.Location = new System.Drawing.Point(0, 21);
            this.ErrorPieChart.Name = "ErrorPieChart";
            this.ErrorPieChart.RuntimeHitTesting = true;
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Error";
            series1.View = pieSeriesView1;
            this.ErrorPieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ErrorPieChart.Size = new System.Drawing.Size(360, 195);
            this.ErrorPieChart.TabIndex = 1;
            this.ErrorPieChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ErrorPieChart_CustomDrawSeriesPoint);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 21);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Location = new System.Drawing.Point(2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Total Error Information";
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.xtraTabPage1;
            this.tabMain.Size = new System.Drawing.Size(816, 391);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(808, 355);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(808, 355);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // UCErrorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptMain);
            this.Name = "UCErrorReport";
            this.Size = new System.Drawing.Size(1190, 391);
            this.Load += new System.EventHandler(this.UCErrorReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UDM.UI.MySplitContainerControl sptMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraCharts.ChartControl ErrorPieChart;
        private DevExpress.XtraGrid.GridControl grdTotal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colMostError;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}
