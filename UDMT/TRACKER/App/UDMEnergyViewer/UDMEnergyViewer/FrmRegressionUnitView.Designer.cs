namespace UDMEnergyViewer
{
    partial class FrmRegressionUnitView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegressionUnitView));
            this.exbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.dtFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.lbStatus = new DevExpress.XtraBars.BarButtonItem();
            this.spinAxisMin = new DevExpress.XtraBars.BarEditItem();
            this.exEditorAxisMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spinAxisMax = new DevExpress.XtraBars.BarEditItem();
            this.exEditorAxisMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnAxisApply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcRegressionUnit = new DevExpress.XtraGrid.GridControl();
            this.gvRegressionUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisaggregation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnergyUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMergeDepth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseEnergy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcCycle = new DevExpress.XtraGrid.GridControl();
            this.gvCycle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCycleDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCycleAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.ucTimeChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalEnergy = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTimeInfo = new DevExpress.XtraEditors.PanelControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblWordValue = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.pnlIndicator1 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.pnlIndicator2 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.pnlInterval = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRegressionUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegressionUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCycle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalEnergy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeInfo)).BeginInit();
            this.pnlTimeInfo.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.pnlIndicator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.pnlIndicator2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.pnlInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // exbarManager
            // 
            this.exbarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.exbarManager.DockControls.Add(this.barDockControlTop);
            this.exbarManager.DockControls.Add(this.barDockControlBottom);
            this.exbarManager.DockControls.Add(this.barDockControlLeft);
            this.exbarManager.DockControls.Add(this.barDockControlRight);
            this.exbarManager.Form = this;
            this.exbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnShow,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.dtFrom,
            this.dtTo,
            this.lbStatus,
            this.spinAxisMin,
            this.btnAxisApply,
            this.spinAxisMax});
            this.exbarManager.LargeImages = this.imgListLarge;
            this.exbarManager.MaxItemId = 17;
            this.exbarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo,
            this.exEditorAxisMax,
            this.exEditorAxisMin});
            this.exbarManager.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnZoomIn, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnZoomOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnShow, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // dtFrom
            // 
            this.dtFrom.Caption = "From";
            this.dtFrom.Edit = this.exEditorFrom;
            this.dtFrom.EditValue = new System.DateTime(2015, 11, 19, 9, 15, 31, 192);
            this.dtFrom.Id = 6;
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Width = 120;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // dtTo
            // 
            this.dtTo.Caption = "To";
            this.dtTo.Edit = this.exEditorTo;
            this.dtTo.EditValue = new System.DateTime(2015, 11, 19, 9, 15, 36, 582);
            this.dtTo.Id = 7;
            this.dtTo.Name = "dtTo";
            this.dtTo.Width = 120;
            // 
            // exEditorTo
            // 
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 2;
            this.btnZoomIn.LargeImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 3;
            this.btnZoomOut.LargeImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 4;
            this.btnItemUp.LargeImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 5;
            this.btnItemDown.LargeImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShow.Glyph")));
            this.btnShow.Id = 0;
            this.btnShow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShow.LargeGlyph")));
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 1;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Status Bar";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbStatus),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spinAxisMin, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spinAxisMax, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAxisApply)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Status Bar";
            // 
            // lbStatus
            // 
            this.lbStatus.Caption = " Ready ";
            this.lbStatus.Id = 9;
            this.lbStatus.Name = "lbStatus";
            // 
            // spinAxisMin
            // 
            this.spinAxisMin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spinAxisMin.Caption = "Min";
            this.spinAxisMin.Edit = this.exEditorAxisMin;
            this.spinAxisMin.EditValue = 0D;
            this.spinAxisMin.Id = 14;
            this.spinAxisMin.Name = "spinAxisMin";
            this.spinAxisMin.Width = 70;
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
            // spinAxisMax
            // 
            this.spinAxisMax.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spinAxisMax.Caption = "Max";
            this.spinAxisMax.Edit = this.exEditorAxisMax;
            this.spinAxisMax.EditValue = 1000D;
            this.spinAxisMax.Id = 16;
            this.spinAxisMax.Name = "spinAxisMax";
            this.spinAxisMax.Width = 70;
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
            this.exEditorAxisMax.MinValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.exEditorAxisMax.Name = "exEditorAxisMax";
            // 
            // btnAxisApply
            // 
            this.btnAxisApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnAxisApply.Caption = "Apply";
            this.btnAxisApply.Id = 15;
            this.btnAxisApply.Name = "btnAxisApply";
            this.btnAxisApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAxisApply_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1218, 67);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 756);
            this.barDockControlBottom.Size = new System.Drawing.Size(1218, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 67);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 689);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1218, 67);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 689);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 67);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1218, 689);
            this.splitContainerControl1.SplitterPosition = 469;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcRegressionUnit);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(469, 532);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Regression Unit List";
            // 
            // gcRegressionUnit
            // 
            this.gcRegressionUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRegressionUnit.Location = new System.Drawing.Point(2, 21);
            this.gcRegressionUnit.MainView = this.gvRegressionUnit;
            this.gcRegressionUnit.MenuManager = this.exbarManager;
            this.gcRegressionUnit.Name = "gcRegressionUnit";
            this.gcRegressionUnit.Size = new System.Drawing.Size(465, 509);
            this.gcRegressionUnit.TabIndex = 0;
            this.gcRegressionUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRegressionUnit});
            // 
            // gvRegressionUnit
            // 
            this.gvRegressionUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colDescription,
            this.colDisaggregation,
            this.colEnergyUnit,
            this.colMergeDepth,
            this.colDegree,
            this.colTheta,
            this.colBaseEnergy});
            this.gvRegressionUnit.GridControl = this.gcRegressionUnit;
            this.gvRegressionUnit.Name = "gvRegressionUnit";
            this.gvRegressionUnit.OptionsBehavior.Editable = false;
            this.gvRegressionUnit.OptionsView.ColumnAutoWidth = false;
            this.gvRegressionUnit.OptionsView.ShowAutoFilterRow = true;
            this.gvRegressionUnit.OptionsView.ShowGroupPanel = false;
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Width = 64;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            this.colDescription.Width = 74;
            // 
            // colDisaggregation
            // 
            this.colDisaggregation.AppearanceCell.Options.UseTextOptions = true;
            this.colDisaggregation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDisaggregation.AppearanceHeader.Options.UseTextOptions = true;
            this.colDisaggregation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDisaggregation.Caption = "Disaggregation";
            this.colDisaggregation.FieldName = "Disaggregation";
            this.colDisaggregation.Name = "colDisaggregation";
            this.colDisaggregation.Visible = true;
            this.colDisaggregation.VisibleIndex = 1;
            this.colDisaggregation.Width = 88;
            // 
            // colEnergyUnit
            // 
            this.colEnergyUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colEnergyUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEnergyUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colEnergyUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEnergyUnit.Caption = "EnergyUnit";
            this.colEnergyUnit.FieldName = "EnergyUnit";
            this.colEnergyUnit.Name = "colEnergyUnit";
            this.colEnergyUnit.Visible = true;
            this.colEnergyUnit.VisibleIndex = 2;
            this.colEnergyUnit.Width = 69;
            // 
            // colMergeDepth
            // 
            this.colMergeDepth.AppearanceCell.Options.UseTextOptions = true;
            this.colMergeDepth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMergeDepth.AppearanceHeader.Options.UseTextOptions = true;
            this.colMergeDepth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMergeDepth.Caption = "MergeDepth";
            this.colMergeDepth.FieldName = "MergeDepth";
            this.colMergeDepth.Name = "colMergeDepth";
            // 
            // colDegree
            // 
            this.colDegree.AppearanceCell.Options.UseTextOptions = true;
            this.colDegree.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDegree.AppearanceHeader.Options.UseTextOptions = true;
            this.colDegree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDegree.Caption = "Degree";
            this.colDegree.FieldName = "Degree";
            this.colDegree.Name = "colDegree";
            this.colDegree.Visible = true;
            this.colDegree.VisibleIndex = 3;
            this.colDegree.Width = 62;
            // 
            // colTheta
            // 
            this.colTheta.AppearanceCell.Options.UseTextOptions = true;
            this.colTheta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTheta.AppearanceHeader.Options.UseTextOptions = true;
            this.colTheta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTheta.Caption = "Theta";
            this.colTheta.FieldName = "Theta";
            this.colTheta.Name = "colTheta";
            this.colTheta.Visible = true;
            this.colTheta.VisibleIndex = 4;
            this.colTheta.Width = 73;
            // 
            // colBaseEnergy
            // 
            this.colBaseEnergy.AppearanceCell.Options.UseTextOptions = true;
            this.colBaseEnergy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBaseEnergy.AppearanceHeader.Options.UseTextOptions = true;
            this.colBaseEnergy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBaseEnergy.Caption = "BaseEnergy";
            this.colBaseEnergy.FieldName = "BaseEnergy";
            this.colBaseEnergy.Name = "colBaseEnergy";
            this.colBaseEnergy.Visible = true;
            this.colBaseEnergy.VisibleIndex = 5;
            this.colBaseEnergy.Width = 83;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcCycle);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 532);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(469, 157);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Energy Estimate Per Cycle";
            // 
            // gcCycle
            // 
            this.gcCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCycle.Location = new System.Drawing.Point(2, 21);
            this.gcCycle.MainView = this.gvCycle;
            this.gcCycle.MenuManager = this.exbarManager;
            this.gcCycle.Name = "gcCycle";
            this.gcCycle.Size = new System.Drawing.Size(377, 134);
            this.gcCycle.TabIndex = 1;
            this.gcCycle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCycle});
            // 
            // gvCycle
            // 
            this.gvCycle.GridControl = this.gcCycle;
            this.gvCycle.Name = "gvCycle";
            this.gvCycle.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCycleDelete);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnCycleAdd);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(379, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 134);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // btnCycleDelete
            // 
            this.btnCycleDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycleDelete.Location = new System.Drawing.Point(0, 72);
            this.btnCycleDelete.Name = "btnCycleDelete";
            this.btnCycleDelete.Size = new System.Drawing.Size(88, 41);
            this.btnCycleDelete.TabIndex = 4;
            this.btnCycleDelete.Text = "Cycle Delete";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(88, 10);
            this.panel4.TabIndex = 3;
            // 
            // btnCycleAdd
            // 
            this.btnCycleAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCycleAdd.Location = new System.Drawing.Point(0, 21);
            this.btnCycleAdd.Name = "btnCycleAdd";
            this.btnCycleAdd.Size = new System.Drawing.Size(88, 41);
            this.btnCycleAdd.TabIndex = 2;
            this.btnCycleAdd.Text = "Cycle Add";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 21);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 21);
            this.panel2.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.ucTimeChart);
            this.groupControl4.Controls.Add(this.panel6);
            this.groupControl4.Controls.Add(this.pnlTimeInfo);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(744, 689);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Edit Operation";
            // 
            // ucTimeChart
            // 
            this.ucTimeChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTimeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTimeChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucTimeChart.Location = new System.Drawing.Point(2, 58);
            this.ucTimeChart.Name = "ucTimeChart";
            this.ucTimeChart.Size = new System.Drawing.Size(740, 608);
            this.ucTimeChart.TabIndex = 25;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtTotalEnergy);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(2, 666);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(740, 21);
            this.panel6.TabIndex = 27;
            this.panel6.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estimated Total Energy Consumption :";
            // 
            // txtTotalEnergy
            // 
            this.txtTotalEnergy.Location = new System.Drawing.Point(581, 1);
            this.txtTotalEnergy.MenuManager = this.exbarManager;
            this.txtTotalEnergy.Name = "txtTotalEnergy";
            this.txtTotalEnergy.Size = new System.Drawing.Size(116, 20);
            this.txtTotalEnergy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "kW/h";
            // 
            // pnlTimeInfo
            // 
            this.pnlTimeInfo.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlTimeInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTimeInfo.Controls.Add(this.panel5);
            this.pnlTimeInfo.Controls.Add(this.pnlIndicator1);
            this.pnlTimeInfo.Controls.Add(this.pnlIndicator2);
            this.pnlTimeInfo.Controls.Add(this.pnlInterval);
            this.pnlTimeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeInfo.Location = new System.Drawing.Point(2, 21);
            this.pnlTimeInfo.Name = "pnlTimeInfo";
            this.pnlTimeInfo.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.pnlTimeInfo.Size = new System.Drawing.Size(740, 37);
            this.pnlTimeInfo.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblWordValue);
            this.panel5.Controls.Add(this.txtWordValue);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(79, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(173, 22);
            this.panel5.TabIndex = 6;
            // 
            // lblWordValue
            // 
            this.lblWordValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblWordValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblWordValue.Location = new System.Drawing.Point(16, 0);
            this.lblWordValue.Name = "lblWordValue";
            this.lblWordValue.Size = new System.Drawing.Size(63, 22);
            this.lblWordValue.TabIndex = 2;
            this.lblWordValue.Text = "Bar Value : ";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.EditValue = "";
            this.txtWordValue.Location = new System.Drawing.Point(79, 0);
            this.txtWordValue.MenuManager = this.exbarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(94, 20);
            this.txtWordValue.TabIndex = 1;
            // 
            // pnlIndicator1
            // 
            this.pnlIndicator1.Controls.Add(this.lblIndicator1);
            this.pnlIndicator1.Controls.Add(this.dtpkIndicator1);
            this.pnlIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIndicator1.Location = new System.Drawing.Point(252, 10);
            this.pnlIndicator1.Name = "pnlIndicator1";
            this.pnlIndicator1.Size = new System.Drawing.Size(175, 22);
            this.pnlIndicator1.TabIndex = 5;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(15, 0);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(60, 22);
            this.lblIndicator1.TabIndex = 2;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(75, 0);
            this.dtpkIndicator1.MenuManager = this.exbarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator1.TabIndex = 1;
            // 
            // pnlIndicator2
            // 
            this.pnlIndicator2.Controls.Add(this.lblIndicator2);
            this.pnlIndicator2.Controls.Add(this.dtpkIndicator2);
            this.pnlIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIndicator2.Location = new System.Drawing.Point(427, 10);
            this.pnlIndicator2.Name = "pnlIndicator2";
            this.pnlIndicator2.Size = new System.Drawing.Size(170, 22);
            this.pnlIndicator2.TabIndex = 3;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(10, 0);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(60, 22);
            this.lblIndicator2.TabIndex = 2;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(70, 0);
            this.dtpkIndicator2.MenuManager = this.exbarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator2.TabIndex = 1;
            // 
            // pnlInterval
            // 
            this.pnlInterval.Controls.Add(this.lblInterval);
            this.pnlInterval.Controls.Add(this.txtInterval);
            this.pnlInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInterval.Location = new System.Drawing.Point(597, 10);
            this.pnlInterval.Name = "pnlInterval";
            this.pnlInterval.Size = new System.Drawing.Size(138, 22);
            this.pnlInterval.TabIndex = 4;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(8, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(56, 22);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(64, 0);
            this.txtInterval.MenuManager = this.exbarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(74, 20);
            this.txtInterval.TabIndex = 1;
            // 
            // FrmRegressionUnitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 783);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmRegressionUnitView";
            this.Text = "Regression Unit Viewer";
            this.Load += new System.EventHandler(this.FrmRegressionUnitView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAxisMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRegressionUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegressionUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCycle)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalEnergy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeInfo)).EndInit();
            this.pnlTimeInfo.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.pnlIndicator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.pnlIndicator2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.pnlInterval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exbarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gcRegressionUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRegressionUnit;
        private DevExpress.XtraGrid.GridControl gcCycle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCycle;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCycleDelete;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btnCycleAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PanelControl pnlTimeInfo;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.LabelControl lblWordValue;
        private DevExpress.XtraEditors.TextEdit txtWordValue;
        private System.Windows.Forms.Panel pnlIndicator1;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel pnlIndicator2;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel pnlInterval;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucTimeChart;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDisaggregation;
        private DevExpress.XtraGrid.Columns.GridColumn colEnergyUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMergeDepth;
        private DevExpress.XtraGrid.Columns.GridColumn colDegree;
        private DevExpress.XtraGrid.Columns.GridColumn colTheta;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseEnergy;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTotalEnergy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem dtFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem lbStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorAxisMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorAxisMin;
        private DevExpress.XtraBars.BarEditItem spinAxisMin;
        private DevExpress.XtraBars.BarButtonItem btnAxisApply;
        private DevExpress.XtraBars.BarEditItem spinAxisMax;
    }
}