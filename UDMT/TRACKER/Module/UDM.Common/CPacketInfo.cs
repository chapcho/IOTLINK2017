using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Common
{
    [Serializable]
    public class CPacketInfo : IDisposable
    {

        #region Member Variables

        protected CRefStepS m_cRefStepS = new CRefStepS();
        protected CRefTagS m_cRefTagS = new CRefTagS();

        #endregion


        #region Initialize/Dispose

        public CPacketInfo()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public CRefStepS RefStepS
        {
            get { return m_cRefStepS; }
            set { m_cRefStepS = value; }
        }

        public CRefTagS RefTagS
        {
            get { return m_cRefTagS; }
            set { m_cRefTagS = value; }
        }

        
        #endregion


        #region Public Methods

        public void Compose(CStepS cStepS, CTagS cTagS)
        {
            m_cRefStepS.Compose(cStepS);
            m_cRefTagS.Compose(cTagS);
        }

        public void Clear()
        {
            if (m_cRefStepS != null)
                m_cRefStepS.Clear();
            else
                m_cRefStepS = new CRefStepS();

            if (m_cRefTagS != null)
                m_cRefTagS.Clear();
            else
                m_cRefTagS = new CRefTagS();            
        }

        #endregion

    }
}
