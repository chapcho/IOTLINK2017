namespace UDMTrackerSimple
{
    partial class UCProcessLogTable
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
            this.colCycleID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridMain
            // 
            this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridMain.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exGridMain.Location = new System.Drawing.Point(0, 0);
            this.exGridMain.MainView = this.exGridView;
            this.exGridMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exGridMain.Name = "exGridMain";
            this.exGridMain.Size = new System.Drawing.Size(801, 566);
            this.exGridMain.TabIndex = 1;
            this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            this.exGridMain.Load += new System.EventHandler(this.UCProcessLogTable_Load);
            this.exGridMain.DoubleClick += new System.EventHandler(this.exGridMain_DoubleClick);
            // 
            // exGridView
            // 
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colCycleStart,
            this.coCycleEnd,
            this.colStateType,
            this.colRecipe,
            this.colCycleID});
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
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "Process";
            this.colGroup.FieldName = "GroupKey";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 104;
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
            this.colCycleStart.VisibleIndex = 3;
            this.colCycleStart.Width = 109;
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
            this.coCycleEnd.VisibleIndex = 4;
            this.coCycleEnd.Width = 112;
            // 
            // colStateType
            // 
            this.colStateType.AppearanceCell.Options.UseTextOptions = true;
            this.colStateType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStateType.AppearanceHeader.Options.UseTextOptions = true;
            this.colStateType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStateType.Caption = "State";
            this.colStateType.FieldName = "CycleType";
            this.colStateType.Name = "colStateType";
            this.colStateType.Visible = true;
            this.colStateType.VisibleIndex = 2;
            this.colStateType.Width = 112;
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRecipe.Caption = "Recipe";
            this.colRecipe.FieldName = "CurrentRecipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.Visible = true;
            this.colRecipe.VisibleIndex = 5;
            this.colRecipe.Width = 148;
            // 
            // colCycleID
            // 
            this.colCycleID.AppearanceCell.Options.UseTextOptions = true;
            this.colCycleID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleID.Caption = "Cycle ID";
            this.colCycleID.FieldName = "CycleID";
            this.colCycleID.Name = "colCycleID";
            this.colCycleID.Visible = true;
            this.colCycleID.VisibleIndex = 1;
            this.colCycleID.Width = 74;
            // 
            // UCProcessLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridMain);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCProcessLogTable";
            this.Size = new System.Drawing.Size(801, 566);
            this.Load += new System.EventHandler(this.UCProcessLogTable_Load);
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
        private DevExpress.XtraGrid.Columns.GridColumn colRecipe;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleID;
    }
}
