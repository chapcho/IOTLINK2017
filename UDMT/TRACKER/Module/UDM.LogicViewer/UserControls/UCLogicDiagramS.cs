using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

using DevComponents.Tree;
using UDM.UDLImport;
using UDM.Log;
using UDM.Common;


namespace UDM.LogicViewer
{

    public partial class UCLogicDiagramS : UserControl
    {
        #region Member Variables

        private List<UCLogicDiagram> m_ucLogicDiagramS = new List<UCLogicDiagram>();
        private UCLogicDiagram m_treeGXSelected = null;
        private ContextMenuStrip m_cntxTabMenu = null;

        public event UEventHandlerFocusedDiagramChanged UEventFocusedDiagramChanged;

        #endregion

        #region Initialize/Dispose

        public UCLogicDiagramS()
        {
            InitializeComponent();

            tabControl.DrawMode = TabDrawMode.Normal;
        }

        #endregion

        private void UCLogicDiagramS_Load(object sender, EventArgs e)
        {
        }


        #region Public interface

        public ContextMenuStrip ContextTabMenuStrip
        {
            get { return m_cntxTabMenu; }
            set { m_cntxTabMenu = value; }
        }

        public UCLogicDiagram FocusedTab
        {
            get { return m_treeGXSelected; }
            set { m_treeGXSelected = value; }
        }
        
        #endregion

        #region Public Method

        public UCLogicDiagram AddTab(string sTab,CTimeLogS cLogS)
        {
            UCLogicDiagram ucLogicDiagram = new UCLogicDiagram();
            ucLogicDiagram.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucLogicDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            ucLogicDiagram.Location = new System.Drawing.Point(3, 3);
            ucLogicDiagram.Name = "ucLogicDiagram1";
            ucLogicDiagram.NodeCurrent = null;
            ucLogicDiagram.Size = new System.Drawing.Size(687, 310);
            ucLogicDiagram.TabIndex = 0;
            ucLogicDiagram.UEventNameChanged += new UEventHandlerNameChanged(ucLogicDiagram_UEventNameChanged);
            if (cLogS != null && cLogS.Count > 0)
                ucLogicDiagram.TimeLogS = cLogS;

            TabPage tabPage = new TabPage();
            tabPage.Controls.Add(ucLogicDiagram);
            tabPage.Location = new System.Drawing.Point(4, 4);
            tabPage.Name = sTab;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(693, 316);
            tabPage.TabIndex = 0;
            tabPage.Text = sTab;
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Tag = ucLogicDiagram;

            this.tabControl.Controls.Add(tabPage);
            this.tabControl.SelectedIndex = this.tabControl.TabCount - 1;
            m_treeGXSelected = ucLogicDiagram;
            ucLogicDiagram.AllowDropDiagram = false;

            return ucLogicDiagram;
        }

        public bool RemoveSelectedTab()
        {
            bool bOK = true;

            try
            {
                m_treeGXSelected = null;
                this.tabControl.TabPages.RemoveAt(this.tabControl.SelectedIndex);                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool ClearTabs()
        {
            this.tabControl.TabPages.Clear();
            m_treeGXSelected = null;

            return true;
        }

        #endregion

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && m_cntxTabMenu != null)
                    m_cntxTabMenu.Show(Cursor.Position);
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void toolStripMenuItem_delete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.tabControl.TabPages.RemoveAt(this.tabControl.SelectedIndex);
            //}
            //catch (System.Exception ex)
            //{
            //    Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            //}
        }


        private void toolStripMenuItem_deleteAll_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.tabControl.TabPages.Clear();
            //    m_treeGXSelected = null;
            //}
            //catch (System.Exception ex)
            //{
            //    Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            //}
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl.SelectedTab != null)
                    m_treeGXSelected = (UCLogicDiagram)this.tabControl.SelectedTab.Tag;
                else
                    m_treeGXSelected = null;

                if (UEventFocusedDiagramChanged != null)
                    UEventFocusedDiagramChanged(this, m_treeGXSelected);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ucLogicDiagram_UEventNameChanged(object sender, string sName)
        {
            if (this.tabControl.SelectedTab != null)
                this.tabControl.SelectedTab.Text = sName;
        }

   

        

        #region private Method


        #endregion

        #region Event Methods



        #endregion
    }

}


