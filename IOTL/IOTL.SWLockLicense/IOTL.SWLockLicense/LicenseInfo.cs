using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOTL.SWLockLicense
{
    [Serializable]
    internal class LicenseInfo : IDisposable
    {
        #region Member Variables

		private bool m_bLicensed = false;
        private string m_sProduct = "";
		private string m_sActivationCode = "";
		private string m_sActivationKey = "";
        private string m_sProcessModel = "";
        private string m_sProcessID = "";
        private string m_sHardDiskModel = "";
        private string m_sHardDiskID = "";
        private string m_sNetworkModel = "";
        private string m_sNetworkMAC = "";
        private bool m_bDemo = false;        
        private int m_iDemoDays = 10;
        private int m_iDemoHours = 1;
        private int m_nUsingDays = 0;
        private double m_nRemainsMin = 60 * 24 * 10;
        private DateTime m_dtLicensed = DateTime.MinValue;
        private DateTime m_dtExcute = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public LicenseInfo()
        {

        }

        public void Dispose()
        {            
            
        }

        #endregion


        #region Public Properties

		internal bool IsLicensed
		{
			get { return m_bLicensed; }
			set { m_bLicensed = value; }
		}
        internal string Product
        {
            get { return m_sProduct; }
            set { m_sProduct = value; }
        }

		internal string ActivationCode
		{
			get { return m_sActivationCode; }
			set { m_sActivationCode = value; }
		}

		internal string ActivationKey
		{
			get { return m_sActivationKey; }
			set { m_sActivationKey = value; }
		}

        internal string ProcessModel
        {
            get { return m_sProcessModel; }
            set { m_sProcessModel = value; }
        }

        internal string ProcessID
        {
            get { return m_sProcessID; }
            set { m_sProcessID = value; }
        }

        internal string HardDiskModel
        {
            get { return m_sHardDiskModel; }
            set { m_sHardDiskModel = value; }
        }

        internal string HardDiskID
        {
            get { return m_sHardDiskID; }
            set { m_sHardDiskID = value; }
        }

        internal string NetworkModel
        {
            get { return m_sNetworkModel; }
            set { m_sNetworkModel = value; }
        }

        internal string MacAddress
        {
            get { return m_sNetworkMAC; }
            set { m_sNetworkMAC = value; }
        }

        internal bool IsDemo
        {
            get { return m_bDemo; }
            set { m_bDemo = value; }
        }

        internal DateTime LicensedTime
        {
            get { return m_dtLicensed; }
            set { m_dtLicensed = value; }
        }

        internal DateTime ExcuteTime
        {
            get { return m_dtExcute; }
            set { m_dtExcute = value; }
        }

        internal int DemoDays
        {
            get { return m_iDemoDays; }
            set { m_iDemoDays = value; }
        }

        internal int DemoHours
        {
            get { return m_iDemoHours; }
            set { m_iDemoHours = value; }
        }

        internal double RemainsMinutes
        {
            get { return m_nRemainsMin; }
            set { m_nRemainsMin = value; }
        }

        internal int UsingDays
        {
            get { return m_nUsingDays; }
            set { m_nUsingDays = value; }
        }

        #endregion

    }
}
