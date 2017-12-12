namespace NewIOMaker.Form
{
    partial class ControlMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMenu));
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.Infopanel = new DevExpress.XtraEditors.PanelControl();
            this.InfotileControl = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.btnTagItem = new DevExpress.XtraEditors.TileItem();
            this.tileGroup4 = new DevExpress.XtraEditors.TileGroup();
            this.btnIOItem = new DevExpress.XtraEditors.TileItem();
            this.tileGroup5 = new DevExpress.XtraEditors.TileGroup();
            this.btnMCItem = new DevExpress.XtraEditors.TileItem();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Infopanel)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.Infopanel);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.InfotileControl);
            this.splitContainerControl1.Panel2.Controls.Add(this.tileControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1044, 564);
            this.splitContainerControl1.SplitterPosition = 149;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // Infopanel
            // 
            this.Infopanel.ContentImage = ((System.Drawing.Image)(resources.GetObject("Infopanel.ContentImage")));
            this.Infopanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Infopanel.Location = new System.Drawing.Point(0, 0);
            this.Infopanel.Name = "Infopanel";
            this.Infopanel.Size = new System.Drawing.Size(1044, 149);
            this.Infopanel.TabIndex = 0;
            // 
            // InfotileControl
            // 
            this.InfotileControl.BackColor = System.Drawing.Color.Transparent;
            this.InfotileControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InfotileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfotileControl.DragSize = new System.Drawing.Size(0, 0);
            this.InfotileControl.Groups.Add(this.tileGroup2);
            this.InfotileControl.Groups.Add(this.tileGroup4);
            this.InfotileControl.Groups.Add(this.tileGroup5);
            this.InfotileControl.Location = new System.Drawing.Point(0, 0);
            this.InfotileControl.MaxId = 4;
            this.InfotileControl.Name = "InfotileControl";
            this.InfotileControl.Size = new System.Drawing.Size(1044, 403);
            this.InfotileControl.TabIndex = 1;
            this.InfotileControl.Text = "tileControl2";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.btnTagItem);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // btnTagItem
            // 
            this.btnTagItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTagItem.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.btnTagItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnTagItem.AppearanceItem.Normal.Options.UseBorderColor = true;
            tileItemElement10.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement10.Image")));
            tileItemElement10.Text = "TagGenerator";
            tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnTagItem.Elements.Add(tileItemElement10);
            this.btnTagItem.Id = 1;
            this.btnTagItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnTagItem.Name = "btnTagItem";
            // 
            // tileGroup4
            // 
            this.tileGroup4.Items.Add(this.btnIOItem);
            this.tileGroup4.Name = "tileGroup4";
            // 
            // btnIOItem
            // 
            this.btnIOItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnIOItem.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.btnIOItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnIOItem.AppearanceItem.Normal.Options.UseBorderColor = true;
            tileItemElement11.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement11.Image")));
            tileItemElement11.Text = "IOMaker";
            tileItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnIOItem.Elements.Add(tileItemElement11);
            this.btnIOItem.Id = 2;
            this.btnIOItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnIOItem.Name = "btnIOItem";
            // 
            // tileGroup5
            // 
            this.tileGroup5.Items.Add(this.btnMCItem);
            this.tileGroup5.Name = "tileGroup5";
            // 
            // btnMCItem
            // 
            this.btnMCItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMCItem.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.btnMCItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnMCItem.AppearanceItem.Normal.Options.UseBorderColor = true;
            tileItemElement12.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement12.Image")));
            tileItemElement12.Text = "MultiCopy";
            tileItemElement12.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnMCItem.Elements.Add(tileItemElement12);
            this.btnMCItem.Id = 3;
            this.btnMCItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnMCItem.Name = "btnMCItem";
            // 
            // tileControl1
            // 
            this.tileControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tileControl1.BackgroundImage")));
            this.tileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.MaxId = 10;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(1044, 403);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup1
            // 
            this.tileGroup1.Name = "tileGroup1";
            // 
            // ControlMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ControlMenu";
            this.Size = new System.Drawing.Size(1044, 564);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Infopanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl Infopanel;
        private DevExpress.XtraEditors.TileControl InfotileControl;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem btnTagItem;
        private DevExpress.XtraEditors.TileGroup tileGroup4;
        private DevExpress.XtraEditors.TileItem btnIOItem;
        private DevExpress.XtraEditors.TileGroup tileGroup5;
        private DevExpress.XtraEditors.TileItem btnMCItem;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
    }
}
