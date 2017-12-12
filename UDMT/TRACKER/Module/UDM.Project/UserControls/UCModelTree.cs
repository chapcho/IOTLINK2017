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
using UDM.Model;

namespace UDM.Project
{
    public partial class UCModelTree : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = false;        
        protected CProject m_cProject = null;
        protected UCProjectManager m_ucManager = null;
        protected TreeListNode m_trnRoot = null;

        public event UEventHandlerModelTreeAdded UEventSymbolAdded;
        public event UEventHandlerModelTreeRemoved UEventSymbolRemoved;
        public event UEventHandlerModelTreeUpdated UEventSymbolUpdated;
        public event UEventHandlerModelTreeNodeDoubleClicked UEventNodeDoubleClicked;

		//20150630 KimMinHui
		//Process Evnet Handler 추가 Start
		public event UEventHandlerModelTreeProcessAdded UEventProcessAdded;
		public event UEventHandlerModelTreeProcessRemove UEventProcessRemoved;
		public event UEventHandlerModelTreeProcessUpdate UEventProcessUpdated;
		//Process Evnet Handler 추가 종료

        protected const int IMG_INDEX_LINE = 0;
        protected const int IMG_INDEX_PROCESS = 1;
        protected const int IMG_INDEX_MACHINE = 1;
        protected const int IMG_INDEX_ROLETYPE = 1;
        protected const int IMG_INDEX_SYMBOL = 2;
        protected const int NODE_LEVEL_LINE = 0;
        protected const int NODE_LEVEL_PROCESS = 1;
        protected const int NODE_LEVEL_MACHINE = 2;
        protected const int NODE_LEVEL_ROLETYPE = 3;
        protected const int NODE_LEVEL_SYMBOL = 4;

        #endregion


        #region Initialize/Dispose

        public UCModelTree()
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
            set { SetProject(value); }
        }

        public UCProjectManager Manager
        {
            get { return m_ucManager; }
            set { m_ucManager = value; }
        }


        #endregion


        #region Public Methods

        public CObject GetSelectedObject()
        {
            CObject cObject = null;

            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null && trnNode.Tag != null)
            {
                cObject = (CObject)trnNode.Tag;
            }

            return cObject;
        }

        public void RenameLine(CLine cLine, string sNewName)
        {
            if (m_trnRoot == null)
                return;

            if (cLine.Name == sNewName)
                return;

            cLine.Key = sNewName;
            cLine.Name = sNewName;
            cLine.Update();

            UpdateTreeNode(m_trnRoot, cLine.Name);
            base.Refresh();
        }

        public void ClearLine(CLine cLine)
        {
            if (m_trnRoot == null)
                return;

            cLine.Clear();

            ClearTreeNode(m_trnRoot);
            base.Refresh();            
        }

        public CProcess AddProcess(CLine cLine, string sName)
        {
            if (m_trnRoot == null)
                return null;

            CProcess cProcess = new CProcess(cLine, sName);
            if (cLine.ProcessS.ContainsKey(cProcess.Key))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cProcess = null;
            }
            else
            {
                cProcess.Parent = cLine;
                cLine.ProcessS.Add(cProcess.Key, cProcess);

                TreeListNode trnProcess = CreateTreeNode(m_trnRoot, cProcess.Name, IMG_INDEX_PROCESS, cProcess);
                CreateSymbolSTreeNode(trnProcess);

				//20150630 KimMinHui Process Add 이벤트 추가
				GenerateProcessAddEvent(cProcess);
				GenerateProcessUpdateEvent(cProcess);

                base.Refresh();
            }

            return cProcess;
        }
        
        public void RenameProcess(CProcess cProcess, string sNewName)
        {
            if (cProcess.Name == sNewName)
                return;

            CLine cLine = (CLine)cProcess.Parent;
            if (cLine.ProcessS.ContainsKey(sNewName))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cProcess.Name = sNewName;
            cLine.Update();
            
            TreeListNode trnNode = GetTreeNode(m_trnRoot, cProcess);
            if (trnNode != null)
                UpdateTreeNode(trnNode, cProcess.Name);

			//20150630 KimMinHui Process Update 추가
			GenerateProcessUpdateEvent(cProcess);

            base.Refresh();
        }

        public void RemoveProcess(CProcess cProcess)
        {
            CLine cLine = (CLine)cProcess.Parent;

			//20150630 KimMinHui Process Remove 추가
			GenerateProcessRemoveEvent(cProcess);

            cLine.ProcessS.Remove(cProcess.Key);

            cProcess.Clear();

            TreeListNode trnNode = GetTreeNode(m_trnRoot, cProcess);
            if (trnNode != null)
                RemoveTreeNode(trnNode);

			GenerateProcessUpdateEvent(cProcess);

            base.Refresh();
        }

        public void ClearProcess(CProcess cProcess)
        {           
            cProcess.Clear();

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            if (trnProcess != null)
            {
                TreeListNode trnSymbolS = ClearSymbolSTreeNode(trnProcess);                
                ClearTreeNode(trnProcess, trnSymbolS);
            }

            base.Refresh();
        }

        public CMachine AddMachine(CProcess cProcess, string sName)
        {
            CMachine cMachine = new CMachine(cProcess, sName);
            if (cProcess.MachineS.ContainsKey(cMachine.Name))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cMachine = null;
            }
            else
            {
                cMachine.Parent = cProcess;
                cProcess.MachineS.Add(cMachine.Key, cMachine);

                TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
                TreeListNode trnMachine = CreateTreeNode(trnProcess, cMachine.Name, IMG_INDEX_PROCESS, cMachine);
                CreateSymbolSTreeNode(trnMachine);

                base.Refresh();
            }

            return cMachine;
        }

        public void RenameMachine(CMachine cMachine, string sNewName)
        {
            if (cMachine.Name == sNewName)
                return;

            CProcess cProcess = (CProcess)cMachine.Parent;
            if (cProcess.MachineS.ContainsKey(sNewName))
            {
                MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cMachine.Name = sNewName;
            cProcess.Update();

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            if (trnProcess != null)
            {
                TreeListNode trnMachine = GetTreeNode(trnProcess, cMachine);
                UpdateTreeNode(trnMachine, cMachine.Name);
            }

            base.Refresh();
        }   

        public void RemoveMachine(CMachine cMachine)
        {
            cMachine.Clear();

            CProcess cProcess = (CProcess)cMachine.Parent;            
            cProcess.MachineS.Remove(cMachine.Key);

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            if (trnProcess != null)
                RemoveTreeNode(trnProcess, cMachine);

            base.Refresh();
        }

        public void ClearMachine(CMachine cMachine)
        {
            cMachine.Clear();

            CProcess cProcess = (CProcess)cMachine.Parent;

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            TreeListNode trnMachine = GetTreeNode(trnProcess, cMachine);
            if (trnMachine != null)
            {
                TreeListNode trnSymbolS = ClearSymbolSTreeNode(trnMachine);
                ClearTreeNode(trnMachine, trnSymbolS);
            }

            base.Refresh();
        }

        public void AddSymbolS(CProcess cProcess, EMMonitorType emRoleType, CSymbolS cSymbolS)
        {
            RemoveSymbolS(cSymbolS);

            CSymbol cSymbol;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                cSymbol.Group = cProcess;
                cSymbol.MonitorType = emRoleType;
                cProcess.SymbolS.Add(cSymbol.Key, cSymbol);
            }

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            if (trnProcess == null)
                return;

            exTreeList.BeginUpdate();

            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                CreateSymbolTreeNode(trnProcess, cSymbol);
            }

            exTreeList.EndUpdate();

            base.Refresh();
        }

        public void AddSymbolS(CMachine cMachine, EMMonitorType emRoleType ,CSymbolS cSymbolS)
        {
            RemoveSymbolS(cSymbolS);

            CProcess cProcess = (CProcess)cMachine.Parent;

            CSymbol cSymbol;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                cSymbol.Group = cMachine;
                cSymbol.MonitorType = emRoleType;
                cMachine.SymbolS.Add(cSymbol.Key, cSymbol);
            }

            TreeListNode trnProcess = GetTreeNode(m_trnRoot, cProcess);
            if (trnProcess == null)
                return;

            TreeListNode trnMachine = GetTreeNode(trnProcess, cMachine);
            if (trnMachine == null)
                return;

            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                CreateSymbolTreeNode(trnMachine, cSymbol);
            }

            base.Refresh();
        }

        public void RemoveSymbolS(CSymbolS cSymbolS)
        {
            TreeListNode trnParent;
            TreeListNode trnSymbolS;
            TreeListNode trnRoleType;
            CGroup cParent;
            CSymbol cSymbol;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                cParent = cSymbol.Group;
                if (cParent != null)
                {
                    trnParent = null;
                    if (cParent.GetType() == typeof(CProcess))
                    {
                        trnParent = GetTreeNode(m_trnRoot, cParent);                        
                    }
                    else if (cParent.GetType() == typeof(CMachine))
                    {
                        trnParent = GetTreeNode(m_trnRoot, cParent.Parent);
                        trnParent = GetTreeNode(trnParent, cParent);
                    }

                    if (trnParent != null)
                    {
                        trnSymbolS = GetTreeNode(trnParent, "Symbols");
                        trnRoleType = GetTreeNode(trnSymbolS, cSymbol.MonitorType.ToString());
                        RemoveTreeNode(trnRoleType, cSymbol);
                    }

                    cParent.SymbolS.Remove(cSymbol.Key);
                    cSymbol.MonitorType = EMMonitorType.General;
                    cSymbol.Group = null;
                }
            }

            base.Refresh();
        }

        public new void Refresh()
        {
            Clear();

            if (m_cProject == null || m_cProject.Name == "")
                return;            

            exTreeList.BeginUpdate();
            {
                // Draw Line
                CLine cLine = m_cProject.Line;
                m_trnRoot = CreateTreeNode(null, cLine.Name, IMG_INDEX_LINE, cLine);                

                
                CProcess cProcess;
                CMachine cMachine;
                CSymbol cSymbol;

                TreeListNode trnProcess;                
                TreeListNode trnMachine;               
                for (int i = 0; i < cLine.ProcessS.Count; i++)
                {
                    // Draw Process
                    cProcess = cLine.ProcessS[i];
                    trnProcess = CreateTreeNode(m_trnRoot, cProcess.Name, IMG_INDEX_PROCESS, cProcess);
                    CreateSymbolSTreeNode(trnProcess);

                    // Draw Symbol
                    for (int j = 0; j < cProcess.SymbolS.Count; j++)
                    {
                        cSymbol = cProcess.SymbolS[j];
                        if (cSymbol.Group == cProcess)
                            CreateSymbolTreeNode(trnProcess, cSymbol);
                    }

                    // Draw Machine                    
                    for (int j = 0; j < cProcess.MachineS.Count; j++)
                    {
                        cMachine = cProcess.MachineS[j];
                        trnMachine = CreateTreeNode(trnProcess, cMachine.Name, IMG_INDEX_MACHINE, cMachine);
                        CreateSymbolSTreeNode(trnMachine);

                        // Draw Symbol
                        for (int k = 0; k < cMachine.SymbolS.Count; k++)
                        {
                            cSymbol = cMachine.SymbolS[k];
                            CreateSymbolTreeNode(trnMachine, cSymbol);
                        }
                    }
                }
            }
            exTreeList.EndUpdate();
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

        protected void SetProject(CProject cProject)
        {
            Clear();

            m_cProject = cProject;

            Refresh();
        }

        protected TreeListNode CreateSymbolSTreeNode(TreeListNode trnParent)
        {
            TreeListNode trnSymbolS = CreateTreeNode(trnParent, "Symbols", IMG_INDEX_PROCESS, null);
            CreateTreeNode(trnSymbolS, EMMonitorType.Key.ToString(), IMG_INDEX_ROLETYPE,null);
            CreateTreeNode(trnSymbolS, EMMonitorType.General.ToString(), IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnSymbolS, EMMonitorType.Trend.ToString(), IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnSymbolS, EMMonitorType.Abnormal.ToString(), IMG_INDEX_ROLETYPE, null);
            

            return trnSymbolS;
        }

        protected TreeListNode ClearSymbolSTreeNode(TreeListNode trnParent)
        {
            TreeListNode trnSymbolS = GetTreeNode(trnParent, "Symbols");
            if (trnSymbolS != null)
            {
                TreeListNode trnRoleType = null;
                trnRoleType = GetTreeNode(trnSymbolS, EMMonitorType.Key.ToString());
                ClearTreeNode(trnRoleType);
                trnRoleType = GetTreeNode(trnSymbolS, EMMonitorType.General.ToString());
                ClearTreeNode(trnRoleType);
                trnRoleType = GetTreeNode(trnSymbolS, EMMonitorType.Trend.ToString());
                ClearTreeNode(trnRoleType);
                trnRoleType = GetTreeNode(trnSymbolS, EMMonitorType.Abnormal.ToString());
                ClearTreeNode(trnRoleType);
            }

            return trnSymbolS;
        }

        protected void CreateSymbolTreeNode(TreeListNode trnParent, CSymbol cSymbol)
        {
            TreeListNode trnSymbolS = GetTreeNode(trnParent, "Symbols");
            TreeListNode trnRoleType = GetTreeNode(trnSymbolS, cSymbol.MonitorType.ToString());

            CreateTreeNode(trnRoleType, cSymbol.Name, IMG_INDEX_SYMBOL, cSymbol);
        }

        protected TreeListNode CreateTreeNode(TreeListNode trnParent, string sText, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { sText });
            else
                trnNode = trnParent.Nodes.Add(new object[] { sText });

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

        protected void GenerateAddEvent(CSymbolS cSymbolS)
        {
            if (UEventSymbolAdded != null)
                UEventSymbolAdded(this, cSymbolS);
        }

        protected void GenerateRemoveEvent(CSymbolS cSymbolS)
        {
            if (UEventSymbolRemoved != null)
                UEventSymbolRemoved(this, cSymbolS);
        }

        protected void GenerateUpdateEvent(CSymbolS cSymbolS)
        {
            if (UEventSymbolUpdated != null)
                UEventSymbolUpdated(this, cSymbolS);
        }

        protected void GenerateDoubleClickEvent(CObject cObject)
        {
            if (UEventNodeDoubleClicked != null)
                UEventNodeDoubleClicked(this, cObject);
        }

		//20150630 KimMinHui Event Add Start
		//Process Add Event 추가
		protected void GenerateProcessAddEvent(CProcess cProcess)
		{
			if (UEventProcessAdded != null)
				UEventProcessAdded(this, cProcess);
		}
		
		//Process Remove Event 추가
		protected void GenerateProcessRemoveEvent(CProcess cProcess)
		{
			if (UEventProcessRemoved != null)
				UEventProcessRemoved(this, cProcess);
		}
		
		//Process Update Event 추가
		protected void GenerateProcessUpdateEvent(CProcess cProcess)
		{
			if (UEventProcessUpdated != null)
				UEventProcessUpdated(this, cProcess);
		}
		//20150630 KimMinHui Event Add End


        protected string GetUserInput()
        {
            string sText = "";

            FrmInputDialog dlgInput = new FrmInputDialog();
            dlgInput.ShowDialog();
            sText = dlgInput.InputText;
            dlgInput.Dispose();
            dlgInput = null;

            return sText;
        }

        #endregion


        #region Event Mehtods

        #region Form Event

        private void UCModelTree_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Line Level Menu

        private void mnuAddProcess_Click(object sender, EventArgs e)
        {
            string sName = GetUserInput();

            if (sName != "")
            {
                CLine cLine = m_cProject.Line;
                AddProcess(cLine, sName);
            }
        }

        private void mnuRenameLine_Click(object sender, EventArgs e)
        {
            string sName = GetUserInput();
            if (sName != "")
            {
                CLine cLine = m_cProject.Line;
                RenameLine(cLine, sName);
            }
        }

        private void mnuClearProcessS_Click(object sender, EventArgs e)
        {
            CLine cLine = m_cProject.Line;
            ClearLine(cLine);
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

        #region Process Level Menu

        private void mnuAddMachine_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CProcess))
                return;

            string sName = GetUserInput();
            if (sName != "")
            {
                CProcess cProcess = (CProcess)trnProcess.Tag;
                AddMachine(cProcess, sName);
            }
        }

        private void mnuDeleteProcess_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CProcess))
                return;

            CProcess cProcess = (CProcess)trnProcess.Tag;
            CSymbolS cSymbolS = cProcess.SymbolS;
            RemoveProcess(cProcess);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        private void mnuRenameProcess_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CProcess))
                return;

            string sName = GetUserInput();
            if (sName != "")
            {
                CProcess cProcess = (CProcess)trnProcess.Tag;
                CSymbolS cSymbolS = cProcess.SymbolS;
                RenameProcess(cProcess, sName);

                GenerateUpdateEvent(cSymbolS);
            }   
        }

        private void mnuClearMachineS_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CProcess))
                return;

            CProcess cProcess = (CProcess)trnProcess.Tag;
            CSymbolS cSymbolS = cProcess.SymbolS;
            ClearProcess(cProcess);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        #endregion

        #region Machine Level Menu

        private void mnuDeleteMachine_Click(object sender, EventArgs e)
        {
            TreeListNode trnMachine = exTreeList.FocusedNode;
            if (trnMachine == null || trnMachine.Tag == null || trnMachine.Tag.GetType() != typeof(CMachine))
                return;

            CMachine cMachine = (CMachine)trnMachine.Tag;
            CSymbolS cSymbolS = new CSymbolS();
            cSymbolS.AddRange(cMachine.SymbolS);

            RemoveMachine(cMachine);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        private void mnuRenameMachine_Click(object sender, EventArgs e)
        {
            TreeListNode trnMachine = exTreeList.FocusedNode;
            if (trnMachine == null || trnMachine.Tag == null || trnMachine.Tag.GetType() != typeof(CMachine))
                return;

            string sName = GetUserInput();
            if (sName != "")
            {
                CMachine cMachine = (CMachine)trnMachine.Tag;
                CSymbolS cSymbolS = new CSymbolS();
                cSymbolS.AddRange(cMachine.SymbolS);

                RenameMachine(cMachine, sName);

                GenerateUpdateEvent(cSymbolS);
            }
        }

        private void mnuClearRoleTypeS_Click(object sender, EventArgs e)
        {
            TreeListNode trnMachine = exTreeList.FocusedNode;
            if (trnMachine == null || trnMachine.Tag == null || trnMachine.Tag.GetType() != typeof(CMachine))
                return;

            CMachine cMachine = (CMachine)trnMachine.Tag;
            CSymbolS cSymbolS = new CSymbolS();
            cSymbolS.AddRange(cMachine.SymbolS);

            ClearMachine(cMachine);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        #endregion

        #region RoleType Level Menu

        private void mnuAddSymbolS_Click(object sender, EventArgs e)
        {
            TreeListNode trnRoleType = exTreeList.FocusedNode;
            TreeListNode trnMachine = trnRoleType.ParentNode;
            if (trnMachine == null || trnMachine.Tag == null || trnMachine.Tag.GetType() != typeof(CMachine))
                return;

            CSymbolS cSymbolS = m_ucManager.GetSelectedSymbolS();
            if (cSymbolS == null || cSymbolS.Count == 0)
                return;


            CMachine cMachine = (CMachine)trnMachine.Tag;
            EMMonitorType emRoleType = CTypeConvert.ToMonitorType(GetNodeText(trnRoleType));

            AddSymbolS(cMachine, emRoleType, cSymbolS);

            GenerateAddEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        private void mnuClearSymbolS_Click(object sender, EventArgs e)
        {
            TreeListNode trnRoleType = exTreeList.FocusedNode;
            if (trnRoleType == null)
                return;

            CSymbolS cSymbolS = new CSymbolS();
            CSymbol cSymbol;
            for (int i = 0; i < trnRoleType.Nodes.Count; i++)
            {
                cSymbol = (CSymbol)trnRoleType.Nodes[i].Tag;
                if (cSymbol != null)
                    cSymbolS.Add(cSymbol.Key, cSymbol);
            }

            RemoveSymbolS(cSymbolS);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        #endregion

        #region Symbol Level Menu

        private void mnuDeleteSymbol_Click(object sender, EventArgs e)
        {
            TreeListNode trnSymbol = exTreeList.FocusedNode;
            if (trnSymbol == null || trnSymbol.Tag == null || trnSymbol.Tag.GetType() != typeof(CSymbol))
                return;


            CSymbolS cSymbolS = new CSymbolS();
            CSymbol cSymbol = (CSymbol)trnSymbol.Tag;
            if (cSymbol != null)
                cSymbolS.Add(cSymbol.Key, cSymbol);

            RemoveSymbolS(cSymbolS);

            GenerateRemoveEvent(cSymbolS);
            GenerateUpdateEvent(cSymbolS);
        }

        #endregion

        #region Tree Event

        private void exTreeList_DragOver(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            if (e.Data.GetDataPresent(typeof(CSymbolS)))
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

            if (e.Data != null && e.Data.GetDataPresent(typeof(CSymbolS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(pntClient);
                if (exHitInfo != null && exHitInfo.Node != null)
                {
                    CSymbolS cSymbolS = (CSymbolS)e.Data.GetData(typeof(CSymbolS));
                    if (cSymbolS == null || cSymbolS.Count == 0)
                        return;

                    TreeListNode trnNode = exHitInfo.Node;
                    string sNodeKey = GetNodeText(trnNode);
                    bool bOK = false;

                    EMMonitorType emRoleType = EMMonitorType.General;
                    if (sNodeKey == EMMonitorType.Key.ToString())
                    {
                        bOK = true;
                        emRoleType = EMMonitorType.Key;
                    }
                    else if (sNodeKey == EMMonitorType.General.ToString())
                    {
                        bOK = true;
                        emRoleType = EMMonitorType.General;
                    }
                    else if (sNodeKey == EMMonitorType.Trend.ToString())
                    {
                        bOK = true;
                        emRoleType = EMMonitorType.Trend;
                    }
                    else if (sNodeKey == EMMonitorType.Abnormal.ToString())
                    {
                        bOK = true;
                        emRoleType = EMMonitorType.Abnormal;
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign symbol at this node!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (bOK)
                    {
                        TreeListNode trnParent = trnNode.ParentNode.ParentNode;
                        CGroup cGroup = (CGroup)trnParent.Tag;

                        exTreeList.BeginUpdate();

                        if (cGroup.GetType() == typeof(CProcess))
                        {
                            AddSymbolS((CProcess)cGroup, emRoleType, cSymbolS);
                        }
                        else if (cGroup.GetType() == typeof(CMachine))
                        {
                            AddSymbolS((CMachine)cGroup, emRoleType, cSymbolS);
                        }

                        exTreeList.EndUpdate();


                        GenerateAddEvent(cSymbolS);
                        GenerateUpdateEvent(cSymbolS);
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
                GenerateDoubleClickEvent(cObject);
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
                    if (sNode == EMMonitorType.Key.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMMonitorType.General.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMMonitorType.Trend.ToString())
                    {
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    }
                    else if (sNode == EMMonitorType.Abnormal.ToString())
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
                    if (tpNode == typeof(CLine))
                    {
                        exTreeList.ContextMenuStrip = cntxLineMenu;
                    }
                    else if(tpNode == typeof(CProcess))
                    {
                        exTreeList.ContextMenuStrip = cntxProcessMenu;
                    }
                    else if (tpNode == typeof(CMachine))
                    {
                        exTreeList.ContextMenuStrip = cntxMachineMenu;
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

        #endregion

        private void OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TreeListNode trnSymbol = exTreeList.FocusedNode;
                if (trnSymbol == null || trnSymbol.Tag == null || trnSymbol.Tag.GetType() != typeof(CSymbol))
                    return;


                CSymbolS cSymbolS = new CSymbolS();
                CSymbol cSymbol = (CSymbol)trnSymbol.Tag;
                if (cSymbol != null)
                    cSymbolS.Add(cSymbol.Key, cSymbol);

                RemoveSymbolS(cSymbolS);

                GenerateRemoveEvent(cSymbolS);
                GenerateUpdateEvent(cSymbolS);
            }
        }

        #endregion

    }
}
