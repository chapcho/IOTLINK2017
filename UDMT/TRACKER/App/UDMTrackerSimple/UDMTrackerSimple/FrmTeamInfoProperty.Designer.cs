namespace UDMTrackerSimple
{
    partial class FrmTeamInfoProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeamInfoProperty));
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.btnAddTeam = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.dtpkOperStart = new DevExpress.XtraBars.BarEditItem();
            this.exEditorOperStart = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkOperEnd = new DevExpress.XtraBars.BarEditItem();
            this.exEditorOperEnd = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.grdTag = new DevExpress.XtraGrid.GridControl();
            this.grvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTeam = new DevExpress.XtraEditors.PanelControl();
            this.grpRecipe = new DevExpress.XtraEditors.GroupControl();
            this.grdRecipeTagS = new DevExpress.XtraGrid.GridControl();
            this.cntxTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.grvRecipeTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.grpProductionEnd = new DevExpress.XtraEditors.GroupControl();
            this.grdEndTag = new DevExpress.XtraGrid.GridControl();
            this.grvEndTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.btnOperationReset = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeam)).BeginInit();
            this.pnlTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipe)).BeginInit();
            this.grpRecipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).BeginInit();
            this.cntxTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductionEnd)).BeginInit();
            this.grpProductionEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEndTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEndTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
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
            this.imgListLarge.Images.SetKeyName(16, "Squeeze_32x32.png");
            this.imgListLarge.Images.SetKeyName(17, "Stretch_32x32.png");
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddTeam,
            this.btnClear,
            this.btnExit,
            this.btnApply,
            this.dtpkOperStart,
            this.dtpkOperEnd,
            this.btnOperationReset});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 19;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorPLC,
            this.exEditorOperStart,
            this.exEditorOperEnd});
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddTeam),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnApply, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkOperStart, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkOperEnd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOperationReset)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Caption = "Add Team";
            this.btnAddTeam.Id = 0;
            this.btnAddTeam.ImageUri.Uri = "Add";
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddTeam_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "All Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 1;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnApply
            // 
            this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnApply.Caption = "Apply";
            this.btnApply.Id = 9;
            this.btnApply.ImageUri.Uri = "Apply";
            this.btnApply.Name = "btnApply";
            this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 6;
            this.btnExit.LargeImageIndex = 15;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // dtpkOperStart
            // 
            this.dtpkOperStart.Caption = "라인 구동 시간 : ";
            this.dtpkOperStart.Edit = this.exEditorOperStart;
            this.dtpkOperStart.Id = 16;
            this.dtpkOperStart.Name = "dtpkOperStart";
            this.dtpkOperStart.Width = 100;
            // 
            // exEditorOperStart
            // 
            this.exEditorOperStart.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorOperStart.Appearance.Options.UseFont = true;
            this.exEditorOperStart.Appearance.Options.UseTextOptions = true;
            this.exEditorOperStart.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorOperStart.AutoHeight = false;
            this.exEditorOperStart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOperStart.DisplayFormat.FormatString = "HH:mm";
            this.exEditorOperStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperStart.EditFormat.FormatString = "HH:mm";
            this.exEditorOperStart.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperStart.Mask.EditMask = "HH:mm";
            this.exEditorOperStart.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorOperStart.Name = "exEditorOperStart";
            // 
            // dtpkOperEnd
            // 
            this.dtpkOperEnd.Caption = " ~  ";
            this.dtpkOperEnd.Edit = this.exEditorOperEnd;
            this.dtpkOperEnd.Id = 17;
            this.dtpkOperEnd.Name = "dtpkOperEnd";
            this.dtpkOperEnd.Width = 100;
            // 
            // exEditorOperEnd
            // 
            this.exEditorOperEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorOperEnd.Appearance.Options.UseFont = true;
            this.exEditorOperEnd.Appearance.Options.UseTextOptions = true;
            this.exEditorOperEnd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorOperEnd.AutoHeight = false;
            this.exEditorOperEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOperEnd.DisplayFormat.FormatString = "HH:mm";
            this.exEditorOperEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperEnd.EditFormat.FormatString = "HH:mm";
            this.exEditorOperEnd.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperEnd.Mask.EditMask = "HH:mm";
            this.exEditorOperEnd.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorOperEnd.Name = "exEditorOperEnd";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(809, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 674);
            this.barDockControlBottom.Size = new System.Drawing.Size(809, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 609);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(809, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 609);
            // 
            // exEditorPLC
            // 
            this.exEditorPLC.AutoHeight = false;
            this.exEditorPLC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPLC.Name = "exEditorPLC";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(341, 65);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 609);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // grdTag
            // 
            this.grdTag.AllowDrop = true;
            this.grdTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTag.Location = new System.Drawing.Point(346, 65);
            this.grdTag.LookAndFeel.SkinName = "Office 2013";
            this.grdTag.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTag.MainView = this.grvTag;
            this.grdTag.Name = "grdTag";
            this.grdTag.Size = new System.Drawing.Size(463, 609);
            this.grdTag.TabIndex = 8;
            this.grdTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTag});
            // 
            // grvTag
            // 
            this.grvTag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDescription,
            this.colDataType});
            this.grvTag.GridControl = this.grdTag;
            this.grvTag.Name = "grvTag";
            this.grvTag.OptionsBehavior.Editable = false;
            this.grvTag.OptionsBehavior.ReadOnly = true;
            this.grvTag.OptionsCustomization.AllowColumnMoving = false;
            this.grvTag.OptionsDetail.AllowZoomDetail = false;
            this.grvTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvTag.OptionsDetail.SmartDetailExpand = false;
            this.grvTag.OptionsSelection.MultiSelect = true;
            this.grvTag.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvTag.OptionsView.ShowAutoFilterRow = true;
            this.grvTag.OptionsView.ShowGroupPanel = false;
            this.grvTag.OptionsView.ShowIndicator = false;
            this.grvTag.RowHeight = 30;
            this.grvTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvTag_MouseDown);
            this.grvTag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvTag_MouseMove);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseForeColor = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 70;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseForeColor = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 207;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType.AppearanceCell.Options.UseFont = true;
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colDataType.AppearanceHeader.Options.UseFont = true;
            this.colDataType.AppearanceHeader.Options.UseForeColor = true;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 1;
            this.colDataType.Width = 79;
            // 
            // pnlTeam
            // 
            this.pnlTeam.Controls.Add(this.grpRecipe);
            this.pnlTeam.Controls.Add(this.splitterControl2);
            this.pnlTeam.Controls.Add(this.grpProductionEnd);
            this.pnlTeam.Controls.Add(this.tabMain);
            this.pnlTeam.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTeam.Location = new System.Drawing.Point(0, 65);
            this.pnlTeam.Name = "pnlTeam";
            this.pnlTeam.Size = new System.Drawing.Size(341, 609);
            this.pnlTeam.TabIndex = 13;
            // 
            // grpRecipe
            // 
            this.grpRecipe.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRecipe.AppearanceCaption.Options.UseFont = true;
            this.grpRecipe.Controls.Add(this.grdRecipeTagS);
            this.grpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRecipe.Location = new System.Drawing.Point(2, 439);
            this.grpRecipe.Name = "grpRecipe";
            this.grpRecipe.Size = new System.Drawing.Size(337, 168);
            this.grpRecipe.TabIndex = 6;
            this.grpRecipe.Text = "Recipe Word";
            // 
            // grdRecipeTagS
            // 
            this.grdRecipeTagS.AllowDrop = true;
            this.grdRecipeTagS.ContextMenuStrip = this.cntxTag;
            this.grdRecipeTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecipeTagS.Location = new System.Drawing.Point(2, 30);
            this.grdRecipeTagS.MainView = this.grvRecipeTagS;
            this.grdRecipeTagS.Name = "grdRecipeTagS";
            this.grdRecipeTagS.Size = new System.Drawing.Size(333, 136);
            this.grdRecipeTagS.TabIndex = 7;
            this.grdRecipeTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRecipeTagS});
            this.grdRecipeTagS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdRecipeTagS_DragDrop);
            this.grdRecipeTagS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdRecipeTagS_DragOver);
            // 
            // cntxTag
            // 
            this.cntxTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClear});
            this.cntxTag.Name = "cntxTag";
            this.cntxTag.Size = new System.Drawing.Size(102, 26);
            // 
            // mnuClear
            // 
            this.mnuClear.Image = ((System.Drawing.Image)(resources.GetObject("mnuClear.Image")));
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(101, 22);
            this.mnuClear.Text = "Clear";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // grvRecipeTagS
            // 
            this.grvRecipeTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.grvRecipeTagS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRecipeTagS.GridControl = this.grdRecipeTagS;
            this.grvRecipeTagS.IndicatorWidth = 35;
            this.grvRecipeTagS.Name = "grvRecipeTagS";
            this.grvRecipeTagS.OptionsBehavior.Editable = false;
            this.grvRecipeTagS.OptionsBehavior.ReadOnly = true;
            this.grvRecipeTagS.OptionsDetail.EnableMasterViewMode = false;
            this.grvRecipeTagS.OptionsDetail.ShowDetailTabs = false;
            this.grvRecipeTagS.OptionsDetail.SmartDetailExpand = false;
            this.grvRecipeTagS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvRecipeTagS.OptionsView.ShowGroupPanel = false;
            this.grvRecipeTagS.RowHeight = 30;
            this.grvRecipeTagS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRecipeTagS_CustomDrawRowIndicator);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Key";
            this.gridColumn2.FieldName = "Key";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 114;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 146;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(2, 434);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(337, 5);
            this.splitterControl2.TabIndex = 8;
            this.splitterControl2.TabStop = false;
            // 
            // grpProductionEnd
            // 
            this.grpProductionEnd.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProductionEnd.AppearanceCaption.Options.UseFont = true;
            this.grpProductionEnd.Controls.Add(this.grdEndTag);
            this.grpProductionEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProductionEnd.Location = new System.Drawing.Point(2, 341);
            this.grpProductionEnd.Name = "grpProductionEnd";
            this.grpProductionEnd.Size = new System.Drawing.Size(337, 93);
            this.grpProductionEnd.TabIndex = 7;
            this.grpProductionEnd.Text = "Production End Tag";
            // 
            // grdEndTag
            // 
            this.grdEndTag.AllowDrop = true;
            this.grdEndTag.ContextMenuStrip = this.cntxTag;
            this.grdEndTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEndTag.Location = new System.Drawing.Point(2, 30);
            this.grdEndTag.MainView = this.grvEndTag;
            this.grdEndTag.Name = "grdEndTag";
            this.grdEndTag.Size = new System.Drawing.Size(333, 61);
            this.grdEndTag.TabIndex = 6;
            this.grdEndTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEndTag});
            this.grdEndTag.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdEndTag_DragDrop);
            this.grdEndTag.DragOver += new System.Windows.Forms.DragEventHandler(this.grdEndTag_DragOver);
            // 
            // grvEndTag
            // 
            this.grvEndTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.gridColumn1});
            this.grvEndTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEndTag.GridControl = this.grdEndTag;
            this.grvEndTag.Name = "grvEndTag";
            this.grvEndTag.OptionsBehavior.Editable = false;
            this.grvEndTag.OptionsBehavior.ReadOnly = true;
            this.grvEndTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvEndTag.OptionsDetail.ShowDetailTabs = false;
            this.grvEndTag.OptionsDetail.SmartDetailExpand = false;
            this.grvEndTag.OptionsView.ShowGroupPanel = false;
            this.grvEndTag.OptionsView.ShowIndicator = false;
            this.grvEndTag.RowHeight = 25;
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKey.AppearanceHeader.Options.UseFont = true;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.FixedWidth = true;
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 114;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Description";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 146;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(337, 339);
            this.tabMain.TabIndex = 5;
            // 
            // btnOperationReset
            // 
            this.btnOperationReset.Caption = "Reset";
            this.btnOperationReset.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOperationReset.Glyph")));
            this.btnOperationReset.Id = 18;
            this.btnOperationReset.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOperationReset.LargeGlyph")));
            this.btnOperationReset.Name = "btnOperationReset";
            this.btnOperationReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOperationReset_ItemClick);
            // 
            // FrmTeamInfoProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 674);
            this.Controls.Add(this.grdTag);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.pnlTeam);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmTeamInfoProperty";
            this.Text = "Product Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTeamInfoProperty_FormClosing);
            this.Load += new System.EventHandler(this.FrmTeamInfoProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeam)).EndInit();
            this.pnlTeam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipe)).EndInit();
            this.grpRecipe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).EndInit();
            this.cntxTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductionEnd)).EndInit();
            this.grpProductionEnd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEndTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEndTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarLargeButtonItem btnAddTeam;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private DevExpress.XtraGrid.GridControl grdTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTag;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.PanelControl pnlTeam;
        private DevExpress.XtraEditors.GroupControl grpProductionEnd;
        private DevExpress.XtraEditors.GroupControl grpRecipe;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraGrid.GridControl grdEndTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEndTag;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl grdRecipeTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRecipeTagS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.ContextMenuStrip cntxTag;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraBars.BarEditItem dtpkOperStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorOperStart;
        private DevExpress.XtraBars.BarEditItem dtpkOperEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorOperEnd;
        private DevExpress.XtraBars.BarLargeButtonItem btnOperationReset;
    }
}