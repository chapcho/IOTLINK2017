using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CTagItemS : Dictionary<string, CTagItem>, IDisposable
    {
        #region Member Variables

        private DateTime m_dtFirst = DateTime.MinValue;
        private DateTime m_dtLast = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public CTagItemS()
        {

        }
        
        public void Dispose()
        {

        }

        protected CTagItemS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties

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

            CTagItem cItem;
            DateTime dtFirst = DateTime.MinValue;
            DateTime dtLast = DateTime.MinValue;
            for(int i=0;i<this.Count;i++)
            {
                cItem = this.ElementAt(i).Value;
                if (cItem.LogS.Count > 0)
                {
                    if(m_dtFirst == DateTime.MinValue)
                    {
                        m_dtFirst = cItem.LogS[0].Time;
                        m_dtLast = cItem.LogS.GetLastLog().Time;
                    }
                    else
                    {
                        dtFirst = cItem.LogS[0].Time;
                        dtLast = cItem.LogS.GetLastLog().Time;

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
