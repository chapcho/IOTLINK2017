namespace UDM.UI.DevGrid
{
    partial class UCGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGrid));
            this.exGridControl = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridControl
            // 
            resources.ApplyResources(this.exGridControl, "exGridControl");
            this.exGridControl.MainView = this.exGridView;
            this.exGridControl.Name = "exGridControl";
            this.exGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey});
            this.exGridView.GridControl = this.exGridControl;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsSelection.MultiSelect = true;
            this.exGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridView.OptionsView.ShowAutoFilterRow = true;
            this.exGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.exGridView.OptionsView.ShowGroupPanel = false;
            this.exGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.exGridView_RowCellClick);
            this.exGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exGridView_KeyDown);
            this.exGridView.DoubleClick += new System.EventHandler(this.exGridView_DoubleClick);
            // 
            // colKey
            // 
            resources.ApplyResources(this.colKey, "colKey");
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            // 
            // UCGrid
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridControl);
            this.Name = "UCGrid";
            ((System.ComponentModel.ISupportInitialize)(this.exGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
    }
}
