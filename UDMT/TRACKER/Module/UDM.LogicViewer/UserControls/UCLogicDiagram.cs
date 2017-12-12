using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

using DevComponents.Tree;
using UDM.Common;
using UDM.UDLImport;
using UDM.Log;


namespace UDM.LogicViewer
{

    public partial class UCLogicDiagram: UserControl, ISupportInitialize
    {
        #region Member Variables

        private Node m_nodeCurrent = null;
        private Point m_CurrentPosition = new Point(0, 0);
        private CTimeLogS m_cTimeLogS = new CTimeLogS();
        private Keys m_KeysCurrent = new Keys();
        private CStep m_cFocusedStep = null;
        private Node m_cFocusedNode = null;

        private int m_iCurrentTimeIndex = 0;

        private ContextMenuStrip m_cntxCoilMenu = null;
        private ContextMenuStrip m_cntxSubCoilMenu = null;

        public event UEventHandlerExpandSubAll UEventExpandSubAll;
        public event UEventHandlerLogicViewerTimeIndicatorChanged UEventTimeIndicatorChanged;
        public event UEventHandlerNameChanged UEventNameChanged;

        #endregion

        #region Initialize/Dispose

        public UCLogicDiagram()
        {
            InitializeComponent();

            trbActiveTime.Properties.Maximum = 0;
            trbActiveTime.Properties.Labels.Clear();

            SetDiagramLayoutFlow(eDiagramFlow.RightToLeft);
           // SetMapLayoutFlow(eMapFlow.RightToLeft);   // Map Flow 사용시 Node Property 수정시에 리프레쉬 시간 대폭 증가
        }

        #endregion

        #region Public interface

        public TreeGX TreeBase
        {
            get { return this.tree; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { SetActiveTime(value); }
        }

        public bool AllowDropDiagram
        {
            get { return tree.AllowDrop; }
            set { tree.AllowDrop = value; }
        }

        public Node NodeBase
        {
            get
            {
                if (this.tree.Nodes.Count == 0)
                    return null;
                else
                    return this.tree.Nodes[0];
            }
        }

        public Keys Keys
        {
            get
            {
                return m_KeysCurrent;
            }
        }

        public Node NodeCurrent
        {
            get { return m_nodeCurrent; }
            set { m_nodeCurrent = value; }
        }

        public Node FocusedNode
        {
            get { return m_cFocusedNode; }
        }

        public CStep FocusedStep
        {
            get { return m_cFocusedStep; }
        }

        public ContextMenuStrip ContextCoilMenuStrip
        {
            get { return m_cntxCoilMenu; }
            set { m_cntxCoilMenu = value; }
        }

        public ContextMenuStrip ContextSubCoilMenuStrip
        {
            get { return m_cntxSubCoilMenu; }
            set { m_cntxSubCoilMenu = value; }
        }

        #endregion

        #region Public Method

        public Bitmap ScreenCapture()
        {
            Size size = new Size(tree.TreeSize.Width, tree.TreeSize.Height);
            Bitmap bmp = new Bitmap(size.Width, size.Height);

            try
            {
                Graphics g = Graphics.FromImage(bmp);
                tree.PaintTo(g, false, new Rectangle(0,0,size.Width, size.Height));               
            }

            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bmp = null;
            }

            return bmp;
        }

        public void BeginInit()
        {
            this.tree.BeginInit();
        }

        public void EndInit()
        {
            this.tree.EndInit();
        }

        public void ClearAll()
        {
            BeginUpdate();

            foreach (Node treeNode in tree.Nodes)
            {
                RemoveLogicTree(treeNode);
            }

            tree.Nodes.Clear();

            EndUpdate();
        }

        public void EndUpdate()
        {
            tree.EndUpdate(true);
            m_KeysCurrent = new Keys();
        }

        public void BeginUpdate()
        {
            tree.BeginUpdate();
        }

        public void RefreshAll()
        {
            tree.Refresh();
        }

        public void ShiftScroll(int nValueX,int nValueY)
        {
            Point p = new Point(-(tree.AutoScrollPosition.X + nValueX), -(tree.AutoScrollPosition.Y + nValueY));
            if (p.X > 0 || p.Y > 0)
                tree.AutoScrollPosition = p;
        }

        public void SetMapLayoutFlow(eMapFlow MapFlow)
        {
            tree.LayoutType = eNodeLayout.Map;
            tree.MapLayoutFlow = MapFlow;
        }

        public void SetDiagramLayoutFlow(eDiagramFlow DiagramFlow)
        {
            tree.LayoutType = eNodeLayout.Diagram;
            tree.DiagramLayoutFlow = DiagramFlow;
        }

        public void CreateBaseNode(bool bExpanded)
        {
            Node nodeBase = new Node();
            nodeBase.Expanded = bExpanded;
            nodeBase.Text = EILGroup.BASE.ToString();
            m_nodeCurrent = nodeBase;
            tree.Nodes.Add(nodeBase);
        }

        public void AddBaseNode(bool bExpanded)
        {
            Node node = new Node();
            node.Expanded = bExpanded;
            node.Text = EILGroup.COIL.ToString();
            m_nodeCurrent = node;
            NodeBase.Nodes.Add(node);
        }

        public bool AddCurrentNode(Node nodeParent, string strCurrentNode, bool bExpanded)
        {
            if (strCurrentNode == string.Empty || nodeParent == null)
                return false;

            Node nodeCurrent = new Node();
            nodeCurrent.Expanded = bExpanded;

            m_nodeCurrent = nodeCurrent;
            nodeParent.Nodes.Add(m_nodeCurrent);

            return true;
        }

        public void RemoveLogicTree(Node treeNode)
        {
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                RemoveLogicTree(treeNode.Nodes[n]);
                if (treeNode.Nodes[n].HostedControl != null)
                    treeNode.Nodes[n].HostedControl.Dispose();
                treeNode.Nodes[n].Dispose();
                treeNode.Nodes.Remove(treeNode.Nodes[n]);
                n--;
            }
        }

        public void RemoveNode(Node treeNode)
        {
            if (treeNode.Parent != null && treeNode.Parent.Nodes.Count > 1)
            {
                RemoveLogicTree(treeNode);
                treeNode.Parent.Nodes.Remove(treeNode);
            }
        }

        public void ShowTimeInfo(bool bVisible)
        {
            CLogicHelper.SetTimeShowCallback(NodeBase, bVisible);
        }

        public void ShowMaxMode(bool bMax)
        {
            CLogicHelper.DrawMinMode(NodeBase, !bMax);
        }

        public void ShowHelp()
        {

        }

        #endregion

        #region private Method

        private void SetActiveTime(CTimeLogS cTimeLogS)
        {
            UpdateActiveTime(cTimeLogS);

            trbActiveTime.Properties.Labels.Clear();
            trbActiveTime.Properties.Maximum = 0;

            if (m_cTimeLogS == null || m_cTimeLogS.Count == 0)
            {
                trbActiveTime.Refresh();
                return;
            }

            trbActiveTime.Properties.Maximum = m_cTimeLogS.Count - 1;
            DevExpress.XtraEditors.Repository.TrackBarLabel cLabel;
            string sTime;
            for (int i = 0; i < m_cTimeLogS.Count; i++)
            {
                sTime = m_cTimeLogS[i].Time.ToString("HH:mm:ss");
                cLabel = new DevExpress.XtraEditors.Repository.TrackBarLabel(sTime, i);
                trbActiveTime.Properties.Labels.Add(cLabel);
            }

            m_iCurrentTimeIndex = m_cTimeLogS.Count - 1;

            trbActiveTime.Value = m_iCurrentTimeIndex;

            trbActiveTime.Refresh();
        }

        private void UpdateActiveTime(CTimeLogS cTimeLogS)
        {
            m_cTimeLogS.Clear();

            if (cTimeLogS.Count > 100)
            {
                int nLastIndex = cTimeLogS.Count - 1;

                for (int i = EMActiveTimeBar.MaxBarCount - 1; i >= 0; i--)
                    m_cTimeLogS.Add(cTimeLogS[nLastIndex - i]);
            }
            else
                m_cTimeLogS = cTimeLogS;

        }

        #endregion

        #region Event Methods

        private void Form1_Load(object sender, System.EventArgs e)
        {
            comboLayout.Items.AddRange(Enum.GetNames(typeof(DevComponents.Tree.eNodeLayout)));
            comboLayout.SelectedItem = "Map";
        }

        private void treeMain_MouseWheel(object sender, MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        private void treeMain_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Cursor = System.Windows.Forms.Cursors.Hand;
                m_CurrentPosition = new Point(-e.X, -e.Y);
            }
         
        }

        private void treeMain_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point((m_CurrentPosition.X + e.X) / 5, (m_CurrentPosition.Y + e.Y) / 5);

                if (!p.IsEmpty)
                {
                    if (tree.DisplayRectangle.Size.Height > this.Size.Height
                        || tree.DisplayRectangle.Size.Width > this.Size.Width)
                    {
                        ShiftScroll(p.X, p.Y);
                        tree.Refresh();
                    }
                }
            }
        }

        private void treeMain_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                Cursor = System.Windows.Forms.Cursors.Arrow;
        }


        private void tree_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            m_KeysCurrent = e.KeyData;
        }

        private void tree_NodeDoubleClick(object sender, TreeGXNodeMouseEventArgs e)
        {
            if (UEventExpandSubAll != null)
            {
                UEventExpandSubAll(this, e.Node);
            }
        }

        private void trbActiveTime_Properties_ValueChanged(object sender, EventArgs e)
        {
            int iValue = trbActiveTime.Value;
            if (iValue != m_iCurrentTimeIndex)
            {
                m_iCurrentTimeIndex = iValue;
                if (m_iCurrentTimeIndex > -1 && m_cTimeLogS.Count > m_iCurrentTimeIndex)
                {
                    if (UEventTimeIndicatorChanged != null)
                    {
                        DateTime dtTime = m_cTimeLogS[m_iCurrentTimeIndex].Time;
                        UEventTimeIndicatorChanged(this, dtTime);
                    }
                }
            }
        }

        private void tree_AfterNodeSelect(object sender, TreeGXNodeEventArgs e)
        {
            m_cFocusedNode = e.Node;

            if (m_cFocusedNode != null && m_cFocusedNode.Tag is CNodeCoil)
            {
                m_cFocusedStep = ((CNodeCoil)m_cFocusedNode.Tag).LDRung.Step;

                if (Control.MouseButtons == MouseButtons.Right && m_cntxCoilMenu != null)
                    m_cntxCoilMenu.Show(Cursor.Position);
            }
            else
            {
                m_cFocusedStep = null;

                if (Control.MouseButtons == MouseButtons.Right && m_cntxSubCoilMenu != null)
                    m_cntxSubCoilMenu.Show(Cursor.Position);
            }
        }
        
        public void SetName(string sName)
        {
            if (UEventNameChanged != null)
            {
                UEventNameChanged(this, sName);
            }
        }

        #endregion
    }
}


