using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.General.Threading;

namespace UDMEnergyViewer
{
    public class CMeterData : IDisposable
    {

        #region Member Variables

        protected DateTime m_dtTime = DateTime.MinValue;
        protected byte[] m_baData = null;

        #endregion


        #region Initialize/Dispose

        public CMeterData()
        {

        }

        public CMeterData(DateTime dtTime, byte[] baData)
        {
            m_dtTime = dtTime;
            m_baData = baData;
        }

        public void Dispose()
        {
            m_baData = null;
        }

        #endregion


        #region Public Properties

        public DateTime Time
        {
            get { return m_dtTime; }
            set { m_dtTime = value; }
        }

        public byte[] Data
        {
            get { return m_baData; }
            set { m_baData = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
