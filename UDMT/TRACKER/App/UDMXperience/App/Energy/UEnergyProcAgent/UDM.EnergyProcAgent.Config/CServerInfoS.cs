using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.EnergyProcAgent.Config
{
    [Serializable]
    public class CServerInfoS : Dictionary<string, CServerInfo>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CServerInfoS()
        {

        }        

        public void Dispose()
        {

        }

        protected CServerInfoS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties
                
        public CServerInfo this[int iIndex]
        {
            get { return this.ElementAt(iIndex).Value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
