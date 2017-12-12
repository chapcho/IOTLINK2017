using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraSpreadsheet.Forms;
using UDM.Common;
using UDM.General.Csv;

namespace UDMIOMaker
{
    partial  class FrmMain
    {
        private bool m_bStandardization = false;
        private bool m_bUnderBar = false;
        private bool m_bBar = false;
        private bool m_bSpace = false;

        private bool LoadStdLibrary()
        {
            bool bOK = false;

            if (File.Exists(CProjectManager.StdLibraryPath))
            {
                CCsvReader cReader = new CCsvReader();
                bOK = cReader.Open(CProjectManager.StdLibraryPath, true);

                if (!bOK)
                    return false;

                if (CProjectManager.StdS == null)
                    CProjectManager.StdS = new CStdS();

                CProjectManager.StdS.Clear();

                List<string> lstValue = null;
                CStd cStd = null;
                while (cReader.EOF == false)
                {
                    lstValue = cReader.ReadLine();
                    if (lstValue != null)
                    {
                        cStd = GetStd(lstValue);
                        if (!CProjectManager.StdS.ContainsKey(cStd.CurrentName))
                            CProjectManager.StdS.Add(cStd.CurrentName, cStd);

                        lstValue.Clear();
                        lstValue = null;
                    }
                }
                bOK = true;

                cReader.Close();
                cReader.Dispose();
                cReader = null;
            }
            return bOK;
        }

        private CStd GetStd(List<string> lstValue)
        {
            CStd cStd = new CStd();

            cStd.CurrentName = lstValue[0];
            cStd.TargetName = lstValue[1];
            cStd.Description = lstValue[2];

            return cStd;
        }

        private void ClearSymbolPLC()
        {
            CProjectManager.StdTagS.Clear();

            m_bStandardization = false;

            grdStd.DataSource = null;
            grdStd.RefreshDataSource();
        }

        private bool SaveStdLibrary()
        {
            bool bOK = true;
            try
            {
                if (CProjectManager.StdS.IsEdit)
                    grdStdL.ExportToCsv(CProjectManager.StdLibraryPath);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Save StdL", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private int ApplyPLCSymbolName()
        {
            int iStandardCount = 0;

            try
            {
                foreach (var who in CProjectManager.StdTagS)
                {
                    if (CProjectManager.PLCTagS.ContainsKey(who.Key))
                    {
                        if (CProjectManager.PLCTagS[who.Key].PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || CProjectManager.PLCTagS[who.Key].PLCMaker.Equals(EMPLCMaker.LS))
                            CProjectManager.PLCTagS[who.Key].Description = who.Value.TargetDesc;
                        else
                            CProjectManager.PLCTagS[who.Key].Name = who.Value.TargetDesc;

                        who.Value.CurrentDesc = who.Value.TargetDesc;
                        iStandardCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Apply Symbol Name Error", ex.Message);
                ex.Data.Clear();
                iStandardCount = -1;
            }

            return iStandardCount;
        }

        private void ShowStdGrid()
        {
            if(CProjectManager.StdTagS == null)
                CProjectManager.StdTagS = new CStdTagS();

            CStdTag cStdTag;
            foreach (var who in CProjectManager.PLCTagS)
            {
                cStdTag = new CStdTag();

                if(who.Value.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || who.Value.PLCMaker.Equals(EMPLCMaker.LS))
                    cStdTag.CurrentDesc = who.Value.Description;
                else
                    cStdTag.CurrentDesc = who.Value.Name;

                cStdTag.Address = who.Value.Address;
                cStdTag.Key = who.Key;

                if(!CProjectManager.StdTagS.ContainsKey(cStdTag.Key))
                    CProjectManager.StdTagS.Add(cStdTag.Key, cStdTag);
            }

            grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
            grdStd.RefreshDataSource();
        }

        private bool Standardization()
        {
            bool bOK = true;

            CStdTag cTag = null;
            List<string> lstValue = null;
            foreach (var who in CProjectManager.StdTagS)
            {
                cTag = who.Value;
                cTag.ClearLevel();

                lstValue = GetParseValue(cTag.CurrentDesc);
                SetGridColumnVisible(lstValue.Count);

                if (SetStdTagLevel(cTag, lstValue))
                    cTag.IsStandard = true;

                cTag.TargetDesc = GetTargetDesc(cTag);

                lstValue.Clear();
                lstValue = null;
            }

            m_bStandardization = true;

            return bOK;
        }

        private bool TagStandardization(string sIndex, int iRowHandle)
        {
            bool bOK = true;

            int iLevelIndex = Convert.ToInt32(sIndex);

            CStdTag cStdTag = (CStdTag)grvStd.GetRow(iRowHandle);

            CLevel cLv = cStdTag.LevelS[iLevelIndex - 1];

            if (CheckStdLibrary(cLv))
                cLv.IsStdExist = true;
            else
                cLv.IsStdExist = false;

            if (cLv.TargetParse != string.Empty)
                cLv.IsCurrentView = false;
            else
                cLv.IsCurrentView = true;

            if (CheckIsStandard(cStdTag))
                cStdTag.IsStandard = true;

            cStdTag.TargetDesc = GetTargetDesc(cStdTag);
            grdStd.RefreshDataSource();

            return bOK;
        }

        private string GetTargetDesc(CStdTag cTag)
        {
            string sTarget = string.Empty;

            foreach (var who in cTag.LevelS)
            {
                if (who.CurrentParse != string.Empty)
                {
                    if (who.IsCurrentView)
                        sTarget += string.Format("{0}_", who.CurrentParse);
                    else
                        sTarget += string.Format("{0}_", who.TargetParse);
                }
            }

            int iLastIndex = sTarget.LastIndexOf("_");

            if (iLastIndex < 0)
                return string.Empty;

            sTarget = sTarget.Remove(iLastIndex, 1);

            return sTarget;
        }

        private bool SetStdTagLevel(CStdTag cStdTag, List<string> lstValue)
        {
            bool bOK = true;

            CLevel cLv;
            for (int i = 0; i < lstValue.Count; i++)
            {
                if (i >= 10)
                    break;

                cLv = cStdTag.LevelS[i];
                cLv.CurrentParse = lstValue[i];

                if (CheckStdLibrary(cLv))
                    cLv.IsStdExist = true;
                else
                    cLv.IsStdExist = false;

                if (cLv.TargetParse != string.Empty)
                    cLv.IsCurrentView = false;
                else
                    cLv.IsCurrentView = true;

                if (bOK && cLv.IsStdExist)
                    bOK = true;
                else
                    bOK = false;
            }

            return bOK;
        }

        private bool CheckIsStandard(CStdTag cTag)
        {
            bool bOK = false;

            foreach (var who in cTag.LevelS)
            {
                if (who.IsStdExist)
                    bOK = true;
                else
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        private bool SetDescParseContainBracket(string sConvertCurrent, CLevel cLv)
        {
            bool bOK = false;

            string sConvertHeader = sConvertCurrent.Split('[')[0];

            string sConvertTail = sConvertCurrent.Split('[')[1].Replace("]", string.Empty);

            if (sConvertHeader == string.Empty)
                return false;

            if (CProjectManager.StdS.ContainsKey(sConvertHeader))
            {
                string sTarget = CProjectManager.StdS[sConvertHeader].TargetName;

                if (sTarget == sConvertHeader)
                    cLv.IsChanged = false;
                else
                {
                    cLv.IsChanged = true;
                    cLv.TargetParse = string.Format("{0}[{1}]", sTarget, sConvertTail);
                }

                bOK = true;
            }
            else if (Regex.IsMatch(sConvertHeader, "[0-9]"))
            {
                if (SetDescParseContainNumber(sConvertHeader, cLv))
                    bOK = true;
                else
                    bOK = false;
            }

            return bOK;
        }

        private bool SetDescParseContainNumber(string sConvertCurrent, CLevel cLv)
        {
            bool bOK = false;

            if (sConvertCurrent == string.Empty)
                return false;

            string sValueExceptNumeric = Regex.Replace(sConvertCurrent, "[0-9]", " ");
            string[] arrValue = sValueExceptNumeric.Split(' ');

            foreach (string sValue in arrValue)
            {
                if (sValue == string.Empty)
                    continue;

                if (CProjectManager.StdS.ContainsKey(sValue))
                {
                    bOK = true;

                    string sTarget = CProjectManager.StdS[sValue].TargetName;

                    if (sValue == sTarget)
                        cLv.IsChanged = false;
                    else
                    {
                        cLv.IsChanged = true;
                        cLv.TargetParse = sConvertCurrent.Replace(sValue, sTarget);
                    }
                }
            }

            return bOK;
        }

        private bool CheckStdLibrary(CLevel cLv)
        {
            bool bOK = false;
            string sConvertCurrent = cLv.CurrentParse;

            if (sConvertCurrent.Contains("["))
            {
                if (SetDescParseContainBracket(sConvertCurrent, cLv))
                    bOK = true;
                else
                    bOK = false;
            }
            else if (Regex.IsMatch(sConvertCurrent, "[0-9]"))
            {
                if (SetDescParseContainNumber(sConvertCurrent, cLv))
                    bOK = true;
                else
                    bOK = false;
            }
            else if (CProjectManager.StdS.ContainsKey(sConvertCurrent))
            {
                bOK = true;

                string sTarget = CProjectManager.StdS[sConvertCurrent].TargetName;

                if (sTarget == sConvertCurrent)
                    cLv.IsChanged = false;
                else
                {
                    cLv.IsChanged = true;
                    cLv.TargetParse = sTarget;
                }
            }
            //else if (CheckDescriptionContainLibrary(sConvertCurrent, cLv))
            //    bOK = true;
            else
                bOK = false;

            return bOK;
        }

        private bool CheckDescriptionContainLibrary(string sConvertCurrent, CLevel cLv)
        {
            bool bOK = false;

            if (sConvertCurrent == string.Empty)
                return false;

            foreach (var who in CProjectManager.StdS)
            {
                if (sConvertCurrent.Contains(who.Key))
                {
                    Match match = Regex.Match(sConvertCurrent, who.Key);
                    string sTarget = who.Value.TargetName;

                    if (who.Key == sTarget)
                        cLv.IsChanged = false;
                    else
                    {
                        cLv.IsChanged = true;
                        cLv.TargetParse = Regex.Replace(sConvertCurrent, who.Key, sTarget);
                    }

                    bOK = true;
                    break;
                }
            }


            return bOK;
        }

        private void SetGridColumnVisible(int iColumnCount)
        {
            if (iColumnCount == 7)
                colLv7.Visible = true;
            else if (iColumnCount == 8)
            {
                colLv7.Visible = true;
                colLv8.Visible = true;
            }
            else if (iColumnCount == 9)
            {
                colLv7.Visible = true;
                colLv8.Visible = true;
                colLv9.Visible = true;
            }
            else if (iColumnCount == 10)
            {
                colLv7.Visible = true;
                colLv8.Visible = true;
                colLv9.Visible = true;
                colLv10.Visible = true;
            }
        }

        private List<string> GetParseValue(string sDescription)
        {
            List<string> lstValue = new List<string>();

            if (m_bUnderBar && !m_bBar && !m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] {'_'}, StringSplitOptions.None).ToList());
            else if (!m_bUnderBar && m_bBar && !m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { '-' }, StringSplitOptions.None).ToList());
            else if (!m_bUnderBar && !m_bBar && m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { ' ' }, StringSplitOptions.None).ToList());
            else if (m_bUnderBar && m_bBar && !m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { '_', '-' }, StringSplitOptions.None).ToList());
            else if (m_bUnderBar && !m_bBar && m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { '_', ' ' }, StringSplitOptions.None).ToList());
            else if (!m_bUnderBar && m_bBar && m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { '-', ' ' }, StringSplitOptions.None).ToList());
            else if (m_bUnderBar && m_bBar && m_bSpace)
                lstValue.AddRange(sDescription.Split(new char[] { '_', '-', ' ' }, StringSplitOptions.None).ToList());

            return lstValue;
        }

        private int ReplaceLevelValue(string sBefore, string sAfter, GridCell[] cells)
        {
            int iCount = 0;

            try
            {
                object obj = null;
                string sValue = string.Empty;
                string sReplaceValue = string.Empty;
                string sIndex = string.Empty;

                foreach (var who in cells)
                {
                    obj = grvStd.GetRowCellValue(who.RowHandle, who.Column);

                    if (obj == null || obj.GetType() != typeof (string))
                        continue;

                    sValue = (string) obj;
                    sReplaceValue = sValue.Replace(sBefore, sAfter);
                    grvStd.SetRowCellValue(who.RowHandle, who.Column, sReplaceValue);

                    sIndex = who.Column.Caption.Replace("Level", string.Empty);
                    if (!Regex.IsMatch(sIndex, "[0-9]"))
                        continue;

                    TagStandardization(sIndex, who.RowHandle);

                    iCount++;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Replace Error", ex.Message);
                ex.Data.Clear();
                iCount = -1;
            }

            return iCount;
        }

        private void btnStandardDicView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabDesign.SelectedTabPage = tpDesignStandardization;
            grpStdL.Show();
        }

        private void chkStandardizationView_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabDesign.SelectedTabPage = tpDesignStandardization;

            if(chkStandardizationView.Checked)
                grpStdL.Show();
            else
                grpStdL.Hide();
        }

        private void btnStandardization_Click(object sender, EventArgs e)
        {
            btnSymbolStandardization_ItemClick(null, null);
        }

        private void btnStandardApply_Click(object sender, EventArgs e)
        {
            btnStandardizationApply_ItemClick(null, null);
        }


        private void btnSymbolStandardization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.StdTagS.Count == 0)
                {
                    XtraMessageBox.Show("Import PLC First!!", "Standardization", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                tabDesign.SelectedTabPage = tpDesignStandardization;

                FrmParsingOption frmOption = new FrmParsingOption();
                if (frmOption.ShowDialog() != DialogResult.OK)
                    return;

                m_bUnderBar = frmOption.UnderBarOption;
                m_bBar = frmOption.BarOption;
                m_bSpace = frmOption.SpaceOption;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    Standardization();

                    grdStd.RefreshDataSource();
                }
                SplashScreenManager.CloseForm(false);

                XtraMessageBox.Show("PLC 심볼 표준화 진행 완료!!!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Standardization Error",ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnStandardizationApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                tabDesign.SelectedTabPage = tpDesignStandardization;

                if (!m_bStandardization)
                {
                    XtraMessageBox.Show("Implement Standardization First!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (
                    XtraMessageBox.Show("변경된 라이브러리 및 표준화된 PLC 심볼을 적용하고자 합니다.\r\n진행하시겠습니까?", "표준화 적용",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                bool bOK = SaveStdLibrary();

                if (!bOK)
                {
                    XtraMessageBox.Show("PLC 심볼 라이브러리 저장 실패!!", "심볼 표준화", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double dStandardCount = ApplyPLCSymbolName();

                if (dStandardCount < 0)
                {
                    XtraMessageBox.Show("PLC 심볼 표준화 적용 실패!!", "심볼 표준화", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double dTotalCount = CProjectManager.PLCTagS.Count;

                string sMessage = string.Format("표준화 적용 완료 : {0} %", (dStandardCount*100)/dTotalCount);

                //grdPLC.RefreshDataSource();
                grdStd.RefreshDataSource();
                grdDesignPLC.RefreshDataSource();
                //grdVerifPLC.RefreshDataSource();

                XtraMessageBox.Show(sMessage, "심볼 표준화", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Standardization Apply Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLibraryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmStdAddProperty frmAdd = new FrmStdAddProperty();
                frmAdd.TopMost = true;

                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    CProjectManager.StdS.IsEdit = true;

                    grdStdL.DataSource = null;
                    grdStdL.DataSource = CProjectManager.StdS.Values.ToList();
                    grdStdL.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Library Add Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CProjectManager.StdS.Count == 0)
                    return;

                if (
                    XtraMessageBox.Show("해당 심볼 라이브러리 요소를 삭제하시겠습니까?", "Delete Symbol", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int iRowHandle = grvStdL.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CStd cStd = (CStd) grvStdL.GetRow(iRowHandle);

                if (cStd == null)
                    return;

                CProjectManager.StdS.Remove(cStd.CurrentName);
                CProjectManager.StdS.IsEdit = true;

                grdStdL.DataSource = null;
                grdStdL.DataSource = CProjectManager.StdS.Values.ToList();
                grdStdL.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Library Delete Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnHideStdL_Click(object sender, EventArgs e)
        {
            grpStdL.Hide();
        }

        private void grvStd_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvStd_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0)
                    return;

                var obj = grvStd.GetRow(e.RowHandle);
                if (obj.GetType() != typeof (CStdTag))
                    return;

                CStdTag cStdTag = (CStdTag) obj;

                #region Lv1

                if (e.Column.FieldName == "Lv1Name")
                {
                    if (cStdTag.Lv1 != null && cStdTag.Lv1.CurrentParse != string.Empty &&
                        e.Appearance.BackColor != Color.Silver)
                    {
                        if (cStdTag.Lv1.IsStdExist)
                        {
                            if (!cStdTag.Lv1.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv2

                if (e.Column.FieldName == "Lv2Name")
                {
                    if (cStdTag.Lv2 != null && cStdTag.Lv2.CurrentParse != string.Empty &&
                        e.Appearance.BackColor != Color.Silver)
                    {
                        if (cStdTag.Lv2.IsStdExist)
                        {
                            if (!cStdTag.Lv2.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv3

                if (e.Column.FieldName == "Lv3Name")
                {
                    if (cStdTag.Lv3 != null && cStdTag.Lv3.CurrentParse != string.Empty &&
                        e.Appearance.BackColor != Color.Silver)
                    {
                        if (cStdTag.Lv3.IsStdExist)
                        {
                            if (!cStdTag.Lv3.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv4

                if (e.Column.FieldName == "Lv4Name")
                {
                    if (cStdTag.Lv4 != null && cStdTag.Lv4.CurrentParse != string.Empty &&
                        e.Appearance.BackColor != Color.Silver)
                    {
                        if (cStdTag.Lv4.IsStdExist)
                        {
                            if (!cStdTag.Lv4.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv5

                if (e.Column.FieldName == "Lv5Name")
                {
                    if (cStdTag.Lv5 != null && cStdTag.Lv5.CurrentParse != string.Empty &&
                        e.Appearance.BackColor != Color.Silver)
                    {
                        if (cStdTag.Lv5.IsStdExist)
                        {
                            if (!cStdTag.Lv5.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv6

                if (e.Column.FieldName == "Lv6Name" && cStdTag.Lv6.CurrentParse != string.Empty &&
                    e.Appearance.BackColor != Color.Silver)
                {
                    if (cStdTag.Lv6 != null)
                    {
                        if (cStdTag.Lv6.IsStdExist)
                        {
                            if (!cStdTag.Lv6.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv7

                if (e.Column.FieldName == "Lv7Name" && cStdTag.Lv7.CurrentParse != string.Empty &&
                    e.Appearance.BackColor != Color.Silver)
                {
                    if (cStdTag.Lv7 != null)
                    {
                        if (cStdTag.Lv7.IsStdExist)
                        {
                            if (!cStdTag.Lv7.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv8

                if (e.Column.FieldName == "Lv8Name" && cStdTag.Lv8.CurrentParse != string.Empty &&
                    e.Appearance.BackColor != Color.Silver)
                {
                    if (cStdTag.Lv8 != null)
                    {
                        if (cStdTag.Lv8.IsStdExist)
                        {
                            if (!cStdTag.Lv8.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv9

                if (e.Column.FieldName == "Lv9Name" && cStdTag.Lv9.CurrentParse != string.Empty &&
                    e.Appearance.BackColor != Color.Silver)
                {
                    if (cStdTag.Lv9 != null)
                    {
                        if (cStdTag.Lv9.IsStdExist)
                        {
                            if (!cStdTag.Lv9.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion

                #region Lv10

                if (e.Column.FieldName == "Lv10Name" && cStdTag.Lv10.CurrentParse != string.Empty &&
                    e.Appearance.BackColor != Color.Silver)
                {
                    if (cStdTag.Lv10 != null)
                    {
                        if (cStdTag.Lv10.IsStdExist)
                        {
                            if (!cStdTag.Lv10.IsChanged)
                            {
                                e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                                e.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = System.Drawing.Color.Orange;
                                e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = System.Drawing.Color.Salmon;
                            e.Appearance.BackColor2 = System.Drawing.Color.Salmon;
                        }
                    }
                }

                #endregion
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvStd RowCellStyle Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvStdL_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvStd_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                string sIndex = e.Column.Caption.Replace("Level", string.Empty);
                if (!Regex.IsMatch(sIndex, "[0-9]"))
                    return;

                TagStandardization(sIndex, iRowHandle);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvStd CellValueChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkStdLExist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStdLExist.Checked)
            {
                chkStdLNotExist.Checked = false;
                chkStandardization.Checked = false;
            }

            if (!m_bStandardization)
                return;

            if (chkStdLExist.Checked)
            {
                grdStd.DataSource = CProjectManager.StdTagS.Values.Where(x => x.IsStandard).ToList();
                grdStd.RefreshDataSource();
            }
            else
            {
                grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
                grdStd.RefreshDataSource();
            }
        }

        private void chkStdLNotExist_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkStdLNotExist.Checked)
                {
                    chkStdLExist.Checked = false;
                    chkStandardization.Checked = false;
                }

                if (!m_bStandardization)
                    return;

                if (chkStdLNotExist.Checked)
                {
                    grdStd.DataSource = CProjectManager.StdTagS.Values.Where(x => x.IsStdLNotExist).ToList();
                    grdStd.RefreshDataSource();
                }
                else
                {
                    grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
                    grdStd.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("chkStdNotExist Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkStandardization_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkStandardization.Checked)
                {
                    chkStdLNotExist.Checked = false;
                    chkStdLExist.Checked = false;
                }

                if (!m_bStandardization)
                    return;

                if (chkStandardization.Checked)
                {
                    grdStd.DataSource = CProjectManager.StdTagS.Values.Where(x => x.IsStandardization).ToList();
                    grdStd.RefreshDataSource();
                }
                else
                {
                    grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
                    grdStd.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("chkStandardization Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvStd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuStandard.ShowPopup(CurrentPoint);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvStd Mouse Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAllLevelClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("선택하신 태그의 모든 레벨을 Clear 하시겠습니까?", "Clear Level", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CStdTag cTag = (CStdTag) grvStd.GetRow(iRowHandle);

                foreach (var who in cTag.LevelS)
                    who.Clear();

                cTag.TargetDesc = string.Empty;

                grdStd.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Level Clear", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAddLibrary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvStd.GetRowCellValue(iRowHandle, grvStd.FocusedColumn);

                if (obj == null)
                    return;

                string sValue = (string) obj;

                CStdTag cTag = (CStdTag) grvStd.GetRow(iRowHandle);
                string sIndex = grvStd.FocusedColumn.Caption.Replace("Level", string.Empty);
                if (!Regex.IsMatch(sIndex, "[0-9]"))
                    return;

                int iIndex = Convert.ToInt32(sIndex);

                CLevel cLv = cTag.LevelS[iIndex - 1];

                if (cLv == null)
                    return;

                if (CProjectManager.StdS.ContainsKey(sValue) || cLv.IsStdExist)
                {
                    XtraMessageBox.Show("해당 \"" + sValue + "\" 이름은 이미 라이브러리에 존재합니다.", "Add Library", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                FrmStdAddProperty frmAdd = new FrmStdAddProperty();
                frmAdd.CurrentName = sValue;
                frmAdd.TopMost = true;

                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    CProjectManager.StdS.IsEdit = true;

                    grdStdL.DataSource = null;
                    grdStdL.DataSource = CProjectManager.StdS.Values.ToList();
                    grdStdL.RefreshDataSource();
                }

                frmAdd.Dispose();
                frmAdd = null;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Add Library", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLevelLeftMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CStdTag cTag = (CStdTag)grvStd.GetRow(iRowHandle);
                string sIndex = grvStd.FocusedColumn.Caption.Replace("Level", string.Empty);
                if (!Regex.IsMatch(sIndex, "[0-9]"))
                    return;

                int iIndex = Convert.ToInt32(sIndex);

                if (iIndex <= 1)
                    return;

                CLevel cFirstLv = cTag.GetLevel(iIndex);
                CLevel cLvTemp = cTag.GetLevel(iIndex).Clone();
                CLevel cLastLv = cTag.GetLevel(iIndex - 1);

                cFirstLv = null;
                cFirstLv = cLastLv.Clone();
                cLastLv = null;
                cLastLv = cLvTemp;

                cTag.TargetDesc = GetTargetDesc(cTag);

                grdStd.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Level Left Move", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLevelRightMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int iRowHandle = grvStd.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CStdTag cTag = (CStdTag)grvStd.GetRow(iRowHandle);
                string sIndex = grvStd.FocusedColumn.Caption.Replace("Level", string.Empty);
                if (!Regex.IsMatch(sIndex, "[0-9]"))
                    return;

                int iIndex = Convert.ToInt32(sIndex);

                if (iIndex >= 10)
                    return;

                CLevel cLvTemp = cTag.LevelS[iIndex - 1].Clone();

                cTag.LevelS[iIndex - 1] = null;
                cTag.LevelS[iIndex - 1] = cTag.LevelS[iIndex].Clone();
                cTag.LevelS[iIndex] = null;
                cTag.LevelS[iIndex] = cLvTemp;

                cTag.TargetDesc = GetTargetDesc(cTag);

                grdStd.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Level Left Move", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnReplace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridCell[] cells = grvStd.GetSelectedCells();

                if (cells.Length < 1)
                {
                    XtraMessageBox.Show("변경하고자 하는 영역을 선택하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmReplace frmReplace = new FrmReplace();
                if (frmReplace.ShowDialog() != DialogResult.OK)
                    return;

                string sBefore = frmReplace.BeforeText;
                string sAfter = frmReplace.AfterText;

                frmReplace.Dispose();
                frmReplace = null;

                int iReplaceCount = ReplaceLevelValue(sBefore, sAfter, cells);

                if (iReplaceCount >= 0)
                    XtraMessageBox.Show(iReplaceCount.ToString() + "개가 바뀌었습니다.\r\n 변경 성공!!!", "Replace",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Replace Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
