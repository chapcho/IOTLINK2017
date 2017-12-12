using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc
{
    public class CMonitorErrorInfo : ICloneable, IDisposable
    {

        #region Member Variables

        private string m_sGroupKey = "";
        private CSymbol m_cSymbol = null;
        private EMMonitorGroupErrorType m_emErrorType = EMMonitorGroupErrorType.None;
        private int m_iValue = -1;
        
        #endregion


        #region Initialize/Dispose

        public CMonitorErrorInfo(string sGroup, EMMonitorGroupErrorType emErrorType)
        {
            m_sGroupKey = sGroup;
            m_emErrorType = emErrorType;
        }

        public CMonitorErrorInfo()
        {
            
        }

        public void Dispose()
        {

        }
        
        #endregion


        #region Public Properties

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        public CSymbol Symbol
        {
            get { return m_cSymbol; }
            set { m_cSymbol = value; }
        }

        public EMMonitorGroupErrorType ErrorType
        {
            get { return m_emErrorType; }
            set { m_emErrorType = value; }
        }

        public int Value
        {
            get { return m_iValue; }
            set { m_iValue = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CMonitorErrorInfo cInfo = new CMonitorErrorInfo(m_sGroupKey, m_emErrorType);
            cInfo.Symbol = m_cSymbol;
            cInfo.Value = m_iValue;

            return cInfo;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
