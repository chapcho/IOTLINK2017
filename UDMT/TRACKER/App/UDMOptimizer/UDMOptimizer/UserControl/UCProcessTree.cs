using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using UDM.Common;
using TrackerCommon;
using TrackerProject;

namespace UDMOptimizer
{

    public delegate void UEventProcessDoubleClicked(object sender, string sProcessKey);
    public delegate void UEventUnitShowLogClicked(object sender, CUnitInfo cUnit, CPlcProc cPlcProcess);
    public delegate void UEventTotalDeviceShowLogClicked(object sender, CPlcProc cPlcProcess);

    public partial class UCProcessTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected const int IMG_INDEX_PROCESS = 0;
        protected const int IMG_INDEX_ROLETYPE = 1;
        protected const int IMG_INDEX_SYMBOL = 2;
        protected const int IMG_INDEX_PROJECT = 3;
        protected const int IMG_INDEX_ERROR = 4;

        protected const int NODE_LEVEL_PROCESS = 0;
        protected const int NODE_LEVEL_ROLETYPE = 1;
        protected const int NODE_LEVEL_SYMBOL = 2;

        protected bool m_bDragDropReady = false;
        protected bool m_bShowErrorProcess = true;

        private CPlcProc m_cCurProcess = null;
        private bool m_bEditable = true;
        public event UEventProcessDoubleClicked UEventProcessDoubleClicked;
        public event UEventUnitShowLogClicked UEventUnitShowLogClicked;
        public event UEventTotalDeviceShowLogClicked UEventTotalDeviceShowLog;
        #endregion


        #region Initialize

        public UCProcessTree()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }
        public bool ShowErrorProcess
        {
            get { return m_bShowErrorProcess; }
            set { m_bShowErrorProcess = value; }
        }

        #endregion


        #region Public Method

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

                    if (who.Value.IsErrorMonitoring)//if(!m_bShowErrorProcess && who.Value.IsErrorMonitoring)
                        continue;

                    cPlcProcess = who.Value;
                    m_cCurProcess = cPlcProcess;
                    trnProcess = CreateTreeNode(null, who.Key, "", IMG_INDEX_PROCESS, cPlcProcess);
                    //Group Node 추가
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

                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    UpdateGroupNode(cProcess, exTreeList.FindNodeByFieldValue("Name", cProcess.Name));
                }
            }
            exTreeList.EndUpdate();
        }

        #endregion


        #region Private Method

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
            bool bError = false;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { sName, sDescription });
            else
                trnNode = trnParent.Nodes.Add(new object[] { sName, sDescription });

            if (oData != null && oData.GetType() == typeof(CPlcProc))
            {
                if (m_cCurProcess.IsErrorMonitoring)
                    bError = true;
            }

            if (bError)
            {
                trnNode.ImageIndex = IMG_INDEX_ERROR;
                trnNode.SelectImageIndex = IMG_INDEX_ERROR;
            }
            else
            {
                trnNode.ImageIndex = iImageIndex;
                trnNode.SelectImageIndex = iImageIndex;
            }
            trnNode.Tag = oData;

            return trnNode;
        }

        private void CreateRoleTypeTreeNodes(TreeListNode trnProcess)
        {
            if (!m_cCurProcess.IsErrorMonitoring)
            {
                CreateTreeNode(trnProcess, "Total Device", "Total Device", IMG_INDEX_ROLETYPE, null);
                CreateTreeNode(trnProcess, "Recipe Word", "RECIPE TAG", IMG_INDEX_ROLETYPE, null);
                CreateTreeNode(trnProcess, "UNIT LIST", "UNIT", IMG_INDEX_ROLETYPE, null);
            }
            else
            {
                CreateTreeNode(trnProcess, EMGroupRoleType.Abnormal.ToString(), "ERROR TAG", IMG_INDEX_ROLETYPE, null);
            }
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
            //trnProcess.Nodes.Clear();

            //CreateRoleTypeTreeNodes(trnProcess);

            //CTag cRecipeTag;
            //CAbnormalSymbol cAbnormalSymbol;

            //TreeListNode trnRoleType = null;

            //if (!m_cCurProcess.IsErrorMonitoring)
            //{
            //    trnRoleType = GetTreeNode(trnProcess, "Recipe Word");

            //    if (cProcess.RecipeWordS == null)
            //        cProcess.RecipeWordS = new CTagS();

            //    for (int j = 0; j < cProcess.RecipeWordS.Count; j++)
            //    {
            //        cRecipeTag = cProcess.RecipeWordS[j];
            //        CreateTreeNode(trnRoleType, cRecipeTag.Key, cRecipeTag.Description, IMG_INDEX_SYMBOL, cRecipeTag);
            //    }

            //    trnRoleType = GetTreeNode(trnProcess, "Total Device");

            //    if (cProcess == null)
            //        cProcess = new CPlcProc();
            //    foreach (CTag cTag in cProcess.ProcessTagS.Values)
            //    {
            //        CreateTreeNode(trnRoleType, cTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cTag);
            //    }

            //    trnRoleType = GetTreeNode(trnProcess, "UNIT LIST");

            //    if (cProcess.UnitInfoS == null)
            //        cProcess.UnitInfoS = new CUnitInfoS();

            //    foreach (CUnitInfo cUnit in cProcess.UnitInfoS.Values)
            //    {
            //        TraceCreateUnitTreeNode(trnRoleType, cUnit.Name, cUnit);
            //    }
            //}

            //else
            //{
            //    trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Abnormal.ToString());
            //    for (int j = 0; j < cProcess.AbnormalSymbolS.Count; j++)
            //    {
            //        cAbnormalSymbol = cProcess.AbnormalSymbolS.ElementAt(j).Value;
            //        TraceCreateAbnormalSymbolTreeNode(trnRoleType, cAbnormalSymbol, cProcess.AbnormalSymbolS.ElementAt(j).Key);
            //    }
            //}
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

        private TreeListNode TraceCreateUnitTreeNode(TreeListNode trnParent, string sName, CUnitInfo cUnit)
        {
            
            TreeListNode trnSymbol = CreateTreeNode(trnParent, sName, "Tag Count :" + cUnit.TotalTagKeyList.Count.ToString(), IMG_INDEX_ROLETYPE, cUnit);
            trnParent.Nodes.Add(trnSymbol);
            return trnSymbol;
        }

        private void TraceCreateSymbolTreeNode(TreeListNode trnParent, CTag cTag)
        {
            TreeListNode trnSubSymbol = CreateTreeNode(trnParent, cTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cTag);
            trnParent.Nodes.Add(trnSubSymbol);
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
                //if (i == CMultiProject.ProjectInfo.ViewRecipe.WordIndex)
                //    cProcess.SelectRecipeWord = cTag;
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

        private void ShowProcessTotalTagS(TreeListNode trnProcess, CTagS cTagS)
        {
            exTreeList.BeginUpdate();
            {
                CTag cTag = null;

                if (cTagS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    trnRoleType = GetTreeNode(trnProcess, "Total Device");

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

        private void SetProcessTree(List<CCommentSplit> lstText)
        {
            CPlcProc cPlcProcess;

            if (lstText != null)
            {
                for (int i = 0; i < lstText.Count; i++)
                {
                    string sName = lstText[i].Text;

                    if (CMultiProject.PlcProcS.ContainsKey(sName))
                        continue;

                    cPlcProcess = new CPlcProc();
                    cPlcProcess.Name = sName;
                    
                    CMultiProject.PlcProcS.Add(cPlcProcess.Name, cPlcProcess);
                }
                ShowTree();
            }
        }

        private void SetRecipeWordS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            if (cTagS == null || cTagS.Count == 0) return;

            AddRecipeWordSymbolS(trnProcess, cPlcProcess, cTagS);
            ShowRecipeWordSymbolS(trnProcess, cTagS);
        }

        #endregion


        #region Event Method

        #region Tree

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
            if (e.Data != null && e.Data.GetDataPresent(typeof(List<CCommentSplit>)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));

                List<CCommentSplit> lstText = (List<CCommentSplit>)e.Data.GetData(typeof(List<CCommentSplit>));

                CShowWaitForm.ShowForm("Update", string.Format("Update Tree"), "Start...", true);
                {
                    SetProcessTree(lstText);
                }
                CShowWaitForm.CloseForm();
            }
            else if (e.Data != null && e.Data.GetDataPresent(typeof (CTagS)))
            {
                //e.Effect = DragDropEffects.Move;

                //Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                //TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(pntClient);
                //if (exHitInfo != null && exHitInfo.Node != null)
                //{
                //    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                //    if (cTagS == null || cTagS.Count == 0)
                //        return;

                //    TreeListNode trnNode = exHitInfo.Node;
                //    string sNodeKey = GetNodeText(trnNode);
                    
                //    TreeListNode trnProcess = trnNode.ParentNode;
                //    CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;
                
                //    if (sNodeKey == "Recipe Word")
                //        SetRecipeWordS(trnProcess, cPlcProcess, cTagS);
                //    else if (sNodeKey == "Total Device")
                //    {
                //        foreach (var who in cTagS)
                //        {
                //            if (cPlcProcess.ProcessTagS.ContainsKey(who.Key) == false)
                //            {
                //                cPlcProcess.ProcessTagS.Add(who.Value);
                //                cPlcProcess.ProcessTotalTagKey.Add(who.Key);
                //            }
                //        }
                //        ShowProcessTotalTagS(trnProcess, cTagS);
                //    }
                //    else if (sNodeKey.Equals(EMGroupRoleType.Abnormal.ToString()))
                //    {
                //        SetAbnormalSymbolS(trnProcess, cPlcProcess, cTagS);
                //    }
                //    else
                //        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign symbol at this node!!", "UDM Tracker Simple",
                //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }


        private void SetAbnormalSymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            //bool bNormalSymbol = false;

            //if (cTagS.Count > 1)
            //{
            //    XtraMessageBox.Show("Abnormal Symbol은 이상 접점 중 가장 최상위 이상 접점 한 개만 등록해주세요!!", "Abnormal Symbol Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else if (cTagS.Count == 1)
            //{
            //    DialogResult dlgResult = XtraMessageBox.Show("추가하고자 하시는 Abnormal Symbol은 값이 1 즉, On일 때 이상입니까?", "Abnormal Symbol Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (dlgResult == DialogResult.Yes)
            //        bNormalSymbol = false;
            //    else
            //        bNormalSymbol = true;
            //}

            //cPlcProcess.AbnormalFilter = CMultiProject.GetAbnormalFilter();

            //SplashScreenManager.ShowDefaultWaitForm();
            //{
            //    cPlcProcess.AbnormalSymbolS.Clear();
            //    cPlcProcess.TotalAbnormalSymbolKey = string.Empty;
            //    //cPlcProcess.UsedAbnormalSymbolKeyList.Clear();

            //    cPlcProcess.IsNormalAbnormalSymbol = bNormalSymbol;
            //    cPlcProcess.AddAbnormalSymbolS(cTagS);
            //    cPlcProcess.UpdateAbnormalSymbolS();
            //    //cPlcProcess.UsedAbnormalSymbolKeyList.AddRange(cPlcProcess.AbnormalSymbolS.GetTagS().Keys.ToList());

            //    ShowAbnormalSymbolS(trnProcess, cPlcProcess);
            //}
            //SplashScreenManager.CloseDefaultWaitForm();
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

        private void exTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_bEditable == false) return;
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
            if (m_bEditable == false) return;
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
                if (trnNode.GetValue(0).ToString() == "UNIT LIST")
                {
                    if (m_bEditable == false)
                    {
                        mnuClearSymbol.Visible = false;
                        mnuSymbolShowLog.Visible = true;
                        exTreeList.ContextMenuStrip = cntxSymbolMenu;
                    }
                }
                else if (trnNode.GetValue(0).ToString() == "Total Device")
                {
                    if (m_bEditable)
                        exTreeList.ContextMenuStrip = cntxUnitMenu;
                }
                else if (oData != null)
                {
                    Type tpNode = trnNode.Tag.GetType();
                    if (tpNode == typeof(CPlcProc))
                    {
                        if (m_bEditable)
                            exTreeList.ContextMenuStrip = cntxProcessMenu;
                    }
                    else if (tpNode == typeof(CUnitInfo))
                    {
                        if (m_bEditable)
                        {
                            mnuRemoveUnit.Visible = true;
                            mnuShowLog.Visible = false;
                        }
                        else
                        {
                            mnuRemoveUnit.Visible = false;
                            mnuShowLog.Visible = true;
                        }
                        exTreeList.ContextMenuStrip = cntxUnitSubMenu;
                    }
                    else if (tpNode == typeof(CTag))
                    {
                        if (m_bEditable)
                        {
                            mnuClearSymbol.Visible = true;
                            mnuSymbolShowLog.Visible = false;
                            exTreeList.ContextMenuStrip = cntxSymbolMenu;
                        }
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

                    if (sDisplayText.Equals("Recipe Word"))
                        exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
            }
        }

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_bEditable == false) return;
            TreeListNode trnNode = exTreeList.FocusedNode;

            if (trnNode != null)
            {
                if (trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CUnitInfo))
                {
                    CUnitInfo cUnit = (CUnitInfo)trnNode.Tag;

                    FrmProcessUnitSetting frmUnitSetting = new FrmProcessUnitSetting();
                    frmUnitSetting.Unit = cUnit;
                    SetProcessFilterName(cUnit);
                    frmUnitSetting.FilterTagS.AddRange(CMultiProject.TotalTagS.Values.Where(b => b.Description.Contains(cUnit.FilterName)).ToList());
                    frmUnitSetting.ShowDialog();
                }
                if (trnNode.Nodes.Count != 0)
                {

                    if (trnNode.Expanded)
                        trnNode.Expanded = false;
                    else
                        trnNode.Expanded = true;
                }
            }
        }

        #endregion

        private void mnuDeleteGroup_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CPlcProc))
                return;

            CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;

            if (
                XtraMessageBox.Show("해당 \'" + cPlcProcess.Name + "\' 공정을 삭제하시겠습니까?", "Delete Process",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            cPlcProcess.Clear();

            if (CMultiProject.PlcProcS.ContainsKey(cPlcProcess.Name))
                CMultiProject.PlcProcS.Remove(cPlcProcess.Name);

            cPlcProcess = null;

            SplashScreenManager.ShowDefaultWaitForm();
            {
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
            TreeListNode trnSymbol = exTreeList.FocusedNode;
            if (trnSymbol == null || trnSymbol.Tag == null)
                return;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                Clear();
                ShowTree();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void mnuClearSymbol_Click(object sender, EventArgs e)
        {
            /*TreeListNode trnRoleType = exTreeList.FocusedNode;
            TreeListNode trnProcess = trnRoleType.ParentNode;

            string sDisplayText = trnRoleType.GetDisplayText(colProcess);

            CPlcProc cProcess = (CPlcProc)trnProcess.Tag;

            if (
                XtraMessageBox.Show("해당 \'" + cProcess.Name + "\'공정의 " + sDisplayText + "를 Clear하시겠습니까?", "Clear",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (sDisplayText.Equals("Key"))
                cProcess.KeySymbolS.Clear();
            else if (sDisplayText.Equals("Abnormal"))
            {
                cProcess.AbnormalSymbolS.Clear();
                cProcess.TotalAbnormalSymbolKey = string.Empty;
                cProcess.IsNormalAbnormalSymbol = false;
                cProcess.UsedAbnormalSymbolKeyList.Clear();
            }
            else if (sDisplayText.Equals("Recipe Word"))
            {
                cProcess.RecipeWordS.Clear();
                cProcess.SelectRecipeWord = null;
            }
            else if (sDisplayText.Equals("SubKey"))
            {
                cProcess.SubKeySymbolS.Clear();

                foreach (var who in cProcess.KeySymbolS)
                {
                    if (who.Value.SubKeySymbolS != null)
                        who.Value.SubKeySymbolS.Clear();
                }
            }
            else if (sDisplayText.Equals("Cycle"))
                cProcess.CycleCheckTag = null;

            Clear();
            ShowTree();*/
        }

        private void mnuErrorMonitoringAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuProperty_Click(object sender, EventArgs e)
        {
            TreeListNode trnProcess = exTreeList.FocusedNode;
            if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CPlcProc))
                return;

            CPlcProc cPlcProcess = (CPlcProc)trnProcess.Tag;

            FrmProcessProperty frmProperty = new FrmProcessProperty();
            frmProperty.Process = cPlcProcess;
            frmProperty.TopMost = true;

            frmProperty.Show();
        }

        #endregion

        private void SetProcessFilterName(CUnitInfo cUnit)
        {
            string sFilterName = cUnit.FilterName;
            if (sFilterName == "")
            {
                FrmInputDialog frmInput = new FrmInputDialog("Filter Text", "공정에서 사용한 대상접점을 1차 골라 냅니다.\r\n공정명의 일부를 기입하면 Comment에 입력한 내용이 포함된 Tag만 불러 들입니다.");
                frmInput.ShowDialog();

                sFilterName = frmInput.InputText;
            }
            else
            {
                DialogResult dlgResult = MessageBox.Show("Filter Text", "설정한 Filter Name : " + cUnit.FilterName + "\r\n이대로 사용하겠습니까?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    FrmInputDialog frmInput = new FrmInputDialog("Filter Text", "공정에서 사용한 대상접점을 1차 골라 냅니다.\r\n공정명의 일부를 기입하면 Comment에 입력한 내용이 포함된 Tag만 불러 들입니다.");
                    frmInput.ShowDialog();

                    sFilterName = frmInput.InputText;
                }
            }
            cUnit.FilterName = sFilterName;
        }

        private void mnuAddunit_Click(object sender, EventArgs e)
        {
            //TreeListNode trnProcess = exTreeList.FocusedNode;
            //if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof(CPlcProc))
            //    return;
            //CPlcProc cProc = (CPlcProc)trnProcess.Tag;
            //CUnitInfo cFirstUnit = cProc.UnitInfoS.First().Value;
            //FrmInputDialog frmInput = null;
            //string sFilterName = "";
            //if (cFirstUnit == null)
            //{
            //    frmInput = new FrmInputDialog("Filter Text", "공정에서 사용한 대상접점을 1차 골라 냅니다.\r\n공정명의 일부를 기입하면 Comment에 입력한 내용이 포함된 Tag만 불러 들입니다.");
            //    frmInput.ShowDialog();

            //    sFilterName = frmInput.InputText;
            //}
            //else
            //{
            //    SetProcessFilterName(cFirstUnit);
            //    sFilterName = cFirstUnit.FilterName;
            //}
            
            //FrmProcessUnitSetting frmUnitSetting = new FrmProcessUnitSetting();
            //frmUnitSetting.FilterTagS.AddRange(CMultiProject.TotalTagS.Values.Where(b => b.Description.Contains(sFilterName)).ToList());
            //frmUnitSetting.ShowDialog();
            
            //if (frmUnitSetting.IsCancel == false)
            //{
            //    //유닛 추가
            //    CUnitInfo cUnit = frmUnitSetting.Unit;
            //    TreeListNode trnRoleType = null;
            //    if (cUnit != null)
            //    {
            //        trnRoleType = GetTreeNode(trnProcess, "UNIT LIST");
            //        if (trnRoleType != null)
            //        {
            //            if (GetTreeNode(trnRoleType, cUnit.Name) != null)
            //            {
            //                MessageBox.Show("동일한 이름이 있습니다. 재설정해야합니다");
            //                frmInput = new FrmInputDialog("Unit Name", "Please Input UnitName");
            //                frmInput.InputText = cUnit.Name;
            //                frmInput.ShowDialog();

            //                if (frmInput.InputText == cUnit.Name && frmInput.InputText == "")
            //                {
            //                    MessageBox.Show("동일한 이름이 있습니다. Unit 설정에 실패했습니다.");
            //                    return;
            //                }
            //                cUnit.Name = frmInput.InputText;
            //                if (GetTreeNode(trnRoleType, cUnit.Name) != null)
            //                {
            //                    MessageBox.Show("동일한 이름이 있습니다. Unit 설정에 실패했습니다.");
            //                    return;
            //                }
            //            }
            //            cUnit.FilterName = sFilterName;
            //            TraceCreateUnitTreeNode(trnRoleType, cUnit.Name, cUnit);
            //            if (cProc.UnitInfoS == null)
            //                cProc.UnitInfoS = new CUnitInfoS();

            //            cProc.UnitInfoS.Add(cUnit.Name, cUnit);
            //        }
            //    }
            //}

        }

        private void mnuUnitDelete_Click(object sender, EventArgs e)
        {
            TreeListNode trnSymbol = exTreeList.FocusedNode;
            if (trnSymbol == null || trnSymbol.Tag == null)
                return;

            if (trnSymbol.Tag.GetType() == typeof(CUnitInfo))
            {
                CUnitInfo cUnit = (CUnitInfo)trnSymbol.Tag;
            }

        }

        private void mnuUnitClear_Click(object sender, EventArgs e)
        {
            //유닛 Clear

        }

        private void exTreeList_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(exTreeList.FocusedNode.ToString());
        }

        private void mnuShowLog_Click(object sender, EventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;

            if (trnNode != null)
            {
                if (trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CUnitInfo))
                {
                    CPlcProc cProc = (CPlcProc)trnNode.ParentNode.ParentNode.Tag;
                    
                    CUnitInfo cUnit = (CUnitInfo)trnNode.Tag;

                    if (UEventUnitShowLogClicked != null)
                        UEventUnitShowLogClicked(sender, cUnit, cProc);
                }
            }
        }

        private void mnuSymbolShowLog_Click(object sender, EventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null)
            {
                TreeListNode trnProcess = trnNode.ParentNode;
                if (trnProcess != null)
                {
                    string sProcess = trnProcess.GetValue(0).ToString();
                    if (CMultiProject.PlcProcS.ContainsKey(sProcess))
                    {
                        if (UEventTotalDeviceShowLog != null)
                            UEventTotalDeviceShowLog(sender, CMultiProject.PlcProcS[sProcess]);
                    }
                }
            }
        }
    }
}
