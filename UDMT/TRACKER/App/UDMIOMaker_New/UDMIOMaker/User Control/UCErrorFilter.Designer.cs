namespace UDMIOMaker
{
    partial class UCErrorFilter
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSheetName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spt2 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spt1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoNotFilter = new DevExpress.XtraEditors.MemoEdit();
            this.memoFilter = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoNotFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.txtSheetName);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.lblText);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(286, 60);
            this.panelControl1.TabIndex = 0;
            // 
            // txtSheetName
            // 
            this.txtSheetName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSheetName.Location = new System.Drawing.Point(0, 36);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Properties.ReadOnly = true;
            this.txtSheetName.Size = new System.Drawing.Size(286, 20);
            this.txtSheetName.TabIndex = 3;
            this.txtSheetName.EditValueChanged += new System.EventHandler(this.txtSheetName_EditValueChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 25);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(286, 11);
            this.panelControl3.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblText.Location = new System.Drawing.Point(0, 11);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(66, 14);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Sheet 이름";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(286, 11);
            this.panelControl2.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.memoFilter);
            this.groupControl1.Controls.Add(this.spt2);
            this.groupControl1.Controls.Add(this.memoNotFilter);
            this.groupControl1.Controls.Add(this.panelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 60);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(286, 297);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "에러 Description 필터";
            // 
            // spt2
            // 
            this.spt2.Dock = System.Windows.Forms.DockStyle.Right;
            this.spt2.Location = new System.Drawing.Point(135, 47);
            this.spt2.Name = "spt2";
            this.spt2.Size = new System.Drawing.Size(5, 248);
            this.spt2.TabIndex = 2;
            this.spt2.TabStop = false;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl6);
            this.panelControl4.Controls.Add(this.spt1);
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 21);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(282, 26);
            this.panelControl4.TabIndex = 1;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.labelControl2);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(138, 2);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(142, 22);
            this.panelControl6.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(138, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "포함 X";
            // 
            // spt1
            // 
            this.spt1.Location = new System.Drawing.Point(133, 2);
            this.spt1.Name = "spt1";
            this.spt1.Size = new System.Drawing.Size(5, 22);
            this.spt1.TabIndex = 3;
            this.spt1.TabStop = false;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(131, 22);
            this.panelControl5.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(127, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "포함 O";
            // 
            // memoNotFilter
            // 
            this.memoNotFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.memoNotFilter.Location = new System.Drawing.Point(140, 47);
            this.memoNotFilter.Name = "memoNotFilter";
            this.memoNotFilter.Size = new System.Drawing.Size(144, 248);
            this.memoNotFilter.TabIndex = 3;
            this.memoNotFilter.EditValueChanged += new System.EventHandler(this.memoNotFilter_EditValueChanged);
            // 
            // memoFilter
            // 
            this.memoFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoFilter.Location = new System.Drawing.Point(2, 47);
            this.memoFilter.Name = "memoFilter";
            this.memoFilter.Size = new System.Drawing.Size(133, 248);
            this.memoFilter.TabIndex = 4;
            this.memoFilter.EditValueChanged += new System.EventHandler(this.memoFilter_EditValueChanged);
            // 
            // UCErrorFilter
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCErrorFilter";
            this.Size = new System.Drawing.Size(286, 357);
            this.Load += new System.EventHandler(this.UCErrorFilter_Load);
            this.Resize += new System.EventHandler(this.UCErrorFilter_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoNotFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtSheetName;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lblText;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SplitterControl spt2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SplitterControl spt1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoFilter;
        private DevExpress.XtraEditors.MemoEdit memoNotFilter;
    }
}
