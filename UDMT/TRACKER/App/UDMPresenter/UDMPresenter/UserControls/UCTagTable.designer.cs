﻿namespace UDMPresenter
{
    partial class UCTagTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTagTable));
            this.exGridMain = new DevExpress.XtraGrid.GridControl();
            this.cntxlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFillCellValue = new System.Windows.Forms.ToolStripMenuItem();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorStepRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
            this.cntxlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridMain
            // 
            this.exGridMain.AllowDrop = true;
            this.exGridMain.ContextMenuStrip = this.cntxlMenu;
            this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridMain.Location = new System.Drawing.Point(0, 0);
            this.exGridMain.MainView = this.exGridView;
            this.exGridMain.Name = "exGridMain";
            this.exGridMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo,
            this.exEditorCheckBox});
            this.exGridMain.Size = new System.Drawing.Size(773, 432);
            this.exGridMain.TabIndex = 0;
            this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            this.exGridMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.exGridMain_DragDrop);
            this.exGridMain.DragOver += new System.Windows.Forms.DragEventHandler(this.exGridMain_DragOver);
            // 
            // cntxlMenu
            // 
            this.cntxlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteSymbolS,
            this.toolStripMenuItem1,
            this.mnuSelectColumn,
            this.mnuFillCellValue});
            this.cntxlMenu.Name = "mnuAddSymbols";
            this.cntxlMenu.Size = new System.Drawing.Size(216, 76);
            // 
            // mnuDeleteSymbolS
            // 
            this.mnuDeleteSymbolS.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteSymbolS.Image")));
            this.mnuDeleteSymbolS.Name = "mnuDeleteSymbolS";
            this.mnuDeleteSymbolS.Size = new System.Drawing.Size(215, 22);
            this.mnuDeleteSymbolS.Text = "Delete Selected Symbol(s)";
            this.mnuDeleteSymbolS.Click += new System.EventHandler(this.mnuDeleteTagS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
            // 
            // mnuSelectColumn
            // 
            this.mnuSelectColumn.Image = ((System.Drawing.Image)(resources.GetObject("mnuSelectColumn.Image")));
            this.mnuSelectColumn.Name = "mnuSelectColumn";
            this.mnuSelectColumn.Size = new System.Drawing.Size(215, 22);
            this.mnuSelectColumn.Text = "Select Column Cells";
            this.mnuSelectColumn.Click += new System.EventHandler(this.mnuSelectColumn_Click);
            // 
            // mnuFillCellValue
            // 
            this.mnuFillCellValue.Image = ((System.Drawing.Image)(resources.GetObject("mnuFillCellValue.Image")));
            this.mnuFillCellValue.Name = "mnuFillCellValue";
            this.mnuFillCellValue.Size = new System.Drawing.Size(215, 22);
            this.mnuFillCellValue.Text = "Fill Selected Cells Value";
            this.mnuFillCellValue.Click += new System.EventHandler(this.mnuFillCellValue_Click);
            // 
            // exGridView
            // 
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colCollectUsed,
            this.colAddress,
            this.colSize,
            this.colDataType,
            this.colDescription,
            this.colChannel,
            this.colLogCount});
            this.exGridView.GridControl = this.exGridMain;
            this.exGridView.IndicatorWidth = 60;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.exGridView.OptionsDetail.EnableMasterViewMode = false;
            this.exGridView.OptionsDetail.ShowDetailTabs = false;
            this.exGridView.OptionsDetail.SmartDetailExpand = false;
            this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridView.OptionsSelection.MultiSelect = true;
            this.exGridView.OptionsView.ShowAutoFilterRow = true;
            this.exGridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.exGridView_CustomDrawRowIndicator);
            this.exGridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.exGridView_CustomRowCellEdit);
            this.exGridView.ShownEditor += new System.EventHandler(this.exGridView_ShownEditor);
            this.exGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.exGridView_CellValueChanged);
            this.exGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.exGridView_CustomUnboundColumnData);
            this.exGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exGridView_KeyDown);
            this.exGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exGridView_MouseDown);
            this.exGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exGridView_MouseMove);
            this.exGridView.DoubleClick += new System.EventHandler(this.exGridView_DoubleClick);
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
            // colCollectUsed
            // 
            this.colCollectUsed.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectUsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectUsed.Caption = "Used";
            this.colCollectUsed.ColumnEdit = this.exEditorCheckBox;
            this.colCollectUsed.FieldName = "IsCollectUsed";
            this.colCollectUsed.MinWidth = 40;
            this.colCollectUsed.Name = "colCollectUsed";
            this.colCollectUsed.Visible = true;
            this.colCollectUsed.VisibleIndex = 0;
            this.colCollectUsed.Width = 40;
            // 
            // exEditorCheckBox
            // 
            this.exEditorCheckBox.AutoHeight = false;
            this.exEditorCheckBox.Name = "exEditorCheckBox";
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 70;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 70;
            // 
            // colSize
            // 
            this.colSize.AppearanceCell.Options.UseTextOptions = true;
            this.colSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.MinWidth = 30;
            this.colSize.Name = "colSize";
            this.colSize.OptionsColumn.AllowEdit = false;
            this.colSize.OptionsColumn.ReadOnly = true;
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 6;
            this.colSize.Width = 30;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.MinWidth = 60;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 5;
            this.colDataType.Width = 60;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 150;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 150;
            // 
            // colChannel
            // 
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Channel";
            this.colChannel.FieldName = "Channel";
            this.colChannel.MinWidth = 60;
            this.colChannel.Name = "colChannel";
            this.colChannel.OptionsColumn.AllowEdit = false;
            this.colChannel.OptionsColumn.ReadOnly = true;
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 3;
            this.colChannel.Width = 60;
            // 
            // colLogCount
            // 
            this.colLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.Caption = "LogCount";
            this.colLogCount.FieldName = "LogCount";
            this.colLogCount.MinWidth = 50;
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.OptionsColumn.AllowEdit = false;
            this.colLogCount.OptionsColumn.ReadOnly = true;
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 4;
            this.colLogCount.Width = 50;
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
            // UCTagTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridMain);
            this.Name = "UCTagTable";
            this.Size = new System.Drawing.Size(773, 432);
            this.Load += new System.EventHandler(this.UCTagTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).EndInit();
            this.cntxlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private DevExpress.XtraGrid.Columns.GridColumn colKey;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colDataType;
		private DevExpress.XtraGrid.Columns.GridColumn colDescription;
		private DevExpress.XtraGrid.Columns.GridColumn colChannel;
		private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private System.Windows.Forms.ContextMenuStrip cntxlMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbolS;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuFillCellValue;
		private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
		private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
		private DevExpress.XtraGrid.GridControl exGridMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectUsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
		
    }
}