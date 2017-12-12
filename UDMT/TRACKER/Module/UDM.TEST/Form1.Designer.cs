namespace UDM.TEST
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
            this.button_Siemens_Import = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Siemens_Import
            // 
            this.button_Siemens_Import.Location = new System.Drawing.Point(24, 26);
            this.button_Siemens_Import.Name = "button_Siemens_Import";
            this.button_Siemens_Import.Size = new System.Drawing.Size(128, 47);
            this.button_Siemens_Import.TabIndex = 0;
            this.button_Siemens_Import.Text = "1. Siemens AWL";
            this.button_Siemens_Import.UseVisualStyleBackColor = true;
            this.button_Siemens_Import.Click += new System.EventHandler(this.button_Siemens_Import_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.button_Siemens_Import);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Siemens_Import;
    }
}

