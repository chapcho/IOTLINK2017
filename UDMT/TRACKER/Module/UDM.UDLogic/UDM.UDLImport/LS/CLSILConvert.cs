using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using UDM.General;
using UDM.Common;
using UDM.UDL;
using System.Data;
using System.Windows.Forms;

namespace UDM.UDLImport
{
    public class CLSILConvert
    {
        private CUDL m_cUDL = new CUDL();
        private Dictionary<string, CUDLBlock> m_dicUDLBlock = new Dictionary<string, CUDLBlock>();
        private List<string> m_lstLocalTagUseBlockName = new List<string>();
        private string m_sBlockNameCur = string.Empty;
        private List<CUDLTag> m_lstUDLTag = new List<CUDLTag>();
        private CUDLRoutine m_cUDLRoutineCur = null;
        private CLSILImport m_cLSILImport = null;
        private CLSILRung m_Rungcur = null;
        private List<CLSILPiece> m_lstILPiece = null;
        private List<CLSILPiece> m_lstMergeCoilPiece = null;
        private Dictionary<string, CInstruction> m_DicInstructionList = null;
        private Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;
        private List<string> m_lstGlobalTag = new List<string>();
        private string m_sChannel = "CH.DV";
        //Debug 용
        private List<CLSILRung> m_lstLSILRung = new List<CLSILRung>();
        private bool m_bMergeEnd = false;

        #region Initialize/Dispose

        public CLSILConvert()
        {
        }

        #endregion

        #region Properties

        public CUDL UDL
        {
            get { return m_cUDL; }
            set { m_cUDL = value; }
        }

        public List<CLSILRung> lstILRung
        {
            get { return m_lstLSILRung; }
            set { m_lstLSILRung = value; }
        }

        public Dictionary<string, CInstruction> DicInstructionList
        {
            get { return m_DicInstructionList; }
            set { m_DicInstructionList = value; }
        }

        public Dictionary<string, List<CInstruction>> DicRepeatedInstructionList
        {
            get { return m_DicRepeatedInstructionList; }
            set { m_DicRepeatedInstructionList = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        #endregion

        #region Public Methods

        public void CreateInit(DataSet dbCSV, Dictionary<string, CInstruction> DicInstructionList, Dictionary<string, List<CInstruction>> DicRepeatedInstructionList)
        {
            m_DicInstructionList = DicInstructionList;

            if (DicRepeatedInstructionList != null)
                m_DicRepeatedInstructionList = DicRepeatedInstructionList;

            CreateLSUDLTag(dbCSV);

            if (CheckLogicImport(dbCSV))
                CreateLSUDLLogic(dbCSV);
        }

        public CTagS CreateLSTagS()
        {
            CTagS cTagS = null;

            try
            {
                cTagS = new CTagS();
                CTag cTag = null;

                foreach (CUDLTag UDLTag in m_lstUDLTag)
                {
                    cTag = new CTag();
                    cTag.Channel = m_sChannel;
                    cTag.Name = UDLTag.Name;
                    cTag.Address = UDLTag.Address;
                    cTag.Description = UDLTag.Description;
                    cTag.DataType = UDLTag.Datatype;

                    if (cTag.Name != string.Empty)
                        cTag.Key = string.Format("{0}{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);
                    else
                        cTag.Key = string.Format("{0}{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);

                    if (CLSPlc.IsLSHexa(UDLTag.Address))
                        cTag.AddressType = EMAddressType.Hexa;
                    else
                        cTag.AddressType = EMAddressType.Decimal;

                    cTagS.Add(cTag.Key, cTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cTagS;
        }

        #endregion

        #region Private Methods

        private bool CheckLogicImport(DataSet dbIL)
        {
            bool bOK = false;

            try
            {
                foreach (DataTable DT in dbIL.Tables)
                {
                    if (DT.Columns.Count <= 3)
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bOK;
        }

        private void CreateLSUDLLogic(DataSet dbIL) //LS 산전 FB 분석은 무조건 Tag와 Logic을 함께 Import!
        {
            bool bFBCheck = false;

            if (m_dicUDLBlock.Count >= 1)
            {
                foreach (CUDLBlock cUDLBlock in m_dicUDLBlock.Values)
                {
                    if (cUDLBlock.BlockType.Equals(EMBlockType.FunctionBlock))
                    {
                        bFBCheck = true;
                        m_lstLocalTagUseBlockName.Add(cUDLBlock.BlockName);
                    }
                }
            }

            m_cLSILImport = new CLSILImport();
            m_cLSILImport.ImportIL(dbIL, bFBCheck, m_lstLocalTagUseBlockName);

            ConvertIL();
        }

        private void ConvertIL() //Change
        {
            string sDebugLine = string.Empty;

            try
            {
                CUDLBlock cUDLDummyBlock = null;

                if (m_dicUDLBlock.Count == 0)
                {
                    cUDLDummyBlock = new CUDLBlock();

                    cUDLDummyBlock.BlockType = EMBlockType.DummryBlock;
                    cUDLDummyBlock.BlockName = "LS Project";
                    cUDLDummyBlock.Routines.Clear();

                    m_dicUDLBlock.Add(cUDLDummyBlock.BlockName ,cUDLDummyBlock);
                }

                m_lstLSILRung.Clear();

                Dictionary<string, List<CLSILLine>> DicILLineProgram = m_cLSILImport.DicLSILLine;
                Dictionary<string, List<CLSILLine>> DicILLine = new Dictionary<string, List<CLSILLine>>();
                bool bLocalTagUseBlockCheck = false;

                foreach (var whoProgram in DicILLineProgram)
                {
                    DicILLine = GetRung(whoProgram.Value);
                    if (DicILLine == null)
                        continue;

                    m_cUDLRoutineCur = new CUDLRoutine();
                    m_cUDLRoutineCur.RoutineName = whoProgram.Key;

                    m_sBlockNameCur = m_cUDLRoutineCur.RoutineName.Split('[')[1].Replace("]", string.Empty);

                    if (m_lstLocalTagUseBlockName.Contains(m_sBlockNameCur))
                        bLocalTagUseBlockCheck = true;
                    else
                        bLocalTagUseBlockCheck = false;

                    foreach (var who in DicILLine)
                    {
                        sDebugLine = who.Key;
                        List<CLSILLine> lstILLine = who.Value;

                        if (!CheckAvalableStep(lstILLine))
                            continue;

                        m_Rungcur = new CLSILRung();
                        m_Rungcur.BLOCKS = new List<CLSILBlock>();

                        CheckValidILCount(lstILLine);

                        MakeUDL(lstILLine, bLocalTagUseBlockCheck);
                    }

                    if(cUDLDummyBlock != null)
                        cUDLDummyBlock.Routines.Add(m_cUDLRoutineCur);
                    else if (m_dicUDLBlock.Count >= 1)//&& m_lstLocalTagUseBlockName.Contains(m_sBlockNameCur))
                        MakeLocalTagUseBlockRoutine(m_sBlockNameCur, m_cUDLRoutineCur);
                }
                m_cUDL.Blocks = m_dicUDLBlock;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error Program & Line : " + sDebugLine);
                Console.WriteLine(string.Format("{0} : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, error.Message));

                error.Data.Clear();
            }
        }

        private List<CLSILLine> GetValidILLineList(List<CLSILLine> lstILLine)
        {
            List<CLSILLine> lstValidLine = new List<CLSILLine>();




            return lstValidLine;
        }

        private void CheckValidILCount(List<CLSILLine> lstILLine)
        {
            try
            {
                int iValidateILCount = 0;

                foreach (CLSILLine ILLine in lstILLine)
                {
                    if (!ILLine.Command.Contains("MPUSH") && !ILLine.Command.Contains("MLOAD") &&
                        !ILLine.Command.Contains("MPOP")
                        && !ILLine.Command.Contains("AND LOAD") && !ILLine.Command.Contains("OR LOAD"))
                        iValidateILCount++;
                }

                m_Rungcur.ValidILSymbolCount = iValidateILCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void CreateLSUDLTag(DataSet DS) //Change
        {
            try
            {
                m_dicUDLBlock.Clear();
                m_lstUDLTag.Clear();

                foreach (DataTable DT in DS.Tables)
                {
                    if (DT.Columns.Count != 7)
                        continue;

                    int iColType = 0;
                    int iColScope = 1;

                    string sProgram = DT.TableName.Replace(".CSV", string.Empty).Replace("_NewPLC", string.Empty);

                    for (int nrow = 0; nrow < DT.Rows.Count; nrow++)
                    {
                        bool bFBCheck = false;
                        bool bDummyBlockCheck = false;

                        string sType = DT.Rows[nrow].ItemArray[iColType].ToString().ToUpper();
                        string sScope = DT.Rows[nrow].ItemArray[iColScope].ToString();

                        if (sType.Contains("TYPE"))
                            continue;

                        //if (sScope.Contains("Flag")) //Debug
                        //    continue;

                        if (sScope.Contains("ScanProgram"))
                            bDummyBlockCheck = true;

                        if (sScope.Contains("UDF"))
                            bFBCheck = true;

                        if (bFBCheck)
                            nrow += MakeFBBlock(DT, nrow, sScope, sProgram);
                        else if (bDummyBlockCheck)
                            nrow += MakeDummyBlock(DT, nrow, sScope, sProgram);
                        else
                        {
                            CUDLTag cUDLTag = GetUDLTag(DT, nrow, sProgram);
                            if (cUDLTag != null)
                            {
                                m_lstUDLTag.Add(cUDLTag);
                                m_lstGlobalTag.Add(cUDLTag.Address);
                            }
                        }
                    }
                }
                m_cUDL.Tags = m_lstUDLTag;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private CUDLTag GetUDLTag(DataTable DT, int nrow, string sProgram)//Change
        {
            CUDLTag cUDLTag = null;
            try
            {
                cUDLTag = new CUDLTag();

                int iColName = 2;
                int iColAddress = 3;
                int iColDataType = 4;
                int iColDescription = 6;

                string sName = DT.Rows[nrow].ItemArray[iColName].ToString();
                string sAddress = DT.Rows[nrow].ItemArray[iColAddress].ToString().ToUpper();
                string sDataType = DT.Rows[nrow].ItemArray[iColDataType].ToString().ToUpper();
                string sDescription = DT.Rows[nrow].ItemArray[iColDescription].ToString();

                if (sName.Contains("@"))
                    sName = sName.Replace("@", string.Empty);

                cUDLTag.Name = sName;
                cUDLTag.Address = sAddress; //GetDigitAddress(sAddress);//GetAddress(sAddress);
                cUDLTag.Description = sDescription.Replace("$r$n", " ");
                cUDLTag.PLCMaker = EMPLCMaker.LS;

                if (sDataType != string.Empty)
                    cUDLTag.Datatype = GetLSDataType(sDataType);
                else
                    cUDLTag.Datatype = GetLSXGIDataType(sAddress);

                if (cUDLTag.Datatype == EMDataType.UserDefDataType)
                    cUDLTag.UDTType = sDataType;

                cUDLTag.Program = sProgram;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cUDLTag;
        }

        private string GetDigitAddress(string sAddress)
        {
            string sNewAddress = string.Empty;
            bool bHeadTwo = false;

            if (sAddress.StartsWith("ZR"))
                bHeadTwo = true;

            if (sAddress.Contains("."))
                sNewAddress = GetDigitAddressContainDot(sAddress, bHeadTwo);
            else
                sNewAddress = GetDigitAddressNotContainDot(sAddress, bHeadTwo);

            return sNewAddress;
        }

        private string GetDigitAddressContainDot(string sAddress, bool bHeadTwo)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sValue1 = string.Empty;
            string sValue2 = string.Empty;
            int iIndex = -1;

            if (bHeadTwo)
            {
                sHeader = sAddress.Substring(0, 2);
                sValue1 = sAddress.Remove(0, 2);
            }
            else
            {
                sHeader = sAddress.Substring(0, 1);
                sValue1 = sAddress.Remove(0, 1);
            }

            sValue2 = sValue1.Split('.')[1];
            sValue1 = sValue1.Split('.')[0];

            if (sValue1.Length < 5)
            {
                iIndex = 5 - sValue1.Length;

                for (int i = 0; i < iIndex; i++)
                    sValue1 = sValue1.Insert(0, "0");
            }
            else if (sValue1.Length > 5)
            {
                iIndex = sValue1.Length - 5;

                for (int i = 0; i < iIndex; i++)
                    sValue1 = sValue1.Remove(0, 1);
            }

            sNewAddress = string.Format("{0}{1}.{2}", sHeader, sValue1, sValue2);

            return sNewAddress;
        }

        private string GetDigitAddressNotContainDot(string sAddress, bool bHeadTwo)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sValue1 = string.Empty;
            int iIndex = -1;

            if (bHeadTwo)
            {
                sHeader = sAddress.Substring(0, 2);
                sValue1 = sAddress.Remove(0, 2);
            }
            else
            {
                sHeader = sAddress.Substring(0, 1);
                sValue1 = sAddress.Remove(0, 1);
            }

            if (sValue1.Length < 5)
            {
                iIndex = 5 - sValue1.Length;

                for (int i = 0; i < iIndex; i++)
                    sValue1 = sValue1.Insert(0, "0");
            }
            else if (sValue1.Length > 5)
            {
                iIndex = sValue1.Length - 5;

                for (int i = 0; i < iIndex; i++)
                    sValue1 = sValue1.Remove(0, 1);
            }

            sNewAddress = string.Format("{0}{1}", sHeader, sValue1);

            return sNewAddress;
        }


        private string GetAddress(string sAddressRaw)
        {
            string sAddress = string.Empty;
            string sHeader = string.Empty;
            string sValue = string.Empty;

            int DecimalValue = -1;
            string sHexaValue = string.Empty;
          

            if(CLSPlc.IsLSHeadOne(sAddressRaw))
            {
                sHeader = sAddressRaw.Substring(0, 1);
                sValue = sAddressRaw.Remove(0, 1);

                DecimalValue = Convert.ToInt32(sValue, 16);
                sHexaValue = Convert.ToString(DecimalValue, 16).ToUpper();
                sAddress = sHeader + sHexaValue;
            }
            else
            {
                sHeader = sAddressRaw.Substring(0, 2);
                sValue = sAddressRaw.Remove(0, 2);

                DecimalValue = Convert.ToInt32(sValue, 16);
                sHexaValue = Convert.ToString(DecimalValue, 16).ToUpper();
                sAddress = sHeader + sHexaValue;
            }


            return sAddress;
        }

        private int MakeDummyBlock(DataTable DT, int nrow, string sScope, string sProgram)
        {
            int iRowCount = 0;

            try
            {
                int iColType = 0;

                CUDLBlock cUDLBlock = new CUDLBlock();
                cUDLBlock.BlockType = EMBlockType.DummryBlock;
                int index = sScope.IndexOf("\\");
                cUDLBlock.BlockName = sScope.Remove(0, index).Replace("\\", string.Empty);
                
                while (true)
                {
                    bool bCheckInstanceTag = false;

                    if ((nrow + iRowCount) == DT.Rows.Count)
                        break;

                    string sType = DT.Rows[nrow + iRowCount].ItemArray[iColType].ToString().ToUpper();

                    if (!sType.Contains("TAG"))
                        break;

                    CUDLTag cUDLTag = GetUDLTag(DT, nrow + iRowCount, sProgram);
                    iRowCount++;

                    //원래 XGI Series가 아니면 이부분 지워야 함!


                    //if (cUDLTag.Datatype == EMDataType.UserDefDataType || cUDLTag.Name.Contains("."))
                        //bCheckInstanceTag = true;

                    //if (bCheckInstanceTag)
                        m_lstUDLTag.Add(cUDLTag);
                    //else if(!m_lstGlobalTag.Contains(cUDLTag.Address))
                    //{
                    //    cUDLTag.Name = string.Format("{0}.{1}", cUDLBlock.BlockName, cUDLTag.Name);
                    //    cUDLTag.Address = string.Format("{0}.{1}", cUDLBlock.BlockName, cUDLTag.Address);
                    //    cUDLBlock.InputTags.Add(cUDLTag);
                    //}
                }
                m_dicUDLBlock.Add( cUDLBlock.BlockName,cUDLBlock);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iRowCount;
        }

        private int MakeFBBlock(DataTable DT, int nrow, string sScope, string sProgram)//Change
        {
            int iRowCount = 0;

            try
            {
                int iColType = 0;
                int iColProperty = 5;

                CUDLBlock cUDLFBBlock = new CUDLBlock();
                cUDLFBBlock.BlockType = EMBlockType.FunctionBlock;
                int index = sScope.IndexOf("\\");
                cUDLFBBlock.BlockName = sScope.Remove(0, index).Replace("\\", string.Empty);

                while (true)
                {
                    if ((nrow + iRowCount) == DT.Rows.Count)
                        break;

                    string sType = DT.Rows[nrow + iRowCount].ItemArray[iColType].ToString().ToUpper();
                    
                    if (!sType.Contains("TAG"))
                        break;

                    string sProperty = DT.Rows[nrow + iRowCount].ItemArray[iColProperty].ToString();

                    CUDLTag cUDLTag = GetUDLTag(DT, nrow + iRowCount, sProgram);
                    iRowCount++;

                    cUDLTag.Name = string.Format("{0}.{1}", cUDLFBBlock.BlockName, cUDLTag.Name);
                    cUDLTag.Address = string.Format("{0}.{1}", cUDLFBBlock.BlockName, cUDLTag.Address);

                    if (sProperty.Equals("Input"))
                        cUDLFBBlock.InputTags.Add(cUDLTag);
                    else if (sProperty.Equals("Output"))
                        cUDLFBBlock.OutputTags.Add(cUDLTag);
                    else if (sProperty.Equals("Temp"))
                        cUDLFBBlock.TempTags.Add(cUDLTag);
                    else if (sProperty.Equals("InOut"))
                    {
                        cUDLTag.LSFBInOutTagCheck = true;
                        cUDLFBBlock.InOutTags.Add(cUDLTag);
                    }
                }
                m_dicUDLBlock.Add(cUDLFBBlock.BlockName, cUDLFBBlock);                
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iRowCount;
        }

        private void MakeLocalTagUseBlockRoutine(string sRoutineName, CUDLRoutine cUDLRoutine)//Change
        {            
            try
            {                
                foreach(CUDLBlock cUDLBlock in m_dicUDLBlock.Values)
                {
                    if (cUDLBlock.BlockName.Contains(sRoutineName))
                    {
                        cUDLBlock.Routines.Add(cUDLRoutine);
                        break;
                    }
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private EMDataType GetLSDataType(string sDataType)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                if (sDataType.Contains("/"))
                {
                    int index = sDataType.IndexOf("/");
                    sDataType = sDataType.Remove(0, index + 1);
                }

                if (sDataType.Contains("TIMER") || sDataType.Contains("TON") || sDataType.Contains("TP") || sDataType.Contains("TOF"))
                    emDataType = EMDataType.Timer;
                else if (sDataType.Contains("COUNTER") || sDataType.Contains("CTU") || sDataType.Contains("CTD"))
                    emDataType = EMDataType.Counter;
                else
                {
                    switch (sDataType)
                    {
                        case "BOOL" : emDataType = EMDataType.Bool; break;
                        case "BIT": emDataType = EMDataType.Bool; break;
                        case "WORD": emDataType = EMDataType.Word; break;
                        case "DWORD": emDataType = EMDataType.DWord; break;
                        case "DINT": emDataType = EMDataType.DInt; break;
                        case "INT": emDataType = EMDataType.Int; break;
                        case "REAL": emDataType = EMDataType.Real; break;
                        case "BYTE": emDataType = EMDataType.Byte; break;
                        case "STRING": emDataType = EMDataType.String; break;
                        case "TIME" : emDataType = EMDataType.Time; break;
                        default: emDataType = EMDataType.UserDefDataType; break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return emDataType;
        }

        private EMDataType GetLSXGIDataType(string sAddress)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                sAddress = sAddress.Replace("%", string.Empty);

                if (sAddress.StartsWith("M"))
                {
                    if(sAddress.Contains("."))
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

        private void MakeUDL(List<CLSILLine> lstILLine, bool bLocalTagUseBlockCheck)
        {
            CLSILLine ILLineDebug = null;
            m_lstMergeCoilPiece = new List<CLSILPiece>();
            m_lstILPiece = new List<CLSILPiece>();

            CUDLLogic cUDLLogic = null;
            bool bFirst = true;
            int iStep = 0;

            try
            {
                foreach (CLSILLine ILLine in lstILLine)
                {
                    ILLineDebug = ILLine;

                    if (ILLine.Command.Contains("LOAD_ON"))
                        continue;

                    if (bFirst)
                    {
                        bFirst = false;
                        cUDLLogic = new CUDLLogic();
                        cUDLLogic.StepIndex = int.Parse(ILLine.Step);
                        m_Rungcur.StepNum = ILLine.Step;
                    }

                    string sUDLCommand = CreateUDLCommand(ILLine);

                    CLSILPiece ILPiece = null;
                    EMILType emILType = EMILType.NONE;
                    if (ILLine.Command.Contains(".") || ILLine.Command.Contains("_"))
                    {
                        if(!ILLine.ItemAll.Contains("^LINEOUT"))
                            emILType = EMILType.COIL;

                        ILPiece = new CLSILPiece(ILLine, emILType, sUDLCommand);
                    }
                    else
                        ILPiece = new CLSILPiece(ILLine, sUDLCommand);

                    if (bLocalTagUseBlockCheck)
                        UsedTagAnalysis(ILPiece);

                    //m_lstILPiece.Add(ILPiece);

                    AddBlock(ILPiece);
                }


                //if (m_Rungcur.StepNum == "1454")
                //{
                //    int i = 0;
                //}

                iStep = 1;

                CheckMergePointBlock();

                iStep = 2;

                //foreach (CLSILPiece ILPiece in m_lstILPiece)
                //{
                //    if (ILPiece.ILType == EMILType.COIL || ILPiece.ILType == EMILType.ROUTINE || ILPiece.Command.Contains("MPUSH") || ILPiece.Command.Contains("MLOAD") || ILPiece.Command.Contains("MPOP"))
                //        m_lstMergeCoilPiece.Add(ILPiece);
                //}

                MergeCoilBehindAND();
                iStep = 3;

                MergeCoil();
                iStep = 4;

                //EMILType.COIL을 분류 잘해야 함! (ILPiece의 Member Variables)

                if (m_Rungcur.BLOCKS.Count != 0)
                {
                    MergeBlock();
                    MergeBlockPiece();
                    m_Rungcur.Logic.AddRange(m_Rungcur.BLOCKS.Last().MergePiece);
                }

                iStep = 5;

                m_Rungcur.Program = ILLineDebug.Program;
                m_Rungcur.MakeUDL();

                iStep = 6;

                cUDLLogic.Logic = m_Rungcur.UDL;
                m_cUDLRoutineCur.Logics.Add(cUDLLogic);

                m_lstLSILRung.Add(m_Rungcur);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Convert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll);
                Console.WriteLine("Step : {0}", iStep);
                Console.WriteLine(error.Message);
                error.Data.Clear();
            }
        }

        private void MergeBlockPiece()
        {
            List<int> lstBlockIndex = new List<int>();

            CLSILBlock cBlock;
            for(int i = 0 ; i< m_Rungcur.BLOCKS.Count ; i++)
            {
                cBlock = m_Rungcur.BLOCKS[i];

                if(cBlock.MergePiece.Count > 0)
                    lstBlockIndex.Add(i);
            }

            if (lstBlockIndex.Count > 1)
            {
                List<CLSILPiece> lstPiece = new List<CLSILPiece>();

                foreach (int iIndex in lstBlockIndex)
                {
                    lstPiece.AddRange(m_Rungcur.BLOCKS[iIndex].MergePiece);
                    m_Rungcur.BLOCKS[iIndex].MergePiece.Clear();
                }

                m_Rungcur.BLOCKS.Last().MergePiece.AddRange(lstPiece);
            }
        }

        private void CheckMergePointBlock()
        {
            int iStep = 0;

            try
            {
                CLSILPiece cPiece = null;
                //string sKey = string.Empty;
                //List<int> lstRemoveMPOPIndex = new List<int>();

                foreach (CLSILBlock cBlock in m_Rungcur.BLOCKS)
                {
                    if ((cBlock.lstJoinOperator.Contains("MPUSH") || cBlock.lstJoinOperator.Contains("MPOP")) &&
                        !cBlock.MergePiece.Last().ILType.Equals(EMILType.COIL) && cBlock.MergePiece.Count > 1)
                        //AND, AND NOT만 들어온다고 가정
                    {
                        iStep = 1;
                        cPiece = cBlock.MergePiece[1];
                        iStep = 2;
                        cBlock.BufferPiece.Remove(string.Format("{0}_{1}", cPiece.ILLine.Command, cPiece.ILLine.Step));
                        iStep = 3;
                        cPiece.ILLine.Command = cPiece.ILLine.Command.Replace("AND", "LOAD");
                        iStep = 4;
                        cBlock.BufferPiece.Add(string.Format("LD_{0}", cPiece.ILLine.Step), cPiece);
                        iStep = 5;
                    }
                    else if ((cBlock.lstJoinOperator.Contains("MPUSH") || cBlock.lstJoinOperator.Contains("MPOP")) &&
                             cBlock.MergePiece.Last().ILType.Equals(EMILType.COIL) && cBlock.MergePiece.Count > 1)
                    {
                        foreach (var who in cBlock.MergePiece)
                        {
                            if (who.ILType.Equals(EMILType.COIL) || who.ILType.Equals(EMILType.ROUTINE)
                                || who.ILLine.Command.Contains("MPUSH") || who.ILLine.Command.Contains("MLOAD") ||
                                who.ILLine.Command.Contains("MPOP"))
                                m_lstMergeCoilPiece.Add(who);
                        }
                    }
                    else
                    {
                        foreach (var who in cBlock.MergePiece)
                        {
                            if (who.ILType.Equals(EMILType.COIL) || who.ILType.Equals(EMILType.ROUTINE))
                                m_lstMergeCoilPiece.Add(who);
                        }
                    }
                }

                #region TEST

                //foreach (CLSILBlock cBlock in m_Rungcur.BLOCKS)
                //{
                //    if (cBlock.lstJoinOperator.Contains("MPUSH") &&
                //        !cBlock.MergePiece.Last().ILType.Equals(EMILType.COIL)) //AND, AND NOT만 들어온다고 가정
                //    {
                //        //cBlock.BufferPiece.Remove(cBlock.BufferPiece.First().Key);
                //        //cBlock.lstJoinOperator.Clear();
                //        //cBlock.MergePiece.RemoveAt(0);

                //        cPiece = cBlock.MergePiece[1];

                //        cBlock.BufferPiece.Remove(string.Format("{0}_{1}", cPiece.ILLine.Command, cPiece.ILLine.Step));
                //        cPiece.ILLine.Command = cPiece.ILLine.Command.Replace("AND", "LOAD");
                //        cBlock.BufferPiece.Add(string.Format("LD_{0}", cPiece.ILLine.Step), cPiece);

                //        iStep = 1;
                //        //sKey = string.Format("LD_{0}", cPiece.ILLine.Step);
                //        //cBlock.BufferPiece.Add(sKey, cPiece);
                //    }
                //    else if (cBlock.lstJoinOperator.Contains("MPOP") && !cBlock.MergePiece.Last().ILType.Equals(EMILType.COIL)) //AND LOAD를 JoinOperator가 처음으로 나오는 Block 뒤에 생성
                //    {
                //        cBlock.BufferPiece.Remove(cBlock.BufferPiece.First().Key);
                //        cBlock.lstJoinOperator.Clear();
                //        cBlock.MergePiece.RemoveAt(0);

                //        if (cBlock.MergePiece.Count > 0)
                //        {
                //            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(cBlock) - 1].MergePiece.AddRange(
                //                m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(cBlock)].MergePiece);

                //            iStep = 6;
                //            foreach (var who in m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(cBlock)].BufferPiece)
                //                m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(cBlock) - 1].BufferPiece.Add(who.Key, who.Value);

                //            cBlock.MergePiece.Clear();
                //            cBlock.BufferPiece.Clear();
                //        }
                //        lstRemoveMPOPIndex.Add(m_Rungcur.BLOCKS.IndexOf(cBlock));
                //    }
                //}

                //if (lstRemoveMPOPIndex.Count != 0)
                //{
                //    iStep = 2;
                //    string sStep = string.Empty;

                //    for (int i = 0; i < lstRemoveMPOPIndex.Count; i++)
                //    {
                //        iStep = 3;
                //        m_Rungcur.BLOCKS.RemoveAt(lstRemoveMPOPIndex[i] - i);
                //    }

                //}

                //if (lstRemoveMPOPIndex.Count != 0)
                //{
                //    iStep = 2;
                //    string sStep = string.Empty;
                //    int iANBIndex = -1;
                //    int iNotRemoveCount = 0;
                //    foreach (int iRemoveIndex in lstRemoveMPOPIndex)
                //    {
                //        iStep = 13;
                //        sStep = m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].MergePiece.First().ILLine.Step;
                //        iStep = 3;

                //        CLSILPiece cANBPiece = null;
                //        CLSILBlock cANBBlock = null;
                //        for (int i = iRemoveIndex + 1 - iNotRemoveCount; i < m_Rungcur.BLOCKS.Count; i++)
                //        {
                //            if (m_Rungcur.BLOCKS[i].lstJoinOperator.Count > 0 )
                //            {
                //                if (!m_Rungcur.BLOCKS[i].MergePiece.Last().ILLine.Command.Contains("AND"))
                //                {
                //                    iStep = 4;

                //                    iANBIndex = i + 1;
                //                    cANBPiece = new CLSILPiece("AND LOAD", EMILType.CONNECT);
                //                    cANBBlock = new CLSILBlock();
                //                    cANBBlock.lstJoinOperator.Add("AND LOAD");
                //                    cANBBlock.MergePiece.Add(cANBPiece);
                //                    cANBBlock.BufferPiece.Add(string.Format("LD_{0}", sStep), cANBPiece);
                //                }
                //                break;
                //            }
                //        }

                //        iStep = 5;
                //        m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].MergePiece.RemoveAt(0);
                //        m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].BufferPiece.Remove(string.Format("MPOP_{0}", sStep));

                //        if (m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].MergePiece.Count > 0)
                //        {
                //            m_Rungcur.BLOCKS[iRemoveIndex - 1 - iNotRemoveCount].MergePiece.AddRange(
                //                m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].MergePiece);

                //            iStep = 6;
                //            foreach (var who in m_Rungcur.BLOCKS[iRemoveIndex - iNotRemoveCount].BufferPiece)
                //                m_Rungcur.BLOCKS[iRemoveIndex - 1 - iNotRemoveCount].BufferPiece.Add(who.Key, who.Value);
                //        }

                //        if (cANBBlock != null)
                //        {
                //            iStep = 7;
                //            m_Rungcur.BLOCKS.Insert(iANBIndex - iNotRemoveCount, cANBBlock);
                //            iStep = 8;
                //            m_Rungcur.BLOCKS.RemoveAt(iRemoveIndex - iNotRemoveCount);
                //            iStep = 9;
                //        }
                //        else
                //        {
                //            iStep = 10;
                //            m_Rungcur.BLOCKS.RemoveAt(iRemoveIndex - iNotRemoveCount);
                //            iNotRemoveCount++;
                //            iStep = 11;
                //        }
                //    }
                //}
          
                #endregion

                foreach (var who in m_Rungcur.BLOCKS)
                    m_lstILPiece.AddRange(who.MergePiece);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Method : {0}, Error : {1}, Step : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, iStep));
                ex.Data.Clear();
            }
        }


        private void UsedTagAnalysis(CLSILPiece ILPiece)
        {
            try
            {
                string sLocalTag = string.Empty;
                string sNewAddress = string.Empty;
                CUDLBlock cLocalBlock = null;

                List<string> lstUsedAddress = GetUsedAddress(ILPiece.Address);
                
                foreach (CUDLBlock cBlock in m_dicUDLBlock.Values)
                {
                    if (cBlock.BlockName == m_sBlockNameCur)
                    {
                        cLocalBlock = cBlock;
                        break;
                    }
                }

                foreach (string sAddress in lstUsedAddress)
                {
                    bool bOK = false;
                    string sTemp = sAddress;
                    sLocalTag = string.Format("{0}.{1}", m_sBlockNameCur, sAddress);

                    if (cLocalBlock.InputTags.Count != 0 && !bOK)
                        bOK = CheckIncludeLocalTag(sLocalTag, cLocalBlock.InputTags, ref sTemp);
                    if (cLocalBlock.InOutTags.Count != 0 && !bOK)
                        bOK = CheckIncludeLocalTag(sLocalTag, cLocalBlock.InOutTags, ref sTemp);
                    if (cLocalBlock.OutputTags.Count != 0 && !bOK)
                        bOK = CheckIncludeLocalTag(sLocalTag, cLocalBlock.OutputTags, ref sTemp);
                    if (cLocalBlock.TempTags.Count != 0 && !bOK)
                        bOK = CheckIncludeLocalTag(sLocalTag, cLocalBlock.TempTags, ref sTemp);
                    if (cLocalBlock.STATTags.Count != 0 && !bOK)
                        bOK = CheckIncludeLocalTag(sLocalTag, cLocalBlock.STATTags, ref sTemp);

                    sNewAddress += string.Format("{0},", sTemp);
                }

                if (sNewAddress != string.Empty)
                    sNewAddress = sNewAddress.Remove(sNewAddress.Length - 1);
                

                ILPiece.Address = sNewAddress;

                if(!CLSILType.IsConnenctionIL(ILPiece.Command))
                    ILPiece.UDL = string.Format("{0}({1})", ILPiece.Command, ILPiece.Address);
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private List<string> GetUsedAddress(string sAddress)
        {
            List<string> lstUsedAddress = null;

            try
            {
                lstUsedAddress = new List<string>();

                if (sAddress.Contains(","))
                {
                    string[] arrAddress = sAddress.Split(',');

                    foreach (string sTemp in arrAddress)
                        lstUsedAddress.Add(sTemp);
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

        private bool CheckIncludeLocalTag(string sLocalTag, List<CUDLTag> lstUDLTag, ref string sTemp)
        {
            bool bOK = false;

            try
            {
                foreach (CUDLTag cUDLTag in lstUDLTag)
                {
                    if (cUDLTag.Address == sLocalTag || cUDLTag.Name == sLocalTag)
                    {
                        bOK = true;
                        sTemp = sLocalTag;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return bOK;
        }

        private string CreateUDLCommand(CLSILLine ILLine)
        {
            string sUDLCommand = string.Empty;

            try
            {
                string sCommand = ILLine.Command;

                if (m_DicInstructionList.Keys.Contains(sCommand))
                    sUDLCommand = m_DicInstructionList[sCommand].Instruction;
                else if (m_DicRepeatedInstructionList != null && m_DicRepeatedInstructionList.Keys.Contains(sCommand))
                    sUDLCommand = FindInstruction(ILLine);
                else if (!sCommand.Contains("MPUSH") && !sCommand.Contains("MLOAD") && !sCommand.Contains("MPOP")
                    && !sCommand.Contains("OR LOAD") && !sCommand.Contains("AND LOAD"))
                {
                    //Console.WriteLine("Not Support [{0}] Command!", sCommand);
                    sUDLCommand = sCommand;
                }
                else
                    sUDLCommand = sCommand;
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sUDLCommand;
        }

        private string FindInstruction(CLSILLine ILLine)
        {
            string sUDLCommand = string.Empty;

            try
            {
                switch(ILLine.Command) //m_DicRepeatedInstructionList마다 Function 추가
                {
                    default: break;
                }                              
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sUDLCommand;
        }

        private void MergeCoilBehindAND()
        {
            CLSILBlock ILBlockDebug = null;
            CLSILPiece ILPieceDebug = null;

            try
            {
                foreach (CLSILBlock ILBlock in m_Rungcur.BLOCKS)
                {
                    ILBlockDebug = ILBlock;

                    if (ILBlock.lstJoinOperator.Contains("AND LOAD"))
                    {
                        if (m_Rungcur.BLOCKS.Last() != ILBlock && ILBlock.BufferPiece.Count == 1 &&
                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First()
                                .Command.Contains("MPUSH")
                            &&
                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First() !=
                            m_lstMergeCoilPiece[0]) //MPS
                        {
                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First().UDL += "[";

                            CLSILPiece ILMPSPiece =
                                m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First();
                            int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                            CLSILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
                            MergeCoilsInMPPPiece(ILMPPPiece, MPPIndex, m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1);
                        }
                    }

                    foreach (CLSILPiece ILPiece in ILBlock.MergePiece)
                    {
                        ILPieceDebug = ILPiece;

                        if (ILPiece.ILType == EMILType.COIL)
                        {
                            #region CheckANDBehindCoil

                            if (ILPiece != ILBlock.MergePiece.Last())
                            {
                                if (
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILLine.Command.Contains(
                                        "AND") &&
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILType != EMILType.COIL
                                    ||
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILLine.Command.Contains(
                                        "AND NOT"))
                                {
                                    int ANDIndex = ReturnANDIndex(ILBlock.MergePiece,
                                        ILBlock.MergePiece.IndexOf(ILPiece) + 1);

                                    if (!CheckCoilCountBehindAND(ILBlock.MergePiece, ANDIndex) &&
                                        m_Rungcur.BLOCKS.Last() != ILBlock
                                        &&
                                        m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First()
                                            .Command.Contains("MPUSH")) //MPS
                                    {
                                        ILBlock.MergePiece[ANDIndex].UDL += "[";

                                        CLSILPiece ILMPSPiece =
                                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First();
                                        int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                                        CLSILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
                                        MergeCoilsInMPPPiece(ILMPPPiece, MPPIndex, m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1);
                                        break;
                                    }
                                    else
                                    {
                                        if (CheckCoilCountBehindAND(ILBlock.MergePiece, ANDIndex))
                                        {
                                            ILBlock.MergePiece[ANDIndex].UDL += "[";
                                            ILBlock.MergePiece.Last().UDL += "]";
                                            break;
                                        }
                                    }

                                }
                            }

                            #endregion
                        }

                        else if (ILPiece.Command.Contains("MPUSH") || ILPiece.Command.Contains("MLOAD") ||
                                 ILPiece.Command.Contains("MPOP"))
                        {
                            #region CheckANDBehindMergePoint

                            if (ILPiece != ILBlock.MergePiece.Last())
                            {
                                if (
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILLine.Command
                                        .Contains("AND") &&
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILType !=
                                    EMILType.COIL
                                    ||
                                    ILBlock.MergePiece[ILBlock.MergePiece.IndexOf(ILPiece) + 1].ILLine.Command
                                        .Contains("ANI"))
                                {
                                    int ANDIndex = ReturnANDIndex(ILBlock.MergePiece,
                                        ILBlock.MergePiece.IndexOf(ILPiece) + 1);

                                    if (!CheckCoilCountBehindAND(ILBlock.MergePiece, ANDIndex) &&
                                        m_Rungcur.BLOCKS.Last() != ILBlock
                                        &&
                                        m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First()
                                            .Command.Contains("MPUSH")) //MPS
                                    {
                                        ILBlock.MergePiece[ANDIndex].UDL += "[";

                                        CLSILPiece ILMPSPiece =
                                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First
                                                ();
                                        int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                                        CLSILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
                                        MergeCoilsInMPPPiece(ILMPPPiece, MPPIndex,
                                            m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1);
                                        break;
                                    }
                                    else
                                    {
                                        if (CheckCoilCountBehindAND(ILBlock.MergePiece, ANDIndex))
                                        {
                                            ILBlock.MergePiece[ANDIndex].UDL += "[";
                                            ILBlock.MergePiece.Last().UDL += "]";
                                            break;
                                        }
                                    }

                                }
                            }

                            #endregion
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Error", System.Reflection.MethodBase.GetCurrentMethod().Name, ILPieceDebug.ILLine.ItemAll);
                error.Data.Clear();
            }
        }

        private void MergeCoilsInMPPPiece(CLSILPiece ILMPPPiece, int  CurMPPIndex, int BlockIndex)
        {
            for (int i = BlockIndex + 1; i < m_Rungcur.BLOCKS.Count; i++)
            {
                if (m_Rungcur.BLOCKS[i].MergePiece.Contains(ILMPPPiece))
                {
                    if (m_Rungcur.BLOCKS[i].MergePiece.Last().ILType != EMILType.COIL)
                    {
                        int MPPIndex = -1;
                        int MPSIndex = -1;

                        if (CheckMPSPiece(CurMPPIndex))
                        {
                            MPSIndex = ReturnMPSIndex(CurMPPIndex);
                            MPPIndex = ReturnMPPIndex(MPSIndex);
                            ILMPPPiece = m_lstMergeCoilPiece[MPPIndex]; //m_lstMergeCoilPiece[MPPIndex];
                            MergeCoilsInMPPPiece(ILMPPPiece, MPPIndex, i + 1);
                        }
                        else
                            SetUDLRelatedMPPPiece(CurMPPIndex);

                        break;
                    }
                    else
                    {
                        SetUDLRelatedMPPPiece(CurMPPIndex);
                        break;
                    }
                }
            }
        }

        private void SetUDLRelatedMPPPiece(int MPPIndex)
        {
            int iMemoryBlock = 0;

            for (int i = MPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPUSH"))
                    iMemoryBlock++;
                else if (m_lstMergeCoilPiece[i].Command.Contains("MPOP"))
                    iMemoryBlock--;

                if (iMemoryBlock == 0 && (i == m_lstMergeCoilPiece.Count - 1))
                    m_lstMergeCoilPiece[i].UDL += "]";
                else if (iMemoryBlock == 0 && m_lstMergeCoilPiece[i + 1].ILType != EMILType.COIL)
                {
                    m_lstMergeCoilPiece[i].UDL += "]";
                    break;
                }
                else if (iMemoryBlock != 0)
                    Console.WriteLine("Return Out Index Error - MPS 존재함");
            }
        }

        private int ReturnMPSIndex(int CurMPPIndex)
        {
            int MPSIndex = -1;

            for (int i = CurMPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPUSH"))
                {
                    MPSIndex = i;
                    break;
                }
            }
            return MPSIndex;
        }

        private bool CheckMPSPiece(int CurMPPIndex)
        {
            bool bOK = false;

            for (int i = CurMPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPUSH"))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private int ReturnMPPIndex(int MPSIndex)
        {
            int iMemoryBlock = 1;
            int MPPIndex = 0;

            for (int i = MPSIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPUSH"))
                    iMemoryBlock++;
                else if (m_lstMergeCoilPiece[i].Command.Contains("MPOP"))
                    iMemoryBlock--;

                if (iMemoryBlock == 0)
                {
                    MPPIndex = i;
                    break;
                }
            }

            return MPPIndex;
        }

        private int ReturnANDIndex(List<CLSILPiece> lstILPiece, int CurrentANDindex)
        {
            int ANDIndex = CurrentANDindex;

            for (int i = CurrentANDindex + 1; i < lstILPiece.Count; i++)
            {
                if (lstILPiece[i].ILLine.Command.Contains("AND") || lstILPiece[i].ILLine.Command.Contains("AND NOT"))
                    ANDIndex = i;
                else if (lstILPiece[i].ILType == EMILType.COIL)
                    break;
            }
            return ANDIndex;
        }

        private void MergeCoil()
        {
            if (m_lstMergeCoilPiece.Count != 1)
            {
                foreach (CLSILPiece ILPiece in m_lstMergeCoilPiece)
                {
                    if (m_lstMergeCoilPiece.First() == ILPiece)
                    {
                        ILPiece.UDL = ILPiece.UDL.Insert(0, "[");
                        if (!ILPiece.Command.Contains("MPUSH"))
                            ILPiece.UDL += ",";
                    }
                    else if (m_lstMergeCoilPiece.Last() == ILPiece)
                        ILPiece.UDL += "]";
                    else if ((!ILPiece.Command.Contains("MPUSH")) && (!ILPiece.Command.Contains("MPOP")) && (!ILPiece.Command.Contains("MLOAD")))
                        ILPiece.UDL += ",";
                }
            }
        }

        private void AddBlock(CLSILPiece ILPiece)
        {
            string sCommand = ILPiece.ILLine.Command;
            string sStep = ILPiece.ILLine.Step;
            string sKey = string.Format("{0}_{1}", sCommand, sStep);

            if (sCommand.Contains("LOAD"))
                sKey = string.Format("{0}_{1}", "LD", sStep);

            if (sCommand.Contains("LOAD") || sCommand.Contains("AND LOAD") || sCommand.Contains("OR LOAD") || sCommand.Contains("MPUSH")
                || sCommand.Contains("MLOAD") || sCommand.Contains("MPOP"))
            {
                CLSILBlock cLSILBlock = new CLSILBlock();
                m_Rungcur.BLOCKS.Add(cLSILBlock);
            }

            if (m_Rungcur.BLOCKS.Count != 0)
            {
                m_Rungcur.BLOCKS.Last().BufferPiece.Add(sKey, ILPiece);
                m_Rungcur.BLOCKS.Last().MergePiece.Add(ILPiece);

                if ((sCommand.Contains("OR") && ILPiece.ILType != EMILType.COIL) || sCommand.Contains("AND LOAD") || sCommand.Contains("MPUSH")
                    || sCommand.Contains("MLOAD") || sCommand.Contains("MPOP"))
                    m_Rungcur.BLOCKS.Last().lstJoinOperator.Add(sCommand);
            }
            else
                m_Rungcur.Logic.Add(ILPiece);
        }

        private void MergeBlock()
        {
            int iStep = 0;
            try
            {
                foreach (CLSILBlock ILBlock in m_Rungcur.BLOCKS)
                {
                    bool bCheckORBNextOR = false; //ORB IL 바로 뒤에 나오는 OR IL일 경우 TRUE
                    bool bCheckORIncludedORB = false;
                    bool bCheckORIncludedANB = false;

                    foreach (string sJoinOperator in ILBlock.lstJoinOperator)
                    {
                        if (sJoinOperator.Contains("AND LOAD"))
                        {
                            iStep = 1;
                            MergeANDLOAD(ILBlock);

                            iStep = 2;

                            if (ILBlock.lstJoinOperator.Count > 1)
                                bCheckORIncludedANB = true;
                        }
                        else if (sJoinOperator.Contains("OR LOAD"))
                        {
                            iStep = 3;

                            if (CheckORBNextOR(ILBlock, sJoinOperator))
                                bCheckORBNextOR = true;

                            MergeORLOAD(ILBlock, bCheckORBNextOR);
                            iStep = 4;
                        }
                        else if (sJoinOperator.Contains("OR"))
                        {
                            if (ILBlock.lstJoinOperator.Count > 1 && ILBlock.lstJoinOperator.Contains("OR LOAD"))
                                bCheckORIncludedORB = true;

                            iStep = 5;
                            MergeOR(ILBlock, bCheckORIncludedORB, bCheckORBNextOR, bCheckORIncludedANB);
                            iStep = 6;
                            break;
                        }
                        else if (sJoinOperator.Contains("MPUSH") || sJoinOperator.Contains("MLOAD") ||
                                 sJoinOperator.Contains("MPOP"))
                        {
                            iStep = 7;
                            MergePoint(ILBlock);
                            iStep = 8;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method : {0}, Step : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, iStep);
                ex.Data.Clear();
            }
        }

        private bool CheckORBNextOR(CLSILBlock ILBlock, string sJoinOperator)
        {
            bool bOK = false;

            if (ILBlock.lstJoinOperator.Count > 1)
            {
                if ((ILBlock.lstJoinOperator.Last() != sJoinOperator) &&
                    (ILBlock.MergePiece[ILBlock.lstJoinOperator.IndexOf(sJoinOperator) + 1].ILLine
                        .Command.Contains("OR")))
                    bOK = true;
            }
            //else if (ILBlock.lstJoinOperator.Count == 1)
            //{
            //    if (ILBlock.MergePiece.Count > 1)
            //        bOK = false;
            //    else
            //    {
            //        int iBlockIndex = m_Rungcur.BLOCKS.IndexOf(ILBlock);

            //        for (int i = iBlockIndex + 1; i < m_Rungcur.BLOCKS.Count; i++)
            //        {
            //            if (m_Rungcur.BLOCKS[i].lstJoinOperator.Count > 0)
            //            {
            //                if (m_Rungcur.BLOCKS[i].MergePiece.Count == 1)
            //                {
            //                    foreach (string sOperator in m_Rungcur.BLOCKS[i].lstJoinOperator)
            //                    {
            //                        if (sOperator.Contains("OR"))
            //                        {
            //                            bOK = true;
            //                            break;
            //                        }
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //    }
            //}

            return bOK;
        }

        private void MergePointANDLOAD(CLSILBlock ILBlock)
        {
            int iBlockCount = 0;

            List<CLSILBlock> lstMergeBlock = new List<CLSILBlock>();
            CLSILBlock cFirstBlock = null;

            for (int i = (m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1); i >= 0; i--)
            {
                if (m_Rungcur.BLOCKS[i].MergePiece.Count != 0)
                {
                    lstMergeBlock.Add(m_Rungcur.BLOCKS[i]);
                    iBlockCount++;
                }

                if (iBlockCount == 1)
                    break;
            }

            cFirstBlock = lstMergeBlock[0];

            if (cFirstBlock.IsMergeStartBlock)
                ILBlock.IsMergeStartBlock = true;

            ILBlock.MergePiece.Reverse();

            cFirstBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cFirstBlock.MergePiece);
            cFirstBlock.MergePiece.Clear();

            ILBlock.MergePiece.Reverse();
        }

        private void MergeANDLOAD(CLSILBlock ILBlock)
        {
            int iBlockCount = 0;

            List<CLSILBlock> lstMergeBlock = new List<CLSILBlock>();
            CLSILBlock cFirstBlock = null;
            CLSILBlock cSecondBlock = null;

            for (int i = (m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1); i >= 0; i--)
            {
                if (m_Rungcur.BLOCKS[i].MergePiece.Count != 0)
                {
                    lstMergeBlock.Add(m_Rungcur.BLOCKS[i]);
                    iBlockCount++;
                }

                if (iBlockCount == 2)
                    break;
            }

            //if (lstMergeBlock.Count == 1)
            //{
            //    ILBlock.MergePiece.RemoveAt(0);
            //    ILBlock.MergePiece.AddRange(lstMergeBlock.First().MergePiece);
            //    return;
            //}

            cFirstBlock = lstMergeBlock[0];
            cSecondBlock = lstMergeBlock[1];

            ILBlock.MergePiece.RemoveAt(0);
            ILBlock.MergePiece.Reverse();

            cFirstBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cFirstBlock.MergePiece);
            cFirstBlock.MergePiece.Clear();

            cSecondBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cSecondBlock.MergePiece);
            cSecondBlock.MergePiece.Clear();

            ILBlock.MergePiece.Reverse();
        }

        private void MergeORLOAD(CLSILBlock ILBlock, bool bCheckORBNextOR)
        {
            int iBlockCount = 0;
            bool bNewORBCheck = true;

            List<CLSILBlock> lstMergeBlock = new List<CLSILBlock>();
            CLSILBlock cFirstBlock = null;
            CLSILBlock cSecondBlock = null;

            for (int i = (m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1); i >= 0; i--)
            {
                if (m_Rungcur.BLOCKS[i].MergePiece.Count != 0)
                {
                    lstMergeBlock.Add(m_Rungcur.BLOCKS[i]);
                    iBlockCount++;
                }

                if (iBlockCount == 2)
                    break;
            }

            cFirstBlock = lstMergeBlock[0];
            cSecondBlock = lstMergeBlock[1];

            if (cSecondBlock.lstJoinOperator.Contains("OR LOAD"))
            {
                if (cSecondBlock.BufferPiece.Count == 1)
                    bNewORBCheck = false;
            }

            ILBlock.MergePiece.RemoveAt(0);
            ILBlock.MergePiece.Reverse();

            if (!bCheckORBNextOR)
                cFirstBlock.MergePiece.Last().UDL = cFirstBlock.MergePiece.Last().UDL.Insert(cFirstBlock.MergePiece.Last().UDL.Length, "]");
            cFirstBlock.MergePiece.First().UDL = cFirstBlock.MergePiece.First().UDL.Insert(0, ",");

            cFirstBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cFirstBlock.MergePiece);
            cFirstBlock.MergePiece.Clear();

            if (bNewORBCheck)
                cSecondBlock.MergePiece.First().UDL = cSecondBlock.MergePiece.First().UDL.Insert(0, "[");
            else
            {
                if(!cSecondBlock.MergePiece.Last().UDL.EndsWith(")"))
                    cSecondBlock.MergePiece.Last().UDL = cSecondBlock.MergePiece.Last()
                    .UDL.Substring(0, cSecondBlock.MergePiece.Last().UDL.Length - 1);
            }

            cSecondBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cSecondBlock.MergePiece);
            cSecondBlock.MergePiece.Clear();

            ILBlock.MergePiece.Reverse();

            if (m_bMergeEnd)
            {
                if (cSecondBlock.IsMergeStartBlock)
                {
                    MergePointANDLOAD(ILBlock);
                    CLSILPiece cPiece = new CLSILPiece("AND LOAD", EMILType.CONNECT);
                    ILBlock.BufferPiece.Add(string.Format("LD_{0}", ILBlock.MergePiece.First().ILLine.StepNumber + 1), cPiece);
                }

                m_bMergeEnd = false;
            }
            else
            {
                if (cSecondBlock.IsMergeStartBlock)
                    ILBlock.IsMergeStartBlock = true;
            }

        }

        private void MergeOR(CLSILBlock ILBlock, bool bCheckORIncludedORB, bool bCheckORBNextOR, bool bCheckORIncludedANB)
        {
            bool bORCheckRoledORB = false;

            if(bCheckORIncludedANB)
                ILBlock.MergePiece.First().UDL = string.Format("[{0}", ILBlock.MergePiece.First().UDL);
            else if (!bCheckORIncludedORB)
            {
                if (!ILBlock.MergePiece.First().UDL.Contains("["))
                    ILBlock.MergePiece.First().UDL = string.Format("[{0}", ILBlock.MergePiece.First().UDL);
            }
            else
            {
                if (!bCheckORBNextOR)
                    ILBlock.MergePiece.First().UDL = string.Format("[{0}", ILBlock.MergePiece.First().UDL);
            }

            for (int i = 0; i < ILBlock.BufferPiece.Count; i++)
            {
                if (ILBlock.BufferPiece.ElementAt(i).Key.Contains("OR") && !ILBlock.BufferPiece.ElementAt(i).Key.Contains("OR LOAD") && ILBlock.BufferPiece.ElementAt(i).Value.ILType != EMILType.COIL)
                {
                    if (bORCheckRoledORB)
                    {
                        ILBlock.MergePiece.First().UDL = string.Format("[{0}", ILBlock.MergePiece.First().UDL);
                        bORCheckRoledORB = false;
                    }

                    string sTemp = string.Format(",{0}", ILBlock.BufferPiece.ElementAt(i).Value.UDL);
                    ILBlock.MergePiece[ILBlock.MergePiece.Count - ILBlock.BufferPiece.Count + i].UDL = sTemp;

                    if (i == (ILBlock.BufferPiece.Count - 1))
                    {
                        if (!ILBlock.MergePiece.Last().UDL.Contains("]"))
                            ILBlock.MergePiece.Last().UDL = string.Format("{0}]", ILBlock.MergePiece.Last().UDL);
                    }
                    else
                    {
                        if (!ILBlock.BufferPiece.ElementAt(i + 1).Key.Contains("OR"))
                        {
                            ILBlock.MergePiece[ILBlock.MergePiece.Count - ILBlock.BufferPiece.Count + i].UDL = string.Format("{0}]", ILBlock.MergePiece[ILBlock.MergePiece.Count - ILBlock.BufferPiece.Count + i].UDL);
                            bORCheckRoledORB = true;
                            continue;
                        }
                    }
                }
            }
        }

        private void MergePoint(CLSILBlock ILBlock)
        {
            if (ILBlock.MergePiece.Last().ILType.Equals(EMILType.COIL))// || ILBlock.MergePiece.First().ILType.Equals(EMILType.COIL))
            {
                ILBlock.MergePiece.Reverse();

                CLSILBlock ILLastBlock = m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1];

                ILLastBlock.MergePiece.Reverse();
                ILBlock.MergePiece.AddRange(ILLastBlock.MergePiece);
                ILLastBlock.MergePiece.Clear();

                ILBlock.MergePiece.Reverse();
            }
            else
            {
                if (ILBlock.lstJoinOperator.Contains("MPUSH"))
                {
                    ILBlock.BufferPiece.Remove(string.Format("MPUSH_{0}", ILBlock.MergePiece.First().ILLine.Step));
                    ILBlock.MergePiece.RemoveAt(0);

                    if(m_Rungcur.BLOCKS.First() != ILBlock)
                        ILBlock.IsMergeStartBlock = true;
                }
                else
                {
                    ILBlock.BufferPiece.Remove(string.Format("MPOP_{0}", ILBlock.MergePiece.First().ILLine.Step));
                    ILBlock.MergePiece.RemoveAt(0);
                    m_bMergeEnd = true;
                }
            }
        }

        private bool CheckAvalableStep(List<CLSILLine> lstline)
        {
            try
            {
                if (lstline.Count == 1)
                {
                    if (CLSILType.IsSkipIL(lstline[0].Command))
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckAvalable Step " + ex.Message);
                ex.Data.Clear();
            }

            return true;
        }

        private bool CheckCoilCountBehindAND(List<CLSILPiece> lstILPiece, int index)
        {
            int iCoilCount = 0;
            bool bOK = false;

            for (int i = index + 1; i < lstILPiece.Count; i++)
            {
                if (IsCoilCommand(lstILPiece[i].ILLine.Command))
                    iCoilCount++;
            }

            if (iCoilCount > 1)
                bOK = true;

            return bOK;
        }

        private Dictionary<string, List<CLSILLine>> GetRung(List<CLSILLine> lstILLine)
        {
            CLSILLine ILLineDebug = null;

            try
            {
                Dictionary<string, List<CLSILLine>> DicILLine = new Dictionary<string, List<CLSILLine>>();
                List<CLSILLine> lstILLineFinded = new List<CLSILLine>();

                bool bNextLoad = false;
                bool bLastILLine = false;
                bool bFBILLine = false;

                foreach (CLSILLine cILLine in lstILLine)
                {
                    ILLineDebug = cILLine;

                    if (cILLine.Command == "NOP" || cILLine.Command == string.Empty)
                        continue;

                    if (cILLine.Command.Contains(".") ||
                        cILLine.Command.Contains("_") && !cILLine.Command.Contains("LOAD"))
                        bFBILLine = true;
                    else
                        bFBILLine = false;

                    if (lstILLine.Last() != cILLine)
                    {
                        CLSILLine cILLineNext = lstILLine[lstILLine.IndexOf(cILLine) + 1];
                        if (CLSILType.IsLoad(cILLineNext.Command) || CLSILType.IsCommandOnlyIL(cILLineNext.Command) || CLSILType.IsOneCommandIL(cILLineNext.Command))
                            bNextLoad = true;
                        else
                            bNextLoad = false;

                        bLastILLine = false;
                    }
                    else
                        bLastILLine = true;

                    lstILLineFinded.Add(cILLine);

                    //Rung 생성
                    if ((bLastILLine || CLSILType.IsCommandOnlyIL(cILLine.Command) || CLSILType.IsSkipIL(cILLine.Command) || CLSILType.IsOneCommandIL(cILLine.Command))
                        || (!bFBILLine && IsCoilCommand(cILLine.Command) && bNextLoad )//&& IsPairringMemoryBlock(lstILLineFinded)) 
                        || (bFBILLine && bNextLoad && IsCoilCommand(cILLine.Command, cILLine.ItemAll)))//&& IsPairringMemoryBlock(lstILLineFinded)))
                    {
                        if (lstILLineFinded.Count != 0)
                        {
                            //if (IsPairringLoad(lstILLineFinded))
                                DicILLine.Add(cILLine.Program + ";" + cILLine.Step, lstILLineFinded);
                            //else
                            //{
                                //List<CLSILLine> lstLine = new List<CLSILLine>();
                                //foreach (CLSILLine ILLinePairring in lstILLineFinded)
                                //{
                                //    if(!!ILLinePairring.Command.Contains("OR LOAD") && !ILLinePairring.Command.Contains("AND LOAD"))
                                //        lstLine.Add(ILLinePairring);
                                //}

                                //DicILLine.Add(cILLine.Program + ";" + cILLine.Step, lstILLineFinded);
                            //}
                            lstILLineFinded = new List<CLSILLine>();
                        }
                    }
                }
                return DicILLine;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : Can't Covert IL Line [{0}] ",System.Reflection.MethodBase.GetCurrentMethod().Name); 
                Console.WriteLine(error.Message);
                error.Data.Clear();
                return null;
            }
        }

        private bool IsCoilCommand(string sCommand, string sOperand)
        {
            bool bOK = false;

            if (!CLSILType.IsConnenctionIL(sCommand)
                && !CLSILType.IsConnenctionOperationIL(sCommand)
                && !CLSILType.IsContactIL(sCommand)
                && !CLSILType.IsSkipIL(sCommand)
                )
            {
                if (sOperand.Contains("LINEOUT"))
                    bOK = false;
                else
                    bOK = true;
            }
            else
                bOK = false;

            return bOK;
        }

        private bool IsCoilCommand(string strOperator) //Change
        {
            if (!CLSILType.IsConnenctionIL(strOperator)
                && !CLSILType.IsConnenctionOperationIL(strOperator)
                && !CLSILType.IsContactIL(strOperator)
                && !CLSILType.IsSkipIL(strOperator)
                )
                return true;
            else
                return false;
        }

        private bool IsPairringMemoryBlock(List<CLSILLine> ListILLine)
        {
            bool bOK = false;

            try
            {
                int iMPS = 0;
                int iMRD = 0;
                int iMPP = 0;
                int iMemoryBlockCount = 0;
                int iCoilCount = 0;

                foreach (CLSILLine ILLine in ListILLine)
                {
                    if (IsCoilCommand(ILLine.Command, ILLine.ItemAll))
                        iCoilCount++;
                    else if (ILLine.Command.Contains("MPUSH"))
                        iMPS++;
                    else if (ILLine.Command.Contains("MLOAD"))
                        iMRD++;
                    else if (ILLine.Command.Contains("MPOP"))
                        iMPP++;
                }

                iMemoryBlockCount = iMPS >= iMPP ? iMPP : iMPS;
                iMemoryBlockCount += iMRD;

                if (iMemoryBlockCount == 0)
                    bOK = true;
                else if (iCoilCount >= iMemoryBlockCount)
                    bOK = true;
                else
                    bOK = false;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
                error.Data.Clear();
            }

            return bOK;
        }

        private bool IsPairringLoad(List<CLSILLine> ListILLine)
        {
            try
            {
                int nLoadIndex = 0;
                int nANBORBIndex = 0;

                foreach (CLSILLine ILLine in ListILLine)
                {
                    if (ListILLine[0] == ILLine)
                        continue;

                    if (CLSILType.IsLoad(ILLine.Command))
                        nLoadIndex++;
                    else if (ILLine.Command == "AND LOAD" || ILLine.Command == "OR LOAD")
                        nANBORBIndex++;
                }

                return nLoadIndex == nANBORBIndex ? true : false;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        #endregion

    }
}
