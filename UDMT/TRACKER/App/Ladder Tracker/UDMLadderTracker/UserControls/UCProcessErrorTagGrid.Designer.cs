namespace UDMLadderTracker
{
    partial class UCProcessErrorTagGrid
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grpGroup = new DevExpress.XtraEditors.GroupControl();
            this.grdAbnormalSymbolS = new DevExpress.XtraGrid.GridControl();
            this.grvAbnormalSymbolS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlBackGround = new DevExpress.XtraEditors.PanelControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.tmrBackGround = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup)).BeginInit();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbnormalSymbolS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbnormalSymbolS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackGround)).BeginInit();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGroup
            // 
            this.grpGroup.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpGroup.AppearanceCaption.Options.UseFont = true;
            this.grpGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpGroup.Controls.Add(this.grdAbnormalSymbolS);
            this.grpGroup.Controls.Add(this.pnlBackGround);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.Location = new System.Drawing.Point(0, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(998, 572);
            this.grpGroup.TabIndex = 26;
            this.grpGroup.Text = "Group1";
            this.grpGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.grpGroup_Paint);
            // 
            // grdAbnormalSymbolS
            // 
            this.grdAbnormalSymbolS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAbnormalSymbolS.Location = new System.Drawing.Point(2, 26);
            this.grdAbnormalSymbolS.MainView = this.grvAbnormalSymbolS;
            this.grdAbnormalSymbolS.Name = "grdAbnormalSymbolS";
            this.grdAbnormalSymbolS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdAbnormalSymbolS.Size = new System.Drawing.Size(994, 544);
            this.grdAbnormalSymbolS.TabIndex = 5;
            this.grdAbnormalSymbolS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbnormalSymbolS});
            // 
            // grvAbnormalSymbolS
            // 
            this.grvAbnormalSymbolS.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.grvAbnormalSymbolS.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.grvAbnormalSymbolS.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvAbnormalSymbolS.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvAbnormalSymbolS.Appearance.Row.Options.UseBackColor = true;
            this.grvAbnormalSymbolS.Appearance.Row.Options.UseFont = true;
            this.grvAbnormalSymbolS.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvAbnormalSymbolS.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvAbnormalSymbolS.ColumnPanelRowHeight = 35;
            this.grvAbnormalSymbolS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colCurrentValue,
            this.colChangeCount,
            this.colDescription});
            this.grvAbnormalSymbolS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbnormalSymbolS.GridControl = this.grdAbnormalSymbolS;
            this.grvAbnormalSymbolS.IndicatorWidth = 50;
            this.grvAbnormalSymbolS.Name = "grvAbnormalSymbolS";
            this.grvAbnormalSymbolS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvAbnormalSymbolS.OptionsDetail.AllowZoomDetail = false;
            this.grvAbnormalSymbolS.OptionsDetail.EnableMasterViewMode = false;
            this.grvAbnormalSymbolS.OptionsDetail.ShowDetailTabs = false;
            this.grvAbnormalSymbolS.OptionsDetail.SmartDetailExpand = false;
            this.grvAbnormalSymbolS.OptionsView.EnableAppearanceEvenRow = true;
            this.grvAbnormalSymbolS.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbnormalSymbolS.OptionsView.ShowGroupPanel = false;
            this.grvAbnormalSymbolS.RowHeight = 30;
            this.grvAbnormalSymbolS.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAddress, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvAbnormalSymbolS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvAbnormalSymbolS_CustomDrawRowIndicator);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 120;
            // 
            // colCurrentValue
            // 
            this.colCurrentValue.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCurrentValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colCurrentValue.AppearanceHeader.Options.UseFont = true;
            this.colCurrentValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentValue.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCurrentValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCurrentValue.Caption = "Value";
            this.colCurrentValue.FieldName = "Value";
            this.colCurrentValue.MinWidth = 70;
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.OptionsColumn.AllowEdit = false;
            this.colCurrentValue.OptionsColumn.FixedWidth = true;
            this.colCurrentValue.OptionsColumn.ReadOnly = true;
            this.colCurrentValue.Visible = true;
            this.colCurrentValue.VisibleIndex = 2;
            this.colCurrentValue.Width = 100;
            // 
            // colChangeCount
            // 
            this.colChangeCount.AppearanceCell.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colChangeCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colChangeCount.AppearanceHeader.Options.UseFont = true;
            this.colChangeCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChangeCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colChangeCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChangeCount.Caption = "Count";
            this.colChangeCount.FieldName = "ChangeCount";
            this.colChangeCount.MinWidth = 70;
            this.colChangeCount.Name = "colChangeCount";
            this.colChangeCount.OptionsColumn.AllowEdit = false;
            this.colChangeCount.OptionsColumn.FixedWidth = true;
            this.colChangeCount.OptionsColumn.ReadOnly = true;
            this.colChangeCount.Visible = true;
            this.colChangeCount.VisibleIndex = 3;
            this.colChangeCount.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 20;
            // 
            // exEditorCheckBox
            // 
            this.exEditorCheckBox.AutoHeight = false;
            this.exEditorCheckBox.Name = "exEditorCheckBox";
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "설정", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.exEditorConfigMDC.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.exEditorConfigMDC.Name = "exEditorConfigMDC";
            this.exEditorConfigMDC.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBackGround.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.pnlBackGround.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBackGround.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBackGround.Appearance.Options.UseBackColor = true;
            this.pnlBackGround.Appearance.Options.UseBorderColor = true;
            this.pnlBackGround.Controls.Add(this.lblMessage);
            this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGround.Location = new System.Drawing.Point(2, 26);
            this.pnlBackGround.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBackGround.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.pnlBackGround.Size = new System.Drawing.Size(994, 544);
            this.pnlBackGround.TabIndex = 6;
            this.pnlBackGround.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(12, 14);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(970, 516);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // tmrBackGround
            // 
            this.tmrBackGround.Interval = 1000;
            this.tmrBackGround.Tick += new System.EventHandler(this.tmrBackGround_Tick);
            // 
            // UCGroupErrorTagGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGroup);
            this.Name = "UCGroupErrorTagGrid";
            this.Size = new System.Drawing.Size(998, 572);
            ((System.ComponentModel.ISupportInitialize)(this.grpGroup)).EndInit();
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbnormalSymbolS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbnormalSymbolS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackGround)).EndInit();
            this.pnlBackGround.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpGroup;
        private DevExpress.XtraGrid.GridControl grdAbnormalSymbolS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbnormalSymbolS;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraEditors.PanelControl pnlBackGround;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private System.Windows.Forms.Timer tmrBackGround;
    }
}
