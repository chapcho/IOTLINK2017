using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace USB_DataRead
{
    public class CUSBDeviceInfo
    {
        #region Member Variables

        private string _DeviceID = string.Empty;
        private string _PNPDeviceID = string.Empty;
        private string _Description = string.Empty;

        #endregion


        #region Initialize

        public CUSBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            _DeviceID = deviceID;
            _PNPDeviceID = pnpDeviceID;
            _DeviceID = description;
        }

        #endregion


        #region Properties

        #endregion


        #region Public Method

        public List<CUSBDeviceInfo> GetUSBDeviceList()
        {
            List<CUSBDeviceInfo> lstDevice = new List<CUSBDeviceInfo>();

            ManagementObjectCollection collection = null;

            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))

                collection = searcher.Get();

            foreach (var device in collection)   //반환된 값을 List에 저장
            {

                lstDevice.Add(new CUSBDeviceInfo(

                (string)device.GetPropertyValue("DeviceID"),

                (string)device.GetPropertyValue("PNPDeviceID"),

                (string)device.GetPropertyValue("Description")

                ));
            }

            return lstDevice;
        }

        #endregion
    }
}
