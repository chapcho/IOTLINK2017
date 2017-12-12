using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using UDM.Common;
using Application = System.Windows.Forms.Application;
using Excel = Microsoft.Office.Interop.Excel.Application;
using Point = System.Drawing.Point;
using Worksheet = DevExpress.Spreadsheet.Worksheet;

namespace UDMIOMaker
{
    public partial class FrmMain
    {
        private string m_sHMIVerifPath = Application.StartupPath + "\\ExcelTemplate\\HMIVerification_Template.xls";
        private string m_sHMIVerifUserPath = Application.StartupPath + "\\ExcelTemplate\\HMIVerification_User_Template.xls";

        private bool m_bHMIVerify = false;
        private int m_iOptionRow = 11;
        
        private void ShowHMIVerifGrid()
        {
            grdVerifHMI.DataSource = null;
            grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.ToList();
            grdVerifHMI.RefreshDataSource();
        }

        private void LoadHMIVerificationExceltoSheet(string sPath)
        {
            try
            {

                var finfo = new System.IO.FileInfo(sPath);
                if (finfo.Exists && !IsFileLocked(finfo))
                    sheetHMIVerification.LoadDocument(sPath);
                else
                    ExceptionHMISheetLoad();

            }
            catch (Exception ex)
            {
                ExceptionHMISheetLoad();
                Console.WriteLine(ex.Message);
            }
        }

        private void ExceptionHMISheetLoad()
        {
            var workbook = sheetVerification.Document;
            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell1 = worksheet.Cells[0, 0];
            cell1.Value = "템플릿 파일로드에 실패 했습니다.";

            Cell cell2 = worksheet.Cells[1, 0];
            cell2.Value = "PLCVerification_Template.xls 파일이 사용 중이거나 파일이 없습니다. ";

            Cell cell3 = worksheet.Cells[2, 0];
            cell3.Value = "프로세스 종료 후 다시 시도해주세요.";
        }

        private void AutoHMIVerification()
        {
            List<string> lstHMIKey = null;

            foreach(var who in CProjectManager.HMITagS)
            {
                if (who.Value.IsEmpty)
                    continue;

                lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(who.Value.Address, who.Value.Description);

                if (lstHMIKey.Count == 1)
                    who.Value.IsMatch = true;
                else if (lstHMIKey.Count > 1)
                {
                    foreach (string sKey in lstHMIKey)
                        CProjectManager.HMITagS[sKey].IsRedundancy = true;
                }
            }

            colVerifHMIAddress.SortOrder = ColumnSortOrder.Descending;
            colHMIAddress.SortOrder = ColumnSortOrder.Descending;
            grdVerifHMI.RefreshDataSource();
            grdHMI.RefreshDataSource();
            grdPLC.RefreshDataSource();
        }

        private void WriteHMIVerificationToExcel()
        {
            var app = new Microsoft.Office.Interop.Excel.Application{Visible = false, DisplayAlerts = false};
            if (File.Exists(m_sHMIVerifUserPath))
            {
                var workbook = app.Workbooks.Open(m_sHMIVerifPath, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                InputHMIVerificationData(workbook);

                workbook.SaveAs(m_sHMIVerifUserPath, XlFileFormat.xlWorkbookNormal,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                workbook.Close(Missing.Value, Missing.Value, Missing.Value);
            }
            app.Quit();
            app = null;
        }

        private void InputHMIVerificationData(Workbook workbook)
        {
            var sheets = workbook.Sheets;
            var sheet = (Microsoft.Office.Interop.Excel.Worksheet) sheets[1];

            sheet.Cells[4, 4] = CProjectManager.HMITagS.Values.Where(x => x.IsMatch).Count();
            sheet.Cells[5, 4] = CProjectManager.HMITagS.Values.Where(x => x.IsRedundancy).Count();
            sheet.Cells[6, 4] = CProjectManager.HMITagS.Values.Where(x => x.IsEmpty).Count();

            sheet.Cells[26, 6] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private CHMITag GetVerifHMITag(int iHandle)
        {
            CHMITag cHMITag = null;

            if (iHandle < 0)
                return null;

            object oData = grvVerifHMI.GetRow(iHandle);
            if (oData.GetType() != typeof(CHMITag))
                return null;

            cHMITag = (CHMITag)oData;

            return cHMITag;
        }

        private void WriteOptionVerification(string sOption, CHMITagS cTagS)
        {
            bool bOK = true;

            var app = new Microsoft.Office.Interop.Excel.Application { Visible = false, DisplayAlerts = false };
            if (File.Exists(m_sHMIVerifUserPath))
            {
                var workbook = app.Workbooks.Open(m_sHMIVerifUserPath, 0, false, 5, "", "", false,
                                                   XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                Microsoft.Office.Interop.Excel.Worksheet sheet = null;

                foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                {
                    if (worksheet.Name == sOption)
                    {
                        bOK = false;
                        break;
                    }
                }

                if (bOK)
                {
                    sheet = (Microsoft.Office.Interop.Excel.Worksheet) workbook.Sheets[workbook.Sheets.Count];

                    sheet.Copy(Type.Missing, sheet);
                    sheet.Name = sOption;

                    InputHyperLinkOption(sOption, cTagS.Count,
                        (Microsoft.Office.Interop.Excel.Worksheet) workbook.Sheets[1]);
                    InputOptionData(sOption, cTagS, sheet);

                    var startSheet =
                        (Microsoft.Office.Interop.Excel.Worksheet) workbook.Sheets[workbook.Sheets.Count - 1];
                    startSheet.Select(Type.Missing);

                    workbook.SaveAs(m_sHMIVerifUserPath, XlFileFormat.xlWorkbookNormal,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }
                else
                    XtraMessageBox.Show("동일한 Option Name이 선언되어 있습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                sheet = null;
                workbook = null;

            }

            app.Quit();
            app = null;
        }

        private void InputHyperLinkOption(string sOption, int iCount, Microsoft.Office.Interop.Excel.Worksheet sheet)
        {
            sheet.Cells[m_iOptionRow, 3] = sOption;
            sheet.Cells[m_iOptionRow, 4] = iCount;

            var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[m_iOptionRow, 3];
            sheet.Hyperlinks.Add(sheet.get_Range(cell, cell), "#" + sOption + "!A1", Type.Missing, Type.Missing, Type.Missing);

            m_iOptionRow++;
        }

        private void InputOptionData(string sOption, CHMITagS cTagS, Microsoft.Office.Interop.Excel.Worksheet sheet)
        {
            sheet.Cells[2, 1] = sOption;

            int iStartRow = 5;

            foreach (var who in cTagS)
            {
                sheet.Cells[iStartRow, 1] = who.Value.Group;
                sheet.Cells[iStartRow, 2] = who.Value.Name;
                sheet.Cells[iStartRow, 3] = who.Value.Description;
                sheet.Cells[iStartRow, 4] = who.Value.Address;
                sheet.Cells[iStartRow, 5] = who.Value.DataType;

                iStartRow++;
            }
        }

        private void SetUserDefineHMIExcelSheet(string sOption)
        {
            CHMITagS cTagS = new CHMITagS();
            CHMITag cTag = null;

            int[] arrView = grvVerifHMI.GetSelectedRows();

            if (arrView.Length < 1)
            {
                XtraMessageBox.Show("추가 하고자 하는 항목에 해당하는 Rows를 선택하세요!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < arrView.Length; i++)
            {
                cTag = GetVerifHMITag(arrView[i]);
                cTagS.Add(cTag.Name, cTag);
            }
            WriteOptionVerification(sOption, cTagS);
            LoadHMIVerificationExceltoSheet(m_sHMIVerifUserPath);
        }

        private void MappingCancel()
        {
            int iRowHandle = grvVerifHMI.FocusedRowHandle;

            object obj = grvVerifHMI.GetRow(iRowHandle);

            if (obj == null)
                return;

            if (obj.GetType() != typeof(CHMITag))
                return;

            CHMITag cTag = (CHMITag) obj;

            List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Address, cTag.Description);

            if (lstHMIKey.Count == 1)
            {
                if (cTag.PLCTagKey != string.Empty && CProjectManager.PLCTagS.ContainsKey(cTag.PLCTagKey))
                    CProjectManager.PLCTagS[cTag.PLCTagKey].IsHMIMapping = false;
            }
            else if (lstHMIKey.Count == 2)
            {
                foreach (string sKey in lstHMIKey)
                    CProjectManager.HMITagS[sKey].IsRedundancy = false;
            }

            cTag.IsMatch = false;
            cTag.IsRedundancy = false;
            cTag.IsEmpty = false;

            cTag.Address = string.Empty;
            cTag.Description = string.Empty;
            cTag.DataType = string.Empty;
            cTag.PLCTagKey = string.Empty;

            grdVerifHMI.RefreshDataSource();
            grdHMI.RefreshDataSource();
            grdPLC.RefreshDataSource();
        }

        private void ExportHMIVerificationReport(bool bExcel)
        {
            try
            {
                sheetHMIVerification.Options.Save.CurrentFileName = "HMIVerificationReport_" +
                                                                    DateTime.Now.ToString("yyyy-MM-dd");

                if (bExcel)
                    sheetHMIVerification.SaveDocumentAs();
                else
                {
                    SaveFileDialog dlgSave = new SaveFileDialog {Filter = @"*.pdf|*.pdf"};
                    dlgSave.FileName = "HMIVerificationReport_" + DateTime.Now.ToString("yyyy-MM-dd");
                    if (dlgSave.ShowDialog() == DialogResult.OK)
                        sheetHMIVerification.ExportToPdf(dlgSave.FileName);
                }
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show("Export Fail!!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CProjectManager.UpdateSystemMessage("Export HMI Report", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void ViewVerifMappedHMI()
        {
            int iRowHandle = grvVerifHMI.FocusedRowHandle;

            CHMITag cTag = GetVerifHMITag(iRowHandle);

            if (cTag == null)
                return;

            List<string> lstMappedHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Address, cTag.Description);

            if (lstMappedHMIKey.Count <= 1)
                return;

            FrmRedundancyHMI frmView = new FrmRedundancyHMI();
            frmView.MappedHMIKeyList = lstMappedHMIKey;
            frmView.UHMIGridDoubleClickEvent += FrmRedundancay_VerfiHMIGridDoubleClick;
            frmView.Show();
        }

        private void ViewMappedVerifHMI(string sHMIKey)
        {
            int iRowHandle = -1;
            string sTemp = string.Empty;

            for (int i = 0; i < CProjectManager.HMITagS.Count; i++)
            {
                sTemp = grvVerifHMI.GetRowCellDisplayText(i, "Name");

                if (sTemp == sHMIKey)
                {
                    iRowHandle = i;
                    break;
                }
            }

            grvVerifHMI.SelectRow(iRowHandle);
            grvVerifHMI.FocusedRowHandle = iRowHandle;
        }


        private void ViewHMIMappingContainRedundancy(bool bCheck)
        {
            if (CProjectManager.HMITagS.Count == 0)
                return;

            grdVerifHMI.DataSource = null;

            if (bCheck)
            {
                List<CHMITag> lstTag = new List<CHMITag>();
                lstTag.AddRange(CProjectManager.HMITagS.Values.Where(x => x.IsMatch == true));

                grdVerifHMI.DataSource = lstTag;
            }
            else
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.ToList();

            grdVerifHMI.RefreshDataSource();
        }

        private void ViewHMIMappingNotContainRedundancy(bool bCheck)
        {
            if (CProjectManager.HMITagS.Count == 0)
                return;

            grdVerifHMI.DataSource = null;

            if (bCheck)
            {
                List<CHMITag> lstTag = new List<CHMITag>();
                lstTag.AddRange(CProjectManager.HMITagS.Values.Where(x => x.IsMatch == true).Where(x => x.IsRedundancy == false));
                lstTag.AddRange(CProjectManager.HMITagS.Values.Where(x => x.IsInsert == true).Where(x => x.IsRedundancy == false));

                grdVerifHMI.DataSource = lstTag;
            }
            else
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.ToList();

            grdVerifHMI.RefreshDataSource();
        }

        private void ViewHMIEmpty(bool bCheck)
        {
            if (CProjectManager.HMITagS.Count == 0)
                return;

            grdVerifHMI.DataSource = null;

            if (bCheck)
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.Where(x => x.IsEmpty).ToList();
            else
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.ToList();

            grdVerifHMI.RefreshDataSource();
        }

        private void ViewHMIRedundancy(bool bCheck)
        {
            if (CProjectManager.HMITagS.Count == 0)
                return;

            grdVerifHMI.DataSource = null;

            if (bCheck)
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.Where(x => x.IsRedundancy).ToList();
            else
                grdVerifHMI.DataSource = CProjectManager.HMITagS.Values.ToList();

            grdVerifHMI.RefreshDataSource();
        }

        private void FrmRedundancay_VerfiHMIGridDoubleClick(string sHMIKey)
        {
            ViewMappedVerifHMI(sHMIKey);
        }

        private void btnHMIClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnClearHMI_Click(null, null);

            m_bHMIVerify = false;
        }

        private void btnAutoHMIVerif_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.HMITagS.Count == 0)
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    AutoHMIVerification();

                    m_bHMIVerify = true;

                    WriteHMIVerificationToExcel();
                    LoadHMIVerificationExceltoSheet(m_sHMIVerifUserPath);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMIAutoVerification Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnHMIOptionAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!m_bHMIVerify)
                {
                    XtraMessageBox.Show("Auto HMI Verification First!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string sOption = string.Empty;

                sOption = (string) txtHMIOptionName.EditValue;

                if (sOption == null)
                {
                    XtraMessageBox.Show("Input User Define Option Name!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (sOption.Contains(" "))
                    sOption = sOption.Replace(" ", "_");

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    SetUserDefineHMIExcelSheet(sOption);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMI Option Add Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvVerifHMI_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                var View = sender as GridView;
                bool bOK = false;

                if (e.Column.FieldName == "Address")
                {
                    object obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsEmpty"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(229, 224, 236);
                        e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(204, 193, 217);
                    }

                    obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsRedundancy"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.BackColor2 = Color.OrangeRed;
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("VerifHMI RowcellStyle Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvVerifHMI_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                //grvVerifHMI.FocusedColumn.BestFit();
                ViewVerifMappedHMI();
                //SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grdVerifHMI Best Fit Exception", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void grvVerifHMI_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuVerifHMI.ShowPopup(CurrentPoint);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("VerifHMI Mouse Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnVerifMappingCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MappingCancel();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Cancel Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnVerifHMIExcelExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.HMITagS.Count == 0 || !m_bHMIVerify)
                {
                    XtraMessageBox.Show("Export Fail!!\r\nPlease Set HMI Verification First!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    ExportHMIVerificationReport(true);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Verif Excel Export Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnVerifHMIPDFExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.HMITagS.Count == 0 || !m_bHMIVerify)
                {
                    XtraMessageBox.Show("Export Fail!!\r\nPlease Set HMI Verification First!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    ExportHMIVerificationReport(false);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Verif HMI PDF Export Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMappingRedun_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMapping.Checked)
                {
                    chkNullEmpty.Checked = false;
                    chkRedundancy.Checked = false;
                }

                ViewHMIMappingNotContainRedundancy(chkMapping.Checked);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Redun Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMappingNotRedun_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNullEmpty.Checked)
                {
                    chkMapping.Checked = false;
                    chkRedundancy.Checked = false;
                }

                ViewHMIEmpty(chkNullEmpty.Checked);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Not Redun Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkRedundancy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRedundancy.Checked)
                {
                    chkMapping.Checked = false;
                    chkNullEmpty.Checked = false;
                }

                ViewHMIRedundancy(chkRedundancy.Checked);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Redundancy Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
