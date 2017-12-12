namespace SmartEnergyVision.UserControls
{
    partial class UCTileItem
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ucMonoImage = new SmartEnergyVision.UCMonoImage(this.components);
            this.pnlTail = new System.Windows.Forms.Panel();
            this.lblTailRight = new System.Windows.Forms.Label();
            this.lblTailLeft = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucMonoImage)).BeginInit();
            this.pnlTail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.ucMonoImage);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(5, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(585, 32);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(32, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(553, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Real-Time Clock";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMonoImage
            // 
            this.ucMonoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucMonoImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMonoImage.Image = null;
            this.ucMonoImage.ImageColor = System.Drawing.Color.White;
            this.ucMonoImage.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucMonoImage.Location = new System.Drawing.Point(0, 0);
            this.ucMonoImage.Name = "ucMonoImage";
            this.ucMonoImage.Size = new System.Drawing.Size(32, 32);
            this.ucMonoImage.TabIndex = 2;
            this.ucMonoImage.TabStop = false;
            // 
            // pnlTail
            // 
            this.pnlTail.Controls.Add(this.lblTailRight);
            this.pnlTail.Controls.Add(this.lblTailLeft);
            this.pnlTail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTail.Location = new System.Drawing.Point(5, 199);
            this.pnlTail.Name = "pnlTail";
            this.pnlTail.Size = new System.Drawing.Size(585, 20);
            this.pnlTail.TabIndex = 4;
            // 
            // lblTailRight
            // 
            this.lblTailRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTailRight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTailRight.ForeColor = System.Drawing.Color.White;
            this.lblTailRight.Location = new System.Drawing.Point(482, 0);
            this.lblTailRight.Name = "lblTailRight";
            this.lblTailRight.Size = new System.Drawing.Size(103, 20);
            this.lblTailRight.TabIndex = 1;
            this.lblTailRight.Text = "FootNote";
            this.lblTailRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTailLeft
            // 
            this.lblTailLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTailLeft.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTailLeft.ForeColor = System.Drawing.Color.White;
            this.lblTailLeft.Location = new System.Drawing.Point(0, 0);
            this.lblTailLeft.Name = "lblTailLeft";
            this.lblTailLeft.Size = new System.Drawing.Size(103, 20);
            this.lblTailLeft.TabIndex = 0;
            this.lblTailLeft.Text = "Status";
            this.lblTailLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCTileItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTail);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCTileItem";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(595, 224);
            this.Load += new System.EventHandler(this.UCTileItem_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucMonoImage)).EndInit();
            this.pnlTail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private UCMonoImage ucMonoImage;
        private System.Windows.Forms.Panel pnlTail;
        private System.Windows.Forms.Label lblTailRight;
        private System.Windows.Forms.Label lblTailLeft;
    }
}
