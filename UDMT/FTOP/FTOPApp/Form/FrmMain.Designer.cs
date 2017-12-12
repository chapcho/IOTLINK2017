namespace FTOPApp
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FTOPApp.Form.SplashScreen1), true, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.tileMain = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.btnClient = new DevExpress.XtraEditors.TileItem();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.btnServer = new DevExpress.XtraEditors.TileItem();
            this.tileGroup4 = new DevExpress.XtraEditors.TileGroup();
            this.btnObserver = new DevExpress.XtraEditors.TileItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 100;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tileMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1046, 583);
            this.panelMain.TabIndex = 0;
            // 
            // tileMain
            // 
            this.tileMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tileMain.BackgroundImage")));
            this.tileMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tileMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileMain.DragSize = new System.Drawing.Size(0, 0);
            this.tileMain.Groups.Add(this.tileGroup2);
            this.tileMain.Groups.Add(this.tileGroup3);
            this.tileMain.Groups.Add(this.tileGroup4);
            this.tileMain.Location = new System.Drawing.Point(2, 2);
            this.tileMain.MaxId = 3;
            this.tileMain.Name = "tileMain";
            this.tileMain.ShowGroupText = true;
            this.tileMain.ShowText = true;
            this.tileMain.Size = new System.Drawing.Size(1042, 579);
            this.tileMain.TabIndex = 0;
            this.tileMain.Text = "Factory Total Operating Package";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.btnClient);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = "F-TOP Client";
            // 
            // btnClient
            // 
            this.btnClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClient.BackgroundImage")));
            this.btnClient.BackgroundImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement7.Text = "PLC 정보를 수집하여 데이터베이스에 저장합니다.";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.btnClient.Elements.Add(tileItemElement7);
            this.btnClient.Id = 0;
            this.btnClient.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
            this.btnClient.Name = "btnClient";
            // 
            // tileGroup3
            // 
            this.tileGroup3.Items.Add(this.btnServer);
            this.tileGroup3.Name = "tileGroup3";
            this.tileGroup3.Text = "F-TOP Server";
            // 
            // btnServer
            // 
            this.btnServer.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Transparent;
            this.btnServer.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.Transparent;
            this.btnServer.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.btnServer.AppearanceItem.Normal.BackColor = System.Drawing.Color.Transparent;
            this.btnServer.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.btnServer.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnServer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnServer.BackgroundImage")));
            this.btnServer.BackgroundImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement8.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement8.Text = "수집된 PLC 정보를 MES 또는 CPS로 전송합니다.";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.btnServer.Elements.Add(tileItemElement8);
            this.btnServer.Id = 1;
            this.btnServer.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
            this.btnServer.Name = "btnServer";
            // 
            // tileGroup4
            // 
            this.tileGroup4.Items.Add(this.btnObserver);
            this.tileGroup4.Name = "tileGroup4";
            this.tileGroup4.Text = "F-TOP DB Observer";
            // 
            // btnObserver
            // 
            this.btnObserver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObserver.BackgroundImage")));
            this.btnObserver.BackgroundImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement9.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement9.Text = "데이터베이스를 검색하고 결과를 리포트 합니다.";
            this.btnObserver.Elements.Add(tileItemElement9);
            this.btnObserver.Id = 2;
            this.btnObserver.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
            this.btnObserver.Name = "btnObserver";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 583);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FrmMain";
            this.Text = "F-TOP";
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.TileControl tileMain;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem btnClient;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private DevExpress.XtraEditors.TileItem btnServer;
        private DevExpress.XtraEditors.TileGroup tileGroup4;
        private DevExpress.XtraEditors.TileItem btnObserver;

    }
}

