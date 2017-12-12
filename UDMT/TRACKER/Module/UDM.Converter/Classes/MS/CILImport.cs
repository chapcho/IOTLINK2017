using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using UDM.Common;


namespace UDM.Converter
{
    public enum EILImportColumn
    {
        LineNumber,
        Note,
        Command,
        Operand,
    }
  

    public class CILImport
    {
        private const int m_nOperandSub = 6;
        private List<CILLine> m_ListILLine = new List<CILLine>();  // ILLine List 저장 구조
        private Dictionary<string, List<CILLine>> m_DicILLine = new Dictionary<string, List<CILLine>>();  // ILLine List 저장 구조
        
        #region Initialize/Dispose

        public CILImport()
        {
            
        }

        public void Dispose()
        {
            m_ListILLine.Clear();
            m_DicILLine.Clear();
        }

        #endregion

        #region Public interface

        public Dictionary<string,List<CILLine>> DicILLINE
        {
            get { return m_DicILLine;}
        }

        #endregion

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
                        strStep = DT.Rows[nRow].ItemArray[(int)EILImportColumn.LineNumber].ToString();
                        strNote = DT.Rows[nRow].ItemArray[(int)EILImportColumn.Note].ToString();
                        strOperand = DT.Rows[nRow].ItemArray[(int)EILImportColumn.Operand].ToString();
                        strCommand = DT.Rows[nRow].ItemArray[(int)EILImportColumn.Command].ToString();

                        if (strCommand == "END")
                            break;
                        if (strStep == "Step No." || strOperand == string.Empty && strCommand == string.Empty)
                            continue;

                        nRow = nRow + GetSubOperand(DT, nRow, ref arrOperandSub);

                        CILLine ILLine = new CILLine(strProgram, strStep, strNote, strCommand, strOperand, arrOperandSub);

                        if (ILLine.ImportType == EMCoilImport.NONE)
                        {
                            Console.WriteLine("Warning : {0} [{1}] - {2}", "Not Support this Command", System.Reflection.MethodBase.GetCurrentMethod().Name, ILLine.ItemAll);
                        }

                        if (!m_DicILLine.ContainsKey(ILLine.Program))
                            m_DicILLine.Add(ILLine.Program, new List<CILLine>());

                        m_DicILLine.Last().Value.Add(ILLine);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error ImportIL Table : " + strTableName);
                throw new Exception("파일 내부 형식이 쉼표로 구분되어 있지 않습니다. - " + strTableName + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }


        private int GetSubOperand(DataTable DT, int nRow, ref string[] arrOperandSub)
        {
            int nNext = 0;
            for (nNext = 0; nNext < m_nOperandSub; nNext++)
            {
                if (DT.Rows[nRow + nNext + 1].ItemArray[(int)EILImportColumn.LineNumber].ToString() == string.Empty)
                    arrOperandSub[nNext] = DT.Rows[nRow + nNext + 1].ItemArray[(int)EILImportColumn.Operand].ToString();
                else
                    break;
            }

            return nNext;
        }
    }

}
