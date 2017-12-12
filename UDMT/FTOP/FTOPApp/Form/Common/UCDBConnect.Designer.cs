namespace FTOPApp
{
    partial class UCDBConnect
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textBoxCommand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.exGrid = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCommand = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.MenuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnColumnAllShow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnColumnHide = new System.Windows.Forms.ToolStripMenuItem();
            this.btnColumnBestFit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewMode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCommand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.MenuGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textBoxCommand);
            this.layoutControl1.Controls.Add(this.labelStatus);
            this.layoutControl1.Controls.Add(this.exGrid);
            this.layoutControl1.Controls.Add(this.btnCommand);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(788, 577);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.EditValue = "Report";
            this.textBoxCommand.Location = new System.Drawing.Point(81, 12);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBoxCommand.Properties.Items.AddRange(new object[] {
            "SELECT * FROM dbo.FTOP300 WHERE IF_MES_RSLT =\'8\'",
            "SELECT * FROM dbo.FTOP300 WHERE IF_MES_RSLT =\'6\'",
            "Report",
            "SELECT * FROM dbo.FTOP300",
            "SELECT * FROM dbo.FTOP110",
            "SELECT * FROM dbo.FTOP100",
            "SELECT * FROM dbo.FTOP200",
            ""});
            this.textBoxCommand.Size = new System.Drawing.Size(386, 20);
            this.textBoxCommand.StyleController = this.layoutControl1;
            this.textBoxCommand.TabIndex = 12;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 38);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 14);
            this.labelStatus.StyleController = this.layoutControl1;
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = "Ready.....";
            // 
            // exGrid
            // 
            this.exGrid.Location = new System.Drawing.Point(12, 56);
            this.exGrid.MainView = this.exGridView;
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(764, 509);
            this.exGrid.TabIndex = 10;
            this.exGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.GridControl = this.exGrid;
            this.exGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsView.ShowFooter = true;
            // 
            // btnCommand
            // 
            this.btnCommand.Location = new System.Drawing.Point(471, 12);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(305, 22);
            this.btnCommand.StyleController = this.layoutControl1;
            this.btnCommand.TabIndex = 9;
            this.btnCommand.Text = "Command";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(788, 577);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.exGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(768, 513);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCommand;
            this.layoutControlItem6.Location = new System.Drawing.Point(459, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.labelStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(768, 18);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.textBoxCommand;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(459, 26);
            this.layoutControlItem7.Text = "Command : ";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(66, 14);
            // 
            // MenuGridView
            // 
            this.MenuGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnColumnAllShow,
            this.btnColumnHide,
            this.btnColumnBestFit,
            this.btnViewMode,
            this.btnExport});
            this.MenuGridView.Name = "MenuGridView";
            this.MenuGridView.Size = new System.Drawing.Size(123, 114);
            // 
            // btnColumnAllShow
            // 
            this.btnColumnAllShow.Name = "btnColumnAllShow";
            this.btnColumnAllShow.Size = new System.Drawing.Size(122, 22);
            this.btnColumnAllShow.Text = "All Show";
            // 
            // btnColumnHide
            // 
            this.btnColumnHide.Name = "btnColumnHide";
            this.btnColumnHide.Size = new System.Drawing.Size(122, 22);
            this.btnColumnHide.Text = "Hide";
            // 
            // btnColumnBestFit
            // 
            this.btnColumnBestFit.Name = "btnColumnBestFit";
            this.btnColumnBestFit.Size = new System.Drawing.Size(122, 22);
            this.btnColumnBestFit.Text = "Best Fit";
            // 
            // btnViewMode
            // 
            this.btnViewMode.Name = "btnViewMode";
            this.btnViewMode.Size = new System.Drawing.Size(122, 22);
            this.btnViewMode.Text = "Expand";
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 22);
            this.btnExport.Text = "Export";
            // 
            // UCDBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCDBConnect";
            this.Size = new System.Drawing.Size(788, 577);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCommand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.MenuGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCommand;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl exGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.ContextMenuStrip MenuGridView;
        private System.Windows.Forms.ToolStripMenuItem btnColumnAllShow;
        private System.Windows.Forms.ToolStripMenuItem btnColumnHide;
        private System.Windows.Forms.ToolStripMenuItem btnColumnBestFit;
        private DevExpress.XtraEditors.ComboBoxEdit textBoxCommand;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.ToolStripMenuItem btnViewMode;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
    }
}
