using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CRDunnettT3Result : IRDunnettT3Result
    {
               
        #region Member Variables

        private string[] m_sGroupName = null;

        private float[] m_nGroupDiff = null;

        private float[] m_nGroupLowerCI = null;
        
        private float[] m_nGroupUpperCI = null;

        #endregion


        #region Intialize/Dispose

        public CRDunnettT3Result()
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
        public float[] GroupLowerCI
        {
            get { return m_nGroupLowerCI; }
            set { m_nGroupLowerCI = value; }
        }
        public float[] GroupUpperCI
        {
            get { return m_nGroupUpperCI; }
            set { m_nGroupUpperCI = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CRDunnettT3Result cResult = new CRDunnettT3Result();
            cResult.GroupName = m_sGroupName;
            cResult.GroupDiff = m_nGroupDiff;
            cResult.GroupLowerCI = m_nGroupLowerCI;
            cResult.GroupUpperCI = m_nGroupUpperCI;

            return cResult;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
