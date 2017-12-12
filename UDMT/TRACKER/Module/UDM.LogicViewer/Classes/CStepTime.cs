using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;
using UDM.General;
using UDM.Log;
using UDM.Converter;
using UDM.Log.Csv;


namespace UDM.LogicViewer
{
    public class CStepTime
    {
        private CLDRung m_cILRung = null;
        private int m_iPacket = -1;
        private TimeSpan m_tsOffSet = new TimeSpan(0);
        private Dictionary<string, CTimeLogS> m_DicSymbolLogS = new Dictionary<string, CTimeLogS>();
        private EMLogType m_emLogType = EMLogType.Normal;

        public CStepTime(CLDRung cILRung, Dictionary<string, CTimeLogS> DicLcEventTagS, int iPacket, TimeSpan tsOffSet, EMLogType emLogType)
        {
            m_cILRung = cILRung;
            m_DicSymbolLogS = DicLcEventTagS;
            m_iPacket = iPacket;
            m_tsOffSet = tsOffSet;
            m_emLogType = emLogType;
        }

        #region Public Methods

        public void ApplyNodeTime(DateTime dtCoil, int nValue)
        {
            List<CLDNodeRow> ListILNodeRow = new List<CLDNodeRow>();

            if (dtCoil == DateTime.MinValue)
                dtCoil = DateTime.MaxValue;

            foreach (var who in m_cILRung.DIAGRAM_HEADS)
            {
                foreach (CLDNodeBody cILNode in m_cILRung.DIAGRAM_HEADS[who.Key])
                {
                    foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                    {
                        if (cILNodeRow.IsCompareRow)
                        {
                            ApplyNodeCompareRowTime(cILNodeRow, nValue, dtCoil);
                        }
                        else if (m_DicSymbolLogS.ContainsKey(cILNodeRow.GetFirstKey()))
                        {
                            ApplyNodeRowTime(cILNodeRow, nValue, dtCoil);
                        }

                        ListILNodeRow.Add(cILNodeRow);
                    }
                }
            }

            if (dtCoil.Year > 1)
                UpdateNodeOrder(ListILNodeRow, dtCoil);
        }

        #endregion

        #region Private Methods

        private CTimeLogS GetBlockLogS(string sKey)
        {
            CTimeLogS cTimeLogS = new CTimeLogS();

            if (m_DicSymbolLogS.ContainsKey(sKey))
            {
                cTimeLogS = m_DicSymbolLogS[sKey];
                if (m_iPacket >= 0 && m_emLogType == EMLogType.Fragment)
                {
                    cTimeLogS = cTimeLogS.GetPacketLogS(m_iPacket, CPlc.DefaultPath + sKey);
                    cTimeLogS = cTimeLogS.GetNormalize(m_tsOffSet);
                }
            }

            return cTimeLogS;
        }

        private void UpdateNodeOrder(List<CLDNodeRow> ListILNodeRow, DateTime dtCoil)
        {
            ListILNodeRow.Sort(CompareTime);
            DateTime dtPre = DateTime.MinValue;
            int n = 0;

            foreach (CLDNodeRow cILNodeRow in ListILNodeRow)
            {
                if (!cILNodeRow.IsCompareRow &&
                    (cILNodeRow.Address == m_cILRung.CoilAddress
                    || cILNodeRow.Address == string.Empty
                    || cILNodeRow.Address.StartsWith("SM")))
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.SPECIAL;  
                    continue;
                }

                string sNodeRowAddrKey = cILNodeRow.GetFirstKey();

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

        private void ApplyNodeCompareRowTime(CLDNodeRow cILNodeRow, int nValue, DateTime dtCoil)
        {
            if (UpdateCompareCondition(cILNodeRow, dtCoil, nValue))
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
                    }
                    else
                    {
                        cILNodeRow.Time = cILNodeRow.Time_Sub2;
                        cILNodeRow.Value = nValue;
                    }
                }
            }
            else
                cILNodeRow.Value = 0;
        }

        private bool UpdateCompareCondition(CLDNodeRow cILNodeRow, DateTime dtCoil, int nValue)
        {
            bool bAvalable = false;

            string sSource_Sub1 = GetWordValue(cILNodeRow.ContentSub1.Argument);
            string sSource_Sub2 = GetWordValue(cILNodeRow.ContentSub2.Argument);

            if (CStringHelper.IsDigitString(sSource_Sub1))
                cILNodeRow.Value_Sub1 = Convert.ToInt32(sSource_Sub1);
            if (CStringHelper.IsDigitString(sSource_Sub2))
                cILNodeRow.Value_Sub2 = Convert.ToInt32(sSource_Sub2);

            string sKeySub1 = cILNodeRow.ContentSub1.Tag != null ? cILNodeRow.ContentSub1.Tag.Key : string.Empty;
            if (m_DicSymbolLogS.ContainsKey(sKeySub1))
                cILNodeRow.Time_Sub1 = GetLastTime(GetBlockLogS(sKeySub1), dtCoil);
            else
                cILNodeRow.Time_Sub1 = DateTime.MinValue;

            string sKeySub2 = cILNodeRow.ContentSub2.Tag != null ? cILNodeRow.ContentSub2.Tag.Key : string.Empty;

            if (m_DicSymbolLogS.ContainsKey(sKeySub2))
                cILNodeRow.Time_Sub2 = GetLastTime(GetBlockLogS(sKeySub2), dtCoil);
            else
                cILNodeRow.Time_Sub2 = DateTime.MinValue;

            if (cILNodeRow.Time_Sub1 == DateTime.MinValue && cILNodeRow.Time_Sub2 == DateTime.MinValue)
                return false;

            if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) >= 0)
            {
                bAvalable = CrossCheckCondition(cILNodeRow, nValue, cILNodeRow.Time_Sub1, sSource_Sub1, true);
            }
            else
            {
                bAvalable = CrossCheckCondition(cILNodeRow, nValue, cILNodeRow.Time_Sub2, sSource_Sub2, false);
            }

            return bAvalable;
        }

        private bool AvalableCompareCondition(CLDNodeRow cILNodeRow, int nValue)
        {
            bool bAvalable = false;
            bool bOpenContact = nValue == 1 ? true : false;

            if (cILNodeRow.CommandCompare.TrimStart('D') == ">=")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare.TrimStart('D') == "<=")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare.TrimStart('D') == ">")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare.TrimStart('D') == "<")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare.TrimStart('D') == "=")
            {
                if (cILNodeRow.Value_Sub1 == cILNodeRow.Value_Sub2)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare.TrimStart('D') == "<>")
            {
                if (cILNodeRow.Value_Sub1 != cILNodeRow.Value_Sub2)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }

            return bAvalable;
        }
        
        private string GetWordValue(string sSource)
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

        private DateTime GetLastTime(CTimeLogS cTimeLogS, DateTime dtCoil)
        {
            CTimeLog cLogFound = null;
            CTimeLog cLog = null;
            for (int i = cTimeLogS.Count - 1; i >= 0; i--)
            {
                cLog = cTimeLogS[i];
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

        private bool CrossCheckCondition(CLDNodeRow cILNodeRow, int nValue, DateTime dtSource, string sSource, bool bSource_Sub1)
        {
            bool bFind = false;

            if (m_DicSymbolLogS.ContainsKey(sSource))
            {
                CTimeLogS cTimeLogS = GetBlockLogS(sSource);
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

        private bool ApplyNodeRowTime(CLDNodeRow cILNodeRow, int nValue, DateTime dtCoil)
        {
            CTimeLogS cTimeLogS = GetBlockLogS(cILNodeRow.GetFirstKey());
            if (cTimeLogS.Count == 1)
            {
                cILNodeRow.Time = cTimeLogS.Last().Time;
                cILNodeRow.Value = cTimeLogS.Last().Value;
                cILNodeRow.IsHoldSignal = true;
                return false;
            }

            CTimeLog cLog = null;
            for (int i = cTimeLogS.Count - 1; i >= 0; i--)
            {
                cLog = cTimeLogS[i];
                if (!AvalableBitCondition(cILNodeRow, cLog, nValue))
                    continue;

                if (dtCoil >= cLog.Time)
                {
                    cILNodeRow.Time = cLog.Time;
                    cILNodeRow.Value = cLog.Value;

                    return true;
                }
            }

            int iValue = 0;
            if (nValue == 0)
                iValue = 1;
            

            for (int i = cTimeLogS.Count - 1; i >= 0; i--)
            {
                cLog = cTimeLogS[i];
                if (!AvalableBitCondition(cILNodeRow, cLog, iValue))
                    continue;
                if (dtCoil == DateTime.MinValue)
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

        private bool AvalableBitCondition(CLDNodeRow cILNodeRow, CTimeLog cTimeLog, int nValue)
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

        private bool IsValueOnCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.Instruction == EMContactTypeBit.Open.ToString()
                || cILNodeRow.Instruction == EMContactTypeBit.PulseOffClose.ToString()
                || cILNodeRow.Instruction == EMContactTypeBit.PulseOnOpen.ToString())
                return true;
            else
                return false;
        }

        private bool IsValueOffCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.Instruction == EMContactTypeBit.Close.ToString()
                || cILNodeRow.Instruction == EMContactTypeBit.PulseOffOpen.ToString()
                || cILNodeRow.Instruction == EMContactTypeBit.PulseOnClose.ToString())
                return true;
            else
                return false;
        }

        private int CompareTime(CLDNodeRow cILNodeRowA, CLDNodeRow cILNodeRowB)
        {
            int retval = cILNodeRowB.Time.CompareTo(cILNodeRowA.Time);
            return retval;
        }

        #endregion
    }

}