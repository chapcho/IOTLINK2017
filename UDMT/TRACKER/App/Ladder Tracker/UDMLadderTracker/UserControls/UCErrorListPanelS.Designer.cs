namespace UDMLadderTracker
{
    partial class UCErrorListPanelS
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
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            this.panel2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panel1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.SuspendLayout();
            // 
            // sptMain
            // 
            this.sptMain.Location = new System.Drawing.Point(581, 0);
            this.sptMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(6, 807);
            this.sptMain.TabIndex = 1;
            this.sptMain.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(587, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 807);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 807);
            this.panel1.TabIndex = 3;
            // 
            // UCErrorListPanelS
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCErrorListPanelS";
            this.Size = new System.Drawing.Size(1174, 807);
            this.Load += new System.EventHandler(this.UCErrorListPanelS_Load);
            this.Resize += new System.EventHandler(this.UCErrorListPanelS_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraEditors.XtraScrollableControl panel2;
        private DevExpress.XtraEditors.XtraScrollableControl panel1;
    }
}
