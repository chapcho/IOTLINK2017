namespace NewIOMaker.Form.FormIOMaker
{
    partial class IOGridLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOGridLog));
            this.IOLogGrid = new DevExpress.XtraGrid.GridControl();
            this.IOLogGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupIOExport = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnIOListLogExport = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.IOLogGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IOLogGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupIOExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // IOLogGrid
            // 
            this.IOLogGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOLogGrid.Location = new System.Drawing.Point(0, 0);
            this.IOLogGrid.MainView = this.IOLogGridView;
            this.IOLogGrid.Name = "IOLogGrid";
            this.IOLogGrid.Size = new System.Drawing.Size(384, 409);
            this.IOLogGrid.TabIndex = 0;
            this.IOLogGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.IOLogGridView});
            // 
            // IOLogGridView
            // 
            this.IOLogGridView.GridControl = this.IOLogGrid;
            this.IOLogGridView.GroupPanelText = "원하는 항목을 드래그하세요";
            this.IOLogGridView.Name = "IOLogGridView";
            this.IOLogGridView.OptionsBehavior.ReadOnly = true;
            this.IOLogGridView.OptionsSelection.MultiSelect = true;
            this.IOLogGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.IOLogGridView.OptionsView.ShowAutoFilterRow = true;
            this.IOLogGridView.OptionsView.ShowFooter = true;
            // 
            // popupIOExport
            // 
            this.popupIOExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIOListLogExport)});
            this.popupIOExport.Manager = this.barManager1;
            this.popupIOExport.Name = "popupIOExport";
            // 
            // btnIOListLogExport
            // 
            this.btnIOListLogExport.Caption = "Export IO List Log";
            this.btnIOListLogExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnIOListLogExport.Glyph")));
            this.btnIOListLogExport.Id = 0;
            this.btnIOListLogExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnIOListLogExport.LargeGlyph")));
            this.btnIOListLogExport.Name = "btnIOListLogExport";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnIOListLogExport});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(384, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 409);
            this.barDockControlBottom.Size = new System.Drawing.Size(384, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 409);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(384, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 409);
            // 
            // IOGridLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IOLogGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "IOGridLog";
            this.Size = new System.Drawing.Size(384, 409);
            ((System.ComponentModel.ISupportInitialize)(this.IOLogGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IOLogGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupIOExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl IOLogGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView IOLogGridView;
        private DevExpress.XtraBars.PopupMenu popupIOExport;
        private DevExpress.XtraBars.BarButtonItem btnIOListLogExport;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
