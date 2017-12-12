namespace UDM.Project.UserControls
{
    partial class UCMonitorHistoryTable
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
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.MainView = this.grvMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(438, 571);
            this.grdMain.TabIndex = 0;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStartTime,
            this.colEndTime,
            this.colCycleCount});
            this.grvMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMain.GridControl = this.grdMain;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsBehavior.Editable = false;
            this.grvMain.OptionsBehavior.ReadOnly = true;
            this.grvMain.OptionsDetail.EnableMasterViewMode = false;
            this.grvMain.OptionsDetail.ShowDetailTabs = false;
            this.grvMain.OptionsDetail.SmartDetailExpand = false;
            this.grvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvMain.DoubleClick += new System.EventHandler(this.grvMain_DoubleClick);
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartTime.Caption = "StartTime";
            this.colStartTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 0;
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.Caption = "EndTime";
            this.colEndTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 1;
            // 
            // colCycleCount
            // 
            this.colCycleCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleCount.Caption = "CycleCount";
            this.colCycleCount.FieldName = "CycleCount";
            this.colCycleCount.Name = "colCycleCount";
            this.colCycleCount.Visible = true;
            this.colCycleCount.VisibleIndex = 2;
            // 
            // UCMonitorHistoryTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdMain);
            this.Name = "UCMonitorHistoryTable";
            this.Size = new System.Drawing.Size(438, 571);
            this.Load += new System.EventHandler(this.UCMonitorHistoryTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleCount;
    }
}
