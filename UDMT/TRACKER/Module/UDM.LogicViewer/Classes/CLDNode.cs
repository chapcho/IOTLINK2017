using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using UDM.Common;

namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDNode : ICloneable
    {
        private string m_sAddress = string.Empty;
        private string m_sSymbol = string.Empty;
        public EMContactState eILMonitor = EMContactState.Off;

        #region Initialize/Dispose

        public CLDNode()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        #region Public interface

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Symbol
        {
            get { return m_sSymbol; }
            set { m_sSymbol = value; }
        }

        #endregion

        #region Public Method

        #endregion

        #region Private Method

        #endregion
    }


}