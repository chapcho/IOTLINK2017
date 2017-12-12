namespace FTOPApp
{
    partial class UCObserver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCObserver));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ListGroup = new DevExpress.XtraEditors.GroupControl();
            this.exListGrid = new DevExpress.XtraGrid.GridControl();
            this.exListGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.exMainGrid = new DevExpress.XtraGrid.GridControl();
            this.exMainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.exLog = new DevExpress.XtraGrid.GridControl();
            this.exLogView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListGroup)).BeginInit();
            this.ListGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exLogView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ListGroup);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.exMainGrid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1027, 489);
            this.splitContainerControl1.SplitterPosition = 252;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ListGroup
            // 
            this.ListGroup.Controls.Add(this.exListGrid);
            this.ListGroup.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("설비 가져오기", ((System.Drawing.Image)(resources.GetObject("ListGroup.CustomHeaderButtons"))))});
            this.ListGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListGroup.Location = new System.Drawing.Point(0, 0);
            this.ListGroup.Name = "ListGroup";
            this.ListGroup.Size = new System.Drawing.Size(252, 489);
            this.ListGroup.TabIndex = 0;
            // 
            // exListGrid
            // 
            this.exListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exListGrid.Location = new System.Drawing.Point(2, 45);
            this.exListGrid.MainView = this.exListGridView;
            this.exListGrid.Name = "exListGrid";
            this.exListGrid.Size = new System.Drawing.Size(248, 442);
            this.exListGrid.TabIndex = 0;
            this.exListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exListGridView});
            // 
            // exListGridView
            // 
            this.exListGridView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.exListGridView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.exListGridView.Appearance.GroupPanel.Options.UseFont = true;
            this.exListGridView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.exListGridView.GridControl = this.exListGrid;
            this.exListGridView.GroupPanelText = "설비 조회 -> 더블 클릭";
            this.exListGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exListGridView.Name = "exListGridView";
            this.exListGridView.OptionsBehavior.Editable = false;
            this.exListGridView.OptionsBehavior.ReadOnly = true;
            this.exListGridView.OptionsView.ShowAutoFilterRow = true;
            // 
            // exMainGrid
            // 
            this.exMainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exMainGrid.Location = new System.Drawing.Point(0, 0);
            this.exMainGrid.MainView = this.exMainView;
            this.exMainGrid.Name = "exMainGrid";
            this.exMainGrid.Size = new System.Drawing.Size(763, 489);
            this.exMainGrid.TabIndex = 0;
            this.exMainGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exMainView});
            // 
            // exMainView
            // 
            this.exMainView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.exMainView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.exMainView.Appearance.GroupPanel.Options.UseFont = true;
            this.exMainView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.exMainView.GridControl = this.exMainGrid;
            this.exMainView.GroupPanelText = "Ready....";
            this.exMainView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exMainView.Name = "exMainView";
            this.exMainView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exMainView.OptionsBehavior.Editable = false;
            this.exMainView.OptionsBehavior.ReadOnly = true;
            this.exMainView.OptionsView.ShowAutoFilterRow = true;
            this.exMainView.OptionsView.ShowFooter = true;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.exLog);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1027, 650);
            this.splitContainerControl2.SplitterPosition = 489;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // exLog
            // 
            this.exLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exLog.Location = new System.Drawing.Point(0, 0);
            this.exLog.MainView = this.exLogView;
            this.exLog.Name = "exLog";
            this.exLog.Size = new System.Drawing.Size(1027, 149);
            this.exLog.TabIndex = 1;
            this.exLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exLogView});
            // 
            // exLogView
            // 
            this.exLogView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.exLogView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.exLogView.Appearance.GroupPanel.Options.UseFont = true;
            this.exLogView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.exLogView.GridControl = this.exLog;
            this.exLogView.GroupPanelText = "Information";
            this.exLogView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exLogView.Name = "exLogView";
            this.exLogView.OptionsBehavior.Editable = false;
            this.exLogView.OptionsBehavior.ReadOnly = true;
            // 
            // UCObserver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "UCObserver";
            this.Size = new System.Drawing.Size(1027, 650);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListGroup)).EndInit();
            this.ListGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exLogView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl ListGroup;
        private DevExpress.XtraGrid.GridControl exListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exListGridView;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl exLog;
        private DevExpress.XtraGrid.Views.Grid.GridView exLogView;
        private DevExpress.XtraGrid.GridControl exMainGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exMainView;
    }
}
