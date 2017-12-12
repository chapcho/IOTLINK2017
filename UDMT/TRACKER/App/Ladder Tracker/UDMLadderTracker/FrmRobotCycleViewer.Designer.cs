namespace UDMLadderTracker
{
    partial class FrmRobotCycleViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRobotCycleViewer));
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.menuBar = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.chkDaily = new DevExpress.XtraBars.BarCheckItem();
            this.chkWeekly = new DevExpress.XtraBars.BarCheckItem();
            this.chkMonthly = new DevExpress.XtraBars.BarCheckItem();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.statusBar = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorRadioGroup = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdRobot = new DevExpress.XtraGrid.GridControl();
            this.grvRobot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.grpChartViewer = new DevExpress.XtraEditors.GroupControl();
            this.ucRobotCycleStatisticS = new UDMLadderTracker.UCRobotCycleStatisticS();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRadioGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpChartViewer)).BeginInit();
            this.grpChartViewer.SuspendLayout();
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
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.menuBar,
            this.statusBar});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Images = this.imgListLarge;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.dtpkFrom,
            this.btnClear,
            this.btnExit,
            this.btnRefresh,
            this.chkDaily,
            this.chkWeekly,
            this.chkMonthly});
            this.exBarManager.MaxItemId = 13;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorRadioGroup,
            this.repositoryItemRadioGroup1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.exBarManager.StatusBar = this.statusBar;
            // 
            // menuBar
            // 
            this.menuBar.BarName = "Tools";
            this.menuBar.DockCol = 0;
            this.menuBar.DockRow = 0;
            this.menuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.menuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkDaily),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkWeekly),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkMonthly),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClear, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.menuBar.OptionsBar.UseWholeRow = true;
            this.menuBar.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2016, 3, 14, 13, 41, 14, 47);
            this.dtpkFrom.Id = 0;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 150;
            this.dtpkFrom.EditValueChanged += new System.EventHandler(this.dtpkFrom_EditValueChanged);
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorFrom.Appearance.Options.UseFont = true;
            this.exEditorFrom.Appearance.Options.UseTextOptions = true;
            this.exEditorFrom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrom.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.exEditorFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.EditFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.Mask.EditMask = "yyyy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // chkDaily
            // 
            this.chkDaily.Caption = "Daily";
            this.chkDaily.Id = 10;
            this.chkDaily.Name = "chkDaily";
            this.chkDaily.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkDaily_CheckedChanged);
            // 
            // chkWeekly
            // 
            this.chkWeekly.BindableChecked = true;
            this.chkWeekly.Caption = "Weekly";
            this.chkWeekly.Checked = true;
            this.chkWeekly.Id = 11;
            this.chkWeekly.Name = "chkWeekly";
            this.chkWeekly.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkWeekly_CheckedChanged);
            // 
            // chkMonthly
            // 
            this.chkMonthly.Caption = "Monthly";
            this.chkMonthly.Id = 12;
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonthly_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Apply";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 2;
            this.btnClear.ImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 3;
            this.btnExit.ImageIndex = 15;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // statusBar
            // 
            this.statusBar.BarName = "Status bar";
            this.statusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.statusBar.DockCol = 0;
            this.statusBar.DockRow = 0;
            this.statusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.statusBar.OptionsBar.AllowQuickCustomization = false;
            this.statusBar.OptionsBar.DrawDragBorder = false;
            this.statusBar.OptionsBar.UseWholeRow = true;
            this.statusBar.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1042, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 626);
            this.barDockControlBottom.Size = new System.Drawing.Size(1042, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1042, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
            // 
            // exEditorRadioGroup
            // 
            this.exEditorRadioGroup.Columns = 3;
            this.exEditorRadioGroup.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Daily"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Weekly"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Monthly")});
            this.exEditorRadioGroup.Name = "exEditorRadioGroup";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdRobot);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 65);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(382, 561);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Robot Cycle Information";
            // 
            // grdRobot
            // 
            this.grdRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRobot.Location = new System.Drawing.Point(2, 27);
            this.grdRobot.LookAndFeel.SkinName = "Office 2013";
            this.grdRobot.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdRobot.MainView = this.grvRobot;
            this.grdRobot.Name = "grdRobot";
            this.grdRobot.Size = new System.Drawing.Size(378, 532);
            this.grdRobot.TabIndex = 6;
            this.grdRobot.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRobot});
            // 
            // grvRobot
            // 
            this.grvRobot.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grvRobot.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Blue;
            this.grvRobot.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRobot.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvRobot.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvRobot.Appearance.Row.Options.UseFont = true;
            this.grvRobot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvRobot.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescription,
            this.colAddress});
            this.grvRobot.GridControl = this.grdRobot;
            this.grvRobot.Name = "grvRobot";
            this.grvRobot.OptionsBehavior.Editable = false;
            this.grvRobot.OptionsBehavior.ReadOnly = true;
            this.grvRobot.OptionsCustomization.AllowColumnMoving = false;
            this.grvRobot.OptionsDetail.AllowZoomDetail = false;
            this.grvRobot.OptionsDetail.EnableMasterViewMode = false;
            this.grvRobot.OptionsDetail.SmartDetailExpand = false;
            this.grvRobot.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvRobot.OptionsView.ShowGroupPanel = false;
            this.grvRobot.OptionsView.ShowIndicator = false;
            this.grvRobot.RowHeight = 30;
            this.grvRobot.DoubleClick += new System.EventHandler(this.grvRobot_DoubleClick);
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.ForeColor = System.Drawing.Color.Navy;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Item";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            this.colDescription.Width = 262;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceHeader.ForeColor = System.Drawing.Color.Navy;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 116;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(382, 65);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 561);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // grpChartViewer
            // 
            this.grpChartViewer.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grpChartViewer.AppearanceCaption.Options.UseFont = true;
            this.grpChartViewer.Controls.Add(this.ucRobotCycleStatisticS);
            this.grpChartViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartViewer.Location = new System.Drawing.Point(387, 65);
            this.grpChartViewer.Name = "grpChartViewer";
            this.grpChartViewer.Size = new System.Drawing.Size(655, 561);
            this.grpChartViewer.TabIndex = 6;
            this.grpChartViewer.Text = "Chart Viewer";
            // 
            // ucRobotCycleStatisticS
            // 
            this.ucRobotCycleStatisticS.AutoScroll = true;
            this.ucRobotCycleStatisticS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRobotCycleStatisticS.Location = new System.Drawing.Point(2, 27);
            this.ucRobotCycleStatisticS.Name = "ucRobotCycleStatisticS";
            this.ucRobotCycleStatisticS.Size = new System.Drawing.Size(651, 532);
            this.ucRobotCycleStatisticS.TabIndex = 1;
            // 
            // FrmRobotCycleViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 649);
            this.Controls.Add(this.grpChartViewer);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRobotCycleViewer";
            this.Text = "Robot Cycle Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRobotCycleViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRadioGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpChartViewer)).EndInit();
            this.grpChartViewer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar menuBar;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup exEditorRadioGroup;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.Bar statusBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl grpChartViewer;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdRobot;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRobot;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraBars.BarCheckItem chkDaily;
        private DevExpress.XtraBars.BarCheckItem chkWeekly;
        private DevExpress.XtraBars.BarCheckItem chkMonthly;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private UCRobotCycleStatisticS ucRobotCycleStatisticS;
    }
}