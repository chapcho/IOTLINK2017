using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.Common;
using UDM.Log;


namespace UDM.Monitor.Energy.Source
{   
    public class CMonitorSource : IDisposable
    {

        #region Member Variables

        private bool m_bRun = false;
        public event EventHandler UEventTerminated;
        public event UEventHandlerMonitorValueChanged UEventValueChanged;
        public event UEventHandlerMeterLogCreate UEventMeterLogCreate;
        protected Random m_Ro = new Random();
        protected CEnergyLogS m_lstTempLogs = null;
        protected int m_iLogBlockSize = 10;
        protected CSerialPortRead m_cSerialPortRead= null;
        protected CEhternetRead m_cEthernetRead= null;
        protected int m_iDemoKw =0;
        protected int m_iDemoKVar =0;
        protected CEnergyConfig m_cEnergyConfig = null;
        protected Thread m_DemoDataThread = null;

        #endregion


        #region Initialize/Dispose

        public CMonitorSource()
        {
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

        public CEnergyConfig EnergyConfig
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

            m_lstTempLogs = new CEnergyLogS();

            m_bRun = bOK;

            if (m_cEnergyConfig.ConnectType == EMConnectType.SerialPort)
                bOK = RunSerialPortMonitor(m_cEnergyConfig);
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Ethernet)
                bOK = RunEthernetMonitor(m_cEnergyConfig);
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Demo)
                bOK = RunDemoMonitor(m_cEnergyConfig);
            
            return bOK;
        }

        public void Stop()
        {

            if (m_cEnergyConfig.ConnectType == EMConnectType.SerialPort)
                StopSerialPortMonitor();
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Ethernet)
                StopEhernetMonitor();
            else if (m_cEnergyConfig.ConnectType == EMConnectType.Demo)
                StopDemoMonitor();
            
            m_bRun = false;
        }


        #endregion


        #region Private Methods

        private bool RunSerialPortMonitor(CEnergyConfig config)
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
            if(m_cSerialPortRead!= null)
            {
                m_cSerialPortRead.Stop();
                m_cSerialPortRead.MonitorLogger.UEventDataRead -= MonitorLogger_UEventDataRead;
                m_cSerialPortRead.Dispose();
                m_cSerialPortRead = null;
            }
        }

        private bool RunEthernetMonitor(CEnergyConfig config)
        {
            bool bOK = true;

            return bOK;
        }

        private void StopEhernetMonitor()
        {
        }

        private bool RunDemoMonitor(CEnergyConfig config)
        {
            bool bOK = true;

            if(m_DemoDataThread!=null && m_DemoDataThread.ThreadState!= ThreadState.Stopped)
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
            if(m_DemoDataThread!=null)
            {
                m_DemoDataThread.Abort();
                m_DemoDataThread = null;
            }
            
        }

        private void DemoDataGenerate()
        {
            while(m_bRun)
            {
                CEnergyLog tempLog = CreateDemoLog();

                GenerateLogCreateEvent(tempLog);

                if (m_lstTempLogs != null)
                {
                    m_lstTempLogs.Add(tempLog);
                }

                if (m_lstTempLogs.Count > m_iLogBlockSize)
                {
                    CEnergyLogS tempEnergyLogs = new CEnergyLogS();

                    tempEnergyLogs.AddRange(m_lstTempLogs);
                    tempEnergyLogs.UpdateTimeRange();

                    if (UEventValueChanged != null)
                        UEventValueChanged(this, tempEnergyLogs);

                    m_lstTempLogs.Clear();
                }
                
                System.Threading.Thread.Sleep(m_cEnergyConfig.IntervalTime);
            }
        }

        private CEnergyLog CreateDemoLog()
        {
            CEnergyLog tempLog = new CEnergyLog();
            DateTime ctime = DateTime.Now;
            string sDataKey = "Demo";

            tempLog.Key = sDataKey;
            tempLog.Time = ctime;
            tempLog.VoltageA = GetRandomFloat();
            tempLog.VoltageB = GetRandomFloat();
            tempLog.VoltageC = GetRandomFloat();
            tempLog.VoltageAB = GetRandomFloat();
            tempLog.VoltageBC = GetRandomFloat();
            tempLog.VoltageCA = GetRandomFloat();
            tempLog.CurrentA = GetRandomFloat();
            tempLog.CurrentB = GetRandomFloat();
            tempLog.CurrentC = GetRandomFloat();
            tempLog.ActiveA = GetRandomFloat();
            tempLog.ActiveB = GetRandomFloat();
            tempLog.ActiveC = GetRandomFloat();
            tempLog.ActiveTotal = GetRandomFloat();
            tempLog.ReactiveA = GetRandomFloat();
            tempLog.ReactiveB = GetRandomFloat();
            tempLog.ReactiveC = GetRandomFloat();
            tempLog.ReactiveTotal = GetRandomFloat();
            tempLog.ApparentA = GetRandomFloat();
            tempLog.ApparentB = GetRandomFloat();
            tempLog.ApparentC = GetRandomFloat();
            tempLog.ApparentTotal = GetRandomFloat();
            tempLog.PFa = GetRandomInt16() * (float)0.001;
            tempLog.PFb = GetRandomInt16() * (float)0.001;
            tempLog.PFc = GetRandomInt16() * (float)0.001;
            tempLog.TotalPF = GetRandomInt16() * (float)0.001;
            tempLog.Frequency = GetRandomInt16() * (float)0.01;
            tempLog.TotalKwh = m_iDemoKw + GetRandomInt32();
            m_iDemoKw = tempLog.TotalKwh;
            tempLog.TotalKvarh = m_iDemoKVar + GetRandomInt32();
            m_iDemoKVar = tempLog.TotalKvarh;

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

        protected void MonitorLogger_UEventDataRead(object sender, CEnergyLog clog)
        {
            GenerateLogCreateEvent(clog);

            if(m_lstTempLogs!= null)
            {
                m_lstTempLogs.Add(clog);
            }

            if(m_lstTempLogs.Count> m_iLogBlockSize)
            {
                CEnergyLogS tempEnergyLogs = new CEnergyLogS();

                tempEnergyLogs.AddRange(m_lstTempLogs);
                tempEnergyLogs.UpdateTimeRange();

                if (UEventValueChanged != null)
                    UEventValueChanged(this, tempEnergyLogs);

                m_lstTempLogs.Clear();
            }
        }

        protected void GenerateLogCreateEvent(CEnergyLog cLog)
        {
            if (UEventMeterLogCreate != null)
                UEventMeterLogCreate(this, cLog);
        }

        protected void GenerateTerminatedEvent()
        {
            if(UEventTerminated!=null)
                UEventTerminated(this,new EventArgs());
        }
        #endregion
    }
}
