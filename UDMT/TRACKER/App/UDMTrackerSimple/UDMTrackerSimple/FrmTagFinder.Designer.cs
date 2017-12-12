namespace UDMTrackerSimple
{
    partial class FrmTagFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTagFinder));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTagAddress = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucStepSelector = new UDMTrackerSimple.UCStepSelector();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagAddress.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 411);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(624, 46);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(543, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.groupBox2);
            this.panelControl2.Controls.Add(this.groupBox1);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.btnClear);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(624, 52);
            this.panelControl2.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Appearance.BackColor = System.Drawing.Color.White;
            this.btnFind.Appearance.Options.UseBackColor = true;
            this.btnFind.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(443, 0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(91, 52);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "찾기";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClear.Appearance.Options.UseBackColor = true;
            this.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(534, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 52);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "지우기";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTagAddress);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(189, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "찾을 내용";
            // 
            // txtTagAddress
            // 
            this.txtTagAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTagAddress.Location = new System.Drawing.Point(3, 18);
            this.txtTagAddress.Name = "txtTagAddress";
            this.txtTagAddress.Size = new System.Drawing.Size(201, 20);
            this.txtTagAddress.TabIndex = 0;
            this.txtTagAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTagAddress_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPLCList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC List";
            // 
            // cboPLCList
            // 
            this.cboPLCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPLCList.Location = new System.Drawing.Point(3, 18);
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCList.Size = new System.Drawing.Size(183, 20);
            this.cboPLCList.TabIndex = 0;
            this.cboPLCList.EditValueChanged += new System.EventHandler(this.cboPLCList_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucStepSelector);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 52);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(624, 359);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "해당 접점이 사용된 Step";
            // 
            // ucStepSelector
            // 
            this.ucStepSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStepSelector.Location = new System.Drawing.Point(2, 21);
            this.ucStepSelector.Name = "ucStepSelector";
            this.ucStepSelector.Size = new System.Drawing.Size(620, 336);
            this.ucStepSelector.TabIndex = 0;
            // 
            // FrmTagFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 457);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 495);
            this.Name = "FrmTagFinder";
            this.Text = "접점 찾기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTagFinder_FormClosing);
            this.Load += new System.EventHandler(this.FrmTagFinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTagAddress.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtTagAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCStepSelector ucStepSelector;
        private DevExpress.XtraEditors.SimpleButton btnClear;
    }
}