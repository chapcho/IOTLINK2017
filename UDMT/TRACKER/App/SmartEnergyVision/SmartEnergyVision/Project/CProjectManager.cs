using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UDM.General.Serialize;

namespace SmartEnergyVision.Project
{

    public static class CProjectManager
    {

        #region Member Variables

        private static CProject m_cProject = new CProject();

        #endregion


        #region Initialize/Dispose


        #endregion


        #region Public Properties

        public static CProject Project
        {
            get { return m_cProject; }
        }

        #endregion


        #region Public Methods

        public static bool New(string sName)
        {
            Clear();

            m_cProject.Name = sName;

            return true;
        }

        public static bool Open(string sPath)
        {
            Clear();

            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();
            m_cProject = (CProject)(cSerializer.Read(sPath));
            if (m_cProject != null)
                bOK = true;
            else
                m_cProject = new CProject();

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static bool Save(string sPath)
        {
            bool bOK = false;
            m_cProject.Path = sPath;
            CNetSerializer cSerializer = new CNetSerializer();
            bOK = cSerializer.Write(sPath, m_cProject);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static void Clear()
        {

        }

        #endregion


        #region Private Methods


        #endregion
    }
}
