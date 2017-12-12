namespace NewIOMaker.Form.Form_MultiCopy
{
    partial class MCTextBox
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
            this.MCrichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // MCrichTextBox
            // 
            this.MCrichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MCrichTextBox.Location = new System.Drawing.Point(0, 0);
            this.MCrichTextBox.Name = "MCrichTextBox";
            this.MCrichTextBox.Size = new System.Drawing.Size(604, 466);
            this.MCrichTextBox.TabIndex = 0;
            this.MCrichTextBox.Text = "";
            // 
            // MCTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MCrichTextBox);
            this.Name = "MCTextBox";
            this.Size = new System.Drawing.Size(604, 466);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox MCrichTextBox;
    }
}
