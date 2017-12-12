namespace UDM.Project
{
    partial class UCTrendProperty
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
            this.catBaseInfo = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowAddress = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDescription = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDataType = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.catBound = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowLowerBound = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUppderBound = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.exEditorValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).BeginInit();
            this.SuspendLayout();
            // 
            // exProperty
            // 
            this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exProperty.Location = new System.Drawing.Point(0, 0);
            this.exProperty.Name = "exProperty";
            this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorValue});
            this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catBaseInfo,
            this.catBound});
            this.exProperty.Size = new System.Drawing.Size(288, 341);
            this.exProperty.TabIndex = 0;
            // 
            // catBaseInfo
            // 
            this.catBaseInfo.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowAddress,
            this.rowDescription,
            this.rowDataType});
            this.catBaseInfo.Height = 25;
            this.catBaseInfo.Name = "catBaseInfo";
            this.catBaseInfo.Properties.Caption = "Base Info";
            // 
            // rowAddress
            // 
            this.rowAddress.Height = 25;
            this.rowAddress.Name = "rowAddress";
            this.rowAddress.Properties.Caption = "Address";
            this.rowAddress.Properties.FieldName = "Address";
            this.rowAddress.Properties.ReadOnly = true;
            // 
            // rowDescription
            // 
            this.rowDescription.Height = 25;
            this.rowDescription.Name = "rowDescription";
            this.rowDescription.Properties.Caption = "Description";
            this.rowDescription.Properties.FieldName = "Description";
            this.rowDescription.Properties.ReadOnly = true;
            // 
            // rowDataType
            // 
            this.rowDataType.Height = 25;
            this.rowDataType.Name = "rowDataType";
            this.rowDataType.Properties.Caption = "DataType";
            this.rowDataType.Properties.FieldName = "DataType";
            this.rowDataType.Properties.ReadOnly = true;
            // 
            // catBound
            // 
            this.catBound.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowLowerBound,
            this.rowUppderBound});
            this.catBound.Height = 25;
            this.catBound.Name = "catBound";
            this.catBound.Properties.Caption = "Bound Info";
            // 
            // rowLowerBound
            // 
            this.rowLowerBound.Height = 25;
            this.rowLowerBound.Name = "rowLowerBound";
            this.rowLowerBound.Properties.Caption = "Lower Bound";
            this.rowLowerBound.Properties.FieldName = "LowerBound";
            this.rowLowerBound.Properties.RowEdit = this.exEditorValue;
            // 
            // rowUppderBound
            // 
            this.rowUppderBound.Height = 25;
            this.rowUppderBound.Name = "rowUppderBound";
            this.rowUppderBound.Properties.Caption = "Upper Bound";
            this.rowUppderBound.Properties.FieldName = "UpperBound";
            this.rowUppderBound.Properties.RowEdit = this.exEditorValue;
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
            // UCTrenSymbolProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exProperty);
            this.Name = "UCTrenSymbolProperty";
            this.Size = new System.Drawing.Size(288, 341);
            this.Load += new System.EventHandler(this.UCTrendSymbolProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catBaseInfo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAddress;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorValue;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDataType;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catBound;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLowerBound;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUppderBound;
    }
}
