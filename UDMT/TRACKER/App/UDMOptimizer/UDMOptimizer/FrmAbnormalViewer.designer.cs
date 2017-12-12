namespace UDMOptimizer
{
    partial class FrmAbnormalViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbnormalViewer));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("0", new object[] {
            ((object)(5.2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(7.4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(8.9D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(30000D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("5", new object[] {
            ((object)(40D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("6", new object[] {
            ((object)(20D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("7", new object[] {
            ((object)(40D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint("8", new object[] {
            ((object)(15D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint("9", new object[] {
            ((object)(11D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint11 = new DevExpress.XtraCharts.SeriesPoint("10", new object[] {
            ((object)(2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint12 = new DevExpress.XtraCharts.SeriesPoint("11", new object[] {
            ((object)(5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint13 = new DevExpress.XtraCharts.SeriesPoint("12", new object[] {
            ((object)(15000D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint14 = new DevExpress.XtraCharts.SeriesPoint("13", new object[] {
            ((object)(10000D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint15 = new DevExpress.XtraCharts.SeriesPoint("14", new object[] {
            ((object)(999D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint16 = new DevExpress.XtraCharts.SeriesPoint("15", new object[] {
            ((object)(100D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint17 = new DevExpress.XtraCharts.SeriesPoint("16", new object[] {
            ((object)(99D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint18 = new DevExpress.XtraCharts.SeriesPoint("17", new object[] {
            ((object)(99D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint19 = new DevExpress.XtraCharts.SeriesPoint("18", new object[] {
            ((object)(22D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint20 = new DevExpress.XtraCharts.SeriesPoint("19", new object[] {
            ((object)(33D))});
            this.exBarManager = new DevExpress.XtraBars.BarManager();
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cboProcess = new DevExpress.XtraBars.BarEditItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sptChart = new UDM.UI.MySplitContainerControl();
            this.grdKey = new DevExpress.XtraGrid.GridControl();
            this.grvKey = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurationnn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipeValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleOver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.exAbnormalChart = new DevExpress.XtraCharts.ChartControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grpErrorData = new DevExpress.XtraEditors.GroupControl();
            this.grdErrorList = new DevExpress.XtraGrid.GridControl();
            this.grvErrorList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErrorDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorActiveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorEndtoCycleStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tmrLoad = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptChart)).BeginInit();
            this.sptChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAbnormalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorData)).BeginInit();
            this.grpErrorData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
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
            this.cboProcess,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
            this.btnRefresh,
            this.btnExit});
            this.exBarManager.MaxItemId = 16;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
            this.exEditorFrom,
            this.exEditorTo});
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.FloatLocation = new System.Drawing.Point(1965, 149);
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboProcess, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // cboProcess
            // 
            this.cboProcess.Caption = "공정";
            this.cboProcess.Edit = this.exEditorGroup;
            this.cboProcess.Id = 1;
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.Width = 150;
            // 
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            this.exEditorGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 11;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.LargeImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 5;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 12;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.LargeImageIndex = 15;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1162, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 820);
            this.barDockControlBottom.Size = new System.Drawing.Size(1162, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 755);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1162, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 755);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sptChart);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1158, 495);
            this.panelControl2.TabIndex = 8;
            // 
            // sptChart
            // 
            this.sptChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptChart.Location = new System.Drawing.Point(2, 2);
            this.sptChart.Name = "sptChart";
            this.sptChart.Panel1.Controls.Add(this.grdKey);
            this.sptChart.Panel1.Text = "Panel1";
            this.sptChart.Panel2.Controls.Add(this.exAbnormalChart);
            this.sptChart.Panel2.Text = "Panel2";
            this.sptChart.Size = new System.Drawing.Size(1154, 491);
            this.sptChart.SplitterPosition = 659;
            this.sptChart.TabIndex = 38;
            this.sptChart.Text = "splitContainerControl1";
            this.sptChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptChart_MouseDoubleClick);
            // 
            // grdKey
            // 
            this.grdKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKey.Location = new System.Drawing.Point(0, 0);
            this.grdKey.MainView = this.grvKey;
            this.grdKey.MenuManager = this.exBarManager;
            this.grdKey.Name = "grdKey";
            this.grdKey.Size = new System.Drawing.Size(659, 491);
            this.grdKey.TabIndex = 34;
            this.grdKey.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKey,
            this.gridView2});
            // 
            // grvKey
            // 
            this.grvKey.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grvKey.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKey.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChannel,
            this.colStart,
            this.colEnd,
            this.colDurationnn,
            this.colRecipeValue,
            this.colType,
            this.colCycleOver});
            this.grvKey.GridControl = this.grdKey;
            this.grvKey.IndicatorWidth = 50;
            this.grvKey.Name = "grvKey";
            this.grvKey.OptionsBehavior.Editable = false;
            this.grvKey.OptionsBehavior.ReadOnly = true;
            this.grvKey.OptionsDetail.AllowZoomDetail = false;
            this.grvKey.OptionsDetail.EnableMasterViewMode = false;
            this.grvKey.OptionsDetail.ShowDetailTabs = false;
            this.grvKey.OptionsDetail.SmartDetailExpand = false;
            this.grvKey.OptionsView.ShowAutoFilterRow = true;
            this.grvKey.OptionsView.ShowGroupPanel = false;
            this.grvKey.RowHeight = 25;
            this.grvKey.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvKey_CustomDrawRowIndicator);
            this.grvKey.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvKey_RowStyle);
            // 
            // colChannel
            // 
            this.colChannel.AppearanceCell.Options.UseTextOptions = true;
            this.colChannel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Device";
            this.colChannel.FieldName = "Symbol";
            this.colChannel.Name = "colChannel";
            this.colChannel.OptionsColumn.AllowEdit = false;
            this.colChannel.OptionsColumn.ReadOnly = true;
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 2;
            this.colChannel.Width = 150;
            // 
            // colStart
            // 
            this.colStart.AppearanceCell.Options.UseTextOptions = true;
            this.colStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.Caption = "Start";
            this.colStart.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStart.FieldName = "Start";
            this.colStart.Name = "colStart";
            this.colStart.OptionsColumn.AllowEdit = false;
            this.colStart.OptionsColumn.ReadOnly = true;
            this.colStart.Visible = true;
            this.colStart.VisibleIndex = 3;
            this.colStart.Width = 120;
            // 
            // colEnd
            // 
            this.colEnd.AppearanceCell.Options.UseTextOptions = true;
            this.colEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.colEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEnd.Caption = "End";
            this.colEnd.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEnd.FieldName = "End";
            this.colEnd.Name = "colEnd";
            this.colEnd.OptionsColumn.AllowEdit = false;
            this.colEnd.OptionsColumn.ReadOnly = true;
            this.colEnd.Visible = true;
            this.colEnd.VisibleIndex = 4;
            this.colEnd.Width = 120;
            // 
            // colDurationnn
            // 
            this.colDurationnn.AppearanceCell.Options.UseTextOptions = true;
            this.colDurationnn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDurationnn.AppearanceHeader.Options.UseTextOptions = true;
            this.colDurationnn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDurationnn.Caption = "Duration(s)";
            this.colDurationnn.FieldName = "Duration";
            this.colDurationnn.Name = "colDurationnn";
            this.colDurationnn.OptionsColumn.AllowEdit = false;
            this.colDurationnn.OptionsColumn.FixedWidth = true;
            this.colDurationnn.OptionsColumn.ReadOnly = true;
            this.colDurationnn.Visible = true;
            this.colDurationnn.VisibleIndex = 5;
            this.colDurationnn.Width = 100;
            // 
            // colRecipeValue
            // 
            this.colRecipeValue.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipeValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipeValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecipeValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipeValue.Caption = "Recipe Value";
            this.colRecipeValue.FieldName = "RecipeValue";
            this.colRecipeValue.Name = "colRecipeValue";
            this.colRecipeValue.Visible = true;
            this.colRecipeValue.VisibleIndex = 6;
            this.colRecipeValue.Width = 147;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.AppearanceHeader.Options.UseTextOptions = true;
            this.colType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            // 
            // colCycleOver
            // 
            this.colCycleOver.Caption = "Avg Over";
            this.colCycleOver.FieldName = "AvgOver";
            this.colCycleOver.Name = "colCycleOver";
            this.colCycleOver.Visible = true;
            this.colCycleOver.VisibleIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdKey;
            this.gridView2.Name = "gridView2";
            // 
            // exAbnormalChart
            // 
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Title.Text = "Count";
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "20";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.VisualRange.SideMarginsValue = 1D;
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "5000";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.WholeRange.SideMarginsValue = 1D;
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.MinorCount = 3;
            xyDiagram1.AxisY.Title.Text = "Time(sec)";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisualRange.Auto = false;
            xyDiagram1.AxisY.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisY.VisualRange.MaxValueSerializable = "3000";
            xyDiagram1.AxisY.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisY.VisualRange.SideMarginsValue = 1D;
            xyDiagram1.AxisY.WholeRange.Auto = false;
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.MaxValueSerializable = "500000";
            xyDiagram1.AxisY.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisY.WholeRange.SideMarginsValue = 1D;
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisYScrolling = true;
            this.exAbnormalChart.Diagram = xyDiagram1;
            this.exAbnormalChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exAbnormalChart.Location = new System.Drawing.Point(0, 0);
            this.exAbnormalChart.Name = "exAbnormalChart";
            this.exAbnormalChart.RuntimeHitTesting = true;
            series1.Name = "Series 1";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5,
            seriesPoint6,
            seriesPoint7,
            seriesPoint8,
            seriesPoint9,
            seriesPoint10,
            seriesPoint11,
            seriesPoint12,
            seriesPoint13,
            seriesPoint14,
            seriesPoint15,
            seriesPoint16,
            seriesPoint17,
            seriesPoint18,
            seriesPoint19,
            seriesPoint20});
            this.exAbnormalChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.exAbnormalChart.Size = new System.Drawing.Size(485, 491);
            this.exAbnormalChart.TabIndex = 37;
            this.exAbnormalChart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.exAbnormalChart_CustomDrawCrosshair);
            this.exAbnormalChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exAbnormalChart_MouseDoubleClick);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1162, 518);
            this.groupControl2.TabIndex = 21;
            this.groupControl2.Text = "Process All Chart";
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Horizontal = false;
            this.sptMain.Location = new System.Drawing.Point(0, 65);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpErrorData);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.groupControl2);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1162, 755);
            this.sptMain.SplitterPosition = 227;
            this.sptMain.TabIndex = 26;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // grpErrorData
            // 
            this.grpErrorData.Controls.Add(this.grdErrorList);
            this.grpErrorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorData.Location = new System.Drawing.Point(0, 0);
            this.grpErrorData.Name = "grpErrorData";
            this.grpErrorData.Size = new System.Drawing.Size(1162, 227);
            this.grpErrorData.TabIndex = 0;
            this.grpErrorData.Text = "Error List";
            // 
            // grdErrorList
            // 
            this.grdErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdErrorList.Location = new System.Drawing.Point(2, 21);
            this.grdErrorList.MainView = this.grvErrorList;
            this.grdErrorList.MenuManager = this.exBarManager;
            this.grdErrorList.Name = "grdErrorList";
            this.grdErrorList.Size = new System.Drawing.Size(1158, 204);
            this.grdErrorList.TabIndex = 35;
            this.grdErrorList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvErrorList,
            this.gridView4});
            // 
            // grvErrorList
            // 
            this.grvErrorList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grvErrorList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvErrorList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErrorDevice,
            this.colErrorStartTime,
            this.colErrorEndTime,
            this.colErrorDuration,
            this.colErrorActiveTime,
            this.colErrorCount,
            this.colErrorEndtoCycleStart});
            this.grvErrorList.GridControl = this.grdErrorList;
            this.grvErrorList.IndicatorWidth = 50;
            this.grvErrorList.Name = "grvErrorList";
            this.grvErrorList.OptionsBehavior.Editable = false;
            this.grvErrorList.OptionsBehavior.ReadOnly = true;
            this.grvErrorList.OptionsDetail.AllowZoomDetail = false;
            this.grvErrorList.OptionsDetail.EnableMasterViewMode = false;
            this.grvErrorList.OptionsDetail.ShowDetailTabs = false;
            this.grvErrorList.OptionsDetail.SmartDetailExpand = false;
            this.grvErrorList.OptionsView.ShowAutoFilterRow = true;
            this.grvErrorList.OptionsView.ShowGroupPanel = false;
            this.grvErrorList.RowHeight = 25;
            this.grvErrorList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colErrorCount, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvErrorList.DoubleClick += new System.EventHandler(this.grvErrorList_DoubleClick);
            // 
            // colErrorDevice
            // 
            this.colErrorDevice.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorDevice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorDevice.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorDevice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorDevice.Caption = "Device";
            this.colErrorDevice.FieldName = "Key";
            this.colErrorDevice.Name = "colErrorDevice";
            this.colErrorDevice.OptionsColumn.AllowEdit = false;
            this.colErrorDevice.OptionsColumn.ReadOnly = true;
            this.colErrorDevice.Visible = true;
            this.colErrorDevice.VisibleIndex = 1;
            this.colErrorDevice.Width = 203;
            // 
            // colErrorStartTime
            // 
            this.colErrorStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorStartTime.Caption = "Start";
            this.colErrorStartTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colErrorStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colErrorStartTime.FieldName = "Start";
            this.colErrorStartTime.Name = "colErrorStartTime";
            this.colErrorStartTime.OptionsColumn.AllowEdit = false;
            this.colErrorStartTime.OptionsColumn.ReadOnly = true;
            this.colErrorStartTime.Visible = true;
            this.colErrorStartTime.VisibleIndex = 2;
            this.colErrorStartTime.Width = 166;
            // 
            // colErrorEndTime
            // 
            this.colErrorEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorEndTime.Caption = "End";
            this.colErrorEndTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colErrorEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colErrorEndTime.FieldName = "End";
            this.colErrorEndTime.Name = "colErrorEndTime";
            this.colErrorEndTime.OptionsColumn.AllowEdit = false;
            this.colErrorEndTime.OptionsColumn.ReadOnly = true;
            this.colErrorEndTime.Visible = true;
            this.colErrorEndTime.VisibleIndex = 3;
            this.colErrorEndTime.Width = 166;
            // 
            // colErrorDuration
            // 
            this.colErrorDuration.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorDuration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorDuration.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorDuration.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorDuration.Caption = "Error 유지 시간(s)";
            this.colErrorDuration.FieldName = "Duration";
            this.colErrorDuration.Name = "colErrorDuration";
            this.colErrorDuration.OptionsColumn.AllowEdit = false;
            this.colErrorDuration.OptionsColumn.FixedWidth = true;
            this.colErrorDuration.OptionsColumn.ReadOnly = true;
            this.colErrorDuration.Visible = true;
            this.colErrorDuration.VisibleIndex = 5;
            this.colErrorDuration.Width = 200;
            // 
            // colErrorActiveTime
            // 
            this.colErrorActiveTime.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorActiveTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorActiveTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorActiveTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorActiveTime.Caption = "Error 발생 전까지 동작 시간";
            this.colErrorActiveTime.FieldName = "CycleFromStartToError";
            this.colErrorActiveTime.Name = "colErrorActiveTime";
            this.colErrorActiveTime.Visible = true;
            this.colErrorActiveTime.VisibleIndex = 4;
            this.colErrorActiveTime.Width = 200;
            // 
            // colErrorCount
            // 
            this.colErrorCount.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.Caption = "Cycle Number";
            this.colErrorCount.FieldName = "CycleNumber";
            this.colErrorCount.Name = "colErrorCount";
            this.colErrorCount.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colErrorCount.Visible = true;
            this.colErrorCount.VisibleIndex = 0;
            this.colErrorCount.Width = 92;
            // 
            // colErrorEndtoCycleStart
            // 
            this.colErrorEndtoCycleStart.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorEndtoCycleStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorEndtoCycleStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorEndtoCycleStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorEndtoCycleStart.Caption = "Error 조치후 Next Cycle Start시간";
            this.colErrorEndtoCycleStart.FieldName = "NextCycleStart";
            this.colErrorEndtoCycleStart.Name = "colErrorEndtoCycleStart";
            this.colErrorEndtoCycleStart.Visible = true;
            this.colErrorEndtoCycleStart.VisibleIndex = 6;
            this.colErrorEndtoCycleStart.Width = 200;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grdErrorList;
            this.gridView4.Name = "gridView4";
            // 
            // tmrLoad
            // 
            this.tmrLoad.Tick += new System.EventHandler(this.tmrLoad_Tick);
            // 
            // FrmAbnormalViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 820);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAbnormalViewer";
            this.Text = "Abnormal Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAbnormalViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptChart)).EndInit();
            this.sptChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAbnormalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorData)).EndInit();
            this.grpErrorData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarEditItem cboProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraCharts.ChartControl exAbnormalChart;
        private DevExpress.XtraGrid.GridControl grdKey;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKey;
        private DevExpress.XtraGrid.Columns.GridColumn colChannel;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraGrid.Columns.GridColumn colEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colDurationnn;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipeValue;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private UDM.UI.MySplitContainerControl sptMain;
        private DevExpress.XtraEditors.GroupControl grpErrorData;
        private DevExpress.XtraGrid.GridControl grdErrorList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvErrorList;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorActiveTime;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorEndtoCycleStart;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleOver;
        private System.Windows.Forms.Timer tmrLoad;
        private UDM.UI.MySplitContainerControl sptChart;
    }
}