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

namespace UDMIOMaker
{
    public partial class UCVerifyTree : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        private FrmLadderView m_frmLadderView = null;
        private TreeListHitInfo dragStartHitInfo = null;
        private bool m_bReportTree = false;

        #endregion

        #region Initialize/Dispose

        public UCVerifyTree()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public void ShowTree(bool bAll)
        {
            try
            {
                exTreeList.BeginUpdate();
                {
                    if (CProjectManager.LogicDataS == null || CProjectManager.LogicDataS.Count == 0)
                        return;

                    CPlcLogicData cData = null;
                    TreeListNode trnPLC = null;
                    foreach (var who in CProjectManager.LogicDataS)
                    {
                        if (CheckExistTreeNode(who.Key))
                            continue;

                        cData = who.Value;
                        trnPLC = CreateTreeNode(null, who.Key, "", "", "", "", false, false, cData, 0);
                        UpdatePLCNode(cData, trnPLC, bAll);

                        trnPLC.Expanded = true;
                    }
                    colAddress.BestFit();
                }
                exTreeList.EndUpdate();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree ShowIOTree", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ShowReportTree()
        {
            try
            {
                colClassification.Width = 200;
                btnSymbolDelete.Visible = true;
                m_bReportTree = true;

                exTreeList.BeginUpdate();
                {
                    if (CProjectManager.LogicDataS == null || CProjectManager.LogicDataS.Count == 0)
                        return;

                    TreeListNode trnElement = null;
                    CPlcLogicData cData = null;
                    TreeListNode trnPLC = null;

                    foreach (CReportElement cElement in CProjectManager.ReportElementS)
                    {
                        if (CheckExistTreeNode(cElement.Element))
                            continue;

                        trnElement = CreateTreeNode(null, cElement.Element, "", "", "", "", false, false, cElement, 1);

                        foreach (var who in CProjectManager.LogicDataS)
                        {
                            cData = who.Value;

                            if (!CheckExistElement(cData, cElement.Element))
                                continue;

                            trnPLC = CreateTreeNode(trnElement, who.Key, "", "", "", "", false, false, cData, 0);
                            UpdateReportNode(cData, trnPLC, cElement.Element);

                            trnPLC.Expanded = true;
                        }
                        trnElement.Expanded = true;
                    }
                    colAddress.BestFit();
                }
                exTreeList.EndUpdate();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree ShowReportTree", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ShowDefaultReportTree()
        {
            try
            {
                colClassification.Width = 200;
                btnSymbolDelete.Visible = true;
                m_bReportTree = true;

                exTreeList.BeginUpdate();
                {
                    if (CProjectManager.LogicDataS == null || CProjectManager.LogicDataS.Count == 0)
                        return;

                    string sDefault1 = "Input 접점 출력 조건으로 사용";
                    string sDefault2 = "Output 접점 입력 조건으로 사용";

                    SetDefaultReportTree(sDefault1, true);
                    SetDefaultReportTree(sDefault2, false);

                    colAddress.BestFit();
                }
                exTreeList.EndUpdate();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree ShowDefaultReportTree", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        public TreeListNode GetElementTreeListNode(string sElement)
        {
            TreeListNode trnNode = null;

            for (int i = 0; i < exTreeList.Nodes.Count; i++)
            {
                if (exTreeList.Nodes[i].GetDisplayText(colClassification) == sElement)
                {
                    trnNode = exTreeList.Nodes[i];
                    break;
                }
            }

            return trnNode;
        }

        public void ClearTree()
        {
            exTreeList.Nodes.Clear();
        }

        #endregion


        #region Private Methods

        private void SetDefaultReportTree(string sName, bool bInput)
        {
            TreeListNode trnElement = null;
            CPlcLogicData cData = null;
            TreeListNode trnPLC = null;

            trnElement = CreateTreeNode(null, sName, "", "", "", "", false, false, null, 1);

            foreach (var who in CProjectManager.LogicDataS)
            {
                cData = who.Value;

                if (!CheckExistInOutSymbolRole(cData, bInput))
                    continue;

                trnPLC = CreateTreeNode(trnElement, who.Key, "", "", "", "", false, false, cData, 0);
                UpdateReportDefaultNode(cData, trnPLC, bInput);

                trnPLC.Expanded = true;
            }
            trnElement.Expanded = true;
        }

        private bool CheckExistElement(CPlcLogicData cData, string sElement)
        {
            bool bOK = false;

            List<string> lstElement = sElement.Split(' ').ToList();
            CVerifTag cTag;

            foreach (var who in cData.TagS)
            {
                if (!CProjectManager.VerifTagS.ContainsKey(who.Key))
                    continue;

                cTag = CProjectManager.VerifTagS[who.Key];
                if(cTag.DataType == EMDataType.Bool && CheckAddressHeader(cData.PLCMaker, cTag.Address) && IsContainElement(cTag, lstElement))
                {
                    bOK = true;
                    break;
                }
            }
            return bOK;
        }

        private bool CheckExistInOutSymbolRole(CPlcLogicData cData, bool bInput)
        {
            bool bOK = false;

            CVerifTag cVerifTag = null;
            foreach (var who in cData.TagS)
            {
                if (!CProjectManager.VerifTagS.ContainsKey(who.Key))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[who.Key];

                if (bInput && CheckInputAddressHeader(cData.PLCMaker, cVerifTag.Address))
                {
                    if (cVerifTag.SymbolRole == EMSymbolRole.Both)
                    {
                        bOK = true;
                        break;
                    }
                }
                else if (!bInput && CheckOutputAddressHeader(cData.PLCMaker, cVerifTag.Address))
                {
                    if (cVerifTag.SymbolRole == EMSymbolRole.Both)
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private bool CheckExistTreeNode(string sText)
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

        private string GetNodeText(TreeListNode trnNode)
        {
            string sName = trnNode.GetValue(0).ToString();

            return sName;
        }

        private bool IsContainElement(CVerifTag cTag, List<string> lstElement)
        {
            bool bOK = true;

            if (cTag.Name == string.Empty && cTag.Description == string.Empty)
                return false;

            if (cTag.Name != string.Empty)
            {
                foreach (string sElement in lstElement)
                {
                    if (!cTag.Name.Contains(sElement))
                    {
                        bOK = false;
                        break;
                    }
                }
            }

            if (bOK && cTag.Description != string.Empty)
            {
                foreach (string sElement in lstElement)
                {
                    if (!cTag.Description.Contains(sElement))
                    {
                        bOK = false;
                        break;
                    }
                }
            }

            return bOK;
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sType, string sAddress, string sName, string sDescription, string sDataType, bool bUsed, bool bDoubleCoil, object oData, int iImageIndex)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                    trnNode =
                        exTreeList.Nodes.Add(new object[]
                        {sType, sAddress, sName, sDescription, sDataType, bUsed, bDoubleCoil});
            else
                    trnNode = trnParent.Nodes.Add(new object[] { sType, sAddress, sName, sDescription, sDataType, bUsed, bDoubleCoil });

            trnNode.Tag = oData;

            if (iImageIndex == -1)
            {
                if (sType.Contains("출력"))
                    iImageIndex = 2;
                else if(sType.Contains("조건"))
                    iImageIndex = 3;
                else if (sType == string.Empty)
                    iImageIndex = -1;
            }

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;

            return trnNode;
        }

        private void UpdateReportNode(CPlcLogicData cData, TreeListNode trnParent, string sElement)
        {
            trnParent.Nodes.Clear();

            List<string> lstElement = sElement.Split(' ').ToList();

            CVerifTag cVerifTag = null;
            TreeListNode trnTag = null;
            foreach (string sKey in cData.TagS.Keys)
            {
                if (!CProjectManager.VerifTagS.ContainsKey(sKey))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[sKey];

                if (cVerifTag.DataType == EMDataType.Bool && CheckAddressHeader(cData.PLCMaker, cVerifTag.Address) && IsContainElement(cVerifTag, lstElement))
                {
                    trnTag = CreateTreeNode(trnParent, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address, cVerifTag.Name, cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil, cVerifTag, -1);

                    if (cVerifTag.SymbolRole.Equals(EMSymbolRole.Both) || cVerifTag.SymbolRole.Equals(EMSymbolRole.Coil))
                        CreateCoilTreeNode(trnTag, sKey, cVerifTag.Channel);
                }
            }
        }

        private void UpdateReportDefaultNode(CPlcLogicData cData, TreeListNode trnParent, bool bInput)
        {
            trnParent.Nodes.Clear();

            CVerifTag cVerifTag = null;
            TreeListNode trnTag = null;
            foreach (string sKey in cData.TagS.Keys)
            {
                if (!CProjectManager.VerifTagS.ContainsKey(sKey))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[sKey];

                if (cVerifTag.DataType != EMDataType.Bool)
                    continue;

                if (bInput && CheckInputAddressHeader(cData.PLCMaker, cVerifTag.Address))
                {
                    trnTag = CreateTreeNode(trnParent, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address, cVerifTag.Name, cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil, cVerifTag, -1);

                    if (cVerifTag.SymbolRole.Equals(EMSymbolRole.Both) || cVerifTag.SymbolRole.Equals(EMSymbolRole.Coil))
                        CreateCoilTreeNode(trnTag, sKey, cVerifTag.Channel);
                }
                else if (!bInput && CheckOutputAddressHeader(cData.PLCMaker, cVerifTag.Address))
                {
                    trnTag = CreateTreeNode(trnParent, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address, cVerifTag.Name, cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil, cVerifTag, -1);

                    if (cVerifTag.SymbolRole.Equals(EMSymbolRole.Both) || cVerifTag.SymbolRole.Equals(EMSymbolRole.Coil))
                        CreateCoilTreeNode(trnTag, sKey, cVerifTag.Channel);
                }
            }
        }

        private void UpdatePLCNode(CPlcLogicData cData, TreeListNode trnPLC, bool bAll)
        {
            trnPLC.Nodes.Clear();

            CVerifTag cVerifTag = null;
            TreeListNode trnTag = null;
            foreach (string sKey in cData.TagS.Keys)
            {
                if (!CProjectManager.VerifTagS.ContainsKey(sKey))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[sKey];

                if (bAll)
                {
                    trnTag = CreateTreeNode(trnPLC, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address,
                        cVerifTag.Name,
                        cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil,
                        cVerifTag, -1);
                }
                else if (!bAll && CheckAddressHeader(cData.PLCMaker, cVerifTag.Address))
                {
                    trnTag = CreateTreeNode(trnPLC, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address,
                        cVerifTag.Name,
                        cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil,
                        cVerifTag, -1);
                }
                else continue;

                if (cVerifTag.SymbolRole.Equals(EMSymbolRole.Both) || cVerifTag.SymbolRole.Equals(EMSymbolRole.Coil))
                    CreateCoilTreeNode(trnTag, sKey, cVerifTag.Channel);
            }
        }

        private void AddReportTreeNode(TreeListNode trnHitNode, TreeListMultiSelection trnNodes)
        {
            List<CVerifTag> lstTag = GetVerifyTagS(trnNodes);
            TreeListNode trnElement = GetReportElementTreeNode(trnHitNode);
            TreeListNode trnPLC = null;
            TreeListNode trnTag = null;
            bool bOK = false;

            foreach (CVerifTag cTag in lstTag)
            {
                bOK = false;

                foreach (TreeListNode trnNode in trnElement.Nodes)
                {
                    if (trnNode.GetDisplayText(colClassification) == cTag.Channel)
                    {
                        trnPLC = trnNode;
                        break;
                    }
                }

                if (trnPLC != null)
                {
                    bOK = true;

                    foreach (TreeListNode trnNode in trnPLC.Nodes)
                    {
                        if (trnNode.GetDisplayText(colAddress) == cTag.Address)
                        {
                            bOK = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (!CProjectManager.LogicDataS.ContainsKey(cTag.Channel))
                        continue;

                    CPlcLogicData cData = CProjectManager.LogicDataS[cTag.Channel];

                    trnPLC = CreateTreeNode(trnElement, cData.Name, "", "", "", "", false, false, cData, 0);

                    bOK = true;
                }

                if (bOK)
                {
                    trnTag = CreateTreeNode(trnPLC, GetSymbolRole(cTag.SymbolRole), cTag.Address, cTag.Name, cTag.Description, cTag.DataType.ToString(), IsUsed(cTag), cTag.IsDoubleCoil, cTag, -1);

                    if (cTag.SymbolRole.Equals(EMSymbolRole.Both) || cTag.SymbolRole.Equals(EMSymbolRole.Coil))
                        CreateCoilTreeNode(trnTag, cTag.Key, cTag.Channel);
                }
            }

            exTreeList.Update();
        }

        private List<CVerifTag> GetVerifyTagS(TreeListMultiSelection trnNodes)
        {
            List<CVerifTag> lstTag = new List<CVerifTag>();

            CVerifTag cTag;
            foreach (TreeListNode trnNode in trnNodes)
            {
                if (trnNode.Tag != null && trnNode.Tag.GetType() == typeof(CVerifTag))
                {
                    cTag = (CVerifTag)trnNode.Tag;
                    lstTag.Add(cTag);
                }
            }

            return lstTag;
        }

        private TreeListNode GetReportElementTreeNode(TreeListNode trnCurrentNode)
        {
            TreeListNode trnElementNode = null;

            if (trnCurrentNode.ParentNode == null)
                return trnCurrentNode;
            else
                trnElementNode = GetReportElementTreeNode(trnCurrentNode.ParentNode);

            return trnElementNode;
        }

        private bool CheckAddressHeader(EMPLCMaker emPLCMaker, string sAddress)
        {
            bool bOK = false;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (sAddress.Contains("X") || sAddress.Contains("Y"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (sAddress.Contains("I") || sAddress.Contains("Q"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (sAddress.Contains("P") || sAddress.Contains("K"))
                    bOK = true;
            }
            else
                bOK = true;

            return bOK;
        }

        private bool CheckInputAddressHeader(EMPLCMaker emPLCMaker, string sAddress)
        {
            bool bOK = false;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (sAddress.Contains("X"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (sAddress.Contains("I"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (sAddress.Contains("P"))
                    bOK = true;
            }
            else
                bOK = true;

            return bOK;
        }

        private bool CheckOutputAddressHeader(EMPLCMaker emPLCMaker, string sAddress)
        {
            bool bOK = false;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (sAddress.Contains("Y"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (sAddress.Contains("Q"))
                    bOK = true;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (sAddress.Contains("K"))
                    bOK = true;
            }
            else
                bOK = true;

            return bOK;
        }

        private void CreateCoilTreeNode(TreeListNode trnParent, string sKey, string sPLCName)
        {
            if (!CProjectManager.PLCTagS.ContainsKey(sKey) || !CProjectManager.LogicDataS.ContainsKey(sPLCName))
                return;

            CTag cTag = CProjectManager.PLCTagS[sKey];
            CPlcLogicData cData = CProjectManager.LogicDataS[sPLCName];

            CStep cStep = null;
            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Both || who.RoleType == EMStepRoleType.Coil)
                {
                    if(!cData.StepS.ContainsKey(who.StepKey))
                        continue;

                    cStep = cData.StepS[who.StepKey];
                    break;
                }
            }

            if (cStep == null)
                return;

            CVerifTag cVerifTag = null;
            foreach (string sContactKey in cStep.RefTagS.KeyList)
            {
                if (sContactKey == sKey)
                    continue;

                if (!CProjectManager.VerifTagS.ContainsKey(sContactKey))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[sContactKey];
                CreateTreeNode(trnParent, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address, cVerifTag.Name,
                    cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil,
                    cVerifTag, -1);
            }
        }

        private void CreateCoilTreeNode(CStep cStep, TreeListNode trnParent, string sKey)
        {
            if (cStep == null)
                return;

            CVerifTag cVerifTag = null;
            foreach (string sContactKey in cStep.RefTagS.KeyList)
            {
                if (sContactKey == sKey)
                    continue;

                if (!CProjectManager.VerifTagS.ContainsKey(sContactKey))
                    continue;

                cVerifTag = CProjectManager.VerifTagS[sContactKey];
                CreateTreeNode(trnParent, GetSymbolRole(cVerifTag.SymbolRole), cVerifTag.Address, cVerifTag.Name,
                    cVerifTag.Description, cVerifTag.DataType.ToString(), IsUsed(cVerifTag), cVerifTag.IsDoubleCoil,
                    cVerifTag, -1);
            }
        }

        private string GetSymbolRole(EMSymbolRole emRole)
        {
            string sType = string.Empty;

            if (emRole.Equals(EMSymbolRole.Both))
                sType = "조건/출력";
            else if (emRole.Equals(EMSymbolRole.Contact))
                sType = "조건";
            else if (emRole.Equals(EMSymbolRole.Coil))
                sType = "출력";
            else
                sType = string.Empty;

            return sType;
        }

        private bool IsUsed(CVerifTag cVerifTag)
        {

            bool bUsed = false;

            if (!cVerifTag.UsedLogic.Equals(EMUsedLogic.NotUsed))
                bUsed = true;

            return bUsed;
        }

        private CStep GetCoilStep(CTag cTag)
        {
            CStep cStep = null;
            CPlcLogicData cData = GetUsedLogicData(cTag.Key);

            string sStepKey = string.Empty;
            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType.Equals(EMStepRoleType.Both) || who.RoleType.Equals(EMStepRoleType.Coil))
                {
                    sStepKey = who.StepKey;
                    break;
                }
            }

            if (sStepKey != string.Empty)
                cStep = cData.StepS[sStepKey];

            return cStep;
        }

        private CPlcLogicData GetUsedLogicData(string sKey)
        {
            CPlcLogicData cData = null;

            foreach (var who in CProjectManager.LogicDataS)
            {
                if (who.Value.TagS.ContainsKey(sKey))
                {
                    cData = who.Value;
                    break;
                }
            }

            return cData;
        }

        private CStep GetStep(CTag cTag)
        {
            if (cTag.StepRoleS.Count == 0)
                return null;

            CStep cStep = null;
            CPlcLogicData cData = GetUsedLogicData(cTag.Key);
            string sStepKey = string.Empty;

            if (cTag.StepRoleS.Count == 1)
            {
                sStepKey = cTag.StepRoleS.First().StepKey;

                if (sStepKey != string.Empty)
                    cStep = cData.StepS[sStepKey];
            }
            else
            {
                FrmStepSelector frmStepSelector = new FrmStepSelector();
                frmStepSelector.Tag = cTag;
                if (frmStepSelector.ShowDialog() != DialogResult.OK)
                    return null;

                cStep = frmStepSelector.GetSelectedStep();
            }

            return cStep;
        }

        private TreeListMultiSelection GetDragNodes(IDataObject data)
        {
            return data.GetData(typeof(TreeListMultiSelection)) as TreeListMultiSelection;
        }

        #endregion

        private void btnClearCondition_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (trnNode == null || trnNode.Tag == null || trnNode.Tag.GetType() != typeof (CVerifTag))
                    return;

                string sType = trnNode.GetDisplayText(colClassification);

                if (!sType.Contains("출력"))
                {
                    XtraMessageBox.Show("출력으로 사용된 접점만 하위 조건을 지울 수 있습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                trnNode.Nodes.Clear();
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree ClearCondition", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnViewCondition_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (trnNode == null || trnNode.Tag == null || trnNode.Tag.GetType() != typeof(CVerifTag))
                    return;

                string sType = trnNode.GetDisplayText(colClassification);

                if (!sType.Contains("출력"))
                {
                    XtraMessageBox.Show("출력으로 사용된 접점만 하위 조건을 볼 수 있습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                trnNode.Nodes.Clear();

                CVerifTag cVerifTag = (CVerifTag)trnNode.Tag;
                CTag cTag = CProjectManager.PLCTagS[cVerifTag.Key];
                CStep cStep = null;

                if (cVerifTag.IsDoubleCoil)
                {
                    FrmStepSelector frmStepSelector = new FrmStepSelector();
                    frmStepSelector.Tag = cTag;
                    frmStepSelector.OnlyCoilView = true;

                    if (frmStepSelector.ShowDialog() != DialogResult.OK)
                        return;

                    cStep = frmStepSelector.GetSelectedStep();
                }
                else
                    cStep = GetCoilStep(cTag);

                if (cStep == null)
                {
                    XtraMessageBox.Show("해당 접점에 대한 Step 이 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                CreateCoilTreeNode(cStep, trnNode, cTag.Key);
                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree ViewCondition", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLadderView_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnNode = exTreeList.FocusedNode;

                if (trnNode == null || trnNode.Tag == null || trnNode.Tag.GetType() != typeof(CVerifTag))
                    return;

                CVerifTag cVerifTag = (CVerifTag)trnNode.Tag;
                CTag cTag = CProjectManager.PLCTagS[cVerifTag.Key];
                CStep cStep = GetStep(cTag);

                if (cStep == null)
                    return;

                if (!m_frmLadderView.IsLoad)
                {
                    m_frmLadderView.Show();
                    m_frmLadderView.IsLoad = true;
                }

                m_frmLadderView.SetLadderStep(cStep, 0, true);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree LadderView", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                TreeListNode trnNode = ((TreeListNodeMenu) e.Menu).Node;

                exTreeList.FocusedNode = trnNode;
                object oData = trnNode.Tag;

                if (m_bReportTree)
                    exTreeList.ContextMenuStrip = cntxMenu;
                else
                {
                    if (oData != null)
                    {
                        if (oData.GetType() == typeof (CVerifTag))
                            exTreeList.ContextMenuStrip = cntxMenu;
                        else
                        {
                            exTreeList.ContextMenuStrip = null;
                            e.Allow = false;
                        }
                    }
                    else
                    {
                        exTreeList.ContextMenuStrip = null;
                        e.Allow = false;
                    }
                }
            }
        }

        private void exTreeList_Load(object sender, EventArgs e)
        {
            m_frmLadderView = new FrmLadderView();
            m_frmLadderView.TopMost = true;
        }

        private void btnSymbolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("해당 Node를 트리에서 삭제하시겠습니까?", "Delete Node", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                exTreeList.DeleteSelectedNodes();

                exTreeList.Update();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree NodeDelete", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (!m_bReportTree)
                    return;

                TreeListMultiSelection trnNodes = GetDragNodes(e.Data);

                if (trnNodes != null)
                {
                        Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                        TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(pntClient);

                    if (exHitInfo != null && exHitInfo.Node != null)
                    {
                        TreeListNode trnHitNode = exHitInfo.Node;

                        SplashScreenManager.ShowDefaultWaitForm();
                        {
                            AddReportTreeNode(trnHitNode, trnNodes);
                        }
                        SplashScreenManager.CloseDefaultWaitForm();
                    }
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree Drag Drop", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (GetDragNodes(e.Data) != null)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree DragOver", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
                {
                    TreeList TreeList = sender as TreeList;
                    dragStartHitInfo = TreeList.CalcHitInfo(e.Location);
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree MouseDown", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && dragStartHitInfo != null && dragStartHitInfo.Node != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(dragStartHitInfo.MousePoint.X - dragSize.Width / 2,
                        dragStartHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);
                    if (!dragRect.Contains(e.Location))
                        ((TreeList)sender).DoDragDrop(exTreeList.Selection, DragDropEffects.Copy);
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UCVerifyTree MouseMove", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
