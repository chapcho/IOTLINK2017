using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CObject : IObject
    {

        #region Member Variables

        protected string m_sKey = "";

        #endregion


        #region Initialize/Dispose

        public CObject()
        {

        }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        #endregion


        #region Pubilc Methods


        #endregion

    }
}
