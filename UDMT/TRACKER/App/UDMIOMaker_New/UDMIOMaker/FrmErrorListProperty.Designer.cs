namespace UDMIOMaker
{
    partial class FrmErrorListProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmErrorListProperty));
            this.tabError = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSheetDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSheetAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabError)).BeginInit();
            this.tabError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabError
            // 
            this.tabError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabError.Location = new System.Drawing.Point(0, 0);
            this.tabError.Name = "tabError";
            this.tabError.SelectedTabPage = this.xtraTabPage1;
            this.tabError.Size = new System.Drawing.Size(389, 485);
            this.tabError.TabIndex = 0;
            this.tabError.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(383, 456);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(383, 456);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSheetDelete);
            this.panelControl1.Controls.Add(this.btnSheetAdd);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 485);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(389, 49);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSheetDelete
            // 
            this.btnSheetDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSheetDelete.Appearance.Options.UseBackColor = true;
            this.btnSheetDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSheetDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSheetDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnSheetDelete.Image")));
            this.btnSheetDelete.Location = new System.Drawing.Point(96, 0);
            this.btnSheetDelete.Name = "btnSheetDelete";
            this.btnSheetDelete.Size = new System.Drawing.Size(96, 49);
            this.btnSheetDelete.TabIndex = 13;
            this.btnSheetDelete.Text = "시트 제거";
            this.btnSheetDelete.Click += new System.EventHandler(this.btnSheetDelete_Click);
            // 
            // btnSheetAdd
            // 
            this.btnSheetAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSheetAdd.Appearance.Options.UseBackColor = true;
            this.btnSheetAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSheetAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSheetAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnSheetAdd.Image")));
            this.btnSheetAdd.Location = new System.Drawing.Point(0, 0);
            this.btnSheetAdd.Name = "btnSheetAdd";
            this.btnSheetAdd.Size = new System.Drawing.Size(96, 49);
            this.btnSheetAdd.TabIndex = 12;
            this.btnSheetAdd.Text = "시트 추가";
            this.btnSheetAdd.Click += new System.EventHandler(this.btnSheetAdd_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(225, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 49);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Apply";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(308, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 49);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmErrorListProperty
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 534);
            this.Controls.Add(this.tabError);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmErrorListProperty";
            this.Text = "에러 리스트 필터 확인";
            this.Load += new System.EventHandler(this.FrmErrorListProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabError)).EndInit();
            this.tabError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabError;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSheetDelete;
        private DevExpress.XtraEditors.SimpleButton btnSheetAdd;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}