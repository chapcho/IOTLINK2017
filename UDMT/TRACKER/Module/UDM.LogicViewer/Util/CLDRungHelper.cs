using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;
using UDM.General;
using UDM.Log;
using UDM.UDLImport;
using UDM.Log.Csv;


namespace UDM.LogicViewer
{
    public class CLDRungHelper
    {
        private static CLDRung m_cLDRung = null;
        private static Dictionary<string, CTimeLogS> m_DicSymbolLogS = new Dictionary<string, CTimeLogS>();

        #region Public Methods

        public static DateTime GetLastTime(string sKey, CTimeLogS cTimeLogS, DateTime dtCoil)
        {
            if (cTimeLogS == null)
                return DateTime.MinValue;

            CTimeLogS cKeyTimeLogS = cTimeLogS.GetTimeLogS(sKey);

            CTimeLog cLogFound = null;
            CTimeLog cLog = null;
            for (int i = cKeyTimeLogS.Count - 1; i >= 0; i--)
            {
                cLog = cKeyTimeLogS[i];
                if (cLog.Time <= dtCoil)
                {
                    cLogFound = cLog;
                    break;
                }
            }

            if (cLogFound == null)
                return DateTime.MinValue;
            else
                return cLogFound.Time;
        }

        public static void UpdateNodeTime(DateTime dtCoil, int nValue, CLDRung cLDRung, CTimeLogS cTimeLogS,  TimeSpan tsOffSet)
        {
            m_cLDRung = cLDRung;

            dtCoil = dtCoil.Subtract(tsOffSet);

            ClearTimeNValue();

            m_DicSymbolLogS = CreateEventTag(cTimeLogS);

            List<CLDNodeRow> ListILNodeRow = new List<CLDNodeRow>();

            if (dtCoil == DateTime.MinValue)
                dtCoil = DateTime.MaxValue;

            foreach (var who in m_cLDRung.DIAGRAM_HEADS)
            {
                foreach (CLDNodeBody cILNode in m_cLDRung.DIAGRAM_HEADS[who.Key])
                {
                    foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                    {
                        if (cILNodeRow.IsCompareRow)
                        {
                            ApplyNodeCompareRowTime(cILNodeRow, nValue, dtCoil);
                        }
                        else
                        {
                            ApplyNodeRowTime(cILNodeRow, nValue, dtCoil,false);
                        }

                        ListILNodeRow.Add(cILNodeRow);
                    }
                }
            }

            foreach (CLDNodeRow cLDNodeRow in m_cLDRung.TagRowS)
            {
                ApplyNodeRowTime(cLDNodeRow, nValue, dtCoil, true);
                ListILNodeRow.Add(cLDNodeRow);
            }

            if (dtCoil.Year > 1)
                UpdateNodeOrder(ListILNodeRow, dtCoil);
        }

        #endregion

        #region Private Methods

        private static bool ClearTimeNValue()
        {
            foreach (var who in m_cLDRung.DIAGRAM_HEADS)
                foreach (CLDNodeBody cILNode in m_cLDRung.DIAGRAM_HEADS[who.Key])
                    foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                    {
                        if(!cILNodeRow.Address.Contains("SM400") && !cILNodeRow.Address.Contains("F00099"))
                            cILNodeRow.ClearTimeNValue();
                    }

            foreach (CLDNodeRow cILNodeRow in m_cLDRung.TagRowS)
                cILNodeRow.ClearTimeNValue();

            return true;
        }

        private static Dictionary<string, CTimeLogS> CreateEventTag(CTimeLogS cTimeLogS)
        {
            Dictionary<string, CTimeLogS> DicTimeLog = new Dictionary<string, CTimeLogS>();
            if (cTimeLogS == null)
                return DicTimeLog;

            foreach (CTimeLog cTimeLog in cTimeLogS)
            {
                if (DicTimeLog.ContainsKey(cTimeLog.Key))
                {
                    DicTimeLog[cTimeLog.Key].Add(cTimeLog);
                }
                else
                {
                    CTimeLogS cTimeLogSNew = new CTimeLogS();
                    cTimeLogSNew.Add(cTimeLog);
                    DicTimeLog.Add(cTimeLog.Key, cTimeLogSNew);
                }
            }

            foreach (CTimeLogS cTimeLogSReverse in DicTimeLog.Values)
                cTimeLogSReverse.Sort();

            return DicTimeLog;
        }

        private static void UpdateNodeOrder(List<CLDNodeRow> ListILNodeRow, DateTime dtCoil)
        {
            ListILNodeRow.Sort(CompareTime);
            DateTime dtPre = DateTime.MinValue;
            int n = 0;

            foreach (CLDNodeRow cILNodeRow in ListILNodeRow)
            {
                if (!cILNodeRow.IsCompareRow &&
                    (cILNodeRow.Address == m_cLDRung.CoilAddress
                    || cILNodeRow.Address == string.Empty
                    || cILNodeRow.Address.StartsWith("SM")))
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.SPECIAL;  
                    continue;
                }

                string sNodeRowAddrKey = cILNodeRow.Key;

                if (!m_DicSymbolLogS.ContainsKey(sNodeRowAddrKey) || cILNodeRow.Time == DateTime.MinValue)
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.COLLECT_SKIP;  
                    continue;
                }

                if (cILNodeRow.IsHoldSignal)
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.ONCE; 
                    continue;
                }

                if (n == 0 || dtPre == cILNodeRow.Time)
                {
                    cILNodeRow.Last = true;
                    dtPre = cILNodeRow.Time;
                    cILNodeRow.SortNumber = 1;
                    n++;
                }
                else
                {
                    cILNodeRow.Last = false;
                    cILNodeRow.SortNumber = ++n;
                }
            }
        }

        private static void ApplyNodeCompareRowTime(CLDNodeRow cILNodeRow, int nValue, DateTime dtCoil)
        {
            bool bUpdated = UpdateCompareCondition(cILNodeRow, dtCoil, nValue);

            if (bUpdated)
            {
                if (cILNodeRow.Time_Sub1 == DateTime.MinValue && cILNodeRow.Time_Sub2 == DateTime.MinValue)
                {
                    cILNodeRow.Value = 0;
                }
                else
                {
                    if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) >= 0)
                    {
                        cILNodeRow.Time = cILNodeRow.Time_Sub1;
                        cILNodeRow.Value = nValue;
                        if (cILNodeRow.ContentSub1.Tag != null)
                            cILNodeRow.Key = cILNodeRow.ContentSub1.Tag.Key;
                    }
                    else
                    {
                        cILNodeRow.Time = cILNodeRow.Time_Sub2;
                        cILNodeRow.Value = nValue;
                        if (cILNodeRow.ContentSub2.Tag != null)
                            cILNodeRow.Key = cILNodeRow.ContentSub2.Tag.Key;
                    }
                }
            }
            else
                cILNodeRow.Value = 0;
        }

        private static bool UpdateCompareCondition(CLDNodeRow cILNodeRow, DateTime dtCoil, int nValue)
        {
            bool bAvalable = false;

            if (CStringHelper.IsDigitString(GetWordValue(cILNodeRow.ContentSub1.Argument)))
                cILNodeRow.Value_Sub1 = Convert.ToInt32(GetWordValue(cILNodeRow.ContentSub1.Argument));
            if (CStringHelper.IsDigitString(GetWordValue(cILNodeRow.ContentSub2.Argument)))
                cILNodeRow.Value_Sub2 = Convert.ToInt32(GetWordValue(cILNodeRow.ContentSub2.Argument));

            string sKeySub1 = cILNodeRow.ContentSub1.Tag != null ? cILNodeRow.ContentSub1.Tag.Key : string.Empty;
            string sKeySub2 = cILNodeRow.ContentSub2.Tag != null ? cILNodeRow.ContentSub2.Tag.Key : string.Empty;

            if (m_DicSymbolLogS.ContainsKey(sKeySub1))
                cILNodeRow.Time_Sub1 = GetLastTime(sKeySub1, m_DicSymbolLogS[sKeySub1], dtCoil);
            else
                cILNodeRow.Time_Sub1 = DateTime.MinValue;

            if (m_DicSymbolLogS.ContainsKey(sKeySub2))
                cILNodeRow.Time_Sub2 = GetLastTime(sKeySub2,  m_DicSymbolLogS[sKeySub2], dtCoil);
            else
                cILNodeRow.Time_Sub2 = DateTime.MinValue;

            if (cILNodeRow.Time_Sub1 == DateTime.MinValue && cILNodeRow.Time_Sub2 == DateTime.MinValue)
                return false;

            if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) >= 0)
                bAvalable = CrossCheckCondition(cILNodeRow, nValue, cILNodeRow.Time_Sub1, sKeySub1, true);
            else
                bAvalable = CrossCheckCondition(cILNodeRow, nValue, cILNodeRow.Time_Sub2, sKeySub2, false);

            return bAvalable;
        }

        private static bool AvalableCompareCondition(CLDNodeRow cILNodeRow, int nValue)
        {
            bool bAvalable = false;
            bool bOpenContact = nValue == 1 ? true : false;

            if (cILNodeRow.Operator == "GEQ" || cILNodeRow.Operator == "DGEQ")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.Operator == "LEQ" || cILNodeRow.Operator == "DLEQ")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.Operator == "GRT" || cILNodeRow.Operator == "DGRT")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.Operator == "LES" || cILNodeRow.Operator == "DLES")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.Operator == "EQU" || cILNodeRow.Operator == "DEQU")
            {
                if (cILNodeRow.Value_Sub1 == cILNodeRow.Value_Sub2)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.Operator == "NEQ" || cILNodeRow.Operator == "DNEQ")
            {
                if (cILNodeRow.Value_Sub1 != cILNodeRow.Value_Sub2)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }

            return bAvalable;
        }

        private static string GetWordValue(string sSource)
        {
            string sWordValue = sSource;

            if (sSource.StartsWith("K"))
            {
                if (CStringHelper.IsDigitString(sSource.Replace("K", string.Empty)))
                    sWordValue = sSource.Replace("K", string.Empty);
            }
            else if (sSource.StartsWith("H"))
                sWordValue = Convert.ToInt32(sSource.Replace("H", string.Empty), 16).ToString();


            return sWordValue;
        }

        private static bool CrossCheckCondition(CLDNodeRow cILNodeRow, int nValue, DateTime dtSource, string sSource, bool bSource_Sub1)
        {
            bool bFind = false;

            if (m_DicSymbolLogS.ContainsKey(sSource))
            {
                CTimeLogS cTimeLogS = m_DicSymbolLogS[sSource];
                cTimeLogS.Reverse();
                foreach (CTimeLog cTimeLog in cTimeLogS)
                {
                    if (dtSource >= cTimeLog.Time)
                    {
                        if (bSource_Sub1)
                        {
                            cILNodeRow.Time_Sub1 = cTimeLog.Time;
                            cILNodeRow.Value_Sub1 = cTimeLog.Value;
                        }
                        else
                        {
                            cILNodeRow.Time_Sub2 = cTimeLog.Time;
                            cILNodeRow.Value_Sub2 = cTimeLog.Value;
                        }
                        if (AvalableCompareCondition(cILNodeRow, nValue))
                        {
                            bFind = true;
                            break;
                        }
                    }
                }

            }

            return bFind;
        }

        private static bool ApplyNodeRowTime(CLDNodeRow cILNodeRow, int nValue, DateTime dtCoil, bool bTag)
        {
            string sKey = cILNodeRow.Key;
            if (!m_DicSymbolLogS.ContainsKey(sKey))
                return false;


            CTimeLogS cTimeLogS = m_DicSymbolLogS[sKey];
            if (cTimeLogS.Count == 1)
            {
                cILNodeRow.Time = cTimeLogS.Last().Time;
                cILNodeRow.Value = cTimeLogS.Last().Value;
                cILNodeRow.IsHoldSignal = true;
                return false;
            }

            CTimeLog cLog = null;
            bool bTimerCoil = cILNodeRow.Address.StartsWith("T");
            for (int i = cTimeLogS.Count - 1; i >= 0; i--)
            {
                cLog = cTimeLogS[i];

                if (bTimerCoil)
                {
                    if (dtCoil >= cLog.Time)
                    {
                        cILNodeRow.Time = cLog.Time;
                        cILNodeRow.Value = cLog.Value > 0 ? 1 : 0;

                        return true;
                    }
                }

                if (!bTag && !AvalableBitCondition(cILNodeRow, cLog, nValue))
                    continue;

                if (dtCoil >= cLog.Time)
                {
                    cILNodeRow.Time = cLog.Time;
                    cILNodeRow.Value = cLog.Value;

                    return true;
                }
            }

            return false;
        }

        private static bool AvalableBitCondition(CLDNodeRow cILNodeRow, CTimeLog cTimeLog, int nValue)
        {
            bool bAvalable = false;
            bool bContactOpen = false;

            if (IsValueOnCondition(cILNodeRow))
                bContactOpen = true;
            else if (IsValueOffCondition(cILNodeRow))
                bContactOpen = false;

            if (cTimeLog.Value == nValue)
                bAvalable = bContactOpen ? true : false;
            else
                bAvalable = bContactOpen ? false : true;

            return bAvalable;
        }

        private static bool IsValueOnCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.Operator == "XIC" 
                || cILNodeRow.Operator == "XIOF"
                || cILNodeRow.Operator == "XICP")
                return true;
            else
                return false;
        }

        private static bool IsValueOffCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.Operator == "XIO"
                || cILNodeRow.Operator == "XICF"
                || cILNodeRow.Operator == "XIO")
                return true;
            else
                return false;
        }

        private static int CompareTime(CLDNodeRow cILNodeRowA, CLDNodeRow cILNodeRowB)
        {
            int retval = cILNodeRowB.Time.CompareTo(cILNodeRowA.Time);
            return retval;
        }

        #endregion
    }

}