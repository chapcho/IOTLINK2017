using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]    
    public class CCondition : CObject
    {

        #region Member Variables

        protected string m_sAddress = "";
        protected int m_iTargetValue = 1;
        protected int m_iValue = -1;
        protected EMOperaterType m_emOperatorType = EMOperaterType.None;

        #endregion


        #region Initialize/Dispose

        public CCondition()
        {

        }

        public CCondition(string sKey, string sAddress, int iTargetValue, EMOperaterType emOperatorType)
        {
            m_sKey = sKey;
            m_sAddress = sAddress;
            m_iTargetValue = iTargetValue;
            m_emOperatorType = emOperatorType;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public int TargetValue
        {
            get { return m_iTargetValue; }
            set { m_iTargetValue = value; }
        }

        public EMOperaterType OperatorType
        {
            get { return m_emOperatorType; }
            set { m_emOperatorType = value; }
        }

        #endregion


        #region Public Methods

        public void Set(int iValue)
        {
            m_iValue = iValue;
        }

        public void Reset()
        {
            m_iValue = -1;
        }

        public bool CheckSatisfied()
        {
            bool bSatisfied = false;

            if (m_iValue == m_iTargetValue)
                bSatisfied = true;

            return bSatisfied;
        }

        #endregion
    }
}
