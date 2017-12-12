using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.General.Serialize;

namespace UDMTrackerSimple
{
    /// <summary>
    /// Key = CPlcProc Name
    /// </summary>
    [Serializable]
    public class CLineInfoS : Dictionary<string, CLineInfo>
    {
        #region Member Variables

        public event UEventHandlerLineInfoValueChanged UEventLineInfoValueChanged = null;

        #endregion

        #region Initialize

        public CLineInfoS()
        {

        }

        protected CLineInfoS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Properties

        #endregion

        #region Public Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns>null이면 실패</returns>
        public CLineInfo OpenLineInfo(string sPath, string sID)
        {
            CLineInfoS cLineInfoS = null;
            CLineInfo cLineInfo = null;
            CNetSerializer cSerializer = new CNetSerializer(); ;
            try
            {
                cLineInfoS = (CLineInfoS)(cSerializer.Read(sPath));
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                cLineInfoS = null;
            }

            cSerializer.Dispose();
            cSerializer = null;
            if (cLineInfoS != null)
            {
                if (cLineInfoS.ContainsKey(sID))
                    cLineInfo = cLineInfoS[sID];
            }
            return cLineInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sID"></param>
        /// <returns>null이면 못찾음.</returns>
        public CLineInfo GetLineInfo(string sID)
        {
            CLineInfo cLineInfo = null;
            if (this.ContainsKey(sID))
                cLineInfo = this[sID];

            return cLineInfo;
        }

        public List<string> AllSymbolListKeyList()
        {
            List<string> lstKeyList = new List<string>();

            foreach(CLineInfo cInfo in this.Values)
            {
                if(cInfo.ReadSymbolListKeyList != null)
                    lstKeyList.AddRange(cInfo.ReadSymbolListKeyList);
            }

            return lstKeyList;
        }

        public void ValueChanged(List<CLineInfoTag> lstChangedTag)
        {
            foreach (CLineInfoTag cLineTag in lstChangedTag)
            {
                foreach(CLineInfo cInfo in this.Values)
                {
                    if(cInfo.ReadSymbolListKeyList.Contains(cLineTag.Tag.Key))
                    {
                        if (cInfo.LimitSetCount.Tag.Key == cLineTag.Tag.Key)
                            cInfo.LimitSetCount = cLineTag;

                        else if (cInfo.NowCount.Tag.Key == cLineTag.Tag.Key)
                            cInfo.NowCount = cLineTag;

                        else if (cInfo.GoodCount.Tag.Key == cLineTag.Tag.Key)
                            cInfo.GoodCount = cLineTag;

                        else if (cInfo.NGCount.Tag.Key == cLineTag.Tag.Key)
                            cInfo.NGCount = cLineTag;
                    }
                }
            }

            if (UEventLineInfoValueChanged != null)
                UEventLineInfoValueChanged(null);
        }

        #endregion
    }
}