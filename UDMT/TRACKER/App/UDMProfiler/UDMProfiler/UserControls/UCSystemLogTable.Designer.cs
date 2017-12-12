namespace UDMProfiler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSystemLogTable));
            this.grdMessage = new DevExpress.XtraGrid.GridControl();
            this.grvMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cntxMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).BeginInit();
            this.cntxMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMessage
            // 
            this.grdMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMessage.Location = new System.Drawing.Point(0, 0);
            this.grdMessage.MainView = this.grvMessage;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.Size = new System.Drawing.Size(595, 444);
            this.grdMessage.TabIndex = 0;
            this.grdMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMessage});
            // 
            // grvMessage
            // 
            this.grvMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTime,
            this.colsender,
            this.colMessage});
            this.grvMessage.GridControl = this.grdMessage;
            this.grvMessage.Name = "grvMessage";
            this.grvMessage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvMessage.OptionsBehavior.Editable = false;
            this.grvMessage.OptionsBehavior.ReadOnly = true;
            this.grvMessage.OptionsView.ShowGroupPanel = false;
            this.grvMessage.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colTime
            // 
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.FixedWidth = true;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 151;
            // 
            // colsender
            // 
            this.colsender.AppearanceHeader.Options.UseTextOptions = true;
            this.colsender.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsender.Caption = "Sender";
            this.colsender.FieldName = "Sender";
            this.colsender.Name = "colsender";
            this.colsender.Visible = true;
            this.colsender.VisibleIndex = 1;
            this.colsender.Width = 73;
            // 
            // colMessage
            // 
            this.colMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMessage.Caption = "Message";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 353;
            // 
            // cntxMainMenu
            // 
            this.cntxMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearAll});
            this.cntxMainMenu.Name = "cntxMainMenu";
            this.cntxMainMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearAll.Image")));
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(152, 22);
            this.mnuClearAll.Text = "Clear All";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // UCSystemLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdMessage);
            this.Name = "UCSystemLogTable";
            this.Size = new System.Drawing.Size(595, 444);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).EndInit();
            this.cntxMainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colsender;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private System.Windows.Forms.ContextMenuStrip cntxMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;

    }
}
