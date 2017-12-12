namespace UDMTrackerSimple
{
    partial class FrmLadderLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLadderLogViewer));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grdLogList = new DevExpress.XtraGrid.GridControl();
            this.grvLogList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollectStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainStepCoil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLadderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainStepKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepKeyS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorStepRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tabLadder = new DevExpress.XtraTab.XtraTabControl();
            this.trbLogTime = new DevExpress.XtraEditors.TrackBarControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager();
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLadder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            this.SuspendLayout();
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.sptMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1184, 662);
            this.pnlMain.TabIndex = 4;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grdLogList);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.tabLadder);
            this.sptMain.Panel2.Controls.Add(this.trbLogTime);
            this.sptMain.Panel2.Controls.Add(this.barDockControlLeft);
            this.sptMain.Panel2.Controls.Add(this.barDockControlRight);
            this.sptMain.Panel2.Controls.Add(this.barDockControlBottom);
            this.sptMain.Panel2.Controls.Add(this.barDockControlTop);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1184, 662);
            this.sptMain.SplitterPosition = 550;
            this.sptMain.TabIndex = 3;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // grdLogList
            // 
            this.grdLogList.AllowDrop = true;
            this.grdLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogList.Font = new System.Drawing.Font("Tahoma", 10F);
            gridLevelNode1.RelationName = "Level1";
            this.grdLogList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdLogList.Location = new System.Drawing.Point(0, 0);
            this.grdLogList.MainView = this.grvLogList;
            this.grdLogList.Name = "grdLogList";
            this.grdLogList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdLogList.Size = new System.Drawing.Size(550, 662);
            this.grdLogList.TabIndex = 2;
            this.grdLogList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLogList});
            // 
            // grvLogList
            // 
            this.grvLogList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLogList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.grvLogList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLogList.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvLogList.Appearance.Row.Options.UseFont = true;
            this.grvLogList.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvLogList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollectStartDate,
            this.colCollectStartTime,
            this.colTimeSpan,
            this.colCollectEndTime,
            this.colMainStepCoil,
            this.colLogCount,
            this.colLadderID,
            this.colMainStepKey,
            this.colStepKeyS,
            this.colPlcId});
            this.grvLogList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvLogList.GridControl = this.grdLogList;
            this.grvLogList.IndicatorWidth = 60;
            this.grvLogList.Name = "grvLogList";
            this.grvLogList.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grvLogList.OptionsBehavior.ReadOnly = true;
            this.grvLogList.OptionsDetail.EnableMasterViewMode = false;
            this.grvLogList.OptionsDetail.ShowDetailTabs = false;
            this.grvLogList.OptionsDetail.SmartDetailExpand = false;
            this.grvLogList.OptionsSelection.MultiSelect = true;
            this.grvLogList.OptionsView.AllowCellMerge = true;
            this.grvLogList.OptionsView.ShowAutoFilterRow = true;
            this.grvLogList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvLogList_CustomDrawRowIndicator);
            this.grvLogList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvLogList_RowStyle);
            this.grvLogList.DoubleClick += new System.EventHandler(this.grvLogList_DoubleClick);
            // 
            // colCollectStartDate
            // 
            this.colCollectStartDate.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colCollectStartDate.AppearanceCell.Options.UseFont = true;
            this.colCollectStartDate.AppearanceCell.Options.UseForeColor = true;
            this.colCollectStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.colCollectStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectStartDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colCollectStartDate.AppearanceHeader.Options.UseFont = true;
            this.colCollectStartDate.AppearanceHeader.Options.UseForeColor = true;
            this.colCollectStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectStartDate.Caption = "Date";
            this.colCollectStartDate.FieldName = "dtCollectStartDate";
            this.colCollectStartDate.Name = "colCollectStartDate";
            this.colCollectStartDate.Visible = true;
            this.colCollectStartDate.VisibleIndex = 0;
            this.colCollectStartDate.Width = 74;
            // 
            // colCollectStartTime
            // 
            this.colCollectStartTime.AppearanceCell.Options.UseForeColor = true;
            this.colCollectStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.colCollectStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectStartTime.AppearanceHeader.Options.UseForeColor = true;
            this.colCollectStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectStartTime.Caption = "Start Time";
            this.colCollectStartTime.FieldName = "dtCollectStartTime";
            this.colCollectStartTime.Name = "colCollectStartTime";
            this.colCollectStartTime.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colCollectStartTime.Visible = true;
            this.colCollectStartTime.VisibleIndex = 1;
            this.colCollectStartTime.Width = 95;
            // 
            // colTimeSpan
            // 
            this.colTimeSpan.AppearanceCell.Options.UseForeColor = true;
            this.colTimeSpan.AppearanceCell.Options.UseTextOptions = true;
            this.colTimeSpan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimeSpan.AppearanceHeader.Options.UseForeColor = true;
            this.colTimeSpan.AppearanceHeader.Options.UseTextOptions = true;
            this.colTimeSpan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimeSpan.Caption = "Total Col Time";
            this.colTimeSpan.FieldName = "dtCollectTime";
            this.colTimeSpan.Name = "colTimeSpan";
            this.colTimeSpan.Visible = true;
            this.colTimeSpan.VisibleIndex = 2;
            this.colTimeSpan.Width = 95;
            // 
            // colCollectEndTime
            // 
            this.colCollectEndTime.AppearanceCell.Options.UseForeColor = true;
            this.colCollectEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.colCollectEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectEndTime.AppearanceHeader.Options.UseForeColor = true;
            this.colCollectEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectEndTime.Caption = "수집종료시간";
            this.colCollectEndTime.FieldName = "dtCollectEndTime";
            this.colCollectEndTime.MinWidth = 70;
            this.colCollectEndTime.Name = "colCollectEndTime";
            this.colCollectEndTime.OptionsColumn.AllowEdit = false;
            this.colCollectEndTime.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colCollectEndTime.OptionsColumn.ReadOnly = true;
            this.colCollectEndTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCollectEndTime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCollectEndTime.Width = 125;
            // 
            // colMainStepCoil
            // 
            this.colMainStepCoil.AppearanceCell.Options.UseForeColor = true;
            this.colMainStepCoil.AppearanceHeader.Options.UseForeColor = true;
            this.colMainStepCoil.AppearanceHeader.Options.UseTextOptions = true;
            this.colMainStepCoil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMainStepCoil.Caption = "Collection Main Tag";
            this.colMainStepCoil.FieldName = "sMainStepCoil";
            this.colMainStepCoil.MinWidth = 40;
            this.colMainStepCoil.Name = "colMainStepCoil";
            this.colMainStepCoil.OptionsColumn.AllowEdit = false;
            this.colMainStepCoil.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colMainStepCoil.OptionsColumn.ReadOnly = true;
            this.colMainStepCoil.Visible = true;
            this.colMainStepCoil.VisibleIndex = 3;
            this.colMainStepCoil.Width = 144;
            // 
            // colLogCount
            // 
            this.colLogCount.AppearanceCell.Options.UseForeColor = true;
            this.colLogCount.AppearanceCell.Options.UseTextOptions = true;
            this.colLogCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.AppearanceHeader.Options.UseForeColor = true;
            this.colLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.Caption = "Log Count";
            this.colLogCount.FieldName = "LogCount";
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 4;
            this.colLogCount.Width = 80;
            // 
            // colLadderID
            // 
            this.colLadderID.AppearanceCell.Options.UseForeColor = true;
            this.colLadderID.AppearanceCell.Options.UseTextOptions = true;
            this.colLadderID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLadderID.AppearanceHeader.Options.UseForeColor = true;
            this.colLadderID.AppearanceHeader.Options.UseTextOptions = true;
            this.colLadderID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLadderID.Caption = "LadderID";
            this.colLadderID.FieldName = "iLadderID";
            this.colLadderID.MinWidth = 100;
            this.colLadderID.Name = "colLadderID";
            this.colLadderID.OptionsColumn.AllowEdit = false;
            this.colLadderID.OptionsColumn.ReadOnly = true;
            this.colLadderID.Width = 152;
            // 
            // colMainStepKey
            // 
            this.colMainStepKey.AppearanceCell.Options.UseForeColor = true;
            this.colMainStepKey.AppearanceCell.Options.UseTextOptions = true;
            this.colMainStepKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMainStepKey.AppearanceHeader.Options.UseForeColor = true;
            this.colMainStepKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colMainStepKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMainStepKey.Caption = "MainStepKey";
            this.colMainStepKey.FieldName = "sMainStepKey";
            this.colMainStepKey.MinWidth = 60;
            this.colMainStepKey.Name = "colMainStepKey";
            this.colMainStepKey.OptionsColumn.AllowEdit = false;
            this.colMainStepKey.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colMainStepKey.OptionsColumn.ReadOnly = true;
            this.colMainStepKey.Width = 111;
            // 
            // colStepKeyS
            // 
            this.colStepKeyS.AppearanceCell.Options.UseForeColor = true;
            this.colStepKeyS.AppearanceCell.Options.UseTextOptions = true;
            this.colStepKeyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepKeyS.AppearanceHeader.Options.UseForeColor = true;
            this.colStepKeyS.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepKeyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepKeyS.Caption = "StepKeyS";
            this.colStepKeyS.FieldName = "sStepKeyS";
            this.colStepKeyS.MinWidth = 70;
            this.colStepKeyS.Name = "colStepKeyS";
            this.colStepKeyS.OptionsColumn.AllowEdit = false;
            this.colStepKeyS.OptionsColumn.ReadOnly = true;
            this.colStepKeyS.Width = 70;
            // 
            // colPlcId
            // 
            this.colPlcId.AppearanceCell.Options.UseForeColor = true;
            this.colPlcId.AppearanceCell.Options.UseTextOptions = true;
            this.colPlcId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPlcId.AppearanceHeader.Options.UseForeColor = true;
            this.colPlcId.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlcId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlcId.Caption = "PlcId";
            this.colPlcId.FieldName = "sPlcId";
            this.colPlcId.MinWidth = 100;
            this.colPlcId.Name = "colPlcId";
            this.colPlcId.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPlcId.Width = 100;
            // 
            // exEditorGroupCombo
            // 
            this.exEditorGroupCombo.AutoHeight = false;
            this.exEditorGroupCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupCombo.Name = "exEditorGroupCombo";
            this.exEditorGroupCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // exEditorGroupRoleCombo
            // 
            this.exEditorGroupRoleCombo.AutoHeight = false;
            this.exEditorGroupRoleCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupRoleCombo.Items.AddRange(new object[] {
            "",
            "Key",
            "SubKey",
            "General",
            "Trend",
            "Alarm"});
            this.exEditorGroupRoleCombo.Name = "exEditorGroupRoleCombo";
            this.exEditorGroupRoleCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // exEditorStepRoleCombo
            // 
            this.exEditorStepRoleCombo.AutoHeight = false;
            this.exEditorStepRoleCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorStepRoleCombo.Items.AddRange(new object[] {
            "",
            "Coil",
            "Contact"});
            this.exEditorStepRoleCombo.Name = "exEditorStepRoleCombo";
            // 
            // tabLadder
            // 
            this.tabLadder.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabLadder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLadder.Location = new System.Drawing.Point(0, 122);
            this.tabLadder.Name = "tabLadder";
            this.tabLadder.Size = new System.Drawing.Size(624, 515);
            this.tabLadder.TabIndex = 5;
            // 
            // trbLogTime
            // 
            this.trbLogTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbLogTime.EditValue = null;
            this.trbLogTime.Location = new System.Drawing.Point(0, 65);
            this.trbLogTime.Name = "trbLogTime";
            this.trbLogTime.Properties.AutoSize = false;
            this.trbLogTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.trbLogTime.Properties.LabelAppearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.trbLogTime.Properties.LabelAppearance.Options.UseFont = true;
            this.trbLogTime.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trbLogTime.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "1";
            this.trbLogTime.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1});
            this.trbLogTime.Properties.Maximum = 0;
            this.trbLogTime.Properties.ShowLabels = true;
            this.trbLogTime.Properties.ShowValueToolTip = true;
            this.trbLogTime.Properties.ValueChanged += new System.EventHandler(this.trbLogTime_Properties_ValueChanged);
            this.trbLogTime.Size = new System.Drawing.Size(624, 57);
            this.trbLogTime.TabIndex = 2;
            this.trbLogTime.BeforeShowValueToolTip += new DevExpress.XtraEditors.TrackBarValueToolTipEventHandler(this.trbLogTime_BeforeShowValueToolTip);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 572);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(624, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 572);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 637);
            this.barDockControlBottom.Size = new System.Drawing.Size(624, 25);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(624, 65);
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
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
            this.exBarManager.Form = this.sptMain.Panel2;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
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
            this.exBarMenu.FloatLocation = new System.Drawing.Point(497, 136);
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.Id = 2;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 150;
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
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 150;
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
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 5;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
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
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            // 
            // FrmLadderLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLadderLogViewer";
            this.Text = "Ladder Log View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLadderLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FrmLadderLogViewer_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLadder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.Panel pnlMain;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private UDM.UI.MySplitContainerControl sptMain;
        private DevExpress.XtraGrid.GridControl grdLogList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLogList;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeSpan;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMainStepCoil;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private DevExpress.XtraGrid.Columns.GridColumn colLadderID;
        private DevExpress.XtraGrid.Columns.GridColumn colMainStepKey;
        private DevExpress.XtraGrid.Columns.GridColumn colStepKeyS;
        private DevExpress.XtraGrid.Columns.GridColumn colPlcId;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
        private DevExpress.XtraTab.XtraTabControl tabLadder;
        private DevExpress.XtraEditors.TrackBarControl trbLogTime;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
    }
}