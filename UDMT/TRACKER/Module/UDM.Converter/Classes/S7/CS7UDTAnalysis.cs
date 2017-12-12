using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7UDTAnalysis
    {
        // Create by Qin Shiming at 2015.06.23
        // Frist edit at 2015.06.26 by Qin Shiming
        // Second edit at 2015.07.01 by Qin Shiming
        #region MemberVariables

        protected Dictionary<string, CS7UDT> m_dUDTDic = null;
        protected double m_fDataItemIndex = 0.0;
        protected string m_sUDTName = string.Empty;
        protected CS7UDT m_cUDTTemp = null;

        protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;

        #endregion

        #region Initialze/Dispose

        public CS7UDTAnalysis()
        {
            m_dUDTDic = new Dictionary<string, CS7UDT>();
        }

        #endregion

        #region Public Properites

        public Dictionary<string, CS7UDT> UDTDic
        {
            get { return m_dUDTDic; }
        }
        public CTagS SymbolTags
        {
            set { m_dSymbolTags = value; }
        }
        public CTagS AddressTags
        {
            set { m_dAddressTags = value; }
        }

        #endregion

        #region Public Methods

        public void DatatypeListAnalysis(List<string> sFilePart)
        {
            try
            {
                m_sUDTName = string.Empty;
                m_fDataItemIndex = 0.0;

                int iCount = sFilePart.Count;
                string sDatatypeName = string.Empty;

                for (int i = 0; i < iCount; i++)
                {
                    if (sFilePart[i].StartsWith("TYPE"))
                    {
                        sDatatypeName = FindDatatypeName(sFilePart[i]);

                        if (CheckIsSymbol(sDatatypeName))
                        {
                            int iLength = sDatatypeName.Length;

                            sDatatypeName = sDatatypeName.Remove(iLength - 1);
                            sDatatypeName = sDatatypeName.Substring(1);

                            m_cUDTTemp = new CS7UDT(sDatatypeName);
                            m_sUDTName = sDatatypeName;

                            if (m_dSymbolTags.ContainsKey(sDatatypeName))
                            {                              
                                m_cUDTTemp.UDTSymbol = sDatatypeName;
                                m_cUDTTemp.UDTAddress = m_dSymbolTags[sDatatypeName].Address;
                                m_cUDTTemp.Comment = m_dSymbolTags[sDatatypeName].Description;
                            }
                            else
                            {
                                m_cUDTTemp.UDTSymbol = sDatatypeName;
                            }

                        }
                        else
                        {
                            m_sUDTName = sDatatypeName;
                            m_cUDTTemp = new CS7UDT(sDatatypeName);

                            if (m_dAddressTags.ContainsKey(sDatatypeName))
                            {
                                sDatatypeName = m_dAddressTags[sDatatypeName].Key;

                                m_cUDTTemp.UDTAddress = m_sUDTName;
                                m_cUDTTemp.UDTSymbol = sDatatypeName;
                                m_cUDTTemp.Comment = m_dAddressTags[m_sUDTName].Description;
                            }
                            else
                            {
                                m_cUDTTemp.UDTAddress = sDatatypeName;
                            }
                        }
                        
                    }
                    else if (sFilePart[i].StartsWith("  STRUCT"))
                    {
                        List<string> sStructPart = new List<string>();
                        int j = i + 1;
                        while (!sFilePart[j].StartsWith("  END_STRUCT"))
                        {
                            sStructPart.Add(sFilePart[j]);
                            j++;
                        }
                        i = j;

                        StructAnalysis(sStructPart, "");
                    }                    
                }

                iCount = Convert.ToInt32(m_fDataItemIndex);
                double fTemp = m_fDataItemIndex - iCount;

                if (fTemp > 0.00001)
                {
                    iCount = iCount + 1;
                }
                m_cUDTTemp.DTLength = iCount;

                m_dUDTDic.Add(m_sUDTName, m_cUDTTemp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void StructAnalysis(List<string> sFilePart, string sPar)
        {
            try
            {
                int count = sFilePart.Count;
                string sDataItemType = string.Empty;
                string sDataItemName = string.Empty;

                for (int i = 0; i < count; i++)
                {
                    string nodedata = sFilePart[i];

                    bool bIsNoCompleteLine = false;

                    if (!nodedata.Contains(";"))
                        bIsNoCompleteLine = true;

                    if (bIsNoCompleteLine && !nodedata.Contains("STRUCT"))
                    {
                        while (!nodedata.Contains(";"))
                        {
                            i = i + 1;

                            if (nodedata.IndexOf("//") > -1)
                            {
                                string sComment = string.Empty;

                                int iPos = nodedata.IndexOf("//");
                                sComment = nodedata.Substring(iPos);
                                nodedata = nodedata.Remove(iPos);

                                string sTemp = sFilePart[i];

                                sTemp = FrontCleanNodedata(sTemp);

                                nodedata = nodedata + sTemp + sComment;
                            }
                            else
                            {
                                string sTemp = sFilePart[i];

                                sTemp = FrontCleanNodedata(sTemp);
                                nodedata = nodedata + sTemp;
                            }
                        }
                    }

                    sDataItemName = FindDataItemName(nodedata);
                    sDataItemType = CheckItemDatatype(nodedata);

                    if (sDataItemType == "END_STRUCT")
                    {

                    }
                    else if (sDataItemType == "STRUCT")
                    {
                        List<string> sStructPart = new List<string>();
                        int j = i + 1;
                        int iInStruct = 1;
                        while (iInStruct > 0)
                        {
                            if (sFilePart[j].Contains(": STRUCT"))
                                iInStruct = iInStruct + 1;
                            else if (sFilePart[j].Contains("END_STRUCT"))
                                iInStruct = iInStruct - 1;

                            if (iInStruct != 0)
                            {
                                sStructPart.Add(sFilePart[j]);

                                j++;
                            }

                        }
                        i = j;

                        if (nodedata.Contains("ARRAY  ["))
                        {
                            int start = CheckArrayStart(nodedata);
                            int end = CheckArrayEnd(nodedata);
                            int itemCount = end - start + 1;
                            int iTemp = 0;

                            for (int k = 0; k < itemCount; k++)
                            {
                                iTemp = start + k;
                                string sItemName = sDataItemName + "[" + iTemp.ToString() + "]";
                                string sTemp = sPar + "." + sItemName;

                                StructAnalysis(sStructPart, sTemp);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sStructPart, sTemp);
                        }

                        sStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "INT": IntDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "BYTE": ByteDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "WORD": WordDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "DWORD": DWordDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "DINT": DintDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "REAL": RealDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "TIME": TimeDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "S5TIME": S5timeDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "DATE": DateDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "TIME_OF_DAY": TODDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                            case "CHAR": CharDataItemAnalysis(nodedata, sDataItemType, sPar); break;
                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sPar); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sPar); break;
                        }
                    }
                }
                MakeIndexEven();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #region Supply Functions

        private string FindDatatypeName(string nodedata)
        {
            string sName = string.Empty;
            try
            {
                if (nodedata.StartsWith("TYPE \""))
                {
                    sName = nodedata.Substring(5);
                }
                else if (nodedata.StartsWith("TYPE "))
                {
                    sName = nodedata.Substring(5);
                    sName = sName.Replace(" ", "");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private bool CheckIsArray(string nodedata)
        {
            bool isArray = false;

            try
            {
                if (nodedata.Contains(" ARRAY "))
                    isArray = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return isArray;
        }

        private bool CheckIsSymbol(string nodedata)
        {
            bool bIsAbsolte = false;
            try
            {
                if (nodedata.StartsWith("\""))
                    bIsAbsolte = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsAbsolte;
        }

        private string CheckItemDatatype(string nodedata)
        {
            string sDatatype = string.Empty;
            try
            {
                if (nodedata.Contains("END_STRUCT"))
                {
                    sDatatype = "END_STRUCT";
                }
                else if (CheckIsArray(nodedata))
                {
                    int iPos = nodedata.IndexOf("] OF ");
                    sDatatype = nodedata.Substring(iPos + 5);
                }
                else
                {
                    int iPos = nodedata.IndexOf(" : ");
                    sDatatype = nodedata.Substring(iPos + 3);
                }

                if (sDatatype.Contains("//"))
                {
                    int iPos = sDatatype.IndexOf("//");
                    sDatatype = sDatatype.Remove(iPos);
                }

                if (sDatatype.Contains(":="))
                {
                    int iPos = sDatatype.IndexOf(":=");
                    sDatatype = sDatatype.Remove(iPos);
                }

                if (sDatatype[0] == '\"')
                {
                    int iPos = sDatatype.LastIndexOf("\"");
                    sDatatype = sDatatype.Remove(iPos + 1);
                }
                else
                {
                    sDatatype = NodedataEdit(sDatatype);
                    sDatatype = sDatatype.Replace(" ", "");
                }

                if (sDatatype.Contains("STRING["))
                {
                    sDatatype = "STRING";
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sDatatype;
        }

        private string CheckComment(string nodedata)
        {
            string sComment = string.Empty;
            try
            {
                if (nodedata.IndexOf("\t//") > -1)
                {
                    int iPos = nodedata.IndexOf("\t//");
                    sComment = nodedata.Substring(iPos);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sComment;
        }

        private string FrontCleanNodedata(string nodedata)
        {
            try
            {
                if (nodedata.Length > 1)
                {
                    while (nodedata[0] == ' ' || nodedata[0] == '\t')
                    {
                        nodedata = nodedata.Substring(1);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private int CheckArrayStart(string nodedata)
        {
            int iArrayStart = -1;
            try
            {
                int iPos = nodedata.IndexOf("ARRAY  [");
                string sTemp = nodedata.Substring(iPos + 8);

                iPos = sTemp.IndexOf(" .. ");
                sTemp = sTemp.Remove(iPos);

                iArrayStart = Convert.ToInt16(sTemp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iArrayStart;
        }

        private void CheckCarry()
        {
            try
            {
                int iTemp = (int)m_fDataItemIndex;
                double fTemp = m_fDataItemIndex - (double)iTemp;
                if (fTemp > 0.701)
                {
                    iTemp = iTemp + 1;
                    m_fDataItemIndex = (float)iTemp;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void MakeIndexEven()
        {
            try
            {
                int iIsEven = (int)m_fDataItemIndex % 2;
                if (iIsEven != 0)
                {
                    int iTemp = (int)m_fDataItemIndex;
                    iTemp = iTemp + 1;
                    m_fDataItemIndex = (double)iTemp;
                }
                else
                {
                    int iTemp = (int)m_fDataItemIndex;
                    double fTemp = m_fDataItemIndex - (double)iTemp;

                    if (fTemp > 0.0)
                    {
                        iTemp = iTemp + 2;
                        m_fDataItemIndex = (double)iTemp;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void MakeIndexSingular()
        {
            try
            {
                int iTemp = (int)m_fDataItemIndex;
                double fTemp = m_fDataItemIndex - (double)iTemp;
                if (fTemp > 0.0)
                {
                    iTemp = iTemp + 1;
                    m_fDataItemIndex = (double)iTemp;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int CheckArrayEnd(string nodedata)
        {
            int iArrayEnd = -1;
            try
            {
                int iPos = nodedata.IndexOf(" .. ");
                string sTemp = nodedata.Substring(iPos + 4);

                iPos = sTemp.IndexOf(" ] ");
                sTemp = sTemp.Remove(iPos);

                iArrayEnd = Convert.ToInt16(sTemp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iArrayEnd;
        }

        private string NodedataEdit(string nodedata)
        {
            try
            {
                int length = nodedata.Length;
                if (length > 1)
                {
                    while (nodedata[0] == ' ' || nodedata[0] == '\t')
                    {
                        nodedata = nodedata.Substring(1);
                    }

                    length = nodedata.Length;

                    while (nodedata[length - 1] == ' ' || nodedata[length - 1] == '\t' || nodedata[length - 1] == ';')
                    {
                        nodedata = nodedata.Remove(length - 1);
                        length = nodedata.Length;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string FindDataItemName(string nodedata)
        {
            string sDataItem = string.Empty;
            try
            {
                if (!nodedata.Contains("END_STRUCT"))
                {
                    nodedata = NodedataEdit(nodedata);

                    int iPos = nodedata.IndexOf(" : ");

                    sDataItem = nodedata.Remove(iPos);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sDataItem;
        }

        #endregion

        private void BoolDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);

                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        CheckCarry();
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Bool;

                        string sSymbel = sPar + "." + sItemName;
                        string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                        cItemTemp.Address = sAddress;
                        cItemTemp.Key = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 0.1;
                     
                    }

                    iTemp = itemCount % 16;

                    if (iTemp > 8)
                    {
                        int a = (int)m_fDataItemIndex;
                        a = a + 1;
                        m_fDataItemIndex = (float)a;
                    }
                    else if (iTemp > 0 && iTemp <= 8)
                    {
                        int a = (int)m_fDataItemIndex;
                        a = a + 2;
                        m_fDataItemIndex = (float)a;
                    } 
                }
                else
                {
                    CheckCarry();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Bool;

                    string sSymbel = sPar + "." + itemName;
                    string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                    cItemTemp.Address = sAddress;
                    cItemTemp.Key = sSymbel;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 0.1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ByteDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Byte;                   

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBB" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 1;
                    }

                    iTemp = itemCount % 2;

                    if (iTemp ==1)
                    {
                        m_fDataItemIndex = m_fDataItemIndex + 1;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexSingular();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Byte;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBB" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WordDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Word;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }                  
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Word;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key= sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void IntDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Int;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Int;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DWordDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.DWord;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.DWord;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DintDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.DInt;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.DInt;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void RealDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Real;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Real;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex +4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ANYDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Any;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 10;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Any;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 10;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        private void TimeDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Time;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Time;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void S5timeDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.S5Time;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.S5Time;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);
                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StringDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                int length = CheckStringLength(nodedata);

                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    iTemp = length % 2;

                    if (iTemp == 1)
                    {
                        length = length + 1;
                    }
                    length = length + 2;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";

                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.String;
                        cItemTemp.Size = length;

                        string sComment = CheckComment(nodedata);
                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    length = length + 2;

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;            
                    cItemTemp.DataType = EMDataType.String;
                    cItemTemp.Size = length;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                string sUDTtype = CheckItemDatatype(nodedata);
                CS7UDT cDatatype = m_dUDTDic[sUDTtype];

                int length = cDatatype.DTLength;
                
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    iTemp = length % 2;

                    if (iTemp == 1)
                    {
                        length = length + 1;
                    }

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.UserDefDataType;
                        cItemTemp.UDTType = sUDTtype;
                        cItemTemp.Size = length;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.UserDefDataType;
                    cItemTemp.UDTType = sUDTtype;
                    cItemTemp.Size = length;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + length;
                }               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int CheckStringLength(string nodedata)
        {
            int length = 0;
            try
            {
                int a = nodedata.IndexOf("STRING  [");
                string temp = nodedata.Substring(a + 9);

                a = temp.IndexOf(" ]");
                temp = temp.Remove(a);

                length = Convert.ToInt32(temp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return length;
        }

        private void DateDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Date;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Date;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void TODDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Time_Of_Day;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Time_Of_Day;
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DateAndTimeDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Date_And_Time;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 8;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Date_And_Time;
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 8;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CharDataItemAnalysis(string nodedata, string itemName, string sPar)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    int start = CheckArrayStart(nodedata);
                    int end = CheckArrayEnd(nodedata);
                    int itemCount = end - start + 1;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        iTemp = start + i;
                        string sItemName = itemName + "[" + iTemp.ToString() + "]";
                        CTag cItemTemp = new CTag();
                        //cItemTemp.Key = sItemName;
                        cItemTemp.DataType = EMDataType.Char;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBB" + iTemp.ToString();

                        cItemTemp.Key = sSymbel;
                        cItemTemp.Address = sAddress;

                        m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                        m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 1;
                    }

                    iTemp = itemCount % 2;

                    if (iTemp == 1)
                    {
                        m_fDataItemIndex = m_fDataItemIndex + 1;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexSingular();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Char;
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBB" + iTemp.ToString();

                    cItemTemp.Key = sSymbel;
                    cItemTemp.Address = sAddress;

                    m_cUDTTemp.AddressTags.Add(sAddress, cItemTemp);
                    m_cUDTTemp.SymbolTags.Add(sSymbel, cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion
    }
}
