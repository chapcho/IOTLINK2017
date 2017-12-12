using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using UDM.General;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILConvert
    {
        private List<CILStep> m_ListConvertCoil = new List<CILStep>();
        private List<CILStep> m_ListCoilBuffer = new List<CILStep>();
        private CILStep m_StepCur = new CILStep();
        private CILSymbolS m_cILSymbolS = new CILSymbolS();

        private int m_iLoad = 0;
        private int m_iBlock = 0;

        private Dictionary<string, string> m_DicRoutineMC = new Dictionary<string, string>();
        private List<string> m_ListRoutineFor = new List<string>();
        private List<string> m_ListRoutineCall = new List<string>();
        private List<string> m_lstBlockOperator = new List<string>();

        #region Initialize/Dispose

        public CILConvert()
        {

        }

        public void Dispose()
        {
            m_ListConvertCoil.Clear();
        }

        #endregion

        #region Public interface

        public List<CILStep> LIST_COIL
        {
            get { return m_ListConvertCoil; }
        }

        public CILSymbolS SymbolS
        {
            get { return m_cILSymbolS; }
            set { m_cILSymbolS = value; }
        }


        #endregion

        #region public Methods

        public void CleanforSave()
        {
            m_cILSymbolS = new CILSymbolS();

            foreach (CILStep cILStep in m_ListConvertCoil)
            {
                foreach (CILBlock cILBlock in cILStep.BLOCKS)
                    cILBlock.CleanBuffer();

                cILStep.CleanBuffer();
                cILStep.RelationContactS.Clear();
            }
        }

        //************************************************************************//
        // IL CONVERT 메인 함수 **********************************************//
        //************************************************************************//
        public void ConvertIL(Dictionary<string, List<CILLine>> DicILLineProgram, BackgroundWorker backgroundWorker)
        {
            string sDebugLine = string.Empty;
            try
            {
                m_ListConvertCoil.Clear();     // 결과 Coil List 초기화
                m_ListCoilBuffer = new List<CILStep>();
                m_DicRoutineMC = new Dictionary<string, string>();
                m_ListRoutineFor = new List<string>();
                m_ListRoutineCall = new List<string>();
                Dictionary<string, List<CILLine>> DicILILine = new Dictionary<string, List<CILLine>>();

                int nCountItem = 0;
                foreach (var whoProgram in DicILLineProgram)
                {
                    if(backgroundWorker != null)
                        backgroundWorker.ReportProgress(nCountItem++ * 100 / DicILLineProgram.Count, "Import");

                    DicILILine = GetLadderLine(whoProgram.Value);  //1.0
                    if (DicILILine == null)
                        continue;

                    ResetRoutine();

                    foreach (var who in DicILILine)
                    {
                        sDebugLine = who.Key;
                        List<CILLine> lstILLine = who.Value;

                        if(!CheckAvalableStep(lstILLine))
                            continue;

                        m_StepCur = new CILStep();
                        m_StepCur.InitializeBuffer();
                        m_StepCur.BLOCKS = new List<CILBlock>();
                        m_lstBlockOperator = new List<string>();

                        m_iLoad = 0;
                        m_iBlock = 1;

                        CreateListLoad(lstILLine);  //2.1

                        MakeCoil(lstILLine);    //2.0
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error Program & Line : " + sDebugLine);
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        #endregion

        #region Privates Methods

        //************************************************************************//
        // 1.0 독립 구성 가능한 Ladder Line 구역 찾기 ****************************//
        //************************************************************************//
        private Dictionary<string, List<CILLine>> GetLadderLine(List<CILLine> ListILLine)
        {
            CILLine ILLineDebug = null;
            try
            {
                Dictionary<string, List<CILLine>> DicILILine = new Dictionary<string, List<CILLine>>();
                List<CILLine> ListILLineFinded = new List<CILLine>();
                int nMemoryBlock = 0;
                bool bNextLoad = false;
                bool bLastILIine = false;
                foreach (CILLine ILLine in ListILLine)
                {
                    ILLineDebug = ILLine;

                    if (ILLine.Command == "NOP" || ILLine.Command == "NOPLF")
                        continue;

                    if (ILLine.Command.StartsWith("P"))
                        bLastILIine = false;

                    if (ListILLine.Last() != ILLine)
                    {
                        CILLine ILLineNext = ListILLine[ListILLine.IndexOf(ILLine) + 1];
                        if (ILLineNext.Command.Contains("LD") || CILType.IsCommandOnlyIL(ILLineNext.Command) || CILType.IsSkipIL(ILLineNext.Command))
                            bNextLoad = true;
                        else
                            bNextLoad = false;

                        bLastILIine = false;
                    }
                    else
                        bLastILIine = true;

                    if ("MPS" == ILLine.Command)
                        nMemoryBlock++;
                    else if ("MPP" == ILLine.Command)
                        nMemoryBlock--;

                    if (!ILLine.IsNote)
                        ListILLineFinded.Add(ILLine);

                    if ((bLastILIine || CILType.IsSkipIL(ILLine.Command) || CILType.IsCommandOnlyIL(ILLine.Command))
                    || (IsCoilCommand(ILLine.Command) && nMemoryBlock == 0 && bNextLoad))
                    {
                        if (ListILLineFinded.Count != 0)
                        {
                            if (IsPairringLoad(ListILLineFinded))
                            {
                                DicILILine.Add(ILLine.Program + ";" + ILLine.Step, ListILLineFinded);
                                ListILLineFinded = new List<CILLine>();
                            }
                            else
                            {
                                foreach (CILLine ILLinePairring in ListILLineFinded)
                                {
                                    DicILILine.Last().Value.Add(ILLinePairring);
                                }
                                ListILLineFinded = new List<CILLine>();
                            }

                        }
                    }
                }

                return DicILILine;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Covert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll); error.Data.Clear();
                return null;
            }
        }

        //************************************************************************//
        // 2.0 Coil(출력) 단위로 Ladder 정보 만들기  *****************************//
        //************************************************************************//
        private void MakeCoil(List<CILLine> ListILLine)
        {
            CILLine ILLineDebug = null;

            try
            {
                
                CCell cell = new CCell(0, 0);
                int iContactNum = 0;

                foreach (CILLine ILLine in ListILLine)
                {
                    ILLineDebug = ILLine;
                    CILContact LP = new CILContact(ILLine);

                    LP.ContactNum = iContactNum++;

                    bool bCoil = false;
                    if (CILType.IsConnenctionIL(LP.Command))
                    {
                        if (LP.Command == "ANB" || LP.Command == "ORB")
                            cell = ConvertAnbOrb(LP, cell);  //2.4
                        else
                            cell = ConvertMemory(LP, cell);  //2.5
                        continue;
                    }

                    if (ILLine == ListILLine[0] && ListILLine.Count > 1)
                        cell = ConvertLoadFirst(LP, cell);  //2.2

                    else if (LP.IsLaod)
                        cell = ConvertLoad(LP, cell);  //2.3

                    else if (LP.eILType == EILType.CONNECT)
                        cell = ConvertAndOr(LP, cell);  //2.6

                    else if (LP.eILType == EILType.CONNECT_OPERATION)
                        cell = ConvertConnetionOperation(LP, cell);  //2.7

                    else if (LP.eILType == EILType.ROUTINE)
                        bCoil = ConvertRoutine(LP, cell);  //2.7

                    else if (LP.eILType == EILType.COIL && !CILType.IsSkipIL(LP.Command))
                        bCoil = ConvertCoil(LP, cell);  //2.9

                    if (!bCoil)
                        AddContact(LP);

                    LP.MergeDepth = m_StepCur.MergeDepth;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Covert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll); error.Data.Clear();
            }
        }

        // 2.1 Load 다음 ANB 또는 ORB를 찾는다 없으면 일단 비워두고 순서상 남는 ANB 또는 ORB를 삽입 *****************************//
        private void CreateListLoad(List<CILLine> ListILLine)
        {
            CILLine ILLineDebug = null;
            try
            {
                List<string> ListLoadStepNum = new List<string>();
                CILBlock cILBlock = new CILBlock();
                int nLoadCount = 0;
                foreach (CILLine ILLine in ListILLine)
                {
                    ILLineDebug = ILLine;

                    if (ILLine.Command.Contains("LD"))
                    {
                        m_lstBlockOperator.Add(ILLine.Step);
                        m_StepCur.lstLoadOperator.Add("LOAD" + nLoadCount.ToString());
                        nLoadCount++;

                        ListLoadStepNum.Add(ILLine.Step);
                        if (ILLine == ListILLine[0])
                        {
                            cILBlock = new CILBlock();
                            m_StepCur.BLOCKS.Add(cILBlock);
                            m_StepCur.AddBlockCell(new CCell(0, 0));
                            m_StepCur.BLOCKS.Last().StepNumLoad = ILLine.Step;
                        }
                    }
//                     else if (ILLine.Command == "MPS" || ILLine.Command == "MRD" || ILLine.Command == "MPP")
//                         m_lstBlockOperator.Add(ILLine.Command);
                    else if (ILLine.Command == "ANB" || ILLine.Command == "ORB")
                    {
                        cILBlock = new CILBlock();
                        m_StepCur.BLOCKS.Add(cILBlock);
                        m_StepCur.AddBlockCell(new CCell(0, 0));

                        m_StepCur.lstLoadOperator.Add(ILLine.Step);

                        if (ILLine.Command == "ANB")
                            m_lstBlockOperator.Add(EMOperaterType.And.ToString());
                        else if (ILLine.Command == "ORB")
                            m_lstBlockOperator.Add(EMOperaterType.Or.ToString());

                        m_StepCur.BLOCKS.Last().StepNumBlock = ILLine.Step;
                        m_StepCur.BLOCKS.Last().StepNumLoad = ListLoadStepNum[m_StepCur.BLOCKS.Count - 1];
                    }

                    if (CILType.IsOutputIL(ILLine.Command))
                        m_StepCur.BLOCKS.Last().IsLast = true;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", "Can't Covert IL Line", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLineDebug.ItemAll); error.Data.Clear();
            }
        }

        // 2.1.1 FindEmptyIndex *****************************//
        private int FindEmptyIndex(int nStart, List<string> ListLoad)
        {
            for (int nLoadIndex = nStart; nLoadIndex >= 0; nLoadIndex--)
            {
                if (ListLoad[nLoadIndex] == "EMPTY")
                    return nLoadIndex;
            }

            return 0;
        }

        // 2.2 첫 Load 명령에 대한 처리 *****************************//
        private CCell ConvertLoadFirst(CILContact LP, CCell cell)
        {
            try
            {
                // 포인팅 **//
                LP.CELL = new CCell(cell.COL, cell.ROW);

                // 후처리 **//
                cell.COL++;


                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.3  Load 명령에 대한 처리 *****************************//
        private CCell ConvertLoad(CILContact LP, CCell cell)
        {
            try
            {
              //  m_StepCur.MergeDepth = 0;

                foreach (CILBlock cILBlock in m_StepCur.BLOCKS)
                {
                    if (LP.ILLine.Step == cILBlock.StepNumLoad)
                    {
                        m_iLoad = m_StepCur.BLOCKS.IndexOf(cILBlock);
                        break;
                    }
                }
           

                if (m_StepCur.GetBlockOperator(m_lstBlockOperator, LP.ILLine.Step) == EMOperaterType.And)
                {
                    m_StepCur.GetBlockCell(m_iBlock).ROW = cell.ROW;
                    m_StepCur.GetBlockCell(m_iBlock).COL = cell.COL;
                }
                else// EMOperaterType.Or
                {
                    cell.ROW = GetBlockLastRow(cell) + 1;
                    cell.COL = m_StepCur.GetBlockCell(m_iBlock - 1).COL;

                    m_StepCur.GetBlockCell(m_iBlock).ROW = cell.ROW;
                    m_StepCur.GetBlockCell(m_iBlock).COL = cell.COL;
                }

                m_iBlock++;

                LP.CELL = new CCell(cell.COL, cell.ROW);

                cell.COL++;

                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.4  ANB 또는 ORB 명령에 대한 처리 *****************************//
        private CCell ConvertAnbOrb(CILContact LP_BLOCK, CCell cell)
        {
            try
            {
                m_iBlock--;
                m_StepCur.MergeDepth++;

                if (LP_BLOCK.Command == "ANB")
                {
                    m_StepCur.UpdateBlockLogic(LP_BLOCK.ILLine.Step, true);
                    // MakeBufferLogic(true);
                }
                else if (LP_BLOCK.Command == "ORB")
                {
                    // FillEmptySpace OR Line
                    LP_BLOCK.CELL = new CCell(cell.COL, cell.ROW);
                    int nSpaceStart = cell.COL;
                    int nSpaceEnd = GetBlockLastColunm(cell) + 1;
                    FillEmptySpace(nSpaceStart, nSpaceEnd, LP_BLOCK);

                    // Next Cell Pointing
                    cell.COL = GetBlockLastColunm(cell) + 1;
                    cell.ROW = m_StepCur.GetBlockCell(m_iBlock - 1).ROW;

                    m_StepCur.UpdateBlockLogic(LP_BLOCK.ILLine.Step, false);
                    //MakeBufferLogic(false);

                    // FillEmptySpace AND Line
                    LP_BLOCK.CELL = new CCell(cell.COL, cell.ROW);
                    int nBlockLastColunm = GetBlockLastColunm(cell);
                    FillEmptySpace(nBlockLastColunm + 1, LP_BLOCK.CELL.COL, LP_BLOCK);
                }

                m_StepCur.BlockConveted = m_StepCur.IsLastBlockMerge(LP_BLOCK.ILLine.Step);

                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        
        // 2.5  MPS 또는 MRD 또는 MPP 명령에 대한 처리 *****************************//
        private CCell ConvertMemory(CILContact LP, CCell cell)
        {
            try
            {
                if (LP.Command == "MPS")
                {
                    m_StepCur.IndexLoad = m_iLoad;
                    CILStep cILStep = (CILStep)m_StepCur.Clone();
                    m_ListCoilBuffer.Add(cILStep);
                }

                if (LP.Command == "MRD" || LP.Command == "MPP")
                {
                    m_StepCur = (CILStep)m_ListCoilBuffer.Last().Clone();
                    m_iLoad = m_StepCur.IndexLoad;

                    cell.COL = m_StepCur.GetLastColunm() + 1;
                    cell.ROW = m_StepCur.GetFirstRow();
                }

                if (LP.Command == "MPP")
                    m_ListCoilBuffer.RemoveAt(m_ListCoilBuffer.Count - 1);

                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.6  AND 또는 OR 명령에 대한 처리 *****************************//
        private CCell ConvertAndOr(CILContact LP, CCell cell)
        {
            try
            {
                if (LP.eILOperator == EMOperaterType.And)
                {
                    int nBlockLastColunm = GetBlockLastColunm(cell);
                    FillEmptySpace(nBlockLastColunm + 1, cell.COL, LP);

                    LP.CELL = new CCell(cell.COL, cell.ROW);
                    cell.COL++;

                }
                else if (LP.eILOperator == EMOperaterType.Or)
                {
                    cell.ROW = GetBlockLastRow(cell) + 1;
                    cell.COL = m_StepCur.GetBlockCell(m_iBlock - 1).COL;

                    LP.CELL = new CCell(cell.COL, cell.ROW);

                    cell.COL = GetBlockLastColunm(cell) + 1;
                    cell.ROW = m_StepCur.GetBlockCell(m_iBlock - 1).ROW;

                    FillEmptySpace(LP.CELL_COL + 1, cell.COL, LP);
                }


                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.7  INV, MEP, MEF, EGP, EGF *****************************//
        private CCell ConvertConnetionOperation(CILContact LP, CCell cell)
        {
            try
            {
                if (LP.Command == "INV" || LP.Command == "MEP" || LP.Command == "MEF")
                {
                    LP.CELL = new CCell(cell.COL, cell.ROW);
                    cell.COL++;
                }
                else if (LP.Command == "EGP" || LP.Command == "EGF")
                {
                    LP.CELL = new CCell(cell.COL, cell.ROW);
                    cell.COL++;
                }

                return cell;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.8 Routine 명령에 대한 처리 *****************************//
        private bool ConvertRoutine(CILContact LP, CCell cell)
        {
            try
            {
                if (LP.Command == "MC")
                {
                    m_DicRoutineMC.Add(LP.Routine, LP.Address);
                    ConvertCoil(LP, cell);
                }
                else if (LP.Command == "MCR")
                    m_DicRoutineMC.Remove(LP.Routine);
                else if (LP.Command == "FOR")
                    m_ListRoutineFor.Add(LP.Routine);
                else if (LP.Command == "NEXT")
                {
                    if (m_ListRoutineFor.Count > 0)
                        m_ListRoutineFor.Remove(m_ListRoutineFor.Last());
                }
                else if (LP.Command == EMCoilImport.ProgramLabel.ToString())
                    m_ListRoutineCall.Add(LP.Routine);
                else if (LP.Command == "RET")
                {
                    if (m_ListRoutineCall.Count > 0)
                        m_ListRoutineCall.Remove(m_ListRoutineCall.Last());
                }


                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        // 2.9 Coil 명령에 대한 처리 *****************************//
        private bool ConvertCoil(CILContact LP, CCell cell)
        {
            try
            {
                if (!m_StepCur.LogicGroup.ValidationLogic())
                    Console.WriteLine("Warning : {0} [{1}] - {2}", "Convert Logic Fail", System.Reflection.MethodBase.GetCurrentMethod().Name, LP.ILLine.ItemAll);

                m_StepCur.ApplyBufferLogic();

                ConvertStep(LP);

                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        private void ResetRoutine()
        {
            try
            {
                m_DicRoutineMC.Clear();
                m_ListRoutineFor.Clear();
                m_ListRoutineCall.Clear();

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

      

        private bool IsCoilCommand(string strOperator)
        {
            if (!CILType.IsConnenctionIL(strOperator)
             && !CILType.IsConnenctionOperationIL(strOperator)
             && !CILType.IsContactIL(strOperator)
            )
                return true;
            else
                return false;
        }

        private int GetBlockLastColunm(CCell cell)
        {
            try
            {
                int nCurrentRow = cell.ROW;
                int nStartRow = m_StepCur.GetBlockCell(m_iBlock - 1).ROW;

                return m_StepCur.GetLastColunm(nStartRow, nCurrentRow);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        private int GetBlockLastRow(CCell cell)
        {
            try
            {
                int nCurrentCol = cell.COL;
                int nStartCol = m_StepCur.GetBlockCell(m_iBlock - 1).COL;

                return m_StepCur.GetLastRow(nStartCol, nCurrentCol);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        private void FillEmptySpace(int nStart, int nEnd, CILContact LP)
        {
            for (int n = nStart; n < nEnd; n++)
            {
                CILContact LP_LINE = new CILContact(LP.ILLine);
                LP_LINE.CELL = new CCell(LP.CELL_COL, LP.CELL_ROW);
                LP_LINE.eILType = EILType.LINE;
                LP_LINE.CELL_COL = n;
                AddContact(LP_LINE);
            }
        }

        private bool IsPairringLoad(List<CILLine> ListILLine)
        {
            try
            {
                int nLoadIndex = 0;
                int nANBORBIndex = 0;

                foreach (CILLine ILLine in ListILLine)
                {
                    if (ListILLine[0] == ILLine)
                        continue;

                    if (CILType.IsILLoad(ILLine.Command))
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

        private bool CheckAvalableStep(List<CILLine> lstline)
        {
            if (lstline.Count == 1)
            {
                if (CILType.IsSkipIL(lstline[0].Command))
                    return false;
            }

            return true;
        }

        private void AddContact(CILContact cILContact)
        {
            if (m_StepCur.BLOCKS[m_iLoad].Updated)
                m_StepCur.BLOCKS[m_iLoad].ILBufferUnit.Add(cILContact);
            else
                m_StepCur.BLOCKS[m_iLoad].ILBufferBlock.Add(cILContact);

        }

        private bool ConvertStep(CILContact LP)
        {
            try
            {
                bool nResult = true;

                if (m_DicRoutineMC.Count > 0)
                {
                    m_StepCur.MasterControl = string.Empty;
                    foreach (var who in m_DicRoutineMC)
                    {
                        m_StepCur.MasterControl += who.Value + "*";
                    }
                }
                if (m_ListRoutineFor.Count > 0)
                {
                    m_StepCur.ForNextControl = string.Empty;
                    foreach (string strForNext in m_ListRoutineFor)
                    {
                        m_StepCur.ForNextControl += strForNext + "*";
                    }
                }
                if (m_ListRoutineCall.Count > 0)
                {
                    m_StepCur.CallControl = string.Empty;
                    foreach (string strCallControl in m_ListRoutineCall)
                    {
                        m_StepCur.CallControl += strCallControl + "*";
                    }
                }


                if (LP.ILLine.ImportType == EMCoilImport.S0_D1_N0
                    || LP.ILLine.Command.Contains("OUT"))
                    m_StepCur.CoilType = EMCoilType.Bit;
                else
                    m_StepCur.CoilType = EMCoilType.Special;

                CILStep ILStep = (CILStep)m_StepCur.Clone();
                ILStep.ILLine = (CILLine)LP.ILLine.Clone();
                ILStep.Program = LP.ILLine.Program;
                ILStep.CoilSymbol = LP.Symbol;
                ILStep.CoilCommand = LP.Command;
                ILStep.CoilCommandFull = LP.CommandFull;

                if (ILStep.CoilType == EMCoilType.Bit)
                    ILStep.CoilAddress = LP.Address;

                m_ListConvertCoil.Add(ILStep);

                return nResult;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        #endregion
    }
}
