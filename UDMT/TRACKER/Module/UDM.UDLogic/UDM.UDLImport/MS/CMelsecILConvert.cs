using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using UDM.General;
using UDM.Common;
using UDM.UDL;
using System.Data;

namespace UDM.UDLImport
{
    public class CMelsecILConvert
    {
        private CUDL m_cUDL = new CUDL();
        private Dictionary<string, CUDLBlock> m_dicUDLBlock = new Dictionary<string, CUDLBlock>();
        private List<CUDLTag> m_lstUDLTag = new List<CUDLTag>();
        private CUDLBlock m_cUDLBlockCur = new CUDLBlock();
        private CUDLRoutine m_cUDLRoutineCur = null;
        private CMelsecILImport m_cMelsecILImport = null;
        private CMelsecILRung m_Rungcur = null;
        private List<CMelsecILPiece> m_lstILPiece = null;
        private List<CMelsecILPiece> m_lstMergeCoilPiece = null;
        private Dictionary<string, CInstruction> m_DicInstructionList = null;
        private Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;

        //Debug 용
        private List<CMelsecILRung> m_lstMelsecILRung = new List<CMelsecILRung>();

        #region Initialize/Dispose

        public CMelsecILConvert(DataSet dbCSV, Dictionary<string, CInstruction> DicInstructionList, Dictionary<string, List<CInstruction>> DicRepeatedInstructionList)
        {
            m_DicInstructionList = DicInstructionList;

            if (DicRepeatedInstructionList != null)
                m_DicRepeatedInstructionList = DicRepeatedInstructionList;

            CreateMelsecUDLTag(dbCSV);

            if (CheckLogicImport(dbCSV))
                CreateMelsecUDLLogic(dbCSV);
        }

        #endregion

        #region Properties

        public CUDL UDL
        {
            get { return m_cUDL; }
            set { m_cUDL = value; }
        }

        public List<CMelsecILRung> lstILRung
        {
            get { return m_lstMelsecILRung; }
            set { m_lstMelsecILRung = value; }
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

        #endregion

        #region Public Method

        public CTagS CreateMelsecTagS()
        {
            CTagS cTagS = null;

            try
            {
                cTagS = new CTagS();
                CTag cTag = null;

                foreach (CUDLTag UDLTag in m_lstUDLTag)
                {
                    cTag = new CTag();

                    cTag.Channel = "[CH_DV]"; //사용자 정의로 바꿔야 할 수 도 있음. 
                    cTag.Name = UDLTag.Name;
                    cTag.Address = UDLTag.Address;
                    cTag.Description = UDLTag.Description;
                    cTag.DataType = UDLTag.Datatype;
                    cTag.Program = UDLTag.Program;
                    cTag.PLCMaker = UDLTag.PLCMaker;

                    if (UDLTag.Name != string.Empty)
                        cTag.Key = string.Format("{0}{1}[{2}]", cTag.Channel, cTag.Name, cTag.Size);
                    else
                        cTag.Key = string.Format("{0}{1}[{2}]", cTag.Channel, cTag.Address, cTag.Size);

                    if (CMelsecPlc.IsMelsecHexa(UDLTag.Address))
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

        private bool CheckLogicImport(DataSet dbCSV)
        {
            bool bOK = false;

            try
            {
                foreach(DataTable DT in dbCSV.Tables)
                {
                    if (m_lstUDLTag.Count > 0 )
                    {
                        if (m_lstUDLTag.First().PLCMaker == EMPLCMaker.Mitsubishi_Developer && DT.Columns.Count == 9)
                        {
                            bOK = true;
                            break;
                        }
                        else if (m_lstUDLTag.First().PLCMaker == EMPLCMaker.Mitsubishi_Works2 && DT.Columns.Count == 7)
                        {
                            bOK = true;
                            break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bOK;
        }

        private void CreateMelsecUDLLogic(DataSet dbCSV)
        {
            m_cMelsecILImport = new CMelsecILImport();
            m_cMelsecILImport.ImportIL(dbCSV);

            ConvertIL();
        }

        private void ConvertIL()//Change 
        {
            string sDebugLine = string.Empty;

            try
            {
                m_dicUDLBlock.Clear();

                m_cUDLBlockCur.BlockType = EMBlockType.DummryBlock;
                m_cUDLBlockCur.BlockName = "MITSUBISHI Project";
                m_cUDLBlockCur.Routines.Clear();
                
                m_lstMelsecILRung.Clear();

                Dictionary<string, List<CMelsecILLine>> DicILLineProgram = m_cMelsecILImport.DiCMelsecILLine;

                Dictionary<string, List<CMelsecILLine>> DicILLine = new Dictionary<string, List<CMelsecILLine>>();

                foreach (var whoProgram in DicILLineProgram)
                {
                    DicILLine = GetRung(whoProgram.Value);
                    if (DicILLine == null)
                        continue;

                    m_cUDLRoutineCur = new CUDLRoutine();
                    m_cUDLRoutineCur.RoutineName = whoProgram.Key;

                    foreach (var who in DicILLine)
                    {
                        sDebugLine = who.Key;
                        List<CMelsecILLine> lstILLine = who.Value;

                        if (!CheckAvalableStep(lstILLine))
                            continue;

                        m_Rungcur = new CMelsecILRung();
                        m_Rungcur.BLOCKS = new List<CMelsecILBlock>();

                        CheckValidILCount(lstILLine);

                        MakeUDL(lstILLine);
                    }

                    m_cUDLBlockCur.Routines.Add(m_cUDLRoutineCur);
                }

                m_dicUDLBlock.Add(m_cUDLBlockCur.BlockName,m_cUDLBlockCur);
                m_cUDL.Blocks = m_dicUDLBlock;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error Program & Line : " + sDebugLine);
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        private void CheckValidILCount(List<CMelsecILLine> lstILLine)
        {
            int iValidateILCount = 0;

            foreach(CMelsecILLine ILLine in lstILLine)
            {
                if (!ILLine.Command.Contains("MPS") && !ILLine.Command.Contains("MRD") && !ILLine.Command.Contains("MPP")
                    && !ILLine.Command.Contains("ANB") && !ILLine.Command.Contains("ORB"))
                    iValidateILCount++;
            }

            m_Rungcur.ValidILSymbolCount = iValidateILCount;
        }

        private void CreateMelsecUDLTag(DataSet DS)//Change 
        {
            string sProgram = string.Empty;

            try
            {
                m_lstUDLTag.Clear();

                foreach (DataTable DT in DS.Tables)
                {
                    #region Developer, Works2 Comment Tag File
                    if (DT.Columns.Count == 2 || DT.Columns.Count == 3)
                    {
                        int iColAddress = 0;
                        int iColSymbol = -1;

                        if (DT.Columns.Count == 2)
                            iColSymbol = 1;
                        else
                            iColSymbol = 2;

                        sProgram = DT.TableName.Replace(".csv", string.Empty).ToUpper();

                        for (int nrow = 0; nrow < DT.Rows.Count; nrow++)
                        {
                            string sAddress = DT.Rows[nrow].ItemArray[iColAddress].ToString().ToUpper();
                            string sDescription = DT.Rows[nrow].ItemArray[iColSymbol].ToString();

                            CUDLTag cUDLTag = new CUDLTag();

                            //cUDLTag.Name = string.Format("{0}_{1}", sProgram, sAddress);
                            cUDLTag.Program = sProgram;
                            cUDLTag.Address = GetAddressFittingFormat(sAddress);
                            cUDLTag.Description = sDescription;

                            if (DT.Columns.Count == 3)
                                cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Developer;
                            else
                                cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Works2;

                            cUDLTag.Datatype = GetMelsecDataType(sAddress);

                            m_lstUDLTag.Add(cUDLTag);
                        }
                    }
                    #endregion
                    #region Works2, Works3 Tag File
                    else //Works2, Work3 Tag File
                    {
                        if (DT.Columns[0].Caption == "Class")
                        {
                            int iColSymbol = 1;
                            int iColDataType = 2;
                            int iColAddress = 4;
                            int iColDescription = 6;
                            
                            if (DT.Columns[6].Caption != "Comment")
                                iColDescription = 5;

                            if (DT.Columns[4].Caption != "Device")
                            {
                                iColAddress = 5;
                                iColDescription = 7;
                            }


                            sProgram = DT.TableName.Replace(".csv", string.Empty).ToUpper();

                            for (int nrow = 0; nrow < DT.Rows.Count; nrow++)
                            {
                                string sName = DT.Rows[nrow].ItemArray[iColSymbol].ToString().ToUpper();
                                string sDataType = DT.Rows[nrow].ItemArray[iColDataType].ToString().ToUpper();
                                string sAddress = DT.Rows[nrow].ItemArray[iColAddress].ToString().ToUpper();
                                string sDescription = DT.Rows[nrow].ItemArray[iColDescription].ToString();

                                bool bCheckArray = false;

                                if (sDataType.Contains("ARRAY"))
                                    bCheckArray = true;
                                
                                if(bCheckArray)
                                {
                                    CreateArrayUDLTag(sName, sDataType, sAddress, sDescription, sProgram, DT.Columns.Count);
                                    continue;
                                }

                                CUDLTag cUDLTag = new CUDLTag();

                                cUDLTag.Name = sName;
                                cUDLTag.Program = sProgram;
                                cUDLTag.Address = GetAddressFittingFormat(sAddress);
                                cUDLTag.Description = sDescription;

                                if (DT.Columns.Count > 20)
                                    cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Works3;
                                else
                                    cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Works2;

                                cUDLTag.Datatype = GetMelsecWorks3DataType(sDataType);                            
                                m_lstUDLTag.Add(cUDLTag);
                            }
                        }
                    }
                    #endregion
                }
                m_cUDL.Tags = m_lstUDLTag;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sProgram); ex.Data.Clear();
            }
        }

        private string GetAddressFittingFormat(string sAddress)
        {
            string sNewAddress = string.Empty;
            string sAddressHeader = string.Empty;
            string sAddressIndex = string.Empty;
            string sTemp = string.Empty;

            if(sAddress.Length < 2)
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

        private void CreateArrayUDLTag(string sName, string sDataType, string sAddress, string sDescription, string sProgram, int ColumnCount)
        {
            try
            {
                CUDLTag cUDLTag = null;

                int DataTypeIndex = sDataType.IndexOf("OF ");

                int Index = sDataType.IndexOf("]");
                string sTemp = sDataType.Substring(0, Index);

                Index = sTemp.IndexOf(".");
                sTemp = sTemp.Remove(0, Index);

                string sArraySize = sTemp.Replace(".", string.Empty);
                int iArraySize = Int32.Parse(sArraySize);
                string sDataTypeTemp = sDataType.Remove(0, DataTypeIndex + 3);

                for(int i = 0 ; i <= iArraySize ; i++)
                {
                    cUDLTag = new CUDLTag();

                    cUDLTag.Name = string.Format("{0}[{1}]", sName, i);
                    cUDLTag.Address = GetNextArrayAddress(sAddress, i);
                    cUDLTag.Program = sProgram;
                    cUDLTag.Description = sDescription;
                    cUDLTag.Datatype = GetMelsecWorks3DataType(sDataTypeTemp);

                    if (ColumnCount > 20)
                        cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Works3;
                    else
                        cUDLTag.PLCMaker = EMPLCMaker.Mitsubishi_Works2;

                    m_lstUDLTag.Add(cUDLTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string GetNextArrayAddress(string sAddress, int nNext)
        {
            string sNextAddress = string.Empty;
            string sAddressType = GetAddressType(sAddress);
            string sAddressIndex = sAddress.Substring(sAddressType.Length, sAddress.Length - sAddressType.Length);

            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            sNextAddress = GetMelsecNextAddress(sAddress, sAddressIndex, sAddressType, nNext);
            sNextAddress = GetAddressFittingFormat(sNextAddress);

            return sNextAddress;
        }

        private string GetAddressType(string sAddress)
        {
            string sAddressType = string.Empty;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
                sAddressType = sAddress.Substring(0, 1);
            else if (CMelsecPlc.IsMelsecHeadTwo(sAddress))
                sAddressType = sAddress.Substring(0, 2);

            return sAddressType;
        }

        private string GetMelsecNextAddress(string sAddress, string sAddressIndex, string sAddressType, int nNext)
        {
            string sNextAddress = string.Empty;

            if (CMelsecPlc.IsMelsecHexa(sAddress))
            {
                if (sAddressIndex.Contains("."))
                {
                    int nAddress = Convert.ToInt32(sAddressIndex.Split('.')[1], 16);
                    int nAddressIndex = Convert.ToInt32(sAddressIndex.Split('.')[0], 16);
                    int nAddressHeader = (nAddress + nNext)/16;
                    int nAddressTail = (nAddress + nNext) % 16;

                    sNextAddress = string.Format("{0}{1:X}.{2:X}", sAddressType, nAddressIndex + nAddressHeader, nAddressTail);
                }
                else
                {
                    int nAddress = Convert.ToInt32(sAddressIndex, 16);
                    sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nNext);
                }
            }
            else
            {
                if (sAddressIndex.Contains("."))
                {
                    int nAddress = Convert.ToInt32(sAddressIndex.Split('.')[1], 16);
                    int nAddressIndex = Convert.ToInt32(sAddressIndex.Split('.')[0]);
                    int nAddressHeader = (nAddress + nNext) / 16;
                    int nAddressTail = (nAddress + nNext) % 16;

                    sNextAddress = string.Format("{0}{1}.{2:X}", sAddressType, nAddressIndex + nAddressHeader, nAddressTail);
                }
                else
                {
                    int nAddress = Convert.ToInt32(sAddressIndex, 10);
                    sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nNext);
                }
            }

            return sNextAddress;
        }

        private EMDataType GetMelsecDataType(string sAddress)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                if (CMelsecPlc.IsMelsecBit(sAddress))
                    emDataType = EMDataType.Bool;
                else if (CMelsecPlc.IsMelsecWord(sAddress))
                    emDataType = EMDataType.Word;
                else
                    emDataType = EMDataType.None;
              
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return emDataType;
        }

        private EMDataType GetMelsecWorks3DataType(string sDataType)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                    if (sDataType.Contains("TIMER"))
                        emDataType = EMDataType.Timer;
                    else if (sDataType.Contains("COUNTER"))
                        emDataType = EMDataType.Counter;

                    switch (sDataType)
                    {
                        case "BOOL": emDataType = EMDataType.Bool; break;
                        case "WORD": emDataType = EMDataType.Word; break;
                        case "DWORD": emDataType = EMDataType.DWord; break;
                        case "DINT": emDataType = EMDataType.DInt; break;
                        case "INT": emDataType = EMDataType.Int; break;
                        case "REAL": emDataType = EMDataType.Real; break;
                        case "BYTE": emDataType = EMDataType.Byte; break;
                        case "STRING": emDataType = EMDataType.String; break;
                    }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return emDataType;
        }    

        private void MakeUDL(List<CMelsecILLine> lstILLine)
        {
            CMelsecILLine ILLineDebug = null;
            m_lstMergeCoilPiece = new List<CMelsecILPiece>();
            m_lstILPiece = new List<CMelsecILPiece>();

            CUDLLogic cUDLLogic = null;

            try
            {
                foreach (CMelsecILLine ILLine in lstILLine)
                {
                    ILLineDebug = ILLine;

                    if (lstILLine.First() == ILLine)
                    {
                        cUDLLogic = new CUDLLogic();
                        cUDLLogic.StepIndex = int.Parse(ILLine.Step);
                        m_Rungcur.StepNum = ILLine.Step;
                    }

                    string sUDLCommand = CreateUDLCommand(ILLine);

                    CMelsecILPiece ILPiece = new CMelsecILPiece(ILLine, sUDLCommand);
                    m_lstILPiece.Add(ILPiece);

                    AddBlock(ILPiece);

                    if (ILPiece.ILType == EMILType.COIL || ILPiece.ILType == EMILType.ROUTINE || ILPiece.Command.Contains("MPS") 
                       || ILPiece.Command.Contains("MRD") || ILPiece.Command.Contains("MPP"))
                        m_lstMergeCoilPiece.Add(ILPiece);
                }

                MergeCoilBehindANDCommand();

                MergeCoil();

                //EMILType.COIL을 분류 잘해야 함! (ILPiece의 Member Variables)

                if (m_Rungcur.BLOCKS.Count != 0)
                {
                    MergeBlock();
                    m_Rungcur.Logic.AddRange(m_Rungcur.BLOCKS.Last().MergePiece);
                }

                m_Rungcur.Program = ILLineDebug.Program;
                m_Rungcur.MakeUDL();

                cUDLLogic.Logic = m_Rungcur.UDL;
                m_cUDLRoutineCur.Logics.Add(cUDLLogic);

                m_lstMelsecILRung.Add(m_Rungcur);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Convert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll);
                error.Data.Clear();
            }
        }

        private string CreateUDLCommand(CMelsecILLine ILLine)
        {
            string sUDLCommand = string.Empty;

            try
            {
                string sCommand = ILLine.Command;

                if (m_DicInstructionList.Keys.Contains(sCommand))
                    sUDLCommand = m_DicInstructionList[sCommand].Instruction;
                else if (m_DicRepeatedInstructionList != null && m_DicRepeatedInstructionList.Keys.Contains(sCommand))
                    sUDLCommand = FindInstruction(ILLine);
                else if (!sCommand.Contains("MPS") && !sCommand.Contains("MRD") && !sCommand.Contains("MPP")
                    && !sCommand.Contains("ORB") && !sCommand.Contains("ANB"))
                {
                    Console.WriteLine("Not Support [{0}] Command!", sCommand);
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

        private string FindInstruction(CMelsecILLine ILLine)
        {
            string sUDLCommand = string.Empty;

            try
            {
                switch (ILLine.Command) //m_DicRepeatedInstructionList마다 Function 추가
                {
                    case "OUT": sUDLCommand = FindOutInstruction(ILLine.ListAddress); break;
                    case "OUTH": sUDLCommand = FindOutHInstruction(ILLine.ListAddress); break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sUDLCommand;
        }

        private string FindOutInstruction(List<string> ListAddress)
        {
            string sUDLCommand = string.Empty;

            try
            {
                List<string> lstUsedAddress = new List<string>();

                foreach (string sAddress in ListAddress)
                {
                    if (sAddress != string.Empty)
                        lstUsedAddress.Add(sAddress);
                }

                if (lstUsedAddress.Count == 1)
                    sUDLCommand = "OUT";
                else
                {
                    if (lstUsedAddress[0].StartsWith("T"))
                        sUDLCommand = "TON";
                    else if (lstUsedAddress[0].StartsWith("ST"))
                        sUDLCommand = "RTO";
                    else if (lstUsedAddress[0].StartsWith("C"))
                        sUDLCommand = "CTU";
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sUDLCommand;
        }

        private string FindOutHInstruction(List<string> ListAddress)
        {
            string sUDLCommand = string.Empty;

            try
            {
                List<string> lstUsedAddress = new List<string>();

                foreach (string sAddress in ListAddress)
                {
                    if (sAddress != string.Empty)
                        lstUsedAddress.Add(sAddress);
                }

                if (lstUsedAddress[0].StartsWith("T"))
                    sUDLCommand = "TONH";
                else if (lstUsedAddress[0].StartsWith("ST"))
                    sUDLCommand = "RTOH";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sUDLCommand;
        }

        private void MergeCoilBehindANDCommand()
        {
            CMelsecILBlock ILBlockDebug = null;
            CMelsecILPiece ILPieceDebug = null;

            try
            {
                foreach (CMelsecILBlock ILBlock in m_Rungcur.BLOCKS)
                {
                    ILBlockDebug = ILBlock;

                    if (ILBlock.lstJoinOperator.Contains("ANB"))
                    {

                        if (m_Rungcur.BLOCKS.Last() != ILBlock && ILBlock.BufferPiece.Count == 1 &&
                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First().Command.Contains("MPS") 
                            && m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First() != m_lstMergeCoilPiece[0]) //MPS
                        {
                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First().UDL += "[";

                            CMelsecILPiece ILMPSPiece =
                                m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First();
                            int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                            CMelsecILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
                            MergeCoilsInMPPPiece(ILMPPPiece, MPPIndex, m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1);
                        }
                    }

                    foreach (CMelsecILPiece ILPiece in ILBlock.MergePiece)
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
                                        "ANI"))
                                {
                                    int ANDIndex = ReturnANDIndex(ILBlock.MergePiece,
                                        ILBlock.MergePiece.IndexOf(ILPiece) + 1);
                                    if (!CheckCoilCountBehindAND(ILBlock.MergePiece, ANDIndex) &&
                                        m_Rungcur.BLOCKS.Last() != ILBlock
                                        &&
                                        m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First()
                                            .Command.Contains("MPS")) //MPS
                                    {
                                        ILBlock.MergePiece[ANDIndex].UDL += "[";

                                        CMelsecILPiece ILMPSPiece =
                                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First();
                                        int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                                        CMelsecILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
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
                        else if (ILPiece.Command.Contains("MPS") || ILPiece.Command.Contains("MRD") ||
                                 ILPiece.Command.Contains("MPP"))
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
                                            .Command.Contains("MPS")) //MPS
                                    {
                                        ILBlock.MergePiece[ANDIndex].UDL += "[";

                                        CMelsecILPiece ILMPSPiece =
                                            m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) + 1].MergePiece.First
                                                ();
                                        int MPPIndex = ReturnMPPIndex(m_lstMergeCoilPiece.IndexOf(ILMPSPiece));

                                        CMelsecILPiece ILMPPPiece = m_lstMergeCoilPiece[MPPIndex];
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

        private void MergeCoilsInMPPPiece(CMelsecILPiece ILMPPPiece, int CurMPPIndex, int BlockIndex)
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
                            MPPIndex = ReturnMPPIndex(MPSIndex); //IndexOf(m_Rungcur.BLOCKS[i+1].MergePiece.First()));
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

        private bool CheckMPSPiece(int CurMPPIndex)
        {
            bool bOK = false;

            for (int i = CurMPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPS"))
                {
                    bOK = true;
                    break;
                }
            }
            return bOK;
        }

        private int ReturnMPSIndex(int CurMPPIndex)
        {
            int MPSIndex = -1;

            for (int i = CurMPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPS"))
                {
                    MPSIndex = i;
                    break;
                }
            }
            return MPSIndex;
        }

        private void SetUDLRelatedMPPPiece(int MPPIndex)
        {
            int iMemoryBlock = 0;

            for (int i = MPPIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPS"))
                    iMemoryBlock++;
                else if (m_lstMergeCoilPiece[i].Command.Contains("MPP"))
                    iMemoryBlock--;

                if(iMemoryBlock == 0 && (i == m_lstMergeCoilPiece.Count - 1))
                    m_lstMergeCoilPiece[i].UDL += "]";
                else if (iMemoryBlock == 0 && m_lstMergeCoilPiece[i+1].ILType != EMILType.COIL )
                {
                    m_lstMergeCoilPiece[i].UDL += "]";
                    break;
                }
                else if(iMemoryBlock != 0)
                    Console.WriteLine("Return Out Index Error - MPS 존재함");
            }
        }

        private int ReturnMPPIndex(int MPSIndex)
        {
            int iMemoryBlock = 1;
            int MPPIndex = 0;

            for (int i = MPSIndex + 1; i < m_lstMergeCoilPiece.Count; i++)
            {
                if (m_lstMergeCoilPiece[i].Command.Contains("MPS"))
                    iMemoryBlock++;
                else if (m_lstMergeCoilPiece[i].Command.Contains("MPP"))
                    iMemoryBlock--;

                if (iMemoryBlock == 0)
                {
                    MPPIndex = i;
                    break;
                }
            }

            return MPPIndex;            
        }

        private int ReturnANDIndex(List<CMelsecILPiece> lstILPiece, int CurrentANDindex)
        {
            int ANDIndex = CurrentANDindex;

            for (int i = CurrentANDindex + 1; i < lstILPiece.Count; i++)
            {
                if (lstILPiece[i].ILLine.Command.Contains("AND") || lstILPiece[i].ILLine.Command.Contains("ANI"))
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
                foreach (CMelsecILPiece ILPiece in m_lstMergeCoilPiece)
                {
                    if (m_lstMergeCoilPiece.First() == ILPiece)
                    {
                        ILPiece.UDL = ILPiece.UDL.Insert(0, "[");
                        if (!ILPiece.Command.Contains("MPS"))
                            ILPiece.UDL += ",";
                    }
                    else if (m_lstMergeCoilPiece.Last() == ILPiece)
                        ILPiece.UDL += "]";
                    else if ((!ILPiece.Command.Contains("MPS")) && (!ILPiece.Command.Contains("MPP")) && (!ILPiece.Command.Contains("MRD")))
                        ILPiece.UDL += ",";
                }
            }
        }

        private void AddBlock(CMelsecILPiece ILPiece)
        {
            string sCommand = ILPiece.ILLine.Command;
            string sStep = ILPiece.ILLine.Step;
            string sKey = string.Format("{0}_{1}", sCommand, sStep);

            if (sCommand.Contains("LD"))
                sKey = string.Format("{0}_{1}", "LD", sStep);

            if (sCommand.Contains("LD") || sCommand.Contains("ANB") || sCommand.Contains("ORB") || sCommand.Contains("MPS")
                || sCommand.Contains("MRD") || sCommand.Contains("MPP"))
            {
                CMelsecILBlock cMelsecILBlock = new CMelsecILBlock();
                m_Rungcur.BLOCKS.Add(cMelsecILBlock);
            }

            if (m_Rungcur.BLOCKS.Count != 0)
            {
                m_Rungcur.BLOCKS.Last().BufferPiece.Add(sKey, ILPiece);
                m_Rungcur.BLOCKS.Last().MergePiece.Add(ILPiece);

                if ((sCommand.Contains("OR") && ILPiece.ILType != EMILType.COIL) || sCommand.Contains("ANB") || sCommand.Contains("MPS")
                    || sCommand.Contains("MRD") || sCommand.Contains("MPP"))
                    m_Rungcur.BLOCKS.Last().lstJoinOperator.Add(sCommand);
            }
            else
                m_Rungcur.Logic.Add(ILPiece);
        }

        private void MergeBlock()
        {
            foreach (CMelsecILBlock ILBlock in m_Rungcur.BLOCKS)
            {
                bool bCheckORBNextOR = false; //ORB IL 바로 뒤에 나오는 OR IL 일 경우 TRUE
                bool bCheckORIncludedORB = false;
                bool bCheckORIncludedANB = false;

                foreach (string sJoinOperator in ILBlock.lstJoinOperator)
                {
                    if (sJoinOperator.Contains("ANB"))
                    {
                        MergeANB(ILBlock);

                        if (ILBlock.lstJoinOperator.Count > 1)
                            bCheckORIncludedANB = true;

                    }
                    else if (sJoinOperator.Contains("ORB"))
                    {
                        if (ILBlock.lstJoinOperator.Count > 1)
                        {
                            if ((ILBlock.lstJoinOperator.Last() != sJoinOperator) && (ILBlock.MergePiece[ILBlock.lstJoinOperator.IndexOf(sJoinOperator) + 1].ILLine.Command.Contains("OR")))
                                bCheckORBNextOR = true;
                        }

                        MergeORB(ILBlock, bCheckORBNextOR);
                    }
                    else if (sJoinOperator.Contains("OR"))
                    {
                        if (ILBlock.lstJoinOperator.Count > 1 && ILBlock.lstJoinOperator.Contains("ORB"))
                            bCheckORIncludedORB = true;

                        MergeOR(ILBlock, bCheckORIncludedORB, bCheckORBNextOR, bCheckORIncludedANB);
                        break;
                    }
                    else if (sJoinOperator.Contains("MPS") || sJoinOperator.Contains("MRD") || sJoinOperator.Contains("MPP"))
                        MergePoint(ILBlock);
                }
            }
        }

        private void MergeANB(CMelsecILBlock ILBlock)
        {
            int iBlockCount = 0;

            List<CMelsecILBlock> lstMergeBlock = new List<CMelsecILBlock>();
            CMelsecILBlock cFirstBlock = null;
            CMelsecILBlock cSecondBlock = null;

            for (int i = (m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1) ; i >= 0 ; i--)
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

        private void MergeORB(CMelsecILBlock ILBlock, bool bCheckORBNextOR)
        {
            int iBlockCount = 0;
            bool bNewORBCheck = true;

            List<CMelsecILBlock> lstMergeBlock = new List<CMelsecILBlock>();
            CMelsecILBlock cFirstBlock = null;
            CMelsecILBlock cSecondBlock = null;

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

            if (cSecondBlock.lstJoinOperator.Contains("ORB"))
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
                cSecondBlock.MergePiece.Last().UDL = cSecondBlock.MergePiece.Last().UDL.Substring(0, cSecondBlock.MergePiece.Last().UDL.Length - 1);

            cSecondBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(cSecondBlock.MergePiece);
            cSecondBlock.MergePiece.Clear();

            ILBlock.MergePiece.Reverse();
        }

        private void MergeOR(CMelsecILBlock ILBlock, bool bCheckORIncludedORB, bool bCheckORBNextOR, bool bCheckORIncludedANB)
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
                if(!bCheckORBNextOR)
                    ILBlock.MergePiece.First().UDL = string.Format("[{0}", ILBlock.MergePiece.First().UDL);
            }

            for (int i = 0; i < ILBlock.BufferPiece.Count; i++)
            {

                if (ILBlock.BufferPiece.ElementAt(i).Key.Contains("OR") && !ILBlock.BufferPiece.ElementAt(i).Key.Contains("ORB") && (ILBlock.BufferPiece.ElementAt(i).Value.ILType != EMILType.COIL))
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
                        if(!ILBlock.MergePiece.Last().UDL.Contains("]"))
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

        private void MergePoint(CMelsecILBlock ILBlock)
        {
            ILBlock.MergePiece.Reverse();

            CMelsecILBlock ILLastBlock = m_Rungcur.BLOCKS[m_Rungcur.BLOCKS.IndexOf(ILBlock) - 1];

            ILLastBlock.MergePiece.Reverse();
            ILBlock.MergePiece.AddRange(ILLastBlock.MergePiece);
            ILLastBlock.MergePiece.Clear();

            ILBlock.MergePiece.Reverse();
        }
        
        private bool CheckAvalableStep(List<CMelsecILLine> lstline)
        {
            if (lstline.Count == 1)
            {
                if (CMelsecILType.IsSkipIL(lstline[0].Command))
                    return false;
            }

            return true;
        }

        private bool CheckCoilCountBehindAND(List<CMelsecILPiece> lstILPiece, int index)
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

        private Dictionary<string, List<CMelsecILLine>> GetRung(List<CMelsecILLine> lstILLine)
        {
            CMelsecILLine ILLineDebug = null;

            try
            {
                Dictionary<string, List<CMelsecILLine>> DicILLine = new Dictionary<string, List<CMelsecILLine>>();
                List<CMelsecILLine> lstILLineFinded = new List<CMelsecILLine>();

                int nMemoryBlock = 0;
                bool bNextLoad = false;
                bool bLastILLine = false;

                foreach (CMelsecILLine cILLine in lstILLine)
                {
                    ILLineDebug = cILLine;

                    if (cILLine.Command == "LABEL")
                    {
                        
                    }

                    if (cILLine.Command == "NOP" || cILLine.Command == "NOPLF")
                        continue;

                    if (cILLine.Command.StartsWith("P"))
                        bLastILLine = false;

                    if (lstILLine.Last() != cILLine)
                    {
                        CMelsecILLine cILLineNext = lstILLine[lstILLine.IndexOf(cILLine) + 1];
                        if (CMelsecILType.IsLoad(cILLineNext.Command) || CMelsecILType.IsCommandOnlyIL(cILLineNext.Command) || CMelsecILType.IsOneCommandIL(cILLineNext.Command))
                            bNextLoad = true;
                        else
                            bNextLoad = false;

                        bLastILLine = false;
                    }
                    else
                        bLastILLine = true;

                    if ("MPS" == cILLine.Command)
                        nMemoryBlock++;
                    else if ("MPP" == cILLine.Command)
                        nMemoryBlock--;

                    if (!cILLine.IsNote)
                        lstILLineFinded.Add(cILLine);

                    if ((bLastILLine || CMelsecILType.IsCommandOnlyIL(cILLine.Command) || CMelsecILType.IsSkipIL(cILLine.Command) || CMelsecILType.IsOneCommandIL(cILLine.Command))
                        || (IsCoilCommand(cILLine.Command) && nMemoryBlock == 0 && bNextLoad))
                    {
                        if (lstILLineFinded.Count != 0)
                        {
                            if (IsPairringLoad(lstILLineFinded))
                            {
                                DicILLine.Add(cILLine.Program + ";" + cILLine.Step, lstILLineFinded);
                                lstILLineFinded = new List<CMelsecILLine>();
                            }
                            else
                            {
                                foreach (CMelsecILLine ILLinePairring in lstILLineFinded)
                                {
                                    DicILLine.Last().Value.Add(ILLinePairring);
                                }
                                lstILLineFinded = new List<CMelsecILLine>();
                            }
                        }
                    }
                }
                return DicILLine;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Covert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll); error.Data.Clear();
                return null;
            }
        }

        private bool IsCoilCommand(string strOperator) //Change
        {
            if (!CMelsecILType.IsConnenctionIL(strOperator)
             && !CMelsecILType.IsConnenctionOperationIL(strOperator)
             && !CMelsecILType.IsContactIL(strOperator)
             && !CMelsecILType.IsSkipIL(strOperator)
            )
                return true;
            else
                return false;
        }

        private bool IsPairringLoad(List<CMelsecILLine> ListILLine)
        {
            try
            {
                int nLoadIndex = 0;
                int nANBORBIndex = 0;

                foreach (CMelsecILLine ILLine in ListILLine)
                {
                    if (ListILLine[0] == ILLine)
                        continue;

                    if (CMelsecILType.IsLoad(ILLine.Command))
                        nLoadIndex++;
                    else if (ILLine.Command == "ANB" || ILLine.Command == "ORB")
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
