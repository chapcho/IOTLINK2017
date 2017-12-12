using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using DevExpress.XtraCharts;
using UDM.Log;

namespace UDMTrackerSimple
{
    public class CErrorInfoSummary
    {
        private string m_sPlcName = string.Empty;
        private string m_sGroupKey = string.Empty;
        private List<CErrorInfo> m_lstErrorInfo = new List<CErrorInfo>();
        private List<CErrorInfo> m_lstErrorInfoNoRedundancy = new CErrorInfoS();
        private List<CErrorInfo> m_lstDelayInfoNoRedundancy = new CErrorInfoS();
        private int m_iErrorCount = 0;
        private DateTime m_dtRecentError = DateTime.MinValue;
        private string m_sRecentError = string.Empty;

        public DateTime RecentErrorTime
        {
            get { return m_dtRecentError;}
            set { m_dtRecentError = value; }
        }

        public string RecentErrorMessage
        {
            get { return m_sRecentError;}
            set { m_sRecentError = value; }
        }

        public string PlcName
        {
            get { return m_sPlcName; }
            set { m_sPlcName = value; }
        }

        public int TotalErrorCount
        {
            get { return m_iErrorCount; }
            set { m_iErrorCount = value; }
        }

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        public int ErrorCount
        {
            get { return m_lstErrorInfo.Count(); }
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

        public List<CErrorInfo> lstDelayInfoNoRedundancy
        {
            get { return m_lstDelayInfoNoRedundancy; }
            set { m_lstDelayInfoNoRedundancy = value; }
        }

        public Dictionary<string, int> GetMergedCategoryErrorInfo()
        {
            Dictionary<string, CErrorInfoS> CatUnitErrorInfo = new Dictionary<string, CErrorInfoS>();
            Dictionary<string, int> CatMergeErrorInfo = new Dictionary<string, int>();
            CErrorInfoS cErrorInfoS = null;
            string sErrorMsg = "";

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                if (!cError.InputSymbolKey.Equals("") && !cError.IsVisible && !cError.DetailErrorMessage.Equals(""))
                {
                    sErrorMsg = cError.DetailErrorMessage;
                }
                else
                {
                    sErrorMsg = cError.ErrorMessage;
                }

                if (CatUnitErrorInfo.ContainsKey(sErrorMsg)) // cError.ErrorMessage => sErrorMsg
                {
                    cErrorInfoS = CatUnitErrorInfo[sErrorMsg];
                    cErrorInfoS.Add(cError);
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    CatUnitErrorInfo.Add(sErrorMsg, cErrorInfoS);
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
            string sErrorMsg = "";

            foreach (CErrorInfo cError in m_lstErrorInfo)
            {
                bOK = false;

                //16.09.19 추가(ErrorDetail Widget과 Grid 내용을 맞추기 위함)
                if (!cError.ErrorType.Equals("CycleOver"))
                {
                    if (!cError.InputSymbolKey.Equals("") && !cError.IsVisible && !cError.DetailErrorMessage.Equals(""))
                        sErrorMsg = cError.DetailErrorMessage;
                    else
                        sErrorMsg = cError.ErrorMessage;
                }
                else
                    sErrorMsg = cError.DetailErrorMessage;

                if (CatUnitErrorInfo.ContainsKey(sErrorMsg))  // cError.ErrorMessage => sErrorMsg
                {
                    cErrorInfoS = CatUnitErrorInfo[sErrorMsg];

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

                    CatUnitErrorInfo.Add(sErrorMsg, cErrorInfoS);
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
            m_lstDelayInfoNoRedundancy.Clear();

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

                        if (!cError.ErrorType.Equals("CycleOver"))
                            m_lstErrorInfoNoRedundancy.Add(cError);
                        else
                            m_lstDelayInfoNoRedundancy.Add(cError);
                    }
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(cError);

                    CatUnitErrorInfo.Add(cError.ErrorMessage, cErrorInfoS);

                    if (!cError.ErrorType.Equals("CycleOver"))
                        m_lstErrorInfoNoRedundancy.Add(cError);
                    else
                        m_lstDelayInfoNoRedundancy.Add(cError);
                }
            }

            CatUnitErrorInfo.Clear();
            CatUnitErrorInfo = null;
        }

        private void SetMergedCategoryError(Dictionary<string, CErrorInfoS> CatUnitErrorInfo, Dictionary<string, CErrorInfoS> CatMergeErrorInfo )
        {
            int iMean = -1;
            List<int> lstErrorCount = new List<int>();
            CErrorInfoS cETCErrorInfoS = new CErrorInfoS();

            foreach(CErrorInfoS cErrorS in CatUnitErrorInfo.Values)
                lstErrorCount.Add(cErrorS.Count);

            iMean = lstErrorCount.Sum()/lstErrorCount.Count;
            
            foreach (var who in CatUnitErrorInfo)
            {
                if(who.Value.Count >= iMean)
                    CatMergeErrorInfo.Add(who.Key, who.Value);
                else
                    cETCErrorInfoS.AddRange(who.Value);
            }

            if(cETCErrorInfoS.Count != 0)
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
