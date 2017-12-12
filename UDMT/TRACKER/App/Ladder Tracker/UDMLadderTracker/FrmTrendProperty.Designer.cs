namespace UDMTrackerSimple
{
    partial class FrmTrendProperty
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
            this.ucTrendProperty = new UDM.Project.UCTrendProperty();
            this.SuspendLayout();
            // 
            // ucTrendProperty
            // 
            this.ucTrendProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTrendProperty.Editable = true;
            this.ucTrendProperty.Location = new System.Drawing.Point(0, 0);
            this.ucTrendProperty.Name = "ucTrendProperty";
            this.ucTrendProperty.Size = new System.Drawing.Size(404, 395);
            this.ucTrendProperty.Symbol = null;
            this.ucTrendProperty.TabIndex = 0;
            // 
            // FrmTrendProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 395);
            this.Controls.Add(this.ucTrendProperty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmTrendProperty";
            this.Text = "Trend Property";
            this.Load += new System.EventHandler(this.FrmTrendProperty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UDM.Project.UCTrendProperty ucTrendProperty;
    }
}