namespace UDMProfiler
{
    partial class FrmCollectModeSelect
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rdoOutput = new System.Windows.Forms.RadioButton();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.labelControl1);
            this.pnlMain.Controls.Add(this.rdoOutput);
            this.pnlMain.Controls.Add(this.rdoNormal);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(324, 92);
            this.pnlMain.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(278, 28);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "수집된 로그의 모드를 선택해주세요. \r\n(다르면 잘못 출력되거나 출력이 안될 수 있습니다.)";
            // 
            // rdoOutput
            // 
            this.rdoOutput.AutoSize = true;
            this.rdoOutput.Location = new System.Drawing.Point(190, 18);
            this.rdoOutput.Name = "rdoOutput";
            this.rdoOutput.Size = new System.Drawing.Size(77, 18);
            this.rdoOutput.TabIndex = 5;
            this.rdoOutput.Text = "출력 수집";
            this.rdoOutput.UseVisualStyleBackColor = true;
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Checked = true;
            this.rdoNormal.Location = new System.Drawing.Point(36, 18);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(77, 18);
            this.rdoNormal.TabIndex = 4;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "부분 수집";
            this.rdoNormal.UseVisualStyleBackColor = true;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnSelect);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.Location = new System.Drawing.Point(0, 92);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(324, 35);
            this.pnlControl.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(180, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(69, 35);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "선택";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(255, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCollectModeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 127);
            this.ControlBox = false;
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCollectModeSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Mode";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlControl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton rdoOutput;
        private System.Windows.Forms.RadioButton rdoNormal;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}