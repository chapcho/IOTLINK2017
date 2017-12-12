namespace UDM.Project
{
    partial class UCGroupLogTable
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
            this.exGridMain = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coCycleEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonitorType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridMain
            // 
            this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridMain.Location = new System.Drawing.Point(0, 0);
            this.exGridMain.MainView = this.exGridView;
            this.exGridMain.Name = "exGridMain";
            this.exGridMain.Size = new System.Drawing.Size(653, 392);
            this.exGridMain.TabIndex = 0;
            this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            this.exGridMain.DoubleClick += new System.EventHandler(this.exGridMain_DoubleClick);
            // 
            // exGridView
            // 
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colCycleStart,
            this.coCycleEnd,
            this.colStateType,
            this.colMonitorType,
            this.colRecipe,
            this.colProduct});
            this.exGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridView.GridControl = this.exGridMain;
            this.exGridView.IndicatorWidth = 40;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.exGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsBehavior.ReadOnly = true;
            this.exGridView.OptionsDetail.EnableMasterViewMode = false;
            this.exGridView.OptionsDetail.ShowDetailTabs = false;
            this.exGridView.OptionsDetail.SmartDetailExpand = false;
            this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.exGridView_CustomDrawRowIndicator);
            // 
            // colGroup
            // 
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "Group";
            this.colGroup.FieldName = "Key";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 60;
            // 
            // colCycleStart
            // 
            this.colCycleStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleStart.Caption = "Cycle Start";
            this.colCycleStart.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.colCycleStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCycleStart.FieldName = "CycleStart";
            this.colCycleStart.Name = "colCycleStart";
            this.colCycleStart.Visible = true;
            this.colCycleStart.VisibleIndex = 1;
            this.colCycleStart.Width = 58;
            // 
            // coCycleEnd
            // 
            this.coCycleEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.coCycleEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coCycleEnd.Caption = "Cycle End";
            this.coCycleEnd.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.coCycleEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coCycleEnd.FieldName = "CycleEnd";
            this.coCycleEnd.Name = "coCycleEnd";
            this.coCycleEnd.Visible = true;
            this.coCycleEnd.VisibleIndex = 2;
            this.coCycleEnd.Width = 60;
            // 
            // colStateType
            // 
            this.colStateType.AppearanceHeader.Options.UseTextOptions = true;
            this.colStateType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStateType.Caption = "State";
            this.colStateType.FieldName = "StateType";
            this.colStateType.Name = "colStateType";
            this.colStateType.Visible = true;
            this.colStateType.VisibleIndex = 3;
            this.colStateType.Width = 60;
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRecipe.Caption = "Recipe";
            this.colRecipe.FieldName = "Recipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.Visible = true;
            this.colRecipe.VisibleIndex = 5;
            // 
            // colProduct
            // 
            this.colProduct.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduct.Caption = "Product";
            this.colProduct.FieldName = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 6;
            this.colProduct.Width = 64;
            // 
            // colMonitorType
            // 
            this.colMonitorType.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonitorType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonitorType.Caption = "MonitorType";
            this.colMonitorType.FieldName = "MonitorType";
            this.colMonitorType.Name = "colMonitorType";
            this.colMonitorType.Visible = true;
            this.colMonitorType.VisibleIndex = 4;
            // 
            // UCGroupLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridMain);
            this.Name = "UCGroupLogTable";
            this.Size = new System.Drawing.Size(653, 392);
            this.Load += new System.EventHandler(this.UCGroupLogTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStart;
        private DevExpress.XtraGrid.Columns.GridColumn coCycleEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colStateType;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipe;
        private DevExpress.XtraGrid.Columns.GridColumn colMonitorType;
    }
}
