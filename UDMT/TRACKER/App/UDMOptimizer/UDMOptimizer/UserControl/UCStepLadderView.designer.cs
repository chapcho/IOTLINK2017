namespace UDMOptimizer
{
    partial class UCStepLadderView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStepLadderView));
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            DevExpress.XtraTreeList.FilterCondition filterCondition2 = new DevExpress.XtraTreeList.FilterCondition();
            DevExpress.XtraTreeList.FilterCondition filterCondition3 = new DevExpress.XtraTreeList.FilterCondition();
            DevExpress.XtraTreeList.FilterCondition filterCondition4 = new DevExpress.XtraTreeList.FilterCondition();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStep = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInstruction = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cntxLadderView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteLadder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearLadder = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.btnCollectStart = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCollectStop = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDeleteLadder = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClearLadder = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnLogView = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.txtSPDStatus = new DevExpress.XtraBars.BarStaticItem();
            this.txtTagSCount = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorLogPath = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tmrStartSPD = new System.Windows.Forms.Timer(this.components);
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager();
            this.grpSteps = new DevExpress.XtraEditors.GroupControl();
            this.tabStep = new DevExpress.XtraTab.XtraTabControl();
            this.tpAllStep = new DevExpress.XtraTab.XtraTabPage();
            this.exTreeStepAll = new DevExpress.XtraTreeList.TreeList();
            this.tpYStep = new DevExpress.XtraTab.XtraTabPage();
            this.exTreeStepY = new DevExpress.XtraTreeList.TreeList();
            this.grpLadderView = new DevExpress.XtraEditors.GroupControl();
            this.tabLadder = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.cntxLadderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLogPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSteps)).BeginInit();
            this.grpSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStep)).BeginInit();
            this.tabStep.SuspendLayout();
            this.tpAllStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeStepAll)).BeginInit();
            this.tpYStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeStepY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLadderView)).BeginInit();
            this.grpLadderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabLadder)).BeginInit();
            this.tabLadder.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.Caption = "Step";
            this.treeListColumn1.FieldName = "Step";
            this.treeListColumn1.MinWidth = 33;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 140;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.treeListColumn2.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn2.Caption = "Instruction";
            this.treeListColumn2.FieldName = "Instruction";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 205;
            // 
            // colStep
            // 
            this.colStep.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.colStep.AppearanceCell.Options.UseFont = true;
            this.colStep.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.colStep.AppearanceHeader.Options.UseFont = true;
            this.colStep.Caption = "Step";
            this.colStep.FieldName = "Step";
            this.colStep.MinWidth = 33;
            this.colStep.Name = "colStep";
            this.colStep.Visible = true;
            this.colStep.VisibleIndex = 0;
            this.colStep.Width = 140;
            // 
            // colInstruction
            // 
            this.colInstruction.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.colInstruction.AppearanceCell.Options.UseFont = true;
            this.colInstruction.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.colInstruction.AppearanceHeader.Options.UseFont = true;
            this.colInstruction.Caption = "Instruction";
            this.colInstruction.FieldName = "Instruction";
            this.colInstruction.Name = "colInstruction";
            this.colInstruction.Visible = true;
            this.colInstruction.VisibleIndex = 1;
            this.colInstruction.Width = 205;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // cntxLadderView
            // 
            this.cntxLadderView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxLadderView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteLadder,
            this.mnuClearLadder});
            this.cntxLadderView.Name = "mnuAddSymbols";
            this.cntxLadderView.Size = new System.Drawing.Size(136, 56);
            // 
            // mnuDeleteLadder
            // 
            this.mnuDeleteLadder.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteLadder.Image")));
            this.mnuDeleteLadder.Name = "mnuDeleteLadder";
            this.mnuDeleteLadder.Size = new System.Drawing.Size(135, 26);
            this.mnuDeleteLadder.Text = "Delete this";
            this.mnuDeleteLadder.Click += new System.EventHandler(this.mnuDeleteLadder_Click);
            // 
            // mnuClearLadder
            // 
            this.mnuClearLadder.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearLadder.Image")));
            this.mnuClearLadder.Name = "mnuClearLadder";
            this.mnuClearLadder.Size = new System.Drawing.Size(135, 26);
            this.mnuClearLadder.Text = "Clear";
            this.mnuClearLadder.Click += new System.EventHandler(this.mnuClearLadder_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "ContentArrangeInRows_16x16.png");
            this.imgList.Images.SetKeyName(3, "green_bullet__16x16.png");
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
            this.btnCollectStart,
            this.btnCollectStop,
            this.btnDeleteLadder,
            this.btnClearLadder,
            this.btnRefresh,
            this.btnLogView,
            this.txtSPDStatus,
            this.txtTagSCount});
            this.exBarManager.MaxItemId = 21;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorLogPath,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollectStart),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollectStop),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteLadder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClearLadder),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLogView)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // btnCollectStart
            // 
            this.btnCollectStart.Caption = "Start";
            this.btnCollectStart.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCollectStart.Glyph")));
            this.btnCollectStart.Id = 0;
            this.btnCollectStart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCollectStart.LargeGlyph")));
            this.btnCollectStart.LargeImageIndex = 14;
            this.btnCollectStart.Name = "btnCollectStart";
            this.btnCollectStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollectStart_ItemClick);
            // 
            // btnCollectStop
            // 
            this.btnCollectStop.Caption = "Stop";
            this.btnCollectStop.Enabled = false;
            this.btnCollectStop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCollectStop.Glyph")));
            this.btnCollectStop.Id = 1;
            this.btnCollectStop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCollectStop.LargeGlyph")));
            this.btnCollectStop.LargeImageIndex = 12;
            this.btnCollectStop.Name = "btnCollectStop";
            this.btnCollectStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollectStop_ItemClick);
            // 
            // btnDeleteLadder
            // 
            this.btnDeleteLadder.Caption = "Delete Ladder";
            this.btnDeleteLadder.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDeleteLadder.Glyph")));
            this.btnDeleteLadder.Id = 2;
            this.btnDeleteLadder.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDeleteLadder.LargeGlyph")));
            this.btnDeleteLadder.LargeImageIndex = 0;
            this.btnDeleteLadder.Name = "btnDeleteLadder";
            this.btnDeleteLadder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteLadder_ItemClick);
            // 
            // btnClearLadder
            // 
            this.btnClearLadder.Caption = "Clear Ladder";
            this.btnClearLadder.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClearLadder.Glyph")));
            this.btnClearLadder.Id = 5;
            this.btnClearLadder.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClearLadder.LargeGlyph")));
            this.btnClearLadder.LargeImageIndex = 17;
            this.btnClearLadder.Name = "btnClearLadder";
            this.btnClearLadder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearLadder_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 6;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.LargeImageIndex = 15;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnLogView
            // 
            this.btnLogView.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnLogView.Caption = "View Log";
            this.btnLogView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogView.Glyph")));
            this.btnLogView.Id = 13;
            this.btnLogView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogView.LargeGlyph")));
            this.btnLogView.Name = "btnLogView";
            this.btnLogView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogView_ItemClick);
            // 
            // exBarStatus
            // 
            this.exBarStatus.BarName = "Status bar";
            this.exBarStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.exBarStatus.DockCol = 0;
            this.exBarStatus.DockRow = 0;
            this.exBarStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.exBarStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.txtSPDStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtTagSCount)});
            this.exBarStatus.OptionsBar.AllowQuickCustomization = false;
            this.exBarStatus.OptionsBar.DrawDragBorder = false;
            this.exBarStatus.OptionsBar.UseWholeRow = true;
            this.exBarStatus.Text = "Status bar";
            // 
            // txtSPDStatus
            // 
            this.txtSPDStatus.Caption = "[실시간 Ladder View 수집 상태] : ";
            this.txtSPDStatus.Id = 18;
            this.txtSPDStatus.Name = "txtSPDStatus";
            this.txtSPDStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtTagSCount
            // 
            this.txtTagSCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtTagSCount.Caption = "[수집 Tag Count] : ";
            this.txtTagSCount.Id = 20;
            this.txtTagSCount.Name = "txtTagSCount";
            this.txtTagSCount.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1196, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 575);
            this.barDockControlBottom.Size = new System.Drawing.Size(1196, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1196, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 510);
            // 
            // exEditorLogPath
            // 
            this.exEditorLogPath.Name = "exEditorLogPath";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // tmrStartSPD
            // 
            this.tmrStartSPD.Interval = 1000;
            this.tmrStartSPD.Tick += new System.EventHandler(this.tmrStartSPD_Tick);
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // grpSteps
            // 
            this.grpSteps.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpSteps.AppearanceCaption.Options.UseFont = true;
            this.grpSteps.Controls.Add(this.tabStep);
            this.grpSteps.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpSteps.Location = new System.Drawing.Point(0, 65);
            this.grpSteps.Name = "grpSteps";
            this.grpSteps.Size = new System.Drawing.Size(380, 510);
            this.grpSteps.TabIndex = 15;
            this.grpSteps.Text = "Step View";
            // 
            // tabStep
            // 
            this.tabStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStep.Location = new System.Drawing.Point(2, 26);
            this.tabStep.Name = "tabStep";
            this.tabStep.SelectedTabPage = this.tpAllStep;
            this.tabStep.Size = new System.Drawing.Size(376, 482);
            this.tabStep.TabIndex = 0;
            this.tabStep.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpAllStep,
            this.tpYStep});
            // 
            // tpAllStep
            // 
            this.tpAllStep.Controls.Add(this.exTreeStepAll);
            this.tpAllStep.Name = "tpAllStep";
            this.tpAllStep.Size = new System.Drawing.Size(370, 453);
            this.tpAllStep.Text = "All Step";
            // 
            // exTreeStepAll
            // 
            this.exTreeStepAll.AllowDrop = true;
            this.exTreeStepAll.CaptionHeight = 30;
            this.exTreeStepAll.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.exTreeStepAll.Dock = System.Windows.Forms.DockStyle.Fill;
            filterCondition1.Column = this.treeListColumn1;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            filterCondition2.Column = this.treeListColumn2;
            filterCondition2.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            this.exTreeStepAll.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1,
            filterCondition2});
            this.exTreeStepAll.FooterPanelHeight = 21;
            this.exTreeStepAll.Location = new System.Drawing.Point(0, 0);
            this.exTreeStepAll.Name = "exTreeStepAll";
            this.exTreeStepAll.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeStepAll.OptionsBehavior.Editable = false;
            this.exTreeStepAll.OptionsFind.AllowFindPanel = true;
            this.exTreeStepAll.OptionsFind.AlwaysVisible = true;
            this.exTreeStepAll.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.exTreeStepAll.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeStepAll.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeStepAll.RowHeight = 30;
            this.exTreeStepAll.SelectImageList = this.imgList;
            this.exTreeStepAll.Size = new System.Drawing.Size(370, 453);
            this.exTreeStepAll.TabIndex = 10;
            this.exTreeStepAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeStep_MouseDoubleClick);
            // 
            // tpYStep
            // 
            this.tpYStep.Controls.Add(this.exTreeStepY);
            this.tpYStep.Name = "tpYStep";
            this.tpYStep.Size = new System.Drawing.Size(370, 281);
            this.tpYStep.Text = "Y";
            // 
            // exTreeStepY
            // 
            this.exTreeStepY.AllowDrop = true;
            this.exTreeStepY.CaptionHeight = 30;
            this.exTreeStepY.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colStep,
            this.colInstruction});
            this.exTreeStepY.Dock = System.Windows.Forms.DockStyle.Fill;
            filterCondition3.Column = this.colStep;
            filterCondition3.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            filterCondition4.Column = this.colInstruction;
            filterCondition4.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            this.exTreeStepY.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition3,
            filterCondition4});
            this.exTreeStepY.FooterPanelHeight = 21;
            this.exTreeStepY.Location = new System.Drawing.Point(0, 0);
            this.exTreeStepY.Name = "exTreeStepY";
            this.exTreeStepY.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeStepY.OptionsBehavior.Editable = false;
            this.exTreeStepY.OptionsFind.AllowFindPanel = true;
            this.exTreeStepY.OptionsFind.AlwaysVisible = true;
            this.exTreeStepY.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.FindClick;
            this.exTreeStepY.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeStepY.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeStepY.RowHeight = 30;
            this.exTreeStepY.SelectImageList = this.imgList;
            this.exTreeStepY.Size = new System.Drawing.Size(370, 281);
            this.exTreeStepY.TabIndex = 9;
            this.exTreeStepY.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeStep_MouseDoubleClick);
            // 
            // grpLadderView
            // 
            this.grpLadderView.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpLadderView.AppearanceCaption.Options.UseFont = true;
            this.grpLadderView.Controls.Add(this.tabLadder);
            this.grpLadderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLadderView.Location = new System.Drawing.Point(380, 65);
            this.grpLadderView.Name = "grpLadderView";
            this.grpLadderView.Size = new System.Drawing.Size(816, 510);
            this.grpLadderView.TabIndex = 16;
            this.grpLadderView.Text = "Ladder View";
            // 
            // tabLadder
            // 
            this.tabLadder.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabLadder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLadder.Location = new System.Drawing.Point(2, 26);
            this.tabLadder.Name = "tabLadder";
            this.tabLadder.SelectedTabPage = this.xtraTabPage1;
            this.tabLadder.Size = new System.Drawing.Size(812, 482);
            this.tabLadder.TabIndex = 3;
            this.tabLadder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.tabLadder.CloseButtonClick += new System.EventHandler(this.tabLadder_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabPage1.Size = new System.Drawing.Size(806, 463);
            // 
            // UCStepLadderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLadderView);
            this.Controls.Add(this.grpSteps);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UCStepLadderView";
            this.Size = new System.Drawing.Size(1196, 600);
            this.Load += new System.EventHandler(this.UCStepLadderView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.cntxLadderView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLogPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSteps)).EndInit();
            this.grpSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabStep)).EndInit();
            this.tabStep.ResumeLayout(false);
            this.tpAllStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeStepAll)).EndInit();
            this.tpYStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeStepY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLadderView)).EndInit();
            this.grpLadderView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabLadder)).EndInit();
            this.tabLadder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxLadderView;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteLadder;
        private System.Windows.Forms.ToolStripMenuItem mnuClearLadder;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarLargeButtonItem btnCollectStart;
        private DevExpress.XtraBars.BarLargeButtonItem btnCollectStop;
        private DevExpress.XtraBars.BarLargeButtonItem btnDeleteLadder;
        private DevExpress.XtraBars.BarLargeButtonItem btnClearLadder;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem btnLogView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorLogPath;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private System.Windows.Forms.Timer tmrStartSPD;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraBars.BarStaticItem txtSPDStatus;
        private DevExpress.XtraBars.BarStaticItem txtTagSCount;
        private DevExpress.XtraEditors.GroupControl grpLadderView;
        private DevExpress.XtraEditors.GroupControl grpSteps;
        private DevExpress.XtraTab.XtraTabControl tabStep;
        private DevExpress.XtraTab.XtraTabPage tpAllStep;
        private DevExpress.XtraTreeList.TreeList exTreeStepAll;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTab.XtraTabPage tpYStep;
        private DevExpress.XtraTreeList.TreeList exTreeStepY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStep;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInstruction;
        private DevExpress.XtraTab.XtraTabControl tabLadder;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    }
}
