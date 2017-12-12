namespace UDM.Project
{
    partial class UCGroupStateTable
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
            if (m_dbTable != null)            
            {
                m_dbTable.Clear();
                m_dbTable.Dispose();
                m_dbTable = null;
            }

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
            this.exGridControl = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTackTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridControl
            // 
            this.exGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridControl.Location = new System.Drawing.Point(5, 5);
            this.exGridControl.MainView = this.exGridView;
            this.exGridControl.Name = "exGridControl";
            this.exGridControl.Size = new System.Drawing.Size(596, 406);
            this.exGridControl.TabIndex = 0;
            this.exGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colTackTime,
            this.colIdleTime,
            this.colState});
            this.exGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridView.GridControl = this.exGridControl;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsBehavior.ReadOnly = true;
            this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridView.OptionsView.ShowGroupPanel = false;
            this.exGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.exGridView_CustomDrawCell);
            // 
            // colGroup
            // 
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "Group";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            // 
            // colTackTime
            // 
            this.colTackTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTackTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTackTime.Caption = "TackTime";
            this.colTackTime.FieldName = "TackTime";
            this.colTackTime.Name = "colTackTime";
            this.colTackTime.Visible = true;
            this.colTackTime.VisibleIndex = 1;
            // 
            // colIdleTime
            // 
            this.colIdleTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdleTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdleTime.Caption = "IdleTime";
            this.colIdleTime.FieldName = "IdleTime";
            this.colIdleTime.Name = "colIdleTime";
            this.colIdleTime.Visible = true;
            this.colIdleTime.VisibleIndex = 2;
            // 
            // colState
            // 
            this.colState.AppearanceHeader.Options.UseTextOptions = true;
            this.colState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colState.Caption = "State";
            this.colState.FieldName = "State";
            this.colState.Name = "colState";
            this.colState.Visible = true;
            this.colState.VisibleIndex = 3;
            // 
            // UCMonitorGroupState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridControl);
            this.Name = "UCMonitorGroupState";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(606, 416);
            this.Load += new System.EventHandler(this.UCGroupStateTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colTackTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIdleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
    }
}
