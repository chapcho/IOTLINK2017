using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7STLAnalysis
    {
        // Create by Qin Shiming at 2015.06.22
        // Frist edit at 2015.06.26 by Qin Shiming
        // Second edit at 2015.07.01 by Qin Shiming
        // 3th edit at 2015.07.05 by Qin Shiming

        #region MemberVariables

        //protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;
        protected CTagS m_dInternalTags = null;
        protected CTagS m_dTagUseCheckAdd = null;
        protected CTagS m_dTagUseCheckSym = null;
        protected Dictionary<string, CS7DataBlock> m_dDBDic = null;
        protected Dictionary<string, CS7UDT> m_dUDTDIC = null;
        protected Dictionary<string, CS7Block> m_dBlockDic = null;

        protected CStep m_cTempStep = null;
        protected CStepS m_cStepList = null;

        protected Dictionary<string, CS7LocalMem> m_dLocalMem = null;
        protected Dictionary<string, bool> m_dTagCheckDic = null;
        protected CStepS m_dJumpDic = null;
        protected List<string> m_lJumpLable = null;
        protected string m_sFunction = string.Empty;
        protected List<string> m_lUnKnowBlock = null;

        protected int m_iNetworkIndex = 0;
        protected int m_iOperitionIndex = 0;

        protected int m_iInputUseCheck = 0;
        protected int m_iOutputUseCheck = 0;
        protected int m_iMemUseCheck = 0;

        protected int m_iTotalStepCount = 0;

        protected List<string> m_lLogicKeyList = new List<string>() { "A", "AN", "A(", "AN(", ")", "O", "ON", "O(", "ON(", "X", "XN", "X(", "XN(", "NOT", "L", "LC", "LAR1", "LAR2" };
        protected List<string> m_lCompareList = new List<string>() { "==I", "<>I", ">I", "<I", ">=I", "<=I", "==D", "<>D", ">D", "<D", ">=D", "<=D", "==R", "<>R", ">R", "<R", ">=R", "<=R", };
        protected List<string> m_lConvertorList = new List<string>() { "BTI", "ITB", "BTD", "ITD", "DTB", "DTR", "INVI", "INVD", "NEGI", "NEGD", "NEGR", "CAW", "CAD", "RND", "TRUNC", "TRUN", "RND+", "RND-" };
        protected List<string> m_lCoilTypeList = new List<string>() { "=", "=I", "FP", "FN", "S", "R", "SI", "RI", "T", "SET", "CLR", "SAVE", "CAR", "TAR1", "TAR2" };
        protected List<string> m_lTimerCountList = new List<string>() { "FR", "CU", "CD", "SF", "SE", "SP", "SD", "SS", };
        protected List<string> m_lDataBlockCommandList = new List<string>() { "OPN", "CDB" };
        protected List<string> m_lLogicControlList = new List<string>() { "JU", "JL", "JC", "JCN", "JCB", "JNB", "JBI", "JNBI", "JO", "JOS", "JZ", "JN", "JP", "JM", "JPZ", "JMZ", "JUO", "LOOP" };
        protected List<string> m_lProgramControllList = new List<string>() { "BE", "BEC", "BEU", "CALL", "CC", "UC", "MCR", "MCR(", ")MCR", "MCRA", "MCRD" };
        protected List<string> m_lComputerList = new List<string>() { "+I", "-I", "*I", "/I", "+D", "-D", "*D", "/D", "MOD", "+R", "-R", "*R", "/R", "ABS", "SQR", "SQRT", "EXP", "LN", "SIN", "COS", "TAN", "ASIN", "ACOS", "ATAN" };
        protected List<string> m_lCyclicShiftList = new List<string>() { "SSI", "SSD", "SLW", "SRW", "SLD", "SRD", "RLD", "RRD", "RLDA", "RRDA" };
        protected List<string> m_lWordLogicList = new List<string>() { "AW", "OW", "XOW", "AD", "OD", "XOD" };
        protected List<string> m_lAccumList = new List<string> { "TAK", "PUSH", "POP", "ENT", "LEAVE", "INC", "DEC", "+AR1", "+AR2", "BLD", "NOP" };
        protected List<string> m_lSpecialAddress = new List<string> { "DBLG", "DBNO", "DILG", "DINO", "STW", "AR1", "AR2", "BR", "OV", "OS", "RLO", "STA", "OR", "CC1", "CC0", "ACCU1", "ACCU2" };

        protected List<string> m_lSimpleCantactType = new List<string> { "MCRA", "MCRD", "NOT" };
        protected List<string> m_lSimpleCoilType = new List<string> { "BE", "BEC", "BEU", "TAK", "PUSH", "POP", "ENT", "LEAVE", "BLD", "NOP", "SET", "SAVE", "CLR", "CDB" };

        protected int m_iCompareCount = 0;
        protected int m_iLogicKeyCount = 0;
        protected int m_iConvertorCount = 0;
        protected int m_iTimerCounterCount = 0;
        protected int m_iDataBlockComCount = 0;
        protected int m_iLogicControlCount = 0;
        protected int m_iProgramControlCount = 0;
        protected int m_iComputerCount = 0;
        protected int m_iCyclicShiftCount = 0;
        protected int m_iWordLogicCount = 0;
        protected int m_iAccumCount = 0;

        protected CS7DataBlock m_cCurrentDB = null;
        protected CS7DataBlock m_cCurrentInstanceDB = null;

        protected Dictionary<string, string> m_dTagContactUseDic = new Dictionary<string, string>();
        protected Dictionary<string, string> m_dTagCoilUseDic = new Dictionary<string, string>();
        protected List<string> m_lCoilS = new List<string>();
        protected List<string> m_lContactS = new List<string>();

        protected int m_iTotalCoilCount = 0;
        protected int m_iTotalContactCount = 0;

        protected int m_iAnalysisPointer = 0;

        protected CContactS m_lTempContacts = null;
        protected CCoilS m_lTempCoilS = null;
        protected CContentS m_lTempContents = null;

        #endregion

        #region Initialze/Dispose

        public CS7STLAnalysis(CTagS addTag)
        {
            //m_dSymbolTags = symTag;
            m_dAddressTags = addTag;
            m_dTagUseCheckAdd = new CTagS();
            m_dTagUseCheckSym = new CTagS();

            m_cStepList = new CStepS();
            m_dTagCheckDic = new Dictionary<string, bool>();
            m_lUnKnowBlock = new List<string>();

            m_iCompareCount = m_lCompareList.Count;
            m_iLogicKeyCount = m_lLogicKeyList.Count;
            m_iConvertorCount = m_lConvertorList.Count;
            m_iTimerCounterCount = m_lTimerCountList.Count;
            m_iDataBlockComCount = m_lDataBlockCommandList.Count;
            m_iLogicControlCount = m_lLogicControlList.Count;
            m_iProgramControlCount = m_lProgramControllList.Count;
            m_iComputerCount = m_lComputerList.Count;
            m_iCyclicShiftCount = m_lCyclicShiftList.Count;
            m_iWordLogicCount = m_lWordLogicList.Count;
            m_iAccumCount = m_lAccumList.Count;


            m_lCoilS.AddRange(m_lConvertorList);
            m_lCoilS.AddRange(m_lTimerCountList);
            m_lCoilS.AddRange(m_lLogicControlList);
            m_lCoilS.AddRange(m_lProgramControllList);
            m_lCoilS.AddRange(m_lComputerList);
            m_lCoilS.AddRange(m_lCyclicShiftList);
            m_lCoilS.AddRange(m_lWordLogicList);
            m_lCoilS.AddRange(m_lAccumList);
            m_lCoilS.AddRange(m_lCoilTypeList);

            m_lContactS.AddRange(m_lLogicKeyList);
            m_lContactS.AddRange(m_lCompareList);
            m_lContactS.AddRange(m_lDataBlockCommandList);

            m_iTotalCoilCount = m_lCoilS.Count;
            m_iTotalContactCount = m_lContactS.Count;
        }


        #endregion

        #region Public Properites

        public Dictionary<string, CS7UDT> UDTDic
        {
            set { m_dUDTDIC = value; }
        }
        public Dictionary<string, CS7DataBlock> DBDic
        {
            set { m_dDBDic = value; }
        }
        public Dictionary<string, string> TagCoilUseDic
        {
            get { return m_dTagCoilUseDic; }
        }
        public Dictionary<string, string> TagContactUseDic
        {
            get { return m_dTagContactUseDic; }
        }

        public Dictionary<string, CS7Block> BlockDic
        {
            set { m_dBlockDic = value; }
        }

        public Dictionary<string, bool> TagUseCheck
        {
            get { return m_dTagCheckDic; }
        }
        public List<string> UnknowBlock
        {
            get { return m_lUnKnowBlock; }
        }
        public CTagS InternalTags
        {
            set { m_dInternalTags = value; }
        }
        public int InputUsedCount
        {
            get { return m_iInputUseCheck; }
        }
        public int OutputUsedCount
        {
            get { return m_iOutputUseCheck; }
        }
        public int MemUsedCheck
        {
            get { return m_iMemUseCheck; }
        }
        public CStepS JumpDic
        {
            get { return m_dJumpDic; }
        }
        public CStep TempStep
        {
            get { return m_cTempStep; }
        }
        public CStepS TotalStep
        {
            get { return m_cStepList; }
        }
        public CTagS TagUseCheckAdd
        {
            get { return m_dTagUseCheckAdd; }
        }
        public CTagS TagUseCheckSymbol
        {
            get { return m_dTagUseCheckSym; }
        }

        #endregion

        #region Public Methods


        public void NewNetworkAnalysis(List<string> FilePart, string FcName, int networkIndex)
        {
            try
            {
                m_dLocalMem = new Dictionary<string, CS7LocalMem>();

                m_iOperitionIndex = 0;
                m_lJumpLable = new List<string>();
                m_lTempContacts = new CContactS();
                m_lTempCoilS = new CCoilS();
                List<string> partStart = new List<string> { "A(", "O(", "AN(", "ON(" };
                bool isInitial = true;

                if (FcName != m_sFunction)
                {
                    m_dJumpDic = new CStepS();
                    m_sFunction = FcName;
                    m_cCurrentDB = null;
                    m_cCurrentInstanceDB = null;
                }

                m_iNetworkIndex = networkIndex;

                FilePart = NewFilePartEdit(FilePart);

                int iCount = FilePart.Count;
                string sNodedata = string.Empty;
                string sComment = string.Empty;
                string sAddress = string.Empty;
                string sLabelName = string.Empty;
                string sLogicType = string.Empty;

                List<int> TotalTempLastContactS = new List<int>();
                List<int> TotalTempLastCoilS = new List<int>();

                List<int> tempLastContactS = new List<int>();
                List<int> tempLastCoilS = new List<int>();
                int iLastOpertion = -1;

                for (int i = 0; i < iCount; i++)
                {
                    m_iAnalysisPointer = i;

                    sNodedata = FilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    if (sNodedata.Length > 2)
                    {
                        if (sNodedata.Contains("//"))
                        {
                            sComment = FindComment(sNodedata);
                            int iPos = sNodedata.IndexOf("//");
                            sNodedata = sNodedata.Remove(iPos);
                        }

                        if (sNodedata.Contains(": "))
                        {
                            int iPos = sNodedata.IndexOf(": ");
                            sLabelName = sNodedata.Remove(iPos);
                            sNodedata = sNodedata.Substring(iPos + 2);

                            m_lJumpLable.Add(sLabelName);
                            CStep labelStep = new CStep();

                            m_dJumpDic.Add(sLabelName, labelStep);
                        }

                        sNodedata = NodedataEdit(sNodedata);
                        sLogicType = LogicTypeCheck(sNodedata);
                        sAddress = FindAddress(sNodedata);


                        if (partStart.Contains(sLogicType) || sLogicType == "MCR(")
                        {
                            List<int> tempCoilS = new List<int>();
                            List<int> tempContactS = new List<int>();

                            NewLocalPartAnalysis(FilePart, sLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS, ref tempContactS, ref tempCoilS);
                            i = m_iAnalysisPointer;
                            isInitial = false;

                            tempLastCoilS.Clear();
                            tempLastContactS.Clear();

                            int iTemp = tempCoilS.Count;
                            for (int j = 0; j < iTemp; j++)
                            {
                                tempLastCoilS.Add(tempCoilS[j]);
                            }

                            iTemp = tempContactS.Count;
                            for (int j = 0; j < iTemp; j++)
                            {
                                tempLastContactS.Add(tempContactS[j]);
                            }
                        }
                        else if(sLogicType=="NOP"||sLogicType =="BLD")
                        {

                        }
                        else if (m_lSimpleCantactType.Contains(sLogicType))
                        {
                            iLastOpertion = NewSimpleContactRelAnalysis(sLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS);
                            isInitial = false;

                            tempLastContactS.Clear();
                            tempLastCoilS.Clear();
                            tempLastContactS.Add(iLastOpertion);
                        }
                        else if (m_lSimpleCoilType.Contains(sLogicType))
                        {
                            if (sLogicType != "SAVE" && sLogicType != "CLR" && sLogicType != "SET" && sLogicType != "BLD")
                            {
                                iLastOpertion = NewSimpleCoilRelAnalysis(sLogicType, i, sNodedata, tempLastContactS, tempLastCoilS);
                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                        }
                        else if (CheckIsLocalMemAdd(sAddress) && sLogicType == "=")
                        {
                            if (tempLastContactS.Count > 1)
                            {
                                int iTemp = tempLastContactS.Count;

                                for (int j = 0; j < iTemp; j++)
                                {
                                    TotalTempLastContactS.Add(tempLastContactS[j]);
                                }

                                iTemp = tempLastCoilS.Count;

                                for (int j = 0; j < iTemp; j++)
                                {
                                    TotalTempLastCoilS.Add(tempLastCoilS[j]);
                                }
                            }

                            NewLocalMemoryAnalysis(sAddress, sComment, TotalTempLastContactS, TotalTempLastCoilS);
                            isInitial = false;
                        }
                        else if (CheckIsCallCoil(sLogicType))
                        {
                            iLastOpertion = NewProgramChontrolRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, tempLastContactS, tempLastCoilS);
                            tempLastContactS.Clear();
                            tempLastCoilS.Clear();
                            tempLastCoilS.Add(iLastOpertion);
                        }
                        else if (m_lLogicControlList.Contains(sLogicType))
                        {
                            iLastOpertion = NewJumpRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, tempLastContactS, tempLastCoilS);

                            tempLastCoilS.Add(iLastOpertion);
                        }
                        else if (CheckIsConTact(sLogicType))
                        {
                            if (CheckIsCounter(FilePart, i))
                            {
                                iLastOpertion = NewCounterRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, tempLastContactS, tempLastCoilS);
                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (CheckIsTimer(FilePart, i))
                            {
                                iLastOpertion = NewTimeRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, tempLastContactS, tempLastCoilS);
                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (sLogicType == "L")
                            {
                                iLastOpertion = NewLoadLogicRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);
                                isInitial = false;

                                if (CheckIsCompare(FilePart, i))
                                {
                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastContactS.Add(iLastOpertion);
                                }
                                else
                                {
                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastCoilS.Add(iLastOpertion);
                                }
                            }
                            else
                            {
                                if (sLogicType == "O" || sLogicType == "ON")
                                {
                                    if (sAddress == "")
                                    {
                                        //i = i + 1;
                                        //sNodedata = FilePart[i];
                                        //sNodedata = NodedataEdit(sNodedata);
                                        //sLogicType = LogicTypeCheck(sNodedata);
                                        //sAddress = FindAddress(sNodedata);
                                        //sComment = FindComment(sNodedata);
                                        //iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sLogicType, sComment,true, new List<int>(), new List<int>());
                                        isInitial = true;
                                        //tempLastContactS.Add(iLastOpertion);
                                    }
                                    else
                                    {
                                        iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, true, new List<int>(), new List<int>());
                                        tempLastContactS.Add(iLastOpertion);
                                        isInitial = false;
                                    }
                                }
                                else if (sLogicType == "A" || sLogicType == "AN")
                                {
                                    if (CheckIsLocalMemAdd(sAddress))
                                    {
                                        NewLocalMemoryRelCheck(sAddress, ref tempLastContactS, ref tempLastCoilS);
                                    }
                                    else
                                    {
                                        iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);
                                        isInitial = false;
                                        tempLastContactS.Clear();
                                        tempLastContactS.Add(iLastOpertion);
                                        isInitial = false;
                                    }
                                }
                            }
                        }
                        else if (CheckIsCoil(sLogicType))
                        {
                            iLastOpertion = NewCoilRelAnalysis(FilePart, i, sAddress, sLogicType, sComment, TotalTempLastContactS, TotalTempLastCoilS);
                            tempLastCoilS.Add(iLastOpertion);
                        }

                        if (i < iCount - 1)
                        {
                            sNodedata = FilePart[i + 1];
                            sNodedata = NodedataEdit(sNodedata);
                            sLogicType = LogicTypeCheck(sNodedata);

                            if (sLogicType == "O" || sLogicType == "ON" || sLogicType == "O(" || sLogicType == "=" || sLogicType == "S" || sLogicType == "R" || sLogicType == "T")
                            {
                                int relationCount = tempLastContactS.Count;

                                for (int j = 0; j < relationCount; j++)
                                {
                                    if (!TotalTempLastContactS.Contains(tempLastContactS[j]))
                                    {
                                        TotalTempLastContactS.Add(tempLastContactS[j]);
                                    }
                                }
                                relationCount = tempLastCoilS.Count;
                                tempLastContactS.Clear();
                                for (int j = 0; j < relationCount; j++)
                                {
                                    if (!TotalTempLastCoilS.Contains(tempLastCoilS[j]))
                                        TotalTempLastCoilS.Add(tempLastCoilS[j]);
                                }
                                tempLastCoilS.Clear();
                            }
                            else if (sLogicType == ")")
                            {
                                int relationCount = tempLastContactS.Count;
                                for (int j = 0; j < relationCount; j++)
                                {
                                    if (!TotalTempLastContactS.Contains(tempLastContactS[j]))
                                    {
                                        TotalTempLastContactS.Add(tempLastContactS[j]);
                                    }
                                }
                                //tempLastContactS.Clear();
                                relationCount = tempLastCoilS.Count;

                                for (int j = 0; j < relationCount; j++)
                                {
                                    if (!TotalTempLastCoilS.Contains(tempLastCoilS[j]))
                                    {
                                        TotalTempLastCoilS.Add(tempLastCoilS[j]);
                                    }
                                }
                                //tempLastCoilS.Clear();
                            }
                        }
                    }

                    i = m_iAnalysisPointer;
                }


                foreach (string sTemp in m_dLocalMem.Keys)
                {
                    iCount = m_dLocalMem[sTemp].TotalContactS.Count;
                    for (int i = 0; i < iCount; i++)
                    {
                        m_cTempStep.ContactS.Add(m_dLocalMem[sTemp].TotalContactS[i]);
                    }
                }

                iCount = m_lTempContacts.Count;
                for (int i = 0; i < iCount; i++)
                {
                    m_cTempStep.ContactS.Add(m_lTempContacts[i]);
                }

                string stepName = FcName + "." + networkIndex.ToString();
                m_cStepList.Add(stepName, m_cTempStep);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                m_dLocalMem.Clear();
                m_lJumpLable.Clear();
            }
        }


        #endregion

        #region Private Methods

        #region New Private Functions

        private List<string> NewFilePartEdit(List<string> FilePart)
        {

            List<string> editedCode = new List<string>();

            try
            {
                int count = FilePart.Count;
                string sTitle = string.Empty;

                for (int i = 1; i < count; i++)
                {
                    string sNodedata = FilePart[i];
                    if (sNodedata.Length > 2)
                    {
                        if (sNodedata.StartsWith("TITLE ="))
                        {
                            sTitle = FindTitle(sNodedata);

                            m_cTempStep = new CS7Step();
                            m_cTempStep.StepIndex = m_iNetworkIndex;
                            m_cTempStep.Program = m_sFunction;
                            m_cTempStep.Situation = sTitle;

                            sNodedata = string.Empty;
                        }
                        else if (sNodedata.StartsWith("      "))
                        {
                            sNodedata = sNodedata.Substring(6);
                            editedCode.Add(sNodedata);
                        }
                        else if (sNodedata.StartsWith("//"))
                        {
                            sNodedata = string.Empty;
                        }
                        else if (sNodedata.Contains(": "))
                        {
                            editedCode.Add(sNodedata);
                        }
                        else
                        {
                            Console.WriteLine("There is a new type nodedata : {0}", sNodedata);
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

        private void NewLocalMemoryRelCheck(string sNodedata, ref List<int> PerContact, ref List<int> PerCoil)
        {
            try
            {
                string stemp = sNodedata;

                while (m_dLocalMem.ContainsKey(stemp + "-New"))
                {
                    stemp = stemp + "-New";
                }

                int icount = 0;

                if (m_dLocalMem.ContainsKey(stemp))
                {
                    icount = m_dLocalMem[stemp].LastContactS.Count;
                }

                PerContact = m_dLocalMem[stemp].LastContactS;
                PerCoil = m_dLocalMem[stemp].LastCoilS;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int NewContactRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, bool isInital, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                CContent cTempContent = new CContent();
                CContact cTempContact = new CContact();

                if(CheckIsConstant(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.Constant;
                    cTempContent.Argument = sAddress;
                }
                else if(CheckIsInternel(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.LogicTag;
                    cTempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if(m_lSpecialAddress.Contains(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.None;
                    cTempContent.Argument = sAddress;
                }
                else
                {
                    cTempContent.ArgumentType = EMArgumentType.Tag;
                    cTempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                cTempContent.Parameter = sNodedata;

                cTempContact.ContentS.Add(cTempContent);
                cTempContact.ContactType = EMContactType.Bit;

                switch (sLogicType)
                {
                    case "A":
                    case "O": cTempContact.Instruction = EMContactTypeBit.Open.ToString();
                        cTempContact.Operator = EMContactTypeBit.Open.ToString();
                        break;
                    case "AN":
                    case "ON":
                        cTempContact.Instruction = EMContactTypeBit.Close.ToString();
                        cTempContact.Operator = EMContactTypeBit.Close.ToString();
                        break;
                    default:
                        cTempContact.Instruction = sLogicType;
                        cTempContact.Operator = sLogicType;
                        break;
                }


                cTempContact.StepIndex = m_iOperitionIndex;
                iOperationNum = m_iOperitionIndex;

                m_iOperitionIndex = m_iOperitionIndex + 1;

                int iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    cTempContact.Relation.PrevCoilS.Add(LastCoilS[i]);
                }

                iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                    cTempContact.Relation.PrevContactS.Add(LastContactS[i]);


                m_lTempContacts.Add(cTempContact);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, false);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].ContactS.Add(cTempContact);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewCoilRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);

                CCoil cTempCoil = new CCoil();
                CContent cTempContent = new CContent();

                if (CheckIsConstant(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.Constant;
                    cTempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.LogicTag;
                    cTempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    cTempContent.ArgumentType = EMArgumentType.None;
                    cTempContent.Argument = sAddress;
                }
                else
                {
                    cTempContent.ArgumentType = EMArgumentType.Tag;
                    cTempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                cTempContent.Parameter = sNodedata;

                cTempCoil.ContentS.Add(cTempContent);

                cTempCoil.CoilType = EMCoilType.Bit;

                switch (sLogicType)
                {
                    case "=":
                    case "=I":
                        cTempCoil.Instruction = EMContactTypeBit.Open.ToString();
                        break;
                    case "S":
                    case "SI":
                        cTempCoil.Instruction = "SET";
                        break;
                    case "R":
                    case "RI":
                        cTempCoil.Instruction = "RESET";
                        break;
                    case "FP":
                        cTempCoil.Instruction = EMContactTypeBit.PulseOnOpen.ToString();
                        break;
                    case "FN":
                        cTempCoil.Instruction = EMContactTypeBit.PulseOnClose.ToString();
                        break;
                    default:
                        cTempCoil.Instruction = sLogicType;
                        break;
                }
                //cTempCoil.Instruction = sLogicType;
                cTempCoil.Command = sNodedata;
                cTempCoil.StepIndex = m_iOperitionIndex;
                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    cTempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    cTempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(cTempCoil);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(cTempCoil);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return iOperationNum;
        }

        private void NewLocalPartAnalysis(List<string> FilePart, string sLogicType, int iAnalysisPointer, string sNodedata, bool isInitial, List<int> LastContactS, List<int> LastCoilS, ref List<int> PartLastConS, ref List<int> PartLastCoiS)
        {
            try
            {
                List<string> partStart = new List<string> { "A(", "O(", "AN(", "ON(" };
                int iLevel = 1;
                int iCount = FilePart.Count;

                bool isInitialtemp = isInitial;

                List<int> tempLastContactS = new List<int>();
                List<int> tempLastCoilS = new List<int>();

                if (partStart.Contains(sLogicType))
                {
                    for (int i = iAnalysisPointer + 1; i < iCount; i++)
                    {
                        sNodedata = FilePart[i];
                        sNodedata = NodedataEdit(sNodedata);
                        string sTempLogicType = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);
                        string sComment = FindComment(sNodedata);

                        if (partStart.Contains(sTempLogicType) || sTempLogicType == "MCR(")
                        {
                            if (partStart.Contains(sTempLogicType))
                            {
                                iLevel = iLevel + 1;
                            }
                            List<int> tempPreContact = new List<int>();
                            List<int> tempPreCoil = new List<int>();

                            if (sTempLogicType == "O(" || sTempLogicType == "ON(")
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }
                            else if (tempLastCoilS.Count > 0 || tempLastContactS.Count > 0)
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;
                                tempLastContactS.Clear();

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempLastCoilS.Clear();
                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }
                            else
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;
                                tempLastContactS.Clear();

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempLastCoilS.Clear();
                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }

                            tempPreContact.Clear();
                            tempPreCoil.Clear();

                            i = m_iAnalysisPointer;
                            isInitial = false;

                            if (i < iCount - 1)
                            {
                                sNodedata = FilePart[i + 1];
                                sNodedata = NodedataEdit(sNodedata);
                                sTempLogicType = LogicTypeCheck(sNodedata);

                                if (sTempLogicType == "O" || sTempLogicType == "ON" || sTempLogicType == "O(" || sTempLogicType == "ON(" || sTempLogicType == "=" || sTempLogicType == "S" || sTempLogicType == "R" || sTempLogicType == "T")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                }
                                else if (sTempLogicType == ")")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                }
                            }

                        }
                        else if (sTempLogicType == ")")
                        {
                            iLevel = iLevel - 1;
                            if (iLevel == 0)
                            {
                                m_iAnalysisPointer = i;


                                break;
                            }
                        }
                        else
                        {
                            //if (i == iAnalysisPointer + 1)
                            //{
                            //    int relCount = LastContactS.Count;
                            //    for (int j = 0; j < relCount; j++)
                            //        tempLastContactS.Add(LastContactS[j]);
                            //
                            //    relCount = LastCoilS.Count;
                            //    for (int j = 0; j < relCount; j++)
                            //        tempLastCoilS.Add(LastCoilS[j]);
                            //}

                            int iLastOpertion = -1;

                            if (m_lSimpleCantactType.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewSimpleContactRelAnalysis(sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewSimpleContactRelAnalysis(sTempLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS);

                                isInitial = false;
                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastContactS.Add(iLastOpertion);
                            }
                            else if (m_lSimpleCoilType.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewSimpleCoilRelAnalysis(sTempLogicType, i, sNodedata, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewSimpleCoilRelAnalysis(sTempLogicType, i, sNodedata, tempLastContactS, tempLastCoilS);

                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (CheckIsLocalMemAdd(sAddress) && sTempLogicType == "=")
                            {
                                NewLocalMemoryAnalysis(sAddress, sComment, PartLastConS, PartLastCoiS);
                            }
                            else if (CheckIsCallCoil(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewProgramChontrolRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewProgramChontrolRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (m_lLogicControlList.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewJumpRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewJumpRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (CheckIsConTact(sTempLogicType))
                            {
                                if (CheckIsCounter(FilePart, i))
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewCounterRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewCounterRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastCoilS.Add(iLastOpertion);
                                }
                                else if (CheckIsTimer(FilePart, i))
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewTimeRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewTimeRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastCoilS.Add(iLastOpertion);
                                }
                                else if (sTempLogicType == "L")
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewLoadLogicRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewLoadLogicRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                    isInitial = false;
                                    if (CheckIsCompare(FilePart, i))
                                    {
                                        tempLastContactS.Clear();
                                        tempLastCoilS.Clear();
                                        tempLastContactS.Add(iLastOpertion);
                                    }
                                    else
                                    {
                                        tempLastContactS.Clear();
                                        tempLastCoilS.Clear();
                                        tempLastCoilS.Add(iLastOpertion);
                                    }
                                }
                                else
                                {
                                    if (sTempLogicType == "O" || sTempLogicType == "ON")
                                    {
                                        if (sAddress == "")
                                        {
                                            //i = i + 1;
                                            //sNodedata = FilePart[i];
                                            //sNodedata = NodedataEdit(sNodedata);
                                            //sTempLogicType = LogicTypeCheck(sNodedata);
                                            //sAddress = FindAddress(sNodedata);
                                            //sComment = FindComment(sNodedata);
                                            //iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment,isInitial, LastContactS, LastCoilS);

                                            isInitial = isInitialtemp;
                                            //tempLastContactS.Add(iLastOpertion);
                                        }
                                        else
                                        {
                                            isInitial = isInitialtemp;
                                            if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                            else
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                            isInitial = false;
                                            tempLastContactS.Add(iLastOpertion);
                                        }
                                    }
                                    else if (sTempLogicType == "A" || sTempLogicType == "AN")
                                    {
                                        if (CheckIsLocalMemAdd(sAddress))
                                        {
                                            NewLocalMemoryRelCheck(sAddress, ref tempLastContactS, ref tempLastCoilS);
                                        }
                                        else
                                        {
                                            if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                            else
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                            isInitial = false;
                                            tempLastContactS.Clear();
                                            tempLastContactS.Add(iLastOpertion);
                                        }
                                    }

                                }
                            }
                            else if (CheckIsCoil(sTempLogicType))
                            {
                                iLastOpertion = NewCoilRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, PartLastConS, PartLastCoiS);
                                tempLastCoilS.Add(iLastOpertion);
                            }

                            if (i < m_iAnalysisPointer)
                                i = m_iAnalysisPointer;
                            else
                                m_iAnalysisPointer = i;

                            if (i < iCount - 1)
                            {
                                sNodedata = FilePart[i + 1];
                                sNodedata = NodedataEdit(sNodedata);
                                sTempLogicType = LogicTypeCheck(sNodedata);

                                if (sTempLogicType == "O" || sTempLogicType == "ON" || sTempLogicType == "O(" || sTempLogicType == "ON(" || sTempLogicType == "=" || sTempLogicType == "S" || sTempLogicType == "R" || sTempLogicType == "T")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    tempLastContactS.Clear();
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                    tempLastCoilS.Clear();
                                }
                                else if (sTempLogicType == ")")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (sLogicType == "MCR(")
                {
                    for (int i = iAnalysisPointer + 1; i < iCount; i++)
                    {
                        sNodedata = FilePart[i];
                        sNodedata = NodedataEdit(sNodedata);
                        string sTempLogicType = LogicTypeCheck(sNodedata);
                        string sAddress = FindAddress(sNodedata);
                        string sComment = FindComment(sNodedata);

                        if (partStart.Contains(sTempLogicType) || sTempLogicType == "MCR(")
                        {
                            if (sTempLogicType == "MCR(")
                            {
                                iLevel = iLevel + 1;
                            }

                            List<int> tempPreContact = new List<int>();
                            List<int> tempPreCoil = new List<int>();

                            if (sTempLogicType == "O(" || sTempLogicType == "ON(")
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }
                            else if (tempLastCoilS.Count > 0 || tempLastContactS.Count > 0)
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;
                                tempLastContactS.Clear();

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempLastCoilS.Clear();
                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }
                            else
                            {
                                NewLocalPartAnalysis(FilePart, sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS, ref tempPreContact, ref tempPreCoil);
                                int tempCount = tempPreContact.Count;
                                tempLastContactS.Clear();

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastContactS.Add(tempPreContact[j]);
                                }

                                tempLastCoilS.Clear();
                                tempCount = tempPreCoil.Count;

                                for (int j = 0; j < tempCount; j++)
                                {
                                    tempLastCoilS.Add(tempPreCoil[j]);
                                }
                            }

                            tempPreContact.Clear();
                            tempPreCoil.Clear();

                            i = m_iAnalysisPointer;
                            isInitial = false;

                            if (i < iCount - 1)
                            {
                                sNodedata = FilePart[i + 1];
                                sNodedata = NodedataEdit(sNodedata);
                                sTempLogicType = LogicTypeCheck(sNodedata);

                                if (sTempLogicType == "O" || sTempLogicType == "ON" || sTempLogicType == "O(" || sTempLogicType == "ON(" || sTempLogicType == "=" || sTempLogicType == "S" || sTempLogicType == "R" || sTempLogicType == "T")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }

                                }
                                else if (sTempLogicType == ")")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                }
                            }
                        }
                        else if (sTempLogicType == ")MCR")
                        {
                            iLevel = iLevel - 1;
                            if (iLevel == 0)
                            {
                                m_iAnalysisPointer = i;
                                break;
                            }
                        }
                        else
                        {

                            //if (i == iAnalysisPointer + 1)
                            //{
                            //    int relCount = LastContactS.Count;
                            //    for (int j = 0; j < relCount; j++)
                            //        tempLastContactS.Add(LastContactS[j]);

                            //    relCount = LastCoilS.Count;
                            //    for (int j = 0; j < relCount; j++)
                            //        tempLastCoilS.Add(LastCoilS[j]);
                            //}

                            int iLastOpertion = -1;

                            if (m_lSimpleCantactType.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewSimpleContactRelAnalysis(sTempLogicType, i, sNodedata, isInitial, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewSimpleContactRelAnalysis(sTempLogicType, i, sNodedata, isInitial, tempLastContactS, tempLastCoilS);

                                isInitial = false;
                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastContactS.Add(iLastOpertion);
                            }
                            else if (m_lSimpleCoilType.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewSimpleCoilRelAnalysis(sTempLogicType, i, sNodedata, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewSimpleCoilRelAnalysis(sTempLogicType, i, sNodedata, tempLastContactS, tempLastCoilS);

                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (CheckIsLocalMemAdd(sAddress) && sTempLogicType == "=")
                            {
                                NewLocalMemoryAnalysis(sAddress, sComment, PartLastConS, PartLastCoiS);
                            }
                            else if (CheckIsCallCoil(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewProgramChontrolRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewProgramChontrolRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                tempLastContactS.Clear();
                                tempLastCoilS.Clear();
                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (m_lLogicControlList.Contains(sTempLogicType))
                            {
                                if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                    iLastOpertion = NewJumpRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                else
                                    iLastOpertion = NewJumpRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                tempLastCoilS.Add(iLastOpertion);
                            }
                            else if (CheckIsConTact(sTempLogicType))
                            {
                                if (CheckIsCounter(FilePart, i))
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewCounterRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewCounterRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastCoilS.Add(iLastOpertion);
                                }
                                else if (CheckIsTimer(FilePart, i))
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewTimeRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewTimeRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, tempLastContactS, tempLastCoilS);

                                    tempLastContactS.Clear();
                                    tempLastCoilS.Clear();
                                    tempLastCoilS.Add(iLastOpertion);
                                }
                                else if (sTempLogicType == "L")
                                {
                                    if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                        iLastOpertion = NewLoadLogicRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                    else
                                        iLastOpertion = NewLoadLogicRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                    isInitial = false;
                                    if (CheckIsConverter(FilePart, i))
                                    {
                                        tempLastContactS.Clear();
                                        tempLastCoilS.Clear();
                                        tempLastContactS.Add(iLastOpertion);
                                    }
                                    else
                                    {
                                        tempLastContactS.Clear();
                                        tempLastCoilS.Clear();
                                        tempLastCoilS.Add(iLastOpertion);
                                    }
                                }
                                else
                                {
                                    if (sTempLogicType == "O" || sTempLogicType == "ON")
                                    {
                                        if (sAddress == "")
                                        {
                                            //i = i + 1;
                                            //sNodedata = FilePart[i];
                                            //sNodedata = NodedataEdit(sNodedata);
                                            //sTempLogicType = LogicTypeCheck(sNodedata);
                                            //sAddress = FindAddress(sNodedata);
                                            //sComment = FindComment(sNodedata);
                                            //iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment,isInitial, LastContactS, LastCoilS);
                                            isInitial = isInitialtemp;
                                            //tempLastContactS.Add(iLastOpertion);
                                        }
                                        else
                                        {
                                            isInitial = isInitialtemp;
                                            if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                            else
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                            isInitial = false;
                                            tempLastContactS.Add(iLastOpertion);
                                        }
                                    }
                                    else if (sTempLogicType == "A" || sTempLogicType == "AN")
                                    {
                                        if (CheckIsLocalMemAdd(sAddress))
                                        {
                                            NewLocalMemoryRelCheck(sAddress, ref tempLastContactS, ref tempLastCoilS);
                                        }
                                        else
                                        {
                                            if (tempLastContactS.Count == 0 && tempLastCoilS.Count == 0)
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, LastContactS, LastCoilS);
                                            else
                                                iLastOpertion = NewContactRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, isInitial, tempLastContactS, tempLastCoilS);

                                            isInitial = false;
                                            tempLastContactS.Clear();
                                            tempLastContactS.Add(iLastOpertion);
                                        }
                                    }
                                }
                            }
                            else if (CheckIsCoil(sTempLogicType))
                            {
                                iLastOpertion = NewCoilRelAnalysis(FilePart, i, sAddress, sTempLogicType, sComment, PartLastConS, PartLastCoiS);
                                tempLastCoilS.Add(iLastOpertion);
                            }

                            if (i < m_iAnalysisPointer)
                                i = m_iAnalysisPointer;
                            else
                                m_iAnalysisPointer = i;

                            if (i < iCount - 1)
                            {
                                sNodedata = FilePart[i + 1];
                                sNodedata = NodedataEdit(sNodedata);
                                sTempLogicType = LogicTypeCheck(sNodedata);

                                if (sTempLogicType == "O" || sTempLogicType == "ON" || sTempLogicType == "O(" || sTempLogicType == "ON(" || sTempLogicType == "=" || sTempLogicType == "S" || sTempLogicType == "R" || sTempLogicType == "T")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    tempLastContactS.Clear();
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                    tempLastCoilS.Clear();
                                }
                                else if (sTempLogicType == ")")
                                {
                                    int relationCount = tempLastContactS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastConS.Contains(tempLastContactS[j]))
                                        {
                                            PartLastConS.Add(tempLastContactS[j]);
                                        }
                                    }
                                    relationCount = tempLastCoilS.Count;

                                    for (int j = 0; j < relationCount; j++)
                                    {
                                        if (!PartLastCoiS.Contains(tempLastCoilS[j]))
                                            PartLastCoiS.Add(tempLastCoilS[j]);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private int NewCompareRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, bool isInitial, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                string sPare = sNodedata;
                m_lTempContents = new CContentS();

                while (!m_lCompareList.Contains(sLogicType))
                {
                    CContent cTempContent = new CContent();

                    if (CheckIsConstant(sAddress))
                    {
                        cTempContent.ArgumentType = EMArgumentType.Constant;
                        cTempContent.Argument = sAddress;
                    }
                    else if (CheckIsInternel(sAddress))
                    {
                        cTempContent.ArgumentType = EMArgumentType.LogicTag;
                        cTempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        cTempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }
                    else if (m_lSpecialAddress.Contains(sAddress))
                    {
                        cTempContent.ArgumentType = EMArgumentType.None;
                        cTempContent.Argument = sAddress;
                    }
                    else
                    {
                        cTempContent.ArgumentType = EMArgumentType.Tag;
                        cTempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        cTempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }

                    cTempContent.Parameter = sNodedata;

                    m_lTempContents.Add(cTempContent);

                    iAnalysisPointer = iAnalysisPointer + 1;

                    sNodedata = FilePart[iAnalysisPointer];
                    sNodedata = NodedataEdit(sNodedata);
                    sPare = sPare + sNodedata;

                    sComment = FindComment(sNodedata);
                    sAddress = FindAddress(sNodedata);
                    sLogicType = LogicTypeCheck(sNodedata);
                }

                CContact tempContact = new CContact();
                int iCount = m_lTempContents.Count;
                tempContact.IsInitial = isInitial;

                for (int i = 0; i < iCount; i++)
                {
                    tempContact.ContentS.Add(m_lTempContents[i]);
                }

                switch (sLogicType)
                {
                    case "==I": tempContact.Instruction = EMContactTypeCompare.Equal.ToString();
                        tempContact.Operator = EMContactTypeCompare.Equal.ToString();
                        break;
                    case "<>I": tempContact.Instruction = EMContactTypeCompare.EqualNot.ToString();
                        tempContact.Operator = EMContactTypeCompare.EqualNot.ToString();
                        break;
                    case ">I": tempContact.Instruction = EMContactTypeCompare.Large.ToString();
                        tempContact.Operator = EMContactTypeCompare.Large.ToString();
                        break;
                    case "<I": tempContact.Instruction = EMContactTypeCompare.Small.ToString();
                        tempContact.Operator = EMContactTypeCompare.Small.ToString();
                        break;
                    case ">=I": tempContact.Instruction = EMContactTypeCompare.LargeEqual.ToString();
                        tempContact.Operator = EMContactTypeCompare.LargeEqual.ToString();
                        break;
                    case "<=I": tempContact.Instruction = EMContactTypeCompare.SmallEqual.ToString();
                        tempContact.Operator = EMContactTypeCompare.SmallEqual.ToString();
                        break;
                    case "==R":
                    case "==D": tempContact.Instruction = EMContactTypeCompare.DWordEqual.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordEqual.ToString();
                        break;
                    case "<>D":
                    case "<>R": tempContact.Instruction = EMContactTypeCompare.DWordEqualNot.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordEqualNot.ToString();
                        break;
                    case ">D":
                    case ">R": tempContact.Instruction = EMContactTypeCompare.DWordLarge.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordLarge.ToString();
                        break;
                    case "<D":
                    case "<R": tempContact.Instruction = EMContactTypeCompare.DWordSmall.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordSmall.ToString();
                        break;
                    case ">=D":
                    case ">=R": tempContact.Instruction = EMContactTypeCompare.DWordLargeEqual.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordLargeEqual.ToString();
                        break;
                    case "<=D":
                    case "<=R": tempContact.Instruction = EMContactTypeCompare.DWordSmallEqual.ToString();
                        tempContact.Operator = EMContactTypeCompare.DWordSmallEqual.ToString();
                        break;
                }
                tempContact.Operator = sPare;
                tempContact.ContactType = EMContactType.Compare;
                tempContact.StepIndex = m_iOperitionIndex;
                iOperationNum = m_iOperitionIndex;

                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempContact.Relation.PrevCoilS.Add(LastCoilS[i]);
                }

                iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                    tempContact.Relation.PrevContactS.Add(LastContactS[i]);

                m_iOperitionIndex = m_iOperitionIndex + 1;
                ConnectToLast(iOperationNum, LastContactS, LastCoilS, false);

                m_lTempContacts.Add(tempContact);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].ContactS.Add(tempContact);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
                m_lTempContents.Clear();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewConverterRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                string sPare = sNodedata;

                CCoil tempCoil = new CCoil();

                CContent cSource = new CContent();
                if (CheckIsConstant(sAddress))
                {
                    cSource.ArgumentType = EMArgumentType.Constant;
                    cSource.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    cSource.ArgumentType = EMArgumentType.LogicTag;
                    cSource.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cSource.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    cSource.ArgumentType = EMArgumentType.None;
                    cSource.Argument = sAddress;
                }
                else
                {
                    cSource.ArgumentType = EMArgumentType.Tag;
                    cSource.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cSource.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                cSource.Parameter = sNodedata;

                tempCoil.ContentS.Add(cSource);


                while (sLogicType != "T")
                {
                    iAnalysisPointer = iAnalysisPointer + 1;

                    sNodedata = FilePart[iAnalysisPointer];
                    sNodedata = NodedataEdit(sNodedata);
                    sPare = sPare + sNodedata;
                    sLogicType = LogicTypeCheck(sNodedata);
                }

                sAddress = FindAddress(sNodedata);
                sComment = FindComment(sNodedata);

                CContent cTarget = new CContent();

                if (CheckIsConstant(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.Constant;
                    cTarget.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.LogicTag;
                    cTarget.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTarget.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.None;
                    cTarget.Argument = sAddress;
                }
                else
                {
                    cTarget.ArgumentType = EMArgumentType.Tag;
                    cTarget.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTarget.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                cTarget.Parameter = sNodedata;

                tempCoil.CoilType = EMCoilType.Math;
                tempCoil.Instruction = sPare;
                tempCoil.Command = sPare;

                tempCoil.StepIndex = m_iOperitionIndex;
                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return iOperationNum;
        }

        private int NewComputerRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                string sPare = sNodedata;
                CContent cSource = null;
                CTag tag = null;
                CCoil tempCoil = new CCoil();

                while (sLogicType == "L")
                {
                    cSource = new CContent();

                    if (CheckIsConstant(sAddress))
                    {
                        cSource.ArgumentType = EMArgumentType.Constant;
                        cSource.Argument = sAddress;
                    }
                    else if (CheckIsInternel(sAddress))
                    {
                        cSource.ArgumentType = EMArgumentType.LogicTag;
                        cSource.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        cSource.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }
                    else if (m_lSpecialAddress.Contains(sAddress))
                    {
                        cSource.ArgumentType = EMArgumentType.None;
                        cSource.Argument = sAddress;
                    }
                    else
                    {
                        cSource.ArgumentType = EMArgumentType.Tag;
                        cSource.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        cSource.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }

                    cSource.Parameter = sNodedata;

                    tempCoil.ContentS.Add(cSource);

                    iAnalysisPointer = iAnalysisPointer + 1;

                    sNodedata = FilePart[iAnalysisPointer];
                    sNodedata = NodedataEdit(sNodedata);
                    sPare = sPare + sNodedata;
                    sLogicType = LogicTypeCheck(sNodedata);
                    sAddress = FindAddress(sNodedata);
                    sComment = FindComment(sNodedata);
                }

                if (m_lComputerList.Contains(sLogicType) || m_lWordLogicList.Contains(sLogicType) || m_lAccumList.Contains(sLogicType))
                {
                    tempCoil.CoilType = EMCoilType.Math;
                    tempCoil.Instruction = sLogicType;
                }
                else if (m_lCyclicShiftList.Contains(sLogicType))
                {
                    tempCoil.CoilType = EMCoilType.Shift;
                    tempCoil.Instruction = sLogicType;
                }

                iAnalysisPointer = iAnalysisPointer + 1;

                sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                sPare = sPare + sNodedata;
                sLogicType = LogicTypeCheck(sNodedata);
                sAddress = FindAddress(sNodedata);
                sComment = FindComment(sNodedata);

                CContent cTarget = new CContent();

                if (CheckIsConstant(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.Constant;
                    cTarget.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.LogicTag;
                    cTarget.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTarget.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    cTarget.ArgumentType = EMArgumentType.None;
                    cTarget.Argument = sAddress;
                }
                else
                {
                    cTarget.ArgumentType = EMArgumentType.Tag;
                    cTarget.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    cTarget.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                cTarget.Parameter = sNodedata;

                tempCoil.ContentS.Add(cTarget);

                tempCoil.Command = sPare;

                tempCoil.StepIndex = m_iOperitionIndex;
                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewMoveRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                string sPare = sNodedata;
                CContent TempContent = new CContent();

                if (CheckIsConstant(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.Constant;
                    TempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.None;
                    TempContent.Argument = sAddress;
                }
                else
                {
                    TempContent.ArgumentType = EMArgumentType.Tag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                TempContent.Parameter = sNodedata;

                CCoil tempCoil = new CCoil();
                tempCoil.CoilType = EMCoilType.Move;

                tempCoil.ContentS.Add(TempContent);

                iAnalysisPointer = iAnalysisPointer + 1;

                sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);
                sPare = sPare + sNodedata;

                sComment = FindComment(sNodedata);
                sAddress = FindAddress(sNodedata);
                sLogicType = LogicTypeCheck(sNodedata);

                if (CheckIsConstant(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.Constant;
                    TempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.None;
                    TempContent.Argument = sAddress;
                }
                else
                {
                    TempContent.ArgumentType = EMArgumentType.Tag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                TempContent.Parameter = sNodedata;

                tempCoil.ContentS.Add(TempContent);

                tempCoil.Instruction = sPare;
                tempCoil.Command = sComment;
                tempCoil.CoilType = EMCoilType.Move;
                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewTimeRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                int iCount = FilePart.Count;
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);

                CCoil tempCoil = new CCoil();
                CContent TempContent = new CContent();
                string sCoilType = string.Empty;

                if (CheckIsConstant(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.Constant;
                    TempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.None;
                    TempContent.Argument = sAddress;
                }
                else
                {
                    TempContent.ArgumentType = EMArgumentType.Tag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                TempContent.Parameter = sNodedata;

                tempCoil.ContentS.Add(TempContent);

                for (int i = iAnalysisPointer + 1; i < iCount; i++)
                {
                    sNodedata = FilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    sAddress = FindAddress(sNodedata);
                    sLogicType = LogicTypeCheck(sNodedata);
                    sComment = FindComment(sNodedata);

                    if (m_lTimerCountList.Contains(sLogicType))
                        sCoilType = sLogicType;

                    if (sLogicType == "A" || sLogicType == "AN")
                    {
                        if (sAddress.StartsWith("T"))
                        {
                            iAnalysisPointer = i - 1;
                            break;
                        }
                    }                   

                    TempContent = new CContent();
                    if (CheckIsConstant(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.Constant;
                        TempContent.Argument = sAddress;
                    }
                    else if (CheckIsInternel(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.LogicTag;
                        TempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        TempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }
                    else if (m_lSpecialAddress.Contains(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.None;
                        TempContent.Argument = sAddress;
                    }
                    else
                    {
                        TempContent.ArgumentType = EMArgumentType.Tag;
                        TempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        TempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }

                    TempContent.Parameter = sNodedata;
                    tempCoil.ContentS.Add(TempContent);
                }

                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;
                tempCoil.Instruction = sCoilType;
                tempCoil.CoilType = EMCoilType.Timer;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    int iCount1 = m_lJumpLable.Count;

                    for (int i = 0; i < iCount1; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewCounterRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                int iCount = FilePart.Count;
                string sNodedata = FilePart[iAnalysisPointer];
                sNodedata = NodedataEdit(sNodedata);

                CCoil tempCoil = new CCoil();
                CContent TempContent = new CContent();
                string sCoilType = string.Empty;
                if (CheckIsConstant(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.Constant;
                    TempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.None;
                    TempContent.Argument = sAddress;
                }
                else
                {
                    TempContent.ArgumentType = EMArgumentType.Tag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                TempContent.Parameter = sNodedata;
                tempCoil.ContentS.Add(TempContent);

                for (int i = iAnalysisPointer + 1; i < iCount; i++)
                {
                    sNodedata = FilePart[i];
                    sNodedata = NodedataEdit(sNodedata);

                    sAddress = FindAddress(sNodedata);
                    sLogicType = LogicTypeCheck(sNodedata);
                    sComment = FindComment(sNodedata);

                    if (m_lTimerCountList.Contains(sLogicType))
                    {
                        if (sCoilType == string.Empty)
                        {
                            sCoilType = sLogicType;
                        }
                        else if (sLogicType == "CU")
                        {
                            if (sCoilType == "CD")
                                sCoilType = "CU_CD";
                            else
                                sCoilType = "CU";
                        }
                        else if (sLogicType == "CD")
                        {
                            if (sCoilType == "CU")
                                sCoilType = "CU_CD";
                            else
                                sCoilType = "CD";
                        }
                    }

                    if (sLogicType == "A" || sLogicType == "AN")
                    {
                        if (sAddress.StartsWith("T"))
                        {
                            iAnalysisPointer = i - 1;
                            break;
                        }
                    }

                    TempContent = new CContent();
                    if (CheckIsConstant(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.Constant;
                        TempContent.Argument = sAddress;
                    }
                    else if (CheckIsInternel(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.LogicTag;
                        TempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        TempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }
                    else if (m_lSpecialAddress.Contains(sAddress))
                    {
                        TempContent.ArgumentType = EMArgumentType.None;
                        TempContent.Argument = sAddress;
                    }
                    else
                    {
                        TempContent.ArgumentType = EMArgumentType.Tag;
                        TempContent.Argument = sAddress;

                        CTag cTempTag = FindTag(sAddress, false);
                        TempContent.Tag = cTempTag;
                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                    }

                    TempContent.Parameter = sNodedata;
                    tempCoil.ContentS.Add(TempContent);
                    iAnalysisPointer = i;
                }

                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);


                m_iOperitionIndex = m_iOperitionIndex + 1;
                tempCoil.CoilType = EMCoilType.Counter;
                tempCoil.Instruction = sCoilType;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    int iCount1 = m_lJumpLable.Count;

                    for (int i = 0; i < iCount1; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewJumpRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sNodedata = FilePart[iAnalysisPointer];

                CContent tempContent = new CContent();
                tempContent.Argument = sAddress;
                tempContent.ArgumentType = EMArgumentType.None;
                tempContent.Parameter = sComment;

                CCoil tempCoil = new CCoil();
                tempCoil.ContentS.Add(tempContent);
                tempCoil.Instruction = sNodedata;
                tempCoil.Command = sComment;

                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewProgramChontrolRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                if (sLogicType == "CALL" || sLogicType == "CC" || sLogicType == "UC")
                {
                    //CCoil cTempCoil = null;
                    CContent TempContent = null;
                    //cTempCoil = new CCoil();

                    CContact cTempContact = new CContact();

                    string sNodedata = FilePart[iAnalysisPointer];
                    sNodedata = NodedataEdit(sNodedata);
                    if (sNodedata.Contains("("))
                    {

                        string sDBName = null;
                        string sFBName = null;
                        if (sAddress.Contains(","))
                        {
                            int iPos = sAddress.IndexOf(",");
                            if (sAddress[iPos + 1] == 'D' && sAddress[iPos + 2] == 'B')
                            {
                                sDBName = sAddress.Substring(iPos + 1);
                                sAddress = sAddress.Remove(iPos);
                                sDBName = AddressEdittor(sDBName);
                                sAddress = AddressEdittor(sAddress);

                                TempContent = new CContent();
                                CTag temptag = FindTag(sDBName, true);
                                TempContent.Argument = sDBName;
                                TempContent.Tag = temptag;

                                cTempContact.ContentS.Add(TempContent);
                            }
                        }
                        CS7Block tempBlock = FindBlock(sAddress);
                        if (tempBlock != null)
                        {
                            sFBName = tempBlock.BlockName;
                        }
                        else
                            sFBName = sAddress;

                        CTagS InputTagS = null;
                        CTagS OutputTagS = null;
                        CTagS InOutTagS = null;

                        if (tempBlock != null)
                        {
                            InputTagS = tempBlock.InputTags;
                            OutputTagS = tempBlock.OutputTags;
                            InOutTagS = tempBlock.InOUtTags;
                        }

                        TempContent = new CContent();
                        string sPar = sNodedata;

                        if (CheckIsConstant(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.Constant;
                            TempContent.Argument = sAddress;
                        }
                        else if (CheckIsInternel(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.LogicTag;
                            TempContent.Argument = sAddress;

                            CTag cTempTag = FindTag(sAddress, false);
                            TempContent.Tag = cTempTag;
                            m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                        }
                        else if (m_lSpecialAddress.Contains(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.None;
                            TempContent.Argument = sAddress;
                        }
                        else
                        {
                            TempContent.ArgumentType = EMArgumentType.Tag;
                            TempContent.Argument = sAddress;

                            CTag cTempTag = FindTag(sAddress, false);
                            TempContent.Tag = cTempTag;
                            m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                        }

                        TempContent.Parameter = sNodedata;

                        cTempContact.ContentS.Add(TempContent);
                        cTempContact.ContactType = EMContactType.Function;
                        cTempContact.Instruction = sFBName;

                        iAnalysisPointer = iAnalysisPointer + 1;
                        sNodedata = FilePart[iAnalysisPointer];

                        while (!sNodedata.EndsWith(");"))
                        {

                            sNodedata = NodedataEdit(sNodedata);

                            sPar = sPar + sNodedata;

                            int iPos = sNodedata.IndexOf(":=");
                            string sIndu = sNodedata.Remove(iPos);
                            sIndu = NodedataEdit(sIndu);

                            sAddress = sNodedata.Substring(iPos + 2);
                            sAddress = AddressEdittor(sAddress);

                            if (CheckIsLocalMemAdd(sAddress))
                            {
                                if (m_dLocalMem.ContainsKey(sAddress))
                                {
                                    CS7LocalMem tempContactS = m_dLocalMem[sAddress];
                                    int iConCount = tempContactS.TotalContactS.Count;

                                    for (int i = 0; i < iConCount; i++)
                                    {
                                        tempContactS.TotalContactS[i].Operator = sFBName + "." + sIndu;
                                        tempContactS.TotalContactS[i].Instruction = sFBName + "." + sIndu;
                                        tempContactS.TotalContactS[i].ContactType = EMContactType.Function;
                                    }
                                }

                            }
                            else if (InputTagS != null)
                            {
                                if (InputTagS.ContainsKey("." + sIndu))
                                {
                                    TempContent = new CContent();
                                    if (CheckIsConstant(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.Constant;
                                        TempContent.Argument = sAddress;
                                    }
                                    else if (CheckIsInternel(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.LogicTag;
                                        TempContent.Argument = sAddress;

                                        CTag cTempTag = FindTag(sAddress, false);
                                        TempContent.Tag = cTempTag;
                                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                    }
                                    else if (m_lSpecialAddress.Contains(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.None;
                                        TempContent.Argument = sAddress;
                                    }
                                    else
                                    {
                                        TempContent.ArgumentType = EMArgumentType.Tag;
                                        TempContent.Argument = sAddress;

                                        CTag cTempTag = FindTag(sAddress, false);
                                        TempContent.Tag = cTempTag;
                                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                    }

                                    TempContent.Parameter = sNodedata;

                                    CContact TempContact = new CContact();
                                    TempContact.ContactType = EMContactType.Function;
                                    TempContact.Instruction = sFBName + "." + sIndu;
                                    TempContact.Operator = sFBName + "." + sIndu;
                                    TempContact.ContentS.Add(TempContent);
                                    TempContact.StepIndex = m_iOperitionIndex;
                                    m_iOperitionIndex = m_iOperitionIndex + 1;

                                    m_lTempContacts.Add(TempContact);

                                    if (m_lJumpLable.Count > 0)
                                    {
                                        int iCount = m_lJumpLable.Count;

                                        for (int i = 0; i < iCount; i++)
                                        {
                                            string label = m_lJumpLable[i];
                                            m_dJumpDic[label].ContactS.Add(TempContact);
                                        }
                                    }
                                }
                                else if (InOutTagS.ContainsKey("." + sIndu) || OutputTagS.ContainsKey("." + sIndu))
                                {                                  

                                    TempContent = new CContent();
                                    if (CheckIsConstant(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.Constant;
                                        TempContent.Argument = sAddress;
                                    }
                                    else if (CheckIsInternel(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.LogicTag;
                                        TempContent.Argument = sAddress;

                                        CTag cTempTag = FindTag(sAddress, false);
                                        TempContent.Tag = cTempTag;
                                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                    }
                                    else if (m_lSpecialAddress.Contains(sAddress))
                                    {
                                        TempContent.ArgumentType = EMArgumentType.None;
                                        TempContent.Argument = sAddress;
                                    }
                                    else
                                    {
                                        TempContent.ArgumentType = EMArgumentType.Tag;
                                        TempContent.Argument = sAddress;

                                        CTag cTempTag = FindTag(sAddress, false);
                                        TempContent.Tag = cTempTag;
                                        m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                    }

                                    TempContent.Parameter = sNodedata;

                                    CCoil subCoil = new CCoil();
                                    subCoil.CoilType = EMCoilType.ProgramControl;
                                    subCoil.Instruction = sFBName + "." + sIndu;
                                    subCoil.StepIndex = m_iOperitionIndex;
                                    m_iOperitionIndex = m_iOperitionIndex + 1;
                                    subCoil.ContentS.Add(TempContent);

                                    m_cTempStep.CoilS.Add(subCoil);

                                    if (m_lJumpLable.Count > 0)
                                    {
                                        int iCount = m_lJumpLable.Count;

                                        for (int i = 0; i < iCount; i++)
                                        {
                                            string label = m_lJumpLable[i];
                                            m_dJumpDic[label].CoilS.Add(subCoil);
                                        }
                                    }
                                }
                            }

                            TempContent = new CContent();
                            if (CheckIsConstant(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.Constant;
                                TempContent.Argument = sAddress;
                            }
                            else if (CheckIsInternel(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.LogicTag;
                                TempContent.Argument = sAddress;

                                CTag cTempTag = FindTag(sAddress, false);
                                TempContent.Tag = cTempTag;
                                m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                            }
                            else if (m_lSpecialAddress.Contains(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.None;
                                TempContent.Argument = sAddress;
                            }
                            else
                            {
                                TempContent.ArgumentType = EMArgumentType.Tag;
                                TempContent.Argument = sAddress;

                                CTag cTempTag = FindTag(sAddress, false);
                                TempContent.Tag = cTempTag;
                                m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                            }

                            TempContent.Parameter = sNodedata;

                            cTempContact.ContentS.Add(TempContent);

                            iAnalysisPointer = iAnalysisPointer + 1;
                            sNodedata = FilePart[iAnalysisPointer];

                            if (sNodedata.Contains("//"))
                            {
                                int ConmentiPos = sNodedata.IndexOf("//");
                                sComment = sNodedata.Substring(ConmentiPos + 2);
                                sNodedata = sNodedata.Remove(ConmentiPos);
                            }

                            sNodedata = NodedataEdit(sNodedata);

                        }
                        sPar = sPar + sNodedata;


                        int iPos1 = sNodedata.IndexOf(":=");
                        string sIndu1 = sNodedata.Remove(iPos1);
                        sIndu1 = NodedataEdit(sIndu1);

                        sAddress = sNodedata.Substring(iPos1 + 2);
                        sAddress = sAddress.Remove(sAddress.Length - 2);
                        sAddress = AddressEdittor(sAddress);

                        if (InputTagS != null)
                        {
                            if (InputTagS.ContainsKey("." + sIndu1))
                            {                               
                                TempContent = new CContent();
                                if (CheckIsConstant(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.Constant;
                                    TempContent.Argument = sAddress;
                                }
                                else if (CheckIsInternel(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                                    TempContent.Argument = sAddress;

                                    CTag cTempTag = FindTag(sAddress, false);
                                    TempContent.Tag = cTempTag;
                                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                }
                                else if (m_lSpecialAddress.Contains(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.None;
                                    TempContent.Argument = sAddress;
                                }
                                else
                                {
                                    TempContent.ArgumentType = EMArgumentType.Tag;
                                    TempContent.Argument = sAddress;

                                    CTag cTempTag = FindTag(sAddress, false);
                                    TempContent.Tag = cTempTag;
                                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                }

                                TempContent.Parameter = sNodedata;

                                CContact TempContact = new CContact();
                                TempContact.ContactType = EMContactType.Function;
                                TempContact.Instruction = sFBName + "." + sIndu1;
                                TempContact.Operator = sFBName + "." + sIndu1;
                                TempContact.ContentS.Add(TempContent);
                                TempContact.StepIndex = m_iOperitionIndex;

                                m_iOperitionIndex = m_iOperitionIndex + 1;

                                m_lTempContacts.Add(TempContact);

                                if (m_lJumpLable.Count > 0)
                                {
                                    int iCount = m_lJumpLable.Count;

                                    for (int i = 0; i < iCount; i++)
                                    {
                                        string label = m_lJumpLable[i];
                                        m_dJumpDic[label].ContactS.Add(TempContact);
                                    }
                                }
                            }
                            else if (InOutTagS.ContainsKey("." + sIndu1) || OutputTagS.ContainsKey("." + sIndu1))
                            {
                                TempContent = new CContent();
                                if (CheckIsConstant(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.Constant;
                                    TempContent.Argument = sAddress;
                                }
                                else if (CheckIsInternel(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                                    TempContent.Argument = sAddress;

                                    CTag cTempTag = FindTag(sAddress, false);
                                    TempContent.Tag = cTempTag;
                                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                }
                                else if (m_lSpecialAddress.Contains(sAddress))
                                {
                                    TempContent.ArgumentType = EMArgumentType.None;
                                    TempContent.Argument = sAddress;
                                }
                                else
                                {
                                    TempContent.ArgumentType = EMArgumentType.Tag;
                                    TempContent.Argument = sAddress;

                                    CTag cTempTag = FindTag(sAddress, false);
                                    TempContent.Tag = cTempTag;
                                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                                }

                                TempContent.Parameter = sNodedata;

                                CCoil subCoil = new CCoil();
                                subCoil.CoilType = EMCoilType.ProgramControl;
                                subCoil.Instruction = sFBName + "." + sIndu1;
                                subCoil.StepIndex = m_iOperitionIndex;
                                m_iOperitionIndex = m_iOperitionIndex + 1;
                                subCoil.ContentS.Add(TempContent);

                                m_cTempStep.CoilS.Add(subCoil);

                                if (m_lJumpLable.Count > 0)
                                {
                                    int iCount = m_lJumpLable.Count;

                                    for (int i = 0; i < iCount; i++)
                                    {
                                        string label = m_lJumpLable[i];
                                        m_dJumpDic[label].CoilS.Add(subCoil);
                                    }
                                }
                            }
                        }
                        else
                        {
                            TempContent = new CContent();
                            if (CheckIsConstant(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.Constant;
                                TempContent.Argument = sAddress;
                            }
                            else if (CheckIsInternel(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.LogicTag;
                                TempContent.Argument = sAddress;

                                CTag cTempTag = FindTag(sAddress, false);
                                TempContent.Tag = cTempTag;
                                m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                            }
                            else if (m_lSpecialAddress.Contains(sAddress))
                            {
                                TempContent.ArgumentType = EMArgumentType.None;
                                TempContent.Argument = sAddress;
                            }
                            else
                            {
                                TempContent.ArgumentType = EMArgumentType.Tag;
                                TempContent.Argument = sAddress;

                                CTag cTempTag = FindTag(sAddress, false);
                                TempContent.Tag = cTempTag;
                                m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                            }

                            TempContent.Parameter = sNodedata;

                            CCoil subCoil = new CCoil();
                            subCoil.CoilType = EMCoilType.ProgramControl;
                            subCoil.Instruction = sFBName + "." + sIndu1;
                            subCoil.StepIndex = m_iOperitionIndex;
                            m_iOperitionIndex = m_iOperitionIndex + 1;
                            subCoil.ContentS.Add(TempContent);

                            m_cTempStep.CoilS.Add(subCoil);

                            if (m_lJumpLable.Count > 0)
                            {
                                int iCount = m_lJumpLable.Count;

                                for (int i = 0; i < iCount; i++)
                                {
                                    string label = m_lJumpLable[i];
                                    m_dJumpDic[label].CoilS.Add(subCoil);
                                }
                            }
                        }

                        TempContent = new CContent();
                        if (CheckIsConstant(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.Constant;
                            TempContent.Argument = sAddress;
                        }
                        else if (CheckIsInternel(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.LogicTag;
                            TempContent.Argument = sAddress;

                            CTag cTempTag = FindTag(sAddress, false);
                            TempContent.Tag = cTempTag;
                            m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                        }
                        else if (m_lSpecialAddress.Contains(sAddress))
                        {
                            TempContent.ArgumentType = EMArgumentType.None;
                            TempContent.Argument = sAddress;
                        }
                        else
                        {
                            TempContent.ArgumentType = EMArgumentType.Tag;
                            TempContent.Argument = sAddress;

                            CTag cTempTag = FindTag(sAddress, false);
                            TempContent.Tag = cTempTag;
                            m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                        }

                        TempContent.Parameter = sNodedata;

                        cTempContact.ContentS.Add(TempContent);

                        cTempContact.Instruction = sPar;
                        cTempContact.Operator = sPar;
                    }
                    else if (sNodedata.Contains(","))
                    {
                        string sDBAddress = string.Empty;
                        string sFAddress = string.Empty;

                        string sTemp = sNodedata.Substring(sNodedata.IndexOf(" "));
                        sTemp = NodedataEdit(sTemp);

                        int i = sTemp.IndexOf(",");

                        sDBAddress = sTemp.Substring(i + 1);
                        sFAddress = sTemp.Remove(i);
                        sDBAddress = AddressEdittor(sDBAddress);
                        sFAddress = AddressEdittor(sFAddress);

                        TempContent = new CContent();

                        CTag cTempTag = FindTag(sFAddress, true);

                        TempContent.Argument = sFAddress;
                        TempContent.ArgumentType = EMArgumentType.Tag;
                        TempContent.Parameter = sNodedata;
                        TempContent.Tag = cTempTag;

                        cTempContact.ContentS.Add(TempContent);

                        cTempTag = FindTag(sDBAddress, true);

                        TempContent = new CContent();

                        TempContent.Argument = sDBAddress;
                        TempContent.Tag = cTempTag;

                        cTempContact.ContentS.Add(TempContent);
                        cTempContact.ContactType = EMContactType.Function;
                        cTempContact.Instruction = sNodedata;
                        cTempContact.Operator = sNodedata;
                    }
                    else
                    {
                        CTag cTempTag = FindTag(sAddress, true);
                        TempContent = new CContent();

                        TempContent.Argument = sAddress;
                        TempContent.ArgumentType = EMArgumentType.Tag;
                        TempContent.Parameter = sComment;
                        TempContent.Tag = cTempTag;

                        cTempContact.ContentS.Add(TempContent);
                        cTempContact.ContactType = EMContactType.Function;
                        cTempContact.Instruction = sNodedata;
                        cTempContact.Operator = sNodedata;
                    }

                    iOperationNum = m_iOperitionIndex;

                    int iCount1 = LastContactS.Count;

                    for (int i = 0; i < iCount1; i++)
                    {
                        cTempContact.Relation.PrevContactS.Add(LastContactS[i]);
                    }
                    iCount1 = LastCoilS.Count;

                    for (int i = 0; i < iCount1; i++)
                        cTempContact.Relation.PrevCoilS.Add(LastCoilS[i]);

                    ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                    cTempContact.StepIndex = m_iOperitionIndex;

                    m_cTempStep.ContactS.Add(cTempContact);

                    m_iOperitionIndex = m_iOperitionIndex + 1;

                    if (m_lJumpLable.Count > 0)
                    {
                        int iCount2 = m_lJumpLable.Count;

                        for (int i = 0; i < iCount2; i++)
                        {
                            string label = m_lJumpLable[i];
                            m_dJumpDic[label].ContactS.Add(cTempContact);
                        }
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewDBRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                string sTemp = string.Empty;

                if (sAddress.StartsWith("DI"))
                {
                    sTemp = sAddress.Substring(2);
                    sTemp = "DB" + sTemp;

                }
                else
                    sTemp = sAddress;

                CContent TempContent = new CContent();

                if (CheckIsConstant(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.Constant;
                    TempContent.Argument = sAddress;
                }
                else if (CheckIsInternel(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.LogicTag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }
                else if (m_lSpecialAddress.Contains(sAddress))
                {
                    TempContent.ArgumentType = EMArgumentType.None;
                    TempContent.Argument = sAddress;
                }
                else
                {
                    TempContent.ArgumentType = EMArgumentType.Tag;
                    TempContent.Argument = sAddress;

                    CTag cTempTag = FindTag(sAddress, false);
                    TempContent.Tag = cTempTag;
                    m_cTempStep.RefTagS.Add(cTempTag.Key, cTempTag);
                }

                TempContent.Parameter = sComment;

                if (m_dDBDic.Keys.Contains(sTemp))
                {
                    CS7DataBlock tempDb = m_dDBDic[sTemp];
                    if (sAddress.StartsWith("DI"))
                        m_cCurrentInstanceDB = tempDb;
                    else if (sAddress.StartsWith("DB"))
                        m_cCurrentDB = tempDb;
                }
                else
                    Console.WriteLine("There a unKnow DB : {0}", sTemp);

                CCoil tempCoil = new CCoil();

                tempCoil.ContentS.Add(TempContent);
                tempCoil.CoilType = EMCoilType.ProgramControl;

                string sNodedata = FilePart[iAnalysisPointer];
                tempCoil.Instruction = NodedataEdit(sNodedata);

                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_cTempStep.CoilS.Add(tempCoil);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
                m_iAnalysisPointer = iAnalysisPointer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewSimpleContactRelAnalysis(string sLogicType, int iAnalysisPointer, string sNodedata, bool isInitial, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                CContent tempContent = new CContent();

                tempContent.Argument = sNodedata;
                tempContent.ArgumentType = EMArgumentType.None;

                CContact tempContact = new CContact();

                tempContact.ContentS.Add(tempContent);
                tempContact.ContactType = EMContactType.Logical;
                tempContact.Instruction = sLogicType;
                tempContact.StepIndex = m_iOperitionIndex;
                tempContact.IsInitial = isInitial;

                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempContact.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempContact.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, false);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_lTempContacts.Add(tempContact);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].ContactS.Add(tempContact);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewSimpleCoilRelAnalysis(string sLogicType, int iAnalysisPointer, string sNodedata, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOperationNum = -1;
            try
            {
                CContent tempContent = new CContent();

                tempContent.Argument = sNodedata;
                tempContent.ArgumentType = EMArgumentType.None;

                CCoil tempCoil = new CCoil();
                tempCoil.ContentS.Add(tempContent);
                tempCoil.Instruction = sLogicType;
                tempCoil.StepIndex = m_iOperitionIndex;

                iOperationNum = m_iOperitionIndex;

                int iCount = LastContactS.Count;

                for (int i = 0; i < iCount; i++)
                {
                    tempCoil.Relation.PrevContactS.Add(LastContactS[i]);
                }
                iCount = LastCoilS.Count;

                for (int i = 0; i < iCount; i++)
                    tempCoil.Relation.PrevCoilS.Add(LastCoilS[i]);

                ConnectToLast(iOperationNum, LastContactS, LastCoilS, true);

                m_iOperitionIndex = m_iOperitionIndex + 1;

                m_cTempStep.CoilS.Add(tempCoil);

                if (m_lJumpLable.Count > 0)
                {
                    iCount = m_lJumpLable.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        string label = m_lJumpLable[i];
                        m_dJumpDic[label].CoilS.Add(tempCoil);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOperationNum;
        }

        private int NewLoadLogicRelAnalysis(List<string> FilePart, int iAnalysisPointer, string sAddress, string sLogicType, string sComment, bool isInitial, List<int> LastContactS, List<int> LastCoilS)
        {
            int iOpertionNum = -1;
            try
            {
                if (CheckIsCompare(FilePart, iAnalysisPointer))
                {
                    iOpertionNum = NewCompareRelAnalysis(FilePart, iAnalysisPointer, sAddress, sLogicType, sComment, isInitial, LastContactS, LastCoilS);
                }
                else if (CheckIsConverter(FilePart, iAnalysisPointer))
                {
                    iOpertionNum = NewConverterRelAnalysis(FilePart, iAnalysisPointer, sAddress, sLogicType, sComment, LastContactS, LastCoilS);
                }
                else if (CheckIsComputer(FilePart, iAnalysisPointer))
                {
                    iOpertionNum = NewComputerRelAnalysis(FilePart, iAnalysisPointer, sAddress, sLogicType, sComment, LastContactS, LastCoilS);
                }
                else if (CheckIsMove(FilePart, iAnalysisPointer))
                {
                    iOpertionNum = NewMoveRelAnalysis(FilePart, iAnalysisPointer, sAddress, sLogicType, sComment, LastContactS, LastCoilS);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return iOpertionNum;
        }

        private void NewLocalMemoryAnalysis(string sAddress, string sComment, List<int> totalLastContactS, List<int> totalLastCoilS)
        {
            try
            {
                CS7LocalMem tempLocal = new CS7LocalMem();

                //int icount = m_lTempContacts.Count;

                //for (int i = 0; i < icount; i++)
                //{
                //    tempLocal.TotalContactS.Add(m_lTempContacts[i]);
                //}

                //icount = m_lTempCoilS.Count;

                //for (int i = 0; i < icount;i++ )
                //{
                //    tempLocal.TotalCoilS.Add(m_lTempCoilS[i]);
                //}
                int icount = totalLastContactS.Count;

                for (int i = 0; i < icount; i++)
                {
                    tempLocal.LastContactS.Add(totalLastContactS[i]);
                }

                icount = totalLastCoilS.Count;

                for (int i = 0; i < icount; i++)
                {
                    tempLocal.LastCoilS.Add(totalLastCoilS[i]);
                }

                if (!m_dLocalMem.ContainsKey(sAddress))
                {
                    m_dLocalMem.Add(sAddress, tempLocal);
                }
                else
                {
                    while (m_dLocalMem.ContainsKey(sAddress))
                    {
                        sAddress = sAddress + "-New";
                    }
                    m_dLocalMem.Add(sAddress, tempLocal);
                }
                //m_lTempContacts.Clear();
                //m_lTempCoilS.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion


        #region Support Functions

        private bool CheckIsConTact(string sLogicType)
        {
            bool bIsContact = false;
            try
            {
                if (m_lContactS.Contains(sLogicType))
                    bIsContact = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsContact;
        }

        private bool CheckIsCoil(string sLogicType)
        {
            bool bIsCoil = false;
            try
            {
                if (m_lCoilS.Contains(sLogicType))
                    bIsCoil = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsCoil;
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

        private bool CheckIsSimpleLogic(string sLogicType)
        {
            bool bIsSimpleLogic = false;
            try
            {
                if (m_lSimpleCantactType.Contains(sLogicType))
                    bIsSimpleLogic = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsSimpleLogic;
        }

        private bool IsHadAddress(string nodedata, string sLogicType)
        {
            bool bHadAddress = true;
            try
            {
                if (sLogicType == "L STW")
                    bHadAddress = false;
                else if (sLogicType == "L DBLG")
                    bHadAddress = false;
                else if (sLogicType == "L DBNO")
                    bHadAddress = false;
                else if (sLogicType == "L DILG")
                    bHadAddress = false;
                else if (sLogicType == "L DINO")
                    bHadAddress = false;
                else
                {
                    int i = nodedata.IndexOf(" ");
                    nodedata = nodedata.Substring(i);
                    nodedata = NodedataEdit(nodedata);

                    if (nodedata.Length < 1)
                        bHadAddress = false;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bHadAddress;
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

        private void priTagUsedCount(string sAddress)
        {
            try
            {
                if (sAddress.StartsWith("I"))
                    m_iInputUseCheck = m_iInputUseCheck + 1;
                else if (sAddress.StartsWith("Q"))
                    m_iOutputUseCheck = m_iOutputUseCheck + 1;
                else if (sAddress.StartsWith("M"))
                    m_iMemUseCheck = m_iMemUseCheck + 1;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

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

        private string FindAddress(string nodedata)
        {
            string sAddress = string.Empty;
            try
            {
                NodedataEdit(nodedata);

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
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sAddress;
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

                    if (!CheckIsSymbol(nodedata))
                    {
                        nodedata = nodedata.Replace(" ", "");
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private void LocalMemoryConnector(string LocalAdd, CContactS tempContactS, List<int> NextCoilS, List<int> NextContactS)
        {
            try
            {
                CS7LocalMem LocalMem = m_dLocalMem[LocalAdd];

                int iCount = LocalMem.TotalContactS.Count;
                for (int i = 0; i < iCount; i++)
                {
                    if (CheckIsLocalMemAdd(LocalMem.TotalContactS[i].ContentS[0].Argument))
                    {
                        string sLocalAddress = LocalMem.TotalContactS[i].ContentS[0].Argument;

                        if (LocalMem.TotalContactS[i].Relation.PrevContactS.Count > 0)
                        {
                            int relationCount = LocalMem.TotalContactS[i].Relation.PrevContactS.Count;

                            for (int j = 0; j < relationCount; j++)
                            {
                                int targetIndex = LocalMem.TotalContactS[i].Relation.NextContactS[j];

                            }
                        }

                        if (LocalMem.TotalContactS[i].Relation.PrevCoilS.Count > 0)
                        {
                            int relationCount = LocalMem.TotalContactS[i].Relation.NextCoilS.Count;

                            for (int j = 0; j < relationCount; j++)
                            {
                                int targetIndex = LocalMem.TotalContactS[i].Relation.NextCoilS[j];
                                //FindFinalContact(LocalMem, targetIndex,NextContactS,NextCoilS);
                            }
                        }
                    }
                    else
                    {
                        tempContactS.Add(LocalMem.TotalContactS[i]);
                        if (LocalMem.TotalContactS[i].Relation.PrevCoilS.Count == 0 && LocalMem.TotalContactS[i].Relation.PrevContactS.Count == 0)
                        {
                            if (LocalMem.TotalContactS[i].Relation.PrevContactS.Count > 0)
                            {
                                int relationCount = LocalMem.TotalContactS[i].Relation.PrevContactS.Count;

                                for (int j = 0; j < relationCount; j++)
                                {
                                    int targetIndex = LocalMem.TotalContactS[i].Relation.NextContactS[j];
                                    //FindFinalContact(LocalMem, targetIndex, NextContactS,NextCoilS);
                                }
                            }

                            if (LocalMem.TotalContactS[i].Relation.PrevCoilS.Count > 0)
                            {
                                int relationCount = LocalMem.TotalContactS[i].Relation.NextCoilS.Count;

                                for (int j = 0; j < relationCount; j++)
                                {
                                    int targetIndex = LocalMem.TotalContactS[i].Relation.NextCoilS[j];
                                    //FindFinalContact(LocalMem, targetIndex, NextContactS, NextCoilS);
                                }
                            }
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private CTag FindTag(string nodedata, bool isCoil)
        {
            CTag TempTag = null;
            try
            {
                if (!CheckIsSymbol(nodedata))
                    nodedata = nodedata.Replace(" ", "");

                if (nodedata.StartsWith("SFC") || nodedata.StartsWith("SFB"))
                {
                    TempTag = new CTag();
                    TempTag.Key = nodedata;
                    //TempTag.Address = nodedata;
                    TempTag.DataType = EMDataType.Block;
                }
                else if (m_lSpecialAddress.Contains(nodedata))
                {
                    TempTag = new CTag();
                    TempTag.Key = nodedata;
                    //TempTag.Address = nodedata;
                    TempTag.DataType = EMDataType.None;
                }
                else if (CheckIsInternel(nodedata))
                {
                    nodedata = nodedata.Substring(1);

                    string stemp = m_sFunction+"." + nodedata;
                    string sss = "." + nodedata;

                    if(m_dAddressTags.ContainsKey(stemp))
                    {
                        TempTag = m_dAddressTags[stemp];
                    }
                    else if (m_dInternalTags.ContainsKey(sss))
                    {
                        TempTag = m_dInternalTags[sss];
                    }
                    else
                    {
                        //Console.WriteLine("There is a internel tag block : {0} block {1}th network.",m_sFunction, m_iNetworkIndex.ToString());
                        TempTag = new CTag();
                        TempTag.Key = stemp;
                        //TempTag.Address = stemp;
                        TempTag.DataType = EMDataType.None;
                    }
                }
                else if (CheckIsDBtag(nodedata))
                {
                    if(m_dAddressTags.ContainsKey(nodedata))
                    {
                        TempTag = m_dAddressTags[nodedata];
                    }
                    else
                    {
                        int itemp = nodedata.IndexOf('.');

                        string DBName = nodedata.Remove(itemp);
                        string ItemName = nodedata.Substring(itemp + 1);

                        if (m_dDBDic.ContainsKey(DBName))
                        {
                            if (m_dDBDic[DBName].SymbolTags.ContainsKey(ItemName))
                                TempTag = m_dDBDic[DBName].SymbolTags[ItemName];
                            else if (m_dDBDic[DBName].AddressTags.ContainsKey(ItemName))
                                TempTag = m_dDBDic[DBName].AddressTags[ItemName];
                            else
                            {
                                //Console.WriteLine("There is no target tag in this DB. DB name is {0}, Item Name is {1}", DBName, ItemName);
                                TempTag = new CTag();
                                TempTag.Key = nodedata;
                                TempTag.Address = nodedata;
                                //TempTag.Name = nodedata;
                                TempTag.DataType = EMDataType.None;
                            }
                        }
                        else
                        {
                            //Console.WriteLine("There is no target DB. DB name is {0}, Item Name is {1}", DBName, ItemName);
                            TempTag = new CTag();
                            TempTag.Key = nodedata;
                            TempTag.Address = nodedata;
                            //TempTag.Name = nodedata;
                            TempTag.DataType = EMDataType.None;
                        }
                    }                    
                }
                else if (CheckIsCurrentDBTag(nodedata))
                {
                    if (m_cCurrentDB != null)
                    {
                        if (m_cCurrentDB.AddressTags.ContainsKey(nodedata))
                            TempTag = m_cCurrentInstanceDB.AddressTags[nodedata];
                        else if (m_cCurrentDB.SymbolTags.ContainsKey(nodedata))
                            TempTag = m_cCurrentInstanceDB.SymbolTags[nodedata];
                        else
                        {
                            //Console.WriteLine("There is no target DB. DB name is {0}, Item Name is {1}", DBName, ItemName);
                            TempTag = new CTag();
                            TempTag.Key = nodedata;
                            TempTag.Address = nodedata;
                            //TempTag.Name = nodedata;
                            TempTag.DataType = EMDataType.None;
                        }
                    }
                    else
                    {
                        TempTag = new CTag();
                        TempTag.Key = nodedata;
                        TempTag.Address = nodedata;
                        //TempTag.Name = nodedata;
                        TempTag.DataType = EMDataType.None;
                    }
                }
                else if (CheckIsCurrentInstanceDBTag(nodedata))
                {
                    if (m_cCurrentInstanceDB != null)
                    {
                        string sTemp = nodedata.Substring(2);
                        sTemp = "DB" + sTemp;

                        if (m_cCurrentInstanceDB.AddressTags.ContainsKey(sTemp))
                            TempTag = m_cCurrentInstanceDB.AddressTags[sTemp];
                        else if (m_cCurrentInstanceDB.SymbolTags.ContainsKey(sTemp))
                            TempTag = m_cCurrentInstanceDB.SymbolTags[sTemp];
                        else
                        {
                            //Console.WriteLine("There is no target DB. DB name is {0}, Item Name is {1}", DBName, ItemName);
                            TempTag = new CTag();
                            TempTag.Key = nodedata;
                            TempTag.Address = nodedata;
                            //TempTag.Name = nodedata;
                            TempTag.DataType = EMDataType.None;
                        }
                    }
                    else
                    {
                        TempTag = new CTag();
                        TempTag.Key = nodedata;
                        TempTag.Address = nodedata;
                        //TempTag.Name = nodedata;
                        TempTag.DataType = EMDataType.None;
                    }
                }
                else if (CheckIsConstant(nodedata))
                {
                    TempTag = new CTag();
                    TempTag.Key = nodedata;
                    //TempTag.Address = nodedata;
                    //TempTag.Name = nodedata;
                    TempTag.DataType = EMDataType.Word;
                    TempTag.Program = m_sFunction;
                }
                else if (CheckIsJumpLabel(nodedata))
                {
                    TempTag = new CTag();
                    TempTag.Key = nodedata;
                    //TempTag.Address = nodedata;
                    //TempTag.Name = nodedata;
                    TempTag.DataType = EMDataType.Bool;
                    TempTag.Description = "Jump Label";

                    TempTag.Program = m_sFunction;
                }
                else if (CheckIsLocalMem(nodedata))
                {
                    TempTag = new CTag();
                    TempTag.Key = nodedata;
                    TempTag.Address = nodedata;
                    //TempTag.Name = nodedata;
                    TempTag.DataType = EMDataType.Bool;
                    TempTag.Description = "Local Memory";
                    TempTag.Program = m_sFunction;
                }
                else
                {
                    //if (CheckIsSymbol(nodedata))
                    //{
                    //    if (m_dSymbolTags.ContainsKey(nodedata))
                    //    {
                    //        TempTag = m_dSymbolTags[nodedata];
                    //    }
                    //    else
                    //    {
                    //        //Console.WriteLine("There is no target tag. The tag's symbol is {0}", nodedata);

                    //        TempTag = new CTag();
                    //        TempTag.Key = nodedata;
                    //        TempTag.Address = nodedata;
                    //        TempTag.Name = nodedata;
                    //        TempTag.DataType = EMDataType.None;
                    //    }

                    //    if (isCoil)
                    //    {
                    //        if (m_dTagCoilUseDic.ContainsKey(nodedata))
                    //        {
                    //            string sTemp = m_dTagCoilUseDic[nodedata];
                    //            string location = m_sFunction +"."+ m_iNetworkIndex.ToString();
                    //            if (!sTemp.Contains(location))
                    //            {
                    //                sTemp = sTemp + ";" + location;
                    //                m_dTagCoilUseDic[nodedata] = sTemp;
                    //            }

                    //        }
                    //        else
                    //            m_dTagCoilUseDic.Add(nodedata, m_sFunction + "." + m_iNetworkIndex.ToString());
                    //    }
                    //    else
                    //    {
                    //        if (m_dTagContactUseDic.ContainsKey(nodedata))
                    //        {
                    //            string sTemp = m_dTagContactUseDic[nodedata];
                    //            string location = m_sFunction + "." + m_iNetworkIndex.ToString();
                    //            if (!sTemp.Contains(location))
                    //            {
                    //                sTemp = sTemp + ";" + location;
                    //                m_dTagContactUseDic[nodedata] = sTemp;
                    //            }
                    //        }
                    //        else
                    //            m_dTagContactUseDic.Add(nodedata, m_sFunction + "." + m_iNetworkIndex.ToString());
                    //    }
                    //}
                    //else
                    //{
                    if (m_dAddressTags.ContainsKey(nodedata))
                    {
                        TempTag = m_dAddressTags[nodedata];
                    }
                    else
                    {
                        //Console.WriteLine("There is no target tag. The tag's address is {0}", nodedata);

                        TempTag = new CTag();
                        TempTag.Key = nodedata;
                        TempTag.Address = nodedata;
                        //TempTag.Name = nodedata;
                        TempTag.DataType = EMDataType.None;
                    }


                    if (isCoil)
                    {
                        if (m_dTagCoilUseDic.ContainsKey(nodedata))
                        {
                            string sTemp = m_dTagCoilUseDic[nodedata];
                            string location = m_sFunction + "." + m_iNetworkIndex.ToString();
                            if (!sTemp.Contains(location))
                            {
                                sTemp = sTemp + ";" + location;
                                m_dTagCoilUseDic[nodedata] = sTemp;
                            }

                        }
                        else
                            m_dTagCoilUseDic.Add(nodedata, m_sFunction + "." + m_iNetworkIndex.ToString());
                    }
                    else
                    {
                        if (m_dTagContactUseDic.ContainsKey(nodedata))
                        {
                            string sTemp = m_dTagContactUseDic[nodedata];
                            string location = m_sFunction + "." + m_iNetworkIndex.ToString();
                            if (!sTemp.Contains(location))
                            {
                                sTemp = sTemp + ";" + location;
                                m_dTagContactUseDic[nodedata] = sTemp;
                            }
                        }
                        else
                            m_dTagContactUseDic.Add(nodedata, m_sFunction + "." + m_iNetworkIndex.ToString());
                    }
                    //}
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return TempTag;
        }

        private CS7Block FindBlock(string nodedata)
        {
            CS7Block tempBlock = null;

            try
            {
                if (m_dBlockDic.ContainsKey(nodedata))
                {
                    tempBlock = m_dBlockDic[nodedata];
                }
                else if (nodedata.StartsWith("#"))
                {
                    nodedata = "." + nodedata.Substring(1);
                    string blockName = string.Empty;
                    if (m_dInternalTags.ContainsKey(nodedata))
                    {
                        CTag tempTag = m_dInternalTags[nodedata];
                        blockName = tempTag.UDTType;
                    }

                    if (m_dBlockDic.ContainsKey(blockName))
                        tempBlock = m_dBlockDic[blockName];
                    else
                    {
                        if (!m_lUnKnowBlock.Contains(nodedata))
                        {
                            m_lUnKnowBlock.Add(nodedata);
                        }
                    }
                }
                else
                {
                    if (!m_lUnKnowBlock.Contains(nodedata))
                    {
                        m_lUnKnowBlock.Add(nodedata);
                    }
                    //Console.WriteLine("There is a unKnow Block, Please Check block name is : {0}", nodedata);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempBlock;
        }

        private CS7DataBlock FindDataBlock(string nodedata)
        {
            CS7DataBlock tempDB = null;
            try
            {
                if (m_dDBDic.ContainsKey(nodedata))
                    tempDB = m_dDBDic[nodedata];
                else
                    Console.WriteLine("There is an unknow DataBlock : {0} .", nodedata);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempDB;
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

        private bool CheckIsInternel(string nodedata)
        {
            bool bIsInternel = false;
            try
            {
                if (nodedata.StartsWith("#"))
                    bIsInternel = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsInternel;
        }

        private bool CheckIsDBtag(string nodedata)
        {
            bool bIsDBtag = false;
            try
            {
                if (nodedata.Contains(".") && (nodedata.StartsWith("DB") || nodedata.StartsWith("DI")))
                    bIsDBtag = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bIsDBtag;
        }

        private string FindTitle(string nodedata)
        {
            string sTitle = string.Empty;
            try
            {
                sTitle = nodedata.Replace("TITLE =", "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sTitle;
        }

        private string FindComment(string nodedata)
        {
            string sComment = string.Empty;
            try
            {
                int iPos = nodedata.IndexOf("//");
                if (iPos > -1)
                {
                    sComment = nodedata.Substring(iPos + 2);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sComment;
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

        private string FindLabelName(string nodedata)
        {
            try
            {
                if (nodedata.Contains(": "))
                {
                    int iPos = nodedata.IndexOf(": ");
                    nodedata = nodedata.Remove(iPos);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private void ConnectToLast(int OperationIndex, List<int> LastContactS, List<int> LastCoilS, bool isCoil)
        {
            try
            {
                if (LastContactS.Count > 0)
                {
                    int iCount = LastContactS.Count;
                    for (int i = 0; i < iCount; i++)
                    {
                        int target = LastContactS[i];

                        foreach (CContact temp in m_lTempContacts)
                        {
                            if (temp.StepIndex == target)
                            {
                                if (isCoil)
                                {
                                    if (!temp.Relation.NextCoilS.Contains(OperationIndex))
                                        temp.Relation.NextCoilS.Add(OperationIndex);
                                }
                                else
                                {
                                    if (!temp.Relation.NextContactS.Contains(OperationIndex))
                                    {
                                        temp.Relation.NextContactS.Add(OperationIndex);
                                    }
                                }

                                break;
                            }
                        }
                    }
                }

                if (LastCoilS.Count > 0)
                {
                    int iCount = LastCoilS.Count;

                    for (int i = 0; i < iCount; i++)
                    {
                        int target = LastCoilS[i];

                        foreach (CCoil temp in m_cTempStep.CoilS)
                        {
                            if (temp.StepIndex == target)
                            {
                                if (isCoil)
                                {
                                    if (!temp.Relation.NextCoilS.Contains(OperationIndex))
                                        temp.Relation.NextCoilS.Add(OperationIndex);
                                }
                                else
                                    if (!temp.Relation.NextContactS.Contains(OperationIndex))
                                        temp.Relation.NextContactS.Add(OperationIndex);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void NewLastRelationEdit(string sLogicType, int iOperitionIdex, ref List<int> LastContactS, ref List<int> LastCoilS)
        {
            try
            {
                bool bIsChecked = false;
                foreach (CContact temp in m_lTempContacts)
                {
                    if (temp.StepIndex == iOperitionIdex)
                    {
                        bIsChecked = true;

                        if (sLogicType == "A" || sLogicType == "AN")
                        {
                            LastContactS.Clear();
                            LastContactS.Add(iOperitionIdex);
                            LastCoilS.Clear();
                        }
                        else
                            LastContactS.Add(iOperitionIdex);
                    }
                }

                if (!bIsChecked)
                {
                    foreach (CCoil temp in m_cTempStep.CoilS)
                    {
                        if (sLogicType == "A" || sLogicType == "AN")
                        {
                            LastCoilS.Clear();
                            LastCoilS.Add(iOperitionIdex);
                            LastContactS.Clear();
                        }
                        else
                            LastCoilS.Add(iOperitionIdex);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Comment Check

        private bool CheckIsCompare(List<string> sFilePart, int index)
        {
            bool bIsCompare = false;
            try
            {
                int iCount = sFilePart.Count;

                if (index < iCount - 2)
                {
                    string nodedata = sFilePart[index + 1];
                    nodedata = NodedataEdit(nodedata);
                    if (nodedata.StartsWith("L "))
                    {
                        nodedata = sFilePart[index + 2];

                        nodedata = NodedataEdit(nodedata);
                        string sLogicType = LogicTypeCheck(nodedata);

                        if (m_lCompareList.Contains(sLogicType))
                            bIsCompare = true;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsCompare;
        }

        private bool CheckIsMove(List<string> sFilePart, int index)
        {
            bool bIsMove = false;
            try
            {
                int iCount = sFilePart.Count;

                if (index < iCount - 1)
                {
                    string nodedata = sFilePart[index + 1];
                    nodedata = NodedataEdit(nodedata);

                    string sLogicType = LogicTypeCheck(nodedata);

                    if (sLogicType == "T")
                        bIsMove = true;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsMove;
        }

        private bool CheckIsComputer(List<string> sFilePart, int index)
        {
            bool bIsComputer = false;
            try
            {
                int iCount = sFilePart.Count;

                if (index < iCount - 2)
                {
                    string nodedata = sFilePart[index + 1];
                    nodedata = NodedataEdit(nodedata);

                    if (nodedata.StartsWith("L "))
                    {
                        nodedata = sFilePart[index + 2];

                        nodedata = NodedataEdit(nodedata);
                        string sLogicType = LogicTypeCheck(nodedata);

                        if (m_lComputerList.Contains(sLogicType) || m_lWordLogicList.Contains(sLogicType) || m_lCyclicShiftList.Contains(sLogicType) || m_lAccumList.Contains(sLogicType))
                            bIsComputer = true;
                    }
                    else
                    {
                        string sLogicType = LogicTypeCheck(nodedata);

                        if (m_lComputerList.Contains(sLogicType) || m_lWordLogicList.Contains(sLogicType) || m_lCyclicShiftList.Contains(sLogicType) || m_lAccumList.Contains(sLogicType))
                            bIsComputer = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsComputer;
        }

        private bool CheckIsConverter(List<string> sFilePart, int index)
        {
            bool bIsConverter = false;
            try
            {
                int iCount = sFilePart.Count;

                if (index < iCount - 2)
                {
                    string nodedata = sFilePart[index + 1];
                    nodedata = NodedataEdit(nodedata);

                    string sLogicType = LogicTypeCheck(nodedata);

                    if (m_lConvertorList.Contains(sLogicType))
                        bIsConverter = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsConverter;
        }

        private bool CheckIsTimer(List<string> sFilePart, int index)
        {
            bool isTimer = false;
            try
            {
                if (sFilePart.Count >= index + 2)
                {
                    string sNodedata = sFilePart[index + 1];
                    sNodedata = NodedataEdit(sNodedata);

                    string slogicType = LogicTypeCheck(sNodedata);

                    if (slogicType == "L")
                    {
                        sNodedata = sFilePart[index + 2];
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
                                CTag tempTag = FindTag(sAddress, true);
                                if (tempTag.DataType == EMDataType.Timer)
                                {
                                    isTimer = true;
                                }
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
                                CTag tempTag = FindTag(sAddress, true);
                                if (tempTag.DataType == EMDataType.Timer)
                                {
                                    isTimer = true;
                                }
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

        private bool CheckIsCounter(List<string> sFilePart, int index)
        {
            bool isCounter = false;
            try
            {
                if (sFilePart.Count >= index + 2)
                {
                    string sNodedata = sFilePart[index + 1];
                    sNodedata = NodedataEdit(sNodedata);

                    string sLogicType = LogicTypeCheck(sNodedata);

                    if (sLogicType == "L")
                    {

                        sNodedata = sFilePart[index + 2];
                        sNodedata = NodedataEdit(sNodedata);

                        sLogicType = LogicTypeCheck(sNodedata);

                        if (sLogicType == "CU" || sLogicType == "CD")
                            isCounter = true;
                        else if (sLogicType == "FR")
                        {
                            string sAddress = FindAddress(sNodedata);
                            if (sAddress.StartsWith("C"))
                                isCounter = true;
                            else
                            {
                                CTag tempTag = FindTag(sAddress, true);
                                if (tempTag.DataType == EMDataType.Counter)
                                {
                                    isCounter = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (sLogicType == "CU" || sLogicType == "CD")
                            isCounter = true;
                        else if (sLogicType == "FR")
                        {
                            string sAddress = FindAddress(sNodedata);
                            if (sAddress.StartsWith("C"))
                                isCounter = true;
                            else
                            {
                                CTag tempTag = FindTag(sAddress, true);
                                if (tempTag.DataType == EMDataType.Counter)
                                {
                                    isCounter = true;
                                }
                            }
                        }
                    }

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isCounter;
        }

        private bool CheckIsJustCoil(string nodedata)
        {
            bool bIsJustCoil = false;
            try
            {
                string sLogicType = LogicTypeCheck(nodedata);
                if (m_lSimpleCoilType.Contains(sLogicType))
                    bIsJustCoil = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsJustCoil;
        }

        private bool CheckIsLocalMem(string nodedata)
        {
            bool bIsLocalMem = false;

            try
            {
                if (m_dLocalMem.ContainsKey(nodedata))
                {
                    bIsLocalMem = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsLocalMem;
        }

        private bool CheckIsJumpLabel(string nodedata)
        {
            bool bIsLabel = false;

            try
            {
                if (m_dJumpDic.ContainsKey(nodedata))
                {
                    bIsLabel = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsLabel;
        }

        private bool CheckIsDBCoil(string nodedata)
        {
            bool bIsDB = false;

            try
            {
                if (m_lDataBlockCommandList.Contains(nodedata))
                {
                    bIsDB = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsDB;
        }

        private bool CheckIsCurrentInstanceDBTag(string nodedata)
        {
            bool bIsDB = false;

            try
            {
                if (nodedata.StartsWith("DIX") || nodedata.StartsWith("DIB") || nodedata.StartsWith("DIW") || nodedata.StartsWith("DID"))
                    bIsDB = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsDB;
        }

        private bool CheckIsCurrentDBTag(string nodedata)
        {
            bool bIsDB = false;

            try
            {
                if (nodedata.StartsWith("DBX") || nodedata.StartsWith("DBB") || nodedata.StartsWith("DBW") || nodedata.StartsWith("DBD"))
                    bIsDB = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsDB;
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

        #endregion
    }
}
