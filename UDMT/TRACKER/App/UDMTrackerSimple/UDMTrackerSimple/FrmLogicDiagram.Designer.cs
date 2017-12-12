namespace UDMTrackerSimple
{
    partial class FrmLogicDiagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogicDiagram));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cboPLC = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnMinimize = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnMaximize = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.grpStepTable = new DevExpress.XtraEditors.GroupControl();
            this.ucMultiStepTagTable = new UDMTrackerSimple.UCMultiStepTagTable();
            this.grpLogicDiagram = new DevExpress.XtraEditors.GroupControl();
            this.ucLogicDiagramS = new UDM.LogicViewer.UCLogicDiagramS();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStepTable)).BeginInit();
            this.grpStepTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogicDiagram)).BeginInit();
            this.grpLogicDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
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
            this.btnRefresh,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnMinimize,
            this.btnMaximize,
            this.btnExit,
            this.cboPLC});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 8;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorPLC});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.FloatLocation = new System.Drawing.Point(2436, 134);
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboPLC, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMinimize),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMaximize),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // cboPLC
            // 
            this.cboPLC.Caption = "PLC";
            this.cboPLC.Edit = this.exEditorPLC;
            this.cboPLC.EditWidth = 120;
            this.cboPLC.Id = 7;
            this.cboPLC.Name = "cboPLC";
            this.cboPLC.EditValueChanged += new System.EventHandler(this.cboPLC_EditValueChanged);
            // 
            // exEditorPLC
            // 
            this.exEditorPLC.AutoHeight = false;
            this.exEditorPLC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPLC.Name = "exEditorPLC";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 0;
            this.btnRefresh.LargeImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 1;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
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
            // btnMinimize
            // 
            this.btnMinimize.Caption = "Minimize";
            this.btnMinimize.Id = 4;
            this.btnMinimize.LargeImageIndex = 16;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMinimize_ItemClick);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Caption = "Maximize";
            this.btnMaximize.Id = 5;
            this.btnMaximize.LargeImageIndex = 17;
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaximize_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 6;
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
            this.exBarStatus.OptionsBar.AllowQuickCustomization = false;
            this.exBarStatus.OptionsBar.DrawDragBorder = false;
            this.exBarStatus.OptionsBar.UseWholeRow = true;
            this.exBarStatus.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(848, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 511);
            this.barDockControlBottom.Size = new System.Drawing.Size(848, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 446);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(848, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 446);
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
            this.imgListLarge.Images.SetKeyName(16, "Squeeze_32x32.png");
            this.imgListLarge.Images.SetKeyName(17, "Stretch_32x32.png");
            // 
            // grpStepTable
            // 
            this.grpStepTable.Controls.Add(this.ucMultiStepTagTable);
            this.grpStepTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStepTable.Location = new System.Drawing.Point(0, 0);
            this.grpStepTable.Name = "grpStepTable";
            this.grpStepTable.Size = new System.Drawing.Size(392, 446);
            this.grpStepTable.TabIndex = 4;
            this.grpStepTable.Text = "Step Table";
            // 
            // ucMultiStepTagTable
            // 
            this.ucMultiStepTagTable.AllowMultiSelect = false;
            this.ucMultiStepTagTable.ContextStepMenuStrip = null;
            this.ucMultiStepTagTable.ContextTagMenuStrip = null;
            this.ucMultiStepTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMultiStepTagTable.Location = new System.Drawing.Point(2, 21);
            this.ucMultiStepTagTable.Name = "ucMultiStepTagTable";
            this.ucMultiStepTagTable.PlcLogicData = null;
            this.ucMultiStepTagTable.Size = new System.Drawing.Size(388, 423);
            this.ucMultiStepTagTable.TabIndex = 0;
            this.ucMultiStepTagTable.UEventStepDoubleClicked += new UDMTrackerSimple.UEventHandlerMultiStepDoubleClicked(this.ucStepTagTable_UEventStepDoubleClicked);
            this.ucMultiStepTagTable.UEventTagDoubleClicked += new UDMTrackerSimple.UEventHandlerMultiTagDoubleClicked(this.ucStepTagTable_UEventTagDoubleClicked);
            // 
            // grpLogicDiagram
            // 
            this.grpLogicDiagram.Controls.Add(this.ucLogicDiagramS);
            this.grpLogicDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLogicDiagram.Location = new System.Drawing.Point(0, 0);
            this.grpLogicDiagram.Name = "grpLogicDiagram";
            this.grpLogicDiagram.Size = new System.Drawing.Size(446, 446);
            this.grpLogicDiagram.TabIndex = 6;
            this.grpLogicDiagram.Text = "Step Table";
            // 
            // ucLogicDiagramS
            // 
            this.ucLogicDiagramS.BackColor = System.Drawing.Color.White;
            this.ucLogicDiagramS.ContextTabMenuStrip = null;
            this.ucLogicDiagramS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogicDiagramS.FocusedTab = null;
            this.ucLogicDiagramS.Location = new System.Drawing.Point(2, 21);
            this.ucLogicDiagramS.Name = "ucLogicDiagramS";
            this.ucLogicDiagramS.Size = new System.Drawing.Size(442, 423);
            this.ucLogicDiagramS.TabIndex = 0;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 65);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpStepTable);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grpLogicDiagram);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(848, 446);
            this.sptMain.SplitterPosition = 392;
            this.sptMain.TabIndex = 11;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // FrmLogicDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 534);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogicDiagram";
            this.Text = "Logic Diagram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLogicDiagram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStepTable)).EndInit();
            this.grpStepTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogicDiagram)).EndInit();
            this.grpLogicDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl grpLogicDiagram;
        private UDM.LogicViewer.UCLogicDiagramS ucLogicDiagramS;
        private DevExpress.XtraEditors.GroupControl grpStepTable;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnMinimize;
        private DevExpress.XtraBars.BarLargeButtonItem btnMaximize;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem cboPLC;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private UCMultiStepTagTable ucMultiStepTagTable;
        private UDM.UI.MySplitContainerControl sptMain;
    }
}