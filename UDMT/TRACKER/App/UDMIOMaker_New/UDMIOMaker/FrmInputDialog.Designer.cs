namespace UDMIOMaker
{
    partial class FrmInputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputDialog));
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.spnModule = new DevExpress.XtraEditors.SpinEdit();
            this.lblModule = new DevExpress.XtraEditors.LabelControl();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.White;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessage.Controls.Add(this.spnModule);
            this.pnlMessage.Controls.Add(this.lblModule);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.txtInput);
            this.pnlMessage.Controls.Add(this.lblAlertMessage);
            this.pnlMessage.Controls.Add(this.pnlImage);
            this.pnlMessage.Controls.Add(this.lblTitle);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(224, 173);
            this.pnlMessage.TabIndex = 2;
            // 
            // spnModule
            // 
            this.spnModule.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnModule.Location = new System.Drawing.Point(166, 146);
            this.spnModule.Name = "spnModule";
            this.spnModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnModule.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnModule.Size = new System.Drawing.Size(44, 20);
            this.spnModule.TabIndex = 14;
            // 
            // lblModule
            // 
            this.lblModule.Location = new System.Drawing.Point(62, 149);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(98, 14);
            this.lblModule.TabIndex = 13;
            this.lblModule.Text = "Module Number : ";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(59, 61);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(165, 29);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "Please enter a text below...";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(11, 110);
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
            this.pnlImage.Location = new System.Drawing.Point(18, 54);
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
            this.lblTitle.Size = new System.Drawing.Size(108, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Please Input Text";
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
            this.btnCancel.Location = new System.Drawing.Point(169, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 173);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(224, 30);
            this.panelControl1.TabIndex = 4;
            // 
            // FrmInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 203);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInputDialog";
            this.Text = "Input Dialog";
            this.Load += new System.EventHandler(this.FrmInputDialog_Load);
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SpinEdit spnModule;
        private DevExpress.XtraEditors.LabelControl lblModule;
        private DevExpress.XtraEditors.PanelControl panelControl1;

    }
}