using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc
{
    public class CMonitorGroupS : Dictionary<string, CMonitorGroup>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CMonitorGroupS(CGroupS cGroupS)
        {
            CGroup cGroup;
            if (cGroupS != null)
            {
                CMonitorGroup cMonitorGroup;
                for (int i = 0; i < cGroupS.Count; i++)
                {
                    cGroup = cGroupS[i];
                    cMonitorGroup = new CMonitorGroup(cGroup);

                    this.Add(cGroup.Key, cMonitorGroup);
                }
            }
        }

        public void Dispose()
        {
            this.Clear();
        }

        #endregion


        #region Public Properties

        public CMonitorGroup this[int iIndex]
        {
            get { return GetMonitorGroup(iIndex); }
        }

        #endregion


        #region Public Methods

        public CGroupLogS AddLog(CTimeLog cLog)
        {
            if (cLog == null)
                return null;
            
            CGroupLogS cTotalGroupLogS = null;
            CGroupLogS cGroupLogS = null;
            CMonitorGroup cMonitorGroup;
            for (int i = 0; i < this.Count;i++ )
            {
                cMonitorGroup = this[i];
                cGroupLogS = cMonitorGroup.AddLog(cLog);
                if (cGroupLogS != null && cGroupLogS.Count > 0)
                {
                    if (cTotalGroupLogS == null)
                        cTotalGroupLogS = new CGroupLogS();

                    cTotalGroupLogS.AddRange(cGroupLogS);
                }
            }

            return cTotalGroupLogS;
        }

        public CGroupLogS CheckTimeOut(DateTime dtCurrent)
        {
            CGroupLogS cGroupLogS = null;
            CGroupLog cGroupLog = null;

            CMonitorGroup cMonitorGroup;
            for (int i = 0; i < this.Count; i++)
            {
                cMonitorGroup = this[i];
                cGroupLog = cMonitorGroup.CheckCycleTimeOut(dtCurrent);
                if (cGroupLog != null)
                {
                    if (cGroupLogS == null)
                        cGroupLogS = new CGroupLogS();

                    cGroupLogS.Add(cGroupLog);
                }
            }

            return cGroupLogS;
        }

        #endregion

        
        #region Private Methods

        protected CMonitorGroup GetMonitorGroup(int iIndex)
        {
            CMonitorGroup cGroup = null;

            if (this.Count > iIndex)
                cGroup = this.ElementAt(iIndex).Value;

            return cGroup;
        }

        #endregion
    }
}
