namespace UDMSPDSingle
{
    partial class FrmDetailView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailView));
            this.tmrView = new System.Windows.Forms.Timer(this.components);
            this.grdComInfo = new DevExpress.XtraGrid.GridControl();
            this.grvComInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdComInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvComInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrView
            // 
            this.tmrView.Interval = 500;
            this.tmrView.Tick += new System.EventHandler(this.tmrView_Tick);
            // 
            // grdComInfo
            // 
            this.grdComInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdComInfo.Location = new System.Drawing.Point(0, 0);
            this.grdComInfo.MainView = this.grvComInfo;
            this.grdComInfo.Name = "grdComInfo";
            this.grdComInfo.Size = new System.Drawing.Size(643, 524);
            this.grdComInfo.TabIndex = 3;
            this.grdComInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvComInfo,
            this.gridView2});
            // 
            // grvComInfo
            // 
            this.grvComInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem,
            this.colValue});
            this.grvComInfo.GridControl = this.grdComInfo;
            this.grvComInfo.Name = "grvComInfo";
            this.grvComInfo.OptionsBehavior.Editable = false;
            this.grvComInfo.OptionsView.AllowCellMerge = true;
            // 
            // colItem
            // 
            this.colItem.AppearanceCell.Options.UseTextOptions = true;
            this.colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.Caption = "항목";
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.OptionsColumn.ReadOnly = true;
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            this.colItem.Width = 200;
            // 
            // colValue
            // 
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "내용";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValue.OptionsColumn.ReadOnly = true;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 200;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdComInfo;
            this.gridView2.Name = "gridView2";
            // 
            // FrmDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 524);
            this.Controls.Add(this.grdComInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "가동 중 상세보기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDetailView_FormClosing);
            this.Load += new System.EventHandler(this.FrmDetailView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdComInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvComInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrView;
        private DevExpress.XtraGrid.GridControl grdComInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvComInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}