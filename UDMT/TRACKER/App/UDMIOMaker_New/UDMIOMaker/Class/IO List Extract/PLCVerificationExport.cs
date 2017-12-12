using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using UDM.Common;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace UDMIOMaker
{
    public class PLCVerificationExport
    {
        public string OutputPath = string.Empty;
        public string Path = System.Windows.Forms.Application.StartupPath + "\\ExcelTemplate\\PLCVerification_Template.xls";
        public string PathUser = System.Windows.Forms.Application.StartupPath + "\\ExcelTemplate\\PLCVerification_User_Template.xls";

        public TagCellNumber TagNumber = new TagCellNumber();

        #region Intialize/Dispose

        public PLCVerificationExport()
        {

        }

        public PLCVerificationExport(VerificationList list)
        {
            WirteUserExcel(list);
        }

        #endregion

        private void WirteUserExcel(VerificationList list)
        {

            var app = new Microsoft.Office.Interop.Excel.Application { Visible = false, DisplayAlerts = false };
            if (File.Exists(PathUser))
            {
                var workbook = app.Workbooks.Open(Path, 0, false, 5, "", "", false,
                                                   XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                InputUserData(list, workbook);
                workbook.SaveAs(PathUser, XlFileFormat.xlWorkbookNormal,
                                Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
                                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                workbook = null;

            }

            app.Quit();
            app = null;
        }

        private void InputUserData(VerificationList list, Workbook workbook)
        {
            var sheets = workbook.Sheets;
            var sheet = (Worksheet)sheets[1];

            sheet.Cells[TagNumber.symbol, TagNumber.count] = list.symbol;
            sheet.Cells[TagNumber.logic, TagNumber.count] = list.logic;
            sheet.Cells[TagNumber.symbolandlogic, TagNumber.count] = list.memoryboth;
            sheet.Cells[TagNumber.contact, TagNumber.count] = list.contact;
            sheet.Cells[TagNumber.coil, TagNumber.count] = list.coil;
            sheet.Cells[TagNumber.contactandcoil, TagNumber.count] = list.contactboth;
            sheet.Cells[TagNumber.dateRow, TagNumber.dataColumn] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void WirteUserExcel(string name , CVerifTagS cTagS)
        {
            bool bOK = true;

            var app = new Microsoft.Office.Interop.Excel.Application { Visible = false, DisplayAlerts = false };
            if (File.Exists(PathUser))
            {
                var workbook = app.Workbooks.Open(PathUser, 0, false, 5, "", "", false,
                                                   XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                Worksheet sheet = null;

                foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                {
                    if (worksheet.Name == name)
                    {
                        bOK = false;
                        break;
                    }
                }

                if (bOK)
                {
                    sheet = (Worksheet) workbook.Sheets[workbook.Sheets.Count];

                    sheet.Copy(Type.Missing, sheet);
                    sheet.Name = name;

                    InputHyperlink(name, cTagS.Count, (Worksheet) workbook.Sheets[1]);
                    InputUserData(name, cTagS, sheet);

                    var startSheet = (Worksheet) workbook.Sheets[workbook.Sheets.Count - 1];
                    startSheet.Select(Type.Missing);

                    workbook.SaveAs(PathUser, XlFileFormat.xlWorkbookNormal,
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

        private void InputUserData(string name, CVerifTagS cTagS, Worksheet sheet)
        {
            TagNumber.NewStart();
            sheet.Cells[TagNumber.nameRow, TagNumber.nameColumn] = name;

            AddPageBreaks(sheet, cTagS.Count);

            foreach(var who in cTagS)
            {
                sheet.Cells[TagNumber.startRow, TagNumber.contentsAddress] = who.Value.Address;
                sheet.Cells[TagNumber.startRow, TagNumber.contentsName] = who.Value.Name;
                sheet.Cells[TagNumber.startRow, TagNumber.contentsDescription] = who.Value.Description;
                sheet.Cells[TagNumber.startRow, TagNumber.contentsUsedLogic] = who.Value.UsedLogic.ToString();
                sheet.Cells[TagNumber.startRow, TagNumber.contentsSymbolRole] = who.Value.SymbolRole.ToString();
                sheet.Cells[TagNumber.startRow, TagNumber.contentsOption] = name;

                TagNumber.startRow++;
            }
        }

        private void AddPageBreaks(Worksheet sheet, int length)
        {
            if (length < 40)
                return;

            var iPage = Math.Ceiling((double)(length - TagNumber.size) / (double)TagNumber.otherSize);
            var startIndex = 44;

            for (var i = 1; i < iPage; i++)
            {
                var startBreak = startIndex;
                var endBreak = startIndex + TagNumber.otherSize - 1;

                sheet.HPageBreaks.Add(sheet.Range["A" + startBreak.ToString()]);
                sheet.HPageBreaks.Add(sheet.Range["A" + endBreak.ToString()]);

                startIndex = startIndex + TagNumber.otherSize;
            }

            sheet.VPageBreaks.Add(sheet.Range["G1"]);
            
        }

        private void InputHyperlink(string name, int count, Worksheet sheet)
        {

            sheet.Cells[TagNumber.UserLogicCount, TagNumber.count] = count;
            sheet.Cells[TagNumber.UserLogicCount, TagNumber.count - 1] = name;

            var cell = (Range)sheet.Cells[TagNumber.UserLogicCount, TagNumber.count - 1];
            sheet.Hyperlinks.Add(sheet.get_Range(cell, cell), "#" + name + "!A1", Type.Missing, Type.Missing, Type.Missing);

            TagNumber.UserLogicCount++;
        }

        #region ExportMode Excel or PDF

        public void ExportToExcel(string iPath, string oPath, EMPLCVerificationMenu type)
        {
            var app = new Application();
            var workbook = app.Workbooks.Open(iPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            var startSheet = (Worksheet)workbook.Sheets[1];
            startSheet.Select(Type.Missing);

            SaveasMode(workbook, type, oPath);
            workbook.Close(true, Type.Missing, Type.Missing);
            workbook = null;

            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
        }

        private void SaveasMode(Workbook workbook, EMPLCVerificationMenu type, string outpath)
        {
            switch (type)
            {
                case EMPLCVerificationMenu.ExportToExcel:
                    workbook.SaveAs(outpath, XlFileFormat.xlWorkbookDefault, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    break;
                case EMPLCVerificationMenu.ExportToPdf:
                    workbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, outpath);
                    break;
            }
        }
        
        #endregion
    }
}
