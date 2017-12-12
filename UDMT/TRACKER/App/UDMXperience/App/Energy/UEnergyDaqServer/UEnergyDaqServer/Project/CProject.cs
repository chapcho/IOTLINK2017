using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;

namespace UEnergyDaqServer
{
    [Serializable]
    public class CProject:IDisposable
    {

        #region Member Variables

        protected string m_sName = "NewProject";
        protected CConfigS m_cConfig = new CConfigS();

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

        public CConfigS Config
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
