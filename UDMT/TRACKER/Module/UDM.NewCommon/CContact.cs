using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CContact:CUnit
    {
        #region Member Variables
        protected EMContactType m_EMContactType = EMContactType.None;
        #endregion

        #region Initialize/Dispose

        public CContact()
        {

        }

        #endregion

        #region Public Properties

        public EMContactType ContactType
        {
            get { return m_EMContactType; }
            set { m_EMContactType = value; }
        }

        #endregion

        #region Public Methods

        public override object Clone()
        {
            CContact cUnit = (CContact)base.Clone(this.GetType());

            cUnit.ContactType = m_EMContactType;

            return cUnit;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
