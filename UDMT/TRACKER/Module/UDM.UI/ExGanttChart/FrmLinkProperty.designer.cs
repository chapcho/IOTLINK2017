namespace UDM.UI.ExGanttChart
{
    partial class FrmLinkProperty
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbFromPoint = new System.Windows.Forms.ComboBox();
            this.cmbToPoint = new System.Windows.Forms.ComboBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Enabled = false;
            this.txtFrom.Location = new System.Drawing.Point(72, 15);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(142, 21);
            this.txtFrom.TabIndex = 3;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(14, 18);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 12);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // cmbFromPoint
            // 
            this.cmbFromPoint.FormattingEnabled = true;
            this.cmbFromPoint.Location = new System.Drawing.Point(217, 15);
            this.cmbFromPoint.Name = "cmbFromPoint";
            this.cmbFromPoint.Size = new System.Drawing.Size(67, 20);
            this.cmbFromPoint.TabIndex = 4;
            // 
            // cmbToPoint
            // 
            this.cmbToPoint.FormattingEnabled = true;
            this.cmbToPoint.Location = new System.Drawing.Point(217, 39);
            this.cmbToPoint.Name = "cmbToPoint";
            this.cmbToPoint.Size = new System.Drawing.Size(67, 20);
            this.cmbToPoint.TabIndex = 7;
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(72, 39);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(142, 21);
            this.txtTo.TabIndex = 6;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(12, 42);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 12);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 67);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(30, 12);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Text";
            // 
            // txtText
            // 
            this.txtText.Enabled = false;
            this.txtText.Location = new System.Drawing.Point(72, 63);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(142, 21);
            this.txtText.TabIndex = 6;
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 22);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 22);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmLinkProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 139);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbToPoint);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cmbFromPoint);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmLinkProperty";
            this.Text = "Link Property";
            this.Load += new System.EventHandler(this.FrmLinkProperty_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLinkProperty_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cmbFromPoint;
        private System.Windows.Forms.ComboBox cmbToPoint;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}