using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CMeterItemS : Dictionary<string, CMeterItem>, IDisposable
    {

        #region Member Variables

        private DateTime m_dtFirst = DateTime.MinValue;
        private DateTime m_dtLast = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public CMeterItemS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CMeterItemS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

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

            CMeterItem cItem;
            for (int i = 0; i < this.Count; i++)
            {
                cItem = this.ElementAt(i).Value;
                if (cItem.FirstTime != DateTime.MinValue)
                {
                    if (m_dtFirst == DateTime.MinValue)
                    {
                        m_dtFirst = cItem.FirstTime;
                        m_dtLast = cItem.LastTime;
                    }
                    else
                    {
                        if (m_dtFirst > cItem.FirstTime)
                            m_dtFirst = cItem.FirstTime;

                        if (cItem.LastTime > m_dtLast)
                            m_dtLast = cItem.LastTime;
                    }
                }
            }
        }

        #endregion


        #region Private Methdos


        #endregion
    }
}
