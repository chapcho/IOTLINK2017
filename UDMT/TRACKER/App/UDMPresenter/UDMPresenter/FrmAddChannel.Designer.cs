namespace UDMPresenter
{
    partial class FrmAddChannel
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
            this.lblConnectionType = new DevExpress.XtraEditors.LabelControl();
            this.cmbConnectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbConnectionType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Location = new System.Drawing.Point(22, 28);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(128, 14);
            this.lblConnectionType.TabIndex = 0;
            this.lblConnectionType.Text = "통신 타입을 설정하세요";
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.EditValue = "DDEA";
            this.cmbConnectionType.Enabled = false;
            this.cmbConnectionType.Location = new System.Drawing.Point(22, 48);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbConnectionType.Properties.Items.AddRange(new object[] {
            "DDEA",
            "OPC"});
            this.cmbConnectionType.Size = new System.Drawing.Size(199, 20);
            this.cmbConnectionType.TabIndex = 1;
            this.cmbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cmbConnectionType_SelectedIndexChanged);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(22, 120);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(199, 22);
            this.txtInput.TabIndex = 12;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(19, 88);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(202, 29);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Channel과 Device 명을 입력하세요\r\nex) Channel.Device1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 22);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(22, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 22);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Add";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmAddChannel
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 194);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.cmbConnectionType);
            this.Controls.Add(this.lblConnectionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddChannel";
            this.ShowIcon = false;
            this.Text = "Add Channel";
            ((System.ComponentModel.ISupportInitialize)(this.cmbConnectionType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblConnectionType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbConnectionType;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;

    }
}