namespace UDMIOMaker
{
    partial class FrmRedundancyChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRedundancyChecker));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSymbolDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grdDesignPLC = new DevExpress.XtraGrid.GridControl();
            this.grvDesignPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDesignPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDesignPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDesignPLC)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSymbolDelete);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 409);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(836, 52);
            this.panelControl1.TabIndex = 13;
            // 
            // btnSymbolDelete
            // 
            this.btnSymbolDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSymbolDelete.Appearance.Options.UseBackColor = true;
            this.btnSymbolDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSymbolDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSymbolDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnSymbolDelete.Image")));
            this.btnSymbolDelete.Location = new System.Drawing.Point(0, 0);
            this.btnSymbolDelete.Name = "btnSymbolDelete";
            this.btnSymbolDelete.Size = new System.Drawing.Size(107, 52);
            this.btnSymbolDelete.TabIndex = 12;
            this.btnSymbolDelete.Text = "심볼 제거";
            this.btnSymbolDelete.Click += new System.EventHandler(this.btnSymbolDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(677, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 52);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(755, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdDesignPLC
            // 
            this.grdDesignPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDesignPLC.Location = new System.Drawing.Point(0, 0);
            this.grdDesignPLC.LookAndFeel.SkinName = "Metropolis";
            this.grdDesignPLC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDesignPLC.MainView = this.grvDesignPLC;
            this.grdDesignPLC.Name = "grdDesignPLC";
            this.grdDesignPLC.Size = new System.Drawing.Size(836, 409);
            this.grdDesignPLC.TabIndex = 14;
            this.grdDesignPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDesignPLC});
            // 
            // grvDesignPLC
            // 
            this.grvDesignPLC.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvDesignPLC.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvDesignPLC.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDesignPLC.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDesignPLC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDesignPLC,
            this.colDesignName,
            this.colDesignAddress,
            this.colDesignDescription,
            this.colDesignDataType,
            this.colDesignKey,
            this.colDesignNote});
            this.grvDesignPLC.GridControl = this.grdDesignPLC;
            this.grvDesignPLC.IndicatorWidth = 60;
            this.grvDesignPLC.Name = "grvDesignPLC";
            this.grvDesignPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvDesignPLC.OptionsDetail.EnableMasterViewMode = false;
            this.grvDesignPLC.OptionsDetail.SmartDetailExpand = false;
            this.grvDesignPLC.OptionsSelection.MultiSelect = true;
            this.grvDesignPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvDesignPLC.OptionsView.ShowAutoFilterRow = true;
            this.grvDesignPLC.OptionsView.ShowIndicator = false;
            this.grvDesignPLC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDesignPLC_CellValueChanged);
            // 
            // colDesignPLC
            // 
            this.colDesignPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignPLC.Caption = "PLC";
            this.colDesignPLC.FieldName = "Channel";
            this.colDesignPLC.Name = "colDesignPLC";
            this.colDesignPLC.OptionsColumn.AllowEdit = false;
            this.colDesignPLC.OptionsColumn.AllowShowHide = false;
            this.colDesignPLC.Visible = true;
            this.colDesignPLC.VisibleIndex = 0;
            this.colDesignPLC.Width = 126;
            // 
            // colDesignName
            // 
            this.colDesignName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignName.AppearanceCell.Options.UseFont = true;
            this.colDesignName.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignName.Caption = "Name";
            this.colDesignName.FieldName = "Name";
            this.colDesignName.Name = "colDesignName";
            this.colDesignName.OptionsColumn.AllowShowHide = false;
            this.colDesignName.Visible = true;
            this.colDesignName.VisibleIndex = 1;
            this.colDesignName.Width = 121;
            // 
            // colDesignAddress
            // 
            this.colDesignAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignAddress.AppearanceCell.Options.UseFont = true;
            this.colDesignAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignAddress.Caption = "Address";
            this.colDesignAddress.FieldName = "Address";
            this.colDesignAddress.Name = "colDesignAddress";
            this.colDesignAddress.OptionsColumn.AllowShowHide = false;
            this.colDesignAddress.Visible = true;
            this.colDesignAddress.VisibleIndex = 2;
            this.colDesignAddress.Width = 246;
            // 
            // colDesignDescription
            // 
            this.colDesignDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignDescription.AppearanceCell.Options.UseFont = true;
            this.colDesignDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDescription.Caption = "Description";
            this.colDesignDescription.FieldName = "Description";
            this.colDesignDescription.MinWidth = 300;
            this.colDesignDescription.Name = "colDesignDescription";
            this.colDesignDescription.OptionsColumn.AllowShowHide = false;
            this.colDesignDescription.Visible = true;
            this.colDesignDescription.VisibleIndex = 3;
            this.colDesignDescription.Width = 300;
            // 
            // colDesignDataType
            // 
            this.colDesignDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDataType.Caption = "DataType";
            this.colDesignDataType.FieldName = "DataType";
            this.colDesignDataType.MinWidth = 120;
            this.colDesignDataType.Name = "colDesignDataType";
            this.colDesignDataType.OptionsColumn.AllowEdit = false;
            this.colDesignDataType.OptionsColumn.AllowShowHide = false;
            this.colDesignDataType.Visible = true;
            this.colDesignDataType.VisibleIndex = 4;
            this.colDesignDataType.Width = 120;
            // 
            // colDesignKey
            // 
            this.colDesignKey.Caption = "Key";
            this.colDesignKey.FieldName = "Key";
            this.colDesignKey.Name = "colDesignKey";
            // 
            // colDesignNote
            // 
            this.colDesignNote.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignNote.Caption = "Type";
            this.colDesignNote.FieldName = "Note";
            this.colDesignNote.Name = "colDesignNote";
            // 
            // FrmRedundancyChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 461);
            this.Controls.Add(this.grdDesignPLC);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRedundancyChecker";
            this.Text = "PLC 심볼 중복 확인";
            this.Load += new System.EventHandler(this.FrmRedundancyChecker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDesignPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDesignPLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.GridControl grdDesignPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDesignPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignName;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignKey;
        private DevExpress.XtraEditors.SimpleButton btnSymbolDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignNote;
    }
}