using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using DevExpress.XtraCharts;
using UDM.Log;

namespace UDMLadderTracker
{
    public class CErrorInfoSummary
    {
        private string m_sGroupKey = string.Empty;
        private List<CErrorInfo> m_lstErrorInfo = new List<CErrorInfo>();
        private List<CErrorInfo> m_lstErrorInfoNoRedundancy = new CErrorInfoS();

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        public int ErrorCount
        {
            get { return m_lstErrorInfo.Where(x => x.IsVisible == true).Count(); }
        }

        public List<CErrorInfo> lstErrorInfo
        {
            get { return m_lstErrorInfo; }
            set { m_lstErrorInfo = value; }
        }

        public List<CErrorInfo> lstErrorInfoNoRedundancy
        {
            get { return m_lstErrorInfoNoRedundancy; }
            set { m_lstErrorInfoNoRedundancy = value; }
        }

        public Dictionary<string, int> GetMergedCategoryErrorInfo()
        {
            Dictionary<string, CErrorInfoS> CatUnitErrorInfo = new Dictionary<string, CErrorInfoS>();
            Dictionary<string, int> CatMergeErrorInfo = new Dictionary<string, int>();
            CErrorInfoS cErrorInfoS = null;

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                if (CatUnitErrorInfo.ContainsKey(cError.ErrorMessage))
                {
                    cErrorInfoS = CatUnitErrorInfo[cError.ErrorMessage];
                    cErrorInfoS.Add(cError);
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    CatUnitErrorInfo.Add(cError.ErrorMessage, cErrorInfoS);
                }
            }

            foreach (var who in CatUnitErrorInfo)
                CatMergeErrorInfo.Add(who.Key, who.Value.Count);

            return CatMergeErrorInfo;
        }

        public Dictionary<string, CErrorInfoS> GetSeriesPointsValue()
        {
            Dictionary<string, CErrorInfoS> CatUnitErrorInfo = new Dictionary<string, CErrorInfoS>();
            Dictionary<string, CErrorInfoS> CatMergeErrorInfo = new Dictionary<string, CErrorInfoS>();
            CErrorInfoS cErrorInfoS = null;
            int iErrorMean = -1;

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                if (CatUnitErrorInfo.ContainsKey(cError.ErrorMessage))
                {
                    cErrorInfoS = CatUnitErrorInfo[cError.ErrorMessage];
                    cErrorInfoS.Add(cError);
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    if (cError.ErrorMessage == string.Empty)
                        continue;

                    CatUnitErrorInfo.Add(cError.ErrorMessage, cErrorInfoS);
                }
            }

            SetMergedCategoryError(CatUnitErrorInfo, CatMergeErrorInfo);

            return CatMergeErrorInfo;
        }

        public Dictionary<string, CErrorInfoS> GetErrorReportValue()
        {
            Dictionary<string, CErrorInfoS> CatUnitErrorInfo = new Dictionary<string, CErrorInfoS>();
            Dictionary<string, CErrorInfoS> CatMergeErrorInfo = new Dictionary<string, CErrorInfoS>();
            CErrorInfoS cErrorInfoS = null;
            bool bOK = false;

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                bOK = false;

                if (CatUnitErrorInfo.ContainsKey(cError.ErrorMessage))
                {
                    cErrorInfoS = CatUnitErrorInfo[cError.ErrorMessage];

                    foreach (var who in cErrorInfoS)
                    {
                        if (who.ErrorTime == cError.ErrorTime)
                        {
                            bOK = true;
                            break;
                        }
                    }

                    if (!bOK)
                        cErrorInfoS.Add(cError);
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    CatUnitErrorInfo.Add(cError.ErrorMessage, cErrorInfoS);
                }
            }

            SetMergedCategoryErrorNotEtc(CatUnitErrorInfo, CatMergeErrorInfo);

            return CatMergeErrorInfo;
        }

        public void SetErrorReportValueNoRedundancy()
        {
            Dictionary<string, CErrorInfoS> CatUnitErrorInfo = new Dictionary<string, CErrorInfoS>();
            CErrorInfoS cErrorInfoS = null;
            bool bOK = false;

            m_lstErrorInfoNoRedundancy.Clear();

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                bOK = false;

                if (CatUnitErrorInfo.ContainsKey(cError.ErrorMessage))
                {
                    cErrorInfoS = CatUnitErrorInfo[cError.ErrorMessage];

                    foreach (var who in cErrorInfoS)
                    {
                        if (who.ErrorTime == cError.ErrorTime)
                        {
                            bOK = true;
                            break;
                        }
                    }

                    if (!bOK)
                    {
                        cErrorInfoS.Add(cError);
                        m_lstErrorInfoNoRedundancy.Add(cError);
                    }
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    CatUnitErrorInfo.Add(cError.ErrorMessage, cErrorInfoS);
                    m_lstErrorInfoNoRedundancy.Add(cError);
                }
            }
        }

        private void SetMergedCategoryError(Dictionary<string, CErrorInfoS> CatUnitErrorInfo, Dictionary<string, CErrorInfoS> CatMergeErrorInfo)
        {
            int iMean = -1;
            List<int> lstErrorCount = new List<int>();
            CErrorInfoS cETCErrorInfoS = new CErrorInfoS();

            foreach (CErrorInfoS cErrorS in CatUnitErrorInfo.Values)
                lstErrorCount.Add(cErrorS.Count);

            iMean = lstErrorCount.Sum() / lstErrorCount.Count;

            foreach (var who in CatUnitErrorInfo)
            {
                if (who.Value.Count >= iMean)
                    CatMergeErrorInfo.Add(who.Key, who.Value);
                else
                    cETCErrorInfoS.AddRange(who.Value);
            }

            if (cETCErrorInfoS.Count != 0)
                CatMergeErrorInfo.Add("etc.", cETCErrorInfoS);
        }

        private void SetMergedCategoryErrorNotEtc(Dictionary<string, CErrorInfoS> CatUnitErrorInfo, Dictionary<string, CErrorInfoS> CatMergeErrorInfo)
        {
            Dictionary<string, int> dicOderbyCount = new Dictionary<string, int>();
            CErrorInfoS cNoDescriptionErrorInfoS = null;

            foreach (var who in CatUnitErrorInfo)
                dicOderbyCount.Add(who.Key, who.Value.Count);

            foreach (var who in dicOderbyCount.OrderByDescending(x => x.Value))
            {
                if (who.Key == string.Empty)
                {
                    cNoDescriptionErrorInfoS = CatUnitErrorInfo[who.Key];
                    continue;
                }
                CatMergeErrorInfo.Add(who.Key, CatUnitErrorInfo[who.Key]);
            }

            if (cNoDescriptionErrorInfoS != null)
                CatMergeErrorInfo.Add(string.Empty, cNoDescriptionErrorInfoS);
        }

    }
}
