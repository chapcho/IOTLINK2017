namespace UDM.Ladder
{
    partial class UCLadderStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLadderStep));
            this.pnlView = new System.Windows.Forms.Panel();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.chkView = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pnlZoom = new System.Windows.Forms.Panel();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkScrollable = new DevExpress.XtraEditors.CheckEdit();
            this.pnlText = new DevExpress.XtraEditors.PanelControl();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.ucCanvas = new UDM.Ladder.UCCanvas();
            this.pnlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.pnlZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkScrollable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).BeginInit();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.BackColor = System.Drawing.SystemColors.Control;
            this.pnlView.Controls.Add(this.ucCanvas);
            this.pnlView.Controls.Add(this.pnlTop);
            this.pnlView.Controls.Add(this.pnlText);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(715, 460);
            this.pnlView.TabIndex = 5;
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblText.Location = new System.Drawing.Point(33, 8);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(51, 24);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "TEXT";
            // 
            // chkView
            // 
            this.chkView.EditValue = true;
            this.chkView.Location = new System.Drawing.Point(9, 11);
            this.chkView.Name = "chkView";
            this.chkView.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.chkView.Properties.Appearance.Options.UseFont = true;
            this.chkView.Properties.AutoHeight = false;
            this.chkView.Properties.Caption = "";
            this.chkView.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkView.Size = new System.Drawing.Size(20, 20);
            this.chkView.TabIndex = 1;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(715, 3);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(715, 3);
            this.panelControl3.TabIndex = 3;
            // 
            // pnlZoom
            // 
            this.pnlZoom.Controls.Add(this.panel1);
            this.pnlZoom.Controls.Add(this.btnZoomOut);
            this.pnlZoom.Controls.Add(this.btnZoomIn);
            this.pnlZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlZoom.Location = new System.Drawing.Point(630, 3);
            this.pnlZoom.Name = "pnlZoom";
            this.pnlZoom.Size = new System.Drawing.Size(85, 34);
            this.pnlZoom.TabIndex = 8;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnZoomIn.Appearance.Options.UseBackColor = true;
            this.btnZoomIn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnZoomIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnZoomIn.Location = new System.Drawing.Point(0, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(40, 34);
            this.btnZoomIn.TabIndex = 8;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnZoomOut.Appearance.Options.UseBackColor = true;
            this.btnZoomOut.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnZoomOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnZoomOut.Location = new System.Drawing.Point(40, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 34);
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(80, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 34);
            this.panel1.TabIndex = 11;
            // 
            // chkScrollable
            // 
            this.chkScrollable.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkScrollable.Location = new System.Drawing.Point(550, 3);
            this.chkScrollable.Name = "chkScrollable";
            this.chkScrollable.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkScrollable.Properties.Appearance.Options.UseFont = true;
            this.chkScrollable.Properties.AutoHeight = false;
            this.chkScrollable.Properties.Caption = "Use Scroll";
            this.chkScrollable.Size = new System.Drawing.Size(80, 34);
            this.chkScrollable.TabIndex = 9;
            this.chkScrollable.CheckedChanged += new System.EventHandler(this.chkScrollable_CheckedChanged);
            // 
            // pnlText
            // 
            this.pnlText.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlText.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlText.Appearance.Options.UseBackColor = true;
            this.pnlText.Appearance.Options.UseFont = true;
            this.pnlText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlText.Controls.Add(this.chkScrollable);
            this.pnlText.Controls.Add(this.pnlZoom);
            this.pnlText.Controls.Add(this.panelControl3);
            this.pnlText.Controls.Add(this.panelControl1);
            this.pnlText.Controls.Add(this.chkView);
            this.pnlText.Controls.Add(this.lblText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.Location = new System.Drawing.Point(0, 0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(715, 40);
            this.pnlText.TabIndex = 12;
            this.pnlText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlText_MouseDown);
            this.pnlText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlText_MouseMove);
            this.pnlText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlText_MouseUp);
            // 
            // pnlTop
            // 
            this.pnlTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Appearance.Options.UseBackColor = true;
            this.pnlTop.Appearance.Options.UseFont = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 40);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(715, 5);
            this.pnlTop.TabIndex = 20;
            // 
            // ucCanvas
            // 
            this.ucCanvas.AutoSize = true;
            this.ucCanvas.Debugable = true;
            this.ucCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCanvas.Dragable = true;
            this.ucCanvas.GridShow = true;
            this.ucCanvas.InfoShow = true;
            this.ucCanvas.Location = new System.Drawing.Point(0, 45);
            this.ucCanvas.Name = "ucCanvas";
            this.ucCanvas.OriginShow = true;
            this.ucCanvas.RulerShow = true;
            this.ucCanvas.ScaleFactor = 1F;
            this.ucCanvas.Scrollable = false;
            this.ucCanvas.Size = new System.Drawing.Size(715, 415);
            this.ucCanvas.TabIndex = 21;
            this.ucCanvas.Zoomable = false;
            this.ucCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucCanvas_MouseDown);
            this.ucCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucCanvas_MouseMove);
            this.ucCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucCanvas_MouseUp);
            // 
            // UCLadderStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlView);
            this.Name = "UCLadderStep";
            this.Size = new System.Drawing.Size(715, 460);
            this.Resize += new System.EventHandler(this.UCLadderStep_Resize);
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.pnlZoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkScrollable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).EndInit();
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
        private DevExpress.XtraEditors.PanelControl pnlText;
        private DevExpress.XtraEditors.CheckEdit chkScrollable;
        private System.Windows.Forms.Panel pnlZoom;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkView;
        private DevExpress.XtraEditors.LabelControl lblText;
        private UCCanvas ucCanvas;
        private DevExpress.XtraEditors.PanelControl pnlTop;


    }
}
