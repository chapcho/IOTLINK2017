namespace UDMTrackerSimple
{
    partial class FrmSymbolSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolSelect));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grpSelectedSymbol = new DevExpress.XtraEditors.GroupControl();
            this.grdSelectedSymbol = new DevExpress.XtraGrid.GridControl();
            this.cntxlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.grvSelectedSymbol = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlText = new DevExpress.XtraEditors.PanelControl();
            this.lblMainText = new DevExpress.XtraEditors.LabelControl();
            this.grdTotalTagS = new DevExpress.XtraGrid.GridControl();
            this.grvTotalTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorStepRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSelectedSymbol)).BeginInit();
            this.grpSelectedSymbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedSymbol)).BeginInit();
            this.cntxlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvSelectedSymbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).BeginInit();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Horizontal = false;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpSelectedSymbol);
            this.sptMain.Panel1.Controls.Add(this.pnlText);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grdTotalTagS);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(987, 642);
            this.sptMain.SplitterPosition = 288;
            this.sptMain.TabIndex = 3;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // grpSelectedSymbol
            // 
            this.grpSelectedSymbol.Controls.Add(this.grdSelectedSymbol);
            this.grpSelectedSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedSymbol.Location = new System.Drawing.Point(0, 53);
            this.grpSelectedSymbol.Name = "grpSelectedSymbol";
            this.grpSelectedSymbol.Size = new System.Drawing.Size(987, 235);
            this.grpSelectedSymbol.TabIndex = 0;
            this.grpSelectedSymbol.Text = "Selected Symbol (From Symbol Table Drag && Drop)";
            // 
            // grdSelectedSymbol
            // 
            this.grdSelectedSymbol.AllowDrop = true;
            this.grdSelectedSymbol.ContextMenuStrip = this.cntxlMenu;
            this.grdSelectedSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSelectedSymbol.Location = new System.Drawing.Point(2, 21);
            this.grdSelectedSymbol.MainView = this.grvSelectedSymbol;
            this.grdSelectedSymbol.Name = "grdSelectedSymbol";
            this.grdSelectedSymbol.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdSelectedSymbol.Size = new System.Drawing.Size(983, 212);
            this.grdSelectedSymbol.TabIndex = 9;
            this.grdSelectedSymbol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSelectedSymbol});
            this.grdSelectedSymbol.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdSelectedSymbol_DragDrop);
            this.grdSelectedSymbol.DragOver += new System.Windows.Forms.DragEventHandler(this.grdSelectedSymbol_DragOver);
            // 
            // cntxlMenu
            // 
            this.cntxlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteSymbolS});
            this.cntxlMenu.Name = "mnuAddSymbols";
            this.cntxlMenu.Size = new System.Drawing.Size(216, 26);
            // 
            // mnuDeleteSymbolS
            // 
            this.mnuDeleteSymbolS.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteSymbolS.Image")));
            this.mnuDeleteSymbolS.Name = "mnuDeleteSymbolS";
            this.mnuDeleteSymbolS.Size = new System.Drawing.Size(215, 22);
            this.mnuDeleteSymbolS.Text = "Delete Selected Symbol(s)";
            this.mnuDeleteSymbolS.Click += new System.EventHandler(this.mnuDeleteSymbolS_Click);
            // 
            // grvSelectedSymbol
            // 
            this.grvSelectedSymbol.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvSelectedSymbol.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSelectedSymbol.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvSelectedSymbol.Appearance.Row.Options.UseFont = true;
            this.grvSelectedSymbol.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvSelectedSymbol.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvSelectedSymbol.ColumnPanelRowHeight = 25;
            this.grvSelectedSymbol.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.grvSelectedSymbol.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSelectedSymbol.GridControl = this.grdSelectedSymbol;
            this.grvSelectedSymbol.IndicatorWidth = 50;
            this.grvSelectedSymbol.Name = "grvSelectedSymbol";
            this.grvSelectedSymbol.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvSelectedSymbol.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvSelectedSymbol.OptionsDetail.AllowZoomDetail = false;
            this.grvSelectedSymbol.OptionsDetail.EnableMasterViewMode = false;
            this.grvSelectedSymbol.OptionsDetail.ShowDetailTabs = false;
            this.grvSelectedSymbol.OptionsDetail.SmartDetailExpand = false;
            this.grvSelectedSymbol.OptionsSelection.MultiSelect = true;
            this.grvSelectedSymbol.OptionsView.EnableAppearanceEvenRow = true;
            this.grvSelectedSymbol.OptionsView.ShowGroupPanel = false;
            this.grvSelectedSymbol.RowHeight = 25;
            this.grvSelectedSymbol.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Address";
            this.gridColumn1.MinWidth = 80;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Comment";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.MinWidth = 200;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 200;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // pnlText
            // 
            this.pnlText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlText.Controls.Add(this.lblMainText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.Location = new System.Drawing.Point(0, 0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(987, 53);
            this.pnlText.TabIndex = 1;
            // 
            // lblMainText
            // 
            this.lblMainText.Appearance.BackColor = System.Drawing.Color.YellowGreen;
            this.lblMainText.Appearance.BackColor2 = System.Drawing.Color.GreenYellow;
            this.lblMainText.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainText.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblMainText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMainText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMainText.AutoEllipsis = true;
            this.lblMainText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMainText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblMainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainText.Location = new System.Drawing.Point(0, 0);
            this.lblMainText.Name = "lblMainText";
            this.lblMainText.Size = new System.Drawing.Size(987, 53);
            this.lblMainText.TabIndex = 1;
            this.lblMainText.Text = "MONITOR OFF";
            // 
            // grdTotalTagS
            // 
            this.grdTotalTagS.AllowDrop = true;
            this.grdTotalTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdTotalTagS.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdTotalTagS.Location = new System.Drawing.Point(0, 0);
            this.grdTotalTagS.MainView = this.grvTotalTagS;
            this.grdTotalTagS.Name = "grdTotalTagS";
            this.grdTotalTagS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdTotalTagS.Size = new System.Drawing.Size(987, 349);
            this.grdTotalTagS.TabIndex = 2;
            this.grdTotalTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotalTagS});
            // 
            // grvTotalTagS
            // 
            this.grvTotalTagS.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTotalTagS.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.Row.Options.UseFont = true;
            this.grvTotalTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colAddress,
            this.colSize,
            this.colDataType,
            this.colDescription,
            this.colChannel,
            this.colGroupRoleType,
            this.colStepRoleType,
            this.colName,
            this.colCoil,
            this.colUsed});
            this.grvTotalTagS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTotalTagS.GridControl = this.grdTotalTagS;
            this.grvTotalTagS.GroupCount = 1;
            this.grvTotalTagS.GroupRowHeight = 30;
            this.grvTotalTagS.IndicatorWidth = 60;
            this.grvTotalTagS.Name = "grvTotalTagS";
            this.grvTotalTagS.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTotalTagS.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grvTotalTagS.OptionsDetail.EnableMasterViewMode = false;
            this.grvTotalTagS.OptionsDetail.ShowDetailTabs = false;
            this.grvTotalTagS.OptionsDetail.SmartDetailExpand = false;
            this.grvTotalTagS.OptionsSelection.MultiSelect = true;
            this.grvTotalTagS.OptionsView.ShowAutoFilterRow = true;
            this.grvTotalTagS.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvTotalTagS.OptionsView.ShowGroupedColumns = true;
            this.grvTotalTagS.RowHeight = 30;
            this.grvTotalTagS.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colChannel, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvTotalTagS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseDown);
            this.grvTotalTagS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseMove);
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.MinWidth = 100;
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.AllowEdit = false;
            this.colKey.OptionsColumn.ReadOnly = true;
            this.colKey.Width = 152;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 80;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 141;
            // 
            // colSize
            // 
            this.colSize.AppearanceCell.Options.UseTextOptions = true;
            this.colSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.MinWidth = 40;
            this.colSize.Name = "colSize";
            this.colSize.OptionsColumn.AllowEdit = false;
            this.colSize.OptionsColumn.ReadOnly = true;
            this.colSize.Width = 77;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.MinWidth = 100;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            this.colDataType.Width = 116;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 180;
            // 
            // colChannel
            // 
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Channel";
            this.colChannel.FieldName = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 4;
            this.colChannel.Width = 87;
            // 
            // colGroupRoleType
            // 
            this.colGroupRoleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupRoleType.Caption = "GroupRole";
            this.colGroupRoleType.FieldName = "_GroupRole_";
            this.colGroupRoleType.Name = "colGroupRoleType";
            this.colGroupRoleType.OptionsColumn.AllowEdit = false;
            this.colGroupRoleType.OptionsColumn.ReadOnly = true;
            this.colGroupRoleType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGroupRoleType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colGroupRoleType.Width = 96;
            // 
            // colStepRoleType
            // 
            this.colStepRoleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepRoleType.Caption = "StepRole";
            this.colStepRoleType.FieldName = "_StepRoleType_";
            this.colStepRoleType.Name = "colStepRoleType";
            this.colStepRoleType.OptionsColumn.AllowEdit = false;
            this.colStepRoleType.OptionsColumn.ReadOnly = true;
            this.colStepRoleType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStepRoleType.Width = 99;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 80;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 93;
            // 
            // colCoil
            // 
            this.colCoil.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoil.Caption = "IsCoil";
            this.colCoil.FieldName = "IsHMIMapping";
            this.colCoil.MaxWidth = 60;
            this.colCoil.MinWidth = 60;
            this.colCoil.Name = "colCoil";
            this.colCoil.Visible = true;
            this.colCoil.VisibleIndex = 5;
            this.colCoil.Width = 60;
            // 
            // colUsed
            // 
            this.colUsed.Caption = "Used";
            this.colUsed.FieldName = "UseOnlyInLogic";
            this.colUsed.MaxWidth = 50;
            this.colUsed.MinWidth = 50;
            this.colUsed.Name = "colUsed";
            this.colUsed.Visible = true;
            this.colUsed.VisibleIndex = 6;
            this.colUsed.Width = 50;
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
            // FrmSymbolSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 642);
            this.Controls.Add(this.sptMain);
            this.Name = "FrmSymbolSelect";
            this.Text = "Symbol Select";
            this.Load += new System.EventHandler(this.FrmSymbolSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSelectedSymbol)).EndInit();
            this.grpSelectedSymbol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedSymbol)).EndInit();
            this.cntxlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvSelectedSymbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).EndInit();
            this.pnlText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UDM.UI.MySplitContainerControl sptMain;
        private DevExpress.XtraEditors.GroupControl grpSelectedSymbol;
        private DevExpress.XtraGrid.GridControl grdSelectedSymbol;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSelectedSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.PanelControl pnlText;
        private DevExpress.XtraEditors.LabelControl lblMainText;
        private System.Windows.Forms.ContextMenuStrip cntxlMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbolS;
        private DevExpress.XtraGrid.GridControl grdTotalTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTotalTagS;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colChannel;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colStepRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCoil;
        private DevExpress.XtraGrid.Columns.GridColumn colUsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
    }
}