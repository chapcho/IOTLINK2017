namespace UDMTrackerSimple
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
            this.panel2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panel1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 628);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 628);
            this.panel1.TabIndex = 3;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.AutoScroll = true;
            this.sptMain.Panel1.Controls.Add(this.panel1);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.AutoScroll = true;
            this.sptMain.Panel2.Controls.Add(this.panel2);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1027, 628);
            this.sptMain.SplitterPosition = 662;
            this.sptMain.TabIndex = 4;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // UCErrorListPanelS
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.sptMain);
            this.Name = "UCErrorListPanelS";
            this.Size = new System.Drawing.Size(1027, 628);
            this.Load += new System.EventHandler(this.UCErrorListPanelS_Load);
            this.Resize += new System.EventHandler(this.UCErrorListPanelS_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl panel2;
        private DevExpress.XtraEditors.XtraScrollableControl panel1;
        private UDM.UI.MySplitContainerControl sptMain;
    }
}
