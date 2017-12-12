namespace UDMTrackerSimple
{
    partial class UCProcessProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCProcessProperty));
            this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.exEditorValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.catGroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.catCycle = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowCycleStartConditionS = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCycleEndConditionS = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.catMisc = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowMaxCycleTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.catKeySymbol = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowKeySymbol = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.grdStartConditionS = new DevExpress.XtraGrid.GridControl();
            this.cntxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grvStartConditionS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCycleStartOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCycleStartOperator = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCycleStartSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleStartValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCycleStartValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grdEndConditionS = new DevExpress.XtraGrid.GridControl();
            this.grvEndConditionS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCycleEndOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCyceEndOperator = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCycleEndSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleEndValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCycleEndValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grdKeySymbolS = new DevExpress.XtraGrid.GridControl();
            this.grvKeySymbolS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStartConditionS)).BeginInit();
            this.cntxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvStartConditionS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEndConditionS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEndConditionS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCyceEndOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleEndValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeySymbolS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKeySymbolS)).BeginInit();
            this.SuspendLayout();
            // 
            // exProperty
            // 
            this.exProperty.AllowDrop = true;
            this.exProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exProperty.Location = new System.Drawing.Point(0, 0);
            this.exProperty.Name = "exProperty";
            this.exProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exProperty.OptionsView.ShowFocusedFrame = false;
            this.exProperty.RecordWidth = 118;
            this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorValue,
            this.exEditorSize});
            this.exProperty.RowHeaderWidth = 82;
            this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catGroup,
            this.catCycle,
            this.catMisc,
            this.catKeySymbol});
            this.exProperty.Size = new System.Drawing.Size(387, 493);
            this.exProperty.TabIndex = 1;
            this.exProperty.CustomDrawRowValueCell += new DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventHandler(this.exProperty_CustomDrawRowValueCell);
            this.exProperty.ShownEditor += new System.EventHandler(this.exProperty_ShownEditor);
            // 
            // exEditorValue
            // 
            this.exEditorValue.AutoHeight = false;
            this.exEditorValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorValue.IsFloatValue = false;
            this.exEditorValue.Mask.EditMask = "N00";
            this.exEditorValue.Name = "exEditorValue";
            // 
            // exEditorSize
            // 
            this.exEditorSize.AutoHeight = false;
            this.exEditorSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorSize.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorSize.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorSize.Name = "exEditorSize";
            // 
            // catGroup
            // 
            this.catGroup.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowName});
            this.catGroup.Height = 25;
            this.catGroup.Name = "catGroup";
            this.catGroup.Properties.Caption = "공정";
            // 
            // rowName
            // 
            this.rowName.Height = 25;
            this.rowName.Name = "rowName";
            this.rowName.Properties.Caption = "이름";
            this.rowName.Properties.FieldName = "Name";
            this.rowName.Properties.ReadOnly = true;
            // 
            // catCycle
            // 
            this.catCycle.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCycleStartConditionS,
            this.rowCycleEndConditionS});
            this.catCycle.Height = 25;
            this.catCycle.Name = "catCycle";
            this.catCycle.Properties.Caption = "사이클 조건";
            // 
            // rowCycleStartConditionS
            // 
            this.rowCycleStartConditionS.Height = 60;
            this.rowCycleStartConditionS.Name = "rowCycleStartConditionS";
            this.rowCycleStartConditionS.Properties.Caption = "시작 조건";
            this.rowCycleStartConditionS.Properties.ReadOnly = true;
            // 
            // rowCycleEndConditionS
            // 
            this.rowCycleEndConditionS.Height = 60;
            this.rowCycleEndConditionS.Name = "rowCycleEndConditionS";
            this.rowCycleEndConditionS.Properties.Caption = "끝 조건";
            this.rowCycleEndConditionS.Properties.ReadOnly = true;
            // 
            // catMisc
            // 
            this.catMisc.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowMaxCycleTime});
            this.catMisc.Height = 25;
            this.catMisc.Name = "catMisc";
            this.catMisc.Properties.Caption = "사이클 타임";
            // 
            // rowMaxCycleTime
            // 
            this.rowMaxCycleTime.Height = 30;
            this.rowMaxCycleTime.Name = "rowMaxCycleTime";
            this.rowMaxCycleTime.Properties.Caption = "목표 사이클 타임(ms)";
            this.rowMaxCycleTime.Properties.FieldName = "TargetTactTime";
            this.rowMaxCycleTime.Properties.RowEdit = this.exEditorValue;
            // 
            // catKeySymbol
            // 
            this.catKeySymbol.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowKeySymbol});
            this.catKeySymbol.Height = 25;
            this.catKeySymbol.Name = "catKeySymbol";
            this.catKeySymbol.Properties.Caption = "연관 접점";
            // 
            // rowKeySymbol
            // 
            this.rowKeySymbol.Height = 200;
            this.rowKeySymbol.Name = "rowKeySymbol";
            this.rowKeySymbol.Properties.Caption = "접점 리스트";
            this.rowKeySymbol.Properties.ReadOnly = true;
            // 
            // grdStartConditionS
            // 
            this.grdStartConditionS.AllowDrop = true;
            this.grdStartConditionS.ContextMenuStrip = this.cntxMenu;
            this.grdStartConditionS.Location = new System.Drawing.Point(167, 72);
            this.grdStartConditionS.MainView = this.grvStartConditionS;
            this.grdStartConditionS.Name = "grdStartConditionS";
            this.grdStartConditionS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCycleStartValue,
            this.exEditorCycleStartOperator});
            this.grdStartConditionS.Size = new System.Drawing.Size(205, 72);
            this.grdStartConditionS.TabIndex = 4;
            this.grdStartConditionS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStartConditionS});
            this.grdStartConditionS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdStartConditionS_DragDrop);
            this.grdStartConditionS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdStartConditionS_DragOver);
            // 
            // cntxMenu
            // 
            this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClear,
            this.toolStripMenuItem1,
            this.mnuMoveUp,
            this.mnuMoveDown,
            this.mnuDelete});
            this.cntxMenu.Name = "cntxMenu";
            this.cntxMenu.Size = new System.Drawing.Size(157, 98);
            // 
            // mnuClear
            // 
            this.mnuClear.Image = ((System.Drawing.Image)(resources.GetObject("mnuClear.Image")));
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(156, 22);
            this.mnuClear.Text = "Clear";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            this.toolStripMenuItem1.Visible = false;
            // 
            // mnuMoveUp
            // 
            this.mnuMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("mnuMoveUp.Image")));
            this.mnuMoveUp.Name = "mnuMoveUp";
            this.mnuMoveUp.Size = new System.Drawing.Size(156, 22);
            this.mnuMoveUp.Text = "Move Up(-)";
            this.mnuMoveUp.Visible = false;
            // 
            // mnuMoveDown
            // 
            this.mnuMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("mnuMoveDown.Image")));
            this.mnuMoveDown.Name = "mnuMoveDown";
            this.mnuMoveDown.Size = new System.Drawing.Size(156, 22);
            this.mnuMoveDown.Text = "Move Down(+)";
            this.mnuMoveDown.Visible = false;
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(156, 22);
            this.mnuDelete.Text = "Delete this";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // grvStartConditionS
            // 
            this.grvStartConditionS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycleStartOperator,
            this.colCycleStartSymbol,
            this.colCycleStartValue});
            this.grvStartConditionS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvStartConditionS.GridControl = this.grdStartConditionS;
            this.grvStartConditionS.Name = "grvStartConditionS";
            this.grvStartConditionS.OptionsView.ShowGroupPanel = false;
            this.grvStartConditionS.OptionsView.ShowIndicator = false;
            // 
            // colCycleStartOperator
            // 
            this.colCycleStartOperator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleStartOperator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStartOperator.Caption = "Op";
            this.colCycleStartOperator.ColumnEdit = this.exEditorCycleStartOperator;
            this.colCycleStartOperator.FieldName = "OperatorType";
            this.colCycleStartOperator.MinWidth = 50;
            this.colCycleStartOperator.Name = "colCycleStartOperator";
            this.colCycleStartOperator.OptionsColumn.FixedWidth = true;
            this.colCycleStartOperator.Visible = true;
            this.colCycleStartOperator.VisibleIndex = 0;
            this.colCycleStartOperator.Width = 50;
            // 
            // exEditorCycleStartOperator
            // 
            this.exEditorCycleStartOperator.AutoHeight = false;
            this.exEditorCycleStartOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorCycleStartOperator.Items.AddRange(new object[] {
            "None",
            "And",
            "Or"});
            this.exEditorCycleStartOperator.Name = "exEditorCycleStartOperator";
            // 
            // colCycleStartSymbol
            // 
            this.colCycleStartSymbol.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleStartSymbol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStartSymbol.Caption = "Address";
            this.colCycleStartSymbol.FieldName = "Address";
            this.colCycleStartSymbol.Name = "colCycleStartSymbol";
            this.colCycleStartSymbol.OptionsColumn.AllowEdit = false;
            this.colCycleStartSymbol.OptionsColumn.ReadOnly = true;
            this.colCycleStartSymbol.Visible = true;
            this.colCycleStartSymbol.VisibleIndex = 1;
            this.colCycleStartSymbol.Width = 86;
            // 
            // colCycleStartValue
            // 
            this.colCycleStartValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleStartValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStartValue.Caption = "Value";
            this.colCycleStartValue.ColumnEdit = this.exEditorCycleStartValue;
            this.colCycleStartValue.FieldName = "TargetValue";
            this.colCycleStartValue.Name = "colCycleStartValue";
            this.colCycleStartValue.OptionsColumn.FixedWidth = true;
            this.colCycleStartValue.Visible = true;
            this.colCycleStartValue.VisibleIndex = 2;
            this.colCycleStartValue.Width = 50;
            // 
            // exEditorCycleStartValue
            // 
            this.exEditorCycleStartValue.AutoHeight = false;
            this.exEditorCycleStartValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorCycleStartValue.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorCycleStartValue.Name = "exEditorCycleStartValue";
            // 
            // grdEndConditionS
            // 
            this.grdEndConditionS.AllowDrop = true;
            this.grdEndConditionS.ContextMenuStrip = this.cntxMenu;
            this.grdEndConditionS.Location = new System.Drawing.Point(167, 150);
            this.grdEndConditionS.MainView = this.grvEndConditionS;
            this.grdEndConditionS.Name = "grdEndConditionS";
            this.grdEndConditionS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCycleEndValue,
            this.exEditorCyceEndOperator});
            this.grdEndConditionS.Size = new System.Drawing.Size(202, 74);
            this.grdEndConditionS.TabIndex = 5;
            this.grdEndConditionS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEndConditionS});
            this.grdEndConditionS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdEndConditionS_DragDrop);
            this.grdEndConditionS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdEndConditionS_DragOver);
            // 
            // grvEndConditionS
            // 
            this.grvEndConditionS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycleEndOperator,
            this.colCycleEndSymbol,
            this.colCycleEndValue});
            this.grvEndConditionS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEndConditionS.GridControl = this.grdEndConditionS;
            this.grvEndConditionS.Name = "grvEndConditionS";
            this.grvEndConditionS.OptionsView.ShowGroupPanel = false;
            this.grvEndConditionS.OptionsView.ShowIndicator = false;
            // 
            // colCycleEndOperator
            // 
            this.colCycleEndOperator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleEndOperator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleEndOperator.Caption = "Op";
            this.colCycleEndOperator.ColumnEdit = this.exEditorCyceEndOperator;
            this.colCycleEndOperator.FieldName = "OperatorType";
            this.colCycleEndOperator.MinWidth = 50;
            this.colCycleEndOperator.Name = "colCycleEndOperator";
            this.colCycleEndOperator.OptionsColumn.FixedWidth = true;
            this.colCycleEndOperator.Visible = true;
            this.colCycleEndOperator.VisibleIndex = 0;
            this.colCycleEndOperator.Width = 50;
            // 
            // exEditorCyceEndOperator
            // 
            this.exEditorCyceEndOperator.AutoHeight = false;
            this.exEditorCyceEndOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorCyceEndOperator.Items.AddRange(new object[] {
            "None",
            "And",
            "Or"});
            this.exEditorCyceEndOperator.Name = "exEditorCyceEndOperator";
            // 
            // colCycleEndSymbol
            // 
            this.colCycleEndSymbol.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleEndSymbol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleEndSymbol.Caption = "Address";
            this.colCycleEndSymbol.FieldName = "Address";
            this.colCycleEndSymbol.Name = "colCycleEndSymbol";
            this.colCycleEndSymbol.OptionsColumn.AllowEdit = false;
            this.colCycleEndSymbol.OptionsColumn.ReadOnly = true;
            this.colCycleEndSymbol.Visible = true;
            this.colCycleEndSymbol.VisibleIndex = 1;
            this.colCycleEndSymbol.Width = 150;
            // 
            // colCycleEndValue
            // 
            this.colCycleEndValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleEndValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleEndValue.Caption = "Value";
            this.colCycleEndValue.ColumnEdit = this.exEditorCycleEndValue;
            this.colCycleEndValue.FieldName = "TargetValue";
            this.colCycleEndValue.Name = "colCycleEndValue";
            this.colCycleEndValue.OptionsColumn.FixedWidth = true;
            this.colCycleEndValue.Visible = true;
            this.colCycleEndValue.VisibleIndex = 2;
            this.colCycleEndValue.Width = 50;
            // 
            // exEditorCycleEndValue
            // 
            this.exEditorCycleEndValue.AutoHeight = false;
            this.exEditorCycleEndValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorCycleEndValue.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorCycleEndValue.Name = "exEditorCycleEndValue";
            // 
            // grdKeySymbolS
            // 
            this.grdKeySymbolS.AllowDrop = true;
            this.grdKeySymbolS.ContextMenuStrip = this.cntxMenu;
            this.grdKeySymbolS.Location = new System.Drawing.Point(157, 284);
            this.grdKeySymbolS.MainView = this.grvKeySymbolS;
            this.grdKeySymbolS.Name = "grdKeySymbolS";
            this.grdKeySymbolS.Size = new System.Drawing.Size(230, 207);
            this.grdKeySymbolS.TabIndex = 6;
            this.grdKeySymbolS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKeySymbolS});
            this.grdKeySymbolS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdKeySymbolS_DragDrop);
            this.grdKeySymbolS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdKeySymbolS_DragOver);
            // 
            // grvKeySymbolS
            // 
            this.grvKeySymbolS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyAddress,
            this.colDescription});
            this.grvKeySymbolS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKeySymbolS.GridControl = this.grdKeySymbolS;
            this.grvKeySymbolS.Name = "grvKeySymbolS";
            this.grvKeySymbolS.OptionsDetail.EnableMasterViewMode = false;
            this.grvKeySymbolS.OptionsDetail.ShowDetailTabs = false;
            this.grvKeySymbolS.OptionsDetail.SmartDetailExpand = false;
            this.grvKeySymbolS.OptionsSelection.MultiSelect = true;
            this.grvKeySymbolS.OptionsView.ShowGroupPanel = false;
            this.grvKeySymbolS.OptionsView.ShowIndicator = false;
            // 
            // colKeyAddress
            // 
            this.colKeyAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colKeyAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKeyAddress.Caption = "Address";
            this.colKeyAddress.FieldName = "Address";
            this.colKeyAddress.Name = "colKeyAddress";
            this.colKeyAddress.OptionsColumn.AllowEdit = false;
            this.colKeyAddress.OptionsColumn.ReadOnly = true;
            this.colKeyAddress.Visible = true;
            this.colKeyAddress.VisibleIndex = 0;
            this.colKeyAddress.Width = 71;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 157;
            // 
            // UCProcessProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdKeySymbolS);
            this.Controls.Add(this.grdEndConditionS);
            this.Controls.Add(this.grdStartConditionS);
            this.Controls.Add(this.exProperty);
            this.Name = "UCProcessProperty";
            this.Size = new System.Drawing.Size(387, 493);
            this.Load += new System.EventHandler(this.UCProcessProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStartConditionS)).EndInit();
            this.cntxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvStartConditionS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEndConditionS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEndConditionS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCyceEndOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCycleEndValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeySymbolS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKeySymbolS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorSize;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catCycle;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCycleStartConditionS;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCycleEndConditionS;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catMisc;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMaxCycleTime;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catKeySymbol;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowKeySymbol;
        private DevExpress.XtraGrid.GridControl grdStartConditionS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStartConditionS;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartOperator;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCycleStartOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorCycleStartValue;
        private DevExpress.XtraGrid.GridControl grdEndConditionS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEndConditionS;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndOperator;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCyceEndOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorCycleEndValue;
        private DevExpress.XtraGrid.GridControl grdKeySymbolS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKeySymbolS;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}
