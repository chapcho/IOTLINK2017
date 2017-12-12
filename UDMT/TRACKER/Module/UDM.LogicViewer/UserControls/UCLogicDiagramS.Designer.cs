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
    public partial class UCLogicDiagramS : UserControl
    {
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboLayout;
        private System.Windows.Forms.ComboBox comboLayoutType;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboLayoutType = new System.Windows.Forms.ComboBox();
            this.comboLayout = new System.Windows.Forms.ComboBox();
            this.tabControl = new UDM.LogicViewer.Util.CTabControlEx();
            this.SuspendLayout();
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
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(48, 32);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(6, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(701, 342);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            // 
            // UCLogicDiagramS
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl);
            this.Name = "UCLogicDiagramS";
            this.Size = new System.Drawing.Size(701, 342);
            this.Load += new System.EventHandler(this.UCLogicDiagramS_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private IContainer components;
        // private TabControl tabControl;

        private UDM.LogicViewer.Util.CTabControlEx tabControl;


    }
}
