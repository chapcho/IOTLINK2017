using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using Microsoft.Office.Interop.Excel;
using UDM.Common;
using UDM.UI;

namespace UDMIOMaker
{
    public partial class FrmErrorListProperty : DevExpress.XtraEditors.XtraForm
    {
        public FrmErrorListProperty()
        {
            InitializeComponent();
        }

        private void ShowTabPageS()
        {

            tabError.TabPages.Clear();
            XtraTabPage tp = null;
            UCErrorFilter ucFilter = null;
            foreach (var who in CProjectManager.ErrorFilterS)
            {
                tp = new XtraTabPage();
                tp.Name = who.Key;
                tp.Text = who.Key;

                ucFilter = new UCErrorFilter();
                ucFilter.ErrorFilter = who.Value;
                ucFilter.Dock = DockStyle.Fill;
                ucFilter.Name = who.Key;
                tp.Controls.Add(ucFilter);

                tabError.TabPages.Add(tp);
            }
        }

        private void ClearTabPageS()
        {
            tabError.TabPages.Clear();
        }

        private DataSet GetDataSet()
        {
            if (CProjectManager.ErrorFilterS.Count == 0)
                return null;

            bool bOK = false;

            DataSet DS = new DataSet();
            System.Data.DataTable DT;

            foreach (var who in CProjectManager.ErrorFilterS)
            {
                DT = new System.Data.DataTable();
                DT.Columns.Add("Description");
                DT.Columns.Add("Address");
                DT.TableName = who.Key;

                DataRow drRow;

                foreach (var who2 in CProjectManager.PLCTagS)
                {
                    if (who2.Value.DataType != EMDataType.Bool)
                        continue;

                    string sDescription = who2.Value.Description;

                    foreach (string sFilter in who.Value.ErrorFilter)
                    {
                        if (sFilter == string.Empty)
                            continue;

                        if (sDescription.Contains(sFilter))
                        {
                            bOK = true;

                            foreach (string sNotFilter in who.Value.ErrorNotContainFilter)
                            {
                                if (sNotFilter == string.Empty)
                                    continue;

                                if (sDescription.Contains(sNotFilter))
                                {
                                    bOK = false;
                                    break;
                                }
                            }

                            if (bOK)
                            {
                                drRow = DT.NewRow();
                                drRow[0] = who2.Value.Description;
                                drRow[1] = who2.Value.Address;

                                DT.Rows.Add(drRow);
                            }
                        }
                    }
                }

                DS.Tables.Add(DT);
            }

            return DS;
        }

        private bool ExportToErrorList()
        {
            bool bOK = false;

            try
            {
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "*.xls|*.xls";
                if (dlgSave.ShowDialog() != DialogResult.OK)
                    return false;

                DataSet DS = GetDataSet();

                string sPath = dlgSave.FileName;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Add(true);

                bOK = true;

                Worksheet worksheet = null;
                for (int i = 0; i < DS.Tables.Count; i++)
                {
                    worksheet = (Worksheet) excelWorkbook.Sheets.Add();
                    SetSheetData(worksheet, DS.Tables[i]);
                }

                excelWorkbook.SaveAs(sPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

                // Release the Application object   
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                excelApp = null;

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export Fail!!", "Export Error List", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                CProjectManager.UpdateSystemMessage("Error List Export Fail", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private void SetSheetData(Worksheet ws, System.Data.DataTable DT)
        {
            ws.Name = DT.TableName;

            ws.Cells[1, 1] = DT.Columns[0].ColumnName;
            ws.Cells[1, 2] = DT.Columns[1].ColumnName;

            int iRowIndex = 2;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                ws.Cells[iRowIndex, 1] = DT.Rows[i][0];
                ws.Cells[iRowIndex, 2] = DT.Rows[i][1];

                iRowIndex++;
            }

            Range range = ws.get_Range("A1", "B" + iRowIndex);
            range.Columns.AutoFit();
        }

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.IsModuleVisible = false;
            dlgInput.TopMost = true;

            if (dlgInput.ShowDialog() != DialogResult.OK)
                return string.Empty;

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        private void UpateErrorFilterS()
        {
            XtraTabPage tp = null;
            UCErrorFilter ucFilter = null;
            foreach (var who in tabError.TabPages)
            {
                if (who.GetType() != typeof(XtraTabPage))
                    continue;

                tp = (XtraTabPage)who;

                if (tp.Controls.ContainsKey(tp.Name))
                {
                    ucFilter = (UCErrorFilter)tp.Controls[tp.Name];
                    ucFilter.UpdateErrorFilter();
                }
            }
        }

        private void FrmErrorListProperty_Load(object sender, EventArgs e)
        {
            if (CProjectManager.ErrorFilterS.Count == 0)
                return;

            ShowTabPageS();
        }

        private void btnSheetAdd_Click(object sender, EventArgs e)
        {
            string sSheetName = GetUserInputText("시트 이름", "시트 이름을 입력하세요.");

            if (sSheetName == string.Empty)
                return;

            if (CProjectManager.ErrorFilterS.ContainsKey(sSheetName))
            {
                XtraMessageBox.Show("해당 이름은 이미 추가된 이름입니다.\r\n다시 이름을 설정하세요.", "Sheet Name", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (Regex.IsMatch(sSheetName, "[\\\\/:*?\"<>|]"))
            {
                XtraMessageBox.Show("Sheet Name에 [\\, /, :, *, ?, \", <, >, |]가 포함될 수 없습니다.\r\n다시 이름을 설정하세요.",
                    "Sheet Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CErrorFilter cFilter = new CErrorFilter();
            CProjectManager.ErrorFilterS.Add(sSheetName, cFilter);

            XtraTabPage tpError = new XtraTabPage();
            tpError.Name = sSheetName;
            tpError.Text = sSheetName;

            UCErrorFilter ucFilter = new UCErrorFilter();
            ucFilter.ErrorFilter = cFilter;
            ucFilter.Name = sSheetName;
            ucFilter.Dock = DockStyle.Fill;
            tpError.Controls.Add(ucFilter);

            tabError.TabPages.Add(tpError);
        }

        private void btnSheetDelete_Click(object sender, EventArgs e)
        {
            string sName = tabError.SelectedTabPage.Text;

            if (
                XtraMessageBox.Show(sName + "시트를 삭제하시겠습니까?", "Sheet Delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CProjectManager.ErrorFilterS.Remove(sName);
                tabError.TabPages.Remove(tabError.SelectedTabPage);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bOK = false;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                UpateErrorFilterS();
                bOK = ExportToErrorList();
            }
            SplashScreenManager.CloseForm(false);

            if (bOK)
            {
                XtraMessageBox.Show("Export Error List Success!!", "에러 리스트", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}