namespace UDMOptimizer
{
    partial class FrmAbnormalCycleVeiwer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbnormalCycleVeiwer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.txtAddress = new DevExpress.XtraBars.BarEditItem();
            this.exEditorText = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtStartTime = new DevExpress.XtraBars.BarEditItem();
            this.txtEndTime = new DevExpress.XtraBars.BarEditItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucChart = new UDM.UI.TimeChart.UCTimeChart();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.tmrLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.txtAddress,
            this.txtStartTime,
            this.btnExit,
            this.txtEndTime});
            this.exBarManager.MaxItemId = 17;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
            this.exEditorFrom,
            this.exEditorText,
            this.repositoryItemTextEdit1});
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.FloatLocation = new System.Drawing.Point(1965, 149);
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.txtAddress, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.txtStartTime, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtEndTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // txtAddress
            // 
            this.txtAddress.Caption = "Address";
            this.txtAddress.Edit = this.exEditorText;
            this.txtAddress.EditWidth = 200;
            this.txtAddress.Id = 1;
            this.txtAddress.Name = "txtAddress";
            // 
            // exEditorText
            // 
            this.exEditorText.AutoHeight = false;
            this.exEditorText.Name = "exEditorText";
            this.exEditorText.ReadOnly = true;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Caption = "이상 발생 시간";
            this.txtStartTime.Edit = this.exEditorText;
            this.txtStartTime.EditValue = new System.DateTime(2015, 2, 18, 21, 2, 4, 835);
            this.txtStartTime.EditWidth = 180;
            this.txtStartTime.Id = 2;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Caption = "- ";
            this.txtEndTime.Edit = this.exEditorText;
            this.txtEndTime.EditWidth = 180;
            this.txtEndTime.Id = 16;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 12;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.LargeImageIndex = 15;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(884, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 497);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 497);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            this.exEditorGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucChart);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 65);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(884, 497);
            this.groupControl1.TabIndex = 4;
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart.Location = new System.Drawing.Point(2, 46);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(880, 449);
            this.ucChart.TabIndex = 58;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(880, 25);
            this.panelControl1.TabIndex = 57;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.txtWordValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(242, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 21);
            this.panel2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(10, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Bar Value :";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.Location = new System.Drawing.Point(69, 0);
            this.txtWordValue.MenuManager = this.exBarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(98, 20);
            this.txtWordValue.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(409, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 21);
            this.panel4.TabIndex = 2;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(11, 0);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator1.TabIndex = 4;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(71, 0);
            this.dtpkIndicator1.MenuManager = this.exBarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblIndicator2);
            this.panel3.Controls.Add(this.dtpkIndicator2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(580, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 21);
            this.panel3.TabIndex = 2;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(5, 0);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator2.TabIndex = 4;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(65, 0);
            this.dtpkIndicator2.MenuManager = this.exBarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(745, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 21);
            this.panel1.TabIndex = 0;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(3, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(56, 21);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(59, 0);
            this.txtInterval.MenuManager = this.exBarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(74, 20);
            this.txtInterval.TabIndex = 3;
            // 
            // tmrLoad
            // 
            this.tmrLoad.Tick += new System.EventHandler(this.tmrLoad_Tick);
            // 
            // FrmAbnormalCycleVeiwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmAbnormalCycleVeiwer";
            this.ShowIcon = false;
            this.Text = "이상신호 Cycle";
            this.Load += new System.EventHandler(this.FrmAbnormalCycleVeiwer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarEditItem txtAddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraBars.BarEditItem txtStartTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorText;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtWordValue;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraBars.BarEditItem txtEndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private UDM.UI.TimeChart.UCTimeChart ucChart;
        private System.Windows.Forms.Timer tmrLoad;
    }
}