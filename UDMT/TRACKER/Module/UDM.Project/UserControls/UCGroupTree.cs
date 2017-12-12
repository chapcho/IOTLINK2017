using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;

using UDM.Common;

namespace UDM.Project
{
    public partial class UCGroupTree : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = false;
        protected CProject m_cProject = null;
        protected UCProjectManager m_ucManager = null;
        protected TreeListNode m_trnRoot = null;
        protected UCTagTable m_ucTagTable = null;
        public event UEventHandlerGroupTreeInputTextRequest UEventInputTextRequest;

        public event UEventHandlerGroupTreeSymbolAdding UEventSymbolAdding;
        public event UEventHandlerGroupTreeSymbolAdded UEventSymbolAdded;
        public event UEventHandlerGroupTreeSymbolRemoved UEventSymbolRemoved;
        public event UEventHandlerGroupTreeSymbolUpdated UEventSymbolUpdated;
        public event UEventHandlerGroupTreeSymbolDoubleClicked UEventSymbolDoubleClicked;

        public event UEventHandlerGroupTreeGroupAdded UEventGroupAdded;
        public event UEventHandlerGroupTreeGroupRemove UEventGroupRemoved;
        public event UEventHandlerGroupTreeGroupUpdate UEventGroupUpdated;
        public event UEventHandlerGroupTreeGroupDoubleClicked UEventGroupDoubleClicked;

        protected const int IMG_INDEX_LINE = 0;
        protected const int IMG_INDEX_GROUP = 1;
        protected const int IMG_INDEX_ROLETYPE = 1;
        protected const int IMG_INDEX_SYMBOL = 2;
        protected const int NODE_LEVEL_GROUP = 1;
        protected const int NODE_LEVEL_ROLETYPE = 2;
        protected const int NODE_LEVEL_SYMBOL = 3;
        protected const int NODE_LEVEL_SUBSYMBOL = 4;

        protected bool m_bDragDropReady = false;

        #endregion


        #region Initialize/Dispose

        public UCGroupTree()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { SetEditable(value); }
        }

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public UCProjectManager Manager
        {
            get { return m_ucManager; }
            set { m_ucManager = value; }
        }

        public UCTagTable TagTable
        {            
            set { m_ucTagTable = value; }
        }

        #endregion


        #region Public Methods

        public void ShowTree()
        {
            Clear();

            if (m_cProject == null || m_cProject.Name == "")
                return;

            exTreeList.BeginUpdate();
            {
                // Draw Line
                m_trnRoot = CreateTreeNode(null, m_cProject.Name, "", IMG_INDEX_LINE, null);

                CGroup cGroup;
                TreeListNode trnGroup;
                for (int i = 0; i < m_cProject.GroupS.Count; i++)
                {
                    // Draw Group
                    cGroup = m_cProject.GroupS[i];
                    trnGroup = CreateTreeNode(m_trnRoot, cGroup.Key, "", IMG_INDEX_GROUP, cGroup);

                    UpdateGroupNode(cGroup, trnGroup);
                }
            }
            exTreeList.EndUpdate();
        }

        public CSymbol GetSelectedSymbol()
        {
            CSymbol cSymbol = null;

            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null && trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CSymbol))
                cSymbol = (CSymbol)trnNode.Tag;

            return cSymbol;
        }

        public CGroup GetSelectedGroup()
        {
            CGroup cGroup = null;

            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null && trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CGroup))
                cGroup = (CGroup)trnNode.Tag;

            return cGroup;
        }

        public void RenameProject(string sNewName)
        {
            if (m_trnRoot == null || m_cProject == null)
                return;

            m_cProject.Name = sNewName;

            UpdateTreeNode(m_trnRoot, sNewName);
        }

        public void ClearProject()
        {
            if (m_trnRoot == null || m_cProject == null)
                return;

            m_cProject.GroupS.Clear();
            ClearTreeNode(m_trnRoot);
            UpdateTagGroupRoleS();
        }

        public CGroup AddGroup(string sName)
        {
            if (m_trnRoot == null || m_cProject == null)
                return null;

            CGroup cGroup = new CGroup();
            cGroup.Key = sName;

            if (m_cProject.GroupS.ContainsKey(cGroup.Key))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cGroup = null;
            }
            else
            {
                m_cProject.GroupS.Add(cGroup.Key, cGroup);

                TreeListNode trnGroup = CreateTreeNode(m_trnRoot, cGroup.Name, "", IMG_INDEX_GROUP, cGroup);
                CreateRoleTypeTreeNodes(trnGroup);

                //20150630 KimMinHui Group Add 이벤트 추가
                GenerateGroupAddEvent(cGroup);
                GenerateGroupUpdateEvent(cGroup);
            }

            return cGroup;
        }

        public void RenameGroup(CGroup cGroup, string sNewName)
        {
            if (m_cProject == null)
                return;

            if (cGroup.Name == sNewName)
                return;

            if (m_cProject.GroupS.ContainsKey(sNewName))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cGroup.Key = sNewName;

            TreeListNode trnNode = GetTreeNode(m_trnRoot, cGroup);
            if (trnNode != null)
                UpdateTreeNode(trnNode, cGroup.Name);

            //20150630 KimMinHui Process Update 추가
            GenerateGroupUpdateEvent(cGroup);
            UpdateTagGroupRoleS();
        }

        public void RemoveGroup(CGroup cGroup)
        {
            if (m_cProject == null)
                return;

            if (m_cProject.GroupS.ContainsKey(cGroup.Key) == false)
                return;

            //20150630 KimMinHui Group Remove 추가
            GenerateGroupRemoveEvent(cGroup);

            m_cProject.GroupS.Remove(cGroup.Key);
            cGroup.Clear();

            TreeListNode trnNode = GetTreeNode(m_trnRoot, cGroup);
            if (trnNode != null)
                RemoveTreeNode(trnNode);

            GenerateGroupUpdateEvent(cGroup);

            UpdateTagGroupRoleS();
        }

        public void ClearGroup(CGroup cGroup)
        {
            cGroup.Clear();
            m_cProject.GroupS.Compose(m_cProject.TagS);

            TreeListNode trnNode = GetTreeNode(m_trnRoot, cGroup);
            if (trnNode != null)
                ClearRoleTypeTreeNode(trnNode);
        }

        public CSymbol AddSymbol(CGroup cGroup, CTag cTag, EMGroupRoleType emRoleType)
        {
            if (emRoleType == EMGroupRoleType.SubKey)
                return null;

            CSymbol cSymbol = cGroup.AddSymbol(cTag, emRoleType);
            if (cSymbol != null)
                UpdateGroupNode(cGroup);

            UpdateTagGroupRoleS();

            return cSymbol;
        }

        public CSymbolS AddSymbolS(CGroup cGroup, CTagS cTagS, EMGroupRoleType emRoleType)
        {
            if (emRoleType == EMGroupRoleType.SubKey)
                return null;

            GenerateSymbolAddingEvent(cGroup.Key, cTagS, emRoleType);

            CSymbolS cSymbolS = new CSymbolS();

            exTreeList.BeginUpdate();
            {
                CTag cTag;
                CSymbol cSymbol;
                for (int i = 0; i < cTagS.Count; i++)
                {
                    cTag = cTagS[i];

                    cSymbol = cGroup.AddSymbol(cTag, emRoleType);
                    if (cSymbol != null)
                        cSymbolS.Add(cSymbol);
                }

                UpdateGroupNode(cGroup);
            }
            exTreeList.EndUpdate();

            UpdateTagGroupRoleS();

            return cSymbolS;
        }

        public void RemoveSymbol(CGroup cGroup, CSymbol cSymbol)
        {
            cGroup.RemoveSymbol(cSymbol);

            TreeListNode trnNode = GetTreeNode(m_trnRoot, cGroup);
            TraceRemoveNode(trnNode, cSymbol);

            UpdateTagGroupRoleS();
        }

        public void RemoveSymbolS(CGroup cGroup, CSymbolS cSymbolS)
        {
            exTreeList.BeginUpdate();
            {
                CSymbol cSymbol;
                for (int i = 0; i < cSymbolS.Count; i++)
                {
                    cSymbol = cSymbolS[i];
                    cGroup.RemoveSymbol(cSymbol);
                }

                UpdateGroupNode(cGroup);
            }
            exTreeList.EndUpdate();

            UpdateTagGroupRoleS();
        }

        public void RemoveAllSymbolS(CTagS cTagS)
        {
            exTreeList.BeginUpdate();
            {
                CGroup cGroup;
                for (int i = 0; i < m_cProject.GroupS.Count; i++)
                {
                    cGroup = m_cProject.GroupS[i];

                    CTag cTag;
                    for (int j = 0; j < cTagS.Count; j++)
                    {
                        cTag = cTagS[j];
                        cGroup.RemoveAllSymbolS(cTag.Key);
                    }

                    UpdateGroupNode(cGroup);
                }
            }
            exTreeList.EndUpdate();

            UpdateTagGroupRoleS();
        }

        public void Clear()
        {
            exTreeList.BeginUpdate();
            {
                exTreeList.Nodes.Clear();
                m_trnRoot = null;
            }
            exTreeList.EndUpdate();
        }

        #endregion


        #region Private Methods

        protected void SetEditable(bool bEditable)
        {
            m_bEditable = bEditable;
            //exTreeList.OptionsBehavior.Editable = bEditable;
        }

        protected void UpdateTagGroupRoleS()
        {
            if (m_cProject == null || m_cProject.GroupS == null || m_cProject.TagS == null)
                return;

            m_cProject.GroupS.Compose(m_cProject.TagS);
        }

        protected void UpdateGroupNode(CGroup cGroup)
        {
            TreeListNode trnNode = GetTreeNode(m_trnRoot, cGroup);
            if (trnNode != null)
                UpdateGroupNode(cGroup, trnNode);
        }


        protected void UpdateGroupNode(CGroup cGroup, TreeListNode trnGroup)
        {
            trnGroup.Nodes.Clear();

            CreateRoleTypeTreeNodes(trnGroup);

            CSymbol cSymbol;
            TreeListNode trnRoleType = null;

            // Draw Key Symbol
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Key.ToString());
            if (cGroup.KeySymbolS == null)
                cGroup.KeySymbolS = new CSymbolS();

            for (int j = 0; j < cGroup.KeySymbolS.Count; j++)
            {
                cSymbol = cGroup.KeySymbolS[j];
                TraceCreateSymbolTreeNode(trnRoleType, cSymbol);
            }

            // Draw General Symbol
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.General.ToString());
            if (cGroup.GeneralSymbolS == null)
                cGroup.GeneralSymbolS = new CSymbolS();

            for (int j = 0; j < cGroup.GeneralSymbolS.Count; j++)
            {
                cSymbol = cGroup.GeneralSymbolS[j];
                TraceCreateSymbolTreeNode(trnRoleType, cSymbol);
            }

            // Draw Trend Symbol
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Trend.ToString());
            if (cGroup.TrendSymbolS == null)
                cGroup.TrendSymbolS = new CSymbolS();

            for (int j = 0; j < cGroup.TrendSymbolS.Count; j++)
            {
                cSymbol = cGroup.TrendSymbolS[j];
                TraceCreateSymbolTreeNode(trnRoleType, cSymbol);
            }

            // Draw Abnormal Symbol
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Abnormal.ToString());
            if (cGroup.AbnormalSymbolS == null)
                cGroup.AbnormalSymbolS = new CSymbolS();

            for (int j = 0; j < cGroup.AbnormalSymbolS.Count; j++)
            {
                cSymbol = cGroup.AbnormalSymbolS[j];
                TraceCreateSymbolTreeNode(trnRoleType, cSymbol);
            }
        }

        protected void CreateRoleTypeTreeNodes(TreeListNode trnGroup)
        {
            CreateTreeNode(trnGroup, EMGroupRoleType.Key.ToString(), "", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnGroup, EMGroupRoleType.General.ToString(), "", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnGroup, EMGroupRoleType.Trend.ToString(), "", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnGroup, EMGroupRoleType.Abnormal.ToString(), "", IMG_INDEX_ROLETYPE, null);
        }

        protected void ClearRoleTypeTreeNode(TreeListNode trnGroup)
        {
            TreeListNode trnRoleType = null;
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Key.ToString());
            ClearTreeNode(trnRoleType);
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.General.ToString());
            ClearTreeNode(trnRoleType);
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Trend.ToString());
            ClearTreeNode(trnRoleType);
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Abnormal.ToString());
            ClearTreeNode(trnRoleType);
        }

        protected TreeListNode TraceCreateSymbolTreeNode(TreeListNode trnParent, CSymbol cSymbol)
        {
            TreeListNode trnSymbol = CreateTreeNode(trnParent, cSymbol.Address, cSymbol.Description, IMG_INDEX_SYMBOL, cSymbol);
            if (cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
            {
                CSymbol cSubSymbol;
                for (int i = 0; i < cSymbol.SubSymbolS.Count; i++)
                {
                    cSubSymbol = cSymbol.SubSymbolS[i];
                    TraceCreateSymbolTreeNode(trnSymbol, cSubSymbol);
                }
            }

            return trnSymbol;
        }

        protected TreeListNode CreateTreeNode(TreeListNode trnParent, string sName, string sDescription, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { sName, sDescription });
            else
                trnNode = trnParent.Nodes.Add(new object[] { sName, sDescription });

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            if (trnParent != null)
                trnParent.ExpandAll();

            return trnNode;
        }

        protected TreeListNode GetTreeNode(TreeListNode trnParent, string sText)
        {
            TreeListNode trnNode = null;
            for (int i = 0; i < trnParent.Nodes.Count; i++)
            {
                if (sText == GetNodeText(trnParent.Nodes[i]))
                {
                    trnNode = trnParent.Nodes[i];
                    break;
                }
            }

            return trnNode;
        }

        protected TreeListNode GetTreeNode(TreeListNode trnParent, object oData)
        {
            TreeListNode trnNode = null;
            for (int i = 0; i < trnParent.Nodes.Count; i++)
            {
                if (trnParent.Nodes[i].Tag == oData)
                {
                    trnNode = trnParent.Nodes[i];
                    break;
                }
            }

            return trnNode;
        }

        protected void RemoveTreeNode(TreeListNode trnNode)
        {
            TreeListNode trnParent = trnNode.ParentNode;
            if (trnParent != null)
                trnParent.Nodes.Remove(trnNode);
        }

        protected void RemoveTreeNode(TreeListNode trnParent, string sText)
        {
            TreeListNode trnNode = GetTreeNode(trnParent, sText);
            if (trnNode != null)
                trnParent.Nodes.Remove(trnNode);
        }

        protected void RemoveTreeNode(TreeListNode trnParent, object oData)
        {
            TreeListNode trnNode = GetTreeNode(trnParent, oData);
            if (trnNode != null)
                trnParent.Nodes.Remove(trnNode);
        }

        protected TreeListNode TraceGetTreeNode(TreeListNode trnParent, object oData)
        {
            TreeListNode trnNode = null;
            for (int i = 0; i < trnParent.Nodes.Count; i++)
            {
                if (trnParent.Nodes[i].Tag == oData)
                {
                    trnNode = trnParent.Nodes[i];
                    break;
                }
            }

            if (trnNode == null)
            {
                TreeListNode trnChild = null;
                for (int i = 0; i < trnParent.Nodes.Count; i++)
                {
                    trnChild = trnParent.Nodes[i];
                    trnNode = TraceGetTreeNode(trnChild, oData);
                    if (trnNode != null)
                        break;
                }
            }

            return trnNode;
        }

        protected bool TraceRemoveNode(TreeListNode trnParent, object oData)
        {
            bool bOK = false;

            TreeListNode trnNode;
            for (int i = 0; i < trnParent.Nodes.Count; i++)
            {
                trnNode = trnParent.Nodes[i];
                if (trnNode.Tag == oData)
                {
                    trnParent.Nodes.RemoveAt(i);
                    bOK = true;
                    break;
                }
            }

            if (bOK == false)
            {
                for (int i = 0; i < trnParent.Nodes.Count; i++)
                {
                    trnNode = trnParent.Nodes[i];
                    bOK = TraceRemoveNode(trnNode, oData);
                    if (bOK)
                        break;
                }
            }

            return bOK;
        }

        protected void UpdateTreeNode(TreeListNode trnNode, string sText)
        {
            trnNode.SetValue(colName, sText);
        }

        protected void ClearTreeNode(TreeListNode trnNode)
        {
            trnNode.Nodes.Clear();
        }

        protected void ClearTreeNode(TreeListNode trnNode, TreeListNode trnExcept)
        {
            TreeListNode trnChild;
            for (int i = 0; i < trnNode.Nodes.Count; i++)
            {
                trnChild = trnNode.Nodes[i];
                if (trnChild != trnExcept)
                {
                    trnNode.Nodes.Remove(trnChild);
                }
            }
        }

        protected string GetNodeText(TreeListNode trnNode)
        {
            string sName = trnNode.GetValue(0).ToString();

            return sName;
        }

        protected void GenerateSymbolAddingEvent(string sGroup, CTagS cTagS, EMGroupRoleType emRoleType)
        {
            if (UEventSymbolAdding != null)
                UEventSymbolAdding(this, sGroup, cTagS, emRoleType);
        }

        protected void GenerateSymbolAddEvent(string sGroup, CSymbolS cSymbolS)
        {
            if (UEventSymbolAdded != null)
                UEventSymbolAdded(this, sGroup, cSymbolS);
        }

        protected void GenerateSymbolRemoveEvent(string sGroup, CSymbolS cSymbolS)
        {
            if (UEventSymbolRemoved != null)
                UEventSymbolRemoved(this, sGroup, cSymbolS);
        }

        protected void GenerateSymbolUpdateEvent(string sGroup, CSymbolS cSymbolS)
        {
            if (UEventSymbolUpdated != null)
                UEventSymbolUpdated(this, sGroup, cSymbolS);
        }

        protected void GenerateSymbolDoubleClickEvent(string sGroup, CSymbol cSymbol)
        {
            if (UEventSymbolDoubleClicked != null)
                UEventSymbolDoubleClicked(this, sGroup, cSymbol);
        }

        protected void GenerateGroupDoubleClickEvent(CGroup cGroup)
        {
            if (UEventGroupDoubleClicked != null)
                UEventGroupDoubleClicked(this, cGroup);
        }

        //20150630 KimMinHui Event Add Start
        //Group Add Event 추가
        protected void GenerateGroupAddEvent(CGroup cGroup)
        {
            if (UEventGroupAdded != null)
                UEventGroupAdded(this, cGroup);
        }

        //Group Remove Event 추가
        protected void GenerateGroupRemoveEvent(CGroup cGroup)
        {
            if (UEventGroupRemoved != null)
                UEventGroupRemoved(this, cGroup);
        }

        //Group Update Event 추가
        protected void GenerateGroupUpdateEvent(CGroup cGroup)
        {
            if (UEventGroupUpdated != null)
                UEventGroupUpdated(this, cGroup);
        }
        //20150630 KimMinHui Event Add End


        protected string GetInputText()
        {
            string sText = "";

            if (UEventInputTextRequest != null)
                sText = UEventInputTextRequest(this);

            return sText;
        }

        #endregion


        #region Event Mehtods

        #region Form Event

        private void UCModelTree_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Project Level Menu

        private void mnuAddGroup_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            string sName = GetInputText();
            if (sName != "")
                AddGroup(sName);
        }

        private void mnuRenameProject_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            string sName = GetInputText();
            if (sName != "")
                RenameProject(sName);
        }

        private void mnuClearGroupS_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            ClearProject();

            GenerateSymbolRemoveEvent("", null);
            GenerateSymbolUpdateEvent("", null);
            GenerateGroupUpdateEvent(null);
        }

        private void mnuExpandAll_Click(object sender, EventArgs e)
        {
            exTreeList.ExpandAll();
        }

        private void mnuCollapseAll_Click(object sender, EventArgs e)
        {
            exTreeList.CollapseAll();
        }

        #endregion

        #region Group Level Menu

        private void mnuDeleteGroup_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnGroup = exTreeList.FocusedNode;
            if (trnGroup == null || trnGroup.Tag == null || trnGroup.Tag.GetType() != typeof(CGroup))
                return;

            CGroup cGroup = (CGroup)trnGroup.Tag;
            RemoveGroup(cGroup);

            GenerateGroupRemoveEvent(cGroup);
            GenerateGroupUpdateEvent(cGroup);
        }

        private void mnuRenameGroup_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnGroup = exTreeList.FocusedNode;
            if (trnGroup == null || trnGroup.Tag == null || trnGroup.Tag.GetType() != typeof(CGroup))
                return;

            string sName = GetInputText();
            if (sName != "")
            {
                CGroup cGroup = (CGroup)trnGroup.Tag;
                RenameGroup(cGroup, sName);

                GenerateGroupUpdateEvent(cGroup);
            }
        }

        private void mnuClearGroup_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnGroup = exTreeList.FocusedNode;
            if (trnGroup == null || trnGroup.Tag == null || trnGroup.Tag.GetType() != typeof(CGroup))
                return;

            CGroup cGroup = (CGroup)trnGroup.Tag;
            ClearGroup(cGroup);

            GenerateGroupUpdateEvent(cGroup);
        }

        #endregion

        #region RoleType Level Menu

        private void mnuAddSymbolS_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnRoleType = exTreeList.FocusedNode;
            TreeListNode trnGroup = trnRoleType.ParentNode;
            if (trnGroup == null || trnGroup.Tag == null || trnGroup.Tag.GetType() != typeof(CGroup))
                return;

            CTagS cTagS = null;
            if (m_ucManager != null)
            {
                cTagS = m_ucManager.GetSelectedTagS();
                if (cTagS == null || cTagS.Count == 0)
                    return;
            }
            else
            {
                if (m_ucTagTable != null)
                    cTagS = m_ucTagTable.GetSelectedTagS();
                else
                    return;
            }
            CGroup cGroup = (CGroup)trnGroup.Tag;
            EMGroupRoleType emRoleType = CCommonUtil.ToGroupRoleType(GetNodeText(trnRoleType));

            CSymbolS cSymbolS = AddSymbolS(cGroup, cTagS, emRoleType);

            GenerateSymbolAddEvent(cGroup.Key, cSymbolS);
            GenerateSymbolUpdateEvent(cGroup.Key, cSymbolS);
            GenerateGroupUpdateEvent(cGroup);
        }

        private void mnuClearSymbolS_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnRoleType = exTreeList.FocusedNode;
            TreeListNode trnGroup = trnRoleType.ParentNode;
            if (trnGroup == null || trnGroup.Tag == null || trnGroup.Tag.GetType() != typeof(CGroup))
                return;

            CGroup cGroup = (CGroup)trnGroup.Tag;
            CSymbolS cSymbolS = new CSymbolS();
            CSymbol cSymbol;
            for (int i = 0; i < trnRoleType.Nodes.Count; i++)
            {
                cSymbol = (CSymbol)trnRoleType.Nodes[i].Tag;
                if (cSymbol != null)
                    cSymbolS.Add(cSymbol.Key, cSymbol);
            }

            RemoveSymbolS(cGroup, cSymbolS);

            GenerateSymbolRemoveEvent(cGroup.Key, cSymbolS);
            GenerateSymbolUpdateEvent(cGroup.Key, cSymbolS);
            GenerateGroupUpdateEvent(cGroup);
        }

        #endregion

        #region Symbol Level Menu

        private void mnuDeleteSymbol_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            TreeListNode trnSymbol = exTreeList.FocusedNode;
            if (trnSymbol == null || trnSymbol.Tag == null || trnSymbol.Tag.GetType() != typeof(CSymbol))
                return;

            CSymbol cSymbol = (CSymbol)trnSymbol.Tag;
            CGroup cGroup = m_cProject.GroupS[cSymbol.GroupKey];

            CSymbolS cSymbolS = new CSymbolS();
            if (cSymbol != null)
                cSymbolS.Add(cSymbol.Key, cSymbol);

            RemoveSymbol(cGroup, cSymbol);

            GenerateSymbolRemoveEvent(cGroup.Key, cSymbolS);
            GenerateSymbolUpdateEvent(cGroup.Key, cSymbolS);
            GenerateGroupUpdateEvent(cGroup);
        }

        #endregion

        #region Tree Event

        private void exTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            m_bDragDropReady = false;

            TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(new Point(e.X, e.Y));
            if (exHitInfo.Node == null)
                return;

            if (Control.ModifierKeys != Keys.None)
                return;

            m_bDragDropReady = true;
        }

        private void exTreeList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_bDragDropReady)
            {
                CSymbol cSymbol = GetSelectedSymbol();
                if (cSymbol == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                exTreeList.DoDragDrop(cSymbol, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void exTreeList_DragOver(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exTreeList_DragDrop(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(pntClient);
                if (exHitInfo != null && exHitInfo.Node != null)
                {
                    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                    if (cTagS == null || cTagS.Count == 0)
                        return;

                    TreeListNode trnNode = exHitInfo.Node;
                    string sNodeKey = GetNodeText(trnNode);
                    bool bOK = false;

                    EMGroupRoleType emRoleType = EMGroupRoleType.General;
                    if (sNodeKey == EMGroupRoleType.Key.ToString())
                    {
                        bOK = true;
                        emRoleType = EMGroupRoleType.Key;
                    }
                    else if (sNodeKey == EMGroupRoleType.General.ToString())
                    {
                        bOK = true;
                        emRoleType = EMGroupRoleType.General;
                    }
                    else if (sNodeKey == EMGroupRoleType.Trend.ToString())
                    {
                        bOK = true;
                        emRoleType = EMGroupRoleType.Trend;
                    }
                    else if (sNodeKey == EMGroupRoleType.Abnormal.ToString())
                    {
                        bOK = true;
                        emRoleType = EMGroupRoleType.Abnormal;
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign symbol at this node!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (bOK)
                    {
                        TreeListNode trnGroup = trnNode.ParentNode;
                        CGroup cGroup = (CGroup)trnGroup.Tag;
                        CSymbolS cSymbolS = AddSymbolS(cGroup, cTagS, emRoleType);

                        GenerateSymbolAddEvent(cGroup.Key, cSymbolS);
                        GenerateSymbolUpdateEvent(cGroup.Key, cSymbolS);
                    }
                }
            }
        }

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null)
            {
                CObject cObject = (CObject)trnNode.Tag;
                if (cObject != null)
                {
                    if (cObject.GetType() == typeof(CGroup))
                    {
                        GenerateGroupDoubleClickEvent((CGroup)cObject);
                    }
                    else if (cObject.GetType() == typeof(CSymbol))
                    {
                        CGroup cGroup = null;
                        if (trnNode.Level == NODE_LEVEL_SYMBOL)
                            cGroup = (CGroup)trnNode.ParentNode.ParentNode.Tag;
                        else if (trnNode.Level == NODE_LEVEL_SUBSYMBOL)
                            cGroup = (CGroup)trnNode.ParentNode.ParentNode.ParentNode.Tag;

                        if (cGroup != null)
                            GenerateSymbolDoubleClickEvent(cGroup.Key, (CSymbol)cObject);
                    }
                }
            }
        }

        private void exTreeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (m_bEditable == false)
            {
                exTreeList.ContextMenuStrip = null;
                e.Allow = false;
                return;
            }

            if (e.Menu is TreeListNodeMenu)
            {
                TreeListNode trnNode = ((TreeListNodeMenu)e.Menu).Node;

                exTreeList.FocusedNode = trnNode;

                object oData = trnNode.Tag;
                if (oData == null)
                {
                    string sNode = GetNodeText(trnNode);
                    if (trnNode == m_trnRoot)
                    {
                        exTreeList.ContextMenuStrip = cntxProjectMenu;
                    }
                    else if (sNode == EMGroupRoleType.Key.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMGroupRoleType.General.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMGroupRoleType.Trend.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMGroupRoleType.Abnormal.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
                else
                {
                    Type tpNode = trnNode.Tag.GetType();
                    if (tpNode == typeof(CGroup))
                    {
                        exTreeList.ContextMenuStrip = cntxGroupMenu;
                    }
                    else if (tpNode == typeof(CSymbol))
                    {
                        exTreeList.ContextMenuStrip = cntxSymbolMenu;
                    }
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
            }
        }

        private void OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (m_bEditable == false)
                return;


            if (e.KeyCode == Keys.Delete)
            {
                TreeListNode trnSymbol = exTreeList.FocusedNode;
                if (trnSymbol == null || trnSymbol.Tag == null || trnSymbol.Tag.GetType() != typeof(CSymbol))
                    return;

                CGroup cGroup = (CGroup)trnSymbol.ParentNode.ParentNode.Tag;
                CSymbolS cSymbolS = new CSymbolS();
                CSymbol cSymbol = (CSymbol)trnSymbol.Tag;
                if (cSymbol != null)
                    cSymbolS.Add(cSymbol.Key, cSymbol);

                RemoveSymbolS(cGroup, cSymbolS);

                GenerateSymbolRemoveEvent(cGroup.Key, cSymbolS);
                GenerateSymbolUpdateEvent(cGroup.Key, cSymbolS);
            }
        }

        #endregion

        #endregion

    }
}
