namespace UDMTracker
{
	partial class UCCyclePresentOptionProperty
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
			this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
			this.exEditorSpin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.exEditorCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.catFilterOption = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowUseFilter = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
			this.catActiveCountOption = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowUseFirstActive = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.rowMinimumActiveCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.rowMinimumLogCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorSpin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCheck)).BeginInit();
			this.SuspendLayout();
			// 
			// exProperty
			// 
			this.exProperty.AllowDrop = true;
			this.exProperty.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exProperty.Location = new System.Drawing.Point(0, 0);
			this.exProperty.Name = "exProperty";
			this.exProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
			this.exProperty.OptionsView.ShowFocusedFrame = false;
			this.exProperty.RecordWidth = 47;
			this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorSpin,
            this.exEditorCheck});
			this.exProperty.RowHeaderWidth = 153;
			this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catFilterOption,
            this.catActiveCountOption});
			this.exProperty.Size = new System.Drawing.Size(242, 161);
			this.exProperty.TabIndex = 1;
			// 
			// exEditorSpin
			// 
			this.exEditorSpin.AutoHeight = false;
			this.exEditorSpin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.exEditorSpin.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.exEditorSpin.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.exEditorSpin.Name = "exEditorSpin";
			// 
			// exEditorCheck
			// 
			this.exEditorCheck.AutoHeight = false;
			this.exEditorCheck.Name = "exEditorCheck";
			// 
			// catFilterOption
			// 
			this.catFilterOption.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowUseFilter});
			this.catFilterOption.Height = 25;
			this.catFilterOption.Name = "catFilterOption";
			this.catFilterOption.Properties.Caption = "Filter Option";
			// 
			// rowUseFilter
			// 
			this.rowUseFilter.Height = 25;
			this.rowUseFilter.IsChildRowsLoaded = true;
			this.rowUseFilter.Name = "rowUseFilter";
			this.rowUseFilter.Properties.Caption = "Use Filter";
			this.rowUseFilter.Properties.FieldName = "UseFilter";
			this.rowUseFilter.Properties.RowEdit = this.exEditorCheck;
			// 
			// catActiveCountOption
			// 
			this.catActiveCountOption.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowUseFirstActive,
            this.rowMinimumActiveCount,
            this.rowMinimumLogCount});
			this.catActiveCountOption.Height = 25;
			this.catActiveCountOption.Name = "catActiveCountOption";
			this.catActiveCountOption.Properties.Caption = "Active Count Option";
			// 
			// rowUseFirstActive
			// 
			this.rowUseFirstActive.Height = 25;
			this.rowUseFirstActive.Name = "rowUseFirstActive";
			this.rowUseFirstActive.Properties.Caption = "Use First Active";
			this.rowUseFirstActive.Properties.FieldName = "UseFirstActive";
			this.rowUseFirstActive.Properties.RowEdit = this.exEditorCheck;
			// 
			// rowMinimumActiveCount
			// 
			this.rowMinimumActiveCount.Height = 25;
			this.rowMinimumActiveCount.Name = "rowMinimumActiveCount";
			this.rowMinimumActiveCount.Properties.Caption = "Minimum Active Count";
			this.rowMinimumActiveCount.Properties.FieldName = "MinimnumActiveCount";
			this.rowMinimumActiveCount.Properties.RowEdit = this.exEditorSpin;
			// 
			// rowMinimumLogCount
			// 
			this.rowMinimumLogCount.Height = 25;
			this.rowMinimumLogCount.Name = "rowMinimumLogCount";
			this.rowMinimumLogCount.Properties.Caption = "Minimum Log Count";
			this.rowMinimumLogCount.Properties.FieldName = "MinimumLogCount";
			this.rowMinimumLogCount.Properties.RowEdit = this.exEditorSpin;
			// 
			// UCCyclePresentOptionProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exProperty);
			this.Name = "UCCyclePresentOptionProperty";
			this.Size = new System.Drawing.Size(242, 161);
			this.Load += new System.EventHandler(this.UCCyclePresentOptionProperty_Load);
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorSpin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorCheck)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorSpin;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUseFirstActive;
		private DevExpress.XtraVerticalGrid.Rows.CategoryRow catActiveCountOption;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMinimumActiveCount;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMinimumLogCount;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheck;
		private DevExpress.XtraVerticalGrid.Rows.CategoryRow catFilterOption;
		private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowUseFilter;

	}
}
