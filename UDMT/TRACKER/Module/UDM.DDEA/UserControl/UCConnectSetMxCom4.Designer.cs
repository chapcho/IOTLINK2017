namespace UDM.DDEA
{
    partial class UCConnectSetMxCom4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCConnectSetMxCom4));
            this.axActWizard = new AxACTUWZDLib.AxActWizard();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpSettingList = new DevExpress.XtraEditors.GroupControl();
            this.radioMxCom4List = new DevExpress.XtraEditors.RadioGroup();
            this.btnSetting = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.axActWizard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSettingList)).BeginInit();
            this.grpSettingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioMxCom4List.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // axActWizard
            // 
            this.axActWizard.Enabled = true;
            this.axActWizard.Location = new System.Drawing.Point(0, 0);
            this.axActWizard.Name = "axActWizard";
            this.axActWizard.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActWizard.OcxState")));
            this.axActWizard.Size = new System.Drawing.Size(0, 0);
            this.axActWizard.TabIndex = 0;
            this.axActWizard.Visible = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grpSettingList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSetting);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(470, 291);
            this.splitContainerControl1.SplitterPosition = 46;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grpSettingList
            // 
            this.grpSettingList.Controls.Add(this.radioMxCom4List);
            this.grpSettingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSettingList.Location = new System.Drawing.Point(0, 0);
            this.grpSettingList.Name = "grpSettingList";
            this.grpSettingList.Size = new System.Drawing.Size(470, 240);
            this.grpSettingList.TabIndex = 0;
            this.grpSettingList.Text = "설정된 List";
            // 
            // radioMxCom4List
            // 
            this.radioMxCom4List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioMxCom4List.Location = new System.Drawing.Point(2, 21);
            this.radioMxCom4List.Name = "radioMxCom4List";
            this.radioMxCom4List.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem()});
            this.radioMxCom4List.Size = new System.Drawing.Size(466, 217);
            this.radioMxCom4List.TabIndex = 0;
            this.radioMxCom4List.SelectedIndexChanged += new System.EventHandler(this.radioMxCom4List_SelectedIndexChanged);
            // 
            // btnSetting
            // 
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(348, 0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(109, 46);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Wizard 열기";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(457, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 46);
            this.panel1.TabIndex = 0;
            // 
            // UCConnectSetMxCom4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axActWizard);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCConnectSetMxCom4";
            this.Size = new System.Drawing.Size(470, 291);
            this.Load += new System.EventHandler(this.UCConnectSetMxCom4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axActWizard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSettingList)).EndInit();
            this.grpSettingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioMxCom4List.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxACTUWZDLib.AxActWizard axActWizard;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl grpSettingList;
        private DevExpress.XtraEditors.RadioGroup radioMxCom4List;
        private DevExpress.XtraEditors.SimpleButton btnSetting;
        private System.Windows.Forms.Panel panel1;
    }
}
