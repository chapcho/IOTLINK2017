namespace UDM.Project
{
    partial class UCSymbolTable
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
			this.exGridMain = new DevExpress.XtraGrid.GridControl();
			this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
			this.SuspendLayout();
			// 
			// exGridMain
			// 
			this.exGridMain.AllowDrop = true;
			this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGridMain.Location = new System.Drawing.Point(0, 0);
			this.exGridMain.MainView = this.exGridView;
			this.exGridMain.Name = "exGridMain";
			this.exGridMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo});
			this.exGridMain.Size = new System.Drawing.Size(652, 495);
			this.exGridMain.TabIndex = 1;
			this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
			// 
			// exGridView
			// 
			this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colAddress,
            this.colSize,
            this.colDataType,
            this.colDescription,
            this.colGroup,
            this.colRoleType});
			this.exGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.exGridView.GridControl = this.exGridMain;
			this.exGridView.IndicatorWidth = 60;
			this.exGridView.Name = "exGridView";
			this.exGridView.OptionsBehavior.Editable = false;
			this.exGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
			this.exGridView.OptionsBehavior.ReadOnly = true;
			this.exGridView.OptionsDetail.EnableMasterViewMode = false;
			this.exGridView.OptionsDetail.ShowDetailTabs = false;
			this.exGridView.OptionsDetail.SmartDetailExpand = false;
			this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.exGridView.OptionsSelection.MultiSelect = true;
			this.exGridView.OptionsView.ShowAutoFilterRow = true;
			this.exGridView.ShownEditor += new System.EventHandler(this.exGridView_ShownEditor);
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
			this.colAddress.MinWidth = 60;
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 0;
			this.colAddress.Width = 111;
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
			this.colSize.Visible = true;
			this.colSize.VisibleIndex = 1;
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
			this.colDataType.MinWidth = 70;
			this.colDataType.Name = "colDataType";
			this.colDataType.Visible = true;
			this.colDataType.VisibleIndex = 2;
			this.colDataType.Width = 93;
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
			this.colDescription.Width = 154;
			// 
			// colGroup
			// 
			this.colGroup.AppearanceCell.Options.UseTextOptions = true;
			this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
			this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGroup.Caption = "Group";
			this.colGroup.FieldName = "GroupKey";
			this.colGroup.MinWidth = 70;
			this.colGroup.Name = "colGroup";
			this.colGroup.Visible = true;
			this.colGroup.VisibleIndex = 4;
			this.colGroup.Width = 81;
			// 
			// colRoleType
			// 
			this.colRoleType.AppearanceHeader.Options.UseTextOptions = true;
			this.colRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRoleType.Caption = "RoleType";
			this.colRoleType.FieldName = "RoleType";
			this.colRoleType.Name = "colRoleType";
			this.colRoleType.Visible = true;
			this.colRoleType.VisibleIndex = 5;
			this.colRoleType.Width = 96;
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
            "General",
            "Trend",
            "Alarm"});
			this.exEditorGroupRoleCombo.Name = "exEditorGroupRoleCombo";
			this.exEditorGroupRoleCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// UCSymbolTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exGridMain);
			this.Name = "UCSymbolTable";
			this.Size = new System.Drawing.Size(652, 495);
			this.Load += new System.EventHandler(this.UCSymbolTable_Load);
			((System.ComponentModel.ISupportInitialize)(this.exGridMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
    }
}
