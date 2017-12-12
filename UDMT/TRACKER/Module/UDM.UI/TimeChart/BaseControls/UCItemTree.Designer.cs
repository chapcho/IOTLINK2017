namespace UDM.UI.TimeChart
{
	partial class UCItemTree
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
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lavender;
            this.exTreeList.Appearance.FocusedRow.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.exTreeList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.exTreeList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.exTreeList.Appearance.FocusedRow.Options.UseFont = true;
            this.exTreeList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.exTreeList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.exTreeList.Appearance.HeaderPanel.Options.UseFont = true;
            this.exTreeList.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.exTreeList.Appearance.Row.Options.UseFont = true;
            this.exTreeList.Appearance.SelectedRow.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.exTreeList.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Blue;
            this.exTreeList.Appearance.SelectedRow.Options.UseFont = true;
            this.exTreeList.Appearance.SelectedRow.Options.UseForeColor = true;
            this.exTreeList.BandPanelRowHeight = 22;
            this.exTreeList.ColumnPanelRowHeight = 30;
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Font = new System.Drawing.Font("Tahoma", 11F);
            this.exTreeList.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsSelection.MultiSelect = true;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.exTreeList.RowHeight = 30;
            this.exTreeList.Size = new System.Drawing.Size(200, 100);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.exTreeList_AfterExpand);
            this.exTreeList.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.exTreeList_AfterCollapse);
            this.exTreeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.exTreeList_AfterCheckNode);
            this.exTreeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.exTreeList_FocusedNodeChanged);
            this.exTreeList.TopVisibleNodeIndexChanged += new System.EventHandler(this.exTreeList_TopVisibleNodeIndexChanged);
            this.exTreeList.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.exTreeList_CellValueChanged);
            this.exTreeList.EndSorting += new System.EventHandler(this.exTreeList_EndSorting);
            this.exTreeList.LayoutUpdated += new System.EventHandler(this.exTreeList_LayoutUpdated);
            this.exTreeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragDrop);
            this.exTreeList.DragOver += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragOver);
            this.exTreeList.Paint += new System.Windows.Forms.PaintEventHandler(this.exTreeList_Paint);
            this.exTreeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exTreeList_KeyDown);
            this.exTreeList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.exTreeList_KeyUp);
            this.exTreeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseMove);
            this.exTreeList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseUp);
            // 
            // UCItemTree
            // 
            this.Controls.Add(this.exTreeList);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		protected DevExpress.XtraTreeList.TreeList exTreeList;


	}
}
