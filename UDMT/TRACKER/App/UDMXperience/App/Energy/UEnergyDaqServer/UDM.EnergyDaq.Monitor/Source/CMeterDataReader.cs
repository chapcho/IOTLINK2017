using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UDM.General.ThreadEx;
using UDM.EnergyDaq.Config;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
{
    public class CMeterDataReader
    {
        #region Member Variables

        public event UEventHandlerMeterLogCreate UEventMeterLogCreate;

        private bool m_bRun = false;
        protected CConfig m_cEnergyConfig = null;
        protected CSerialPortRead m_cSerialPortRead = null;
        protected CEhternetRead m_cEthernetRead = null;

        protected Random m_Ro = new Random();
        protected int m_iDemoKw = 0;
        protected int m_iDemoKVar = 0;
        protected Thread m_DemoDataThread = null;

        #endregion

        #region Initialize/Dispose

        public CMeterDataReader(CConfig Config)
        {
            m_cEnergyConfig = Config;
        }

        public void Dispose()
        {

        }

        #endregion

        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
            set { m_bRun = value; }
        }

        public CConfig EnergyConfig
        {
            get { return m_cEnergyConfig; }
            set { m_cEnergyConfig = value; }
        }

        #endregion

        #region Public Methods

        public bool Run()
        {
            Stop();

            bool bOK = true;

            m_bRun = bOK;

            if (m_cEnergyConfig.ConnectType == EMConnectType.SerialPort)
                bOK = RunSerialPortMonitor(m_cEnergyConfig);
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Ethernet)
                bOK = RunEthernetMonitor(m_cEnergyConfig);
            else if (m_cEnergyConfig.ConnectType == EMConnectType.DummyMeter)
                bOK = RunDemoMonitor(m_cEnergyConfig);

            return bOK;
        }

        public void Stop()
        {

            if (m_cEnergyConfig.ConnectType == EMConnectType.SerialPort)
                StopSerialPortMonitor();
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Ethernet)
                StopEhernetMonitor();
            else if (m_cEnergyConfig.ConnectType == EMConnectType.DummyMeter)
                StopDemoMonitor();

            m_bRun = false;
        }

        #endregion

        #region Private Methods

        private bool RunSerialPortMonitor(CConfig config)
        {
            bool bOK = true;

            try
            {
                m_cSerialPortRead = new CSerialPortRead();

                CSerialPortConfig tempConfig = (CSerialPortConfig)config;
                m_cSerialPortRead.Config = tempConfig;
                m_cSerialPortRead.MonitorLogger.UEventDataRead += MonitorLogger_UEventDataRead;

                bOK = m_cSerialPortRead.Run();

                if (bOK == false)
                    StopSerialPortMonitor();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return bOK;
        }

        private void StopSerialPortMonitor()
        {
            if (m_cSerialPortRead != null)
            {
                m_cSerialPortRead.Stop();
                m_cSerialPortRead.MonitorLogger.UEventDataRead -= MonitorLogger_UEventDataRead;
                m_cSerialPortRead.Dispose();
                m_cSerialPortRead = null;
            }
        }

        private bool RunEthernetMonitor(CConfig config)
        {
            bool bOK = true;

            return bOK;
        }

        private void StopEhernetMonitor()
        {
        }

        private bool RunDemoMonitor(CConfig config)
        {
            bool bOK = true;

            if (m_DemoDataThread != null && m_DemoDataThread.ThreadState != ThreadState.Stopped)
            {
                m_DemoDataThread.Abort();
                m_DemoDataThread = null;
            }

            m_DemoDataThread = new Thread(new ThreadStart(DemoDataGenerate));
            m_DemoDataThread.Start();

            return bOK;
        }

        private void StopDemoMonitor()
        {
            if (m_DemoDataThread != null)
            {
                m_DemoDataThread.Abort();
                m_DemoDataThread = null;
            }

        }

        private void DemoDataGenerate()
        {
            while (m_bRun)
            {
                CEnergyLog tempLog = CreateDemoLog(m_cEnergyConfig.MeterKey);

                CEnergyLogS tempLogs = new CEnergyLogS();

                tempLogs.Add(tempLog);

                GenerateLogCreateEvent(tempLogs);    

                System.Threading.Thread.Sleep(m_cEnergyConfig.IntervalTime);
            }
        }

        private CEnergyLog CreateDemoLog(string sKey)
        {
            CEnergyLog tempLog = new CEnergyLog();
            DateTime ctime = DateTime.Now;

            tempLog.Key = sKey;
            tempLog.Time = ctime;

            tempLog.Current = (double)GetRandomFloat();
            tempLog.Voltage = (double)GetRandomFloat();
            tempLog.ActivePower = (double)GetRandomFloat();
            tempLog.ReactivePower = (double)GetRandomFloat();
            tempLog.ApparentPower = (double)GetRandomFloat();
            tempLog.Frequency = (double)GetRandomFloat();
            tempLog.ActiveAmountPower = (double)GetRandomFloat();
            tempLog.ReactiveAmountPower = (double)GetRandomFloat();

            return tempLog;
        }

        private float GetRandomFloat()
        {
            float temp = (float)0.0;

            temp = (float)m_Ro.NextDouble();
            int iTemp = m_Ro.Next(10, 1200);

            temp = temp * iTemp;

            return temp;
        }

        private short GetRandomInt16()
        {
            short temp = 0;

            temp = (short)m_Ro.Next(100, 1200);

            return temp;
        }

        private int GetRandomInt32()
        {
            int temp = 0;

            temp = m_Ro.Next(2, 30);

            return temp;
        }

        #endregion

        #region Event Methods

        protected void MonitorLogger_UEventDataRead(object sender, CEnergyLogS clogs)
        {
            GenerateLogCreateEvent(clogs);
        }

        protected void GenerateLogCreateEvent(CEnergyLogS cLog)
        {
            if (UEventMeterLogCreate != null)
                UEventMeterLogCreate(this, cLog);
        }
        #endregion
    }
}
