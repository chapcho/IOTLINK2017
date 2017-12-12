namespace FTOPApp
{
    partial class UCDBSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDBSender));
            this.GridGroup = new DevExpress.XtraEditors.GroupControl();
            this.exGrid = new DevExpress.XtraGrid.GridControl();
            this.exGrdiVeiw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnGridViewClear = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridGroup)).BeginInit();
            this.GridGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdiVeiw)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridGroup
            // 
            this.GridGroup.Controls.Add(this.exGrid);
            this.GridGroup.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Run", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Stop", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons1")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Option", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons2")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("ReConnect", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons3"))))});
            this.GridGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridGroup.Location = new System.Drawing.Point(0, 0);
            this.GridGroup.Name = "GridGroup";
            this.GridGroup.Size = new System.Drawing.Size(599, 518);
            this.GridGroup.TabIndex = 4;
            // 
            // exGrid
            // 
            this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrid.Location = new System.Drawing.Point(2, 45);
            this.exGrid.LookAndFeel.SkinName = "Metropolis";
            this.exGrid.MainView = this.exGrdiVeiw;
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(595, 471);
            this.exGrid.TabIndex = 16;
            this.exGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGrdiVeiw});
            // 
            // exGrdiVeiw
            // 
            this.exGrdiVeiw.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
            this.exGrdiVeiw.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.exGrdiVeiw.Appearance.GroupPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.exGrdiVeiw.Appearance.GroupPanel.Options.UseBackColor = true;
            this.exGrdiVeiw.Appearance.GroupPanel.Options.UseFont = true;
            this.exGrdiVeiw.Appearance.GroupPanel.Options.UseForeColor = true;
            this.exGrdiVeiw.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.exGrdiVeiw.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.exGrdiVeiw.Appearance.SelectedRow.Options.UseBackColor = true;
            this.exGrdiVeiw.Appearance.SelectedRow.Options.UseForeColor = true;
            this.exGrdiVeiw.GridControl = this.exGrid;
            this.exGrdiVeiw.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, null, null, "")});
            this.exGrdiVeiw.IndicatorWidth = 60;
            this.exGrdiVeiw.Name = "exGrdiVeiw";
            this.exGrdiVeiw.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exGrdiVeiw.OptionsDetail.EnableMasterViewMode = false;
            this.exGrdiVeiw.OptionsDetail.SmartDetailExpand = false;
            this.exGrdiVeiw.OptionsFind.AlwaysVisible = true;
            this.exGrdiVeiw.OptionsSelection.MultiSelect = true;
            this.exGrdiVeiw.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGrdiVeiw.OptionsView.ShowAutoFilterRow = true;
            this.exGrdiVeiw.OptionsView.ShowIndicator = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGridViewClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 26);
            // 
            // btnGridViewClear
            // 
            this.btnGridViewClear.Name = "btnGridViewClear";
            this.btnGridViewClear.Size = new System.Drawing.Size(153, 22);
            this.btnGridViewClear.Text = "GridView Clear";
            // 
            // UCDBSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridGroup);
            this.Name = "UCDBSender";
            this.Size = new System.Drawing.Size(599, 518);
            ((System.ComponentModel.ISupportInitialize)(this.GridGroup)).EndInit();
            this.GridGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdiVeiw)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GridGroup;
        private DevExpress.XtraGrid.GridControl exGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exGrdiVeiw;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnGridViewClear;
    }
}
