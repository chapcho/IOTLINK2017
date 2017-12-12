namespace UDMEnergyViewer
{
    partial class FrmClassifySymbol
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
            this.grpSetting = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpgMachineUnit = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMachineName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlSettingLeft = new System.Windows.Forms.Panel();
            this.cboMeterItemS = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbEnergyGroup = new System.Windows.Forms.Label();
            this.tpgMotionUnit = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpAllCoil = new DevExpress.XtraEditors.GroupControl();
            this.gcAllCoilTable = new DevExpress.XtraGrid.GridControl();
            this.gvAllCoilTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAllCoilAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllCoilDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpMachineTag = new DevExpress.XtraEditors.GroupControl();
            this.gcUnitCoilTable = new DevExpress.XtraGrid.GridControl();
            this.gvUnitCoilTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpSetting)).BeginInit();
            this.grpSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tpgMachineUnit.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName.Properties)).BeginInit();
            this.pnlSettingLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMeterItemS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAllCoil)).BeginInit();
            this.grpAllCoil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAllCoilTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllCoilTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMachineTag)).BeginInit();
            this.grpMachineTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUnitCoilTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnitCoilTable)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSetting
            // 
            this.grpSetting.Controls.Add(this.panelControl1);
            this.grpSetting.Controls.Add(this.xtraTabControl1);
            this.grpSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetting.Location = new System.Drawing.Point(0, 0);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(637, 112);
            this.grpSetting.TabIndex = 0;
            this.grpSetting.Text = "설정";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Controls.Add(this.btnApply);
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(430, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(205, 89);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(109, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 49);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl5
            // 
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl5.Enabled = false;
            this.panelControl5.Location = new System.Drawing.Point(185, 20);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(18, 49);
            this.panelControl5.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApply.Location = new System.Drawing.Point(20, 20);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(77, 49);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Enabled = false;
            this.panelControl4.Location = new System.Drawing.Point(2, 20);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(18, 49);
            this.panelControl4.TabIndex = 4;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Enabled = false;
            this.panelControl3.Location = new System.Drawing.Point(2, 69);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(201, 18);
            this.panelControl3.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Enabled = false;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(201, 18);
            this.panelControl2.TabIndex = 2;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 21);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpgMachineUnit;
            this.xtraTabControl1.Size = new System.Drawing.Size(428, 89);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpgMachineUnit,
            this.tpgMotionUnit});
            // 
            // tpgMachineUnit
            // 
            this.tpgMachineUnit.Controls.Add(this.panel1);
            this.tpgMachineUnit.Controls.Add(this.splitterControl1);
            this.tpgMachineUnit.Controls.Add(this.pnlSettingLeft);
            this.tpgMachineUnit.Name = "tpgMachineUnit";
            this.tpgMachineUnit.Size = new System.Drawing.Size(422, 60);
            this.tpgMachineUnit.Text = "Machine Unit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMachineName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(219, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 60);
            this.panel1.TabIndex = 5;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(6, 29);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(186, 20);
            this.txtMachineName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unit Name";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(214, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 60);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // pnlSettingLeft
            // 
            this.pnlSettingLeft.Controls.Add(this.cboMeterItemS);
            this.pnlSettingLeft.Controls.Add(this.lbEnergyGroup);
            this.pnlSettingLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSettingLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlSettingLeft.Name = "pnlSettingLeft";
            this.pnlSettingLeft.Size = new System.Drawing.Size(214, 60);
            this.pnlSettingLeft.TabIndex = 0;
            // 
            // cboMeterItemS
            // 
            this.cboMeterItemS.EditValue = "";
            this.cboMeterItemS.Location = new System.Drawing.Point(9, 29);
            this.cboMeterItemS.Name = "cboMeterItemS";
            this.cboMeterItemS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMeterItemS.Size = new System.Drawing.Size(199, 20);
            this.cboMeterItemS.TabIndex = 1;
            this.cboMeterItemS.SelectedValueChanged += new System.EventHandler(this.cboMeterItemS_SelectedValueChanged);
            // 
            // lbEnergyGroup
            // 
            this.lbEnergyGroup.Location = new System.Drawing.Point(9, 7);
            this.lbEnergyGroup.Name = "lbEnergyGroup";
            this.lbEnergyGroup.Size = new System.Drawing.Size(82, 14);
            this.lbEnergyGroup.TabIndex = 0;
            this.lbEnergyGroup.Text = "Meter Items";
            // 
            // tpgMotionUnit
            // 
            this.tpgMotionUnit.Name = "tpgMotionUnit";
            this.tpgMotionUnit.Size = new System.Drawing.Size(422, 60);
            this.tpgMotionUnit.Text = "Motion Unit";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 112);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grpAllCoil);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grpMachineTag);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(637, 565);
            this.splitContainerControl1.SplitterPosition = 316;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grpAllCoil
            // 
            this.grpAllCoil.Controls.Add(this.gcAllCoilTable);
            this.grpAllCoil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAllCoil.Location = new System.Drawing.Point(0, 0);
            this.grpAllCoil.Name = "grpAllCoil";
            this.grpAllCoil.Size = new System.Drawing.Size(316, 565);
            this.grpAllCoil.TabIndex = 0;
            this.grpAllCoil.Text = "All Coil Table";
            // 
            // gcAllCoilTable
            // 
            this.gcAllCoilTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAllCoilTable.Location = new System.Drawing.Point(2, 21);
            this.gcAllCoilTable.MainView = this.gvAllCoilTable;
            this.gcAllCoilTable.Name = "gcAllCoilTable";
            this.gcAllCoilTable.Size = new System.Drawing.Size(312, 542);
            this.gcAllCoilTable.TabIndex = 1;
            this.gcAllCoilTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAllCoilTable});
            // 
            // gvAllCoilTable
            // 
            this.gvAllCoilTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAllCoilAddress,
            this.colAllCoilDescription});
            this.gvAllCoilTable.GridControl = this.gcAllCoilTable;
            this.gvAllCoilTable.Name = "gvAllCoilTable";
            this.gvAllCoilTable.OptionsBehavior.Editable = false;
            this.gvAllCoilTable.OptionsSelection.MultiSelect = true;
            this.gvAllCoilTable.OptionsView.ShowAutoFilterRow = true;
            this.gvAllCoilTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MachineTagTable_MouseDown);
            this.gvAllCoilTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MachineTagTable_MouseMove);
            // 
            // colAllCoilAddress
            // 
            this.colAllCoilAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAllCoilAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllCoilAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAllCoilAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllCoilAddress.Caption = "Address";
            this.colAllCoilAddress.FieldName = "Address";
            this.colAllCoilAddress.Name = "colAllCoilAddress";
            this.colAllCoilAddress.Visible = true;
            this.colAllCoilAddress.VisibleIndex = 0;
            this.colAllCoilAddress.Width = 93;
            // 
            // colAllCoilDescription
            // 
            this.colAllCoilDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colAllCoilDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllCoilDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colAllCoilDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllCoilDescription.Caption = "Description";
            this.colAllCoilDescription.FieldName = "Description";
            this.colAllCoilDescription.Name = "colAllCoilDescription";
            this.colAllCoilDescription.Visible = true;
            this.colAllCoilDescription.VisibleIndex = 1;
            this.colAllCoilDescription.Width = 203;
            // 
            // grpMachineTag
            // 
            this.grpMachineTag.Controls.Add(this.gcUnitCoilTable);
            this.grpMachineTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMachineTag.Location = new System.Drawing.Point(0, 0);
            this.grpMachineTag.Name = "grpMachineTag";
            this.grpMachineTag.Size = new System.Drawing.Size(316, 565);
            this.grpMachineTag.TabIndex = 0;
            this.grpMachineTag.Text = "Unit Coil Table";
            // 
            // gcUnitCoilTable
            // 
            this.gcUnitCoilTable.AllowDrop = true;
            this.gcUnitCoilTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUnitCoilTable.Location = new System.Drawing.Point(2, 21);
            this.gcUnitCoilTable.MainView = this.gvUnitCoilTable;
            this.gcUnitCoilTable.Name = "gcUnitCoilTable";
            this.gcUnitCoilTable.Size = new System.Drawing.Size(312, 542);
            this.gcUnitCoilTable.TabIndex = 0;
            this.gcUnitCoilTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUnitCoilTable});
            this.gcUnitCoilTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.MachineTagTable_DragDrop);
            this.gcUnitCoilTable.DragOver += new System.Windows.Forms.DragEventHandler(this.MachineTagTable_DragOver);
            // 
            // gvUnitCoilTable
            // 
            this.gvUnitCoilTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDescription});
            this.gvUnitCoilTable.GridControl = this.gcUnitCoilTable;
            this.gvUnitCoilTable.Name = "gvUnitCoilTable";
            this.gvUnitCoilTable.OptionsBehavior.Editable = false;
            this.gvUnitCoilTable.OptionsSelection.MultiSelect = true;
            this.gvUnitCoilTable.OptionsView.ShowAutoFilterRow = true;
            this.gvUnitCoilTable.OptionsView.ShowGroupPanel = false;
            this.gvUnitCoilTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MachineTagTable_MouseMove);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 93;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 203;
            // 
            // FrmClassifySymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 677);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.grpSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmClassifySymbol";
            this.Text = "Symbol Classification";
            this.Load += new System.EventHandler(this.FrmClassifySymbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSetting)).EndInit();
            this.grpSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tpgMachineUnit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName.Properties)).EndInit();
            this.pnlSettingLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboMeterItemS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpAllCoil)).EndInit();
            this.grpAllCoil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAllCoilTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllCoilTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMachineTag)).EndInit();
            this.grpMachineTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUnitCoilTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnitCoilTable)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.GroupControl grpSetting;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpgMachineUnit;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSettingLeft;
        private DevExpress.XtraEditors.ComboBoxEdit cboMeterItemS;
        private System.Windows.Forms.Label lbEnergyGroup;
        private DevExpress.XtraTab.XtraTabPage tpgMotionUnit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl grpAllCoil;
        private DevExpress.XtraEditors.GroupControl grpMachineTag;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtMachineName;
        private DevExpress.XtraGrid.GridControl gcUnitCoilTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUnitCoilTable;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.GridControl gcAllCoilTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAllCoilTable;
        private DevExpress.XtraGrid.Columns.GridColumn colAllCoilAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colAllCoilDescription;

	}
}