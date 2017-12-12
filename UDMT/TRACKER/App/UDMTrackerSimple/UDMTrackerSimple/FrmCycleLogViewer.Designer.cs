namespace UDMTrackerSimple
{
    partial class FrmCycleLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCycleLogViewer));
            this.exManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cmbGroup = new DevExpress.XtraBars.BarEditItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
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
            this.imgListSmal = new System.Windows.Forms.ImageList(this.components);
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.ucChart = new UDM.UI.TimeChart.UCTimeChart();
            this.ucProcessLogTable = new UDMTrackerSimple.UCProcessLogTable();
            this.pnlRecipe = new DevExpress.XtraEditors.PanelControl();
            this.ucRecipeView = new UDMTrackerSimple.UCRecipeView();
            this.sptChart = new UDM.UI.MySplitContainerControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.exManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecipe)).BeginInit();
            this.pnlRecipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptChart)).BeginInit();
            this.sptChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // exManager
            // 
            this.exManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu,
            this.exBarStatus});
            this.exManager.DockControls.Add(this.barDockControlTop);
            this.exManager.DockControls.Add(this.barDockControlBottom);
            this.exManager.DockControls.Add(this.barDockControlLeft);
            this.exManager.DockControls.Add(this.barDockControlRight);
            this.exManager.Form = this;
            this.exManager.Images = this.imgListSmal;
            this.exManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.cmbGroup,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnRefresh,
            this.btnExit});
            this.exManager.LargeImages = this.imgListLarge;
            this.exManager.MaxItemId = 13;
            this.exManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
            this.exEditorFrom,
            this.exEditorTo});
            this.exManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cmbGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
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
            // cmbGroup
            // 
            this.cmbGroup.Caption = "Process";
            this.cmbGroup.Edit = this.exEditorGroup;
            this.cmbGroup.Id = 1;
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Width = 150;
            // 
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 18, 21, 2, 4, 835);
            this.dtpkFrom.Id = 2;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 150;
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
            this.dtpkTo.EditValue = new System.DateTime(2015, 2, 18, 21, 3, 4, 84);
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 150;
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
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 11;
            this.btnRefresh.LargeImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowCycleList_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 5;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 6;
            this.btnZoomIn.LargeImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 7;
            this.btnZoomOut.LargeImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 8;
            this.btnItemUp.LargeImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 9;
            this.btnItemDown.LargeImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 12;
            this.btnExit.LargeImageIndex = 15;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1073, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
            this.barDockControlBottom.Size = new System.Drawing.Size(1073, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1073, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // imgListSmal
            // 
            this.imgListSmal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmal.ImageStream")));
            this.imgListSmal.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmal.Images.SetKeyName(0, "Grid_16x16.png");
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
            this.imgListLarge.Images.SetKeyName(13, "Grid_32x32.png");
            this.imgListLarge.Images.SetKeyName(14, "Refresh_32x32.png");
            this.imgListLarge.Images.SetKeyName(15, "Cancel_32x32.png");
            // 
            // ucChart
            // 
            this.ucChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart.Location = new System.Drawing.Point(0, 0);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(709, 427);
            this.ucChart.TabIndex = 11;
            // 
            // ucProcessLogTable
            // 
            this.ucProcessLogTable.CycleInfoS = null;
            this.ucProcessLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucProcessLogTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucProcessLogTable.Name = "ucProcessLogTable";
            this.ucProcessLogTable.Size = new System.Drawing.Size(354, 427);
            this.ucProcessLogTable.TabIndex = 16;
            this.ucProcessLogTable.UEventRowDoubleClicked += new UDMTrackerSimple.UEventHandlerProcessLogTableRowDoubleClicked(this.ucProcessLogTable_UEventRowDoubleClicked);
            // 
            // pnlRecipe
            // 
            this.pnlRecipe.Controls.Add(this.ucRecipeView);
            this.pnlRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecipe.Location = new System.Drawing.Point(0, 0);
            this.pnlRecipe.Name = "pnlRecipe";
            this.pnlRecipe.Size = new System.Drawing.Size(0, 0);
            this.pnlRecipe.TabIndex = 22;
            this.pnlRecipe.Visible = false;
            // 
            // ucRecipeView
            // 
            this.ucRecipeView.Appearance.BackColor = System.Drawing.Color.White;
            this.ucRecipeView.Appearance.Options.UseBackColor = true;
            this.ucRecipeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRecipeView.Location = new System.Drawing.Point(0, 0);
            this.ucRecipeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucRecipeView.Name = "ucRecipeView";
            this.ucRecipeView.RecipeLogS = null;
            this.ucRecipeView.RecipeTagS = null;
            this.ucRecipeView.Size = new System.Drawing.Size(0, 0);
            this.ucRecipeView.TabIndex = 0;
            this.ucRecipeView.Visible = false;
            // 
            // sptChart
            // 
            this.sptChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptChart.Location = new System.Drawing.Point(0, 0);
            this.sptChart.Name = "sptChart";
            this.sptChart.Panel1.Controls.Add(this.ucProcessLogTable);
            this.sptChart.Panel1.Text = "Panel1";
            this.sptChart.Panel2.Controls.Add(this.ucChart);
            this.sptChart.Panel2.Text = "Panel2";
            this.sptChart.Size = new System.Drawing.Size(1073, 427);
            this.sptChart.SplitterPosition = 354;
            this.sptChart.TabIndex = 28;
            this.sptChart.Text = "splitContainerControl1";
            this.sptChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptChart_MouseDoubleClick);
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Horizontal = false;
            this.sptMain.Location = new System.Drawing.Point(0, 65);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.pnlRecipe);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.sptChart);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1073, 437);
            this.sptMain.SplitterPosition = 0;
            this.sptMain.TabIndex = 29;
            this.sptMain.Text = "splitContainerControl2";
            // 
            // FrmCycleLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 527);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCycleLogViewer";
            this.Text = "Cycle Log Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCycleLogViewer_Load);
            this.Resize += new System.EventHandler(this.FrmCycleLogViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.exManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecipe)).EndInit();
            this.pnlRecipe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptChart)).EndInit();
            this.sptChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem cmbGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private System.Windows.Forms.ImageList imgListSmal;
		private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private UDM.UI.TimeChart.UCTimeChart ucChart;
        private UCProcessLogTable ucProcessLogTable;
        private DevExpress.XtraEditors.PanelControl pnlRecipe;
        private UCRecipeView ucRecipeView;
        private UDM.UI.MySplitContainerControl sptMain;
        private UDM.UI.MySplitContainerControl sptChart;
    }
}