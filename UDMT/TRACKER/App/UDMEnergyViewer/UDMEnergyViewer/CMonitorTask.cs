using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source.LS;

namespace UDMEnergyViewer
{
    public class CMonitorTask : IDisposable    
    {

        #region Member Variables

        private bool m_bRun = false;
        private bool m_bPlcRun = false;
        private bool m_bMeterRun = false;
        private CProject m_cProject = null;
        private CMonitor m_cPlcMonitor = null;
        private CCsvLogWriter m_cPlcLogWriter = null;
        private CMeterMonitor m_cMeterMonitor = null;
        private CMeterLogWriter m_cMeterLogWriter = null;

        #endregion


        #region Initialize/Dispose

        public CMonitorTask()
        {

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

        public bool IsPlcRunning
        {
            get { return m_bPlcRun; }
        }

        public bool IsMeterRunning
        {
            get { return m_bMeterRun; }
        }

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }


        #endregion


        #region Public Methods

        public bool Run()
        {
            Stop();

            m_bPlcRun = RunPlcMontior();
            
            m_bMeterRun = RunMeterMontior();

            if (m_bPlcRun == false && m_bMeterRun == false)
                m_bRun = false;
            else
                m_bRun = true;

            return m_bRun;
        }

        public void Stop()
        {
            StopPlcMonitor();
            StopMeterMonitor();

            m_bRun = false;
        }

        #endregion


        #region Private Methods

        private bool RunPlcMontior()
        {
            m_cPlcMonitor = new CMonitor();
            m_cPlcMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.LS;
            m_cPlcMonitor.Source.LsConfig = m_cProject.PlcConfig;
            m_cPlcMonitor.Logger.UEventValueChanged += MonitorLogger_UEventValueChanged;

            CTagS cTagS = new CTagS();
            for (int i = 0; i < m_cProject.SymbolS.Count; i++)
                cTagS.Add(m_cProject.SymbolS[i].Tag);

            m_cPlcMonitor.TagS = cTagS;
            bool bOK = m_cPlcMonitor.Run();
            if (bOK)
            {
                DateTime dtTime = DateTime.Now;

                string sPath = m_cProject.LogConfig.SavePath.ToString() + "\\" + dtTime.ToString("yyMMddHHmmss") + "_PlcLog.csv";
                m_cPlcLogWriter = new CCsvLogWriter();
                bOK = m_cPlcLogWriter.Open(sPath);
                if (bOK == false)
                    StopPlcMonitor();
            }
            else
            {
                StopPlcMonitor();
            }

            return bOK;
        }

        private bool RunMeterMontior()
        {
            m_cMeterMonitor = new CMeterMonitor();
            m_cMeterMonitor.Config = m_cProject.MeterConfig;
            m_cMeterMonitor.MonitorLogger.UEventDataRead += MonitorLogger_UEventDataRead;
            bool bOK = m_cMeterMonitor.Run();
            if (bOK)
            {
                DateTime dtTime = DateTime.Now;

                string sPath = m_cProject.LogConfig.EnergySavePath + "\\" + dtTime.ToString("yyMMddHHmmss") + "_MeterLog.csv";
                m_cMeterLogWriter = new CMeterLogWriter();
                m_cMeterLogWriter.ChannelS = m_cProject.MeterConfig.ChannelNum;

                bOK = m_cMeterLogWriter.Open(sPath);
                if (bOK == false)
                    StopMeterMonitor();
            }
            else
            {
                StopMeterMonitor();
            }

            return bOK;
        }

        private void StopPlcMonitor()
        {
            if (m_cPlcMonitor != null)
            {
                m_cPlcMonitor.Stop();
                m_cPlcMonitor.Logger.UEventValueChanged -= MonitorLogger_UEventValueChanged;

                if (m_cPlcMonitor.TagS != null)
                    m_cPlcMonitor.TagS.Clear();

                m_cPlcMonitor.Dispose();
                m_cPlcMonitor = null;

                if (m_cPlcLogWriter != null)
                {
                    m_cPlcLogWriter.Dispose();
                    m_cPlcLogWriter = null;
                }
            }
        }

        private void StopMeterMonitor()
        {
            if (m_cMeterMonitor != null)
            {
                m_cMeterMonitor.Stop();
                m_cMeterMonitor.MonitorLogger.UEventDataRead -= MonitorLogger_UEventDataRead;


                m_cMeterMonitor.Dispose();
                m_cMeterMonitor = null;

                if (m_cMeterLogWriter != null)
                {
                    m_cMeterLogWriter.Dispose();
                    m_cMeterLogWriter = null;
                }
            }
        }


        #endregion

        #region Event Mehtods

        private void MonitorLogger_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            if(m_cPlcLogWriter != null)
            {
                m_cPlcLogWriter.WriteTimeLogS(cLogS);
            }
        }

        private void MonitorLogger_UEventDataRead(object sender, CMeterData cData)
        {
            if(m_cMeterLogWriter != null)
            {
                m_cMeterLogWriter.Write(cData);
            }
        }

        #endregion
    }
}
