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
using UDM.Flow;

namespace UDMTrackerSimple
{

    public delegate void UEventHandlerProcessDoubleClicked(object sender, string sProcessKey);
    public delegate void UEventHandlerCandidateKeyDoubleClicked(string sProcess, bool bExpand);

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
        private List<string> m_lstAbnormalFilter = null;
        //private List<CTag> m_lstAbnormalTag = new List<CTag>();

        private CPlcProc m_cCurProcess = null;
        private bool m_bProcessEdit = false;

        public event UEventHandlerProcessDoubleClicked UEventProcessDoubleClicked;
        public event UEventHandlerCandidateKeyDoubleClicked UEventCandidateKeyDoubleClicked;

        #endregion


        #region Initialize

        public UCProcessTree()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool IsProcessEdit
        {
            get { return m_bProcessEdit; }
            set { m_bProcessEdit = value; }
        }

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
                    m_cCurProcess = cPlcProcess;
                    trnProcess = CreateTreeNode(null, who.Key, "", IMG_INDEX_PROCESS, cPlcProcess);
                    UpdateGroupNode(cPlcProcess, trnProcess);

                    trnProcess.Expanded = true;
                }
            }
            exTreeList.EndUpdate();
        }

        public void UpdateTree()
        {
            //exTreeList.BeginUpdate();
            //{
            //    string sDescription = string.Empty;
            //    CAbnormalSymbol cAbnormalSymbol = null;

            //    foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            //    {
            //        cProcess.AbnormalSymbolS.Clear();

            //        foreach (CTag cTag in cProcess.InOutTagS.Values)
            //        {
            //            sDescription = cTag.Description;

            //            foreach (string sAbnormal in m_lstAbnormalFilter)
            //            {
            //                if (sDescription.Contains(sAbnormal))
            //                {
            //                    cAbnormalSymbol = new CAbnormalSymbol(cTag);
            //                    cProcess.AbnormalSymbolS.Add(cAbnormalSymbol.Tag.Key, cAbnormalSymbol);
            //                    break;
            //                }
            //            }
            //        }
            //        UpdateGroupNode(cProcess, exTreeList.FindNodeByFieldValue("Name", cProcess.Name));
            //    }
            //}
            //exTreeList.EndUpdate();
        }

        #endregion


        
        #region Private Method

        private List<CTag> GetProcessKeyTagS(string sText)
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
            if (cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.Address.Contains("Y"))
                return true;

            //Seimens
            if (cTag.PLCMaker.Equals(EMPLCMaker.Siemens) && cTag.Address.Contains("Q"))
                return true;

            //LS
            if (cTag.PLCMaker.Equals(EMPLCMaker.LS))
            {
                if (cTag.Address.StartsWith("%"))
                {
                    string sAddress = cTag.Address.Remove(0, 1);
                    if (sAddress.StartsWith("Q"))
                        return true;
                }
                else if((cTag.Address.Contains("K") || cTag.Address.Contains("P")))
                    return true;
            }

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell))
                return true;

            return false;
        }

        private bool CheckPlcInputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.Address.Contains("X"))
                return true;

            //Seimens
            if (cTag.PLCMaker.Equals(EMPLCMaker.Siemens) && cTag.Address.Contains("I"))
                return true;

            //LS
            if (cTag.PLCMaker.Equals(EMPLCMaker.LS))
            {
                if (cTag.Address.StartsWith("%"))
                {
                    string sAddress = cTag.Address.Remove(0, 1);
                    if (sAddress.StartsWith("I"))
                        return true;
                }
                else
                    return true;
            }

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell))
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
            bool bError = false;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { sName, sDescription, 0 });
            else
                trnNode = trnParent.Nodes.Add(new object[] { sName, sDescription, 0 });

            if (oData != null && oData.GetType() == typeof (CPlcProc))
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

            CKeySymbol cKeySymbol;
            CCollectTag cCollectTag = null;
            //CSubKeySymbol cSubKeySymbol;
            CAbnormalSymbol cAbnormalSymbol;
            CTag cRecipeTag;
            TreeListNode trnRoleType = null;

            if (!m_cCurProcess.IsErrorMonitoring)
            {
                trnRoleType = GetTreeNode(trnProcess, "CANDIDATE KEY");

                if(m_cCurProcess.CollectCandidateTagS != null)
                {
                    for (int j = 0; j < m_cCurProcess.CollectCandidateTagS.Count; j++)
                    {
                        cCollectTag = m_cCurProcess.CollectCandidateTagS.ElementAt(j).Value;
                        TraceCreateCollectTagTreeNode(trnRoleType, cCollectTag);
                    }
                }

                // Draw Key Symbol
                trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Key.ToString().ToUpper());
                for (int j = 0; j < cProcess.KeySymbolS.Count; j++)
                {
                    cKeySymbol = cProcess.KeySymbolS.ElementAt(j).Value;
                    TraceCreateSymbolTreeNode(trnRoleType, cKeySymbol);
                }

                //if (cProcess.SubKeySymbolS == null)
                //    cProcess.SubKeySymbolS = new CSubKeySymbolS();

                //// Draw Sub Key Symbol
                //trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.SubKey.ToString());
                //for (int j = 0; j < cProcess.SubKeySymbolS.Count; j++)
                //{
                //    cSubKeySymbol = cProcess.SubKeySymbolS.ElementAt(j).Value;
                //    TraceCreateSymbolTreeNode(trnRoleType, cSubKeySymbol);
                //}

                //Draw Recipe Word
                trnRoleType = GetTreeNode(trnProcess, "RECIPE WORD");

                if (cProcess.RecipeWordS == null)
                    cProcess.RecipeWordS = new CTagS();

                TreeListNode trnRecipe = null;
                for (int j = 0; j < cProcess.RecipeWordS.Count; j++)
                {
                    cRecipeTag = cProcess.RecipeWordS[j];
                    trnRecipe = CreateTreeNode(trnRoleType, cRecipeTag.Key, cRecipeTag.Description, IMG_INDEX_SYMBOL, cRecipeTag);

                    if (cProcess.CycleStartConditionS != null && cProcess.CycleStartConditionS.ContainsKey(cRecipeTag.Key))
                        trnRecipe.SetValue(colRecipe, 2);
                    else if (cProcess.SelectRecipeWord != null && cProcess.SelectRecipeWord.Key == cRecipeTag.Key)
                        trnRecipe.SetValue(colRecipe, 1);
                }

                trnRecipe = null;
            }

            // Draw Abnormal Symbol
            trnRoleType = GetTreeNode(trnProcess, "ERROR");
            for (int j = 0; j < cProcess.AbnormalSymbolS.Count; j++)
            {
                cAbnormalSymbol = cProcess.AbnormalSymbolS.ElementAt(j).Value;
                TraceCreateAbnormalSymbolTreeNode(trnRoleType, cAbnormalSymbol, cProcess.AbnormalSymbolS.ElementAt(j).Key);
            }

            //Draw ERROR RST END
            trnRoleType = GetTreeNode(trnProcess, "ERROR RST");

            if (cProcess.CycleCheckTag != null)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(cProcess.CycleCheckTag.Key))
                    return;

                CreateTreeNode(trnRoleType, cProcess.CycleCheckTag.Key, cProcess.CycleCheckTag.Description,
                    IMG_INDEX_SYMBOL, cProcess.CycleCheckTag);
            }
        }

        private TreeListNode TraceCreateSymbolTreeNode(TreeListNode trnParent, CSubKeySymbol cSymbol)
        {
            if (GetTreeNode(trnParent, cSymbol.Tag.Key) != null)
                return null;

            TreeListNode trnSymbol = CreateTreeNode(trnParent, cSymbol.Tag.Key, cSymbol.Tag.Description, IMG_INDEX_SYMBOL, cSymbol);

            return trnSymbol;
        }

        private TreeListNode TraceCreateCollectTagTreeNode(TreeListNode trnParent, CCollectTag cCollectTag)
        {
            if (GetTreeNode(trnParent, cCollectTag.Key) != null)
                return null;

            CTag cTag = CMultiProject.TotalTagS[cCollectTag.Key];
            TreeListNode trnSymbol = CreateTreeNode(trnParent, cCollectTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cCollectTag);

            return trnSymbol;
        }


        private TreeListNode TraceCreateSymbolTreeNode(TreeListNode trnParent, CKeySymbol cSymbol)
        {
            if (GetTreeNode(trnParent, cSymbol.Tag.Key) != null)
                return null;

            TreeListNode trnSymbol = CreateTreeNode(trnParent, cSymbol.Tag.Key, cSymbol.Tag.Description, IMG_INDEX_SYMBOL, cSymbol);

            if (cSymbol.SubKeySymbolS != null && cSymbol.SubKeySymbolS.Count > 0)
            {
                CSubKeySymbol cSubSymbol;
                for (int i = 0; i < cSymbol.SubKeySymbolS.Count; i++)
                {
                    cSubSymbol = cSymbol.SubKeySymbolS.ElementAt(i).Value;
                    TraceCreateSymbolTreeNode(trnSymbol, cSubSymbol);
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
            if (!m_cCurProcess.IsErrorMonitoring)
            {
                CreateTreeNode(trnProcess, "CANDIDATE KEY", "COLLECT TAG", IMG_INDEX_ROLETYPE, null);
                CreateTreeNode(trnProcess, EMGroupRoleType.Key.ToString().ToUpper(), "OUTPUT TAG", IMG_INDEX_ROLETYPE, null);
                //CreateTreeNode(trnProcess, EMGroupRoleType.SubKey.ToString(), "INPUT TAG", IMG_INDEX_ROLETYPE, null);
                CreateTreeNode(trnProcess, "RECIPE WORD", "RECIPE TAG", IMG_INDEX_ROLETYPE, null);
            }

            CreateTreeNode(trnProcess, "ERROR", "ERROR TAG", IMG_INDEX_ROLETYPE, null);
            CreateTreeNode(trnProcess, "ERROR RST", "ERROR RST TAG", IMG_INDEX_ROLETYPE, null);
        }

        private void ClearRoleTypeTreeNode(TreeListNode trnGroup)
        {
            TreeListNode trnRoleType = null;
            trnRoleType = GetTreeNode(trnGroup, EMGroupRoleType.Key.ToString().ToUpper());
            ClearTreeNode(trnRoleType);
            trnRoleType = GetTreeNode(trnGroup, "ERROR");
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

        private void AddKeySymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            CKeySymbol cKeySymbol = null;
            bool bOutput = true;

            foreach (CTag cTag in cTagS.Values)
            {
                //if (!CheckPlcOutputDevice(cTag))
                //{
                //    bOutput = false;
                //    continue;
                //}

                if (!cPlcProcess.KeySymbolS.ContainsKey(cTag.Key))
                {
                    cKeySymbol = new CKeySymbol(cTag);
                    cPlcProcess.KeySymbolS.Add(cKeySymbol.Tag.Key, cKeySymbol);
                }

                if(cPlcProcess.ChartViewTagS == null)
                    cPlcProcess.ChartViewTagS = new CTagS();

                if (!cPlcProcess.ChartViewTagS.ContainsKey(cTag.Key))
                    cPlcProcess.ChartViewTagS.Add(cTag.Key, cTag);

                //if(cPlcProcess.KeySymbolList == null)
                //    cPlcProcess.KeySymbolList = new List<string>();

                //if (!cPlcProcess.KeySymbolList.Contains(cTag.Key))
                //    cPlcProcess.KeySymbolList.Add(cTag.Key);
            }

            //if (!bOutput)
            //    XtraMessageBox.Show("Key Symbol은 Output 태그만 추가하실 수 있습니다.\r\nMelsec : Y, Siemens : Q, LS : K,P, %Q",
            //        "Key Symbol Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddSubKeySymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            CSubKeySymbol cSubSymbol = null;
            bool bInput = true;

            foreach (CTag cTag in cTagS.Values)
            {
                if (!CheckPlcInputDevice(cTag))
                {
                    bInput = false;
                    continue;
                }

                //if (!cPlcProcess.SubKeySymbolS.ContainsKey(cTag.Key))
                //{
                //    cSubSymbol = new CSubKeySymbol(cTag);
                //    cPlcProcess.SubKeySymbolS.Add(cSubSymbol.Tag.Key, cSubSymbol);
                //}
            }

            if (!bInput)
                XtraMessageBox.Show("Sub Key Symbol은 Input 태그만 추가하실 수 있습니다.\r\nMelsec : X, Siemens : I, LS : P, %IX",
                    "Sub Key Symbol Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.Key.ToString().ToUpper());

                    for (int j = 0; j < cAddKeySymbolS.Count; j++)
                    {
                        cKeySymbol = cAddKeySymbolS.ElementAt(j).Value;
                        TraceCreateSymbolTreeNode(trnRoleType, cKeySymbol);
                    }
                }
            }
            exTreeList.EndUpdate();
        }

        private void ShowCollectCandidateTagS(TreeListNode trnProcess, CCollectTagS cCollectTagS)
        {
            exTreeList.BeginUpdate();
            {
                CCollectTag cCollectTag = null;

                if (cCollectTagS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    // Draw Key Symbol
                    trnRoleType = GetTreeNode(trnProcess, "CANDIDATE KEY");

                    for (int j = 0; j < cCollectTagS.Count; j++)
                    {
                        cCollectTag = cCollectTagS.ElementAt(j).Value;
                        TraceCreateCollectTagTreeNode(trnRoleType, cCollectTag);
                    }
                }
            }
            exTreeList.EndUpdate();
        }

        private void ShowSubKeySymbolS(TreeListNode trnProcess, CSubKeySymbolS cSymbolS)
        {
            exTreeList.BeginUpdate();
            {
                CSubKeySymbol cSymbol = null;

                if (cSymbolS.Count != 0)
                {
                    TreeListNode trnRoleType = null;

                    // Draw Key Symbol
                    trnRoleType = GetTreeNode(trnProcess, EMGroupRoleType.SubKey.ToString());

                    for (int j = 0; j < cSymbolS.Count; j++)
                    {
                        cSymbol = cSymbolS.ElementAt(j).Value;
                        TraceCreateSymbolTreeNode(trnRoleType, cSymbol);
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
                    trnRoleType = GetTreeNode(trnProcess, "ERROR");

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

            //if (cTagS.Values.Where(x => x.DataType != EMDataType.Word && x.DataType != EMDataType.DWord).Count() > 0)
            //    XtraMessageBox.Show("Recipe Word는 Word/DWord 형식의 태그만 추가될 수 있습니다", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);

            for(int i=0; i<cTagS.Count; i++)
            {
                cTag = cTagS[i];

                if (!cProcess.RecipeWordS.ContainsKey(cTag.Key))//&& (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord))
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

                    trnRoleType = GetTreeNode(trnProcess, "RECIPE WORD");

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

        private void ShowCycleEndTag(TreeListNode trnProcess, CTag cTag)
        {
            exTreeList.BeginUpdate();
            {
                TreeListNode trnRoleType = GetTreeNode(trnProcess, "ERROR RST");
                if(GetTreeNode(trnRoleType, cTag.Key) == null)
                    CreateTreeNode(trnRoleType, cTag.Key, cTag.Description, IMG_INDEX_SYMBOL, cTag);
            }
            exTreeList.EndUpdate();
        }

        private void GenerateProcessDoubleClickEvent(CPlcProc cProcess)
        {
            if (UEventProcessDoubleClicked != null)
                UEventProcessDoubleClicked(this, cProcess.Name);
        }

        private void SetProcessTree(List<CCommentSplit> lstText, bool bAutoAdd)
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

                    if (bAutoAdd)
                    {
                        List<CTag> lstTag = GetProcessKeyTagS(lstText[i].Text);

                        CPlcLogicData cData = null;
                        CKeySymbol cKeySymbol = null;
                        foreach (CTag cTag in lstTag)
                        {
                            cData = CMultiProject.GetPlcLogicData(cTag);

                            if (cData.Maker == EMPLCMaker.Rockwell)
                                break;

                            if (!cPlcProcess.PlcLogicDataS.ContainsValue(cData))
                                cPlcProcess.PlcLogicDataS.Add(cData.PLCID, cData);

                            cKeySymbol = new CKeySymbol(cTag);
                            cPlcProcess.KeySymbolS.Add(cKeySymbol.Tag.Key, cKeySymbol);
                        }

                        if (cPlcProcess.ChartViewTagS == null)
                            cPlcProcess.ChartViewTagS = new CTagS();

                        cPlcProcess.ChartViewTagS.AddRange(lstTag);
                    }
                    cPlcProcess.UpdateKeySymbolS();
                    CMultiProject.PlcProcS.Add(cPlcProcess.Name, cPlcProcess);
                    CMultiProject.LineInfoS.Add(cPlcProcess.Name, new CLineInfo(cPlcProcess.Name));
                }
                ShowTree();
            }
        }

        private void SetKeySymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            
            SplashScreenManager.ShowDefaultWaitForm();
            {
                AddKeySymbolS(trnProcess, cPlcProcess, cTagS);

                CPlcLogicData cData = null;
                foreach (CTag cTag in cTagS.Values)
                {
                    cData = CMultiProject.GetPlcLogicData(cTag);

                    if (!cPlcProcess.PlcLogicDataS.ContainsValue(cData))
                        cPlcProcess.PlcLogicDataS.Add(cData.PLCID, cData);
                }

                cPlcProcess.UpdateKeySymbolS();
                ShowKeySymbolS(trnProcess, cPlcProcess.KeySymbolS);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void SetCandidateSymbolS(TreeListNode trnProcess, CPlcProc cProcess, CTagS cTagS)
        {
            if(cProcess.CollectCandidateTagS == null)
                cProcess.CollectCandidateTagS = new CCollectTagS();

            SplashScreenManager.ShowDefaultWaitForm();
            {
                CPlcLogicData cData = null;
                foreach (CTag cTag in cTagS.Values)
                {
                    cData = CMultiProject.GetPlcLogicData(cTag);

                    if(!cProcess.PlcLogicDataS.ContainsValue(cData))
                        cProcess.PlcLogicDataS.Add(cData.PLCID, cData);

                    cProcess.AddCollectTagS(cTag);
                }

                ShowCollectCandidateTagS(trnProcess, cProcess.CollectCandidateTagS);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void SetAbnormalSymbolS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            bool bNormalSymbol = false;

            if(cTagS.Count > 1)
            {
                XtraMessageBox.Show("Abnormal Symbol은 이상 접점 중 가장 최상위 이상 접점 한 개만 등록해주세요!!", "Abnormal Symbol Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(cTagS.Count == 1)
            {
                DialogResult dlgResult = XtraMessageBox.Show("추가하고자 하시는 Abnormal Symbol은 값이 1 즉, On일 때 이상입니까?", "Abnormal Symbol Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.Yes)
                    bNormalSymbol = false;
                else
                    bNormalSymbol = true;
            }

            SplashScreenManager.ShowDefaultWaitForm();
            {
                cPlcProcess.AbnormalSymbolS.Clear();
                cPlcProcess.TotalAbnormalSymbolKey = string.Empty;

                cPlcProcess.IsNormalAbnormalSymbol = bNormalSymbol;
                cPlcProcess.AbnormalFilter = CMultiProject.AbnormalFilter;
                cPlcProcess.AddAbnormalSymbolS(cTagS);
                cPlcProcess.UpdateAbnormalSymbolS();
                CMultiProject.UpdatePlcProcHierarchyAbnormalSymbolS();

                ShowAbnormalSymbolS(trnProcess, cPlcProcess);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void SetRecipeWordS(TreeListNode trnProcess, CPlcProc cPlcProcess, CTagS cTagS)
        {
            //if (cTagS.Count == CMultiProject.RecipeWordList.Count)
            //{
                AddRecipeWordSymbolS(trnProcess, cPlcProcess, cTagS);
                ShowRecipeWordSymbolS(trnProcess, cTagS);
            //}
            //else
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("설정된 RecipeWord수와 다릅니다. " + CMultiProject.RecipeWordList.Count.ToString(), "UDM Tracker Simple",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void SetCycle(TreeListNode trnProcess, CPlcProc cProcess, CTagS cTagS)
        {
            if (cTagS.Count != 1)
            {
                XtraMessageBox.Show("CYCLE END 태그는 한 개만 설정 가능합니다.", "Set Cycle", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                cProcess.CycleCheckTag = cTagS.First().Value;
                ShowCycleEndTag(trnProcess, cTagS.First().Value);
            }
        }

        #endregion


        #region Event Method

        private void exTreeList_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof (List<CCommentSplit>)))
                    e.Effect = DragDropEffects.Move;
                else if (e.Data.GetDataPresent(typeof (CTagS)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                CPlcProc cPlcProcess = null;

                if (e.Data != null && e.Data.GetDataPresent(typeof (List<CCommentSplit>)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));

                    List<CCommentSplit> lstText = (List<CCommentSplit>) e.Data.GetData(typeof (List<CCommentSplit>));
                    bool bAutoAdd = false;

                    if (
                        XtraMessageBox.Show("끌어다놓으신 텍스트를 포함하는 출력 접점을 자동으로 추가하시겠습니까?", "출력접점 자동 추가",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        bAutoAdd = true;

                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm();
                    {
                        SetProcessTree(lstText, bAutoAdd);
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
                        CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        TreeListNode trnNode = exHitInfo.Node;
                        string sNodeKey = GetNodeText(trnNode);
                        bool bOK = false;

                        if (sNodeKey.Equals(EMGroupRoleType.Key.ToString().ToUpper()) ||
                            sNodeKey.Equals("ERROR")
                            || sNodeKey.Equals(EMGroupRoleType.SubKey.ToString()) || sNodeKey.Equals("ERROR RST") ||
                            sNodeKey.Equals("RECIPE WORD") || sNodeKey.Equals("CANDIDATE KEY"))
                            bOK = true;
                        else
                            DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign symbol at this node!!",
                                "UDM Tracker Simple",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (bOK)
                        {
                            TreeListNode trnProcess = trnNode.ParentNode;
                            cPlcProcess = (CPlcProc) trnProcess.Tag;

                            if (sNodeKey == EMGroupRoleType.Key.ToString().ToUpper())
                                SetKeySymbolS(trnProcess, cPlcProcess, cTagS);
                            else if (sNodeKey == "CANDIDATE KEY")
                                SetCandidateSymbolS(trnProcess, cPlcProcess, cTagS);
                            //else if (sNodeKey == EMGroupRoleType.SubKey.ToString())
                            //    SetSubKeySymbolS(trnProcess, cPlcProcess, cTagS);
                            else if (sNodeKey == "ERROR")
                                SetAbnormalSymbolS(trnProcess, cPlcProcess, cTagS);
                            else if (sNodeKey == "RECIPE WORD")
                                SetRecipeWordS(trnProcess, cPlcProcess, cTagS);
                            else if (sNodeKey == "ERROR RST")
                                SetCycle(trnProcess, cPlcProcess, cTagS);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                m_bDragDropReady = false;

                TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(new Point(e.X, e.Y));
                if (exHitInfo.Node == null)
                    return;

                if (Control.ModifierKeys != Keys.None)
                    return;

                m_bDragDropReady = true;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && m_bDragDropReady)
                {
                    //CSymbol cSymbol = GetSelectedSymbol();
                    //if (cSymbol == null)
                    //{
                    //    m_bDragDropReady = false;
                    //    return;
                    //}

                    //exTreeList.DoDragDrop(cSymbol, DragDropEffects.Move);
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                    m_bDragDropReady = false;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.Menu is TreeListNodeMenu)
                {
                    TreeListNode trnNode = ((TreeListNodeMenu) e.Menu).Node;

                    exTreeList.FocusedNode = trnNode;

                    object oData = trnNode.Tag;

                    if (oData != null)
                    {
                        Type tpNode = trnNode.Tag.GetType();
                        if (tpNode == typeof (CPlcProc))
                            exTreeList.ContextMenuStrip = cntxProcessMenu;
                        else if (tpNode == typeof (CKeySymbol) || tpNode == typeof (CAbnormalSymbol) ||
                                 tpNode == typeof (CSubKeySymbol))
                            exTreeList.ContextMenuStrip = cntxSymbolMenu;
                        else if (tpNode == typeof (CTag))
                            exTreeList.ContextMenuStrip = cntxRecipeMenu;
                        else
                        {
                            exTreeList.ContextMenuStrip = null;
                            e.Allow = false;
                        }
                    }
                    else
                    {
                        string sDisplayText = trnNode.GetDisplayText(colProcess);

                        if (sDisplayText.Equals("RECIPE WORD") || sDisplayText.Equals("KEY") ||
                            sDisplayText.Equals("ERROR") || sDisplayText.Equals("SubKey") ||
                            sDisplayText.Equals("ERROR RST") || sDisplayText.Equals("CANDIDATE KEY"))
                            exTreeList.ContextMenuStrip = cntxRoleTypeMenu;
                        else
                        {
                            exTreeList.ContextMenuStrip = null;
                            e.Allow = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnProcess = exTreeList.FocusedNode;
                if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof (CPlcProc))
                    return;

                CPlcProc cPlcProcess = (CPlcProc) trnProcess.Tag;

                if (
                    XtraMessageBox.Show("해당 \'" + cPlcProcess.Name + "\' 공정을 삭제하시겠습니까?", "Delete Process",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                cPlcProcess.Clear();

                if (CMultiProject.MasterPatternS != null && CMultiProject.MasterPatternS.ContainsKey(cPlcProcess.Name))
                    CMultiProject.MasterPatternS.Remove(cPlcProcess.Name);

                if (CMultiProject.PlcProcS.ContainsKey(cPlcProcess.Name))
                    CMultiProject.PlcProcS.Remove(cPlcProcess.Name);

                cPlcProcess = null;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    Clear();
                    ShowTree();
                    m_bProcessEdit = true;
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuRenameGroup_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnProcess = exTreeList.FocusedNode;
                if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof (CPlcProc))
                    return;

                string sName = GetUserInputText("Input Process Name", "Please enter text below...");
                if (sName != "")
                {
                    CPlcProc cPlcProcess = (CPlcProc) trnProcess.Tag;

                    CMasterPattern cMasterPattern = null;
                    if (CMultiProject.MasterPatternS.ContainsKey(cPlcProcess.Name))
                        cMasterPattern = CMultiProject.MasterPatternS[cPlcProcess.Name];

                    CLineInfo cLineInfo = null;
                    if (CMultiProject.LineInfoS.ContainsKey(cPlcProcess.Name))
                        cLineInfo = CMultiProject.LineInfoS[cPlcProcess.Name];

                    if (cPlcProcess.Name == sName)
                        return;

                    if (CMultiProject.PlcProcS.ContainsKey(sName))
                    {
                        MessageBox.Show("The name is exists already!!", "UDM Solution", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    CMultiProject.PlcProcS.Remove(cPlcProcess.Name);
                    //CMultiProject.LineInfoS.Remove(cPlcProcess.Name);
                    //CMultiProject.MasterPatternS.Remove(cPlcProcess.Name);

                    if (CMultiProject.LineInfoS.ContainsKey(cPlcProcess.Name))
                        CMultiProject.LineInfoS.Remove(cPlcProcess.Name);

                    if (CMultiProject.MasterPatternS.ContainsKey(cPlcProcess.Name))
                        CMultiProject.MasterPatternS.Remove(cPlcProcess.Name);

                    cPlcProcess.Name = sName;

                    CMultiProject.PlcProcS.Add(cPlcProcess.Name, cPlcProcess);

                    //CMultiProject.LineInfoS.Add(cPlcProcess.Name, new CLineInfo(cPlcProcess.Name));
                    //CMultiProject.MasterPatternS.Add(cPlcProcess.Name, cMasterPattern);

                    if (cLineInfo != null)
                    {
                        cLineInfo.PlcProc = cPlcProcess;
                        CMultiProject.LineInfoS.Add(cPlcProcess.Name, cLineInfo);
                    }

                    if (cMasterPattern != null)
                    {
                        cMasterPattern.Key = sName;
                        CMultiProject.MasterPatternS.Add(cPlcProcess.Name, cMasterPattern);
                    }

                    trnProcess.SetValue(colProcess, sName);
                    m_bProcessEdit = true;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuDeleteSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnSymbol = exTreeList.FocusedNode;
                if (trnSymbol == null || trnSymbol.Tag == null)
                    return;

                if (trnSymbol.Tag.GetType() == typeof (CKeySymbol))
                {
                    CKeySymbol cKeySymbol = (CKeySymbol) trnSymbol.Tag;

                    TreeListNode trnProcess = trnSymbol.ParentNode.ParentNode;
                    CPlcProc cPlcProcess = (CPlcProc) trnProcess.Tag;

                    if (cPlcProcess.KeySymbolS.ContainsKey(cKeySymbol.Tag.Key))
                        cPlcProcess.KeySymbolS.Remove(cKeySymbol.Tag.Key);

                    if (cPlcProcess.ChartViewTagS != null && cPlcProcess.ChartViewTagS.ContainsKey(cKeySymbol.Tag.Key))
                        cPlcProcess.ChartViewTagS.Remove(cKeySymbol.Tag.Key);

                    //if (cPlcProcess.KeySymbolList != null && cPlcProcess.KeySymbolList.Contains(cKeySymbol.TagKey))
                    //    cPlcProcess.KeySymbolList.Remove(cKeySymbol.TagKey);
                }
                else if (trnSymbol.Tag.GetType() == typeof (CAbnormalSymbol))
                {
                    CAbnormalSymbol cAbnormalSymbol = (CAbnormalSymbol) trnSymbol.Tag;

                    TreeListNode trnProcess = trnSymbol.ParentNode.ParentNode;
                    CPlcProc cPlcProcess = (CPlcProc) trnProcess.Tag;

                    string sKey = string.Format("{0}_{1}", cAbnormalSymbol.Tag.Key,
                        cAbnormalSymbol.IsAStateSymbol ? "A" : "B");

                    if (cPlcProcess.AbnormalSymbolS.ContainsKey(sKey))
                        cPlcProcess.AbnormalSymbolS.Remove(sKey);

                    if (cPlcProcess.AbnormalSymbolList.Contains(sKey))
                        cPlcProcess.AbnormalSymbolList.Remove(sKey);

                    if (cPlcProcess.AbnormalSymbolPriority.ContainsKey(sKey))
                        cPlcProcess.AbnormalSymbolPriority.Remove(sKey);
                }

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    Clear();
                    ShowTree();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (trnNode != null)
                {
                    if (trnNode.Nodes.Count != 0)
                    {
                        string sDisplayText = trnNode.GetDisplayText(colProcess);

                        if (sDisplayText.Equals("CANDIDATE KEY"))
                        {
                            TreeListNode trnProcess = trnNode.ParentNode;
                            CPlcProc cProcess = (CPlcProc) trnProcess.Tag;

                            if (trnNode.Expanded)
                            {
                                if (UEventCandidateKeyDoubleClicked != null)
                                    UEventCandidateKeyDoubleClicked(cProcess.Name, false);
                                trnNode.Expanded = false;
                            }
                            else
                            {
                                if (UEventCandidateKeyDoubleClicked != null)
                                    UEventCandidateKeyDoubleClicked(cProcess.Name, true);
                                trnNode.Expanded = true;
                            }
                        }
                        else
                        {
                            if (trnNode.Expanded)
                                trnNode.Expanded = false;
                            else
                                trnNode.Expanded = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuClearSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRoleType = exTreeList.FocusedNode;
                TreeListNode trnProcess = trnRoleType.ParentNode;

                string sDisplayText = trnRoleType.GetDisplayText(colProcess);

                CPlcProc cProcess = (CPlcProc) trnProcess.Tag;

                if (
                    XtraMessageBox.Show("해당 \'" + cProcess.Name + "\'공정의 " + sDisplayText + "를 Clear하시겠습니까?", "Clear",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (sDisplayText.Equals("KEY"))
                {
                    cProcess.KeySymbolS.Clear();

                    if (cProcess.ChartViewTagS != null)
                        cProcess.ChartViewTagS.Clear();

                    //if (cProcess.KeySymbolList != null)
                    //    cProcess.KeySymbolList.Clear();
                }
                else if (sDisplayText.Equals("ERROR"))
                    cProcess.RemoveAbnormalInfo();
                else if (sDisplayText.Equals("RECIPE WORD"))
                {
                    cProcess.RecipeWordS.Clear();
                    cProcess.SelectRecipeWord = null;
                }
                else if (sDisplayText.Equals("ERROR RST"))
                    cProcess.CycleCheckTag = null;
                else if (sDisplayText.Equals("CANDIDATE KEY"))
                {
                    if(cProcess.CollectCandidateTagS != null)
                        cProcess.CollectCandidateTagS.Clear();
                }

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    Clear();
                    ShowTree();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuErrorMonitoringAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sName = GetUserInputText("이상 신호 Monitoring", "Monitoring 할 이상 신호에 대한 이름을 설정하세요.");

                if (sName != string.Empty)
                {
                    if (!CMultiProject.PlcProcS.ContainsKey(sName))
                    {
                        CPlcProc cErrorProcess = new CPlcProc();
                        cErrorProcess.Name = sName;
                        cErrorProcess.IsErrorMonitoring = true;

                        CMultiProject.PlcProcS.Add(cErrorProcess.Name, cErrorProcess);

                        SplashScreenManager.ShowDefaultWaitForm();
                        {
                            ShowTree();
                        }
                        SplashScreenManager.CloseDefaultWaitForm();

                    }
                    else
                        XtraMessageBox.Show("해당 이름은 이미 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuProperty_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnProcess = exTreeList.FocusedNode;
                if (trnProcess == null || trnProcess.Tag == null || trnProcess.Tag.GetType() != typeof (CPlcProc))
                    return;

                CPlcProc cPlcProcess = (CPlcProc) trnProcess.Tag;

                FrmProcessProperty frmProperty = new FrmProcessProperty();
                frmProperty.Process = cPlcProcess;
                frmProperty.TopMost = true;

                frmProperty.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void btnSelectViewRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRecipe = exTreeList.FocusedNode;
                if (trnRecipe == null || trnRecipe.Tag == null)
                    return;

                if (trnRecipe.Tag.GetType() == typeof(CTag))
                {
                    CTag cRecipeTag = (CTag)trnRecipe.Tag;

                    TreeListNode trnProcess = trnRecipe.ParentNode.ParentNode;
                    CPlcProc cProcess = (CPlcProc)trnProcess.Tag;

                    if (cProcess.RecipeWordS.ContainsKey(cRecipeTag.Key))
                    {
                        TreeListNode trnRoleType = trnRecipe.ParentNode;

                        foreach (TreeListNode trnNode in trnRoleType.Nodes)
                        {
                            if(Convert.ToInt32(trnNode.GetValue(colRecipe)) == 1)
                                trnNode.SetValue(colRecipe, 0);
                        }

                        cProcess.SelectRecipeWord = cRecipeTag;
                        if(Convert.ToInt32(trnRecipe.GetValue(colRecipe)) != 2)
                            trnRecipe.SetValue(colRecipe, 1);
                    }
                }
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDeleteRecipeWord_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRecipe = exTreeList.FocusedNode;
                if (trnRecipe == null || trnRecipe.Tag == null)
                    return;

                if (trnRecipe.Tag.GetType() == typeof(CTag))
                {
                    CTag cRecipeTag = (CTag)trnRecipe.Tag;

                    TreeListNode trnProcess = trnRecipe.ParentNode.ParentNode;
                    CPlcProc cProcess = (CPlcProc)trnProcess.Tag;

                    if (cProcess.RecipeWordS.ContainsKey(cRecipeTag.Key))
                        cProcess.RecipeWordS.Remove(cRecipeTag.Key);
                }

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    Clear();
                    ShowTree();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                //if (e.Column != colRecipe)
                //    return;

                if (Convert.ToInt32(e.Node.GetValue(colRecipe)) == 2)
                {
                    e.Appearance.BackColor = Color.LimeGreen;
                    e.Appearance.BackColor2 = Color.NavajoWhite;
                }
                else if (Convert.ToInt32(e.Node.GetValue(colRecipe)) == 1)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.BackColor2 = Color.White;
                }

                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCancelViewRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRecipe = exTreeList.FocusedNode;
                if (trnRecipe == null || trnRecipe.Tag == null)
                    return;

                if (trnRecipe.Tag.GetType() == typeof(CTag))
                {
                    TreeListNode trnProcess = trnRecipe.ParentNode.ParentNode;
                    CPlcProc cProcess = (CPlcProc)trnProcess.Tag;

                    if(Convert.ToInt32(trnRecipe.GetValue(colRecipe)) != 2)
                        trnRecipe.SetValue(colRecipe, 0);

                    cProcess.SelectRecipeWord = null;
                }
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSelectCycleRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRecipe = exTreeList.FocusedNode;
                if (trnRecipe == null || trnRecipe.Tag == null)
                    return;

                if (trnRecipe.Tag.GetType() == typeof (CTag))
                {
                    CTag cRecipeTag = (CTag) trnRecipe.Tag;

                    TreeListNode trnProcess = trnRecipe.ParentNode.ParentNode;
                    CPlcProc cProcess = (CPlcProc) trnProcess.Tag;

                    if (cProcess.CycleStartConditionS.Count > 0 || cProcess.CycleEndConditionS.Count > 0)
                    {
                        if (XtraMessageBox.Show(
                            "해당 공정의 Cycle 신호는 이미 설정되어 있습니다.\r\n선택하신 Recipe Word로 사이클 신호를 다시 설정하시겠습니까?",
                            "Excalmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            return;
                    }

                    cProcess.CycleStartConditionS.Clear();
                    cProcess.CycleEndConditionS.Clear();
                    //cProcess.StartCompareCondition = null;
                    //cProcess.EndCompareCondition = null;

                    CCondition cStartCondition = new CCondition(cRecipeTag.Key, cRecipeTag.Address, 100,
                        EMOperaterType.And);
                    cProcess.CycleStartConditionS.Add(cStartCondition);
                    //cProcess.StartCompareCondition = cStartCondition;

                    CCondition cEndCondition = new CCondition(cRecipeTag.Key, cRecipeTag.Address, 100,
                        EMOperaterType.And);
                    cProcess.CycleEndConditionS.Add(cEndCondition);
                    //cProcess.EndCompareCondition = cEndCondition;

                    TreeListNode trnRoleType = trnRecipe.ParentNode;

                    foreach (TreeListNode trnNode in trnRoleType.Nodes)
                    {
                        if (Convert.ToInt32(trnNode.GetValue(colRecipe)) == 2)
                            trnNode.SetValue(colRecipe, 0);
                    }

                    trnRecipe.SetValue(colRecipe, 2);

                    //if (cProcess.SelectRecipeWord == null)
                    //    cProcess.SelectRecipeWord = cRecipeTag;
                    //else if (cProcess.SelectRecipeWord != cRecipeTag)
                    //{
                    //    if (
                    //        XtraMessageBox.Show(
                    //            "View Recipe와 Cycle Recipe 가 일치하지 않습니다.\r\nView Recipe는 차종에 관련된 값을 나타내며 사이클 마다 바뀌지 않을 수 있으나 Cycle Recipe는 사이클 마다 필히 값이 바뀌어야 하는 Word 값 입니다.\r\nView Recipe를 Cycle Recipe와 일치시키시겠습니까?",
                    //            "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //    {
                    //        foreach (TreeListNode trnNode in trnRoleType.Nodes)
                    //        {
                    //            if (Convert.ToInt32(trnNode.GetValue(colRecipe)) == 1)
                    //                trnNode.SetValue(colRecipe, 0);
                    //        }

                    //        cProcess.SelectRecipeWord = null;
                    //        cProcess.SelectRecipeWord = cRecipeTag;
                    //    }
                    //    else
                    //    {
                    //        if (cProcess.SelectRecipeWord != null)
                    //        {
                    //            foreach (TreeListNode trnNode in trnRoleType.Nodes)
                    //            {
                    //                if (Convert.ToInt32(trnNode.GetValue(colRecipe)) == 1)
                    //                    trnNode.SetValue(colRecipe, 0);

                    //                if (trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CTag))
                    //                {
                    //                    CTag cTag = (CTag)trnNode.Tag;

                    //                    if (cTag == cProcess.SelectRecipeWord)
                    //                        trnNode.SetValue(colRecipe, 1);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCancelCycleRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnRecipe = exTreeList.FocusedNode;
                if (trnRecipe == null || trnRecipe.Tag == null)
                    return;

                if (trnRecipe.Tag.GetType() == typeof (CTag))
                {
                    CTag cRecipeTag = (CTag) trnRecipe.Tag;

                    TreeListNode trnProcess = trnRecipe.ParentNode.ParentNode;
                    CPlcProc cProcess = (CPlcProc) trnProcess.Tag;

                    if (cProcess.CycleStartConditionS.Count == 0 || cProcess.CycleEndConditionS.Count == 0)
                    {
                        XtraMessageBox.Show("해당 공정의 Cycle 신호가 설정되있지 않습니다.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (Convert.ToInt32(trnRecipe.GetValue(colRecipe)) != 2)
                        return;

                    cProcess.CycleStartConditionS.Clear();
                    cProcess.CycleEndConditionS.Clear();
                    //cProcess.StartCompareCondition = null;
                    //cProcess.EndCompareCondition = null;

                    TreeListNode trnRoleType = trnRecipe.ParentNode;

                    foreach (TreeListNode trnNode in trnRoleType.Nodes)
                    {
                        if (Convert.ToInt32(trnNode.GetValue(colRecipe)) == 2)
                            trnNode.SetValue(colRecipe, 0);
                    }

                    if (cProcess.SelectRecipeWord != null)
                    {
                        foreach (TreeListNode trnNode in trnRoleType.Nodes)
                        {
                            if (Convert.ToInt32(trnNode.GetValue(colRecipe)) == 1)
                                trnNode.SetValue(colRecipe, 0);

                            if (trnNode.Tag != null && trnNode.Tag.GetType() == typeof (CTag))
                            {
                                CTag cTag = (CTag) trnNode.Tag;

                                if(cTag == cProcess.SelectRecipeWord)
                                    trnNode.SetValue(colRecipe, 1);
                            }
                        }
                    }
                }
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCProcessTree", ex.Message);
                ex.Data.Clear();
            }
        }

        
    }
}
