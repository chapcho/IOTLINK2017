using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CRScheffeResult : IRScheffeResult
    {
        #region Member Variables

        private string[] m_sGroupName = null;

        private float[] m_nGroupDiff = null;

        private float[] m_nGroupPValue = null;

        private int[] m_nGroupSig = null;

        private float[] m_nGroupLCL = null;

        private float[] m_nGroupUCL = null;

        #endregion

        #region Intialize/Dispose

        public CRScheffeResult()
        {

        }

        #endregion

        #region Public Properties

        public string[] GroupName
        {
            get { return m_sGroupName; }
            set { m_sGroupName = value; }
        }
        public float[] GroupDiff 
        {
            get { return m_nGroupDiff; }
            set { m_nGroupDiff = value; }
        }
        public float[] GroupPValue 
        {
            get { return m_nGroupPValue; }
            set { m_nGroupPValue = value; }
        }
        public int[] GroupSig 
        {
            get { return m_nGroupSig; }
            set { m_nGroupSig = value; }
        }
        public float[] GroupLCL 
        {
            get { return m_nGroupLCL; }
            set { m_nGroupLCL = value; }
        }
        public float[] GroupUCL 
        {
            get { return m_nGroupUCL; }
            set { m_nGroupUCL = value; }
        }
        #endregion


        #region Public Methods

        public object Clone()
        {
            CRScheffeResult cResult = new CRScheffeResult();
            cResult.GroupName = m_sGroupName;
            cResult.GroupDiff = m_nGroupDiff;
            cResult.GroupPValue = m_nGroupPValue;
            cResult.GroupSig = m_nGroupSig;
            cResult.GroupLCL = m_nGroupLCL;
            cResult.GroupUCL = m_nGroupUCL;

            return cResult;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
