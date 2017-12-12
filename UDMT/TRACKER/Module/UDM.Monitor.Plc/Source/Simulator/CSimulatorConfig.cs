using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.Simulator
{
    public class CSimulatorConfig : IDisposable
    {

        #region Member Variables

        private CTimeLogS m_cLogS = null;
        private int m_iSpeed = 1;

        #endregion


        #region Initialize/Dispose

        public CSimulatorConfig()
        {

        }

        public void Dispose()
        {
            m_cLogS = null;
        }

        #endregion


        #region Public Properties

        public CTimeLogS LogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }

        public int Speed
        {
            get { return m_iSpeed; }
            set { m_iSpeed = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
