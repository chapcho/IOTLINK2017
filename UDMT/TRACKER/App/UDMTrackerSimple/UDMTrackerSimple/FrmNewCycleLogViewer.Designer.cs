namespace UDMTrackerSimple
{
    partial class FrmNewCycleLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewCycleLogViewer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cmbGroup = new DevExpress.XtraBars.BarEditItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmal = new System.Windows.Forms.ImageList(this.components);
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.pnlCycleChart = new DevExpress.XtraEditors.PanelControl();
            this.ucChart = new UDM.UI.TimeChart.UCTimeChart();
            this.toolTipConMasterBar = new DevExpress.Utils.ToolTipController(this.components);
            this.cntxCycle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCycleStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCycleEnd = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCycleChart)).BeginInit();
            this.pnlCycleChart.SuspendLayout();
            this.cntxCycle.SuspendLayout();
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
            this.exBarManager.Images = this.imgListSmal;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.cmbGroup,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnRefresh,
            this.btnExit});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 13;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cmbGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // cmbGroup
            // 
            this.cmbGroup.Caption = "Process";
            this.cmbGroup.Edit = this.exEditorGroup;
            this.cmbGroup.EditWidth = 150;
            this.cmbGroup.Id = 1;
            this.cmbGroup.Name = "cmbGroup";
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
            this.dtpkFrom.EditWidth = 150;
            this.dtpkFrom.Id = 2;
            this.dtpkFrom.Name = "dtpkFrom";
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
            this.dtpkTo.EditWidth = 150;
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
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
            this.btnRefresh.Id = 11;
            this.btnRefresh.LargeImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowCycleList_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 5;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 6;
            this.btnZoomIn.LargeImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 7;
            this.btnZoomOut.LargeImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 8;
            this.btnItemUp.LargeImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 9;
            this.btnItemDown.LargeImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 12;
            this.btnExit.LargeImageIndex = 15;
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
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1073, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
            this.barDockControlBottom.Size = new System.Drawing.Size(1073, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1073, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // imgListSmal
            // 
            this.imgListSmal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmal.ImageStream")));
            this.imgListSmal.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmal.Images.SetKeyName(0, "Grid_16x16.png");
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1073, 25);
            this.panelControl1.TabIndex = 55;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(602, 2);
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
            this.lblIndicator1.Text = "Line 1 :";
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
            this.panel3.Location = new System.Drawing.Point(773, 2);
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
            this.lblIndicator2.Text = "Line 2 :";
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
            this.panel1.Location = new System.Drawing.Point(938, 2);
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
            // pnlCycleChart
            // 
            this.pnlCycleChart.Controls.Add(this.ucChart);
            this.pnlCycleChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCycleChart.Location = new System.Drawing.Point(0, 90);
            this.pnlCycleChart.Name = "pnlCycleChart";
            this.pnlCycleChart.Size = new System.Drawing.Size(1073, 412);
            this.pnlCycleChart.TabIndex = 66;
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart.Location = new System.Drawing.Point(2, 2);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(1069, 408);
            this.ucChart.TabIndex = 61;
            // 
            // toolTipConMasterBar
            // 
            this.toolTipConMasterBar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipConMasterBar.Appearance.Options.UseFont = true;
            this.toolTipConMasterBar.AppearanceTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolTipConMasterBar.AppearanceTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipConMasterBar.AppearanceTitle.Options.UseBorderColor = true;
            this.toolTipConMasterBar.AppearanceTitle.Options.UseFont = true;
            this.toolTipConMasterBar.AutoPopDelay = 3000;
            // 
            // cntxCycle
            // 
            this.cntxCycle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxCycle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCycleStart,
            this.mnuCycleEnd});
            this.cntxCycle.Name = "cntxMenu";
            this.cntxCycle.Size = new System.Drawing.Size(140, 56);
            this.cntxCycle.Text = "Cycle Setting";
            // 
            // mnuCycleStart
            // 
            this.mnuCycleStart.Image = ((System.Drawing.Image)(resources.GetObject("mnuCycleStart.Image")));
            this.mnuCycleStart.Name = "mnuCycleStart";
            this.mnuCycleStart.Size = new System.Drawing.Size(139, 26);
            this.mnuCycleStart.Text = "Select Start";
            this.mnuCycleStart.Click += new System.EventHandler(this.mnuCycleStart_Click);
            // 
            // mnuCycleEnd
            // 
            this.mnuCycleEnd.Image = ((System.Drawing.Image)(resources.GetObject("mnuCycleEnd.Image")));
            this.mnuCycleEnd.Name = "mnuCycleEnd";
            this.mnuCycleEnd.Size = new System.Drawing.Size(139, 26);
            this.mnuCycleEnd.Text = "Select End";
            this.mnuCycleEnd.Click += new System.EventHandler(this.mnuCycleEnd_Click);
            // 
            // FrmNewCycleLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 527);
            this.Controls.Add(this.pnlCycleChart);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNewCycleLogViewer";
            this.Text = "New Cycle Log Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmNewCycleLogViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCycleChart)).EndInit();
            this.pnlCycleChart.ResumeLayout(false);
            this.cntxCycle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem cmbGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private System.Windows.Forms.ImageList imgListSmal;
		private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraEditors.PanelControl pnlCycleChart;
        private UDM.UI.TimeChart.UCTimeChart ucChart;
        private DevExpress.Utils.ToolTipController toolTipConMasterBar;
        private System.Windows.Forms.ContextMenuStrip cntxCycle;
        private System.Windows.Forms.ToolStripMenuItem mnuCycleStart;
        private System.Windows.Forms.ToolStripMenuItem mnuCycleEnd;
    }
}