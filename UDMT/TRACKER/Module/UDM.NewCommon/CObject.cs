using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CObject:IDisposable
    {
        #region Member Variables

        protected string m_sKey = "";

        #endregion


        #region Initialize/Dispose

        public CObject()
        {

        }

        public void Dispose()
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
