using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDModule:CObject,ICloneable
    {
        #region Member Variables
        protected string m_sModuleName = string.Empty;
        protected string m_sCatalogName = string.Empty;
        protected int m_iSlot = 0;
        protected string m_sParent = string.Empty;
        #endregion

        #region Initialize/Dispose

        public CLDModule()
        {

        }

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
        /// CatalogNumber
        /// </summary>
        public string CatalogNumber
        {
            get { return m_sCatalogName; }
            set { m_sCatalogName = value; }
        }

        /// <summary>
        /// BaseBoard Slot Number
        /// </summary>
        public int SlotNumber
        {
            get { return m_iSlot; }
            set { m_iSlot = value; }
        }

        /// <summary>
        /// Parent Name
        /// </summary>
        public string Parent
        {
            get { return m_sParent; }
            set { m_sParent = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CLDModule ctempModule = new CLDModule();

            ctempModule.Key = m_sKey;
            ctempModule.ModuleName = m_sModuleName;
            ctempModule.m_sCatalogName = m_sCatalogName;
            ctempModule.SlotNumber = m_iSlot;
            ctempModule.Parent = m_sParent;

            return ctempModule;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
