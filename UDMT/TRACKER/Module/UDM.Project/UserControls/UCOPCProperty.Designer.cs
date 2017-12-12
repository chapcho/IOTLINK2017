namespace UDM.Project.UserControls
{
	partial class UCOPCProperty
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
            this.exEditorOPCServer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorChannel = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.exEditorUpdateRate = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.catOPCServer = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowServerName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.catOPCChannel = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowChannelName = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.catUpdateRate = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowUpdateRate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.cmbServerList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbChannelList = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOPCServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUpdateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // exEditorOPCServer
            // 
            this.exEditorOPCServer.AllowFocused = false;
            this.exEditorOPCServer.AutoHeight = false;
            this.exEditorOPCServer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOPCServer.Name = "exEditorOPCServer";
            // 
            // exEditorChannel
            // 
            this.exEditorChannel.AllowFocused = false;
            this.exEditorChannel.AutoHeight = false;
            this.exEditorChannel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorChannel.Name = "exEditorChannel";
            // 
            // exProperty
            // 
            this.exProperty.AllowDrop = true;
            this.exProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exProperty.Location = new System.Drawing.Point(0, 0);
            this.exProperty.Name = "exProperty";
            this.exProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exProperty.OptionsView.ShowFocusedFrame = false;
            this.exProperty.RecordWidth = 141;
            this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorUpdateRate});
            this.exProperty.RowHeaderWidth = 59;
            this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catOPCServer,
            this.catOPCChannel,
            this.catUpdateRate});
            this.exProperty.Size = new System.Drawing.Size(460, 161);
            this.exProperty.TabIndex = 1;
            // 
            // exEditorUpdateRate
            // 
            this.exEditorUpdateRate.AutoHeight = false;
            this.exEditorUpdateRate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorUpdateRate.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorUpdateRate.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exEditorUpdateRate.Name = "exEditorUpdateRate";
            // 
            // catOPCServer
            // 
            this.catOPCServer.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowServerName});
            this.catOPCServer.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOPCServer.Height = 25;
            this.catOPCServer.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOPCServer.Name = "catOPCServer";
            this.catOPCServer.OptionsRow.AllowFocus = false;
            this.catOPCServer.OptionsRow.AllowMove = false;
            this.catOPCServer.OptionsRow.AllowMoveToCustomizationForm = false;
            this.catOPCServer.OptionsRow.AllowSize = false;
            this.catOPCServer.OptionsRow.DblClickExpanding = false;
            this.catOPCServer.OptionsRow.ShowInCustomizationForm = false;
            this.catOPCServer.Properties.Caption = "OPC Server";
            // 
            // rowServerName
            // 
            this.rowServerName.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowServerName.Height = 25;
            this.rowServerName.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowServerName.Name = "rowServerName";
            this.rowServerName.OptionsRow.AllowMove = false;
            this.rowServerName.OptionsRow.AllowMoveToCustomizationForm = false;
            this.rowServerName.OptionsRow.AllowSize = false;
            this.rowServerName.Properties.Caption = "Server Name";
            this.rowServerName.Properties.FieldName = "ServerName";
            this.rowServerName.Properties.ReadOnly = false;
            this.rowServerName.Properties.RowEdit = this.exEditorOPCServer;
            // 
            // catOPCChannel
            // 
            this.catOPCChannel.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowChannelName});
            this.catOPCChannel.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOPCChannel.Height = 25;
            this.catOPCChannel.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catOPCChannel.Name = "catOPCChannel";
            this.catOPCChannel.OptionsRow.AllowFocus = false;
            this.catOPCChannel.OptionsRow.AllowMove = false;
            this.catOPCChannel.OptionsRow.AllowMoveToCustomizationForm = false;
            this.catOPCChannel.OptionsRow.AllowSize = false;
            this.catOPCChannel.OptionsRow.DblClickExpanding = false;
            this.catOPCChannel.OptionsRow.ShowInCustomizationForm = false;
            this.catOPCChannel.Properties.Caption = "OPC Channel";
            // 
            // rowChannelName
            // 
            this.rowChannelName.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowChannelName.Height = 25;
            this.rowChannelName.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowChannelName.IsChildRowsLoaded = true;
            this.rowChannelName.Name = "rowChannelName";
            this.rowChannelName.OptionsRow.AllowMove = false;
            this.rowChannelName.OptionsRow.AllowMoveToCustomizationForm = false;
            this.rowChannelName.OptionsRow.AllowSize = false;
            this.rowChannelName.Properties.Caption = "Channel Name";
            this.rowChannelName.Properties.FieldName = "ChannelDevice";
            this.rowChannelName.Properties.ReadOnly = false;
            this.rowChannelName.Properties.RowEdit = this.exEditorChannel;
            // 
            // catUpdateRate
            // 
            this.catUpdateRate.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowUpdateRate});
            this.catUpdateRate.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catUpdateRate.Height = 25;
            this.catUpdateRate.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.catUpdateRate.Name = "catUpdateRate";
            this.catUpdateRate.OptionsRow.AllowFocus = false;
            this.catUpdateRate.OptionsRow.AllowMove = false;
            this.catUpdateRate.OptionsRow.AllowMoveToCustomizationForm = false;
            this.catUpdateRate.OptionsRow.AllowSize = false;
            this.catUpdateRate.OptionsRow.DblClickExpanding = false;
            this.catUpdateRate.OptionsRow.ShowInCustomizationForm = false;
            this.catUpdateRate.Properties.Caption = "Update Rate";
            // 
            // rowUpdateRate
            // 
            this.rowUpdateRate.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowUpdateRate.Height = 25;
            this.rowUpdateRate.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
            this.rowUpdateRate.Name = "rowUpdateRate";
            this.rowUpdateRate.OptionsRow.AllowMove = false;
            this.rowUpdateRate.OptionsRow.AllowMoveToCustomizationForm = false;
            this.rowUpdateRate.OptionsRow.AllowSize = false;
            this.rowUpdateRate.Properties.Caption = "Update Rate(ms)";
            this.rowUpdateRate.Properties.FieldName = "UpdateRate";
            this.rowUpdateRate.Properties.RowEdit = this.exEditorUpdateRate;
            // 
            // cmbServerList
            // 
            this.cmbServerList.Location = new System.Drawing.Point(136, 26);
            this.cmbServerList.Name = "cmbServerList";
            this.cmbServerList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbServerList.Properties.Appearance.Options.UseFont = true;
            this.cmbServerList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServerList.Size = new System.Drawing.Size(313, 24);
            this.cmbServerList.TabIndex = 2;
            this.cmbServerList.SelectedIndexChanged += new System.EventHandler(this.cmbServerList_SelectedIndexChanged);
            // 
            // cmbChannelList
            // 
            this.cmbChannelList.Location = new System.Drawing.Point(136, 79);
            this.cmbChannelList.Name = "cmbChannelList";
            this.cmbChannelList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbChannelList.Properties.Appearance.Options.UseFont = true;
            this.cmbChannelList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChannelList.Size = new System.Drawing.Size(313, 24);
            this.cmbChannelList.TabIndex = 3;
            this.cmbChannelList.SelectedIndexChanged += new System.EventHandler(this.cmbChannelList_SelectedIndexChanged);
            // 
            // UCOPCProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbChannelList);
            this.Controls.Add(this.cmbServerList);
            this.Controls.Add(this.exProperty);
            this.Name = "UCOPCProperty";
            this.Size = new System.Drawing.Size(460, 161);
            this.Load += new System.EventHandler(this.UCOPCConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOPCServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUpdateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorUpdateRate;
		private DevExpress.XtraVerticalGrid.Rows.CategoryRow catOPCServer;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow rowServerName;
		private DevExpress.XtraVerticalGrid.Rows.CategoryRow catUpdateRate;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUpdateRate;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catOPCChannel;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowChannelName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbServerList;
        private DevExpress.XtraEditors.ComboBoxEdit cmbChannelList;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorOPCServer;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorChannel;
	}
}
