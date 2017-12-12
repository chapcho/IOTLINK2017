namespace UDMTrackerSimple
{
    partial class FrmDeviceDetailViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeviceDetailViewer));
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.dtpkTime = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.exEditorMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpCycle = new DevExpress.XtraTab.XtraTabPage();
            this.grdCycle = new DevExpress.XtraGrid.GridControl();
            this.grvCycle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.bandProcess = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGroupKey = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandAllCycle = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCheck = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCycleAvr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProcessAvr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIdleAvr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMax = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMin = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandCycleAtTime = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCycleStart = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.exEditorTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colCycleTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProcessTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIdleTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.tpError = new DevExpress.XtraTab.XtraTabPage();
            this.ucError = new UDMTrackerSimple.UserControls.UCErrorLogGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpCycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).BeginInit();
            this.tpError.SuspendLayout();
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
            this.imgListLarge.Images.SetKeyName(13, "Cancel_32x32.png");
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
            this.lblStatus,
            this.dtpkTime,
            this.btnShow,
            this.btnExit});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 21;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo,
            this.exEditorColor,
            this.exEditorMin,
            this.exEditorMax,
            this.exEditorPLC});
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTime, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // dtpkTime
            // 
            this.dtpkTime.Caption = "Time";
            this.dtpkTime.Edit = this.exEditorFrom;
            this.dtpkTime.EditValue = new System.DateTime(2015, 2, 24, 21, 32, 0, 275);
            this.dtpkTime.Id = 1;
            this.dtpkTime.Name = "dtpkTime";
            this.dtpkTime.Width = 120;
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
            this.exEditorFrom.ReadOnly = true;
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShow.Glyph")));
            this.btnShow.Id = 9;
            this.btnShow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShow.LargeGlyph")));
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(955, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 623);
            this.barDockControlBottom.Size = new System.Drawing.Size(955, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 558);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(955, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 558);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
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
            // exEditorColor
            // 
            this.exEditorColor.AutoHeight = false;
            this.exEditorColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColor.Name = "exEditorColor";
            // 
            // exEditorMin
            // 
            this.exEditorMin.AutoHeight = false;
            this.exEditorMin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMin.Name = "exEditorMin";
            this.exEditorMin.NullText = "0";
            // 
            // exEditorMax
            // 
            this.exEditorMax.AutoHeight = false;
            this.exEditorMax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMax.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorMax.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorMax.Name = "exEditorMax";
            this.exEditorMax.NullText = "10";
            // 
            // exEditorPLC
            // 
            this.exEditorPLC.AutoHeight = false;
            this.exEditorPLC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPLC.Name = "exEditorPLC";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 65);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpCycle;
            this.tabMain.Size = new System.Drawing.Size(955, 558);
            this.tabMain.TabIndex = 4;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpCycle,
            this.tpError});
            // 
            // tpCycle
            // 
            this.tpCycle.Controls.Add(this.grdCycle);
            this.tpCycle.Name = "tpCycle";
            this.tpCycle.Size = new System.Drawing.Size(949, 529);
            this.tpCycle.Text = "Cycle Information";
            // 
            // grdCycle
            // 
            this.grdCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCycle.Location = new System.Drawing.Point(0, 0);
            this.grdCycle.MainView = this.grvCycle;
            this.grdCycle.Name = "grdCycle";
            this.grdCycle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorTime});
            this.grdCycle.Size = new System.Drawing.Size(949, 529);
            this.grdCycle.TabIndex = 1;
            this.grdCycle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCycle});
            // 
            // grvCycle
            // 
            this.grvCycle.BandPanelRowHeight = 40;
            this.grvCycle.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandProcess,
            this.bandAllCycle,
            this.bandCycleAtTime});
            this.grvCycle.ColumnPanelRowHeight = 40;
            this.grvCycle.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colGroupKey,
            this.colCycleAvr,
            this.colMin,
            this.colMax,
            this.colCycleStart,
            this.colCycleTime,
            this.colProcessAvr,
            this.colIdleAvr,
            this.colProcessTime,
            this.colIdleTime,
            this.colCheck});
            this.grvCycle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvCycle.GridControl = this.grdCycle;
            this.grvCycle.Name = "grvCycle";
            this.grvCycle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvCycle.OptionsBehavior.Editable = false;
            this.grvCycle.OptionsBehavior.ReadOnly = true;
            this.grvCycle.OptionsCustomization.AllowBandMoving = false;
            this.grvCycle.OptionsCustomization.AllowColumnMoving = false;
            this.grvCycle.OptionsDetail.AllowZoomDetail = false;
            this.grvCycle.OptionsDetail.EnableMasterViewMode = false;
            this.grvCycle.OptionsDetail.ShowDetailTabs = false;
            this.grvCycle.OptionsDetail.SmartDetailExpand = false;
            this.grvCycle.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCycle.OptionsView.ShowAutoFilterRow = true;
            this.grvCycle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvCycle.OptionsView.ShowGroupPanel = false;
            this.grvCycle.RowHeight = 40;
            this.grvCycle.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvCycle_RowStyle);
            this.grvCycle.DoubleClick += new System.EventHandler(this.grvCycle_DoubleClick);
            // 
            // bandProcess
            // 
            this.bandProcess.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bandProcess.AppearanceHeader.Options.UseFont = true;
            this.bandProcess.Caption = "Process";
            this.bandProcess.Columns.Add(this.colGroupKey);
            this.bandProcess.Name = "bandProcess";
            this.bandProcess.VisibleIndex = 0;
            this.bandProcess.Width = 93;
            // 
            // colGroupKey
            // 
            this.colGroupKey.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceCell.Options.UseFont = true;
            this.colGroupKey.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceHeader.Options.UseFont = true;
            this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.Caption = "Name";
            this.colGroupKey.FieldName = "ProcessName";
            this.colGroupKey.Name = "colGroupKey";
            this.colGroupKey.OptionsColumn.FixedWidth = true;
            this.colGroupKey.OptionsColumn.ReadOnly = true;
            this.colGroupKey.Visible = true;
            this.colGroupKey.Width = 93;
            // 
            // bandAllCycle
            // 
            this.bandAllCycle.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bandAllCycle.AppearanceHeader.Options.UseFont = true;
            this.bandAllCycle.Caption = "All Cycle";
            this.bandAllCycle.Columns.Add(this.colCheck);
            this.bandAllCycle.Columns.Add(this.colCycleAvr);
            this.bandAllCycle.Columns.Add(this.colProcessAvr);
            this.bandAllCycle.Columns.Add(this.colIdleAvr);
            this.bandAllCycle.Columns.Add(this.colMax);
            this.bandAllCycle.Columns.Add(this.colMin);
            this.bandAllCycle.Name = "bandAllCycle";
            this.bandAllCycle.VisibleIndex = 1;
            this.bandAllCycle.Width = 409;
            // 
            // colCheck
            // 
            this.colCheck.Caption = "Check";
            this.colCheck.FieldName = "DelayCheck";
            this.colCheck.Name = "colCheck";
            // 
            // colCycleAvr
            // 
            this.colCycleAvr.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleAvr.AppearanceCell.Options.UseFont = true;
            this.colCycleAvr.AppearanceCell.Options.UseTextOptions = true;
            this.colCycleAvr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleAvr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleAvr.AppearanceHeader.Options.UseFont = true;
            this.colCycleAvr.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleAvr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleAvr.Caption = "Cycle Avr.";
            this.colCycleAvr.FieldName = "CycleAvr";
            this.colCycleAvr.Name = "colCycleAvr";
            this.colCycleAvr.Visible = true;
            this.colCycleAvr.Width = 99;
            // 
            // colProcessAvr
            // 
            this.colProcessAvr.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcessAvr.AppearanceCell.Options.UseFont = true;
            this.colProcessAvr.AppearanceCell.Options.UseTextOptions = true;
            this.colProcessAvr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessAvr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcessAvr.AppearanceHeader.Options.UseFont = true;
            this.colProcessAvr.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcessAvr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessAvr.Caption = "Process Avr.";
            this.colProcessAvr.FieldName = "TactAvr";
            this.colProcessAvr.Name = "colProcessAvr";
            this.colProcessAvr.Visible = true;
            this.colProcessAvr.Width = 90;
            // 
            // colIdleAvr
            // 
            this.colIdleAvr.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdleAvr.AppearanceCell.Options.UseFont = true;
            this.colIdleAvr.AppearanceCell.Options.UseTextOptions = true;
            this.colIdleAvr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdleAvr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdleAvr.AppearanceHeader.Options.UseFont = true;
            this.colIdleAvr.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdleAvr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdleAvr.Caption = "Idle Avr.";
            this.colIdleAvr.FieldName = "IdleAvr";
            this.colIdleAvr.Name = "colIdleAvr";
            this.colIdleAvr.Visible = true;
            this.colIdleAvr.Width = 91;
            // 
            // colMax
            // 
            this.colMax.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMax.AppearanceCell.Options.UseFont = true;
            this.colMax.AppearanceCell.Options.UseTextOptions = true;
            this.colMax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMax.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMax.AppearanceHeader.Options.UseFont = true;
            this.colMax.AppearanceHeader.Options.UseTextOptions = true;
            this.colMax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMax.Caption = "Max";
            this.colMax.FieldName = "Max";
            this.colMax.Name = "colMax";
            this.colMax.Visible = true;
            this.colMax.Width = 61;
            // 
            // colMin
            // 
            this.colMin.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMin.AppearanceCell.Options.UseFont = true;
            this.colMin.AppearanceCell.Options.UseTextOptions = true;
            this.colMin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMin.AppearanceHeader.Options.UseFont = true;
            this.colMin.AppearanceHeader.Options.UseTextOptions = true;
            this.colMin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMin.Caption = "Min";
            this.colMin.FieldName = "Min";
            this.colMin.Name = "colMin";
            this.colMin.Visible = true;
            this.colMin.Width = 68;
            // 
            // bandCycleAtTime
            // 
            this.bandCycleAtTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bandCycleAtTime.AppearanceHeader.Options.UseFont = true;
            this.bandCycleAtTime.Caption = "Cycle At Time";
            this.bandCycleAtTime.Columns.Add(this.colCycleStart);
            this.bandCycleAtTime.Columns.Add(this.colCycleTime);
            this.bandCycleAtTime.Columns.Add(this.colProcessTime);
            this.bandCycleAtTime.Columns.Add(this.colIdleTime);
            this.bandCycleAtTime.Name = "bandCycleAtTime";
            this.bandCycleAtTime.VisibleIndex = 2;
            this.bandCycleAtTime.Width = 433;
            // 
            // colCycleStart
            // 
            this.colCycleStart.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleStart.AppearanceCell.Options.UseFont = true;
            this.colCycleStart.AppearanceCell.Options.UseTextOptions = true;
            this.colCycleStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStart.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleStart.AppearanceHeader.Options.UseFont = true;
            this.colCycleStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStart.Caption = "Cycle Start";
            this.colCycleStart.ColumnEdit = this.exEditorTime;
            this.colCycleStart.FieldName = "CycleStart";
            this.colCycleStart.Name = "colCycleStart";
            this.colCycleStart.Visible = true;
            this.colCycleStart.Width = 150;
            // 
            // exEditorTime
            // 
            this.exEditorTime.AutoHeight = false;
            this.exEditorTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.exEditorTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.EditFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.exEditorTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.Mask.EditMask = "yy.MM.dd HH:mm:ss";
            this.exEditorTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTime.Name = "exEditorTime";
            // 
            // colCycleTime
            // 
            this.colCycleTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleTime.AppearanceCell.Options.UseFont = true;
            this.colCycleTime.AppearanceCell.Options.UseTextOptions = true;
            this.colCycleTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleTime.AppearanceHeader.Options.UseFont = true;
            this.colCycleTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleTime.Caption = "Cycle";
            this.colCycleTime.FieldName = "Cycle";
            this.colCycleTime.Name = "colCycleTime";
            this.colCycleTime.Visible = true;
            this.colCycleTime.Width = 89;
            // 
            // colProcessTime
            // 
            this.colProcessTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcessTime.AppearanceCell.Options.UseFont = true;
            this.colProcessTime.AppearanceCell.Options.UseTextOptions = true;
            this.colProcessTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcessTime.AppearanceHeader.Options.UseFont = true;
            this.colProcessTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcessTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessTime.Caption = "Process";
            this.colProcessTime.FieldName = "Tact";
            this.colProcessTime.Name = "colProcessTime";
            this.colProcessTime.Visible = true;
            this.colProcessTime.Width = 89;
            // 
            // colIdleTime
            // 
            this.colIdleTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdleTime.AppearanceCell.Options.UseFont = true;
            this.colIdleTime.AppearanceCell.Options.UseTextOptions = true;
            this.colIdleTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdleTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdleTime.AppearanceHeader.Options.UseFont = true;
            this.colIdleTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdleTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdleTime.Caption = "Idle";
            this.colIdleTime.FieldName = "Idle";
            this.colIdleTime.Name = "colIdleTime";
            this.colIdleTime.Visible = true;
            this.colIdleTime.Width = 105;
            // 
            // tpError
            // 
            this.tpError.Controls.Add(this.ucError);
            this.tpError.Name = "tpError";
            this.tpError.Size = new System.Drawing.Size(949, 529);
            this.tpError.Text = "Error Information";
            // 
            // ucError
            // 
            this.ucError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucError.Location = new System.Drawing.Point(0, 0);
            this.ucError.Name = "ucError";
            this.ucError.Size = new System.Drawing.Size(949, 529);
            this.ucError.TabIndex = 0;
            // 
            // FrmDeviceDetailViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 623);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeviceDetailViewer";
            this.Text = "Device Detail Viewer";
            this.Load += new System.EventHandler(this.FrmDeviceDetailViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpCycle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).EndInit();
            this.tpError.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarEditItem dtpkTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpCycle;
        private DevExpress.XtraTab.XtraTabPage tpError;
        private UserControls.UCErrorLogGrid ucError;
        private DevExpress.XtraGrid.GridControl grdCycle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvCycle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGroupKey;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleAvr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProcessAvr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIdleAvr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMax;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMin;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleStart;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProcessTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIdleTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCheck;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandProcess;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandAllCycle;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandCycleAtTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTime;
        private System.Windows.Forms.Timer timer1;
    }
}