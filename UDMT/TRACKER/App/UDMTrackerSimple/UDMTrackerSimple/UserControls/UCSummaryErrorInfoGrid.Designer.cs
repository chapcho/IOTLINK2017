namespace UDMTrackerSimple
{
    partial class UCSummaryErrorInfoGrid
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
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdError = new DevExpress.XtraGrid.GridControl();
            this.grvErrorTile = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnChartClear = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlErrorChart = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvErrorTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.Caption = "Group";
            this.tileViewColumn2.FieldName = "GroupKey";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.Caption = "#Error";
            this.tileViewColumn3.FieldName = "ErrorCount";
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            // 
            // grdError
            // 
            this.grdError.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdError.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdError.Location = new System.Drawing.Point(0, 0);
            this.grdError.MainView = this.grvErrorTile;
            this.grdError.Name = "grdError";
            this.grdError.Size = new System.Drawing.Size(413, 368);
            this.grdError.TabIndex = 26;
            this.grdError.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvErrorTile});
            // 
            // grvErrorTile
            // 
            this.grvErrorTile.Appearance.ItemFocused.ForeColor = System.Drawing.Color.Black;
            this.grvErrorTile.Appearance.ItemFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvErrorTile.Appearance.ItemFocused.Options.UseForeColor = true;
            this.grvErrorTile.Appearance.ItemNormal.Options.UseTextOptions = true;
            this.grvErrorTile.Appearance.ItemNormal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvErrorTile.Appearance.ItemNormal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvErrorTile.Appearance.ItemSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grvErrorTile.Appearance.ItemSelected.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.grvErrorTile.Appearance.ItemSelected.Options.UseBackColor = true;
            this.grvErrorTile.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.grvErrorTile.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvErrorTile.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvErrorTile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3});
            this.grvErrorTile.GridControl = this.grdError;
            this.grvErrorTile.Name = "grvErrorTile";
            this.grvErrorTile.OptionsBehavior.Editable = false;
            this.grvErrorTile.OptionsTiles.HighlightFocusedTileOnGridLoad = true;
            this.grvErrorTile.OptionsTiles.IndentBetweenGroups = 30;
            this.grvErrorTile.OptionsTiles.IndentBetweenItems = 20;
            this.grvErrorTile.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(10);
            this.grvErrorTile.OptionsTiles.ItemSize = new System.Drawing.Size(130, 100);
            this.grvErrorTile.OptionsTiles.RowCount = 10;
            tileViewItemElement1.AnchorIndent = 0;
            tileViewItemElement1.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            tileViewItemElement1.Appearance.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement1.Appearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tileViewItemElement1.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement1.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement1.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement1.Column = this.tileViewColumn2;
            tileViewItemElement1.Height = 40;
            tileViewItemElement1.StretchHorizontal = true;
            tileViewItemElement1.Text = "tileViewColumn2";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement2.AnchorIndent = 2;
            tileViewItemElement2.Appearance.Normal.BackColor = System.Drawing.Color.Orange;
            tileViewItemElement2.Appearance.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement2.Appearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tileViewItemElement2.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement2.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement2.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement2.Column = this.tileViewColumn3;
            tileViewItemElement2.Height = 45;
            tileViewItemElement2.StretchHorizontal = true;
            tileViewItemElement2.Text = "tileViewColumn3";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileViewItemElement3.Appearance.Normal.BackColor = System.Drawing.Color.Black;
            tileViewItemElement3.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement3.Column = null;
            tileViewItemElement3.Height = 2;
            tileViewItemElement3.StretchHorizontal = true;
            tileViewItemElement3.Text = "";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(0, 34);
            tileViewItemElement4.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement4.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement4.Column = null;
            tileViewItemElement4.StretchVertical = true;
            tileViewItemElement4.Text = "";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(-10, 0);
            tileViewItemElement4.Width = 10;
            tileViewItemElement5.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement5.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement5.Column = null;
            tileViewItemElement5.StretchVertical = true;
            tileViewItemElement5.Text = "";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(10, 0);
            tileViewItemElement5.Width = 10;
            tileViewItemElement6.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement6.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement6.Column = null;
            tileViewItemElement6.Height = 10;
            tileViewItemElement6.StretchHorizontal = true;
            tileViewItemElement6.Text = "";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(0, -10);
            tileViewItemElement7.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement7.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement7.Column = null;
            tileViewItemElement7.Height = 10;
            tileViewItemElement7.StretchHorizontal = true;
            tileViewItemElement7.Text = "";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(0, 10);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement1);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement2);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement3);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement4);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement5);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement6);
            this.grvErrorTile.TileTemplate.Add(tileViewItemElement7);
            this.grvErrorTile.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.grvErrorTile_ItemClick);
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "Address";
            this.tileViewColumn1.FieldName = "Address";
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(413, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 368);
            this.splitterControl1.TabIndex = 27;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnChartClear);
            this.panelControl1.Controls.Add(this.lblTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(418, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(495, 28);
            this.panelControl1.TabIndex = 28;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(379, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChartClear
            // 
            this.btnChartClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChartClear.Location = new System.Drawing.Point(436, 2);
            this.btnChartClear.Name = "btnChartClear";
            this.btnChartClear.Size = new System.Drawing.Size(57, 24);
            this.btnChartClear.TabIndex = 2;
            this.btnChartClear.Text = "Clear";
            this.btnChartClear.Click += new System.EventHandler(this.btnChartClear_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(141, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Error Statistic Chart";
            // 
            // pnlErrorChart
            // 
            this.pnlErrorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlErrorChart.Location = new System.Drawing.Point(418, 28);
            this.pnlErrorChart.Name = "pnlErrorChart";
            this.pnlErrorChart.Size = new System.Drawing.Size(495, 340);
            this.pnlErrorChart.TabIndex = 29;
            // 
            // UCSummaryErrorInfoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlErrorChart);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.grdError);
            this.Name = "UCSummaryErrorInfoGrid";
            this.Size = new System.Drawing.Size(913, 368);
            this.Load += new System.EventHandler(this.UCSummaryErrorInfoGrid_Load);
            this.Resize += new System.EventHandler(this.UCSummaryErrorInfoGrid_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvErrorTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdError;
        private DevExpress.XtraGrid.Views.Tile.TileView grvErrorTile;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnChartClear;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PanelControl pnlErrorChart;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
