using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace UDM.General.Remote
{
    [DataContract()]
    public class CDataObject : IDisposable
    {

        #region Member Variables

        protected string m_sClient = "";

        #endregion


        #region Initialize/Dispose

        public CDataObject()
        {

        }

        public void Dispose()
        {

        }
        
        #endregion


        #region Public Properties

        [DataMember]
        public string Client
        {
            get { return m_sClient; }
            set { m_sClient = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
