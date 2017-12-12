namespace UDMTrackerSimple
{
    partial class FrmPatternItemUpdater
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatternItemUpdater));
			this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
			this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
			this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
			this.bar3 = new DevExpress.XtraBars.Bar();
			this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
			this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
			this.exEditorDiscriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
			this.grpMonitorHistory = new DevExpress.XtraEditors.GroupControl();
			this.ucMonitorHistoryTable = new UDM.Project.UserControls.UCMonitorHistoryTable();
			this.split = new DevExpress.XtraEditors.SplitterControl();
			this.grpPatternItemRecord = new DevExpress.XtraEditors.GroupControl();
			this.grdPatternItemHistory = new DevExpress.XtraGrid.GridControl();
			this.grvMain = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
			this.bndSymbol = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colAddress = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.grpKeySymbolOption = new DevExpress.XtraEditors.GroupControl();
			this.ucKeyOptionProperty = new UDMTrackerSimple.UCCyclePresentOptionProperty();
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorDiscriptionFilter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMonitorHistory)).BeginInit();
			this.grpMonitorHistory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPatternItemRecord)).BeginInit();
			this.grpPatternItemRecord.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPatternItemHistory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpKeySymbolOption)).BeginInit();
			this.grpKeySymbolOption.SuspendLayout();
			this.SuspendLayout();
			// 
			// exBarManager
			// 
			this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
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
			this.exBarManager.StatusBar = this.bar3;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApply, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
			this.bar1.OptionsBar.DrawSizeGrip = true;
			this.bar1.OptionsBar.MultiLine = true;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.Caption = "From";
			this.dtpkFrom.Edit = this.exEditorFrom;
			this.dtpkFrom.EditValue = new System.DateTime(2015, 8, 12, 13, 2, 18, 929);
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
			this.dtpkTo.EditValue = new System.DateTime(2015, 8, 12, 13, 3, 35, 84);
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
			this.btnRefresh.LargeImageIndex = 0;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
			// 
			// btnClear
			// 
			this.btnClear.Caption = "Clear";
			this.btnClear.Id = 6;
			this.btnClear.LargeImageIndex = 1;
			this.btnClear.Name = "btnClear";
			this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
			// 
			// btnApply
			// 
			this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.btnApply.Caption = "Apply";
			this.btnApply.Id = 8;
			this.btnApply.LargeImageIndex = 2;
			this.btnApply.Name = "btnApply";
			this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
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
			// bar3
			// 
			this.bar3.BarName = "Status bar";
			this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.bar3.DockCol = 0;
			this.bar3.DockRow = 0;
			this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
			this.bar3.OptionsBar.AllowQuickCustomization = false;
			this.bar3.OptionsBar.DrawDragBorder = false;
			this.bar3.OptionsBar.UseWholeRow = true;
			this.bar3.Text = "Status bar";
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
			this.barDockControlTop.Size = new System.Drawing.Size(1000, 65);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 495);
			this.barDockControlBottom.Size = new System.Drawing.Size(1000, 25);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 430);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1000, 65);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 430);
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
			// grpMonitorHistory
			// 
			this.grpMonitorHistory.Controls.Add(this.ucMonitorHistoryTable);
			this.grpMonitorHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpMonitorHistory.Location = new System.Drawing.Point(0, 0);
			this.grpMonitorHistory.Name = "grpMonitorHistory";
			this.grpMonitorHistory.Size = new System.Drawing.Size(281, 245);
			this.grpMonitorHistory.TabIndex = 4;
			this.grpMonitorHistory.Text = "Monitor History";
			// 
			// ucMonitorHistoryTable
			// 
			this.ucMonitorHistoryTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMonitorHistoryTable.GroupLogS = null;
			this.ucMonitorHistoryTable.Location = new System.Drawing.Point(2, 22);
			this.ucMonitorHistoryTable.MonitorType = UDM.Log.EMMonitorType.Detection;
			this.ucMonitorHistoryTable.Name = "ucMonitorHistoryTable";
			this.ucMonitorHistoryTable.Size = new System.Drawing.Size(277, 221);
			this.ucMonitorHistoryTable.TabIndex = 0;
			this.ucMonitorHistoryTable.UEventHistoryDoubleClicked += new UDM.Project.UEventHandlerMonitorHistoryTableRowDoubleClicked(this.ucMonitorHistoryTable_UEventHistoryDoubleClicked);
			// 
			// split
			// 
			this.split.Location = new System.Drawing.Point(281, 65);
			this.split.Name = "split";
			this.split.Size = new System.Drawing.Size(5, 430);
			this.split.TabIndex = 11;
			this.split.TabStop = false;
			// 
			// grpPatternItemRecord
			// 
			this.grpPatternItemRecord.Controls.Add(this.grdPatternItemHistory);
			this.grpPatternItemRecord.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpPatternItemRecord.Location = new System.Drawing.Point(286, 65);
			this.grpPatternItemRecord.Name = "grpPatternItemRecord";
			this.grpPatternItemRecord.Size = new System.Drawing.Size(714, 430);
			this.grpPatternItemRecord.TabIndex = 12;
			this.grpPatternItemRecord.Text = "Pattern Item History";
			// 
			// grdPatternItemHistory
			// 
			this.grdPatternItemHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdPatternItemHistory.Location = new System.Drawing.Point(2, 22);
			this.grdPatternItemHistory.MainView = this.grvMain;
			this.grdPatternItemHistory.MenuManager = this.exBarManager;
			this.grdPatternItemHistory.Name = "grdPatternItemHistory";
			this.grdPatternItemHistory.Size = new System.Drawing.Size(710, 406);
			this.grdPatternItemHistory.TabIndex = 0;
			this.grdPatternItemHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
			// 
			// grvMain
			// 
			this.grvMain.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bndSymbol});
			this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colAddress,
            this.colDescription});
			this.grvMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvMain.GridControl = this.grdPatternItemHistory;
			this.grvMain.IndicatorWidth = 50;
			this.grvMain.Name = "grvMain";
			this.grvMain.OptionsBehavior.Editable = false;
			this.grvMain.OptionsBehavior.ReadOnly = true;
			this.grvMain.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvMain_CustomDrawRowIndicator);
			this.grvMain.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvMain_CustomUnboundColumnData);
			// 
			// bndSymbol
			// 
			this.bndSymbol.AppearanceHeader.Options.UseTextOptions = true;
			this.bndSymbol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bndSymbol.Caption = "Symbol";
			this.bndSymbol.Columns.Add(this.colAddress);
			this.bndSymbol.Columns.Add(this.colDescription);
			this.bndSymbol.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
			this.bndSymbol.Name = "bndSymbol";
			this.bndSymbol.VisibleIndex = 0;
			this.bndSymbol.Width = 150;
			// 
			// colAddress
			// 
			this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
			this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colAddress.Caption = "Address";
			this.colAddress.FieldName = "Tag.Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			// 
			// colDescription
			// 
			this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
			this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDescription.Caption = "Description";
			this.colDescription.FieldName = "Tag.Description";
			this.colDescription.Name = "colDescription";
			this.colDescription.Visible = true;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.grpMonitorHistory);
			this.pnlLeft.Controls.Add(this.grpKeySymbolOption);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 65);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(281, 430);
			this.pnlLeft.TabIndex = 17;
			// 
			// grpKeySymbolOption
			// 
			this.grpKeySymbolOption.Controls.Add(this.ucKeyOptionProperty);
			this.grpKeySymbolOption.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpKeySymbolOption.Location = new System.Drawing.Point(0, 245);
			this.grpKeySymbolOption.Name = "grpKeySymbolOption";
			this.grpKeySymbolOption.Size = new System.Drawing.Size(281, 185);
			this.grpKeySymbolOption.TabIndex = 5;
			this.grpKeySymbolOption.Text = "Key Symbol Option";
			// 
			// ucKeyOptionProperty
			// 
			this.ucKeyOptionProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucKeyOptionProperty.Location = new System.Drawing.Point(2, 22);
			this.ucKeyOptionProperty.Name = "ucKeyOptionProperty";
			this.ucKeyOptionProperty.Option = null;
			this.ucKeyOptionProperty.Size = new System.Drawing.Size(277, 161);
			this.ucKeyOptionProperty.TabIndex = 0;
			// 
			// FrmPatternItemUpdater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 520);
			this.Controls.Add(this.grpPatternItemRecord);
			this.Controls.Add(this.split);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmPatternItemUpdater";
			this.Text = "Pattern Item Updater";
			this.Load += new System.EventHandler(this.FrmPatternItemUpdater_Load);
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorDiscriptionFilter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMonitorHistory)).EndInit();
			this.grpMonitorHistory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpPatternItemRecord)).EndInit();
			this.grpPatternItemRecord.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdPatternItemHistory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpKeySymbolOption)).EndInit();
			this.grpKeySymbolOption.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
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
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraEditors.GroupControl grpMonitorHistory;
        private UDM.Project.UserControls.UCMonitorHistoryTable ucMonitorHistoryTable;
        private DevExpress.XtraEditors.GroupControl grpPatternItemRecord;
        private DevExpress.XtraGrid.GridControl grdPatternItemHistory;
        private DevExpress.XtraEditors.SplitterControl split;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvMain;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand bndSymbol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDiscriptionFilter;
		private System.Windows.Forms.Panel pnlLeft;
		private DevExpress.XtraEditors.GroupControl grpKeySymbolOption;
		private UCCyclePresentOptionProperty ucKeyOptionProperty;
    }
}