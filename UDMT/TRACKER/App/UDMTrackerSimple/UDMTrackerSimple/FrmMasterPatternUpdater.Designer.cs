namespace UDMTrackerSimple
{
    partial class FrmMasterPatternUpdater
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterPatternUpdater));
			this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.exBarMenu = new DevExpress.XtraBars.Bar();
			this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
			this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
			this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
			this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
			this.exBarStatus = new DevExpress.XtraBars.Bar();
			this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
			this.grpResult = new DevExpress.XtraEditors.GroupControl();
			this.grdPatternList = new DevExpress.XtraGrid.GridControl();
			this.grvPatternList = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRecipe = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grpFlowOption = new DevExpress.XtraEditors.GroupControl();
			this.ucFlowRuleProperty = new UDM.Project.UCFlowRuleProperty();
			this.splitMain = new DevExpress.XtraEditors.SplitterControl();
			this.grpMonitorHistory = new DevExpress.XtraEditors.GroupControl();
			this.ucMonitorHistoryTable = new UDM.Project.UserControls.UCMonitorHistoryTable();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.grpKeySymbolOption = new DevExpress.XtraEditors.GroupControl();
			this.ucKeyOptionProperty = new UDMTrackerSimple.UCCyclePresentOptionProperty();
			this.grpSubKeySymbolOption = new DevExpress.XtraEditors.GroupControl();
			this.ucSubKeyOptionProperty = new UDMTrackerSimple.UCCyclePresentOptionProperty();
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpResult)).BeginInit();
			this.grpResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPatternList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvPatternList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpFlowOption)).BeginInit();
			this.grpFlowOption.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMonitorHistory)).BeginInit();
			this.grpMonitorHistory.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpKeySymbolOption)).BeginInit();
			this.grpKeySymbolOption.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSubKeySymbolOption)).BeginInit();
			this.grpSubKeySymbolOption.SuspendLayout();
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
            this.dtpkFrom,
            this.dtpkTo,
            this.btnRefresh,
            this.btnClear,
            this.lblStatus,
            this.btnApply,
            this.btnExit});
			this.exBarManager.LargeImages = this.imgListLarge;
			this.exBarManager.MaxItemId = 16;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApply, true),
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
			this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 8, 13, 34, 6, 416);
			this.dtpkFrom.Id = 0;
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
			this.dtpkTo.EditValue = new System.DateTime(2015, 2, 8, 13, 35, 2, 857);
			this.dtpkTo.Id = 1;
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
			// btnRefresh
			// 
			this.btnRefresh.Caption = "Refresh";
			this.btnRefresh.Id = 2;
			this.btnRefresh.LargeImageIndex = 0;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
			// 
			// btnClear
			// 
			this.btnClear.Caption = "Clear";
			this.btnClear.Id = 3;
			this.btnClear.LargeImageIndex = 1;
			this.btnClear.Name = "btnClear";
			this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
			// 
			// btnApply
			// 
			this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.btnApply.Caption = "Apply";
			this.btnApply.Id = 14;
			this.btnApply.LargeImageIndex = 2;
			this.btnApply.Name = "btnApply";
			this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
			// 
			// btnExit
			// 
			this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.btnExit.Caption = "Exit";
			this.btnExit.Id = 15;
			this.btnExit.LargeImageIndex = 3;
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
			this.lblStatus.Id = 13;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(791, 65);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 565);
			this.barDockControlBottom.Size = new System.Drawing.Size(791, 25);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 500);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(791, 65);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 500);
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
			// grpResult
			// 
			this.grpResult.Controls.Add(this.grdPatternList);
			this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpResult.Location = new System.Drawing.Point(301, 297);
			this.grpResult.Name = "grpResult";
			this.grpResult.Size = new System.Drawing.Size(490, 268);
			this.grpResult.TabIndex = 4;
			this.grpResult.Text = "Pattern List";
			// 
			// grdPatternList
			// 
			this.grdPatternList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdPatternList.Location = new System.Drawing.Point(2, 22);
			this.grdPatternList.MainView = this.grvPatternList;
			this.grdPatternList.Name = "grdPatternList";
			this.grdPatternList.Size = new System.Drawing.Size(486, 244);
			this.grdPatternList.TabIndex = 2;
			this.grdPatternList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPatternList});
			// 
			// grvPatternList
			// 
			this.grvPatternList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colRecipe,
            this.colCount});
			this.grvPatternList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvPatternList.GridControl = this.grdPatternList;
			this.grvPatternList.Name = "grvPatternList";
			this.grvPatternList.OptionsBehavior.Editable = false;
			this.grvPatternList.OptionsBehavior.ReadOnly = true;
			this.grvPatternList.OptionsView.ShowGroupPanel = false;
			this.grvPatternList.OptionsView.ShowIndicator = false;
			// 
			// colGroup
			// 
			this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
			this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGroup.Caption = "Group";
			this.colGroup.FieldName = "Group";
			this.colGroup.Name = "colGroup";
			this.colGroup.Visible = true;
			this.colGroup.VisibleIndex = 0;
			// 
			// colRecipe
			// 
			this.colRecipe.AppearanceHeader.Options.UseTextOptions = true;
			this.colRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRecipe.Caption = "Recipe";
			this.colRecipe.FieldName = "Recipe";
			this.colRecipe.Name = "colRecipe";
			this.colRecipe.Visible = true;
			this.colRecipe.VisibleIndex = 1;
			// 
			// colCount
			// 
			this.colCount.AppearanceCell.Options.UseTextOptions = true;
			this.colCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.colCount.AppearanceHeader.Options.UseTextOptions = true;
			this.colCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCount.Caption = "Count";
			this.colCount.FieldName = "Count";
			this.colCount.Name = "colCount";
			this.colCount.Visible = true;
			this.colCount.VisibleIndex = 2;
			// 
			// grpFlowOption
			// 
			this.grpFlowOption.Controls.Add(this.ucFlowRuleProperty);
			this.grpFlowOption.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpFlowOption.Location = new System.Drawing.Point(301, 65);
			this.grpFlowOption.Name = "grpFlowOption";
			this.grpFlowOption.Size = new System.Drawing.Size(490, 232);
			this.grpFlowOption.TabIndex = 9;
			this.grpFlowOption.Text = "Flow Option";
			// 
			// ucFlowRuleProperty
			// 
			this.ucFlowRuleProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucFlowRuleProperty.Editable = true;
			this.ucFlowRuleProperty.Location = new System.Drawing.Point(2, 22);
			this.ucFlowRuleProperty.Name = "ucFlowRuleProperty";
			this.ucFlowRuleProperty.Rule = null;
			this.ucFlowRuleProperty.Size = new System.Drawing.Size(486, 208);
			this.ucFlowRuleProperty.TabIndex = 0;
			// 
			// splitMain
			// 
			this.splitMain.Location = new System.Drawing.Point(296, 65);
			this.splitMain.Name = "splitMain";
			this.splitMain.Size = new System.Drawing.Size(5, 500);
			this.splitMain.TabIndex = 10;
			this.splitMain.TabStop = false;
			// 
			// grpMonitorHistory
			// 
			this.grpMonitorHistory.Controls.Add(this.ucMonitorHistoryTable);
			this.grpMonitorHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpMonitorHistory.Location = new System.Drawing.Point(0, 0);
			this.grpMonitorHistory.Name = "grpMonitorHistory";
			this.grpMonitorHistory.Size = new System.Drawing.Size(296, 130);
			this.grpMonitorHistory.TabIndex = 15;
			this.grpMonitorHistory.Text = "Monitor History";
			// 
			// ucMonitorHistoryTable
			// 
			this.ucMonitorHistoryTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMonitorHistoryTable.GroupLogS = null;
			this.ucMonitorHistoryTable.Location = new System.Drawing.Point(2, 22);
			this.ucMonitorHistoryTable.MonitorType = UDM.Log.EMMonitorType.Detection;
			this.ucMonitorHistoryTable.Name = "ucMonitorHistoryTable";
			this.ucMonitorHistoryTable.Size = new System.Drawing.Size(292, 106);
			this.ucMonitorHistoryTable.TabIndex = 0;
			this.ucMonitorHistoryTable.UEventHistoryDoubleClicked += new UDM.Project.UEventHandlerMonitorHistoryTableRowDoubleClicked(this.ucMonitorHistoryTable_UEventHistoryDoubleClicked);
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.grpMonitorHistory);
			this.pnlLeft.Controls.Add(this.grpKeySymbolOption);
			this.pnlLeft.Controls.Add(this.grpSubKeySymbolOption);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 65);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(296, 500);
			this.pnlLeft.TabIndex = 21;
			// 
			// grpKeySymbolOption
			// 
			this.grpKeySymbolOption.Controls.Add(this.ucKeyOptionProperty);
			this.grpKeySymbolOption.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpKeySymbolOption.Location = new System.Drawing.Point(0, 130);
			this.grpKeySymbolOption.Name = "grpKeySymbolOption";
			this.grpKeySymbolOption.Size = new System.Drawing.Size(296, 185);
			this.grpKeySymbolOption.TabIndex = 16;
			this.grpKeySymbolOption.Text = "Key Symbol Option";
			// 
			// ucKeyOptionProperty
			// 
			this.ucKeyOptionProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucKeyOptionProperty.Location = new System.Drawing.Point(2, 22);
			this.ucKeyOptionProperty.Name = "ucKeyOptionProperty";
			this.ucKeyOptionProperty.Option = null;
			this.ucKeyOptionProperty.Size = new System.Drawing.Size(292, 161);
			this.ucKeyOptionProperty.TabIndex = 0;
			// 
			// grpSubKeySymbolOption
			// 
			this.grpSubKeySymbolOption.Controls.Add(this.ucSubKeyOptionProperty);
			this.grpSubKeySymbolOption.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpSubKeySymbolOption.Location = new System.Drawing.Point(0, 315);
			this.grpSubKeySymbolOption.Name = "grpSubKeySymbolOption";
			this.grpSubKeySymbolOption.Size = new System.Drawing.Size(296, 185);
			this.grpSubKeySymbolOption.TabIndex = 17;
			this.grpSubKeySymbolOption.Text = "SubKey Symbol Option";
			// 
			// ucSubKeyOptionProperty
			// 
			this.ucSubKeyOptionProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSubKeyOptionProperty.Location = new System.Drawing.Point(2, 22);
			this.ucSubKeyOptionProperty.Name = "ucSubKeyOptionProperty";
			this.ucSubKeyOptionProperty.Option = null;
			this.ucSubKeyOptionProperty.Size = new System.Drawing.Size(292, 161);
			this.ucSubKeyOptionProperty.TabIndex = 0;
			// 
			// FrmMasterPatternUpdater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 590);
			this.Controls.Add(this.grpResult);
			this.Controls.Add(this.grpFlowOption);
			this.Controls.Add(this.splitMain);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMasterPatternUpdater";
			this.Text = "Master Pattern Updater";
			this.Load += new System.EventHandler(this.FrmPatternGenerator_Load);
			((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpResult)).EndInit();
			this.grpResult.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdPatternList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvPatternList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpFlowOption)).EndInit();
			this.grpFlowOption.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMonitorHistory)).EndInit();
			this.grpMonitorHistory.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpKeySymbolOption)).EndInit();
			this.grpKeySymbolOption.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpSubKeySymbolOption)).EndInit();
			this.grpSubKeySymbolOption.ResumeLayout(false);
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
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraEditors.GroupControl grpResult;
        private DevExpress.XtraGrid.GridControl grdPatternList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPatternList;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraEditors.SplitterControl splitMain;
        private DevExpress.XtraEditors.GroupControl grpFlowOption;
        private UDM.Project.UCFlowRuleProperty ucFlowRuleProperty;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipe;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
		private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraEditors.GroupControl grpMonitorHistory;
        private UDM.Project.UserControls.UCMonitorHistoryTable ucMonitorHistoryTable;
        private System.Windows.Forms.ImageList imgListLarge;
		private System.Windows.Forms.Panel pnlLeft;
		private DevExpress.XtraEditors.GroupControl grpKeySymbolOption;
		private UCCyclePresentOptionProperty ucKeyOptionProperty;
		private DevExpress.XtraEditors.GroupControl grpSubKeySymbolOption;
		private UCCyclePresentOptionProperty ucSubKeyOptionProperty;
    }
}