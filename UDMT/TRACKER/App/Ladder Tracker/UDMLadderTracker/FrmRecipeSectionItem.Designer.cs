namespace UDMLadderTracker
{
    partial class FrmRecipeSectionItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecipeSectionItem));
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdSectionItem = new DevExpress.XtraGrid.GridControl();
            this.grvSectionItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSectionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSectionItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnRemove);
            this.pnlControl.Controls.Add(this.panel2);
            this.pnlControl.Controls.Add(this.btnAddItem);
            this.pnlControl.Controls.Add(this.panel3);
            this.pnlControl.Controls.Add(this.btnClose);
            this.pnlControl.Controls.Add(this.panel1);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 369);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(670, 44);
            this.pnlControl.TabIndex = 2;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddItem.Location = new System.Drawing.Point(16, 2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 40);
            this.btnAddItem.TabIndex = 82;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(106, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 40);
            this.panel2.TabIndex = 84;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(564, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 83;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(654, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 40);
            this.panel1.TabIndex = 0;
            // 
            // grdSectionItem
            // 
            this.grdSectionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSectionItem.Location = new System.Drawing.Point(0, 0);
            this.grdSectionItem.MainView = this.grvSectionItem;
            this.grdSectionItem.Name = "grdSectionItem";
            this.grdSectionItem.Size = new System.Drawing.Size(670, 369);
            this.grdSectionItem.TabIndex = 3;
            this.grdSectionItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSectionItem});
            // 
            // grvSectionItem
            // 
            this.grvSectionItem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvSectionItem.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSectionItem.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvSectionItem.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSectionItem.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvSectionItem.Appearance.Row.Options.UseFont = true;
            this.grvSectionItem.Appearance.Row.Options.UseTextOptions = true;
            this.grvSectionItem.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSectionItem.ColumnPanelRowHeight = 30;
            this.grvSectionItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemValue,
            this.colItemName});
            this.grvSectionItem.GridControl = this.grdSectionItem;
            this.grvSectionItem.Name = "grvSectionItem";
            this.grvSectionItem.OptionsView.ShowDetailButtons = false;
            this.grvSectionItem.OptionsView.ShowGroupPanel = false;
            this.grvSectionItem.RowHeight = 30;
            // 
            // colItemValue
            // 
            this.colItemValue.Caption = "Item Value (Decimal)";
            this.colItemValue.FieldName = "ItemValue";
            this.colItemValue.Name = "colItemValue";
            this.colItemValue.Visible = true;
            this.colItemValue.VisibleIndex = 1;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(120, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 40);
            this.btnRemove.TabIndex = 85;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 40);
            this.panel3.TabIndex = 86;
            // 
            // FrmRecipeSectionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 413);
            this.ControlBox = false;
            this.Controls.Add(this.grdSectionItem);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRecipeSectionItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recipe Item Detail";
            this.Load += new System.EventHandler(this.FrmRecipeSectionItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSectionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSectionItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlControl;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraGrid.GridControl grdSectionItem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSectionItem;
        private DevExpress.XtraGrid.Columns.GridColumn colItemValue;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private System.Windows.Forms.Panel panel3;
    }
}