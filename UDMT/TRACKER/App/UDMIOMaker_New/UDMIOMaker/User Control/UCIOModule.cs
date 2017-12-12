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
using UDM.Common;

namespace UDMIOMaker
{
    public partial class UCIOModule : DevExpress.XtraEditors.XtraUserControl
    {
        private bool m_bExtend = false;
        private bool m_bUsed = false;

        protected const int IMG_INDEX_PLC = 0;
        protected const int IMG_INDEX_UNIT = 2;

        protected const int NODE_LEVEL_PLC = 0;
        protected const int NODE_LEVEL_UNIT = 1;

        private const int MELSEC_NORMAL_AREA = 511;
        private const int MELSEC_EXTEND_AREA = 1023;

        private const int SIEMENS_NORMAL_AREA = 8191;
        private const int SIEMENS_EXTEND_AREA = 16383;

        private const int LS_NORMAL_AREA = 1023;
        private const int LS_EXTEND_AREA = 2047;

        public UCIOModule()
        {
            InitializeComponent();
        }

        public void ShowTree(bool bExtend, bool bUsed)
        {
            ClearTree();

            m_bExtend = bExtend;
            m_bUsed = bUsed;

            exTreeList.BeginUpdate();
            {
                CPlcLogicData cData;
                TreeListNode trnPLC;

                foreach (var who in CProjectManager.LogicDataS)
                {
                    cData = who.Value;
                    trnPLC = CreatePLCTreeNode(null, who.Key, IMG_INDEX_PLC, who.Value);
                    UpdatePLCNode(trnPLC, cData);
                    trnPLC.Expanded = true;
                }
            }
            exTreeList.EndUpdate();
        }

        public void ClearTree()
        {
            exTreeList.Nodes.Clear();
        }

        private TreeListNode CreatePLCTreeNode(TreeListNode trnParent, string sPLC, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] { string.Format("{0} : IO", sPLC), "", "", "", ""});

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private TreeListNode CreateMelsecUnitTreeNode(TreeListNode trnParent, string sPLCName, CBlockUnit cUnit, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                return null;

            string sInput = CheckMelsecInputRangeUsed(cUnit, sPLCName);
            string sOutput = CheckMelsecOutputRangeUsed(cUnit, sPLCName);

            if (CheckMelsecUsed(cUnit, sPLCName))
                cUnit.IsUsed = true;
            else
            {
                cUnit.IsUsed = false;

                if (m_bUsed)
                    return null;
            }

            trnNode = trnParent.Nodes.Add(new object[] { cUnit.AddressRange, sInput, sOutput, cUnit.Description, cUnit.Module });

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private TreeListNode CreateLSUnitTreeNode(TreeListNode trnParent, string sPLCName, CBlockUnit cUnit, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                return null;

            string sInput = CheckLSInputRangeUsed(cUnit, sPLCName);
            string sOutput = CheckLSOutputRangeUsed(cUnit, sPLCName);

            if (CheckLSUsed(cUnit, sPLCName))
                cUnit.IsUsed = true;
            else
            {
                cUnit.IsUsed = false;

                if (m_bUsed)
                    return null;
            }

            trnNode = trnParent.Nodes.Add(new object[] { cUnit.AddressRange, sInput, sOutput, cUnit.Description, cUnit.Module });

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private TreeListNode CreateSiemensUnitTreeNode(TreeListNode trnParent, string sPLCName, CBlockUnit cUnit, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                return null;

            string sInput = CheckSiemensInputRangeUsed(cUnit, sPLCName);
            string sOutput = CheckSiemensOutputRangeUsed(cUnit, sPLCName);

            if (CheckSiemensUsed(cUnit, sPLCName))
                cUnit.IsUsed = true;
            else
            {
                cUnit.IsUsed = false;

                if (m_bUsed)
                    return null;
            }

            trnNode = trnParent.Nodes.Add(new object[] { cUnit.AddressRange, sInput, sOutput, cUnit.Description, cUnit.Module });

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private void UpdatePLCNode(TreeListNode trnPLC, CPlcLogicData cData)
        {
            trnPLC.Nodes.Clear();

            if(cData.PLCMaker.ToString().Contains("Mitsubishi"))
                UpdateMelsecPLCNode(trnPLC, cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.Siemens))
                UpdateSiemensPLCNode(trnPLC, cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.LS))
                UpdateLSPLCNode(trnPLC, cData);
        }

        private void UpdateMelsecPLCNode(TreeListNode trnPLC, CPlcLogicData cData)
        {
            int iCount = 0;

            if (m_bExtend)
                iCount = MELSEC_EXTEND_AREA;
            else
                iCount = MELSEC_NORMAL_AREA;

            for (int i = 0; i <= iCount; i++)
                CreateMelsecUnitTreeNode(trnPLC, cData.Name, cData.IOModuleBlock.UnitS[i], IMG_INDEX_UNIT,
                    cData.IOModuleBlock.UnitS[i]);
        }

        private void UpdateLSPLCNode(TreeListNode trnPLC, CPlcLogicData cData)
        {
            int iCount = 0;

            if (m_bExtend)
                iCount = LS_EXTEND_AREA;
            else
                iCount = LS_NORMAL_AREA;

            for (int i = 0; i <= iCount; i++)
                CreateLSUnitTreeNode(trnPLC, cData.Name, cData.IOModuleBlock.UnitS[i], IMG_INDEX_UNIT,
                    cData.IOModuleBlock.UnitS[i]);
        }

        private void UpdateSiemensPLCNode(TreeListNode trnPLC, CPlcLogicData cData)
        {
            int iCount = 0;

            if (m_bExtend)
                iCount = SIEMENS_EXTEND_AREA;
            else
                iCount = SIEMENS_NORMAL_AREA;

            for (int i = 0; i <= iCount; i++)
                CreateSiemensUnitTreeNode(trnPLC, cData.Name, cData.IOModuleBlock.UnitS[i], IMG_INDEX_UNIT,
                    cData.IOModuleBlock.UnitS[i]);

        }

        private bool CheckSiemensUsed(CBlockUnit cUnit, string sPLCName)
        {
            bool bOK = false;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["I"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["I"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Q"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Q"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            return bOK;
        }

        private string CheckSiemensInputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["I"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["I"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }

        private string CheckSiemensOutputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Q"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Q"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }


        private bool CheckMelsecUsed(CBlockUnit cUnit, string sPLCName)
        {
            bool bOK = false;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["X"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["X"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Y"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Y"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            return bOK;
        }

        private string CheckMelsecInputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["X"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["X"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }

        private string CheckMelsecOutputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Y"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["Y"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }

        private bool CheckLSUsed(CBlockUnit cUnit, string sPLCName)
        {
            bool bOK = false;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["P"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["P"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["K"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["K"].UnitS[cUnit.RangeIndex].IsUsed)
                    bOK = true;
            }

            return bOK;
        }

        private string CheckLSInputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["P"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["P"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }

        private string CheckLSOutputRangeUsed(CBlockUnit cUnit, string sPLCName)
        {
            string sValue = string.Empty;

            if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["K"].UnitS.ContainsKey(cUnit.RangeIndex))
            {
                if (CProjectManager.LogicDataS[sPLCName].AddressBlockS["K"].UnitS[cUnit.RangeIndex].IsUsed)
                    sValue = "...";
                else
                    sValue = string.Empty;
            }

            return sValue;
        }

        private void exTreeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            string sValue = string.Empty;
            object obj = null;

            if (e.Column.FieldName == "Input")
            {
                obj = e.Node.GetValue(e.Column.AbsoluteIndex);

                if (obj.GetType() == typeof (string))
                {
                    sValue = (string) obj;
                    if (sValue.Equals("..."))
                        e.Appearance.BackColor = Color.DodgerBlue;
                }
            }

            if (e.Column.FieldName == "Output")
            {
                obj = e.Node.GetValue(e.Column.AbsoluteIndex);

                if (obj.GetType() == typeof (string))
                {
                    sValue = (string) obj;
                    if (sValue.Equals("..."))
                        e.Appearance.BackColor = Color.Firebrick;
                }
            }
        }

    }
}
