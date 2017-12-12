namespace UDMIOMaker
{
    partial class FrmSymbolAddProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolAddProperty));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.exSymbolProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.catPLCSymbol = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowAddress = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowDescription = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowTagName = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowDataType = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowSize = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowPLCName = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.grbPLCList = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exSymbolProperty)).BeginInit();
            this.grbPLCList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
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
            this.panelControl1.Location = new System.Drawing.Point(0, 344);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(377, 50);
            this.panelControl1.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(209, 0);
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
            this.btnClose.Location = new System.Drawing.Point(296, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // exSymbolProperty
            // 
            this.exSymbolProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exSymbolProperty.Location = new System.Drawing.Point(0, 48);
            this.exSymbolProperty.Name = "exSymbolProperty";
            this.exSymbolProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exSymbolProperty.RecordWidth = 132;
            this.exSymbolProperty.RowHeaderWidth = 68;
            this.exSymbolProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catPLCSymbol});
            this.exSymbolProperty.Size = new System.Drawing.Size(377, 296);
            this.exSymbolProperty.TabIndex = 5;
            // 
            // catPLCSymbol
            // 
            this.catPLCSymbol.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.catPLCSymbol.Appearance.Options.UseFont = true;
            this.catPLCSymbol.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowAddress,
            this.rowDescription,
            this.rowTagName,
            this.rowDataType,
            this.rowSize,
            this.rowPLCName});
            this.catPLCSymbol.Height = 40;
            this.catPLCSymbol.Name = "catPLCSymbol";
            this.catPLCSymbol.Properties.Caption = "PLC 심볼";
            // 
            // rowAddress
            // 
            this.rowAddress.Height = 40;
            this.rowAddress.Name = "rowAddress";
            this.rowAddress.Properties.Caption = "Address *";
            this.rowAddress.Properties.FieldName = "Address";
            // 
            // rowDescription
            // 
            this.rowDescription.Height = 40;
            this.rowDescription.Name = "rowDescription";
            this.rowDescription.Properties.Caption = "Description";
            this.rowDescription.Properties.FieldName = "Description";
            // 
            // rowTagName
            // 
            this.rowTagName.Height = 40;
            this.rowTagName.Name = "rowTagName";
            this.rowTagName.Properties.Caption = "Name*";
            this.rowTagName.Properties.FieldName = "Name";
            // 
            // rowDataType
            // 
            this.rowDataType.Height = 40;
            this.rowDataType.Name = "rowDataType";
            this.rowDataType.Properties.Caption = "Data Type *";
            this.rowDataType.Properties.FieldName = "DataType";
            // 
            // rowSize
            // 
            this.rowSize.Height = 40;
            this.rowSize.Name = "rowSize";
            this.rowSize.Properties.Caption = "Size";
            this.rowSize.Properties.FieldName = "Size";
            // 
            // rowPLCName
            // 
            this.rowPLCName.Height = 40;
            this.rowPLCName.Name = "rowPLCName";
            this.rowPLCName.Properties.Caption = "PLC Name *";
            this.rowPLCName.Properties.FieldName = "Channel";
            this.rowPLCName.Properties.ReadOnly = true;
            // 
            // grbPLCList
            // 
            this.grbPLCList.BackColor = System.Drawing.Color.White;
            this.grbPLCList.Controls.Add(this.labelControl1);
            this.grbPLCList.Controls.Add(this.cboPLCList);
            this.grbPLCList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbPLCList.Location = new System.Drawing.Point(0, 0);
            this.grbPLCList.Name = "grbPLCList";
            this.grbPLCList.Size = new System.Drawing.Size(377, 48);
            this.grbPLCList.TabIndex = 6;
            this.grbPLCList.TabStop = false;
            this.grbPLCList.Text = "PLC List";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(290, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "*는 필수 기입";
            // 
            // cboPLCList
            // 
            this.cboPLCList.Location = new System.Drawing.Point(6, 21);
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Size = new System.Drawing.Size(176, 20);
            this.cboPLCList.TabIndex = 0;
            this.cboPLCList.SelectedValueChanged += new System.EventHandler(this.cboPLCList_SelectedValueChanged);
            // 
            // FrmSymbolAddProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 394);
            this.Controls.Add(this.exSymbolProperty);
            this.Controls.Add(this.grbPLCList);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSymbolAddProperty";
            this.Text = "PLC 심볼 추가 ";
            this.Load += new System.EventHandler(this.FrmSymbolAddProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exSymbolProperty)).EndInit();
            this.grbPLCList.ResumeLayout(false);
            this.grbPLCList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exSymbolProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catPLCSymbol;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowAddress;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowDescription;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowTagName;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowDataType;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowSize;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowPLCName;
        private System.Windows.Forms.GroupBox grbPLCList;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}