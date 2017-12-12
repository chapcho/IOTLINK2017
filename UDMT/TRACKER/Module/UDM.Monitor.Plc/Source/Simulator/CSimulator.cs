using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using UDM.Log;

namespace UDM.Monitor.Plc.Source.Simulator
{
    public class CSimulator : IDisposable
    {

        #region Member Variables

        protected bool m_bRun = false;

        protected CSimulatorConfig m_cConfig = new CSimulatorConfig();

        public event UEventHandlerMonitorValueChanged UEventValueChanged;

        #endregion


        #region Initialize/Dispose

        public CSimulator()
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

        public CSimulatorConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        #endregion


        #region Public Methods

        public bool Connect()
        {
            return true;
        }

        public bool Disconnect()
        {
            return true;
        }

        public bool Run()
        {
            if (m_cConfig == null || m_cConfig.LogS == null)
                return false;

            m_bRun = true;

            CTimeLog cLogCurrent = null;
            CTimeLog cLogPrev = null;
            CTimeLogS cLogS = new CTimeLogS();
            for (int i = 0; i < m_cConfig.LogS.Count; i++)
            {
                if (m_bRun == false)
                    break;

                cLogCurrent = m_cConfig.LogS[i];

                if (cLogPrev == null)
                {   
                    cLogPrev = cLogCurrent;
                }
                else
                {
                    if (cLogPrev.Time != cLogCurrent.Time || cLogPrev.Key != cLogCurrent.Key)
                    {
                        if (UEventValueChanged != null)
                            UEventValueChanged(this, cLogS);

                        TimeSpan tsSpan = cLogCurrent.Time.Subtract(cLogPrev.Time);
                        double dWaitWhile = tsSpan.TotalMilliseconds;
                        WaitWhile(dWaitWhile > 100 ? 100 : dWaitWhile);
                        // WaitWhile(tsSpan.TotalMilliseconds);


                        cLogS = new CTimeLogS();
                        cLogPrev = cLogCurrent;
                    }   
                }

                cLogS.Add(cLogCurrent);
                Application.DoEvents();
            }

            if (cLogS != null && cLogS.Count > 0)
            {
                if (UEventValueChanged != null)
                    UEventValueChanged(this, cLogS);
            }


            m_bRun = false;

            return true;
        }

        public bool Stop()
        {
            m_bRun = false;

            return true;
        }

        #endregion


        #region Private Methods

        private void WaitWhile(double nMilsec)
        {
            DateTime dtTime = DateTime.Now;
            DateTime dtTarget = dtTime.AddMilliseconds(nMilsec);

            while (true)
            {
                Application.DoEvents();

                dtTime = DateTime.Now;
                if (dtTime >= dtTarget)
                    break;
            }
        }

        #endregion
    }
}
