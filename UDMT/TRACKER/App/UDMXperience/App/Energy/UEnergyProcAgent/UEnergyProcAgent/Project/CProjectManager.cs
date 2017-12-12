using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using UDM.General.Serialize;
using UDM.EnergyProcAgent.Config;

namespace UEnergyProcAgent
{
    public static class CProjectManager
    {

        #region Member Variables
        
        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public static bool Save(string sPath, CProject cProject)
        {
            bool bOK = false;

            try
            {
                CNetSerializer cSerializer = new CNetSerializer();
                bOK  = cSerializer.Write(sPath, cProject);
                cSerializer.Dispose();
                cSerializer = null;
            }
            catch(System.Exception ex)
            {
                ex.Data.Clear();
            }

            return bOK;
        }

        public static CProject Open(string sPath)
        {
            CProject cProject = null;

            try
            {
                CNetSerializer cSerializer = new CNetSerializer();
                object oData = cSerializer.Read(sPath);
                cProject = oData as CProject;

                cSerializer.Dispose();
                cSerializer = null;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return cProject;
        }

        #endregion


        #region Private Methods

        
        #endregion
    }
}
