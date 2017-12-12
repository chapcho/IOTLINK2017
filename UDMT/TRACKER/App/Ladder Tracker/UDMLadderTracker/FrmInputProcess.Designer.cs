namespace UDMLadderTracker
{
    partial class FrmInputProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputProcess));
            this.stpMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCommentSplit = new DevExpress.XtraGrid.GridControl();
            this.grvCommentSplit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exShowCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grpProcessTree = new DevExpress.XtraEditors.GroupControl();
            this.ucProcessTree = new UDMLadderTracker.UCProcessTree();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnResetAbnormal = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtAbnormalFilter = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtFilter = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.btnInitText = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.stpMain)).BeginInit();
            this.stpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommentSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCommentSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessTree)).BeginInit();
            this.grpProcessTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpMain
            // 
            this.stpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpMain.Location = new System.Drawing.Point(0, 0);
            this.stpMain.Name = "stpMain";
            this.stpMain.Panel1.Controls.Add(this.grdCommentSplit);
            this.stpMain.Panel1.Controls.Add(this.panelControl1);
            this.stpMain.Panel1.Text = "Panel1";
            this.stpMain.Panel2.Controls.Add(this.grpProcessTree);
            this.stpMain.Panel2.Controls.Add(this.panelControl2);
            this.stpMain.Panel2.Controls.Add(this.pnlFilter);
            this.stpMain.Panel2.Text = "Panel2";
            this.stpMain.Size = new System.Drawing.Size(1005, 526);
            this.stpMain.SplitterPosition = 368;
            this.stpMain.TabIndex = 0;
            this.stpMain.Text = "splitContainerControl1";
            // 
            // grdCommentSplit
            // 
            this.grdCommentSplit.AllowDrop = true;
            this.grdCommentSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCommentSplit.Location = new System.Drawing.Point(0, 52);
            this.grdCommentSplit.MainView = this.grvCommentSplit;
            this.grdCommentSplit.Name = "grdCommentSplit";
            this.grdCommentSplit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exShowCheck});
            this.grdCommentSplit.Size = new System.Drawing.Size(368, 474);
            this.grdCommentSplit.TabIndex = 8;
            this.grdCommentSplit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCommentSplit});
            this.grdCommentSplit.DragOver += new System.Windows.Forms.DragEventHandler(this.grdCommentSplit_DragOver);
            // 
            // grvCommentSplit
            // 
            this.grvCommentSplit.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grvCommentSplit.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCommentSplit.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCommentSplit.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCommentSplit.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvCommentSplit.Appearance.Row.Options.UseFont = true;
            this.grvCommentSplit.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvCommentSplit.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvCommentSplit.ColumnPanelRowHeight = 25;
            this.grvCommentSplit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComment});
            this.grvCommentSplit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvCommentSplit.GridControl = this.grdCommentSplit;
            this.grvCommentSplit.IndicatorWidth = 50;
            this.grvCommentSplit.Name = "grvCommentSplit";
            this.grvCommentSplit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvCommentSplit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvCommentSplit.OptionsDetail.AllowZoomDetail = false;
            this.grvCommentSplit.OptionsDetail.EnableMasterViewMode = false;
            this.grvCommentSplit.OptionsDetail.ShowDetailTabs = false;
            this.grvCommentSplit.OptionsDetail.SmartDetailExpand = false;
            this.grvCommentSplit.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCommentSplit.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvCommentSplit.OptionsSelection.MultiSelect = true;
            this.grvCommentSplit.OptionsView.ShowAutoFilterRow = true;
            this.grvCommentSplit.OptionsView.ShowGroupPanel = false;
            this.grvCommentSplit.RowHeight = 25;
            this.grvCommentSplit.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colComment, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvCommentSplit.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvCommentSplit_CustomDrawRowIndicator);
            this.grvCommentSplit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvCommentSplit_MouseMove);
            // 
            // colComment
            // 
            this.colComment.Caption = "Text";
            this.colComment.FieldName = "Text";
            this.colComment.MinWidth = 80;
            this.colComment.Name = "colComment";
            this.colComment.OptionsColumn.AllowEdit = false;
            this.colComment.OptionsColumn.FixedWidth = true;
            this.colComment.OptionsColumn.ReadOnly = true;
            this.colComment.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 0;
            this.colComment.Width = 80;
            // 
            // exShowCheck
            // 
            this.exShowCheck.AutoHeight = false;
            this.exShowCheck.Name = "exShowCheck";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(368, 52);
            this.panelControl1.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtProcessName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(295, 48);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "직접 입력란";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessName.Location = new System.Drawing.Point(136, 21);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessName.Properties.Appearance.Options.UseFont = true;
            this.txtProcessName.Size = new System.Drawing.Size(157, 26);
            this.txtProcessName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(2, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(134, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Process Name  :   ";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(297, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpProcessTree
            // 
            this.grpProcessTree.Controls.Add(this.ucProcessTree);
            this.grpProcessTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcessTree.Location = new System.Drawing.Point(260, 43);
            this.grpProcessTree.Name = "grpProcessTree";
            this.grpProcessTree.Size = new System.Drawing.Size(372, 483);
            this.grpProcessTree.TabIndex = 2;
            this.grpProcessTree.Text = "Process Tree View";
            // 
            // ucProcessTree
            // 
            this.ucProcessTree.AbnormalFilter = null;
            this.ucProcessTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessTree.Location = new System.Drawing.Point(2, 21);
            this.ucProcessTree.Name = "ucProcessTree";
            this.ucProcessTree.Size = new System.Drawing.Size(368, 460);
            this.ucProcessTree.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnResetAbnormal);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(260, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(372, 43);
            this.panelControl2.TabIndex = 3;
            // 
            // btnResetAbnormal
            // 
            this.btnResetAbnormal.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResetAbnormal.Image = ((System.Drawing.Image)(resources.GetObject("btnResetAbnormal.Image")));
            this.btnResetAbnormal.Location = new System.Drawing.Point(244, 2);
            this.btnResetAbnormal.Name = "btnResetAbnormal";
            this.btnResetAbnormal.Size = new System.Drawing.Size(126, 39);
            this.btnResetAbnormal.TabIndex = 3;
            this.btnResetAbnormal.Text = "Abnormal\r\n초기화";
            this.btnResetAbnormal.Click += new System.EventHandler(this.btnResetAbnormal_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.groupControl4);
            this.pnlFilter.Controls.Add(this.groupControl3);
            this.pnlFilter.Controls.Add(this.pnlControl);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(260, 526);
            this.pnlFilter.TabIndex = 1;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtAbnormalFilter);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(132, 43);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(126, 481);
            this.groupControl4.TabIndex = 6;
            this.groupControl4.Text = "Abnormal Filter";
            // 
            // txtAbnormalFilter
            // 
            this.txtAbnormalFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAbnormalFilter.EditValue = "이상\r\n에러\r\nError\r\nErr\r\n안전\r\n비상\r\nWarning\r\nAlarm";
            this.txtAbnormalFilter.Location = new System.Drawing.Point(2, 37);
            this.txtAbnormalFilter.Name = "txtAbnormalFilter";
            this.txtAbnormalFilter.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtAbnormalFilter.Properties.Appearance.Options.UseFont = true;
            this.txtAbnormalFilter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbnormalFilter.Size = new System.Drawing.Size(122, 442);
            this.txtAbnormalFilter.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl3.Location = new System.Drawing.Point(2, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(122, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "포함 O";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtFilter);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(2, 43);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(130, 481);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Process Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.EditValue = "이상\r\n차종\r\n서열\r\nDATA\r\nGOT\r\nPROG\r\n준비\r\n용접\r\n인터록\r\n정지\r\n고장\r\n간섭\r\n자동\r\n항상\r\n대차\r\n급전\r\n로보트\r\n지그\r\n공기" +
    "압\r\n파트\r\n후크\r\n자동\r\n수동\r\n차종\r\n완료\r\n불량\r\n옵션\r\n급기\r\n기동\r\n선택\r\nPROG\r\nLAMP\r\n램프\r\n확인\r\n호출\r\n원위치\r\n팁\r\n외" +
    "부\r\n하강\r\n상승\r\n전진\r\n후진\r\nALL\r\n헤밍\r\n셔틀";
            this.txtFilter.Location = new System.Drawing.Point(2, 37);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.txtFilter.Properties.Appearance.Options.UseFont = true;
            this.txtFilter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Size = new System.Drawing.Size(126, 442);
            this.txtFilter.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(2, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(126, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "포함 X";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnInitText);
            this.pnlControl.Controls.Add(this.btnApply);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(2, 2);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(256, 41);
            this.pnlControl.TabIndex = 2;
            // 
            // btnInitText
            // 
            this.btnInitText.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInitText.Image = ((System.Drawing.Image)(resources.GetObject("btnInitText.Image")));
            this.btnInitText.Location = new System.Drawing.Point(2, 2);
            this.btnInitText.Name = "btnInitText";
            this.btnInitText.Size = new System.Drawing.Size(80, 37);
            this.btnInitText.TabIndex = 2;
            this.btnInitText.Text = "초기화";
            this.btnInitText.Click += new System.EventHandler(this.btnInitText_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(174, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 37);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FrmInputProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 526);
            this.Controls.Add(this.stpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInputProcess";
            this.Text = "User Input Process";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInputProcess_FormClosing);
            this.Load += new System.EventHandler(this.FrmInputProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stpMain)).EndInit();
            this.stpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCommentSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCommentSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessTree)).EndInit();
            this.grpProcessTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl stpMain;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.PanelControl pnlControl;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.SimpleButton btnInitText;
        private DevExpress.XtraGrid.GridControl grdCommentSplit;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCommentSplit;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exShowCheck;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl grpProcessTree;
        private UCProcessTree ucProcessTree;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.MemoEdit txtAbnormalFilter;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.MemoEdit txtFilter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnResetAbnormal;
    }
}