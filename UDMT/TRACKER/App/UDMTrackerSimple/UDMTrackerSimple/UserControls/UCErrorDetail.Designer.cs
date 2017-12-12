namespace UDMTrackerSimple
{
    partial class UCErrorDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCErrorDetail));
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpErrorList = new DevExpress.XtraTab.XtraTabPage();
            this.ucGrid = new UDMTrackerSimple.UserControls.UCErrorLogGrid();
            this.tpAnalysis = new DevExpress.XtraTab.XtraTabPage();
            this.tabView = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tpPattern = new DevExpress.XtraTab.XtraTabPage();
            this.pnlPatternResult = new DevExpress.XtraEditors.PanelControl();
            this.ucFlowResultViewer = new UDMTrackerSimple.UCFlowResultGanttViewer();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.exManagerPattern = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarButtonItem();
            this.btnPatternClear = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.btnExportRawData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkAbnormalSymbol = new DevExpress.XtraEditors.CheckButton();
            this.chkUnknownStop = new DevExpress.XtraEditors.CheckButton();
            this.chkCellMerge = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpErrorList.SuspendLayout();
            this.tpAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).BeginInit();
            this.tabView.SuspendLayout();
            this.tpPattern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPatternResult)).BeginInit();
            this.pnlPatternResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exManagerPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 32);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpErrorList;
            this.tabMain.Size = new System.Drawing.Size(939, 600);
            this.tabMain.TabIndex = 4;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpErrorList,
            this.tpAnalysis,
            this.tpPattern});
            // 
            // tpErrorList
            // 
            this.tpErrorList.Controls.Add(this.ucGrid);
            this.tpErrorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Size = new System.Drawing.Size(933, 552);
            this.tpErrorList.Text = "Error List";
            // 
            // ucGrid
            // 
            this.ucGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGrid.Location = new System.Drawing.Point(0, 0);
            this.ucGrid.Name = "ucGrid";
            this.ucGrid.Size = new System.Drawing.Size(933, 552);
            this.ucGrid.TabIndex = 0;
            // 
            // tpAnalysis
            // 
            this.tpAnalysis.Controls.Add(this.tabView);
            this.tpAnalysis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpAnalysis.Name = "tpAnalysis";
            this.tpAnalysis.Size = new System.Drawing.Size(933, 552);
            this.tpAnalysis.Text = "Ladder View";
            // 
            // tabView
            // 
            this.tabView.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.Header.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabView.Location = new System.Drawing.Point(0, 0);
            this.tabView.Name = "tabView";
            this.tabView.SelectedTabPage = this.xtraTabPage1;
            this.tabView.Size = new System.Drawing.Size(933, 552);
            this.tabView.TabIndex = 0;
            this.tabView.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(927, 513);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(927, 513);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // tpPattern
            // 
            this.tpPattern.Controls.Add(this.pnlPatternResult);
            this.tpPattern.Name = "tpPattern";
            this.tpPattern.PageVisible = false;
            this.tpPattern.Size = new System.Drawing.Size(933, 552);
            this.tpPattern.Text = "Pattern View";
            // 
            // pnlPatternResult
            // 
            this.pnlPatternResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPatternResult.Controls.Add(this.ucFlowResultViewer);
            this.pnlPatternResult.Controls.Add(this.barDockControl3);
            this.pnlPatternResult.Controls.Add(this.barDockControl4);
            this.pnlPatternResult.Controls.Add(this.barDockControl2);
            this.pnlPatternResult.Controls.Add(this.barDockControl1);
            this.pnlPatternResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatternResult.Location = new System.Drawing.Point(0, 0);
            this.pnlPatternResult.Name = "pnlPatternResult";
            this.pnlPatternResult.Size = new System.Drawing.Size(933, 552);
            this.pnlPatternResult.TabIndex = 0;
            // 
            // ucFlowResultViewer
            // 
            this.ucFlowResultViewer.BarHeight = 50;
            this.ucFlowResultViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFlowResultViewer.Location = new System.Drawing.Point(0, 31);
            this.ucFlowResultViewer.Name = "ucFlowResultViewer";
            this.ucFlowResultViewer.OverViewHeight = 50;
            this.ucFlowResultViewer.Size = new System.Drawing.Size(933, 498);
            this.ucFlowResultViewer.TabIndex = 9;
            this.ucFlowResultViewer.UnitHeight = 26;
            this.ucFlowResultViewer.UnitWidth = 20;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 31);
            this.barDockControl3.Size = new System.Drawing.Size(0, 498);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(933, 31);
            this.barDockControl4.Size = new System.Drawing.Size(0, 498);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 529);
            this.barDockControl2.Size = new System.Drawing.Size(933, 23);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(933, 31);
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
            // exManagerPattern
            // 
            this.exManagerPattern.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.exManagerPattern.DockControls.Add(this.barDockControl1);
            this.exManagerPattern.DockControls.Add(this.barDockControl2);
            this.exManagerPattern.DockControls.Add(this.barDockControl3);
            this.exManagerPattern.DockControls.Add(this.barDockControl4);
            this.exManagerPattern.Form = this.pnlPatternResult;
            this.exManagerPattern.Images = this.imgList;
            this.exManagerPattern.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnPatternClear});
            this.exManagerPattern.MaxItemId = 5;
            this.exManagerPattern.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnZoomIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnZoomOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnItemUp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnItemDown, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPatternClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.DrawSizeGrip = true;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 0;
            this.btnZoomIn.ImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 1;
            this.btnZoomOut.ImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 2;
            this.btnItemUp.ImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 3;
            this.btnItemDown.ImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnPatternClear
            // 
            this.btnPatternClear.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPatternClear.Caption = "Clear";
            this.btnPatternClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPatternClear.Glyph")));
            this.btnPatternClear.Id = 4;
            this.btnPatternClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPatternClear.LargeGlyph")));
            this.btnPatternClear.Name = "btnPatternClear";
            this.btnPatternClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPatternClear_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnExportRawData);
            this.pnlFilter.Controls.Add(this.chkCellMerge);
            this.pnlFilter.Controls.Add(this.labelControl1);
            this.pnlFilter.Controls.Add(this.chkAbnormalSymbol);
            this.pnlFilter.Controls.Add(this.chkUnknownStop);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(939, 32);
            this.pnlFilter.TabIndex = 5;
            // 
            // btnExportRawData
            // 
            this.btnExportRawData.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportRawData.Appearance.Options.UseFont = true;
            this.btnExportRawData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportRawData.Image = ((System.Drawing.Image)(resources.GetObject("btnExportRawData.Image")));
            this.btnExportRawData.Location = new System.Drawing.Point(155, 2);
            this.btnExportRawData.Name = "btnExportRawData";
            this.btnExportRawData.Size = new System.Drawing.Size(188, 28);
            this.btnExportRawData.TabIndex = 6;
            this.btnExportRawData.Text = "Export Raw Error Data";
            this.btnExportRawData.Click += new System.EventHandler(this.btnExportRawData_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(552, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 28);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "  Error Log Filter : ";
            // 
            // chkAbnormalSymbol
            // 
            this.chkAbnormalSymbol.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAbnormalSymbol.Appearance.Options.UseFont = true;
            this.chkAbnormalSymbol.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkAbnormalSymbol.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkAbnormalSymbol.Image = ((System.Drawing.Image)(resources.GetObject("chkAbnormalSymbol.Image")));
            this.chkAbnormalSymbol.Location = new System.Drawing.Point(666, 2);
            this.chkAbnormalSymbol.Name = "chkAbnormalSymbol";
            this.chkAbnormalSymbol.Size = new System.Drawing.Size(141, 28);
            this.chkAbnormalSymbol.TabIndex = 3;
            this.chkAbnormalSymbol.Text = "Error Symbol";
            this.chkAbnormalSymbol.CheckedChanged += new System.EventHandler(this.chkAbnormalSymbol_CheckedChanged);
            // 
            // chkUnknownStop
            // 
            this.chkUnknownStop.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnknownStop.Appearance.Options.UseFont = true;
            this.chkUnknownStop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkUnknownStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkUnknownStop.Image = ((System.Drawing.Image)(resources.GetObject("chkUnknownStop.Image")));
            this.chkUnknownStop.Location = new System.Drawing.Point(807, 2);
            this.chkUnknownStop.Name = "chkUnknownStop";
            this.chkUnknownStop.Size = new System.Drawing.Size(130, 28);
            this.chkUnknownStop.TabIndex = 4;
            this.chkUnknownStop.Text = "Cycle Over";
            this.chkUnknownStop.CheckedChanged += new System.EventHandler(this.chkUnknownStop_CheckedChanged);
            // 
            // chkCellMerge
            // 
            this.chkCellMerge.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCellMerge.Appearance.Options.UseFont = true;
            this.chkCellMerge.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkCellMerge.Checked = true;
            this.chkCellMerge.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkCellMerge.Image = ((System.Drawing.Image)(resources.GetObject("chkCellMerge.Image")));
            this.chkCellMerge.Location = new System.Drawing.Point(2, 2);
            this.chkCellMerge.Name = "chkCellMerge";
            this.chkCellMerge.Size = new System.Drawing.Size(153, 28);
            this.chkCellMerge.TabIndex = 7;
            this.chkCellMerge.Text = "Allow Cell Merge";
            this.chkCellMerge.CheckedChanged += new System.EventHandler(this.chkCellMerge_CheckedChanged);
            // 
            // UCErrorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlFilter);
            this.Name = "UCErrorDetail";
            this.Size = new System.Drawing.Size(939, 632);
            this.Load += new System.EventHandler(this.UCErrorDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpErrorList.ResumeLayout(false);
            this.tpAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).EndInit();
            this.tabView.ResumeLayout(false);
            this.tpPattern.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPatternResult)).EndInit();
            this.pnlPatternResult.ResumeLayout(false);
            this.pnlPatternResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exManagerPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpAnalysis;
        private DevExpress.XtraTab.XtraTabPage tpErrorList;
        private UserControls.UCErrorLogGrid ucGrid;
        private DevExpress.XtraTab.XtraTabPage tpPattern;
        private DevExpress.XtraEditors.PanelControl pnlPatternResult;
        private System.Windows.Forms.ImageList imgList;
        private UCFlowResultGanttViewer ucFlowResultViewer;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager exManagerPattern;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarButtonItem btnItemUp;
        private DevExpress.XtraBars.BarButtonItem btnItemDown;
        private DevExpress.XtraBars.BarButtonItem btnPatternClear;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraTab.XtraTabControl tabView;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckButton chkAbnormalSymbol;
        private DevExpress.XtraEditors.CheckButton chkUnknownStop;
        private DevExpress.XtraEditors.SimpleButton btnExportRawData;
        private DevExpress.XtraEditors.CheckButton chkCellMerge;
    }
}
