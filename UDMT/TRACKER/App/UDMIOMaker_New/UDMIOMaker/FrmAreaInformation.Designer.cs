namespace UDMIOMaker
{
    partial class FrmAreaInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAreaInformation));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdArea = new DevExpress.XtraGrid.GridControl();
            this.grvArea = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNormalRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtendRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdAddressType = new DevExpress.XtraGrid.GridControl();
            this.grvAddressType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddressType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddressStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddressEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaker = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(288, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(523, 315);
            this.panelControl1.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdArea);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(523, 315);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Maker 별 ADDRESS 일반/최대 영역";
            // 
            // grdArea
            // 
            this.grdArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdArea.Location = new System.Drawing.Point(2, 21);
            this.grdArea.MainView = this.grvArea;
            this.grdArea.Name = "grdArea";
            this.grdArea.Size = new System.Drawing.Size(519, 292);
            this.grdArea.TabIndex = 3;
            this.grdArea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArea});
            // 
            // grvArea
            // 
            this.grvArea.Appearance.FocusedCell.BackColor = System.Drawing.Color.Orange;
            this.grvArea.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvArea.Appearance.SelectedRow.BackColor = System.Drawing.Color.Orange;
            this.grvArea.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Orange;
            this.grvArea.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvArea.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvArea.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvArea.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
            this.grvArea.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaker,
            this.colType,
            this.colNormalRange,
            this.colExtendRange});
            this.grvArea.GridControl = this.grdArea;
            this.grvArea.IndicatorWidth = 40;
            this.grvArea.Name = "grvArea";
            this.grvArea.OptionsBehavior.Editable = false;
            this.grvArea.OptionsBehavior.FocusLeaveOnTab = true;
            this.grvArea.OptionsBehavior.ReadOnly = true;
            this.grvArea.OptionsDetail.EnableMasterViewMode = false;
            this.grvArea.OptionsDetail.SmartDetailExpand = false;
            this.grvArea.OptionsSelection.MultiSelect = true;
            this.grvArea.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvArea.OptionsView.AllowCellMerge = true;
            this.grvArea.OptionsView.ShowGroupPanel = false;
            this.grvArea.OptionsView.ShowIndicator = false;
            // 
            // colMaker
            // 
            this.colMaker.AppearanceCell.Options.UseTextOptions = true;
            this.colMaker.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaker.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaker.AppearanceHeader.Options.UseFont = true;
            this.colMaker.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaker.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaker.Caption = "Maker";
            this.colMaker.FieldName = "PLCMaker";
            this.colMaker.Name = "colMaker";
            this.colMaker.Visible = true;
            this.colMaker.VisibleIndex = 0;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colType.AppearanceHeader.Options.UseFont = true;
            this.colType.AppearanceHeader.Options.UseTextOptions = true;
            this.colType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.Caption = "Type";
            this.colType.FieldName = "TypeList";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            // 
            // colNormalRange
            // 
            this.colNormalRange.AppearanceCell.Options.UseTextOptions = true;
            this.colNormalRange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNormalRange.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNormalRange.AppearanceHeader.Options.UseFont = true;
            this.colNormalRange.AppearanceHeader.Options.UseTextOptions = true;
            this.colNormalRange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNormalRange.Caption = "일반 영역";
            this.colNormalRange.FieldName = "NormalRange";
            this.colNormalRange.Name = "colNormalRange";
            this.colNormalRange.Visible = true;
            this.colNormalRange.VisibleIndex = 2;
            // 
            // colExtendRange
            // 
            this.colExtendRange.AppearanceCell.Options.UseTextOptions = true;
            this.colExtendRange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExtendRange.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colExtendRange.AppearanceHeader.Options.UseFont = true;
            this.colExtendRange.AppearanceHeader.Options.UseTextOptions = true;
            this.colExtendRange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExtendRange.Caption = "최대 영역";
            this.colExtendRange.FieldName = "ExtendRange";
            this.colExtendRange.Name = "colExtendRange";
            this.colExtendRange.Visible = true;
            this.colExtendRange.VisibleIndex = 3;
            // 
            // cboPLCList
            // 
            this.cboPLCList.Location = new System.Drawing.Point(71, 12);
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCList.Size = new System.Drawing.Size(211, 20);
            this.cboPLCList.TabIndex = 10;
            this.cboPLCList.SelectedValueChanged += new System.EventHandler(this.cboPLCList_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "PLC List ";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(288, 315);
            this.panelControl2.TabIndex = 10;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdAddressType);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 78);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(288, 237);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "사용 중인 ADDRESS 영역";
            // 
            // grdAddressType
            // 
            this.grdAddressType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAddressType.Location = new System.Drawing.Point(2, 21);
            this.grdAddressType.MainView = this.grvAddressType;
            this.grdAddressType.Name = "grdAddressType";
            this.grdAddressType.Size = new System.Drawing.Size(284, 214);
            this.grdAddressType.TabIndex = 2;
            this.grdAddressType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAddressType});
            // 
            // grvAddressType
            // 
            this.grvAddressType.Appearance.SelectedRow.BackColor = System.Drawing.Color.Orange;
            this.grvAddressType.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAddressType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddressType,
            this.colAddressStart,
            this.colAddressEnd});
            this.grvAddressType.GridControl = this.grdAddressType;
            this.grvAddressType.IndicatorWidth = 40;
            this.grvAddressType.Name = "grvAddressType";
            this.grvAddressType.OptionsBehavior.Editable = false;
            this.grvAddressType.OptionsBehavior.ReadOnly = true;
            this.grvAddressType.OptionsDetail.EnableMasterViewMode = false;
            this.grvAddressType.OptionsDetail.SmartDetailExpand = false;
            this.grvAddressType.OptionsSelection.MultiSelect = true;
            this.grvAddressType.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvAddressType.OptionsView.ShowGroupPanel = false;
            this.grvAddressType.OptionsView.ShowIndicator = false;
            // 
            // colAddressType
            // 
            this.colAddressType.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colAddressType.AppearanceCell.Options.UseBackColor = true;
            this.colAddressType.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressType.AppearanceHeader.Options.UseFont = true;
            this.colAddressType.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressType.Caption = "Type";
            this.colAddressType.FieldName = "BlockName";
            this.colAddressType.MaxWidth = 70;
            this.colAddressType.MinWidth = 70;
            this.colAddressType.Name = "colAddressType";
            this.colAddressType.Visible = true;
            this.colAddressType.VisibleIndex = 0;
            this.colAddressType.Width = 70;
            // 
            // colAddressStart
            // 
            this.colAddressStart.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colAddressStart.AppearanceCell.Options.UseBackColor = true;
            this.colAddressStart.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressStart.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressStart.AppearanceHeader.Options.UseFont = true;
            this.colAddressStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressStart.Caption = "START";
            this.colAddressStart.FieldName = "StartAddress";
            this.colAddressStart.Name = "colAddressStart";
            this.colAddressStart.Visible = true;
            this.colAddressStart.VisibleIndex = 1;
            this.colAddressStart.Width = 125;
            // 
            // colAddressEnd
            // 
            this.colAddressEnd.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colAddressEnd.AppearanceCell.Options.UseBackColor = true;
            this.colAddressEnd.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressEnd.AppearanceHeader.Options.UseFont = true;
            this.colAddressEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressEnd.Caption = "END";
            this.colAddressEnd.FieldName = "EndAddress";
            this.colAddressEnd.Name = "colAddressEnd";
            this.colAddressEnd.Visible = true;
            this.colAddressEnd.VisibleIndex = 2;
            this.colAddressEnd.Width = 128;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.txtMaker);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.cboPLCList);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(288, 78);
            this.panelControl3.TabIndex = 11;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(86, 46);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Properties.ReadOnly = true;
            this.txtMaker.Size = new System.Drawing.Size(196, 20);
            this.txtMaker.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(12, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "PLC Maker ";
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnClose);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 315);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(811, 47);
            this.panelControl4.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(730, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 47);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAreaInformation
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 362);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAreaInformation";
            this.Text = "영역 정보 확인";
            this.Load += new System.EventHandler(this.FrmAreaInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtMaker;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdAddressType;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAddressType;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressType;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressStart;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressEnd;
        private DevExpress.XtraGrid.GridControl grdArea;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArea;
        private DevExpress.XtraGrid.Columns.GridColumn colMaker;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colNormalRange;
        private DevExpress.XtraGrid.Columns.GridColumn colExtendRange;

    }
}