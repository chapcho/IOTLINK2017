namespace UDMTracker
{
    partial class FrmSymbolLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolLogViewer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.spltMain = new DevExpress.XtraEditors.SplitterControl();
            this.ucLogGanttViewer = new UDM.Project.UCLogGanttViewer();
            this.ucTagTable = new UDM.Project.UCTagTable();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            this.SuspendLayout();
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu,
            this.exBarStatus});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnShow,
            this.btnExit});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 11;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 24, 21, 32, 0, 275);
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 120;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // dtpkTo
            // 
            this.dtpkTo.Caption = "To";
            this.dtpkTo.Edit = this.exEditorTo;
            this.dtpkTo.EditValue = new System.DateTime(2015, 2, 24, 21, 33, 2, 912);
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 120;
            // 
            // exEditorTo
            // 
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 9;
            this.btnShow.LargeImageIndex = 11;
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 4;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 5;
            this.btnZoomIn.LargeImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 6;
            this.btnZoomOut.LargeImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 7;
            this.btnItemUp.LargeImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 8;
            this.btnItemDown.LargeImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 10;
            this.btnExit.LargeImageIndex = 13;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // exBarStatus
            // 
            this.exBarStatus.BarName = "Status bar";
            this.exBarStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.exBarStatus.DockCol = 0;
            this.exBarStatus.DockRow = 0;
            this.exBarStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.exBarStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
            this.exBarStatus.OptionsBar.AllowQuickCustomization = false;
            this.exBarStatus.OptionsBar.DrawDragBorder = false;
            this.exBarStatus.OptionsBar.UseWholeRow = true;
            this.exBarStatus.Text = "Status bar";
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(871, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
            this.barDockControlBottom.Size = new System.Drawing.Size(871, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 358);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(871, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 358);
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "ZoomIn_32x32.png");
            this.imgListLarge.Images.SetKeyName(1, "ZoomOut_32x32.png");
            this.imgListLarge.Images.SetKeyName(2, "MoveUp_32x32.png");
            this.imgListLarge.Images.SetKeyName(3, "MoveDown_32x32.png");
            this.imgListLarge.Images.SetKeyName(4, "Find_32x32.png");
            this.imgListLarge.Images.SetKeyName(5, "Clear_32x32.png");
            this.imgListLarge.Images.SetKeyName(6, "AddItem_32x32.png");
            this.imgListLarge.Images.SetKeyName(7, "DeleteList_32x32.png");
            this.imgListLarge.Images.SetKeyName(8, "SaveAll_32x32.png");
            this.imgListLarge.Images.SetKeyName(9, "Add_16x16.png");
            this.imgListLarge.Images.SetKeyName(10, "ImportCSV_32x32.png");
            this.imgListLarge.Images.SetKeyName(11, "Gantt_32x32.png");
            this.imgListLarge.Images.SetKeyName(12, "RemoveItem_32x32.png");
            this.imgListLarge.Images.SetKeyName(13, "Cancel_32x32.png");
            // 
            // spltMain
            // 
            this.spltMain.Location = new System.Drawing.Point(330, 65);
            this.spltMain.Name = "spltMain";
            this.spltMain.Size = new System.Drawing.Size(5, 358);
            this.spltMain.TabIndex = 5;
            this.spltMain.TabStop = false;
            // 
            // ucLogGanttViewer
            // 
            this.ucLogGanttViewer.BarHeight = 100;
            this.ucLogGanttViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogGanttViewer.Location = new System.Drawing.Point(335, 65);
            this.ucLogGanttViewer.Name = "ucLogGanttViewer";
            this.ucLogGanttViewer.OverViewHeight = 100;
            this.ucLogGanttViewer.Size = new System.Drawing.Size(536, 358);
            this.ucLogGanttViewer.TabIndex = 6;
            this.ucLogGanttViewer.UnitWidth = 20;
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucTagTable.Editable = false;
            this.ucTagTable.Location = new System.Drawing.Point(0, 65);
            this.ucTagTable.Manager = null;
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.Project = null;
            this.ucTagTable.Size = new System.Drawing.Size(330, 358);
            this.ucTagTable.TabIndex = 16;
            // 
            // FrmSymbolLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 448);
            this.Controls.Add(this.ucLogGanttViewer);
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.ucTagTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSymbolLogViewer";
            this.Text = "Symbol Log Viewer";
            this.Load += new System.EventHandler(this.FrmSymbolLogViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private UDM.Project.UCLogGanttViewer ucLogGanttViewer;
        private DevExpress.XtraEditors.SplitterControl spltMain;
		private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
		private UDM.Project.UCTagTable ucTagTable;
    }
}