namespace UDMIOMaker
{
    partial class FrmStdAddProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStdAddProperty));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.exStdProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.catStdLibrary = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowCurrent = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowTarget = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowDescription = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exStdProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 169);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(353, 50);
            this.panelControl1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(185, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 50);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(272, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // exStdProperty
            // 
            this.exStdProperty.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.exStdProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exStdProperty.Location = new System.Drawing.Point(0, 0);
            this.exStdProperty.Name = "exStdProperty";
            this.exStdProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exStdProperty.RecordWidth = 135;
            this.exStdProperty.RowHeaderWidth = 65;
            this.exStdProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catStdLibrary});
            this.exStdProperty.Size = new System.Drawing.Size(353, 169);
            this.exStdProperty.TabIndex = 4;
            // 
            // catStdLibrary
            // 
            this.catStdLibrary.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.catStdLibrary.Appearance.Options.UseFont = true;
            this.catStdLibrary.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCurrent,
            this.rowTarget,
            this.rowDescription});
            this.catStdLibrary.Height = 40;
            this.catStdLibrary.Name = "catStdLibrary";
            this.catStdLibrary.Properties.Caption = "심볼 표준 라이브러리";
            // 
            // rowCurrent
            // 
            this.rowCurrent.Height = 40;
            this.rowCurrent.Name = "rowCurrent";
            this.rowCurrent.Properties.Caption = "기존 이름";
            this.rowCurrent.Properties.FieldName = "CurrentName";
            // 
            // rowTarget
            // 
            this.rowTarget.Height = 40;
            this.rowTarget.Name = "rowTarget";
            this.rowTarget.Properties.Caption = "표준 이름";
            this.rowTarget.Properties.FieldName = "TargetName";
            // 
            // rowDescription
            // 
            this.rowDescription.Height = 40;
            this.rowDescription.Name = "rowDescription";
            this.rowDescription.Properties.Caption = "설명";
            this.rowDescription.Properties.FieldName = "Description";
            // 
            // FrmStdAddProperty
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 219);
            this.Controls.Add(this.exStdProperty);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStdAddProperty";
            this.Text = "라이브러리 추가";
            this.Load += new System.EventHandler(this.FrmStdAddProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exStdProperty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exStdProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catStdLibrary;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowCurrent;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTarget;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowDescription;
    }
}