namespace UDMTrackerSimple
{
    partial class UCRobotCycleItem
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
            this.pnlItem = new DevExpress.XtraEditors.PanelControl();
            this.ucCycleTimeInfo = new UDMTrackerSimple.UCCircleGauge2Row();
            this.lblRbtName = new DevExpress.XtraEditors.LabelControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdInfo = new DevExpress.XtraGrid.GridControl();
            this.grvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCommItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlItem)).BeginInit();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.ucCycleTimeInfo);
            this.pnlItem.Controls.Add(this.lblRbtName);
            this.pnlItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlItem.Location = new System.Drawing.Point(0, 0);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(235, 180);
            this.pnlItem.TabIndex = 1;
            // 
            // ucCycleTimeInfo
            // 
            this.ucCycleTimeInfo.BackColor = System.Drawing.Color.White;
            this.ucCycleTimeInfo.BottomLabelCaption = "Maximum";
            this.ucCycleTimeInfo.BottomLabelText = "0.00s";
            this.ucCycleTimeInfo.CircleText = "0s";
            this.ucCycleTimeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCycleTimeInfo.Location = new System.Drawing.Point(2, 37);
            this.ucCycleTimeInfo.MaxBarColor = System.Drawing.Color.LightGray;
            this.ucCycleTimeInfo.MaxValue = 100F;
            this.ucCycleTimeInfo.Name = "ucCycleTimeInfo";
            this.ucCycleTimeInfo.Size = new System.Drawing.Size(231, 141);
            this.ucCycleTimeInfo.TabIndex = 3;
            this.ucCycleTimeInfo.TitleText = "Cycle Time";
            this.ucCycleTimeInfo.TopLabelCaption = "Average";
            this.ucCycleTimeInfo.TopLabelText = "0.00s";
            this.ucCycleTimeInfo.Value = 0F;
            this.ucCycleTimeInfo.ValueBarColor = System.Drawing.Color.Blue;
            // 
            // lblRbtName
            // 
            this.lblRbtName.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRbtName.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblRbtName.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.lblRbtName.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblRbtName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRbtName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRbtName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRbtName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblRbtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRbtName.Location = new System.Drawing.Point(2, 2);
            this.lblRbtName.Name = "lblRbtName";
            this.lblRbtName.Size = new System.Drawing.Size(231, 35);
            this.lblRbtName.TabIndex = 2;
            this.lblRbtName.Text = "#205 RB1 ABCDEF";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdInfo;
            this.gridView2.Name = "gridView2";
            // 
            // grdInfo
            // 
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.Location = new System.Drawing.Point(235, 0);
            this.grdInfo.MainView = this.grvInfo;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.Size = new System.Drawing.Size(424, 180);
            this.grdInfo.TabIndex = 4;
            this.grdInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInfo,
            this.gridView2});
            // 
            // grvInfo
            // 
            this.grvInfo.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grvInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvInfo.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.grvInfo.Appearance.Row.Options.UseFont = true;
            this.grvInfo.Appearance.Row.Options.UseTextOptions = true;
            this.grvInfo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvInfo.ColumnPanelRowHeight = 36;
            this.grvInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCommItem,
            this.colCommValue});
            this.grvInfo.GridControl = this.grdInfo;
            this.grvInfo.Name = "grvInfo";
            this.grvInfo.OptionsBehavior.Editable = false;
            this.grvInfo.OptionsCustomization.AllowColumnMoving = false;
            this.grvInfo.OptionsCustomization.AllowColumnResizing = false;
            this.grvInfo.OptionsCustomization.AllowFilter = false;
            this.grvInfo.OptionsCustomization.AllowSort = false;
            this.grvInfo.OptionsFilter.AllowFilterEditor = false;
            this.grvInfo.OptionsView.AllowCellMerge = true;
            this.grvInfo.OptionsView.ShowDetailButtons = false;
            this.grvInfo.OptionsView.ShowGroupPanel = false;
            this.grvInfo.OptionsView.ShowIndicator = false;
            this.grvInfo.RowHeight = 34;
            // 
            // colCommItem
            // 
            this.colCommItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommItem.Caption = "Item";
            this.colCommItem.FieldName = "Item";
            this.colCommItem.Name = "colCommItem";
            this.colCommItem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommItem.OptionsColumn.ReadOnly = true;
            this.colCommItem.Visible = true;
            this.colCommItem.VisibleIndex = 0;
            this.colCommItem.Width = 140;
            // 
            // colCommValue
            // 
            this.colCommValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommValue.Caption = "Value";
            this.colCommValue.FieldName = "Value";
            this.colCommValue.Name = "colCommValue";
            this.colCommValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommValue.OptionsColumn.ReadOnly = true;
            this.colCommValue.Visible = true;
            this.colCommValue.VisibleIndex = 1;
            this.colCommValue.Width = 268;
            // 
            // UCRobotCycleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdInfo);
            this.Controls.Add(this.pnlItem);
            this.Name = "UCRobotCycleItem";
            this.Size = new System.Drawing.Size(659, 180);
            ((System.ComponentModel.ISupportInitialize)(this.pnlItem)).EndInit();
            this.pnlItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlItem;
        private DevExpress.XtraEditors.LabelControl lblRbtName;
        private UCCircleGauge2Row ucCycleTimeInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grdInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colCommItem;
        private DevExpress.XtraGrid.Columns.GridColumn colCommValue;

    }
}
