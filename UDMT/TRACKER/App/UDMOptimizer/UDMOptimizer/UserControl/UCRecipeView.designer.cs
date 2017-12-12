namespace UDMOptimizer
{
    partial class UCRecipeView
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
            this.grpRecipeWord = new DevExpress.XtraEditors.GroupControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.grdRecipeTagS = new DevExpress.XtraGrid.GridControl();
            this.grvRecipeTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCycleOver = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCycleMax = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCycleMin = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblAverage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAverage = new DevExpress.XtraEditors.TextEdit();
            this.cCycleAnalyzedDataBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipeWord)).BeginInit();
            this.grpRecipeWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleOver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCycleAnalyzedDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRecipeWord
            // 
            this.grpRecipeWord.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRecipeWord.AppearanceCaption.Options.UseFont = true;
            this.grpRecipeWord.Controls.Add(this.sptMain);
            this.grpRecipeWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRecipeWord.Location = new System.Drawing.Point(0, 0);
            this.grpRecipeWord.Name = "grpRecipeWord";
            this.grpRecipeWord.Size = new System.Drawing.Size(668, 192);
            this.grpRecipeWord.TabIndex = 0;
            this.grpRecipeWord.Text = "Process Info";
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(2, 25);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grdRecipeTagS);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.panelControl5);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(664, 165);
            this.sptMain.SplitterPosition = 343;
            this.sptMain.TabIndex = 9;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // grdRecipeTagS
            // 
            this.grdRecipeTagS.AllowDrop = true;
            this.grdRecipeTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecipeTagS.Location = new System.Drawing.Point(0, 0);
            this.grdRecipeTagS.MainView = this.grvRecipeTagS;
            this.grdRecipeTagS.Name = "grdRecipeTagS";
            this.grdRecipeTagS.Size = new System.Drawing.Size(343, 165);
            this.grdRecipeTagS.TabIndex = 8;
            this.grdRecipeTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRecipeTagS});
            // 
            // grvRecipeTagS
            // 
            this.grvRecipeTagS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvRecipeTagS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRecipeTagS.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvRecipeTagS.Appearance.Row.Options.UseFont = true;
            this.grvRecipeTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colComment});
            this.grvRecipeTagS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRecipeTagS.GridControl = this.grdRecipeTagS;
            this.grvRecipeTagS.Name = "grvRecipeTagS";
            this.grvRecipeTagS.OptionsBehavior.Editable = false;
            this.grvRecipeTagS.OptionsBehavior.ReadOnly = true;
            this.grvRecipeTagS.OptionsDetail.EnableMasterViewMode = false;
            this.grvRecipeTagS.OptionsDetail.ShowDetailTabs = false;
            this.grvRecipeTagS.OptionsDetail.SmartDetailExpand = false;
            this.grvRecipeTagS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvRecipeTagS.OptionsView.ShowGroupPanel = false;
            this.grvRecipeTagS.RowHeight = 25;
            this.grvRecipeTagS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRecipeTagS_CustomDrawRowIndicator);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 251;
            // 
            // colComment
            // 
            this.colComment.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colComment.AppearanceCell.Options.UseFont = true;
            this.colComment.AppearanceCell.Options.UseTextOptions = true;
            this.colComment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colComment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colComment.AppearanceHeader.Options.UseFont = true;
            this.colComment.AppearanceHeader.Options.UseTextOptions = true;
            this.colComment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colComment.Caption = "Comment";
            this.colComment.FieldName = "Description";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 1;
            this.colComment.Width = 647;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.panelControl4);
            this.panelControl5.Controls.Add(this.panelControl3);
            this.panelControl5.Controls.Add(this.panelControl2);
            this.panelControl5.Controls.Add(this.panelControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(311, 165);
            this.panelControl5.TabIndex = 7;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.labelControl6);
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Controls.Add(this.txtCycleOver);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 122);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(307, 40);
            this.panelControl4.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(18, 11);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(95, 18);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Cycle Over : ";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(268, 11);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(18, 18);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "ea";
            // 
            // txtCycleOver
            // 
            this.txtCycleOver.EditValue = "0";
            this.txtCycleOver.Location = new System.Drawing.Point(119, 8);
            this.txtCycleOver.Name = "txtCycleOver";
            this.txtCycleOver.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycleOver.Properties.Appearance.Options.UseFont = true;
            this.txtCycleOver.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCycleOver.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCycleOver.Properties.ReadOnly = true;
            this.txtCycleOver.Size = new System.Drawing.Size(139, 24);
            this.txtCycleOver.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Controls.Add(this.txtCycleMax);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 82);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(307, 40);
            this.panelControl3.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(24, 11);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 18);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Cycle Max : ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(268, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(25, 18);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "sec";
            // 
            // txtCycleMax
            // 
            this.txtCycleMax.EditValue = "0.0";
            this.txtCycleMax.Location = new System.Drawing.Point(119, 8);
            this.txtCycleMax.Name = "txtCycleMax";
            this.txtCycleMax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycleMax.Properties.Appearance.Options.UseFont = true;
            this.txtCycleMax.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCycleMax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCycleMax.Properties.ReadOnly = true;
            this.txtCycleMax.Size = new System.Drawing.Size(139, 24);
            this.txtCycleMax.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtCycleMin);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(307, 40);
            this.panelControl2.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(28, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Cycle Min : ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(268, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "sec";
            // 
            // txtCycleMin
            // 
            this.txtCycleMin.EditValue = "0.0";
            this.txtCycleMin.Location = new System.Drawing.Point(119, 8);
            this.txtCycleMin.Name = "txtCycleMin";
            this.txtCycleMin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycleMin.Properties.Appearance.Options.UseFont = true;
            this.txtCycleMin.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCycleMin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCycleMin.Properties.ReadOnly = true;
            this.txtCycleMin.Size = new System.Drawing.Size(139, 24);
            this.txtCycleMin.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblAverage);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtAverage);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(307, 40);
            this.panelControl1.TabIndex = 3;
            // 
            // lblAverage
            // 
            this.lblAverage.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(38, 11);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(75, 18);
            this.lblAverage.TabIndex = 0;
            this.lblAverage.Text = "Average : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(268, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "sec";
            // 
            // txtAverage
            // 
            this.txtAverage.EditValue = "0.0";
            this.txtAverage.Location = new System.Drawing.Point(119, 8);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAverage.Properties.Appearance.Options.UseFont = true;
            this.txtAverage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAverage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAverage.Properties.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(139, 24);
            this.txtAverage.TabIndex = 1;
            // 
            // cCycleAnalyzedDataBindingSource
            // 
            this.cCycleAnalyzedDataBindingSource.DataSource = typeof(UDMOptimizer.CCycleAnalyzedData);
            // 
            // UCRecipeView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRecipeWord);
            this.Name = "UCRecipeView";
            this.Size = new System.Drawing.Size(668, 192);
            this.Load += new System.EventHandler(this.UCRecipeView_Load);
            this.Resize += new System.EventHandler(this.UCRecipeView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipeWord)).EndInit();
            this.grpRecipeWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleOver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycleMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCycleAnalyzedDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpRecipeWord;
        private DevExpress.XtraGrid.GridControl grdRecipeTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRecipeTagS;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private UDM.UI.MySplitContainerControl sptMain;
        private System.Windows.Forms.BindingSource cCycleAnalyzedDataBindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCycleMax;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCycleMin;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblAverage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAverage;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtCycleOver;
    }
}
