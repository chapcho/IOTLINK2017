namespace UDMEnergyViewer
{
    partial class FrmCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalibration));
            UDM.UI.TimeChart.CSeriesAxis cSeriesAxis1 = new UDM.UI.TimeChart.CSeriesAxis();
            this.exMenuBar = new DevExpress.XtraBars.Bar();
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.dtRefTime = new DevExpress.XtraBars.BarEditItem();
            this.exEditorRefTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtCalibTime = new DevExpress.XtraBars.BarEditItem();
            this.exEditorCalibrationTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnApply = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.txtTimeSpan = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTimeSpan = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnMeterShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucGanttChart = new UDM.UI.TimeChart.UCTimeChart();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucSeriesTree = new UDM.UI.TimeChart.UCSeriesTree(this.components);
            this.ucSeriesChart = new UDM.UI.TimeChart.UCSeriesChart(this.components);
            this.ucTimeLine = new UDM.UI.TimeChart.UCTimeLine(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpItemTable = new DevExpress.XtraEditors.GroupControl();
            this.gcTagTable = new DevExpress.XtraGrid.GridControl();
            this.gvTagTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsTagShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorShow = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpMeterItemTable = new DevExpress.XtraEditors.GroupControl();
            this.gcMeterTable = new DevExpress.XtraGrid.GridControl();
            this.gvMeterTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsMeterShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorMeterShow = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColParent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.cntxGanttTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuGridGantMenuSplitter4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGanttItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeriesItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSeriesTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRefTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCalibrationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTimeSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSeriesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpItemTable)).BeginInit();
            this.grpItemTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTagTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTagTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMeterItemTable)).BeginInit();
            this.grpMeterItemTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMeterTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMeterTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMeterShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            this.cntxGanttTreeMenu.SuspendLayout();
            this.cntxSeriesTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exMenuBar
            // 
            this.exMenuBar.BarName = "Tools";
            this.exMenuBar.DockCol = 0;
            this.exMenuBar.DockRow = 0;
            this.exMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exMenuBar.OptionsBar.DrawSizeGrip = true;
            this.exMenuBar.OptionsBar.MultiLine = true;
            this.exMenuBar.OptionsBar.UseWholeRow = true;
            this.exMenuBar.Text = "Tools";
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar1});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.dtRefTime,
            this.dtCalibTime,
            this.btnApply,
            this.btnExit,
            this.barButtonItem1,
            this.txtTimeSpan,
            this.barButtonItem2,
            this.btnMeterShow,
            this.btnClear});
            this.exBarManager.MaxItemId = 10;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorRefTime,
            this.exEditorCalibrationTime,
            this.exEditorTimeSpan});
            this.exBarManager.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ready";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bar1
            // 
            this.bar1.BarName = "Calibration Bar";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtRefTime, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtCalibTime, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnApply, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.txtTimeSpan, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMeterShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear)});
            this.bar1.OptionsBar.AllowRename = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Calibration Bar";
            // 
            // dtRefTime
            // 
            this.dtRefTime.Caption = "Reference Time(기준 시간)";
            this.dtRefTime.Edit = this.exEditorRefTime;
            this.dtRefTime.EditValue = new System.DateTime(2015, 11, 24, 8, 30, 29, 700);
            this.dtRefTime.Id = 0;
            this.dtRefTime.Name = "dtRefTime";
            this.dtRefTime.Width = 120;
            // 
            // exEditorRefTime
            // 
            this.exEditorRefTime.AutoHeight = false;
            this.exEditorRefTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorRefTime.DisplayFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditorRefTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorRefTime.EditFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditorRefTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorRefTime.Mask.EditMask = "yy-MM-dd HH:mm";
            this.exEditorRefTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorRefTime.Name = "exEditorRefTime";
            // 
            // dtCalibTime
            // 
            this.dtCalibTime.Caption = "Calibration Time(교정 대상 시간)";
            this.dtCalibTime.Edit = this.exEditorCalibrationTime;
            this.dtCalibTime.EditValue = new System.DateTime(2015, 11, 24, 8, 30, 36, 875);
            this.dtCalibTime.Id = 1;
            this.dtCalibTime.Name = "dtCalibTime";
            this.dtCalibTime.Width = 120;
            // 
            // exEditorCalibrationTime
            // 
            this.exEditorCalibrationTime.AutoHeight = false;
            this.exEditorCalibrationTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorCalibrationTime.DisplayFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditorCalibrationTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorCalibrationTime.EditFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditorCalibrationTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorCalibrationTime.Mask.EditMask = "yy-MM-dd HH:mm";
            this.exEditorCalibrationTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorCalibrationTime.Name = "exEditorCalibrationTime";
            // 
            // btnApply
            // 
            this.btnApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnApply.Caption = "Apply";
            this.btnApply.Glyph = ((System.Drawing.Image)(resources.GetObject("btnApply.Glyph")));
            this.btnApply.Id = 2;
            this.btnApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnApply.LargeGlyph")));
            this.btnApply.Name = "btnApply";
            this.btnApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApply_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 3;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // txtTimeSpan
            // 
            this.txtTimeSpan.Caption = "TimeSpan ";
            this.txtTimeSpan.Edit = this.exEditorTimeSpan;
            this.txtTimeSpan.Id = 6;
            this.txtTimeSpan.Name = "txtTimeSpan";
            this.txtTimeSpan.Width = 80;
            // 
            // exEditorTimeSpan
            // 
            this.exEditorTimeSpan.AutoHeight = false;
            this.exEditorTimeSpan.Name = "exEditorTimeSpan";
            this.exEditorTimeSpan.ReadOnly = true;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "ms";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnMeterShow
            // 
            this.btnMeterShow.Caption = "Show";
            this.btnMeterShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMeterShow.Glyph")));
            this.btnMeterShow.Id = 8;
            this.btnMeterShow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMeterShow.LargeGlyph")));
            this.btnMeterShow.Name = "btnMeterShow";
            this.btnMeterShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMeterShow_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 9;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1047, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 587);
            this.barDockControlBottom.Size = new System.Drawing.Size(1047, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 522);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1047, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 522);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(313, 65);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucGanttChart);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(734, 522);
            this.splitContainerControl1.SplitterPosition = 276;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucGanttChart
            // 
            this.ucGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGanttChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGanttChart.Location = new System.Drawing.Point(0, 0);
            this.ucGanttChart.Name = "ucGanttChart";
            this.ucGanttChart.Size = new System.Drawing.Size(734, 276);
            this.ucGanttChart.TabIndex = 0;
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.ucSeriesTree);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.ucSeriesChart);
            this.splitContainerControl3.Panel2.Controls.Add(this.ucTimeLine);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(734, 241);
            this.splitContainerControl3.SplitterPosition = 300;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // ucSeriesTree
            // 
            this.ucSeriesTree.ColumnHeight = 18;
            this.ucSeriesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeriesTree.FirstVisibleItem = null;
            this.ucSeriesTree.FirstVisibleItemIndex = 0;
            this.ucSeriesTree.FocusedItem = null;
            this.ucSeriesTree.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucSeriesTree.IsItemMovable = true;
            this.ucSeriesTree.ItemHeight = 18;
            this.ucSeriesTree.Location = new System.Drawing.Point(0, 0);
            this.ucSeriesTree.Name = "ucSeriesTree";
            this.ucSeriesTree.ScrollValue = 0;
            this.ucSeriesTree.ShowAutoFilter = false;
            this.ucSeriesTree.ShowCheckBox = false;
            this.ucSeriesTree.ShowHScrollBarAlways = true;
            this.ucSeriesTree.Size = new System.Drawing.Size(300, 241);
            this.ucSeriesTree.TabIndex = 1;
            this.ucSeriesTree.UEventCellValueChagned += new UDM.UI.TimeChart.UEventHandlerItemTreeCellValueChanged(this.SeriesTree_UEventCellValueChagned);
            // 
            // ucSeriesChart
            // 
            cSeriesAxis1.MajorTickCount = 10;
            cSeriesAxis1.Maximum = 1F;
            cSeriesAxis1.Minimumn = 0F;
            cSeriesAxis1.MinorTickCount = 2;
            cSeriesAxis1.ShowMinorGrid = true;
            this.ucSeriesChart.Axis = cSeriesAxis1;
            this.ucSeriesChart.AxisScrollValue = 0;
            this.ucSeriesChart.BackColor = System.Drawing.Color.White;
            this.ucSeriesChart.ChartType = UDM.UI.TimeChart.EMSeriesChartType.Line;
            this.ucSeriesChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeriesChart.ErrorImage = null;
            this.ucSeriesChart.Image = null;
            this.ucSeriesChart.InitialImage = null;
            this.ucSeriesChart.Location = new System.Drawing.Point(0, 40);
            this.ucSeriesChart.Name = "ucSeriesChart";
            this.ucSeriesChart.SeriesTree = this.ucSeriesTree;
            this.ucSeriesChart.Size = new System.Drawing.Size(429, 201);
            this.ucSeriesChart.TabIndex = 4;
            this.ucSeriesChart.TabStop = false;
            this.ucSeriesChart.TimeLine = this.ucTimeLine;
            // 
            // ucTimeLine
            // 
            this.ucTimeLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTimeLine.ErrorImage = null;
            this.ucTimeLine.FirstVisibleTime = new System.DateTime(1, 1, 1, 0, 0, 1, 0);
            this.ucTimeLine.Image = null;
            this.ucTimeLine.InitialImage = null;
            this.ucTimeLine.Location = new System.Drawing.Point(0, 0);
            this.ucTimeLine.Name = "ucTimeLine";
            this.ucTimeLine.RangeFrom = new System.DateTime(((long)(0)));
            this.ucTimeLine.RangeTo = new System.DateTime(((long)(0)));
            this.ucTimeLine.ScrollValue = 1;
            this.ucTimeLine.Size = new System.Drawing.Size(429, 40);
            this.ucTimeLine.TabIndex = 1;
            this.ucTimeLine.TabStop = false;
            this.ucTimeLine.UnitWidth = 20F;
            this.ucTimeLine.UEventTimeIndicatorMoved += new UDM.UI.TimeChart.UEventHandlerTimeLineTimeIndicatorMoved(this.SeriesChart_TimeLine_UEventTimeIndicatorMoved);
            this.ucTimeLine.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Series_TimeLine_MouseDoubleClick);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(308, 65);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 522);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 65);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.grpItemTable);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grpMeterItemTable);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(308, 522);
            this.splitContainerControl2.SplitterPosition = 276;
            this.splitContainerControl2.TabIndex = 6;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // grpItemTable
            // 
            this.grpItemTable.Controls.Add(this.gcTagTable);
            this.grpItemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemTable.Location = new System.Drawing.Point(0, 0);
            this.grpItemTable.Name = "grpItemTable";
            this.grpItemTable.Size = new System.Drawing.Size(308, 276);
            this.grpItemTable.TabIndex = 33;
            this.grpItemTable.Text = "Reference Item Table";
            // 
            // gcTagTable
            // 
            this.gcTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTagTable.Location = new System.Drawing.Point(2, 21);
            this.gcTagTable.MainView = this.gvTagTable;
            this.gcTagTable.MenuManager = this.exBarManager;
            this.gcTagTable.Name = "gcTagTable";
            this.gcTagTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorShow});
            this.gcTagTable.Size = new System.Drawing.Size(304, 253);
            this.gcTagTable.TabIndex = 0;
            this.gcTagTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTagTable});
            // 
            // gvTagTable
            // 
            this.gvTagTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsTagShow,
            this.colAddress,
            this.colDescription,
            this.colLogCount});
            this.gvTagTable.GridControl = this.gcTagTable;
            this.gvTagTable.Name = "gvTagTable";
            this.gvTagTable.OptionsDetail.AllowZoomDetail = false;
            this.gvTagTable.OptionsDetail.EnableMasterViewMode = false;
            this.gvTagTable.OptionsDetail.ShowDetailTabs = false;
            this.gvTagTable.OptionsDetail.SmartDetailExpand = false;
            this.gvTagTable.OptionsView.ShowAutoFilterRow = true;
            this.gvTagTable.OptionsView.ShowGroupPanel = false;
            this.gvTagTable.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvTagTable_CellValueChanging);
            // 
            // colIsTagShow
            // 
            this.colIsTagShow.AppearanceCell.Options.UseTextOptions = true;
            this.colIsTagShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsTagShow.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsTagShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsTagShow.Caption = "Show";
            this.colIsTagShow.ColumnEdit = this.exEditorShow;
            this.colIsTagShow.FieldName = "IsVisible";
            this.colIsTagShow.Name = "colIsTagShow";
            this.colIsTagShow.OptionsColumn.FixedWidth = true;
            this.colIsTagShow.Width = 45;
            // 
            // exEditorShow
            // 
            this.exEditorShow.AutoHeight = false;
            this.exEditorShow.Name = "exEditorShow";
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 74;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 93;
            // 
            // colLogCount
            // 
            this.colLogCount.AppearanceCell.Options.UseTextOptions = true;
            this.colLogCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.Caption = "LogCount";
            this.colLogCount.FieldName = "LogCount";
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.OptionsColumn.AllowEdit = false;
            this.colLogCount.OptionsColumn.ReadOnly = true;
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 2;
            this.colLogCount.Width = 97;
            // 
            // grpMeterItemTable
            // 
            this.grpMeterItemTable.Controls.Add(this.gcMeterTable);
            this.grpMeterItemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMeterItemTable.Location = new System.Drawing.Point(0, 0);
            this.grpMeterItemTable.Name = "grpMeterItemTable";
            this.grpMeterItemTable.Size = new System.Drawing.Size(308, 241);
            this.grpMeterItemTable.TabIndex = 34;
            this.grpMeterItemTable.Text = "Calibration Item Table";
            // 
            // gcMeterTable
            // 
            this.gcMeterTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMeterTable.Location = new System.Drawing.Point(2, 21);
            this.gcMeterTable.MainView = this.gvMeterTable;
            this.gcMeterTable.MenuManager = this.exBarManager;
            this.gcMeterTable.Name = "gcMeterTable";
            this.gcMeterTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorMeterShow,
            this.exEditorColor});
            this.gcMeterTable.Size = new System.Drawing.Size(304, 218);
            this.gcMeterTable.TabIndex = 1;
            this.gcMeterTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMeterTable});
            // 
            // gvMeterTable
            // 
            this.gvMeterTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsMeterShow,
            this.ColParent,
            this.colUnitKey});
            this.gvMeterTable.GridControl = this.gcMeterTable;
            this.gvMeterTable.Name = "gvMeterTable";
            this.gvMeterTable.OptionsDetail.AllowZoomDetail = false;
            this.gvMeterTable.OptionsDetail.EnableMasterViewMode = false;
            this.gvMeterTable.OptionsDetail.ShowDetailTabs = false;
            this.gvMeterTable.OptionsDetail.SmartDetailExpand = false;
            this.gvMeterTable.OptionsView.ShowAutoFilterRow = true;
            this.gvMeterTable.OptionsView.ShowGroupPanel = false;
            this.gvMeterTable.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvMeterTable_CellValueChanging);
            // 
            // colIsMeterShow
            // 
            this.colIsMeterShow.AppearanceCell.Options.UseTextOptions = true;
            this.colIsMeterShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsMeterShow.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsMeterShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsMeterShow.Caption = "Show";
            this.colIsMeterShow.ColumnEdit = this.exEditorMeterShow;
            this.colIsMeterShow.FieldName = "IsVisible";
            this.colIsMeterShow.Name = "colIsMeterShow";
            this.colIsMeterShow.OptionsColumn.FixedWidth = true;
            this.colIsMeterShow.Visible = true;
            this.colIsMeterShow.VisibleIndex = 0;
            this.colIsMeterShow.Width = 56;
            // 
            // exEditorMeterShow
            // 
            this.exEditorMeterShow.AutoHeight = false;
            this.exEditorMeterShow.Name = "exEditorMeterShow";
            // 
            // ColParent
            // 
            this.ColParent.AppearanceCell.Options.UseTextOptions = true;
            this.ColParent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColParent.AppearanceHeader.Options.UseTextOptions = true;
            this.ColParent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColParent.Caption = "Parent";
            this.ColParent.FieldName = "Parent";
            this.ColParent.Name = "ColParent";
            this.ColParent.OptionsColumn.AllowEdit = false;
            this.ColParent.OptionsColumn.ReadOnly = true;
            this.ColParent.Visible = true;
            this.ColParent.VisibleIndex = 2;
            this.ColParent.Width = 105;
            // 
            // colUnitKey
            // 
            this.colUnitKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitKey.Caption = "Key";
            this.colUnitKey.FieldName = "Key";
            this.colUnitKey.Name = "colUnitKey";
            this.colUnitKey.OptionsColumn.AllowEdit = false;
            this.colUnitKey.OptionsColumn.ReadOnly = true;
            this.colUnitKey.Visible = true;
            this.colUnitKey.VisibleIndex = 1;
            this.colUnitKey.Width = 142;
            // 
            // exEditorColor
            // 
            this.exEditorColor.AutoHeight = false;
            this.exEditorColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColor.Name = "exEditorColor";
            // 
            // cntxGanttTreeMenu
            // 
            this.cntxGanttTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGridGantMenuSplitter4,
            this.mnuGanttItemDelete});
            this.cntxGanttTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxGanttTreeMenu.Size = new System.Drawing.Size(155, 32);
            // 
            // mnuGridGantMenuSplitter4
            // 
            this.mnuGridGantMenuSplitter4.Name = "mnuGridGantMenuSplitter4";
            this.mnuGridGantMenuSplitter4.Size = new System.Drawing.Size(151, 6);
            this.mnuGridGantMenuSplitter4.Visible = false;
            // 
            // mnuGanttItemDelete
            // 
            this.mnuGanttItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuGanttItemDelete.Image")));
            this.mnuGanttItemDelete.Name = "mnuGanttItemDelete";
            this.mnuGanttItemDelete.Size = new System.Drawing.Size(154, 22);
            this.mnuGanttItemDelete.Text = "선택 접점 삭제";
            this.mnuGanttItemDelete.Click += new System.EventHandler(this.mnuGanttItemDelete_Click);
            // 
            // mnuSeriesItemDelete
            // 
            this.mnuSeriesItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesItemDelete.Image")));
            this.mnuSeriesItemDelete.Name = "mnuSeriesItemDelete";
            this.mnuSeriesItemDelete.Size = new System.Drawing.Size(166, 22);
            this.mnuSeriesItemDelete.Text = "선택 접점 삭제";
            // 
            // cntxSeriesTreeMenu
            // 
            this.cntxSeriesTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cntxSeriesTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxSeriesTreeMenu.Size = new System.Drawing.Size(155, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "선택 접점 삭제";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.mnuSeriesItemDelete_Click);
            // 
            // FrmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 612);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmCalibration";
            this.Text = "Calibration";
            this.Load += new System.EventHandler(this.FrmCalibration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorRefTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCalibrationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTimeSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSeriesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpItemTable)).EndInit();
            this.grpItemTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTagTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTagTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMeterItemTable)).EndInit();
            this.grpMeterItemTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMeterTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMeterTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMeterShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            this.cntxGanttTreeMenu.ResumeLayout(false);
            this.cntxSeriesTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar exMenuBar;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorRefTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorCalibrationTime;
        private DevExpress.XtraBars.BarEditItem dtRefTime;
        private DevExpress.XtraBars.BarEditItem dtCalibTime;
        private DevExpress.XtraBars.BarLargeButtonItem btnApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl grpItemTable;
        private DevExpress.XtraGrid.GridControl gcTagTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTagTable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTagShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorShow;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private DevExpress.XtraEditors.GroupControl grpMeterItemTable;
        private DevExpress.XtraGrid.GridControl gcMeterTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMeterTable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMeterShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorMeterShow;
        private DevExpress.XtraGrid.Columns.GridColumn ColParent;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private UDM.UI.TimeChart.UCTimeChart ucGanttChart;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private UDM.UI.TimeChart.UCSeriesTree ucSeriesTree;
        private UDM.UI.TimeChart.UCTimeLine ucTimeLine;
        private UDM.UI.TimeChart.UCSeriesChart ucSeriesChart;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem txtTimeSpan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorTimeSpan;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarLargeButtonItem btnMeterShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private System.Windows.Forms.ContextMenuStrip cntxGanttTreeMenu;
        private System.Windows.Forms.ToolStripSeparator mnuGridGantMenuSplitter4;
        private System.Windows.Forms.ToolStripMenuItem mnuGanttItemDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesItemDelete;
        private System.Windows.Forms.ContextMenuStrip cntxSeriesTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}