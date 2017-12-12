using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowRule : IDisposable, ICloneable
    {

        #region Member Variables

        protected bool m_bLink = false;
        protected int m_iInterval = 1000;
        protected int m_iTolerance = 1000;
        protected EMLinkPointType m_emPointTypeFrom = EMLinkPointType.Start;
        protected EMLinkPointType m_emPointTypeTo = EMLinkPointType.Start;

        #endregion


        #region Initialize/Dispose

        public CFlowRule()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Proprerties

        public bool HasLink
        {
            get { return m_bLink; }
            set { m_bLink = value; }
        }

        public int Interval
        {
            get { return m_iInterval; }
            set { m_iInterval = value; }
        }

        public int Tolerance
        {
            get { return m_iTolerance; }
            set { m_iTolerance = value; }
        }

        public EMLinkPointType PointTypeFrom
        {
            get { return m_emPointTypeFrom; }
            set { m_emPointTypeFrom = value; }
        }

        public EMLinkPointType PointTypeTo
        {
            get { return m_emPointTypeTo; }
            set { m_emPointTypeTo = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CFlowRule cRuleClone = new CFlowRule();
            cRuleClone.HasLink = m_bLink;
            cRuleClone.Interval = m_iInterval;
            cRuleClone.Tolerance = m_iTolerance;
            cRuleClone.PointTypeFrom = m_emPointTypeFrom;
            cRuleClone.PointTypeTo = m_emPointTypeTo;

            return cRuleClone;
        }

        #endregion
    }
}
