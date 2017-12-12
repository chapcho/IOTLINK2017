namespace UDMSPDManager
{
    partial class UCUnitView
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnData = new DevExpress.XtraEditors.SimpleButton();
            this.lblLogCount = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(290, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 90);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 90);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 10);
            this.panel5.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 10);
            this.panel3.TabIndex = 7;
            // 
            // btnData
            // 
            this.btnData.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnData.Appearance.BackColor2 = System.Drawing.Color.Green;
            this.btnData.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnData.Appearance.Font = new System.Drawing.Font("HY신명조", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnData.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnData.Appearance.Options.UseBackColor = true;
            this.btnData.Appearance.Options.UseBorderColor = true;
            this.btnData.Appearance.Options.UseFont = true;
            this.btnData.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnData.Location = new System.Drawing.Point(10, 10);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(280, 70);
            this.btnData.TabIndex = 8;
            this.btnData.Text = "S233\r\nCLAMP 1";
            // 
            // lblLogCount
            // 
            this.lblLogCount.Appearance.BackColor = System.Drawing.Color.GreenYellow;
            this.lblLogCount.Appearance.Font = new System.Drawing.Font("HY신명조", 15F);
            this.lblLogCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLogCount.Location = new System.Drawing.Point(277, 10);
            this.lblLogCount.Name = "lblLogCount";
            this.lblLogCount.Size = new System.Drawing.Size(13, 20);
            this.lblLogCount.TabIndex = 0;
            this.lblLogCount.Text = "0";
            // 
            // UCUnitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLogCount);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "UCUnitView";
            this.Size = new System.Drawing.Size(300, 90);
            this.Load += new System.EventHandler(this.UCUnitView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnData;
        private DevExpress.XtraEditors.LabelControl lblLogCount;

    }
}
