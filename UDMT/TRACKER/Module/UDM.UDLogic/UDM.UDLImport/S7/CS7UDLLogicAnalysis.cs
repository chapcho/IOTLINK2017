using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.UDL;

namespace UDM.UDLImport
{
    public class CS7UDLLogicAnalysis
    {

        protected Dictionary<string, string> m_DicLabelJumpS = null;
        protected Dictionary<string, string> m_DicSubLogic = null;
        protected Dictionary<string, CS7LocalMem> m_DicLocalMem = null;
        protected Dictionary<string, CUDLBlock> m_dicSystemFunctS = null;

        protected int m_iConveterIndex = 0;
        protected string m_sBlockName = string.Empty;
        protected int m_iLogicIndex = 0;
        protected Dictionary<string,CUDLBlock> m_lstBlockList = null;
        protected List<string> m_lstLabelS = null;
        protected List<string> m_lstProtectedFBList = null;
        protected CUDLBlock m_cTempBlock = null;
        protected Dictionary<string, string> m_dicLocalBlocks = null;

        protected CS7StateWord m_cS7StateWord = new CS7StateWord();
        protected string m_sPrevTimerCounter = string.Empty;

        #region Instruction

        protected Dictionary<string, CInstruction> m_DicInstructionS = null;

        protected List<string> m_lstTimerList = new List<string>() { "FR", "SF", "SE", "SP", "SD", "SS", };
        protected List<string> m_lstCounterList = new List<string>() { "FR", "CU", "CD" };
        protected List<string> m_lstConvertorList = new List<string>() { "BTI", "ITB", "BTD", "ITD", "DTB", "DTR", "INVI", "INVD", "NEGI", "NEGD", "NEGR", "CAW", "CAD", "RND", "TRUNC", "TRUN", "RND+", "RND-" };
        protected List<string> m_lstDualComputerList = new List<string>() { "+I", "-I", "*I", "/I", "+","+D", "-D", "*D", "/D", "MOD", "+R", "-R", "*R", "/R" };
        protected List<string> m_lstSingleComputerList = new List<string>() { "ABS", "SQR", "SQRT", "EXP", "LN", "SIN", "COS", "TAN", "ASIN", "ACOS", "ATAN" };
        protected List<string> m_lstDataBlockCommandList = new List<string>() { "OPN", "CDB" };
        protected List<string> m_lstProgramControllList = new List<string>() { "CALL", "CC", "UC"};
        protected List<string> m_lstLogicControlList = new List<string>() { "JU", "JL", "JC", "JCN", "JCB", "JNB", "JBI", "JNBI", "JO", "JOS", "JZ", "JN", "JP", "JM", "JPZ", "JMZ", "JUO", "LOOP" };
        protected List<string> m_lstCompareList = new List<string>() { "==I", "<>I", ">I", "<I", ">=I", "<=I", "==D", "<>D", ">D", "<D", ">=D", "<=D", "==R", "<>R", ">R", "<R", ">=R", "<=R", };
        protected List<string> m_lstCyclicShiftList = new List<string>() { "SSI", "SSD", "SLW", "SRW", "SLD", "SRD", "RLD", "RRD", "RLDA", "RRDA" };
        protected List<string> m_lstWordLogicList = new List<string>() { "AW", "OW", "XOW", "AD", "OD", "XOD" };
        protected List<string> m_lstAccumList = new List<string> { "INC", "DEC", "+AR1", "+AR2"};

        protected List<string> m_lstSimpleCommandType = new List<string> { "TAK", "PUSH","CAR", "POP", "ENT", "LEAVE", "CDB", "MCRA", "MCRD", "MCR(", ")MCR", "BE", "BEC", "BEU","NOT" };
        protected List<string> m_lstNonConvertorList = new List<string> { "NOP", "SET", "SAVE", "CLR", "BLD"};

        protected List<string> m_lstPartStart = new List<string> { "A(", "AN(", "O(", "ON(" };
        protected List<string> m_lstNormalCoilS = new List<string> { "=", "S", "R" };
        protected List<string> m_lstS7FixedAddress = new List<string> { "DBLG", "DBNO", "DILG", "DINO", "STW", "AR1", "AR2", "BR", "OV", "OS", "RLO", "STA", "OR", "CC1", "CC0", "ACCU1", "ACCU2" };
        protected List<string> m_lstNonAddressCommand = new List<string> { "LAR1", "TAR1", "LAR2", "TAR2","TAK","PUSH","POP","ENT","LEAVE", "BE","BEC","BEU","NOT"};
        protected List<string> m_lstAddressRegisterCommand = new List<string> { "LAR1", "TAR1", "LAR2", "TAR2" };

        protected List<string> m_lstCoilCommand = null;
        protected List<string> m_lstContactCommand = null;
        protected List<string> m_lstValueCommand = null;
        #endregion

        #region Intialize/Dispose

        public CS7UDLLogicAnalysis(Dictionary<string,CInstruction> insDic)
        {
            m_lstProtectedFBList = new List<string>();
            m_DicInstructionS = insDic;

            m_lstCoilCommand = new List<string>();
            m_lstContactCommand = new List<string>();
            m_lstValueCommand = new List<string>();

            m_lstCoilCommand.AddRange(m_lstTimerList);
            m_lstCoilCommand.AddRange(m_lstCounterList);
            m_lstCoilCommand.AddRange(m_lstConvertorList);
            m_lstCoilCommand.AddRange(m_lstDualComputerList);
            m_lstCoilCommand.AddRange(m_lstSingleComputerList);
            m_lstCoilCommand.AddRange(m_lstProgramControllList);
            m_lstCoilCommand.AddRange(m_lstLogicControlList);
            m_lstCoilCommand.AddRange(m_lstCyclicShiftList);
            m_lstCoilCommand.AddRange(m_lstAccumList);
            m_lstCoilCommand.AddRange(m_lstWordLogicList);
            m_lstCoilCommand.AddRange(m_lstNormalCoilS);


            m_lstContactCommand.AddRange(m_lstCompareList);
            m_lstContactCommand.Add("A");
            m_lstContactCommand.Add("AN");
            m_lstContactCommand.Add("O");
            m_lstContactCommand.Add("ON");
            m_lstContactCommand.Add("X");
            m_lstContactCommand.Add("XN");

            m_lstValueCommand.AddRange(m_lstCompareList);
            m_lstValueCommand.AddRange(m_lstConvertorList);
            m_lstValueCommand.AddRange(m_lstDualComputerList);
            m_lstValueCommand.AddRange(m_lstSingleComputerList);
            m_lstValueCommand.AddRange(m_lstCyclicShiftList);
            m_lstValueCommand.AddRange(m_lstAccumList);
            m_lstValueCommand.AddRange(m_lstWordLogicList);
        }

        #endregion

        #region Public Properties

        public Dictionary<string,string> LabelJumpDic
        {
            get { return m_DicLabelJumpS; }
            set { m_DicLabelJumpS = value; }
        }
        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }
        public string BlockName
        {
            get { return m_sBlockName; }
            set { m_sBlockName = value; }
        }

        public Dictionary<string, CUDLBlock> BlockList
        {
            get { return m_lstBlockList; }
            set { m_lstBlockList = value; }
        }

        public int LogicIndex
        {
            get { return m_iLogicIndex; }
            set { m_iLogicIndex = value; }
        }

        public Dictionary<string, CUDLBlock> SystemFunctionS
        {
            get { return m_dicSystemFunctS; }
            set { m_dicSystemFunctS = value; }
        }

        #endregion

        #region Public methods

        public void NewBlockSetting(string BlockName,CUDLBlock tempBlock,Dictionary<string,string> localBlcokS)
        {
            m_sBlockName = BlockName;
            m_DicLabelJumpS = new Dictionary<string, string>();
            m_cTempBlock = tempBlock;
            m_dicLocalBlocks = localBlcokS;
        }

        public CUDLLogic NetworkAnalysisi(List<string> filePart, int LogicIndex)
        {
            CUDLLogic tempLogic = new CUDLLogic();

            m_cS7StateWord.ResetStateWord();

            try
            {
                filePart = FilePartEdit(filePart);

                if(m_sBlockName == "FC160")
                {

                }

                m_DicSubLogic = new Dictionary<string, string>();
                m_DicLocalMem = new Dictionary<string, CS7LocalMem>();
                m_iConveterIndex = 0;
                tempLogic.StepIndex = LogicIndex;

                m_lstLabelS = new List<string>();

                string sLogic = string.Empty;

                int iCount = filePart.Count;
                int iUpDownConterStartPoint = 0;
                string sUpDownCounterAddress = string.Empty;
 
                if(CheckHaveUpDownCounter(filePart,0))
                {
                    int iTemp=0;
                    sUpDownCounterAddress = CheckUpDownCounterAddress(filePart,0,ref iTemp);
                    iUpDownConterStartPoint = CheckCountUpDownStartPos(filePart,0,iTemp);
                }

                for(int i =0;i<iCount ;i++)
                {
                    string sNodedata = filePart[i];

                    string sSubLogic = string.Empty;

                    if(sNodedata.Contains(": "))
                    {
                        int iPos = sNodedata.IndexOf(": ");
                        string sLabelName = sNodedata.Remove(iPos);
                        sNodedata = sNodedata.Substring(iPos + 2);

                        string sLabelLogic = string.Empty;

                        m_lstLabelS.Add(sLabelName);
                        m_DicLabelJumpS.Add(sLabelName, sLabelLogic);
                    }

                    sNodedata = NodedataEdit(sNodedata);
                    string sLogicType = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);

                    if(sUpDownCounterAddress!=string.Empty && iUpDownConterStartPoint ==i)
                    {
                        sSubLogic = CTUDCounterConverter(filePart, i);
                        sLogic = sLogic + sSubLogic;
                    }
                    else if(m_lstPartStart.Contains(sLogicType))
                    {
                        sSubLogic = LocalPartAnalysis(filePart, i);

                        if (sLogicType == "O(" || sLogicType == "ON(")
                        {
                            if (sLogic == "")
                                sLogic = "[" + sSubLogic;
                            else if(CheckBracketMapped(sLogic))
                            {
                                sLogic = "[" + sLogic + "," + sSubLogic;
                            }
                            else if (sLogic.StartsWith("["))
                                sLogic = sLogic + "," + sSubLogic;
                            else
                                sLogic = "[" + sLogic + "," + sSubLogic;
                        }
                        else
                        {
                            sLogic = sLogic + sSubLogic;
                        }
                    }
                    else if(sLogicType ==")")
                    {

                    }
                    else
                    {                      
                        if(m_lstSimpleCommandType.Contains(sLogicType))
                        {
                            sSubLogic = SimpleCommandConverter(sNodedata);
                            sLogic = sLogic + sSubLogic;
                        }
                        else if (sAddress == ""&&!m_lstNonAddressCommand.Contains(sLogicType)&&!m_lstValueCommand.Contains(sLogicType))
                        {
                            if (sLogicType == "O" || sLogicType == "ON")
                            {
                                if (sLogic == "")
                                    sLogic = "[";
                                else if (sLogic.StartsWith("["))
                                {
                                    if(CheckBracketMapped(sLogic))
                                    {
                                        sLogic = "[" + sLogic + ",";
                                    }
                                    else
                                        sLogic = sLogic + ",";
                                }                                    
                                else
                                    sLogic = "[" + sLogic + ",";
                            }
                            else
                                Console.WriteLine("There is a new type command. Command is {0}", sLogicType);
                        }                        
                        else if(CheckIsLocalMemAdd(sAddress))
                        {
                            if(sLogicType == "=")
                            {
                                if (!CheckBracketMapped(sLogic))
                                    sLogic = sLogic + "]";

                                string stempLocal = LocalMemLogicConverter(sAddress, sLogic);

                                sLogic = "**" + stempLocal + "**";
                            }
                            else if(sLogicType =="A")
                            {
                                sAddress = GetLastLocalMemroyName(sAddress);

                                LocalStartLogicConverter(sAddress, filePart, i);
                            }
                        }
                        else
                        {
                            sSubLogic = CommandAnalysis(filePart, i);

                            if (sLogicType == "O" || sLogicType == "ON")
                            {
                                if (sLogic == "")
                                    sLogic = "[" + sSubLogic;
                                else if(CheckBracketMapped(sLogic))
                                {
                                    sLogic = "[" + sLogic + "," + sSubLogic;
                                }
                                else if (sLogic.StartsWith("["))
                                    sLogic = sLogic + "," + sSubLogic;
                                else
                                    sLogic = "[" + sLogic + "," + sSubLogic;
                            }
                            else if(m_lstNormalCoilS.Contains(sLogicType))
                            {
                                if (!CheckBracketMapped(sLogic))
                                    sLogic = sLogic + "]";

                                sLogic = sLogic + sSubLogic;
                            }
                            else
                            {
                                sLogic = sLogic + sSubLogic;
                            }
                        }   
                    }


                    if (i < m_iConveterIndex)
                        i = m_iConveterIndex;
                    else
                        m_iConveterIndex = i;
                }

                if (sLogic.Contains("**"))
                    sLogic = FinalLogicEditer(sLogic);

                sLogic = UDLLogicEditter(sLogic);

                tempLogic.Logic = sLogic;

                if(m_DicSubLogic.Count>0)
                {
                    foreach(string stemp in m_DicSubLogic.Keys)
                    {
                        tempLogic.SubLogicS.Add(stemp, m_DicSubLogic[stemp]);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempLogic;
        }

        #endregion

        #region Private Methods     
        
        private string FinalLogicEditer(string sLogic)
        {
            string FinalLogic = string.Empty;

            try
            {
                int iPos = sLogic.IndexOf("**");
                string sTemp = sLogic.Substring(iPos);
                string slocalMemName = LogicLocalNameCut(sTemp);

                int localNameLenght = slocalMemName.Length;

                sTemp = sLogic.Remove(iPos);
                if (sLogic.Length > iPos + localNameLenght + 4)
                {
                    sLogic = sLogic.Substring(iPos + localNameLenght + 4);
                    while (sLogic.Contains("**"))
                        sLogic = FinalLogicEditer(sLogic);

                    FinalLogic = sTemp + StartLocalMemLogciConnect(slocalMemName) + sLogic;
                }
                else
                    FinalLogic = sTemp + StartLocalMemLogciConnect(slocalMemName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return FinalLogic;
        }

        #region Support FunctionS          

        private string NodedataEdit(string nodedata)
        {
            try
            {
                if (nodedata.Length > 1)
                {
                    while (nodedata[0] == ' ' || nodedata[0] == '\t')
                    {
                        if (nodedata.Length > 1)
                            nodedata = nodedata.Substring(1);
                        else
                            nodedata = "";
                    }

                    while (nodedata[nodedata.Length - 1] == ' ' || nodedata[nodedata.Length - 1] == '\t')
                        nodedata = nodedata.Remove(nodedata.Length - 1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }               

        #region Logic SupportFunctionS

        private bool CheckBracketMapped(string nodedata)
        {
            bool bIsMapped = false;

            try
            {
                int iCount = nodedata.Length;
                int iLevelCount = 0;

                for (int i = 0; i < iCount; i++)
                {
                    if (nodedata[i] == '[')
                        iLevelCount = iLevelCount + 1;
                    else if (nodedata[i] == ']')
                        iLevelCount = iLevelCount - 1;
                }

                if (iLevelCount == 0)
                    bIsMapped = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bIsMapped;
        }

        private List<string> FilePartEdit(List<string> FilePart)
        {
            List<string> editedCode = new List<string>();
            try
            {
                int count = FilePart.Count;

                for (int i = 1; i < count; i++)
                {
                    string sNodedata = FilePart[i];

                    if (sNodedata.StartsWith("TITLE ="))
                    {
                        sNodedata = string.Empty;
                    }
                    else if (sNodedata.StartsWith("      "))
                    {
                        sNodedata = sNodedata.Substring(6);

                    }
                    else if (sNodedata.StartsWith("//"))
                    {
                        sNodedata = string.Empty;
                    }
                    else if (sNodedata.Contains(": "))
                    {
                        if (CheckIsSytemJumpLabel(sNodedata))
                        {
                            sNodedata = sNodedata.Substring(6);
                        }
                    }
                    else if (sNodedata == "")
                    {

                    }
                    else
                    {
                        Console.WriteLine("There is a new type nodedata : {0}", sNodedata);
                        sNodedata = string.Empty;
                    }


                    if (sNodedata.Contains("A     BR;") && i > 5)
                        sNodedata = string.Empty;
                    else if (sNodedata.Contains("AN    OV;") && i > 5)
                        sNodedata = string.Empty;

                    if (sNodedata != "")
                    {
                        if (sNodedata.Contains("//"))
                        {
                            int iPos = sNodedata.IndexOf("//");
                            sNodedata = sNodedata.Remove(iPos);
                        }

                        string sInstu = string.Empty;
                        string sAddress = string.Empty;

                        sInstu = LogicTypeCheck(sNodedata);
                        sAddress = FindAddress(sNodedata);

                        if (!m_lstNonConvertorList.Contains(sInstu) && !m_lstLogicControlList.Contains(sInstu))
                        {
                            editedCode.Add(sNodedata);
                        }
                        else if (m_lstLogicControlList.Contains(sInstu))
                        {
                            if (!CheckLabelIsSystemLabel(sAddress))
                            {
                                editedCode.Add(sNodedata);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return editedCode;
        }

        private bool CheckIsSytemJumpLabel(string sNodedata)
        {
            bool bSysJump = false;

            try
            {
                if (sNodedata.Contains(": "))
                {
                    int index = sNodedata.IndexOf(": ");

                    if (index == 4 && sNodedata[0] == '_')
                        bSysJump = true;
                    else if(sNodedata[0]=='M')
                    {
                        string sTemp = sNodedata.Remove(index);

                        bool isTure = true;
                        for(int i =1;i<sTemp.Length;i++)
                        {
                            if(!Char.IsDigit(sTemp[i]))
                            {
                                isTure = false;
                                break;
                            }
                        }

                        if (isTure)
                            bSysJump = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bSysJump;
        }

        private bool CheckLabelIsSystemLabel(string nodedata)
        {
            bool bSysJump = false;

            try
            {
                if (nodedata.StartsWith("_") && nodedata.Length == 4)
                    bSysJump = true;
                else if(nodedata.StartsWith("M"))
                {
                    bool isTure = true;
                    for (int i = 1; i < nodedata.Length; i++)
                    {
                        if (!Char.IsDigit(nodedata[i]))
                        {
                            isTure = false;
                            break;
                        }
                    }

                    if (isTure)
                        bSysJump = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bSysJump;
        }

        private string UDLLogicEditter(string sNodedata)
        {
            string sTempNodedata = string.Empty;

            try
            {
                int effective = 0;
                int iPartLevel = 0;
                string sBeforPart = string.Empty;
                bool isHavePart = false;
                int iPartStartPos = -1;
                int iPartEndPos = -1;

                for(int i =0;i<sNodedata.Length;i++)
                {
                    if (sNodedata[i] == '(')
                        effective = effective + 1;
                    else if (sNodedata[i] == ')')
                        effective = effective - 1;
                    else if(sNodedata[i]=='[')
                    {
                        if (effective == 0)
                        {
                            iPartLevel = iPartLevel + 1;
                            isHavePart = true;
                            if(iPartLevel ==1)
                            {
                                iPartStartPos = i;
                            }
                        }
                    }
                    else if(sNodedata[i]==']')
                    {
                        if(effective ==0)
                        {
                            iPartLevel = iPartLevel - 1;
                            if(iPartLevel ==0)
                            {
                                iPartEndPos = i;
                                sBeforPart = sNodedata.Remove(iPartStartPos);

                                string sLogicPart = sNodedata.Substring(iPartStartPos, iPartEndPos - iPartStartPos + 1);
                                sLogicPart = UDLLgoicPartEditter(sLogicPart);
                                string sTemp = string.Empty;

                                if (iPartEndPos < sNodedata.Length - 2)
                                {
                                    sTemp = sNodedata.Substring(iPartEndPos + 1);
                                    sTemp = UDLLogicEditter(sTemp);
                                }
                                sTempNodedata = sTempNodedata + sBeforPart + sLogicPart + sTemp;

                                break;
                            }                            
                        }
                    }
                }

                if (!isHavePart)
                    sTempNodedata = sNodedata;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sTempNodedata;
        }

        private string UDLLgoicPartEditter(string sNodedata)
        {
            string sTempNodedata = string.Empty;

            try
            {
                int effective = 0;
                bool isHaveComma = false;
                int iPartLevel = 0;
                int iCount = sNodedata.Length;
                sNodedata = sNodedata.Remove(iCount-1);
                sNodedata = sNodedata.Substring(1);
                int iPos = 0;

                for (int i = 0; i < sNodedata.Length; i++)
                {
                    if (sNodedata[i] == '(')
                        effective = effective + 1;
                    else if (sNodedata[i] == ')')
                        effective = effective - 1;
                    else if(sNodedata[i]=='[')
                    {
                        if (effective == 0)
                            iPartLevel = iPartLevel + 1;
                    }
                    else if(sNodedata[i]==']')
                    {
                        if (effective == 0)
                            iPartLevel = iPartLevel - 1;
                    }
                    else if(sNodedata[i] ==',')
                    {
                        if(effective ==0&& iPartLevel ==0)
                        {
                            isHaveComma = true;
                            
                            if(iPos == 0)
                            {
                                string sTemp = sNodedata.Remove(i);
                                sTemp = UDLLogicEditter(sTemp);

                                sTempNodedata = sTemp;
                                isHaveComma = true;
                                iPos = i;
                            }
                            else
                            {
                                string sTemp = sNodedata.Substring(iPos + 1, i - iPos - 1);
                                sTemp = UDLLogicEditter(sTemp);

                                sTempNodedata = sTempNodedata +","+ sTemp;
                                iPos = i;
                            }
                        }
                    }
                }

                if(isHaveComma)
                {
                    string sTemp = sNodedata.Substring(iPos + 1);
                    sTemp = UDLLogicEditter(sTemp);

                    sTempNodedata = "["+sTempNodedata + "," + sTemp+"]";
                }
                else 
                {
                    sTempNodedata = sNodedata;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sTempNodedata;
        }

        #endregion

        #region Command Support FunctionS

        private string LogicTypeCheck(string nodedata)
        {
            string sLogicType = string.Empty;
            try
            {
                nodedata = CutLabelName(nodedata);
                nodedata = NodedataEdit(nodedata);

                if (nodedata.IndexOf(" ") >= 1)
                {
                    int a = nodedata.IndexOf(" ");
                    sLogicType = nodedata.Remove(a);
                }
                else
                    sLogicType = nodedata;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogicType;
        }

        private string GeneralInstruCheck(string nodedata)
        {
            try
            {
                if (m_DicInstructionS.ContainsKey(nodedata))
                {
                    CInstruction tempInstruction = m_DicInstructionS[nodedata];

                    nodedata = tempInstruction.Instruction;
                }
                else
                {
                    Console.WriteLine("There is one comment cann't find general instruction : [{0}] .", nodedata);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private int CommandCount(string nodedata)
        {
            int iCount = 0;
            try
            {
                int tempCount = nodedata.Length;

                for (int i = 0; i < tempCount; i++)
                {
                    if (nodedata[i] == '(')
                        iCount = iCount + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iCount;
        }

        private string CheckFirstUDLLogicType(string sLogic)
        {
            string sLogicType = string.Empty;

            if (sLogic.Length > 4)
            {
                int iPos = sLogic.IndexOf("(");

                sLogicType = sLogic.Remove(iPos);
            }

            return sLogicType;
        }

        #endregion

        #region Address Support FunctionS

        private string FindAddress(string nodedata)
        {
            string sAddress = string.Empty;
            try
            {
                nodedata = CutLabelName(nodedata);
                nodedata = NodedataEdit(nodedata);

                if (nodedata.EndsWith(");"))
                {
                    int iPos = nodedata.IndexOf(");");

                    nodedata = nodedata.Remove(iPos);
                }

                if (nodedata.Contains(";"))
                {
                    int iPos = nodedata.IndexOf(";");

                    nodedata = nodedata.Remove(iPos);
                }

                if (nodedata[nodedata.Length - 1] == ',')
                {
                    nodedata = nodedata.Remove(nodedata.Length - 1);
                }

                int i = nodedata.IndexOf(" ");
                if (i > 0)
                    sAddress = nodedata.Substring(i);

                if (!sAddress.StartsWith("\""))
                    sAddress = sAddress.Replace(" ", "");

                NodedataEdit(sAddress);

                if (sAddress.EndsWith("("))
                {
                    i = sAddress.Length - 1;
                    sAddress = sAddress.Remove(i);
                }

                if (sAddress.StartsWith("#"))
                {
                    sAddress = m_sBlockName + "." + sAddress.Substring(1);
                }

                if (sAddress.Contains(".DIX") || sAddress.Contains(".DIB") || sAddress.Contains(".DIW") || sAddress.Contains(".DID"))
                {
                    int iPos = sAddress.IndexOf(".DI");
                    sAddress.Replace(".DI", ".DB");
                }
                else if (sAddress.StartsWith("DI"))
                {
                    if(sAddress!="DINO"&&sAddress!="DILG")
                        sAddress = "DB" + sAddress.Substring(2);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sAddress;
        }

        private string FindUdlLogicAddress(string nodedata)
        {
            string sAddress = string.Empty;

            try
            {
                int iPos = nodedata.IndexOf("(");

                sAddress = nodedata.Substring(iPos + 1);

                iPos = sAddress.IndexOf(")");

                sAddress = sAddress.Remove(iPos);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sAddress;
        }

        private bool CheckIsLocalMemAdd(string sNodedata)
        {
            bool IsLocalMem = false;
            try
            {
                if (sNodedata.StartsWith("L"))
                {
                    int iCount = sNodedata.Length;

                    int j = 0;
                    for (int i = 1; i < iCount; i++)
                    {
                        if (char.IsNumber(sNodedata[i]) || sNodedata[i] == '.')
                            j = j + 1;
                    }

                    if (j == iCount - 1)
                        IsLocalMem = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return IsLocalMem;
        }

        private bool CheckIsConstant(string nodedata)
        {
            bool bIsCons = false;
            try
            {
                if (nodedata.StartsWith("W#") || nodedata.StartsWith("DW#") || nodedata.StartsWith("S5T#") || nodedata.StartsWith("2#") || nodedata.StartsWith("B#") || nodedata.StartsWith("T#") || nodedata.StartsWith("L#") || nodedata.StartsWith("C#"))
                    bIsCons = true;
                else
                {
                    int j = 0;
                    for (int i = 0; i < nodedata.Length; i++)
                    {
                        if (i == 0)
                        {
                            if (char.IsNumber(nodedata[i]) && nodedata[i] != '-')
                            {
                                j = j + 1;
                            }
                        }
                        else
                        {
                            if (char.IsNumber(nodedata[i]))
                            {
                                j = j + 1;
                            }
                        }
                    }
                    if (j == nodedata.Length)
                        bIsCons = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsCons;
        }

        private string AddressEdittor(string nodedata)
        {
            try
            {
                if (nodedata.Length > 2)
                {
                    nodedata = NodedataEdit(nodedata);

                    if (nodedata[nodedata.Length - 1] == ';')
                        nodedata = nodedata.Remove(nodedata.Length - 1);
                    if (nodedata[nodedata.Length - 1] == ',')
                        nodedata = nodedata.Remove(nodedata.Length - 1);
                }

                nodedata = nodedata.Replace(" ", "");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string CutLabelName(string nodedata)
        {
            try
            {
                if (nodedata.Contains(": "))
                {
                    int iPos = nodedata.IndexOf(": ");
                    nodedata = nodedata.Substring(iPos + 2);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }       

        #endregion

        #region Local Memory & SubLogic Support FunctionS

        private string NewLocalMemoryNameEdit(string nodedata)
        {
            string sNewName = string.Empty;

            try
            {
                sNewName = nodedata;

                while (m_DicLocalMem.ContainsKey(sNewName + "_New"))
                {
                    sNewName = sNewName + "_New";
                }

                if (m_DicLocalMem.ContainsKey(sNewName))
                    sNewName = sNewName + "_New";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sNewName;
        }

        private string GetLastLocalMemroyName(string nodedata)
        {
            string sNewName = string.Empty;

            try
            {
                sNewName = nodedata;

                while (m_DicLocalMem.ContainsKey(sNewName + "_New"))
                {
                    sNewName = sNewName + "_New";
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sNewName;
        }

        private string SubLogicNameGenertor()
        {
            string sSubLogicName = string.Empty;

            try
            {
                int i = m_DicSubLogic.Count;

                sSubLogicName = "SubLogic_" + i.ToString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sSubLogicName;
        }

        private string StartLocalMemLogciConnect(string LocalName)
        {
            string LocalMemLogic = string.Empty;

            try
            {
                //LocalName = GetLastLocalMemroyName(LocalName);

                CS7LocalMem templocal = m_DicLocalMem[LocalName];

                if (!templocal.IsUsed)
                {
                    LocalMemLogic = templocal.SubLogic;

                    if (LocalMemLogic.Contains("**"))
                    {
                        int iPos = LocalMemLogic.IndexOf("**");
                        string sTemp = LocalMemLogic.Substring(iPos);
                        string slocalMemName = LogicLocalNameCut(sTemp);

                        int localNameLenght = slocalMemName.Length;

                        sTemp = LocalMemLogic.Remove(iPos);
                        if (LocalMemLogic.Length > iPos + localNameLenght + 4)
                        {
                            LocalMemLogic = sTemp + StartLocalMemLogciConnect(slocalMemName) + LocalMemLogic.Substring(iPos + localNameLenght + 4);
                        }
                        else
                            LocalMemLogic = sTemp + StartLocalMemLogciConnect(slocalMemName);
                    }

                    if (templocal.NextLogic.Count > 0)
                    {
                        LocalMemLogic = LocalMemLogic + "[";

                        for (int i = templocal.NextLogic.Count - 1; i >= 0; i--)
                        {
                            if (i > 0)
                            {
                                string sTempLocalLogic = string.Empty;

                                if (templocal.NextLogic[i].Contains("**"))
                                {
                                    int iPos = templocal.NextLogic[i].IndexOf("**");

                                    string sTemp = templocal.NextLogic[i];

                                    sTempLocalLogic = sTemp.Remove(iPos);
                                    sTemp = sTemp.Substring(iPos);

                                    string slocalMemName = LogicLocalNameCut(sTemp);

                                    iPos = slocalMemName.Length;
                                    if (sTemp.Length > iPos + 4)
                                    {
                                        sTemp = sTemp.Substring(iPos + 4);
                                        sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName) + sTemp;
                                    }
                                    else
                                        sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName);
                                }
                                else
                                {
                                    sTempLocalLogic = templocal.NextLogic[i];
                                }
                                LocalMemLogic = LocalMemLogic + sTempLocalLogic + ",";
                            }
                            else
                            {
                                string sTempLocalLogic = string.Empty;

                                if (templocal.NextLogic[i].Contains("**"))
                                {
                                    int iPos = templocal.NextLogic[i].IndexOf("**");

                                    string sTemp = templocal.NextLogic[i];

                                    sTempLocalLogic = sTemp.Remove(iPos);
                                    sTemp = sTemp.Substring(iPos);

                                    string slocalMemName = LogicLocalNameCut(sTemp);

                                    iPos = slocalMemName.Length;
                                    if (sTemp.Length > iPos + 4)
                                    {
                                        sTemp = sTemp.Substring(iPos + 4);
                                        sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName) + sTemp;
                                    }
                                    else
                                        sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName);
                                }
                                else
                                {
                                    sTempLocalLogic = templocal.NextLogic[i];
                                }
                                LocalMemLogic = LocalMemLogic + sTempLocalLogic;
                            }
                        }
                        LocalMemLogic = LocalMemLogic + "]";
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return LocalMemLogic;
        }

        private string SubLogicEdit(string sNodedata)
        {
            string sSubLogicName = string.Empty;

            try
            {
                sSubLogicName = SubLogicNameGenertor();

                string sLogic = sNodedata;

                m_DicSubLogic.Add(sSubLogicName, sLogic);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sSubLogicName;
        }

        private string LogicLocalNameCut(string sNodedata)
        {
            string LogicLocalName = string.Empty;

            try
            {
                int iPos = sNodedata.IndexOf("**");

                sNodedata = sNodedata.Substring(iPos + 2);
                iPos = sNodedata.IndexOf("**");

                LogicLocalName = sNodedata.Remove(iPos);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return LogicLocalName;
        }

        private void LocalStartLogicConverter(string Localname, List<string> filePart, int index)
        {
            try
            {
                CS7LocalMem tempLocal = null;
                Localname = GetLastLocalMemroyName(Localname);

                if (m_DicLocalMem.ContainsKey(Localname))
                {
                    tempLocal = m_DicLocalMem[Localname];

                    string sLogic = string.Empty;

                    int iCount = filePart.Count;
                    int iUpDownConterStartPoint = 0;
                    string sUpDownCounterAddress = string.Empty;

                    if (CheckHaveUpDownCounter(filePart, 0))
                    {
                        int iTemp = 0;
                        sUpDownCounterAddress = CheckUpDownCounterAddress(filePart, 0, ref iTemp);
                        iUpDownConterStartPoint = CheckCountUpDownStartPos(filePart, 0, iTemp);
                    }
                    

                    for (int i = index + 1; i < iCount; i++)
                    {
                        string sNodedata = filePart[i];


                        string sSubLogic = string.Empty;

                        if (sNodedata.Contains(": "))
                        {
                            int iPos = sNodedata.IndexOf(": ");
                            string sLabelName = sNodedata.Remove(iPos);
                            sNodedata = sNodedata.Substring(iPos + 2);

                            string sLabelLogic = string.Empty;

                            m_lstLabelS.Add(sLabelName);
                            m_DicLabelJumpS.Add(sLabelName, sLabelLogic);
                        }

                        sNodedata = NodedataEdit(sNodedata);
                        string sLogicType = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);

                        if (sUpDownCounterAddress != string.Empty && iUpDownConterStartPoint == i)
                        {
                            sSubLogic = CTUDCounterConverter(filePart, i);
                            sLogic = sLogic + sSubLogic;
                        }
                        else if (m_lstPartStart.Contains(sLogicType))
                        {
                            sSubLogic = LocalPartAnalysis(filePart, i);

                            if (sLogicType == "O(" || sLogicType == "ON(")
                            {
                                if (sLogic == "")
                                    sLogic = "[" + sSubLogic;
                                else if(CheckBracketMapped(sLogic))
                                    sLogic = "[" + sLogic + "," + sSubLogic;
                                else if (sLogic.StartsWith("["))
                                    sLogic = sLogic + "," + sSubLogic;
                                else
                                    sLogic = "[" + sLogic + "," + sSubLogic;
                            }
                            else
                            {
                                sLogic = sLogic + sSubLogic;
                            }
                        }
                        else
                        {

                            if (m_lstSimpleCommandType.Contains(sLogicType))
                            {
                                sSubLogic = SimpleCommandConverter(sNodedata);
                                sLogic = sLogic + sSubLogic;
                            }
                            else if (sAddress == "" && !m_lstNonAddressCommand.Contains(sLogicType)&&!m_lstValueCommand.Contains(sLogicType))
                            {
                                if (sLogicType == "O" || sLogicType == "ON")
                                {
                                    if (sLogic == "")
                                        sLogic = "[";
                                    else if (sLogic.StartsWith("["))
                                    {
                                        if (CheckBracketMapped(sLogic))
                                        {
                                            sLogic = "[" + sLogic + ",";
                                        }
                                        else
                                            sLogic = sLogic + ",";
                                    }
                                    else
                                        sLogic = "[" + sLogic + ",";
                                }
                                else if (sLogicType == ")")
                                { }
                                else
                                    Console.WriteLine("There is a new type command. Command is {0}", sLogicType);
                            }
                            else if (CheckIsLocalMemAdd(sAddress))
                            {
                                if (sLogicType == "=")
                                {
                                    if (!CheckBracketMapped(sLogic))
                                        sLogic = sLogic + "]";

                                    string stempLocal = LocalMemLogicConverter(sAddress, sLogic);

                                    sLogic = "**" + stempLocal + "**";
                                }
                                else if (sLogicType == "A")
                                {
                                    sAddress = GetLastLocalMemroyName(sAddress);

                                    LocalStartLogicConverter(sAddress, filePart, i);
                                }
                            }
                            else
                            {
                                sSubLogic = CommandAnalysis(filePart, i);

                                if (m_lstSimpleCommandType.Contains(sLogicType))
                                {
                                    sSubLogic = SimpleCommandConverter(sNodedata);
                                }
                                else if (sLogicType == "O" || sLogicType == "ON")
                                {
                                    if (sLogic == "")
                                        sLogic = "[" + sSubLogic;
                                    else if(CheckBracketMapped(sLogic))
                                        sLogic = "[" + sLogic + "," + sSubLogic;
                                    else if (sLogic.StartsWith("["))
                                        sLogic = sLogic + "," + sSubLogic;
                                    else
                                        sLogic = "[" + sLogic + "," + sSubLogic;
                                }
                                else if (m_lstNormalCoilS.Contains(sLogicType))
                                {
                                    if (!CheckBracketMapped(sLogic))
                                        sLogic = sLogic + "]";

                                    sLogic = sLogic + sSubLogic;
                                }
                                else
                                {
                                    sLogic = sLogic + sSubLogic;
                                }
                            }
                        }


                        if (i < m_iConveterIndex)
                            i = m_iConveterIndex;
                        else
                            m_iConveterIndex = i;
                    }

                    tempLocal.NextLogic.Add(sLogic);

                }
                else
                {
                    Console.WriteLine("There one new Local Memory Block Is {0}, Logic Index is {1}, Local memory name is {2}", m_sBlockName, m_iLogicIndex.ToString(), Localname);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string CommandSubLogicConvert(string sNodedata)
        {
            string sLogic = string.Empty;

            try
            {
                int iCommandCount = CommandCount(sNodedata);
                string sFirstLogicType = CheckFirstUDLLogicType(sNodedata);

                if (iCommandCount == 1 && sFirstLogicType == "XIC")
                {
                    sLogic = FindUdlLogicAddress(sNodedata);

                    if (CheckIsLocalMemAdd(sLogic))
                    {
                        sLogic = ConveterLocalMemToSubLogic(sLogic);
                    }
                }
                else
                {
                    sLogic = SubLogicEdit(sNodedata);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sLogic;
        }

        private string ConveterLocalMemToSubLogic(string sLocalMemName)
        {
            string sSubLogicName = string.Empty;

            try
            {
                string sLogic = string.Empty;

                sSubLogicName = SubLogicNameGenertor();

                sLocalMemName = GetLastLocalMemroyName(sLocalMemName);

                CS7LocalMem templocal = m_DicLocalMem[sLocalMemName];
                templocal.IsUsed = true;
                sLogic = templocal.SubLogic;

                if (sLogic.Contains("**"))
                {
                    int iPos = sLogic.IndexOf("**");
                    string sTemp = sLogic.Substring(iPos);
                    string slocalMemName = LogicLocalNameCut(sTemp);

                    int localNameLenght = slocalMemName.Length;

                    sTemp = sLogic.Remove(iPos);
                    if (sLogic.Length > iPos + localNameLenght + 4)
                    {
                        sLogic = sTemp + StartLocalMemLogciConnect(slocalMemName) + sLogic.Substring(iPos + localNameLenght + 4);
                    }
                    else
                        sLogic = sTemp + StartLocalMemLogciConnect(slocalMemName);
                }
                else if (CommandCount(sLogic) == 1 && templocal.NextLogic.Count == 0)
                {
                    sLogic = CommandSubLogicConvert(sLogic);
                    sSubLogicName = sLogic;

                    return sSubLogicName;
                }
                else if (templocal.NextLogic.Count > 0)
                {
                    sLogic = sLogic + "[";

                    for (int i = 0; i < templocal.NextLogic.Count; i++)
                    {
                        if (i < templocal.NextLogic.Count - 1)
                        {
                            string sTempLocalLogic = string.Empty;

                            if (templocal.NextLogic[i].Contains("**"))
                            {
                                int iPos = templocal.NextLogic[i].IndexOf("**");

                                string sTemp = templocal.NextLogic[i];

                                sTempLocalLogic = sTemp.Remove(iPos);
                                sTemp = sTemp.Substring(iPos);

                                string slocalMemName = LogicLocalNameCut(sTemp);

                                iPos = slocalMemName.Length;
                                if (sTemp.Length > iPos + 4)
                                {
                                    sTemp = sTemp.Substring(iPos + 4);
                                    sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName) + sTemp;
                                }
                                else
                                    sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName);
                            }
                            else
                            {
                                sTempLocalLogic = templocal.NextLogic[i];
                            }
                            sLogic = sLogic + sTempLocalLogic + ",";
                        }
                        else
                        {
                            string sTempLocalLogic = string.Empty;

                            if (templocal.NextLogic[i].Contains("**"))
                            {
                                int iPos = templocal.NextLogic[i].IndexOf("**");

                                string sTemp = templocal.NextLogic[i];

                                sTempLocalLogic = sTemp.Remove(iPos);
                                sTemp = sTemp.Substring(iPos);

                                string slocalMemName = LogicLocalNameCut(sTemp);

                                iPos = slocalMemName.Length;
                                if (sTemp.Length > iPos + 4)
                                {
                                    sTemp = sTemp.Substring(iPos + 4);
                                    sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName) + sTemp;
                                }
                                else
                                    sTempLocalLogic = sTempLocalLogic + StartLocalMemLogciConnect(slocalMemName);
                            }
                            else
                            {
                                sTempLocalLogic = templocal.NextLogic[i];
                            }
                            sLogic = sLogic + sTempLocalLogic;
                        }
                    }
                    sLogic = sLogic + "]";
                }

                m_DicSubLogic.Add(sSubLogicName, sLogic);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sSubLogicName;
        }

        #endregion
        /// <summary>
        /// Find FB, DB, and Call Label name
        /// </summary>
        /// <param name="sLogicAddress"></param>
        /// <returns></returns>
        #region Call Command Support FunctionS

        private string FindInsDBAddress(string sLogicAddress)
        {
            string sAddress = string.Empty;

            try
            {
                foreach (CUDLTag tempUDLTag in m_cTempBlock.InputTags)
                {
                    string tempAddress = tempUDLTag.Address;
                    int iPos = tempAddress.IndexOf(".");
                    tempAddress = tempAddress.Substring(iPos + 1);

                    if (sLogicAddress == tempAddress)
                    {
                        sAddress = tempUDLTag.Name;
                        break;
                    }
                }

                if (sAddress == string.Empty)
                {
                    foreach (CUDLTag tempUDLTag in m_cTempBlock.OutputTags)
                    {
                        string tempAddress = tempUDLTag.Address;
                        int iPos = tempAddress.IndexOf(".");
                        tempAddress = tempAddress.Substring(iPos + 1);

                        if (sLogicAddress == tempAddress)
                        {
                            sAddress = tempUDLTag.Name;
                            break;
                        }
                    }
                }

                if (sAddress == string.Empty)
                {
                    foreach (CUDLTag tempUDLTag in m_cTempBlock.InOutTags)
                    {
                        string tempAddress = tempUDLTag.Address;
                        int iPos = tempAddress.IndexOf(".");
                        tempAddress = tempAddress.Substring(iPos + 1);

                        if (sLogicAddress == tempAddress)
                        {
                            sAddress = tempUDLTag.Name;
                            break;
                        }
                    }
                }

                if (sAddress == string.Empty)
                {
                    foreach (CUDLTag tempUDLTag in m_cTempBlock.STATTags)
                    {
                        string tempAddress = tempUDLTag.Address;
                        int iPos = tempAddress.IndexOf(".");
                        tempAddress = tempAddress.Substring(iPos + 1);

                        if (sLogicAddress == tempAddress)
                        {
                            sAddress = tempUDLTag.Name;
                            break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sAddress;
        }

        private string FindCallFunctionName(string nodedata)
        {
            string sName = string.Empty;

            try
            {
                if (nodedata.Contains("("))
                {
                    string sTemp = nodedata.Substring(nodedata.IndexOf(" ") + 1);
                    sTemp = NodedataEdit(sTemp);
                    int iPos = sTemp.IndexOf("(");

                    sTemp = sTemp.Remove(iPos);

                    if (sTemp.Contains(","))
                    {
                        iPos = sTemp.IndexOf(",");
                        sName = sTemp.Remove(iPos);
                    }
                    else
                        sName = sTemp;
                }
                else if (nodedata.Contains(","))
                {
                    string sTemp = nodedata.Substring(nodedata.IndexOf(" "));
                    sTemp = NodedataEdit(sTemp);

                    int iPos = sTemp.IndexOf(",");

                    sName = sTemp.Remove(iPos);
                }
                else
                {
                    sName = FindAddress(nodedata);
                }

                if (sName.StartsWith("#"))
                    sName = m_sBlockName + "." + sName.Substring(1);

                sName = sName.Replace(" ", "");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private string FindCallDBName(string nodedata)
        {
            string sName = string.Empty;

            try
            {
                if (nodedata.Contains("("))
                {
                    string sTemp = nodedata.Substring(nodedata.IndexOf(" "));
                    sTemp = NodedataEdit(sTemp);
                    int iPos = sTemp.IndexOf("(");

                    sTemp = sTemp.Remove(iPos);

                    if (sTemp.Contains(","))
                    {
                        iPos = sTemp.IndexOf(",");
                        sName = sTemp.Substring(iPos + 1);
                    }
                }
                else if (nodedata.Contains(","))
                {
                    string sTemp = nodedata.Substring(nodedata.IndexOf(" "));
                    sTemp = NodedataEdit(sTemp);

                    int iPos = sTemp.IndexOf(",");

                    sName = sTemp.Substring(iPos + 1);
                }
                if (sName.EndsWith(";"))
                {
                    int iPos = sName.IndexOf(";");
                    sName = sName.Remove(iPos);
                }

                sName = sName.Replace(" ", "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private string FindCallLabelAddress(string nodedata)
        {
            string sName = string.Empty;

            try
            {
                int iPos = nodedata.IndexOf(":=");
                sName = nodedata.Substring(iPos + 2);

                sName = AddressEdittor(sName);
                if (sName.StartsWith("#"))
                {
                    sName = m_sBlockName + "." + sName.Substring(1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private string FindCallLabelName(string nodedata)
        {
            string sName = string.Empty;

            try
            {
                int iPos = nodedata.IndexOf(":=");
                sName = nodedata.Remove(iPos);

                sName = AddressEdittor(sName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sName;
        }

        private List<string> GetFBLabelList(string functionName)
        {
            List<string> LabelNameS = new List<string>();

            try
            {
                CUDLBlock tempBlock = GetCallBlock(functionName);

                GetVarLabelNameS(LabelNameS, tempBlock.InputTags);

                GetVarLabelNameS(LabelNameS, tempBlock.InOutTags);

                GetVarLabelNameS(LabelNameS, tempBlock.OutputTags);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return LabelNameS;
        }

        private CUDLBlock GetCallBlock(string sFunctionName)
        {
            CUDLBlock tempBlock = null;
            try
            {
                bool bIsFound = false;
                if (m_dicSystemFunctS.ContainsKey(sFunctionName))
                {
                    tempBlock = m_dicSystemFunctS[sFunctionName];
                    bIsFound = true;
                }

                if (!bIsFound)
                {
                    if (sFunctionName.Contains("."))
                    {
                        string sBlockName = string.Empty;
                        if (m_dicLocalBlocks.ContainsKey(sFunctionName))
                        {
                            sBlockName = m_dicLocalBlocks[sFunctionName];
                            tempBlock = GetCallBlock(sBlockName);
                            bIsFound = true;
                        }
                    }
                    else
                    {
                        if(m_lstBlockList.ContainsKey(sFunctionName))
                        {
                            tempBlock = m_lstBlockList[sFunctionName];
                            bIsFound = true;
                        }
                        else
                        {
                            foreach (CUDLBlock temp in m_lstBlockList.Values)
                            {
                                if (temp.BlockName == sFunctionName)
                                {
                                    tempBlock = temp;
                                    bIsFound = true;
                                    break;
                                }
                            }
                        }                        
                    }
                }

                if (!bIsFound)
                {
                    tempBlock = new CUDLBlock();
                    tempBlock.BlockName = sFunctionName;
                    tempBlock.BlockType = EMBlockType.FunctionBlock;

                    if(!m_lstProtectedFBList.Contains(sFunctionName))
                    {
                        m_lstProtectedFBList.Add(sFunctionName);
                        Console.WriteLine("This is a unKnow block. Block Name is [{0}]. Will return a Dummuy Block.", sFunctionName);
                    } 
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempBlock;
        }

        private void GetVarLabelNameS(List<string> labelS, List<CUDLTag> Var)
        {
            try
            {
                foreach (CUDLTag tempTag in Var)
                {
                    string sTemp = GetFBLabelNameWithoutFBName(tempTag);
                    labelS.Add(sTemp);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string GetFBLabelNameWithoutFBName(CUDLTag cTag)
        {
            string LabelName = string.Empty;

            try
            {
                string stemp = cTag.Name;
                int iPos = stemp.IndexOf(".");

                LabelName = stemp.Substring(iPos + 1);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return LabelName;
        }

        private string CallCommandLabelConnect(string sLogic, List<string> LabelS, Dictionary<string, string> CallLabels)
        {
            try
            {
                int iCount = LabelS.Count;

                if (iCount > 0)
                {
                    for (int i = 0; i < iCount; i++)
                    {
                        string label = LabelS[i];

                        if (CallLabels.ContainsKey(label))
                        {
                            string address = CallLabels[label];
                            if (CheckIsLocalMemAdd(address))
                            {
                                address = ConveterLocalMemToSubLogic(address);

                                sLogic = sLogic + address + ",";
                            }
                            else
                            {
                                sLogic = sLogic + address + ",";
                            }
                        }
                        else
                            sLogic = sLogic + ",";
                    }
                }
                else
                {
                    foreach (string key in CallLabels.Keys)
                    {
                        string address = CallLabels[key];

                        if (CheckIsLocalMemAdd(address))
                        {
                            address = ConveterLocalMemToSubLogic(address);

                            sLogic = sLogic + address + ",";
                        }
                        else
                        {
                            sLogic = sLogic + address + ",";
                        }
                    }
                }

                iCount = sLogic.LastIndexOf(",");

                if (iCount > 5)
                    sLogic = sLogic.Remove(iCount);

                sLogic = sLogic + ")";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sLogic;
        }

        #endregion
        /// <summary>
        /// Timer and Counter Support Functions
        /// Will help main convertor function to Convertor the Timer and Count Command
        /// About : Preset value, Reset, set Preset value...
        /// </summary>
        /// <param name="sFilePart"> STL Logic TextS</param>
        /// <param name="index"> Command Start index </param>
        /// <param name="sAddress"> Timer or Count address</param>
        /// <returns></returns>
        #region Timer Counter Support Functions

        private bool CheckIsHaveReset(List<string> sFilePart, int index, string sAddress)
        {
            bool bHave = false;

            try
            {
                int iCount = sFilePart.Count;

                for (int i = index ; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTCAddress = FindAddress(sNodedata);

                    if (slogictype == "R" && sAddress == sTCAddress)
                    {
                        bHave = true;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bHave;
        }

        private bool CheckIsHaveLoadTC(List<string> sFilePart, int index, string sAddress)
        {
            bool bHave = false;

            try
            {
                int iCount = sFilePart.Count;

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTCAddress = FindAddress(sNodedata);

                    if (slogictype == "L" && sAddress == sTCAddress)
                    {
                        bHave = true;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bHave;
        }

        private string GetTCLoadTarget(List<string> sFilePart, int index, string sAddress)
        {
            string sLoadTarget = string.Empty;

            try
            {
                int iCount = sFilePart.Count;

                for (int i = index ; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTCAddress = FindAddress(sNodedata);

                    if ((slogictype == "L" || slogictype == "LC") && sAddress == sTCAddress)
                    {
                        sNodedata = sFilePart[i + 1];
                        sNodedata = NodedataEdit(sNodedata);

                        sLoadTarget = FindAddress(sNodedata);
                        m_iConveterIndex = i + 1;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sLoadTarget;
        }

        private bool CheckIsHaveBLDLoadTC(List<string> sFilePart, int index, string sAddress)
        {
            bool bHave = false;

            try
            {
                int iCount = sFilePart.Count;

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTCAddress = FindAddress(sNodedata);

                    if (slogictype == "LC" && sAddress == sTCAddress)
                    {
                        bHave = true;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bHave;
        }

        private bool CheckNeedSubLogicReset(List<string> sFilePart, int index, string sAddress)
        {
            bool bNeed = true;

            try
            {
                int iCount = sFilePart.Count;

                int iContactCount = 0;

                for (int i = index ; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTagetAddress = FindAddress(sNodedata);

                    if (slogictype == "R" && sAddress == sTagetAddress)
                    {
                        break;
                    }
                    else
                    {
                        iContactCount = iContactCount + 1;
                    }
                }

                if (iContactCount < 2)
                    bNeed = false;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bNeed;
        }

        private bool CheckIsDiscreteReset(List<string> sFilePart, int index, string sAddress)
        {
            bool isDiscrete = false;

            try
            {
                int iCount = sFilePart.Count;
                int iOtherOutCount = 0;

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTagetAddress = FindAddress(sNodedata);

                    if (slogictype == "R" && sAddress == sTagetAddress)
                    {
                        break;
                    }
                    else if (slogictype == "R" || slogictype == "S" || slogictype == "=")
                    {
                        iOtherOutCount = iOtherOutCount + 1;
                    }
                }

                if (iOtherOutCount > 0)
                    isDiscrete = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isDiscrete;
        }

        private string GetResetAddress(List<string> sFilePart, int index, string sAddress)
        {
            string sResetAddress = string.Empty;
            try
            {
                int iCount = sFilePart.Count;

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sTagetAddress = FindAddress(sNodedata);

                    if (slogictype == "R" && sAddress == sTagetAddress)
                    {
                        sNodedata = sFilePart[i - 1];
                        sResetAddress = FindAddress(sNodedata);

                        m_iConveterIndex = i;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sResetAddress;
        }

        private bool CheckHaveUpDownCounter(List<string> sFilePart, int index)
        {
            bool isHaveCounter = false;

            try
            {
                int iCount = sFilePart.Count;
                bool bCountUp = false;
                bool bCountDown = false;

                string sCountUpAddress = string.Empty;
                string sCountDownAddress = string.Empty;
                bool bIsAfterCU = false;
                bool bIsHaveOtherCoil = false;

                for (int i = index ; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);
                    if (sLogicType == "CU")
                    {
                        bCountUp = true;
                        sCountUpAddress = sAddress;
                        bIsAfterCU = true;
                    }
                    else if (sLogicType == "CD")
                    {
                        if (!bIsHaveOtherCoil)
                        {
                            bCountDown = true;
                            sCountDownAddress = sAddress;
                        }
                        break;
                    }
                    else if (bIsAfterCU)
                    {
                        if (m_lstCoilCommand.Contains(sLogicType))
                        {
                            bIsHaveOtherCoil = true;
                        }
                    }
                }

                if ((bCountUp && bCountDown) && (sCountDownAddress == sCountUpAddress))
                    isHaveCounter = true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return isHaveCounter;
        }

        private string CheckUpDownCounterAddress(List<string> sFilePart, int index,ref int iCountPos)
        {
            string sCounterAddress = string.Empty;

            try
            {
                int iCount = sFilePart.Count;
                int iTempPos = 0;
                string sTempAddress = string.Empty;

                for(int i = index;i<iCount;i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);

                    if(sLogicType == "CU")
                    {
                        iTempPos = i;
                        sTempAddress = sAddress;
                    }
                    else if(sLogicType == "CD")
                    {
                        if (sTempAddress == sAddress)
                        {
                            break;
                        }
                        else
                        {
                            iTempPos = 0;
                            sTempAddress = string.Empty;
                        }
                    }
                }

                iCountPos = iTempPos;
                sCounterAddress = sTempAddress;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sCounterAddress;
        }

        private int CheckCountUpDownStartPos(List<string> sFilePart, int index, int CountPos)
        {
            int CTLogicStartPos = 0;

            try
            {
                int iStartPos = index;
                for (int i = index; i <= CountPos; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);

                    if (sLogicType == "=")
                        iStartPos = i + 1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return CTLogicStartPos;
        }

        private string GetTimeCountReset(List<string> sFilePart, int index, string sAddress)
        {
            string reset = string.Empty;
            try
            {
                if (CheckIsDiscreteReset(sFilePart, index, sAddress))
                {

                }
                else if (CheckNeedSubLogicReset(sFilePart, index, sAddress))
                {
                    reset = ResetSubLogicAnalysis(sFilePart, index, sAddress);
                }
                else
                {
                    reset = GetResetAddress(sFilePart, index, sAddress);

                    if (CheckIsLocalMemAdd(reset))
                    {
                        reset = GetLastLocalMemroyName(reset);
                        string sResetLocal = m_DicLocalMem[reset].SubLogic;
                        if (m_DicLocalMem[reset].NextLogic.Count == 0)
                        {
                            if (CommandCount(sResetLocal) == 1)
                            {
                                reset = FindUdlLogicAddress(sResetLocal);
                            }
                            else
                                reset = ConveterLocalMemToSubLogic(reset);
                        }
                        else
                            reset = ConveterLocalMemToSubLogic(reset);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return reset;
        }

        private string GetCountPreSet(List<string> sFilePart, int index, string sCountAddress, ref string PreSetValue)
        {
            string sLogic = string.Empty;
            try
            {
                int iCount = sFilePart.Count;

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);

                    if (sLogicType == "L")
                    {
                        string NextLine = sFilePart[i + 1];
                        NextLine = NodedataEdit(NextLine);

                        string sNextLogic = LogicTypeCheck(NextLine);
                        string sNextAddress = FindAddress(NextLine);

                        if (sNextLogic == "S" && sNextAddress == sCountAddress)
                        {
                            PreSetValue = sAddress;
                            m_iConveterIndex = i+1;

                            if (sLogic.StartsWith("["))
                                sLogic = sLogic + "]";

                            break;
                        }
                    }
                    else
                    {
                        string sSubLogic = CommandAnalysis(sFilePart, i);

                        if (sLogicType == "O" || sLogicType == "ON")
                        {
                            if (sLogic == "")
                                sLogic = "[" + sSubLogic;
                            else if (sLogic.StartsWith("["))
                                sLogic = sLogic + ", " + sSubLogic;
                            else
                                sLogic = "[" + sLogic + ", " + sSubLogic;
                        }
                        else
                        {
                            sLogic = sLogic + sSubLogic;
                        }
                    }
                }

                sLogic = CommandSubLogicConvert(sLogic);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }

        private bool CheckIsHaveSetCounter(List<string> sFilePart, int index, string sCountAddress)
        {
            bool isHave = false;

            int iCount = sFilePart.Count;

            for (int i = index; i < iCount; i++)
            {
                string sNodedata = sFilePart[i];
                sNodedata = NodedataEdit(sNodedata);

                string sLogicType = LogicTypeCheck(sNodedata);
                string sAddress = FindAddress(sNodedata);

                if (sLogicType == "S" && sAddress == sCountAddress)
                {
                    isHave = true;
                    break;
                }
            }

            return isHave;
        }

        private string ResetSubLogicAnalysis(List<string> sFilePart, int index, string sResetAddress)
        {
            string sSubLogicName = string.Empty;

            try
            {
                string sLogic = string.Empty;

                int iCount = sFilePart.Count;

                sSubLogicName = SubLogicNameGenertor();

                for (int i = index; i < iCount; i++)
                {
                    string sNodedata = sFilePart[i];

                    sNodedata = NodedataEdit(sNodedata);

                    string slogictype = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);

                    if (slogictype == "R" && sAddress == sResetAddress)
                    {
                        m_DicSubLogic.Add(sSubLogicName, sLogic);

                        m_iConveterIndex = i;
                        break;
                    }
                    else
                    {
                        string subLogic = CommandAnalysis(sFilePart, i);
                        sLogic = sLogic + subLogic;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sSubLogicName;
        }

        #endregion

        #endregion

        #region Command Check

        private bool CheckIsTimer(List<string> sFilePart, int index)
        {
            bool isTimer = false;
            try
            {
                if (sFilePart.Count >= index + 2)
                {
                   
                    string sNodedata = sFilePart[index];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogicType = LogicTypeCheck(sNodedata);

                    if (slogicType=="L")
                    {
                        sNodedata = sFilePart[index + 1];
                        sNodedata = NodedataEdit(sNodedata);

                        slogicType = LogicTypeCheck(sNodedata);
                        if (slogicType == "SD" || slogicType == "SE" || slogicType == "SF" || slogicType == "SP" || slogicType == "SS")
                            isTimer = true;
                        else if (slogicType == "FR")
                        {
                            string sAddress = FindAddress(sNodedata);
                            if (sAddress.StartsWith("T"))
                                isTimer = true;
                            else
                            {
                                //CTag tempUDLTag = FindTag(sAddress, true);
                                //if (tempUDLTag.DataType == EMDataType.Timer)
                                //{
                                //    isTimer = true;
                                //}
                            }
                        }
                    }
                    else
                    {
                        if (slogicType == "SD" || slogicType == "SE" || slogicType == "SF" || slogicType == "SP" || slogicType == "SS")
                            isTimer = true;
                        else if (slogicType == "FR")
                        {
                            string sAddress = FindAddress(sNodedata);
                            if (sAddress.StartsWith("T"))
                                isTimer = true;
                            else
                            {
                                //CTag tempUDLTag = FindTag(sAddress, true);
                                //if (tempUDLTag.DataType == EMDataType.Timer)
                                //{
                                //    isTimer = true;
                                //}
                            }
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTimer;
        }

        private bool CheckIsFRTimerOrCounter(List<string> sFilePart, int index)
        {
            bool bIsFR = false;

            try
            {
                if(sFilePart.Count>=index+2)
                {
                    string sNodedata = sFilePart[index + 1];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);

                    if (sLogicType =="L")
                    {

                        sNodedata = sFilePart[index + 2];
                        sNodedata = NodedataEdit(sNodedata);

                        sLogicType = LogicTypeCheck(sNodedata);
                        if (sLogicType == "FR")
                        {
                            bIsFR = true;
                        }
                    }
                    else
                    {
                        if (sLogicType == "FR")
                        {
                            bIsFR = true;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsFR;
        }

        private bool CheckIsCounter(List<string> sFilePart, int index)
        {
            bool isCounter = false;
            try
            {
                
                string sNodedata = sFilePart[index];
                sNodedata = NodedataEdit(sNodedata);

                string sLogicType = LogicTypeCheck(sNodedata);

                if( m_lstCounterList.Contains(sLogicType))
                {
                    sNodedata = sFilePart[index ];
                    sNodedata = NodedataEdit(sNodedata);

                    sLogicType = LogicTypeCheck(sNodedata);

                   
                    if (sLogicType == "CU" || sLogicType == "CD")
                        isCounter = true;
                    else if (sLogicType == "FR")
                    {
                        string sAddress = FindAddress(sNodedata);
                        if (sAddress.StartsWith("C"))
                            isCounter = true;
                                               
                    }
                }        
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isCounter;
        }      

        private bool CheckIsCallCoil(string sLogicType)
        {
            bool bIsCall = false;
            try
            {
                if (sLogicType == "CALL" || sLogicType == "CC" || sLogicType == "UC")
                    bIsCall = true;

                
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsCall;
        }

        #endregion

        #region Comment Converter
        
        private string LocalPartAnalysis(List<string> FilePart,int index)
        {
            string sLogic = string.Empty;

            try
            {
                int iLevel = 1;
                int iCount = FilePart.Count;

                string sNodedata = FilePart[index];
                sNodedata = NodedataEdit(sNodedata);

                string sLogicType = LogicTypeCheck(sNodedata);

                if(m_lstPartStart.Contains(sLogicType))
                {
                    string subLogic = string.Empty;
                    int iUpDownConterStartPoint = 0;
                    string sUpDownCounterAddress = string.Empty;

                    if (CheckHaveUpDownCounter(FilePart, 0))
                    {
                        int iTemp = 0;
                        sUpDownCounterAddress = CheckUpDownCounterAddress(FilePart, 0, ref iTemp);
                        iUpDownConterStartPoint = CheckCountUpDownStartPos(FilePart, 0, iTemp);
                    }

                    for(int i = index+1;i<iCount;i++)
                    {
                        sNodedata = FilePart[i];
                        sNodedata = NodedataEdit(sNodedata);
                        string sTempLogicType = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);

                        if (sUpDownCounterAddress != string.Empty && iUpDownConterStartPoint == i)
                        {
                            subLogic = CTUDCounterConverter(FilePart, i);
                            sLogic = sLogic + subLogic;
                        }
                        else if (m_lstPartStart.Contains(sTempLogicType))
                        {
                            //iLevel = iLevel + 1;

                            subLogic = LocalPartAnalysis(FilePart, i);

                            if (sTempLogicType == "O(" || sTempLogicType == "ON(")
                            {
                                if (sLogic == "")
                                    sLogic = "[" + subLogic;
                                else if(CheckBracketMapped(sLogic))
                                    sLogic = "[" + sLogic + "," + subLogic;
                                else if (sLogic.StartsWith("["))
                                    sLogic = sLogic + "," + subLogic;
                                else
                                    sLogic = "[" + sLogic + "," + subLogic;
                            }
                            else
                            {
                                sLogic = sLogic + subLogic;
                            }
                        }
                        else if(sTempLogicType == ")")
                        {                         

                            iLevel = iLevel - 1;
                            if (iLevel == 0)
                            {
                                if (sLogic.StartsWith("["))
                                    sLogic = sLogic + "]";

                                m_iConveterIndex = i;
                                break;
                            }
                        }
                        else
                        {
                            if (m_lstSimpleCommandType.Contains(sTempLogicType))
                            {
                                subLogic = SimpleCommandConverter(sNodedata);
                                sLogic = sLogic + subLogic;
                            }
                            else if (sAddress == ""&& !m_lstNonAddressCommand.Contains(sTempLogicType)&&!m_lstValueCommand.Contains(sTempLogicType))
                            {
                                if (sTempLogicType == "O" || sTempLogicType == "ON")
                                {
                                    if (sLogic == "")
                                        sLogic = "[";
                                    else if (sLogic.StartsWith("["))
                                    {
                                        if (CheckBracketMapped(sLogic))
                                        {
                                            sLogic = "[" + sLogic + ",";
                                        }
                                        else
                                            sLogic = sLogic + ",";
                                    }
                                    else
                                        sLogic = "[" + sLogic + ",";
                                }
                                else
                                {
                                    Console.WriteLine("There is a new type command. Command is {0}", sTempLogicType);
                                }                                    
                            }
                            else if (CheckIsLocalMemAdd(sAddress))
                            {
                                if (sTempLogicType == "=")
                                {
                                    if (!CheckBracketMapped(sLogic))
                                        sLogic = sLogic + "]";

                                    string stempLocal = LocalMemLogicConverter(sAddress, sLogic);

                                    sLogic = "**" + stempLocal + "**";
                                }
                                else if (sTempLogicType == "A")
                                {
                                    sAddress = GetLastLocalMemroyName(sAddress);

                                    LocalStartLogicConverter(sAddress, FilePart, i);
                                }
                            }
                            else
                            {
                                subLogic = CommandAnalysis(FilePart, i);

                                if (sTempLogicType == "O" || sTempLogicType == "ON")
                                {
                                    if (sLogic == "")
                                        sLogic = "[" + subLogic;
                                    else if(CheckBracketMapped(sLogic))
                                        sLogic = "[" + sLogic + "," + subLogic;
                                    else if (sLogic.StartsWith("["))
                                        sLogic = sLogic + "," + subLogic;
                                    else
                                        sLogic = "[" + sLogic + "," + subLogic;
                                }
                                else
                                {
                                    sLogic = sLogic + subLogic;
                                }
                            }                            
                        }

                        if (i < m_iConveterIndex)
                            i = m_iConveterIndex;
                        else
                            m_iConveterIndex = i;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sLogic;
        }       

        private string CommandAnalysis(List<string> FilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {
                string sNodedata = FilePart[index];

                if (sNodedata.Contains(": "))
                {
                    int iPos = sNodedata.IndexOf(": ");
                    sNodedata = sNodedata.Substring(iPos + 2);
                }
                sNodedata = NodedataEdit(sNodedata);

                string sLogicType = LogicTypeCheck(sNodedata);
                string sAddress = FindAddress(sNodedata);

                if ((sLogicType == "O" || sLogicType == "ON") && sAddress == "")
                    sLogic = "";
                else if(CheckIsLocalMemAdd(sAddress))
                {
                    sAddress = GetLastLocalMemroyName(sAddress);

                    LocalStartLogicConverter(sAddress, FilePart, index);
                }
                else if (m_lstSimpleCommandType.Contains(sLogicType))
                    sLogic = SimpleCommandConverter(sNodedata);
                else if(CheckIsCallCoil(sLogicType))
                {
                    sLogic = CallCoilConverter(FilePart, index);
                }
                else if(CheckIsCounter(FilePart,index))
                {
                    sLogic = CounterConverter(FilePart, index);
                }
                else if(CheckIsTimer(FilePart,index))
                {
                    sLogic = TimerConverter(FilePart, index);
                }
                else if(sLogicType == "L")
                {
                    LoadValueConverter(FilePart, index);
                    sLogic = string.Empty;
                    //sLogic = LoadLogicConverter(FilePart, index);
                }
                else if(m_lstValueCommand.Contains(sLogicType))
                {
                    sLogic = ValueCommandConverter(FilePart, index);
                }
                else if(sLogicType == "T")
                {
                    sAddress = FindCommandDestAdd(sNodedata);
                    sLogic = "MOV(" + m_cS7StateWord.ACCU1 + "," + sAddress + ")";
                    //m_cS7StateWord.ResetLoadValue();
                }
                else
                {
                    sLogic = SingelTagCommentConverter(FilePart, index);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }

        private void LoadValueConverter(List<string> FilePart,int index)
        {
            try
            {
                string sNodedata = FilePart[index];

                if (sNodedata.Contains(": "))
                {
                    int iPos = sNodedata.IndexOf(": ");
                    sNodedata = sNodedata.Substring(iPos + 2);
                }
                sNodedata = NodedataEdit(sNodedata);

                string sAddress = FindCommandSourceAdd(sNodedata);

                m_cS7StateWord.ValueLoad(sAddress);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string ValueCommandConverter(List<string> FilePart, int index)
        {
            string sLogic = string.Empty;
            try
            {
                string sNodedata = FilePart[index];

                if (sNodedata.Contains(": "))
                {
                    int iPos = sNodedata.IndexOf(": ");
                    sNodedata = sNodedata.Substring(iPos + 2);
                }
                sNodedata = NodedataEdit(sNodedata);

                string sSubLogic = LogicTypeCheck(sNodedata);
                string sAddress = string.Empty;
                sAddress = FindCommandSourceAdd(sNodedata);

                if(sAddress!=string.Empty)
                {
                    m_cS7StateWord.ValueLoad(sAddress);
                }

                if(m_lstCompareList.Contains(sSubLogic))
                {
                    sSubLogic = GeneralInstruCheck(sSubLogic);
                    sLogic = sSubLogic + "(" + m_cS7StateWord.ACCU2 + "," + m_cS7StateWord.ACCU1 + ")";

                    m_cS7StateWord.ResetLoadValue();
                }
                else if (sSubLogic == "+AR1" || sSubLogic == "+AR2")
                {
                    sSubLogic = GeneralInstruCheck(sSubLogic);
                    sLogic = sSubLogic + "(" + m_cS7StateWord.ACCU1 + ")";

                    m_cS7StateWord.ResetLoadValue();
                }
                else
                {                    
                    if(m_lstSingleComputerList.Contains(sSubLogic)||m_lstConvertorList.Contains(sSubLogic))
                    {
                        sSubLogic = GeneralInstruCheck(sSubLogic);
                        sLogic = sSubLogic + "(" + m_cS7StateWord.ACCU1 + ",";
                    }
                    else if(m_lstDualComputerList.Contains(sSubLogic)||m_lstWordLogicList.Contains(sSubLogic)|| m_lstAccumList.Contains(sSubLogic))
                    {
                        sSubLogic = GeneralInstruCheck(sSubLogic);
                        sLogic = sSubLogic + "(" + m_cS7StateWord.ACCU2 + "," + m_cS7StateWord.ACCU1 + ",";
                    }
                    else if(m_lstCyclicShiftList.Contains(sSubLogic))
                    {
                        sSubLogic = GeneralInstruCheck(sSubLogic);
                        sLogic = sSubLogic + "(" + m_cS7StateWord.ACCU2 + "," + m_cS7StateWord.ACCU1 + ",";
                    }

                    m_cS7StateWord.ResetLoadValue();

                    string sTemp = FilePart[index + 1];
                    if(sTemp.Contains(": "))
                    {
                        int iPos = sTemp.IndexOf(": ");
                        sTemp = sTemp.Substring(iPos + 2);
                    }

                    sSubLogic = LogicTypeCheck(sTemp);
                    sAddress = FindCommandDestAdd(sTemp);

                    if(sSubLogic =="T")
                    {
                        sLogic = sLogic + sAddress + ")";
                        m_iConveterIndex = index + 1;
                    }
                    else
                    {
                        if(m_lstLogicControlList.Contains(sSubLogic))
                        {
                            int iCount = sLogic.Length;

                            sLogic = sLogic.Remove(iCount - 1);
                            sLogic = sLogic + ")";
                        }
                        else
                        {
                            if(m_cS7StateWord.ACCU1 == string.Empty)
                            {                                
                                sLogic = sLogic + "ACCU1" + ")";
                                m_cS7StateWord.ValueLoad("ACCU1");
                            }
                            else
                            {
                                sLogic = sLogic + m_cS7StateWord.ACCU1 + ")";
                            }
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }

        private string LocalMemLogicConverter(string localName,string logic)
        {
            try
            {
                localName = NewLocalMemoryNameEdit(localName);

                if(logic.StartsWith("**"))
                {
                    logic = logic.Substring(3);
                    int iPos = logic.IndexOf("**");

                    logic = logic.Substring(iPos + 2);
                }

                CS7LocalMem tempLocal = new CS7LocalMem(localName, logic);

                m_DicLocalMem.Add(localName, tempLocal);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return localName;
        }        

        private string SimpleCommandConverter(string nodedata)
        {
            string sLogic = string.Empty;

            try
            {
                string sCommand = LogicTypeCheck(nodedata);

                sCommand = GeneralInstruCheck(sCommand);

                sLogic = sCommand + "( )";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }

        private string FindCommandSourceAdd(string sNodedata)
        {
            string sSource = string.Empty;
            try
            {
                string sLogicType = LogicTypeCheck(sNodedata);
                if (sLogicType == "LAR1")
                    sSource = "AR1"; 
                else if (sLogicType == "LAR2")
                    sSource = "AR2";
                else
                {
                    sSource = FindAddress(sNodedata);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sSource;
        }

        private string FindCommandDestAdd(string sNodedata)
        {
            string sDest = string.Empty;
            try
            {
                string sLogicType = LogicTypeCheck(sNodedata);
                if (sLogicType == "TAR1"||sLogicType == "LAR1")
                    sDest = "AR1";
                else if (sLogicType == "TAR2" || sLogicType == "LAR2")
                    sDest = "AR2";
                else
                {
                    sDest = FindAddress(sNodedata);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sDest;
        }

        private string SingelTagCommentConverter(List<string> sFilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {
                string sNodedata = sFilePart[index];
                sNodedata = NodedataEdit(sNodedata);

                string sSource = FindAddress(sNodedata);
                string sComment = LogicTypeCheck(sNodedata);
                sComment = GeneralInstruCheck(sComment);

                sLogic = sComment + "(" + sSource  + ")";

                m_iConveterIndex = index;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }       

        private string CallCoilConverter(List<string> sFilePart,int index)
        {
            string sLogic = string.Empty;

            try
            {
                int iCount = sFilePart.Count;
                string sFuncName = string.Empty;
                string sDBName = string.Empty;

                string sNodedata = sFilePart[index];
                sNodedata = NodedataEdit(sNodedata);

                sFuncName = FindCallFunctionName(sNodedata);
                sDBName = FindCallDBName(sNodedata);

                List<string> FBLabelS = GetFBLabelList(sFuncName);

                Dictionary<string, string> CallLabelS = new Dictionary<string, string>();

                if (sDBName != "")
                    sFuncName = sFuncName + "." + sDBName;

                sLogic = sFuncName + "(";                

                if (sNodedata.Contains("("))
                {
                    int j = index + 1;

                    sNodedata = sFilePart[j];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLabelName = string.Empty;
                    string sLabelAddress = string.Empty;


                    while(!sNodedata.EndsWith(");"))
                    {
                        sLabelName = FindCallLabelName(sNodedata);
                        sLabelAddress = FindCallLabelAddress(sNodedata);

                        //sLogic = sLogic + sLabelName + ":+:" + sLabelAddress + ",";
                        CallLabelS.Add(sLabelName, sLabelAddress);
                        j = j+1;

                        sNodedata = sFilePart[j];
                        sNodedata = NodedataEdit(sNodedata);
                    }
                    sLabelName = FindCallLabelName(sNodedata);
                    sLabelAddress = FindCallLabelAddress(sNodedata);
                    if (sLabelAddress.EndsWith(")"))
                        sLabelAddress = sLabelAddress.Remove(sLabelAddress.Length - 1);

                    CallLabelS.Add(sLabelName, sLabelAddress);

                    sLogic = CallCommandLabelConnect(sLogic, FBLabelS, CallLabelS);

                    m_iConveterIndex = j;
                }
                else
                {
                    sLogic = CallCommandLabelConnect(sLogic, FBLabelS, CallLabelS); 
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        } 

        private string TimerConverter(List<string> sFilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {
                int iCount = sFilePart.Count;

                if(CheckIsFRTimerOrCounter(sFilePart,index))
                {
                    sLogic = FRCommentConverter(sFilePart, index);
                }
                else
                {
                    string sTimeAddress = string.Empty;
                    string sPresetValue = string.Empty;
                    string sCommand = string.Empty;

                    for (int i = index; i < iCount; i++)
                    {
                        string sNodedata = sFilePart[i];
                        sNodedata = NodedataEdit(sNodedata);

                        string sLogictype = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);

                        if(sLogictype =="L")
                        {
                            sPresetValue = sAddress;
                        }
                        else if(m_lstTimerList.Contains(sLogictype))
                        {
                            sTimeAddress = sAddress;
                            sCommand = LogicTypeCheck(sNodedata);
                            sCommand = GeneralInstruCheck(sCommand);

                            sLogic = sCommand + "(" + sTimeAddress + "," + sPresetValue;

                            if (CheckIsHaveReset(sFilePart, i+1, sTimeAddress))
                            {

                                string reset = GetTimeCountReset(sFilePart, i+1, sTimeAddress);

                                sLogic = sLogic + "," + reset;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            if(CheckIsHaveLoadTC(sFilePart,i+1,sTimeAddress))
                            {
                                string sLoad = GetTCLoadTarget(sFilePart, i+1, sTimeAddress);
                                sLogic = sLogic + "," + sLoad;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            if(CheckIsHaveBLDLoadTC(sFilePart,i+1,sTimeAddress))
                            {
                                string sLoad = GetTCLoadTarget(sFilePart, i+1, sTimeAddress);
                                sLogic = sLogic + "," + sLoad;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            sLogic = sLogic + ")";
                            m_iConveterIndex = i;
                            break;
                        }
                    }
                }               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFilePart"></param>
        /// <param name="index"></param>
        /// <returns>Siemense Count  CTU// CTD (Counter Tag, SetLogic, perset Value, Reset, Load to, BCD Load To)
        ///  CTUD(Counter Tag, SetLogic, perset Value, Count Down Logic, Reset, Load to, BCD Load To) </returns>
        private string CounterConverter(List<string> sFilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {

                int iCount = sFilePart.Count;

                
                if (CheckIsFRTimerOrCounter(sFilePart, index))
                {
                    sLogic = FRCommentConverter(sFilePart, index);
                }
                else
                {
                    string sCountAddress = string.Empty;
                    string sPresetValue = string.Empty;
                    string sCommand = string.Empty;
                    string sSetLogic = string.Empty;

                    string sTempLogic = string.Empty;

                    for (int i = index; i < iCount; i++)
                    {
                        string sNodedata = sFilePart[i];
                        sNodedata = NodedataEdit(sNodedata);

                        string sLogictype = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);

                        if (m_lstCounterList.Contains(sLogictype))
                        {
                            sCountAddress = sAddress;

                            if (sLogictype == "CU")
                                sCommand = "CTU";
                            else if (sLogictype == "CD")
                                sCommand = "CTD";

                            sCommand = GeneralInstruCheck(sCommand);
                            sLogic = sCommand + "(" + sCountAddress ;

                            if(CheckIsHaveSetCounter(sFilePart,i+1,sCountAddress))
                            {
                                sSetLogic = GetCountPreSet(sFilePart, i + 1, sCountAddress, ref sPresetValue);
                                sLogic = sLogic + "," + sSetLogic + "," + sPresetValue;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",,";

                            if (CheckIsHaveReset(sFilePart, i+1, sCountAddress))
                            {

                                string reset = GetTimeCountReset(sFilePart, i+1, sCountAddress);

                                sLogic = sLogic + "," + reset;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            if (CheckIsHaveLoadTC(sFilePart, i+1, sCountAddress))
                            {
                                string sLoad = GetTCLoadTarget(sFilePart, i+1, sCountAddress);
                                sLogic = sLogic + "," + sLoad;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            if (CheckIsHaveBLDLoadTC(sFilePart, i+1, sCountAddress))
                            {
                                string sLoad = GetTCLoadTarget(sFilePart, i+1, sCountAddress);
                                sLogic = sLogic + "," + sLoad;

                                i = m_iConveterIndex;
                            }
                            else
                                sLogic = sLogic + ",";

                            sLogic = sLogic + ")";

                            m_iConveterIndex = i;
                            break;
                        }                       
                        i = m_iConveterIndex;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }       

        private string CTUDCounterConverter(List<string> sFilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {
                string sSetLogic = string.Empty;
                string sPersetValue = string.Empty;
                string sResetLogic = string.Empty;
                string sCountUpLogic = string.Empty;
                string sCountDownLogic = string.Empty;

                string sLoadTarget = string.Empty;
                string sLoadBCDTarget = string.Empty;

                string sCounterAddress = string.Empty;

                int iCount = sFilePart.Count;

                for(int i = index;i<iCount;i++)
                {
                    string sNodedata = sFilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);
                    string sAddress = FindAddress(sNodedata);

                    if (sLogicType == "CU")
                    {
                        if (sLogic.StartsWith("["))
                            sLogic = sLogic + "]";

                        sCountUpLogic = CommandSubLogicConvert(sLogic);
                        sCounterAddress = sAddress;
                        sLogic = string.Empty;
                    }
                    else if(sLogicType == "CD")
                    {
                        if (sLogic.StartsWith("["))
                            sLogic = sLogic + "]";

                        sCountDownLogic = CommandSubLogicConvert(sLogic);
                        sLogic = string.Empty;

                        if(CheckIsHaveSetCounter(sFilePart,i+1,sCounterAddress))
                        {
                            sSetLogic = GetCountPreSet(sFilePart, i + 1, sCounterAddress, ref sPersetValue);

                            i = m_iConveterIndex;
                        }


                        if (CheckIsHaveReset(sFilePart, i+1, sCounterAddress))
                        {
                            sResetLogic = GetTimeCountReset(sFilePart, i + 1, sCounterAddress);

                            i = m_iConveterIndex;
                        }

                        if(CheckIsHaveLoadTC(sFilePart,i,sCounterAddress))
                        {
                            sLoadTarget = GetTCLoadTarget(sFilePart, i + 1, sCounterAddress);

                            i = m_iConveterIndex;
                        }
                        if (CheckIsHaveBLDLoadTC(sFilePart, i, sCounterAddress))
                        {
                            sLoadBCDTarget = GetTCLoadTarget(sFilePart, i + 1, sCounterAddress);

                            i = m_iConveterIndex;
                        }

                        if (i > m_iConveterIndex)
                            m_iConveterIndex = i;

                        break;
                    }
                    else
                    {
                        string sSubLogic = CommandAnalysis(sFilePart, i);

                        if (sLogicType == "O" || sLogicType == "ON")
                        {
                            if (sLogic == "")
                                sLogic = "[" + sSubLogic;
                            else if (sLogic.StartsWith("["))
                            {
                                if (CheckBracketMapped(sLogic))
                                {
                                    sLogic = "[" + sLogic + ", ";
                                }
                                else
                                    sLogic = sLogic + ", ";
                            }
                            else
                                sLogic = "[" + sLogic + ", " + sSubLogic;
                        }
                        else
                        {
                            sLogic = sLogic + sSubLogic;
                        }
                    }
                }

                sLogic = "CTUD("+sCounterAddress+","+sCountUpLogic+","+sCountDownLogic+","+sPersetValue+","+sSetLogic+","+sResetLogic+","+sLoadTarget+","+sLoadBCDTarget+")";

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }

        private string FRCommentConverter(List<string> sFilePart, int index)
        {
            string sLogic = string.Empty;

            try
            {
                string sNodedata = sFilePart[index];
                sNodedata = NodedataEdit(sNodedata);

                string sSource = FindAddress(sNodedata);
                string sComment = "FR";

                sLogic = sComment + "(" + sSource + ")";

                m_iConveterIndex = index;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sLogic;
        }     

        #endregion

        #endregion
    }
}
