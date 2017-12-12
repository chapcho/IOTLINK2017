namespace UDMPresenter
{
    partial class FrmAddTag
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
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spnAddCount = new DevExpress.XtraEditors.SpinEdit();
            this.txtComment = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.cmbDataType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnAddCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnAdd);
            this.grpControl.Controls.Add(this.panel1);
            this.grpControl.Controls.Add(this.btnClose);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpControl.Location = new System.Drawing.Point(0, 155);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(355, 53);
            this.grpControl.TabIndex = 0;
            this.grpControl.Text = "Control";
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(211, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(277, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(287, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spnAddCount);
            this.groupControl1.Controls.Add(this.txtComment);
            this.groupControl1.Controls.Add(this.txtAddress);
            this.groupControl1.Controls.Add(this.cmbDataType);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(355, 155);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "추가 Tag 설정";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(39, 118);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Add Count : ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 92);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Comment : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Data Type : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Address : ";
            // 
            // spnAddCount
            // 
            this.spnAddCount.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnAddCount.Location = new System.Drawing.Point(115, 115);
            this.spnAddCount.Name = "spnAddCount";
            this.spnAddCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnAddCount.Properties.IsFloatValue = false;
            this.spnAddCount.Properties.Mask.EditMask = "N00";
            this.spnAddCount.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spnAddCount.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnAddCount.Size = new System.Drawing.Size(113, 20);
            this.spnAddCount.TabIndex = 4;
            this.spnAddCount.ToolTip = "연속적으로 생성할 갯수를 입력한다.";
            // 
            // txtComment
            // 
            this.txtComment.EditValue = "User Create ";
            this.txtComment.Location = new System.Drawing.Point(115, 89);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(217, 20);
            this.txtComment.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(115, 36);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(113, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // cmbDataType
            // 
            this.cmbDataType.EditValue = "BOOL";
            this.cmbDataType.Location = new System.Drawing.Point(115, 62);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbDataType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataType.Properties.Items.AddRange(new object[] {
            "BOOL",
            "WORD",
            "DWORD"});
            this.cmbDataType.Size = new System.Drawing.Size(113, 20);
            this.cmbDataType.TabIndex = 0;
            // 
            // FrmAddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 208);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAddTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag 설정";
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnAddCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spnAddCount;
        private DevExpress.XtraEditors.TextEdit txtComment;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDataType;
    }
}