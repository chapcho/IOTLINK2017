namespace NewIOMaker.Form.FormCommon.UserControl
{
    partial class ControlBackupGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBackupGrid));
            this.BackupGrid = new DevExpress.XtraGrid.GridControl();
            this.BackupGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupBackup = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnBackupExport = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.BackupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackupGrid
            // 
            this.BackupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupGrid.Location = new System.Drawing.Point(0, 0);
            this.BackupGrid.MainView = this.BackupGridView;
            this.BackupGrid.Name = "BackupGrid";
            this.BackupGrid.Size = new System.Drawing.Size(437, 356);
            this.BackupGrid.TabIndex = 0;
            this.BackupGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BackupGridView});
            // 
            // BackupGridView
            // 
            this.BackupGridView.GridControl = this.BackupGrid;
            this.BackupGridView.Name = "BackupGridView";
            this.BackupGridView.OptionsBehavior.ReadOnly = true;
            this.BackupGridView.OptionsSelection.MultiSelect = true;
            this.BackupGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.BackupGridView.OptionsView.ShowAutoFilterRow = true;
            this.BackupGridView.OptionsView.ShowFooter = true;
            // 
            // popupBackup
            // 
            this.popupBackup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBackupExport)});
            this.popupBackup.Manager = this.barManager1;
            this.popupBackup.Name = "popupBackup";
            // 
            // btnBackupExport
            // 
            this.btnBackupExport.Caption = "Export Backup List";
            this.btnBackupExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBackupExport.Glyph")));
            this.btnBackupExport.Id = 0;
            this.btnBackupExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBackupExport.LargeGlyph")));
            this.btnBackupExport.Name = "btnBackupExport";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnBackupExport});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(437, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 356);
            this.barDockControlBottom.Size = new System.Drawing.Size(437, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 356);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(437, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 356);
            // 
            // ControlBackupGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackupGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ControlBackupGrid";
            this.Size = new System.Drawing.Size(437, 356);
            ((System.ComponentModel.ISupportInitialize)(this.BackupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl BackupGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView BackupGridView;
        private DevExpress.XtraBars.PopupMenu popupBackup;
        private DevExpress.XtraBars.BarButtonItem btnBackupExport;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
