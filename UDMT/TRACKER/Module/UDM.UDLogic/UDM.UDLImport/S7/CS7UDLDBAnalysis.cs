using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CS7UDLDBAnalysis
    {
        protected Dictionary<string,CUDLUDT> m_lstUDTList = null;
        protected double m_fDataItemIndex;
        protected Dictionary<string, CUDLBlock> m_lstBlockList = null;
        protected List<CUDLTag> m_lstTagList = null;
        protected string m_sChannel = string.Empty;
        protected Dictionary<string, CUDLBlock> m_dicSystemFunctS = null;
        protected List<string> m_lstAnalysisDBS = null;
        #region Initialze/Dispose

        public CS7UDLDBAnalysis(List<string> AnlyDBS)
        {
            m_lstAnalysisDBS = AnlyDBS;
            m_fDataItemIndex = 0.0;
        }

        #endregion

        #region Public Properites

        public Dictionary<string,CUDLUDT> UDTList
        {
            get { return m_lstUDTList; }
            set { m_lstUDTList = value; }
        }

        public List<CUDLTag> TagList
        {
            get { return m_lstTagList; }
            set { m_lstTagList = value; }
        }

        public Dictionary<string,CUDLBlock> BlockList
        {
            get { return m_lstBlockList; }
            set { m_lstBlockList = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public Dictionary<string,CUDLBlock> SystemFunctionS
        {
            get { return m_dicSystemFunctS; }
            set { m_dicSystemFunctS = value; }
        }

        #endregion

        #region Public Methods

        public void DatablockAnalysis(List<string> FilePart)
        {
            try
            {
                CUDLBlock TempBlock = new CUDLBlock();
                TempBlock.BlockType = EMBlockType.Datablock;
                string sDBName = string.Empty;
                string sDBAddress = string.Empty;
                string sFbName = string.Empty;
                m_fDataItemIndex = 0.0;
                int iCount = FilePart.Count;

                for(int i=0;i<iCount;i++)
                {
                    if (FilePart[i].StartsWith("DATA_BLOCK"))
                    {
                        sDBAddress = FindDataBlockName(FilePart[i]);

                        if (sDBAddress.Contains("\""))
                            sDBAddress = sDBAddress.Replace("\"", "");

                        TempBlock.BlockName = sDBAddress;
                        m_lstAnalysisDBS.Add(sDBAddress);
                        sDBName = FindBlockSymbol(sDBAddress);

                        if (sDBName.Contains("\""))
                            sDBName = sDBName.Replace("\"", "");

                        TempBlock.BlockAddress = sDBName;
                    }
                    else if(FilePart[i].StartsWith(" FB "))
                    {
                        sFbName = FilePart[i].Replace(" ", "");
                        //m_lstAnalysisDBS.Add(sDBAddress);
                        InstanceDBAnalysis(sFbName, TempBlock);
                        TempBlock.IsSharedDB = false;
                        break;
                    }
                    else if (FilePart[i].StartsWith("  STRUCT"))
                    {
                        List<string> sStructPart = new List<string>();
                        int j = i + 1;
                        while (!FilePart[j].StartsWith("  END_STRUCT"))
                        {
                            sStructPart.Add(FilePart[j]);
                            j++;
                        }
                        i = j;

                        StructAnalysis(sStructPart, "", TempBlock);
                        break;
                    }
                }

                iCount = Convert.ToInt32(m_fDataItemIndex);
                double fTemp = m_fDataItemIndex - iCount;

                if (fTemp > 0.0001)
                {
                    iCount = iCount + 1;
                }

                TempBlock.ParameterLenght = iCount;

                m_lstBlockList.Add(TempBlock.BlockName ,TempBlock);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private string FindBlockSymbol(string nodeData)
        {
            string FBSymbol = string.Empty;
            try
            {
                foreach (CUDLTag tempTag in m_lstTagList)
                {
                    if (tempTag.Address == nodeData)
                    {
                        FBSymbol = tempTag.Name;
                        break;
                    }
                }

                if (FBSymbol != string.Empty)
                    FBSymbol = "\"" + FBSymbol + "\"";

                if (FBSymbol == string.Empty)
                    FBSymbol = nodeData;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return FBSymbol;
        }

        private string FindDataBlockName(string nodedata)
        {
            string sName = string.Empty;
            try
            {
                if (nodedata.StartsWith("DATA_BLOCK \""))
                {
                    sName = nodedata.Substring(5);
                }
                else if (nodedata.StartsWith("DATA_BLOCK "))
                {
                    sName = nodedata.Substring(10);
                    sName = sName.Replace(" ", "");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private void InstanceDBAnalysis(string nodedata, CUDLBlock tempDB)
        {
            try
            {
                if(m_lstBlockList.ContainsKey(nodedata))
                {
                    CUDLBlock tempBlock = m_lstBlockList[nodedata];
                    TransFBTags(tempDB, tempBlock);
                }
                else
                {
                    foreach (CUDLBlock tempBlock in m_lstBlockList.Values)
                    {
                        if (tempBlock.BlockName == nodedata)
                        {
                            TransFBTags(tempDB, tempBlock);
                            break;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void TransFBTags(CUDLBlock tempDB, CUDLBlock TempFB)
        {
            try
            {
                CUDLTag TempDBTag = null;

                foreach (CUDLTag tempTag in TempFB.InputTags)
                {
                    TempDBTag = FBToDBUDLTag(tempTag, tempDB.BlockName, tempDB.BlockAddress);
                    tempDB.InputTags.Add(TempDBTag);
                }

                foreach (CUDLTag tempTag in TempFB.OutputTags)
                {
                    TempDBTag = FBToDBUDLTag(tempTag, tempDB.BlockName, tempDB.BlockAddress);
                    tempDB.OutputTags.Add(TempDBTag);
                }

                foreach(CUDLTag tempTag in TempFB.InOutTags)
                {
                    TempDBTag = FBToDBUDLTag(tempTag, tempDB.BlockName, tempDB.BlockAddress);
                    tempDB.InOutTags.Add(TempDBTag);
                }

                foreach(CUDLTag tempTag in TempFB.STATTags)
                {
                    TempDBTag = FBToDBUDLTag(tempTag, tempDB.BlockName, tempDB.BlockAddress);
                    tempDB.STATTags.Add(TempDBTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private CUDLTag FBToDBUDLTag(CUDLTag tempTag,string DBName, string DBAddress)
        {
            CUDLTag dbTag = new CUDLTag();

            try
            {
                string dbTagName = tempTag.Name;
                int iPos = dbTagName.IndexOf(".");

                dbTagName = DBAddress + dbTagName.Substring(iPos);

                string dbTagAddress = tempTag.Address;
                iPos = dbTagAddress.IndexOf(".");
                dbTagAddress = DBName + dbTagAddress.Substring(iPos);

                dbTag.Name = dbTagName;
                dbTag.Address = dbTagAddress;
                dbTag.Description = tempTag.Description;
                dbTag.PLCMaker = tempTag.PLCMaker;
                dbTag.Program = tempTag.Program;
                dbTag.Length = tempTag.Length;
                dbTag.Datatype = tempTag.Datatype;

                if (tempTag.Datatype == EMDataType.UserDefDataType)
                    dbTag.UDTType = tempTag.UDTType;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return dbTag;
        }

        private void StructAnalysis(List<string> sFilePart, string sPar, CUDLBlock tempBlock)
        {
            string sDataItemType = string.Empty;
            string sDataItemName = string.Empty;
            try
            {
                int count = sFilePart.Count;


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

                                StructAnalysis(sStructPart, sTemp, tempBlock);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sStructPart, sTemp, tempBlock);
                        }

                        sStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "BYTE":
                            case "CHAR": ByteDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "INT":
                            case "WORD":
                            case "S5TIME":
                            case "DATE": WordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "DWORD":
                            case "DINT":
                            case "REAL":
                            case "TIME":
                            case "TIME_OF_DAY": DWordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock); break;
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

                switch (ItemDataType)
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

        private List<string> ArrayIndexGenertor(string nodedata)
        {
            List<string> IndexS = new List<string>();

            try
            {
                int iPos = 0;
                string sTemp = string.Empty;

                if (nodedata.Contains("ARRAY  ["))
                {
                    iPos = nodedata.IndexOf("ARRAY  [");
                    sTemp = nodedata.Substring(iPos + 8);
                }
                else
                    sTemp = nodedata;

                int iArrayStart = CheckArrayStart(sTemp);
                int iArrayEnd = CheckArrayEnd(sTemp);

                if (sTemp.Contains(", "))
                {
                    iPos = sTemp.IndexOf(", ");

                    sTemp = sTemp.Substring(iPos + 2);

                    List<string> tempSubIndex = ArrayIndexGenertor(sTemp);
                    iPos = tempSubIndex.Count;

                    for (int i = iArrayStart; i <= iArrayEnd; i++)
                    {
                        for (int j = 0; j < iPos; j++)
                        {
                            sTemp = i.ToString() + ", " + tempSubIndex[j];

                            IndexS.Add(sTemp);
                        }
                    }
                }
                else
                {
                    for (int i = iArrayStart; i <= iArrayEnd; i++)
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

                if (iPos1 > -1)
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

                    if (iPos == -1)
                        iPos = nodedata.IndexOf(": ");

                    if(iPos != -1)
                        sDataItem = nodedata.Remove(iPos);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sDataItem;
        }

        private void BoolDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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
                        CheckCarry();
                        string sItemName = itemName + "[" + IndexS[i] + "]";
                        CUDLTag cItemTemp = new CUDLTag();

                        cItemTemp.Name = sItemName;
                        cItemTemp.Datatype = EMDataType.Bool;

                        string sSymbel = sPar + "." + sItemName;
                        string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                        cItemTemp.Address = tempBlock.BlockName +"."+ sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;

                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 1;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        tempBlock.InputTags.Add(cItemTemp);

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

                    CUDLTag cItemTemp = new CUDLTag();

                    cItemTemp.Datatype = EMDataType.Bool;

                    string sSymbel = sPar + "." + itemName;
                    string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                    cItemTemp.Length = 1;

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 0.1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ByteDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 1;

                        tempBlock.InputTags.Add(cItemTemp);

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

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                    cItemTemp.Length = 1;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WordDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 1;

                        tempBlock.InputTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();

                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                    cItemTemp.Length = 1;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }        

        private void DWordDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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
                        string sAddress = "DBD" + iTemp.ToString();

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 1;

                        tempBlock.InputTags.Add(cItemTemp);

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CUDLTag cItemTemp = new CUDLTag();

                    WriteItemDatatype(cItemTemp, nodedata);

                    string sComment = CheckComment(nodedata);
                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBD" + iTemp.ToString();

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                    cItemTemp.Length = 1;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ANYDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 10;

                        tempBlock.InputTags.Add(cItemTemp);

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

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                    cItemTemp.Length = 10;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 10;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StringDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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
                        cItemTemp.Datatype = EMDataType.String;

                        string sComment = CheckComment(nodedata);
                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        string sSymbel = sPar + "." + sItemName;
                        iTemp = Convert.ToInt32(m_fDataItemIndex);
                        string sAddress = "DBW" + iTemp.ToString();

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                        cItemTemp.Length = length;

                        tempBlock.InputTags.Add(cItemTemp);

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
                    cItemTemp.Datatype = EMDataType.String;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    string sSymbel = sPar + "." + itemName;
                    int iTemp = Convert.ToInt32(m_fDataItemIndex);

                    string sAddress = "DBW" + iTemp.ToString();

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                    cItemTemp.Length = length;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
        {
            try
            {
                string sUDTtype = CheckItemDatatype(nodedata);

                int length = CheckUDTTagLength(sUDTtype);
                if (length == 0)
                    length = CheckFBTagLength(sUDTtype);

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

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                        cItemTemp.Length = length;

                        tempBlock.InputTags.Add(cItemTemp);

                        FindUDTSubTagS(sSymbel, tempBlock, m_fDataItemIndex, sUDTtype);

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

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                    cItemTemp.Length = length;

                    tempBlock.InputTags.Add(cItemTemp);

                    FindUDTSubTagS(sSymbel, tempBlock, m_fDataItemIndex, sUDTtype);

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

        private int CheckUDTTagLength(string sNodedata)
        {
            int iLength = 0;

            try
            {
                if(m_lstUDTList.ContainsKey(sNodedata))
                {
                    iLength = m_lstUDTList[sNodedata].UDTLength;
                }
                else
                {
                    foreach (CUDLUDT udt in m_lstUDTList.Values)
                    {
                        if (udt.UDTName == sNodedata)
                        {
                            iLength = udt.UDTLength;
                            break;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iLength;
        }

        private int CheckFBTagLength(string sNodedata)
        {
            int iLength = 0;
            try
            {
                if(m_lstBlockList.ContainsKey(sNodedata))
                {
                    iLength = m_lstBlockList[sNodedata].ParameterLenght;
                }
                else
                {
                    foreach (CUDLBlock tempblock in m_lstBlockList.Values)
                    {
                        if (tempblock.BlockName == sNodedata)
                        {
                            iLength = tempblock.ParameterLenght;
                            break;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iLength;
        }

        private void DateAndTimeDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock)
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

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                        cItemTemp.Length = 1;

                        tempBlock.InputTags.Add(cItemTemp);

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

                    cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                    cItemTemp.Name = tempBlock.BlockAddress + sSymbel;
                    cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                    cItemTemp.Length = 1;

                    tempBlock.InputTags.Add(cItemTemp);

                    m_fDataItemIndex = m_fDataItemIndex + 8;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTSubTagAnalysis(string sPar, CUDLBlock tempBlock, double udtAddress,CUDLUDT tempUDT)
        {
            try
            {
                foreach(CUDLTag tempTag in tempUDT.MemTags)
                {
                    string tagName = tempTag.Name;
                    string tagAddress = tempTag.Address;
                    string tagDescri = tempTag.Description;

                    tagAddress = MakeNewSubTagAddress(tagAddress, udtAddress);

                    tagName = sPar + tagName;
                    tagAddress = tempBlock.BlockName + "." + tagAddress;

                    CUDLTag tempItemTag = new CUDLTag();
                    tempItemTag.Description = tagDescri;
                    tempItemTag.Name = tempBlock.BlockAddress+ tagName;
                    tempItemTag.Address = tagAddress;
                    tempItemTag.Datatype = tempTag.Datatype;
                    tempItemTag.PLCMaker = EMPLCMaker.Siemens;

                    if (tempItemTag.Datatype == EMDataType.UserDefDataType)
                    {
                        tempItemTag.UDTType = tempTag.UDTType;
                        double dTempAddress = GetUdtItemAddress(tagAddress);

                        tempBlock.InputTags.Add(tempItemTag);

                        FindUDTSubTagS(tagName, tempBlock, dTempAddress, tempItemTag.UDTType);
                    }
                    else
                        tempBlock.InputTags.Add(tempItemTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void BlockSubTagAnalysis(string sPar,CUDLBlock tempBlock, double udtAddress, CUDLBlock TagBlock)
        {
            try
            {
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.InputTags);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.OutputTags);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.InOutTags);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.STATTags);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void FindUDTSubTagS(string sPar,CUDLBlock tempBlock,double udtAddress, string udtType)
        {
            try
            {
                if(CheckIsUDTType(udtType))
                {
                    CUDLUDT targetUDT = GetUDT(udtType);
                    UDTSubTagAnalysis(sPar, tempBlock, udtAddress, targetUDT);
                }
                else if(CheckIsBlockType(udtType))
                {
                    CUDLBlock targetBlock = GetBlock(udtType);
                    BlockSubTagAnalysis(sPar, tempBlock, udtAddress, targetBlock);
                }
                    
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private bool CheckIsUDTType(string sNodedata)
        {
            bool isTrue = false;
            try
            {
                if(m_lstUDTList.ContainsKey(sNodedata))
                {
                    isTrue = true;
                }
                else
                {
                    foreach (CUDLUDT tempUdt in m_lstUDTList.Values)
                    {
                        if (tempUdt.UDTName == sNodedata)
                        {
                            isTrue = true;
                            break;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private bool CheckIsBlockType(string sNodedata)
        {
            bool isTrue = false;
            try
            {
                if(m_dicSystemFunctS.ContainsKey(sNodedata))
                {
                    isTrue = true;
                }
                else
                {
                    if(m_lstBlockList.ContainsKey(sNodedata))
                    {
                        isTrue = true;
                    }
                    else
                    {
                        foreach (CUDLBlock tempBlock in m_lstBlockList.Values)
                        {
                            if (tempBlock.BlockAddress == sNodedata)
                            {
                                isTrue = true;
                                break;
                            }
                        }
                    }                   
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private CUDLBlock GetBlock(string sNodedata)
        {
            CUDLBlock targetBlock = null;
            try
            {
                if (m_dicSystemFunctS.ContainsKey(sNodedata))
                {
                    targetBlock = m_dicSystemFunctS[sNodedata];
                }
                else
                {
                    if(m_lstBlockList.ContainsKey(sNodedata))
                    {
                        targetBlock = m_lstBlockList[sNodedata];
                    }
                    else
                    {
                        foreach (CUDLBlock tempBlock in m_lstBlockList.Values)
                        {
                            if (tempBlock.BlockName == sNodedata)
                            {
                                targetBlock = tempBlock;
                                break;
                            }
                        }
                    }                    
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return targetBlock;
        }

        private CUDLUDT GetUDT(string sNodedata)
        {
            CUDLUDT tempUDT = null;
            try
            {
                if(m_lstUDTList.ContainsKey(sNodedata))
                {
                    tempUDT = m_lstUDTList[sNodedata];
                }
                else
                {
                    foreach (CUDLUDT tempUdt in m_lstUDTList.Values)
                    {
                        if (tempUdt.UDTName == sNodedata)
                        {
                            tempUDT = tempUdt;
                            break;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempUDT;
        }

        private string MakeNewSubTagAddress(string OldAddress, double TagGlobAddress)
        {
            string newAddress = string.Empty;
            try
            {
                int iPos = -1;
                bool isBoolType = false;

                if(OldAddress.Contains("DBX"))
                {
                    iPos = OldAddress.IndexOf("DBX");
                    isBoolType = true;
                }
                else if (OldAddress.Contains("DBB"))
                {
                    iPos = OldAddress.IndexOf("DBB");
                }
                if (OldAddress.Contains("DBW"))
                {
                    iPos = OldAddress.IndexOf("DBW");
                }
                if (OldAddress.Contains("DBD"))
                {
                    iPos = OldAddress.IndexOf("DBD");
                }

                if (iPos >= 0)
                {
                    string sTemp = OldAddress.Substring(iPos + 3);
                    double dTempAddress = Convert.ToDouble(sTemp);
                    dTempAddress = dTempAddress+TagGlobAddress;

                    sTemp = OldAddress.Remove(iPos + 3);

                    if(isBoolType)
                    {
                        newAddress = sTemp + dTempAddress.ToString("0.0");
                    }
                    else
                    {
                        int iTemp = Convert.ToInt32(dTempAddress);
                        newAddress = sTemp + iTemp.ToString();
                    }
                }
                else
                    newAddress = OldAddress;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return newAddress;
        }

        private double GetUdtItemAddress(string sTemp)
        {
            double dTemp = 0.0;
            try
            {
                int iPos = -1;

                if (sTemp.Contains("DBX"))
                {
                    iPos = sTemp.IndexOf("DBX");
                }
                else if (sTemp.Contains("DBB"))
                {
                    iPos = sTemp.IndexOf("DBB");
                }
                if (sTemp.Contains("DBW"))
                {
                    iPos = sTemp.IndexOf("DBW");
                }
                if (sTemp.Contains("DBD"))
                {
                    iPos = sTemp.IndexOf("DBD");
                }

                if (iPos >= 0)
                {
                    sTemp = sTemp.Substring(iPos + 3);
                    dTemp = Convert.ToDouble(sTemp);                   
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return dTemp;
        }

        private void BlockUsageSubTagAnalysis(string sPar,CUDLBlock tempBlock, double udtAddress, List<CUDLTag> tempListTagS)
        {
            try
            {
                foreach (CUDLTag tempTag in tempListTagS)
                {
                    string tagName = tempTag.Name;
                    string tagAddress = tempTag.Address;
                    string tagDescri = tempTag.Description;

                    int Ipos = tagName.IndexOf(".");

                    tagName = tagName.Substring(Ipos);

                    Ipos = tagAddress.IndexOf(".");
                    tagAddress = tagAddress.Substring(Ipos + 1);

                    tagAddress = MakeNewSubTagAddress(tagAddress, udtAddress);

                    tagName = sPar + tagName;
                    tagAddress = tempBlock.BlockName + "." + tagAddress;

                    CUDLTag tempItemTag = new CUDLTag();
                    tempItemTag.Description = tagDescri;
                    tempItemTag.Name = tempBlock.BlockAddress + tagName;
                    tempItemTag.Address = tagAddress;
                    tempItemTag.Datatype = tempTag.Datatype;
                    tempItemTag.PLCMaker = EMPLCMaker.Siemens;

                    if (tempItemTag.Datatype == EMDataType.UserDefDataType)
                    {
                        tempItemTag.UDTType = tempTag.UDTType;
                        double dTempAddress = GetUdtItemAddress(tagAddress);

                        tempBlock.InputTags.Add(tempItemTag);

                        FindUDTSubTagS(tagName, tempBlock, dTempAddress, tempItemTag.UDTType);
                    }
                    else
                        tempBlock.InputTags.Add(tempItemTag);
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
