using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;
using UDM.General;
using UDM.ILConverter;

namespace UDM.LogicViewer
{
    public class CILRungTime
    {
        private CLDRung m_cLDRung = null;
        private Dictionary<string, CILSymbolS> m_DicLcEventTagS = new Dictionary<string, CILSymbolS>();
        private Dictionary<string, EMDataType> m_DicCollect = new Dictionary<string, EMDataType>();

        public CILRungTime(CLDRung cLDRung, Dictionary<string, CILSymbolS> DicLcEventTagS, Dictionary<string, EMDataType> DicCollect)
        {
            m_cLDRung = cLDRung;
            m_DicLcEventTagS = DicLcEventTagS;
            m_DicCollect = DicCollect;
        }

        #region Public Methods

        public void ApplyNodeTime(DateTime dtCoil, string sValue)
        {
            CILSymbolS cILSymbolS = null;
            List<CLDNodeRow> ListILNodeRow = new List<CLDNodeRow>();

            foreach (var who in m_cLDRung.DIAGRAM_HEADS)
            {
                foreach (CLDNodeBody cILNode in m_cLDRung.DIAGRAM_HEADS[who.Key])
                {
                    foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                    {
                        if (cILNodeRow.IsCompareRow)
                        {
                            ApplyNodeCompareRowTime(cILNodeRow, sValue, dtCoil);
                        }
                        else if (m_DicLcEventTagS.ContainsKey(cILNodeRow.Address))
                        {
                            cILSymbolS = m_DicLcEventTagS[cILNodeRow.Address];
                            //List<CLcEventTag> ListLcEventTag = cLcEventTagS.SortEventTag();
                            if (cILSymbolS.IsOneEvent && dtCoil != DateTime.MinValue)
                            {
                                cILNodeRow.Time = cILSymbolS.First().Value.Time;
                                cILNodeRow.Value = cILSymbolS.First().Value.Value.ToString();
                                cILNodeRow.IsHoldSignal = true;
                            }
                            else
                            {
                                ApplyNodeRowTime(cILSymbolS, cILNodeRow, sValue, dtCoil);
                            }
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

        private void UpdateNodeOrder(List<CLDNodeRow> ListILNodeRow, DateTime dtCoil)
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

                if (!m_DicCollect.ContainsKey(cILNodeRow.Address))
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.COLLECT_SKIP;  
                    continue;
                }

                if (cILNodeRow.Time == DateTime.MinValue)
                {
                    cILNodeRow.SortNumber = (int)EMSortNumber.EMPTY;
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
                    cILNodeRow.SortNumber = ++n;
            }
        }

        private void ApplyNodeCompareRowTime(CLDNodeRow cILNodeRow, string sValue, DateTime dtCoil)
        {
            if (UpdateCompareCondition(cILNodeRow, dtCoil, sValue))
            {
                if (cILNodeRow.Time_Sub1 == DateTime.MinValue && cILNodeRow.Time_Sub2 == DateTime.MinValue)
                {
                    cILNodeRow.Value = "0";
                }
                else
                {
                    if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) >= 0)
                    {
                        cILNodeRow.Time = cILNodeRow.Time_Sub1;
                        cILNodeRow.Value = sValue;
                    }
                    else
                    {
                        cILNodeRow.Time = cILNodeRow.Time_Sub2;
                        cILNodeRow.Value = sValue;
                    }
                }
            }
            else
                cILNodeRow.Value = "0";
        }

        private bool UpdateCompareCondition(CLDNodeRow cILNodeRow, DateTime dtCoil, string sValue)
        {
            bool bAvalable = false;

            string sSource_Sub1 = GetWordValue(cILNodeRow.Addess_Sub1);
            string sSource_Sub2 = GetWordValue(cILNodeRow.Addess_Sub2);

            if (CStringHelper.IsDigitString(sSource_Sub1))
                cILNodeRow.Value_Sub1 = sSource_Sub1;
            if (CStringHelper.IsDigitString(sSource_Sub2))
                cILNodeRow.Value_Sub2 = sSource_Sub2;

            if (m_DicLcEventTagS.ContainsKey(sSource_Sub1))
                cILNodeRow.Time_Sub1 = GetLastTime(m_DicLcEventTagS[sSource_Sub1], dtCoil);
            else
                cILNodeRow.Time_Sub1 = DateTime.MinValue;

            if (m_DicLcEventTagS.ContainsKey(sSource_Sub2))
                cILNodeRow.Time_Sub2 = GetLastTime(m_DicLcEventTagS[sSource_Sub2], dtCoil);
            else
                cILNodeRow.Time_Sub2 = DateTime.MinValue;

            if (cILNodeRow.Time_Sub1 == DateTime.MinValue && cILNodeRow.Time_Sub2 == DateTime.MinValue)
                return false;

            if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) >= 0)
            {
                bAvalable = CrossCheckCondition(cILNodeRow, sValue, cILNodeRow.Time_Sub1, sSource_Sub1, true);
            }
            else
            {
                bAvalable = CrossCheckCondition( cILNodeRow, sValue, cILNodeRow.Time_Sub2, sSource_Sub2, false);
            }

            return bAvalable;
        }

        private bool AvalableCompareCondition(CLDNodeRow cILNodeRow, string sValue)
        {
            bool bAvalable = false;
            bool bOpenContact = sValue == "1" ? true : false;

            if (cILNodeRow.CommandCompare == ">=")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare =="<=")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) >= 0)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare ==">")
            {
                if (cILNodeRow.Value_Sub1.CompareTo(cILNodeRow.Value_Sub2) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare =="<")
            {
                if (cILNodeRow.Value_Sub2.CompareTo(cILNodeRow.Value_Sub1) == 1)
                    bAvalable = bOpenContact ? true : false;
                else
                    bAvalable = bOpenContact ? false : true;
            }
            else if (cILNodeRow.CommandCompare =="=")
            {
                if (cILNodeRow.Value_Sub1 == cILNodeRow.Value_Sub2)
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

        private DateTime GetLastTime(CILSymbolS cILSymbolS, DateTime dtCoil)
        {
            DateTime dtLast = DateTime.MinValue;

            foreach (var whoLcEventTag in cILSymbolS)
            {
                CILSymbol cILSymbol = (CILSymbol)whoLcEventTag.Value;

                if (dtCoil.CompareTo(cILSymbol.Time) >= 0)
                {
                    dtLast = cILSymbol.Time;
                    break;
                }
            }

            return dtLast;
        }

        private bool CrossCheckCondition(CLDNodeRow cILNodeRow, string sValue, DateTime dtSource, string sSource, bool bSource_Sub1)
        {
            bool bFind = false;

            if (m_DicLcEventTagS.ContainsKey(sSource))
            {
                CILSymbolS cILSymbolS = m_DicLcEventTagS[sSource];
                foreach (var whoLcEventTag in cILSymbolS)
                {
                    CILSymbol cLcEventTag = (CILSymbol)whoLcEventTag.Value;
                    if (dtSource.CompareTo(cLcEventTag.Time) >= 0)
                    {
                        if (bSource_Sub1)
                        {
                            cILNodeRow.Time_Sub1 = cLcEventTag.Time;
                            cILNodeRow.Value_Sub1 = cLcEventTag.Value.ToString();
                        }
                        else
                        {
                            cILNodeRow.Time_Sub2 = cLcEventTag.Time;
                            cILNodeRow.Value_Sub2 = cLcEventTag.Value.ToString();
                        }


                        if (AvalableCompareCondition(cILNodeRow, sValue))
                        {
                            bFind = true;
                            break;
                        }
                    }
                }

            }

            return bFind;
        }

        private bool ApplyNodeRowTime(CILSymbolS cILSymbolS, CLDNodeRow cILNodeRow, string sValue, DateTime dtCoil)
        {
            foreach (var whoLcEventTag in cILSymbolS)
            {
                CILSymbol cLcEventTag = (CILSymbol)whoLcEventTag.Value;
                if (!AvalableBitCondition(cILNodeRow, cLcEventTag, sValue))
                    continue;

                if (dtCoil.CompareTo(cLcEventTag.Time) >= 0)
                {
                    cILNodeRow.Time = cLcEventTag.Time;
                    cILNodeRow.Value = cLcEventTag.Value.ToString();

                    return true;
                }
            }

            return false;
        }

        private bool AvalableBitCondition(CLDNodeRow cILNodeRow, CILSymbol cILSymbol, string sValue)
        {
            bool bAvalable = false;
            bool bContactOpen = false;

            if (IsValueOnCondition(cILNodeRow))
                bContactOpen = true;

            if (cILSymbol.Value.ToString() == sValue)
                bAvalable = bContactOpen ? true : false;
            else
                bAvalable = bContactOpen ? false : true;

            return bAvalable;
        }

        private bool IsValueOnCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.ContactType == EMContactType.Open
                || cILNodeRow.ContactType == EMContactType.PulseOffClose
                || cILNodeRow.ContactType == EMContactType.PulseOnOpen)
                return true;
            else
                return false;
        }

        private bool IsValueOffCondition(CLDNodeRow cILNodeRow)
        {
            if (cILNodeRow.ContactType == EMContactType.Close
                || cILNodeRow.ContactType == EMContactType.PulseOffOpen
                || cILNodeRow.ContactType == EMContactType.PulseOnClose)
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