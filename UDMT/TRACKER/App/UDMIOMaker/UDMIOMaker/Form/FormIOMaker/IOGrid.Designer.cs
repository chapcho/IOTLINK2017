namespace NewIOMaker.Form.FormIOMaker
{
    partial class IOGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOGrid));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::NewIOMaker.Form.FormIOMaker.WaitForm1), true, true, typeof(System.Windows.Forms.UserControl));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colTAG = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colARRAY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTYPE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colADDRESS = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSYMBOL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnTreeExpand = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollapes = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exGrid = new DevExpress.XtraGrid.GridControl();
            this.exGridViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupTree = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTree)).BeginInit();
            this.groupTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTAG,
            this.colARRAY,
            this.colTYPE,
            this.colADDRESS,
            this.colSYMBOL});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 29);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.treeList1.OptionsBehavior.CopyToClipboardWithNodeHierarchy = false;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodeOnDrag = false;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeList1.OptionsFind.AllowFindPanel = true;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsSelection.MultiSelect = true;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.SelectImageList = this.imageCollection1;
            this.treeList1.Size = new System.Drawing.Size(477, 468);
            this.treeList1.TabIndex = 0;
            // 
            // colTAG
            // 
            this.colTAG.Caption = "TAG";
            this.colTAG.FieldName = "Tag";
            this.colTAG.MinWidth = 34;
            this.colTAG.Name = "colTAG";
            this.colTAG.Visible = true;
            this.colTAG.VisibleIndex = 0;
            this.colTAG.Width = 93;
            // 
            // colARRAY
            // 
            this.colARRAY.Caption = "ARRAY";
            this.colARRAY.FieldName = "Array";
            this.colARRAY.Name = "colARRAY";
            this.colARRAY.Visible = true;
            this.colARRAY.VisibleIndex = 1;
            // 
            // colTYPE
            // 
            this.colTYPE.Caption = "TYPE";
            this.colTYPE.FieldName = "Type";
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 2;
            // 
            // colADDRESS
            // 
            this.colADDRESS.Caption = "ADDRESS";
            this.colADDRESS.FieldName = "Address";
            this.colADDRESS.Name = "colADDRESS";
            this.colADDRESS.Visible = true;
            this.colADDRESS.VisibleIndex = 4;
            // 
            // colSYMBOL
            // 
            this.colSYMBOL.Caption = "SYMBOL";
            this.colSYMBOL.FieldName = "Symbol";
            this.colSYMBOL.Name = "colSYMBOL";
            this.colSYMBOL.Visible = true;
            this.colSYMBOL.VisibleIndex = 3;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("pages_16x16.png", "devav/layout/pages_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/layout/pages_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "pages_16x16.png");
            this.imageCollection1.InsertGalleryImage("linestyle_16x16.png", "images/analysis/linestyle_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/analysis/linestyle_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "linestyle_16x16.png");
            this.imageCollection1.InsertGalleryImage("linearforecast_16x16.png", "images/trendlines/linearforecast_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/trendlines/linearforecast_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "linearforecast_16x16.png");
            this.imageCollection1.InsertGalleryImage("increasedecimal_16x16.png", "images/number%20formats/increasedecimal_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/number%20formats/increasedecimal_16x16.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "increasedecimal_16x16.png");
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTreeExpand),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollapes)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnTreeExpand
            // 
            this.btnTreeExpand.Caption = "Expand ALL";
            this.btnTreeExpand.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTreeExpand.Glyph")));
            this.btnTreeExpand.Id = 0;
            this.btnTreeExpand.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTreeExpand.LargeGlyph")));
            this.btnTreeExpand.Name = "btnTreeExpand";
            // 
            // btnCollapes
            // 
            this.btnCollapes.Caption = "Collapse ALL";
            this.btnCollapes.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCollapes.Glyph")));
            this.btnCollapes.Id = 1;
            this.btnCollapes.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCollapes.LargeGlyph")));
            this.btnCollapes.Name = "btnCollapes";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTreeExpand,
            this.btnCollapes});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(487, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 528);
            this.barDockControlBottom.Size = new System.Drawing.Size(487, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 528);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(487, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 528);
            // 
            // exGrid
            // 
            this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrid.Location = new System.Drawing.Point(0, 0);
            this.exGrid.MainView = this.exGridViewLog;
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(485, 500);
            this.exGrid.TabIndex = 1;
            this.exGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewLog});
            // 
            // exGridViewLog
            // 
            this.exGridViewLog.GridControl = this.exGrid;
            this.exGridViewLog.GroupPanelText = "원하는 항목을 드래그하세요";
            this.exGridViewLog.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridViewLog.Name = "exGridViewLog";
            this.exGridViewLog.OptionsBehavior.ReadOnly = true;
            this.exGridViewLog.OptionsFilter.UseNewCustomFilterDialog = true;
            this.exGridViewLog.OptionsSelection.MultiSelect = true;
            this.exGridViewLog.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridViewLog.OptionsView.ShowAutoFilterRow = true;
            this.exGridViewLog.OptionsView.ShowChildrenInGroupPanel = true;
            this.exGridViewLog.OptionsView.ShowFooter = true;
            this.exGridViewLog.OptionsView.ShowGroupedColumns = true;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(487, 528);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.exGrid);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(485, 500);
            this.xtraTabPage1.Text = "PLC 주소 목록";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupTree);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(481, 499);
            this.xtraTabPage2.Text = "트리 구조 확인 ( AB 전용 )";
            // 
            // groupTree
            // 
            this.groupTree.Controls.Add(this.treeList1);
            this.groupTree.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("트리 구조 보기", ((System.Drawing.Image)(resources.GetObject("groupTree.CustomHeaderButtons"))))});
            this.groupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTree.Location = new System.Drawing.Point(0, 0);
            this.groupTree.Name = "groupTree";
            this.groupTree.Size = new System.Drawing.Size(481, 499);
            this.groupTree.TabIndex = 0;
            // 
            // IOGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "IOGrid";
            this.Size = new System.Drawing.Size(487, 528);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTree)).EndInit();
            this.groupTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTAG;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colARRAY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTYPE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colADDRESS;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSYMBOL;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnTreeExpand;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnCollapes;
        private DevExpress.XtraGrid.GridControl exGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewLog;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupTree;
    }
}
