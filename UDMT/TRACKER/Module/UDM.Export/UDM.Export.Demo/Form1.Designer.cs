namespace UDM.Export.Demo
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
            this.button_Open = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.dataGridView_PLC = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PLC)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(33, 23);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(153, 108);
            this.button_Open.TabIndex = 0;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(377, 23);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(153, 108);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // dataGridView_PLC
            // 
            this.dataGridView_PLC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_PLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PLC.Location = new System.Drawing.Point(35, 159);
            this.dataGridView_PLC.Name = "dataGridView_PLC";
            this.dataGridView_PLC.RowTemplate.Height = 23;
            this.dataGridView_PLC.Size = new System.Drawing.Size(494, 333);
            this.dataGridView_PLC.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 508);
            this.Controls.Add(this.dataGridView_PLC);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.button_Open);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.DataGridView dataGridView_PLC;
    }
}

