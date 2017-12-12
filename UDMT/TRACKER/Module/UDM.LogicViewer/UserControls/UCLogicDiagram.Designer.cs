using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using DevComponents.Tree;

namespace UDM.LogicViewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public partial class UCLogicDiagram: UserControl, ISupportInitialize
	{
        private DevComponents.Tree.TreeGX tree;
		private DevComponents.Tree.NodeConnector nodeConnector1;
		private DevComponents.Tree.NodeConnector nodeConnector2;
		private DevComponents.Tree.ElementStyle nodeStyle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboLayout;
		private System.Windows.Forms.ComboBox comboLayoutType;
        private DevComponents.Tree.ElementStyle elementStyle1;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.tree = new DevComponents.Tree.TreeGX();
            this.nodeConnector2 = new DevComponents.Tree.NodeConnector();
            this.nodeStyle = new DevComponents.Tree.ElementStyle();
            this.nodeConnector1 = new DevComponents.Tree.NodeConnector();
            this.elementStyle1 = new DevComponents.Tree.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboLayoutType = new System.Windows.Forms.ComboBox();
            this.comboLayout = new System.Windows.Forms.ComboBox();
            this.trbActiveTime = new DevExpress.XtraEditors.TrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbActiveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbActiveTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.AutoScrollMinSize = new System.Drawing.Size(653, 166);
            this.tree.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.tree.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tree.BackgroundStyle.BackColor2 = System.Drawing.Color.Azure;
            this.tree.BackgroundStyle.BackColorGradientAngle = 90;
            this.tree.CommandBackColorGradientAngle = 90;
            this.tree.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            this.tree.CommandMouseOverBackColorGradientAngle = 90;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ExpandBorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            this.tree.ExpandButtonSize = new System.Drawing.Size(16, 16);
            this.tree.ExpandButtonType = DevComponents.Tree.eExpandButtonType.Rectangle;
            this.tree.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.tree.LicenseKey = "EB364C34-3CE3-4cd6-BB1B-13513ABE0D62";
            this.tree.Location = new System.Drawing.Point(0, 57);
            this.tree.Name = "tree";
            this.tree.NodesConnector = this.nodeConnector2;
            this.tree.NodeStyle = this.nodeStyle;
            this.tree.NodeVerticalSpacing = 5;
            this.tree.PathSeparator = ";";
            this.tree.RootConnector = this.nodeConnector1;
            this.tree.Size = new System.Drawing.Size(701, 285);
            this.tree.Styles.Add(this.nodeStyle);
            this.tree.Styles.Add(this.elementStyle1);
            this.tree.SuspendPaint = false;
            this.tree.TabIndex = 0;
            this.tree.Text = "treeGX_Main";
            this.tree.NodeDoubleClick += new DevComponents.Tree.TreeGXNodeMouseEventHandler(this.tree_NodeDoubleClick);
            this.tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseDown);
            this.tree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseUp);
            this.tree.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseWheel);
            this.tree.AfterNodeSelect += new DevComponents.Tree.TreeGXNodeEventHandler(this.tree_AfterNodeSelect);
            this.tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_KeyDown);
            this.tree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseMove);
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nodeConnector2.LineWidth = 5;
            // 
            // nodeStyle
            // 
            this.nodeStyle.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.BarBackground2;
            this.nodeStyle.BackColorGradientAngle = 90;
            this.nodeStyle.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            this.nodeStyle.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.nodeStyle.BorderBottomWidth = 1;
            this.nodeStyle.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.nodeStyle.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.nodeStyle.BorderLeftWidth = 1;
            this.nodeStyle.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.nodeStyle.BorderRightWidth = 1;
            this.nodeStyle.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.nodeStyle.BorderTopWidth = 1;
            this.nodeStyle.CornerDiameter = 4;
            this.nodeStyle.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.nodeStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeStyle.Name = "nodeStyle";
            this.nodeStyle.PaddingBottom = 2;
            this.nodeStyle.PaddingLeft = 2;
            this.nodeStyle.PaddingRight = 2;
            this.nodeStyle.PaddingTop = 2;
            this.nodeStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineWidth = 5;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Name = "elementStyle1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // comboLayoutType
            // 
            this.comboLayoutType.Location = new System.Drawing.Point(0, 0);
            this.comboLayoutType.Name = "comboLayoutType";
            this.comboLayoutType.Size = new System.Drawing.Size(121, 20);
            this.comboLayoutType.TabIndex = 0;
            // 
            // comboLayout
            // 
            this.comboLayout.Location = new System.Drawing.Point(0, 0);
            this.comboLayout.Name = "comboLayout";
            this.comboLayout.Size = new System.Drawing.Size(121, 20);
            this.comboLayout.TabIndex = 0;
            // 
            // trbActiveTime
            // 
            this.trbActiveTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbActiveTime.EditValue = null;
            this.trbActiveTime.Location = new System.Drawing.Point(0, 0);
            this.trbActiveTime.Name = "trbActiveTime";
            this.trbActiveTime.Properties.AutoSize = false;
            this.trbActiveTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.trbActiveTime.Properties.LabelAppearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.trbActiveTime.Properties.LabelAppearance.Options.UseFont = true;
            this.trbActiveTime.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trbActiveTime.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "1";
            this.trbActiveTime.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1});
            this.trbActiveTime.Properties.Maximum = 0;
            this.trbActiveTime.Properties.ShowLabels = true;
            this.trbActiveTime.Properties.ValueChanged += new System.EventHandler(this.trbActiveTime_Properties_ValueChanged);
            this.trbActiveTime.Size = new System.Drawing.Size(701, 57);
            this.trbActiveTime.TabIndex = 1;
            // 
            // UCLogicDiagram
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.trbActiveTime);
            this.Name = "UCLogicDiagram";
            this.Size = new System.Drawing.Size(701, 342);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbActiveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbActiveTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private DevExpress.XtraEditors.TrackBarControl trbActiveTime;
        private IContainer components;

    }
}
