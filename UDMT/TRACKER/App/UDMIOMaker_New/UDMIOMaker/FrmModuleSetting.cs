using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using UDM.Common;

namespace UDMIOMaker
{
    public delegate void UEventHandlerModuleApplyClick();

    public partial class FrmModuleSetting : DevExpress.XtraEditors.XtraForm
    {
        private string m_sPLCName = string.Empty;
        private int m_iSlotNumber = -1;
        private int m_iSlotStart = -1;

        private bool m_bEdit = false;

        private CBlockUnitS m_cCloneUnitS = null;

        public event UEventHandlerModuleApplyClick UEventModuleApplyClicked;

        private Dictionary<string, List<string>> m_dicConfig = new Dictionary<string, List<string>>();

        public FrmModuleSetting()
        {
            InitializeComponent();
        }

        public string PLCName
        {
            get { return m_sPLCName; }
            set { m_sPLCName = value; }
        }

        private void SetPLCList()
        {
            cboPLCList.Properties.Items.Clear();

            if (m_sPLCName == string.Empty)
                return;

            foreach (var who in CProjectManager.LogicDataS)
                cboPLCList.Properties.Items.Add(who.Key);

            cboPLCList.EditValue = m_sPLCName;
        }

        private void SetSlotInformation()
        {
            cboSlotStart.Properties.Items.Clear();
            cboSlotSize.Properties.Items.Clear();

            for (int i = 0; i < 20; i++)
                cboSlotStart.Properties.Items.Add(string.Format("{0:00}", i));

            for (int i = 1; i < 9; i++)
                cboSlotSize.Properties.Items.Add(string.Format("{0:00}", i));

            cboSlotStart.EditValue = "00";
            cboSlotSize.EditValue = "02";
        }

        private bool LoadConfigXml()
        {
            bool bOK = false;

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

            m_dicConfig.Clear();

            if (emPLCMaker == EMPLCMaker.Rockwell)
            {
                
            }
            else if (emPLCMaker == EMPLCMaker.Siemens)
                bOK = LoadSiemensConfigXml();
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                bOK = LoadMelsecConfigXml();

            return bOK;
        }

        private bool LoadSiemensConfigXml()
        {
            bool bOK = true;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (!File.Exists(CProjectManager.MelsecModuleConfigPath))
                    return false;

                xmlDoc.Load(CProjectManager.S7ModuleConfigPath);
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/CONFIGURATION/MODULELIST/MODULE");
                XmlElement xmlElement;

                string sModuleName = string.Empty;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement)xmlNode;

                    sModuleName = xmlElement.GetAttribute("NAME");

                    if (sModuleName.Contains("IN"))
                        bOK = SetINModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("OUT"))
                        bOK = SetOUTModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("MIX"))
                        bOK = SetMIXModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("Intelli"))
                        bOK = SetIntelliModule(xmlNode.ChildNodes);
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool LoadMelsecConfigXml()
        {
            bool bOK = true;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (!File.Exists(CProjectManager.MelsecModuleConfigPath))
                    return false;

                xmlDoc.Load(CProjectManager.MelsecModuleConfigPath);
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/CONFIGURATION/MODULELIST/MODULE");
                XmlElement xmlElement;

                string sModuleName = string.Empty;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement) xmlNode;

                    sModuleName = xmlElement.GetAttribute("NAME");

                    if (sModuleName.Contains("IN"))
                        bOK = SetINModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("OUT"))
                        bOK = SetOUTModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("MIX"))
                        bOK = SetMIXModule(xmlNode.ChildNodes);
                    else if (sModuleName.Contains("Intelli"))
                        bOK = SetIntelliModule(xmlNode.ChildNodes);
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool SetINModule(XmlNodeList xmlNodeList)
        {
            bool bOK = false;

            try
            {
                exEditorIn.Items.Clear();

                m_dicConfig.Add("IN", new List<string>());

                string sInModule = string.Empty;
                XmlElement xmlElement;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement) xmlNode;

                    sInModule = xmlElement.GetAttribute("NAME");
                    exEditorIn.Items.Add(sInModule);
                    m_dicConfig["IN"].Add(sInModule);

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config IN Module Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool SetOUTModule(XmlNodeList xmlNodeList)
        {
            bool bOK = false;

            try
            {
                exEditorOut.Items.Clear();

                m_dicConfig.Add("OUT", new List<string>());

                string sOUTModule = string.Empty;
                XmlElement xmlElement;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement)xmlNode;

                    sOUTModule = xmlElement.GetAttribute("NAME");
                    exEditorOut.Items.Add(sOUTModule);
                    m_dicConfig["OUT"].Add(sOUTModule);

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config OUT Module Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool SetMIXModule(XmlNodeList xmlNodeList)
        {
            bool bOK = false;

            try
            {
                exEditorMix.Items.Clear();

                m_dicConfig.Add("MIX", new List<string>());

                string sMIXModule = string.Empty;
                XmlElement xmlElement;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement)xmlNode;

                    sMIXModule = xmlElement.GetAttribute("NAME");
                    exEditorMix.Items.Add(sMIXModule);
                    m_dicConfig["MIX"].Add(sMIXModule);

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config MIX Module Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool SetIntelliModule(XmlNodeList xmlNodeList)
        {
            bool bOK = false;

            try
            {
                exEditorIntelli.Items.Clear();

                m_dicConfig.Add("Intelli", new List<string>());

                string sIntelliModule = string.Empty;
                XmlElement xmlElement;

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    xmlElement = (XmlElement) xmlNode;

                    sIntelliModule = xmlElement.GetAttribute("NAME");
                    exEditorIntelli.Items.Add(sIntelliModule);
                    m_dicConfig["Intelli"].Add(sIntelliModule);

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Config INTELLI Module Load Fail", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private void SetModuleMenu()
        {
            LoadConfigXml();
        }

        private void SetSlotMenu()
        {
            exEditorBase.Items.Clear();
            exEditorExtend1.Items.Clear();
            exEditorExtend2.Items.Clear();

            for (int i = 0; i < 20; i++)
            {
                exEditorBase.Items.Add(string.Format("{0:00}", i));
                exEditorExtend1.Items.Add(string.Format("{0:00}", i));
                exEditorExtend2.Items.Add(string.Format("{0:00}", i));
            }
        }

        private void SetModuleGrid()
        {
            grdModule.DataSource = null;
            grdModule.DataSource = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Values.ToList();
            grdModule.RefreshDataSource();

            if(m_cCloneUnitS == null)
                m_cCloneUnitS = new CBlockUnitS();

            m_cCloneUnitS.Clear();

            foreach(CBlockUnit cUnit in CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Values)
                m_cCloneUnitS.Add(cUnit.RangeIndex, cUnit.Clone());
        }

        private void RemoveExistModuleValue()
        {
            int iRowHandle = grvModule.FocusedRowHandle;
            bool bOK = false;

            if (iRowHandle < 0)
                return;

            int iRangeIndex = (int)grvModule.GetRowCellValue(iRowHandle, colRangeIndex);
            CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex];

            if (cUnit.IsForceAssigned || cUnit.Module == string.Empty)
                return;

            cUnit.IOType = string.Empty;
            cUnit.Module = string.Empty;

            while (!bOK)
            {
                cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[++iRangeIndex];

                if (cUnit.IsForceAssigned)
                {
                    cUnit.Module = string.Empty;
                    cUnit.IOType = string.Empty;
                    cUnit.IsForceAssigned = false;
                    bOK = false;
                }
                else
                    bOK = true;
            }

            m_bEdit = true;
            grdModule.RefreshDataSource();
        }

        private void RemoveExistModuleValue(int iRowHandle)
        {
            bool bOK = false;

            if (iRowHandle < 0)
                return;

            int iRangeIndex = (int)grvModule.GetRowCellValue(iRowHandle, colRangeIndex);
            CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex];

            if (cUnit.IsForceAssigned || cUnit.Module == string.Empty)
                return;

            cUnit.IOType = string.Empty;
            cUnit.Module = string.Empty;

            while (!bOK)
            {
                cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[++iRangeIndex];

                if (cUnit.IsForceAssigned)
                {
                    cUnit.Module = string.Empty;
                    cUnit.IOType = string.Empty;
                    cUnit.IsForceAssigned = false;
                    bOK = false;
                }
                else
                    bOK = true;
            }

            m_bEdit = true;
            grdModule.RefreshDataSource();
        }

        private void RemoveModuleInformation()
        {
            GridCell[] cells = grvModule.GetSelectedCells();

            if (cells.Length < 0)
                return;

            foreach (var who in cells)
            {
                if (who.Column == colModuleName)
                {
                    object obj = grvModule.GetRow(who.RowHandle);

                    if (obj == null || obj.GetType() != typeof (CBlockUnit))
                        continue;

                    CBlockUnit cUnit = (CBlockUnit) obj;

                    if (cUnit.IsForceAssigned)
                        continue;
                    else
                        RemoveExistModuleValue(who.RowHandle);
                }
                else if (who.Column == colModuleDescription || who.Column == colNetwork)
                    grvModule.SetRowCellValue(who.RowHandle, who.Column, string.Empty);
            }
        }

        private void ClearSlotValue()
        {
            int iRowHandle = grvModule.FocusedRowHandle;
            bool bOK = false;
            string sSlot = string.Empty;

            if (iRowHandle < 0)
                return;

            int iRangeIndex = (int)grvModule.GetRowCellValue(iRowHandle, colRangeIndex);
            CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex];
            sSlot = cUnit.Slot;

            if (sSlot == string.Empty)
                return;

            cUnit.Slot = string.Empty;

            while (!bOK)
            {
                cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[++iRangeIndex];
                if (cUnit.Slot == sSlot)
                {
                    cUnit.Slot = string.Empty;
                    bOK = false;
                }
                else
                    bOK = true;
            }

            m_bEdit = true;
            grdModule.RefreshDataSource();
        }

        private void SetUserAssingInformation(string sValue, CBlockUnit cUnit)
        {
            RemoveExistModuleValue();

            cUnit.IOType = "Speical";
            cUnit.Module = sValue;
        }
        
        private void SetModuleInformation(string sValue)
        {
            string sParse = string.Empty;

            foreach (var who in m_dicConfig)
            {
                foreach (var who2 in who.Value)
                {
                    sParse = who2.Split(']')[1];

                    if (sParse == sValue)
                    {
                        if(who.Equals("IN"))
                            SetInCardInformation(who2);
                        else if(who.Equals("OUT"))
                            SetOutCardInformation(who2);
                        else if(who.Equals("MIX"))
                            SetMixCardInformation(who2);
                        else if(who.Equals("Intelli"))
                            SetIntelliCardInformation(who2);

                        break;
                    }
                }
            }
        }

        private void SetInCardInformation(string sCard)
        {
            RemoveExistModuleValue();

            int iRangeIndex = (int)grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
            CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;
            string sIOType = sCard.Split(']')[0].Replace("[", string.Empty);
            sCard = sCard.Split(']')[1];
            int iModuleCount = Convert.ToInt32(sIOType.Split('*')[1]) / 16;

            for (int i = 0; i < iModuleCount; i++)
            {
                if (cUnitS[iRangeIndex].IsForceAssigned)
                    break;

                if (i == 0)
                    cUnitS[iRangeIndex].IOType = sIOType;
                else
                    cUnitS[iRangeIndex].IsForceAssigned = true;

                cUnitS[iRangeIndex++].Module = sCard;
            }
        }

        private void SetOutCardInformation(string sCard)
        {
            RemoveExistModuleValue();

            int iRangeIndex = (int)grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
            CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;
            string sIOType = sCard.Split(']')[0].Replace("[", string.Empty);
            sCard = sCard.Split(']')[1];
            int iModuleCount = Convert.ToInt32(sIOType.Split('*')[1]) / 16;

            for (int i = 0; i < iModuleCount; i++)
            {
                if (cUnitS[iRangeIndex].IsForceAssigned)
                    break;

                if (i == 0)
                    cUnitS[iRangeIndex].IOType = sIOType;
                else
                    cUnitS[iRangeIndex].IsForceAssigned = true;

                cUnitS[iRangeIndex++].Module = sCard;
            }
        }

        private void SetMixCardInformation(string sCard)
        {
            RemoveExistModuleValue();

            int iRangeIndex = (int)grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
            CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;

            string sIOType = sCard.Split(']')[0].Replace("[", string.Empty);
            sCard = sCard.Split(']')[1];

            string sInputCount = sIOType.Split(',')[0];
            string sOutputCount = sIOType.Split(',')[1];

            int iInputCount = Convert.ToInt32(sInputCount.Split('*')[1]) / 16;
            int iOutputCount = Convert.ToInt32(sOutputCount.Split('*')[1]) / 16;

            int iModuleCount = iInputCount >= iOutputCount ? iInputCount : iOutputCount;

            for (int i = 0; i < iModuleCount; i++)
            {
                if (cUnitS[iRangeIndex].IsForceAssigned)
                    break;

                if (i == 0)
                    cUnitS[iRangeIndex].IOType = sIOType;
                else
                    cUnitS[iRangeIndex].IsForceAssigned = true;

                cUnitS[iRangeIndex++].Module = sCard;
            }
        }

        private void SetIntelliCardInformation(string sCard)
        {
            RemoveExistModuleValue();

            int iRangeIndex = (int)grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
            CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;
            string sIOType = sCard.Split(']')[0].Replace("[", string.Empty);
            sCard = sCard.Split(']')[1];

            for (int i = 0; i < 2; i++)
            {
                if (cUnitS[iRangeIndex].IsForceAssigned)
                    break;

                if (i == 0)
                    cUnitS[iRangeIndex].IOType = sIOType;
                else
                    cUnitS[iRangeIndex].IsForceAssigned = true;

                cUnitS[iRangeIndex++].Module = sCard;
            }
        }

        private bool CheckConfigExist(string sValue)
        {
            bool bOK = false;
            string sParse = string.Empty;

            if (m_dicConfig.Count == 0)
                return false;

            foreach (var who in m_dicConfig)
            {
                foreach (var who2 in who.Value)
                {
                    sParse = who2.Split(']')[1];

                    if (sParse == sValue)
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private bool SetMakerModuleInformation()
        {
            bool bOK = false;

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

            if (emPLCMaker == EMPLCMaker.Rockwell)
            {

            }
            else if (emPLCMaker == EMPLCMaker.Siemens)
                bOK = SetSiemensModuleInformation();
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                bOK = SetMelsecModuleInformation();

            return bOK;
        }

        private bool SetMelsecModuleInformation()
        {
            bool bOK = false;

            CBlockUnit cUnit;
            string sInformation = string.Empty;
            foreach (var who in CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS)
            {
                cUnit = who.Value;

                if (!cUnit.IsUsed)
                    continue;

                if (CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["X"].UnitS[cUnit.RangeIndex].IsUsed)
                    sInformation = GetFirstTagItemDescription(CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["X"].UnitS[cUnit.RangeIndex].TagItemS);

                if(sInformation == string.Empty && CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["Y"].UnitS[cUnit.RangeIndex].IsUsed)
                    sInformation = GetFirstTagItemDescription(CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["Y"].UnitS[cUnit.RangeIndex].TagItemS);

                if (sInformation != string.Empty)
                    cUnit.Description = sInformation;
            }

            bOK = true;

            return bOK;
        }


        private bool SetSiemensModuleInformation()
        {
            bool bOK = false;

            CBlockUnit cUnit;
            string sInformation = string.Empty;
            foreach (var who in CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS)
            {
                sInformation = string.Empty;

                cUnit = who.Value;

                if (!cUnit.IsUsed)
                    continue;

                if (CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["I"].UnitS[cUnit.RangeIndex].IsUsed)
                    sInformation = GetFirstTagItemDescription(CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["I"].UnitS[cUnit.RangeIndex].TagItemS);

                if (sInformation == string.Empty && CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["Q"].UnitS[cUnit.RangeIndex].IsUsed)
                    sInformation = GetFirstTagItemDescription(CProjectManager.LogicDataS[m_sPLCName].AddressBlockS["Q"].UnitS[cUnit.RangeIndex].TagItemS);

                if (sInformation != string.Empty)
                    cUnit.Description = sInformation;
            }

            bOK = true;

            return bOK;
        }

        private string GetFirstTagItemDescription(CTagItemS cItemS)
        {
            string sInfo = string.Empty;
            List<string> lstParse = null;
            int iCount = -1;

            foreach (var who in cItemS)
            {
                if (who.Description != string.Empty)
                {
                    lstParse = who.Description.Split('_').ToList();

                    if (lstParse.Count < 3)
                        iCount = lstParse.Count;
                    else
                        iCount = 3;

                    for (int i = 0; i < iCount; i++)
                    {
                        if (i == 0)
                            sInfo = lstParse[i];
                        else
                            sInfo += string.Format("_{0}", lstParse[i]);
                    }
                    break;
                }
            }

            return sInfo;
        }


        private void FrmModuleSetting_Load(object sender, EventArgs e)
        {
            try
            {
                SetPLCList();
                SetSlotInformation();

                SetModuleMenu();
                SetSlotMenu();
                SetModuleGrid();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnImportInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Address 영역에 포함된 선두 I/O 접점의 심볼 이름(Description) 3마디를 불러옵니다.\r\n계속 진행하시겠습니까?",
                    "모듈 설명 가져오기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                bool bOK = SetMakerModuleInformation();

                m_bEdit = true;

                if (bOK)
                    XtraMessageBox.Show("모듈 설명 가져오기 성공!!!", "Import Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                grdModule.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Import Information", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (UEventModuleApplyClicked != null)
                    UEventModuleApplyClicked();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting Apply Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_bEdit)
            {
                if (
                    XtraMessageBox.Show("수정된 내용이 존재합니다.\r\n그래도 창을 종료하시겠습니까?", "Information", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;
                else if(m_cCloneUnitS != null)
                {
                    CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Clear();

                    foreach(CBlockUnit cUnit in m_cCloneUnitS.Values)
                        CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Add(cUnit.RangeIndex, cUnit.Clone());
                }
            }

            this.Close();
        }

        private void cboSlotStart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSlotSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClearslot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ClearSlotValue();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Clear Slot error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvModule_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);

                    if (grvModule.FocusedColumn == colModuleName)
                        mnuModule.ShowPopup(CurrentPoint);
                    else if (grvModule.FocusedColumn == colSlot)
                        mnuSlot.ShowPopup(CurrentPoint);
                    else if (grvModule.FocusedColumn == colIOType)
                        mnuIOType.ShowPopup(CurrentPoint);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting mouse Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvModule_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string sUsed = string.Empty;
                var View = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                if (e.Column.FieldName == "AddressRange" && e.Appearance.BackColor != Color.Orange)
                {
                    e.Appearance.BackColor = Color.PaleTurquoise;
                    e.Appearance.BackColor2 = Color.PaleTurquoise;
                }

                if (e.Column.FieldName == "IOType" && e.Appearance.BackColor != Color.Orange &&
                    !colIOType.OptionsColumn.AllowEdit)
                {
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.BackColor2 = Color.Silver;
                }

                if (e.Column.FieldName == "Slot" && e.Appearance.BackColor != Color.Orange)
                {
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.BackColor2 = Color.Silver;
                }

                if (e.Column.FieldName == "Module")
                {
                    if (grvModule.GetRow(e.RowHandle).GetType() != typeof (CBlockUnit))
                        return;

                    CBlockUnit cUnit = (CBlockUnit) grvModule.GetRow(e.RowHandle);

                    if (cUnit.IsForceAssigned)
                    {
                        e.Appearance.BackColor = Color.Silver;
                        e.Appearance.BackColor2 = Color.Silver;
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module setting RowcellStyle Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboBaseSlot_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBaseSlot.EditValue == null)
                    return;

                string sSlotCount = (string) cboBaseSlot.EditValue;
                string sSlotStart = (string) cboSlotStart.EditValue;
                string sSlotSize = (string) cboSlotSize.EditValue;

                int iSlotCount = Convert.ToInt32(sSlotCount);
                int iSlotStart = Convert.ToInt32(sSlotStart);
                int iSlotSize = Convert.ToInt32(sSlotSize);

                int iRangeIndex = (int) grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
                CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;

                string sSlot = string.Empty;

                for (int i = 0; i < iSlotCount; i++)
                {
                    sSlot = string.Format("{0:00} BASE", iSlotStart++);

                    for (int j = 0; j < iSlotSize; j++)
                        cUnitS[iRangeIndex++].Slot = sSlot;
                }
                m_bEdit = true;
                grdModule.RefreshDataSource();

                cboBaseSlot.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Base Slot Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboExtend1Slot_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboExtend1Slot.EditValue == null)
                    return;

                string sSlotCount = (string) cboExtend1Slot.EditValue;
                string sSlotStart = (string) cboSlotStart.EditValue;
                string sSlotSize = (string) cboSlotSize.EditValue;

                int iSlotCount = Convert.ToInt32(sSlotCount);
                int iSlotStart = Convert.ToInt32(sSlotStart);
                int iSlotSize = Convert.ToInt32(sSlotSize);

                int iRangeIndex = (int) grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
                CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;

                string sSlot = string.Empty;

                for (int i = 0; i < iSlotCount; i++)
                {
                    sSlot = string.Format("{0:00} EXT1", iSlotStart++);

                    for (int j = 0; j < iSlotSize; j++)
                        cUnitS[iRangeIndex++].Slot = sSlot;
                }
                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboExtend1Slot.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Extend1 Slot Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboExtend2Slot_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboExtend2Slot.EditValue == null)
                    return;

                string sSlotCount = (string) cboExtend2Slot.EditValue;
                string sSlotStart = (string) cboSlotStart.EditValue;
                string sSlotSize = (string) cboSlotSize.EditValue;

                int iSlotCount = Convert.ToInt32(sSlotCount);
                int iSlotStart = Convert.ToInt32(sSlotStart);
                int iSlotSize = Convert.ToInt32(sSlotSize);

                int iRangeIndex = (int) grvModule.GetRowCellValue(grvModule.FocusedRowHandle, colRangeIndex);
                CBlockUnitS cUnitS = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS;

                string sSlot = string.Empty;

                for (int i = 0; i < iSlotCount; i++)
                {
                    sSlot = string.Format("{0:00} EXT2", iSlotStart++);

                    for (int j = 0; j < iSlotSize; j++)
                        cUnitS[iRangeIndex++].Slot = sSlot;
                }
                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboExtend2Slot.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Extend2 Slot Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboInCard_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboInCard.EditValue == null)
                    return;

                string sCard = (string) cboInCard.EditValue;
                if (sCard == string.Empty)
                    return;

                SetInCardInformation(sCard);

                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboInCard.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("InCard  Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboOutCard_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboOutCard.EditValue == null)
                    return;

                string sCard = (string) cboOutCard.EditValue;
                if (sCard == string.Empty)
                    return;

                SetOutCardInformation(sCard);
                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboOutCard.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("OutCard  Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboMixCard_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMixCard.EditValue == null)
                    return;

                string sCard = (string) cboMixCard.EditValue;
                if (sCard == string.Empty)
                    return;

                SetMixCardInformation(sCard);
                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboMixCard.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("MixCard  Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboInteliCard_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboInteliCard.EditValue == null)
                    return;

                string sCard = (string) cboInteliCard.EditValue;
                if (sCard == string.Empty)
                    return;

                SetIntelliCardInformation(sCard);
                m_bEdit = true;
                grdModule.RefreshDataSource();
                cboInteliCard.EditValue = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("IntelliCard  Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvModule_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string sValue = grvModule.GetFocusedDisplayText();
                int iRowHandle = grvModule.FocusedRowHandle;

                if (iRowHandle < 0 || sValue == string.Empty)
                    return;

                if (grvModule.FocusedColumn != colModuleName)
                    return;

                int iRowIndex = (int) grvModule.GetRowCellValue(iRowHandle, colRangeIndex);
                CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRowIndex];

                if (CheckConfigExist(sValue))
                    SetModuleInformation(sValue);
                else
                    SetUserAssingInformation(sValue, cUnit);
                m_bEdit = true;
                grdModule.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Cell Value Change  Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvModule_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (grvModule.GetRow(grvModule.FocusedRowHandle).GetType() != typeof (CBlockUnit))
                    return;

                CBlockUnit cUnit = (CBlockUnit) grvModule.GetRow(grvModule.FocusedRowHandle);

                if (grvModule.FocusedColumn.FieldName == "Module" && cUnit.IsForceAssigned)
                    e.Cancel = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting ShowingEditor Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRemoveModuleName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RemoveExistModuleValue();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Remove Module Name error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tgsIOTypeEditable_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tgsIOTypeEditable.Checked)
                colIOType.OptionsColumn.AllowEdit = true;
            else
                colIOType.OptionsColumn.AllowEdit = false;
        }

        private void grvModule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    RemoveModuleInformation();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ModuleSetting KeyDown Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmModuleSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(m_cCloneUnitS != null)
                    m_cCloneUnitS.Clear();

                m_cCloneUnitS = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ModuleSetting FormClosed Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboPLCList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null)
                    return;

                if (m_bEdit)
                {
                    if (
    XtraMessageBox.Show("수정된 내용이 존재합니다.\r\n수정된 내용을 적용하시겠습니까?", "Information", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        if (m_cCloneUnitS != null)
                        {
                            CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Clear();

                            foreach (CBlockUnit cUnit in m_cCloneUnitS.Values)
                                CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS.Add(cUnit.RangeIndex, cUnit.Clone());
                        }
                    }
                }

                m_bEdit = false;

                string sPLCName = (string) cboPLCList.EditValue;
                m_sPLCName = sPLCName;

                SetModuleMenu();
                SetModuleGrid();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ModuleSetting SElectedValueChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }
}