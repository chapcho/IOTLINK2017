using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using UDM.Common;
using UDM.UDL;

namespace UDM.UDLImport
{
    public class CLSILImport
    {
        public enum EMILImportColumn
        {
            LineNumber,
            Command,
            Operand,
        }

        private const int m_nOperandSub = 6;
        private List<CLSILLine> m_ListILLine = new List<CLSILLine>();
        private Dictionary<string, List<CLSILLine>> m_DicLSILLine = new Dictionary<string, List<CLSILLine>>();

        #region Initialize/Dispose

        public CLSILImport()
        {

        }

        public void Dispose()
        {
            m_ListILLine.Clear();
            m_DicLSILLine.Clear();
        }

        #endregion

        #region Properties

        public Dictionary<string, List<CLSILLine>> DicLSILLine
        {
            get { return m_DicLSILLine; }
        }

        #endregion

        #region Public Methods

        public void ImportIL(DataSet DS, bool bFBCheck, List<string> lstFBName)
        {
            string sTableName = string.Empty;

            try
            {
                string sStep = string.Empty;
                string sCommand = string.Empty;
                string sOperand = string.Empty;
                string[] arrOperandSub = new string[m_nOperandSub];
                string sProgram = string.Empty;
                string sBranchCommand = string.Empty;

                bool bUDFRUNGCheck = false;
                bool bXGISeries = false;
                bool bBrandch = false;
                bool bMergePointAdd = false;

                m_ListILLine.Clear();

                foreach(DataTable DT in DS.Tables)
                {                    
                    if (DT.Columns.Count > 3)
                        continue;

                    sProgram = DT.TableName;
                    sTableName = DT.TableName;

                    for(int nRow = 0 ; nRow < DT.Rows.Count ; nRow++)
                    {
                        bMergePointAdd = false;

                        arrOperandSub = new string[m_nOperandSub];
                        sStep = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.LineNumber].ToString();
                        sCommand = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.Command].ToString();
                        sOperand = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.Operand].ToString();

                        if (sCommand.Contains("XGRUNGSTART"))
                        {
                            bXGISeries = true;
                            continue;
                        }

                        //XGI Series
                        if (!bBrandch && sCommand.Contains("LOAD_BR"))
                        {
                            bBrandch = true;
                            continue;
                        }

                        if (bBrandch)
                        {
                            if (sCommand.Contains("MPUSH") || sCommand.Contains("MLOAD") || sCommand.Contains("MPOP"))
                            {
                                sBranchCommand = sCommand;
                                continue;
                            }
                            else
                            {
                                if (sCommand.Contains("AND"))
                                {
                                    sCommand = sCommand.Replace("AND", "LOAD");

                                    if (!sBranchCommand.Equals("MLOAD"))
                                        bMergePointAdd = true;
                                }
                                else
                                {
                                    if (sBranchCommand != string.Empty)
                                    {
                                        CLSILLine ILBranchLine = new CLSILLine(sProgram, nRow - 1, sBranchCommand,
                                            string.Empty);

                                        if (!m_DicLSILLine.ContainsKey(ILBranchLine.Program))
                                            m_DicLSILLine.Add(ILBranchLine.Program, new List<CLSILLine>());

                                        m_DicLSILLine.Last().Value.Add(ILBranchLine);
                                    }
                                }
                                bBrandch = false;
                            }
                        }

                        if (sCommand.Contains("CMT") || sCommand.Contains("REM"))
                            continue;

                        if (bFBCheck && sCommand.Contains("UDF_RUNG_BEGIN"))
                        {
                            bUDFRUNGCheck = true;
                            continue;
                        }
                        else if (bFBCheck && sCommand.Contains("UDF_RUNG_END"))
                        {
                            bUDFRUNGCheck = false;
                            continue;
                        }

                        if (sOperand != string.Empty && sOperand.Contains(' '))
                            GetSubOperand(ref sOperand, ref arrOperandSub);

                        CLSILLine ILLine = null;

                        string sCommandTemp = sCommand;

                        if (sCommand.Contains("."))
                            sCommandTemp = sCommandTemp.Split('.')[0];

                        if (bXGISeries)
                            ILLine = new CLSILLine(sProgram, nRow, sCommand, sOperand);
                        else if (bUDFRUNGCheck && lstFBName.Contains(sCommandTemp))                        
                            ILLine = new CLSILLine(sProgram, sStep, sCommand, sOperand);
                        else
                            ILLine = new CLSILLine(sProgram, sStep, sCommand, sOperand, arrOperandSub);

                        if (ILLine.ImportType == EMCoilImport.NONE)
                        {
                            Console.WriteLine("Warning : {0} [{1}] - {2}", "Not Support this Command", System.Reflection.MethodBase.GetCurrentMethod().Name, sTableName, ILLine.Command);
                        }

                        if (!m_DicLSILLine.ContainsKey(ILLine.Program))
                            m_DicLSILLine.Add(ILLine.Program, new List<CLSILLine>());

                        m_DicLSILLine.Last().Value.Add(ILLine);

                        if (bMergePointAdd)
                        {
                            CLSILLine ILMergePointLine = new CLSILLine(sProgram, nRow - 1, sBranchCommand, string.Empty);
                            m_DicLSILLine.Last().Value.Insert(m_DicLSILLine.Last().Value.IndexOf(ILLine), ILMergePointLine);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error ImportIL Table : " + sTableName);
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine(error.Message);
                error.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void GetSubOperand(ref string sOperand, ref string[] arrOperandSub)
        {
            try
            {
                string[] TempArray = sOperand.Split(' ');

                sOperand = TempArray[0];

                for (int i = 1; i < TempArray.Length; i++)
                    arrOperandSub[i - 1] = TempArray[i];
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

    }
}
