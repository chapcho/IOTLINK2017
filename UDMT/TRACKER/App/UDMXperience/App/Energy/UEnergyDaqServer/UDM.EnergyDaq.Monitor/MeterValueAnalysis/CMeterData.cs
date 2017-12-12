using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;

namespace UDM.EnergyDaq.Monitor
{
    public class CMeterData
    {
        protected DateTime m_dtTime = DateTime.MinValue;
        protected string m_sDeviceInfo = string.Empty;
        protected EMMeterModel m_emModel = EMMeterModel.Accura3300S;
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

        public EMMeterModel DeviceModel
        {
            get { return m_emModel; }
            set { m_emModel = value; }
        }

        #endregion
    }
}
