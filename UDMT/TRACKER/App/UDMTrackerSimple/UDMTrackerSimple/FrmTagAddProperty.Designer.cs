namespace UDMTrackerSimple
{
    partial class FrmTagAddProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTagAddProperty));
            this.grbPLCList = new System.Windows.Forms.GroupBox();
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnValidTag = new DevExpress.XtraEditors.SimpleButton();
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaker = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCollectType = new DevExpress.XtraEditors.TextEdit();
            this.grbPLCList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exSymbolProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollectType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grbPLCList
            // 
            this.grbPLCList.BackColor = System.Drawing.Color.White;
            this.grbPLCList.Controls.Add(this.cboPLCList);
            this.grbPLCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPLCList.Location = new System.Drawing.Point(2, 2);
            this.grbPLCList.Name = "grbPLCList";
            this.grbPLCList.Size = new System.Drawing.Size(142, 44);
            this.grbPLCList.TabIndex = 7;
            this.grbPLCList.TabStop = false;
            this.grbPLCList.Text = "PLC Name List";
            // 
            // cboPLCList
            // 
            this.cboPLCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPLCList.Location = new System.Drawing.Point(3, 18);
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCList.Size = new System.Drawing.Size(136, 20);
            this.cboPLCList.TabIndex = 0;
            this.cboPLCList.SelectedIndexChanged += new System.EventHandler(this.cboPLCList_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(276, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "*는 필수 기입";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnValidTag);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 352);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(378, 50);
            this.panelControl1.TabIndex = 8;
            // 
            // btnValidTag
            // 
            this.btnValidTag.Appearance.BackColor = System.Drawing.Color.White;
            this.btnValidTag.Appearance.Options.UseBackColor = true;
            this.btnValidTag.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnValidTag.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnValidTag.Image = ((System.Drawing.Image)(resources.GetObject("btnValidTag.Image")));
            this.btnValidTag.Location = new System.Drawing.Point(0, 0);
            this.btnValidTag.Name = "btnValidTag";
            this.btnValidTag.Size = new System.Drawing.Size(131, 50);
            this.btnValidTag.TabIndex = 21;
            this.btnValidTag.Text = "Validate Check";
            this.btnValidTag.Click += new System.EventHandler(this.btnValidTag_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(210, 0);
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
            this.btnClose.Location = new System.Drawing.Point(297, 0);
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
            this.exSymbolProperty.Size = new System.Drawing.Size(378, 304);
            this.exSymbolProperty.TabIndex = 9;
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
            this.catPLCSymbol.Properties.Caption = "PLC 태그";
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
            this.rowPLCName.Properties.Caption = "PLC Channel *";
            this.rowPLCName.Properties.FieldName = "Channel";
            this.rowPLCName.Properties.ReadOnly = true;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grbPLCList);
            this.panelControl2.Controls.Add(this.groupBox2);
            this.panelControl2.Controls.Add(this.groupBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(378, 48);
            this.panelControl2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtMaker);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(144, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 44);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maker";
            // 
            // txtMaker
            // 
            this.txtMaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaker.Location = new System.Drawing.Point(3, 18);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Properties.ReadOnly = true;
            this.txtMaker.Size = new System.Drawing.Size(118, 20);
            this.txtMaker.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtCollectType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(268, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 44);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collect Type";
            // 
            // txtCollectType
            // 
            this.txtCollectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCollectType.Location = new System.Drawing.Point(3, 18);
            this.txtCollectType.Name = "txtCollectType";
            this.txtCollectType.Properties.ReadOnly = true;
            this.txtCollectType.Size = new System.Drawing.Size(102, 20);
            this.txtCollectType.TabIndex = 1;
            // 
            // FrmTagAddProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 402);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.exSymbolProperty);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTagAddProperty";
            this.Text = "ADD PLC Tag";
            this.Load += new System.EventHandler(this.FrmTagAddProperty_Load);
            this.grbPLCList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exSymbolProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCollectType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPLCList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
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
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtMaker;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtCollectType;
        private DevExpress.XtraEditors.SimpleButton btnValidTag;
    }
}