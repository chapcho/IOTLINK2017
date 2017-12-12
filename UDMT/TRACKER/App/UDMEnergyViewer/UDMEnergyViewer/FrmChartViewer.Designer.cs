namespace UDMEnergyViewer
{
    partial class FrmChartViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChartViewer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exMenuBar = new DevExpress.XtraBars.Bar();
            this.btnAllTagViewer = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCoilView = new DevExpress.XtraBars.BarLargeButtonItem();
            this.cboDisaggregation = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDisaggregation = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAnalysis = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exStatusBar = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.dtSeriesPointTime = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPointTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.txtPointValue = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPointValue = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.spnAxisMin = new DevExpress.XtraBars.BarEditItem();
            this.exEditorAxisMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spnAxisMax = new DevExpress.XtraBars.BarEditItem();
            this.exEditorAxisMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnAxisApply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAllTagView = new DevExpress.XtraBars.BarButtonItem();
            this.imgList = new DevExpress.Utils.ImageCollection(this.components);
            this.ucChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSelectedMeterShow = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllTagShow = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.splitMain = new System.Windows.Forms.Splitter();
            this.grpItemTable = new DevExpress.XtraEditors.GroupControl();
            this.gcTagTable = new DevExpress.XtraGrid.GridControl();
            this.cntxItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
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
            this.spltLeftHalf = new DevExpress.XtraEditors.SplitterControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.cntxGanttTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuGridGantMenuSplitter4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGanttItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSeriesTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.munRelatedTagView = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDisaggregation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPointTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPointValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpItemTable)).BeginInit();
            this.grpItemTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTagTable)).BeginInit();
            this.cntxItemMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTagTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMeterItemTable)).BeginInit();
            this.grpMeterItemTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMeterTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMeterTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMeterShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            this.panel5.SuspendLayout();
            this.cntxGanttTreeMenu.SuspendLayout();
            this.cntxSeriesTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exMenuBar,
            this.exStatusBar});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnShow,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnAxisApply,
            this.spnAxisMax,
            this.spnAxisMin,
            this.cboDisaggregation,
            this.btnAllTagView,
            this.btnAllTagViewer,
            this.btnAnalysis,
            this.btnCoilView,
            this.txtPointValue,
            this.dtSeriesPointTime});
            this.exBarManager.LargeImages = this.imgList;
            this.exBarManager.MaxItemId = 28;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo,
            this.exEditorAxisMax,
            this.exEditorAxisMin,
            this.exEditorDisaggregation,
            this.exEditorPointValue,
            this.exEditorPointTime});
            this.exBarManager.StatusBar = this.exStatusBar;
            // 
            // exMenuBar
            // 
            this.exMenuBar.BarName = "Tools";
            this.exMenuBar.DockCol = 0;
            this.exMenuBar.DockRow = 0;
            this.exMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAllTagViewer, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCoilView),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboDisaggregation, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnalysis),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown)});
            this.exMenuBar.OptionsBar.DrawSizeGrip = true;
            this.exMenuBar.OptionsBar.MultiLine = true;
            this.exMenuBar.OptionsBar.UseWholeRow = true;
            this.exMenuBar.Text = "Tools";
            // 
            // btnAllTagViewer
            // 
            this.btnAllTagViewer.Caption = "Tag View";
            this.btnAllTagViewer.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllTagViewer.Glyph")));
            this.btnAllTagViewer.Id = 23;
            this.btnAllTagViewer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAllTagViewer.LargeGlyph")));
            this.btnAllTagViewer.Name = "btnAllTagViewer";
            this.btnAllTagViewer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllTagViewer_ItemClick);
            // 
            // btnCoilView
            // 
            this.btnCoilView.Caption = "Coil View";
            this.btnCoilView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCoilView.Glyph")));
            this.btnCoilView.Id = 25;
            this.btnCoilView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCoilView.LargeGlyph")));
            this.btnCoilView.Name = "btnCoilView";
            this.btnCoilView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCoilView_ItemClick);
            // 
            // cboDisaggregation
            // 
            this.cboDisaggregation.Caption = "Disaggregation";
            this.cboDisaggregation.Edit = this.exEditorDisaggregation;
            this.cboDisaggregation.Id = 21;
            this.cboDisaggregation.Name = "cboDisaggregation";
            this.cboDisaggregation.Width = 134;
            this.cboDisaggregation.EditValueChanged += new System.EventHandler(this.cboDisaggregation_EditValueChanged);
            // 
            // exEditorDisaggregation
            // 
            this.exEditorDisaggregation.AutoHeight = false;
            this.exEditorDisaggregation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDisaggregation.Name = "exEditorDisaggregation";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 11, 10, 9, 26, 40, 4);
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 120;
            this.dtpkFrom.EditValueChanged += new System.EventHandler(this.dtpkFrom_EditValueChanged);
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.EditFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditorFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // dtpkTo
            // 
            this.dtpkTo.Caption = "To";
            this.dtpkTo.Edit = this.exEditorTo;
            this.dtpkTo.EditValue = new System.DateTime(2015, 11, 10, 9, 28, 12, 759);
            this.dtpkTo.Id = 2;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 120;
            this.dtpkTo.EditValueChanged += new System.EventHandler(this.dtpkTo_EditValueChanged);
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
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 3;
            this.btnShow.LargeImageIndex = 1;
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Caption = "Analysis";
            this.btnAnalysis.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnalysis.Glyph")));
            this.btnAnalysis.Id = 24;
            this.btnAnalysis.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnalysis.LargeGlyph")));
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnalysis_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 5;
            this.btnClear.LargeImageIndex = 0;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 6;
            this.btnZoomIn.LargeImageIndex = 2;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 7;
            this.btnZoomOut.LargeImageIndex = 3;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 8;
            this.btnItemUp.LargeImageIndex = 5;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 9;
            this.btnItemDown.LargeImageIndex = 4;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // exStatusBar
            // 
            this.exStatusBar.BarName = "Status bar";
            this.exStatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.exStatusBar.DockCol = 0;
            this.exStatusBar.DockRow = 0;
            this.exStatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.exStatusBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtSeriesPointTime, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.txtPointValue, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spnAxisMin, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spnAxisMax, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAxisApply)});
            this.exStatusBar.OptionsBar.AllowQuickCustomization = false;
            this.exStatusBar.OptionsBar.DrawDragBorder = false;
            this.exStatusBar.OptionsBar.UseWholeRow = true;
            this.exStatusBar.Text = "Status bar";
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // dtSeriesPointTime
            // 
            this.dtSeriesPointTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.dtSeriesPointTime.Caption = "Point Time";
            this.dtSeriesPointTime.Edit = this.exEditorPointTime;
            this.dtSeriesPointTime.Id = 27;
            this.dtSeriesPointTime.Name = "dtSeriesPointTime";
            this.dtSeriesPointTime.Width = 120;
            // 
            // exEditorPointTime
            // 
            this.exEditorPointTime.AutoHeight = false;
            this.exEditorPointTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPointTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorPointTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorPointTime.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorPointTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorPointTime.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorPointTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorPointTime.Name = "exEditorPointTime";
            // 
            // txtPointValue
            // 
            this.txtPointValue.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtPointValue.Caption = "Point Value ";
            this.txtPointValue.Edit = this.exEditorPointValue;
            this.txtPointValue.EditValue = 0D;
            this.txtPointValue.Id = 26;
            this.txtPointValue.Name = "txtPointValue";
            this.txtPointValue.Width = 90;
            // 
            // exEditorPointValue
            // 
            this.exEditorPointValue.Appearance.Options.UseTextOptions = true;
            this.exEditorPointValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.exEditorPointValue.AutoHeight = false;
            this.exEditorPointValue.Name = "exEditorPointValue";
            this.exEditorPointValue.ReadOnly = true;
            // 
            // spnAxisMin
            // 
            this.spnAxisMin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spnAxisMin.Caption = "Min";
            this.spnAxisMin.Edit = this.exEditorAxisMin;
            this.spnAxisMin.EditValue = 0D;
            this.spnAxisMin.Id = 13;
            this.spnAxisMin.Name = "spnAxisMin";
            this.spnAxisMin.Width = 70;
            // 
            // exEditorAxisMin
            // 
            this.exEditorAxisMin.AutoHeight = false;
            this.exEditorAxisMin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAxisMin.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.exEditorAxisMin.Name = "exEditorAxisMin";
            // 
            // spnAxisMax
            // 
            this.spnAxisMax.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spnAxisMax.Caption = "Max";
            this.spnAxisMax.Edit = this.exEditorAxisMax;
            this.spnAxisMax.EditValue = 1D;
            this.spnAxisMax.Id = 12;
            this.spnAxisMax.Name = "spnAxisMax";
            this.spnAxisMax.Width = 70;
            // 
            // exEditorAxisMax
            // 
            this.exEditorAxisMax.AutoHeight = false;
            this.exEditorAxisMax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAxisMax.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.exEditorAxisMax.Name = "exEditorAxisMax";
            // 
            // btnAxisApply
            // 
            this.btnAxisApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnAxisApply.Caption = "Apply";
            this.btnAxisApply.Id = 11;
            this.btnAxisApply.Name = "btnAxisApply";
            this.btnAxisApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAxisApply_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1241, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 659);
            this.barDockControlBottom.Size = new System.Drawing.Size(1241, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 594);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1241, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 594);
            // 
            // btnAllTagView
            // 
            this.btnAllTagView.Caption = "All Tag View";
            this.btnAllTagView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllTagView.Glyph")));
            this.btnAllTagView.Id = 22;
            this.btnAllTagView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAllTagView.LargeGlyph")));
            this.btnAllTagView.Name = "btnAllTagView";
            // 
            // imgList
            // 
            this.imgList.ImageSize = new System.Drawing.Size(32, 32);
            this.imgList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.Images.SetKeyName(0, "RemoveItem_32x32.png");
            this.imgList.Images.SetKeyName(1, "Gantt_32x32.png");
            this.imgList.Images.SetKeyName(2, "ZoomIn_32x32.png");
            this.imgList.Images.SetKeyName(3, "ZoomOut_32x32.png");
            this.imgList.Images.SetKeyName(4, "MoveDown_32x32.png");
            this.imgList.Images.SetKeyName(5, "MoveUp_32x32.png");
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucChart.Location = new System.Drawing.Point(301, 95);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(940, 564);
            this.ucChart.TabIndex = 10;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSelectedMeterShow);
            this.panelControl1.Controls.Add(this.btnAllTagShow);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1241, 25);
            this.panelControl1.TabIndex = 26;
            // 
            // btnSelectedMeterShow
            // 
            this.btnSelectedMeterShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectedMeterShow.Location = new System.Drawing.Point(107, 2);
            this.btnSelectedMeterShow.Name = "btnSelectedMeterShow";
            this.btnSelectedMeterShow.Size = new System.Drawing.Size(144, 21);
            this.btnSelectedMeterShow.TabIndex = 4;
            this.btnSelectedMeterShow.Text = "Selected Meter Show";
            this.btnSelectedMeterShow.Click += new System.EventHandler(this.btnSelectedMeterShow_Click);
            // 
            // btnAllTagShow
            // 
            this.btnAllTagShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAllTagShow.Location = new System.Drawing.Point(2, 2);
            this.btnAllTagShow.Name = "btnAllTagShow";
            this.btnAllTagShow.Size = new System.Drawing.Size(105, 21);
            this.btnAllTagShow.TabIndex = 3;
            this.btnAllTagShow.Text = "All Tag Show";
            this.btnAllTagShow.Click += new System.EventHandler(this.btnAllTagShow_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.txtWordValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(603, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 21);
            this.panel2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(10, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Bar Value :";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.Location = new System.Drawing.Point(69, 0);
            this.txtWordValue.MenuManager = this.exBarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(98, 20);
            this.txtWordValue.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(770, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 21);
            this.panel4.TabIndex = 2;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(11, 0);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator1.TabIndex = 4;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(71, 0);
            this.dtpkIndicator1.MenuManager = this.exBarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblIndicator2);
            this.panel3.Controls.Add(this.dtpkIndicator2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(941, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 21);
            this.panel3.TabIndex = 2;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(5, 0);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator2.TabIndex = 4;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(65, 0);
            this.dtpkIndicator2.MenuManager = this.exBarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1106, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 21);
            this.panel1.TabIndex = 0;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(3, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(56, 21);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(59, 0);
            this.txtInterval.MenuManager = this.exBarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(74, 20);
            this.txtInterval.TabIndex = 3;
            // 
            // splitMain
            // 
            this.splitMain.Location = new System.Drawing.Point(298, 95);
            this.splitMain.Name = "splitMain";
            this.splitMain.Size = new System.Drawing.Size(3, 564);
            this.splitMain.TabIndex = 31;
            this.splitMain.TabStop = false;
            // 
            // grpItemTable
            // 
            this.grpItemTable.Controls.Add(this.gcTagTable);
            this.grpItemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemTable.Location = new System.Drawing.Point(0, 0);
            this.grpItemTable.Name = "grpItemTable";
            this.grpItemTable.Size = new System.Drawing.Size(298, 322);
            this.grpItemTable.TabIndex = 32;
            this.grpItemTable.Text = "Tag Item Table";
            // 
            // gcTagTable
            // 
            this.gcTagTable.ContextMenuStrip = this.cntxItemMenu;
            this.gcTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTagTable.Location = new System.Drawing.Point(2, 21);
            this.gcTagTable.MainView = this.gvTagTable;
            this.gcTagTable.MenuManager = this.exBarManager;
            this.gcTagTable.Name = "gcTagTable";
            this.gcTagTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorShow});
            this.gcTagTable.Size = new System.Drawing.Size(294, 299);
            this.gcTagTable.TabIndex = 0;
            this.gcTagTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTagTable});
            // 
            // cntxItemMenu
            // 
            this.cntxItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemDelete,
            this.mnuItemAdd});
            this.cntxItemMenu.Name = "cntxGridGanttMenu";
            this.cntxItemMenu.Size = new System.Drawing.Size(162, 48);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemDelete.Image")));
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.Size = new System.Drawing.Size(161, 22);
            this.mnuItemDelete.Text = "Item 삭제";
            this.mnuItemDelete.Click += new System.EventHandler(this.mnuItemDelete_Click);
            // 
            // mnuItemAdd
            // 
            this.mnuItemAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemAdd.Image")));
            this.mnuItemAdd.Name = "mnuItemAdd";
            this.mnuItemAdd.Size = new System.Drawing.Size(161, 22);
            this.mnuItemAdd.Text = "Meter Item 추가";
            this.mnuItemAdd.Click += new System.EventHandler(this.mnuItemAdd_Click);
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
            this.gvTagTable.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvTagTable_CustomDrawRowIndicator);
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
            this.colIsTagShow.Visible = true;
            this.colIsTagShow.VisibleIndex = 0;
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
            this.colAddress.VisibleIndex = 1;
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
            this.colDescription.VisibleIndex = 2;
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
            this.colLogCount.VisibleIndex = 3;
            this.colLogCount.Width = 97;
            // 
            // grpMeterItemTable
            // 
            this.grpMeterItemTable.Controls.Add(this.gcMeterTable);
            this.grpMeterItemTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMeterItemTable.Location = new System.Drawing.Point(0, 327);
            this.grpMeterItemTable.Name = "grpMeterItemTable";
            this.grpMeterItemTable.Size = new System.Drawing.Size(298, 237);
            this.grpMeterItemTable.TabIndex = 33;
            this.grpMeterItemTable.Text = "Meter Item Table";
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
            this.gcMeterTable.Size = new System.Drawing.Size(294, 214);
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
            this.gvMeterTable.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvMeterTable_CustomDrawRowIndicator);
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
            // spltLeftHalf
            // 
            this.spltLeftHalf.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltLeftHalf.Location = new System.Drawing.Point(0, 90);
            this.spltLeftHalf.Name = "spltLeftHalf";
            this.spltLeftHalf.Size = new System.Drawing.Size(1241, 5);
            this.spltLeftHalf.TabIndex = 38;
            this.spltLeftHalf.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grpItemTable);
            this.panel5.Controls.Add(this.splitterControl1);
            this.panel5.Controls.Add(this.grpMeterItemTable);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 95);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(298, 564);
            this.panel5.TabIndex = 43;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 322);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(298, 5);
            this.splitterControl1.TabIndex = 34;
            this.splitterControl1.TabStop = false;
            // 
            // cntxGanttTreeMenu
            // 
            this.cntxGanttTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGridGantMenuSplitter4,
            this.mnuGanttItemDelete});
            this.cntxGanttTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxGanttTreeMenu.Size = new System.Drawing.Size(155, 32);
            this.cntxGanttTreeMenu.Click += new System.EventHandler(this.mnuGanttItemDelete_Click);
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
            // 
            // cntxSeriesTreeMenu
            // 
            this.cntxSeriesTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesItemDelete,
            this.munRelatedTagView});
            this.cntxSeriesTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxSeriesTreeMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // mnuSeriesItemDelete
            // 
            this.mnuSeriesItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesItemDelete.Image")));
            this.mnuSeriesItemDelete.Name = "mnuSeriesItemDelete";
            this.mnuSeriesItemDelete.Size = new System.Drawing.Size(166, 22);
            this.mnuSeriesItemDelete.Text = "선택 접점 삭제";
            this.mnuSeriesItemDelete.Click += new System.EventHandler(this.mnuSeriesItemDelete_Click);
            // 
            // munRelatedTagView
            // 
            this.munRelatedTagView.Image = ((System.Drawing.Image)(resources.GetObject("munRelatedTagView.Image")));
            this.munRelatedTagView.Name = "munRelatedTagView";
            this.munRelatedTagView.Size = new System.Drawing.Size(166, 22);
            this.munRelatedTagView.Text = "연관된 접점 보기";
            this.munRelatedTagView.Click += new System.EventHandler(this.munRelatedTagView_Click);
            // 
            // FrmChartViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 684);
            this.Controls.Add(this.ucChart);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.spltLeftHalf);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmChartViewer";
            this.Text = "FrmChartViewer";
            this.Load += new System.EventHandler(this.FrmChartViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDisaggregation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPointTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPointValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpItemTable)).EndInit();
            this.grpItemTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTagTable)).EndInit();
            this.cntxItemMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTagTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMeterItemTable)).EndInit();
            this.grpMeterItemTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMeterTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMeterTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMeterShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            this.panel5.ResumeLayout(false);
            this.cntxGanttTreeMenu.ResumeLayout(false);
            this.cntxSeriesTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exMenuBar;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private DevExpress.XtraBars.Bar exStatusBar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgList;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucChart;
        private DevExpress.XtraBars.BarEditItem spnAxisMin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorAxisMin;
        private DevExpress.XtraBars.BarEditItem spnAxisMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorAxisMax;
        private DevExpress.XtraBars.BarButtonItem btnAxisApply;
        private DevExpress.XtraBars.BarEditItem cboDisaggregation;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDisaggregation;
        private DevExpress.XtraBars.BarButtonItem btnAllTagView;
        private DevExpress.XtraBars.BarLargeButtonItem btnAllTagViewer;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtWordValue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraBars.BarLargeButtonItem btnAnalysis;
        private DevExpress.XtraEditors.GroupControl grpMeterItemTable;
        private DevExpress.XtraGrid.GridControl gcMeterTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMeterTable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMeterShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorMeterShow;
        private DevExpress.XtraGrid.Columns.GridColumn ColParent;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitKey;
        private DevExpress.XtraEditors.GroupControl grpItemTable;
        private DevExpress.XtraGrid.GridControl gcTagTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTagTable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTagShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorShow;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private System.Windows.Forms.Splitter splitMain;
        private DevExpress.XtraEditors.SplitterControl spltLeftHalf;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SimpleButton btnAllTagShow;
        private DevExpress.XtraEditors.SimpleButton btnSelectedMeterShow;
        private System.Windows.Forms.ContextMenuStrip cntxGanttTreeMenu;
        private System.Windows.Forms.ToolStripSeparator mnuGridGantMenuSplitter4;
        private System.Windows.Forms.ToolStripMenuItem mnuGanttItemDelete;
        private System.Windows.Forms.ContextMenuStrip cntxSeriesTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesItemDelete;
        private DevExpress.XtraBars.BarLargeButtonItem btnCoilView;
        private DevExpress.XtraBars.BarEditItem txtPointValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorPointValue;
        private System.Windows.Forms.ToolStripMenuItem munRelatedTagView;
        private DevExpress.XtraBars.BarEditItem dtSeriesPointTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorPointTime;
        private System.Windows.Forms.ContextMenuStrip cntxItemMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
    }
}