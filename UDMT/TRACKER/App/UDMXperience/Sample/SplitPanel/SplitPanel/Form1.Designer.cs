namespace SplitPanel
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ucSplitPanel1 = new SplitPanel.UserControls.UCSplitPanel(this.components);
            this.ucSplitPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucSplitPanel1
            // 
            this.ucSplitPanel1.BackColor = System.Drawing.Color.White;
            // 
            // ucSplitPanel1.BodyPanel
            // 
            this.ucSplitPanel1.BodyPanel.BackColor = System.Drawing.Color.White;
            this.ucSplitPanel1.BodyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSplitPanel1.BodyPanel.Location = new System.Drawing.Point(0, 140);
            this.ucSplitPanel1.BodyPanel.Name = "BodyPanel";
            this.ucSplitPanel1.BodyPanel.Size = new System.Drawing.Size(411, 167);
            this.ucSplitPanel1.BodyPanel.TabIndex = 0;
            // 
            // ucSplitPanel1.HeaderPanel
            // 
            this.ucSplitPanel1.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.ucSplitPanel1.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSplitPanel1.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.ucSplitPanel1.HeaderPanel.Name = "HeaderPanel";
            this.ucSplitPanel1.HeaderPanel.Size = new System.Drawing.Size(411, 90);
            this.ucSplitPanel1.HeaderPanel.TabIndex = 0;
            this.ucSplitPanel1.Location = new System.Drawing.Point(123, 73);
            this.ucSplitPanel1.Name = "ucSplitPanel1";
            this.ucSplitPanel1.Size = new System.Drawing.Size(411, 307);
            this.ucSplitPanel1.SplitterColor = System.Drawing.Color.LightGray;
            this.ucSplitPanel1.SplitterHeight = 100;
            this.ucSplitPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 455);
            this.Controls.Add(this.ucSplitPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ucSplitPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCSplitPanel ucSplitPanel1;







    }
}

