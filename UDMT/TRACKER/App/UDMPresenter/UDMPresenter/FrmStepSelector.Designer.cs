namespace UDMPresenter
{
    partial class FrmStepSelector
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStepSelector));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.grdStepTable = new DevExpress.XtraGrid.GridControl();
            this.grvStepTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetworkNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStepTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStepTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(607, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(58, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "선택";
            this.btnOK.ToolTip = "선택";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnOK);
            this.pnlControl.Controls.Add(this.pnlSplitter);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 309);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlControl.Size = new System.Drawing.Size(741, 35);
            this.pnlControl.TabIndex = 8;
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSplitter.Location = new System.Drawing.Point(665, 5);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Size = new System.Drawing.Size(8, 25);
            this.pnlSplitter.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(673, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.ToolTip = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdStepTable
            // 
            this.grdStepTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStepTable.Location = new System.Drawing.Point(0, 0);
            this.grdStepTable.MainView = this.grvStepTable;
            this.grdStepTable.Name = "grdStepTable";
            this.grdStepTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdStepTable.Size = new System.Drawing.Size(741, 309);
            this.grdStepTable.TabIndex = 11;
            this.grdStepTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStepTable});
            // 
            // grvStepTable
            // 
            this.grvStepTable.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvStepTable.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvStepTable.ColumnPanelRowHeight = 35;
            this.grvStepTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelect,
            this.colAddress,
            this.colDescription,
            this.colDataType,
            this.colProgram,
            this.colNetworkNum,
            this.colStep,
            this.colCommand});
            this.grvStepTable.GridControl = this.grdStepTable;
            this.grvStepTable.IndicatorWidth = 50;
            this.grvStepTable.Name = "grvStepTable";
            this.grvStepTable.OptionsBehavior.Editable = false;
            this.grvStepTable.OptionsBehavior.ReadOnly = true;
            this.grvStepTable.OptionsDetail.EnableMasterViewMode = false;
            this.grvStepTable.OptionsDetail.ShowDetailTabs = false;
            this.grvStepTable.OptionsDetail.SmartDetailExpand = false;
            this.grvStepTable.OptionsSelection.MultiSelect = true;
            this.grvStepTable.OptionsView.ShowAutoFilterRow = true;
            this.grvStepTable.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStepTable_CustomDrawRowIndicator);
            this.grvStepTable.DoubleClick += new System.EventHandler(this.grvStepTable_DoubleClick);
            // 
            // colIsSelect
            // 
            this.colIsSelect.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSelect.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colIsSelect.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsSelect.Caption = "Used";
            this.colIsSelect.ColumnEdit = this.exEditorCheckBox;
            this.colIsSelect.FieldName = "CoilCollectUsed";
            this.colIsSelect.MinWidth = 40;
            this.colIsSelect.Name = "colIsSelect";
            this.colIsSelect.OptionsColumn.FixedWidth = true;
            this.colIsSelect.Visible = true;
            this.colIsSelect.VisibleIndex = 0;
            this.colIsSelect.Width = 40;
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
            this.colAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "CoilAddress";
            this.colAddress.MinWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDescription.Caption = "Label / Description";
            this.colDescription.FieldName = "CoilComment";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 100;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDataType.Caption = "Data Type";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "CoilDataType";
            this.colDataType.MinWidth = 70;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowFocus = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            this.colDataType.Width = 70;
            // 
            // exEditorDataType
            // 
            this.exEditorDataType.AutoHeight = false;
            this.exEditorDataType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDataType.Items.AddRange(new object[] {
            "Bool",
            "Word",
            "DWord"});
            this.exEditorDataType.Name = "exEditorDataType";
            // 
            // colProgram
            // 
            this.colProgram.AppearanceCell.Options.UseTextOptions = true;
            this.colProgram.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.Caption = "Program";
            this.colProgram.FieldName = "Program";
            this.colProgram.MinWidth = 100;
            this.colProgram.Name = "colProgram";
            this.colProgram.OptionsColumn.AllowEdit = false;
            this.colProgram.OptionsColumn.AllowFocus = false;
            this.colProgram.OptionsColumn.ReadOnly = true;
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 5;
            this.colProgram.Width = 100;
            // 
            // colNetworkNum
            // 
            this.colNetworkNum.AppearanceCell.Options.UseTextOptions = true;
            this.colNetworkNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNetworkNum.AppearanceHeader.Options.UseTextOptions = true;
            this.colNetworkNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNetworkNum.Caption = "Network";
            this.colNetworkNum.FieldName = "NetworkNumber";
            this.colNetworkNum.MinWidth = 30;
            this.colNetworkNum.Name = "colNetworkNum";
            this.colNetworkNum.OptionsColumn.AllowEdit = false;
            this.colNetworkNum.OptionsColumn.AllowFocus = false;
            this.colNetworkNum.OptionsColumn.ReadOnly = true;
            this.colNetworkNum.Visible = true;
            this.colNetworkNum.VisibleIndex = 6;
            this.colNetworkNum.Width = 30;
            // 
            // colStep
            // 
            this.colStep.AppearanceCell.Options.UseTextOptions = true;
            this.colStep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStep.AppearanceHeader.Options.UseTextOptions = true;
            this.colStep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStep.Caption = "Step";
            this.colStep.FieldName = "StepNumber";
            this.colStep.Name = "colStep";
            this.colStep.OptionsColumn.AllowEdit = false;
            this.colStep.OptionsColumn.AllowFocus = false;
            this.colStep.OptionsColumn.ReadOnly = true;
            this.colStep.Visible = true;
            this.colStep.VisibleIndex = 7;
            this.colStep.Width = 20;
            // 
            // colCommand
            // 
            this.colCommand.AppearanceCell.Options.UseTextOptions = true;
            this.colCommand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommand.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommand.Caption = "Command";
            this.colCommand.FieldName = "Command";
            this.colCommand.MinWidth = 100;
            this.colCommand.Name = "colCommand";
            this.colCommand.Visible = true;
            this.colCommand.VisibleIndex = 2;
            this.colCommand.Width = 100;
            // 
            // exEditorCreatorType
            // 
            this.exEditorCreatorType.AutoHeight = false;
            this.exEditorCreatorType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorCreatorType.Items.AddRange(new object[] {
            "ByLogic",
            "ByUser"});
            this.exEditorCreatorType.Name = "exEditorCreatorType";
            // 
            // exEditorFeatureType
            // 
            this.exEditorFeatureType.AutoHeight = false;
            this.exEditorFeatureType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFeatureType.Items.AddRange(new object[] {
            "None",
            "AlwaysOn",
            "AlwaysOff",
            "ManualOperation",
            "NotAccessable"});
            this.exEditorFeatureType.Name = "exEditorFeatureType";
            // 
            // exEditorConfigMDC
            // 
            this.exEditorConfigMDC.AutoHeight = false;
            this.exEditorConfigMDC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "설정", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.exEditorConfigMDC.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.exEditorConfigMDC.Name = "exEditorConfigMDC";
            this.exEditorConfigMDC.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // FrmStepSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 344);
            this.Controls.Add(this.grdStepTable);
            this.Controls.Add(this.pnlControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStepSelector";
            this.Text = "Step Selector";
            this.Load += new System.EventHandler(this.FrmStepSelector_Load);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStepTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStepTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlSplitter;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl grdStepTable;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStepTable;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colNetworkNum;
        private DevExpress.XtraGrid.Columns.GridColumn colStep;
        private DevExpress.XtraGrid.Columns.GridColumn colCommand;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
    }
}