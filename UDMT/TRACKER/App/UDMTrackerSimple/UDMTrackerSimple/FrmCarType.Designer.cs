﻿namespace UDMTrackerSimple
{
    partial class FrmCarType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarType));
            this.pnlCommon = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbWordSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblWordSize = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWordCount = new DevExpress.XtraEditors.LabelControl();
            this.spnWordCount = new DevExpress.XtraEditors.SpinEdit();
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grpCarTypeMapList = new DevExpress.XtraEditors.GroupControl();
            this.grdCarTypeMap = new DevExpress.XtraGrid.GridControl();
            this.cntxCarType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSelectCarType = new System.Windows.Forms.ToolStripMenuItem();
            this.grvCarTypeMap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBitS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWordName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubItemCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommon)).BeginInit();
            this.pnlCommon.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWordSize.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnWordCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCarTypeMapList)).BeginInit();
            this.grpCarTypeMapList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCarTypeMap)).BeginInit();
            this.cntxCarType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCarTypeMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCommon
            // 
            this.pnlCommon.Controls.Add(this.btnClose);
            this.pnlCommon.Controls.Add(this.btnApply);
            this.pnlCommon.Controls.Add(this.panel5);
            this.pnlCommon.Controls.Add(this.btnClear);
            this.pnlCommon.Controls.Add(this.panel6);
            this.pnlCommon.Controls.Add(this.panel3);
            this.pnlCommon.Controls.Add(this.panel2);
            this.pnlCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommon.Location = new System.Drawing.Point(0, 0);
            this.pnlCommon.Name = "pnlCommon";
            this.pnlCommon.Size = new System.Drawing.Size(1178, 48);
            this.pnlCommon.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1086, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 44);
            this.btnClose.TabIndex = 85;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(554, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 44);
            this.btnApply.TabIndex = 81;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(540, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(14, 44);
            this.panel5.TabIndex = 82;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(450, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 44);
            this.btnClear.TabIndex = 83;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(436, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(14, 44);
            this.panel6.TabIndex = 84;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbWordSize);
            this.panel3.Controls.Add(this.lblWordSize);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(212, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 44);
            this.panel3.TabIndex = 2;
            // 
            // cmbWordSize
            // 
            this.cmbWordSize.EditValue = "16 Bit";
            this.cmbWordSize.Location = new System.Drawing.Point(131, 11);
            this.cmbWordSize.Name = "cmbWordSize";
            this.cmbWordSize.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbWordSize.Properties.Appearance.Options.UseFont = true;
            this.cmbWordSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWordSize.Properties.Items.AddRange(new object[] {
            "16 Bit",
            "32 Bit"});
            this.cmbWordSize.Size = new System.Drawing.Size(67, 24);
            this.cmbWordSize.TabIndex = 3;
            // 
            // lblWordSize
            // 
            this.lblWordSize.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblWordSize.Location = new System.Drawing.Point(11, 14);
            this.lblWordSize.Name = "lblWordSize";
            this.lblWordSize.Size = new System.Drawing.Size(102, 18);
            this.lblWordSize.TabIndex = 2;
            this.lblWordSize.Text = "Word Header : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWordCount);
            this.panel2.Controls.Add(this.spnWordCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 44);
            this.panel2.TabIndex = 1;
            // 
            // lblWordCount
            // 
            this.lblWordCount.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblWordCount.Location = new System.Drawing.Point(10, 14);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(93, 18);
            this.lblWordCount.TabIndex = 1;
            this.lblWordCount.Text = "Word Count : ";
            // 
            // spnWordCount
            // 
            this.spnWordCount.EditValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spnWordCount.Location = new System.Drawing.Point(123, 11);
            this.spnWordCount.Name = "spnWordCount";
            this.spnWordCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.spnWordCount.Properties.Appearance.Options.UseFont = true;
            this.spnWordCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnWordCount.Properties.MaxValue = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.spnWordCount.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnWordCount.Size = new System.Drawing.Size(40, 24);
            this.spnWordCount.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.panel1);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 686);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(1178, 44);
            this.pnlControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1162, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 40);
            this.panel1.TabIndex = 0;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptMain.Location = new System.Drawing.Point(0, 48);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpCarTypeMapList);
            this.sptMain.Panel1.MinSize = 500;
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.MinSize = 600;
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1178, 638);
            this.sptMain.SplitterPosition = 600;
            this.sptMain.TabIndex = 2;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // grpCarTypeMapList
            // 
            this.grpCarTypeMapList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpCarTypeMapList.AppearanceCaption.Options.UseFont = true;
            this.grpCarTypeMapList.Controls.Add(this.grdCarTypeMap);
            this.grpCarTypeMapList.Controls.Add(this.panelControl1);
            this.grpCarTypeMapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCarTypeMapList.Location = new System.Drawing.Point(0, 0);
            this.grpCarTypeMapList.Name = "grpCarTypeMapList";
            this.grpCarTypeMapList.Size = new System.Drawing.Size(568, 638);
            this.grpCarTypeMapList.TabIndex = 0;
            this.grpCarTypeMapList.Text = "Car Type Map List";
            // 
            // grdCarTypeMap
            // 
            this.grdCarTypeMap.ContextMenuStrip = this.cntxCarType;
            this.grdCarTypeMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCarTypeMap.Location = new System.Drawing.Point(2, 59);
            this.grdCarTypeMap.MainView = this.grvCarTypeMap;
            this.grdCarTypeMap.Name = "grdCarTypeMap";
            this.grdCarTypeMap.Size = new System.Drawing.Size(564, 577);
            this.grdCarTypeMap.TabIndex = 0;
            this.grdCarTypeMap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCarTypeMap});
            // 
            // cntxCarType
            // 
            this.cntxCarType.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxCarType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectCarType});
            this.cntxCarType.Name = "cntxCarType";
            this.cntxCarType.Size = new System.Drawing.Size(201, 30);
            // 
            // mnuSelectCarType
            // 
            this.mnuSelectCarType.Image = ((System.Drawing.Image)(resources.GetObject("mnuSelectCarType.Image")));
            this.mnuSelectCarType.Name = "mnuSelectCarType";
            this.mnuSelectCarType.Size = new System.Drawing.Size(200, 26);
            this.mnuSelectCarType.Text = "Select Car Type Recipe";
            this.mnuSelectCarType.Click += new System.EventHandler(this.mnuSelectCarType_Click);
            // 
            // grvCarTypeMap
            // 
            this.grvCarTypeMap.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvCarTypeMap.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCarTypeMap.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCarTypeMap.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCarTypeMap.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvCarTypeMap.Appearance.Row.Options.UseFont = true;
            this.grvCarTypeMap.Appearance.Row.Options.UseTextOptions = true;
            this.grvCarTypeMap.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCarTypeMap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBitS,
            this.colWordName,
            this.colItemName,
            this.colSubItemCount});
            this.grvCarTypeMap.GridControl = this.grdCarTypeMap;
            this.grvCarTypeMap.GroupCount = 1;
            this.grvCarTypeMap.Name = "grvCarTypeMap";
            this.grvCarTypeMap.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCarTypeMap.OptionsBehavior.Editable = false;
            this.grvCarTypeMap.OptionsView.ShowDetailButtons = false;
            this.grvCarTypeMap.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWordName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvCarTypeMap.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvCarTypeMap_RowStyle);
            this.grvCarTypeMap.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCarTypeMap_FocusedRowChanged);
            this.grvCarTypeMap.DoubleClick += new System.EventHandler(this.grvCarTypeMap_DoubleClick);
            // 
            // colBitS
            // 
            this.colBitS.Caption = "Bit List";
            this.colBitS.FieldName = "BitPosString";
            this.colBitS.Name = "colBitS";
            this.colBitS.Visible = true;
            this.colBitS.VisibleIndex = 1;
            // 
            // colWordName
            // 
            this.colWordName.Caption = "Word Name";
            this.colWordName.FieldName = "WordName";
            this.colWordName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colWordName.MinWidth = 50;
            this.colWordName.Name = "colWordName";
            this.colWordName.Visible = true;
            this.colWordName.VisibleIndex = 0;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            // 
            // colSubItemCount
            // 
            this.colSubItemCount.Caption = "Sub Item Count";
            this.colSubItemCount.FieldName = "SubItemCount";
            this.colSubItemCount.Name = "colSubItemCount";
            this.colSubItemCount.ToolTip = "To open the window of the details must be a double-click.";
            this.colSubItemCount.Visible = true;
            this.colSubItemCount.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 26);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(564, 33);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(386, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "오른쪽 버튼을 클릭하여 화면에 나타날 차종에 대한 Item을 선택하세요.";
            // 
            // FrmCarType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 730);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlCommon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCarType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Common Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCarType_FormClosing);
            this.Load += new System.EventHandler(this.FrmCarType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommon)).EndInit();
            this.pnlCommon.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWordSize.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnWordCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCarTypeMapList)).EndInit();
            this.grpCarTypeMapList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCarTypeMap)).EndInit();
            this.cntxCarType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvCarTypeMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlCommon;
        private DevExpress.XtraEditors.PanelControl pnlControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbWordSize;
        private DevExpress.XtraEditors.LabelControl lblWordSize;
        private DevExpress.XtraEditors.LabelControl lblWordCount;
        private DevExpress.XtraEditors.SpinEdit spnWordCount;
        private UDM.UI.MySplitContainerControl sptMain;
        private DevExpress.XtraEditors.GroupControl grpCarTypeMapList;
        private DevExpress.XtraGrid.GridControl grdCarTypeMap;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCarTypeMap;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraGrid.Columns.GridColumn colBitS;
        private DevExpress.XtraGrid.Columns.GridColumn colWordName;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colSubItemCount;
        private System.Windows.Forms.ContextMenuStrip cntxCarType;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectCarType;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}