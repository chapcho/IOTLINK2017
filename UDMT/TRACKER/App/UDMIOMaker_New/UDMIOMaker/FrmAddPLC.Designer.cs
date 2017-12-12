namespace UDMIOMaker
{
    partial class FrmAddPLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPLC));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.cboPLCMaker = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCMaker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 193);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(229, 30);
            this.panelControl1.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(174, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.White;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessage.Controls.Add(this.cboPLCMaker);
            this.pnlMessage.Controls.Add(this.labelControl1);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.txtInput);
            this.pnlMessage.Controls.Add(this.lblAlertMessage);
            this.pnlMessage.Controls.Add(this.pnlImage);
            this.pnlMessage.Controls.Add(this.lblTitle);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(229, 193);
            this.pnlMessage.TabIndex = 6;
            // 
            // cboPLCMaker
            // 
            this.cboPLCMaker.Location = new System.Drawing.Point(11, 158);
            this.cboPLCMaker.Name = "cboPLCMaker";
            this.cboPLCMaker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCMaker.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCMaker.Size = new System.Drawing.Size(199, 20);
            this.cboPLCMaker.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 138);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 14);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "PLC Maker";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(49, 57);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(175, 29);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "추가하고자 하는 PLC의 이름과\r\nMaker를 선택하세요.";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(11, 108);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(199, 22);
            this.txtInput.TabIndex = 11;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblAlertMessage
            // 
            this.lblAlertMessage.AutoSize = true;
            this.lblAlertMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertMessage.ForeColor = System.Drawing.Color.Red;
            this.lblAlertMessage.Location = new System.Drawing.Point(107, 194);
            this.lblAlertMessage.Name = "lblAlertMessage";
            this.lblAlertMessage.Size = new System.Drawing.Size(0, 14);
            this.lblAlertMessage.TabIndex = 3;
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlImage.BackgroundImage")));
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImage.Location = new System.Drawing.Point(9, 54);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(34, 32);
            this.pnlImage.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(11, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ADD PLC";
            // 
            // FrmAddPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 223);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddPLC";
            this.Text = "새로운 PLC 심볼 파일 생성";
            this.Load += new System.EventHandler(this.FrmAddPLC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCMaker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel pnlMessage;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCMaker;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Label lblTitle;
    }
}