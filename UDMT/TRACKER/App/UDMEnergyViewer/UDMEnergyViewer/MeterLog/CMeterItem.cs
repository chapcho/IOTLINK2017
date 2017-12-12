using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CMeterItem : List<CMeterUnit>, IDisposable
    {
        #region Member Variables

        protected string m_sKey = "";//Channel
        protected string m_sUnitName = "";
        private DateTime m_dtFirst = DateTime.MinValue;
        private DateTime m_dtLast = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public CMeterItem()
        {

        }

        public CMeterItem(string sKey)
        {
            m_sKey = sKey;
        }


        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string UnitName
        {
            get { return m_sUnitName; }
            set { m_sUnitName = value; }
        }

        public DateTime FirstTime
        {
            get { return m_dtFirst; }
            set { m_dtFirst = value; }
        }

        public DateTime LastTime
        {
            get { return m_dtLast; }
            set { m_dtLast = value; }
        }

        #endregion


        #region Public Methods

        public void UpdateTimeRange()
        {
            m_dtFirst = DateTime.MinValue;
            m_dtLast = DateTime.MinValue;

            CMeterUnit cUnit;
            DateTime dtFirst = DateTime.MinValue;
            DateTime dtLast = DateTime.MinValue;
            for (int i = 0; i < this.Count; i++)
            {
                cUnit = this[i];
                if (cUnit.LogS.Count > 0)
                {
                    if (m_dtFirst == DateTime.MinValue)
                    {
                        m_dtFirst = cUnit.LogS[0].Time;
                        m_dtLast = cUnit.LogS.GetLastLog().Time;
                    }
                    else
                    {
                        dtFirst = cUnit.LogS[0].Time;
                        dtLast = cUnit.LogS.GetLastLog().Time;

                        if (m_dtFirst > dtFirst)
                            m_dtFirst = dtFirst;

                        if (dtLast > m_dtLast)
                            m_dtLast = dtLast;
                    }
                }
            }
        }

        #endregion


        #region Private Methods
        

        #endregion
    }
}
