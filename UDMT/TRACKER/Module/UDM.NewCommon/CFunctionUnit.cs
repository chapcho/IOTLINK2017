using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CFunctionUnit:CUnit
    {
        #region Member Variables
        protected string m_sBlockName = string.Empty;
        protected CParaMappingInfo m_cParaMappingInfo = null;
        #endregion

        #region Initialize/Dispose

        public CFunctionUnit()
        {
            m_cParaMappingInfo = new CParaMappingInfo();
        }

        public new void Dispose()
        {
            m_cParaMappingInfo.Clear();
            base.Dispose();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Original Function BlockName
        /// </summary>
        public string BlockName
        {
            get { return m_sBlockName; }
            set { m_sBlockName = value; }
        }

        public CParaMappingInfo ParaMappingInfo
        {
            get { return m_cParaMappingInfo; }
            set { m_cParaMappingInfo = value; }
        }
        #endregion

        #region Public Methods

        public override object Clone()
        {

            CFunctionUnit cUnit = (CFunctionUnit)base.Clone(this.GetType());

            cUnit.BlockName = m_sBlockName;
            cUnit.ParaMappingInfo = (CParaMappingInfo)m_cParaMappingInfo.Clone();

            return cUnit;
        }


        #endregion

        #region Private Methods

        #endregion
    }
}
