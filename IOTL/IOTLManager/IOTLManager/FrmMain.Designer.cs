using System;

namespace IOTLManager
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProcessUsagePct = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMemoryUsageMB = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로만들기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.인쇄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인쇄미리보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.끝내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.실행취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다시실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.잘라내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.복사ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.붙여넣기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.모두선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자지정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.내용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인덱스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.검색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시스템ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackupDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestoreDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.구성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabIotlCompSvr = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucCompressorDataManager1 = new IOTLManager.UserControls.UCCompressorDataManager();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.txtQueryString = new System.Windows.Forms.TextBox();
            this.tvIotlTable = new System.Windows.Forms.TreeView();
            this.tabSocketServer = new System.Windows.Forms.TabPage();
            this.ucSocketServer1 = new IOTL.Common.UserControls.UCSocketServer();
            this.ucClock1 = new IOTLManager.UserControls.UCClock();
            this.tabMonitoring = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chartCpuUsage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMemoryAvailable = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabLogConfig = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ucSystemLogTable = new IOTLManager.UserControls.UCSystemLogTable();
            this.timerTimeRefresh = new System.Windows.Forms.Timer(this.components);
            this.ucConfigIOTLinkManager1 = new IOTLManager.UserControls.UCConfigIOTLinkManager();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabIotlCompSvr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.tabSocketServer.SuspendLayout();
            this.tabMonitoring.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMemoryAvailable)).BeginInit();
            this.tabConfig.SuspendLayout();
            this.tabLogConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.lblProcessUsagePct,
            this.lblMemoryUsageMB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblProcessUsagePct
            // 
            this.lblProcessUsagePct.Name = "lblProcessUsagePct";
            this.lblProcessUsagePct.Size = new System.Drawing.Size(24, 17);
            this.lblProcessUsagePct.Text = "0%";
            this.lblProcessUsagePct.ToolTipText = "Process Usage";
            // 
            // lblMemoryUsageMB
            // 
            this.lblMemoryUsageMB.Name = "lblMemoryUsageMB";
            this.lblMemoryUsageMB.Size = new System.Drawing.Size(25, 17);
            this.lblMemoryUsageMB.Text = "MB";
            this.lblMemoryUsageMB.ToolTipText = "Memory Usage";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.편집ToolStripMenuItem,
            this.도구ToolStripMenuItem,
            this.도움말ToolStripMenuItem,
            this.시스템ToolStripMenuItem,
            this.구성ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로만들기ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.toolStripSeparator,
            this.저장ToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem,
            this.toolStripSeparator1,
            this.인쇄ToolStripMenuItem,
            this.인쇄미리보기ToolStripMenuItem,
            this.toolStripSeparator2,
            this.끝내기ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 새로만들기ToolStripMenuItem
            // 
            this.새로만들기ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("새로만들기ToolStripMenuItem.Image")));
            this.새로만들기ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.새로만들기ToolStripMenuItem.Name = "새로만들기ToolStripMenuItem";
            this.새로만들기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.새로만들기ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.새로만들기ToolStripMenuItem.Text = "새로 만들기";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("열기ToolStripMenuItem.Image")));
            this.열기ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("저장ToolStripMenuItem.Image")));
            this.저장ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // 인쇄ToolStripMenuItem
            // 
            this.인쇄ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("인쇄ToolStripMenuItem.Image")));
            this.인쇄ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.인쇄ToolStripMenuItem.Name = "인쇄ToolStripMenuItem";
            this.인쇄ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.인쇄ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.인쇄ToolStripMenuItem.Text = "인쇄";
            // 
            // 인쇄미리보기ToolStripMenuItem
            // 
            this.인쇄미리보기ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("인쇄미리보기ToolStripMenuItem.Image")));
            this.인쇄미리보기ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.인쇄미리보기ToolStripMenuItem.Name = "인쇄미리보기ToolStripMenuItem";
            this.인쇄미리보기ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.인쇄미리보기ToolStripMenuItem.Text = "인쇄 미리 보기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // 끝내기ToolStripMenuItem
            // 
            this.끝내기ToolStripMenuItem.Name = "끝내기ToolStripMenuItem";
            this.끝내기ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.끝내기ToolStripMenuItem.Text = "끝내기";
            // 
            // 편집ToolStripMenuItem
            // 
            this.편집ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.실행취소ToolStripMenuItem,
            this.다시실행ToolStripMenuItem,
            this.toolStripSeparator3,
            this.잘라내기ToolStripMenuItem,
            this.복사ToolStripMenuItem,
            this.붙여넣기ToolStripMenuItem,
            this.toolStripSeparator4,
            this.모두선택ToolStripMenuItem});
            this.편집ToolStripMenuItem.Name = "편집ToolStripMenuItem";
            this.편집ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.편집ToolStripMenuItem.Text = "편집";
            // 
            // 실행취소ToolStripMenuItem
            // 
            this.실행취소ToolStripMenuItem.Name = "실행취소ToolStripMenuItem";
            this.실행취소ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.실행취소ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.실행취소ToolStripMenuItem.Text = "실행 취소";
            // 
            // 다시실행ToolStripMenuItem
            // 
            this.다시실행ToolStripMenuItem.Name = "다시실행ToolStripMenuItem";
            this.다시실행ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.다시실행ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.다시실행ToolStripMenuItem.Text = "다시 실행";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // 잘라내기ToolStripMenuItem
            // 
            this.잘라내기ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("잘라내기ToolStripMenuItem.Image")));
            this.잘라내기ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.잘라내기ToolStripMenuItem.Name = "잘라내기ToolStripMenuItem";
            this.잘라내기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.잘라내기ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.잘라내기ToolStripMenuItem.Text = "잘라내기";
            // 
            // 복사ToolStripMenuItem
            // 
            this.복사ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("복사ToolStripMenuItem.Image")));
            this.복사ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.복사ToolStripMenuItem.Name = "복사ToolStripMenuItem";
            this.복사ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.복사ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.복사ToolStripMenuItem.Text = "복사";
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            this.붙여넣기ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("붙여넣기ToolStripMenuItem.Image")));
            this.붙여넣기ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            this.붙여넣기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.붙여넣기ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // 모두선택ToolStripMenuItem
            // 
            this.모두선택ToolStripMenuItem.Name = "모두선택ToolStripMenuItem";
            this.모두선택ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.모두선택ToolStripMenuItem.Text = "모두 선택";
            // 
            // 도구ToolStripMenuItem
            // 
            this.도구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자지정ToolStripMenuItem,
            this.옵션ToolStripMenuItem});
            this.도구ToolStripMenuItem.Name = "도구ToolStripMenuItem";
            this.도구ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.도구ToolStripMenuItem.Text = "도구";
            // 
            // 사용자지정ToolStripMenuItem
            // 
            this.사용자지정ToolStripMenuItem.Name = "사용자지정ToolStripMenuItem";
            this.사용자지정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.사용자지정ToolStripMenuItem.Text = "사용자 지정";
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.옵션ToolStripMenuItem.Text = "옵션";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.내용ToolStripMenuItem,
            this.인덱스ToolStripMenuItem,
            this.검색ToolStripMenuItem,
            this.toolStripSeparator5,
            this.InfoToolStripMenuItem});
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // 내용ToolStripMenuItem
            // 
            this.내용ToolStripMenuItem.Name = "내용ToolStripMenuItem";
            this.내용ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.내용ToolStripMenuItem.Text = "내용";
            // 
            // 인덱스ToolStripMenuItem
            // 
            this.인덱스ToolStripMenuItem.Name = "인덱스ToolStripMenuItem";
            this.인덱스ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.인덱스ToolStripMenuItem.Text = "인덱스";
            // 
            // 검색ToolStripMenuItem
            // 
            this.검색ToolStripMenuItem.Name = "검색ToolStripMenuItem";
            this.검색ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.검색ToolStripMenuItem.Text = "검색";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(107, 6);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.InfoToolStripMenuItem.Text = "정보...";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // 시스템ToolStripMenuItem
            // 
            this.시스템ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateDatabase,
            this.menuBackupDatabase,
            this.menuRestoreDatabase});
            this.시스템ToolStripMenuItem.Name = "시스템ToolStripMenuItem";
            this.시스템ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.시스템ToolStripMenuItem.Text = "시스템";
            // 
            // menuCreateDatabase
            // 
            this.menuCreateDatabase.Name = "menuCreateDatabase";
            this.menuCreateDatabase.Size = new System.Drawing.Size(170, 22);
            this.menuCreateDatabase.Text = "데이터베이스생성";
            this.menuCreateDatabase.Click += new System.EventHandler(this.CreateDBToolStripMenuItem_Click);
            // 
            // menuBackupDatabase
            // 
            this.menuBackupDatabase.Name = "menuBackupDatabase";
            this.menuBackupDatabase.Size = new System.Drawing.Size(170, 22);
            this.menuBackupDatabase.Text = "데이터베이스백업";
            this.menuBackupDatabase.Click += new System.EventHandler(this.menuBackupDatabase_Click);
            // 
            // menuRestoreDatabase
            // 
            this.menuRestoreDatabase.Name = "menuRestoreDatabase";
            this.menuRestoreDatabase.Size = new System.Drawing.Size(170, 22);
            this.menuRestoreDatabase.Text = "데이터베이스복원";
            this.menuRestoreDatabase.Click += new System.EventHandler(this.menuRestoreDatabase_Click);
            // 
            // 구성ToolStripMenuItem
            // 
            this.구성ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuServerConfig});
            this.구성ToolStripMenuItem.Name = "구성ToolStripMenuItem";
            this.구성ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.구성ToolStripMenuItem.Text = "구성";
            // 
            // menuServerConfig
            // 
            this.menuServerConfig.Name = "menuServerConfig";
            this.menuServerConfig.Size = new System.Drawing.Size(122, 22);
            this.menuServerConfig.Text = "환경설정";
            this.menuServerConfig.Click += new System.EventHandler(this.menuServerConfig_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mainTabControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucSystemLogTable);
            this.splitContainer2.Size = new System.Drawing.Size(1032, 582);
            this.splitContainer2.SplitterDistance = 435;
            this.splitContainer2.TabIndex = 5;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabIotlCompSvr);
            this.mainTabControl.Controls.Add(this.tabDatabase);
            this.mainTabControl.Controls.Add(this.tabSocketServer);
            this.mainTabControl.Controls.Add(this.tabMonitoring);
            this.mainTabControl.Controls.Add(this.tabConfig);
            this.mainTabControl.Controls.Add(this.tabLogConfig);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1032, 435);
            this.mainTabControl.TabIndex = 2;
            // 
            // tabIotlCompSvr
            // 
            this.tabIotlCompSvr.AutoScroll = true;
            this.tabIotlCompSvr.Controls.Add(this.groupBox1);
            this.tabIotlCompSvr.Location = new System.Drawing.Point(4, 22);
            this.tabIotlCompSvr.Name = "tabIotlCompSvr";
            this.tabIotlCompSvr.Padding = new System.Windows.Forms.Padding(3);
            this.tabIotlCompSvr.Size = new System.Drawing.Size(1024, 409);
            this.tabIotlCompSvr.TabIndex = 5;
            this.tabIotlCompSvr.Text = "Compressor Data Manager";
            this.tabIotlCompSvr.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucCompressorDataManager1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 409);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compressor Data Manager";
            // 
            // ucCompressorDataManager1
            // 
            this.ucCompressorDataManager1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ucCompressorDataManager1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucCompressorDataManager1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucCompressorDataManager1.Location = new System.Drawing.Point(3, 17);
            this.ucCompressorDataManager1.Name = "ucCompressorDataManager1";
            this.ucCompressorDataManager1.Size = new System.Drawing.Size(738, 389);
            this.ucCompressorDataManager1.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.splitContainer1);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Size = new System.Drawing.Size(1024, 409);
            this.tabDatabase.TabIndex = 3;
            this.tabDatabase.Text = "DataBase Viewer";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.txtQueryString);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvIotlTable);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 412);
            this.splitContainer1.SplitterDistance = 607;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 390);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query Result";
            // 
            // dataGridReport
            // 
            this.dataGridReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridReport.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridReport.Location = new System.Drawing.Point(3, 17);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.RowTemplate.Height = 23;
            this.dataGridReport.Size = new System.Drawing.Size(601, 370);
            this.dataGridReport.TabIndex = 2;
            // 
            // txtQueryString
            // 
            this.txtQueryString.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtQueryString.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQueryString.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQueryString.Location = new System.Drawing.Point(0, 0);
            this.txtQueryString.Name = "txtQueryString";
            this.txtQueryString.ReadOnly = true;
            this.txtQueryString.Size = new System.Drawing.Size(607, 22);
            this.txtQueryString.TabIndex = 1;
            // 
            // tvIotlTable
            // 
            this.tvIotlTable.BackColor = System.Drawing.SystemColors.Info;
            this.tvIotlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvIotlTable.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tvIotlTable.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tvIotlTable.Location = new System.Drawing.Point(0, 0);
            this.tvIotlTable.Name = "tvIotlTable";
            this.tvIotlTable.Size = new System.Drawing.Size(413, 412);
            this.tvIotlTable.TabIndex = 4;
            this.tvIotlTable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvIotlTable_AfterSelect);
            this.tvIotlTable.DoubleClick += new System.EventHandler(this.tvIotlTable_DoubleClick);
            // 
            // tabSocketServer
            // 
            this.tabSocketServer.Controls.Add(this.ucSocketServer1);
            this.tabSocketServer.Controls.Add(this.ucClock1);
            this.tabSocketServer.Location = new System.Drawing.Point(4, 22);
            this.tabSocketServer.Name = "tabSocketServer";
            this.tabSocketServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSocketServer.Size = new System.Drawing.Size(1024, 409);
            this.tabSocketServer.TabIndex = 4;
            this.tabSocketServer.Text = "SocketServer(Chat)";
            this.tabSocketServer.UseVisualStyleBackColor = true;
            // 
            // ucSocketServer1
            // 
            this.ucSocketServer1.BackColor = System.Drawing.Color.Aquamarine;
            this.ucSocketServer1.ConnectedClientCount = 0;
            this.ucSocketServer1.Location = new System.Drawing.Point(286, 16);
            this.ucSocketServer1.Name = "ucSocketServer1";
            this.ucSocketServer1.ReceivedPacketCount = 0;
            this.ucSocketServer1.SendPacketCount = 0;
            this.ucSocketServer1.ServerCaption = "TCP Socket Server";
            this.ucSocketServer1.Size = new System.Drawing.Size(542, 272);
            this.ucSocketServer1.SocketServerIsStarted = false;
            this.ucSocketServer1.TabIndex = 7;
            // 
            // ucClock1
            // 
            this.ucClock1.Location = new System.Drawing.Point(8, 6);
            this.ucClock1.Name = "ucClock1";
            this.ucClock1.Size = new System.Drawing.Size(272, 79);
            this.ucClock1.TabIndex = 6;
            // 
            // tabMonitoring
            // 
            this.tabMonitoring.Controls.Add(this.groupBox3);
            this.tabMonitoring.Location = new System.Drawing.Point(4, 22);
            this.tabMonitoring.Name = "tabMonitoring";
            this.tabMonitoring.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonitoring.Size = new System.Drawing.Size(1024, 409);
            this.tabMonitoring.TabIndex = 0;
            this.tabMonitoring.Text = "Monitoring";
            this.tabMonitoring.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1018, 403);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monitoring ";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 17);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chartCpuUsage);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chartMemoryAvailable);
            this.splitContainer3.Size = new System.Drawing.Size(1012, 383);
            this.splitContainer3.SplitterDistance = 517;
            this.splitContainer3.TabIndex = 2;
            // 
            // chartCpuUsage
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCpuUsage.ChartAreas.Add(chartArea1);
            this.chartCpuUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartCpuUsage.Legends.Add(legend1);
            this.chartCpuUsage.Location = new System.Drawing.Point(0, 0);
            this.chartCpuUsage.Name = "chartCpuUsage";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCpuUsage.Series.Add(series1);
            this.chartCpuUsage.Size = new System.Drawing.Size(515, 381);
            this.chartCpuUsage.TabIndex = 0;
            this.chartCpuUsage.Text = "Cpu Usage";
            this.chartCpuUsage.Click += new System.EventHandler(this.chartCpuUsage_Click);
            // 
            // chartMemoryAvailable
            // 
            this.chartMemoryAvailable.BorderSkin.BackSecondaryColor = System.Drawing.Color.Lime;
            chartArea2.Name = "ChartArea1";
            this.chartMemoryAvailable.ChartAreas.Add(chartArea2);
            this.chartMemoryAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartMemoryAvailable.Legends.Add(legend2);
            this.chartMemoryAvailable.Location = new System.Drawing.Point(0, 0);
            this.chartMemoryAvailable.Name = "chartMemoryAvailable";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMemoryAvailable.Series.Add(series2);
            this.chartMemoryAvailable.Size = new System.Drawing.Size(489, 381);
            this.chartMemoryAvailable.TabIndex = 1;
            this.chartMemoryAvailable.Text = "chart1";
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.ucConfigIOTLinkManager1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(1024, 409);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "Configure";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // tabLogConfig
            // 
            this.tabLogConfig.Controls.Add(this.button2);
            this.tabLogConfig.Controls.Add(this.button1);
            this.tabLogConfig.Location = new System.Drawing.Point(4, 22);
            this.tabLogConfig.Name = "tabLogConfig";
            this.tabLogConfig.Size = new System.Drawing.Size(1024, 409);
            this.tabLogConfig.TabIndex = 2;
            this.tabLogConfig.Text = "System Log";
            this.tabLogConfig.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 68);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "테스트 하세요.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Size = new System.Drawing.Size(1032, 143);
            this.ucSystemLogTable.TabIndex = 4;
            // 
            // timerTimeRefresh
            // 
            this.timerTimeRefresh.Enabled = true;
            this.timerTimeRefresh.Interval = 1000;
            this.timerTimeRefresh.Tick += new System.EventHandler(this.timerTimeRefresh_Tick);
            // 
            // ucConfigIOTLinkManager1
            // 
            this.ucConfigIOTLinkManager1.Location = new System.Drawing.Point(20, 20);
            this.ucConfigIOTLinkManager1.Name = "ucConfigIOTLinkManager1";
            this.ucConfigIOTLinkManager1.Size = new System.Drawing.Size(591, 278);
            this.ucConfigIOTLinkManager1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 628);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "IOTLink Data Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabIotlCompSvr.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.tabSocketServer.ResumeLayout(false);
            this.tabMonitoring.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMemoryAvailable)).EndInit();
            this.tabConfig.ResumeLayout(false);
            this.tabLogConfig.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로만들기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 인쇄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인쇄미리보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 끝내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 실행취소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다시실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 잘라내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 복사ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 모두선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자지정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 내용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인덱스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 검색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabMonitoring;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabLogConfig;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabSocketServer;
        private System.Windows.Forms.ToolStripMenuItem 시스템ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuCreateDatabase;
        private UserControls.UCSystemLogTable ucSystemLogTable;
        private UserControls.UCClock ucClock1;
        private System.Windows.Forms.ToolStripMenuItem 구성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuServerConfig;
        private System.Windows.Forms.ToolStripMenuItem menuBackupDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuRestoreDatabase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabIotlCompSvr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvIotlTable;
        private IOTL.Common.UserControls.UCSocketServer ucSocketServer1;
        private UserControls.UCCompressorDataManager ucCompressorDataManager1;
        public System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtQueryString;
        private System.Windows.Forms.Timer timerTimeRefresh;
        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessUsagePct;
        private System.Windows.Forms.ToolStripStatusLabel lblMemoryUsageMB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMemoryAvailable;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCpuUsage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private UserControls.UCConfigIOTLinkManager ucConfigIOTLinkManager1;
    }
}