namespace UDMTrackerSimple
{
    partial class FrmCollectOptimizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCollectOptimizer));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btnOptimize = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkTo = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkFrom = new DevExpress.XtraEditors.TimeEdit();
            this.btnMonitorStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonitorStop = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpSetting = new DevExpress.XtraTab.XtraTabPage();
            this.tabSetting = new DevExpress.XtraTab.XtraTabControl();
            this.tpOption = new DevExpress.XtraTab.XtraTabPage();
            this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.exEditorEachProcess = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorSameSignal = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorFixValue = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorTargetCycle = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorFrequency = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorOptimizationFreq = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.category = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowTargetCount = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowMonitorMethod = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowOptimization = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.category1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowFixValue = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.category2 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSameSignal = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowSignalFrequency = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.tpProcessOption = new DevExpress.XtraTab.XtraTabPage();
            this.grdProcess = new DevExpress.XtraGrid.GridControl();
            this.grvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcSelection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptimization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tpMonitor = new DevExpress.XtraTab.XtraTabPage();
            this.grdMonitor = new DevExpress.XtraGrid.GridControl();
            this.grvMonitor = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGroupKey = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colRecipe = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbCount = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCurrentCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTargetCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbFrequency = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCurrentFrequency = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTargetFrequency = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMontiorStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.tpTagView = new DevExpress.XtraTab.XtraTabPage();
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colCategory = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList();
            this.tpLog = new DevExpress.XtraTab.XtraTabPage();
            this.tabLog = new DevExpress.XtraTab.XtraTabControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdStatus = new DevExpress.XtraGrid.GridControl();
            this.grvStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusRecipe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblOperTime = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblMonitorStatus = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tabMessage = new DevExpress.XtraTab.XtraTabControl();
            this.tpSystem = new DevExpress.XtraTab.XtraTabPage();
            this.ucSystemLogTable = new UDMTrackerSimple.UCSystemLogTable();
            this.timer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSetting)).BeginInit();
            this.tabSetting.SuspendLayout();
            this.tpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEachProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSameSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFixValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTargetCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOptimizationFreq)).BeginInit();
            this.tpProcessOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tpMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonitor)).BeginInit();
            this.tpTagView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.tpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMessage)).BeginInit();
            this.tabMessage.SuspendLayout();
            this.tpSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Controls.Add(this.btnMonitorStart);
            this.panelControl1.Controls.Add(this.btnMonitorStop);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(764, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl5.Controls.Add(this.btnOptimize);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.dtpkTo);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Controls.Add(this.dtpkFrom);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(311, 61);
            this.panelControl5.TabIndex = 41;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptimize.Appearance.Options.UseFont = true;
            this.btnOptimize.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOptimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOptimize.Image = ((System.Drawing.Image)(resources.GetObject("btnOptimize.Image")));
            this.btnOptimize.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnOptimize.Location = new System.Drawing.Point(224, 2);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(85, 57);
            this.btnOptimize.TabIndex = 43;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(5, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 14);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = " To    : ";
            // 
            // dtpkTo
            // 
            this.dtpkTo.EditValue = new System.DateTime(2017, 8, 21, 0, 0, 0, 0);
            this.dtpkTo.Location = new System.Drawing.Point(54, 33);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkTo.Properties.Mask.EditMask = "yyyy.MM.dd HH:mm:ss";
            this.dtpkTo.Size = new System.Drawing.Size(160, 20);
            this.dtpkTo.TabIndex = 42;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 14);
            this.labelControl1.TabIndex = 39;
            this.labelControl1.Text = " From : ";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.EditValue = new System.DateTime(2017, 8, 21, 0, 0, 0, 0);
            this.dtpkFrom.Location = new System.Drawing.Point(54, 9);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkFrom.Properties.Mask.EditMask = "yyyy.MM.dd HH:mm:ss";
            this.dtpkFrom.Size = new System.Drawing.Size(160, 20);
            this.dtpkFrom.TabIndex = 40;
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnMonitorStart.Appearance.Options.UseFont = true;
            this.btnMonitorStart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMonitorStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonitorStart.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitorStart.Image")));
            this.btnMonitorStart.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnMonitorStart.Location = new System.Drawing.Point(552, 2);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(105, 61);
            this.btnMonitorStart.TabIndex = 37;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // btnMonitorStop
            // 
            this.btnMonitorStop.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnMonitorStop.Appearance.Options.UseFont = true;
            this.btnMonitorStop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMonitorStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonitorStop.Enabled = false;
            this.btnMonitorStop.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitorStop.Image")));
            this.btnMonitorStop.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnMonitorStop.Location = new System.Drawing.Point(657, 2);
            this.btnMonitorStop.Name = "btnMonitorStop";
            this.btnMonitorStop.Size = new System.Drawing.Size(105, 61);
            this.btnMonitorStop.TabIndex = 38;
            this.btnMonitorStop.Click += new System.EventHandler(this.btnMonitorStop_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 517);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(764, 5);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.tabMain);
            this.panelControl3.Controls.Add(this.groupControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 65);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(764, 452);
            this.panelControl3.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpSetting;
            this.tabMain.Size = new System.Drawing.Size(503, 448);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSetting,
            this.tpMonitor,
            this.tpTagView,
            this.tpLog});
            // 
            // tpSetting
            // 
            this.tpSetting.Controls.Add(this.tabSetting);
            this.tpSetting.Name = "tpSetting";
            this.tpSetting.Size = new System.Drawing.Size(497, 419);
            this.tpSetting.Text = "Setting";
            // 
            // tabSetting
            // 
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedTabPage = this.tpOption;
            this.tabSetting.Size = new System.Drawing.Size(497, 419);
            this.tabSetting.TabIndex = 1;
            this.tabSetting.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpOption,
            this.tpProcessOption});
            // 
            // tpOption
            // 
            this.tpOption.Controls.Add(this.exProperty);
            this.tpOption.Name = "tpOption";
            this.tpOption.Size = new System.Drawing.Size(491, 390);
            this.tpOption.Text = "Option";
            // 
            // exProperty
            // 
            this.exProperty.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exProperty.Location = new System.Drawing.Point(0, 0);
            this.exProperty.Name = "exProperty";
            this.exProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exProperty.RecordWidth = 60;
            this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorEachProcess,
            this.exEditorSameSignal,
            this.exEditorFixValue,
            this.exEditorTargetCycle,
            this.exEditorFrequency,
            this.exEditorOptimizationFreq});
            this.exProperty.RowHeaderWidth = 140;
            this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.category,
            this.category1,
            this.category2});
            this.exProperty.Size = new System.Drawing.Size(491, 390);
            this.exProperty.TabIndex = 0;
            // 
            // exEditorEachProcess
            // 
            this.exEditorEachProcess.AutoHeight = false;
            this.exEditorEachProcess.Name = "exEditorEachProcess";
            // 
            // exEditorSameSignal
            // 
            this.exEditorSameSignal.AutoHeight = false;
            this.exEditorSameSignal.Name = "exEditorSameSignal";
            // 
            // exEditorFixValue
            // 
            this.exEditorFixValue.AutoHeight = false;
            this.exEditorFixValue.Name = "exEditorFixValue";
            // 
            // exEditorTargetCycle
            // 
            this.exEditorTargetCycle.AutoHeight = false;
            this.exEditorTargetCycle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTargetCycle.Name = "exEditorTargetCycle";
            // 
            // exEditorFrequency
            // 
            this.exEditorFrequency.AutoHeight = false;
            this.exEditorFrequency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrequency.Name = "exEditorFrequency";
            // 
            // exEditorOptimizationFreq
            // 
            this.exEditorOptimizationFreq.AutoHeight = false;
            this.exEditorOptimizationFreq.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOptimizationFreq.MaxValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.exEditorOptimizationFreq.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorOptimizationFreq.Name = "exEditorOptimizationFreq";
            // 
            // category
            // 
            this.category.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTargetCount,
            this.rowMonitorMethod,
            this.rowOptimization});
            this.category.Height = 30;
            this.category.Name = "category";
            this.category.Properties.Caption = "Optimization Option";
            // 
            // rowTargetCount
            // 
            this.rowTargetCount.Height = 40;
            this.rowTargetCount.Name = "rowTargetCount";
            this.rowTargetCount.Properties.Caption = "공정 별 목표 수집 사이클 수";
            this.rowTargetCount.Properties.FieldName = "CycleTargetCount";
            this.rowTargetCount.Properties.RowEdit = this.exEditorTargetCycle;
            // 
            // rowMonitorMethod
            // 
            this.rowMonitorMethod.Height = 40;
            this.rowMonitorMethod.Name = "rowMonitorMethod";
            this.rowMonitorMethod.Properties.Caption = "개별 공정 모니터링/분석 진행 유/무";
            this.rowMonitorMethod.Properties.FieldName = "IsEachProcessMonitor";
            this.rowMonitorMethod.Properties.RowEdit = this.exEditorEachProcess;
            // 
            // rowOptimization
            // 
            this.rowOptimization.Height = 40;
            this.rowOptimization.Name = "rowOptimization";
            this.rowOptimization.Properties.Caption = "최적화 반복 수";
            this.rowOptimization.Properties.FieldName = "OptimizationFrequency";
            this.rowOptimization.Properties.RowEdit = this.exEditorOptimizationFreq;
            // 
            // category1
            // 
            this.category1.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowFixValue});
            this.category1.Height = 30;
            this.category1.Name = "category1";
            this.category1.Properties.Caption = "ALL RANGE";
            // 
            // rowFixValue
            // 
            this.rowFixValue.Height = 40;
            this.rowFixValue.Name = "rowFixValue";
            this.rowFixValue.Properties.Caption = "고정 값(Always ON/OFF) 제거 유/무";
            this.rowFixValue.Properties.FieldName = "RemoveFixValue";
            this.rowFixValue.Properties.RowEdit = this.exEditorFixValue;
            // 
            // category2
            // 
            this.category2.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSameSignal,
            this.rowSignalFrequency});
            this.category2.Height = 30;
            this.category2.Name = "category2";
            this.category2.Properties.Caption = "CYCLE";
            // 
            // rowSameSignal
            // 
            this.rowSameSignal.Height = 40;
            this.rowSameSignal.Name = "rowSameSignal";
            this.rowSameSignal.Properties.Caption = "동시 신호 제거 유/무";
            this.rowSameSignal.Properties.CustomizationCaption = "OUTPUT → DUMMY → INPUT 순";
            this.rowSameSignal.Properties.FieldName = "RemoveSameTimeSignal";
            this.rowSameSignal.Properties.RowEdit = this.exEditorSameSignal;
            // 
            // rowSignalFrequency
            // 
            this.rowSignalFrequency.Height = 40;
            this.rowSignalFrequency.Name = "rowSignalFrequency";
            this.rowSignalFrequency.Properties.Caption = "사이클 내 제거 가능한 신호 빈도 수";
            this.rowSignalFrequency.Properties.FieldName = "RemoveSignalFrequency";
            this.rowSignalFrequency.Properties.RowEdit = this.exEditorFrequency;
            // 
            // tpProcessOption
            // 
            this.tpProcessOption.Controls.Add(this.grdProcess);
            this.tpProcessOption.Name = "tpProcessOption";
            this.tpProcessOption.Size = new System.Drawing.Size(491, 390);
            this.tpProcessOption.Text = "Process Selection";
            // 
            // grdProcess
            // 
            this.grdProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcess.Location = new System.Drawing.Point(0, 0);
            this.grdProcess.MainView = this.grvProcess;
            this.grdProcess.Name = "grdProcess";
            this.grdProcess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdProcess.Size = new System.Drawing.Size(491, 390);
            this.grdProcess.TabIndex = 3;
            this.grdProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProcess});
            // 
            // grvProcess
            // 
            this.grvProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcSelection,
            this.colOptimization});
            this.grvProcess.GridControl = this.grdProcess;
            this.grvProcess.Name = "grvProcess";
            this.grvProcess.OptionsView.ShowGroupPanel = false;
            this.grvProcess.RowHeight = 30;
            // 
            // colProcSelection
            // 
            this.colProcSelection.AppearanceCell.Options.UseTextOptions = true;
            this.colProcSelection.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcSelection.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcSelection.AppearanceHeader.Options.UseFont = true;
            this.colProcSelection.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcSelection.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcSelection.Caption = "Process";
            this.colProcSelection.FieldName = "Process";
            this.colProcSelection.Name = "colProcSelection";
            this.colProcSelection.OptionsColumn.AllowEdit = false;
            this.colProcSelection.OptionsColumn.ReadOnly = true;
            this.colProcSelection.Visible = true;
            this.colProcSelection.VisibleIndex = 0;
            this.colProcSelection.Width = 278;
            // 
            // colOptimization
            // 
            this.colOptimization.AppearanceCell.Options.UseTextOptions = true;
            this.colOptimization.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOptimization.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOptimization.AppearanceHeader.Options.UseFont = true;
            this.colOptimization.AppearanceHeader.Options.UseTextOptions = true;
            this.colOptimization.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOptimization.Caption = "Optimizing";
            this.colOptimization.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colOptimization.FieldName = "IsOptimizing";
            this.colOptimization.Name = "colOptimization";
            this.colOptimization.Visible = true;
            this.colOptimization.VisibleIndex = 1;
            this.colOptimization.Width = 115;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // tpMonitor
            // 
            this.tpMonitor.Controls.Add(this.grdMonitor);
            this.tpMonitor.Name = "tpMonitor";
            this.tpMonitor.Size = new System.Drawing.Size(497, 419);
            this.tpMonitor.Text = "Monitoring";
            // 
            // grdMonitor
            // 
            this.grdMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMonitor.Location = new System.Drawing.Point(0, 0);
            this.grdMonitor.MainView = this.grvMonitor;
            this.grdMonitor.Name = "grdMonitor";
            this.grdMonitor.Size = new System.Drawing.Size(497, 419);
            this.grdMonitor.TabIndex = 1;
            this.grdMonitor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMonitor});
            // 
            // grvMonitor
            // 
            this.grvMonitor.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbInfo,
            this.gbCount,
            this.gbFrequency});
            this.grvMonitor.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colGroupKey,
            this.colRecipe,
            this.colCurrentCount,
            this.colTargetCount,
            this.colMontiorStatus,
            this.colCurrentFrequency,
            this.colTargetFrequency});
            this.grvMonitor.GridControl = this.grdMonitor;
            this.grvMonitor.Name = "grvMonitor";
            this.grvMonitor.OptionsBehavior.Editable = false;
            this.grvMonitor.OptionsBehavior.ReadOnly = true;
            this.grvMonitor.OptionsDetail.AllowZoomDetail = false;
            this.grvMonitor.OptionsDetail.EnableMasterViewMode = false;
            this.grvMonitor.OptionsDetail.ShowDetailTabs = false;
            this.grvMonitor.OptionsDetail.SmartDetailExpand = false;
            this.grvMonitor.OptionsView.ShowGroupPanel = false;
            this.grvMonitor.RowHeight = 30;
            this.grvMonitor.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvMonitor_RowCellStyle);
            // 
            // gbInfo
            // 
            this.gbInfo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gbInfo.AppearanceHeader.Options.UseFont = true;
            this.gbInfo.AppearanceHeader.Options.UseTextOptions = true;
            this.gbInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbInfo.Caption = "Information";
            this.gbInfo.Columns.Add(this.colGroupKey);
            this.gbInfo.Columns.Add(this.colRecipe);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.VisibleIndex = 0;
            this.gbInfo.Width = 198;
            // 
            // colGroupKey
            // 
            this.colGroupKey.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceCell.Options.UseFont = true;
            this.colGroupKey.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colGroupKey.AppearanceHeader.Options.UseFont = true;
            this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.Caption = "Process";
            this.colGroupKey.FieldName = "Process";
            this.colGroupKey.Name = "colGroupKey";
            this.colGroupKey.OptionsColumn.AllowEdit = false;
            this.colGroupKey.OptionsColumn.AllowMove = false;
            this.colGroupKey.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGroupKey.OptionsColumn.ReadOnly = true;
            this.colGroupKey.Visible = true;
            this.colGroupKey.Width = 72;
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRecipe.AppearanceCell.Options.UseFont = true;
            this.colRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colRecipe.AppearanceHeader.Options.UseFont = true;
            this.colRecipe.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.Caption = "Recipe";
            this.colRecipe.FieldName = "Recipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.OptionsColumn.AllowEdit = false;
            this.colRecipe.OptionsColumn.AllowMove = false;
            this.colRecipe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRecipe.OptionsColumn.ReadOnly = true;
            this.colRecipe.Visible = true;
            this.colRecipe.Width = 126;
            // 
            // gbCount
            // 
            this.gbCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gbCount.AppearanceHeader.Options.UseFont = true;
            this.gbCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gbCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbCount.Caption = "Cycle";
            this.gbCount.Columns.Add(this.colCurrentCount);
            this.gbCount.Columns.Add(this.colTargetCount);
            this.gbCount.Name = "gbCount";
            this.gbCount.VisibleIndex = 1;
            this.gbCount.Width = 140;
            // 
            // colCurrentCount
            // 
            this.colCurrentCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCurrentCount.AppearanceCell.Options.UseFont = true;
            this.colCurrentCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colCurrentCount.AppearanceHeader.Options.UseFont = true;
            this.colCurrentCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentCount.Caption = "# Current";
            this.colCurrentCount.FieldName = "CurrentCount";
            this.colCurrentCount.Name = "colCurrentCount";
            this.colCurrentCount.OptionsColumn.AllowEdit = false;
            this.colCurrentCount.OptionsColumn.AllowMove = false;
            this.colCurrentCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrentCount.OptionsColumn.FixedWidth = true;
            this.colCurrentCount.OptionsColumn.ReadOnly = true;
            this.colCurrentCount.Visible = true;
            this.colCurrentCount.Width = 70;
            // 
            // colTargetCount
            // 
            this.colTargetCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTargetCount.AppearanceCell.Options.UseFont = true;
            this.colTargetCount.AppearanceCell.Options.UseTextOptions = true;
            this.colTargetCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colTargetCount.AppearanceHeader.Options.UseFont = true;
            this.colTargetCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colTargetCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetCount.Caption = "# Target";
            this.colTargetCount.FieldName = "TargetCount";
            this.colTargetCount.Name = "colTargetCount";
            this.colTargetCount.OptionsColumn.AllowEdit = false;
            this.colTargetCount.OptionsColumn.AllowMove = false;
            this.colTargetCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTargetCount.OptionsColumn.FixedWidth = true;
            this.colTargetCount.OptionsColumn.ReadOnly = true;
            this.colTargetCount.Visible = true;
            this.colTargetCount.Width = 70;
            // 
            // gbFrequency
            // 
            this.gbFrequency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gbFrequency.AppearanceHeader.Options.UseFont = true;
            this.gbFrequency.AppearanceHeader.Options.UseTextOptions = true;
            this.gbFrequency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbFrequency.Caption = "Frequency";
            this.gbFrequency.Columns.Add(this.colCurrentFrequency);
            this.gbFrequency.Columns.Add(this.colTargetFrequency);
            this.gbFrequency.Name = "gbFrequency";
            this.gbFrequency.VisibleIndex = 2;
            this.gbFrequency.Width = 140;
            // 
            // colCurrentFrequency
            // 
            this.colCurrentFrequency.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCurrentFrequency.AppearanceCell.Options.UseFont = true;
            this.colCurrentFrequency.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentFrequency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentFrequency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCurrentFrequency.AppearanceHeader.Options.UseFont = true;
            this.colCurrentFrequency.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentFrequency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentFrequency.Caption = "# Current";
            this.colCurrentFrequency.FieldName = "CurrentFrequency";
            this.colCurrentFrequency.Name = "colCurrentFrequency";
            this.colCurrentFrequency.OptionsColumn.AllowEdit = false;
            this.colCurrentFrequency.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrentFrequency.OptionsColumn.FixedWidth = true;
            this.colCurrentFrequency.OptionsColumn.ReadOnly = true;
            this.colCurrentFrequency.Visible = true;
            this.colCurrentFrequency.Width = 70;
            // 
            // colTargetFrequency
            // 
            this.colTargetFrequency.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTargetFrequency.AppearanceCell.Options.UseFont = true;
            this.colTargetFrequency.AppearanceCell.Options.UseTextOptions = true;
            this.colTargetFrequency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetFrequency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTargetFrequency.AppearanceHeader.Options.UseFont = true;
            this.colTargetFrequency.AppearanceHeader.Options.UseTextOptions = true;
            this.colTargetFrequency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetFrequency.Caption = "# Target";
            this.colTargetFrequency.FieldName = "TargetFrequency";
            this.colTargetFrequency.Name = "colTargetFrequency";
            this.colTargetFrequency.OptionsColumn.AllowEdit = false;
            this.colTargetFrequency.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTargetFrequency.OptionsColumn.FixedWidth = true;
            this.colTargetFrequency.OptionsColumn.ReadOnly = true;
            this.colTargetFrequency.Visible = true;
            this.colTargetFrequency.Width = 70;
            // 
            // colMontiorStatus
            // 
            this.colMontiorStatus.Caption = "bandedGridColumn1";
            this.colMontiorStatus.FieldName = "MonitorStatus";
            this.colMontiorStatus.Name = "colMontiorStatus";
            // 
            // tpTagView
            // 
            this.tpTagView.Controls.Add(this.exTreeList);
            this.tpTagView.Name = "tpTagView";
            this.tpTagView.Size = new System.Drawing.Size(497, 419);
            this.tpTagView.Text = "Tag Tree View";
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colCategory,
            this.colDesc});
            this.exTreeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.ReadOnly = true;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(497, 419);
            this.exTreeList.TabIndex = 0;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.FieldName = "Category";
            this.colCategory.MinWidth = 34;
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            this.colCategory.Width = 180;
            // 
            // colDesc
            // 
            this.colDesc.Caption = "Desc";
            this.colDesc.FieldName = "Desc";
            this.colDesc.Name = "colDesc";
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 1;
            this.colDesc.Width = 219;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(3, "yellow_bullet__16x16.png");
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.tabLog);
            this.tpLog.Name = "tpLog";
            this.tpLog.Size = new System.Drawing.Size(497, 419);
            this.tpLog.Text = "Log";
            // 
            // tabLog
            // 
            this.tabLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLog.Location = new System.Drawing.Point(0, 0);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(497, 419);
            this.tabLog.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdStatus);
            this.groupControl2.Controls.Add(this.panelControl4);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(505, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(257, 448);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Monitor Status";
            // 
            // grdStatus
            // 
            this.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStatus.Location = new System.Drawing.Point(2, 165);
            this.grdStatus.MainView = this.grvStatus;
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.Size = new System.Drawing.Size(253, 281);
            this.grdStatus.TabIndex = 2;
            this.grdStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStatus});
            // 
            // grvStatus
            // 
            this.grvStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcess,
            this.colStatus,
            this.colStatusRecipe});
            this.grvStatus.GridControl = this.grdStatus;
            this.grvStatus.Name = "grvStatus";
            this.grvStatus.OptionsBehavior.Editable = false;
            this.grvStatus.OptionsBehavior.ReadOnly = true;
            this.grvStatus.OptionsView.ShowGroupPanel = false;
            this.grvStatus.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvStatus_RowCellStyle);
            // 
            // colProcess
            // 
            this.colProcess.AppearanceCell.Options.UseTextOptions = true;
            this.colProcess.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcess.AppearanceHeader.Options.UseFont = true;
            this.colProcess.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.Caption = "Process";
            this.colProcess.FieldName = "Process";
            this.colProcess.Name = "colProcess";
            this.colProcess.Visible = true;
            this.colProcess.VisibleIndex = 0;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "MonitorStatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            // 
            // colStatusRecipe
            // 
            this.colStatusRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusRecipe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusRecipe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colStatusRecipe.AppearanceHeader.Options.UseFont = true;
            this.colStatusRecipe.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusRecipe.Caption = "Recipe";
            this.colStatusRecipe.FieldName = "Recipe";
            this.colStatusRecipe.Name = "colStatusRecipe";
            this.colStatusRecipe.Visible = true;
            this.colStatusRecipe.VisibleIndex = 1;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lblOperTime);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 93);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl4.Size = new System.Drawing.Size(253, 72);
            this.panelControl4.TabIndex = 1;
            // 
            // lblOperTime
            // 
            this.lblOperTime.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.lblOperTime.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.lblOperTime.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblOperTime.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblOperTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOperTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblOperTime.AutoEllipsis = true;
            this.lblOperTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOperTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblOperTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperTime.Location = new System.Drawing.Point(7, 7);
            this.lblOperTime.Name = "lblOperTime";
            this.lblOperTime.Size = new System.Drawing.Size(239, 58);
            this.lblOperTime.TabIndex = 2;
            this.lblOperTime.Text = "00:00:00";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblMonitorStatus);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(253, 72);
            this.panelControl2.TabIndex = 0;
            // 
            // lblMonitorStatus
            // 
            this.lblMonitorStatus.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.lblMonitorStatus.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.lblMonitorStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorStatus.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblMonitorStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMonitorStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMonitorStatus.AutoEllipsis = true;
            this.lblMonitorStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMonitorStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblMonitorStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonitorStatus.Location = new System.Drawing.Point(7, 7);
            this.lblMonitorStatus.Name = "lblMonitorStatus";
            this.lblMonitorStatus.Size = new System.Drawing.Size(239, 58);
            this.lblMonitorStatus.TabIndex = 1;
            this.lblMonitorStatus.Text = "MONITOR OFF";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tabMessage);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 522);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(764, 211);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Message";
            // 
            // tabMessage
            // 
            this.tabMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMessage.Location = new System.Drawing.Point(2, 21);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.SelectedTabPage = this.tpSystem;
            this.tabMessage.Size = new System.Drawing.Size(760, 188);
            this.tabMessage.TabIndex = 1;
            this.tabMessage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSystem});
            // 
            // tpSystem
            // 
            this.tpSystem.Controls.Add(this.ucSystemLogTable);
            this.tpSystem.Name = "tpSystem";
            this.tpSystem.Size = new System.Drawing.Size(754, 159);
            this.tpSystem.Text = "System";
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucSystemLogTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.IsAutoFilterRowView = false;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucSystemLogTable.Size = new System.Drawing.Size(754, 159);
            this.ucSystemLogTable.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmCollectOptimizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 733);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(780, 690);
            this.Name = "FrmCollectOptimizer";
            this.Text = "Collection Optimizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCollectOptimizer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCollectOptimizer_FormClosed);
            this.Load += new System.EventHandler(this.FrmCollectOptimizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabSetting)).EndInit();
            this.tabSetting.ResumeLayout(false);
            this.tpOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEachProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSameSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFixValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTargetCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOptimizationFreq)).EndInit();
            this.tpProcessOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tpMonitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonitor)).EndInit();
            this.tpTagView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.tpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMessage)).EndInit();
            this.tabMessage.ResumeLayout(false);
            this.tpSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpSetting;
        private DevExpress.XtraTab.XtraTabPage tpMonitor;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCSystemLogTable ucSystemLogTable;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblMonitorStatus;
        private DevExpress.XtraGrid.GridControl grdStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.LabelControl lblOperTime;
        private DevExpress.XtraEditors.SimpleButton btnMonitorStop;
        private DevExpress.XtraEditors.SimpleButton btnMonitorStart;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowMonitorMethod;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorEachProcess;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTargetCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorSameSignal;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorFixValue;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowSameSignal;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowFixValue;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowSignalFrequency;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorTargetCycle;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorFrequency;
        private DevExpress.XtraGrid.GridControl grdMonitor;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvMonitor;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGroupKey;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecipe;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCurrentCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTargetCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMontiorStatus;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraTab.XtraTabControl tabSetting;
        private DevExpress.XtraTab.XtraTabPage tpOption;
        private DevExpress.XtraTab.XtraTabPage tpProcessOption;
        private DevExpress.XtraGrid.GridControl grdProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colProcSelection;
        private DevExpress.XtraGrid.Columns.GridColumn colOptimization;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusRecipe;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton btnOptimize;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TimeEdit dtpkTo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit dtpkFrom;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category2;
        private DevExpress.XtraTab.XtraTabControl tabMessage;
        private DevExpress.XtraTab.XtraTabPage tpSystem;
        private DevExpress.XtraTab.XtraTabPage tpTagView;
        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCategory;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDesc;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowOptimization;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorOptimizationFreq;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbCount;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbFrequency;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTargetFrequency;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCurrentFrequency;
        private DevExpress.XtraTab.XtraTabPage tpLog;
        private DevExpress.XtraTab.XtraTabControl tabLog;
    }
}