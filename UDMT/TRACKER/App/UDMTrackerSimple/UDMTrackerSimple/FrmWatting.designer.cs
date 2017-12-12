namespace UDMTrackerSimple
{
    partial class FrmWatting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWatting));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogo = new DevExpress.XtraEditors.PanelControl();
            this.lblCopy = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.pnlProgress = new DevExpress.XtraEditors.PanelControl();
            this.lblPrograssText = new DevExpress.XtraEditors.LabelControl();
            this.progressWat = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.pnlMessage = new DevExpress.XtraEditors.PanelControl();
            this.lblSmallText = new DevExpress.XtraEditors.LabelControl();
            this.lblBigText = new DevExpress.XtraEditors.LabelControl();
            this.pnlSpace2 = new DevExpress.XtraEditors.PanelControl();
            this.pnlSpace1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogo)).BeginInit();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProgress)).BeginInit();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressWat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pnlLogo, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.pnlProgress, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.pnlMessage, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 13, 0, 13);
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(768, 412);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlLogo.Appearance.Options.UseBackColor = true;
            this.pnlLogo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLogo.Controls.Add(this.lblCopy);
            this.pnlLogo.Controls.Add(this.linkLabel);
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogo.Location = new System.Drawing.Point(4, 324);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(760, 71);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblCopy
            // 
            this.lblCopy.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCopy.Location = new System.Drawing.Point(17, 17);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(278, 16);
            this.lblCopy.TabIndex = 2;
            this.lblCopy.Text = "Copyright (C) 2006 UDMTEK All Rights Reserved.";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(14, 41);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(148, 14);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "http://www.udmtek.com";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.EditValue = ((object)(resources.GetObject("picLogo.EditValue")));
            this.picLogo.Location = new System.Drawing.Point(567, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLogo.Size = new System.Drawing.Size(193, 54);
            this.picLogo.TabIndex = 0;
            this.picLogo.ToolTip = "Click on the graphic to go to the UDMTEK website.";
            this.picLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLogo_MouseClick);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlProgress.Controls.Add(this.lblPrograssText);
            this.pnlProgress.Controls.Add(this.progressWat);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProgress.Location = new System.Drawing.Point(4, 228);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(760, 89);
            this.pnlProgress.TabIndex = 1;
            // 
            // lblPrograssText
            // 
            this.lblPrograssText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrograssText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPrograssText.Location = new System.Drawing.Point(76, 13);
            this.lblPrograssText.Name = "lblPrograssText";
            this.lblPrograssText.Size = new System.Drawing.Size(606, 20);
            this.lblPrograssText.TabIndex = 1;
            this.lblPrograssText.Text = "Watting...";
            // 
            // progressWat
            // 
            this.progressWat.EditValue = 0;
            this.progressWat.Location = new System.Drawing.Point(76, 39);
            this.progressWat.Name = "progressWat";
            this.progressWat.Properties.EndColor = System.Drawing.Color.Blue;
            this.progressWat.Properties.StartColor = System.Drawing.SystemColors.HotTrack;
            this.progressWat.Size = new System.Drawing.Size(606, 24);
            this.progressWat.TabIndex = 0;
            // 
            // pnlMessage
            // 
            this.pnlMessage.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlMessage.Appearance.Options.UseBackColor = true;
            this.pnlMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMessage.Controls.Add(this.lblSmallText);
            this.pnlMessage.Controls.Add(this.lblBigText);
            this.pnlMessage.Controls.Add(this.pnlSpace2);
            this.pnlMessage.Controls.Add(this.pnlSpace1);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(4, 17);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(760, 204);
            this.pnlMessage.TabIndex = 2;
            // 
            // lblSmallText
            // 
            this.lblSmallText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSmallText.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSmallText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblSmallText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSmallText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSmallText.Location = new System.Drawing.Point(16, 83);
            this.lblSmallText.Name = "lblSmallText";
            this.lblSmallText.Size = new System.Drawing.Size(728, 118);
            this.lblSmallText.TabIndex = 3;
            this.lblSmallText.Text = "E:\\00_UDMTek\\00_소스\\01_Tracker\\bTracker_20170814\\DYK32_RH_22.umpp";
            // 
            // lblBigText
            // 
            this.lblBigText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBigText.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBigText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBigText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblBigText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBigText.Location = new System.Drawing.Point(16, 3);
            this.lblBigText.Name = "lblBigText";
            this.lblBigText.Size = new System.Drawing.Size(728, 87);
            this.lblBigText.TabIndex = 2;
            this.lblBigText.Text = "Open";
            // 
            // pnlSpace2
            // 
            this.pnlSpace2.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSpace2.Appearance.Options.UseBackColor = true;
            this.pnlSpace2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpace2.Location = new System.Drawing.Point(750, 0);
            this.pnlSpace2.Name = "pnlSpace2";
            this.pnlSpace2.Size = new System.Drawing.Size(10, 204);
            this.pnlSpace2.TabIndex = 1;
            // 
            // pnlSpace1
            // 
            this.pnlSpace1.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSpace1.Appearance.Options.UseBackColor = true;
            this.pnlSpace1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpace1.Location = new System.Drawing.Point(0, 0);
            this.pnlSpace1.Name = "pnlSpace1";
            this.pnlSpace1.Size = new System.Drawing.Size(10, 204);
            this.pnlSpace1.TabIndex = 0;
            // 
            // FrmWatting
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 412);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmWatting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmWatting_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogo)).EndInit();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProgress)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressWat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraEditors.PanelControl pnlLogo;
        private DevExpress.XtraEditors.PanelControl pnlProgress;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressWat;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl lblPrograssText;
        private DevExpress.XtraEditors.PanelControl pnlMessage;
        private DevExpress.XtraEditors.LabelControl lblBigText;
        private DevExpress.XtraEditors.PanelControl pnlSpace2;
        private DevExpress.XtraEditors.PanelControl pnlSpace1;
        private System.Windows.Forms.LinkLabel linkLabel;
        private DevExpress.XtraEditors.LabelControl lblCopy;
        private DevExpress.XtraEditors.LabelControl lblSmallText;

    }
}