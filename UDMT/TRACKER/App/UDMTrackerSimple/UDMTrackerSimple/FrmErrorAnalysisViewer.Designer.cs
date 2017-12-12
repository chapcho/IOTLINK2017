namespace UDMTrackerSimple
{
    partial class FrmErrorAnalysisViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmErrorAnalysisViewer));
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpgPatternResult = new DevExpress.XtraTab.XtraTabPage();
            this.pnlPatternResult = new DevExpress.XtraEditors.PanelControl();
            this.ucFlowResultViewer = new UDMTrackerSimple.UCFlowResultGanttViewer();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.tpgDetectingResult = new DevExpress.XtraTab.XtraTabPage();
            this.exTreeGX = new DevComponents.Tree.TreeGX();
            this.elementStyle1 = new DevComponents.Tree.ElementStyle();
            this.nodeConnector1 = new DevComponents.Tree.NodeConnector();
            this.node1 = new DevComponents.Tree.Node();
            this.cell1 = new DevComponents.Tree.Cell();
            this.cell2 = new DevComponents.Tree.Cell();
            this.cell3 = new DevComponents.Tree.Cell();
            this.node3 = new DevComponents.Tree.Node();
            this.node2 = new DevComponents.Tree.Node();
            this.node4 = new DevComponents.Tree.Node();
            this.node5 = new DevComponents.Tree.Node();
            this.node6 = new DevComponents.Tree.Node();
            this.node7 = new DevComponents.Tree.Node();
            this.nodeConnector3 = new DevComponents.Tree.NodeConnector();
            this.nodeConnector2 = new DevComponents.Tree.NodeConnector();
            this.tpgDiagramResult = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDiagramResult = new DevExpress.XtraEditors.PanelControl();
            this.ucLogicDiagramS = new UDM.LogicViewer.UCLogicDiagramS();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.exBarManagerPattern = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnChartZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartItemUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartItemDown = new DevExpress.XtraBars.BarButtonItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.exBarManagerDiagram = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnDiagramZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramMaximize = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramMinimize = new DevExpress.XtraBars.BarButtonItem();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.columnHeader1 = new DevComponents.Tree.ColumnHeader();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpgPatternResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPatternResult)).BeginInit();
            this.pnlPatternResult.SuspendLayout();
            this.tpgDetectingResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeGX)).BeginInit();
            this.tpgDiagramResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDiagramResult)).BeginInit();
            this.pnlDiagramResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerDiagram)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpgPatternResult;
            this.tabMain.Size = new System.Drawing.Size(812, 424);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpgDetectingResult,
            this.tpgPatternResult,
            this.tpgDiagramResult});
            this.tabMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabMain_SelectedPageChanged);
            // 
            // tpgPatternResult
            // 
            this.tpgPatternResult.Controls.Add(this.pnlPatternResult);
            this.tpgPatternResult.Name = "tpgPatternResult";
            this.tpgPatternResult.Padding = new System.Windows.Forms.Padding(2);
            this.tpgPatternResult.Size = new System.Drawing.Size(806, 395);
            this.tpgPatternResult.Text = "Pattern Result";
            // 
            // pnlPatternResult
            // 
            this.pnlPatternResult.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlPatternResult.Appearance.Options.UseBackColor = true;
            this.pnlPatternResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPatternResult.Controls.Add(this.ucFlowResultViewer);
            this.pnlPatternResult.Controls.Add(this.barDockControlLeft);
            this.pnlPatternResult.Controls.Add(this.barDockControlRight);
            this.pnlPatternResult.Controls.Add(this.barDockControlBottom);
            this.pnlPatternResult.Controls.Add(this.barDockControlTop);
            this.pnlPatternResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatternResult.Location = new System.Drawing.Point(2, 2);
            this.pnlPatternResult.Name = "pnlPatternResult";
            this.pnlPatternResult.Size = new System.Drawing.Size(802, 391);
            this.pnlPatternResult.TabIndex = 0;
            // 
            // ucFlowResultViewer
            // 
            this.ucFlowResultViewer.BarHeight = 50;
            this.ucFlowResultViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFlowResultViewer.Location = new System.Drawing.Point(0, 31);
            this.ucFlowResultViewer.Name = "ucFlowResultViewer";
            this.ucFlowResultViewer.OverViewHeight = 50;
            this.ucFlowResultViewer.Size = new System.Drawing.Size(802, 360);
            this.ucFlowResultViewer.TabIndex = 7;
            this.ucFlowResultViewer.UnitHeight = 26;
            this.ucFlowResultViewer.UnitWidth = 20;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 360);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(802, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 360);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 391);
            this.barDockControlBottom.Size = new System.Drawing.Size(802, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(802, 31);
            // 
            // tpgDetectingResult
            // 
            this.tpgDetectingResult.Controls.Add(this.exTreeGX);
            this.tpgDetectingResult.Name = "tpgDetectingResult";
            this.tpgDetectingResult.PageVisible = false;
            this.tpgDetectingResult.Size = new System.Drawing.Size(806, 395);
            this.tpgDetectingResult.Text = "Detecting Result";
            // 
            // exTreeGX
            // 
            this.exTreeGX.AllowDrop = true;
            this.exTreeGX.AutoScrollMinSize = new System.Drawing.Size(280, 400);
            this.exTreeGX.BackColor = System.Drawing.Color.White;
            this.exTreeGX.CellStyleDefault = this.elementStyle1;
            this.exTreeGX.CommandBackColorGradientAngle = 90;
            this.exTreeGX.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            this.exTreeGX.CommandMouseOverBackColorGradientAngle = 90;
            this.exTreeGX.DiagramLayoutFlow = DevComponents.Tree.eDiagramFlow.RightToLeft;
            this.exTreeGX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeGX.ExpandBorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            this.exTreeGX.ExpandButtonSize = new System.Drawing.Size(16, 16);
            this.exTreeGX.ExpandButtonType = DevComponents.Tree.eExpandButtonType.Rectangle;
            this.exTreeGX.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.exTreeGX.LicenseKey = "EB364C34-3CE3-4cd6-BB1B-13513ABE0D62";
            this.exTreeGX.LinkConnector = this.nodeConnector1;
            this.exTreeGX.Location = new System.Drawing.Point(0, 0);
            this.exTreeGX.Name = "exTreeGX";
            this.exTreeGX.NodeHorizontalSpacing = 50;
            this.exTreeGX.Nodes.AddRange(new DevComponents.Tree.Node[] {
            this.node1});
            this.exTreeGX.NodesConnector = this.nodeConnector3;
            this.exTreeGX.NodeStyle = this.elementStyle1;
            this.exTreeGX.NodeVerticalSpacing = 5;
            this.exTreeGX.PathSeparator = ";";
            this.exTreeGX.RootConnector = this.nodeConnector2;
            this.exTreeGX.SelectionBox = false;
            this.exTreeGX.SelectionBoxSize = 2;
            this.exTreeGX.Size = new System.Drawing.Size(806, 395);
            this.exTreeGX.Styles.Add(this.elementStyle1);
            this.exTreeGX.SuspendPaint = false;
            this.exTreeGX.TabIndex = 0;
            this.exTreeGX.Text = "treeGX";
            // 
            // elementStyle1
            // 
            this.elementStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.elementStyle1.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.elementStyle1.BackColorGradientAngle = 5;
            this.elementStyle1.BackColorGradientType = DevComponents.Tree.eGradientType.Radial;
            this.elementStyle1.BackgroundImagePosition = DevComponents.Tree.eStyleBackgroundImage.Center;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextAlignment = DevComponents.Tree.eStyleTextAlignment.Center;
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.elementStyle1.TextTrimming = DevComponents.Tree.eStyleTextTrimming.None;
            this.elementStyle1.WordWrap = true;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.ConnectorType = DevComponents.Tree.eNodeConnectorType.Line;
            this.nodeConnector1.EndCap = DevComponents.Tree.eConnectorCap.Arrow;
            this.nodeConnector1.LineWidth = 5;
            // 
            // node1
            // 
            this.node1.CellLayout = DevComponents.Tree.eCellLayout.Vertical;
            this.node1.Cells.Add(this.cell1);
            this.node1.Cells.Add(this.cell2);
            this.node1.Cells.Add(this.cell3);
            this.node1.DragDropEnabled = false;
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.Tree.Node[] {
            this.node3});
            this.node1.Text = "node1";
            // 
            // cell1
            // 
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
            this.cell1.Text = "Test1";
            // 
            // cell2
            // 
            this.cell2.Name = "cell2";
            this.cell2.StyleMouseOver = null;
            this.cell2.Text = "Test2";
            // 
            // cell3
            // 
            this.cell3.Name = "cell3";
            this.cell3.StyleMouseOver = null;
            this.cell3.Text = "Test3";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Nodes.AddRange(new DevComponents.Tree.Node[] {
            this.node2,
            this.node4,
            this.node5,
            this.node6,
            this.node7});
            this.node3.Text = "node3";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Text = "node2";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Text = "node4";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "node5";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Text = "node6";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.Text = "node7";
            // 
            // nodeConnector3
            // 
            this.nodeConnector3.LineColor = System.Drawing.Color.LightGray;
            this.nodeConnector3.LineWidth = 2;
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.ConnectorType = DevComponents.Tree.eNodeConnectorType.Line;
            this.nodeConnector2.LineColor = System.Drawing.Color.LightGray;
            // 
            // tpgDiagramResult
            // 
            this.tpgDiagramResult.Controls.Add(this.pnlDiagramResult);
            this.tpgDiagramResult.Name = "tpgDiagramResult";
            this.tpgDiagramResult.Padding = new System.Windows.Forms.Padding(2);
            this.tpgDiagramResult.Size = new System.Drawing.Size(806, 395);
            this.tpgDiagramResult.Text = "Diagram Result";
            // 
            // pnlDiagramResult
            // 
            this.pnlDiagramResult.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDiagramResult.Appearance.Options.UseBackColor = true;
            this.pnlDiagramResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDiagramResult.Controls.Add(this.ucLogicDiagramS);
            this.pnlDiagramResult.Controls.Add(this.barDockControl3);
            this.pnlDiagramResult.Controls.Add(this.barDockControl4);
            this.pnlDiagramResult.Controls.Add(this.barDockControl2);
            this.pnlDiagramResult.Controls.Add(this.barDockControl1);
            this.pnlDiagramResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiagramResult.Location = new System.Drawing.Point(2, 2);
            this.pnlDiagramResult.Name = "pnlDiagramResult";
            this.pnlDiagramResult.Size = new System.Drawing.Size(802, 391);
            this.pnlDiagramResult.TabIndex = 1;
            // 
            // ucLogicDiagramS
            // 
            this.ucLogicDiagramS.BackColor = System.Drawing.Color.White;
            this.ucLogicDiagramS.ContextTabMenuStrip = null;
            this.ucLogicDiagramS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogicDiagramS.FocusedTab = null;
            this.ucLogicDiagramS.Location = new System.Drawing.Point(0, 31);
            this.ucLogicDiagramS.Name = "ucLogicDiagramS";
            this.ucLogicDiagramS.Size = new System.Drawing.Size(802, 360);
            this.ucLogicDiagramS.TabIndex = 7;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 360);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(802, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 360);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 391);
            this.barDockControl2.Size = new System.Drawing.Size(802, 0);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(802, 31);
            // 
            // exBarManagerPattern
            // 
            this.exBarManagerPattern.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.exBarManagerPattern.DockControls.Add(this.barDockControlTop);
            this.exBarManagerPattern.DockControls.Add(this.barDockControlBottom);
            this.exBarManagerPattern.DockControls.Add(this.barDockControlLeft);
            this.exBarManagerPattern.DockControls.Add(this.barDockControlRight);
            this.exBarManagerPattern.Form = this.pnlPatternResult;
            this.exBarManagerPattern.Images = this.imgList;
            this.exBarManagerPattern.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnChartZoomIn,
            this.btnChartZoomOut,
            this.btnChartItemUp,
            this.btnChartItemDown});
            this.exBarManagerPattern.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChartZoomIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChartZoomOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChartItemUp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChartItemDown, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.DrawSizeGrip = true;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnChartZoomIn
            // 
            this.btnChartZoomIn.Caption = "Zoom In";
            this.btnChartZoomIn.Id = 0;
            this.btnChartZoomIn.ImageIndex = 0;
            this.btnChartZoomIn.Name = "btnChartZoomIn";
            this.btnChartZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartZoomIn_ItemClick);
            // 
            // btnChartZoomOut
            // 
            this.btnChartZoomOut.Caption = "Zoom Out";
            this.btnChartZoomOut.Id = 1;
            this.btnChartZoomOut.ImageIndex = 1;
            this.btnChartZoomOut.Name = "btnChartZoomOut";
            this.btnChartZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartZoomOut_ItemClick);
            // 
            // btnChartItemUp
            // 
            this.btnChartItemUp.Caption = "Item Up";
            this.btnChartItemUp.Id = 2;
            this.btnChartItemUp.ImageIndex = 2;
            this.btnChartItemUp.Name = "btnChartItemUp";
            this.btnChartItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartItemUp_ItemClick);
            // 
            // btnChartItemDown
            // 
            this.btnChartItemDown.Caption = "Item Down";
            this.btnChartItemDown.Id = 3;
            this.btnChartItemDown.ImageIndex = 3;
            this.btnChartItemDown.Name = "btnChartItemDown";
            this.btnChartItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartItemDown_ItemClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "ZoomIn_16x16.png");
            this.imgList.Images.SetKeyName(1, "ZoomOut_16x16.png");
            this.imgList.Images.SetKeyName(2, "MoveUp_16x16.png");
            this.imgList.Images.SetKeyName(3, "MoveDown_16x16.png");
            this.imgList.Images.SetKeyName(4, "Squeeze_16x16.png");
            this.imgList.Images.SetKeyName(5, "Stretch_16x16.png");
            // 
            // exBarManagerDiagram
            // 
            this.exBarManagerDiagram.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl1);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl2);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl3);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl4);
            this.exBarManagerDiagram.Form = this.pnlDiagramResult;
            this.exBarManagerDiagram.Images = this.imgList;
            this.exBarManagerDiagram.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDiagramZoomIn,
            this.btnDiagramZoomOut,
            this.btnDiagramMaximize,
            this.btnDiagramMinimize});
            this.exBarManagerDiagram.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramZoomIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramZoomOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramMaximize, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramMinimize, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawSizeGrip = true;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Tools";
            // 
            // btnDiagramZoomIn
            // 
            this.btnDiagramZoomIn.Caption = "Zoom In";
            this.btnDiagramZoomIn.Id = 0;
            this.btnDiagramZoomIn.ImageIndex = 0;
            this.btnDiagramZoomIn.Name = "btnDiagramZoomIn";
            this.btnDiagramZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramZoomIn_ItemClick);
            // 
            // btnDiagramZoomOut
            // 
            this.btnDiagramZoomOut.Caption = "Zoom Out";
            this.btnDiagramZoomOut.Id = 1;
            this.btnDiagramZoomOut.ImageIndex = 1;
            this.btnDiagramZoomOut.Name = "btnDiagramZoomOut";
            this.btnDiagramZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramZoomOut_ItemClick);
            // 
            // btnDiagramMaximize
            // 
            this.btnDiagramMaximize.Caption = "Maximize";
            this.btnDiagramMaximize.Id = 2;
            this.btnDiagramMaximize.ImageIndex = 5;
            this.btnDiagramMaximize.Name = "btnDiagramMaximize";
            this.btnDiagramMaximize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramMaximize_ItemClick);
            // 
            // btnDiagramMinimize
            // 
            this.btnDiagramMinimize.Caption = "Minimize";
            this.btnDiagramMinimize.Id = 3;
            this.btnDiagramMinimize.ImageIndex = 4;
            this.btnDiagramMinimize.Name = "btnDiagramMinimize";
            this.btnDiagramMinimize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramMinimize_ItemClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Group";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Controls.Add(this.btnOK);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 424);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Padding = new System.Windows.Forms.Padding(3);
            this.pnlControl.Size = new System.Drawing.Size(812, 30);
            this.pnlControl.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(739, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmErrorAnalysisViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 454);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmErrorAnalysisViewer";
            this.Text = "Error Analysis Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmErrorAnalysisViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpgPatternResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPatternResult)).EndInit();
            this.pnlPatternResult.ResumeLayout(false);
            this.pnlPatternResult.PerformLayout();
            this.tpgDetectingResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeGX)).EndInit();
            this.tpgDiagramResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDiagramResult)).EndInit();
            this.pnlDiagramResult.ResumeLayout(false);
            this.pnlDiagramResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerDiagram)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpgPatternResult;
        private DevExpress.XtraTab.XtraTabPage tpgDiagramResult;
        private DevExpress.XtraEditors.PanelControl pnlPatternResult;
        private UCFlowResultGanttViewer ucFlowResultViewer;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraEditors.PanelControl pnlDiagramResult;
        private UDM.LogicViewer.UCLogicDiagramS ucLogicDiagramS;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager exBarManagerPattern;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnChartZoomIn;
        private DevExpress.XtraBars.BarButtonItem btnChartZoomOut;
        private DevExpress.XtraBars.BarButtonItem btnChartItemUp;
        private DevExpress.XtraBars.BarButtonItem btnChartItemDown;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraBars.BarManager exBarManagerDiagram;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnDiagramZoomIn;
        private DevExpress.XtraBars.BarButtonItem btnDiagramZoomOut;
        private DevExpress.XtraBars.BarButtonItem btnDiagramMaximize;
        private DevExpress.XtraBars.BarButtonItem btnDiagramMinimize;
        private System.ComponentModel.BackgroundWorker bgWorker;
		private DevExpress.XtraTab.XtraTabPage tpgDetectingResult;
		private DevComponents.Tree.TreeGX exTreeGX;
		private DevComponents.Tree.Node node1;
		private DevComponents.Tree.Node node3;
		private DevComponents.Tree.NodeConnector nodeConnector1;
		private DevComponents.Tree.NodeConnector nodeConnector2;
		private DevComponents.Tree.ElementStyle elementStyle1;
		private DevComponents.Tree.Cell cell1;
		private DevComponents.Tree.Cell cell2;
		private DevComponents.Tree.Cell cell3;
		private DevComponents.Tree.ColumnHeader columnHeader1;
		private DevComponents.Tree.NodeConnector nodeConnector3;
		private DevComponents.Tree.Node node2;
		private DevComponents.Tree.Node node4;
		private DevComponents.Tree.Node node5;
		private DevComponents.Tree.Node node6;
		private DevComponents.Tree.Node node7;
        private System.Windows.Forms.Panel pnlControl;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}