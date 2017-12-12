using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CMasterSequenceUnitS : Dictionary<int, CMasterSequenceUnit>, IDisposable
    {
        private string m_sRecipe = string.Empty;

        public CMasterSequenceUnitS()
        {

        }
        public void Dispose()
        {
            Clear();
        }

        protected CMasterSequenceUnitS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        public string Recipe
        {
            get { return m_sRecipe; }
            set { m_sRecipe = value; }
        }

        public bool CheckSameUnitS(CMasterSequenceUnitS cUnitS)
        {
            bool bOK = false;

            if (cUnitS.Count != this.Count)
                return false;

            CMasterSequenceUnit cExistUnit;
            CMasterSequenceUnit cNewUnit;
            foreach (var who in cUnitS)
            {
                cExistUnit = this[who.Key];
                cNewUnit = who.Value;

                if (cExistUnit.TagKey != cNewUnit.TagKey)
                    return false;
            }

            bOK = true;

            return bOK;
        }

        public void Update(CMasterSequenceUnitS cUnitS)
        {
            CMasterSequenceUnit cExistUnit;
            CMasterSequenceUnit cNewUnit;
            foreach (var who in cUnitS)
            {
                cExistUnit = this[who.Key];
                cNewUnit = who.Value;

                cExistUnit.DurationS.AddRange(cNewUnit.DurationS);

                if (cNewUnit.SubMasterSequenceBlock.Count != 0)
                    cExistUnit.SubMasterSequenceBlock.Update(cNewUnit.SubMasterSequenceBlock.First());
            }
        }

        public bool CheckSameUnitS(List<CTimeLog> cOnLogS)
        {
            bool bOK = false;

            if (this.Count != cOnLogS.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (cOnLogS[i].Key != this[i].TagKey)
                    return false;
            }

            bOK = true;

            return bOK;
        }

        public int GetSatisfiedUnitCount(CTimeLogS cLogS)
        {
            int iSatisfiedCount = 0;

            CMasterSequenceUnitS cCurUnitS = GetCurrentUnitS(cLogS);

            CMasterSequenceUnit cExistUnit;
            CMasterSequenceUnit cCurUnit;
            foreach (var who in this)
            {
                cExistUnit = who.Value;
                cCurUnit = cCurUnitS[who.Key];

                if (cExistUnit.LogCount != cCurUnit.LogCount)
                    continue;

                if (CheckDuration(cExistUnit.LowerDuration, cExistUnit.UpperDuration, cCurUnit.LowerDuration,
                    cCurUnit.UpperDuration, 100))
                    iSatisfiedCount++;
            }

            return iSatisfiedCount;
        }

        private bool CheckDuration(double dExistLower, double dExistUpper, double dCurrentLower, double dCurrentUpper, double dTolerance)
        {
            bool bOK = false;

            if ((dExistLower - dTolerance) <= dCurrentLower)
            {
                if ((dExistUpper + dTolerance) >= dCurrentUpper)
                    bOK = true;
            }

            return bOK;
        }

        private CMasterSequenceUnitS GetCurrentUnitS(CTimeLogS cSortLogS)
        {
            CMasterSequenceUnitS cUnitS = new CMasterSequenceUnitS();

            CTimeLogS cLogS;
            CTimeLog cOffLog;
            CTimeLog cOnLog;
            CMasterSequenceUnit cUnit;
            int iOrderNumber = 0;

            foreach (CTimeLog cLog in cSortLogS)
            {
                if (cLog.Value == 0)
                    continue;

                cLogS = cSortLogS.GetTimeLogS(cLog.Key);
                cLogS.Sort((x, y) => DateTime.Compare(x.Time, y.Time));

                cOnLog = cLog;
                cOffLog = cLogS.GetFirstLog(cLog.Key, cOnLog.Time, 0);

                if (cOnLog != null)
                {
                    cUnit = new CMasterSequenceUnit();
                    cUnit.Order = iOrderNumber++;
                    cUnit.TagKey = cLog.Key;

                    if (cOffLog != null)
                    {
                        cUnit.LogCount = 2;
                        cUnit.DurationS.Add(cOffLog.Time.Subtract(cOnLog.Time).TotalMilliseconds);
                    }
                    else
                    {
                        cUnit.LogCount = 1;
                        cUnit.DurationS.Add(cSortLogS.Last().Time.Subtract(cOnLog.Time).TotalMilliseconds);
                    }

                    cUnitS.Add(cUnit.Order, cUnit);
                }
            }

            return cUnitS;
        }

        //private CMasterSequenceUnitS GetCurrentUnitS(CTimeLogS cLogS)
        //{
        //    CMasterSequenceUnitS cUnitS = new CMasterSequenceUnitS();
        //    try
        //    {
        //        List<CTimeLog> lstOnLog = cLogS.Where(x => x.Value == 1).ToList();
        //        string sFirstLogKey = lstOnLog.First().Key;

        //        List<string> lstNextMasterUnit = new List<string>();
        //        List<string> lstNextCurrentUnit = new List<string>();
        //        List<int> lstCurrentExistOrder = new List<int>();

        //        int iMasterIndex = -1;

        //        foreach (var who in this)
        //        {
        //            if (who.Value.TagKey == sFirstLogKey)
        //            {
        //                iMasterIndex = who.Key;
        //                break;
        //            }
        //        }

        //        for (int i = iMasterIndex + 1; i < this.Count; i++)
        //            lstNextMasterUnit.Add(this[i].TagKey);

        //        for (int i = 1; i < lstOnLog.Count; i++)
        //            lstNextCurrentUnit.Add(lstOnLog[i].Key);

        //        string sExistKey = string.Empty;
        //        int iIndex = -1;
        //        for (int i = 0; i < lstNextCurrentUnit.Count; i++)
        //        {
        //            sExistKey = lstNextCurrentUnit[i];

        //            if (lstNextMasterUnit.Contains(sExistKey))
        //            {
        //                iIndex = lstNextMasterUnit.IndexOf(sExistKey);
        //                lstCurrentExistOrder.Add(iIndex + iMasterIndex + 1);
        //                lstNextMasterUnit[iIndex] = string.Empty;
        //            }
        //        }
        //        lstCurrentExistOrder.Add(iMasterIndex);

        //        CTimeLog cOnLog;
        //        CTimeLog cOffLog;
        //        CMasterSequenceUnit cUnit;
        //        int iOrderNumber = 0;
        //        foreach (CTimeLog cLog in cLogS)
        //        {
        //            if (cLog.Value == 0)
        //                continue;

        //            cLogS = cLogS.GetTimeLogS(cLog.Key);
        //            cOnLog = cLog;
        //            cOffLog = cLogS.GetFirstLog(cLog.Key, cOnLog.Time, 0);

        //            if (cOnLog != null && cOffLog != null)
        //            {
        //                cUnit = new CMasterSequenceUnit();
        //                cUnit.Order = lstCurrentExistOrder[iOrderNumber++];
        //                cUnit.TagKey = cLog.Key;
        //                cUnit.DurationS.Add(cOffLog.Time.Subtract(cOnLog.Time).TotalMilliseconds);

        //                cUnitS.Add(cUnit.Order, cUnit);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("MasterSequenceUnit Error " + ex.Message);
        //        ex.Data.Clear();
        //    }
        //    return cUnitS;
        //}

    }
}
