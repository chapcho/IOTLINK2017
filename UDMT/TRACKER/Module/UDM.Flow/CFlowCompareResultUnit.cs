using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    public class CFlowCompareResultUnit : IDisposable
    {

        #region Member Variables

        protected CTimeNode m_cNode = null;
        protected CFlowLink m_cLink = null;        
        protected EMDifferenceType m_emDiffType = EMDifferenceType.Unknown;

        #endregion


        #region Initialize/Dispose


        public CFlowCompareResultUnit()
        {

        }

        public CFlowCompareResultUnit(CTimeNode cNode, EMDifferenceType emDiffType)
        {
            m_cNode = cNode;
            m_emDiffType = emDiffType;
        }

        public CFlowCompareResultUnit(CFlowLink cLink, EMDifferenceType emDiffType)
        {
            m_cNode = (CTimeNode)cLink.NodeTo;
            m_cLink = cLink;
            m_emDiffType = emDiffType;
        }

        public void Dispose()
        {


        }

        #endregion


        #region Public Properties

        public CTimeNode TimeNode
        {
            get { return m_cNode; }
            set { m_cNode = value; }
        }

        public CFlowLink TimeNodeLink
        {
            get { return m_cLink; }
            set { m_cLink = value; }
        }

        public EMDifferenceType DifferenceType
        {
            get { return m_emDiffType; }
            set { m_emDiffType = value; }
        }

        #endregion
    }
}
