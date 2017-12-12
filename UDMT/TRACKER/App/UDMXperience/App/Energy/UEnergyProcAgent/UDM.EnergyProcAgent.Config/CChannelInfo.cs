using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.EnergyProcAgent.Config
{
    [Serializable]
    public class CChannelInfo : IDisposable
    {

        #region Member Variables

        protected string m_sLayer = "";
        protected string m_sChannel = "";

        #endregion


        #region Initialize/Dispose

        public CChannelInfo()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Layer
        {
            get { return m_sLayer; }
            set { m_sLayer = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }


        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
