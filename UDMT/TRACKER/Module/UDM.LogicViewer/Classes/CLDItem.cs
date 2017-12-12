using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using System.Drawing;

namespace UDM.LogicViewer
{

    [Serializable]
    public class CLDItem : ICloneable
    {
        private string m_sAddress = string.Empty;
        private string m_sSymbol = string.Empty;
        public EMMonitor m_emMonitor = EMMonitor.OFF;

        #region Initialize/Dispose

        public CLDItem()
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

        public EMMonitor Monitor
        {
            get { return m_emMonitor; }
            set { m_emMonitor = value; }
        }

        #endregion

        #region Public Method

        #endregion

        #region Private Method

        #endregion
    }


}