using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    public class CMeterData
    {
        protected DateTime m_dtTime = DateTime.MinValue;
        protected string m_sDeviceInfo = string.Empty;
        protected EMMeterModule m_emModel = EMMeterModule.Accura3300S;
        protected byte[] m_baData = null;

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

        public string DeviceInfo
        {
            get { return m_sDeviceInfo; }
            set { m_sDeviceInfo = value; }
        }

        public EMMeterModule DeviceModel
        {
            get { return m_emModel; }
            set { m_emModel = value; }
        }

        #endregion
    }
}
