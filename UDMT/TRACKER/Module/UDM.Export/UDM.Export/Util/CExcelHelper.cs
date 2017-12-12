using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;


namespace UDM.Export
{
    public delegate void UEventHandlerProcess(object sender, int nProcess);

    public class ExcelHelper
    {
        public class eExcel
        {
            public static string TEMPLATE = "Template";
            public static string MAP = "MAP";
            public const string LIBTABLENAME = "tLIB";
            public const string EPLTABLENAME = "tEPLAN";
            public const char EXCELSPLIT = '˙';
            public const string EXCELYELLOW = "˙．";
            public const string EXCELAQUA = "˙˘";
        }
    

        //0=xls , 1=xlsx, 2=csv, 3=sdf
        public enum eFileType
        {
            XLS,
            XLSX,
            CSV,
            SDF,
        }

        public static event UEventHandlerProcess UEventProcessChanged;

        // 확장명 XLS (Excel 97~2003 용)
        private const string ConnectStrFrm_Excel97_2003 =
            "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 8.0; HDR={1}; IMEX=1';" +
            "Persist Security Info=False";

        // 확장명 XLSX (Excel 2007 이상용)
        private const string ConnectStrFrm_Excel =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 12.0; HDR={1}; IMEX=1';" +
            "Persist Security Info=False";

        // 확장명 csv (csv)
        private const string ConnectStrFrm_CSV =
            "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //"Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=\"{0}\";" +
            "Extended Properties='text; HDR=NO; FMT=Delimited';";

        // TabDelimited : 필드가 탭으로 구분.   
        // CSVDelimited : 필드가 쉼표로 구분.
        // Delimited(*) : 필드가 별표로 구분. 여기에서 별표(*) 대신 큰따옴표(")를 제외한 모든 문자를 사용가능.
        // FixedLength : 텍스트의 필드 너비가 고정.

        public static int ExcelFileType(string XlsFile)
        {
            // result -2=error, -1=not excel , 0=xls , 1=xlsx, 2=csv, 3=sdf
            int result = -1;
            FileInfo FI = new FileInfo(XlsFile);
            switch (FI.Extension.ToLower())
            {
                case (".xls"): result = 0; break;
                case (".xlsx"): result = 1; break;
                case (".csv"): result = 2; break;
                case (".sdf"): result = 3; break;
            }

            return result;
        }

        private static string GetConnectionStr(string FileName, bool bUseHDR)
        {
            string ConnStr = string.Empty;

            int ExcelType = ExcelFileType(FileName);

            switch (ExcelType)
            {
                case (-2): throw new Exception(FileName + "의 형식검사중 오류가 발생하였습니다.");
                case (-1): throw new Exception(FileName + "은 엑셀 파일형식이 아닙니다.");
                case (0):
                    ConnStr = string.Format(ConnectStrFrm_Excel97_2003, FileName, bUseHDR? "YES" : "NO");
                    break;
                case (1):
                    ConnStr = string.Format(ConnectStrFrm_Excel, FileName, bUseHDR ? "YES" : "NO");
                    break;
            }

            return ConnStr;
        }

        public static void WriteSchema(string filePath, string fileName, bool bUnicode, bool bTabDelimited)
        {
            try
            {
                FileStream fsOutput = new FileStream(filePath + "\\schema.ini", FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput);
                string s1, s2, s3, s4, s5;

                s1 = string.Format("[{0}]", fileName);// "[TempFile.csv]";
                s2 = "MaxScanRows=25";
                s3 = "ColNameHeader=false";
                s4 = bTabDelimited ? "Format=TabDelimited" : "Format=CSVDelimited";
                s5 = bUnicode ? "CharacterSet=UNICODE": "CharacterSet=ANSI";

                srOutput.WriteLine(s1 + "\r\n" + s2 + "\r\n" + s3 + "\r\n" + s4 + "\r\n" + s5);
                srOutput.Close();
                fsOutput.Close();
            }          
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteCSV(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(51949));  //51949  euc-kr

                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("{0},", field));
                    str.Remove(str.Length - 1, 1);
                    str.Append("\r\n");
                }

                str.Remove(str.Length - 2, 2);

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteSymbolListOPC(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(51949));

                StringBuilder str = new StringBuilder();

                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("\"{0}\",", field));
                    str.Remove(str.Length - 1, 1);
                    str.Append("\r\n");
                }

                str.Remove(str.Length - 2, 2);

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteSymbolListSiemens(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(51949));

                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("\"{0}\",", field));
                    str.Remove(str.Length - 1, 1);
                    str.Append("\r\n");
                }

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteSymbolListAB(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(51949));  //51949  euc-kr

                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("{0},", field));
                    str.Remove(str.Length - 1, 1);
                    str.Append("\r\n");
                }

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteSymbolListWorks2(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding("utf-16"));

                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("\"{0}\"\t", field));
                    str.Append("\r\n");
                }

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void WriteSymbolListDevoloper(string fileName, System.Data.DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(51949));

                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)
                        str.Append(string.Format("{0},", field));
                    str.Remove(str.Length - 1, 1);
                    str.Append("\r\n");
                }

                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static void DeleteSchema(string filePath)
        {
            try
            {
                File.Delete(filePath + "\\schema.ini");
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public static List<string> OpenTXT(string FileName)
        {
            List<string> lines = new List<string>();

            StreamReader sr = new StreamReader(FileName);
            while (sr.Peek() >= 0)
            {
                lines.Add(sr.ReadLine());
            }

            sr.Close();

            return lines;
        }

        public static DataSet OpenCSV(string FileName, bool bUnicode, bool bTabDelimited)
        {
            WriteSchema(Path.GetDirectoryName(FileName), "TempFile.csv", bUnicode, bTabDelimited);

            string ConnStr = string.Format(ConnectStrFrm_CSV, Path.GetDirectoryName(FileName));
            DataSet DS = new DataSet();
            DS.Tables.Add("CSV");

            OleDbConnection CSVConn = new OleDbConnection(ConnStr);

            try
            {

                CSVConn.Open();
                string cmdText = string.Format("SELECT * FROM [{0}];", Path.GetFileName(FileName));

                OleDbCommand dbCommand = new OleDbCommand(cmdText, CSVConn);
                OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCommand);

                dbAdapter.Fill(DS.Tables[0]);

                DeleteSchema((Path.GetDirectoryName(FileName)));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (CSVConn != null) CSVConn.Close();
            }

            return DS;
        }


        public static DataSet OpenCSVfiles(string[] FileNames, bool bUnicode, bool bTabDelimited)
        {
            DataSet DS = new DataSet();
            string strConn = string.Format(ConnectStrFrm_CSV, Path.GetDirectoryName(FileNames[0]));
            OleDbConnection CSVConn = new OleDbConnection(strConn);

            try
            {
                CSVConn.Open();

                foreach (string strFile in FileNames)
                {
                    WriteSchema(Path.GetDirectoryName(strFile), Path.GetFileName(strFile), bUnicode, bTabDelimited);
                    string strFilename = Path.GetFileName(strFile);
                    DS.Tables.Add(strFilename);

                    string cmdText = string.Format("SELECT * FROM [{0}];", strFilename);

                    OleDbCommand dbCommand = new OleDbCommand(cmdText, CSVConn);
                    OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCommand);
                    dbAdapter.Fill(DS.Tables[strFilename]);

                    DeleteSchema(Path.GetDirectoryName(strFile));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (CSVConn != null) CSVConn.Close();
            }
            return DS;
        }

        public static DataSet OpenExcel(string FileName, bool bUseHDR)
        {
            string ConnStr = GetConnectionStr(FileName, bUseHDR);

            OleDbConnection OleDBConn = null;
            OleDbDataAdapter OleDBAdap = null;
            System.Data.DataTable Schema;
            DataSet DS = new DataSet();

            try
            {
//                 List<string> SheetOrdered = GetWorkSheetsXls(FileName);
//                 List<string> SheetNames = new List<string>();
// 
//                 OleDBConn = new OleDbConnection(ConnStr);
//                 OleDBConn.Open();
//                 Schema = OleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
// 
//                 foreach (DataRow DR in Schema.Rows)
//                     SheetNames.Add(DR["TABLE_NAME"].ToString().Replace("''", "'").TrimEnd('_'));
// 
//                 foreach (string workSheet in SortTabSheets(SheetOrdered, SheetNames))
//                 {
//                     OleDBAdap = new OleDbDataAdapter("SELECT * FROM [" + workSheet + "]", OleDBConn);
//                     OleDBAdap.Fill(DS, workSheet);
//                 }

                List<string> SheetNames = new List<string>();

                OleDBConn = new OleDbConnection(ConnStr);
                OleDBConn.Open();
                Schema = OleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow DR in Schema.Rows)
                {
                    string sSheet = DR["TABLE_NAME"].ToString().Replace("''", "'").TrimEnd('_');
                    if (!sSheet.EndsWith("Print_Area"))
                        SheetNames.Add(sSheet);
                }

                foreach (string workSheet in SheetNames)
                {
                    OleDBAdap = new OleDbDataAdapter("SELECT * FROM [" + workSheet + "]", OleDBConn);
                    OleDBAdap.Fill(DS, workSheet);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (OleDBConn != null) OleDBConn.Close();
            }
            return DS;
        }

        private static List<string> SortTabSheets(List<string> sheetOrder, List<string> sheetValue)
        {
            try
            {
                List<string> TabSheets = new List<string>();
                foreach (string sheetOrderMember in sheetOrder)
                {
                    foreach (string sheetValueMember in sheetValue)
                    {
                        if (sheetValueMember.Replace("$", String.Empty).Replace("'_", "'").Replace("''", "'").TrimEnd('\'').TrimStart('\'')
                            == sheetOrderMember.Replace(".", "#"))
                        {
                            if (!TabSheets.Contains(sheetValueMember))
                                TabSheets.Add(sheetValueMember);
                        }
                    }
                }
                return TabSheets;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private static List<string> GetWorkSheetsXls(string path)
        {
            Application _excelApp = new Application();
            Workbook workBook = _excelApp.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            List<string> worksheets = new List<string>();

            try
            {

                foreach (Worksheet sheet in workBook.Sheets)
                {
                    if (UEventProcessChanged != null)
                    {
                        UEventProcessChanged(null, sheet.Index * 100 / workBook.Sheets.Count);
                    }

                    worksheets.Add(sheet.Name);
                }

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
            finally
            {
                workBook.Close(false, path, null);
                _excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelApp);
            }

            return worksheets;

        }

        #region Write

        public static void ExportToExcel(DataSet dataSet, string inputPath, string outputPath, int nStartRow, string strCoverName, string strSpecialCell)
        {
            Application excelApp = new Application();
            Workbook excelWorkbook = excelApp.Workbooks.Open(inputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            int sheetIndex = 1;
            // Copy each DataTable

            CreateCoverSheet(excelWorkbook, nStartRow, strCoverName);

            foreach (System.Data.DataTable dt in dataSet.Tables)
            {
                if (dt.TableName.Length > 31)
                    dt.TableName = dt.TableName.Substring(0, 31);
                // Create a new Sheet
                if (dt.TableName.Contains(eExcel.LIBTABLENAME) || dt.TableName.Contains(eExcel.EPLTABLENAME))
                    CreateSheet(excelWorkbook, dt, sheetIndex, nStartRow);
                else
                    CreateUIOSheet(excelWorkbook, dt, sheetIndex, nStartRow, strSpecialCell);

                sheetIndex++;

                if (UEventProcessChanged != null)
                {
                    UEventProcessChanged(null, sheetIndex * 100 / dataSet.Tables.Count);
                }
            }

            foreach (System.Data.DataTable dt in dataSet.Tables)
                SetHyperlinks(dt, excelWorkbook);

            foreach (Worksheet ws in excelWorkbook.Sheets)
            {
                if (ws.Name.ToUpper().Contains(eExcel.TEMPLATE.ToUpper()))
                  ws.Visible = XlSheetVisibility.xlSheetVeryHidden;
            }


            XlFileFormat xlFileFormat = XlFileFormat.xlWorkbookNormal;
            if (outputPath.Substring(outputPath.Length - 1, 1) == "x")
                xlFileFormat = XlFileFormat.xlWorkbookDefault;


            // Save and Close the Workbook
            excelWorkbook.SaveAs(outputPath, xlFileFormat, Type.Missing,
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

        private static void CreateCoverSheet(Workbook excelWorkbook, int nStartRow, string strCoverName)
        {
            // Create a new Sheet
            Worksheet excelSheet = null;

            excelSheet = (Worksheet)excelWorkbook.Sheets[1];

            excelSheet.Cells[18, 24] = strCoverName;
            excelSheet.Cells[24, 24] = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private static void CreateSheet(Workbook excelWorkbook, System.Data.DataTable dt, int sheetIndex, int nStartRow)
        {
            // Create a new Sheet
            Worksheet excelSheet = null;

            excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];

            excelSheet.Copy(Type.Missing, excelSheet);
            excelSheet.Name = dt.TableName;

            SetRawData(dt, excelSheet, nStartRow, string.Empty);

        }

        private static void CreateUIOSheet(Workbook excelWorkbook, System.Data.DataTable dt, int sheetIndex, int nStartRow, string strSpecialCell)
        {
            // Create a new Sheet
            Worksheet excelSheet = null;

            if (dt.TableName.Contains(eExcel.MAP))
                excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count - 1];
            else
                excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];

            excelSheet.Copy(Type.Missing, excelSheet);

            if (dt.TableName.EndsWith("#1"))
                excelSheet.Tab.Color = Color.DarkOrange.ToArgb();
            else if (dt.TableName.EndsWith("#2"))
                excelSheet.Tab.Color = Color.LightGreen.ToArgb();
            else if (dt.TableName.EndsWith("#3"))
                excelSheet.Tab.Color = Color.LightPink.ToArgb();
            else if (dt.TableName.EndsWith("#4"))
                excelSheet.Tab.Color = Color.RosyBrown.ToArgb();
            else if (dt.TableName.EndsWith("#5"))
                excelSheet.Tab.Color = Color.BlueViolet.ToArgb();

            string sRobot = dt.TableName.ToUpper().Replace("RB", "R");

            if (sRobot.Contains("R") && sRobot.Split('R')[1].Length > 0)
                excelSheet.Tab.Color = Color.IndianRed.ToArgb();

            excelSheet.Name = dt.TableName.Replace("[", "(").Replace("]", ")");

            if (dt.TableName.Contains(eExcel.MAP))
                excelSheet.Move(Type.Missing, excelWorkbook.Sheets[excelSheet.Index]);
            else
                excelSheet.Move(Type.Missing, excelWorkbook.Sheets[excelSheet.Index - 1]);

            SetRawData(dt, excelSheet, nStartRow, strSpecialCell);
        }

        private static void SetRawData(System.Data.DataTable dt, Worksheet excelSheet, int nStartRow, string SpecialCell)
        {
            // Copy the values to the object array
            for (int col = 0; col < dt.Columns.Count; col++)
                for (int row = 0; row < dt.Rows.Count; row++)
                    if (dt.Rows[row].ItemArray[col] != DBNull.Value)
                    {
                        if (dt.Rows[row].ItemArray[col].ToString().Contains(eExcel.EXCELSPLIT.ToString()))
                        {
                            excelSheet.Cells[row + nStartRow + 1, col + 1] = dt.Rows[row].ItemArray[col].ToString().Split(eExcel.EXCELSPLIT)[0];
                            if (eExcel.EXCELYELLOW.Contains(dt.Rows[row].ItemArray[col].ToString().Split(eExcel.EXCELSPLIT)[1]))
                                ((Range)excelSheet.Cells[row + nStartRow + 1, col + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Yellow);
                            if (eExcel.EXCELAQUA.Contains(dt.Rows[row].ItemArray[col].ToString().Split(eExcel.EXCELSPLIT)[1]))
                                ((Range)excelSheet.Cells[row + nStartRow + 1, col + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Aqua);
                        }
                        else
                            excelSheet.Cells[row + nStartRow + 1, col + 1] = dt.Rows[row].ItemArray[col];
                    }
        }

        private static void SetHyperlinks(System.Data.DataTable dt, Workbook excelWorkbook)
        {
            Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets[dt.TableName.Replace("[", "(").Replace("]", ")")];

            List<string> worksheets = new List<string>();
            foreach (Worksheet sheet in excelWorkbook.Sheets)
                worksheets.Add(sheet.Name);

            string excelRange = string.Empty;
            string hyperlinkTargetAddress = string.Empty;

            if (dt.TableName.Contains(eExcel.MAP))
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                    for (int row = 0; row < dt.Rows.Count; row++)
                        if (worksheets.Contains(dt.Rows[row].ItemArray[col].ToString().Replace("[", "(").Replace("]", ")")))
                        {
                            excelRange = string.Format("{0}{1}:{2}{3}", CalculateFinalColumn(col + 1), row + 1, CalculateFinalColumn(col + 1), row + 1);
                            hyperlinkTargetAddress = "'" + dt.Rows[row].ItemArray[col].ToString().Replace("[", "(").Replace("]", ")") + "'!A1";
                            excelSheet.Hyperlinks.Add(excelSheet.get_Range(excelRange, excelRange), string.Empty, hyperlinkTargetAddress, Type.Missing, Type.Missing);
                            excelSheet.get_Range(excelRange, excelRange).Font.Size = 10;
                        }
            }
            else
            {
                excelRange = string.Format("{0}{1}:{2}{3}", "A", 1, "A", 1);
                hyperlinkTargetAddress = "'" + GethyperlinkTargetSheet(worksheets, dt) + "'!A1";
                excelSheet.Hyperlinks.Add(excelSheet.get_Range(excelRange, excelRange), string.Empty, hyperlinkTargetAddress, Type.Missing, Type.Missing);
                excelSheet.get_Range(excelRange, excelRange).Font.Size = 10;
            }
        }

        private static object[,] GetRawData(System.Data.DataTable dt)
        {
            // Copy the DataTable to an object array
            object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

            // Copy the values to the object array
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                for (int row = 0; row < dt.Rows.Count; row++)
                {

                    if (dt.Rows[row].ItemArray[col] != DBNull.Value)
                    {
                        rawData[row, col] = dt.Rows[row].ItemArray[col];
                    }
                }
            }

            return rawData;
        }

        private static string GethyperlinkTargetSheet(List<string> worksheets, System.Data.DataTable dt)
        {
            string hyperlinkTargetSheet = string.Empty;
            List<string> Mapsheets = new List<string>();
            foreach (string strMap in worksheets)
            {
                if (strMap.Contains(eExcel.MAP + "("))
                    Mapsheets.Add(strMap);
            }

            DataSet DS = dt.DataSet;

            foreach (string strMap in Mapsheets)
            {
                System.Data.DataTable DT = DS.Tables[strMap];
                int nRowCount = DT.Rows.Count;
                int nColCount = DT.Columns.Count;

                for (int nCol = 0; nCol < nColCount; nCol++)
                {
                    for (int nRow = 0; nRow < nRowCount; nRow++)
                    {
                        if (DT.Rows[nRow][nCol].ToString() == dt.TableName)
                            return strMap;
                    }
                }
            }

            return hyperlinkTargetSheet;
        }

        private static string CalculateFinalColumn(int nColumn)
        {
            // Calculate the final column letter
            string finalColLetter = string.Empty;
            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;

            if (nColumn > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (nColumn - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                    (nColumn - 1) % colCharsetLen, 1);

            return finalColLetter;
        }

        #endregion 


    }
}
