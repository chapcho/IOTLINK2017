using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;

namespace UDM.Converter
{
    public static class CIL
    {
        public static string SOURCE = "SOURCE-";
        public static string LOCAL = "LOCAL-";
        public static string OPERATOR = "OPERATOR-";

        public static string OPEN = "OPEN";
        public static string CLOSE = "CLOSE";
        public static string AND = "AND";
        public static string OR = "OR";
        public static string WAIT = "WAIT";
        public static string EMPTY = "EMPTY";
    }


    public class CPlcLogic : ICloneable
    {
        #region Member Variables

        private List<string> m_ListLogic = new List<string>();

        #endregion

        #region Initialize/Dispose

        public CPlcLogic()
        {
            
        }

        public object Clone()
        {
            CPlcLogic cPlcLogic = (CPlcLogic)this.MemberwiseClone();
            cPlcLogic.m_ListLogic = m_ListLogic.Clone();

            return cPlcLogic;
        }


        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        public int GetCount()
        {
            return m_ListLogic.Count;
        }

        public bool IsOpen(int index)
        {
            if (m_ListLogic[index] == CIL.OPEN)
                return true;
            else
                return false;
        }

        public bool IsAnd(string sLogic)
        {
            if (sLogic == CIL.AND)
                return true;
            else
                return false;
        }

        public bool IsOr(string sLogic)
        {
            if (sLogic == CIL.OR)
                return true;
            else
                return false;
        }

        public bool IsClose(int index)
        {
            if (m_ListLogic[index] == CIL.CLOSE)
                return true;
            else
                return false;
        }

        public bool IsSource(int index)
        {
            if (m_ListLogic[index].StartsWith(CIL.SOURCE))
                return true;
            else
                return false;
        }

        public bool IsLocal(int index)
        {
            if (m_ListLogic[index].StartsWith(CIL.LOCAL))
                return true;
            else
                return false;
        }

        public string GetOperator(int index)
        {
            string sOperator = string.Empty;

            if (m_ListLogic[index].StartsWith(CIL.OPERATOR))
            {
                sOperator = m_ListLogic[index].Split('-')[1];
                m_ListLogic[index] = CIL.EMPTY;
            }

            return sOperator;
        }

        public int GetSource(int index)
        {
            int iSource = -1;

            if (m_ListLogic[index].StartsWith(CIL.SOURCE))
            {
                iSource = Convert.ToInt32(m_ListLogic[index].Split('-')[1]);
                m_ListLogic[index] = CIL.EMPTY;
            }

            return iSource;
        }

        public int GetSourceNumber(int index)
        {
            int iSource = -1;

            if (m_ListLogic[index].StartsWith(CIL.SOURCE))
            {
                iSource = Convert.ToInt32(m_ListLogic[index].Split('-')[1]);
            }

            return iSource;
        }

        public int  GetLocal(int index)
        {
            int iLocal  = -1;

            if (m_ListLogic[index].StartsWith(CIL.LOCAL))
            {
                iLocal = Convert.ToInt32(m_ListLogic[index].Split('-')[1]); 
                m_ListLogic[index] = CIL.EMPTY;
            }

            return iLocal;
        }


        public int GetBlockCount()
        {
            int nLogic = 0;
            foreach (string str in m_ListLogic)
                if (str == CIL.OPEN)
                    nLogic++;

            return nLogic;
        }

        public bool AddWait()
        {
            m_ListLogic.Add(CIL.WAIT);

            return true;
        }

        public bool AddLocal(int index, int iLocal)
        {
            if (m_ListLogic.Count > index)
            {
                m_ListLogic[index] = CIL.LOCAL + iLocal.ToString();
                return true;
            }
            else
                return false;
        }

        public bool ModifyLogic(int index, string sLogic)
        {
            if (m_ListLogic.Count > index)
            {
                m_ListLogic[index] = sLogic;
                return true;
            }
            else
                return false;
        }

        public bool ModifyEmpty(int index)
        {
            if (m_ListLogic.Count > index)
            {
                m_ListLogic[index] = CIL.EMPTY;
                return true;
            }
            else
                return false;
        }

        public bool AddLogic(int nSourceA, int nSourceB, bool bAnd)
        {
            m_ListLogic.Add(CIL.OPEN);
            m_ListLogic.Add(CIL.SOURCE + nSourceA.ToString());

            m_ListLogic.Add(CIL.OPERATOR + (bAnd ? CIL.AND : CIL.OR));

            m_ListLogic.Add(CIL.SOURCE + nSourceB.ToString());
            m_ListLogic.Add(CIL.CLOSE);

            return true;
        }

        public bool AddLogicFront(int nSource, bool bAnd)
        {
            int iInsertPoint = GetInsertPoint(m_ListLogic.Count - 1);

            if (iInsertPoint != 0)
                iInsertPoint++;

            m_ListLogic.Insert(iInsertPoint, CIL.OPERATOR + (bAnd ? CIL.AND : CIL.OR));
            m_ListLogic.Insert(iInsertPoint, CIL.SOURCE + nSource.ToString());
            m_ListLogic.Insert(iInsertPoint, CIL.OPEN);
            m_ListLogic.Add(CIL.CLOSE);

            return true;
        }

        public bool AddLogicBack(int nSource, bool bAnd)
        {
            int iInsertPoint = GetInsertPoint(m_ListLogic.Count - 1);

            if (iInsertPoint != 0)
                iInsertPoint++;

            m_ListLogic.Insert(iInsertPoint, CIL.OPEN);
            m_ListLogic.Add(CIL.OPERATOR + (bAnd ? CIL.AND : CIL.OR));
            m_ListLogic.Add(CIL.SOURCE + nSource.ToString());
            m_ListLogic.Add(CIL.CLOSE);

            return true;
        }

        public bool MergeLogicBlock(bool bAnd)
        {
            for (int i = m_ListLogic.Count - 1; i >= 0; i--)
            {
                if (m_ListLogic[i] == CIL.WAIT)
                {
                    int iInsertPoint = GetInsertPoint(i - 1);

                    if (iInsertPoint != 0)
                        iInsertPoint++;

                    m_ListLogic[i] = CIL.OPERATOR + (bAnd ? CIL.AND : CIL.OR);
                    m_ListLogic.Insert(iInsertPoint, CIL.OPEN);
                    m_ListLogic.Add(CIL.CLOSE);
                    break;
                }
            }

            return true;
        }

        public bool IsMergeLogicBlock(int nSource)
        {
            if (!m_ListLogic.Contains(CIL.WAIT))
                return false;

            int sSourceWait = -1;
            for (int i = 0; i < m_ListLogic.Count; i++)
            {
                int nLogicSource = GetSourceNumber(i);

                if (nLogicSource != -1)
                    sSourceWait = nLogicSource;

                if (m_ListLogic[i] == CIL.WAIT)
                {
                    if (sSourceWait > nSource)
                        return true;
                    else
                        return false;
                }
            }

            return false;

        }

   

        public bool IsMergeFinished(int nSource)
        {
            if (m_ListLogic.Contains(CIL.WAIT))
                return false;

            int sSourceWait = -1;
            for (int i = 0; i < m_ListLogic.Count; i++)
            {
                int nLogicSource = GetSourceNumber(i);

                if (nLogicSource != -1)
                    sSourceWait = nLogicSource;

                if (m_ListLogic[i] == CIL.WAIT)
                {
                    if (sSourceWait > nSource)
                        return true;
                    else
                        return false;
                }
            }

            return false;

        }

        public bool ValidationLogic()
        {
            for (int i = 0; i < m_ListLogic.Count; i++)
            {
                if (m_ListLogic[i].Contains(CIL.SOURCE))
                {
                    if (m_ListLogic[i] == CIL.SOURCE + "0")
                        return true;
                    else
                        return false;
                }
            }

            return true;
        }


        #endregion

        #region Private Methods

        private int GetInsertPoint(int nSearchBack)
        {
            int iInsertPoint = 0;
            for (int i = nSearchBack; i >= 0; i--)
            {
                if (m_ListLogic.Count <= nSearchBack)
                    continue;

                if (m_ListLogic[i] == CIL.WAIT)
                {
                    iInsertPoint = i;
                    break;
                }
            }

            return iInsertPoint;

        }


        #endregion

    }
}
