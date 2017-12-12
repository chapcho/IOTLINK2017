using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using NewIOMaker.Enumeration.EnumCommon;
using NewIOMaker.Classes.ClassCommon.Util;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    public class ClassCommonReader : IDisposable
    {       

        private StreamReader _cReader = null;
        private bool _bReadable = false;
        private bool _bEOF = false;
        private bool _bDetailParse = false;
        private List<string> _lstHeader = new List<string>();
        private EMCommonFileState _emState = EMCommonFileState.Closed;
        private EMCommonCsvType _emType = EMCommonCsvType.Comma;


        #region Initialize/Dispose

        public ClassCommonReader()
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
            get { return _bEOF; }
        }

        public List<string> Header
        {
            get { return _lstHeader; }
            set { _lstHeader = value; }
        }

        public EMCommonFileState State
        {
            get { return _emState; }
        }

        public EMCommonCsvType CsvType
        {
            get { return _emType; }
            set { _emType = value; }
        }

        public bool AllowDetailParsing
        {
            get { return _bDetailParse; }
            set { _bDetailParse = value; }
        }

        #endregion


        #region Public Methods

        public bool Open(string sPath, bool bHeader)
        {
            bool bOK = true;

            Close();

            try
            {
                if (File.Exists(sPath) == false)
                    return false;

                _cReader = new StreamReader(sPath, Encoding.Default);
                _bReadable = true;

                _emState = EMCommonFileState.Opened;

                if (bHeader)
                    ReadHeader(bHeader, 0);

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

                _cReader = new StreamReader(sPath, Encoding.Default);
                _bReadable = true;

                _emState = EMCommonFileState.Opened;

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

            _bReadable = false;
            _bEOF = false;

            try
            {
                if (_cReader != null)
                {
                    _cReader.Close();
                    _cReader = null;
                }

                _lstHeader.Clear();
                _emState = EMCommonFileState.Closed;
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
            if (_bReadable == false)
                return null;

            if (_cReader.EndOfStream)
            {
                _bEOF = true;
                _bReadable = false;
                return null;
            }

            List<string> lstToken = new List<string>();

            try
            {
                string sLine = _cReader.ReadLine();
                lstToken = ParseLine(sLine);

                if (_lstHeader.Count == 0)
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
            if (_bReadable == false)
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
                        if (_lstHeader.Count == 0)
                            CreateEmptyHeader(lstToken);

                        if (dbTable.Columns.Count == 0)
                        {
                            for (int i = 0; i < _lstHeader.Count; i++)
                                dbTable.Columns.Add(_lstHeader[i]);
                        }

                        if (_lstHeader.Count == lstToken.Count)
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

        #endregion


        #region Private Methods

        private void CreateEmptyHeader(List<string> lstToken)
        {
            _lstHeader.Clear();
            for (int i = 0; i < lstToken.Count; i++)
            {
                _lstHeader.Add(i.ToString());
            }
        }

        private bool ReadHeader(bool bHeader, int iRowIndex)
        {
            bool bOK = true;

            try
            {
                if (_lstHeader == null)
                    _lstHeader = new List<string>();

                _lstHeader.Clear();

                if (_bReadable)
                {
                    string sLine = "";

                    //skip
                    for (int i = 0; i < iRowIndex; i++)
                        sLine = _cReader.ReadLine();

                    sLine = _cReader.ReadLine();

                    List<string> lstToken = ParseLine(sLine);

                    for (int i = 0; i < lstToken.Count; i++)
                    {
                        if (bHeader)
                        {
                            _lstHeader.Add(lstToken[i]);
                        }
                        else
                        {
                            _lstHeader.Add(i.ToString());
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
            if (_emType == EMCommonCsvType.Tab)
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
            if (_emType == EMCommonCsvType.Tab)
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
            //bool bEndWithSplitter = false;
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
                oValue = ClassCommonTypeConverter.ToBool(sValue);
            else if (t == typeof(int))
                oValue = ClassCommonTypeConverter.ToInteger(sValue);
            else if (t == typeof(decimal))
                oValue = ClassCommonTypeConverter.ToDecimal(sValue);
            else if (t == typeof(double))
                oValue = ClassCommonTypeConverter.ToDouble(sValue);
            else if (t == typeof(Color))
                oValue = ClassCommonTypeConverter.ToColor(sValue);
            else if (t == typeof(DateTime))
                oValue = ClassCommonTypeConverter.ToDateTime(sValue);
            else if (t.BaseType == typeof(Enum))
                oValue = ClassCommonTypeConverter.ToEnum(t, sValue);
            else
                oValue = sValue;

            return oValue;
        }

        #endregion
    }
}
