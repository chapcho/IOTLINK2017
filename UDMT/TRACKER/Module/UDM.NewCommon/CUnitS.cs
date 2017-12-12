using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CUnitS:List<CUnit>,IDisposable,ICloneable
    {
        #region Member Variables

        #endregion

        #region Initialize/Dispose

        public void Dispose()
        {
            this.Clear();
        }

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        public object Clone()
        {
            CUnitS cTempUnitS = new CUnitS();

            foreach(CUnit tempUnit in this)
            {
                cTempUnitS.Add((CUnit)tempUnit.Clone());
            }

            return cTempUnitS;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
