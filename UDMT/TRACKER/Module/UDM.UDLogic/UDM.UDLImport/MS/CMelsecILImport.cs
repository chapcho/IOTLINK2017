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
    public class CMelsecILImport
    {
        public enum EMILImportColumn
        {
            LineNumber,
            Note,
            Command,
            Operand,        
        }

        private const int m_nOperandSub = 6;
        private List<CMelsecILLine> m_ListILLine = new List<CMelsecILLine>();  // ILLine List 저장 구조
        private Dictionary<string, List<CMelsecILLine>> m_DiCMelsecILLine = new Dictionary<string, List<CMelsecILLine>>();  // ILLine List 저장 구조

        #region Initialize/Dispose

        public CMelsecILImport()
        {

        }

        public void Dispose()
        {
            m_ListILLine.Clear();
            m_DiCMelsecILLine.Clear();
        }

        #endregion


        #region Properties

        public Dictionary<string, List<CMelsecILLine>> DiCMelsecILLine
        {
            get { return m_DiCMelsecILLine; }
        }

        #endregion

        #region Public Methods

        public void ImportIL(DataSet DS)
        {
            string strTableName = string.Empty;
            try
            {
                string strStep = "0";
                string strNote = string.Empty;
                string strCommand = string.Empty;
                string strOperand = string.Empty;
                string[] arrOperandSub = new string[m_nOperandSub];
                string strProgram = string.Empty;

                m_ListILLine.Clear();

                foreach (DataTable DT in DS.Tables)
                {
                    if (DT.Columns.Count <= 3)  // IL Column 7
                        continue;

                    strProgram = DT.TableName;
                    strTableName = DT.TableName;

                    for (int nRow = 0; nRow < DT.Rows.Count; nRow++)
                    {
                        arrOperandSub = new string[m_nOperandSub];
                        strStep = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.LineNumber].ToString();
                        strNote = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.Note].ToString();
                        strOperand = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.Operand].ToString();
                        strCommand = DT.Rows[nRow].ItemArray[(int)EMILImportColumn.Command].ToString();

                        if (strCommand == "END")
                            break;
                        if (strStep == "Step No." || strOperand == string.Empty && strCommand == string.Empty)
                            continue;

                        nRow = nRow + GetSubOperand(DT, nRow, ref arrOperandSub);

                        CMelsecILLine ILLine = new CMelsecILLine(strProgram, strStep, strNote, strCommand, strOperand, arrOperandSub);

                        if (ILLine.ImportType == EMCoilImport.NONE)
                        {
                            Console.WriteLine("Warning : {0} [{1}] - {2}", "Not Support this Command", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLine.ItemAll);
                        }

                        if (!m_DiCMelsecILLine.ContainsKey(ILLine.Program))
                            m_DiCMelsecILLine.Add(ILLine.Program, new List<CMelsecILLine>());

                        m_DiCMelsecILLine.Last().Value.Add(ILLine);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error ImportIL Table : " + strTableName);
                throw new Exception("파일 내부 형식이 쉼표로 구분되어 있지 않습니다. - " + strTableName + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        #endregion

        
        #region Private Methods


        private int GetSubOperand(DataTable DT, int nRow, ref string[] arrOperandSub)
        {
            int nNext = 0;
            for (nNext = 0; nNext < m_nOperandSub; nNext++)
            {
                if (DT.Rows[nRow + nNext + 1].ItemArray[(int)EMILImportColumn.Command].ToString() == string.Empty)
                    arrOperandSub[nNext] = DT.Rows[nRow + nNext + 1].ItemArray[(int)EMILImportColumn.Operand].ToString();
                else
                    break;
            }

            return nNext;
        }


        #endregion

    }
}
