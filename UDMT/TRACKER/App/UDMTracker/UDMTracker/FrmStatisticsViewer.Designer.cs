namespace UDMTracker
{
    partial class FrmStatisticsViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatisticsViewer));
			this.exBarManager = new DevExpress.XtraBars.BarManager();
			this.exBarMenu = new DevExpress.XtraBars.Bar();
			this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
			this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
			this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
			this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
			this.exBarStatus = new DevExpress.XtraBars.Bar();
			this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imgListLarge = new System.Windows.Forms.ImageList();
			this.grdMain = new DevExpress.XtraGrid.GridControl();
			this.bandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
			this.gbGroup = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colGroupKey = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gbCycle = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colCycleTotalCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleErrorCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleMean = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleMinimum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleMaximum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleStandardDev = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleCp = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCycleCpk = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gbIdle = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colIdleMean = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colIdleMinimum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colIdleMaximum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gbRecovery = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colRecoveryAll = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colRecoveryMean = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colRecoveryMinimum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colRecoveryMaximum = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).BeginInit();
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
            this.btnRefresh,
            this.btnClear,
            this.btnExit,
            this.barLargeButtonItem1});
			this.exBarManager.LargeImages = this.imgListLarge;
			this.exBarManager.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
			this.exBarMenu.OptionsBar.DrawSizeGrip = true;
			this.exBarMenu.OptionsBar.MultiLine = true;
			this.exBarMenu.OptionsBar.UseWholeRow = true;
			this.exBarMenu.Text = "Tools";
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.Caption = "From";
			this.dtpkFrom.Edit = this.exEditorFrom;
			this.dtpkFrom.EditValue = new System.DateTime(2015, 8, 19, 18, 49, 6, 574);
			this.dtpkFrom.Id = 2;
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
			this.dtpkTo.EditValue = new System.DateTime(2015, 8, 19, 18, 49, 42, 361);
			this.dtpkTo.Id = 3;
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
			this.btnRefresh.Id = 4;
			this.btnRefresh.LargeImageIndex = 14;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
			// 
			// btnClear
			// 
			this.btnClear.Caption = "Clear";
			this.btnClear.Id = 5;
			this.btnClear.LargeImageIndex = 12;
			this.btnClear.Name = "btnClear";
			this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
			// 
			// barLargeButtonItem1
			// 
			this.barLargeButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.barLargeButtonItem1.Caption = "Show Chart";
			this.barLargeButtonItem1.Id = 7;
			this.barLargeButtonItem1.LargeImageIndex = 16;
			this.barLargeButtonItem1.Name = "barLargeButtonItem1";
			this.barLargeButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
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
			this.barDockControlTop.Size = new System.Drawing.Size(762, 65);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 555);
			this.barDockControlBottom.Size = new System.Drawing.Size(762, 25);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 490);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(762, 65);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 490);
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
			this.imgListLarge.Images.SetKeyName(16, "Bar_32x32.png");
			// 
			// grdMain
			// 
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.Location = new System.Drawing.Point(0, 65);
			this.grdMain.MainView = this.bandedGridView;
			this.grdMain.MenuManager = this.exBarManager;
			this.grdMain.Name = "grdMain";
			this.grdMain.Size = new System.Drawing.Size(762, 490);
			this.grdMain.TabIndex = 4;
			this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView});
			// 
			// bandedGridView
			// 
			this.bandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbGroup,
            this.gbCycle,
            this.gbIdle,
            this.gbRecovery});
			this.bandedGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colGroupKey,
            this.colCycleTotalCount,
            this.colCycleErrorCount,
            this.colCycleMean,
            this.colCycleMinimum,
            this.colCycleMaximum,
            this.colCycleStandardDev,
            this.colCycleCp,
            this.colCycleCpk,
            this.colIdleMean,
            this.colIdleMinimum,
            this.colIdleMaximum,
            this.colRecoveryAll,
            this.colRecoveryMean,
            this.colRecoveryMinimum,
            this.colRecoveryMaximum});
			this.bandedGridView.GridControl = this.grdMain;
			this.bandedGridView.Name = "bandedGridView";
			this.bandedGridView.OptionsBehavior.Editable = false;
			this.bandedGridView.OptionsBehavior.ReadOnly = true;
			this.bandedGridView.OptionsDetail.EnableMasterViewMode = false;
			this.bandedGridView.OptionsDetail.ShowDetailTabs = false;
			this.bandedGridView.OptionsDetail.SmartDetailExpand = false;
			// 
			// gbGroup
			// 
			this.gbGroup.Caption = "Group Info";
			this.gbGroup.Columns.Add(this.colGroupKey);
			this.gbGroup.CustomizationCaption = "GroupInfo";
			this.gbGroup.Name = "gbGroup";
			this.gbGroup.VisibleIndex = 0;
			this.gbGroup.Width = 75;
			// 
			// colGroupKey
			// 
			this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
			this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGroupKey.Caption = "Group";
			this.colGroupKey.FieldName = "GroupInfo.GroupKey";
			this.colGroupKey.Name = "colGroupKey";
			this.colGroupKey.Visible = true;
			// 
			// gbCycle
			// 
			this.gbCycle.Caption = "Cycle Info";
			this.gbCycle.Columns.Add(this.colCycleTotalCount);
			this.gbCycle.Columns.Add(this.colCycleErrorCount);
			this.gbCycle.Columns.Add(this.colCycleMean);
			this.gbCycle.Columns.Add(this.colCycleMinimum);
			this.gbCycle.Columns.Add(this.colCycleMaximum);
			this.gbCycle.Columns.Add(this.colCycleStandardDev);
			this.gbCycle.Columns.Add(this.colCycleCp);
			this.gbCycle.Columns.Add(this.colCycleCpk);
			this.gbCycle.CustomizationCaption = "CycleInfo";
			this.gbCycle.Name = "gbCycle";
			this.gbCycle.VisibleIndex = 1;
			this.gbCycle.Width = 600;
			// 
			// colCycleTotalCount
			// 
			this.colCycleTotalCount.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleTotalCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleTotalCount.Caption = "Total Count";
			this.colCycleTotalCount.FieldName = "CycleInfo.TotalCount";
			this.colCycleTotalCount.Name = "colCycleTotalCount";
			this.colCycleTotalCount.Visible = true;
			// 
			// colCycleErrorCount
			// 
			this.colCycleErrorCount.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleErrorCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleErrorCount.Caption = "Error Count";
			this.colCycleErrorCount.FieldName = "CycleInfo.ErrorCount";
			this.colCycleErrorCount.Name = "colCycleErrorCount";
			this.colCycleErrorCount.Visible = true;
			// 
			// colCycleMean
			// 
			this.colCycleMean.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleMean.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleMean.Caption = "Mean";
			this.colCycleMean.FieldName = "CycleInfo.Mean";
			this.colCycleMean.Name = "colCycleMean";
			this.colCycleMean.Visible = true;
			// 
			// colCycleMinimum
			// 
			this.colCycleMinimum.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleMinimum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleMinimum.Caption = "Minimum";
			this.colCycleMinimum.FieldName = "CycleInfo.Minimum";
			this.colCycleMinimum.Name = "colCycleMinimum";
			this.colCycleMinimum.Visible = true;
			// 
			// colCycleMaximum
			// 
			this.colCycleMaximum.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleMaximum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleMaximum.Caption = "Maximum";
			this.colCycleMaximum.FieldName = "CycleInfo.Maximum";
			this.colCycleMaximum.Name = "colCycleMaximum";
			this.colCycleMaximum.Visible = true;
			// 
			// colCycleStandardDev
			// 
			this.colCycleStandardDev.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleStandardDev.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleStandardDev.Caption = "Std.Dev.";
			this.colCycleStandardDev.FieldName = "CycleInfo.StandardDev";
			this.colCycleStandardDev.Name = "colCycleStandardDev";
			this.colCycleStandardDev.Visible = true;
			// 
			// colCycleCp
			// 
			this.colCycleCp.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleCp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleCp.Caption = "Cp";
			this.colCycleCp.FieldName = "CycleInfo.Cp";
			this.colCycleCp.Name = "colCycleCp";
			this.colCycleCp.Visible = true;
			// 
			// colCycleCpk
			// 
			this.colCycleCpk.AppearanceHeader.Options.UseTextOptions = true;
			this.colCycleCpk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCycleCpk.Caption = "Cpk";
			this.colCycleCpk.FieldName = "CycleInfo.Cpk";
			this.colCycleCpk.Name = "colCycleCpk";
			this.colCycleCpk.Visible = true;
			// 
			// gbIdle
			// 
			this.gbIdle.Caption = "Idle Info";
			this.gbIdle.Columns.Add(this.colIdleMean);
			this.gbIdle.Columns.Add(this.colIdleMinimum);
			this.gbIdle.Columns.Add(this.colIdleMaximum);
			this.gbIdle.CustomizationCaption = "IdleInfo";
			this.gbIdle.Name = "gbIdle";
			this.gbIdle.VisibleIndex = 2;
			this.gbIdle.Width = 225;
			// 
			// colIdleMean
			// 
			this.colIdleMean.AppearanceHeader.Options.UseTextOptions = true;
			this.colIdleMean.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colIdleMean.Caption = "Mean";
			this.colIdleMean.FieldName = "IdleInfo.Mean";
			this.colIdleMean.Name = "colIdleMean";
			this.colIdleMean.Visible = true;
			// 
			// colIdleMinimum
			// 
			this.colIdleMinimum.AppearanceHeader.Options.UseTextOptions = true;
			this.colIdleMinimum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colIdleMinimum.Caption = "Minimum";
			this.colIdleMinimum.FieldName = "IdleInfo.Minimum";
			this.colIdleMinimum.Name = "colIdleMinimum";
			this.colIdleMinimum.Visible = true;
			// 
			// colIdleMaximum
			// 
			this.colIdleMaximum.AppearanceHeader.Options.UseTextOptions = true;
			this.colIdleMaximum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colIdleMaximum.Caption = "Maximum";
			this.colIdleMaximum.FieldName = "IdleInfo.Maximum";
			this.colIdleMaximum.Name = "colIdleMaximum";
			this.colIdleMaximum.Visible = true;
			// 
			// gbRecovery
			// 
			this.gbRecovery.Caption = "Recovery Info";
			this.gbRecovery.Columns.Add(this.colRecoveryAll);
			this.gbRecovery.Columns.Add(this.colRecoveryMean);
			this.gbRecovery.Columns.Add(this.colRecoveryMinimum);
			this.gbRecovery.Columns.Add(this.colRecoveryMaximum);
			this.gbRecovery.CustomizationCaption = "RecoveryInfo";
			this.gbRecovery.Name = "gbRecovery";
			this.gbRecovery.VisibleIndex = 3;
			this.gbRecovery.Width = 300;
			// 
			// colRecoveryAll
			// 
			this.colRecoveryAll.AppearanceHeader.Options.UseTextOptions = true;
			this.colRecoveryAll.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRecoveryAll.Caption = "All";
			this.colRecoveryAll.FieldName = "RecoveryInfo.All";
			this.colRecoveryAll.Name = "colRecoveryAll";
			this.colRecoveryAll.Visible = true;
			// 
			// colRecoveryMean
			// 
			this.colRecoveryMean.AppearanceHeader.Options.UseTextOptions = true;
			this.colRecoveryMean.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRecoveryMean.Caption = "Mean";
			this.colRecoveryMean.FieldName = "RecoveryInfo.Mean";
			this.colRecoveryMean.Name = "colRecoveryMean";
			this.colRecoveryMean.Visible = true;
			// 
			// colRecoveryMinimum
			// 
			this.colRecoveryMinimum.AppearanceHeader.Options.UseTextOptions = true;
			this.colRecoveryMinimum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRecoveryMinimum.Caption = "Minimum";
			this.colRecoveryMinimum.FieldName = "RecoveryInfo.Minimum";
			this.colRecoveryMinimum.Name = "colRecoveryMinimum";
			this.colRecoveryMinimum.Visible = true;
			// 
			// colRecoveryMaximum
			// 
			this.colRecoveryMaximum.AppearanceHeader.Options.UseTextOptions = true;
			this.colRecoveryMaximum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRecoveryMaximum.Caption = "Maximum";
			this.colRecoveryMaximum.FieldName = "RecoveryInfo.Maximum";
			this.colRecoveryMaximum.Name = "colRecoveryMaximum";
			this.colRecoveryMaximum.Visible = true;
			// 
			// FrmStatisticsViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 580);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmStatisticsViewer";
			this.Text = "CycleTime Statistics";
			this.Load += new System.EventHandler(this.FrmKPIViewer_Load);
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bandedGridView)).EndInit();
			this.ResumeLayout(false);

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
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private System.Windows.Forms.ImageList imgListLarge;
		private DevExpress.XtraGrid.GridControl grdMain;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGroupKey;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleTotalCount;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleErrorCount;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleMean;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleMinimum;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleMaximum;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleStandardDev;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleCp;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCycleCpk;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIdleMean;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIdleMinimum;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIdleMaximum;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecoveryAll;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecoveryMean;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecoveryMinimum;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecoveryMaximum;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbGroup;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbCycle;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbIdle;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbRecovery;
		private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
    }
}