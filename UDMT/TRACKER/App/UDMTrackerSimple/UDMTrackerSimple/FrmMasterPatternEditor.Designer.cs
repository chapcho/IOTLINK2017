namespace UDMTrackerSimple
{
    partial class FrmMasterPatternEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterPatternEditor));
            this.exBarManager = new DevExpress.XtraBars.BarManager();
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cmbGroup = new DevExpress.XtraBars.BarEditItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbRecipe = new DevExpress.XtraBars.BarEditItem();
            this.exEditorRecipe = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbIndex = new DevExpress.XtraBars.BarEditItem();
            this.exEditorIndex = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCreatePattern = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnRemovePattern = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListLarge = new System.Windows.Forms.ImageList();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ucFlowEditor = new UDMTrackerSimple.UCFlowGanttEditor2();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
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
            this.cmbGroup,
            this.cmbIndex,
            this.btnShow,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnCreatePattern,
            this.btnRemovePattern,
            this.cmbRecipe,
            this.btnApply,
            this.btnExit});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 19;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
            this.exEditorIndex,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.exEditorRecipe});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cmbGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmbRecipe),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmbIndex),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCreatePattern, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemovePattern),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApply, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
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
            this.cmbGroup.EditValueChanged += new System.EventHandler(this.cmbGroup_EditValueChanged);
            // 
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            this.exEditorGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // cmbRecipe
            // 
            this.cmbRecipe.Caption = "Recipe";
            this.cmbRecipe.Edit = this.exEditorRecipe;
            this.cmbRecipe.Id = 16;
            this.cmbRecipe.Name = "cmbRecipe";
            this.cmbRecipe.Width = 70;
            this.cmbRecipe.EditValueChanged += new System.EventHandler(this.cmbRecipe_EditValueChanged);
            // 
            // exEditorRecipe
            // 
            this.exEditorRecipe.AutoHeight = false;
            this.exEditorRecipe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorRecipe.Name = "exEditorRecipe";
            this.exEditorRecipe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // cmbIndex
            // 
            this.cmbIndex.Edit = this.exEditorIndex;
            this.cmbIndex.Id = 2;
            this.cmbIndex.Name = "cmbIndex";
            // 
            // exEditorIndex
            // 
            this.exEditorIndex.AutoHeight = false;
            this.exEditorIndex.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorIndex.Name = "exEditorIndex";
            this.exEditorIndex.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 3;
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
            // btnCreatePattern
            // 
            this.btnCreatePattern.Caption = "Create\r\nPattern";
            this.btnCreatePattern.Id = 9;
            this.btnCreatePattern.LargeImageIndex = 6;
            this.btnCreatePattern.Name = "btnCreatePattern";
            this.btnCreatePattern.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreatePattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreatePattern_ItemClick);
            // 
            // btnRemovePattern
            // 
            this.btnRemovePattern.Caption = "Remove\r\nPattern";
            this.btnRemovePattern.Id = 13;
            this.btnRemovePattern.LargeImageIndex = 5;
            this.btnRemovePattern.Name = "btnRemovePattern";
            this.btnRemovePattern.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRemovePattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemovePattern_ItemClick);
            // 
            // btnApply
            // 
            this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnApply.Caption = "Apply";
            this.btnApply.Id = 17;
            this.btnApply.LargeImageIndex = 13;
            this.btnApply.Name = "btnApply";
            this.btnApply.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 18;
            this.btnExit.LargeImageIndex = 14;
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
            this.barDockControlTop.Size = new System.Drawing.Size(978, 80);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 395);
            this.barDockControlBottom.Size = new System.Drawing.Size(978, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 80);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 315);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(978, 80);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 315);
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
            this.imgListLarge.Images.SetKeyName(13, "Apply_32x32.png");
            this.imgListLarge.Images.SetKeyName(14, "Cancel_32x32.png");
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // ucFlowEditor
            // 
            this.ucFlowEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFlowEditor.Location = new System.Drawing.Point(0, 80);
            this.ucFlowEditor.Name = "ucFlowEditor";
            this.ucFlowEditor.Size = new System.Drawing.Size(978, 315);
            this.ucFlowEditor.TabIndex = 4;
            // 
            // FrmMasterPatternEditor
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 420);
            this.Controls.Add(this.ucFlowEditor);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMasterPatternEditor";
            this.Text = "Pattern Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPatternEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem cmbGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem cmbIndex;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorIndex;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private UCFlowGanttEditor2 ucFlowEditor;
        private DevExpress.XtraBars.BarLargeButtonItem btnCreatePattern;
        private DevExpress.XtraBars.BarLargeButtonItem btnRemovePattern;
        private DevExpress.XtraBars.BarEditItem cmbRecipe;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorRecipe;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
    }
}