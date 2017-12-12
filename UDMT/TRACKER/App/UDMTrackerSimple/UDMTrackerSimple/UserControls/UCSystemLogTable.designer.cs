namespace UDMTrackerSimple
{
    partial class UCSystemLogTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSystemLogTable));
            this.exGridMain = new DevExpress.XtraGrid.GridControl();
            this.cntxMainMenu = new System.Windows.Forms.ContextMenuStrip();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
            this.cntxMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridMain
            // 
            this.exGridMain.ContextMenuStrip = this.cntxMainMenu;
            this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridMain.Location = new System.Drawing.Point(5, 5);
            this.exGridMain.MainView = this.exGridView;
            this.exGridMain.Name = "exGridMain";
            this.exGridMain.Size = new System.Drawing.Size(500, 477);
            this.exGridMain.TabIndex = 2;
            this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // cntxMainMenu
            // 
            this.cntxMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearAll});
            this.cntxMainMenu.Name = "cntxMainMenu";
            this.cntxMainMenu.Size = new System.Drawing.Size(120, 26);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearAll.Image")));
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(119, 22);
            this.mnuClearAll.Text = "Clear All";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // exGridView
            // 
            this.exGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.exGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.exGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTime,
            this.colSender,
            this.colMessage});
            this.exGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridView.GridControl = this.exGridMain;
            this.exGridView.IndicatorWidth = 40;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.exGridView.OptionsBehavior.ReadOnly = true;
            this.exGridView.OptionsDetail.EnableMasterViewMode = false;
            this.exGridView.OptionsDetail.ShowDetailTabs = false;
            this.exGridView.OptionsDetail.SmartDetailExpand = false;
            this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridView.OptionsSelection.MultiSelect = true;
            this.exGridView.OptionsView.ShowGroupPanel = false;
            this.exGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.exGridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.exGridView_CustomDrawRowIndicator);
            // 
            // colTime
            // 
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.AllowEdit = false;
            this.colTime.OptionsColumn.AllowMove = false;
            this.colTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTime.OptionsColumn.FixedWidth = true;
            this.colTime.OptionsColumn.ReadOnly = true;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 132;
            // 
            // colSender
            // 
            this.colSender.Caption = "Sender";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.OptionsColumn.AllowEdit = false;
            this.colSender.OptionsColumn.AllowMove = false;
            this.colSender.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSender.OptionsColumn.ReadOnly = true;
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 1;
            this.colSender.Width = 92;
            // 
            // colMessage
            // 
            this.colMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMessage.Caption = "Message";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.OptionsColumn.AllowEdit = false;
            this.colMessage.OptionsColumn.AllowMove = false;
            this.colMessage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMessage.OptionsColumn.ReadOnly = true;
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 258;
            // 
            // UCSystemLogTable
            // 
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.exGridMain);
            this.Name = "UCSystemLogTable";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(510, 487);
            this.Load += new System.EventHandler(this.UCSystemLogTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).EndInit();
            this.cntxMainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private System.Windows.Forms.ContextMenuStrip cntxMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;

    }
}
