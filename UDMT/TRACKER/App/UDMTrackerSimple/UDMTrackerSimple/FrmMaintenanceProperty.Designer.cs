namespace UDMTrackerSimple
{
    partial class FrmMaintenanceProperty
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
            this.exMaintProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.catOperator = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowName = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.catMaintenance = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowCategory = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowSolution = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.exMaintProperty)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exMaintProperty
            // 
            this.exMaintProperty.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.exMaintProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exMaintProperty.Location = new System.Drawing.Point(0, 0);
            this.exMaintProperty.Name = "exMaintProperty";
            this.exMaintProperty.RecordWidth = 133;
            this.exMaintProperty.RowHeaderWidth = 67;
            this.exMaintProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catOperator,
            this.catMaintenance});
            this.exMaintProperty.Size = new System.Drawing.Size(389, 294);
            this.exMaintProperty.TabIndex = 0;
            // 
            // catOperator
            // 
            this.catOperator.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowName});
            this.catOperator.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOperator.Height = 35;
            this.catOperator.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOperator.Name = "catOperator";
            this.catOperator.Properties.Caption = "Operator";
            // 
            // rowName
            // 
            this.rowName.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowName.Height = 35;
            this.rowName.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowName.Name = "rowName";
            this.rowName.Properties.Caption = "Name";
            this.rowName.Properties.FieldName = "Name";
            this.rowName.Properties.ReadOnly = false;
            // 
            // catMaintenance
            // 
            this.catMaintenance.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCategory,
            this.rowSolution});
            this.catMaintenance.Height = 30;
            this.catMaintenance.Name = "catMaintenance";
            this.catMaintenance.Properties.Caption = "Error Maintenance";
            // 
            // rowCategory
            // 
            this.rowCategory.Height = 35;
            this.rowCategory.Name = "rowCategory";
            this.rowCategory.Properties.Caption = "Error Category";
            this.rowCategory.Properties.FieldName = "ErrorCategory";
            this.rowCategory.Properties.ReadOnly = false;
            // 
            // rowSolution
            // 
            this.rowSolution.Height = 150;
            this.rowSolution.Name = "rowSolution";
            this.rowSolution.Properties.Caption = "Solution";
            this.rowSolution.Properties.FieldName = "ErrorSolution";
            this.rowSolution.Properties.ReadOnly = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 32);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(314, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmMaintenanceProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 326);
            this.Controls.Add(this.exMaintProperty);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmMaintenanceProperty";
            this.Text = "Maintenance Property";
            this.Load += new System.EventHandler(this.FrmMaintenanceProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exMaintProperty)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exMaintProperty;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catMaintenance;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catOperator;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowName;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowCategory;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowSolution;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}