using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.EnergyProcAgent.Config;

namespace UEnergyProcAgent
{
    [Serializable]
    public class CProject : IDisposable
    {

        #region Member Variables

        protected string m_sName = "NewProject";
        protected CConfig m_cConfig = new CConfig();

        #endregion


        #region Initialize/Dispose

        public CProject()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properites

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public CConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            if (m_cConfig != null)
                m_cConfig.Clear();
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
