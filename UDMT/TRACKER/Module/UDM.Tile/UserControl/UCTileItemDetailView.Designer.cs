namespace UDM.Tile
{
	partial class UCTileItemDetailView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTileItemDetailView));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnErrorAlert = new DevExpress.XtraEditors.SimpleButton();
			this.btnView1 = new DevExpress.XtraEditors.SimpleButton();
			this.imgBtnList = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.ucFlowResultGanttViewer = new UDM.Project.UCFlowResultGanttViewer();
			this.ucLogicDiagramS = new UDM.LogicViewer.UCLogicDiagramS();
			this.ucLogGanttViewer = new UDM.Project.UCLogGanttViewer();
			this.btnBack = new DevExpress.XtraEditors.SimpleButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.Controls.Add(this.btnErrorAlert, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnView1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnBack, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 520);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// btnErrorAlert
			// 
			this.btnErrorAlert.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnErrorAlert.Appearance.BackColor2 = System.Drawing.Color.Red;
			this.btnErrorAlert.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnErrorAlert.Appearance.Options.UseBackColor = true;
			this.btnErrorAlert.Appearance.Options.UseForeColor = true;
			this.btnErrorAlert.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.btnErrorAlert.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnErrorAlert.Location = new System.Drawing.Point(3, 3);
			this.btnErrorAlert.Name = "btnErrorAlert";
			this.btnErrorAlert.Size = new System.Drawing.Size(587, 72);
			this.btnErrorAlert.TabIndex = 1;
			this.btnErrorAlert.Text = "simpleButton1";
			// 
			// btnView1
			// 
			this.btnView1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnView1.Appearance.Options.UseBackColor = true;
			this.btnView1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnView1.ImageIndex = 1;
			this.btnView1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.btnView1.Location = new System.Drawing.Point(596, 3);
			this.btnView1.Name = "btnView1";
			this.btnView1.Padding = new System.Windows.Forms.Padding(3);
			this.btnView1.Size = new System.Drawing.Size(68, 72);
			this.btnView1.TabIndex = 2;
            this.btnView1.Text = "래더";
			this.btnView1.Click += new System.EventHandler(this.btnView1_Click);
			// 
			// imgBtnList
			// 
			this.imgBtnList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBtnList.ImageStream")));
			this.imgBtnList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgBtnList.Images.SetKeyName(0, "Close_32x32.png");
			this.imgBtnList.Images.SetKeyName(1, "Gantt_32x32.png");
			this.imgBtnList.Images.SetKeyName(2, "Tree_32x32.png");
			// 
			// panel1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
			this.panel1.Controls.Add(this.ucFlowResultGanttViewer);
			this.panel1.Controls.Add(this.ucLogicDiagramS);
			this.panel1.Controls.Add(this.ucLogGanttViewer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 81);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(736, 436);
			this.panel1.TabIndex = 9;
			// 
			// ucFlowResultGanttViewer
			// 
			this.ucFlowResultGanttViewer.Location = new System.Drawing.Point(315, 26);
			this.ucFlowResultGanttViewer.Name = "ucFlowResultGanttViewer";
			this.ucFlowResultGanttViewer.Size = new System.Drawing.Size(239, 113);
			this.ucFlowResultGanttViewer.TabIndex = 2;
			// 
			// ucLogicDiagramS
			// 
			this.ucLogicDiagramS.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ucLogicDiagramS.ContextTabMenuStrip = null;
			this.ucLogicDiagramS.FocusedTab = null;
			this.ucLogicDiagramS.Location = new System.Drawing.Point(279, 176);
			this.ucLogicDiagramS.Name = "ucLogicDiagramS";
			this.ucLogicDiagramS.Size = new System.Drawing.Size(276, 194);
			this.ucLogicDiagramS.TabIndex = 1;
			// 
			// ucLogGanttViewer
			// 
			this.ucLogGanttViewer.Location = new System.Drawing.Point(35, 28);
			this.ucLogGanttViewer.Name = "ucLogGanttViewer";
			this.ucLogGanttViewer.Size = new System.Drawing.Size(176, 148);
			this.ucLogGanttViewer.TabIndex = 0;
			this.ucLogGanttViewer.Visible = false;
			// 
			// btnBack
			// 
			this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnBack.ImageIndex = 0;
			this.btnBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.btnBack.Location = new System.Drawing.Point(670, 3);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(69, 72);
			this.btnBack.TabIndex = 10;
			this.btnBack.Text = "닫기";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// UCTileItemDetailView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "UCTileItemDetailView";
			this.Size = new System.Drawing.Size(742, 520);
			this.Load += new System.EventHandler(this.UCTileItemDetailView_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private DevExpress.XtraEditors.SimpleButton btnErrorAlert;
		private DevExpress.XtraEditors.SimpleButton btnView1;
		private System.Windows.Forms.Panel panel1;
		private UDM.Project.UCLogGanttViewer ucLogGanttViewer;
		private DevExpress.XtraEditors.SimpleButton btnBack;
		private UDM.LogicViewer.UCLogicDiagramS ucLogicDiagramS;
		private UDM.Project.UCFlowResultGanttViewer ucFlowResultGanttViewer;
		private System.Windows.Forms.ImageList imgBtnList;
		//private UDM.LogicViewer.UCLogicDiagram ucLogicDiagram;
	}
}
