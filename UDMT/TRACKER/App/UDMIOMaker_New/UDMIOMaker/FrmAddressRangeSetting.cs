using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmAddressRangeSetting : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, CBlockView> m_dicBlockView = new Dictionary<string, CBlockView>(); 
        private Dictionary<int, CRangeView> m_dicRangeView = new Dictionary<int, CRangeView>();
        private string m_sPLCName = string.Empty;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        private bool m_bEdit = false;
        private bool m_bSymbolEdit = false;
        private bool m_bKeyAutoChange = true;

        private CBlockUnit m_cCopyUnit = null;
        private FrmSymbolNameEdit m_frmSymboNameEdit = null;

        private UCMelsecAddressArea m_ucMelsecArea = null;
        private UCSiemensAddressArea m_ucSiemensArea = null;
        private UCLSAddressArea m_ucLSArea = null;


        public FrmAddressRangeSetting()
        {
            InitializeComponent();
        }

        public string PLCName
        {
            get { return m_sPLCName; }
            set { m_sPLCName = value; }
        }


        #region Private Methods

        private void SetPLCNameList()
        {
            exEditorPLCName.Items.Clear();
            foreach (var who in CProjectManager.LogicDataS)
                exEditorPLCName.Items.Add(who.Key);

            cboPLCName.EditValue = CProjectManager.LogicDataS.First().Key;
        }

        private void SetListType()
        {
            exEditorListType.Items.Clear();

            exEditorListType.Items.Add("ALL_LIST");
            exEditorListType.Items.Add("IO_LIST");
            exEditorListType.Items.Add("DUMMY_LIST");
            exEditorListType.Items.Add("LINK_LIST");
            exEditorListType.Items.Add("TIMER_COUNT_LIST");

            cboListType.EditValue = "ALL_LIST";
        }

        private void SetMelsecAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();
                m_dicBlockView.Clear();

                CBlock cBlock;
                CRangeView cView;
                CBlockView cBlockView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 12287; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetMelsecAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetMelsecAreaInfo(cView, cBlock);
                        }
                    }
                    cBlockView = new CBlockView();
                    cBlockView.BlockName = who.Key;
                    cBlockView.StartAddress = cBlock.GetFirstBlockUnit();
                    cBlockView.EndAddress = cBlock.GetLastBlockUnit();

                    m_dicBlockView.Add(who.Key, cBlockView);

                    cBlock = null;
                }

                SetMelsecUserControl();
                ShowAddressTypeGrid();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetSiemensAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();
                m_dicBlockView.Clear();

                CBlock cBlock;
                CRangeView cView;
                CBlockView cBlockView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 65535; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetSiemensAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetSiemensAreaInfo(cView, cBlock);
                        }
                    }

                    cBlockView = new CBlockView();
                    cBlockView.BlockName = who.Key;
                    cBlockView.StartAddress = cBlock.GetFirstBlockUnit();
                    cBlockView.EndAddress = cBlock.GetLastBlockUnit();

                    m_dicBlockView.Add(who.Key, cBlockView);

                    cBlock = null;
                }
                SetSiemensUserControl();
                ShowAddressTypeGrid();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetSiemensAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "I":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.IArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsIFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertIArea = true;
                    break;
                case "Q":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.QArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsQFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertQArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "DB":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DBArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDBFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDBArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }

        private void SetSiemensUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucSiemensArea = new UCSiemensAddressArea();
            m_ucSiemensArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucSiemensArea);

            m_ucSiemensArea.PLCName = m_sPLCName;
            m_ucSiemensArea.IsViewPopmenu = true;
            m_ucSiemensArea.RangeViewS = m_dicRangeView;
            m_ucSiemensArea.UEventGridCellClick += ucAddressArea_GridCellClick;

            ShowAddressArea();
        }

        private void SetMelsecUserControl()
        {
            m_ucMelsecArea = new UCMelsecAddressArea();
            m_ucMelsecArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucMelsecArea);

            m_ucMelsecArea.PLCName = m_sPLCName;
            m_ucMelsecArea.IsViewPopmenu = true;
            m_ucMelsecArea.RangeViewS = m_dicRangeView;
            m_ucMelsecArea.UEventMelsecGridCellClick += ucAddressArea_GridCellClick;

            ShowAddressArea();
        }

        private void ShowAddressArea()
        {
            try
            {
                if (cboListType.EditValue == null)
                    return;

                string sList = (string) cboListType.EditValue;
                SetListTypeChangeView(sList);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Show Address Area Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetMelsecAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "X":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.XArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsXFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertXArea = true;
                    break;
                case "Y":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.YArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsYFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertYArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "L":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.LArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsLFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertLArea = true;
                    break;
                case "D":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDArea = true;
                    break;
                case "B":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.BArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsBFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertBArea = true;
                    break;
                case "W":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.WArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsWFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertWArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }

        private void SetLSAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();
                m_dicBlockView.Clear();

                CBlock cBlock;
                CRangeView cView;
                CBlockView cBlockView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 25000; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetLSAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetLSAreaInfo(cView, cBlock);
                        }
                    }
                    cBlockView = new CBlockView();
                    cBlockView.BlockName = who.Key;
                    cBlockView.StartAddress = cBlock.GetFirstBlockUnit();
                    cBlockView.EndAddress = cBlock.GetLastBlockUnit();

                    m_dicBlockView.Add(who.Key, cBlockView);

                    cBlock = null;
                }
                SetLSUserControl();
                ShowAddressTypeGrid();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("LS Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucLSArea = new UCLSAddressArea();
            m_ucLSArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucLSArea);

            m_ucLSArea.PLCName = m_sPLCName;
            m_ucLSArea.IsViewPopmenu = true;
            m_ucLSArea.RangeViewS = m_dicRangeView;
            m_ucLSArea.GroupPanelText = "Cell을 더블클릭하시면 해당 Cell의 영역에 포함된 PLC 심볼이 왼쪽 표에 나타납니다.";
            m_ucLSArea.UEventGridCellClick += ucAddressArea_GridCellClick;

            ShowAddressArea();
        }

        private void SetLSAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "P":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.PArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsPFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertPArea = true;
                    break;
                case "K":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.KArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsKFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertKArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "L":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.LArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsLFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertLArea = true;
                    break;
                case "D":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDArea = true;
                    break;
                case "N":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.NArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsNFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertNArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }

        private void ShowAddressTypeGrid()
        {
            grdAddressType.DataSource = m_dicBlockView.Values.ToList();
            grdAddressType.RefreshDataSource();
        }

        private void ClearAllInformation()
        {
            grpAddressArea.Controls.Clear();
            grdAddressType.DataSource = null;
            grdAddressType.RefreshDataSource();
            grdSelectedArea.DataSource = null;
            grdSelectedArea.RefreshDataSource();

            m_cCopyUnit = null;
        }

        private List<string> GetParseDescription(List<string> lstDescription)
        {
            List<string> lstParse = new List<string>();

            List<string> lstTemp = null;

            Dictionary<int, List<string>> dicSplit = new Dictionary<int, List<string>>();
            List<string> lstSplit = null;
            int iMinCount = -1;
            string sSplit = string.Empty;
            bool bSame = true;

            for (int i = 0; i < lstDescription.Count; i++)
            {
                lstSplit = new List<string>();
                lstTemp = lstDescription[i].Split('_').ToList();

                if (lstTemp == null)
                    continue;

                if (i == 0)
                    iMinCount = lstTemp.Count;

                if (iMinCount > lstTemp.Count)
                    iMinCount = lstTemp.Count;

                lstSplit.AddRange(lstTemp);
                dicSplit.Add(i, lstSplit);
            }

            for (int i = 0; i < iMinCount; i++)
            {
                foreach (var who in dicSplit)
                {
                    if (sSplit == string.Empty)
                        sSplit = who.Value[i];
                    else if (sSplit != who.Value[i])
                    {
                        bSame = false;
                        break;
                    }
                    else if (sSplit == who.Value[i])
                        bSame = true;
                }

                if (bSame)
                    lstParse.Add(sSplit);
                else
                    lstParse.Add(string.Empty);

                sSplit = string.Empty;
            }
            return lstParse;
        }

        private void SetMakerAddressArea()
        {
            if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensAddressArea(m_sPLCName);
            else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecAddressArea(m_sPLCName);
            else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                SetLSAddressArea(m_sPLCName);
        }

        private void SetListTypeChangeView(string sType)
        {
            if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                m_ucSiemensArea.ShowAddressArea(sType, chkAddressMaxView.Checked, chkUsedAreaView.Checked);
            else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                m_ucMelsecArea.ShowAddressArea(sType, chkAddressMaxView.Checked, chkUsedAreaView.Checked);
            else if(m_emPLCMaker.Equals(EMPLCMaker.LS))
                m_ucLSArea.ShowAddressArea(sType, chkAddressMaxView.Checked, chkUsedAreaView.Checked);
        }

        private bool CheckEdit()
        {
            bool bOK = false;

            if (m_bEdit)
                return true;

            if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (m_ucSiemensArea.IsEdit)
                    bOK = true;
            }
            else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (m_ucMelsecArea.IsEdit)
                    bOK = true;
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (m_ucLSArea.IsEdit)
                    bOK = true;
            }

            return bOK;
        }

        private void Standardization(int[] arrRows)
        {
            try
            {
                CTagItem cItem;
                string sNewDesc = string.Empty;
                foreach (int iRowHandle in arrRows)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvSelectedArea.GetRow(iRowHandle) == null)
                        continue;

                    if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                        continue;

                    cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);

                    if (!cItem.Description.Contains("_"))
                        continue;

                    sNewDesc = GetStandardizationDesc(cItem.Description);

                    if (cItem.Description != sNewDesc)
                        cItem.Description = sNewDesc;
                }

                grdSelectedArea.RefreshDataSource();

            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Standardization Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private string GetStandardizationDesc(string sCurDesc)
        {
            string sNewDesc = string.Empty;
            string sParse = string.Empty;
            string sNewParse = string.Empty;
            List<string> lstParse = sCurDesc.Split('_').ToList();

            if (lstParse == null || lstParse.Count == 0)
                return sNewDesc;

            for (int i = 0; i < lstParse.Count; i++)
            {
                sParse = lstParse[i].ToUpper();

                if (sParse.Contains("["))
                    sNewParse = GetDescParseContainBracket(sParse);
                else if (Regex.IsMatch(sParse, "[0-9]"))
                    sNewParse = GetDescParseContainNumber(sParse);
                else if (CProjectManager.StdS.ContainsKey(sParse))
                    sNewParse = CProjectManager.StdS[sParse].TargetName;
                else
                    sNewParse = sParse;

                sNewDesc += string.Format("{0}_", sNewParse);
            }

            sNewDesc = sNewDesc.Substring(0, sNewDesc.Length - 1);

            return sNewDesc;
        }

        //BT[1]과 같은 경우 Standardization
        private string GetDescParseContainBracket(string sCurParse)
        {
            string sNewParse = sCurParse;

            string sConvertHeader = sCurParse.Split('[')[0];
            string sConvertTail = sCurParse.Split('[')[1].Replace("]", string.Empty);

            if (sConvertHeader == string.Empty)
                return sNewParse;

            if (CProjectManager.StdS.ContainsKey(sConvertHeader))
            {
                string sTarget = CProjectManager.StdS[sConvertHeader].TargetName;

                if (sTarget != sConvertHeader)
                    sNewParse = string.Format("{0}[{1}]", sTarget, sConvertTail);
            }
            else if (Regex.IsMatch(sConvertHeader, "[0-9]"))
            {
                string sTarget = GetDescParseContainNumber(sConvertHeader);

                if (sTarget != sConvertHeader)
                    sNewParse = string.Format("{0}[{1}]", sTarget, sConvertTail);
            }

            return sNewParse;
        }

        private string GetDescParseContainNumber(string sCurParse)
        {
            string sNewParse = sCurParse;

            string sValueExceptNumeric = Regex.Replace(sCurParse, "[0-9]", " ");
            string[] arrValue = sValueExceptNumeric.Split(' ');

            foreach (string sValue in arrValue)
            {
                if (sValue == string.Empty)
                    continue;

                if (CProjectManager.StdS.ContainsKey(sValue))
                {
                    string sTarget = CProjectManager.StdS[sValue].TargetName;

                    if (sValue != sTarget)
                        sNewParse = sCurParse.Replace(sValue, sTarget);
                }
            }

            return sNewParse;
        }

        #endregion



        private void ucAddressArea_GridCellClick(CTagItemS cItemS, string sStart, string sEnd, string sCount, string sModule, string sDescription)
        {
            grdSelectedArea.DataSource = cItemS;
            grdSelectedArea.RefreshDataSource();

            //lblSelectStart.Text = sStart;
            //lblSelectEnd.Text = sEnd;
            //lblSelectCount.Text = sCount;

            txtModule.Text = sModule;
            txtDescription.Text = sDescription;
        }

        private void FrmSymbolNameEdit_UEventNameEdit(string sDescription)
        {
            int[] arrRow = grvSelectedArea.GetSelectedRows();

            if (arrRow.Length < 1)
            {
                XtraMessageBox.Show("Name을 변경하고자 하는 Symbol을 선택하지 않았습니다.\r\nSymbol을 선택하세요.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CTagItem cItem;
            foreach (int iRowHandle in arrRow)
            {
                if (iRowHandle < 0)
                    continue;

                if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                    continue;

                cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);

                if (cItem.Description != sDescription)
                    m_bEdit = true;

                cItem.Description = sDescription;
            }

            grdSelectedArea.RefreshDataSource();
        }

        private void FrmAddressRangeSetting_Load(object sender, EventArgs e)
        {
            try
            {
                tgsSymbolEdit.IsOn = true;

                SetPLCNameList();
                SetListType();

                string sPLCName = CProjectManager.LogicDataS.First().Key;
                m_sPLCName = sPLCName;
                m_emPLCMaker = CProjectManager.LogicDataS.First().Value.PLCMaker;

                SetMakerAddressArea();

                m_frmSymboNameEdit = new FrmSymbolNameEdit();
                m_frmSymboNameEdit.TopMost = true;
                m_frmSymboNameEdit.UEventNameEdit += FrmSymbolNameEdit_UEventNameEdit;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Address Range Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (cboPLCName.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCName.EditValue;

                if (m_sPLCName == sPLCName)
                    return;

                m_dicRangeView.Clear();
                ClearAllInformation();

                SetListType();
                m_sPLCName = sPLCName;
                m_emPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

                SetMakerAddressArea();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Adress Range Apply Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckEdit())
            {
                if (
                    XtraMessageBox.Show("수정하신 부분이 존재합니다.\r\n수정하신 내용을 반영하시겠습니까?", "Apply", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;
            }

            //Save
            this.Close();
        }

        private void cboListType_EditValueChanged(object sender, EventArgs e)
        {
            ShowAddressArea();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckEdit())
            {
                if (
                    XtraMessageBox.Show("수정하신 부분이 존재합니다.\r\n그래도 닫으시겠습니까?", "Close", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                    return;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void chkUsedAreaView_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddressArea();
        }

        private void chkAddressMaxView_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddressArea();
        }

        private void tgsSymbolEdit_Toggled(object sender, EventArgs e)
        {
            if (tgsSymbolEdit.IsOn)
            {
                m_bSymbolEdit = true;
                colSelectedDescription.OptionsColumn.AllowEdit = true;
            }
            else
            {
                m_bSymbolEdit = false;
                colSelectedDescription.OptionsColumn.AllowEdit = false;
            }
        }

        private void grvSelectedArea_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                m_bEdit = true;

                if (m_bKeyAutoChange)
                {
                    int[] arrRow = grvSelectedArea.GetSelectedRows();

                    if (arrRow == null || arrRow.Length < 1)
                        return;

                    CTagItem cItem;
                    foreach (int iRowHandle in arrRow)
                    {
                        if (iRowHandle < 0)
                            continue;

                        if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof(CTagItem))
                            continue;

                        cItem = (CTagItem)grvSelectedArea.GetRow(iRowHandle);
                        if (cItem.Description.Contains(" "))
                            cItem.Description = cItem.Description.Replace(" ", "_");
                    }
                    cItem = null;
                    grdSelectedArea.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("address Area Cellvalue Changed Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmAddressRangeSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_frmSymboNameEdit.UEventNameEdit -= FrmSymbolNameEdit_UEventNameEdit;
            m_frmSymboNameEdit.Dispose();

            m_frmSymboNameEdit = null;
        }

        private void grvSelectedArea_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!m_frmSymboNameEdit.IsLoad)
                        return;

                    int[] arrRow = grvSelectedArea.GetSelectedRows();
                    List<string> lstDescription = new List<string>();

                    CTagItem cItem;
                    foreach (int iRowHandle in arrRow)
                    {
                        if (iRowHandle < 0)
                            continue;

                        if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                            continue;

                        cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);
                        lstDescription.Add(cItem.Description);
                    }

                    List<string> lstParse = GetParseDescription(lstDescription);

                    if (lstParse.Count != 0)
                        m_frmSymboNameEdit.SetParseView(lstParse);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuSelectedArea.ShowPopup(CurrentPoint);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("address Area Mouse Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSymbolNameSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                m_frmSymboNameEdit.Show();
                m_frmSymboNameEdit.IsLoad = true;

                int[] arrRow = grvSelectedArea.GetSelectedRows();
                List<string> lstDescription = new List<string>();

                CTagItem cItem;
                foreach (int iRowHandle in arrRow)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                        continue;

                    cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);
                    lstDescription.Add(cItem.Description);
                }

                List<string> lstParse = GetParseDescription(lstDescription);

                if (lstParse.Count != 0)
                    m_frmSymboNameEdit.SetParseView(lstParse);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Name Edit Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvSelectedArea_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //string sUsed = string.Empty;
            //var View = sender as GridView;

            //if (e.RowHandle < 0)
            //    return;

            //if (e.Column.FieldName == "Address")
            //{
            //    if (e.Appearance.BackColor != Color.Orange)
            //        e.Appearance.BackColor = Color.PaleTurquoise;
            //}

            //if (e.Column.FieldName == "Description")
            //{
            //    if (e.Appearance.BackColor != Color.Orange)
            //    {
            //        if (!m_bSymbolEdit)
            //            e.Appearance.BackColor = Color.FromArgb(224, 224, 224);
            //        else
            //            e.Appearance.BackColor = Color.White;
            //    }
            //}

            //if (e.Column.FieldName == "DataType")
            //{
            //    if (e.Appearance.BackColor != Color.Orange)
            //        e.Appearance.BackColor = Color.FromArgb(224, 224, 224);
            //}

        }

        private void grvSelectedArea_LostFocus(object sender, EventArgs e)
        {

        }

        private void btnSelectedSymbolNameClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("해당 심볼의 이름을 지우시겠습니까?", "Symbol Name Clear", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int[] arrRow = grvSelectedArea.GetSelectedRows();

                CTagItem cItem;
                foreach (int iRowHandle in arrRow)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                        continue;

                    cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);
                    cItem.Description = string.Empty;
                }

                grdSelectedArea.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol name Clear Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmAddressRangeSetting_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void grvSelectedArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!m_bSymbolEdit)
                {
                    if (
                        XtraMessageBox.Show("현재 Symbol 수정모드가 아닙니다.\r\n수정모드로 전환하시겠습니까?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    else
                        tgsSymbolEdit.IsOn = true;
                }

                int[] arrRow = grvSelectedArea.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                    return;

                if (e.KeyCode == Keys.Delete)
                {
                    if (
                        XtraMessageBox.Show("해당 심볼의 이름을 지우시겠습니까?", "Symbol Name Clear", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    CTagItem cItem;
                    foreach (int iRowHandle in arrRow)
                    {
                        if (iRowHandle < 0)
                            continue;

                        if (grvSelectedArea.GetRow(iRowHandle).GetType() != typeof (CTagItem))
                            continue;

                        cItem = (CTagItem) grvSelectedArea.GetRow(iRowHandle);
                        cItem.Description = string.Empty;
                    }
                    grdSelectedArea.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol name Clear Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkKeyChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeyChange.Checked)
                m_bKeyAutoChange = true;
            else
                m_bKeyAutoChange = false;
        }

        private void btnStandardization_Click(object sender, EventArgs e)
        {
            try
            {
                int[] arrRows = grvSelectedArea.GetSelectedRows();

                if (arrRows == null || arrRows.Length < 1)
                    return;

                if (
                    XtraMessageBox.Show("선택하신 " + arrRows.Length + "개의 심볼의 표준화 작업을 진행하시겠습니까?", "Standardization",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                Standardization(arrRows);
                m_bEdit = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Standardization Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }

    public class CBlockView
    {
        private string m_sBlockName = string.Empty;
        private string m_sStartAddress = string.Empty;
        private string m_sEndAddress = string.Empty;

        public string BlockName
        {
            get { return m_sBlockName; }
            set { m_sBlockName = value; }
        }

        public string StartAddress
        {
            get { return m_sStartAddress; }
            set { m_sStartAddress = value; }
        }

        public string EndAddress
        {
            get { return m_sEndAddress;}
            set { m_sEndAddress = value; }
        }
    }

    public class CRangeView
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        private int m_iRangeIndex = -1;
        private string m_sXArea = string.Empty;
        private bool m_bXUsedFull = false;
        private bool m_bInsertXArea = false;

        private string m_sYArea = string.Empty;
        private bool m_bYUsedFull = false;
        private bool m_bInsertYArea = false;

        private string m_sMArea = string.Empty;
        private bool m_bMUsedFull = false;
        private bool m_bInsertMArea = false;

        private string m_sLArea = string.Empty;
        private bool m_bLUsedFull = false;
        private bool m_bInsertLArea = false;

        private string m_sDArea = string.Empty;
        private bool m_bDUsedFull = false;
        private bool m_bInsertDArea = false;

        private string m_sBArea = string.Empty;
        private bool m_bBUsedFull = false;
        private bool m_bInsertBArea = false;

        private string m_sWArea = string.Empty;
        private bool m_bWUsedFull = false;
        private bool m_bInsertWArea = false;

        private string m_sTArea = string.Empty;
        private bool m_bTUsedFull = false;
        private bool m_bInsertTArea = false;

        private string m_sCArea = string.Empty;
        private bool m_bCUsedFull = false;
        private bool m_bInsertCArea = false;

        private string m_sIArea = string.Empty;
        private bool m_bIUsedFull = false;
        private bool m_bInsertIArea = false;

        private string m_sOArea = string.Empty;
        private bool m_bOUsedFull = false;
        private bool m_bInsertOArea = false;

        private string m_sQArea = string.Empty;
        private bool m_bQUsedFull = false;
        private bool m_bInsertQArea = false;

        private string m_sDBArea = string.Empty;
        private bool m_bDBUsedFull = false;
        private bool m_bInsertDBArea = false;

        private string m_sHArea = string.Empty;
        private bool m_bHUsedFull = false;
        private bool m_bInsertHArea = false;

        private string m_sNArea = string.Empty;
        private bool m_bNUsedFull = false;
        private bool m_bInsertNArea = false;

        private string m_sSArea = string.Empty;
        private bool m_bSUsedFull = false;
        private bool m_bInsertSArea = false;

        private string m_sPArea = string.Empty;
        private bool m_bPUsedFull = false;
        private bool m_bInsertPArea = false;

        private string m_sKArea = string.Empty;
        private bool m_bKUsedFull = false;
        private bool m_bInsertKArea = false;

        #region Properties

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }

        public string AddressArea
        {
            get { return GetAddressArea();}
        }

        public int RangeIndex
        {
            get { return m_iRangeIndex;}
            set { m_iRangeIndex = value; }
        }

        public string IArea
        {
            get { return m_sIArea; }
            set { m_sIArea = value; }
        }

        public bool IsIFull
        {
            get { return m_bIUsedFull; }
            set { m_bIUsedFull = value; }
        }

        public bool IsInsertIArea
        {
            get { return m_bInsertIArea; }
            set { m_bInsertIArea = value; }
        }

        public string PArea
        {
            get { return m_sPArea; }
            set { m_sPArea = value; }
        }

        public bool IsPFull
        {
            get { return m_bPUsedFull; }
            set { m_bPUsedFull = value; }
        }

        public bool IsInsertPArea
        {
            get { return m_bInsertPArea; }
            set { m_bInsertPArea = value; }
        }

        public string KArea
        {
            get { return m_sKArea; }
            set { m_sKArea = value; }
        }

        public bool IsKFull
        {
            get { return m_bKUsedFull; }
            set { m_bKUsedFull = value; }
        }

        public bool IsInsertKArea
        {
            get { return m_bInsertKArea; }
            set { m_bInsertKArea = value; }
        }

        public string OArea
        {
            get { return m_sOArea; }
            set { m_sOArea = value; }
        }

        public bool IsOFull
        {
            get { return m_bOUsedFull; }
            set { m_bOUsedFull = value; }
        }

        public bool IsInsertOArea
        {
            get { return m_bInsertOArea; }
            set { m_bInsertOArea = value; }
        }

        public string QArea
        {
            get { return m_sQArea; }
            set { m_sQArea = value; }
        }

        public bool IsQFull
        {
            get { return m_bQUsedFull; }
            set { m_bQUsedFull = value; }
        }

        public bool IsInsertQArea
        {
            get { return m_bInsertQArea; }
            set { m_bInsertQArea = value; }
        }

        public string DBArea
        {
            get { return m_sDBArea; }
            set { m_sDBArea = value; }
        }

        public bool IsDBFull
        {
            get { return m_bDBUsedFull; }
            set { m_bDBUsedFull = value; }
        }

        public bool IsInsertDBArea
        {
            get { return m_bInsertDBArea; }
            set { m_bInsertDBArea = value; }
        }

        public string XArea
        {
            get { return m_sXArea; }
            set { m_sXArea = value; }
        }

        public bool IsXFull
        {
            get { return m_bXUsedFull; }
            set { m_bXUsedFull = value; }
        }

        public bool IsInsertXArea
        {
            get { return m_bInsertXArea; }
            set { m_bInsertXArea = value; }
        }

        public string YArea
        {
            get { return m_sYArea; }
            set { m_sYArea = value; }
        }

        public bool IsYFull
        {
            get { return m_bYUsedFull; }
            set { m_bYUsedFull = value; }
        }

        public bool IsInsertYArea
        {
            get { return m_bInsertYArea; }
            set { m_bInsertYArea = value; }
        }

        public string MArea
        {
            get { return m_sMArea; }
            set { m_sMArea = value; }
        }

        public bool IsMFull
        {
            get { return m_bMUsedFull; }
            set { m_bMUsedFull = value; }
        }

        public bool IsInsertMArea
        {
            get { return m_bInsertMArea; }
            set { m_bInsertMArea = value; }
        }

        public string LArea
        {
            get { return m_sLArea; }
            set { m_sLArea = value; }
        }

        public bool IsLFull
        {
            get { return m_bLUsedFull; }
            set { m_bLUsedFull = value; }
        }

        public bool IsInsertLArea
        {
            get { return m_bInsertLArea; }
            set { m_bInsertLArea = value; }
        }

        public string DArea
        {
            get { return m_sDArea; }
            set { m_sDArea = value; }
        }

        public bool IsDFull
        {
            get { return m_bDUsedFull; }
            set { m_bDUsedFull = value; }
        }

        public bool IsInsertDArea
        {
            get { return m_bInsertDArea; }
            set { m_bInsertDArea = value; }
        }

        public string BArea
        {
            get { return m_sBArea; }
            set { m_sBArea = value; }
        }

        public bool IsBFull
        {
            get { return m_bBUsedFull; }
            set { m_bBUsedFull = value; }
        }

        public bool IsInsertBArea
        {
            get { return m_bInsertBArea; }
            set { m_bInsertBArea = value; }
        }

        public string WArea
        {
            get { return m_sWArea; }
            set { m_sWArea = value; }
        }

        public bool IsWFull
        {
            get { return m_bWUsedFull; }
            set { m_bWUsedFull = value; }
        }

        public bool IsInsertWArea
        {
            get { return m_bInsertWArea; }
            set { m_bInsertWArea = value; }
        }

        public string TArea
        {
            get { return m_sTArea; }
            set { m_sTArea = value; }
        }

        public bool IsTFull
        {
            get { return m_bTUsedFull; }
            set { m_bTUsedFull = value; }
        }

        public bool IsInsertTArea
        {
            get { return m_bInsertTArea; }
            set { m_bInsertTArea = value; }
        }

        public string CArea
        {
            get { return m_sCArea; }
            set { m_sCArea = value; }
        }

        public bool IsCFull
        {
            get { return m_bCUsedFull; }
            set { m_bCUsedFull = value; }
        }

        public bool IsInsertCArea
        {
            get { return m_bInsertCArea; }
            set { m_bInsertCArea = value; }
        }

        public string HArea
        {
            get { return m_sHArea; }
            set { m_sHArea = value; }
        }

        public bool IsHFull
        {
            get { return m_bHUsedFull; }
            set { m_bHUsedFull = value; }
        }

        public bool IsInsertHArea
        {
            get { return m_bInsertHArea; }
            set { m_bInsertHArea = value; }
        }

        public string NArea
        {
            get { return m_sNArea; }
            set { m_sNArea = value; }
        }

        public bool IsNFull
        {
            get { return m_bNUsedFull; }
            set { m_bNUsedFull = value; }
        }

        public bool IsInsertNArea
        {
            get { return m_bInsertNArea; }
            set { m_bInsertNArea = value; }
        }

        public string SArea
        {
            get { return m_sSArea; }
            set { m_sSArea = value; }
        }

        public bool IsSFull
        {
            get { return m_bSUsedFull; }
            set { m_bSUsedFull = value; }
        }

        public bool IsInsertSArea
        {
            get { return m_bInsertSArea; }
            set { m_bInsertSArea = value; }
        }

        #endregion


        private string GetAddressArea()
        {
            string sArea = string.Empty;

            if (m_iRangeIndex == -1)
                return string.Empty;

            if (m_emPLCMaker == EMPLCMaker.ALL)
                return string.Empty;

            if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                string sAddressDecimal = CUtil.ConvertMelsecAddressRange(m_iRangeIndex, false);
                string sAddressHexa = CUtil.ConvertMelsecAddressRange(m_iRangeIndex, true);

                sArea = string.Format("{0} ({1})", sAddressDecimal, sAddressHexa);
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                sArea = CUtil.ConvertSiemensAddressRange(m_iRangeIndex);
            else if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                sArea = CUtil.ConvertABAddressRange(m_iRangeIndex);
                sArea = sArea.Insert(sArea.Length - 3, "[");
                sArea = sArea + "]";
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                sArea = CUtil.ConvertLSAddressRange(m_iRangeIndex);

            return sArea;
        }
    }
}