using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.General.Serialize;
using UDM.Log;

namespace UDMOptraManager
{
    public static class CProjectManager
    {
        #region Member Variables

        private static string m_sManagerProjectPath = Application.StartupPath + "\\TrackerManager.ump";

        private static CBaseProject m_cBaseproject = new CBaseProject();
        private static CSystemLog m_cSysLog = null;

        #endregion

        #region Properties

        public static string ManagerProjectPath
        {
            get { return m_sManagerProjectPath; }
            //set { m_sManagerProjectPath = value; }
        }

        public static CBaseProject BaseProject
        {
            get { return m_cBaseproject; }
            set { m_cBaseproject = value; }
        }
        public static CSystemLog SystemLog
        {
            get { return m_cSysLog; }
            set { m_cSysLog = value; }
        }

        #endregion

        #region Public Methods
        public static bool Open(string sPath)
        {
            bool bOK = false;
            try
            {
                CNetSerializer cSerializer = new CNetSerializer();

                CBaseProject cBaseProject = (CBaseProject)(cSerializer.Read(sPath));
                if (cBaseProject != null)
                {
                    m_cBaseproject = cBaseProject;

                    cSerializer.Dispose();
                    cSerializer = null;

                    bOK = true;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return bOK;
        }

        public static bool Save(string sPath)
        {
            bool bOK = false;

            try
            {
                string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));

                if (!Directory.Exists(sFolderPath))
                    Directory.CreateDirectory(sFolderPath);

                CNetSerializer cSerializer = new CNetSerializer();

                bOK = cSerializer.Write(m_sManagerProjectPath, m_cBaseproject);

                cSerializer.Dispose();
                cSerializer = null;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return bOK;
        }

        #endregion

        #region Private Method
        #endregion


  
    }
}
