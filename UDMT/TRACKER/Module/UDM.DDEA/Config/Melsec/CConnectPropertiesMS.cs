using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    [Serializable]
    public class CUSB : ICloneable
    {
        #region Member Veriables

        EMStationTypeMS m_emStationType = EMStationTypeMS.Host;
        EMCpuTypeMS m_emCPUType = EMCpuTypeMS.Q26UDEH;

        int m_iNetworkNumber = 0;
        int m_iStationNumber = 0;
        int m_iCpuValue = 0x94;
        int m_iThroughNetworkType = 1;
        int m_iIONumber = 0;                //Multi CPU
        int m_iUnitNumber = 0;
        int m_iDestinationIONumber = 0;     //기본값
        int m_iMultiDropChannelNumber = 0;  //기본값

        int m_iTimeOut = 1000;

        #endregion


        #region Iniitalize

        public CUSB()
        {

        }

        #endregion


        #region Properties

        public EMStationTypeMS StationType
        {
            get { return m_emStationType; }
            set { m_emStationType = value; }
        }

        public EMCpuTypeMS CPUType
        {
            get { return m_emCPUType; }
            set { m_emCPUType = value; }
        }

        public int CpuNumber
        {
            get { return m_iCpuValue; }
            set { m_iCpuValue = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int StationNumber
        {
            get { return m_iStationNumber; }
            set { m_iStationNumber = value; }
        }

        public int ThroughNetworkType
        {
            get { return m_iThroughNetworkType; }
            set { m_iThroughNetworkType = value; }
        }
        public int IONumber
        {
            get { return m_iIONumber; }
            set { m_iIONumber = value; }
        }

        public int UnitNumber
        {
            get { return m_iUnitNumber; }
        }

        public int DestinationIONumber
        {
            get { return m_iDestinationIONumber; }
            set { m_iDestinationIONumber = value; }
        }

        public int MultiDropChannelNumber
        {
            get { return m_iMultiDropChannelNumber; }
        }
        public int TimeOut
        {
            get { return m_iTimeOut; }
            set { m_iTimeOut = value; }
        }

        #endregion


        #region Public Method

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            CUSB usb = (CUSB)obj;

            if (StationType != usb.StationType) return false;
            if (CPUType != usb.CPUType) return false;
            if (CpuNumber != usb.CpuNumber) return false;
            if (NetworkNumber != usb.NetworkNumber) return false;
            if (StationNumber != usb.StationNumber) return false;
            if (TimeOut != usb.TimeOut) return false;
            if (IONumber != usb.IONumber) return false;
            if (DestinationIONumber != usb.DestinationIONumber) return false;
            if (UnitNumber != usb.UnitNumber) return false;
            if (MultiDropChannelNumber != usb.MultiDropChannelNumber) return false;
            if (ThroughNetworkType != usb.ThroughNetworkType) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public class CGXSim : ICloneable
    {
        #region Member Veriables

        EMStationTypeMS m_emStationType = EMStationTypeMS.Host;
        EMCpuTypeMS m_emCPUType = EMCpuTypeMS.Q26UDEH;

        int m_iNetworkNumber = 1;
        int m_iStationNumber = 1;
        int m_iCpuValue = 0x94;
        int m_iTimeOut = 1000;

        #endregion


        #region Iniitalize

        public CGXSim()
        {

        }

        #endregion


        #region Properties

        public EMStationTypeMS StationType
        {
            get { return m_emStationType; }
            set { m_emStationType = value; }
        }

        public EMCpuTypeMS CPUType
        {
            get { return m_emCPUType; }
            set { m_emCPUType = value; }
        }

        public int CpuNumber
        {
            get { return m_iCpuValue; }
            set { m_iCpuValue = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int StationNumber
        {
            get { return m_iStationNumber; }
            set { m_iStationNumber = value; }
        }

        public int TimeOut
        {
            get { return m_iTimeOut; }
            set { m_iTimeOut = value; }
        }

        #endregion


        #region Public Method

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            CGXSim sim = (CGXSim)obj;

            if (StationType != sim.StationType) return false;
            if (CPUType != sim.CPUType) return false;
            if (CpuNumber != sim.CpuNumber) return false;
            if (NetworkNumber != sim.NetworkNumber) return false;
            if (StationNumber != sim.StationNumber) return false;
            if (TimeOut != sim.TimeOut) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public class CMNet : ICloneable
    {
        #region Member Veriables

        EMStationTypeMS m_emStationType = EMStationTypeMS.Host;
        EMCpuTypeMS m_emCPUType = EMCpuTypeMS.Q26UDEH;

        int m_iNetworkNumber = 0;
        int m_iStationNumber = 0;
        int m_iCpuValue = 0x94;
        int m_iThroughNetworkType = 1;
        int m_iPortNumber = 1;              //Board No
        int m_iIONumber = 0;                //Multi CPU
        int m_iUnitNumber = 0;
        int m_iDestinationIONumber = 0;     //기본값
        int m_iMultiDropChannelNumber = 0;  //기본값

        #endregion
        

        #region Iniitalize

        public CMNet()
        {

        }

        #endregion


        #region Properties

        public EMStationTypeMS StationType
        {
            get { return m_emStationType; }
            set { m_emStationType = value; }
        }

        public EMCpuTypeMS CPUType
        {
            get { return m_emCPUType; }
            set { m_emCPUType = value; }
        }

        public int CpuNumber
        {
            get { return m_iCpuValue; }
            set { m_iCpuValue = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int StationNumber
        {
            get { return m_iStationNumber; }
            set { m_iStationNumber = value; }
        }

        public int IONumber
        {
            get { return m_iIONumber; }
            set { m_iIONumber = value; }
        }

        public int PortNumber
        {
            get { return m_iPortNumber; }
            set { m_iPortNumber = value; }
        }

        public int UnitNumber
        {
            get { return m_iUnitNumber; }
        }

        public int ThroughNetworkType
        {
            get { return m_iThroughNetworkType; }
            set { m_iThroughNetworkType = value; }
        }

        public int DestinationIONumber
        {
            get { return m_iDestinationIONumber; }
            set { m_iDestinationIONumber = value; }
        }

        public int MultiDropChannelNumber
        {
            get { return m_iMultiDropChannelNumber; }
        }

        #endregion


        #region Public Method

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            CMNet Mnet = (CMNet)obj;
            if (StationType != Mnet.StationType) return false;
            if (StationNumber != Mnet.StationNumber) return false;
            if (CPUType != Mnet.CPUType) return false;
            if (CpuNumber != Mnet.CpuNumber) return false;
            if (NetworkNumber != Mnet.NetworkNumber) return false;
            if (StationNumber != Mnet.StationNumber) return false;
            if (IONumber != Mnet.IONumber) return false;
            if (PortNumber != Mnet.PortNumber) return false;
            if (DestinationIONumber != Mnet.DestinationIONumber) return false;
            if (ThroughNetworkType != Mnet.ThroughNetworkType) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public class CENet : ICloneable
    {
        #region Memeber Veriables

        EMStationTypeMS m_emStationType = EMStationTypeMS.Host;
        EMCpuTypeMS m_emCPUType = EMCpuTypeMS.Q26UDEH;
        EMENetModuleTypeMS m_emModule = EMENetModuleTypeMS.QJ71E71;
        EMENetProtocolTypeMS m_emProtocol = EMENetProtocolTypeMS.TCP;
        EMENetPacketTypeMS m_emPacket = EMENetPacketTypeMS.Binary;

        string m_sIPAddress = string.Empty;

        int m_iCpuValue = 0x94;
        int m_iNetworkNumber = 0;
        int m_iPCStationNumber = 0;
        int m_iPLCStationNumber = 0;
        int m_iPortNumber = 5001;
        int m_iConnectionUnitNumber = 0;        //이것을 1로 설정하면 Other Station동작함.
        int m_iIONumber = 0;                //Multi CPU

        int m_iTimeOut = 1000;

        #endregion
        

        #region Iniitalize

        public CENet()
        {

        }

        #endregion


        #region Properties

        public EMStationTypeMS StationType
        {
            get { return m_emStationType; }
            set { m_emStationType = value; }
        }

        public EMCpuTypeMS CPUType
        {
            get { return m_emCPUType; }
            set { m_emCPUType = value; }
        }

        public EMENetModuleTypeMS ModuleType
        {
            get { return m_emModule; }
            set { m_emModule = value; }
        }

        public EMENetProtocolTypeMS ProtocolType
        {
            get { return m_emProtocol; }
            set { m_emProtocol = value; }
        }

        public EMENetPacketTypeMS PacketType
        {
            get { return m_emPacket; }
            set { m_emPacket = value; }
        }

        public string IPAddress
        {
            get { return m_sIPAddress; }
            set { m_sIPAddress = value; }
        }

        public int CpuNumber
        {
            get { return m_iCpuValue; }
            set { m_iCpuValue = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int PC_StationNumber
        {
            get { return m_iPCStationNumber; }
            set { m_iPCStationNumber = value; }
        }

        public int PLC_StationNumber
        {
            get { return m_iPLCStationNumber; }
            set { m_iPLCStationNumber = value; }
        }

        public int PortNumber
        {
            get { return m_iPortNumber; }
            set { m_iPortNumber = value; }
        }

        public int ConnectionUnitNumber
        {
            get { return m_iConnectionUnitNumber; }
            set { m_iConnectionUnitNumber = value; }
        }

        public int TimeOut
        {
            get { return m_iTimeOut; }
            set { m_iTimeOut = value; }
        }

        public int IONumber
        {
            get { return m_iIONumber; }
            set { m_iIONumber = value; }
        }

        #endregion


        #region Public Method

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            CENet Ether = (CENet)obj;

            if (StationType != Ether.StationType) return false;
            if (CPUType != Ether.CPUType) return false;
            if (ModuleType != Ether.ModuleType) return false;
            if (ProtocolType != Ether.ProtocolType) return false;
            if (PacketType != Ether.PacketType) return false;
            if (IPAddress != Ether.IPAddress) return false;
            if (CpuNumber != Ether.CpuNumber) return false;
            if (NetworkNumber != Ether.NetworkNumber) return false;
            if (PC_StationNumber != Ether.PC_StationNumber) return false;
            if (PLC_StationNumber != Ether.PLC_StationNumber) return false;
            if (PortNumber != Ether.PortNumber) return false;
            if (ConnectionUnitNumber != Ether.ConnectionUnitNumber) return false;
            if (TimeOut != Ether.TimeOut) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public class CGOT : ICloneable
    {
        #region Member Veriables

        EMStationTypeMS m_emStationType = EMStationTypeMS.Host;
        EMCpuTypeMS m_emCPUType = EMCpuTypeMS.Q26UDEH;

        int m_iNetworkNumber = 0;
        int m_iStationNumber = 0;
        int m_iCpuValue = 0x94;
        int m_iIONumber = 0;                //Multi CPU
        int m_iGotTransparentPcif = 1;      //1 = USB
        int m_iGotTransparentPlcif = 90;    //90 = Bus
        int m_iTimeOut = 1000;

        #endregion


        #region Iniitalize

        public CGOT()
        {

        }

        #endregion


        #region Properties

        public EMStationTypeMS StationType
        {
            get { return m_emStationType; }
            set { m_emStationType = value; }
        }

        public EMCpuTypeMS CPUType
        {
            get { return m_emCPUType; }
            set { m_emCPUType = value; }
        }

        public int CpuNumber
        {
            get { return m_iCpuValue; }
            set { m_iCpuValue = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int StationNumber
        {
            get { return m_iStationNumber; }
            set { m_iStationNumber = value; }
        }

        public int GotTransparentPcif
        {
            get { return m_iGotTransparentPcif; }
            set { m_iGotTransparentPcif = value; }
        }
        public int IONumber
        {
            get { return m_iIONumber; }
            set { m_iIONumber = value; }
        }

        public int GotTransparentPlcif
        {
            get { return m_iGotTransparentPlcif; }
            set { m_iGotTransparentPlcif = value; }
        }

        public int TimeOut
        {
            get { return m_iTimeOut; }
            set { m_iTimeOut = value; }
        }

        #endregion


        #region Public Method

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            CGOT got = (CGOT)obj;

            if (StationType != got.StationType) return false;
            if (CPUType != got.CPUType) return false;
            if (CpuNumber != got.CpuNumber) return false;
            if (NetworkNumber != got.NetworkNumber) return false;
            if (StationNumber != got.StationNumber) return false;
            if (TimeOut != got.TimeOut) return false;
            if (IONumber != got.IONumber) return false;
            if (GotTransparentPcif != got.GotTransparentPcif) return false;
            if (GotTransparentPlcif != got.GotTransparentPlcif) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public class CMxCom4
    {
        #region Member Variables

        protected int _iConnectionNumber = -1;
        protected string _sName = "";
        protected string _sRegistryPath = "";
        protected string _sConnectionType = "";
        protected EMMelsecCpu _emCpuType = EMMelsecCpu.CPU_BOARD;
        protected int _iProtocolNumer = 0;
        protected int _iNetworkNumber = 0;
        protected int _iStationNumber = 0;
        protected string _sComment = "";

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public int ConnectionNumber
        {
            get { return _iConnectionNumber; }
            set { _iConnectionNumber = value; }
        }

        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        public string RegistryPath
        {
            get { return _sRegistryPath; }
            set { _sRegistryPath = value; }
        }

        public string ConnetctionTypeString
        {
            get { return _sConnectionType; }
            set { _sConnectionType = value; }
        }

        public EMMelsecCpu CpuType
        {
            get { return _emCpuType; }
            set { _emCpuType = value; }
        }

        public int ProtocolNumber
        {
            get { return _iProtocolNumer; }
            set { _iProtocolNumer = value; }
        }

        public int NetworkNumber
        {
            get { return _iNetworkNumber; }
            set { _iNetworkNumber = value; }
        }

        public int StationNumber
        {
            get { return _iStationNumber; }
            set { _iStationNumber = value; }
        }

        public string Comment
        {
            get { return _sComment; }
            set { _sComment = value; }
        }

        #endregion


        #region Public Method

        public void SetDetailInfo()
        {
            string  sStecmOpen = _sRegistryPath + "\\STECMOPEN";
            string sTEL = _sRegistryPath + "\\TEL";
            string sUTL = _sRegistryPath + "\\UTL";


            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(sStecmOpen);
            int iProtocolNum = (int)regKey.GetValue("ProtocolType");

            switch (iProtocolNum)
            {
                case 0x04: _sConnectionType = "Serial port"; break;
                case 0x0D: _sConnectionType = "USB port"; break;
                case 0x05: _sConnectionType = "TCP/IP"; break;
                case 0x08: _sConnectionType = "UDP/IP"; break;
                case 0x0F: _sConnectionType = "MELSECNET/H board"; break;
                case 0x14: _sConnectionType = "CC-Link IE Controller Network board"; break;
                case 0x15: _sConnectionType = "CC-Link IE Field Network board"; break;
                case 0x07: _sConnectionType = "CC-Link"; break;
                case 0x0E: _sConnectionType = "serial port and modem"; break;
                case 0x0A: _sConnectionType = "TEL"; break;
                case 0x10: _sConnectionType = "Q series bus"; break;
                case 0x13: _sConnectionType = "USB port and GOT"; break;
                case 0x06: _sConnectionType = "shared memory server (Simulator)"; break;
                default: _sConnectionType = "Not Found"; break;
            }
            int iCpuNumber = (int)regKey.GetValue("CpuType");
            foreach (var value in Enum.GetValues(typeof(EMMelsecCpu)))
            {
                if (iCpuNumber == (int)value)
                {
                    _emCpuType = (EMMelsecCpu)value;
                    break;
                }
            }
            _iNetworkNumber = (int)regKey.GetValue("NetworkNumber");
            _iStationNumber = (int)regKey.GetValue("StationNumber");

            regKey = Registry.LocalMachine.OpenSubKey(sUTL);
            _sComment = (string)regKey.GetValue("Comment");
        }
        #endregion
    }
}
