namespace UDMEnergyViewer
{
    partial class FrmBaseEnergySelector
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("0", new object[] {
            ((object)(1.5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(7.2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(3.3D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(3.7D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(2.1D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseEnergySelector));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEnergyUnit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBaseEnergy = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucSeriesTree = new UDM.UI.TimeChart.UCSeriesTree(this.components);
            this.EnergyChart = new DevExpress.XtraCharts.ChartControl();
            this.exbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnergyUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseEnergy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Location = new System.Drawing.Point(5, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Energy Unit ";
            // 
            // txtEnergyUnit
            // 
            this.txtEnergyUnit.Location = new System.Drawing.Point(5, 52);
            this.txtEnergyUnit.Name = "txtEnergyUnit";
            this.txtEnergyUnit.Properties.ReadOnly = true;
            this.txtEnergyUnit.Size = new System.Drawing.Size(214, 20);
            this.txtEnergyUnit.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Location = new System.Drawing.Point(5, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Base Energy";
            // 
            // txtBaseEnergy
            // 
            this.txtBaseEnergy.EditValue = "0";
            this.txtBaseEnergy.Location = new System.Drawing.Point(5, 98);
            this.txtBaseEnergy.Name = "txtBaseEnergy";
            this.txtBaseEnergy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBaseEnergy.Size = new System.Drawing.Size(180, 20);
            this.txtBaseEnergy.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl4.Location = new System.Drawing.Point(191, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Watt";
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(174, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(111, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 32);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Controls.Add(this.txtEnergyUnit);
            this.groupControl1.Controls.Add(this.txtBaseEnergy);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(242, 165);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Information";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 32);
            this.panel1.TabIndex = 9;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 65);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucSeriesTree);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.EnergyChart);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(915, 331);
            this.splitContainerControl1.SplitterPosition = 242;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucSeriesTree
            // 
            this.ucSeriesTree.ColumnHeight = 18;
            this.ucSeriesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeriesTree.FirstVisibleItem = null;
            this.ucSeriesTree.FirstVisibleItemIndex = 0;
            this.ucSeriesTree.FocusedItem = null;
            this.ucSeriesTree.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucSeriesTree.IsItemMovable = true;
            this.ucSeriesTree.ItemHeight = 18;
            this.ucSeriesTree.Location = new System.Drawing.Point(0, 165);
            this.ucSeriesTree.Name = "ucSeriesTree";
            this.ucSeriesTree.ScrollValue = 0;
            this.ucSeriesTree.ShowAutoFilter = false;
            this.ucSeriesTree.ShowCheckBox = false;
            this.ucSeriesTree.ShowHScrollBarAlways = true;
            this.ucSeriesTree.Size = new System.Drawing.Size(242, 166);
            this.ucSeriesTree.TabIndex = 10;
            // 
            // EnergyChart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            constantLine1.AxisValueSerializable = "1";
            constantLine1.Color = System.Drawing.Color.Red;
            constantLine1.LineStyle.Thickness = 2;
            constantLine1.Name = "BaseEnergyLine";
            constantLine1.ShowBehind = true;
            constantLine1.ShowInLegend = false;
            constantLine1.Title.Text = "Base Energy";
            xyDiagram1.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine1});
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.EnergyChart.Diagram = xyDiagram1;
            this.EnergyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnergyChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.EnergyChart.Location = new System.Drawing.Point(0, 0);
            this.EnergyChart.Name = "EnergyChart";
            series1.Name = "Energy Consumption";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5});
            lineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Diamond;
            lineSeriesView1.LineMarkerOptions.Size = 5;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = lineSeriesView1;
            this.EnergyChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.EnergyChart.Size = new System.Drawing.Size(668, 331);
            this.EnergyChart.TabIndex = 0;
            this.EnergyChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EnergyChart_MouseDown);
            this.EnergyChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EnergyChart_MouseMove);
            this.EnergyChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EnergyChart_MouseUp);
            // 
            // exbarManager
            // 
            this.exbarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.exbarManager.DockControls.Add(this.barDockControlTop);
            this.exbarManager.DockControls.Add(this.barDockControlBottom);
            this.exbarManager.DockControls.Add(this.barDockControlLeft);
            this.exbarManager.DockControls.Add(this.barDockControlRight);
            this.exbarManager.Form = this;
            this.exbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.dtpkFrom,
            this.dtpkTo,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnExit,
            this.barButtonItem1});
            this.exbarManager.MaxItemId = 6;
            this.exbarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorColor,
            this.exEditorFrom,
            this.exEditorTo});
            this.exbarManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(2830, 166);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.Id = 0;
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
            this.exEditorFrom.ReadOnly = true;
            // 
            // dtpkTo
            // 
            this.dtpkTo.Caption = "To";
            this.dtpkTo.Edit = this.exEditorTo;
            this.dtpkTo.Id = 1;
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
            this.exEditorTo.ReadOnly = true;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Glyph = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Glyph")));
            this.btnZoomIn.Id = 2;
            this.btnZoomIn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.LargeGlyph")));
            this.btnZoomIn.Name = "btnZoomIn";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Glyph = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Glyph")));
            this.btnZoomOut.Id = 3;
            this.btnZoomOut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.LargeGlyph")));
            this.btnZoomOut.Name = "btnZoomOut";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 4;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(915, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 396);
            this.barDockControlBottom.Size = new System.Drawing.Size(915, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 331);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(915, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 331);
            // 
            // exEditorColor
            // 
            this.exEditorColor.AutoHeight = false;
            this.exEditorColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColor.Name = "exEditorColor";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ready";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FrmBaseEnergySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 421);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBaseEnergySelector";
            this.Text = "Base Energy Select";
            this.Load += new System.EventHandler(this.FrmBaseEnergySelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEnergyUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseEnergy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEnergyUnit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBaseEnergy;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private UDM.UI.TimeChart.UCSeriesTree ucSeriesTree;
        private DevExpress.XtraCharts.ChartControl EnergyChart;
        private DevExpress.XtraBars.BarManager exbarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}