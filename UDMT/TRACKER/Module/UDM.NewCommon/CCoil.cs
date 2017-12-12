using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CCoil:CUnit
    {
        #region Member Variables

        protected EMCoilType m_emCoilType = EMCoilType.None;

        #endregion

        #region Initialize/Dispose

        public CCoil()
        {

        }

        #endregion

        #region Public Properties

        public EMCoilType CoilType
        {
            get { return m_emCoilType; }
            set { m_emCoilType = value; }
        }

        public void Dispase()
        {

        }

        #endregion

        #region Public Methods
        
        public override object Clone()
        {
            CCoil cUnit = (CCoil)base.Clone(this.GetType());

            cUnit.CoilType = m_emCoilType;

            return cUnit;
        }


        #endregion

        #region Private Methods

        #endregion
    }
}
