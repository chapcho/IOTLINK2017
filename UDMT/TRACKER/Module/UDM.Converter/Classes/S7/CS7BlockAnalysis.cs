using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7BlockAnalysis
    {
        // Create by Qin Shiming at 2015.06.25
        // Frist edit at 2015.06.29 by Qin Shiming
        // Second edit at 2015.07.05 by Qin Shiming

        #region MemberVariables

        //protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;
        protected Dictionary<string, CS7UDT> m_dUDTDic = null;
        protected Dictionary<string, CS7DataBlock> m_dDBDic = null;
        protected Dictionary<string, CS7Block> m_dBlockDic = null;

        protected CS7STLAnalysis m_cLogicAnalysis = null;

        protected CS7Block m_cTempBlock = null;
        protected double m_fDataItemIndex = 0.0;
        protected int m_iNetworkCount = 0;
        protected string m_sBlockSymbol = string.Empty;
        protected string m_sBlockAddress = string.Empty;
        protected string m_sChannel = "[CH_DV]";

        #endregion

        #region Initialze/Dispose

        public CS7BlockAnalysis(CTagS AddressTags)
        {
            //m_dSymbolTags = symbolTags;
            m_dAddressTags = AddressTags;
            m_dBlockDic = new Dictionary<string, CS7Block>();
        }

        #endregion

        #region Public Properites

        public Dictionary<string, CS7UDT> UDTDic
        {
            set { m_dUDTDic = value; }
        }
        public Dictionary<string, CS7DataBlock> DBDic
        {
            set { m_dDBDic = value; }
        }
        public Dictionary<string, CS7Block> BlockDic
        {
            get { return m_dBlockDic; }
        }
        public CS7STLAnalysis LogicAnalysis
        {
            set { m_cLogicAnalysis = value; }
        }
        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }
        #endregion

        #region Public Methods

        public void FunctionAnalysis(List<string> sfile)
        {

            try
            {
                m_fDataItemIndex = 0.0;
                m_iNetworkCount = 0;

                string sBlockName = string.Empty;
                int count = sfile.Count;
                for (int i = 0; i < count; i++)
                {
                    if (sfile[i].StartsWith("FUNCTION_BLOCK "))
                    {
                        sBlockName = FindFBName(sfile[i]);
                        m_cTempBlock = new CS7Block(sBlockName);
                        m_cTempBlock.BlockType = EMS7BlockType.FB;
                        BlockInforMapping(sBlockName);
                    }
                    else if (sfile[i].StartsWith("FUNCTION "))
                    {
                        sBlockName = FindFCName(sfile[i]);
                        m_cTempBlock = new CS7Block(sBlockName);
                        m_cTempBlock.BlockType = EMS7BlockType.FC;
                        BlockInforMapping(sBlockName);
                    }
                    else if (sfile[i].StartsWith("ORGANIZATION_BLOCK"))
                    {
                        sBlockName = FindOBName(sfile[i]);
                        m_cTempBlock = new CS7Block(sBlockName);
                        m_cTempBlock.BlockType = EMS7BlockType.OB;
                        BlockInforMapping(sBlockName);
                    }
                    else if (sfile[i].StartsWith("TITLE ="))
                    {
                        string sTitle = sfile[i];
                        int j = i + 1;
                        while (!sfile[j].StartsWith("VERSION :"))
                        {
                            sTitle = sTitle + sfile[j];
                            j++;
                        }

                        sTitle = FindFunctionComment(sTitle);

                        m_cTempBlock.BlockComment = sTitle;
                    }
                    else if (sfile[i].StartsWith("VAR"))
                    {
                        List<string> sTagPart = new List<string>();
                        int j = i;

                        while (sfile[j] != "BEGIN")
                        {
                            sTagPart.Add(sfile[j]);
                            j++;
                        }
                        i = j;

                        FunctionTagAnalysis(sTagPart);
                    }
                    else if (sfile[i] == "NETWORK")
                    {
                        List<string> sLogicPart = new List<string>();
                        int j = i;
                        while (sfile[j] != "END_FUNCTION_BLOCK" && sfile[j] != "END_FUNCTION" && sfile[j] != "END_ORGANIZATION_BLOCK")
                        {
                            sLogicPart.Add(sfile[j]);
                            j++;
                        }
                        i = j;

                        FunctionLogicAnalysis(sLogicPart);
                    }
                }

                int iTemp = Convert.ToInt32(m_fDataItemIndex);
                double fTemp = m_fDataItemIndex - iTemp;

                if (fTemp > 0.00001)
                {
                    iTemp = iTemp + 1;
                }

                m_cTempBlock.BlockTagLength = iTemp;

                BlockDic.Add(sBlockName, m_cTempBlock);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void FunctionTagAnalysis(List<string> sTagPart)
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

                        VarTagAnalysis(varPart, usage);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void FunctionLogicAnalysis(List<string> sLogicPart)
        {
            try
            {
                int iCount = sLogicPart.Count;

                for (int i = 0; i < iCount; i++)
                {
                    if (sLogicPart[i] == "NETWORK")
                    {
                        List<string> NetWorkPart = new List<string>();
                        NetWorkPart.Add(sLogicPart[i]);

                        int j = i + 1;
                        while (sLogicPart[j] != "NETWORK")
                        {
                            NetWorkPart.Add(sLogicPart[j]);
                            j++;

                            if (j == sLogicPart.Count)
                                break;
                        }
                        i = j - 1;

                        NetWorkAnalysis(NetWorkPart);

                        m_iNetworkCount = m_iNetworkCount + 1;
                    }
                }
                if (m_cLogicAnalysis.JumpDic.Count > 0)
                {
                    m_cTempBlock.JumpLabelS = new CStepS();
                    foreach (string labelkey in m_cLogicAnalysis.JumpDic.Keys)
                    {
                        m_cTempBlock.JumpLabelS.Add(labelkey, m_cLogicAnalysis.JumpDic[labelkey]);
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
                    nodedata = nodedata.Remove(nodedata.IndexOf(":"));

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

        private void NetWorkAnalysis(List<string> sNetwork)
        {
            try
            {
                m_cLogicAnalysis.InternalTags = m_cTempBlock.TotalInternalTags;
                m_cLogicAnalysis.NewNetworkAnalysis(sNetwork, m_cTempBlock.BlockName, m_iNetworkCount + 1);
                //m_cLogicAnalysis.NetworkAnalysis(sNetwork, m_cTempBlock.TotalInternalTags, m_cTempBlock.BlockName, m_iNetworkCount);
                m_cTempBlock.InternalLogic.Add(m_iNetworkCount.ToString(), m_cLogicAnalysis.TempStep);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void BlockInforMapping(string nodedata)
        {
            try
            {
                if (m_dAddressTags.ContainsKey(nodedata))
                {
                    m_cTempBlock.BlockAddress = nodedata;
                    m_cTempBlock.BlockSymbol = m_dAddressTags[nodedata].Name;
                    m_cTempBlock.BlockComment = m_dAddressTags[nodedata].Description;

                    m_sBlockAddress = nodedata;
                    m_sBlockSymbol = m_dAddressTags[nodedata].Name;
                }
                else
                    m_cTempBlock.BlockAddress = nodedata;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void VarTagAnalysis(List<string> sVarPart, string sUsage)
        {
            try
            {
                int iCount = sVarPart.Count;
                string sDataItemName = string.Empty;
                string sDataItemType = string.Empty;
                string sPar = m_sBlockSymbol;
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

                                StructAnalysis(sStructPart, sUsage, sTemp);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sStructPart, sUsage, sTemp);
                        }

                        sStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "INT": IntDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "BYTE": ByteDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "WORD": WordDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DWORD": DWordDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DINT": DintDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "REAL": RealDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "TIME": TimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "S5TIME": S5TimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DATE": DateDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "TIME_OF_DAY": TODDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "CHAR": CharDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StructAnalysis(List<string> sStructPart, string sUsage, string sPar)
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

                                StructAnalysis(sSubStructPart, sUsage, sTemp);
                            }
                        }
                        else
                        {
                            string sTemp = sPar + "." + sDataItemName;

                            StructAnalysis(sSubStructPart, sUsage, sTemp);
                        }

                        sSubStructPart.Clear();
                    }
                    else
                    {
                        switch (sDataItemType)
                        {
                            case "BOOL": BoolDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "INT": IntDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "BYTE": ByteDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "WORD": WordDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DWORD": DWordDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DINT": DintDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "REAL": RealDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "TIME": TimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "S5TIME": S5TimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "STRING": StringDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DATE": DateDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "TIME_OF_DAY": TODDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "DATE_AND_TIME": DateAndTimeDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "ANY": ANYDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                            case "CHAR": CharDataItemAnalysis(nodedata, sDataItemType, sUsage, sPar); break;

                            default: UDTDataItemAnalysis(nodedata, sDataItemName, sUsage, sPar); break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #region Supply Functions

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
                else if (nodedata.Contains("STRUCT"))
                {
                    sDatatype = "STRUCT";
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

        private void AddToSubTags(CTag cItemTag, string sSymbol, string usage)
        {
            try
            {
                switch (usage)
                {
                    case "INPUT": m_cTempBlock.InputTags.Add(sSymbol, cItemTag); break;
                    case "OUTPUT": m_cTempBlock.OutputTags.Add(sSymbol, cItemTag); break;
                    case "IN_OUT": m_cTempBlock.InOUtTags.Add(sSymbol, cItemTag); break;
                    case "TEMP": m_cTempBlock.TempTags.Add(sSymbol, cItemTag); break;
                    case "STAT": m_cTempBlock.StatTags.Add(sSymbol, cItemTag); break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int CheckUDTAndBlockLenght(string nodedata)
        {
            int iLenght = 0;
            try
            {
                if (CheckIsSymbol(nodedata))
                {
                    int itemp = nodedata.Length;

                    nodedata = nodedata.Remove(itemp - 1);
                    nodedata = nodedata.Substring(1);
                }

                if (m_dUDTDic.ContainsKey(nodedata))
                {
                    iLenght = m_dUDTDic[nodedata].DTLength;
                }
                else if (m_dBlockDic.ContainsKey(nodedata))
                {
                    iLenght = m_dBlockDic[nodedata].BlockTagLength;
                }
                else
                {
                    Console.WriteLine("There is a unKnow data type : {0}.", nodedata);
                    iLenght = 0;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iLenght;
        }

        #endregion

        #region DataItemAnalysis

        private void BoolDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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
                        //cItemTemp.Address = sSymbel;


                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;  

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol+sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel+ sTemp1+"[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);
                        
                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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
                    //cItemTemp.Address = sSymbel;
                                      

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 0.1;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ByteDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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
                    cItemTemp.DataType = EMDataType.Byte;

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;                    

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 1;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WordDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 2;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void IntDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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
                       
                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;                      

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 2;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DWordDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;
       
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 4;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DintDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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
  
                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void RealDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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
                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 4;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ANYDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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
                        
                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 10;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void TimeDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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
                    cItemTemp.Size = 2;

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 4;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void S5TimeDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 2;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void StringDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + length;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
        {
            try
            {
                string sUDTtype = CheckItemDatatype(nodedata);

                int length = 0;

                if (sUDTtype.StartsWith("SF"))
                {
                    length = 20;
                }
                else
                    length = CheckUDTAndBlockLenght(sUDTtype);

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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;


                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + length;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DateDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;
                   
                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 2;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void TODDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                       // cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;

                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 4;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void DateAndTimeDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);

                        if (usage != "TEMP")
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

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;
  
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 8;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CharDataItemAnalysis(string nodedata, string itemName, string usage, string sPar)
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

                        string sSymbel = sPar + "." + sItemName;
                        //cItemTemp.Address = sSymbel;

                        string sComment = CheckComment(nodedata);

                        if (sComment.Length > 1)
                            cItemTemp.Description = sComment;

                        int n = sSymbel.IndexOf(".");
                        string sTemp = sSymbel.Substring(n);

                        cItemTemp.Name = m_sBlockSymbol + sSymbel;
                        cItemTemp.Size = 1;
                        string sTemp1 = m_sBlockAddress + sTemp;
                        cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                        m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                        AddToSubTags(cItemTemp, sTemp, usage);

                        m_dAddressTags.Add(sTemp1, cItemTemp);
                        
                        if (usage != "TEMP")
                            m_fDataItemIndex = m_fDataItemIndex + 1;

                    }

                }
                else
                {
                    CheckCarry();
                    MakeIndexEven();

                    CTag cItemTemp = new CTag();
                    //cItemTemp.Key = itemName;
                    cItemTemp.DataType = EMDataType.Char;

                    string sSymbel = sPar + "." + itemName;
                    //cItemTemp.Address = sSymbel;
     
                    string sComment = CheckComment(nodedata);

                    if (sComment.Length > 1)
                        cItemTemp.Description = sComment;

                    int n = sSymbel.IndexOf(".");
                    string sTemp = sSymbel.Substring(n);

                    cItemTemp.Name = m_sBlockSymbol + sSymbel;
                    cItemTemp.Size = 1;
                    string sTemp1 = m_sBlockAddress + sTemp;
                    cItemTemp.Key = m_sChannel + sTemp1 + "[1]";

                    m_cTempBlock.TotalInternalTags.Add(sTemp, cItemTemp);

                    AddToSubTags(cItemTemp, sTemp, usage);

                    m_dAddressTags.Add(sTemp1, cItemTemp);

                    if (usage != "TEMP")
                        m_fDataItemIndex = m_fDataItemIndex + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #endregion
    }
}
