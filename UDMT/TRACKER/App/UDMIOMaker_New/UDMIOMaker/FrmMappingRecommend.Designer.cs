namespace UDMIOMaker
{
    partial class FrmMappingRecommend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMappingRecommend));
            this.grdPLC = new DevExpress.XtraGrid.GridControl();
            this.grvPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMapping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLCGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLCKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtHMIName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHMIName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPLC
            // 
            this.grdPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPLC.Location = new System.Drawing.Point(2, 21);
            this.grdPLC.LookAndFeel.SkinName = "Metropolis";
            this.grdPLC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPLC.MainView = this.grvPLC;
            this.grdPLC.Name = "grdPLC";
            this.grdPLC.Size = new System.Drawing.Size(955, 354);
            this.grdPLC.TabIndex = 0;
            this.grdPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPLC});
            this.grdPLC.DoubleClick += new System.EventHandler(this.grdPLC_DoubleClick);
            // 
            // grvPLC
            // 
            this.grvPLC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMapping,
            this.colPLC,
            this.colPLCGroup,
            this.colName,
            this.colAddress,
            this.colDescription,
            this.colDataType,
            this.colPLCKey});
            this.grvPLC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPLC.GridControl = this.grdPLC;
            this.grvPLC.GroupPanelText = "Tab 키를 누르면 HMI Tag 표로 Focus 전환 됩니다.";
            this.grvPLC.IndicatorWidth = 60;
            this.grvPLC.Name = "grvPLC";
            this.grvPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvPLC.OptionsDetail.EnableMasterViewMode = false;
            this.grvPLC.OptionsDetail.SmartDetailExpand = false;
            this.grvPLC.OptionsSelection.MultiSelect = true;
            this.grvPLC.OptionsView.ShowAutoFilterRow = true;
            this.grvPLC.OptionsView.ShowGroupPanel = false;
            this.grvPLC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvPLC_KeyDown);
            // 
            // colMapping
            // 
            this.colMapping.AppearanceCell.Options.UseTextOptions = true;
            this.colMapping.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMapping.AppearanceHeader.Options.UseTextOptions = true;
            this.colMapping.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMapping.Caption = "Is Mapping";
            this.colMapping.FieldName = "IsHMIMapping";
            this.colMapping.Name = "colMapping";
            this.colMapping.OptionsColumn.AllowEdit = false;
            this.colMapping.OptionsColumn.AllowMove = false;
            this.colMapping.OptionsColumn.AllowShowHide = false;
            this.colMapping.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMapping.OptionsColumn.FixedWidth = true;
            this.colMapping.OptionsColumn.ReadOnly = true;
            this.colMapping.Visible = true;
            this.colMapping.VisibleIndex = 0;
            this.colMapping.Width = 70;
            // 
            // colPLC
            // 
            this.colPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.Caption = "PLC";
            this.colPLC.FieldName = "Channel";
            this.colPLC.Name = "colPLC";
            this.colPLC.OptionsColumn.AllowEdit = false;
            this.colPLC.OptionsColumn.AllowShowHide = false;
            this.colPLC.Visible = true;
            this.colPLC.VisibleIndex = 1;
            this.colPLC.Width = 110;
            // 
            // colPLCGroup
            // 
            this.colPLCGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLCGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLCGroup.Caption = "Group";
            this.colPLCGroup.FieldName = "Creator";
            this.colPLCGroup.Name = "colPLCGroup";
            this.colPLCGroup.Visible = true;
            this.colPLCGroup.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowShowHide = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 110;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowShowHide = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 110;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowShowHide = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 110;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowShowHide = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 6;
            this.colDataType.Width = 70;
            // 
            // colPLCKey
            // 
            this.colPLCKey.Caption = "Key";
            this.colPLCKey.FieldName = "Key";
            this.colPLCKey.Name = "colPLCKey";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 409);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(959, 52);
            this.panelControl1.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(878, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 52);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.txtHMIName);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(959, 32);
            this.panelControl2.TabIndex = 11;
            // 
            // txtHMIName
            // 
            this.txtHMIName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtHMIName.EditValue = "HMI TAG NAME";
            this.txtHMIName.Location = new System.Drawing.Point(89, 0);
            this.txtHMIName.Name = "txtHMIName";
            this.txtHMIName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.txtHMIName.Properties.Appearance.Options.UseFont = true;
            this.txtHMIName.Properties.ReadOnly = true;
            this.txtHMIName.Size = new System.Drawing.Size(371, 30);
            this.txtHMIName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 32);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HMI 태그 이름 : ";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdPLC);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 32);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(959, 377);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "추천된 PLC 태그 리스트";
            // 
            // FrmMappingRecommend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 461);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMappingRecommend";
            this.Text = "매핑 PLC 태그 추천";
            this.Load += new System.EventHandler(this.FrmMappingRecommend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHMIName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colPLCGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colPLCKey;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtHMIName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}