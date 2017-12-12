using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.DDEA;

namespace UDMPresenter
{
    public partial class FrmModeler : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private List<string> m_lstSelectStepKey = new List<string>();
        private List<string> m_lstDescriptionFilter = new List<string>();

        #endregion


        #region Initialize

        public FrmModeler()
        {
            InitializeComponent();
        }

        #endregion

        
        #region Private Method
        
        private void ShowCoilTable()
        {
            if (CProjectManager.SelectedProject.StepTagList.Count > 0)
            {
                grdCoilTagList.DataSource = CProjectManager.SelectedProject.StepTagList;
                grdCoilTagList.Refresh();
            }
            else
            {
                MessageBox.Show("Step 정보가 없습니다");
            }
        }

        private int SortResult(string sValue1, string sValue2)
        {
            int iResult = -9999;

            try
            {
                if (sValue1.Length > 0 && sValue2.Length > 0)
                {
                    if (sValue1[0] != sValue2[0])
                        return iResult;

                    sValue1 = sValue1.Remove(0, 1);
                    sValue2 = sValue2.Remove(0, 1);

                    bool bComparable = false;
                    bool bS1Digit = false;
                    bool bS2Digit = false;
                    while (true)
                    {
                        bS1Digit = char.IsDigit(sValue1[0]);
                        bS2Digit = char.IsDigit(sValue2[0]);

                        if (bS1Digit && bS2Digit)
                        {
                            bComparable = true;
                            break;
                        }
                        else if (sValue1[0] == sValue2[0])
                        {
                            sValue1 = sValue1.Remove(0, 1);
                            sValue2 = sValue2.Remove(0, 1);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (bComparable)
                    {
                        int iLength1 = sValue1.Length;
                        int iLength2 = sValue2.Length;

                        if (iLength1 > iLength2)
                            iResult = 1;
                        else if (iLength1 < iLength2)
                            iResult = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return iResult;
        }

        protected void InitAddressFilterItem(List<string> lstBase)
        {
            List<string> lstInitValue = new List<string>();
            lstInitValue.Add("SM");
            lstInitValue.Add("SW");
            lstInitValue.Add("SB");
            lstInitValue.Add("SD");
            lstInitValue.Add("F");
            lstInitValue.Add("FX");
            lstInitValue.Add("FY");
            lstInitValue.Add("FD");

            foreach (string sItem in lstInitValue)
            {
                if (lstBase.Contains(sItem) == false)
                    lstBase.Add(sItem);
            }
        }

        protected void InitDescriptionItem(List<string> lstBase)
        {
            List<string> lstInitValue = new List<string>();
            lstInitValue.Add("Alarm");
            lstInitValue.Add("알람");
            lstInitValue.Add("에러");
            lstInitValue.Add("Error");
            lstInitValue.Add("경고");
            lstInitValue.Add("경보");
            lstInitValue.Add("Warning");
            lstInitValue.Add("Dummy");
            lstInitValue.Add("더미");
            lstInitValue.Add("TEST");
            lstInitValue.Add("테스트");
            lstInitValue.Add("실험");
            lstInitValue.Add("Debug");
            lstInitValue.Add("디버그");
            lstInitValue.Add("수동");
            lstInitValue.Add("Manual");
            lstInitValue.Add("화면");
            lstInitValue.Add("Touch");
            lstInitValue.Add("Spare");
            lstInitValue.Add("예비");
            lstInitValue.Add("임시");
            lstInitValue.Add("TEMP");
            lstInitValue.Add("Jog");
            lstInitValue.Add("안전");
            lstInitValue.Add("Safe");
            lstInitValue.Add("BUZZER");
            lstInitValue.Add("부저");
            lstInitValue.Add("HISTORY");
            lstInitValue.Add("이력");
            lstInitValue.Add("시계");
            lstInitValue.Add("Clock");
            lstInitValue.Add("클럭");
            lstInitValue.Add("클락");
            lstInitValue.Add("Reserve");
            lstInitValue.Add("예약");
            lstInitValue.Add("Password");
            lstInitValue.Add("암호");
            lstInitValue.Add("Emergency");
            lstInitValue.Add("EMO");
            lstInitValue.Add("Door");
            lstInitValue.Add("도어");
            lstInitValue.Add("고장");
            lstInitValue.Add("Timeover");
            lstInitValue.Add("Timeout");
            lstInitValue.Add("타임 오버");
            lstInitValue.Add("타임 오바");
            lstInitValue.Add("타임 아웃");
            foreach (string sItem in lstInitValue)
            {
                if (lstBase.Contains(sItem) == false)
                    lstBase.Add(sItem);
            }
        }

        protected void ShowFilterOption()
        {
            cmbAddressFilter.SelectedIndex = Convert.ToInt32(!CProjectManager.SelectedProject.FilterOption.UseAddressFilter);
            cmbDescriptionFilter.SelectedIndex = Convert.ToInt32(!CProjectManager.SelectedProject.FilterOption.UseDescriptionFilter);

            List<string> lstAddressFilter = CProjectManager.SelectedProject.FilterOption.AddressFilterList;
            List<string> lstDescriptionFilter = CProjectManager.SelectedProject.FilterOption.DescriptionFilterList;

            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi)
                InitAddressFilterItem(lstAddressFilter);
            InitDescriptionItem(lstDescriptionFilter);

            txtAddressFilter.Lines = lstAddressFilter.ToArray();
            txtDescriptionFilter.Lines = lstDescriptionFilter.ToArray();
            spnWordSize.Value = CProjectManager.SelectedProject.FilterOption.MaxWord;
            spnDepth.Value = CProjectManager.SelectedProject.FilterOption.Depth;
        }

        private void SetCollectOption()
        {
            //Base Address
            string sLine = "";
            CProjectManager.SelectedProject.FilterOption.BaseAddressList.Clear();
            if (txtBaseAddress.Lines != null)
            {
                for (int i = 0; i < txtBaseAddress.Lines.Length; i++)
                {
                    sLine = txtBaseAddress.Lines[i].Trim();
                    if (sLine != "")
                        CProjectManager.SelectedProject.FilterOption.BaseAddressList.Add(sLine);
                }
            }

            //Depth
            CProjectManager.SelectedProject.FilterOption.Depth = (int)(spnDepth.Value);

            //DataType
            if (cmbDataType.SelectedIndex < 1)
                CProjectManager.SelectedProject.FilterOption.DataType = EMDataType.None;
            else if (cmbDataType.SelectedIndex == 1)
                CProjectManager.SelectedProject.FilterOption.DataType = EMDataType.Bool;
            
            //WordSize
            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi)
                CProjectManager.SelectedProject.FilterOption.MaxWord = (int)(spnWordSize.Value);
            else
                CProjectManager.SelectedProject.FilterOption.MaxWord = 10000;

        }

        private void SetFilterOption()
        {
            string sLine = "";

            //AddressFilter
            if (cmbAddressFilter.SelectedIndex < 1)
                CProjectManager.SelectedProject.FilterOption.UseAddressFilter = true;
            else
                CProjectManager.SelectedProject.FilterOption.UseAddressFilter = false;

            //DescriptionFilter
            if (cmbDescriptionFilter.SelectedIndex < 1)
                CProjectManager.SelectedProject.FilterOption.UseDescriptionFilter = true;
            else
                CProjectManager.SelectedProject.FilterOption.UseDescriptionFilter = false;

            //Filter Address
            CProjectManager.SelectedProject.FilterOption.AddressFilterList.Clear();
            if (txtAddressFilter.Lines != null)
            {
                for (int i = 0; i < txtAddressFilter.Lines.Length; i++)
                {
                    sLine = txtAddressFilter.Lines[i].Trim();
                    if (sLine != "")
                        CProjectManager.SelectedProject.FilterOption.AddressFilterList.Add(sLine);
                }
            }

            //Filter Description

            m_lstDescriptionFilter.Clear();
            CProjectManager.SelectedProject.FilterOption.DescriptionFilterList.Clear();
            if (txtDescriptionFilter.Lines != null)
            {
                for (int i = 0; i < txtDescriptionFilter.Lines.Length; i++)
                {
                    sLine = txtDescriptionFilter.Lines[i].Trim();
                    if (sLine != "")
                    {
                        CProjectManager.SelectedProject.FilterOption.DescriptionFilterList.Add(sLine);
                        m_lstDescriptionFilter.Add(sLine.ToLower());
                    }
                }
            }
        }

        private bool IsDescriptionFiltered(CTag cTag)
        {
            string sDescription = cTag.Description.ToLower();

            bool bOK = false;
            for (int i = 0; i < m_lstDescriptionFilter.Count; i++)
            {
                if (sDescription.Contains(m_lstDescriptionFilter[i]))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsAddressFiltered(List<string> lstFilter, CTag cTag)
        {
            bool bOK = false;
            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi)
            {
                CDDEASymbol cDDEASymbol = new CDDEASymbol(cTag);
                for (int i = 0; i < lstFilter.Count; i++)
                {
                    if (cDDEASymbol.AddressHeader == lstFilter[i] || cDDEASymbol.Address == lstFilter[i])
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            else if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Siemens)
            {
                for (int i = 0; i < lstFilter.Count; i++)
                {
                    if (cTag.Address.Contains(lstFilter[i]))
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            return bOK;
        }

        private int AddTag(CStep cStep, CFilterOption cFilterOption, List<CTag> lstTotalTag, List<CTag> lstAddTag)
        {
            int iTagCount = 0;
            int iAdditional = 0;

            CTag cTag = new CTag();
            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            foreach (List<string> lstKey in cStep.CoilS.Select(b => b.RefTagS.KeyList))
            {
                for (int i = 0; i < lstKey.Count; i++)
                {
                    if (cTagS.ContainsKey(lstKey[i]))
                        cTag = cTagS[cStep.RefTagS.KeyList[i]];
                    else
                    {
                        continue;
                    }
                    if (cTag.IsCollectUsed)
                        continue;

                    if (cFilterOption.DataType != EMDataType.None && cTag.DataType != cFilterOption.DataType)
                        continue;

                    if (IsAddressFiltered(cFilterOption.AddressFilterList, cTag))
                        continue;

                    if (IsDescriptionFiltered(cTag))
                        continue;

                    cTag.IsCollectUsed = true;
                    lstTotalTag.Add(cTag);
                    lstAddTag.Add(cTag);

                    iTagCount += 1;
                    iAdditional += 1;
                }
            }

            for (int i = 0; i < cStep.RefTagS.KeyList.Count; i++)
            {
                if (cTagS.ContainsKey(cStep.RefTagS.KeyList[i]))
                    cTag = cTagS[cStep.RefTagS.KeyList[i]];
                else
                {
                    continue;
                }
                if (cTag.IsCollectUsed)
                    continue;

                if (cFilterOption.DataType != EMDataType.None && cTag.DataType != cFilterOption.DataType)
                    continue;

                if (IsAddressFiltered(cFilterOption.AddressFilterList, cTag))
                    continue;

                if (IsDescriptionFiltered(cTag))
                    continue;

                cTag.IsCollectUsed = true;
                lstTotalTag.Add(cTag);
                lstAddTag.Add(cTag);

                iTagCount += 1;
                iAdditional += 1;
            }

            return iTagCount;
        }
        private int AddTag(CStep cStep, CFilterOption cFilterOption, List<CTag> lstTotalTag, List<CTag> lstAddTag, int iCurrentWordSize, out int iResultWordSize, out bool bFull)
        {
            bFull = false;
            iResultWordSize = iCurrentWordSize;

            if (iCurrentWordSize >= cFilterOption.MaxWord)
                return 0;

            int iWordSizeDiff = cFilterOption.MaxWord - iCurrentWordSize;

            int iTagCount = 0;
            int iAdditional = 0;

            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            CTag cTag;
            foreach (List<string> lstKey in cStep.CoilS.Select(b => b.RefTagS.KeyList))
            {
                for (int i = 0; i < lstKey.Count; i++)
                {
                    cTag = cTagS[lstKey[i]];
                    if (cTag.IsCollectUsed)
                        continue;

                    if (cFilterOption.DataType != EMDataType.None && cTag.DataType != cFilterOption.DataType)
                        continue;

                    if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi && CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
                    {
                        if (IsAddressFiltered(cFilterOption.AddressFilterList, cTag))
                            continue;
                    }
                    if (IsDescriptionFiltered(cTag))
                        continue;

                    cTag.IsCollectUsed = true;
                    lstTotalTag.Add(cTag);
                    lstAddTag.Add(cTag);

                    iTagCount += 1;
                    iAdditional += 1;
                }
            }
            for (int i = 0; i < cStep.RefTagS.KeyList.Count; i++)
            {
                cTag = cTagS[cStep.RefTagS.KeyList[i]];
                if (cTag.IsCollectUsed)
                    continue;

                if (cFilterOption.DataType != EMDataType.None && cTag.DataType != cFilterOption.DataType)
                    continue;

                if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi && CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
                {
                    if (IsAddressFiltered(cFilterOption.AddressFilterList, cTag))
                        continue;
                }
                if (IsDescriptionFiltered(cTag))
                    continue;

                cTag.IsCollectUsed = true;
                lstTotalTag.Add(cTag);
                lstAddTag.Add(cTag);

                iTagCount += 1;
                iAdditional += 1;
                
                if (iAdditional >= iWordSizeDiff)
                {
                    iResultWordSize = CProjectManager.SelectedProject.GetWordSize(lstTotalTag);
                    if (iResultWordSize < cFilterOption.MaxWord)
                    {
                        iWordSizeDiff = cFilterOption.MaxWord - iResultWordSize;
                        iAdditional = 0;
                    }
                    else if (iResultWordSize > cFilterOption.MaxWord)
                    {
                        lstTotalTag.Remove(cTag);
                        bFull = true;
                        break;
                    }
                    else
                    {
                        bFull = true;
                        break;
                    }
                }
            }

            iResultWordSize = CProjectManager.SelectedProject.GetWordSize(lstTotalTag);

            return iTagCount;
        }

        private int Generate(int iStartWordSize, bool bUseDepth)
        {
            if (m_lstSelectStepKey.Count == 0) return iStartWordSize;

            List<CStep> lstAddStep = new List<CStep>();
            CStepS cTotalStepS = new CStepS();
            List<CTag> lstTotalTag = new List<CTag>();
            List<CTag> lstAddTag = new List<CTag>();

            if (CProjectManager.SelectedProject.FilterOption.BaseAddressList.Count > 0)
            {
                if (CProjectManager.SelectedProject.FilterOption.Depth == 0)
                {
                    lstAddTag = CProjectManager.SelectedProject.GetModeTagList(CProjectManager.SelectedProject.FilterOption.BaseAddressList);
                    int iResult = lstAddTag.Count;
                    lstAddTag.Clear();
                    return iResult;
                }
                else
                    lstAddStep = CProjectManager.SelectedProject.GetCoilStepList(CProjectManager.SelectedProject.FilterOption.BaseAddressList);
            }

            lstAddStep.AddRange(CProjectManager.SelectedProject.GetSelectStepList(m_lstSelectStepKey));

            int iTagCount = 0;
            int iResultWordSize = 0;
            int iDepth = 0;
            bool bSizeFull = false;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Add");
            exScreenManager.SetWaitFormDescription("Select Coil Address Adding...");

            CStep cStep;
            while (true)
            {
                if (lstAddStep.Count == 0)
                    break;

                if (bUseDepth && iDepth >= CProjectManager.SelectedProject.FilterOption.Depth)
                    break;

                cTotalStepS.AddRange(lstAddStep);

                for (int i = 0; i < lstAddStep.Count; i++)
                {
                    cStep = lstAddStep[i];
                    iTagCount += AddTag(cStep, CProjectManager.SelectedProject.FilterOption, lstTotalTag, lstAddTag, iStartWordSize, out iResultWordSize, out bSizeFull);

                    if (bSizeFull)
                    {
                        iResultWordSize = CProjectManager.SelectedProject.GetWordSize(lstTotalTag);
                        break;
                    }

                    iStartWordSize = iResultWordSize;
                }

                iDepth += 1;

                if (bSizeFull)
                    break;

                lstAddStep.Clear();
                lstAddStep = GetNextStepList(CProjectManager.SelectedProject.StepS, cTotalStepS.Values.ToList(), lstAddTag);

                lstAddTag.Clear();
            }

            exScreenManager.CloseWaitForm();

            lstAddStep.Clear();
            lstAddTag.Clear();
            cTotalStepS.Clear();
            lstTotalTag.Clear();

            return iTagCount;
        }

        private int GenerateOPC(bool bUseDepth)
        {
            List<CStep> lstAddStep = new List<CStep>();
            List<CStep> lstTotalStep = new List<CStep>();
            List<CTag> lstTotalTag = new List<CTag>();
            List<CTag> lstAddTag = new List<CTag>();

            //if (CProjectManager.Project.FilterOption.BaseAddressList.Count == 0)
            //    lstAddStep = CProjectManager.Project.GetEndCoilStepList();
            //else
            //{
            //    if (CProjectManager.Project.FilterOption.Depth == 0)
            //    {
            //        lstAddTag = CProjectManager.Project.GetModeTagList(CProjectManager.Project.FilterOption.BaseAddressList);
            //        int iResult = lstAddTag.Count;
            //        lstAddTag.Clear();
            //        return iResult;
            //    }
            //    else
            //        lstAddStep = CProjectManager.Project.GetCoilStepList(CProjectManager.Project.FilterOption.BaseAddressList);
            //}
            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            foreach (CStepTagList lst in CProjectManager.SelectedProject.StepTagList)
            {
                if (lst.CoilCollectUsed)
                {
                    //lst.CoilTag.IsCollectUsed = true;
                    //for (int i = 0; i < lst.ContactTagList.Count; i++)
                    //    lst.ContactTagList[i].IsCollectUsed = true;
                    if (CProjectManager.SelectedProject.StepS.ContainsKey(lst.StepKey))
                    {
                        lstAddStep.Add(CProjectManager.SelectedProject.StepS[lst.StepKey]);
                    }
                }
            }

            int iTagCount = 0;
            int iDepth = 0;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Add");
            exScreenManager.SetWaitFormDescription("Select Coil Address Adding...");

            CStep cStep;
            while (true)
            {
                if (lstAddStep.Count == 0)
                    break;

                lstTotalStep.AddRange(lstAddStep);

                for (int i = 0; i < lstAddStep.Count; i++)
                {
                    cStep = lstAddStep[i];
                    iTagCount += AddTag(cStep, CProjectManager.SelectedProject.FilterOption, lstTotalTag, lstAddTag);
                }

                iDepth += 1;

                if (bUseDepth && iDepth >= CProjectManager.SelectedProject.FilterOption.Depth)
                    break;

                lstAddStep.Clear();
                lstAddStep = GetNextStepList(CProjectManager.SelectedProject.StepS, lstTotalStep, lstAddTag);

                lstAddTag.Clear();
            }

            exScreenManager.CloseWaitForm();

            lstAddStep.Clear();
            lstAddTag.Clear();
            lstTotalStep.Clear();
            lstTotalTag.Clear();

            return iTagCount;
        }

        private int GetWordSize()
        {
            int iWordSize = 0;

            List<CTag> lstTag = CProjectManager.SelectedProject.TagS.Values.Where(b => b.IsCollectUsed).ToList();
            iWordSize = CProjectManager.SelectedProject.GetWordSize(lstTag);
            
            return iWordSize;
        }

        private int GetTagSize()
        {
            int iTagSize = 0;

            CTag cTag;
            for (int i = 0; i < CProjectManager.SelectedProject.TagS.Count; i++)
            {
                cTag = CProjectManager.SelectedProject.TagS.ElementAt(i).Value;
                if (cTag.IsCollectUsed)
                    iTagSize++;
            }

            return iTagSize;
        }

        private List<CStep> GetNextStepList(CStepS cStepS, List<CStep> lstExistStep, List<CTag> lstTargetTag)
        {
            List<CStep> lstNextStep = new List<CStep>();

            string sStep;
            CStep cStep;
            CTag cTag;
            for (int i = 0; i < lstTargetTag.Count; i++)
            {
                cTag = lstTargetTag[i];
                for (int j = 0; j < cTag.StepRoleS.Count; j++)
                {
                    if (cTag.StepRoleS[j].RoleType == EMStepRoleType.Coil || cTag.StepRoleS[j].RoleType == EMStepRoleType.Both)
                    {
                        sStep = cTag.StepRoleS[j].StepKey;
                        if (cStepS.ContainsKey(sStep))
                        {
                            cStep = cStepS[sStep];
                            if (lstExistStep.Contains(cStep) == false)
                                lstNextStep.Add(cStep);
                        }
                    }
                }
            }

            return lstNextStep;
        }

        private void ShowTable(CTagS cTagS)
        {
            Clear();

            grdTagTable.BeginUpdate();
            {
                grdTagTable.DataSource = cTagS.Select(x => x.Value).ToList();
            }
            grdTagTable.EndUpdate();
        }


        private void Clear()
        {
            //if (exEditorGroupCombo.Items.Count > 0)
            //{
            //    exEditorGroupCombo.Items.Clear();
            //    exEditorGroupCombo.Items.Add("");
            //}

            grdTagTable.DataSource = null;
            grdTagTable.RefreshDataSource();
        }

        #endregion


        private void FrmModeler_Load(object sender, EventArgs e)
        {
            ShowTable(CProjectManager.SelectedProject.TagS);

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Loading");
            exScreenManager.SetWaitFormDescription("Coil Contants Loading...");

            ShowFilterOption();

            ShowCoilTable();

            exScreenManager.CloseWaitForm();

            List<string> lstAddressFilter = CProjectManager.SelectedProject.FilterOption.AddressFilterList;
            List<string> lstDescriptionFilter = CProjectManager.SelectedProject.FilterOption.DescriptionFilterList;

            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi)
                InitAddressFilterItem(lstAddressFilter);

            InitDescriptionItem(lstDescriptionFilter);

            m_lstSelectStepKey = CProjectManager.SelectedProject.StepTagList.Where(b => b.CoilCollectUsed == true).Select(b => b.StepKey).ToList();

            txtAddressFilter.Lines = lstAddressFilter.ToArray();
            txtDescriptionFilter.Lines = lstDescriptionFilter.ToArray();
            spnDepth.Value = CProjectManager.SelectedProject.FilterOption.Depth;
            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Siemens)
            {
                pnlNormalOptionLeft.Enabled = false;
                pnlDataTypeFilter.Visible = false;
                pnlWordSize.Visible = false;
            }

        }


        private void grvTagList_ShowingEditor(object sender, CancelEventArgs e)
        {
            //int iRowIndex = grvTagList.FocusedRowHandle;
            //if (iRowIndex < 0)
            //    return;

            //if (grvTagList.FocusedColumn == colAddress)
            //{
            //    CTag cTag = (CTag)(grvTagList.GetRow(iRowIndex));
            //    if (cTag.Creator == "System")
            //        e.Cancel = true;
            //}
            //else if (grvTagList.FocusedColumn == colDataType)
            //{
            //    CTag cTag = (CTag)(grvTagList.GetRow(iRowIndex));
            //    if (cTag.Creator == "System")
            //        e.Cancel = true;
            //}
        }

        private void grvTagList_ShownEditor(object sender, EventArgs e)
        {
            if (grvCoilTagList.FocusedColumn == colAddress)
            {
                TextEdit edit = grvCoilTagList.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void grvTagList_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            if (e.Value1 == null || e.Value2 == null)
                return;

            string sValue1 = (string)e.Value1;
            string sValue2 = (string)e.Value2;

            int iResult = SortResult(sValue1, sValue2);
            if (iResult != -9999)
            {
                e.Result = iResult;
                e.Handled = true;
            }
        }

        private void grvTagList_HiddenEditor(object sender, EventArgs e)
        {
            colDescription.OptionsColumn.AllowEdit = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCollectOption();
            SetFilterOption();
            int iCount = 0;
            List<string> lstSelectStepKey = CProjectManager.SelectedProject.StepTagList.Where(b => b.CoilCollectUsed == true).Select(b => b.StepKey).ToList();

            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            DialogResult dlgResult = MessageBox.Show("지금 설정된 내용으로 초기화합니다.", "UDM Presenter", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (var who in cTagS)
                {
                    if (CProjectManager.SelectedProject.UserAddSymbol.Contains(who.Key)) continue;
                    who.Value.IsCollectUsed = false;
                }

                m_lstSelectStepKey.Clear();
                m_lstSelectStepKey = lstSelectStepKey;
            }
            else
            {
                
                for (int i = 0; i < lstSelectStepKey.Count; i++)
                {
                    if (m_lstSelectStepKey.Contains(lstSelectStepKey[i]) == false)
                        m_lstSelectStepKey.Add(lstSelectStepKey[i]);
                }
            }

            if (CProjectManager.SelectedProject.PlcMaker == EMPLCMaker.Mitsubishi && CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
            {
                int iWordSize = GetWordSize();
                if (iWordSize >= (int)(spnWordSize.Value))
                {
                    MessageBox.Show("현재 WordSize가 최대치입니다.", "UDM Profiler2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                iCount = Generate(iWordSize, chkDepth.Checked);
            }
            else
            {
                //int iTagSize = GetTagSize();
                iCount = GenerateOPC(chkDepth.Checked);
            }

            //iWordSize = GetWordSize(m_emModeType);
            //txtWordSizeT.Text = iWordSize.ToString();
            
            grdCoilTagList.RefreshDataSource();
            grdTagTable.RefreshDataSource();
            CProjectManager.SelectedProject.FilterOption.Depth = (int)spnDepth.Value;
            MessageBox.Show(iCount.ToString() + " 접점이 수집 대상으로 추가 되었습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grvTagList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvTagTable_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void FrmModeler_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SymbolS 생성
            //사용자가 임의로 추가한 접점을 따로 빼야함.
            CSymbolS cSymbolS = CProjectManager.SelectedProject.SymbolS;
            List<CTag> lstTag = CProjectManager.SelectedProject.TagS.Select(x => x.Value).Where(x => x.IsCollectUsed == true).ToList();
            List<string> lstRemoveSymbol = new List<string>();
            
            foreach (var who in cSymbolS)
            {
                if (CProjectManager.SelectedProject.UserAddSymbol.Contains(who.Key) == false)
                    lstRemoveSymbol.Add(who.Key);
            }
            for (int i = 0; i < lstRemoveSymbol.Count; i++)
                cSymbolS.Remove(lstRemoveSymbol[i]);

            for (int i = 0; i < lstTag.Count; i++)
            {
                CTag cTag = lstTag[i];

                if (cSymbolS.ContainsKey(cTag.Key) == false)
                {
                    CSymbol cSymbol = new CSymbol(cTag);
                    cSymbolS.Add(cSymbol.Key, cSymbol);
                }
            }
        }

    }
}