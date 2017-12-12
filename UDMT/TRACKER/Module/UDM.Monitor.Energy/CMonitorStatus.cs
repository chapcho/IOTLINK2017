using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    public static class CMonitorStatus
    {
        private static int m_iMonitorBuffer = 0;
        private static int m_iLoggerBuffer = 0;
        private static int m_iViewerBuffer = 0;
        private static int m_iRecieveDataCount = 0;

        private static int MAX_BUFFER_SIZE = 50000;

        public static int MonitorBuffer
        {
            get { return m_iMonitorBuffer; }
            set { m_iMonitorBuffer = value; if (m_iMonitorBuffer > MAX_BUFFER_SIZE) { m_iMonitorBuffer = 0; } }
        }               

        public static int LoggerBuffer
        {
            get { return m_iLoggerBuffer; }
            set { m_iLoggerBuffer = value; if (m_iLoggerBuffer > MAX_BUFFER_SIZE) { m_iLoggerBuffer = 0; } }
        }

        public static int ViewerBuffer
        {
            get { return m_iViewerBuffer; }
            set { m_iViewerBuffer = value; if (m_iViewerBuffer > MAX_BUFFER_SIZE) { m_iViewerBuffer = 0; } }
        }

        public static int RecieveDataCount
        {
            get { return m_iRecieveDataCount = 0; }
            set
            {
                m_iRecieveDataCount = value;
                if (m_iRecieveDataCount > 1000000)
                    m_iRecieveDataCount = 0;
            }
        }
    }
}
