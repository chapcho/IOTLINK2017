using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CS7UDLUDTAnalysis
    {
        protected Dictionary<string,CUDLUDT> m_lstUDTList = null;
        protected double m_fDataItemIndex;

        #region Initialze/Dispose

        public CS7UDLUDTAnalysis()
        {
            //m_lstUDTList = new Dictionary<string,CUDLUDT>();
        }
        #endregion

        #region Public Properites

        public Dictionary<string,CUDLUDT> UDTList
        {
            get { return m_lstUDTList; }
            set { m_lstUDTList = value; }
        }

        #endregion

        #region Public Methods

        public void UDTListAnalysis(List<string> FilePart)
        {
            CUDLUDT TempUDT = new CUDLUDT();
            try
            {
                string sUDTName = string.Empty;
                m_fDataItemIndex = 0.0;
                int iCount = FilePart.Count;

                for(int i=0;i<iCount;i++)
                {
                    if(FilePart[i].StartsWith("TYPE"))
                    {
                        sUDTName = FindDatatypeName(FilePart[i]);
                        TempUDT.UDTName = sUDTName;
                    }
                    else if(FilePart[i].StartsWith("  STRUCT"))
                    {
                        List<string> sStructPart = new List<string>();
                        int j = i + 1;
                        while (!FilePart[j].StartsWith("  END_STRUCT"))
                        {
                            sStructPart.Add(FilePart[j]);
                            j++;
                        }
                        i = j;

                        StructAnalysis(sStructPart, "",TempUDT);
                    }
                }

                iCount = Convert.ToInt32(m_fDataItemIndex);
                double fTemp = m_fDataItemIndex - iCount;

                if(fTemp>0.0001)
                {
                    iCount = iCount + 1;
                }

                TempUDT.UDTLength = iCount;

                m_lstUDTList.Add(TempUDT.UDTName ,TempUDT);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

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

        private void StructAnalysis(List<string> sFilePart,string sPar,CUDLUDT tempUDT)
        {
            try
            {
                int count = sFilePart.Count;
                string sDataItemType = string.Empty;
                string sDataItemName = string.Empty;

                for(int i=0;i<count;i++)
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
                            if (sFilePart[j].Contains(": STRUCT") || sFilePart[j].Contains("OF STRUCT"))
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
                            List<string> IndexS = ArrayIndexGenertor(nodedata);

                            int itemCount = IndexS.Count;

                            for (int k = 0; k < itemCount; k++)
                            {
                                string sItemName = sDataItemName + "[" + IndexS[k] + "]";
                                string sTemp = sPar + "." + sItemName;

                                StructAnalysis(sStructPart, sTemp, tempUDT);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sStructPart, sTemp,tempUDT);
                        }

                        sStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sPar,tempUDT); break;

                            case "BYTE":
                            case "CHAR": ByteDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;

                            case "INT":                           
                            case "WORD": 
                            case "S5TIME": 
                            case "DATE": WordDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;

                            case "DWORD": 
                            case "DINT": 
                            case "REAL": 
                            case "TIME": 
                            case "TIME_OF_DAY": DWordDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;
                            
                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;

                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;                          
                         
                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sPar, tempUDT); break;
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

        private List<string> ArrayIndexGenertor(string nodedata)
        {
            List<string> IndexS = new List<string>();

            try
            {
                int iPos =0;
                string sTemp = string.Empty;

                if(nodedata.Contains("ARRAY  ["))
                {
                    iPos = nodedata.IndexOf("ARRAY  [");
                    sTemp = nodedata.Substring(iPos + 8);
                }
                else
                    sTemp = nodedata;

                int iArrayStart = CheckArrayStart(sTemp);
                int iArrayEnd = CheckArrayEnd(sTemp);

                if(sTemp.Contains(", "))
                {
                    iPos = sTemp.IndexOf(", ");

                    sTemp = sTemp.Substring(iPos + 2);

                    List<string> tempSubIndex = ArrayIndexGenertor(sTemp);
                    iPos = tempSubIndex.Count;

                    for(int i = iArrayStart;i<= iArrayEnd;i++)
                    {
                        for(int j =0;j<iPos;j++)
                        {
                            sTemp = i.ToString() + ", " + tempSubIndex[j];

                            IndexS.Add(sTemp);
                        }                        
                    }
                }
                else
                {
                    for(int i= iArrayStart;i<= iArrayEnd;i++)
                    {
                        sTemp = i.ToString();

                        IndexS.Add(sTemp);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return IndexS;
        }

        private int CheckArrayStart(string nodedata)
        {
            int iArrayStart = -1;
            try
            {             
                int iPos = nodedata.IndexOf(" .. ");
                string sTemp = nodedata.Remove(iPos);

                iArrayStart = Convert.ToInt16(sTemp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iArrayStart;
        }

        private int CheckArrayEnd(string nodedata)
        {
            int iArrayEnd = -1;
            try
            {
                int iPos = nodedata.IndexOf(" .. ");
                string sTemp = nodedata.Substring(iPos + 4);

                iPos = sTemp.IndexOf(" ] ");
                int iPos1 = sTemp.IndexOf(", ");

                if(iPos1>-1)
                {
                    sTemp = sTemp.Remove(iPos1);
                }
                else
                    sTemp = sTemp.Remove(iPos);

                iArrayEnd = Convert.ToInt16(sTemp);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iArrayEnd;
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

        private void WriteItemDatatype(CUDLTag cTag, string nodedata)
        {
            try
            {
                string ItemDataType = CheckItemDatatype(nodedata);

                switch(ItemDataType)
                {
                    case "BOOL": cTag.Datatype = EMDataType.Bool; break;

                    case "BYTE": cTag.Datatype = EMDataType.Byte; break;
                    case "CHAR": cTag.Datatype = EMDataType.Char; break;

                    case "INT": cTag.Datatype = EMDataType.Int; break;
                    case "WORD": cTag.Datatype = EMDataType.Word; break;
                    case "S5TIME": cTag.Datatype = EMDataType.S5Time; break;
                    case "DATE": cTag.Datatype = EMDataType.Date; break;

                    case "DWORD": cTag.Datatype = EMDataType.DWord; break;
                    case "DINT": cTag.Datatype = EMDataType.DInt; break;
                    case "REAL": cTag.Datatype = EMDataType.Real; break;
                    case "TIME": cTag.Datatype = EMDataType.Time; break;
                    case "TIME_OF_DAY": cTag.Datatype = EMDataType.Time_Of_Day; break;

                    case "DATE_AND_TIME": cTag.Datatype = EMDataType.Date_And_Time; break;

                    case "STRING": cTag.Datatype = EMDataType.String; break;

                    case "ANY": cTag.Datatype = EMDataType.Any; break;

                    default: cTag.Datatype = EMDataType.UserDefDataType;
                        cTag.UDTType = ItemDataType; break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
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

        private void BoolDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        CheckCarry();
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();

                        cItemTemp.Name = sItemName;
                        cItemTemp.Datatype = EMDataType.Bool;

                        string sSymbel = sPar + "." + sItemName;
                        string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                        cItemTemp.Address = sAddress;
                        cItemTemp.Name = sSymbel;
                        cItemTemp.Length = 1;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 0.1;

                    }

                    int iTemp = itemCount % 16;

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

                    CUDLTag cItemTemp = new CUDLTag();
                    
                    cItemTemp.Datatype = EMDataType.Bool;

                    string sSymbel = sPar + "." + itemName;
                    string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                    cItemTemp.Address = sAddress;
                    cItemTemp.Name = sSymbel;
                    cItemTemp.Length = 1;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 0.1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ByteDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();

                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBB" + iTemp.ToString();
                        
                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = 1;

                        tempUDT.MemTags.Add(cItemTemp);

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

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBB" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = 1;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WordDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = 1;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = 1;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DWordDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Name= sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = 1;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = 1;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ANYDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = 10;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 10;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = 10;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 10;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StringDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                int length = CheckStringLength(nodedata);

                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
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
                        string sItemName = itemName + "[" + IndexS[i] + "]";

                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);
                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = length;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    length = length + 2;

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;            
                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = length;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                string sUDTtype = CheckItemDatatype(nodedata);

                int length =0;

                if(m_lstUDTList.ContainsKey(sUDTtype))
                {
                    length = m_lstUDTList[sUDTtype].UDTLength;
                }
                else
                {
                    foreach (CUDLUDT udt in m_lstUDTList.Values)
                    {
                        if (udt.UDTName == sUDTtype)
                        {
                            length = udt.UDTLength;
                            break;
                        }
                    }
                }
                

                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
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
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = length;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);               

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = length;

                    tempUDT.MemTags.Add(cItemTemp);

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

        private void DateAndTimeDataItemAnalysis(string nodedata, string itemName, string sPar,CUDLUDT tempUDT)
        {
            try
            {
                if (CheckIsArray(nodedata))
                {
                    List<string> IndexS = ArrayIndexGenertor(nodedata);

                    int itemCount = IndexS.Count;
                    int iTemp = 0;

                    CheckCarry();
                    MakeIndexEven();

                    for (int i = 0; i < itemCount; i++)
                    {
                        string sItemName = itemName + "[" + IndexS[i] + "]";

                        CUDLTag cItemTemp = new CUDLTag();
                        //cItemTemp.Key = sItemName;
                        WriteItemDatatype(cItemTemp, nodedata);

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Name = sSymbel;
                        cItemTemp.Address = sAddress;
                        cItemTemp.Length = 1;

                        tempUDT.MemTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 8;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();
                    //cItemTemp.Key = itemName;
                    WriteItemDatatype(cItemTemp, nodedata);
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Name = sSymbel;
                    cItemTemp.Address = sAddress;
                    cItemTemp.Length = 1;

                    tempUDT.MemTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 8;
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
