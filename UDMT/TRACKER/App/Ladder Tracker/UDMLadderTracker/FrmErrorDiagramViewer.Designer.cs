namespace UDMLadderTracker
{
    partial class FrmErrorDiagramViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmErrorDiagramViewer));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.exBarManagerDiagram = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnDiagramZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramMaximize = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagramMinimize = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.ucLogicDiagramS = new UDM.LogicViewer.UCLogicDiagramS();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "ZoomIn_16x16.png");
            this.imgList.Images.SetKeyName(1, "ZoomOut_16x16.png");
            this.imgList.Images.SetKeyName(2, "MoveUp_16x16.png");
            this.imgList.Images.SetKeyName(3, "MoveDown_16x16.png");
            this.imgList.Images.SetKeyName(4, "Squeeze_16x16.png");
            this.imgList.Images.SetKeyName(5, "Stretch_16x16.png");
            // 
            // exBarManagerDiagram
            // 
            this.exBarManagerDiagram.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl1);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl2);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl3);
            this.exBarManagerDiagram.DockControls.Add(this.barDockControl4);
            this.exBarManagerDiagram.Form = this;
            this.exBarManagerDiagram.Images = this.imgList;
            this.exBarManagerDiagram.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDiagramZoomIn,
            this.btnDiagramZoomOut,
            this.btnDiagramMaximize,
            this.btnDiagramMinimize});
            this.exBarManagerDiagram.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramZoomIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramZoomOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramMaximize, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDiagramMinimize, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawSizeGrip = true;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Tools";
            // 
            // btnDiagramZoomIn
            // 
            this.btnDiagramZoomIn.Caption = "Zoom In";
            this.btnDiagramZoomIn.Id = 0;
            this.btnDiagramZoomIn.ImageIndex = 0;
            this.btnDiagramZoomIn.Name = "btnDiagramZoomIn";
            // 
            // btnDiagramZoomOut
            // 
            this.btnDiagramZoomOut.Caption = "Zoom Out";
            this.btnDiagramZoomOut.Id = 1;
            this.btnDiagramZoomOut.ImageIndex = 1;
            this.btnDiagramZoomOut.Name = "btnDiagramZoomOut";
            // 
            // btnDiagramMaximize
            // 
            this.btnDiagramMaximize.Caption = "Maximize";
            this.btnDiagramMaximize.Id = 2;
            this.btnDiagramMaximize.ImageIndex = 5;
            this.btnDiagramMaximize.Name = "btnDiagramMaximize";
            this.btnDiagramMaximize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramMaximize_ItemClick);
            // 
            // btnDiagramMinimize
            // 
            this.btnDiagramMinimize.Caption = "Minimize";
            this.btnDiagramMinimize.Id = 3;
            this.btnDiagramMinimize.ImageIndex = 4;
            this.btnDiagramMinimize.Name = "btnDiagramMinimize";
            this.btnDiagramMinimize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagramMinimize_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1008, 31);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 730);
            this.barDockControl2.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 699);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1008, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 699);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ucLogicDiagramS);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1008, 699);
            this.pnlMain.TabIndex = 5;
            // 
            // ucLogicDiagramS
            // 
            this.ucLogicDiagramS.BackColor = System.Drawing.Color.White;
            this.ucLogicDiagramS.ContextTabMenuStrip = null;
            this.ucLogicDiagramS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogicDiagramS.FocusedTab = null;
            this.ucLogicDiagramS.Location = new System.Drawing.Point(2, 2);
            this.ucLogicDiagramS.Name = "ucLogicDiagramS";
            this.ucLogicDiagramS.Size = new System.Drawing.Size(1004, 695);
            this.ucLogicDiagramS.TabIndex = 8;
            // 
            // FrmErrorDiagramViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmErrorDiagramViewer";
            this.Text = "Error Diagram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmErrorDiagramViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManagerDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraBars.BarManager exBarManagerDiagram;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnDiagramZoomIn;
        private DevExpress.XtraBars.BarButtonItem btnDiagramZoomOut;
        private DevExpress.XtraBars.BarButtonItem btnDiagramMaximize;
        private DevExpress.XtraBars.BarButtonItem btnDiagramMinimize;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private UDM.LogicViewer.UCLogicDiagramS ucLogicDiagramS;
    }
}