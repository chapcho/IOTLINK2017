using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnergyVision
{

    [Serializable]
    public class CProject : IDisposable
    {

        #region Member Variables

        protected string m_sName = "";
        protected string m_sPath = "";

        #endregion


        #region Initialize/Dispose

        public CProject()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Path
        {
            get { return m_sPath; }
            set { m_sPath = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
