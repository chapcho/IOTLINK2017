using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace IOTL.Common.Csv
{
    public class CsvReader : IDisposable
    {

        #region Member Variables

        private StreamReader m_cReader = null;
        private bool m_bReadable = false;
        private bool m_bEOF = false;
        private bool m_bDetailParse = false;
        private List<string> m_lstHeader = new List<string>();
        private EMFileState m_emState = EMFileState.Closed;
        private EMCsvType m_emType = EMCsvType.Comma;

        #endregion


        #region Initialize/Dispose

        public CsvReader()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        public bool EOF
        {
            get { return m_bEOF; }
        }

        public List<string> Header
        {
            get { return m_lstHeader; }
            set { m_lstHeader = value; }
        }

        public EMFileState State
        {
            get { return m_emState; }
        }

        public EMCsvType CsvType
        {
            get { return m_emType; }
            set { m_emType = value; }
        }

        public bool AllowDetailParsing
        {
            get { return m_bDetailParse; }
            set { m_bDetailParse = value; }
        }

        #endregion


        #region Public Methods

        public Encoding GetFileEncoding(string srcFile)
        {
            // *** Use Default of Encoding.Default (Ansi CodePage)
            Encoding enc = Encoding.Default;

            // *** Detect byte order mark if any - otherwise assume default
            byte[] buffer = new byte[5];
            FileStream file = new FileStream(srcFile, FileMode.Open);
            file.Read(buffer, 0, 5);
            file.Close();

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
                enc = Encoding.UTF8;
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
                enc = Encoding.Unicode;
            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
                enc = Encoding.UTF32;
            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
                enc = Encoding.UTF7;
            else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                // 1201 unicodeFFFE Unicode (Big-Endian)
                enc = Encoding.GetEncoding(1201);
            else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                // 1200 utf-16 Unicode
                enc = Encoding.GetEncoding(1200);


            return enc;
        }

        public bool Open(string sPath, bool bHeader)
        {
            bool bOK = true;

            Close();

            try
            {
                if (File.Exists(sPath) == false)
                    return false;

                m_cReader = new StreamReader(sPath, GetFileEncoding(sPath)); // Encoding.Default);
                m_bReadable = true;

                m_emState = EMFileState.Opened;

                if (bHeader)
                    ReadHeader(bHeader, 0); // file Read Point moved.

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Open(string sPath, bool bHeader, int iHeaderRowIndex)
        {
            bool bOK = true;

            Close();

            try
            {
                if (File.Exists(sPath) == false)
                    return false;

                m_cReader = new StreamReader(sPath, GetFileEncoding(sPath)); // Encoding.Default);
                m_bReadable = true;

                m_emState = EMFileState.Opened;

                if (bHeader)
                    ReadHeader(bHeader, iHeaderRowIndex);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Close()
        {
            bool bOK = true;

            m_bReadable = false;
            m_bEOF = false;

            try
            {
                if (m_cReader != null)
                {
                    m_cReader.Close();
                    m_cReader = null;
                }

                m_lstHeader.Clear();
                m_emState = EMFileState.Closed;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public List<string> ReadLine()
        {
            if (m_bReadable == false)
                return null;

            if (m_cReader.EndOfStream)
            {
                m_bEOF = true;
                m_bReadable = false;
                return null;
            }

            List<string> lstToken = new List<string>();

            try
            {
                string sLine = m_cReader.ReadLine();
                lstToken = ParseLine(sLine);

                if (m_lstHeader.Count == 0)
                    CreateEmptyHeader(lstToken);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                lstToken = null;
            }

            return lstToken;
        }


        public bool Fill(DataTable dbTable)
        {
            if (m_bReadable == false)
                return false;

            if (dbTable == null)
                dbTable = new DataTable();

            bool bOK = true;

            try
            {
                List<string> lstToken;
                DataRow dbRow;
                object oValue;
                while (this.EOF == false)
                {
                    lstToken = this.ReadLine();
                    if (lstToken != null)
                    {
                        if (m_lstHeader.Count == 0)
                            CreateEmptyHeader(lstToken);

                        if (dbTable.Columns.Count == 0)
                        {
                            for (int i = 0; i < m_lstHeader.Count; i++)
                                dbTable.Columns.Add(m_lstHeader[i]);
                        }

                        if (m_lstHeader.Count == lstToken.Count)
                        {
                            dbRow = dbTable.NewRow();
                            for (int i = 0; i < dbTable.Columns.Count; i++)
                            {
                                oValue = GetValue(lstToken[i], dbTable.Columns[i].DataType);
                                dbRow[i] = oValue;
                            }

                            dbTable.Rows.Add(dbRow);
                        }

                        lstToken.Clear();
                        lstToken = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Fill(string sText, bool bHeader, int iHeaderRowIndex, DataTable dbTable)
        {
            if (dbTable == null)
                dbTable = new DataTable();

            bool bOK = true;

            try
            {
                string[] saSpliter = new string[] { "\n" };
                string[] saLine = sText.Split(saSpliter, StringSplitOptions.None);

                if (bHeader == false)
                    CreateEmptyHeader(ParseLine(saLine[0]));
                else
                    m_lstHeader = ParseLine(saLine[iHeaderRowIndex]);

                List<string> lstToken = null;
                DataRow dbRow;
                object oValue;

                for (int i = iHeaderRowIndex + 1; i < saLine.Length; i++)
                {
                    lstToken = ParseLine(saLine[i]);
                    if (lstToken != null)
                    {
                        if (dbTable.Columns.Count == 0)
                        {
                            for (int j = 0; j < m_lstHeader.Count; j++)
                                dbTable.Columns.Add(m_lstHeader[j]);
                        }

                        if (m_lstHeader.Count == lstToken.Count)
                        {
                            dbRow = dbTable.NewRow();
                            for (int j = 0; j < dbTable.Columns.Count; j++)
                            {
                                oValue = GetValue(lstToken[j], dbTable.Columns[j].DataType);
                                dbRow[j] = oValue;
                            }

                            dbTable.Rows.Add(dbRow);
                        }

                        lstToken.Clear();
                        lstToken = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        #endregion


        #region Private Methods

        private void CreateEmptyHeader(List<string> lstToken)
        {
            m_lstHeader.Clear();
            for (int i = 0; i < lstToken.Count; i++)
            {
                m_lstHeader.Add(i.ToString());
            }
        }

        private bool ReadHeader(bool bHeader, int iRowIndex)
        {
            bool bOK = true;

            try
            {
                if (m_lstHeader == null)
                    m_lstHeader = new List<string>();

                m_lstHeader.Clear();

                if (m_bReadable)
                {
                    string sLine = "";

                    //skip
                    for (int i = 0; i < iRowIndex; i++)
                        sLine = m_cReader.ReadLine();

                    sLine = m_cReader.ReadLine();

                    List<string> lstToken = ParseLine(sLine);

                    for (int i = 0; i < lstToken.Count; i++)
                    {
                        if (bHeader)
                        {
                            m_lstHeader.Add(lstToken[i]);
                        }
                        else
                        {
                            m_lstHeader.Add(i.ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private List<string> ParseLine2(string sLine)
        {
            char cSplitter = ',';
            if (m_emType == EMCsvType.Tab)
                cSplitter = '\t';


            List<string> lstToken = new List<string>();

            char cQuote = '\"';

            string[] saToken = sLine.Split(cSplitter);
            if (saToken != null)
            {
                string sToken;
                int iLastIndex = 0;
                for (int i = 0; i < saToken.Length; i++)
                {
                    sToken = saToken[i];
                    sToken = sToken.Trim();
                    if (sToken.Length > 0)
                    {
                        iLastIndex = sToken.Length - 1;
                        if (sToken[0] == cQuote)
                        {
                            if (sToken[iLastIndex] == cQuote)
                            {
                                sToken = sToken.Substring(1, iLastIndex - 1);
                                sToken = sToken.Replace("\"\"", "\"");
                                lstToken.Add(sToken);
                            }
                            else
                            {
                                // Find Last Quote Index
                                int iLastTokenIndex = -1;
                                string sQuoteToken = "";
                                for (int j = i + 1; j < saToken.Length; j++)
                                {
                                    sQuoteToken = saToken[j].TrimEnd();
                                    iLastIndex = sQuoteToken.Length - 1;
                                    if (sQuoteToken[iLastIndex] == cQuote)
                                    {
                                        iLastTokenIndex = j;
                                        break;
                                    }
                                }

                                if (iLastTokenIndex > 0)
                                {
                                    for (int j = i + 1; j < iLastTokenIndex + 1; j++)
                                        sToken += "," + saToken[j];

                                    iLastIndex = sToken.Length - 1;

                                    sToken = sToken.Substring(1, iLastIndex - 1);
                                    sToken = sToken.Replace("\"\"", "\"");

                                    lstToken.Add(sToken);
                                    i = iLastTokenIndex;
                                }
                                else
                                    lstToken.Add(sToken);

                            }
                        }
                        else
                            lstToken.Add(sToken);

                    }
                    else
                        lstToken.Add(sToken);
                }
            }

            return lstToken;
        }

        private List<string> ParseLine(string sLine)
        {
            char cSplitter = ',';
            if (m_emType == EMCsvType.Tab)
                cSplitter = '\t';

            List<string> lstToken = new List<string>();

            char cQuote = '\"';
            char cSpace = ' ';
            char cValue = '\0';
            char cLast = '\0';
            int iLastIndex = 0;
            char cEmpty = '\0';
            bool bQuoteStart = false;
            bool bTokenStart = false;
            string sToken = "";
            for (int i = 0; i < sLine.Length; i++)
            {
                cValue = sLine[i];

                if (bTokenStart)
                {
                    if (cValue == cSplitter)
                    {
                        if (bQuoteStart)
                        {
                            if (cLast == cQuote)
                            {
                                sToken = sToken.Trim();
                                iLastIndex = sToken.Length - 1;
                                if (iLastIndex > -1)
                                    sToken = sToken.Remove(iLastIndex);

                                lstToken.Add(sToken);

                                sToken = "";
                                bQuoteStart = false;
                                bTokenStart = false;
                                cLast = cEmpty;
                            }
                            else
                            {
                                sToken += cValue.ToString();
                                cLast = cValue;
                            }
                        }
                        else
                        {
                            sToken = sToken.Trim();

                            lstToken.Add(sToken);

                            sToken = "";
                            bQuoteStart = false;
                            bTokenStart = false;
                            cLast = cEmpty;
                        }
                    }
                    else
                    {
                        sToken += cValue.ToString();

                        if (cValue != cSpace)
                            cLast = cValue;
                    }
                }
                else
                {
                    if (cValue != cSpace)
                    {
                        if (cValue == cQuote)
                        {
                            bQuoteStart = true;
                            bTokenStart = true;
                            cLast = cEmpty;
                            sToken = "";
                        }
                        else if (cValue == cSplitter)
                        {
                            bQuoteStart = false;
                            bTokenStart = false;
                            cLast = cEmpty;
                            sToken = "";
                            lstToken.Add("");
                        }
                        else
                        {
                            bQuoteStart = false;
                            bTokenStart = true;
                            cLast = cValue;
                            sToken = cValue.ToString();
                        }
                    }
                    else
                    {
                        sToken += cValue.ToString();
                    }
                }
            }

            if (cValue == cSplitter)
            {
                lstToken.Add("");
            }
            else if (sToken != "")
            {
                sToken = sToken.Trim();
                iLastIndex = sToken.Length;

                if (sToken.EndsWith("\""))
                    sToken = sToken.Remove(iLastIndex - 1);

                lstToken.Add(sToken);
            }

            return lstToken;
        }

        private object GetValue(string sValue, Type t)
        {
            object oValue = null;

            if (t == typeof(string))
                oValue = sValue;
            else if (t == typeof(bool))
                oValue = CTypeConverter.ToBool(sValue);
            else if (t == typeof(int))
                oValue = CTypeConverter.ToInteger(sValue);
            else if (t == typeof(decimal))
                oValue = CTypeConverter.ToDecimal(sValue);
            else if (t == typeof(double))
                oValue = CTypeConverter.ToDouble(sValue);
            else if (t == typeof(Color))
                oValue = CTypeConverter.ToColor(sValue);
            else if (t == typeof(DateTime))
                oValue = CTypeConverter.ToDateTime(sValue);
            else if (t.BaseType == typeof(Enum))
                oValue = CTypeConverter.ToEnum(t, sValue);
            else
                oValue = sValue;

            return oValue;
        }

        #endregion
    }
}
