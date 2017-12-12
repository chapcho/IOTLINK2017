using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using UDM.Common;
using TrackerCommon;

namespace UDMLadderTracker
{

    public delegate void UEventProcessDoubleClicked(object sender, string sProcessKey);

    public partial class UCProcessTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected const int IMG_INDEX_PROCESS = 0;
        protected const int IMG_INDEX_ROLETYPE = 1;
        protected const int IMG_INDEX_SYMBOL = 2;
        protected const int IMG_INDEX_PROJECT = 3;

        protected const int NODE_LEVEL_PROCESS = 0;
        protected const int NODE_LEVEL_ROLETYPE = 1;
        protected const int NODE_LEVEL_SYMBOL = 2;

        protected bool m_bDragDropReady = false;
        private List<string> m_lstAbnormalFilter = null;

        public event UEventProcessDoubleClicked UEventProcessDoubleClicked;

        #endregion


        #region Initialize

        public UCProcessTree()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public List<string> AbnormalFilter
        {
            get { return m_lstAbnormalFilter; }
            set { m_lstAbnormalFilter = value; }
        }

        #endregion


        #region Public Method

        public void ResetAbnormal(CPlcProc cProcess)
        {
            /*
            m_lstAbnormalTag.Clear();
            List<CTag> lstTag = GetProcessKeyTagS(cProcess.Name);

            string sDescription = string.Empty;
            CAbnormalSymbol cAbnormalSymbol = null;
            CPlcLogicData cData = null;

            foreach (CTag cTag in lstTag)
            {
                cData = CMultiProject.GetPlcLogicData(cTag);

                if (!cProcess.PlcLogicDataS.ContainsValue(cData))
                    cProcess.PlcLogicDataS.Add(cData.PLCID, cData);

            }

            cProcess.AbnormalSymbolS.Clear();

            foreach(CTag cTag in m_lstAbnormalTag)
            {
                sDescription = cTag.Description;

                if (m_lstAbnormalFilter == null)
                    continue;

                foreach (string sAbnormal in m_lstAbnormalFilter)
                {
                    if (sDescription.Contains(sAbnormal))
                    {
                        cAbnormalSymbol = new CAbnormalSymbol(cTag);
                        cProcess.AbnormalSymbolS.Add(cAbnormalSymbol.Tag.Key, cAbnormalSymbol);
                        break;
                    }
                }
            }

            cProcess.UpdateAbnormalSymbolS();
             * */
        }

        public void Clear()
        {
            exTreeList.Nodes.Clear();
        }

        public void ShowTree()
        {
            exTreeList.BeginUpdate();
            {
                CPlcProc cPlcProcess;
                TreeListNode trnProcess;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (CheckProcessTreeNode(who.Key))
                        continue;

                    cPlcProcess = who.Value;
                    trnProcess = CreateTreeNode(null, who.Key, "", IMG_INDEX_PROCESS, cPlcProcess);
                    UpdateGroupNode(cPlcProcess, trnProcess);

                    trnProcess.Expanded = true;
                }
            }
            exTreeList.EndUpdate();
        }

        public void UpdateTree()
        {
            exTreeList.BeginUpdate();
            {
                string sDescription = string.Empty;
                CAbnormalSymbol cAbnormalSymbol = null;

                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    cProcess.AbnormalSymbolS.Clear();

                    foreach (CTag cTag in cProcess.InOutTagS.Values)
                    {
                        sDescription = cTag.Description;

                        foreach (string sAbnormal in m_lstAbnormalFilter)
                        {
                            if (sDescription.Contains(sAbnormal))
                            {
                                cAbnormalSymbol = new CAbnormalSymbol(cTag);
                                cProcess.AbnormalSymbolS.Add(cAbnormalSymbol.Tag.Key, cAbnormalSymbol);
                                break;
                            }
                        }
                    }
                    UpdateGroupNode(cProcess, exTreeList.FindNodeByFieldValue("Name", cProcess.Name));
                }
            }
            exTreeList.EndUpdate();
        }

        #endregion


        #region Private Method

        private List<CTag> GetProcessKeyTagS(string sText, CPlcProc cProcess)
        {
            List<CTag> lstResult = new List<CTag>();

            foreach (var who in CMultiProject.TotalTagS)
            {
                CTag cTag = who.Value;
                if (cTag.DataType != EMDataType.Bool) continue;
                if (cTag.Description == string.Empty) continue;
                if (cTag.Description.Contains(sText) == false) continue;
                if (CheckPlcOutputDevice(cTag) == false) continue;

                lstResult.Add(cTag);
            }

            return lstResult;
        }

        private bool CheckPlcIODevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.Address.Contains("X") || cTag.Address.Contains("Y"))
                return true;

            //Seimens
            if (cTag.Address.Contains("I") || cTag.Address.Contains("Q"))
                return true;

            //LS
            if (cTag.Address.Contains("P"))
                return true;

            return false;
        }

        private bool CheckPlcOutputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.Address.Contains("Y"))
                return true;

            //Seimens
            if (cTag.Address.Contains("Q"))
                return true;

            //LS
            if (cTag.Address.Contains("P"))
                return true;

            return false;
        }

        private bool CheckPlcInputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.Address.Contains("X"))
                return true;

            //Seimens
            if (cTag.Address.Contains("I"))
                return true;

            //LS
            if (cTag.Address.Contains("P"))
                return true;

            return false;
        }

        private bool CheckProcessTreeNode(string sText)
        {
            bool bOK = false;

            for (int i = 0; i < exTreeList.Nodes.Count; i++)
            {
                if (sText == GetNodeText(exTreeList.Nodes[i]))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sName, string sDescription, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { sName, sDescription });
            else
                trnNode = trnParent.Nodes.Add(new object[] { sName, sDescription });

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private TreeListNode GetTreeNode(TreeListNode trnParent, string sText)
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

        private string GetNodeText(TreeListNode trnNode)
        {
            string sName = trnNode.GetValue(0).ToString();

            return sName;
        }

        private void UpdateGroupNode(CPlcProc cProcess, TreeListNode trnProcess)
        {
            trnProcess.Nodes.Clear();

            CreateRoleTypeTreeNodes(trnProcess);

            CTag cCycleTag;
            CAbnormalSymbol cAbnormalSymbol;
            CTag cRecipeTag;
            TreeListNode trnRoleType = null;

            // Draw Key Symbol
            trnRoleType = GetTreeNode(trnProcess, "Cycle Signal");

            for (int j = 0; j < cProcess.InOutTagS.Count; j++)
            {
                cCycleTag = cProcess.InOutTagS[j];
                TraceCreateSymbolTreeNode(trnRoleType, cCycleTag);
            }

            // Draw Abnormal Symbol
            trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Abnormal.ToString());
            for (int j = 0; j < cProcess.AbnormalSymbolS.Count; j++)
            {
                cAbnormalSymbol = cProcess.AbnormalSymbolS.ElementAt(j).Value;
                TraceCreateAbnormalSymbolTreeNode(trnRoleType, cAbnormalSymbol, cProcess.AbnormalSymbolS.ElementAt(j).Key);
            }

            //Draw Recipe Word
            trnRoleType = GetTreeNode(trnProcess, "Recipe Word");

            if(cProcess.RecipeWordS == null)
                cProcess.RecipeWordS = new CTagS();

            for (int j = 0; j < cProcess.RecipeWordS.Count; j++)
            {
                cRecipeTag = cProcess.RecipeWordS[j];
                CreateTreeNode(trnRoleType, cRecipeTag.Key, cRecipeTag.Description, IMG_INDEX_SYMBOL, cRecipeTag);
            }
        }

        private TreeListNode TraceCreateSymbolTreeNode(TreeListNode trnParent, CKeySymbol cSymbol)
        {
            if (GetTreeNode(trnParent, cSymbol.Tag.Key) != null)
                return null;

            TreeListNode trnSymbol = CreateTreeNode(trnParent, cSymbol.Tag.Key, cSymbol.Tag.Description, IMG_INDEX_SYMBOL, cSymbol);

            if (cSymbol.FirstTagList != null && cSymbol.FirstTagList.Count > 0)
            {
                CTag cSubTag;
                for (int i = 0; i < cSymbol.FirstTagList.Count; i++)
                {
                    cSubTag = cSymbol.FirstTagList[i];
                    TraceCreateSymbolTreeNode(trnSymbol, cSubTag);
                }
            }

            return trnSymbol;
        }

        private void TraceCreateSymbolTreeNode(TreeListNode trnParent, CTag cTag)
        {
            TreeListNode trnSubSymbol = CreateTreeNode(trnParent, cTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cTag);
            trnParent.Nodes.Add(trnSubSymbol);
        }

        private TreeListNode TraceCreateAbnormalSymbolTreeNode(TreeListNode trnParent, CAbnormalSymbol cSymbol, string sAbnormalKey)
        {
            if (GetTreeNode(trnParent, sAbnormalKey) != null)
                return null;

            TreeListNode trnSymbol = CreateTreeNode(trnParent, sAbnormalKey, cSymbol.Tag.Description, IMG_INDEX_SYMBOL, cSymbol);

            //if (cSymbol.FirstSymbolTagList != null && cSymbol.FirstSymbolTagList.Count > 0)
            //{
            //    CSymbolTag cSymbolTag;

            //    for (int i = 0; i < cSymbol.FirstSymbolTagList.Count; i++)
            //    {
            //        cSymbolTag = cSymbol.FirstSymbolTagList[i];
            //        TraceCreateSymbolTreeNode(trnSymbol, cSymbolTag.Tag);
            //    }
            //}

            return trnSymbol;
        }

        private void CreateRoleTypeTreeNodes(TreeListNode trnProcess)
        {
            CreateTreeNode(trnProcess, "Cycle Signal", "", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnProcess, EMGroupRoleType.Abnormal.ToString(), "", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnProcess, "Recipe Word", "", IMG_INDEX_ROLETYPE, null);
        }

        private void ClearRoleTypeTreeNode(TreeListNode trnGroup)
        {
            TreeListNode trnRoleType = null;
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Key.ToString());
            ClearTreeNode(trnRoleType);
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Abnormal.ToString());
            ClearTreeNode(trnRoleType);
        }

        private void ClearTreeNode(TreeListNode trnNode)
        {
            trnNode.Nodes.Clear();
        }

        private void RemoveTreeNode(TreeListNode trnNode)
        {
            TreeListNode trnParent = null;

            if (trnNode.Nodes.Count != 0)
                trnNode.Nodes.Clear();

            if (trnNode.ParentNode != null)
            {
                trnParent = trnNode.ParentNode;
                trnParent.Nodes.Remove(trnNode);
            }
            else
                exTreeList.Nodes.Remove(trnNode);
        }

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        private void ShowKeySymbolS(TreeListNode trnProcess, CKeySymbolS cAddKeySymbolS)
        {
            exTreeList.BeginUpdate();
            {
                CKeySymbol cKeySymbol = null;

                if (cAddKeySymbolS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    // Draw Key Symbol
                    trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Key.ToString());

                    for (int j = 0; j < cAddKeySymbolS.Count; j++)
                    {
                        cKeySymbol = cAddKeySymbolS.ElementAt(j).Value;
                        TraceCreateSymbolTreeNode(trnRoleType, cKeySymbol);
                    }
                }
            }
            exTreeList.EndUpdate();
        }

        private void AddAbnormalSymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            CAbnormalSymbol cAbnormalSymbol = null;

            foreach (CTag cTag in cTagS.Values)
            {
                if (!cPlcProcess.AbnormalSymbolS.ContainsKey(cTag.Key))
                {
                    if (cTag.DataType != EMDataType.Bool) continue;
                    //if (CheckPlcInputDevice(cTag) == false) continue;
                    cAbnormalSymbol = new CAbnormalSymbol(cTag);
                    cPlcProcess.AbnormalSymbolS.Add(cAbnormalSymbol.Tag.Key, cAbnormalSymbol);
                }
            }

        }

        private void ShowAbnormalSymbolS(TreeListNode trnProcess, CPlcProc cProcess)
        {
            exTreeList.BeginUpdate();
            {
                CAbnormalSymbolS cAddAbnormalSymbolS = cProcess.AbnormalSymbolS;
                CAbnormalSymbol cAbnormalSymbol = null;

                if (cAddAbnormalSymbolS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    // Draw Abnormal Symbol
                    trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Abnormal.ToString());

                    for (int j = 0; j < cAddAbnormalSymbolS.Count; j++)
                    {
                        cAbnormalSymbol = cAddAbnormalSymbolS.ElementAt(j).Value;
                        TraceCreateAbnormalSymbolTreeNode(trnRoleType, cAbnormalSymbol, cAddAbnormalSymbolS.ElementAt(j).Key);
                    }
                }
            }
            exTreeList.EndUpdate();
        }

        private void AddRecipeWordSymbolS(TreeListNode trnProcess, CPlcProc cProcess, CTagS cTagS)
        {
            CTag cTag = null;

            if(cProcess.RecipeWordS == null)
                cProcess.RecipeWordS = new CTagS();
            
            for(int i=0; i<cTagS.Count; i++)
            {
                cTag = cTagS[i];

                if (!cProcess.RecipeWordS.ContainsKey(cTag.Key) && (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord))
                    cProcess.RecipeWordS.Add(cTag.Key, cTag);
                if (i == CMultiProject.ProjectInfo.ViewRecipe.WordIndex)
                    cProcess.SelectRecipeWord = cTag;
            }
        }

        private void ShowRecipeWordSymbolS(TreeListNode trnProcess, CTagS cTagS)
        {
            exTreeList.BeginUpdate();
            {
                CTag cTag = null;

                if (cTagS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    trnRoleType = GetTreeNode(trnProcess, "Recipe Word");

                    foreach (var who in cTagS)
                    {
                        cTag = who.Value;

                        if (GetTreeNode(trnRoleType, cTag.Key) != null)
                            continue;

                        CreateTreeNode(trnRoleType, cTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cTag);
                    }
                }
            }
            exTreeList.EndUpdate();
        }

        private void GenerateProcessDoubleClickEvent(CPlcProc cProcess)
        {
            if (UEventProcessDoubleClicked != null)
                UEventProcessDoubleClicked(this, cProcess.Name);
        }

        #endregion


        #region Event Method

        private void exTreeList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<CCommentSplit>)))
                e.Effect = DragDropEffects.Move;
            else if(e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void exTreeList_DragDrop(object sender, DragEventArgs e)
        {
            CPlcProc cPlcProcess = null;

            if (e.Data != null && e.Data.GetDataPresent(typeof(List<CCommentSplit>)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));

                List<CCommentSplit> lstText = (List<CCommentSplit>)e.Data.GetData(typeof(List<CCommentSplit>));

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm();

                if (lstText != null)
                {
                    for (int i = 0; i < lstText.Count; i++)
                    {
                        string sName = lstText[i].Text;

                        if(CMultiProject.PlcProcS.ContainsKey(sName))
                            continue;

                        cPlcProcess = new CPlcProc();
                        cPlcProcess.Name = sName;

                        List<CTag> lstTag = GetProcessKeyTagS(lstText[i].Text, cPlcProcess);

                        CKeySymbol cKeySymbol = null;
                        CPlcLogicData cData = null;

                        foreach (CTag cTag in lstTag)
                        {
                            cKeySymbol = new CKeySymbol(cTag);
                            cPlcProcess.KeySymbolS.Add(cTag.Key, cKeySymbol);

                            cData = CMultiProject.GetPlcLogicData(cTag);

                            if(!cPlcProcess.PlcLogicDataS.ContainsValue(cData))
                                cPlcProcess.PlcLogicDataS.Add(cData.PLCID, cData);

                        }
                        cPlcProcess.UpdateKeySymbolS();
                        CMultiProject.PlcProcS.Add(cPlcProcess.Name, cPlcProcess);
                    }
                    ShowTree();
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
            }
            else if (e.Data != null && e.Data.GetDataPresent(typeof (CTagS)))
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

                    if (sNodeKey == "Cycle Signal")
                        bOK = true;
                    else if (sNodeKey == EMGroupRoleType.Abnormal.ToString())
                        bOK = true;
                    else if (sNodeKey == "Recipe Word")
                    {
                        if (CMultiProject.RecipeWordList == null || CMultiProject.RecipeWordList.Count == 0)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Recipe Setting이 진행되지 않았습니다.", "UDM Tracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bOK = false;
                        }
                        else
                            bOK = true;
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign symbol at this node!!", "UDM Tracker Simple",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (bOK)
                    {
                        TreeListNode trnProcess = trnNode.ParentNode;
                        cPlcProcess = (CPlcProc)trnProcess.Tag;

                        if (sNodeKey == "Cycle Signal")
                        {
                            cPlcProcess.InOutTagS.Add(cTagS.GetFirst());
                            TreeListNode trnRoleType = null;
                            trnRoleType = GetTreeNode(trnProcess, "Cycle Signal");
                            CreateTreeNode(trnRoleType, cTagS.GetFirst().Key, cTagS.GetFirst().Description, IMG_INDEX_SYMBOL, cTagS.GetFirst());
                        }
                        else if (sNodeKey == EMGroupRoleType.Abnormal.ToString())
                        {
                            SplashScreenManager.ShowDefaultWaitForm();
                            {
                                cPlcProcess.AbnormalFilter = CMultiProject.AbnormalFilter;
                                cPlcProcess.AddAbnormalSymbolS(cTagS);
                                cPlcProcess.UpdateAbnormalSymbolS();
                                ShowAbnormalSymbolS(trnProcess, cPlcProcess);
                            }
                            SplashScreenManager.CloseDefaultWaitForm();
                        }
                        else if (sNodeKey == "Recipe Word")
                        {
                            if (cTagS.Count == CMultiProject.RecipeWordList.Count)
                            {
                                AddRecipeWordSymbolS(trnProcess, cPlcProcess, cTagS);
                                ShowRecipeWordSymbolS(trnProcess, cTagS);
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("설정된 RecipeWord수와 다릅니다. " + CMultiProject.RecipeWordList.Count.ToString(), "UDM Tracker Simple",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

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
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void exTreeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                TreeListNode trnNode = ((TreeListNodeMenu)e.Menu).Node;

                exTreeList.FocusedNode = trnNode;

                object oData = trnNode.Tag;

                if (oData != null)
                {
                    Type tpNode = trnNode.Tag.GetType();
                    if (tpNode == typeof(CPlcProc))
                    {
                        exTreeList.ContextMenuStrip = cntxProcessMenu;
                    }
                    else if (tpNode == typeof(CTag) || tpNode == typeof(CAbnormalSymbol))
                    {
                        exTreeList.ContextMenuStrip = cntxSymbolMenu;
                    }
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
                else
                {
                    string sDisplayText = trnNode.GetDisplayText(colProcess);

                    if (sDisplayText.Equals("Recipe Word") || sDisplayText.Equals("Cycle Signal") || sDisplayText.Equals("Abnormal"))
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
            }
        }

        private void mnuDeleteGroup_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                TreeListNode trnProcess = exTreeList.FocusedNode;
                if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CPlcProc))
                    return;

                CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;
                cPlcProcess.Clear();

                if (CMultiProject.PlcProcS.ContainsKey(cPlcProcess.Name))
                    CMultiProject.PlcProcS.Remove(cPlcProcess.Name);

                Clear();
                ShowTree();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void mnuRenameGroup_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CPlcProc))
                return;

            string sName = GetUserInputText("Input Process Name", "Please enter text below...");
            if (sName != "")
            {
                CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;

                if (cPlcProcess.Name == sName)
                    return;

                if (CMultiProject.PlcProcS.ContainsKey(sName))
                {
                    MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CMultiProject.PlcProcS.Remove(cPlcProcess.Name);
                cPlcProcess.Name = sName;
                
                CMultiProject.PlcProcS.Add(cPlcProcess.Name, cPlcProcess);

                trnProcess.SetValue(colProcess, sName);
            }
        }

        private void mnuDeleteSymbol_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                TreeListNode trnSymbol = exTreeList.FocusedNode;
                if (trnSymbol == null || trnSymbol.Tag == null)
                    return;

                if (trnSymbol.Tag.GetType() == typeof(CTag))
                {
                    TreeListNode trnRoleType = trnSymbol.ParentNode;
                    CTag cTag = (CTag)trnSymbol.Tag;

                    TreeListNode trnProcess = trnSymbol.ParentNode.ParentNode;
                    CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;

                    string sDisplayText = trnRoleType.GetDisplayText(colProcess);

                    if (sDisplayText.Equals("Cycle Signal"))
                    {
                        if (cPlcProcess.InOutTagS.ContainsKey(cTag.Key))
                            cPlcProcess.InOutTagS.Remove(cTag.Key);
                    }
                    else if (sDisplayText.Equals("Recipe Word"))
                    {
                        if (cPlcProcess.RecipeWordS.ContainsKey(cTag.Key))
                            cPlcProcess.RecipeWordS.Remove(cTag.Key);
                    }
                }
                else if (trnSymbol.Tag.GetType() == typeof(CAbnormalSymbol))
                {
                    CAbnormalSymbol cAbnormalSymbol = (CAbnormalSymbol)trnSymbol.Tag;

                    TreeListNode trnProcess = trnSymbol.ParentNode.ParentNode;
                    CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;

                    if (cPlcProcess.AbnormalSymbolS.ContainsKey(cAbnormalSymbol.Tag.Key))
                        cPlcProcess.AbnormalSymbolS.Remove(cAbnormalSymbol.Tag.Key);
                }

                Clear();
                ShowTree();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TreeListNode trnNode = exTreeList.FocusedNode;

            //if (trnNode != null)
            //{
            //    if (trnNode.Tag == null)
            //        return;

            //    if (trnNode.Tag.GetType() == typeof(CPlcProc))
            //    {
            //        CPlcProc cProcess = (CPlcProc)trnNode.Tag;
            //        GenerateProcessDoubleClickEvent(cProcess);
            //    }
            //}
        }

        private void mnuClearSymbol_Click(object sender, EventArgs e)
        {
            TreeListNode trnRoleType = exTreeList.FocusedNode;
            TreeListNode trnProcess = trnRoleType.ParentNode;

            string sDisplayText = trnRoleType.GetDisplayText(colProcess);

            CPlcProc cProcess = (CPlcProc)trnProcess.Tag;

            if (sDisplayText.Equals("Cycle Signal"))
                cProcess.InOutTagS.Clear();
            else if (sDisplayText.Equals("Abnormal"))
                cProcess.AbnormalSymbolS.Clear();
            else if (sDisplayText.Equals("Recipe Word"))
            {
                cProcess.RecipeWordS.Clear();
                cProcess.SelectRecipeWord = null;
            }

            Clear();
            ShowTree();
        }

        #endregion
        
    }
}
