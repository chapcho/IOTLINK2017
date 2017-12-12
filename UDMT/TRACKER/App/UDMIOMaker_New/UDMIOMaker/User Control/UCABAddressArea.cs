using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class UCABAddressArea : DevExpress.XtraEditors.XtraUserControl
    {
        private Dictionary<int, CRangeView> m_dicRangeView = null;
        private string m_sPLCName = string.Empty;
        private CBlockUnit m_cCopyUnit = null;
        private string m_sGroupPanelText = string.Empty;

        private bool m_bEdit = false;
        private bool m_bCut = false;
        private bool m_bViewPopmenu = false;

        public UEventHandlerGridCellClick UEventGridCellClick;
        public UEventHandlerGridDoubleClick UEventGridDoubleClick;

        public UCABAddressArea()
        {
            InitializeComponent();
        }

        #region Properties

        public string PLCName
        {
            get { return m_sPLCName; }
            set { m_sPLCName = value; }
        }

        public Dictionary<int, CRangeView> RangeViewS
        {
            get { return m_dicRangeView; }
            set { m_dicRangeView = value; }
        }

        public bool IsEdit
        {
            get { return m_bEdit; }
            set { m_bEdit = value; }
        }

        public bool IsViewPopmenu
        {
            get { return m_bViewPopmenu; }
            set { m_bViewPopmenu = value; }
        }

        public string GroupPanelText
        {
            get { return m_sGroupPanelText; }
            set
            {
                m_sGroupPanelText = value;
                SetGroupPanelText();
            }
        }

        #endregion

        #region Public Methods

        public void ShowAddressArea(string sType, bool bExtend, bool bUsed)
        {
            SetABListTypeView(sType);

            if (bUsed)
            {
                List<CRangeView> lstUsedItem = GetAddressAreaRange();

                if (bExtend)
                    grdAddressArea.DataSource = lstUsedItem;
                else
                    grdAddressArea.DataSource = lstUsedItem.Where(x => x.RangeIndex <= 1500);

                grdAddressArea.RefreshDataSource();
            }
            else
            {
                if (bExtend)
                    grdAddressArea.DataSource = m_dicRangeView.Values.ToList();
                else
                    grdAddressArea.DataSource = m_dicRangeView.Values.Where(x => x.RangeIndex <= 1500).ToList();

                grdAddressArea.RefreshDataSource();
            }
        }

        #endregion

        #region Private Methods

        private void SetGroupPanelText()
        {
            if (m_sGroupPanelText == string.Empty)
                return;

            grvAddressArea.OptionsView.ShowGroupPanel = true;
            grvAddressArea.GroupPanelText = m_sGroupPanelText;
        }

        private List<CRangeView> GetAddressAreaRange()
        {
            Dictionary<int, CRangeView> dicView = new Dictionary<int, CRangeView>();
            List<CRangeView> lstView = null;

            if (colI.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.IArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colO.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.OArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colB.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.BArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colH.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.HArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colN.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.NArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colB.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.BArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colT.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.TArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            if (colC.Visible)
            {
                lstView = m_dicRangeView.Values.Where(x => x.CArea != string.Empty).ToList();
                if (lstView != null && lstView.Count != 0)
                {
                    foreach (var who in lstView)
                    {
                        if (!dicView.ContainsKey(who.RangeIndex))
                            dicView.Add(who.RangeIndex, who);
                    }
                }
            }
            return dicView.Values.OrderBy(x => x.RangeIndex).ToList();
        }

        private void SetABSelectedAreaInfo(int iRowHandle)
        {
            List<string> lstKey = new List<string>();

            int iRangeIndex = (int)grvAddressArea.GetRowCellValue(iRowHandle, colRangeIndex);
            string sType = grvAddressArea.FocusedColumn.Caption;

            if (CProjectManager.LogicDataS[m_sPLCName].AddressBlockS.ContainsKey(sType))
            {
                foreach (
                    var who in CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sType].UnitS[iRangeIndex].TagItemS)
                {
                    if (CProjectManager.PLCTagS.ContainsKey(who.Key) && !lstKey.Contains(who.Key))
                        lstKey.Add(who.Key);
                }
            }

            if (UEventGridDoubleClick != null)
                UEventGridDoubleClick(lstKey);
        }

        private void SetABListTypeView(string sType)
        {
            if (sType.Equals("IO_LIST"))
            {
                colI.Visible = true;
                colO.Visible = true;
                colH.Visible = false;
                colN.Visible = false;
                colB.Visible = false;
                colS.Visible = false;
                colT.Visible = false;
                colC.Visible = false;
            }
            else if (sType.Equals("DUMMY_LIST"))
            {
                colI.Visible = false;
                colO.Visible = false;
                colH.Visible = true;
                colN.Visible = true;
                colB.Visible = true;
                colS.Visible = true;
                colT.Visible = false;
                colC.Visible = false;
            }
            else if (sType.Equals("LINK_LIST"))
            {
                colI.Visible = false;
                colO.Visible = false;
                colH.Visible = false;
                colN.Visible = false;
                colB.Visible = false;
                colS.Visible = false;
                colT.Visible = false;
                colC.Visible = false;
            }
            else if (sType.Equals("TIMER_COUNT_LIST"))
            {
                colI.Visible = false;
                colO.Visible = false;
                colH.Visible = false;
                colN.Visible = false;
                colB.Visible = false;
                colS.Visible = false;
                colT.Visible = true;
                colC.Visible = true;
            }
            else
            {
                colI.Visible = true;
                colO.Visible = true;
                colH.Visible = true;
                colN.Visible = true;
                colB.Visible = true;
                colS.Visible = true;
                colT.Visible = true;
                colC.Visible = true;
            }

        }

        private void SetABSelectedAreaInfo(GridCell[] cells)
        {
            int iRangeIndex = -1;
            string sType = string.Empty;
            CTagItemS cItemS = new CTagItemS();
            List<int> lstRowHandle = new List<int>();
            int iRowHandle = grvAddressArea.FocusedRowHandle;

            if (iRowHandle < 0)
                return;

            foreach (var who in cells)
            {
                if (!lstRowHandle.Contains(who.RowHandle))
                    lstRowHandle.Add(who.RowHandle);

                iRangeIndex = (int)grvAddressArea.GetRowCellValue(who.RowHandle, colRangeIndex);
                sType = who.Column.Caption;

                if (CProjectManager.LogicDataS[m_sPLCName].AddressBlockS.ContainsKey(sType))
                {
                    if (CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sType].UnitS.ContainsKey(iRangeIndex))
                        cItemS.AddRange(CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sType].UnitS[iRangeIndex].TagItemS);
                }
            }

            cells = null;

            lstRowHandle.Sort();

            string sStart = (string)grvAddressArea.GetRowCellValue(lstRowHandle.First(), colAddress);
            string sEnd = (string)grvAddressArea.GetRowCellValue(lstRowHandle.Last(), colAddress);
            string sCount = lstRowHandle.Count.ToString();
            string sModule = string.Empty;
            string sDescription = string.Empty;

            if (grvAddressArea.FocusedColumn == colI || grvAddressArea.FocusedColumn == colO)
            {
                iRangeIndex = (int)grvAddressArea.GetRowCellValue(iRowHandle, colRangeIndex);

                if (CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex].Module != string.Empty)
                    sModule = CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex].Module;

                if (CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex].Description != string.Empty)
                    sDescription =
                        CProjectManager.LogicDataS[m_sPLCName].IOModuleBlock.UnitS[iRangeIndex].Description;
            }

            if (UEventGridCellClick != null)
                UEventGridCellClick(cItemS, sStart, sEnd, sCount, sModule, sDescription);
        }

        private void SetNewArea(GridCell[] cells)
        {
            string sCellValue = string.Empty;
            string sBlockName = string.Empty;
            int iRangeIndex = -1;
            CRangeView cView;

            foreach (var who in cells)
            {
                sCellValue = grvAddressArea.GetRowCellDisplayText(who.RowHandle, who.Column);
                if (sCellValue.Equals("..."))
                    continue;

                cView = (CRangeView)grvAddressArea.GetRow(who.RowHandle);
                sBlockName = who.Column.Caption;
                iRangeIndex = (int)grvAddressArea.GetRowCellValue(who.RowHandle, grvAddressArea.Columns["RangeIndex"]);
                AddSymbolToNewArea(cView, sBlockName, iRangeIndex);

                m_bEdit = true;
            }

            grdAddressArea.RefreshDataSource();
        }

        private void AddSymbolToNewArea(CRangeView cView, string sBlockName, int iRangeIndex)
        {
            CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sBlockName].UnitS[iRangeIndex];

            if (cUnit.TagItemS.Count != 0)
                return;

            CTagItem cItem;
            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                cItem = new CTagItem();
                cItem.Address = CUtil.GetMelsecNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);
                cItem.Description = "NULL";

                if (cUnit.AddressHeader.Equals("T") || cUnit.AddressHeader.Equals("C"))
                    cItem.DataType = EMDataType.Word;
                else
                    cItem.DataType = EMDataType.Bool;

                cItem.Key = string.Format("[{0}]{1}[1]", m_sPLCName, cItem.Address);

                cUnit.TagItemS.Add(cItem);
            }

            cUnit.IsUsed = true;
            cUnit.IsFullUsed = true;

            SetABAreaInfo(cView, CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sBlockName]);
        }

        private void SetABAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "I":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.IArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsIFull = true;
                    break;
                case "O":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.OArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsOFull = true;
                    break;
                case "H":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.HArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsHFull = true;
                    break;
                case "N":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.NArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsNFull = true;
                    break;
                case "S":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.SArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsSFull = true;
                    break;
                case "B":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.BArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsBFull = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    break;
            }
        }

        private void DeleteArea(GridCell[] cells)
        {
            string sCellValue = string.Empty;
            string sBlockName = string.Empty;
            int iRangeIndex = -1;
            CRangeView cView;

            foreach (var who in cells)
            {
                sCellValue = grvAddressArea.GetRowCellDisplayText(who.RowHandle, who.Column);
                if (!sCellValue.Equals("..."))
                    continue;

                cView = (CRangeView)grvAddressArea.GetRow(who.RowHandle);
                sBlockName = who.Column.Caption;
                iRangeIndex = (int)grvAddressArea.GetRowCellValue(who.RowHandle, grvAddressArea.Columns["RangeIndex"]);
                DeleteSymbolSelectArea(cView, sBlockName, iRangeIndex);

                m_bEdit = true;
            }

            grdAddressArea.RefreshDataSource();
        }

        private void DeleteSymbolSelectArea(CRangeView cView, string sBlockName, int iRangeIndex)
        {
            CBlockUnit cUnit = CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sBlockName].UnitS[iRangeIndex];

            if (cUnit.TagItemS.Count == 0)
                return;

            cUnit.TagItemS.Clear();
            cUnit.IsUsed = false;
            cUnit.IsFullUsed = false;
            cUnit.IsDelete = true;

            DeleteABAreaInfo(cView, CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sBlockName]);
        }

        private void DeleteABAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "I":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.IArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsIFull = false;
                    break;
                case "O":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.OArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsOFull = false;
                    break;
                case "H":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.HArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsHFull = false;
                    break;
                case "N":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.NArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsNFull = false;
                    break;
                case "S":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.SArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsSFull = false;
                    break;
                case "B":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.BArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsBFull = false;
                    break;
                case "T":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = false;
                    break;
                case "C":
                    if (!cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = string.Empty;
                    if (!cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = false;
                    break;
            }
        }

        private void CopyArea(GridCell cell)
        {
            string sCellValue = string.Empty;
            string sBlockName = string.Empty;
            int iRangeIndex = -1;

            sCellValue = grvAddressArea.GetRowCellDisplayText(cell.RowHandle, cell.Column);

            if (sCellValue == string.Empty)
                return;

            sBlockName = cell.Column.Caption;
            iRangeIndex = (int)grvAddressArea.GetRowCellValue(cell.RowHandle, grvAddressArea.Columns["RangeIndex"]);

            m_cCopyUnit = CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[sBlockName].UnitS[iRangeIndex];
        }

        private void PasteArea(GridCell cell)
        {
            string sCellValue = string.Empty;
            int iRangeIndex = -1;
            CRangeView cView;

            if (cell.Column.Caption != m_cCopyUnit.AddressHeader)
            {
                XtraMessageBox.Show("복사한 영역의 Address Type과 붙여 넣기 할 영역의 Address Type이 일치하지 않습니다", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sCellValue = grvAddressArea.GetRowCellDisplayText(cell.RowHandle, cell.Column);

            if (sCellValue.Equals("..."))
            {
                if (XtraMessageBox.Show("해당 영역은 이미 심볼이 할당되어 있는 영역입니다.\r\n영역 붙여넣기를 진행하시겠습니까?", "Paste Area",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            iRangeIndex = (int)grvAddressArea.GetRowCellValue(cell.RowHandle, grvAddressArea.Columns["RangeIndex"]);
            cView = (CRangeView)grvAddressArea.GetRow(cell.RowHandle);
            SetPasteArea(iRangeIndex, cView);

            grdAddressArea.RefreshDataSource();

            GridCell[] cells = grvAddressArea.GetSelectedCells();

            if (cells.Length < 1)
                return;

            SetABSelectedAreaInfo(cells);

            m_bEdit = true;
        }

        private void SetPasteArea(int iPasteRangeIndex, CRangeView cView)
        {
            CBlockUnit cPasteUnit = CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[m_cCopyUnit.AddressHeader].UnitS[iPasteRangeIndex];

            cPasteUnit.TagItemS.Clear();
            CTagItem cItem;
            for (int i = 0; i < m_cCopyUnit.TagItemS.Count; i++)
            {
                if (m_cCopyUnit.TagItemS[i].DataType != EMDataType.Bool)
                    continue;

                cItem = new CTagItem();
                cItem.Address = CUtil.GetMelsecNextAddress(cPasteUnit.AddressHeader, cPasteUnit.AddressRange, i);
                cItem.Description = m_cCopyUnit.TagItemS[i].Description;
                cItem.DataType = EMDataType.Bool;
                cItem.Key = string.Format("[{0}]{1}[1]", m_sPLCName, cItem.Address);

                cPasteUnit.TagItemS.Add(cItem);
            }

            cPasteUnit.IsUsed = m_cCopyUnit.IsUsed;
            cPasteUnit.IsFullUsed = m_cCopyUnit.IsFullUsed;

            SetABAreaInfo(cView, CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[cPasteUnit.AddressHeader]);

            if (m_bCut)
                CutArea();

            m_cCopyUnit = null;
        }

        private void CutArea()
        {
            CRangeView cView = (CRangeView)grvAddressArea.GetRow(m_cCopyUnit.RangeIndex);

            m_cCopyUnit.TagItemS.Clear();
            m_cCopyUnit.IsUsed = false;
            m_cCopyUnit.IsFullUsed = false;
            m_cCopyUnit.IsDelete = true;

            DeleteABAreaInfo(cView, CProjectManager.LogicDataS[m_sPLCName].AddressBlockS[m_cCopyUnit.AddressHeader]);

            m_bCut = false;
        }

        #endregion

        #region Event Methods

        private void grvAddressArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (!m_bViewPopmenu)
                return;

            if (e.KeyData == Keys.Down || e.KeyData == Keys.Up || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                //SetMelsecSelectedAreaInfo(cells);
            }
            else if (e.KeyData == Keys.F7)
                btnAreaPaste_ItemClick(null, null);
            else if (e.KeyData == Keys.F5)
                btnAreaCopy_ItemClick(null, null);
            else if (e.KeyData == Keys.F6)
                btnAreaCut_ItemClick(null, null);
            else if (e.KeyData == Keys.Delete)
                btnAreaDelete_ItemClick(null, null);
            else if (e.KeyData == Keys.Insert)
                btnSymbolAssign_ItemClick(null, null);
        }

        private void grvAddressArea_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    GridCell[] cells = grvAddressArea.GetSelectedCells();

                    if (cells.Length < 1)
                        return;

                    //SetMelsecSelectedAreaInfo(cells);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (!m_bViewPopmenu)
                        return;

                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuAddressArea.ShowPopup(CurrentPoint);
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Address Range Mouse Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvAddressArea_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string sUsed = string.Empty;
                var View = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                #region IArea

                if (e.Column.FieldName == "IArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["IArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsIFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region OArea

                if (e.Column.FieldName == "OArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["OArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsOFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region BArea

                if (e.Column.FieldName == "BArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["BArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsBFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region HArea

                if (e.Column.FieldName == "HArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["HArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsHFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region NArea

                if (e.Column.FieldName == "NArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["NArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsNFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region SArea

                if (e.Column.FieldName == "SArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["SArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsSFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region TArea

                if (e.Column.FieldName == "TArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["TArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsTFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion

                #region CArea

                if (e.Column.FieldName == "CArea")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["CArea"]);

                    if (category != null)
                        sUsed = (string)category;

                    if (sUsed.Equals("...") && e.Appearance.BackColor != Color.Orange)
                    {
                        bool bFull = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["IsCFull"]);

                        if (bFull)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.DodgerBlue;
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                            e.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Address Range RowStyle", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSymbolAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                SetNewArea(cells);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Add Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAreaDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("해당 영역의 심볼을 모두 제거하시겠습니까?", "Delete Symbol", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                DeleteArea(cells);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Delete Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAreaCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                if (cells.Length > 1)
                {
                    XtraMessageBox.Show("1개의 Cell 만 복사 가능합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_bCut = false;
                m_cCopyUnit = null;

                CopyArea(cells[0]);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Copy Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAreaCut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                if (cells.Length > 1)
                {
                    XtraMessageBox.Show("1개의 Cell 만 잘라내기 가능합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_bCut = true;
                m_cCopyUnit = null;

                CopyArea(cells[0]);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Cut Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAreaPaste_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_cCopyUnit == null)
                    return;

                GridCell[] cells = grvAddressArea.GetSelectedCells();

                if (cells.Length < 1)
                    return;

                if (cells.Length > 1)
                {
                    XtraMessageBox.Show("1개의 Cell 만 붙여넣기 가능합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PasteArea(cells[0]);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Paste Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvAddressArea_DoubleClick(object sender, EventArgs e)
        {
            int iRowHandle = grvAddressArea.FocusedRowHandle;

            if (iRowHandle < 0)
                return;

            SetABSelectedAreaInfo(iRowHandle);
        }

        #endregion

    }
}
