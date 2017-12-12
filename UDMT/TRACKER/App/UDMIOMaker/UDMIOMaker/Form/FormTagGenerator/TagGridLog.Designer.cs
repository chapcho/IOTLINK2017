namespace NewIOMaker.Form.Form_TagGenerator
{
    partial class TagGridLog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagGridLog));
            this.exGridLog = new DevExpress.XtraGrid.GridControl();
            this.exGridViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PopupTagLog = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnExportTagLog = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.exGridLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupTagLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridLog
            // 
            this.exGridLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridLog.Location = new System.Drawing.Point(0, 0);
            this.exGridLog.MainView = this.exGridViewLog;
            this.exGridLog.Name = "exGridLog";
            this.exGridLog.Size = new System.Drawing.Size(753, 512);
            this.exGridLog.TabIndex = 0;
            this.exGridLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewLog});
            // 
            // exGridViewLog
            // 
            this.exGridViewLog.GridControl = this.exGridLog;
            this.exGridViewLog.GroupPanelText = "원하는 항목을 드래그하세요";
            this.exGridViewLog.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", null, "")});
            this.exGridViewLog.Name = "exGridViewLog";
            this.exGridViewLog.OptionsBehavior.ReadOnly = true;
            this.exGridViewLog.OptionsFilter.UseNewCustomFilterDialog = true;
            this.exGridViewLog.OptionsSelection.MultiSelect = true;
            this.exGridViewLog.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridViewLog.OptionsView.ShowAutoFilterRow = true;
            this.exGridViewLog.OptionsView.ShowChildrenInGroupPanel = true;
            this.exGridViewLog.OptionsView.ShowFooter = true;
            this.exGridViewLog.OptionsView.ShowGroupedColumns = true;
            // 
            // PopupTagLog
            // 
            this.PopupTagLog.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportTagLog, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.PopupTagLog.Manager = this.barManager1;
            this.PopupTagLog.Name = "PopupTagLog";
            // 
            // btnExportTagLog
            // 
            this.btnExportTagLog.Caption = "Export TagMapping Information";
            this.btnExportTagLog.Id = 1;
            this.btnExportTagLog.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportTagLog.LargeGlyph")));
            this.btnExportTagLog.Name = "btnExportTagLog";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExportTagLog});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(753, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 512);
            this.barDockControlBottom.Size = new System.Drawing.Size(753, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 512);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(753, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 512);
            // 
            // TagGridLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridLog);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TagGridLog";
            this.Size = new System.Drawing.Size(753, 512);
            ((System.ComponentModel.ISupportInitialize)(this.exGridLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupTagLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridLog;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewLog;
        private DevExpress.XtraBars.PopupMenu PopupTagLog;
        private DevExpress.XtraBars.BarButtonItem btnExportTagLog;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
