namespace UDMTrackerSimple
{
    partial class UCPlcCycle
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
            this.sptCycleMain = new UDM.UI.MySplitContainerControl();
            this.sptRealTime = new UDM.UI.MySplitContainerControl();
            this.grpTotalCycleStatisticS = new DevExpress.XtraEditors.GroupControl();
            this.ucProcessCycleStatisticS = new UDMTrackerSimple.UCProcessCycleStatisticS();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.groupProcessCycle = new DevExpress.XtraEditors.GroupControl();
            this.ucProcessCycleBoardS = new UDMTrackerSimple.UCProcessCycleBoardS();
            this.grpCycleInfoDashBoard = new DevExpress.XtraEditors.GroupControl();
            this.ucCycleInfoDashBoard = new UDMTrackerSimple.UCCycleInfoDashBoard();
            ((System.ComponentModel.ISupportInitialize)(this.sptCycleMain)).BeginInit();
            this.sptCycleMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptRealTime)).BeginInit();
            this.sptRealTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTotalCycleStatisticS)).BeginInit();
            this.grpTotalCycleStatisticS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupProcessCycle)).BeginInit();
            this.groupProcessCycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleInfoDashBoard)).BeginInit();
            this.grpCycleInfoDashBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptCycleMain
            // 
            this.sptCycleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptCycleMain.Location = new System.Drawing.Point(0, 0);
            this.sptCycleMain.Name = "sptCycleMain";
            this.sptCycleMain.Panel1.Controls.Add(this.sptRealTime);
            this.sptCycleMain.Panel1.MinSize = 390;
            this.sptCycleMain.Panel1.Text = "Panel1";
            this.sptCycleMain.Panel2.Controls.Add(this.grpCycleInfoDashBoard);
            this.sptCycleMain.Panel2.Text = "Panel2";
            this.sptCycleMain.Size = new System.Drawing.Size(1139, 660);
            this.sptCycleMain.SplitterPosition = 681;
            this.sptCycleMain.TabIndex = 30;
            this.sptCycleMain.Text = "splitContainerControl1";
            this.sptCycleMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptCycleMain_MouseDoubleClick);
            // 
            // sptRealTime
            // 
            this.sptRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptRealTime.Location = new System.Drawing.Point(0, 0);
            this.sptRealTime.Name = "sptRealTime";
            this.sptRealTime.Panel1.Controls.Add(this.grpTotalCycleStatisticS);
            this.sptRealTime.Panel1.Text = "Panel1";
            this.sptRealTime.Panel2.Controls.Add(this.groupProcessCycle);
            this.sptRealTime.Panel2.Text = "Panel2";
            this.sptRealTime.Size = new System.Drawing.Size(681, 660);
            this.sptRealTime.SplitterPosition = 348;
            this.sptRealTime.TabIndex = 42;
            this.sptRealTime.Text = "splitContainerControl1";
            this.sptRealTime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptRealTime_MouseDoubleClick);
            // 
            // grpTotalCycleStatisticS
            // 
            this.grpTotalCycleStatisticS.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpTotalCycleStatisticS.AppearanceCaption.Options.UseFont = true;
            this.grpTotalCycleStatisticS.Controls.Add(this.ucProcessCycleStatisticS);
            this.grpTotalCycleStatisticS.Controls.Add(this.radioGroup);
            this.grpTotalCycleStatisticS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTotalCycleStatisticS.Location = new System.Drawing.Point(0, 0);
            this.grpTotalCycleStatisticS.Name = "grpTotalCycleStatisticS";
            this.grpTotalCycleStatisticS.Size = new System.Drawing.Size(348, 660);
            this.grpTotalCycleStatisticS.TabIndex = 4;
            this.grpTotalCycleStatisticS.Text = "Statistics";
            // 
            // ucProcessCycleStatisticS
            // 
            this.ucProcessCycleStatisticS.AutoScroll = true;
            this.ucProcessCycleStatisticS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessCycleStatisticS.Location = new System.Drawing.Point(2, 26);
            this.ucProcessCycleStatisticS.Name = "ucProcessCycleStatisticS";
            this.ucProcessCycleStatisticS.ProcessS = null;
            this.ucProcessCycleStatisticS.Size = new System.Drawing.Size(344, 632);
            this.ucProcessCycleStatisticS.TabIndex = 5;
            this.ucProcessCycleStatisticS.TotalCycleInfoS = null;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(169, 2);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.Columns = 3;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Daily"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Weekly"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Monthly")});
            this.radioGroup.Size = new System.Drawing.Size(214, 21);
            this.radioGroup.TabIndex = 4;
            this.radioGroup.Visible = false;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // groupProcessCycle
            // 
            this.groupProcessCycle.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupProcessCycle.AppearanceCaption.Options.UseFont = true;
            this.groupProcessCycle.Controls.Add(this.ucProcessCycleBoardS);
            this.groupProcessCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupProcessCycle.Location = new System.Drawing.Point(0, 0);
            this.groupProcessCycle.Name = "groupProcessCycle";
            this.groupProcessCycle.Size = new System.Drawing.Size(323, 660);
            this.groupProcessCycle.TabIndex = 41;
            this.groupProcessCycle.Text = "Real-Time";
            // 
            // ucProcessCycleBoardS
            // 
            this.ucProcessCycleBoardS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessCycleBoardS.Location = new System.Drawing.Point(2, 26);
            this.ucProcessCycleBoardS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucProcessCycleBoardS.Name = "ucProcessCycleBoardS";
            this.ucProcessCycleBoardS.Size = new System.Drawing.Size(319, 632);
            this.ucProcessCycleBoardS.TabIndex = 0;
            // 
            // grpCycleInfoDashBoard
            // 
            this.grpCycleInfoDashBoard.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpCycleInfoDashBoard.AppearanceCaption.Options.UseFont = true;
            this.grpCycleInfoDashBoard.Controls.Add(this.ucCycleInfoDashBoard);
            this.grpCycleInfoDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCycleInfoDashBoard.Location = new System.Drawing.Point(0, 0);
            this.grpCycleInfoDashBoard.Name = "grpCycleInfoDashBoard";
            this.grpCycleInfoDashBoard.Size = new System.Drawing.Size(448, 660);
            this.grpCycleInfoDashBoard.TabIndex = 4;
            this.grpCycleInfoDashBoard.Text = "Analysis";
            // 
            // ucCycleInfoDashBoard
            // 
            this.ucCycleInfoDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCycleInfoDashBoard.Location = new System.Drawing.Point(2, 26);
            this.ucCycleInfoDashBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucCycleInfoDashBoard.Name = "ucCycleInfoDashBoard";
            this.ucCycleInfoDashBoard.PlcProcS = null;
            this.ucCycleInfoDashBoard.Size = new System.Drawing.Size(444, 632);
            this.ucCycleInfoDashBoard.TabIndex = 0;
            // 
            // UCPlcCycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptCycleMain);
            this.Name = "UCPlcCycle";
            this.Size = new System.Drawing.Size(1139, 660);
            this.Load += new System.EventHandler(this.UCPlcCycle_Load);
            this.Resize += new System.EventHandler(this.UCPlcCycle_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sptCycleMain)).EndInit();
            this.sptCycleMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptRealTime)).EndInit();
            this.sptRealTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTotalCycleStatisticS)).EndInit();
            this.grpTotalCycleStatisticS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupProcessCycle)).EndInit();
            this.groupProcessCycle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleInfoDashBoard)).EndInit();
            this.grpCycleInfoDashBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UDM.UI.MySplitContainerControl sptCycleMain;
        private DevExpress.XtraEditors.GroupControl groupProcessCycle;
        private UCProcessCycleBoardS ucProcessCycleBoardS;
        private DevExpress.XtraEditors.GroupControl grpTotalCycleStatisticS;
        private UCProcessCycleStatisticS ucProcessCycleStatisticS;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraEditors.GroupControl grpCycleInfoDashBoard;
        private UCCycleInfoDashBoard ucCycleInfoDashBoard;
        private UDM.UI.MySplitContainerControl sptRealTime;
    }
}
