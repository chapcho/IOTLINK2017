using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDLModule
    {
        protected string m_sModuleName = string.Empty;
        protected string m_sCatalogNum = string.Empty;
        protected string m_sSlot = string.Empty;
        protected string m_sParent = string.Empty;

        #region Intialize/Dispose
        #endregion

        #region Public Properties
        /// <summary>
        /// Module Name
        /// </summary>
        public string ModuleName
        {
            get { return m_sModuleName; }
            set { m_sModuleName = value; }
        }

        /// <summary>
        /// CatalogNum of each module
        /// </summary>
        public string CatalogNum
        {
            get { return m_sCatalogNum; }
            set { m_sCatalogNum = value; }
        }

        /// <summary>
        /// Module Position
        /// </summary>
        public string Slot
        {
            get { return m_sSlot; }
            set { m_sSlot = value; }
        }

        public string Parent
        {
            get { return m_sParent; }
            set { m_sParent = value; }
        }
        #endregion

        #region Public Methods
        public string ModuleInfo()
        {
            string sTemp = string.Empty;
            try
            {
                sTemp = "MODULE  " + m_sModuleName + "  \t" + m_sSlot + "  \t" + m_sCatalogNum;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sTemp;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
