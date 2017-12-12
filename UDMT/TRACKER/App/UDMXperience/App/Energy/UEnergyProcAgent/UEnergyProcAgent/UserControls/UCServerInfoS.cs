using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;

using UDM.EnergyProcAgent.Config;

namespace UEnergyProcAgent
{
    public partial class UCServerInfoS : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = true;
        protected CProject m_cProject = null;

        #endregion


        #region Intialize/Dispose

        public UCServerInfoS()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties
        
        public bool IsEditable
        {
            get { return m_bEditable; }
            set { SetEditable(value); }
        }

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; Refresh(); }
        }

        #endregion


        #region Public Methods

        public new void Refresh()
        {
            ShowConfig(m_cProject);

            base.Refresh();
        }

        public void Clear()
        {
            trvServerInfoS.Nodes.Clear();

            base.Refresh();
        }

        #endregion


        #region Private Methods

        private void SetEditable(bool bValue)
        {
            m_bEditable = bValue;
            trvServerInfoS.OptionsBehavior.Editable = m_bEditable;
            trvServerInfoS.OptionsBehavior.ReadOnly = !m_bEditable;
        }

        private void ShowConfig(CProject cProject)
        {
            trvServerInfoS.Nodes.Clear();
            if (cProject == null)
                return;

            object[] oaValue = new object[3];
            oaValue[0] = cProject.Name;
            oaValue[1] = "";
            oaValue[2] = "";

            TreeListNode trnNode = trvServerInfoS.Nodes.Add(oaValue);
            trnNode.ImageIndex = 0;
            trnNode.SelectImageIndex = 0;
            trnNode.Tag = "Project";

            CServerInfo cInfo;
            for(int i=0;i<m_cProject.Config.ServerInfoS.Count;i++)
            {
                cInfo = m_cProject.Config.ServerInfoS[i];
                AddTreeNode(trnNode, cInfo);
            }
        }

        private TreeListNode AddTreeNode(TreeListNode cParent, CServerInfo cInfo)
        {
            object[] oaValue = new object[3];
            oaValue[0] = "Server";
            oaValue[1] = cInfo.ServiceName;
            oaValue[2] = cInfo.IP + ":" + cInfo.Port.ToString();

            TreeListNode trnNode = cParent.Nodes.Add(oaValue);
            trnNode.ImageIndex = 1;
            trnNode.SelectImageIndex = 1;
            trnNode.Tag = cInfo;

            for(int i=0;i<cInfo.ChannelInfoS.Count;i++)
                AddTreeNode(trnNode, cInfo.ChannelInfoS[i]);

            return trnNode;
        }

        private TreeListNode AddTreeNode(TreeListNode cParent, CChannelInfo cInfo)
        {   
            object[] oaValue = new object[3];
            oaValue[0] = "Channel";
            oaValue[1] = cInfo.Channel;
            oaValue[2] = cInfo.Layer;

            TreeListNode trnNode = cParent.Nodes.Add(oaValue);
            trnNode.ImageIndex = 2;
            trnNode.SelectImageIndex = 2;
            trnNode.Tag = cInfo;

            return trnNode;
        }

        #endregion


        #region Event Methods

        private void UCServerInfoS_Load(object sender, EventArgs e)
        {

        }

        private void trvSeriesInfoS_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            if (m_bEditable == false)
            {
                trvServerInfoS.ContextMenuStrip = null;
                e.Allow = false;
                return;
            }

            if (e.Menu is TreeListNodeMenu)
            {
                TreeListNode trnNode = ((TreeListNodeMenu)e.Menu).Node;
                trvServerInfoS.FocusedNode = trnNode;

                object oData = trnNode.Tag;
                if(oData != null)
                {
                    Type tpNode = trnNode.Tag.GetType();
                    if (tpNode == typeof(string))
                    {
                        trvServerInfoS.ContextMenuStrip = cntxProjectMenu;
                    }
                    else if (tpNode == typeof(CServerInfo))
                    {
                        trvServerInfoS.ContextMenuStrip = cntxServerMenu;
                    }
                    else if(tpNode == typeof(CChannelInfo))
                    {
                        trvServerInfoS.ContextMenuStrip = cntxChannelMenu;                     
                    }
                    else
                    {
                        trvServerInfoS.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
            }
        }

        private void mnuAddServer_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            CServerInfo cServerInfo = new CServerInfo();
            m_cProject.Config.ServerInfoS.Add(cServerInfo);

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            AddTreeNode(trnNode, cServerInfo);

            trnNode.Expanded = true;
        }

        private void mnuClearProject_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            m_cProject.Config.ServerInfoS.Clear();

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            trnNode.Nodes.Clear();
        }

        private void mnuExpandAll_Click(object sender, EventArgs e)
        {
            trvServerInfoS.ExpandAll();
        }

        private void mnuCollapseAll_Click(object sender, EventArgs e)
        {
            trvServerInfoS.CollapseAll();
        }

        private void mnuAddChannel_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            CChannelInfo cChannelInfo = new CChannelInfo();

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            CServerInfo cServerInfo = (CServerInfo)trnNode.Tag;
            
            cServerInfo.ChannelInfoS.Add(cChannelInfo);
            AddTreeNode(trnNode, cChannelInfo);
            trnNode.Expanded = true;
        }

        private void mnuDeleteServer_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            TreeListNode trnParent = trnNode.ParentNode;

            CServerInfo cServerInfo = (CServerInfo)trnNode.Tag;
            m_cProject.Config.ServerInfoS.Remove(cServerInfo);

            trnParent.Nodes.Remove(trnNode);
        }

        private void mnuClearServer_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            CServerInfo cServerInfo = (CServerInfo)trnNode.Tag;

            cServerInfo.ChannelInfoS.Clear();
            trnNode.Nodes.Clear();
        }

        private void mnuDeleteChannel_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false || m_cProject == null)
                return;

            TreeListNode trnNode = trvServerInfoS.FocusedNode;
            TreeListNode trnParent = trnNode.ParentNode;

            CChannelInfo cChannelInfo = (CChannelInfo)trnNode.Tag;
            CServerInfo cServerInfo = (CServerInfo)trnParent.Tag;

            cServerInfo.ChannelInfoS.Remove(cChannelInfo);
            trnParent.Nodes.Remove(trnNode);
        }

        private void trvServerInfoS_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if(e.Column == colName)
            {
                Type type = e.Node.Tag.GetType();
                if(type == typeof(CServerInfo))
                {
                    CServerInfo cInfo = (CServerInfo)e.Node.Tag;
                    cInfo.ServiceName = (string)e.Value;
                }
                else if(type == typeof(CChannelInfo))
                {
                    CChannelInfo cInfo = (CChannelInfo)e.Node.Tag;
                    cInfo.Channel = (string)e.Value;
                }
            }
            else if(e.Column == colAddress)
            {
                Type type = e.Node.Tag.GetType();
                if (type == typeof(CServerInfo))
                {
                    CServerInfo cInfo = (CServerInfo)e.Node.Tag;
                    string sIpPort = (string)e.Value;

                    string[] saIpPort = sIpPort.Split(':');
                    if(saIpPort.Length != 2)
                    {
                        MessageBox.Show("Please check formation!! (formation - IP:Port)", "UEnergyProcAgent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {   
                        int iPort = -1;
                        if (int.TryParse(saIpPort[1], out iPort) == false)
                        {
                            MessageBox.Show("Please check port number!! (formation - IP:Port)", "UEnergyProcAgent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cInfo.IP = saIpPort[0];
                        cInfo.Port = iPort;
                    }
                }
                else if (type == typeof(CChannelInfo))
                {
                    CChannelInfo cInfo = (CChannelInfo)e.Node.Tag;
                    cInfo.Layer = (string)e.Value;
                }
            }
        }
        
        #endregion
    }
}
