using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CS7UDLBlockAnalysis
    {
        protected List<string> m_lstFilePart = null;
        protected Dictionary<string,CUDLBlock> m_lstBlockList = null;
        protected Dictionary<string,CUDLUDT> m_lstUDTList = null;
        protected List<CUDLTag> m_lstTagList = null;
        protected double m_fDataItemIndex;
        protected int m_iNetworkCount = 0;
        protected string m_sChannel = "1";
        protected CS7UDLLogicAnalysis m_cLogicAnalysis = null;
        protected Dictionary<string, CUDLBlock> m_dicSystemFunctS = null;
        protected Dictionary<string, string> m_dLocalBlocks = null;
        protected List<string> m_lstProtectedFBList = null;
        protected string m_sFCReturnType = null;

        #region Initialze/Dispose

        public CS7UDLBlockAnalysis(Dictionary<string, CInstruction> insDic)
        {
            m_cLogicAnalysis = new CS7UDLLogicAnalysis(insDic);

            m_lstProtectedFBList = m_cLogicAnalysis.ProtectedFBList;
        }

        #endregion

        #region Public Properites
        
        public Dictionary<string,CUDLBlock> BlockList
        {
            get { return m_lstBlockList; }
            set { m_lstBlockList = value;
            m_cLogicAnalysis.BlockList = m_lstBlockList;
            }
        }

        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }

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

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }
        public Dictionary<string, CUDLBlock> SystemFunctionS
        {
            get { return m_dicSystemFunctS; }
            set { m_dicSystemFunctS = value;
            m_cLogicAnalysis.SystemFunctionS = m_dicSystemFunctS;
            }
        }
        #endregion

        #region Public Methods

        public void BlockAnalysis(List<string> FilePart)
        {            
            try
            {
                m_fDataItemIndex = 0.0;
                m_iNetworkCount = 0;

                string sBlockName = string.Empty;
                string sBlockAddress = string.Empty;
                int iCount = FilePart.Count;
                m_dLocalBlocks = new Dictionary<string, string>();

                CUDLBlock TempBlock = new CUDLBlock();
                m_sFCReturnType = string.Empty;

                for(int i =0;i<iCount;i++)
                {
                    if(FilePart[i].StartsWith("FUNCTION_BLOCK "))
                    {
                        sBlockAddress = FindFBName(FilePart[i]);

                        if (sBlockAddress.Contains("\""))
                            sBlockAddress = sBlockAddress.Replace("\"", "");

                        TempBlock.BlockName = sBlockAddress;
                        TempBlock.BlockType = EMBlockType.FunctionBlock;

                        sBlockName = FindBlockSymbol(sBlockAddress);

                        if (sBlockName.Contains("\""))
                            sBlockName = sBlockName.Replace("\"", "");

                        TempBlock.BlockAddress = sBlockName;
                    }
                    else if(FilePart[i].StartsWith("FUNCTION "))
                    {
                        sBlockAddress = FindFCName(FilePart[i]);

                        if (sBlockAddress.Contains("\""))
                            sBlockAddress = sBlockAddress.Replace("\"", "");

                        TempBlock.BlockName = sBlockAddress;
                        TempBlock.BlockType = EMBlockType.Function;

                        sBlockName = FindBlockSymbol(sBlockAddress);

                        if (sBlockName.Contains("\""))
                            sBlockName = sBlockName.Replace("\"", "");

                        TempBlock.BlockAddress = sBlockName;
                    }
                    else if(FilePart[i].StartsWith("ORGANIZATION_BLOCK"))
                    {
                        sBlockAddress = FindOBName(FilePart[i]);

                        if (sBlockAddress.Contains("\""))
                            sBlockAddress = sBlockAddress.Replace("\"", "");

                        TempBlock.BlockName= sBlockAddress;
                        TempBlock.BlockType = EMBlockType.OrganizationBlock;

                        sBlockName = FindBlockSymbol(sBlockAddress);

                        if (sBlockName.Contains("\""))
                            sBlockName = sBlockName.Replace("\"", "");

                        TempBlock.BlockAddress = sBlockName;
                    }
                    else if(FilePart[i].StartsWith("TITLE ="))
                    {
                        string sTitle = FilePart[i];
                        int j = i + 1;
                        while (!FilePart[j].StartsWith("VERSION :"))
                        {
                            sTitle = sTitle + FilePart[j];
                            j++;
                        }
                        i = j;
                        sTitle = FindFunctionComment(sTitle);

                        TempBlock.Comment = sTitle;
                    }
                    else if (FilePart[i].StartsWith("VAR"))
                    {
                        List<string> sTagPart = new List<string>();
                        int j = i;

                        while (FilePart[j] != "BEGIN")
                        {
                            sTagPart.Add(FilePart[j]);
                            j++;
                        }
                        i = j;

                        FunctionTagAnalysis(sTagPart,"",TempBlock);

                    }
                    else if (FilePart[i]=="NETWORK")
                    {
                        List<string> sLogicPart = new List<string>();
                        int j = i;
                        while (FilePart[j] != "END_FUNCTION_BLOCK" && FilePart[j] != "END_FUNCTION" && FilePart[j] != "END_ORGANIZATION_BLOCK")
                        {
                            sLogicPart.Add(FilePart[j]);
                            j++;
                        }
                        i = j;
                        BlockLogicAnalysis(sLogicPart, TempBlock);
                    }
                }

                if (m_sFCReturnType != string.Empty)
                {
                    if (!m_sFCReturnType.Contains("VOID"))
                    {
                        CUDLTag cDataItem = new CUDLTag();

                        cDataItem.Name = TempBlock.BlockAddress + "." + "RET_VAL";
                        cDataItem.Address = TempBlock.BlockName + "." + "RET_VAL";

                        switch (m_sFCReturnType)
                        {
                            case "BOOL": cDataItem.Datatype = EMDataType.Bool; break;

                            case "BYTE": cDataItem.Datatype = EMDataType.Byte; break;
                            case "CHAR": cDataItem.Datatype = EMDataType.Char; break;

                            case "INT": cDataItem.Datatype = EMDataType.Int; break;
                            case "WORD": cDataItem.Datatype = EMDataType.Word; break;
                            case "S5TIME": cDataItem.Datatype = EMDataType.S5Time; break;
                            case "DATE": cDataItem.Datatype = EMDataType.Date; break;

                            case "DWORD": cDataItem.Datatype = EMDataType.DWord; break;
                            case "DINT": cDataItem.Datatype = EMDataType.DInt; break;
                            case "REAL": cDataItem.Datatype = EMDataType.Real; break;
                            case "TIME": cDataItem.Datatype = EMDataType.Time; break;
                            case "TIME_OF_DAY": cDataItem.Datatype = EMDataType.Time_Of_Day; break;

                            case "DATE_AND_TIME": cDataItem.Datatype = EMDataType.Date_And_Time; break;

                            case "STRING": cDataItem.Datatype = EMDataType.String; break;

                            case "ANY": cDataItem.Datatype = EMDataType.Any; break;
                        }
                        cDataItem.PLCMaker = EMPLCMaker.Siemens;
                        TempBlock.OutputTags.Add(cDataItem);
                    }
                }

                int iTemp = Convert.ToInt32(m_fDataItemIndex);
                double fTemp = m_fDataItemIndex - iTemp;

                if (fTemp > 0.00001)
                {
                    iTemp = iTemp + 1;
                }

                TempBlock.ParameterLenght = iTemp;

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
                foreach(CUDLTag tempTag in m_lstTagList)
                {
                    if(tempTag.Address == nodeData)
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

        private void BlockLogicAnalysis(List<string> sFilePart, CUDLBlock tempBlock)
        {
            try
            {
                int iCount = sFilePart.Count;

                CUDLRoutine tempRouting = new CUDLRoutine();

                m_iNetworkCount = 1;

                string sBlockName = tempBlock.BlockName;

                m_cLogicAnalysis.NewBlockSetting(sBlockName,tempBlock,m_dLocalBlocks);

                for(int i =0;i<iCount;i++)
                {
                    if (sFilePart[i] == "NETWORK")
                    {
                        List<string> NetWorkPart = new List<string>();
                        NetWorkPart.Add(sFilePart[i]);

                        int j = i + 1;
                        while (sFilePart[j] != "NETWORK")
                        {
                            NetWorkPart.Add(sFilePart[j]);
                            j++;

                            if (j == sFilePart.Count)
                                break;
                        }
                        i = j - 1;

                        CUDLLogic tempLogic =  m_cLogicAnalysis.NetworkAnalysisi(NetWorkPart, m_iNetworkCount);

                        tempRouting.Logics.Add(tempLogic);

                        m_iNetworkCount = m_iNetworkCount + 1;
                    }
                }
                tempBlock.Routines.Add(tempRouting);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void FunctionTagAnalysis(List<string> sTagPart,string sPar,CUDLBlock tempBlock)
        {
            try
            {
                int iCount = sTagPart.Count;
                for (int i = 0; i < iCount; i++)
                {
                    if (sTagPart[i].StartsWith("VAR"))
                    {
                        string usage = CheckUsage(sTagPart[i]);
                        List<string> varPart = new List<string>();

                        int j = i + 1;
                        while (sTagPart[j] != "END_VAR")
                        {
                            varPart.Add(sTagPart[j]);
                            j++;
                        }
                        i = j;

                        VarTagAnalysis(varPart, usage,sPar,tempBlock);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void VarTagAnalysis(List<string> sVarPart,string sUsage,string sPar,CUDLBlock tempBlock)
        {
            try
            {
                int iCount = sVarPart.Count;
                string sDataItemName = string.Empty;
                string sDataItemType = string.Empty;

                MakeIndexEven();

                for (int i = 0; i < iCount; i++)
                {
                    string nodedata = sVarPart[i];

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

                                string sTemp = sVarPart[i];

                                sTemp = FrontCleanNodedata(sTemp);

                                nodedata = nodedata + sTemp + sComment;
                            }
                            else
                            {
                                string sTemp = sVarPart[i];

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
                            if (sVarPart[j].Contains(" STRUCT"))
                                iInStruct = iInStruct + 1;
                            else if (sVarPart[j].Contains("END_STRUCT"))
                                iInStruct = iInStruct - 1;

                            if (iInStruct != 0)
                            {
                                sStructPart.Add(sVarPart[j]);

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

                                CUDLTag cItemTemp = new CUDLTag();

                                cItemTemp.Address = tempBlock.BlockName + "." + sTemp;
                                cItemTemp.Name = tempBlock.BlockAddress + sTemp;
                                cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                                cItemTemp.Datatype = EMDataType.UserDefDataType;
                                cItemTemp.UDTType = "Struct";
                                cItemTemp.Length = 1;

                                AddToSubTagS(cItemTemp, tempBlock, sUsage);

                                StructAnalysis(sStructPart, sUsage, sTemp,tempBlock);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            CUDLTag cItemTemp = new CUDLTag();

                            cItemTemp.Address = tempBlock.BlockName + "." + sTemp;
                            cItemTemp.Name = tempBlock.BlockAddress + sTemp;
                            cItemTemp.PLCMaker = EMPLCMaker.Siemens;
                            cItemTemp.Datatype = EMDataType.UserDefDataType;
                            cItemTemp.UDTType = "Struct";
                            cItemTemp.Length = 1;

                            AddToSubTagS(cItemTemp, tempBlock, sUsage);


                            StructAnalysis(sStructPart, sUsage, sTemp,tempBlock);
                        }

                        sStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock,sUsage,false); break;

                            case "BYTE":
                            case "CHAR": ByteDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            case "INT":
                            case "WORD":
                            case "S5TIME":
                            case "DATE": WordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            case "DWORD":
                            case "DINT":
                            case "REAL":
                            case "TIME":
                            case "TIME_OF_DAY": DWordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, false); break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StructAnalysis(List<string> sStructPart, string sUsage,string sPar,CUDLBlock tempBlock)
        {
            try
            {
                int iCount = sStructPart.Count;
                string sDataItemName = string.Empty;
                string sDataItemType = string.Empty;

                for (int i = 0; i < iCount; i++)
                {
                    string nodedata = sStructPart[i];

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

                                string sTemp = sStructPart[i];

                                sTemp = FrontCleanNodedata(sTemp);

                                nodedata = nodedata + sTemp + sComment;
                            }
                            else
                            {
                                string sTemp = sStructPart[i];

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
                        List<string> sSubStructPart = new List<string>();
                        int j = i + 1;
                        int iInStruct = 1;
                        while (iInStruct > 0)
                        {
                            if (sStructPart[j].Contains(" STRUCT"))
                                iInStruct = iInStruct + 1;
                            else if (sStructPart[j].Contains("END_STRUCT"))
                                iInStruct = iInStruct - 1;

                            if (iInStruct != 0)
                            {
                                sSubStructPart.Add(sStructPart[j]);

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

                                StructAnalysis(sSubStructPart, sUsage, sTemp,tempBlock);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sSubStructPart, sUsage, sTemp,tempBlock);
                        }

                        sSubStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage,true); break;

                            case "BYTE":
                            case "CHAR": ByteDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            case "INT":
                            case "WORD":
                            case "S5TIME":
                            case "DATE": WordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            case "DWORD":
                            case "DINT":
                            case "REAL":
                            case "TIME":
                            case "TIME_OF_DAY": DWordDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sPar, tempBlock, sUsage, true); break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string FindFunctionComment(string nodedata)
        {
            try
            {
                if (nodedata.Length > 7)
                {
                    nodedata = nodedata.Substring(7);
                }
                return nodedata;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string FindFCName(string nodedata)
        {
            try
            {
                nodedata = nodedata.Replace("FUNCTION ", "");

                if (nodedata.IndexOf(":") > 1)
                {
                    m_sFCReturnType = nodedata.Substring(nodedata.IndexOf(":")+1);
                    m_sFCReturnType = m_sFCReturnType.Replace(" ", "");
                    nodedata = nodedata.Remove(nodedata.IndexOf(":"));
                }
                    

                if (!nodedata.StartsWith("\""))
                    nodedata = nodedata.Replace(" ", "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string FindFBName(string nodedata)
        {
            try
            {
                nodedata = nodedata.Replace("FUNCTION_BLOCK ", "");
                if (!nodedata.StartsWith("\""))
                    nodedata = nodedata.Replace(" ", "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string FindOBName(string nodedata)
        {
            try
            {
                nodedata = nodedata.Replace("ORGANIZATION_BLOCK ", "");
                if (!nodedata.StartsWith("\""))
                    nodedata = nodedata.Replace(" ", "");
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

        private string CheckUsage(string nodedata)
        {
            try
            {
                if (nodedata.Length > 4)
                    nodedata = nodedata.Substring(4);
                else
                    nodedata = "STAT";
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

        private void AddToSubTagS(CUDLTag cItemTag, CUDLBlock cTempBlock, string sUsage)
        {
            try
            {
                switch(sUsage)
                {
                    case "INPUT": cTempBlock.InputTags.Add(cItemTag); break;
                    case "OUTPUT": cTempBlock.OutputTags.Add(cItemTag); break;
                    case "IN_OUT": cTempBlock.InOutTags.Add(cItemTag); break;
                    case "TEMP": cTempBlock.TempTags.Add(cItemTag); break;
                    case "STAT": cTempBlock.STATTags.Add(cItemTag); break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void BoolDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock,string usage,bool bIsInStruct)
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
                        if(!bIsInStruct)
                        {
                            string sItemName = itemName + "[" + IndexS[i] + "]";
                            CUDLTag cItemTemp = new CUDLTag();

                            cItemTemp.Name = sItemName;
                            cItemTemp.Datatype = EMDataType.Bool;

                            string sSymbel = sPar + "." + sItemName;
                            string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                            cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                            cItemTemp.Name = tempBlock.BlockAddress + sSymbel;

                            cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                            cItemTemp.Length = 1;

                            string sComment = CheckComment(nodedata);

                            if (sComment.Length > 1)
                                cItemTemp.Description = sComment;

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                        

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

                    if(!bIsInStruct)
                    {
                        CUDLTag cItemTemp = new CUDLTag();

                        cItemTemp.Datatype = EMDataType.Bool;

                        string sSymbel = sPar + "." + itemName;
                        string sAddress = "DBX" + m_fDataItemIndex.ToString("0.0");

                        cItemTemp.Address = sAddress;

                        cItemTemp.Address = tempBlock.BlockName + "." + sAddress;
                        cItemTemp.Name = tempBlock.BlockAddress + sSymbel;

                        cItemTemp.PLCMaker = EMPLCMaker.Siemens;

                        cItemTemp.Length = 1;

                        string sComment = CheckComment(nodedata);
                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }                    

                    m_fDataItemIndex = m_fDataItemIndex + 0.1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ByteDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }
                        

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

                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }                    

                    m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WordDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                        

                        m_fDataItemIndex = m_fDataItemIndex + 2;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }                   

                    m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DWordDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                       

                        m_fDataItemIndex = m_fDataItemIndex + 4;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }
                    
                    m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ANYDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                       
                        m_fDataItemIndex = m_fDataItemIndex + 10;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }                    

                    m_fDataItemIndex = m_fDataItemIndex + 10;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StringDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                        

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }
                    
                    m_fDataItemIndex = m_fDataItemIndex + length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
        {
            try
            {
                string sUDTtype = CheckItemDatatype(nodedata);

                int length = CheckUDTTagLength(sUDTtype);
                if (length == 0)
                    length = CheckFBTagLength(sUDTtype);

                if (length == 0)
                    length = 10;

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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                            if (CheckIsBlockType(sUDTtype))
                                m_dLocalBlocks.Add(tempBlock.BlockName + sSymbel, sUDTtype);

                            FindUDTSubTagS(sSymbel, tempBlock, m_fDataItemIndex, sUDTtype, usage, bIsInStruct);
                        }                       

                        m_fDataItemIndex = m_fDataItemIndex + length;
                    }
                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();
                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                        if (CheckIsBlockType(sUDTtype))
                            m_dLocalBlocks.Add(tempBlock.BlockName + sSymbel, sUDTtype);

                        FindUDTSubTagS(sSymbel, tempBlock, m_fDataItemIndex, sUDTtype, usage, bIsInStruct);
                    }                    

                    m_fDataItemIndex = m_fDataItemIndex + length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int CheckUDTTagLength (string sNodedata)
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
                        if (tempblock.BlockAddress == sNodedata)
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

        private void DateAndTimeDataItemAnalysis(string nodedata, string itemName, string sPar, CUDLBlock tempBlock, string usage, bool bIsInStruct)
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
                        if(!bIsInStruct)
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

                            AddToSubTagS(cItemTemp, tempBlock, usage);
                        }                        

                        m_fDataItemIndex = m_fDataItemIndex + 8;
                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();
                    if(!bIsInStruct)
                    {
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

                        AddToSubTagS(cItemTemp, tempBlock, usage);
                    }                   

                    m_fDataItemIndex = m_fDataItemIndex + 8;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTSubTagAnalysis(string sPar, CUDLBlock tempBlock, double udtAddress, CUDLUDT tempUDT, string sUsage, bool bIsInStruct)
        {
            try
            {
                foreach (CUDLTag tempTag in tempUDT.MemTags)
                {
                    string tagName = tempTag.Name;
                    string tagAddress = tempTag.Address;
                    string tagDescri = tempTag.Description;

                    if (tagAddress.Contains("DBX") || tagAddress.Contains("DBW") || tagAddress.Contains("DBD") || tagAddress.Contains("DBB"))
                    {
                        int Ipos = tagAddress.IndexOf(".");
                        tagAddress = tagAddress.Substring(Ipos + 1);

                        tagAddress = MakeNewSubTagAddress(tagAddress, udtAddress);

                        tagAddress = tempBlock.BlockName + "." + tagAddress;
                    }
                    else
                    {
                        int Ipos = tagAddress.IndexOf(".");
                        tagAddress = tagAddress.Substring(Ipos + 1);

                        string sTemp = sPar.Substring(sPar.IndexOf("."));

                        tagAddress = tempBlock.BlockName + sTemp + "." + tagAddress;
                    }

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

                        AddToSubTagS(tempItemTag, tempBlock, sUsage);

                        FindUDTSubTagS(tagName, tempBlock, dTempAddress, tempItemTag.UDTType,sUsage,bIsInStruct);
                    }
                    else
                        AddToSubTagS(tempItemTag, tempBlock, sUsage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void BlockSubTagAnalysis(string sPar, CUDLBlock tempBlock, double udtAddress, CUDLBlock TagBlock, string sUsage, bool bIsInStruct)
        {
            try
            {
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.InputTags,sUsage,bIsInStruct);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.OutputTags,sUsage,bIsInStruct);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.InOutTags,sUsage,bIsInStruct);
                BlockUsageSubTagAnalysis(sPar, tempBlock, udtAddress, TagBlock.STATTags,sUsage,bIsInStruct);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void FindUDTSubTagS(string sPar, CUDLBlock tempBlock, double udtAddress, string udtType, string sUsage, bool bIsInStruct)
        {
            try
            {
                if (CheckIsUDTType(udtType))
                {
                    CUDLUDT targetUDT = GetUDT(udtType);
                    UDTSubTagAnalysis(sPar, tempBlock, udtAddress, targetUDT,sUsage,bIsInStruct);
                }
                else if (CheckIsBlockType(udtType))
                {
                    CUDLBlock targetBlock = GetBlock(udtType);
                    BlockSubTagAnalysis(sPar, tempBlock, udtAddress, targetBlock,sUsage,bIsInStruct);
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
                if (m_dicSystemFunctS.ContainsKey(sNodedata))
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
                            if (tempBlock.BlockName == sNodedata)
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

                if (OldAddress.Contains("DBX"))
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
                    dTempAddress = dTempAddress + TagGlobAddress;

                    sTemp = OldAddress.Remove(iPos + 3);

                    if (isBoolType)
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

        private void BlockUsageSubTagAnalysis(string sPar, CUDLBlock tempBlock, double udtAddress, List<CUDLTag> tempListTagS, string sUsage, bool bIsInStruct)
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

                    if (tagAddress.Contains("DBX") || tagAddress.Contains("DBW") || tagAddress.Contains("DBD") || tagAddress.Contains("DBB"))
                    {
                        Ipos = tagAddress.IndexOf(".");
                        tagAddress = tagAddress.Substring(Ipos + 1);

                        tagAddress = MakeNewSubTagAddress(tagAddress, udtAddress);

                        tagAddress = tempBlock.BlockName + "." + tagAddress;
                    }
                    else
                    {
                        Ipos = tagAddress.IndexOf(".");
                        tagAddress = tagAddress.Substring(Ipos + 1);

                        string sTemp = sPar.Substring(sPar.IndexOf("."));

                        tagAddress = tempBlock.BlockName + sTemp + "." + tagAddress;
                    }

                    tagName = sPar + tagName;

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

                        AddToSubTagS(tempItemTag, tempBlock, sUsage);

                        FindUDTSubTagS(tagName, tempBlock, dTempAddress, tempItemTag.UDTType,sUsage,bIsInStruct);
                    }
                    else
                        AddToSubTagS(tempItemTag, tempBlock, sUsage);
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
