using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace UDM.DDEA
{
    [Serializable]
    public partial class UCConnectSetting : UserControl
    {

        #region Member Variables

        protected CDDEAConfigMS m_cConfig = null;
        protected bool m_bDataChange = false;
        protected CReadFunction m_cReadFunction = null;
        protected CPlcTypeConverter m_cTypeConvert = new CPlcTypeConverter();

        #endregion

        #region Initialize/Dispose

        public UCConnectSetting()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        public CDDEAConfigMS Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value;
            }
        }
        
        public bool DataChange
        {
            get { return m_bDataChange; }
            set { m_bDataChange = value; }
        }

        #endregion


        #region Private Methods

        private void InitialItems()
        {
            List<string> lstData = new List<string>();
            CPlcTypeConverter cTypeConvert = new CPlcTypeConverter();
            //통신설정
            lstData = cTypeConvert.GetPlcMakerStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbPLCVender.Items.Add(lstData[i]);
            lstData.Clear();

            lstData = cTypeConvert.GetConnectTypeFullStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbPlcConnectType.Items.Add(lstData[i]);
            lstData.Clear();

            lstData = cTypeConvert.GetPlcCpuStringList();
            for (int i = 0; i < lstData.Count; i++)
            {
                cmbCpuType.Items.Add(lstData[i]);
            }
            lstData.Clear();

            lstData = cTypeConvert.GetMultiCpuTypeStringList();
            for (int i = 0; i < lstData.Count; i++)
            {
                cmbMultiCPU.Items.Add(lstData[i]);
            }
            lstData.Clear();

            #region Ethernet Detail

            lstData = cTypeConvert.GetEthernetModuleTypeStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbEthernetModule.Items.Add(lstData[i]);
            lstData.Clear();

            lstData = cTypeConvert.GetEthernetProtocolTypeStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbEthernetProtocol.Items.Add(lstData[i]);
            lstData.Clear();

            lstData = cTypeConvert.GetEthernetPacketTypeStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbEthernetPacket.Items.Add(lstData[i]);

            #endregion
            lstData.Clear();

            lstData = cTypeConvert.GetMnetPcSlotStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbMNetSlotNumber.Items.Add(lstData[i]);

            lstData.Clear();

            lstData = cTypeConvert.GetStationTypeStringList();
            for (int i = 0; i < lstData.Count; i++)
                cmbStationType.Items.Add(lstData[i]);


            lstData.Clear();

            cmbPLCVender.SelectedIndex = 0;
            cmbPlcConnectType.SelectedIndex = 0;
            cmbEthernetPacket.SelectedIndex = 0;
            cmbEthernetProtocol.SelectedIndex = 1;
            cmbEthernetModule.SelectedIndex = 0;
            cmbCpuType.SelectedIndex = 0;
            cmbMultiCPU.SelectedIndex = 0;
            cmbMNetSlotNumber.SelectedIndex = 0;

            cmbStationType.SelectedIndex = 0;
            cmbOtherNet.SelectedIndex = 1;
            cmbGotPcIF.SelectedIndex = 0;
            cmbGotPlcIF.SelectedIndex = 0;

        }

        /// <summary>
        /// 화면설정 -> Config Class
        /// </summary>
        /// <param name="cConfig"></param>
        /// <returns></returns>
        public CDDEAConfigMS SetConfig(CDDEAConfigMS cConfig)
        {
            if(cConfig == null)
                cConfig = new CDDEAConfigMS();

            EMConnectTypeMS emConnectType = m_cTypeConvert.GetConnectType(cmbPlcConnectType.SelectedItem.ToString());

            cConfig.SelectedItem = emConnectType;

            if ((emConnectType == EMConnectTypeMS.MNetH) || (emConnectType == EMConnectTypeMS.MNetG))
            {
                cConfig.MNet.CpuNumber = (int)m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.MNet.CPUType = m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.MNet.StationType = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());
                cConfig.MNet.IONumber = 0x3FF;
                cConfig.MNet.DestinationIONumber = 0;
                cConfig.MNet.PortNumber = ((int)m_cTypeConvert.GetMnetPcSlotType(cmbMNetSlotNumber.SelectedItem.ToString())) + 1;
                cConfig.MNet.ThroughNetworkType = 0;

                if (cConfig.MNet.StationType == EMStationTypeMS.Host)
                {
                    cConfig.MNet.NetworkNumber = 255;
                    cConfig.MNet.StationNumber = 0;
                }
                else
                {
                    cConfig.MNet.IONumber = (int)m_cTypeConvert.GetMultiCpuType(cmbMultiCPU.SelectedItem.ToString());
                    cConfig.MNet.NetworkNumber = (int)spinOtherNetNo.Value;
                    cConfig.MNet.StationNumber = (int)spinOtherStationNo.Value;
                    cConfig.MNet.ThroughNetworkType = cmbOtherNet.SelectedIndex;
                }
            }
            else if (emConnectType == EMConnectTypeMS.Ethernet)
            {
                cConfig.ENet.CpuNumber = (int)m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.ENet.CPUType = m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.ENet.StationType = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());
                cConfig.ENet.ModuleType = m_cTypeConvert.GetEthernetModuleType(cmbEthernetModule.SelectedItem.ToString());
                cConfig.ENet.PacketType = m_cTypeConvert.GetEthernetPacketType(cmbEthernetPacket.SelectedItem.ToString());
                cConfig.ENet.ProtocolType = m_cTypeConvert.GetEthernetProtocolType(cmbEthernetProtocol.SelectedItem.ToString());
                cConfig.ENet.TimeOut = (int)spnConnectionTime.Value;
                if (cConfig.ENet.ModuleType == EMENetModuleTypeMS.CPU)
                {
                    cConfig.ENet.PC_StationNumber = 255;
                    cConfig.ENet.NetworkNumber = 0;
                }
                else
                {
                    cConfig.ENet.PC_StationNumber = (int)spnEthernetPCStation.Value;
                    cConfig.ENet.NetworkNumber = (int)spnEthernetNetwork.Value;
                }
                cConfig.ENet.IPAddress = txtEthernetIPAddress.Text;

                if (cConfig.ENet.StationType == EMStationTypeMS.Host)
                {
                    cConfig.ENet.ConnectionUnitNumber = 0;
                }
                else
                {
                    cConfig.ENet.ConnectionUnitNumber = 1;
                }

                cConfig.ENet.PortNumber = (int)spnEthernetPort.Value;
                cConfig.ENet.PLC_StationNumber = (int)spnEthernetPLCStation.Value;
                cConfig.ENet.IONumber = (int)m_cTypeConvert.GetMultiCpuType(cmbMultiCPU.SelectedItem.ToString());
            }
            else if (emConnectType == EMConnectTypeMS.USB)
            {
                cConfig.USB.CPUType = m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.USB.StationType = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());
                cConfig.USB.CpuNumber = (int)m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.USB.DestinationIONumber = 0;
                cConfig.USB.TimeOut = (int)spnConnectionTime.Value;

                if (cConfig.USB.StationType == EMStationTypeMS.Host)
                {
                    cConfig.USB.NetworkNumber = 0;
                    cConfig.USB.StationNumber = 255;
                }
                else
                {
                    cConfig.USB.NetworkNumber = (int)spinOtherNetNo.Value;
                    cConfig.USB.StationNumber = (int)spinOtherStationNo.Value;
                    cConfig.USB.ThroughNetworkType = cmbOtherNet.SelectedIndex;
                }

                cConfig.USB.IONumber = (int)m_cTypeConvert.GetMultiCpuType(cmbMultiCPU.SelectedItem.ToString());
            }
            else if (emConnectType == EMConnectTypeMS.GXSim)
            {
                cConfig.GxSim.CPUType = m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.GxSim.StationType = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());
                cConfig.GxSim.CpuNumber = (int)m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.GxSim.TimeOut = (int)spnConnectionTime.Value;
                cConfig.GxSim.NetworkNumber = (int)spinOtherNetNo.Value;
                cConfig.GxSim.StationNumber = (int)spinOtherStationNo.Value;
            }
            else if (emConnectType == EMConnectTypeMS.GOT)
            {
                cConfig.GOT.CPUType = m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.GOT.StationType = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());
                cConfig.GOT.CpuNumber = (int)m_cTypeConvert.GetPlcCpuType(cmbCpuType.SelectedItem.ToString());
                cConfig.GOT.TimeOut = (int)spnConnectionTime.Value;
                if (cConfig.GOT.StationType == EMStationTypeMS.Host)
                {
                    cConfig.GOT.NetworkNumber = 255;
                    cConfig.GOT.StationNumber = 0;
                }
                else
                {
                    cConfig.GOT.NetworkNumber = (int)spinOtherNetNo.Value;
                    cConfig.GOT.StationNumber = (int)spinOtherStationNo.Value;
                }
                cConfig.GOT.IONumber = (int)m_cTypeConvert.GetMultiCpuType(cmbMultiCPU.SelectedItem.ToString());
            }
            else
            {
                cConfig = null;
            }

            return cConfig;
            
        }

        /// <summary>
        /// Config Class ->화면설정
        /// </summary>
        /// <param name="cConfig"></param>
        public void GetConfig(CDDEAConfigMS cConfig)
        {
            EMConnectTypeMS emConnectType = cConfig.SelectedItem;
            cmbPlcConnectType.SelectedIndex = (int)cConfig.SelectedItem;
            
            if ((emConnectType == EMConnectTypeMS.MNetH) || (emConnectType == EMConnectTypeMS.MNetG))
            {
                cmbCpuType.SelectedIndex = m_cTypeConvert.GetPlcCpuIndexNumber(cConfig.MNet.CPUType);
                cmbMultiCPU.SelectedIndex = m_cTypeConvert.GetMutiCpuIndexNumber(cConfig.MNet.IONumber);
                cmbStationType.SelectedIndex = (int)cConfig.MNet.StationType;
                cmbMNetSlotNumber.SelectedIndex = cConfig.MNet.PortNumber - 1;
                spinOtherNetNo.Value = cConfig.MNet.NetworkNumber;
                spinOtherStationNo.Value = cConfig.MNet.StationNumber;
                cmbOtherNet.SelectedIndex = cConfig.MNet.ThroughNetworkType;
                
            }
            else if (emConnectType == EMConnectTypeMS.Ethernet)
            {
                cmbCpuType.SelectedIndex = m_cTypeConvert.GetPlcCpuIndexNumber(cConfig.ENet.CPUType);
                cmbStationType.SelectedIndex = (int)cConfig.ENet.StationType;
                cmbEthernetModule.SelectedIndex = (int)cConfig.ENet.ModuleType;
                cmbEthernetPacket.SelectedIndex = (int)cConfig.ENet.PacketType;
                cmbEthernetProtocol.SelectedIndex = (int)cConfig.ENet.ProtocolType;
                
                spnEthernetPort.Value = cConfig.ENet.PortNumber;
                spnEthernetPLCStation.Value = cConfig.ENet.PLC_StationNumber;
                spnConnectionTime.Value = cConfig.ENet.TimeOut;
                spnEthernetPCStation.Value = cConfig.ENet.PC_StationNumber;
                spnEthernetNetwork.Value = cConfig.ENet.NetworkNumber;
                txtEthernetIPAddress.Text = cConfig.ENet.IPAddress;
            }
            else if (emConnectType == EMConnectTypeMS.USB)
            {
                cmbCpuType.SelectedIndex = m_cTypeConvert.GetPlcCpuIndexNumber(cConfig.USB.CPUType);
                cmbStationType.SelectedIndex = (int)cConfig.USB.StationType;
                cmbMultiCPU.SelectedIndex = m_cTypeConvert.GetMutiCpuIndexNumber(cConfig.USB.IONumber);
                spnConnectionTime.Value = cConfig.USB.TimeOut;
                spinOtherNetNo.Value = cConfig.USB.NetworkNumber;
                spinOtherStationNo.Value = cConfig.USB.StationNumber;
                cmbOtherNet.SelectedIndex = cConfig.USB.ThroughNetworkType;
            }
            else if (emConnectType == EMConnectTypeMS.GXSim)
            {
                cmbCpuType.SelectedIndex = m_cTypeConvert.GetPlcCpuIndexNumber(cConfig.GxSim.CPUType);
                cmbStationType.SelectedIndex = (int)cConfig.GxSim.StationType;
                spnConnectionTime.Value = cConfig.GxSim.TimeOut;

                spinOtherNetNo.Value = cConfig.GxSim.NetworkNumber;
                spinOtherStationNo.Value = cConfig.GxSim.StationNumber;
            }
            else if (emConnectType == EMConnectTypeMS.GOT)
            {
                cmbCpuType.SelectedIndex = m_cTypeConvert.GetPlcCpuIndexNumber(cConfig.GOT.CPUType);
                cmbStationType.SelectedIndex = (int)cConfig.GOT.StationType;
                spnConnectionTime.Value = cConfig.GOT.TimeOut;

                spinOtherNetNo.Value = cConfig.GOT.NetworkNumber;
                spinOtherStationNo.Value = cConfig.GOT.StationNumber;
            }
            else
            {
                MessageBox.Show("설정이 없습니다.");
            }
        }

        #endregion


        #region Event Methods

        private void FrmConnectSetting_Load(object sender, EventArgs e)
        {
            InitialItems();
        }

        private void cmbStationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EMStationTypeMS emStation = m_cTypeConvert.GetStationType(cmbStationType.SelectedItem.ToString());

            if (emStation == EMStationTypeMS.Host)
            {
                spinOtherNetNo.Enabled = false;
                spinOtherStationNo.Enabled = false;
            }
            else
            {
                spinOtherNetNo.Enabled = true;
                spinOtherStationNo.Enabled = true;
            }
        }

        private void cmbEthernetModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEthernetProtocol.Enabled = true;
            cmbEthernetPacket.Enabled = true;
            txtEthernetIPAddress.Enabled = true;
            spnEthernetNetwork.Enabled = true;
            spnEthernetPCStation.Enabled = true;
            spnEthernetPLCStation.Enabled = true;
            spnEthernetPort.Enabled = true;

            EMENetModuleTypeMS emENetModule = m_cTypeConvert.GetEthernetModuleType(cmbEthernetModule.SelectedItem.ToString());

            switch (emENetModule)
            {
                case EMENetModuleTypeMS.AJ71E71:
                    spnEthernetNetwork.Enabled = false;
                    spnEthernetPCStation.Enabled = false;
                    spnEthernetPLCStation.Enabled = false;
                    break;
                case EMENetModuleTypeMS.AJ71QE71:
                    cmbEthernetPacket.Enabled = false;
                    break;
                case EMENetModuleTypeMS.QJ71E71:
                    cmbEthernetPacket.Enabled = false;
                    break;
                case EMENetModuleTypeMS.CPU:
                    cmbEthernetPacket.Enabled = false;
                    spnEthernetNetwork.Enabled = false;
                    spnEthernetPCStation.Enabled = false;
                    spnEthernetPLCStation.Enabled = false;
                    spnEthernetPort.Enabled = false;
                    break;
                case EMENetModuleTypeMS.GOT:
                    cmbEthernetPacket.Enabled = false;
                    spnEthernetNetwork.Enabled = false;
                    spnEthernetPCStation.Enabled = false;
                    spnEthernetPLCStation.Enabled = false;
                    spnEthernetPort.Enabled = false;
                    cmbEthernetProtocol.Enabled = false;
                    break;
            }
        }

        private void cmbPlcConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spnConnectionTime.Value = 1000;
            cmbMultiCPU.SelectedIndex = 0;

            EMConnectTypeMS emConnectType = m_cTypeConvert.GetConnectType(cmbPlcConnectType.SelectedItem.ToString());
            cmbStationType.Enabled = true;
            cmbStationType.SelectedIndex = 0;
            switch (emConnectType)
            {
                case EMConnectTypeMS.USB:
                    tabConfigDetail.SelectedTabPage = tpUSB;
                    pnlTabMelsecnet.Enabled = false;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = false;
                    break;
                case EMConnectTypeMS.Ethernet:
                    cmbStationType.Enabled = false;
                    tabConfigDetail.SelectedTabPage = tpEthernet;
                    pnlTabMelsecnet.Enabled = false;
                    pnlTabEthernet.Enabled = true;
                    pnlTapGot.Enabled = false;
                    break;
                case EMConnectTypeMS.MNetH:
                    tabConfigDetail.SelectedTabPage = tpMelsecnet;
                    pnlTabMelsecnet.Enabled = true;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = false;
                    break;
                case EMConnectTypeMS.MNetG:
                    tabConfigDetail.SelectedTabPage = tpMelsecnet;
                    pnlTabMelsecnet.Enabled = true;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = false;
                    break;

                case EMConnectTypeMS.GXSim:
                    cmbStationType.Enabled = false;
                    tabConfigDetail.SelectedTabPage = tpUSB;
                    pnlTabMelsecnet.Enabled = false;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = false;
                    break;
                case EMConnectTypeMS.GOT:
                    tabConfigDetail.SelectedTabPage = tpGot;
                    pnlTabMelsecnet.Enabled = false;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = true;
                    break;
                default:
                    tabConfigDetail.SelectedTabPage = tpUSB;
                    pnlTabMelsecnet.Enabled = false;
                    pnlTabEthernet.Enabled = false;
                    pnlTapGot.Enabled = false;
                    break;
            }
        }

        private void cmbEthernetProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            EMENetProtocolTypeMS emProtocol = m_cTypeConvert.GetEthernetProtocolType(cmbEthernetProtocol.SelectedItem.ToString());

            if (emProtocol == EMENetProtocolTypeMS.TCP)
                spnEthernetPort.Enabled = false;
            else
                spnEthernetPort.Enabled = true;
        }

        #endregion

       
    }
}
