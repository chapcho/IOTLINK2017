using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    internal class CCyclePresentResultS : Dictionary<string, CCyclePresentResult>, IDisposable
    {

        #region Member Variables

        private int m_iTotalCycleCount = 0;

        #endregion


        #region Initialize/Dispose

        public CCyclePresentResultS()
        {

        }

        public CCyclePresentResultS(CTagS cTagS)
        {
            Initialize(cTagS);
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public int TotalCycleCount
        {
            get { return m_iTotalCycleCount; }
            set { m_iTotalCycleCount = value; }
        }

        public CCyclePresentResult this[int iIndex]
        {
            get { return GetResult(iIndex); }
        }

        #endregion


        #region Public Methods

        public void UpdatePresentResult(string sRecipe, string sKey, CTimeLogS cLogS)
        {
            if (this.ContainsKey(sKey) == false)
                return;

            CCyclePresentResult cResult = this[sKey];
            CCyclePresentUnit cUnit = new CCyclePresentUnit(sRecipe, 0);
			cUnit.LogCount = cLogS.Count; 
			
            DateTime dtStart = DateTime.MinValue;
            DateTime dtEnd = DateTime.MinValue;
            double dDuration = -1;
            CTimeLog cLog;
            bool bOn = false;
            for (int i = 0; i < cLogS.Count; i++)
            {
                cLog = cLogS[i];
                if (i == 0)
                    cUnit.FirstValue = cLog.Value;

                if (cLog.Value != 0)
                    cUnit.ActiveCount += 1;

                if (!bOn && cLog.Value == 1)
                {
                    bOn = true;
                    dtStart = cLog.Time;
                }
                else if (bOn && cLog.Value == 0)
                {
                    dtEnd = cLog.Time;
                    dDuration = dtEnd.Subtract(dtStart).TotalMilliseconds;

                    if(dDuration >= 0)
                        cUnit.DurationS.Add(dDuration);

                    bOn = false;
                }
            }

			cResult.Add(cUnit);
        }

        #endregion


        #region Private Methods

        private void Initialize(CTagS cTagS)
        {
            if (cTagS == null)
                return;

            CCyclePresentResult cCounter;
            CTag cTag;
            for (int i = 0; i < cTagS.Count; i++)
            {
                cTag = cTagS.ElementAt(i).Value;
                cCounter = new CCyclePresentResult(cTag);
                this.Add(cTag.Key, cCounter);
            }
        }

        protected CCyclePresentResult GetResult(int iIndex)
        {
            CCyclePresentResult cResult = null;

            if (this.Count > iIndex)
                cResult = this.ElementAt(iIndex).Value;

            return cResult;
        }

        #endregion
    }
}
