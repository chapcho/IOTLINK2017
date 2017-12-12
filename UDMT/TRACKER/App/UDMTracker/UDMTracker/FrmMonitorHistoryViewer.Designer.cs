namespace UDMTracker
{
    partial class FrmMonitorHistoryViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitorHistoryViewer));
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.exBarManager = new DevExpress.XtraBars.BarManager();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
            this.imgListLarge = new System.Windows.Forms.ImageList();
            this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.exEditorDiscriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.exGrdMonitorHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetectionHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFstUpdDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFnlUpdDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFnlUpder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonitorNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDiscriptionFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdMonitorHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetectionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.DrawSizeGrip = true;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.DrawSizeGrip = true;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Tools";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.OptionsBar.DrawSizeGrip = true;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Tools";
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4,
            this.bar5});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnRefresh,
            this.btnClear,
            this.btnApply,
            this.btnExit});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 17;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo,
            this.exEditorAddressFilter,
            this.exEditorDiscriptionFilter});
            this.exBarManager.StatusBar = this.bar5;
            // 
            // bar4
            // 
            this.bar4.BarName = "Tools";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.bar4.OptionsBar.DrawSizeGrip = true;
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2016, 1, 18, 18, 59, 34, 719);
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 120;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // dtpkTo
            // 
            this.dtpkTo.Caption = "To";
            this.dtpkTo.Edit = this.exEditorTo;
            this.dtpkTo.EditValue = new System.DateTime(2016, 1, 18, 18, 59, 34, 726);
            this.dtpkTo.Id = 2;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 120;
            // 
            // exEditorTo
            // 
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageUri.Uri = "Refresh";
            this.btnRefresh.LargeImageIndex = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.ActAsDropDown = true;
            this.btnClear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnClear.Caption = "Clear";
            this.btnClear.DropDownControl = this.galleryDropDown1;
            this.btnClear.Id = 6;
            this.btnClear.LargeImageIndex = 1;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Manager = this.exBarManager;
            this.galleryDropDown1.Name = "galleryDropDown1";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 9;
            this.btnExit.LargeImageIndex = 3;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // bar5
            // 
            this.bar5.BarName = "Status bar";
            this.bar5.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Status bar";
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
            this.barDockControlTop.Size = new System.Drawing.Size(952, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 480);
            this.barDockControlBottom.Size = new System.Drawing.Size(952, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(952, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
            // 
            // btnApply
            // 
            this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnApply.Caption = "Apply";
            this.btnApply.Id = 8;
            this.btnApply.LargeImageIndex = 2;
            this.btnApply.Name = "btnApply";
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "Refresh_32x32.png");
            this.imgListLarge.Images.SetKeyName(1, "RemoveItem_32x32.png");
            this.imgListLarge.Images.SetKeyName(2, "Apply_32x32.png");
            this.imgListLarge.Images.SetKeyName(3, "Cancel_32x32.png");
            // 
            // exEditorAddressFilter
            // 
            this.exEditorAddressFilter.AutoHeight = false;
            this.exEditorAddressFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAddressFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.exEditorAddressFilter.Name = "exEditorAddressFilter";
            // 
            // exEditorDiscriptionFilter
            // 
            this.exEditorDiscriptionFilter.AutoHeight = false;
            this.exEditorDiscriptionFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDiscriptionFilter.Name = "exEditorDiscriptionFilter";
            // 
            // exGrdMonitorHistory
            // 
            this.exGrdMonitorHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrdMonitorHistory.Location = new System.Drawing.Point(0, 65);
            this.exGrdMonitorHistory.MainView = this.gridViewDetectionHistory;
            this.exGrdMonitorHistory.Name = "exGrdMonitorHistory";
            this.exGrdMonitorHistory.Padding = new System.Windows.Forms.Padding(2);
            this.exGrdMonitorHistory.Size = new System.Drawing.Size(952, 415);
            this.exGrdMonitorHistory.TabIndex = 4;
            this.exGrdMonitorHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetectionHistory});
            // 
            // gridViewDetectionHistory
            // 
            this.gridViewDetectionHistory.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridViewDetectionHistory.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridViewDetectionHistory.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewDetectionHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcess,
            this.colProduct,
            this.colRecipe,
            this.colFstUpdDt,
            this.colFnlUpdDt,
            this.colFnlUpder,
            this.colClearDt,
            this.colErrorCode,
            this.colDescription,
            this.colMonitorNote});
            this.gridViewDetectionHistory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDetectionHistory.GridControl = this.exGrdMonitorHistory;
            this.gridViewDetectionHistory.Name = "gridViewDetectionHistory";
            this.gridViewDetectionHistory.OptionsBehavior.Editable = false;
            this.gridViewDetectionHistory.OptionsBehavior.ReadOnly = true;
            this.gridViewDetectionHistory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDetectionHistory.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewDetectionHistory.OptionsSelection.InvertSelection = true;
            this.gridViewDetectionHistory.OptionsSelection.UseIndicatorForSelection = false;
            this.gridViewDetectionHistory.OptionsView.ShowGroupPanel = false;
            this.gridViewDetectionHistory.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDetectionHistory_RowStyle);
            // 
            // colProcess
            // 
            this.colProcess.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.Caption = "공정";
            this.colProcess.CustomizationCaption = "공정(Process)";
            this.colProcess.FieldName = "Key";
            this.colProcess.Name = "colProcess";
            this.colProcess.Visible = true;
            this.colProcess.VisibleIndex = 0;
            this.colProcess.Width = 100;
            // 
            // colProduct
            // 
            this.colProduct.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduct.Caption = "제품";
            this.colProduct.CustomizationCaption = "제품(Product)";
            this.colProduct.FieldName = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 3;
            this.colProduct.Width = 92;
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.Caption = "레시피";
            this.colRecipe.CustomizationCaption = "레시피(Recipe)";
            this.colRecipe.FieldName = "Recipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.Visible = true;
            this.colRecipe.VisibleIndex = 4;
            this.colRecipe.Width = 92;
            // 
            // colFstUpdDt
            // 
            this.colFstUpdDt.AppearanceHeader.Options.UseTextOptions = true;
            this.colFstUpdDt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFstUpdDt.Caption = "생성일시";
            this.colFstUpdDt.CustomizationCaption = "생성일시(FirstUpdateDT)";
            this.colFstUpdDt.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss.fff";
            this.colFstUpdDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFstUpdDt.FieldName = "FirstUpdateDT";
            this.colFstUpdDt.Name = "colFstUpdDt";
            this.colFstUpdDt.Visible = true;
            this.colFstUpdDt.VisibleIndex = 1;
            this.colFstUpdDt.Width = 92;
            // 
            // colFnlUpdDt
            // 
            this.colFnlUpdDt.AppearanceHeader.Options.UseTextOptions = true;
            this.colFnlUpdDt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFnlUpdDt.Caption = "수정일시";
            this.colFnlUpdDt.CustomizationCaption = "수정일시(FinalUpdateDT)";
            this.colFnlUpdDt.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss.fff";
            this.colFnlUpdDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFnlUpdDt.FieldName = "FinalUpdateDT";
            this.colFnlUpdDt.Name = "colFnlUpdDt";
            this.colFnlUpdDt.Visible = true;
            this.colFnlUpdDt.VisibleIndex = 2;
            this.colFnlUpdDt.Width = 92;
            // 
            // colFnlUpder
            // 
            this.colFnlUpder.AppearanceHeader.Options.UseTextOptions = true;
            this.colFnlUpder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFnlUpder.Caption = "수정자";
            this.colFnlUpder.CustomizationCaption = "수정자(FinalUpder)";
            this.colFnlUpder.FieldName = "FinalUpdater";
            this.colFnlUpder.Name = "colFnlUpder";
            this.colFnlUpder.Visible = true;
            this.colFnlUpder.VisibleIndex = 5;
            this.colFnlUpder.Width = 92;
            // 
            // colClearDt
            // 
            this.colClearDt.AppearanceHeader.Options.UseTextOptions = true;
            this.colClearDt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClearDt.Caption = "조치일시";
            this.colClearDt.CustomizationCaption = "조치일시(ClearDT)";
            this.colClearDt.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss.fff";
            this.colClearDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colClearDt.FieldName = "ClearDT";
            this.colClearDt.Name = "colClearDt";
            this.colClearDt.Visible = true;
            this.colClearDt.VisibleIndex = 6;
            this.colClearDt.Width = 92;
            // 
            // colErrorCode
            // 
            this.colErrorCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCode.Caption = "에러코드";
            this.colErrorCode.CustomizationCaption = "에러코드(ErrorCode)";
            this.colErrorCode.FieldName = "ErrorCode";
            this.colErrorCode.Name = "colErrorCode";
            this.colErrorCode.Visible = true;
            this.colErrorCode.VisibleIndex = 7;
            this.colErrorCode.Width = 92;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "설명";
            this.colDescription.CustomizationCaption = "설명(ErrorDescription)";
            this.colDescription.FieldName = "ErrorDescription";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 8;
            this.colDescription.Width = 92;
            // 
            // colMonitorNote
            // 
            this.colMonitorNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonitorNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonitorNote.Caption = "비고";
            this.colMonitorNote.CustomizationCaption = "비고(MonitorNote)";
            this.colMonitorNote.FieldName = "MonitorNote";
            this.colMonitorNote.Name = "colMonitorNote";
            this.colMonitorNote.Visible = true;
            this.colMonitorNote.VisibleIndex = 9;
            this.colMonitorNote.Width = 98;
            // 
            // FrmMonitorHistoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 505);
            this.Controls.Add(this.exGrdMonitorHistory);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMonitorHistoryViewer";
            this.Text = "Monitor 이력 조회";
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDiscriptionFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdMonitorHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetectionHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDiscriptionFilter;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private DevExpress.XtraGrid.GridControl exGrdMonitorHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetectionHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipe;
        private DevExpress.XtraGrid.Columns.GridColumn colFstUpdDt;
        private DevExpress.XtraGrid.Columns.GridColumn colFnlUpdDt;
        private DevExpress.XtraGrid.Columns.GridColumn colFnlUpder;
        private DevExpress.XtraGrid.Columns.GridColumn colClearDt;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMonitorNote;
    }
}