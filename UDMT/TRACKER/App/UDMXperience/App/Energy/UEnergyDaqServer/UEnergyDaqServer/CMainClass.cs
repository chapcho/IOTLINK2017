using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Log.Energy;
using UDM.EnergyDaq.Service;
using UDM.EnergyDaq.Config;
using UDM.EnergyDaq.Monitor;

namespace UEnergyDaqServer
{
    internal class CMainClass : IDisposable
    {
        #region Member Variables

        protected bool m_bRun = false;
        protected CEnergyDaqServer m_cServer = null;
        protected CConfigS m_lstConfigS = null;
        protected List<string> m_lstMeterKeyS = null;
        #endregion


        #region Initilaize/Dispose

        public CMainClass()
        {
            List<string> m_lstMeterKeyS = new List<string>();
        }

        public void Dispose()
        {
            Stop();
        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public CConfigS ConfigS
        {
            set { m_lstConfigS = value; }
            get { return m_lstConfigS; }
        }

        #endregion


        #region Public Methods

        public bool Start()
        {
            if (m_bRun)
                return true;

            bool bOK = true;

            try
            {
                m_cServer = new CEnergyDaqServer();
                m_cServer.ConfigS = m_lstConfigS;

                m_cServer.UEventClientConnected += m_cServer_UEventClientConnected;
                m_cServer.UEventClientDisconnected += m_cServer_UEventClientDisconnected;
                m_cServer.UEventLogKeyListRequire += m_cServer_UEventClientLogKeyListRequrie;                

                bOK = m_cServer.Start();
                m_cServer.BeforeRunMonitor();

                if(bOK == false)
                    Stop();
                m_cServer.RunMonitor();

                m_bRun = bOK;                
            }
            catch(System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Stop()
        {
            if (m_cServer == null)
                return true;

            bool bOK = true;

            try
            {

                m_cServer.StopMonitor();
                m_cServer.AfterStopMonitor();
                m_cServer.Stop();

                m_cServer.UEventClientConnected -= m_cServer_UEventClientConnected;
                m_cServer.UEventClientDisconnected -= m_cServer_UEventClientDisconnected;
                m_cServer.UEventLogKeyListRequire -= m_cServer_UEventClientLogKeyListRequrie;

                m_cServer.Dispose();
                m_cServer = null;

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            m_bRun = false;

            return bOK;
        }

        public void GetConfigKeyS()
        {
            foreach(CConfig ctemp in m_lstConfigS)
            {
                if(ctemp.ChannelCount>1)
                {
                    GetSubConfigKey(ctemp);
                }
                else
                {
                    if(ctemp.ConnectType == EMConnectType.Ethernet)
                    {
                        m_lstMeterKeyS.Add(ctemp.MeterKey);
                    }
                    else if(ctemp.ConnectType == EMConnectType.SerialPort)
                    {
                         CSerialPortConfig tempSerialConfig = (CSerialPortConfig) ctemp;
                         m_lstMeterKeyS.Add(tempSerialConfig.DeviceConfigList[0].MeterDeviceKey);
                    }
                }
            }
        }

        #endregion


        #region Private Methods

        private void GetSubConfigKey(CConfig cTempConfig)
        {
            int iChannelCount = cTempConfig.ChannelCount;

            if(cTempConfig.ConnectType == EMConnectType.Ethernet)
            {
                for (int i = 0; i < iChannelCount; i++)
                {
                    string sTemp = cTempConfig.MeterKey + "_Channel" + (i + 1).ToString();
                    m_lstMeterKeyS.Add(sTemp);
                }
            }
            else if(cTempConfig.ConnectType == EMConnectType.SerialPort)
            {
                CSerialPortConfig tempSerialConfig = (CSerialPortConfig) cTempConfig;
                for(int i =0;i<iChannelCount;i++)
                {
                    m_lstMeterKeyS.Add(tempSerialConfig.DeviceConfigList[i].MeterDeviceKey);
                }
            }
        }

        #endregion


        #region Event Methods

        private void m_cServer_UEventClientConnected(object sender, string sClient)
        {
            MessageBox.Show("Eenergy Client: \"{0}\" is connected.", sClient);
        }

        private void m_cServer_UEventClientDisconnected(object sender, string sClient)
        {
            MessageBox.Show("Eenergy Client: \"{0}\" is disonnected.", sClient);
        }

        private List<string> m_cServer_UEventClientLogKeyListRequrie(object sender,string sClient)
        {
            GetConfigKeyS();

            return m_lstMeterKeyS;
        }

        #endregion
    }
}
