using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;
using System.Text.RegularExpressions;

namespace UDM.UDLImport
{
    public class CUDLConvert
    {
        private CTagS m_cGlobalTagS = null;
        private CTagS m_cUsedGlobalTagS = new CTagS();
        private CTagS m_cLocalTagS = new CTagS();
        private CStepS m_cStepS = null;
        private CUDL m_cUDL = null;
        private string m_sChannel = "1";
        private EMPLCMaker m_emPLCMaker;

        private CStep m_cStepCur = null;
        private CFB_Info m_cFBInfoCur = new CFB_Info();
        private List<CFB_Info> m_lstCFBInfo = new List<CFB_Info>();

        private string m_sBlockName = string.Empty;
        private int m_iOperatorIndex = 0;
        private Dictionary<string, CUDLBlock> m_DicFB = new Dictionary<string, CUDLBlock>();
        private int m_iInputInOutTagCount = 0;
        private bool m_bCheckFBUsedENENO = true;
        private Dictionary<string, string> m_DicLocalFBNameS = new Dictionary<string, string>();
        private List<string> m_lstProtectedFBList = null;
        private Dictionary<string, CUDLBlock> m_DicSystemFC = null;
        private List<int> m_lstContactStepIndexTemp = new List<int>();
        private CTagS m_cAddressGlobalTagS = new CTagS();
        private CTagS m_cAddressLocalTagS = new CTagS();
        private Dictionary<string, string> m_DicSubLogic = null;
        private List<string> m_lstAnalysisDBs = null;

        private List<string> m_lstForNextControl = new List<string>();
        private List<string> m_lstCallControl = new List<string>();
        private List<string> m_lstMasterControl = new List<string>();
        private int m_iLastNextContactIndex = -1;
        private List<int> m_lstComSubLogicLastNextContact = new List<int>();
        private string m_sOpenedDBName = string.Empty;
        private string m_sOpenedDIName = string.Empty;
        private int m_iLogicLevel = 0;
        private int m_iPrevLogicIsCoil = 0;
        private int m_iIsNewStartLogic = 0;

        private CContact m_cPreFBContact = new CContact();
        private bool m_bSetFB = false;
        #region Common Command Library

        protected List<string> m_lstCompareCommand = new List<string> { "EQU", "GEQ", "GRT", "LEQ", "LES", "NEQ", "abLIM", "CMP" };
        protected List<string> m_lstComputCommand = new List<string> { "ADD", "SUB", "MUL", "DIV", "MOD", "SQRT", "NEG", "ABS", "BTD", "AND", "OR", "XOR", "XNR", "NOT", "SIN", "COS", "TAN", "LN", "LOG", "DEG", "RAD", "TRN", "BCD", "BIN", "INC", "DEC", "CPT", "CLR" };
        protected List<string> m_lstMoveCommand = new List<string> { "MOV", "MVM", "MOVE" };
        protected List<string> m_lstTimerCommand = new List<string> { "TON", "TOFF", "RTO", "TMR" };
        protected List<string> m_lstCountCommand = new List<string> { "CTU", "CTD", "UDCNT" };
        protected List<string> m_lstConstantHead = new List<string>() { "A", "2#", "8#", "16#", "K", "H", "N", "C#", "S5T#", "L#", "W#", "DW#", "B#", "T#", "J" };
        protected List<string> m_lstSpecialTags = new List<string>() { "\"", "\\", "\'" };
        protected List<string> m_lstContactCommand = new List<string>() { "XIC", "XIO" };
        protected List<string> m_lstLogicalCommand = new List<string>() { "ONS", "INV", "AFI" };
        protected List<string> m_lstShiftCommand = new List<string>() { "SFR", "SFL", "SR", "BRR", "BRL" };
        protected List<string> m_lstProgramControlCommand = new List<string>() { "MCR", "FOR", "NEXT", "BREAK", "LABEL", "RET", "CJ", "SCJ", "CALL", "JMP", "SBRT", "END" };
        protected List<string> m_lstCommunicationCommand = new List<string>() { "FROM", "TO" };
        protected List<string> m_lstSpecialCommand = new List<string>() { "DATE", "CLK", "SECOND", "HOUR", "mLIM", "lsLIM", "EQ2", "DECO", "BRST", "FAL", "FSC", "COP", "CPS", "FLL", "AVE", "SRT", "STD", "SIZE", "FBCX", "DDT", "DTR", "PID", "FFL", "FFU" };
        protected List<string> m_lstSubDataMoveCommandAll = new List<string>() { "DIV", "DDIV", "BDIV", "DBDIV", "EDIV", "SER", "DSER", "SECOND", "BSIN", "BCOS", "BTAN", "BASIN", "BACOS", "BATAN", "BINHA", "BCDDA", "MAX", "MIN", "DATE+", "DATE-",
            "HOUR", "BINDA", "DMAX", "DMIN", "DBINHA", "DBCDDA", "RBCD", "DBINDA", "BSWAP", "GBMOV", "BAND", "BOR", "BXOR", "BXNR", "BKEQU", "BKGEQ", "BKGRT", "BKLEQ", "BKLES", "BKNEQ", "BKADD", "BKSUB", "GMOV", "FMOV", "BKBCD", "BKBIN", "mBMOV", 
            "BKOR", "BKAND", "BKXOR", "BKXNR", "WSFR", "WSL", "DIS", "WTOD", "BSFR", "BSFL", "DATERD", "DECO", "ENCO", "FROM", "TO"};
        protected List<string> m_lstDoubleDataSizeCommandAll = new List<string>() {"DABIN", "HABIN", "DABCD", "EQU", "GEQ", "GRT", "LEQ", "LES", "NEQ", "LIM", "CMP", "ADD", "SUB", "MUL", "DIV", "MOD", "SQRT", "NEG", "ABS", "BTD", "AND", "OR", "XOR", "XNR", "NOT", "SIN", "COS", "TAN", "LN", "LOG", "DEG", "RAD"
            , "TRN", "BCD", "BIN", "INC", "DEC", "TEST", "SFR", "SFL", "SR", "BRR", "BRL", "SER", "BSUM", "MAX", "MIN", "SUM", "AVE", "MUX", "ROR", "RCR", "ROL", "RCL", "STR", "VAL", "FROM", "TO", "MOV", "MVM"};
        protected List<string> m_lst4DataSizeCommandAll = new List<string>() { "UDDIV", "UDMUL", "DMUL", "LADD", "LSUB", "LMUL", "LDIV", "DBMUL", "DSUM" };
        protected List<string> m_lstS7FixedAddress = new List<string> { "DBLG", "DBNO", "DILG", "DINO", "STW", "AR1", "AR2", "BR", "OV", "OS", "RLO", "STA", "OR", "CC1", "CC0", "ACCU1", "ACCU2" };
        //변환 명령어, 데이터 처리 명령어 BCD, BIN 등등 어떻게 처리 해야함? ASK

        #endregion

        #region Initialize/Dispose

        public CUDLConvert(CUDL cUDL, EMPLCMaker emPLCMaker) //isAddKey True 면 Address 기준 Tag Key 생성.
        {
            m_cUDL = cUDL;
            m_emPLCMaker = emPLCMaker;

            if (m_cUDL.Tags.Count != 0)
                m_emPLCMaker = m_cUDL.Tags[0].PLCMaker;

            CSfcXmlOpen cSFCOpen = new CSfcXmlOpen(m_emPLCMaker);
            m_DicSystemFC = cSFCOpen.SystemBlockS;
            m_lstProtectedFBList = cUDL.ProtectedFBList;
        }

        #endregion

        #region Properties

        public CUDL UDL
        {
            get { return m_cUDL; }
        }

        public CTagS UsedGlobalTagS
        {
            get { return m_cUsedGlobalTagS; }
            set { m_cUsedGlobalTagS = value; }
        }

        public CTagS GlobalTagS
        {
            get { return m_cGlobalTagS; }
            set { m_cGlobalTagS = value; }
        }

        public CTagS LocalTagS
        {
            get { return m_cLocalTagS; }
        }

        public CStepS StepS
        {
            get { return m_cStepS; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }

        public List<string> AnalysisDBS
        {
            get { return m_lstAnalysisDBs; }
            set { m_lstAnalysisDBs = value; }
        }

        #endregion

        #region Public Methods

        public void LogicAnalysis()
        {
            //if (m_emPLCMaker == EMPLCMaker.Mitsubishi_Works2 || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works3)
            //    return;

            m_cStepS = GetStepS();
        }

        public bool CreateGlobalTagS(bool bAddressKey, bool bLsDDEA)
        {
            m_cGlobalTagS = GetGlobalTagS(bAddressKey, bLsDDEA);

            string sLogMassage = string.Format("Total {0} GlobalTagS Created.", m_cGlobalTagS.Count);
            CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);

            if (m_cGlobalTagS == null)
                return false;
            return true;
        }

        public bool CreateLocalTagS(bool bAddressKey)
        {
            int iGlobalTagCount = m_cGlobalTagS.Count;

            if (m_cUDL.Blocks != null)
            {
                GetLocalTagS(bAddressKey);

                string sLogMassage = string.Format("Total {0} DB TagS and {1} Local Tags had Creat.", m_cGlobalTagS.Count - iGlobalTagCount, m_cLocalTagS.Count);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
            }
            else return false;

            return true;
        }

        #endregion

        #region Private Methods

        #region Methods of Tag Generate

        private CTagS GetGlobalTagS(bool bAddressKeyCheck, bool bLsDDEA)
        {
            CTagS cTagS = null;

            try
            {
                cTagS = new CTagS();
                CTag cTag = null;

                foreach (CUDLTag cUDLTag in m_cUDL.Tags)
                {
                    cTag = new CTag();

                    cTag.Channel = m_sChannel;
                    cTag.Name = cUDLTag.Name;
                    cTag.DataType = cUDLTag.Datatype;
                    cTag.Program = cUDLTag.Program;
                    cTag.PLCMaker = cUDLTag.PLCMaker;
                    cTag.Description = cUDLTag.Description;

                    if (cUDLTag.Note != string.Empty)
                        cTag.Note = cUDLTag.Note;

                    if (m_emPLCMaker == EMPLCMaker.Siemens)
                    {
                        cTag.Address = GetSiemensAddress(cUDLTag.Address);

                        if (cTag.DataType.Equals(EMDataType.Block))
                            cTag.UDTType = cUDLTag.UDTType;
                    }
                    else if (m_emPLCMaker == EMPLCMaker.LS)
                    {
                        if (!bLsDDEA && !cUDLTag.Address.StartsWith("%"))
                            cTag.Address = GetLSDDEAAddress(cUDLTag.Address, cUDLTag.Datatype); //자리수 맞춤
                        else
                            cTag.Address = cUDLTag.Address;

                        if (cTag.Description == string.Empty)
                            cTag.Description = cTag.Name;
                    }
                    else
                        cTag.Address = cUDLTag.Address;

                    if (m_emPLCMaker != EMPLCMaker.Rockwell)
                    {
                        if (bAddressKeyCheck)
                        {
                            if (cUDLTag.Address != string.Empty)
                                cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                            else
                                cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);
                        }
                        else
                        {
                            if (cUDLTag.Name != string.Empty)
                                cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);
                            else
                                cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                        }
                    }
                    else
                    {
                        if (cUDLTag.Name != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);
                        else
                            cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                    }

                    if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    {
                        if (CMelsecPlc.IsMelsecHexa(cUDLTag.Address))
                            cTag.AddressType = EMAddressType.Hexa;
                        else
                            cTag.AddressType = EMAddressType.Decimal;
                    }

                    cTagS.Add(cTag.Key, cTag);

                    if (m_emPLCMaker == EMPLCMaker.Siemens)
                    {
                        string sTempAddressKey = string.Empty;

                        if (cUDLTag.Address != string.Empty)
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                        else
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);

                        m_cAddressGlobalTagS.Add(sTempAddressKey, cTag);
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                return null;
            }
            return cTagS;
        }

        private string GetSiemensAddress(string sAddress)
        {
            string sNewAddress = string.Empty;

            try
            {
                string sHeader = string.Empty;
                string sIndexFirst = string.Empty;
                //string sIndexSecond = string.Empty;
                int iDigit = -1;

                string[] sAddressPart = null;
                sIndexFirst = sAddress;

                if (sAddress.Contains("."))
                {
                    sAddressPart = sAddress.Split('.');
                    //sIndexSecond = sAddress.Split('.')[1];
                    sIndexFirst = sAddress.Split('.')[0];
                }

                if (sAddress.StartsWith("DB") || sAddress.StartsWith("MB") || sAddress.StartsWith("MW") || sAddress.StartsWith("MD"))
                {
                    sHeader = sAddress.Substring(0, 2);
                    sIndexFirst = sIndexFirst.Replace(sHeader, "");
                }
                else if (sAddress.StartsWith("I") || sAddress.StartsWith("Q") || sAddress.StartsWith("M") ||
                         sAddress.StartsWith("T") || sAddress.StartsWith("C"))
                {
                    sHeader = sAddress.Substring(0, 1);
                    sIndexFirst = sIndexFirst.Replace(sHeader, "");
                }
                else
                    return sAddress;

                if (!sAddress.StartsWith("DB") && !sAddress.StartsWith("FB") && !sAddress.StartsWith("FC") && !sAddress.StartsWith("OB"))
                {
                    if (sIndexFirst.Length < 4)
                    {
                        iDigit = 4 - sIndexFirst.Length;

                        for (int i = 0; i < iDigit; i++)
                            sIndexFirst = sIndexFirst.Insert(0, "0");
                    }
                }

                if (sAddressPart != null/*sIndexSecond != string.Empty*/)
                {
                    sNewAddress = string.Format("{0}{1}", sHeader, sIndexFirst);

                    if (sAddressPart.Length > 1)
                    {
                        for (int i = 1; i < sAddressPart.Length; i++)
                        {
                            sNewAddress = sNewAddress + "." + sAddressPart[i];
                        }
                    }
                    //sNewAddress = string.Format("{0}{1}.{2}", sHeader, sIndexFirst, sIndexSecond);
                }
                else
                    sNewAddress = string.Format("{0}{1}", sHeader, sIndexFirst);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                return null;
            }

            return sNewAddress;
        }

        private string GetLSDDEAAddress(string sAddress, EMDataType emDataType)
        {
            //Word는 Header 포함 6자리, Bit는 Header 포함 7자리 - HeaderOne 기준

            string sDDEAAddress = string.Empty;

            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sIndexBit = string.Empty;
            string sDigit = string.Empty;
            int iIndexCount = 5;


            if (CLSPlc.IsLSHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

            if (sHeader.Equals("F"))
                return sAddress;

            if (sIndex.Contains("."))
            {
                sIndexBit = "." + sIndex.Split('.')[1];
                sIndex = sIndex.Split('.')[0];
            }

            if (emDataType == EMDataType.Bool && sIndexBit == string.Empty)
                iIndexCount = 6;

            for (int i = sIndex.Length; i < iIndexCount; i++)
                sDigit += "0";

            sDDEAAddress = string.Format("{0}{1}{2}{3}", sHeader, sDigit, sIndex, sIndexBit);

            return sDDEAAddress;
        }

        private void AddDBTagToGlobalTagS(CUDLBlock tempBlock, bool bAddressKeyCheck)
        {
            try
            {
                if (m_emPLCMaker == EMPLCMaker.Siemens)
                {
                    string sDBName = tempBlock.BlockName;

                    if (m_lstAnalysisDBs.Contains(sDBName))
                    {
                        if (tempBlock.InputTags.Count > 0)
                            AddDBTagToGlobalTag(tempBlock.InputTags, bAddressKeyCheck);

                        if (tempBlock.OutputTags.Count > 0)
                            AddDBTagToGlobalTag(tempBlock.OutputTags, bAddressKeyCheck);

                        if (tempBlock.InOutTags.Count > 0)
                            AddDBTagToGlobalTag(tempBlock.InOutTags, bAddressKeyCheck);

                        if (tempBlock.TempTags.Count > 0)
                            AddDBTagToGlobalTag(tempBlock.TempTags, bAddressKeyCheck);

                        if (tempBlock.STATTags.Count > 0)
                            AddDBTagToGlobalTag(tempBlock.STATTags, bAddressKeyCheck);
                    }
                }
                else
                {
                    if (tempBlock.InputTags.Count > 0)
                        AddDBTagToGlobalTag(tempBlock.InputTags, bAddressKeyCheck);

                    if (tempBlock.OutputTags.Count > 0)
                        AddDBTagToGlobalTag(tempBlock.OutputTags, bAddressKeyCheck);

                    if (tempBlock.InOutTags.Count > 0)
                        AddDBTagToGlobalTag(tempBlock.InOutTags, bAddressKeyCheck);

                    if (tempBlock.TempTags.Count > 0)
                        AddDBTagToGlobalTag(tempBlock.TempTags, bAddressKeyCheck);

                    if (tempBlock.STATTags.Count > 0)
                        AddDBTagToGlobalTag(tempBlock.STATTags, bAddressKeyCheck);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void AddDBTagToGlobalTag(List<CUDLTag> lstUDLTag, bool bAddressKeyCheck)
        {
            try
            {
                CTag cTag = null;

                foreach (CUDLTag cUDLTag in lstUDLTag)
                {
                    cTag = new CTag();

                    cTag.Channel = m_sChannel;
                    cTag.Name = cUDLTag.Name;
                    cTag.Address = cUDLTag.Address;
                    cTag.DataType = cUDLTag.Datatype;
                    cTag.Program = cUDLTag.Program;
                    cTag.PLCMaker = cUDLTag.PLCMaker;

                    if (cUDLTag.Description == string.Empty)
                        cTag.Description = cTag.Name;
                    else
                        cTag.Description = cUDLTag.Description;

                    if (bAddressKeyCheck)
                    {
                        if (cUDLTag.Address != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                    }
                    else
                    {
                        if (cUDLTag.Name != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                    }

                    if (!m_cGlobalTagS.ContainsKey(cTag.Key))
                        m_cGlobalTagS.Add(cTag.Key, cTag);

                    if (m_emPLCMaker == EMPLCMaker.Siemens)
                    {
                        string sTempAddressKey = string.Empty;

                        if (cUDLTag.Address != string.Empty)
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                        else
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);

                        m_cAddressGlobalTagS.Add(sTempAddressKey, cTag);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void GetLocalTagS(bool bAddressKeyCheck)
        {
            try
            {
                foreach (CUDLBlock tempblock in m_cUDL.Blocks.Values)
                {
                    if (tempblock.BlockType == EMBlockType.Datablock)
                    {
                        //AddDBTagToGlobalTagS(tempblock, bAddressKeyCheck);
                    }
                    else
                        CreateLocalTagS(tempblock, bAddressKeyCheck);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CreateLocalTagS(CUDLBlock cUDLBlock, bool bAddressKeyCheck)
        {
            try
            {
                string sFBName = cUDLBlock.BlockName;

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                {
                    if (cUDLBlock.InputTags.Count != 0)
                        MakeSiemensLocalTagS(cUDLBlock.InputTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.OutputTags.Count != 0)
                        MakeSiemensLocalTagS(cUDLBlock.OutputTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.InOutTags.Count != 0)
                        MakeSiemensLocalTagS(cUDLBlock.InOutTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.TempTags.Count != 0)
                        MakeSiemensLocalTagS(cUDLBlock.TempTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.STATTags.Count != 0)
                        MakeSiemensLocalTagS(cUDLBlock.STATTags, sFBName, bAddressKeyCheck);
                }
                else
                {
                    if (cUDLBlock.InputTags.Count != 0)
                        MakeLocalTagS(cUDLBlock.InputTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.OutputTags.Count != 0)
                        MakeLocalTagS(cUDLBlock.OutputTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.InOutTags.Count != 0)
                        MakeLocalTagS(cUDLBlock.InOutTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.TempTags.Count != 0)
                        MakeLocalTagS(cUDLBlock.TempTags, sFBName, bAddressKeyCheck);
                    if (cUDLBlock.STATTags.Count != 0)
                        MakeLocalTagS(cUDLBlock.STATTags, sFBName, bAddressKeyCheck);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void MakeLocalTagS(List<CUDLTag> lstUDLTag, string sFBName, bool bAddressKeyCheck)
        {
            try
            {
                CTag cTag = null;

                foreach (CUDLTag cUDLTag in lstUDLTag)
                {
                    cTag = new CTag();

                    cTag.Channel = m_sChannel;
                    cTag.Name = cUDLTag.Name;
                    cTag.Address = cUDLTag.Address;
                    cTag.DataType = cUDLTag.Datatype;
                    cTag.Program = cUDLTag.Program;
                    cTag.PLCMaker = cUDLTag.PLCMaker;

                    if (cUDLTag.Description == string.Empty)
                        cTag.Description = cTag.Name;
                    else
                        cTag.Description = cUDLTag.Description;

                    if (cUDLTag.Datatype == EMDataType.UserDefDataType)
                    {
                        cTag.UDTType = cUDLTag.UDTType;
                    }

                    if (bAddressKeyCheck)
                    {
                        if (cUDLTag.Address != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                    }
                    else
                    {
                        if (cUDLTag.Name != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                    }

                    m_cLocalTagS.Add(cTag.Key, cTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void MakeSiemensLocalTagS(List<CUDLTag> lstUDLTag, string sFBName, bool bAddressKeyCheck)
        {
            try
            {
                CTag cTag = null;

                foreach (CUDLTag cUDLTag in lstUDLTag)
                {
                    cTag = new CTag();

                    string tagAddress = cUDLTag.Address;
                    int iPos = tagAddress.IndexOf(".");

                    tagAddress = tagAddress.Remove(iPos);

                    string stemp = cUDLTag.Name;
                    iPos = stemp.IndexOf(".");

                    stemp = stemp.Substring(iPos);

                    tagAddress = tagAddress + stemp;

                    cTag.Channel = m_sChannel;
                    cTag.Name = cUDLTag.Name;
                    cTag.Address = tagAddress;
                    cTag.DataType = cUDLTag.Datatype;
                    cTag.Program = cUDLTag.Program;
                    cTag.PLCMaker = cUDLTag.PLCMaker;

                    if (cUDLTag.Description == string.Empty)
                        cTag.Description = cTag.Name;
                    else
                        cTag.Description = cUDLTag.Description;

                    if (cUDLTag.Datatype == EMDataType.UserDefDataType)
                    {
                        cTag.UDTType = cUDLTag.UDTType;
                        if (cUDLTag.UDTType.StartsWith("FB") || cUDLTag.UDTType.StartsWith("FC") || cUDLTag.UDTType.StartsWith("SFC") || cUDLTag.UDTType.StartsWith("SFB"))
                        {
                            if (!m_DicLocalFBNameS.ContainsKey(tagAddress))
                                m_DicLocalFBNameS.Add(tagAddress, cTag.UDTType);
                        }
                    }

                    if (bAddressKeyCheck)
                    {
                        if (cUDLTag.Address != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                    }
                    else
                    {
                        if (cUDLTag.Name != string.Empty)
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Name);
                        else
                            cTag.Key = string.Format("[{0}]{1}[1]", cTag.Channel, cTag.Address);
                    }

                    if (!m_cLocalTagS.ContainsKey(cTag.Key))
                        m_cLocalTagS.Add(cTag.Key, cTag);


                    string sTempAddressKey = string.Empty;

                    if (cUDLTag.Address != string.Empty)
                        sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                    else
                        sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);

                    if (!m_cAddressLocalTagS.ContainsKey(sTempAddressKey))
                        m_cAddressLocalTagS.Add(sTempAddressKey, cTag);

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        #endregion

        #region Methods of Step Generate

        private CStepS GetStepS()
        {
            CStepS cStepS = new CStepS();
            try
            {
                //if (m_emPLCMaker == EMPLCMaker.Rockwell)
                //    return cStepS;

                foreach (CUDLBlock cBlock in m_cUDL.Blocks.Values)
                {
                    if (cBlock.BlockType != EMBlockType.Datablock)
                    {
                        m_sBlockName = cBlock.BlockName;

                        int iStepCountBeforeBlock = cStepS.Count;

                        string sLogMassage = string.Format("Start Analysis Block [{0}]", m_sBlockName);
                        CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);

                        m_sOpenedDBName = string.Empty;
                        m_sOpenedDIName = string.Empty;

                        if (cBlock.BlockType != EMBlockType.DummryBlock)
                            m_DicFB.Add(cBlock.BlockName, cBlock);

                        foreach (CUDLRoutine cRoutine in cBlock.Routines)
                        {
                            m_lstForNextControl.Clear();
                            m_lstCallControl.Clear();
                            m_lstMasterControl.Clear();

                            foreach (CUDLLogic cLogic in cRoutine.Logics)
                            {
                                CStep cStep = new CStep();

                                if ((m_emPLCMaker.Equals(EMPLCMaker.Siemens) || m_emPLCMaker.Equals(EMPLCMaker.Rockwell)) && cLogic.SubLogicS.Count > 0)
                                    m_DicSubLogic = cLogic.SubLogicS;

                                if (m_emPLCMaker != EMPLCMaker.Siemens && m_emPLCMaker != EMPLCMaker.Rockwell)
                                    cStep.Program = cRoutine.RoutineName;
                                else if (m_emPLCMaker == EMPLCMaker.Rockwell)
                                    cStep.Program = m_sBlockName + "." + cRoutine.RoutineName;
                                else
                                    cStep.Program = m_sBlockName;

                                cStep.StepIndex = cLogic.StepIndex;
                                string sKey = string.Format("{0}.{1}", cStep.Program, cStep.StepIndex);
                                cStep.Key = sKey;


                                if (cBlock.BlockName.Equals("FB45") && cLogic.StepIndex == 1)//if (cBlock.BlockName.Contains("FB117") && cLogic.StepIndex == 3)
                                {

                                }

                                m_cStepCur = cStep;
                                m_lstCFBInfo = new List<CFB_Info>();

                                CreateStep(cLogic);
                                CheckStepRefTags();

                                CheckProgramControls();



                                sLogMassage = string.Format("Step {0} had analysis. There are {1} Contacts and {2} Coils in this step.", sKey, cStep.ContactS.Count, cStep.CoilS.Count);
                                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
                                CConverterLogWriter.WriteEmptyLine();
                                cStepS.Add(sKey, cStep);
                            }
                        }

                        int iStepCountAfterBlock = cStepS.Count;

                        int iTemp = iStepCountAfterBlock - iStepCountBeforeBlock;

                        sLogMassage = string.Format("Finish Analysis Block [{0}]. Total create {1} steps", m_sBlockName, iTemp);
                        CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
                    }
                    else if (cBlock.BlockType == EMBlockType.Datablock)
                    {
                        if (cBlock.BlockName == "DB1" || cBlock.BlockAddress == "DB1")
                        {
                            AddDBTagToGlobalTagS(cBlock,true);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            List<CStep> lstStep = cStepS.Values.Where(b => b.FBInfoList.Count > 0).ToList();
            return cStepS;
        }

        private void CheckProgramControls()
        {
            try
            {
                // FORNEXT Control
                if (m_lstForNextControl.Count != 0)
                {
                    foreach (string sValue in m_lstForNextControl)
                        m_cStepCur.ForNextControl += string.Format("{0}*", sValue);
                }

                //CALL Control
                if (m_lstCallControl.Count != 0)
                {
                    foreach (string sValue in m_lstCallControl)
                        m_cStepCur.CallControl += string.Format("{0}*", sValue);
                }

                //MASTER Control
                if (m_lstMasterControl.Count != 0)
                {
                    foreach (string sValue in m_lstMasterControl)
                        m_cStepCur.MasterControl += string.Format("{0}*", sValue);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateStep(CUDLLogic cLogic)
        {
            try
            {
                List<int> PreCont = new List<int>();
                List<int> PreCoil = new List<int>();
                List<int> NextCont = new List<int>();
                List<int> NextCoil = new List<int>();

                m_iOperatorIndex = 0;

                m_iLogicLevel = 0;
                m_iPrevLogicIsCoil = 0;
                m_iIsNewStartLogic = 0;

                string sLogic = cLogic.Logic.Replace(" ", string.Empty).Replace("\t", string.Empty);
                bool bIsInitial = true;

                if (sLogic.StartsWith("["))
                    CreateOptLogic(sLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
                else
                    CreateComLogic(sLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateOptLogic(string sLogic, List<int> PreCont, List<int> PreCoil, List<int> NextCont, List<int> NextCoil, bool bIsInitial)
        {
            try
            {
                string sOptionLogicUnit = GetOptionLogicUnit(sLogic);
                List<string> lstOptionLogicPart = GetOptionLogicPart(sOptionLogicUnit);
                m_iLogicLevel++;
                List<int> PreContOfNextSymbol = new List<int>();
                List<int> PreCoilOfNextSymbol = new List<int>();

                for (int i = 0; i < lstOptionLogicPart.Count; i++)
                {
                    if (i > 0)
                    {
                        if (m_iLastNextContactIndex > -1)
                            m_lstComSubLogicLastNextContact.Add(m_iLastNextContactIndex);
                    }

                    m_iLastNextContactIndex = -1;

                    List<int> TempPreCont = new List<int>();
                    List<int> TempPreCoil = new List<int>();

                    SetRelationList(PreCont, TempPreCont);
                    SetRelationList(PreCoil, TempPreCoil);

                    if (lstOptionLogicPart[i].StartsWith("["))
                        CreateOptLogic(lstOptionLogicPart[i], TempPreCont, TempPreCoil, NextCont, NextCoil, bIsInitial);
                    else
                        CreateComLogic(lstOptionLogicPart[i], TempPreCont, TempPreCoil, NextCont, NextCoil, bIsInitial);

                    SetRelationList(NextCont, PreContOfNextSymbol);
                    SetRelationList(NextCoil, PreCoilOfNextSymbol);

                    NextCont.Clear();
                    NextCoil.Clear();
                }

                m_iLogicLevel--;

                if (m_iLastNextContactIndex > -1)
                    m_lstComSubLogicLastNextContact.Add(m_iLastNextContactIndex);

                bIsInitial = false;

                int iBehindLogicStartPos = sOptionLogicUnit.Length;
                string sBehindLogic = sLogic.Remove(0, iBehindLogicStartPos);

                if (sBehindLogic.Length > 3 && Regex.IsMatch(sBehindLogic, @"[A-Z]"))
                {
                    PreCont.Clear();
                    PreCoil.Clear();

                    SetRelationList(PreContOfNextSymbol, PreCont);
                    SetRelationList(PreCoilOfNextSymbol, PreCoil);

                    NextCont.Clear();
                    NextCoil.Clear();

                    if (sBehindLogic.StartsWith("["))
                        CreateOptLogic(sBehindLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
                    else
                        CreateComLogic(sBehindLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
                }
                else
                {
                    SetRelationList(PreContOfNextSymbol, NextCont);
                    SetRelationList(PreCoilOfNextSymbol, NextCoil);
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateComLogic(string sLogic, List<int> PreCont, List<int> PreCoil, List<int> NextCont, List<int> NextCoil, bool bIsInitial)
        {
            try
            {
                if (sLogic.Length > 3 && Regex.IsMatch(sLogic, @"[A-Z]"))
                {
                    string sSymbolUnit = GetSymbolUnit(sLogic);
                    string sCommand = sSymbolUnit.Split('(')[0];

                    bool bIsAfterOptLogic = CheckIsAfterOptRelation(PreCont);

                    if (bIsAfterOptLogic)
                        m_lstComSubLogicLastNextContact.Clear();

                    m_iLastNextContactIndex = -1;
                    CreateSymbolObject(sCommand, sSymbolUnit, PreCont, PreCoil, bIsInitial);

                    int iBehindLogicStartPos = sSymbolUnit.Length;
                    string sBehindLogic = sLogic.Remove(0, iBehindLogicStartPos);

                    bIsInitial = false;

                    if (bIsInitial == false && m_iIsNewStartLogic == 0)
                    {
                        bIsInitial = true;
                        PreCoil.Clear();
                        PreCont.Clear();
                    }

                    if (sBehindLogic.Length > 3 && Regex.IsMatch(sBehindLogic, @"[A-Z]"))
                    {
                        if (sBehindLogic.StartsWith("["))
                            CreateOptLogic(sBehindLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
                        else
                            CreateComLogic(sBehindLogic, PreCont, PreCoil, NextCont, NextCoil, bIsInitial);
                    }
                    else
                    {
                        SetRelationList(PreCont, NextCont);
                        SetRelationList(PreCoil, NextCoil);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateSymbolObject(string sCommand, string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bIsInitial)
        {
            try
            {
                string sCommandTemp = sCommand;
                string sInstanceDBName = string.Empty;
                bool bCheckInstanceDB = false;
                bool bCoil = false;
                if (CheckIsLocalInstanceDB(sCommand))
                {
                    bCheckInstanceDB = true;
                    sInstanceDBName = sCommand;
                    sCommandTemp = m_DicLocalFBNameS[sInstanceDBName];
                }
                else if (CheckIsLocalSystemFB(sCommand))
                {
                    //string sFBName = sCommand;
                    //if (sCommand.Contains("."))
                    //    sFBName = sCommand.Split('.')[1];
                    //CFB_Info cFBInfo = new CFB_Info();
                    //cFBInfo.FBNumber = sFBName;
                    //m_cStepCur.FBInfoList.Add(cFBInfo);
                    bCoil = true;
                    sCommandTemp = m_DicLocalFBNameS[sCommand];
                }
                else if (CheckIsGlobalInstanceDB(sCommand))
                {
                    bCheckInstanceDB = true;
                    sInstanceDBName = FindInstanceDBName(sCommand);
                    sCommandTemp = FindFBName(sCommand);
                }

                if (sCommand == "OPN")
                {
                    string sDBName = string.Empty;

                    sDBName = sSymbolUnit.Substring(4);
                    int iPos = sDBName.LastIndexOf(")");
                    sDBName = sDBName.Remove(iPos);

                    if (sDBName.StartsWith("DB"))
                        m_sOpenedDBName = sDBName;
                    else if (sDBName.StartsWith("DI"))
                        m_sOpenedDIName = sDBName;
                }

                int iBeforeNewStart = m_iIsNewStartLogic;

                if (CheckIsFunctionCommand(sCommandTemp))
                {
                    string sFBName = sCommand;
                    if (sCommand.Contains("."))
                        sFBName = sCommand.Split('.')[1];

                    m_cFBInfoCur = new CFB_Info();
                    m_cFBInfoCur.FBDescription = sFBName;
                    m_cFBInfoCur.FBNumber = sCommandTemp;

                    if (bCoil) m_cFBInfoCur.LastFB = true;

                    m_bSetFB = true;

                    CreateSymbolObjectRelatedFB(FindBlock(sCommandTemp), sSymbolUnit, PreCont, PreCoil, bIsInitial, bCheckInstanceDB, sInstanceDBName);

                    m_cStepCur.FBInfoList.Add(m_cFBInfoCur);
                    m_lstCFBInfo.Add(m_cFBInfoCur);

                    m_bSetFB = false;
                }
                else if (IsContactCommand(sCommand, sSymbolUnit))
                    CreateContactSymbol(sCommand, sSymbolUnit, PreCont, PreCoil, bIsInitial);
                else
                    CreateCoilSymbol(sCommand, sSymbolUnit, PreCont, PreCoil, bIsInitial);

                if (iBeforeNewStart == 0)
                    m_iIsNewStartLogic = 1;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetInstruction(string sCommand, string sSymbolUnit)
        {
            string sInstruction = sCommand;

            try
            {
                string sUsedAddress = GetLogicUnitUsedAddress(sSymbolUnit);
                List<string> lstUsedAddress = GetUsedAddress(sUsedAddress);

                foreach (string sTemp in lstUsedAddress)
                {
                    string sTemp1 = string.Format("\t{0}", sTemp);
                    sInstruction += sTemp1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sInstruction;
        }

        private string GetLogicUnitUsedAddress(string sSymbolUnit)
        {
            string sUsedAddress = string.Empty;

            try
            {
                int iLevel = 0;
                bool bInBracket = false;

                for (int i = 0; i < sSymbolUnit.Length; i++)
                {
                    if (sSymbolUnit[i] == '(')
                    {
                        if (iLevel > 0)
                            sUsedAddress = sUsedAddress + sSymbolUnit[i];

                        iLevel = iLevel + 1;

                        if (iLevel > 0)
                        {
                            bInBracket = true;
                        }
                    }
                    else if (sSymbolUnit[i] == ')')
                    {
                        iLevel = iLevel - 1;

                        if (iLevel == 0)
                        {
                            bInBracket = false;
                            break;
                        }

                        sUsedAddress = sUsedAddress + sSymbolUnit[i];
                    }
                    else if (bInBracket)
                        sUsedAddress = sUsedAddress + sSymbolUnit[i];
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sUsedAddress;
        }

        private string GetCompareCommandInstruction(string sInstruction)
        {
            string sCompareInstruction = string.Empty;

            try
            {
                string[] sTemp = sInstruction.Split('\t');
                string sCommand = sTemp[0];

                if (sCommand.Contains("EQU"))
                    sCommand = sCommand.Replace("EQU", "=");
                else if (sCommand.Contains("GRT"))
                    sCommand = sCommand.Replace("GRT", ">");
                else if (sCommand.Contains("GEQ"))
                    sCommand = sCommand.Replace("GEQ", ">=");
                else if (sCommand.Contains("LES"))
                    sCommand = sCommand.Replace("LES", "<");
                else if (sCommand.Contains("LEQ"))
                    sCommand = sCommand.Replace("LEQ", "<=");
                else if (sCommand.Contains("NEQ"))
                    sCommand = sCommand.Replace("NEQ", "<>");

                if (sTemp.Length > 2)
                    sCompareInstruction = string.Format("{0} {1} {2}", sTemp[1], sCommand, sTemp[2]);
                else
                    sCompareInstruction = string.Format("{0} {1}", sCommand, sTemp[1]);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sCompareInstruction;
        }

        private void CreateSymbolObjectRelatedFB(CUDLBlock cUDLBlock, string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bIsInitial, bool bCheckInstanceDB, string sInstanceDBName)
        {
            try
            {
                m_lstContactStepIndexTemp.AddRange(PreCont);

                List<CContact> lstFBArgumentContact = GetFBArgumentContact(cUDLBlock, sSymbolUnit);
                List<string> lstUsedFBAddress = GetUsedFBAddress(sSymbolUnit);

                //SetFBArgumentLineINOUTContact(lstFBArgumentContact, PreCont, PreCoil, bIsInitial);

                if (m_lstCFBInfo.Count > 0)
                {
                    if (m_lstCFBInfo[m_lstCFBInfo.Count - 1].Relation.PrevContactS.Count > 0)
                        CreateRelation(m_cFBInfoCur.Relation, m_lstCFBInfo[m_lstCFBInfo.Count - 1].Relation.PrevContactS, PreCoil);
                }

                else
                    CreateRelation(m_cFBInfoCur.Relation, PreCont, PreCoil);

                List<CContact> lstFBArgumentContactExceptedENENO = GetFBArgumentContactExpcetedENENO(lstFBArgumentContact);
                CreateFBParameterObject(lstUsedFBAddress, lstFBArgumentContactExceptedENENO, PreCont, PreCoil, bCheckInstanceDB, sInstanceDBName);

                PreCont.Clear();
                PreCont.AddRange(m_lstContactStepIndexTemp);
                m_lstContactStepIndexTemp.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void SetFBArgumentLineINOUTContact(List<CContact> lstFBArgumentContact, List<int> PreCont, List<int> PreCoil, bool bIsInitial)
        {
            try
            {
                CContact cLineInContact = lstFBArgumentContact[0];
                cLineInContact.IsInitial = bIsInitial;
                CreateRelation(cLineInContact.Relation, PreCont, PreCoil);
                CreateNextRelation(PreCont, PreCoil, false, cLineInContact.StepIndex);

                PreCont.Clear();
                PreCoil.Clear();

                int iLineOutContact = m_iInputInOutTagCount;

                if (m_bCheckFBUsedENENO)
                    iLineOutContact += 1;

                CContact cLineOutContact = lstFBArgumentContact[iLineOutContact];
                PreCont.Add(cLineOutContact.StepIndex);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private List<CContact> GetFBArgumentContactExpcetedENENO(List<CContact> lstFBArgumentContact)
        {
            List<CContact> lstFBArgumentContactExceptedENENO = null;

            try
            {
                lstFBArgumentContactExceptedENENO = new List<CContact>();

                if (m_emPLCMaker == EMPLCMaker.LS)
                {
                    foreach (CContact cContact in lstFBArgumentContact)
                    {
                        if (cContact.Instruction.Contains(".EN"))
                            continue;

                        lstFBArgumentContactExceptedENENO.Add(cContact);
                    }
                }
                else if (m_emPLCMaker == EMPLCMaker.Siemens)
                {
                    foreach (CContact cContact in lstFBArgumentContact)
                    {
                        string[] saInstruction = cContact.Instruction.Split('.');

                        if (saInstruction[1].Equals("EN") || saInstruction[1].Equals("ENO"))
                            continue;

                        lstFBArgumentContactExceptedENENO.Add(cContact);
                    }
                }

                else
                {
                    lstFBArgumentContactExceptedENENO.AddRange(lstFBArgumentContact);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstFBArgumentContactExceptedENENO;
        }

        private void CreateFBParameterObject(List<string> lstUsedFBAddress, List<CContact> lstFBArgumentContactExceptedENENO, List<int> lstPreCont, List<int> lstPreCoil, bool bCheckInstanceDB, string sInstanceDBName)
        {
            try
            {
                int iTotalObjectCount = lstUsedFBAddress.Count;

                List<int> lstFBContParaIndex = new List<int>();
                List<int> lstFBCoilParaIndex = new List<int>();


                List<int> TempPreCont = new List<int>();
                List<int> TempPreCoil = new List<int>();

                for (int i = 0; i < iTotalObjectCount; i++)
                {
                    CContact cContact = null;
                    CCoil cCoil = null;
                    int iLastLogicUnitIndex = -1;

                    m_lstComSubLogicLastNextContact.Clear();

                    if (i < m_iInputInOutTagCount)
                    {
                        iLastLogicUnitIndex = CreateFBParameterContact(cContact, lstFBArgumentContactExceptedENENO[i], lstUsedFBAddress[i], TempPreCont, TempPreCoil, bCheckInstanceDB, sInstanceDBName);

                        if (m_lstComSubLogicLastNextContact.Count > 0)
                        {
                            lstFBContParaIndex.AddRange(m_lstComSubLogicLastNextContact);
                        }
                        else if (iLastLogicUnitIndex != -1)
                            lstFBContParaIndex.Add(iLastLogicUnitIndex);

                    }
                    else
                    {
                        if (m_cFBInfoCur.Relation.PrevContactS.Count > 0)
                        {
                            TempPreCont = new List<int>();
                            TempPreCont.AddRange(m_cFBInfoCur.Relation.PrevContactS);
                        }

                        iLastLogicUnitIndex = CreateFBParameterCoil(cCoil, lstFBArgumentContactExceptedENENO[i], lstUsedFBAddress[i], TempPreCont, TempPreCoil, bCheckInstanceDB, sInstanceDBName);

                        if (iLastLogicUnitIndex != -1)
                            lstFBCoilParaIndex.Add(iLastLogicUnitIndex);
                    }
                }

                MappingFBParameter(lstFBContParaIndex, lstFBCoilParaIndex);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private int CreateFBParameterCoil(CCoil cParameterCoil, CContact cArgumentContact, string sUsedFBAddress, List<int> TempPreCont, List<int> TempPreCoil, bool bCheckInstanceDB, string sInstanceDBName)
        {
            int iCoilIndex = -1;
            try
            {
                //TempPreCont.Clear();
                //TempPreCoil.Clear();

                //TempPreCont.Add(cArgumentUDLTag.UnitIndex);

                //SubLogic 추가
                if (sUsedFBAddress != string.Empty)
                {
                    cParameterCoil = GetFBParameterCoil(sUsedFBAddress, false, false, m_cStepCur.Key);
                    iCoilIndex = cParameterCoil.StepIndex;
                }
                else if (sUsedFBAddress == string.Empty && bCheckInstanceDB)
                {
                    //string sArgumentType = cArgumentUDLTag.Instruction.Split('.')[1];
                    //string sInstanceDBAddress = string.Format("{0}.{1}", sInstanceDBName, sArgumentType);

                    //cParameterCoil = GetFBParameterCoil(sInstanceDBAddress, false, false, m_cStepCur.Key);
                    //iCoilIndex = cParameterCoil.StepIndex;
                    return iCoilIndex;
                }
                else if (sUsedFBAddress == string.Empty)
                    return iCoilIndex;

                //CreateRelation(cParameterCoil.Relation, m_lstContactStepIndexTemp, TempPreCoil);
                CreateRelation(cParameterCoil.Relation, TempPreCont, TempPreCoil);
                m_cStepCur.CoilS.Add(cParameterCoil);
                m_cFBInfoCur.CoilS.Add(cParameterCoil);

                if (m_cFBInfoCur.DicItem.ContainsKey(cArgumentContact.Instruction))
                    m_cFBInfoCur.DicItem[cArgumentContact.Instruction] = cParameterCoil.StepIndex.ToString();

                //CreateNextRelation(m_lstContactStepIndexTemp, TempPreCoil, true, cParameterCoil.StepIndex);
                //CreateNextRelation(cStep, TempPreCont, TempPreCoil, true, cParameterCoil.UnitIndex);

                //TempPreCont.Clear();
                //TempPreCoil.Clear();

                //TempPreCoil.Add(cParameterCoil.UnitIndex);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return iCoilIndex;
        }

        private int CreateFBParameterContact(CContact cParameterContact, CContact cArgumentContact, string sUsedFBAddress, List<int> TempPreCont, List<int> TempPreCoil, bool bCheckInstanceDB, string sInstanceDBName)
        {
            int iContactIndex = -1;
            try
            {
                //if (sUsedFBAddress != string.Empty)
                //{
                if (sUsedFBAddress.Contains("SubLogic"))
                 {
                    CreateSubLogicSymbol(sUsedFBAddress, TempPreCont, TempPreCoil);
                    iContactIndex = m_iLastNextContactIndex;

                    string sLogic = m_DicSubLogic[sUsedFBAddress];
                    string[] saLogic = Regex.Split(@sLogic, @"\),");
                    int iSubLogicLength = saLogic.Length;

                    if (sLogic.Contains("]["))
                    {
                        iSubLogicLength = 0;
                        saLogic = Regex.Split(@sLogic, @"\]\[");
                        
                        foreach(string sTempLogic in saLogic)
                        {
                            string[] saTempLogic = Regex.Split(sTempLogic, @"\),");
                            if (iSubLogicLength < saTempLogic.Length)
                            {
                                iSubLogicLength = saTempLogic.Length;
                            }
                        }
                    }

                    if (m_cFBInfoCur.DicItem.ContainsKey(cArgumentContact.Instruction))
                    {
                        m_cFBInfoCur.DicItem[cArgumentContact.Instruction] = sUsedFBAddress + ";" + iSubLogicLength;

                        //string sIndex = "";
                        //if (m_lstComSubLogicLastNextContact.Count > 0)
                        //{
                        //    foreach (int iSubLogicIndex in m_lstComSubLogicLastNextContact)
                        //        sIndex = sIndex + iSubLogicIndex.ToString() + ";";

                        //    m_cFB_InfoCur.DicItem[cArgumentContact.Instruction] = sUsedFBAddress + ";" + sIndex;
                        //}
                        //else
                        //    m_cFB_InfoCur.DicItem[cArgumentContact.Instruction] = sUsedFBAddress + ";" + iContactIndex.ToString() + ";";
                    }

                    m_lstContactStepIndexTemp.AddRange(TempPreCont);

                    TempPreCont.Clear();
                    TempPreCoil.Clear();

                    return iContactIndex;
                }
                else
                {
                    if (IsConstant(sUsedFBAddress) || sUsedFBAddress == "")
                    {
                        if (m_cFBInfoCur.DicItem.ContainsKey(cArgumentContact.Instruction))
                        {
                            if (sUsedFBAddress == "") sUsedFBAddress = "...";
                            m_cFBInfoCur.DicItem[cArgumentContact.Instruction] = sUsedFBAddress;
                        }
                    }
                    cParameterContact = GetFBParameterContact(sUsedFBAddress, true, false, m_cStepCur.Key);
                    iContactIndex = cParameterContact.StepIndex;
                }

                //else if(IsConstant(sUsedFBAddress))
                //{
                //    //return iContactIndex;
                //}
                //else
                //{
                //    cParameterContact = GetFBParameterContact(sUsedFBAddress, true, false, m_cStepCur.Key);
                //    iContactIndex = cParameterContact.StepIndex;
                //}
                //}
                //else if (sUsedFBAddress == string.Empty && bCheckInstanceDB)
                //{
                //    //int Index = cArgumentUDLTag.Instruction.IndexOf(".");

                //    //string sArgumentType = cArgumentUDLTag.Instruction.Remove(0, Index + 1);
                //    //string sInstanceDBAddress = string.Format("{0}.{1}", sInstanceDBName, sArgumentType);

                //    //cParameterContact = GetFBParameterContact(sInstanceDBAddress, true, false, m_cStepCur.Key);
                //    //iContactIndex = cParameterContact.StepIndex;

                //    return iContactIndex;
                //}
                //else if (sUsedFBAddress == string.Empty)
                //    return iContactIndex;

                m_lstContactStepIndexTemp.Add(cParameterContact.StepIndex);
                CreateRelation(cParameterContact.Relation, TempPreCont, TempPreCoil);
                m_cStepCur.ContactS.Add(cParameterContact);
                m_cFBInfoCur.ContactS.Add(cParameterContact);

                CreateNextRelation(TempPreCont, TempPreCoil, false, cParameterContact.StepIndex);

                TempPreCont.Clear();
                TempPreCoil.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iContactIndex;
        }

        private void CreateSubLogicSymbol(string sSubLogicKey, List<int> PreCont, List<int> PreCoil)
        {
            try
            {
                string sSubLogic = m_DicSubLogic[sSubLogicKey].Replace(" ", string.Empty).Replace("\t", string.Empty);

                PreCont.Clear();
                PreCoil.Clear();
                List<int> TempNextCont = new List<int>();
                List<int> TempNextCoil = new List<int>();

                if (sSubLogic.StartsWith("["))
                    CreateOptLogic(sSubLogic, PreCont, PreCoil, TempNextCont, TempNextCoil, true);
                else
                    CreateComLogic(sSubLogic, PreCont, PreCoil, TempNextCont, TempNextCoil, true);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private CCoil GetFBParameterCoil(string sAddress, bool bCheckDoubleWord, bool bCheck4SizeCommand, string sStepKey)
        {
            CCoil cCoil = null;

            try
            {
                string sSymbolUnit = string.Format("OUT({0})", sAddress);

                cCoil = new CCoil();
                cCoil.Command = sSymbolUnit.Split('(')[0];
                cCoil.StepIndex = m_iOperatorIndex++;
                cCoil.Instruction = GetInstruction(cCoil.Command, sSymbolUnit);
                cCoil.CoilType = EMCoilType.Function;//Bit;
                cCoil.Step = sStepKey;

                CreateCoilContent(sAddress, cCoil, bCheckDoubleWord, bCheck4SizeCommand, sStepKey, true);

                string sLogMassage = string.Format("Create FB Coil. Contact Address: [{0}], StepKey: [{1}], Unit Index: [{2}].", sAddress, m_cStepCur.Key, cCoil.StepIndex);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cCoil;
        }

        private CContact GetFBParameterContact(string sAddress, bool bIsInitial, bool bCheckDoubleWord, string sStepKey)
        {
            CContact cContact = null;

            try
            {
                string sSymbolUnit = string.Format("XIC({0})", sAddress);

                cContact = new CContact();

                cContact.ContactType = EMContactType.Function;//EMContactType.Bit;
                if (IsConstant(sAddress) || sAddress == "...")
                    cContact.ContactType = EMContactType.Constant;

                cContact.Operator = sSymbolUnit.Split('(')[0];
                cContact.StepIndex = m_iOperatorIndex++;
                cContact.IsInitial = bIsInitial;
                cContact.Instruction = GetInstruction(cContact.Operator, sSymbolUnit);
                cContact.Step = sStepKey;

                CreateContactContent(sAddress, cContact, bCheckDoubleWord, sStepKey, false);

                string sLogMassage = string.Format("Create FB Contact. Contact Address: [{0}], StepKey: [{1}], Unit Index: [{2}].", sAddress, m_cStepCur.Key, cContact.StepIndex);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cContact;
        }

        private List<CContact> GetFBArgumentContact(CUDLBlock cUDLBlock, string sSymbolUnit)
        {
            List<CContact> lstFBArgumentContact = null;

            try
            {
                if (cUDLBlock.BlockName.Contains("ACT_10") || cUDLBlock.BlockName.Contains("FB400"))
                {

                }

                List<CUDLTag> lstFBArgument = new List<CUDLTag>();
                Dictionary<int, CUDLTag> lstTempLSInOutTag = new Dictionary<int, CUDLTag>();
                lstFBArgumentContact = new List<CContact>();

                lstFBArgument.AddRange(cUDLBlock.InputTags);
                lstFBArgument.AddRange(cUDLBlock.InOutTags);

                m_iInputInOutTagCount = lstFBArgument.Count;

                lstFBArgument.AddRange(cUDLBlock.OutputTags);

                if (m_emPLCMaker == EMPLCMaker.LS)
                {
                    lstFBArgument.Sort(); //FB 내부 Parameter 쓰여지는 순서의 기준이 Address

                    foreach (CUDLTag cUDLTag in lstFBArgument)//LS InOut Tag Check, FB 같은 위상에 좌/우 Parameter 놓임
                    {
                        CUDLTag cInOutTag = null;

                        if (cUDLTag.LSFBInOutTagCheck)//InOut Tag Check
                        {
                            cInOutTag = (CUDLTag)cUDLTag.Clone();
                            int iInOutTagIndex = lstFBArgument.IndexOf(cUDLTag);
                            lstTempLSInOutTag.Add(iInOutTagIndex + m_iInputInOutTagCount, cInOutTag);
                        }
                    }

                    if (lstTempLSInOutTag.Count != 0)
                    {
                        foreach (int iInOutIndex in lstTempLSInOutTag.Keys)
                            lstFBArgument.Insert(iInOutIndex, lstTempLSInOutTag[iInOutIndex]);
                    }
                }

                CreateFBParameterENENO(cUDLBlock.BlockName, sSymbolUnit, lstFBArgument);

                CContact cContact = null;

                foreach (CUDLTag cUDLTag in lstFBArgument)
                {
                    cContact = new CContact();
                    cContact.ContactType = EMContactType.Function;//EMContactType.SystemFunction;
                    cContact.StepIndex = m_iOperatorIndex++;
                    cContact.Operator = "UDF_Argument";
                    cContact.Instruction = string.Format("{0}", cUDLTag.Name);
                    cContact.Step = m_cStepCur.Key;

                    lstFBArgumentContact.Add(cContact);
                    //cStep.ContactS.Add(cContact);
                }

                foreach (CUDLTag cUDLTag in cUDLBlock.InputTags)// for (int i = 0; i<cUDLBlock.InputTags.Count; i++)
                {
                    string sAddress = cUDLTag.Name;
                    m_cFBInfoCur.In_ItemNameList.Add(sAddress);
                    m_cFBInfoCur.DicItem.Add(sAddress, "");
                }

                foreach (CUDLTag cUDLTag in cUDLBlock.InOutTags)  //for (int i = 0; i < cUDLBlock.InOutTags.Count; i++) 
                {
                    string sAddress = cUDLTag.Name;
                    m_cFBInfoCur.InOut_ItemNameList.Add(sAddress);
                    m_cFBInfoCur.DicItem.Add(sAddress, "");
                }

                foreach (CUDLTag cUDLTag in cUDLBlock.OutputTags)  //for (int i = 0; i < cUDLBlock.OutputTags.Count; i++)
                {
                    string sAddress = cUDLTag.Name;
                    m_cFBInfoCur.Out_ItemNameList.Add(sAddress);
                    m_cFBInfoCur.DicItem.Add(sAddress, "");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstFBArgumentContact;
        }

        private void CreateFBParameterENENO(string sFBName, string sSymbolUnit, List<CUDLTag> lstFBParameter)
        {
            try
            {
                string sUsedAddress = sSymbolUnit.Split('(')[1].Replace(")", string.Empty);
                List<string> lstUsedAddress = GetUsedAddress(sUsedAddress);

                if (m_emPLCMaker == EMPLCMaker.LS && lstUsedAddress[0] != "LINEIN" && lstUsedAddress[1] != "LINEOUT") //EN, ENO쓰지 않는 경우
                {
                    m_bCheckFBUsedENENO = false;
                    return;
                }

                m_bCheckFBUsedENENO = true;

                CUDLTag cENOTag = new CUDLTag();
                cENOTag.Name = string.Format("{0}.ENO", sFBName);
                lstFBParameter.Insert(m_iInputInOutTagCount, cENOTag);
                m_cFBInfoCur.Out_ItemNameList.Add(cENOTag.Name);

                CUDLTag cENTag = new CUDLTag();
                cENTag.Name = string.Format("{0}.EN", sFBName);
                lstFBParameter.Insert(0, cENTag);
                m_cFBInfoCur.In_ItemNameList.Add(cENTag.Name);
                m_cFBInfoCur.DicItem.Add(cENTag.Name, "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private bool CheckIsFunctionCommand(string sCommand)
        {
            bool isTrue = false;
            try
            {
                if (m_DicFB.ContainsKey(sCommand))
                    isTrue = true;
                else if (sCommand.StartsWith("SFC") || sCommand.StartsWith("SFB"))
                    isTrue = true;
                else if (m_DicLocalFBNameS.ContainsKey(sCommand))
                    isTrue = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return isTrue;
        }

        private CUDLBlock FindBlock(string tempBlockName)
        {
            CUDLBlock tempBlock = null;
            try
            {
                if (m_DicFB.ContainsKey(tempBlockName))
                {
                    tempBlock = m_DicFB[tempBlockName];
                }
                else if (m_DicLocalFBNameS.ContainsKey(tempBlockName))
                {
                    string blockName = m_DicLocalFBNameS[tempBlockName];

                    if (m_DicFB.ContainsKey(blockName))
                        tempBlock = m_DicFB[blockName];
                    else if (m_DicSystemFC.ContainsKey(blockName))
                        tempBlock = m_DicSystemFC[blockName];
                    else
                    {
                        tempBlock = new CUDLBlock();
                        tempBlock.BlockName = blockName;
                        tempBlock.BlockType = EMBlockType.FunctionBlock;
                    }
                }
                else if (m_DicSystemFC.ContainsKey(tempBlockName))
                    tempBlock = m_DicSystemFC[tempBlockName];
                else
                {
                    tempBlock = new CUDLBlock();
                    tempBlock.BlockName = tempBlockName;
                    tempBlock.BlockType = EMBlockType.FunctionBlock;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return tempBlock;
        }

        private string FindFBName(string sCommand)
        {
            string sDBName = string.Empty;

            try
            {
                int iPos = sCommand.IndexOf(".");
                sDBName = sCommand.Substring(0, iPos);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sDBName;
        }

        private string FindInstanceDBName(string sCommand)
        {
            string sFBName = string.Empty;

            try
            {
                int iPos = sCommand.IndexOf(".");
                sFBName = sCommand.Remove(0, iPos + 1);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sFBName;
        }

        private bool CheckIsGlobalInstanceDB(string sCommand)
        {
            bool isTrue = false;

            try
            {
                if (!sCommand.Contains("."))
                    return false;

                int iPos = sCommand.IndexOf(".");
                string sLSGloblaDBTemp = sCommand.Substring(0, iPos);
                string sSiemensGlobalDBTemp = sCommand.Remove(0, iPos + 1);

                if (m_emPLCMaker == EMPLCMaker.LS && m_DicFB.ContainsKey(sLSGloblaDBTemp)
                    || m_emPLCMaker == EMPLCMaker.Siemens && sSiemensGlobalDBTemp.StartsWith("DB"))
                    isTrue = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return isTrue;
        }

        private bool CheckIsLocalInstanceDB(string sCommand)
        {
            try
            {
                if (m_emPLCMaker == EMPLCMaker.LS)
                    return false;

                if (m_DicLocalFBNameS.ContainsKey(sCommand))
                {
                    string sBlockName = m_DicLocalFBNameS[sCommand];
                    if (sBlockName.StartsWith("SFB") || sBlockName.StartsWith("SFC"))
                        return false;
                    else
                        return true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return false;
        }

        private bool CheckIsLocalSystemFB(string sCommand)
        {
            try
            {
                if (m_emPLCMaker == EMPLCMaker.LS)
                    return false;

                if (m_DicLocalFBNameS.ContainsKey(sCommand))
                {
                    string sBlockName = m_DicLocalFBNameS[sCommand];
                    if (sBlockName.StartsWith("SFB") || sBlockName.StartsWith("SFC"))
                        return true;
                    else
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return false;
        }

        private List<string> GetUsedAddress(string sAddress)
        {
            List<string> lstUsedAddress = null;

            try
            {
                lstUsedAddress = new List<string>();

                if (sAddress.Contains(","))
                {
                    int effictive = 0;
                    int iCount = sAddress.Length;
                    int iLastCommaPos = -1;

                    for (int i = 0; i < iCount; i++)
                    {
                        if (sAddress[i] == '[')
                            effictive = effictive + 1;
                        else if (sAddress[i] == ']')
                            effictive = effictive - 1;
                        else if (sAddress[i] == ',')
                        {
                            if (effictive == 0)
                            {
                                if (i > 0)
                                {
                                    string sTemp = string.Empty;

                                    if (iLastCommaPos == -1)
                                    {
                                        sTemp = sAddress.Remove(i);
                                        iLastCommaPos = i;
                                    }
                                    else
                                    {
                                        sTemp = sAddress.Substring(iLastCommaPos + 1, i - iLastCommaPos - 1);
                                        iLastCommaPos = i;
                                    }

                                    lstUsedAddress.Add(sTemp);
                                }
                                else
                                {
                                    string sTemp = string.Empty;
                                    lstUsedAddress.Add(sTemp);
                                    iLastCommaPos = 0;
                                }

                            }
                        }
                    }

                    if (iLastCommaPos < sAddress.Length - 1)
                    {
                        string sTemp = sAddress.Substring(iLastCommaPos + 1);
                        lstUsedAddress.Add(sTemp);
                    }
                    else
                    {
                        string sTemp = string.Empty;
                        lstUsedAddress.Add(sTemp);
                    }
                }
                else
                    lstUsedAddress.Add(sAddress);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstUsedAddress;
        }

        private List<string> GetUsedFBAddress(string sSymbolUnit)
        {
            List<string> lstUsedFBAddress = null;

            try
            {
                string sUsedAddress = sSymbolUnit.Split('(')[1].Replace(")", string.Empty);
                lstUsedFBAddress = GetUsedAddress(sUsedAddress);

                if (lstUsedFBAddress.Count == 1 & lstUsedFBAddress[0] == string.Empty)
                {
                    lstUsedFBAddress.RemoveAt(0);
                    return lstUsedFBAddress;
                }

                if (m_emPLCMaker == EMPLCMaker.LS)
                {
                    lstUsedFBAddress.RemoveAt(0);
                    lstUsedFBAddress.RemoveAt(0);

                    if (lstUsedFBAddress.Contains("LINEIN") || lstUsedFBAddress.Contains("LINEOUT"))
                    {
                        List<string> lstTemp = new List<string>();

                        foreach (string sAddress in lstUsedFBAddress)
                        {
                            if (sAddress.Equals("LINEIN") || sAddress.Equals("LINEOUT"))
                                lstTemp.Add(string.Empty);
                            else
                                lstTemp.Add(sAddress);
                        }

                        lstUsedFBAddress = lstTemp;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstUsedFBAddress;
        }

        private void CreateContactSymbol(string sCommand, string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bIsInitial)
        {
            try
            {
                bool bCheckDoubleWord = CheckDoubleWordCommandHeader(sCommand);

                if (m_iPrevLogicIsCoil == 1 && m_iLogicLevel == 0)
                    bIsInitial = true;

                CContact cContact = GetContact(sSymbolUnit, PreCont, PreCoil, bIsInitial, bCheckDoubleWord, m_cStepCur.Key);
                m_cStepCur.ContactS.Add(cContact);

                if (m_bSetFB)
                    m_cFBInfoCur.ContactS.Add(cContact);

                CreateNextRelation(PreCont, PreCoil, false, cContact.StepIndex);

                PreCont.Clear();
                PreCoil.Clear();

                m_iLastNextContactIndex = cContact.StepIndex;
                PreCont.Add(cContact.StepIndex);

                m_iPrevLogicIsCoil = 0;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateCoilSymbol(string sCommand, string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bIsInitial)
        {
            try
            {
                bool bCheckDoubleWord = CheckDoubleWordCommandHeader(sCommand);
                bool bCheck4SizeCommand = Check4SizeWordCommand(sCommand);

                CCoil cCoil = GetCoil(sSymbolUnit, PreCont, PreCoil, bCheckDoubleWord, bCheck4SizeCommand, m_cStepCur.Key);
                m_cStepCur.CoilS.Add(cCoil);
                CreateNextRelation(PreCont, PreCoil, true, cCoil.StepIndex);

                PreCont.Clear();
                PreCoil.Clear();

                PreCoil.Add(cCoil.StepIndex);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private bool Check4SizeWordCommand(string sCommand)
        {
            bool bOK = false;
            try
            {
                string sTemp = sCommand;

                if (sTemp.EndsWith("P"))
                    sTemp = sTemp.TrimEnd('P');

                if (m_lst4DataSizeCommandAll.Contains(sTemp))
                    bOK = true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return bOK;
        }

        private bool CheckDoubleWordCommandHeader(string sCommand)
        {
            bool bOK = false;
            try
            {
                if (sCommand.EndsWith("P"))
                    sCommand = sCommand.TrimEnd('P');

                if (m_lst4DataSizeCommandAll.Contains(sCommand))
                    return false;

                string sHeader = string.Empty;
                string sCommonCommand = string.Empty;
                int iHeaderIndex = 0;

                foreach (string sTemp in m_lstDoubleDataSizeCommandAll)
                {
                    if (sCommand.Contains(sTemp))
                    {
                        if (sTemp.Equals("TO") && sCommand.Contains("TON") || sTemp.Equals("TO") && sCommand.Contains("TOFF") || sTemp.Equals("TO") && sCommand.Contains("RTO"))
                            continue;

                        sCommonCommand = sTemp;
                        iHeaderIndex = sCommand.IndexOf(sTemp);
                        sHeader = sCommand.Substring(0, iHeaderIndex);
                    }
                }

                if (sHeader == string.Empty)
                    bOK = false;
                else if (sHeader.Equals("R") || sHeader.Equals("D") || sHeader.Equals("DB") || sHeader.Equals("E")
                    || sHeader.Equals("GD") || sHeader.Equals("UD") || sHeader.Equals("BD"))
                    bOK = true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return bOK;
        }

        private CCoil GetCoil(string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bCheckDoubleWord, bool bCheck4SizeCommand, string sStepKey)
        {
            CCoil cCoil = null;

            try
            {
                cCoil = new CCoil();
                cCoil.Command = sSymbolUnit.Split('(')[0];
                cCoil.StepIndex = m_iOperatorIndex++;
                cCoil.Instruction = GetInstruction(cCoil.Command, sSymbolUnit);
                cCoil.CoilType = GetCoilType(cCoil.Command);
                cCoil.Step = sStepKey;
                CreateRelation(cCoil.Relation, PreCont, PreCoil);

                string sUsedAddress = GetLogicUnitUsedAddress(sSymbolUnit);

                if (cCoil.Command == "SET" || cCoil.Command == "RET")
                {
                    m_iPrevLogicIsCoil = 1;
                    if (m_iLogicLevel == 0)
                        m_iIsNewStartLogic = 0;
                    else
                        m_iIsNewStartLogic = 1;
                }
                else
                {
                    m_iIsNewStartLogic = 1;
                    m_iPrevLogicIsCoil = 0;
                }

                //if (cCoil.Command.Equals("FOR"))
                //    m_lstForNextControl.Add(sUsedAddress);
                //else if (cCoil.Command.Equals("NEXT"))
                //    m_lstForNextControl.RemoveAt(m_lstForNextControl.Count - 1);

                //if (cCoil.Command.Equals("LABEL"))
                //    m_lstCallControl.Add(sUsedAddress);
                //else if (cCoil.Command.Equals("RET"))
                //    m_lstCallControl.RemoveAt(m_lstCallControl.Count - 1);

                //if (cCoil.Command.Equals("MC"))
                //    m_lstMasterControl.Add(sUsedAddress.Split(',')[0]);
                //else if (cCoil.Command.Equals("MCR"))
                //    m_lstMasterControl.RemoveAt(m_lstMasterControl.Count - 1);

                CreateCoilContent(sUsedAddress, cCoil, bCheckDoubleWord, bCheck4SizeCommand, sStepKey, true);

                CCommonImportType.SetContentParameter(cCoil.Command, m_emPLCMaker, cCoil.ContentS);

                string sTemp = cCoil.Command;

                if (cCoil.Command.EndsWith("P"))
                    sTemp = cCoil.Command.TrimEnd('P');

                if (m_lstSubDataMoveCommandAll.Contains(sTemp))
                    CreateSubDataArgumentS(sTemp, cCoil.ContentS, sStepKey, true);

                string sLogMassage = string.Format("Create Coil. Coil Address: [{0}], StepKey: [{1}], Unit Index: [{2}].", sUsedAddress, m_cStepCur.Key, cCoil.StepIndex);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cCoil;
        }

        private void CreateSubDataArgumentS(string sCommand, CContentS cContentS, string sStepKey, bool bIsCoil)
        {
            try
            {
                if (m_emPLCMaker != EMPLCMaker.Mitsubishi && m_emPLCMaker != EMPLCMaker.Mitsubishi_Developer
                    && m_emPLCMaker != EMPLCMaker.Mitsubishi_Works2 && m_emPLCMaker != EMPLCMaker.Mitsubishi_Works3
                    && m_emPLCMaker != EMPLCMaker.LS)
                    return;


                CContent cContent = null;
                bool bCheckDoubleWord = false;

                CSubDataType cSubDatatType = new CSubDataType(sCommand, cContentS, m_emPLCMaker);
                CSubData cSubData = cSubDatatType.GetSubData();

                if (cSubData == null)
                    return;

                if (cSubData.SubDataType == EMSubDataType.DWord)
                    bCheckDoubleWord = true;

                foreach (string sAddress in cSubData.SubDataList)
                {
                    cContent = GetContent(sAddress, bCheckDoubleWord, false, sStepKey, bIsCoil);

                    if (cContent != null && cContent.Tag != null)
                        cContentS.Add(cContent);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CheckStepRefTags()
        {
            try
            {
                if (m_cStepCur.ContactS.Count > 0)
                {
                    foreach (CContact tempContact in m_cStepCur.ContactS)
                    {
                        foreach (string refKey in tempContact.RefTagS.KeyList)
                        {
                            if (!m_cStepCur.RefTagS.ContainsKey(refKey))
                                m_cStepCur.RefTagS.Add(refKey, tempContact.RefTagS[refKey]);
                        }
                    }
                }

                if (m_cStepCur.CoilS.Count > 0)
                {
                    foreach (CCoil tempCoil in m_cStepCur.CoilS)
                    {
                        foreach (string refKey in tempCoil.RefTagS.KeyList)
                        {
                            if (!m_cStepCur.RefTagS.ContainsKey(refKey))
                                m_cStepCur.RefTagS.Add(refKey, tempCoil.RefTagS[refKey]);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private bool CheckIsSystemFunction(string sCommand)
        {
            bool isSFCB = false;

            if (sCommand.StartsWith("SFC") || sCommand.StartsWith("SFB"))
                isSFCB = true;

            return isSFCB;
        }

        private bool CheckisUSERDefiFunction(string sCommand)
        {
            bool isFCB = false;

            if (sCommand.StartsWith("FB") || sCommand.StartsWith("FC") || sCommand.StartsWith("OB"))
                isFCB = true;

            return isFCB;
        }

        private bool CheckIsInternalFunction(string sCommand)
        {

            bool isSFCB = false;

            if (sCommand.StartsWith("#"))
                isSFCB = true;

            return isSFCB;
        }

        private List<string> CutContentAddress(string sUsedAddress)
        {
            List<string> lstAddress = new List<string>();

            try
            {
                int efftive = 0;

                int iCount = sUsedAddress.Length;
                int LastCommaPos = 0;

                for (int i = 0; i < iCount; i++)
                {
                    if (sUsedAddress[i] == '[')
                    {
                        efftive = efftive + 1;
                    }
                    else if (sUsedAddress[i] == ']')
                    {
                        efftive = efftive - 1;
                    }
                    else if (sUsedAddress[i] == ',')
                    {
                        if (efftive == 0)
                        {
                            string stemp = sUsedAddress.Remove(i);

                            if (LastCommaPos > 0)
                                stemp = stemp.Substring(LastCommaPos + 1);

                            if (stemp.Length > 1)
                                if (stemp[0] == ',')
                                    stemp = stemp.Substring(1);

                            LastCommaPos = i;
                            lstAddress.Add(stemp);
                        }
                    }
                }

                if (LastCommaPos == 0)
                    lstAddress.Add(sUsedAddress);
                else
                    lstAddress.Add(sUsedAddress.Substring(LastCommaPos + 1));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstAddress;
        }

        private void CreateCoilContent(string sUsedAddress, CCoil cCoil, bool bCheckDoubleWord, bool bCheck4SizeCommand, string sStepKey, bool bIsCoil)
        {
            try
            {
                if (sUsedAddress == string.Empty)
                    return;

                List<string> lstUsedAddress = GetUsedAddress(sUsedAddress);
                CContent cContent = null;

                foreach (string sAddress in lstUsedAddress)
                {
                    if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                    {
                        if (sAddress.Contains("LINEIN") || sAddress.Contains("LINEOUT") || sAddress.Contains("EMPTY"))
                            continue;
                    }

                    if (sAddress.Contains("SubLogic"))
                    {
                        List<int> TempPreCont = new List<int>();
                        List<int> TempPreCoil = new List<int>();

                        CreateSubLogicSymbol(sAddress, TempPreCont, TempPreCoil);

                        cCoil.Relation.PrevContactS.AddRange(TempPreCont);

                        TempPreCont.Clear();
                        TempPreCoil.Clear();
                    }
                    else
                    {
                        cContent = GetContent(sAddress, bCheckDoubleWord, bCheck4SizeCommand, sStepKey, true);

                        if (cContent != null)
                        {
                            cCoil.ContentS.Add(cContent);

                            string refkey = CheckRefTagKey(cContent);

                            if (refkey != string.Empty)
                                cCoil.RefTagS.Add(refkey, cContent.Tag);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private EMCoilType GetCoilType(string sCommand)
        {
            EMCoilType emCoilType = EMCoilType.None;

            try
            {
                if (IsTimerCommand(sCommand))
                    emCoilType = EMCoilType.Timer;
                else if (IsCounterCommand(sCommand))
                    emCoilType = EMCoilType.Counter;
                else if (IsComputCommand(sCommand))
                    emCoilType = EMCoilType.Math;
                else if (IsMoveCommand(sCommand))
                    emCoilType = EMCoilType.Move;
                else if (IsShiftCommand(sCommand))
                    emCoilType = EMCoilType.Shift;
                else if (IsProgramControlCommand(sCommand))
                    emCoilType = EMCoilType.ProgramControl;
                else if (IsCommunicationCommand(sCommand))
                    emCoilType = EMCoilType.Communication;
                else if (IsSpecialCommand(sCommand))
                    emCoilType = EMCoilType.Special;
                else
                    emCoilType = EMCoilType.Bit;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return emCoilType;
        }

        private void CreateNextRelation(List<int> PreCont, List<int> PreCoil, bool IsCoil, int StepIndex)
        {
            try
            {
                if (PreCont.Count != 0)
                {
                    foreach (int iPreCon in PreCont)
                    {
                        int iContactCount = m_cStepCur.ContactS.Count;

                        for (int i = 0; i < iContactCount; i++)
                        {
                            if (m_cStepCur.ContactS[i].StepIndex == iPreCon)
                            {
                                if (IsCoil)
                                {
                                    if (!m_cStepCur.ContactS[i].Relation.NextCoilS.Contains(StepIndex))
                                        m_cStepCur.ContactS[i].Relation.NextCoilS.Add(StepIndex);
                                }
                                else
                                {
                                    if (!m_cStepCur.ContactS[i].Relation.NextContactS.Contains(StepIndex))
                                        m_cStepCur.ContactS[i].Relation.NextContactS.Add(StepIndex);
                                }
                            }
                        }
                    }
                }

                if (PreCoil.Count != 0)
                {
                    foreach (int iPreCoil in PreCoil)
                    {
                        int iCoilCount = m_cStepCur.CoilS.Count;

                        for (int i = 0; i < iCoilCount; i++)
                        {
                            if (m_cStepCur.CoilS[i].StepIndex == iPreCoil)
                            {
                                if (IsCoil)
                                {
                                    if (!m_cStepCur.CoilS[i].Relation.NextCoilS.Contains(StepIndex))
                                        m_cStepCur.CoilS[i].Relation.NextCoilS.Add(StepIndex);
                                }
                                else
                                {
                                    if (!m_cStepCur.CoilS[i].Relation.NextContactS.Contains(StepIndex))
                                        m_cStepCur.CoilS[i].Relation.NextContactS.Add(StepIndex);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetSymbolUnit(string sLogic)
        {
            string sSymbolUnit = string.Empty;

            try
            {
                //int iPos = sLogic.IndexOf(')');

                //if (iPos <= sLogic.Length - 1)
                //    sUsedAddress = sLogic.Substring(0, iPos + 1);
                int iLevel = 0;

                if (sLogic.StartsWith("XIC(B183[(N187_20"))
                {

                }

                for (int i = 0; i < sLogic.Length; i++)
                {
                    if (sLogic[i] == '(')
                    {
                        iLevel = iLevel + 1;
                        sSymbolUnit = sSymbolUnit + sLogic[i];

                    }
                    else if (sLogic[i] == ')')
                    {
                        iLevel = iLevel - 1;
                        sSymbolUnit = sSymbolUnit + sLogic[i];

                        if (iLevel == 0)
                        {
                            break;
                        }
                    }
                    else
                        sSymbolUnit = sSymbolUnit + sLogic[i];
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sSymbolUnit;
        }

        private string GetOptionLogicUnit(string sLogic)
        {
            string sOptionLogicUnit = string.Empty;

            try
            {
                int iOptionLogicEndPos = 0;
                int iMemoryBlock = 1;

                for (int i = 1; i < sLogic.Length; i++)
                {
                    if (sLogic[i].Equals('['))
                        iMemoryBlock++;
                    else if (sLogic[i].Equals(']'))
                        iMemoryBlock--;

                    if (iMemoryBlock == 0)
                    {
                        iOptionLogicEndPos = i;
                        break;
                    }
                }

                if (iOptionLogicEndPos <= sLogic.Length - 1)
                    sOptionLogicUnit = sLogic.Substring(0, iOptionLogicEndPos + 1);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sOptionLogicUnit;
        }

        private List<string> GetOptionLogicPart(string sOptionLogicUnit)
        {
            List<string> lstOptionLogicPart = null;

            try
            {
                lstOptionLogicPart = new List<string>();
                string sOptionLogicPart = string.Empty;

                int iBracketBlock = 0;
                int iMemoryBlock = 1;
                int iLocalPartPos = 1;

                for (int i = 1; i < sOptionLogicUnit.Length; i++)
                {
                    if (sOptionLogicUnit[i].Equals('['))
                        iMemoryBlock++;
                    else if (sOptionLogicUnit[i].Equals(']'))
                    {
                        iMemoryBlock--;

                        if (iBracketBlock == 0 && iMemoryBlock == 0)
                        {
                            sOptionLogicPart = sOptionLogicUnit.Substring(iLocalPartPos, i - iLocalPartPos);
                            lstOptionLogicPart.Add(sOptionLogicPart);
                            break;
                        }
                    }
                    else if (sOptionLogicUnit[i].Equals('('))
                        iBracketBlock++;
                    else if (sOptionLogicUnit[i].Equals(')'))
                        iBracketBlock--;
                    else if (sOptionLogicUnit[i].Equals(','))
                    {
                        if (iBracketBlock == 0 && iMemoryBlock == 1)
                        {
                            sOptionLogicPart = sOptionLogicUnit.Substring(iLocalPartPos, i - iLocalPartPos);
                            iLocalPartPos = i + 1;

                            lstOptionLogicPart.Add(sOptionLogicPart);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstOptionLogicPart;
        }

        private void SetRelationList(List<int> lst_Value, List<int> lst_Empty)
        {
            try
            {
                if (lst_Value.Count > 0)
                {
                    foreach (int iValue in lst_Value)
                    {
                        if (!lst_Empty.Contains(iValue))
                            lst_Empty.Add(iValue);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private CContact GetContact(string sSymbolUnit, List<int> PreCont, List<int> PreCoil, bool bIsInitial, bool bCheckDoubleWord, string sStepKey)
        {
            CContact cContact = null;

            try
            {
                cContact = new CContact();
                cContact.Operator = sSymbolUnit.Split('(')[0];
                cContact.StepIndex = m_iOperatorIndex++;
                cContact.IsInitial = bIsInitial;
                cContact.Instruction = GetInstruction(cContact.Operator, sSymbolUnit);
                cContact.ContactType = GetContactType(cContact.Operator);
                cContact.Step = sStepKey;
                CreateRelation(cContact.Relation, PreCont, PreCoil);

                if (cContact.ContactType == EMContactType.Compare)
                    cContact.Instruction = GetCompareCommandInstruction(cContact.Instruction);

                string sUsedAddress = GetLogicUnitUsedAddress(sSymbolUnit);
                CreateContactContent(sUsedAddress, cContact, bCheckDoubleWord, sStepKey, false);

                CCommonImportType.SetContentParameter(cContact.Operator, m_emPLCMaker, cContact.ContentS);

                string sLogMassage = string.Format("Create contact. Contact Address: [{0}], StepKey: [{1}], Unit Index: [{2}].", sUsedAddress, m_cStepCur.Key, cContact.StepIndex);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cContact;
        }

        private void CreateContactContent(string sUsedAddress, CContact cContact, bool bCheckDoubleWord, string sStepKey, bool bIsCoil)
        {
            try
            {
                if (sUsedAddress == string.Empty)
                    return;

                List<string> lstUsedAddress = GetUsedAddress(sUsedAddress);
                CContent cContent = null;

                foreach (string sAddress in lstUsedAddress)
                {
                    if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                    {
                        if (sAddress.Contains("LINEIN") || sAddress.Contains("LINEOUT") || sAddress.Contains("EMPTY"))
                            continue;
                    }

                    cContent = GetContent(sAddress, bCheckDoubleWord, false, sStepKey, false);
                    if (cContent != null)
                    {
                        cContact.ContentS.Add(cContent);

                        string refkey = CheckRefTagKey(cContent);

                        if (refkey != string.Empty)
                            cContact.RefTagS.Add(refkey, cContent.Tag);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string CheckRefTagKey(CContent tempContent)
        {
            string refKey = string.Empty;

            try
            {
                if (tempContent.ArgumentType == EMArgumentType.Tag || tempContent.ArgumentType == EMArgumentType.MoveTag || tempContent.ArgumentType == EMArgumentType.LogicTag)
                {
                    if (tempContent.Tag != null)
                    {
                        CTag tempTag = tempContent.Tag;

                        if (tempTag.Address.Length >= 2)
                        {
                            if (m_cGlobalTagS.ContainsKey(tempTag.Key))
                                refKey = tempTag.Key;
                            else
                            {
                                if (CheckIsS7DBTagAddress(tempTag.Address))
                                    refKey = tempTag.Key;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return refKey;
        }

        private CContent GetContent(string sAddress, bool bCheckDoubleWord, bool bCheck4SizeCommand, string sStepKey, bool bIsCoil)
        {
            CContent cContent = null;

            try
            {
                if (sAddress == string.Empty || sAddress == "?")
                    return null;

                cContent = new CContent();

                if (IsConstant(sAddress))
                {
                    cContent.Argument = sAddress;
                    cContent.ArgumentType = EMArgumentType.Constant;
                }
                else
                {
                    cContent.ArgumentType = EMArgumentType.Tag;

                    CTag cTag = GetTag(sAddress, bCheckDoubleWord, bCheck4SizeCommand, sStepKey, bIsCoil);
                    if (cTag != null)
                    {
                        cContent.Tag = cTag;
                        cContent.Argument = cTag.Address;
                    }
                    else
                    {
                        cContent.ArgumentType = EMArgumentType.LogicTag;
                        cContent.Argument = sAddress;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cContent;
        }

        private CTag GetTag(string sAddress, bool bCheckDoubleWord, bool bCheck4SizeCommand, string sStepKey, bool isCoilTag)
        {
            CTag cTag = null;

            try
            {
                bool bIsLocalTag = false;
                int iTagSize = 1;

                if (bCheck4SizeCommand)
                    iTagSize = 4;

                if (sAddress.Contains("+") || sAddress.Contains("-") || sAddress.Contains("*") || sAddress.Contains("/")
                    || sAddress.Contains("<") || sAddress.Contains(">") || sAddress.Contains("<=") || sAddress.Contains(">="))
                    return cTag;

                if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                    sAddress = GetSiemensAddress(sAddress);
                else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    sAddress = GetAddressFittingFormat(sAddress);

                string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sAddress, iTagSize);
                bool bCheckTagMatched = false;

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                {
                    if (m_cAddressLocalTagS.ContainsKey(sKey))
                    {
                        bCheckTagMatched = true;
                        cTag = m_cAddressLocalTagS[sKey];
                        bIsLocalTag = true;
                    }
                    else if (m_cAddressGlobalTagS.ContainsKey(sKey))
                    {
                        bCheckTagMatched = true;
                        cTag = m_cAddressGlobalTagS[sKey];
                    }
                    else
                    {
                        if (CheckIsS7DBTagAddress(sAddress) || CheckIsSiemensDBTag(sAddress))
                        {
                            cTag = GetSiemesDBTag(sAddress);

                            if (cTag != null)
                                bCheckTagMatched = true;
                        }
                    }
                }
                else
                {
                    if (m_cLocalTagS.ContainsKey(sKey))
                    {
                        bCheckTagMatched = true;
                        cTag = m_cLocalTagS[sKey];
                        bIsLocalTag = true;
                    }
                    else if (m_cGlobalTagS.ContainsKey(sKey))
                    {
                        bCheckTagMatched = true;
                        cTag = m_cGlobalTagS[sKey];
                    }
                }

                if (!bCheckTagMatched && CheckIsArrayTag(sAddress))
                {
                    cTag = CreatArrayTag(sAddress, sStepKey, isCoilTag);
                    bCheckTagMatched = true;
                }

                if (!bCheckTagMatched)
                {
                    foreach (CTag cTempTag in m_cLocalTagS.Values)
                    {
                        if (cTempTag.Address == sAddress || cTempTag.Name == sAddress)
                        {
                            cTag = cTempTag;
                            bCheckTagMatched = true;
                            break;
                        }
                    }

                    if (!bCheckTagMatched)
                    {
                        foreach (CTag cTempTag in m_cGlobalTagS.Values)
                        {
                            if (cTempTag.Address == sAddress || cTempTag.Name == sAddress)
                            {
                                cTag = cTempTag;
                                bCheckTagMatched = true;
                                break;
                            }
                        }
                    }
                }

                if (!bCheckTagMatched && !IsConstant(sAddress))
                    cTag = GetTagUsedInOnlyLogic(sAddress, iTagSize);

                if (bCheckDoubleWord)
                    cTag.DataType = EMDataType.DWord;

                if (cTag != null)
                {
                    cTag = WriteTagStepRoleType(cTag, sStepKey, isCoilTag);

                    if (!bIsLocalTag)
                        m_cUsedGlobalTagS.Add(cTag.Key, cTag);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTag;
        }

        private bool CheckIsArrayBoolTag(string sAddress)
        {
            bool bOK = false;

            try
            {
                int iPos = sAddress.LastIndexOf(".");

                if (iPos > 0 && iPos < sAddress.Length - 1)
                {
                    string sTemp = sAddress.Substring(iPos + 1);

                    if (CheckIsNumricAddress(sTemp))
                        bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return bOK;
        }

        private bool CheckIsSiemensDBTag(string sAddress)
        {
            bool bIs = false;
            try
            {
                if (sAddress.StartsWith("DB"))
                    bIs = true;
                else if (sAddress.StartsWith("DI"))
                    bIs = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return bIs;
        }

        private CTag GetSiemesDBTag(string sAddress)
        {
            CTag cTag = null;

            try
            {
                CUDLTag cTempUdlTag = null;

                if (sAddress.Contains("."))
                {
                    int iPos = sAddress.IndexOf(".");
                    string sDBName = sAddress.Remove(iPos);

                    if (m_cUDL.Blocks.ContainsKey(sDBName))
                    {
                        CUDLBlock cTempBlock = m_cUDL.Blocks[sDBName];

                        cTempUdlTag = FindDBUDLTag(cTempBlock, sAddress);
                    }
                    else
                    {
                        foreach (CUDLBlock tempBlock in m_cUDL.Blocks.Values)
                        {
                            if (tempBlock.BlockAddress == sDBName)
                            {
                                CUDLBlock cTempBlock = tempBlock;

                                cTempUdlTag = FindDBUDLTag(cTempBlock, sAddress);

                                break;
                            }
                        }
                    }
                }
                else
                {
                    string sTempAddress = string.Empty;
                    string sBlockName = string.Empty;
                    if (sAddress.StartsWith("DI"))
                    {
                        string sTemp = "DB" + sAddress.Substring(2);

                        sBlockName = m_sOpenedDIName;
                        sTempAddress = m_sOpenedDIName + "." + sTemp;
                    }
                    else
                    {
                        sBlockName = m_sOpenedDBName;
                        sTempAddress = m_sOpenedDBName + "." + sAddress;
                    }


                    if (m_cUDL.Blocks.ContainsKey(sBlockName))
                    {
                        CUDLBlock cTempBlock = m_cUDL.Blocks[sBlockName];

                        cTempUdlTag = FindDBUDLTag(cTempBlock, sAddress);
                    }
                    else
                    {
                        foreach (CUDLBlock tempBlock in m_cUDL.Blocks.Values)
                        {
                            if (tempBlock.BlockAddress == sBlockName)
                            {
                                CUDLBlock cTempBlock = tempBlock;

                                cTempUdlTag = FindDBUDLTag(cTempBlock, sAddress);

                                break;
                            }
                        }
                    }
                }

                if (cTempUdlTag != null)
                {
                    cTag = new CTag();

                    cTag.Address = GetSiemensAddress(cTempUdlTag.Address);
                    cTag.DataType = cTempUdlTag.Datatype;
                    cTag.Name = cTempUdlTag.Name;
                    cTag.Size = 1;

                    if (cTempUdlTag.Description != string.Empty)
                        cTag.Description = cTempUdlTag.Description;
                    else
                        cTag.Description = cTempUdlTag.Name;

                    if (cTempUdlTag.Datatype == EMDataType.UserDefDataType)
                        cTag.UDTType = cTempUdlTag.UDTType;

                    cTag.PLCMaker = cTempUdlTag.PLCMaker;
                    cTag.Channel = m_sChannel;
                    cTag.UseOnlyInLogic = false;

                    if (cTempUdlTag.Address != string.Empty)
                        cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                    else
                        cTag.Key = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);

                    m_cGlobalTagS.Add(cTag.Key, cTag);

                    if (m_emPLCMaker == EMPLCMaker.Siemens)
                    {
                        string sTempAddressKey = string.Empty;

                        if (cTempUdlTag.Address != string.Empty)
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);
                        else
                            sTempAddressKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);

                        m_cAddressGlobalTagS.Add(sTempAddressKey, cTag);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTag;
        }

        private CUDLTag FindDBUDLTag(CUDLBlock cTempUDLBlock, string sAddress)
        {
            CUDLTag cUdlTag = null;

            try
            {
                bool bIsfind = false;

                foreach (CUDLTag tempTag in cTempUDLBlock.InputTags)
                {
                    if (tempTag.Address == sAddress)
                    {
                        cUdlTag = tempTag;
                        bIsfind = true;
                        break;
                    }
                }

                if (!bIsfind)
                {
                    foreach (CUDLTag tempTag in cTempUDLBlock.OutputTags)
                    {
                        if (tempTag.Address == sAddress)
                        {
                            cUdlTag = tempTag;
                            bIsfind = true;
                            break;
                        }
                    }
                }

                if (!bIsfind)
                {
                    foreach (CUDLTag tempTag in cTempUDLBlock.InOutTags)
                    {
                        if (tempTag.Address == sAddress)
                        {
                            cUdlTag = tempTag;
                            bIsfind = true;
                            break;
                        }
                    }
                }

                if (!bIsfind)
                {
                    foreach (CUDLTag tempTag in cTempUDLBlock.STATTags)
                    {
                        if (tempTag.Address == sAddress)
                        {
                            cUdlTag = tempTag;
                            bIsfind = true;
                            break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cUdlTag;
        }

        private CTag CreatArrayTag(string sAddress, string sStepKey, bool bIsCoil)
        {
            CTag cTempTag = new CTag();

            try
            {
                int iTagSize = 1;
                bool bIsFind = false;

                if (sAddress.Contains("]."))
                {
                    int iPos = sAddress.IndexOf("].");
                    string sTemp = sAddress.Remove(iPos + 1);
                    string sTempKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sTemp, iTagSize);

                    if (m_cGlobalTagS.ContainsKey(sTempKey))
                    {
                        bIsFind = true;

                        CTag cArrayTag = m_cGlobalTagS[sTempKey];
                        cTempTag.DataType = cArrayTag.DataType;
                        cTempTag.Description = cArrayTag.Description;
                        cTempTag.PLCMaker = cArrayTag.PLCMaker;
                    }
                }

                if (!bIsFind)
                {
                    int iPos = sAddress.IndexOf("[");
                    string sTemp = sAddress.Remove(iPos);

                    string sArrayName = FindArrayName(sTemp);

                    if (sArrayName != string.Empty)
                    {
                        CTag cArrayTag = m_cGlobalTagS[sArrayName];
                        cTempTag.DataType = cArrayTag.DataType;
                        cTempTag.Description = cArrayTag.Description;
                        cTempTag.PLCMaker = cArrayTag.PLCMaker;
                    }
                }

                cTempTag.Name = sAddress;
                cTempTag.Address = sAddress;
                cTempTag.Channel = m_sChannel;
                cTempTag.Size = 1;

                if (CheckIsArrayBoolTag(sAddress))
                    cTempTag.DataType = EMDataType.Bool;

                if (sAddress.Contains(".EN") || sAddress.Contains(".DN"))
                    cTempTag.DataType = EMDataType.Bool;

                string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sAddress, iTagSize);
                cTempTag.Key = sKey;

                m_cGlobalTagS.Add(sKey, cTempTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTempTag;
        }

        private string FindArrayName(string sAddress)
        {
            string sTemp = string.Empty;

            try
            {
                string sPrevKey = "[" + m_sChannel + "]" + sAddress;


                foreach (string sArrayName in m_cGlobalTagS.Keys)
                {
                    if (sArrayName.StartsWith(sPrevKey))
                    {
                        int iPos = sPrevKey.Length;

                        if (sArrayName[iPos] == '[')
                        {
                            sTemp = sArrayName;
                            break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sTemp;
        }

        private bool CheckIsArrayTag(string sAddress)
        {
            bool bIsArrayTag = false;

            try
            {
                if (sAddress.Contains("["))
                    bIsArrayTag = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return bIsArrayTag;
        }

        private CTag WriteTagStepRoleType(CTag cTag, string sStepKey, bool isCoil)
        {
            try
            {
                bool bIsFindStepKey = false;

                foreach (CTagStepRole tempStepRole in cTag.StepRoleS)
                {
                    if (tempStepRole.StepKey == sStepKey)
                    {
                        if (isCoil)
                        {
                            if (tempStepRole.RoleType == EMStepRoleType.Contact)
                            {
                                tempStepRole.RoleType = EMStepRoleType.Both;
                            }
                            else if (tempStepRole.RoleType == EMStepRoleType.Both)
                            {

                            }
                            else
                            {
                                tempStepRole.RoleType = EMStepRoleType.Coil;
                            }
                        }
                        else
                        {
                            if (tempStepRole.RoleType == EMStepRoleType.Coil)
                            {
                                tempStepRole.RoleType = EMStepRoleType.Both;
                            }
                            else if (tempStepRole.RoleType == EMStepRoleType.Both)
                            {

                            }
                            else
                            {
                                tempStepRole.RoleType = EMStepRoleType.Contact;
                            }
                        }

                        bIsFindStepKey = true;
                        break;
                    }
                }

                if (!bIsFindStepKey)
                {
                    CTagStepRole tempStepRole = new CTagStepRole();
                    tempStepRole.StepKey = sStepKey;
                    if (isCoil)
                    {
                        tempStepRole.RoleType = EMStepRoleType.Coil;
                    }
                    else
                    {
                        tempStepRole.RoleType = EMStepRoleType.Contact;
                    }
                    cTag.StepRoleS.Add(tempStepRole);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTag;
        }

        private CTag GetTagUsedInOnlyLogic(string sAddress, int iTagSize)
        {
            CTag cTag = null;

            try
            {
                if (m_emPLCMaker.ToString().Contains("Mitsubishi")) //Comment 추출 시 추출 안되는 Tag들 존재(Developer)
                    cTag = GetMelsecTag(sAddress, iTagSize);
                else if (m_emPLCMaker == EMPLCMaker.LS)
                    cTag = GetLSTag(sAddress, iTagSize);
                else if (m_emPLCMaker == EMPLCMaker.Siemens)
                    cTag = GetSiemensTag(sAddress);
                else if (m_emPLCMaker == EMPLCMaker.Rockwell)
                    cTag = GetABTag(sAddress, iTagSize);

                if (cTag != null)
                {
                    cTag.Channel = m_sChannel;
                    cTag.UseOnlyInLogic = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTag;
        }

        private CTag GetABTag(string sAddress, int iTagSize)
        {
            CTag cTag = null;

            try
            {
                cTag = new CTag();
                if (sAddress.Contains(".DN") || sAddress.Contains(".EN"))
                {
                    int iPos = sAddress.LastIndexOf(".");
                    string sTemp = sAddress.Remove(iPos);

                    sTemp = string.Format("[{0}]{1}[{2}]", m_sChannel, sTemp, iTagSize);

                    if (m_cGlobalTagS.ContainsKey(sTemp))
                    {
                        CTag tempTag = m_cGlobalTagS[sTemp];

                        cTag.Name = sAddress;
                        cTag.Address = sAddress;
                        cTag.DataType = EMDataType.Bool;
                        cTag.Size = iTagSize;
                        cTag.PLCMaker = EMPLCMaker.Rockwell;
                        cTag.Channel = m_sChannel;
                        cTag.Description = tempTag.Description;
                    }
                    else
                    {
                        cTag.Name = sAddress;
                        cTag.Address = sAddress;
                        cTag.Size = iTagSize;
                        cTag.PLCMaker = EMPLCMaker.Rockwell;
                        cTag.Channel = m_sChannel;
                        if (sAddress.StartsWith("T") || sAddress.StartsWith("t"))
                            cTag.DataType = EMDataType.Bool;
                        else if (sAddress.StartsWith("C") || sAddress.StartsWith("c"))
                            cTag.DataType = EMDataType.Bool;
                        else
                            cTag.DataType = EMDataType.Bool;
                    }
                }
                else
                {
                    cTag.Name = sAddress;
                    cTag.Address = sAddress;
                    cTag.DataType = CheckABTagDataType(sAddress);
                    cTag.Size = iTagSize;
                    cTag.PLCMaker = EMPLCMaker.Rockwell;
                    cTag.Channel = m_sChannel;
                }

                string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sAddress, iTagSize);

                cTag.Key = sKey;

                m_cGlobalTagS.Add(cTag.Key, cTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTag;
        }

        private EMDataType CheckABTagDataType(string sAddress)
        {
            EMDataType tempDatatype = EMDataType.Bool;
            try
            {
                bool bIsFind = false;

                if (sAddress.Contains("]."))
                {
                    int iPos = sAddress.LastIndexOf("].");
                    string sTemp = sAddress.Substring(iPos + 2);
                    bool bIsNum = true;

                    for (int i = 0; i < sTemp.Length; i++)
                    {
                        if (!Char.IsDigit(sTemp[i]))
                        {
                            bIsNum = false;
                            break;
                        }
                    }

                    if (bIsNum)
                    {
                        tempDatatype = EMDataType.Bool;
                        bIsFind = true;
                    }
                }

                if (!bIsFind && sAddress.Contains(":"))
                {
                    if (sAddress.EndsWith("]"))
                    {
                        tempDatatype = EMDataType.DInt;
                        bIsFind = true;
                    }

                    if (!bIsFind)
                    {
                        int iPos = sAddress.LastIndexOf(":");
                        string sTemp = sAddress.Substring(iPos + 1);

                        if (sTemp == "I" || sTemp == "O")
                        {
                            tempDatatype = EMDataType.DInt;
                            bIsFind = true;
                        }
                    }

                    if (!bIsFind && sAddress.Contains("."))
                    {
                        int iPos = sAddress.LastIndexOf(".");
                        string sTemp = sAddress.Substring(iPos + 1);

                        if (sTemp == "RUN")
                        {
                            tempDatatype = EMDataType.Bool;
                            bIsFind = true;
                        }
                    }
                }

                if (sAddress.Contains("[") && !bIsFind)
                {
                    int iPos = sAddress.IndexOf("[");
                    string sAliasName = sAddress.Remove(iPos);

                    foreach (CUDLTag tempudlTag in m_cUDL.Tags)
                    {
                        if (tempudlTag.Name.Contains(sAliasName))
                        {
                            int iLenght = sAliasName.Length;
                            if (tempudlTag.Name[iLenght] == '[')
                            {
                                tempDatatype = tempudlTag.Datatype;
                                bIsFind = true;
                                break;
                            }
                        }
                    }
                }

                if (!bIsFind)
                {
                    foreach (CUDLTag tempudlTag in m_cUDL.Tags)
                    {
                        if (tempudlTag.Name == sAddress)
                        {
                            tempDatatype = tempudlTag.Datatype;
                            bIsFind = true;
                            break;
                        }
                    }
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return tempDatatype;
        }

        private CTag GetMelsecTag(string sAddress, int iTagSize)
        {
            CTag cTag = null;

            try
            {
                if (sAddress.Equals("Z"))
                    sAddress = "Z0";
                else if (sAddress.Equals("V"))
                    sAddress = "V0";


                if (CMelsecPlc.IsMelsecAddress(sAddress))
                {
                    cTag = new CTag();
                    cTag.Address = GetAddressFittingFormat(sAddress);
                    cTag.Program = m_sBlockName;
                    cTag.Channel = m_sChannel;

                    if (CMelsecPlc.IsMelsecHexa(sAddress))
                        cTag.AddressType = EMAddressType.Hexa;
                    else
                        cTag.AddressType = EMAddressType.Decimal;

                    if (CMelsecPlc.CheckAddressDesignatedDigit(sAddress))//수정
                    {
                        int iDigitSize = Int32.Parse(sAddress.Substring(0, 2).Replace("K", string.Empty));

                        if (iDigitSize > 4)
                            cTag.DataType = EMDataType.DWord;
                        else
                            cTag.DataType = EMDataType.Word;
                    }
                    else if (CMelsecPlc.CheckAddressDesignatedIndirect(sAddress))
                        cTag.DataType = EMDataType.DWord;
                    else if (CMelsecPlc.IsMelsecBit(sAddress))
                        cTag.DataType = EMDataType.Bool;
                    else if (CMelsecPlc.IsMelsecWord(sAddress))
                        cTag.DataType = EMDataType.Word;
                    else
                        cTag.DataType = EMDataType.None;

                    string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel, cTag.Address, iTagSize);

                    cTag.Key = sKey;

                    m_cGlobalTagS.Add(cTag.Key, cTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTag;
        }

        private string GetAddressFittingFormat(string sAddress)
        {
            string sNewAddress = string.Empty;
            string sAddressHeader = string.Empty;
            string sAddressIndex = string.Empty;
            string sTemp = string.Empty;

            if (sAddress.Length < 2)
                return sAddress;


            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sAddressHeader = sAddress.Substring(0, 1);
                sAddressIndex = sAddress.Remove(0, 1);
            }
            else if (CMelsecPlc.IsMelsecHeadTwo(sAddressIndex))
            {
                sAddressHeader = sAddress.Substring(0, 2);
                sAddressIndex = sAddress.Remove(0, 2);
            }
            else
                return sAddress;


            if (sAddressIndex.Contains("."))
                sTemp = sAddressIndex.Split('.')[0];
            else
                sTemp = sAddressIndex;

            if (sTemp.Length < 4)
            {
                int iCount = sTemp.Length;

                for (int i = 0; i < 4 - iCount; i++)
                    sTemp = sTemp.Insert(0, "0");
            }

            if (sAddressIndex.Contains("."))
                sNewAddress = string.Format("{0}{1}.{2}", sAddressHeader, sTemp, sAddressIndex.Split('.')[1]);
            else
                sNewAddress = string.Format("{0}{1}", sAddressHeader, sTemp);

            return sNewAddress;
        }

        private CTag GetSiemensTag(string sAddress)
        {
            CTag cTag = null;

            try
            {
                cTag = new CTag();
                cTag.Address = GetSiemensAddress(sAddress);
                cTag.Program = m_sBlockName;
                cTag.DataType = CheckS7TagDatatype(sAddress);
                cTag.PLCMaker = EMPLCMaker.Siemens;

                string sKey = string.Format("[{0}]{1}[1]", m_sChannel, sAddress);

                cTag.Key = sKey;

                if (CheckIsS7GlobalTagAddress(sAddress))
                {
                    m_cGlobalTagS.Add(cTag.Key, cTag);
                    m_cAddressGlobalTagS.Add(cTag.Key, cTag);
                }
                else if (CheckIsS7FullDBAddress(sAddress))
                {
                    m_cGlobalTagS.Add(cTag.Key, cTag);
                    m_cAddressGlobalTagS.Add(cTag.Key, cTag);
                }
                else
                {
                    m_cLocalTagS.Add(cTag.Key, cTag);
                    m_cAddressLocalTagS.Add(cTag.Key, cTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTag;
        }

        private CTag GetLSTag(string sAddress, int iTagSize)
        {
            CTag cTag = null;

            try
            {
                string sNewAddress = string.Empty;
                string sNewKey = string.Empty;
                EMDataType emDataType = EMDataType.None;

                if (sAddress.StartsWith("%"))
                {
                    emDataType = GetLSXGIDataType(sAddress);
                    sNewAddress = sAddress;
                    sNewKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sNewAddress, 1);

                    cTag = new CTag();
                    cTag.Program = m_sBlockName;
                    cTag.Channel = m_sChannel;
                    cTag.DataType = emDataType;
                    cTag.Address = sNewAddress;
                    cTag.Key = sNewKey;
                }
                else if (CLSPlc.IsLSAddress(sAddress))
                {
                    if (CLSPlc.IsLSBit(sAddress))
                        emDataType = EMDataType.Bool;
                    else if (CLSPlc.IsLSWord(sAddress))
                        emDataType = EMDataType.Word;
                    else
                        emDataType = EMDataType.None;

                    sNewAddress = GetLSDDEAAddress(sAddress, emDataType);
                    sNewKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sNewAddress, 1);

                    if (m_cGlobalTagS.ContainsKey(sNewKey))
                        return m_cGlobalTagS[sNewKey];

                    cTag = new CTag();
                    cTag.Program = m_sBlockName;
                    cTag.Channel = m_sChannel;

                    if (CLSPlc.IsLSHexa(sAddress))
                        cTag.AddressType = EMAddressType.Hexa;
                    else
                        cTag.AddressType = EMAddressType.Decimal;

                    cTag.DataType = emDataType;
                    cTag.Address = sNewAddress;
                    cTag.Key = sNewKey;
                }

                if (cTag != null)
                    m_cGlobalTagS.Add(cTag.Key, cTag);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTag;
        }

        private EMDataType GetLSXGIDataType(string sAddress)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                sAddress = sAddress.Replace("%", string.Empty);

                if (sAddress.StartsWith("M"))
                {
                    if (sAddress.Contains("."))
                        emDataType = EMDataType.Bool;
                    else
                        emDataType = EMDataType.Word;
                }
                else
                    emDataType = EMDataType.Bool;

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }

            return emDataType;
        }

        private EMContactType GetContactType(string sCommand)
        {
            EMContactType emContactType = EMContactType.None;

            if (m_emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (sCommand.Contains(".") || sCommand.Contains("_"))
                    return EMContactType.SystemFunction;//EMContactType.Function;
            }

            if (IsCompareCommand(sCommand))
                emContactType = EMContactType.Compare;
            else if (IsLogicalCommand(sCommand))
                emContactType = EMContactType.Logical;
            else if (sCommand == "AFI")
                emContactType = EMContactType.None;
            else
                emContactType = EMContactType.Bit;

            return emContactType;
        }

        private void CreateRelation(CRelation cRelation, List<int> PreCont, List<int> PreCoil)
        {
            try
            {
                foreach (int iPreCont in PreCont)
                {
                    if (!cRelation.PrevContactS.Contains(iPreCont))
                        cRelation.PrevContactS.Add(iPreCont);
                }

                foreach (int iPreCoil in PreCoil)
                {
                    if (!cRelation.PrevCoilS.Contains(iPreCoil))
                        cRelation.PrevCoilS.Add(iPreCoil);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void MappingFBParameter(List<int> lstContact, List<int> lstCoil)
        {
            try
            {
                foreach (int iContact in lstContact)
                {
                    foreach (CContact tempContact in m_cStepCur.ContactS)
                    {
                        if (tempContact.StepIndex == iContact)
                        {
                            foreach (int iCoil in lstCoil)
                            {
                                if (!tempContact.Relation.NextCoilS.Contains(iCoil))
                                    tempContact.Relation.NextCoilS.Add(iCoil);
                            }
                        }
                    }
                }

                foreach (int iCoil in lstCoil)
                {
                    foreach (CCoil tempCoil in m_cStepCur.CoilS)
                    {
                        if (tempCoil.StepIndex == iCoil)
                        {
                            foreach (int iContact in lstContact)
                            {
                                if (!tempCoil.Relation.PrevContactS.Contains(iContact))
                                    tempCoil.Relation.PrevContactS.Add(iContact);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private bool CheckIsAfterOptRelation(List<int> lstPreContact)
        {
            int iCount = lstPreContact.Count;

            int iTemp = 0;

            foreach (int iPreContact in lstPreContact)
            {
                if (m_lstComSubLogicLastNextContact.Contains(iPreContact))
                {
                    iTemp++;
                }
            }

            if (iTemp == iCount && iCount != 0)
                return true;
            else
                return false;
        }

        #endregion

        #region Is Functions

        private bool IsContactCommand(string sCommand, string sSymbolUnit)
        {
            bool bOK = false;

            if (m_emPLCMaker.Equals(EMPLCMaker.LS) && (sCommand.Contains(".") || sCommand.Contains("_")))
            {
                if (sSymbolUnit.Contains("LINEOUT"))
                    bOK = true;
            }

            if (!bOK)
            {
                foreach (string sTemp in m_lstContactCommand) //Contact Check
                {
                    if (sCommand.Contains(sTemp))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            if (!bOK)
            {
                foreach (string sTemp in m_lstCompareCommand) //Compare Check
                {
                    if (sCommand.Contains(sTemp))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            if (!bOK)
            {
                foreach (string sTemp in m_lstLogicalCommand) //Connection Operation Check
                {
                    if (sCommand.Contains(sTemp))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private bool IsCompareCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstCompareCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsLogicalCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstLogicalCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsComputCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstComputCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsTimerCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstTimerCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsCounterCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstCountCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsMoveCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstMoveCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsProgramControlCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstProgramControlCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsCommunicationCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstCommunicationCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsSpecialCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstSpecialCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsShiftCommand(string sCommand)
        {
            bool bOK = false;

            foreach (string sTemp in m_lstShiftCommand)
            {
                if (sCommand.Contains(sTemp))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool IsConstant(string sAddress)
        {
            bool bOK = false;

            sAddress = sAddress.ToUpper();

            if (m_emPLCMaker == EMPLCMaker.Siemens && m_lstS7FixedAddress.Contains(sAddress))
                return true;
            else if (m_emPLCMaker == EMPLCMaker.Rockwell)
            {
                if (CheckIsNumricAddress(sAddress))
                    bOK = true;
                else if (sAddress.StartsWith("2#") || sAddress.StartsWith("8#") || sAddress.StartsWith("16#"))
                    bOK = true;
            }
            else
            {
                foreach (string sTemp in m_lstConstantHead)
                {
                    if (sAddress.StartsWith(sTemp))
                    {
                        if (sAddress.StartsWith("K"))
                        {
                            if (m_emPLCMaker == EMPLCMaker.LS)
                            {
                                bOK = false;
                                break;
                            }

                            bOK = true;
                        }
                        else if (sTemp.Equals("N") || sTemp.Equals("A") || sTemp.Equals("H"))
                        {
                            string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel, sAddress, 1);

                            if (m_cLocalTagS.ContainsKey(sKey))
                                bOK = false;
                            else
                                bOK = true;
                        }
                        else
                            bOK = true;

                        if (bOK)
                            break;
                    }
                }

                //if (!bOK)
                //{
                //    if (!Regex.IsMatch(sAddress, @"[a-zA-Z]") && Regex.IsMatch(sAddress, @"[0-9]"))
                //        bOK = true;
                //}

                if (!bOK)
                {
                    foreach (string sTemp in m_lstSpecialTags)
                    {
                        if (sAddress.Contains(sTemp))
                        {
                            bOK = true;
                            break;
                        }
                    }
                }
            }

            if (!bOK && (m_emPLCMaker == EMPLCMaker.Mitsubishi || m_emPLCMaker == EMPLCMaker.Mitsubishi_Developer
                || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works2 || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works3) && (sAddress.StartsWith("U") || sAddress.StartsWith("P")))
                bOK = true;

            if (!bOK)
            {
                if (CheckIsNumricAddress(sAddress))
                    bOK = true;
            }

            return bOK;
        }

        private EMDataType CheckS7TagDatatype(string sAddress)
        {
            EMDataType tagDT = EMDataType.Bool;

            try
            {
                if (IsS7BitTagAddress(sAddress))
                    tagDT = EMDataType.Bool;
                else if (IsS7ByteTagAddress(sAddress))
                    tagDT = EMDataType.Byte;
                else if (IsS7WordTagAddress(sAddress))
                    tagDT = EMDataType.Word;
                else if (IsS7DWordTagAddress(sAddress))
                    tagDT = EMDataType.DWord;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tagDT;
        }

        private bool IsS7BitTagAddress(string sAddress)
        {
            bool isTrue = false;
            try
            {
                if (CheckIsS7DBTagAddress(sAddress))
                {
                    int iPos = sAddress.IndexOf(".D");
                    sAddress = sAddress.Substring(iPos + 1);
                }

                if (sAddress.StartsWith("DBX"))
                    isTrue = true;
                else
                {
                    if (sAddress[0] == 'I' || sAddress[0] == 'Q' || sAddress[0] == 'M')
                    {
                        if (Char.IsDigit(sAddress[1]))
                            isTrue = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private bool IsS7ByteTagAddress(string sAddress)
        {
            bool isTrue = false;
            try
            {
                if (CheckIsS7DBTagAddress(sAddress))
                {
                    int iPos = sAddress.IndexOf(".D");
                    sAddress = sAddress.Substring(iPos + 1);
                }

                if (sAddress.StartsWith("DBB"))
                    isTrue = true;
                else
                {
                    if (sAddress[0] == 'I' || sAddress[0] == 'Q' || sAddress[0] == 'M')
                    {
                        if (sAddress[1] == 'B')
                            isTrue = true;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private bool CheckIsS7GlobalTagAddress(string sAddress)
        {
            bool isTrue = false;

            try
            {
                if (sAddress.StartsWith("IB") || sAddress.StartsWith("QB") || sAddress.StartsWith("MB"))
                    isTrue = true;
                else if (sAddress.StartsWith("ID") || sAddress.StartsWith("QD") || sAddress.StartsWith("MD"))
                    isTrue = true;
                else if (sAddress.StartsWith("IW") || sAddress.StartsWith("QW") || sAddress.StartsWith("MW"))
                    isTrue = true;
                else if (sAddress.StartsWith("I") || sAddress.StartsWith("Q") || sAddress.StartsWith("M") || sAddress.StartsWith("T") || sAddress.StartsWith("C"))
                {
                    if (sAddress.Length > 1)
                    {

                        string sTemp = sAddress.Substring(1);

                        if (CheckIsNumricAddress(sTemp))
                            isTrue = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return isTrue;
        }

        private bool CheckIsNumricAddress(string sAddress)
        {
            bool isTrue = true;

            try
            {
                int iCount = sAddress.Length;

                for (int i = 0; i < iCount; i++)
                {
                    if (!Char.IsDigit(sAddress[i]) && sAddress[i] != '.')
                    {
                        isTrue = false;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return isTrue;
        }

        private bool CheckIsS7FullDBAddress(string sAddress)
        {
            bool isTrue = false;

            try
            {
                if (sAddress.StartsWith("DB"))
                {
                    int iPos = sAddress.IndexOf(".D");

                    if (iPos > 2)
                    {
                        string stemp = sAddress.Substring(iPos + 1);
                        if (stemp.StartsWith("DB") || stemp.StartsWith("DI"))
                            isTrue = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return isTrue;
        }

        private bool IsS7WordTagAddress(string sAddress)
        {
            bool isTrue = false;
            try
            {
                if (CheckIsS7DBTagAddress(sAddress))
                {
                    int iPos = sAddress.IndexOf(".D");
                    sAddress = sAddress.Substring(iPos + 1);
                }

                if (sAddress.StartsWith("DBW"))
                    isTrue = true;
                else
                {
                    if (sAddress[0] == 'I' || sAddress[0] == 'Q' || sAddress[0] == 'M')
                    {
                        if (sAddress[1] == 'W')
                            isTrue = true;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private bool IsS7DWordTagAddress(string sAddress)
        {
            bool isTrue = false;
            try
            {
                if (CheckIsS7DBTagAddress(sAddress))
                {
                    int iPos = sAddress.IndexOf(".D");
                    sAddress = sAddress.Substring(iPos + 1);
                }

                if (sAddress.StartsWith("DBD"))
                    isTrue = true;
                else
                {
                    if (sAddress[0] == 'I' || sAddress[0] == 'Q' || sAddress[0] == 'M')
                    {
                        if (sAddress[1] == 'D')
                            isTrue = true;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        private bool CheckIsS7DBTagAddress(string sAddress)
        {
            bool isTrue = false;
            try
            {
                if (sAddress.Contains(".DB") || sAddress.Contains(".DI"))
                {
                    isTrue = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isTrue;
        }

        #endregion


        #endregion

    }
}
