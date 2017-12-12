namespace FTOPApp
{
    partial class FrmServerOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServerOption));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkUseACS = new DevExpress.XtraEditors.CheckEdit();
            this.TrancCount = new DevExpress.XtraEditors.TextEdit();
            this.checkUseMES = new DevExpress.XtraEditors.CheckEdit();
            this.checkUseCPS = new DevExpress.XtraEditors.CheckEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.comboInterval = new System.Windows.Forms.ComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseACS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrancCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseMES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseCPS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkUseACS);
            this.layoutControl1.Controls.Add(this.TrancCount);
            this.layoutControl1.Controls.Add(this.checkUseMES);
            this.layoutControl1.Controls.Add(this.checkUseCPS);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.comboMode);
            this.layoutControl1.Controls.Add(this.comboInterval);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(385, 144);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkUseACS
            // 
            this.checkUseACS.EditValue = true;
            this.checkUseACS.Location = new System.Drawing.Point(183, 96);
            this.checkUseACS.Name = "checkUseACS";
            this.checkUseACS.Properties.Caption = "ASC";
            this.checkUseACS.Size = new System.Drawing.Size(173, 19);
            this.checkUseACS.StyleController = this.layoutControl1;
            this.checkUseACS.TabIndex = 11;
            // 
            // TrancCount
            // 
            this.TrancCount.EditValue = "10";
            this.TrancCount.Location = new System.Drawing.Point(114, 62);
            this.TrancCount.Name = "TrancCount";
            this.TrancCount.Size = new System.Drawing.Size(242, 20);
            this.TrancCount.StyleController = this.layoutControl1;
            this.TrancCount.TabIndex = 10;
            // 
            // checkUseMES
            // 
            this.checkUseMES.EditValue = true;
            this.checkUseMES.Location = new System.Drawing.Point(12, 96);
            this.checkUseMES.Name = "checkUseMES";
            this.checkUseMES.Properties.Caption = "Use MES";
            this.checkUseMES.Size = new System.Drawing.Size(81, 19);
            this.checkUseMES.StyleController = this.layoutControl1;
            this.checkUseMES.TabIndex = 9;
            // 
            // checkUseCPS
            // 
            this.checkUseCPS.EditValue = true;
            this.checkUseCPS.Location = new System.Drawing.Point(97, 96);
            this.checkUseCPS.Name = "checkUseCPS";
            this.checkUseCPS.Properties.Caption = "Use CPS";
            this.checkUseCPS.Size = new System.Drawing.Size(82, 19);
            this.checkUseCPS.StyleController = this.layoutControl1;
            this.checkUseCPS.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(183, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(173, 22);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            // 
            // comboMode
            // 
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Items.AddRange(new object[] {
            "Array Mode",
            "Sequence Mode",
            "Thread Que Mode"});
            this.comboMode.Location = new System.Drawing.Point(114, 37);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(242, 22);
            this.comboMode.TabIndex = 5;
            this.comboMode.Text = "Array Mode";
            // 
            // comboInterval
            // 
            this.comboInterval.FormattingEnabled = true;
            this.comboInterval.Items.AddRange(new object[] {
            "100",
            "300",
            "500",
            "1000",
            "1500",
            "2000"});
            this.comboInterval.Location = new System.Drawing.Point(114, 12);
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(242, 22);
            this.comboInterval.TabIndex = 4;
            this.comboInterval.Text = "100";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(368, 153);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.comboInterval;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(348, 25);
            this.layoutControlItem1.Text = "Scan Interval :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboMode;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(348, 25);
            this.layoutControlItem2.Text = "Transport Mode : ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 107);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(171, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnOK;
            this.layoutControlItem4.Location = new System.Drawing.Point(171, 107);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(177, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 74);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(348, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.checkUseCPS;
            this.layoutControlItem5.Location = new System.Drawing.Point(85, 84);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(86, 23);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkUseMES;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(85, 23);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.TrancCount;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem7.Text = "Send Count :";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(99, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkUseACS;
            this.layoutControlItem8.Location = new System.Drawing.Point(171, 84);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(177, 23);
            this.layoutControlItem8.Text = "ACS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // FrmServerOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 144);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmServerOption";
            this.Text = "Server Option";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkUseACS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrancCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseMES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseCPS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.ComboBox comboInterval;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit checkUseCPS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit checkUseMES;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit TrancCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.CheckEdit checkUseACS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}