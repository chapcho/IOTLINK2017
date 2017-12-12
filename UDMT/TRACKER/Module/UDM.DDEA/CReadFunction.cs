using System;
using System.Collections.Generic;
using UDM.Common;

namespace UDM.DDEA
{
    public class CReadFunction
    {
        #region Member Variables

        protected CDDEAConfigMS m_cConfigMS = null;

        #region Melsec Mx Component V3 PLC Dll

        protected ACTBOARDLib.ActMnetHBD m_actMelsecnet = null;
        protected ACTBOARDLib.ActMnetGBD m_actMnetG = null;
        protected ACTLLTLib.ActLLT m_actGXSim = null;
        protected ACTPCUSBLib.ActQCPUQUSB m_QCPUQUSB = null;
        protected ACTGOTLib.ActGOTTRSP m_actGotTrsp = null;

        protected ACTETHERLib.ActQJ71E71TCP m_QJ71E71TCP = null;
        protected ACTETHERLib.ActQJ71E71UDP m_QJ71E71UDP = null;

        protected ACTETHERLib.ActAJ71E71TCP m_AJ71E71TCP = null;
        protected ACTETHERLib.ActAJ71E71UDP m_AJ71E71UDP = null;

        protected ACTETHERLib.ActAJ71QE71TCP m_AJ71QE71TCP = null;
        protected ACTETHERLib.ActAJ71QE71UDP m_AJ71QE71UDP = null;

        protected ACTETHERLib.ActQNUDECPUTCP m_QNUDECPUTCP = null;        //CPU에 달린 Ethernet Port
        protected ACTETHERLib.ActQNUDECPUUDP m_QNUDECPUUDP = null;        //CPU에 달린 Ethernet Port

        #endregion

        #region Melsec Mx Component V4 PLC Dll

        ActUtlTypeLib.ActUtlType _actUtil = null;

        #endregion

        protected bool m_bConnect = false;
        protected EMPlcConnettionType _emPlcType = EMPlcConnettionType.Melsec_Normal;
        protected List<string> m_lstReadSymbolList = new List<string>();
        protected List<int> m_lstReadSymbolCount = new List<int>();

        protected int m_iReadErrorCode = -1;

        #endregion


        #region Initialize

        public CReadFunction(CDDEAConfigMS cConfig, EMPlcConnettionType emType)
        {
            m_cConfigMS = cConfig;
            _emPlcType = emType;
        }

        #endregion


        #region Properties

        public bool IsConnection
        {
            get { return m_bConnect; }
        }

        public int ReadErrorCode
        {
            get { return m_iReadErrorCode; }
        }

        #endregion


        #region Private Method

        public CTagS ChangeFromListSymbolToSymbolS(List<CTag> lstSymbol)
        {
            CTagS cTagS = new CTagS();

            foreach (CTag sym in lstSymbol)
            {
                cTagS.Add(sym.Key, sym);
            }

            return cTagS;
        }

        public List<string> ChangeFromSymbolSToAddressList(CTagS cTagS)
        {
            List<string> lstResult = new List<string>();

            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                lstResult.Add(cTag.Address);
            }

            return lstResult;
        }


        #endregion


        #region Public Method


        /// <summary>
        /// Project 그룹에서 DDE 설정값을 적용하여 통신연결
        /// </summary>
        /// <returns>연결되면 True</returns>
        public bool Connect()
        {
            int iResult = -1;
            try
            {
                if (_emPlcType == EMPlcConnettionType.Melsec_Normal)
                {
                    #region Melsec Normal Mx Component V3

                    if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetH)
                    {
                        m_actMelsecnet = new ACTBOARDLib.ActMnetHBD();
                        m_actMelsecnet.ActNetworkNumber = m_cConfigMS.MNet.NetworkNumber;
                        m_actMelsecnet.ActStationNumber = m_cConfigMS.MNet.StationNumber;
                        m_actMelsecnet.ActIONumber = m_cConfigMS.MNet.IONumber;                              //Single Type설정
                        m_actMelsecnet.ActCpuType = m_cConfigMS.MNet.CpuNumber;
                        m_actMelsecnet.ActPortNumber = m_cConfigMS.MNet.PortNumber;                          //기본값
                        m_actMelsecnet.ActUnitNumber = m_cConfigMS.MNet.UnitNumber;                          //기본값
                        m_actMelsecnet.ActDestinationIONumber = m_cConfigMS.MNet.DestinationIONumber;        //기본값
                        m_actMelsecnet.ActMultiDropChannelNumber = m_cConfigMS.MNet.MultiDropChannelNumber;  //기본값

                        iResult = Convert.ToInt32(m_actMelsecnet.Open());

                    }
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetG)
                    {
                        m_actMnetG = new ACTBOARDLib.ActMnetGBD();
                        m_actMnetG.ActNetworkNumber = m_cConfigMS.MNet.NetworkNumber;
                        m_actMnetG.ActStationNumber = m_cConfigMS.MNet.StationNumber;
                        m_actMnetG.ActIONumber = m_cConfigMS.MNet.IONumber;                              //Single Type설정
                        m_actMnetG.ActCpuType = m_cConfigMS.MNet.CpuNumber;
                        m_actMnetG.ActPortNumber = m_cConfigMS.MNet.PortNumber;                          //기본값
                        m_actMnetG.ActUnitNumber = m_cConfigMS.MNet.UnitNumber;                          //기본값
                        m_actMnetG.ActDestinationIONumber = m_cConfigMS.MNet.DestinationIONumber;        //기본값
                        m_actMnetG.ActMultiDropChannelNumber = m_cConfigMS.MNet.MultiDropChannelNumber;  //기본값

                        iResult = Convert.ToInt32(m_actMnetG.Open());
                    }
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.USB)
                    {
                        m_QCPUQUSB = new ACTPCUSBLib.ActQCPUQUSB();
                        m_QCPUQUSB.ActCpuType = m_cConfigMS.USB.CpuNumber;
                        m_QCPUQUSB.ActTimeOut = m_cConfigMS.USB.TimeOut;
                        m_QCPUQUSB.ActThroughNetworkType = m_cConfigMS.USB.ThroughNetworkType;
                        m_QCPUQUSB.ActNetworkNumber = m_cConfigMS.USB.NetworkNumber;
                        m_QCPUQUSB.ActStationNumber = m_cConfigMS.USB.StationNumber;
                        m_QCPUQUSB.ActDestinationIONumber = 0;
                        m_QCPUQUSB.ActIONumber = m_cConfigMS.USB.IONumber;

                        iResult = m_QCPUQUSB.Open();
                    }
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GXSim)
                    {
                        m_actGXSim = new ACTLLTLib.ActLLT();
                        m_actGXSim.ActCpuType = m_cConfigMS.GxSim.CpuNumber;
                        m_actGXSim.ActTimeOut = m_cConfigMS.GxSim.TimeOut;

                        iResult = m_actGXSim.Open();
                    }
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.Ethernet)
                    {
                        #region Ethernet 설정

                        if (m_cConfigMS.ENet.ProtocolType == EMENetProtocolTypeMS.TCP)
                        {
                            if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)
                            {
                                m_QJ71E71TCP = new ACTETHERLib.ActQJ71E71TCP();
                                m_QJ71E71TCP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_QJ71E71TCP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_QJ71E71TCP.ActStationNumber = m_cConfigMS.ENet.PLC_StationNumber;
                                m_QJ71E71TCP.ActConnectUnitNumber = m_cConfigMS.ENet.ConnectionUnitNumber;
                                m_QJ71E71TCP.ActNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QJ71E71TCP.ActSourceNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QJ71E71TCP.ActSourceStationNumber = m_cConfigMS.ENet.PC_StationNumber;
                                m_QJ71E71TCP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_QJ71E71TCP.Open();

                            }
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                            {
                                m_AJ71E71TCP = new ACTETHERLib.ActAJ71E71TCP();
                                m_AJ71E71TCP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_AJ71E71TCP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_AJ71E71TCP.ActStationNumber = m_cConfigMS.ENet.PLC_StationNumber;
                                m_AJ71E71TCP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_AJ71E71TCP.Open();
                            }
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                            {
                                m_AJ71QE71TCP = new ACTETHERLib.ActAJ71QE71TCP();
                                m_AJ71QE71TCP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_AJ71QE71TCP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_AJ71QE71TCP.ActStationNumber = m_cConfigMS.ENet.PLC_StationNumber;
                                m_AJ71QE71TCP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_AJ71QE71TCP.Open();
                            }
                            else
                            {
                                m_QNUDECPUTCP = new ACTETHERLib.ActQNUDECPUTCP();

                                m_QNUDECPUTCP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_QNUDECPUTCP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_QNUDECPUTCP.ActStationNumber = m_cConfigMS.ENet.PC_StationNumber;
                                m_QNUDECPUTCP.ActNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QNUDECPUTCP.ActIONumber = m_cConfigMS.ENet.IONumber;
                                m_QNUDECPUTCP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_QNUDECPUTCP.Open();
                            }
                        }
                        else
                        {
                            if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)                      //확인완료
                            {
                                m_QJ71E71UDP = new ACTETHERLib.ActQJ71E71UDP();
                                m_QJ71E71UDP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_QJ71E71UDP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_QJ71E71UDP.ActPortNumber = m_cConfigMS.ENet.PortNumber;
                                m_QJ71E71UDP.ActConnectUnitNumber = m_cConfigMS.ENet.ConnectionUnitNumber;
                                m_QJ71E71UDP.ActNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QJ71E71UDP.ActStationNumber = m_cConfigMS.ENet.PLC_StationNumber;
                                m_QJ71E71UDP.ActSourceNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QJ71E71UDP.ActSourceStationNumber = m_cConfigMS.ENet.PC_StationNumber;
                                m_QJ71E71UDP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_QJ71E71UDP.Open();
                            }
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                            {
                                m_AJ71E71UDP = new ACTETHERLib.ActAJ71E71UDP();
                                m_AJ71E71UDP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_AJ71E71UDP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                //m_AJ71E71UDP.ActPortNumber = m_cDDEConfig.Port;                             //Port Number.
                                //m_AJ71E71UDP.ActPacketType = cDDEConfig.ENet.PacketType;
                                //m_AJ71E71UDP.ActStationNumber = cDDEConfig.StationNumber;                 //
                                m_AJ71E71UDP.ActTimeOut = m_cConfigMS.ENet.TimeOut;
                                iResult = m_AJ71E71UDP.Open();
                            }
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                            {
                                m_AJ71QE71UDP = new ACTETHERLib.ActAJ71QE71UDP();
                                m_AJ71QE71UDP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_AJ71QE71UDP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_AJ71QE71UDP.ActPortNumber = m_cConfigMS.ENet.PortNumber;
                                m_AJ71QE71UDP.ActConnectUnitNumber = m_cConfigMS.ENet.ConnectionUnitNumber;
                                m_AJ71QE71UDP.ActNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_AJ71QE71UDP.ActStationNumber = m_cConfigMS.ENet.PLC_StationNumber;
                                m_AJ71QE71UDP.ActSourceNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_AJ71QE71UDP.ActSourceStationNumber = m_cConfigMS.ENet.PC_StationNumber;
                                m_AJ71QE71UDP.ActTimeOut = m_cConfigMS.ENet.TimeOut;

                                iResult = m_AJ71QE71UDP.Open();
                            }
                            else
                            {
                                m_QNUDECPUUDP = new ACTETHERLib.ActQNUDECPUUDP();
                                m_QNUDECPUUDP.ActCpuType = m_cConfigMS.ENet.CpuNumber;
                                m_QNUDECPUUDP.ActHostAddress = m_cConfigMS.ENet.IPAddress;
                                m_QNUDECPUUDP.ActStationNumber = m_cConfigMS.ENet.PC_StationNumber;                 //255
                                m_QNUDECPUUDP.ActTimeOut = m_cConfigMS.ENet.TimeOut;
                                m_QNUDECPUUDP.ActNetworkNumber = m_cConfigMS.ENet.NetworkNumber;
                                m_QNUDECPUUDP.ActIONumber = m_cConfigMS.ENet.IONumber;

                                iResult = m_QNUDECPUUDP.Open();
                            }
                        }
                        #endregion
                    }
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GOT)
                    {
                        m_actGotTrsp = new ACTGOTLib.ActGOTTRSP();
                        m_actGotTrsp.ActCpuType = m_cConfigMS.GOT.CpuNumber;
                        m_actGotTrsp.ActNetworkNumber = m_cConfigMS.GOT.NetworkNumber;
                        m_actGotTrsp.ActStationNumber = m_cConfigMS.GOT.StationNumber;
                        m_actGotTrsp.ActIONumber = m_cConfigMS.GOT.IONumber;
                        m_actGotTrsp.ActTimeOut = m_cConfigMS.GOT.TimeOut;
                        m_actGotTrsp.ActGotTransparentPCIf = m_cConfigMS.GOT.GotTransparentPcif;
                        m_actGotTrsp.ActGotTransparentPLCIf = m_cConfigMS.GOT.GotTransparentPlcif;

                        iResult = m_actGotTrsp.Open();
                    }

                    #endregion
                }
                else if (_emPlcType == EMPlcConnettionType.Melsec_RSeries)
                {
                    if (m_cConfigMS.MxCom4SelectedIndex == -1)
                        return false;

                    _actUtil = new ActUtlTypeLib.ActUtlType();
                    _actUtil.ActLogicalStationNumber = m_cConfigMS.MxCom4SelectedIndex;
                    iResult = _actUtil.Open();
                }
            }
            catch (System.Exception ex)
            {
                //Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); 
                ex.Data.Clear();
            }

            if (iResult != 0)
                return false;

            m_bConnect = true;

            return true;
        }

        /// <summary>
        /// 통신연결 해제
        /// </summary>
        /// <param name="em_PCIF"></param>
        /// <returns></returns>
        public bool Disconnect()
        {
            int iResult = -1;
            try
            {
                if (_emPlcType == EMPlcConnettionType.Melsec_Normal)
                {
                    if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetH)
                        iResult = m_actMelsecnet.Close();
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetG)
                        iResult = m_actMnetG.Close();
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.USB)
                        iResult = m_QCPUQUSB.Close();
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GXSim)
                        iResult = m_actGXSim.Close();
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GOT)
                        iResult = m_actGotTrsp.Close();
                    else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.Ethernet)
                    {
                        #region Ethernet 설정

                        if (m_cConfigMS.ENet.ProtocolType == EMENetProtocolTypeMS.TCP)
                        {
                            if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)
                                iResult = m_QJ71E71TCP.Close();
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                                iResult = m_AJ71E71TCP.Close();
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                                iResult = m_AJ71QE71TCP.Close();
                            else
                                iResult = m_QNUDECPUTCP.Close();
                        }
                        else
                        {
                            if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)                      //확인완료
                                iResult = m_QJ71E71UDP.Close();
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                                iResult = m_AJ71E71UDP.Close();
                            else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                                iResult = m_AJ71QE71UDP.Close();
                            else
                                iResult = m_QNUDECPUUDP.Close();
                        }
                        #endregion
                    }
                }
                else if (_emPlcType == EMPlcConnettionType.Melsec_RSeries)
                {
                    iResult = _actUtil.Close();
                }
            }
            catch (System.Exception ex)
            {
                //Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); 
                ex.Data.Clear();
            }

            if (iResult != 0)
                return false;

            m_bConnect = false;

            return true;
        }


        /// <summary>
        /// 타 Class에서 수집요청시 사용함수
        /// </summary>
        /// <param name="sAddress"></param>
        /// <param name="iCnt"></param>
        /// <returns></returns>
        public int[] ReadRandomData(string sAddress, int iCnt)
        {
            int iResult = -1;
            m_iReadErrorCode = -1;
            int[] iResultValue = new int[iCnt];

            if (_emPlcType == EMPlcConnettionType.Melsec_Normal)
            {
                #region Melsec MX Component V3

                if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetH)
                {
                    iResult = m_actMelsecnet.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetG)
                {
                    iResult = m_actMnetG.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.USB)
                {
                    iResult = m_QCPUQUSB.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GOT)
                {
                    iResult = m_actGotTrsp.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GXSim)
                {
                    iResult = m_actGXSim.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.Ethernet)
                {
                    if (m_cConfigMS.ENet.ProtocolType == EMENetProtocolTypeMS.TCP)
                    {
                        if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)
                        {
                            iResult = m_QJ71E71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                        {
                            iResult = m_AJ71E71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                        {
                            iResult = m_AJ71QE71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else
                        {
                            iResult = m_QNUDECPUTCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                    }
                    else
                    {
                        if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)                      //확인완료
                        {
                            iResult = m_QJ71E71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                        {
                            iResult = m_AJ71E71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                        {
                            iResult = m_AJ71QE71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else
                        {
                            iResult = m_QNUDECPUUDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                    }
                }
                #endregion
            }
            else if (_emPlcType == EMPlcConnettionType.Melsec_RSeries)
            {
                iResult = _actUtil.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
            }
            if (iResult != 0)
            {
                m_iReadErrorCode = iResult;
                return null;
            }
            return iResultValue;
        }


        /// <summary>
        /// 수집이 가능한지 확인 함수(
        /// </summary>
        /// <param name="sAddress"></param>
        /// <param name="iCnt"></param>
        /// <returns></returns>
        public bool ReadPossible(string sAddress, int iCnt)
        {
            int iResult = -1;
            int[] iResultValue = new int[iCnt];

            if (_emPlcType == EMPlcConnettionType.Melsec_Normal)
            {
                if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetH)
                {
                    iResult = m_actMelsecnet.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.MNetG)
                {
                    iResult = m_actMnetG.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.USB)
                {
                    iResult = m_QCPUQUSB.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GOT)
                {
                    iResult = m_actGotTrsp.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.GXSim)
                {
                    iResult = m_actGXSim.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                }
                else if (m_cConfigMS.SelectedItem == EMConnectTypeMS.Ethernet)
                {
                    if (m_cConfigMS.ENet.ProtocolType == EMENetProtocolTypeMS.TCP)
                    {
                        if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)
                        {
                            iResult = m_QJ71E71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                        {
                            iResult = m_AJ71E71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                        {
                            iResult = m_AJ71QE71TCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else
                        {
                            iResult = m_QNUDECPUTCP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                    }
                    else
                    {
                        if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.QJ71E71)                      //확인완료
                        {
                            iResult = m_QJ71E71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71E71)
                        {
                            iResult = m_AJ71E71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else if (m_cConfigMS.ENet.ModuleType == EMENetModuleTypeMS.AJ71QE71)
                        {
                            iResult = m_AJ71QE71UDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                        else
                        {
                            iResult = m_QNUDECPUUDP.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
                        }
                    }
                }
            }
            else if (_emPlcType == EMPlcConnettionType.Melsec_RSeries)
            {
                iResult = _actUtil.ReadDeviceRandom(sAddress, iCnt, out iResultValue[0]);
            }
            if (iResult != 0)
                return false;
            return true;
        }

        /// <summary>
        /// PLC 파라메터 정보 수집
        /// 0부터 시작하므로 사용시에는 -1 해야 실제 수집이 가능한 한계이다.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> ReadParameterSymbolSize()
        {
            #region 파라메터 설정 참고
            /*
             * X8000
               실제 X8191까지
               K8을 최대로 붙일수 있는 한계는 K8X1FE0 까지(8160)
               파라메터를 읽으면 X8192라고 표시되는데 0을 포함하므로 실제는 X8191
               8191 - 31 = 8160
               M15000
               실제 M15359까지
               15359 - 31 = 15328
             * */
            #endregion

            Dictionary<string, int> dicParameterValue = new Dictionary<string, int>();

            if (!m_bConnect)
                m_bConnect = Connect();

            if (m_bConnect)
            {
                string[] saName4 = { "X", "Y", "M", "L", "B", "F", "SB", "V", "S", "T", "ST", "C", "D", "W", "SW" };
                string sAddress = "SD290\nSD291\nSD292\nSD293\nSD294\nSD295\nSD296\nSD297\nSD298\nSD299\nSD300\nSD301\nSD302\nSD303\nSD304\n";    //15ea
                string sMsg = string.Empty;
                int[] iaValue = ReadRandomData(sAddress, 15);

                for (int i = 0; i < 15; i++)
                    dicParameterValue.Add(saName4[i], iaValue[i]);

            }
            else
            {
                return null;
            }
            return dicParameterValue;
        }

        public List<string> FindErrorSymbol(string[] sAddressList)
        {
            List<string> lstErrAddress = new List<string>();

            for (int i = 0; i < sAddressList.Length; i++)
            {
                if (sAddressList[i] != "")
                {
                    int[] iarrReadData = ReadRandomData(sAddressList[i], 1);
                    if (iarrReadData == null)
                        lstErrAddress.Add(sAddressList[i]);
                    //System.Threading.Thread.Sleep(1);
                }
            }

            return lstErrAddress;
        }

        #region Verify

        /// <summary>
        ///  심볼이 중복된 것까지 걸러낸 후 수집이 가능한 심볼인지 걸러줌.
        ///  외부사용
        /// </summary>
        /// <param name="lstSymbol"></param>
        /// <param name="lstSymbolCount"></param>
        /// <returns></returns>
        public Dictionary<EMCollectCheck, List<CTag>> VerifySymbolList(CTagS cTagS)
        {
            if (m_cConfigMS == null) return null;

            Dictionary<EMCollectCheck, List<CTag>> dicResult = new Dictionary<EMCollectCheck, List<CTag>>();
            List<string> lstError = new List<string>();
            List<string> lstSourceList = ChangeFromSymbolSToAddressList(cTagS);
            List<string> lstSendList = new List<string>();
            List<int> lstSendListCount = new List<int>();

            //SymbolS에서 DWord를 갖는 Symbol만 추출 후 해당 추가 접점을 추가하는 구문 삽입 예정

            bool bPossible;
            int iCnt = 0;
            string sSumSymbol = string.Empty;
            string sMessage = string.Empty;

            //Stopwatch swTimer = new Stopwatch();
            //swTimer.Start();
            lstSourceList.Sort();
            foreach (string sym in lstSourceList)
            {
                if (iCnt > 50)
                {
                    lstSendListCount.Add(iCnt);
                    lstSendList.Add(sSumSymbol);
                    iCnt = 1;
                    sSumSymbol = sym + "\n";
                }
                else
                {
                    sSumSymbol += sym + "\n";
                    iCnt++;
                }
            }
            if (iCnt > 0)
            {
                lstSendListCount.Add(iCnt);
                lstSendList.Add(sSumSymbol);
            }

            bool bOK = Connect();
            if (bOK)
                Console.WriteLine("PLC연결성공");
            else
                Console.WriteLine("PLC연결실패");

            for (int i = 0; i < lstSendList.Count; i++)
            {
                bPossible = ReadPossible(lstSendList[i], lstSendListCount[i]);
                if (!bPossible)
                {
                    string[] sSplit = lstSendList[i].Split('\n');

                    for (int a = 0; a < sSplit.Length - 1; a++)
                    {
                        bPossible = ReadPossible(sSplit[a], 1);
                        if (!bPossible)
                        {
                            lstError.Add(sSplit[a]);
                        }
                    }
                }
            }

            bOK = Disconnect();
            if (bOK)
                Console.WriteLine("PLC해제성공");
            else
                Console.WriteLine("PLC해제실패");

            dicResult.Add(EMCollectCheck.Possible, new List<CTag>());
            dicResult.Add(EMCollectCheck.Impossible, new List<CTag>());

            if (lstError.Count > 0)
            {
                foreach (var who in cTagS)
                {
                    CTag tag = (CTag)who.Value;

                    if (!lstError.Contains(tag.Address))
                        dicResult[EMCollectCheck.Possible].Add(tag);
                    else
                    {
                        dicResult[EMCollectCheck.Impossible].Add(tag);
                        sMessage += tag.Address + ", ";
                    }
                }

                sMessage += "  \r\n수집 불가 갯수 : " + lstError.Count.ToString();
                Console.WriteLine(sMessage);
            }
            else
            {
                foreach (var who in cTagS)
                {
                    CTag tag = (CTag)who.Value;
                    dicResult[EMCollectCheck.Possible].Add(tag);
                }
            }

            return dicResult;
        }

        #endregion

        

        #endregion

    }
}
