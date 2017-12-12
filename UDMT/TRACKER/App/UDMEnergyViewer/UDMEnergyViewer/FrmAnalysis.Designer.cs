namespace UDMEnergyViewer
{
    partial class FrmAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalysis));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("0", new object[] {
            ((object)(6.2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(5.2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(1.1D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(5.4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(7.5D))});
            DevExpress.XtraCharts.PointSeriesView pointSeriesView1 = new DevExpress.XtraCharts.PointSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("0", new object[] {
            ((object)(1.8D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(0.9D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(3.7D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(0.8D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(7.9D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.exbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exMenuBar = new DevExpress.XtraBars.Bar();
            this.cboDisaggregation = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDisaggregation = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cboEnergyUnit = new DevExpress.XtraBars.BarEditItem();
            this.exEditorEnergyUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.spinMergeDepth = new DevExpress.XtraBars.BarEditItem();
            this.exEditorMergeDepth = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.dtFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.spinDegree = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDegree = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcTag = new DevExpress.XtraGrid.GridControl();
            this.gvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnShowData = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.Chart = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtEquation = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDisaggregation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMergeDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEquation.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // exbarManager
            // 
            this.exbarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exMenuBar});
            this.exbarManager.DockControls.Add(this.barDockControlTop);
            this.exbarManager.DockControls.Add(this.barDockControlBottom);
            this.exbarManager.DockControls.Add(this.barDockControlLeft);
            this.exbarManager.DockControls.Add(this.barDockControlRight);
            this.exbarManager.Form = this;
            this.exbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.dtFrom,
            this.dtTo,
            this.btnShow,
            this.btnClear,
            this.cboDisaggregation,
            this.spinDegree,
            this.barEditItem1,
            this.cboEnergyUnit,
            this.spinMergeDepth});
            this.exbarManager.MaxItemId = 10;
            this.exbarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditFrom,
            this.exEditTo,
            this.exEditorDisaggregation,
            this.exEditorDegree,
            this.exEditorEnergyUnit,
            this.exEditorMergeDepth});
            // 
            // exMenuBar
            // 
            this.exMenuBar.BarName = "Tools";
            this.exMenuBar.DockCol = 0;
            this.exMenuBar.DockRow = 0;
            this.exMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboDisaggregation, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboEnergyUnit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spinMergeDepth, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spinDegree, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnShow, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.exMenuBar.OptionsBar.MultiLine = true;
            this.exMenuBar.OptionsBar.UseWholeRow = true;
            this.exMenuBar.Text = "Tools";
            // 
            // cboDisaggregation
            // 
            this.cboDisaggregation.Caption = "Disaggregation";
            this.cboDisaggregation.Edit = this.exEditorDisaggregation;
            this.cboDisaggregation.Id = 4;
            this.cboDisaggregation.Name = "cboDisaggregation";
            this.cboDisaggregation.Width = 120;
            this.cboDisaggregation.EditValueChanged += new System.EventHandler(this.cboDisaggregation_EditValueChanged);
            // 
            // exEditorDisaggregation
            // 
            this.exEditorDisaggregation.AutoHeight = false;
            this.exEditorDisaggregation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDisaggregation.Name = "exEditorDisaggregation";
            // 
            // cboEnergyUnit
            // 
            this.cboEnergyUnit.Caption = "Energy Unit ";
            this.cboEnergyUnit.Edit = this.exEditorEnergyUnit;
            this.cboEnergyUnit.Id = 8;
            this.cboEnergyUnit.Name = "cboEnergyUnit";
            this.cboEnergyUnit.Width = 120;
            this.cboEnergyUnit.EditValueChanged += new System.EventHandler(this.cboEnergyUnit_EditValueChanged);
            // 
            // exEditorEnergyUnit
            // 
            this.exEditorEnergyUnit.AutoHeight = false;
            this.exEditorEnergyUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorEnergyUnit.Name = "exEditorEnergyUnit";
            // 
            // spinMergeDepth
            // 
            this.spinMergeDepth.Caption = "Merge Depth";
            this.spinMergeDepth.Edit = this.exEditorMergeDepth;
            this.spinMergeDepth.Id = 9;
            this.spinMergeDepth.Name = "spinMergeDepth";
            this.spinMergeDepth.Width = 40;
            this.spinMergeDepth.EditValueChanged += new System.EventHandler(this.spinMergeDepth_EditValueChanged);
            // 
            // exEditorMergeDepth
            // 
            this.exEditorMergeDepth.AutoHeight = false;
            this.exEditorMergeDepth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMergeDepth.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorMergeDepth.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorMergeDepth.Name = "exEditorMergeDepth";
            this.exEditorMergeDepth.NullText = "1";
            // 
            // dtFrom
            // 
            this.dtFrom.Caption = "From";
            this.dtFrom.Edit = this.exEditFrom;
            this.dtFrom.EditValue = new System.DateTime(2015, 11, 18, 15, 24, 9, 662);
            this.dtFrom.Id = 0;
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Width = 120;
            // 
            // exEditFrom
            // 
            this.exEditFrom.AutoHeight = false;
            this.exEditFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditFrom.EditFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditFrom.Name = "exEditFrom";
            this.exEditFrom.ReadOnly = true;
            // 
            // dtTo
            // 
            this.dtTo.Caption = "To";
            this.dtTo.Edit = this.exEditTo;
            this.dtTo.EditValue = new System.DateTime(2015, 11, 18, 15, 24, 18, 350);
            this.dtTo.Id = 1;
            this.dtTo.Name = "dtTo";
            this.dtTo.Width = 120;
            // 
            // exEditTo
            // 
            this.exEditTo.AutoHeight = false;
            this.exEditTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditTo.EditFormat.FormatString = "yy-MM-dd HH:mm";
            this.exEditTo.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditTo.Name = "exEditTo";
            this.exEditTo.ReadOnly = true;
            // 
            // spinDegree
            // 
            this.spinDegree.Caption = "Degree ";
            this.spinDegree.Edit = this.exEditorDegree;
            this.spinDegree.Id = 5;
            this.spinDegree.Name = "spinDegree";
            this.spinDegree.Width = 40;
            this.spinDegree.EditValueChanged += new System.EventHandler(this.spinDegree_EditValueChanged);
            // 
            // exEditorDegree
            // 
            this.exEditorDegree.AutoHeight = false;
            this.exEditorDegree.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDegree.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorDegree.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorDegree.Name = "exEditorDegree";
            this.exEditorDegree.NullText = "1";
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShow.Glyph")));
            this.btnShow.Id = 2;
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 3;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1208, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 699);
            this.barDockControlBottom.Size = new System.Drawing.Size(1208, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 634);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1208, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 634);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 7;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 65);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1208, 634);
            this.splitContainerControl1.SplitterPosition = 253;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcData);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 179);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(253, 455);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Regression Data";
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(2, 21);
            this.gcData.MainView = this.gvData;
            this.gcData.MenuManager = this.exbarManager;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(249, 432);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcTag);
            this.groupControl1.Controls.Add(this.panel6);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(253, 179);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tag Information";
            // 
            // gcTag
            // 
            this.gcTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTag.Location = new System.Drawing.Point(2, 21);
            this.gcTag.MainView = this.gvTag;
            this.gcTag.MenuManager = this.exbarManager;
            this.gcTag.Name = "gcTag";
            this.gcTag.Size = new System.Drawing.Size(249, 129);
            this.gcTag.TabIndex = 1;
            this.gcTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTag});
            // 
            // gvTag
            // 
            this.gvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDescription});
            this.gvTag.GridControl = this.gcTag;
            this.gvTag.Name = "gvTag";
            this.gvTag.OptionsBehavior.Editable = false;
            this.gvTag.OptionsDetail.EnableMasterViewMode = false;
            this.gvTag.OptionsDetail.SmartDetailExpand = false;
            this.gvTag.OptionsView.ShowGroupPanel = false;
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
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 64;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 169;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnShowData);
            this.panel6.Controls.Add(this.btnClearData);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(2, 150);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(249, 27);
            this.panel6.TabIndex = 0;
            // 
            // btnShowData
            // 
            this.btnShowData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowData.Location = new System.Drawing.Point(109, 0);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(71, 27);
            this.btnShowData.TabIndex = 1;
            this.btnShowData.Text = "Show";
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearData.Location = new System.Drawing.Point(180, 0);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(69, 27);
            this.btnClearData.TabIndex = 0;
            this.btnClearData.Text = "Clear";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.Chart);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(950, 553);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Regressgion Plot";
            // 
            // Chart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.Chart.Diagram = xyDiagram1;
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Location = new System.Drawing.Point(2, 21);
            this.Chart.Name = "Chart";
            series1.Name = "Energy Variation";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5});
            series1.View = pointSeriesView1;
            series2.Name = "Regression Line";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint6,
            seriesPoint7,
            seriesPoint8,
            seriesPoint9,
            seriesPoint10});
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.View = lineSeriesView1;
            this.Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.Chart.Size = new System.Drawing.Size(946, 530);
            this.Chart.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 553);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(950, 81);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.panel2);
            this.groupControl4.Controls.Add(this.panel3);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(2, 2);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(946, 77);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "Regression Equation";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.txtEquation);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 54);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(786, 15);
            this.panel5.TabIndex = 3;
            // 
            // txtEquation
            // 
            this.txtEquation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEquation.Location = new System.Drawing.Point(0, 19);
            this.txtEquation.MenuManager = this.exbarManager;
            this.txtEquation.Name = "txtEquation";
            this.txtEquation.Properties.ReadOnly = true;
            this.txtEquation.Size = new System.Drawing.Size(786, 20);
            this.txtEquation.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 19);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(788, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 54);
            this.panel3.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(89, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 54);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(71, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(18, 54);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 54);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 699);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmAnalysis";
            this.Text = "Energy Analysis";
            this.Load += new System.EventHandler(this.FrmAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDisaggregation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMergeDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEquation.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exbarManager;
        private DevExpress.XtraBars.Bar exMenuBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem dtFrom;
        private DevExpress.XtraBars.BarEditItem dtTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditTo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarEditItem cboDisaggregation;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDisaggregation;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraBars.BarEditItem spinDegree;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorDegree;
        private DevExpress.XtraCharts.ChartControl Chart;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.TextEdit txtEquation;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorEnergyUnit;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem cboEnergyUnit;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraBars.BarEditItem spinMergeDepth;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMergeDepth;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gcTag;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTag;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.SimpleButton btnShowData;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
    }
}