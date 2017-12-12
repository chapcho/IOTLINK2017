namespace UDMTrackerSimple
{
    partial class UCTeamInfo
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
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.catTime = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowFrom = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowTo = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.catTeamName = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowTeamName = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.catTargetCount = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowTargetCount = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
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
            this.exProperty.RecordWidth = 132;
            this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo});
            this.exProperty.RowHeaderWidth = 68;
            this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catTime,
            this.catTeamName,
            this.catTargetCount});
            this.exProperty.Size = new System.Drawing.Size(423, 595);
            this.exProperty.TabIndex = 1;
            this.exProperty.CustomDrawRowValueCell += new DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventHandler(this.exProperty_CustomDrawRowValueCell);
            this.exProperty.DragDrop += new System.Windows.Forms.DragEventHandler(this.exProperty_DragDrop);
            this.exProperty.DragOver += new System.Windows.Forms.DragEventHandler(this.exProperty_DragOver);
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorFrom.Appearance.Options.UseFont = true;
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFrom.DisplayFormat.FormatString = "HH:mm";
            this.exEditorFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.EditFormat.FormatString = "HH:mm";
            this.exEditorFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorFrom.Mask.EditMask = "HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            this.exEditorFrom.EditValueChanged += new System.EventHandler(this.exEditorFrom_EditValueChanged);
            // 
            // exEditorTo
            // 
            this.exEditorTo.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorTo.Appearance.Options.UseFont = true;
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTo.DisplayFormat.FormatString = "HH:mm";
            this.exEditorTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTo.EditFormat.FormatString = "HH:mm";
            this.exEditorTo.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTo.Mask.EditMask = "HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
            this.exEditorTo.EditValueChanged += new System.EventHandler(this.exEditorTo_EditValueChanged);
            // 
            // catTime
            // 
            this.catTime.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catTime.Appearance.Options.UseFont = true;
            this.catTime.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowFrom,
            this.rowTo});
            this.catTime.Height = 40;
            this.catTime.Name = "catTime";
            this.catTime.Properties.Caption = "근무 시간";
            // 
            // rowFrom
            // 
            this.rowFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowFrom.Appearance.Options.UseFont = true;
            this.rowFrom.Height = 40;
            this.rowFrom.Name = "rowFrom";
            this.rowFrom.Properties.Caption = "시작";
            this.rowFrom.Properties.FieldName = "From";
            this.rowFrom.Properties.RowEdit = this.exEditorFrom;
            // 
            // rowTo
            // 
            this.rowTo.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowTo.Appearance.Options.UseFont = true;
            this.rowTo.Height = 40;
            this.rowTo.Name = "rowTo";
            this.rowTo.Properties.Caption = "끝";
            this.rowTo.Properties.FieldName = "To";
            this.rowTo.Properties.RowEdit = this.exEditorTo;
            // 
            // catTeamName
            // 
            this.catTeamName.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catTeamName.Appearance.Options.UseFont = true;
            this.catTeamName.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTeamName});
            this.catTeamName.Height = 40;
            this.catTeamName.Name = "catTeamName";
            this.catTeamName.Properties.Caption = "근무조";
            // 
            // rowTeamName
            // 
            this.rowTeamName.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowTeamName.Appearance.Options.UseFont = true;
            this.rowTeamName.Height = 40;
            this.rowTeamName.Name = "rowTeamName";
            this.rowTeamName.Properties.Caption = "이름";
            this.rowTeamName.Properties.FieldName = "TeamName";
            // 
            // catTargetCount
            // 
            this.catTargetCount.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catTargetCount.Appearance.Options.UseFont = true;
            this.catTargetCount.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTargetCount});
            this.catTargetCount.Height = 40;
            this.catTargetCount.Name = "catTargetCount";
            this.catTargetCount.Properties.Caption = "목표 수량";
            // 
            // rowTargetCount
            // 
            this.rowTargetCount.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowTargetCount.Appearance.Options.UseFont = true;
            this.rowTargetCount.Height = 40;
            this.rowTargetCount.Name = "rowTargetCount";
            this.rowTargetCount.Properties.Caption = "수량";
            this.rowTargetCount.Properties.FieldName = "TargetCount";
            // 
            // UCTeamInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exProperty);
            this.Name = "UCTeamInfo";
            this.Size = new System.Drawing.Size(423, 595);
            this.Load += new System.EventHandler(this.UCTeamInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catTeamName;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catTime;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catTargetCount;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTeamName;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowFrom;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTo;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTargetCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
    }
}
