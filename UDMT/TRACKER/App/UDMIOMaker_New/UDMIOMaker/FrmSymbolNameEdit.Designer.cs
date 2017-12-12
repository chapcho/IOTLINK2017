namespace UDMIOMaker
{
    partial class FrmSymbolNameEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolNameEdit));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLevelAdd = new DevExpress.XtraEditors.SimpleButton();
            this.exNameProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.catSymbolName = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowLv1 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv2 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv3 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv4 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv5 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv6 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv7 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv8 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv9 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv10 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv11 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.rowLv12 = new DevExpress.XtraVerticalGrid.Rows.PGridEditorRow();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl14 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnStandardization = new DevExpress.XtraEditors.SimpleButton();
            this.btnStdLView = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exNameProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnLevelAdd);
            this.panelControl1.Controls.Add(this.exNameProperty);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(424, 480);
            this.panelControl1.TabIndex = 0;
            // 
            // btnLevelAdd
            // 
            this.btnLevelAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnLevelAdd.Appearance.Options.UseBackColor = true;
            this.btnLevelAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLevelAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnLevelAdd.Image")));
            this.btnLevelAdd.Location = new System.Drawing.Point(271, 99);
            this.btnLevelAdd.Name = "btnLevelAdd";
            this.btnLevelAdd.Size = new System.Drawing.Size(130, 31);
            this.btnLevelAdd.TabIndex = 23;
            this.btnLevelAdd.Text = "레벨 추가하기";
            this.btnLevelAdd.Click += new System.EventHandler(this.btnLevelAdd_Click);
            // 
            // exNameProperty
            // 
            this.exNameProperty.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.exNameProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exNameProperty.Location = new System.Drawing.Point(0, 93);
            this.exNameProperty.Name = "exNameProperty";
            this.exNameProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exNameProperty.RecordWidth = 135;
            this.exNameProperty.RowHeaderWidth = 65;
            this.exNameProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catSymbolName});
            this.exNameProperty.Size = new System.Drawing.Size(424, 387);
            this.exNameProperty.TabIndex = 5;
            this.exNameProperty.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.exNameProperty_CellValueChanged);
            // 
            // catSymbolName
            // 
            this.catSymbolName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.catSymbolName.Appearance.Options.UseFont = true;
            this.catSymbolName.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowLv1,
            this.rowLv2,
            this.rowLv3,
            this.rowLv4,
            this.rowLv5,
            this.rowLv6,
            this.rowLv7,
            this.rowLv8,
            this.rowLv9,
            this.rowLv10,
            this.rowLv11,
            this.rowLv12});
            this.catSymbolName.Height = 40;
            this.catSymbolName.Name = "catSymbolName";
            this.catSymbolName.Properties.Caption = "심볼 이름 설정";
            // 
            // rowLv1
            // 
            this.rowLv1.Appearance.BackColor = System.Drawing.Color.White;
            this.rowLv1.Appearance.Options.UseBackColor = true;
            this.rowLv1.Height = 40;
            this.rowLv1.Name = "rowLv1";
            this.rowLv1.Properties.Caption = "Lv1";
            this.rowLv1.Properties.FieldName = "Lv1Name";
            // 
            // rowLv2
            // 
            this.rowLv2.Height = 40;
            this.rowLv2.Name = "rowLv2";
            this.rowLv2.Properties.Caption = "Lv2";
            this.rowLv2.Properties.FieldName = "Lv2Name";
            // 
            // rowLv3
            // 
            this.rowLv3.Height = 40;
            this.rowLv3.Name = "rowLv3";
            this.rowLv3.Properties.Caption = "Lv3";
            this.rowLv3.Properties.FieldName = "Lv3Name";
            // 
            // rowLv4
            // 
            this.rowLv4.Height = 40;
            this.rowLv4.Name = "rowLv4";
            this.rowLv4.Properties.Caption = "Lv4";
            this.rowLv4.Properties.FieldName = "Lv4Name";
            // 
            // rowLv5
            // 
            this.rowLv5.Height = 40;
            this.rowLv5.Name = "rowLv5";
            this.rowLv5.Properties.Caption = "Lv5";
            this.rowLv5.Properties.FieldName = "Lv5Name";
            // 
            // rowLv6
            // 
            this.rowLv6.Height = 40;
            this.rowLv6.Name = "rowLv6";
            this.rowLv6.Properties.Caption = "Lv6";
            this.rowLv6.Properties.FieldName = "Lv6Name";
            // 
            // rowLv7
            // 
            this.rowLv7.Height = 40;
            this.rowLv7.Name = "rowLv7";
            this.rowLv7.Properties.Caption = "Lv7";
            this.rowLv7.Properties.FieldName = "Lv7Name";
            // 
            // rowLv8
            // 
            this.rowLv8.Height = 40;
            this.rowLv8.Name = "rowLv8";
            this.rowLv8.Properties.Caption = "Lv8";
            this.rowLv8.Properties.FieldName = "Lv8Name";
            this.rowLv8.Visible = false;
            // 
            // rowLv9
            // 
            this.rowLv9.Height = 40;
            this.rowLv9.Name = "rowLv9";
            this.rowLv9.Properties.Caption = "Lv9";
            this.rowLv9.Properties.FieldName = "Lv9Name";
            this.rowLv9.Visible = false;
            // 
            // rowLv10
            // 
            this.rowLv10.Height = 40;
            this.rowLv10.Name = "rowLv10";
            this.rowLv10.Properties.Caption = "Lv10";
            this.rowLv10.Properties.FieldName = "Lv10Name";
            this.rowLv10.Visible = false;
            // 
            // rowLv11
            // 
            this.rowLv11.Height = 40;
            this.rowLv11.Name = "rowLv11";
            this.rowLv11.Properties.Caption = "Lv11";
            this.rowLv11.Properties.FieldName = "Lv11Name";
            this.rowLv11.Visible = false;
            // 
            // rowLv12
            // 
            this.rowLv12.Height = 40;
            this.rowLv12.Name = "rowLv12";
            this.rowLv12.Properties.Caption = "Lv12";
            this.rowLv12.Properties.FieldName = "Lv12Name";
            this.rowLv12.Visible = false;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.panelControl6);
            this.panelControl3.Controls.Add(this.panelControl14);
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 63);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(424, 30);
            this.panelControl3.TabIndex = 24;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(332, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 14);
            this.labelControl5.TabIndex = 29;
            this.labelControl5.Text = "표준화 진행";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(186, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(107, 14);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "라이브러리 존재 X";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(39, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 14);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "라이브러리 존재 O";
            // 
            // panelControl6
            // 
            this.panelControl6.Appearance.BackColor = System.Drawing.Color.Orange;
            this.panelControl6.Appearance.Options.UseBackColor = true;
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Location = new System.Drawing.Point(299, 5);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(27, 20);
            this.panelControl6.TabIndex = 26;
            // 
            // panelControl14
            // 
            this.panelControl14.Appearance.BackColor = System.Drawing.Color.PaleGreen;
            this.panelControl14.Appearance.Options.UseBackColor = true;
            this.panelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl14.Location = new System.Drawing.Point(6, 5);
            this.panelControl14.Name = "panelControl14";
            this.panelControl14.Size = new System.Drawing.Size(27, 20);
            this.panelControl14.TabIndex = 24;
            // 
            // panelControl5
            // 
            this.panelControl5.Appearance.BackColor = System.Drawing.Color.Salmon;
            this.panelControl5.Appearance.Options.UseBackColor = true;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Location = new System.Drawing.Point(153, 5);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(27, 20);
            this.panelControl5.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "이름 설정 가이드";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(222, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "ex) S509_RBT3_W_9TH_WORK_COMPL";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(6, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(413, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "라인 → 공정 → 설비 → Data Type → 동작 → 상태 순으로 입력하세요.";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnStandardization);
            this.panelControl2.Controls.Add(this.btnStdLView);
            this.panelControl2.Controls.Add(this.btnApply);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 480);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(424, 50);
            this.panelControl2.TabIndex = 1;
            // 
            // btnStandardization
            // 
            this.btnStandardization.Appearance.BackColor = System.Drawing.Color.White;
            this.btnStandardization.Appearance.Options.UseBackColor = true;
            this.btnStandardization.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnStandardization.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStandardization.Image = ((System.Drawing.Image)(resources.GetObject("btnStandardization.Image")));
            this.btnStandardization.Location = new System.Drawing.Point(111, 0);
            this.btnStandardization.Name = "btnStandardization";
            this.btnStandardization.Size = new System.Drawing.Size(90, 50);
            this.btnStandardization.TabIndex = 25;
            this.btnStandardization.Text = "표준화\r\n진행";
            this.btnStandardization.Click += new System.EventHandler(this.btnStandardization_Click);
            // 
            // btnStdLView
            // 
            this.btnStdLView.Appearance.BackColor = System.Drawing.Color.White;
            this.btnStdLView.Appearance.Options.UseBackColor = true;
            this.btnStdLView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnStdLView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStdLView.Image = ((System.Drawing.Image)(resources.GetObject("btnStdLView.Image")));
            this.btnStdLView.Location = new System.Drawing.Point(0, 0);
            this.btnStdLView.Name = "btnStdLView";
            this.btnStdLView.Size = new System.Drawing.Size(111, 50);
            this.btnStdLView.TabIndex = 24;
            this.btnStdLView.Text = "라이브러리\r\n보기";
            this.btnStdLView.Click += new System.EventHandler(this.btnStdLView_Click);
            // 
            // btnApply
            // 
            this.btnApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApply.Appearance.Options.UseBackColor = true;
            this.btnApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(256, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 50);
            this.btnApply.TabIndex = 22;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(343, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 50);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmSymbolNameEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 530);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 38);
            this.Name = "FrmSymbolNameEdit";
            this.Text = "심볼 이름 설정";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSymbolNameEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSymbolNameEdit_FormClosed);
            this.Load += new System.EventHandler(this.FrmSymbolNameEdit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSymbolNameEdit_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exNameProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnStdLView;
        private DevExpress.XtraEditors.SimpleButton btnLevelAdd;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exNameProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catSymbolName;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv1;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv2;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv3;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv4;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv5;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv6;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv7;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv8;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv9;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv10;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv11;
        private DevExpress.XtraVerticalGrid.Rows.PGridEditorRow rowLv12;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnStandardization;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl14;
        private DevExpress.XtraEditors.PanelControl panelControl5;
    }
}