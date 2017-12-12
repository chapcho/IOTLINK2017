using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using TrackerSPD.DDEA;

namespace UDMTrackerSimple
{
    public partial class FrmCarType : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private const string m_sCreateUCName = "ucWordDetail";
        private List<CRecipeSection> m_lstCarType = new List<CRecipeSection>();
        private CRecipeSection m_cViewRecipeSection = null;
        private int m_iSplitPos = 0;

        #endregion


        #region Initialize

        public FrmCarType()
        {
            InitializeComponent();
        }

        #endregion


        private void FrmCarType_Load(object sender, EventArgs e)
        {
            try
            {
                cmbWordSize.SelectedIndex = 0;
                if (CMultiProject.RecipeWordList.Count > 0)
                {
                    foreach (var who in CMultiProject.RecipeWordList)
                    {
                        CreateRecipeWord(who.Value);
                        m_lstCarType.AddRange(who.Value.RecipeSectionList);
                    }
                    for (int i = 0; i < sptMain.Panel2.Controls.Count; i++)
                        sptMain.Panel2.Controls[i].BringToFront();
                    if (CMultiProject.RecipeWordList.Values.First().BitSizeType == EMBitSizeType.Bit_32)
                        cmbWordSize.SelectedIndex = 1;
                    cmbWordSize.Enabled = false;
                    btnApply.Enabled = false;
                }
                if (CMultiProject.ProjectInfo.ViewRecipe == null)
                    CMultiProject.ProjectInfo.ViewRecipe = new CRecipeSection();
                m_cViewRecipeSection = CMultiProject.ProjectInfo.ViewRecipe;
                grdCarTypeMap.DataSource = m_lstCarType;
                grdCarTypeMap.RefreshDataSource();

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void CreateRecipeWord(CRecipeWord cRecipeWord)
        {
            UCWordDetail ucView = new UCWordDetail();
            ucView.Name = m_sCreateUCName + cRecipeWord.WordIndex.ToString();
            ucView.WordName = cRecipeWord.WordName;
            ucView.UEventSelectBits += new UEventHandlerSelectBitS(ucWordDetail_SelectItem);
            ucView.BitSizeType = cRecipeWord.BitSizeType;
            ucView.WordMaskValue = cRecipeWord.Mask;
            ucView.WordIndex = cRecipeWord.WordIndex;
            
            ucView.Dock = DockStyle.Top;
            
            sptMain.Panel2.Controls.Add(ucView);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                int iWordCount = (int) spnWordCount.Value;
                EMBitSizeType emBitSizeType = EMBitSizeType.Bit_16;
                if (cmbWordSize.SelectedIndex == 1)
                    emBitSizeType = EMBitSizeType.Bit_32;

                for (int i = 0; i < iWordCount; i++)
                {
                    Control[] acControl = this.Controls.Find(m_sCreateUCName + i.ToString(), true);
                    if (acControl.Length == 0)
                    {
                        CRecipeWord cRecipeWord = new CRecipeWord();
                        cRecipeWord.WordIndex = i;
                        cRecipeWord.BitSizeType = emBitSizeType;
                        cRecipeWord.WordName = "Word " + i.ToString();
                        CMultiProject.RecipeWordList.Add(i, cRecipeWord);

                        CreateRecipeWord(cRecipeWord);
                    }
                    else
                    {
                        if (CMultiProject.RecipeWordList.ContainsKey(i))
                            CMultiProject.RecipeWordList[i].BitSizeType = emBitSizeType;
                    }
                }
                for (int i = 0; i < sptMain.Panel2.Controls.Count; i++)
                    sptMain.Panel2.Controls[i].BringToFront();

                cmbWordSize.Enabled = false;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlgResult = MessageBox.Show("설정된 내용을 모두 지우시겠습니까?", "UDM Tracker Simple",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    return;

                sptMain.Panel2.Controls.Clear();
                cmbWordSize.Enabled = true;
                m_lstCarType.Clear();
                grdCarTypeMap.RefreshDataSource();
                CMultiProject.RecipeWordList.Clear();
                btnApply.Enabled = true;
                //선택된 Word만 초기화
                foreach (var who in CMultiProject.PlcProcS)
                    who.Value.SelectRecipeWord = null;
                m_cViewRecipeSection = null;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void ucWordDetail_SelectItem(object sender, int iIndex, string sWordName, List<int> lstSelected)
        {
            try
            {
                if (sender.GetType() != typeof (UCWordDetail)) return;
                UCWordDetail ucView = (UCWordDetail) sender;

                if (m_lstCarType == null) m_lstCarType = new List<CRecipeSection>();
                if (CMultiProject.RecipeWordList.ContainsKey(iIndex) == false) return;

                string sBitString = "";
                for (int i = 0; i < lstSelected.Count; i++)
                    sBitString += string.Format("{0},", lstSelected[i]);

                CRecipeSection cCarType = m_lstCarType.Find(b => b.BitPosString == sBitString && b.WordIndex == iIndex);
                if (cCarType != null) return;

                FrmInputDialog frmInputText = new FrmInputDialog(sWordName, "Please Input text for Item Name.");
                frmInputText.StartPosition = FormStartPosition.CenterParent;
                frmInputText.ShowDialog();

                if (frmInputText.InputText == "") return;

                cCarType = new CRecipeSection();
                cCarType.WordName = sWordName;
                cCarType.BitPosList = lstSelected;
                cCarType.WordIndex = iIndex;
                cCarType.ItemName = frmInputText.InputText;
                m_lstCarType.Add(cCarType);
                CMultiProject.RecipeWordList[iIndex].RecipeSectionList.Add(cCarType);
                CMultiProject.RecipeWordList[iIndex].SetMask();
                grdCarTypeMap.RefreshDataSource();
                ucView.CompleteView(lstSelected);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvCarTypeMap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle < 0) return;

                int iRowHandle = e.FocusedRowHandle;
                object oData = grvCarTypeMap.GetRow(iRowHandle);

                if (oData.GetType() == typeof (CRecipeSection))
                {
                    CRecipeSection cCarType = (CRecipeSection) oData;
                    UCWordDetail ucWord = null;
                    for (int i = 0; i < sptMain.Panel2.Controls.Count; i++)
                    {
                        if (sptMain.Panel2.Controls[i].GetType() == typeof (UCWordDetail))
                        {
                            ucWord = (UCWordDetail) sptMain.Panel2.Controls[i];
                            if (ucWord.WordIndex == cCarType.WordIndex)
                                ucWord.SetPosColor(cCarType.Mask);
                            else
                                ucWord.SetPosColor(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvCarTypeMap_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iHandle = grvCarTypeMap.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                object oData = grvCarTypeMap.GetRow(iHandle);
                if ((oData.GetType() == typeof (CRecipeSection)))
                {
                    //DetailView Open
                    FrmRecipeSectionItem frmRecipe = new FrmRecipeSectionItem((CRecipeSection) oData);
                    frmRecipe.ShowDialog();
                }
                grdCarTypeMap.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmCarType_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_cViewRecipeSection == null)
                {
                    if (MessageBox.Show(
                        "차종(Car Type)에 관련된 Recipe Item을 지정하지 않았습니다.\r\n 그래도 창을 닫으시겠습니까?",
                        "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                        System.Windows.Forms.DialogResult.No)
                        e.Cancel = true;
                }
                else
                {
                    CMultiProject.ProjectInfo.ViewRecipe = m_cViewRecipeSection;

                    foreach(CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    {
                        if (cProcess.RecipeWordS == null || cProcess.RecipeWordS.Count == 0)
                            continue;

                        for(int i = 0 ; i < cProcess.RecipeWordS.Count ; i++)
                        {
                            if (i == CMultiProject.ProjectInfo.ViewRecipe.WordIndex)
                                cProcess.SelectRecipeWord = cProcess.RecipeWordS[i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuSelectCarType_Click(object sender, EventArgs e)
        {
            try
            {
                int iHandle = grvCarTypeMap.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                object oData = grvCarTypeMap.GetRow(iHandle);
                if ((oData.GetType() == typeof (CRecipeSection)))
                    m_cViewRecipeSection = (CRecipeSection) oData;

                grdCarTypeMap.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvCarTypeMap_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (m_cViewRecipeSection == null)
                    return;

                if (e.RowHandle >= 0)
                {
                    CRecipeSection cRecipe = (CRecipeSection) grvCarTypeMap.GetRow(e.RowHandle);

                    if (cRecipe == m_cViewRecipeSection)
                    {
                        e.Appearance.BackColor = Color.Salmon;
                        e.Appearance.BackColor2 = Color.SeaShell;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCarType",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }
    }
}