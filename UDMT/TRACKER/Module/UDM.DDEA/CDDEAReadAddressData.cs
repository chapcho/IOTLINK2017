using System;

namespace UDM.DDEA
{
    public class CDDEAReadAddressData : IDisposable, ICloneable
    {
        #region Member Variables

        protected string m_sAddress = string.Empty;
        protected int m_iAddressLength = 1;
        protected short m_iValue = -1;
        protected string m_sValue = "";
        protected int m_iDWordValue = -1;
        protected DateTime m_dtRisingTime = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public CDDEAReadAddressData()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public short Value
        {
            get { return m_iValue; }
            set { m_iValue = value; }
        }

        public int DWordValue
        {
            get { return m_iDWordValue; }
            set { m_iDWordValue = value; }
        }

        public int AddressLength
        {
            get { return m_iAddressLength; }
            set { m_iAddressLength = value; }
        }

        public string SValue
        {
            get { return m_sValue; }
            set { m_sValue = value; }
        }

        public DateTime RisingTime
        {
            get { return m_dtRisingTime; }
            set { m_dtRisingTime = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CDDEAReadAddressData oData = new CDDEAReadAddressData();

            oData.Address = m_sAddress;
            oData.Value = m_iValue;
            oData.DWordValue = m_iDWordValue;
            oData.AddressLength = m_iAddressLength;
            oData.RisingTime = m_dtRisingTime;

            return oData;
        }

        #endregion
    }
}
