using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Excel
{
    public delegate void UEventHandlerProcess(object sender, int nProcess);

    public class ExcelHelper
    {
        public class eExcel
        {
            public static string TEMPLATE = "Template";
            public static string MAP = "MAP";
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
            string strFilenameOnly = XlsFile.Replace(FI.DirectoryName, string.Empty).Replace("\\", string.Empty);
            switch (strFilenameOnly.Split('.')[1].ToLower())
            {
                case ("xls"): result = 0; break;
                case ("xlsx"): result = 1; break;
                case ("csv"): result = 2; break;
                case ("sdf"): result = 3; break;
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
                    ConnStr = string.Format(ConnectStrFrm_Excel97_2003, FileName, bUseHDR ? "YES" : "NO");
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
                string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11;

                s1 = string.Format("[{0}]", fileName);// "[TempFile.csv]";
                s2 = "MaxScanRows=25";
                s3 = "ColNameHeader=false";
                s4 = bTabDelimited ? "Format=TabDelimited" : "Format=CSVDelimited";
                s5 = bUnicode ? "CharacterSet=UNICODE" : "CharacterSet=ANSI";
                s6 = "Col1=C1 Text";
                s7 = "Col2=C2 Text";
                s8 = "Col3=C3 Text";
                s9 = "Col4=C4 Text";
                s10 = "Col5=C5 Text";
                s11 = "Col6=C6 Text";

                //s5 = "CharacterSet=Shift_JIS";
                //s5 = "CharacterSet=UTF-8";


                srOutput.WriteLine(s1 + "\r\n" + s2 + "\r\n" + s3 + "\r\n" + s4 + "\r\n" + s5
                    + "\r\n" + s6 + "\r\n" + s7 + "\r\n" + s8 + "\r\n" + s9 + "\r\n" + s10 + "\r\n" + s11);
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




    }
}
