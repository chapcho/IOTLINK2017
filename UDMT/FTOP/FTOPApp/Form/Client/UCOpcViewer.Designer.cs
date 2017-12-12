namespace FTOPApp
{
    partial class UCOpcViewer
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboBoxNetworkAdapter = new System.Windows.Forms.ComboBox();
            this.comboInterval = new System.Windows.Forms.ComboBox();
            this.btnTagView = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.exGrid = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.comboBoxNetworkAdapter);
            this.layoutControl1.Controls.Add(this.comboInterval);
            this.layoutControl1.Controls.Add(this.btnTagView);
            this.layoutControl1.Controls.Add(this.btnGenerate);
            this.layoutControl1.Controls.Add(this.exGrid);
            this.layoutControl1.Controls.Add(this.comboClient);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(408, 351);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboBoxNetworkAdapter
            // 
            this.comboBoxNetworkAdapter.FormattingEnabled = true;
            this.comboBoxNetworkAdapter.Location = new System.Drawing.Point(316, 37);
            this.comboBoxNetworkAdapter.Name = "comboBoxNetworkAdapter";
            this.comboBoxNetworkAdapter.Size = new System.Drawing.Size(80, 20);
            this.comboBoxNetworkAdapter.TabIndex = 10;
            // 
            // comboInterval
            // 
            this.comboInterval.FormattingEnabled = true;
            this.comboInterval.Items.AddRange(new object[] {
            "500",
            "700",
            "1000"});
            this.comboInterval.Location = new System.Drawing.Point(122, 37);
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(80, 20);
            this.comboInterval.TabIndex = 9;
            this.comboInterval.Text = "1000";
            // 
            // btnTagView
            // 
            this.btnTagView.Location = new System.Drawing.Point(12, 317);
            this.btnTagView.Name = "btnTagView";
            this.btnTagView.Size = new System.Drawing.Size(190, 22);
            this.btnTagView.StyleController = this.layoutControl1;
            this.btnTagView.TabIndex = 8;
            this.btnTagView.Text = "Get OPCTag";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(206, 317);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(190, 22);
            this.btnGenerate.StyleController = this.layoutControl1;
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate OPC Infomation";
            // 
            // exGrid
            // 
            this.exGrid.Location = new System.Drawing.Point(12, 62);
            this.exGrid.MainView = this.exGridView;
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(384, 251);
            this.exGrid.TabIndex = 6;
            this.exGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.GridControl = this.exGrid;
            this.exGridView.Name = "exGridView";
            // 
            // comboClient
            // 
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Items.AddRange(new object[] {
            "FTOPClient1",
            "FTOPClient2"});
            this.comboClient.Location = new System.Drawing.Point(122, 12);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(274, 20);
            this.comboClient.TabIndex = 4;
            this.comboClient.Text = "FTOPClient1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(408, 351);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.comboClient;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(388, 25);
            this.layoutControlItem1.Text = "Select Client : ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.exGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(388, 255);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnGenerate;
            this.layoutControlItem4.Location = new System.Drawing.Point(194, 305);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(194, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnTagView;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 305);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(194, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.comboInterval;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(194, 25);
            this.layoutControlItem5.Text = "Scan Interval :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(107, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.comboBoxNetworkAdapter;
            this.layoutControlItem6.Location = new System.Drawing.Point(194, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(194, 25);
            this.layoutControlItem6.Text = "Network Adapter : ";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(107, 14);
            // 
            // UCOpcViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCOpcViewer";
            this.Size = new System.Drawing.Size(408, 351);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnGenerate;
        private DevExpress.XtraGrid.GridControl exGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private System.Windows.Forms.ComboBox comboClient;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.ComboBox comboInterval;
        private DevExpress.XtraEditors.SimpleButton btnTagView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.ComboBox comboBoxNetworkAdapter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;


    }
}
