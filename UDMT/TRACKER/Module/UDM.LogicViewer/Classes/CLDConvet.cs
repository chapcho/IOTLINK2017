using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;


namespace UDM.ILConverter
{
    [Serializable]
    public class CLDConvet
    {
        private CILRungS m_cILRungS = null;
        
        #region Initialize/Dispose

        public CLDConvet(CStepS cStepS)
        {
            m_cILRungS = CreateRungS(cStepS);
        }

        public void Dispose()
        {

        }

        #endregion

        #region Public interface

        public CILRungS ILRungS
        {
            get { return m_cILRungS; }
            set { m_cILRungS = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Privates Methods

        private CILRungS CreateRungS(CStepS cStepS)
        {
            CILRungS cILRungS = new CILRungS();

            foreach (CStep cStep in cStepS)
            {
                CILRung cILRung = new CILRung(cStep);

                cILRungS.Add(cILRung.CoilKey, cILRung);
            }

           // CreateColorRowSub(cILRungS);

            return cILRungS;
        }
      
        #endregion
    }
}
