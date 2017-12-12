namespace UDM.Project
{
    partial class UCGroupProperty
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGroupProperty));
			this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
			this.exEditorValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.exEditorSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.catGroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.catCycle = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowCycleStartConditionS = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.rowCycleEndConditionS = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.catRecipe = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowProduct = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
			this.rowProductAddress = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
			this.rowProductSize = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
			this.rowRecipe = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
			this.rowRecipeAddress = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
			this.rowRecipeSize = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
			this.catMisc = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowMaxCycleTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.exGridCycleStartConditionS = new DevExpress.XtraGrid.GridControl();
			this.cntxMenu = new System.Windows.Forms.ContextMenuStrip();
			this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.exGridViewCycleStartConditionS = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCycleStartOperator = new DevExpress.XtraGrid.Columns.GridColumn();
			this.exEditorCycleStartOperator = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCycleStartSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCycleStartValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.exEditorCycleStartValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.exGridCycleEndConditionS = new DevExpress.XtraGrid.GridControl();
			this.exGridViewCycleEndConditionS = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCycleEndOperator = new DevExpress.XtraGrid.Columns.GridColumn();
			this.exEditorCyceEndOperator = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCycleEndSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCycleEndValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.exEditorCycleEndValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridCycleStartConditionS)).BeginInit();
			this.cntxMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.exGridViewCycleStartConditionS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartOperator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridCycleEndConditionS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridViewCycleEndConditionS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCyceEndOperator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleEndValue)).BeginInit();
			this.SuspendLayout();
			// 
			// exProperty
			// 
			this.exProperty.AllowDrop = true;
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
            this.catRecipe,
            this.catMisc});
			this.exProperty.Size = new System.Drawing.Size(363, 544);
			this.exProperty.TabIndex = 0;
			this.exProperty.CustomDrawRowValueCell += new DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventHandler(this.exProperty_CustomDrawRowValueCell);
			this.exProperty.ShownEditor += new System.EventHandler(this.exProperty_ShownEditor);
			this.exProperty.DragDrop += new System.Windows.Forms.DragEventHandler(this.exProperty_DragDrop);
			this.exProperty.DragOver += new System.Windows.Forms.DragEventHandler(this.exProperty_DragOver);
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
			this.catGroup.Properties.Caption = "Group";
			// 
			// rowName
			// 
			this.rowName.Height = 25;
			this.rowName.Name = "rowName";
			this.rowName.Properties.Caption = "Name";
			this.rowName.Properties.FieldName = "Key";
			this.rowName.Properties.ReadOnly = true;
			// 
			// catCycle
			// 
			this.catCycle.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCycleStartConditionS,
            this.rowCycleEndConditionS});
			this.catCycle.Height = 25;
			this.catCycle.Name = "catCycle";
			this.catCycle.Properties.Caption = "Cycle Conditions";
			// 
			// rowCycleStartConditionS
			// 
			this.rowCycleStartConditionS.Height = 60;
			this.rowCycleStartConditionS.Name = "rowCycleStartConditionS";
			this.rowCycleStartConditionS.Properties.Caption = "Start Conditions";
			this.rowCycleStartConditionS.Properties.ReadOnly = true;
			// 
			// rowCycleEndConditionS
			// 
			this.rowCycleEndConditionS.Height = 60;
			this.rowCycleEndConditionS.Name = "rowCycleEndConditionS";
			this.rowCycleEndConditionS.Properties.Caption = "End  Conditions";
			this.rowCycleEndConditionS.Properties.ReadOnly = true;
			// 
			// catRecipe
			// 
			this.catRecipe.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowProduct,
            this.rowRecipe});
			this.catRecipe.Height = 25;
			this.catRecipe.Name = "catRecipe";
			this.catRecipe.Properties.Caption = "Recipe/Product";
			// 
			// rowProduct
			// 
			this.rowProduct.Height = 25;
			this.rowProduct.Name = "rowProduct";
			this.rowProduct.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.rowProductAddress,
            this.rowProductSize});
			// 
			// rowProductAddress
			// 
			this.rowProductAddress.Caption = "Product";
			this.rowProductAddress.CellWidth = 123;
			this.rowProductAddress.FieldName = "Product.Address";
			this.rowProductAddress.Width = 60;
			// 
			// rowProductSize
			// 
			this.rowProductSize.Caption = "Size";
			this.rowProductSize.CellWidth = 42;
			this.rowProductSize.FieldName = "Product.Size";
			this.rowProductSize.RowEdit = this.exEditorSize;
			// 
			// rowRecipe
			// 
			this.rowRecipe.Height = 25;
			this.rowRecipe.Name = "rowRecipe";
			this.rowRecipe.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.rowRecipeAddress,
            this.rowRecipeSize});
			// 
			// rowRecipeAddress
			// 
			this.rowRecipeAddress.Caption = "Recipe";
			this.rowRecipeAddress.CellWidth = 60;
			this.rowRecipeAddress.FieldName = "Recipe.Address";
			this.rowRecipeAddress.Width = 60;
			// 
			// rowRecipeSize
			// 
			this.rowRecipeSize.Caption = "Size";
			this.rowRecipeSize.FieldName = "Recipe.Size";
			this.rowRecipeSize.RowEdit = this.exEditorSize;
			// 
			// catMisc
			// 
			this.catMisc.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowMaxCycleTime});
			this.catMisc.Height = 25;
			this.catMisc.Name = "catMisc";
			this.catMisc.Properties.Caption = "Misc.";
			// 
			// rowMaxCycleTime
			// 
			this.rowMaxCycleTime.Height = 30;
			this.rowMaxCycleTime.Name = "rowMaxCycleTime";
			this.rowMaxCycleTime.Properties.Caption = "Max Cycle Time(ms)";
			this.rowMaxCycleTime.Properties.FieldName = "MaxCycleTime";
			this.rowMaxCycleTime.Properties.RowEdit = this.exEditorValue;
			// 
			// exGridCycleStartConditionS
			// 
			this.exGridCycleStartConditionS.AllowDrop = true;
			this.exGridCycleStartConditionS.ContextMenuStrip = this.cntxMenu;
			this.exGridCycleStartConditionS.Location = new System.Drawing.Point(158, 58);
			this.exGridCycleStartConditionS.MainView = this.exGridViewCycleStartConditionS;
			this.exGridCycleStartConditionS.Name = "exGridCycleStartConditionS";
			this.exGridCycleStartConditionS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCycleStartValue,
            this.exEditorCycleStartOperator});
			this.exGridCycleStartConditionS.Size = new System.Drawing.Size(205, 72);
			this.exGridCycleStartConditionS.TabIndex = 3;
			this.exGridCycleStartConditionS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewCycleStartConditionS});
			this.exGridCycleStartConditionS.DragDrop += new System.Windows.Forms.DragEventHandler(this.exGridCycleStartConditionS_DragDrop);
			this.exGridCycleStartConditionS.DragOver += new System.Windows.Forms.DragEventHandler(this.exGridCycleStartConditionS_DragOver);
			// 
			// cntxMenu
			// 
			this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClear,
            this.toolStripMenuItem1,
            this.mnuMoveUp,
            this.mnuMoveDown});
			this.cntxMenu.Name = "cntxMenu";
			this.cntxMenu.Size = new System.Drawing.Size(157, 76);
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
			// 
			// mnuMoveUp
			// 
			this.mnuMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("mnuMoveUp.Image")));
			this.mnuMoveUp.Name = "mnuMoveUp";
			this.mnuMoveUp.Size = new System.Drawing.Size(156, 22);
			this.mnuMoveUp.Text = "Move Up(-)";
			this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
			// 
			// mnuMoveDown
			// 
			this.mnuMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("mnuMoveDown.Image")));
			this.mnuMoveDown.Name = "mnuMoveDown";
			this.mnuMoveDown.Size = new System.Drawing.Size(156, 22);
			this.mnuMoveDown.Text = "Move Down(+)";
			this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
			// 
			// exGridViewCycleStartConditionS
			// 
			this.exGridViewCycleStartConditionS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycleStartOperator,
            this.colCycleStartSymbol,
            this.colCycleStartValue});
			this.exGridViewCycleStartConditionS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.exGridViewCycleStartConditionS.GridControl = this.exGridCycleStartConditionS;
			this.exGridViewCycleStartConditionS.Name = "exGridViewCycleStartConditionS";
			this.exGridViewCycleStartConditionS.OptionsView.ShowGroupPanel = false;
			this.exGridViewCycleStartConditionS.OptionsView.ShowIndicator = false;
			this.exGridViewCycleStartConditionS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exGridViewCycleStartConditionS_KeyDown);
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
			// exGridCycleEndConditionS
			// 
			this.exGridCycleEndConditionS.AllowDrop = true;
			this.exGridCycleEndConditionS.ContextMenuStrip = this.cntxMenu;
			this.exGridCycleEndConditionS.Location = new System.Drawing.Point(158, 136);
			this.exGridCycleEndConditionS.MainView = this.exGridViewCycleEndConditionS;
			this.exGridCycleEndConditionS.Name = "exGridCycleEndConditionS";
			this.exGridCycleEndConditionS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCycleEndValue,
            this.exEditorCyceEndOperator});
			this.exGridCycleEndConditionS.Size = new System.Drawing.Size(202, 74);
			this.exGridCycleEndConditionS.TabIndex = 4;
			this.exGridCycleEndConditionS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewCycleEndConditionS});
			this.exGridCycleEndConditionS.DragDrop += new System.Windows.Forms.DragEventHandler(this.exGridCycleEndConditionS_DragDrop);
			this.exGridCycleEndConditionS.DragOver += new System.Windows.Forms.DragEventHandler(this.exGridCycleEndConditionS_DragOver);
			// 
			// exGridViewCycleEndConditionS
			// 
			this.exGridViewCycleEndConditionS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycleEndOperator,
            this.colCycleEndSymbol,
            this.colCycleEndValue});
			this.exGridViewCycleEndConditionS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.exGridViewCycleEndConditionS.GridControl = this.exGridCycleEndConditionS;
			this.exGridViewCycleEndConditionS.Name = "exGridViewCycleEndConditionS";
			this.exGridViewCycleEndConditionS.OptionsView.ShowGroupPanel = false;
			this.exGridViewCycleEndConditionS.OptionsView.ShowIndicator = false;
			this.exGridViewCycleEndConditionS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exGridViewCycleEndConditionS_KeyDown);
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
			// UCGroupProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exGridCycleStartConditionS);
			this.Controls.Add(this.exGridCycleEndConditionS);
			this.Controls.Add(this.exProperty);
			this.Name = "UCGroupProperty";
			this.Size = new System.Drawing.Size(363, 544);
			this.Load += new System.EventHandler(this.UCGroupProperty_Load);
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridCycleStartConditionS)).EndInit();
			this.cntxMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.exGridViewCycleStartConditionS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartOperator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleStartValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridCycleEndConditionS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridViewCycleEndConditionS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCyceEndOperator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCycleEndValue)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catCycle;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCycleStartConditionS;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCycleEndConditionS;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catRecipe;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catMisc;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMaxCycleTime;
        private DevExpress.XtraGrid.GridControl exGridCycleStartConditionS;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewCycleStartConditionS;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStartValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorCycleStartValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCycleStartOperator;
        private DevExpress.XtraGrid.GridControl exGridCycleEndConditionS;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewCycleEndConditionS;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndOperator;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCyceEndOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEndValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorCycleEndValue;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorValue;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowProduct;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties rowProductAddress;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties rowProductSize;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowRecipe;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties rowRecipeAddress;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties rowRecipeSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorSize;
    }
}
