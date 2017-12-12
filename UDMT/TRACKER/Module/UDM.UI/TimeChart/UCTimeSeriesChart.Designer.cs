namespace UDM.UI.TimeChart
{
	partial class UCGanttSeriesChart
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
            UDM.UI.TimeChart.CSeriesAxis cSeriesAxis1 = new UDM.UI.TimeChart.CSeriesAxis();
            this.pnlGanttTreeArea = new System.Windows.Forms.Panel();
            this.ucGanttTree = new UDM.UI.TimeChart.UCGanttTree();
            this.pnlGanttTreeHeader = new System.Windows.Forms.Panel();
            this.pnlGanttChartArea = new System.Windows.Forms.Panel();
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.ucItemScrollBar = new UDM.UI.TimeChart.UCItemScrollBar();
            this.ucGanttChart = new UDM.UI.TimeChart.UCGanttChart();
            this.ucTimeLine = new UDM.UI.TimeChart.UCTimeLine();
            this.pnlGanttArea = new System.Windows.Forms.Panel();
            this.sptGanttChart = new UDM.UI.MySplitContainerControl();
            this.pnlSeriesArea = new System.Windows.Forms.Panel();
            this.sptSeriesChart = new UDM.UI.MySplitContainerControl();
            this.pnlSeriesTreeArea = new System.Windows.Forms.Panel();
            this.ucSeriesTree = new UDM.UI.TimeChart.UCSeriesTree();
            this.ucSeriesChart = new UDM.UI.TimeChart.UCSeriesChart();
            this.ucAxisScrollBar = new UDM.UI.TimeChart.UCAxisScrollBar();
            this.ucTimeScrollBar = new UDM.UI.TimeChart.UCTimeScrollBar();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.pnlGanttTreeArea.SuspendLayout();
            this.pnlGanttChartArea.SuspendLayout();
            this.pnlGanttChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGanttChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).BeginInit();
            this.pnlGanttArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptGanttChart)).BeginInit();
            this.sptGanttChart.SuspendLayout();
            this.pnlSeriesArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptSeriesChart)).BeginInit();
            this.sptSeriesChart.SuspendLayout();
            this.pnlSeriesTreeArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSeriesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGanttTreeArea
            // 
            this.pnlGanttTreeArea.Controls.Add(this.ucGanttTree);
            this.pnlGanttTreeArea.Controls.Add(this.pnlGanttTreeHeader);
            this.pnlGanttTreeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttTreeArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttTreeArea.Name = "pnlGanttTreeArea";
            this.pnlGanttTreeArea.Size = new System.Drawing.Size(300, 455);
            this.pnlGanttTreeArea.TabIndex = 0;
            // 
            // ucGanttTree
            // 
            this.ucGanttTree.ColumnHeight = 20;
            this.ucGanttTree.DefaultBarHeight = 12;
            this.ucGanttTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGanttTree.FirstVisibleItem = null;
            this.ucGanttTree.FirstVisibleItemIndex = 0;
            this.ucGanttTree.FocusedItem = null;
            this.ucGanttTree.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ucGanttTree.IsItemMovable = true;
            this.ucGanttTree.ItemHeight = 20;
            this.ucGanttTree.Location = new System.Drawing.Point(0, 19);
            this.ucGanttTree.Name = "ucGanttTree";
            this.ucGanttTree.ScrollValue = 0;
            this.ucGanttTree.ShowAutoFilter = false;
            this.ucGanttTree.ShowCheckBox = false;
            this.ucGanttTree.ShowHScrollBarAlways = false;
            this.ucGanttTree.Size = new System.Drawing.Size(300, 436);
            this.ucGanttTree.TabIndex = 0;
            // 
            // pnlGanttTreeHeader
            // 
            this.pnlGanttTreeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGanttTreeHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGanttTreeHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttTreeHeader.Name = "pnlGanttTreeHeader";
            this.pnlGanttTreeHeader.Size = new System.Drawing.Size(300, 19);
            this.pnlGanttTreeHeader.TabIndex = 1;
            // 
            // pnlGanttChartArea
            // 
            this.pnlGanttChartArea.Controls.Add(this.pnlGanttChart);
            this.pnlGanttChartArea.Controls.Add(this.ucTimeLine);
            this.pnlGanttChartArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttChartArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttChartArea.Name = "pnlGanttChartArea";
            this.pnlGanttChartArea.Size = new System.Drawing.Size(597, 455);
            this.pnlGanttChartArea.TabIndex = 2;
            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.Controls.Add(this.ucItemScrollBar);
            this.pnlGanttChart.Controls.Add(this.ucGanttChart);
            this.pnlGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttChart.Location = new System.Drawing.Point(0, 44);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(597, 411);
            this.pnlGanttChart.TabIndex = 3;
            // 
            // ucItemScrollBar
            // 
            this.ucItemScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucItemScrollBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucItemScrollBar.ItemTree = this.ucGanttTree;
            this.ucItemScrollBar.Location = new System.Drawing.Point(580, 0);
            this.ucItemScrollBar.Name = "ucItemScrollBar";
            this.ucItemScrollBar.Size = new System.Drawing.Size(17, 411);
            this.ucItemScrollBar.TabIndex = 2;
            // 
            // ucGanttChart
            // 
            this.ucGanttChart.BackColor = System.Drawing.Color.White;
            this.ucGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGanttChart.ErrorImage = null;
            this.ucGanttChart.GanttTree = this.ucGanttTree;
            this.ucGanttChart.Image = null;
            this.ucGanttChart.InitialImage = null;
            this.ucGanttChart.IsEditable = false;
            this.ucGanttChart.Location = new System.Drawing.Point(0, 0);
            this.ucGanttChart.Name = "ucGanttChart";
            this.ucGanttChart.Size = new System.Drawing.Size(597, 411);
            this.ucGanttChart.TabIndex = 1;
            this.ucGanttChart.TabStop = false;
            this.ucGanttChart.TimeLine = this.ucTimeLine;
            // 
            // ucTimeLine
            // 
            this.ucTimeLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTimeLine.ErrorImage = null;
            this.ucTimeLine.FirstVisibleTime = new System.DateTime(1, 1, 1, 0, 0, 1, 0);
            this.ucTimeLine.Image = null;
            this.ucTimeLine.InitialImage = null;
            this.ucTimeLine.Location = new System.Drawing.Point(0, 0);
            this.ucTimeLine.Name = "ucTimeLine";
            this.ucTimeLine.RangeFrom = new System.DateTime(((long)(0)));
            this.ucTimeLine.RangeTo = new System.DateTime(((long)(0)));
            this.ucTimeLine.ScrollValue = 1;
            this.ucTimeLine.Size = new System.Drawing.Size(597, 44);
            this.ucTimeLine.TabIndex = 0;
            this.ucTimeLine.TabStop = false;
            this.ucTimeLine.UnitWidth = 20F;
            // 
            // pnlGanttArea
            // 
            this.pnlGanttArea.Controls.Add(this.sptGanttChart);
            this.pnlGanttArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttArea.Name = "pnlGanttArea";
            this.pnlGanttArea.Size = new System.Drawing.Size(907, 455);
            this.pnlGanttArea.TabIndex = 3;
            // 
            // sptGanttChart
            // 
            this.sptGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptGanttChart.Location = new System.Drawing.Point(0, 0);
            this.sptGanttChart.Name = "sptGanttChart";
            this.sptGanttChart.Panel1.Controls.Add(this.pnlGanttTreeArea);
            this.sptGanttChart.Panel1.Text = "Panel1";
            this.sptGanttChart.Panel2.Controls.Add(this.pnlGanttChartArea);
            this.sptGanttChart.Panel2.Text = "Panel2";
            this.sptGanttChart.Size = new System.Drawing.Size(907, 455);
            this.sptGanttChart.SplitterPosition = 300;
            this.sptGanttChart.TabIndex = 3;
            this.sptGanttChart.Text = "splitContainerControl1";
            this.sptGanttChart.SplitterMoving += new DevExpress.XtraEditors.SplitMovingEventHandler(this.sptGanttChart_SplitterMoving);
            this.sptGanttChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sptGanttChart_MouseClick);
            // 
            // pnlSeriesArea
            // 
            this.pnlSeriesArea.Controls.Add(this.sptSeriesChart);
            this.pnlSeriesArea.Controls.Add(this.ucAxisScrollBar);
            this.pnlSeriesArea.Controls.Add(this.ucTimeScrollBar);
            this.pnlSeriesArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeriesArea.Location = new System.Drawing.Point(0, 0);
            this.pnlSeriesArea.Name = "pnlSeriesArea";
            this.pnlSeriesArea.Size = new System.Drawing.Size(907, 110);
            this.pnlSeriesArea.TabIndex = 5;
            // 
            // sptSeriesChart
            // 
            this.sptSeriesChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptSeriesChart.Location = new System.Drawing.Point(0, 0);
            this.sptSeriesChart.Name = "sptSeriesChart";
            this.sptSeriesChart.Panel1.Controls.Add(this.pnlSeriesTreeArea);
            this.sptSeriesChart.Panel1.Text = "Panel1";
            this.sptSeriesChart.Panel2.Controls.Add(this.ucSeriesChart);
            this.sptSeriesChart.Panel2.Text = "Panel2";
            this.sptSeriesChart.Size = new System.Drawing.Size(890, 92);
            this.sptSeriesChart.SplitterPosition = 300;
            this.sptSeriesChart.TabIndex = 5;
            this.sptSeriesChart.Text = "splitContainerControl1";
            this.sptSeriesChart.SplitterMoving += new DevExpress.XtraEditors.SplitMovingEventHandler(this.sptSeriesChart_SplitterMoving);
            this.sptSeriesChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptGanttChart_MouseClick);
            // 
            // pnlSeriesTreeArea
            // 
            this.pnlSeriesTreeArea.Controls.Add(this.ucSeriesTree);
            this.pnlSeriesTreeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeriesTreeArea.Location = new System.Drawing.Point(0, 0);
            this.pnlSeriesTreeArea.Name = "pnlSeriesTreeArea";
            this.pnlSeriesTreeArea.Size = new System.Drawing.Size(300, 92);
            this.pnlSeriesTreeArea.TabIndex = 0;
            // 
            // ucSeriesTree
            // 
            this.ucSeriesTree.ColumnHeight = 18;
            this.ucSeriesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeriesTree.FirstVisibleItem = null;
            this.ucSeriesTree.FirstVisibleItemIndex = 0;
            this.ucSeriesTree.FocusedItem = null;
            this.ucSeriesTree.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ucSeriesTree.IsItemMovable = true;
            this.ucSeriesTree.ItemHeight = 18;
            this.ucSeriesTree.Location = new System.Drawing.Point(0, 0);
            this.ucSeriesTree.Name = "ucSeriesTree";
            this.ucSeriesTree.ScrollValue = 0;
            this.ucSeriesTree.ShowAutoFilter = false;
            this.ucSeriesTree.ShowCheckBox = false;
            this.ucSeriesTree.ShowHScrollBarAlways = true;
            this.ucSeriesTree.Size = new System.Drawing.Size(300, 92);
            this.ucSeriesTree.TabIndex = 0;
            // 
            // ucSeriesChart
            // 
            cSeriesAxis1.MajorTickCount = 10;
            cSeriesAxis1.Maximum = 1F;
            cSeriesAxis1.Minimumn = 0F;
            cSeriesAxis1.MinorTickCount = 2;
            cSeriesAxis1.ShowMinorGrid = true;
            this.ucSeriesChart.Axis = cSeriesAxis1;
            this.ucSeriesChart.AxisScrollValue = 0;
            this.ucSeriesChart.BackColor = System.Drawing.Color.White;
            this.ucSeriesChart.ChartType = UDM.UI.TimeChart.EMSeriesChartType.Line;
            this.ucSeriesChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeriesChart.ErrorImage = null;
            this.ucSeriesChart.Image = null;
            this.ucSeriesChart.InitialImage = null;
            this.ucSeriesChart.Location = new System.Drawing.Point(0, 0);
            this.ucSeriesChart.Name = "ucSeriesChart";
            this.ucSeriesChart.SeriesTree = this.ucSeriesTree;
            this.ucSeriesChart.Size = new System.Drawing.Size(580, 92);
            this.ucSeriesChart.TabIndex = 3;
            this.ucSeriesChart.TabStop = false;
            this.ucSeriesChart.TimeLine = this.ucTimeLine;
            // 
            // ucAxisScrollBar
            // 
            this.ucAxisScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucAxisScrollBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucAxisScrollBar.Location = new System.Drawing.Point(890, 0);
            this.ucAxisScrollBar.Name = "ucAxisScrollBar";
            this.ucAxisScrollBar.SeriesChart = this.ucSeriesChart;
            this.ucAxisScrollBar.Size = new System.Drawing.Size(17, 92);
            this.ucAxisScrollBar.TabIndex = 4;
            // 
            // ucTimeScrollBar
            // 
            this.ucTimeScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucTimeScrollBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucTimeScrollBar.Location = new System.Drawing.Point(0, 92);
            this.ucTimeScrollBar.Name = "ucTimeScrollBar";
            this.ucTimeScrollBar.Size = new System.Drawing.Size(907, 18);
            this.ucTimeScrollBar.TabIndex = 2;
            this.ucTimeScrollBar.TimeLine = this.ucTimeLine;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptMain.Horizontal = false;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.pnlGanttArea);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.pnlSeriesArea);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(907, 575);
            this.sptMain.SplitterPosition = 110;
            this.sptMain.TabIndex = 6;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // UCGanttSeriesChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sptMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "UCGanttSeriesChart";
            this.Size = new System.Drawing.Size(907, 575);
            this.Load += new System.EventHandler(this.UCTimeChart_Load);
            this.pnlGanttTreeArea.ResumeLayout(false);
            this.pnlGanttChartArea.ResumeLayout(false);
            this.pnlGanttChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucGanttChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).EndInit();
            this.pnlGanttArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptGanttChart)).EndInit();
            this.sptGanttChart.ResumeLayout(false);
            this.pnlSeriesArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptSeriesChart)).EndInit();
            this.sptSeriesChart.ResumeLayout(false);
            this.pnlSeriesTreeArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSeriesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlGanttTreeArea;
		private System.Windows.Forms.Panel pnlGanttChartArea;
		private System.Windows.Forms.Panel pnlGanttTreeHeader;
		private UCGanttTree ucGanttTree;
		private UCTimeLine ucTimeLine;
		private UCTimeScrollBar ucTimeScrollBar;
		private System.Windows.Forms.Panel pnlGanttChart;
		private UCItemScrollBar ucItemScrollBar;
		private UCGanttChart ucGanttChart;
        private System.Windows.Forms.Panel pnlGanttArea;
		private System.Windows.Forms.Panel pnlSeriesArea;
		private UCAxisScrollBar ucAxisScrollBar;
		private UCSeriesChart ucSeriesChart;
        private UCSeriesTree ucSeriesTree;
		private System.Windows.Forms.Panel pnlSeriesTreeArea;
        private UDM.UI.MySplitContainerControl sptSeriesChart;
        private UDM.UI.MySplitContainerControl sptMain;
        private UDM.UI.MySplitContainerControl sptGanttChart;
	}
}
