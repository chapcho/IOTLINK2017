using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CContentS : List<CContent>,  IDisposable,ICloneable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CContentS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Propoerties


        #endregion


        #region Public Methods

        public object Clone()
        {
            CContentS tempContentS = new CContentS();

            foreach(CContent tempContent in this)
            {
                tempContentS.Add((CContent)tempContent.Clone());
            }

            return tempContentS;
        }

        #endregion
    }
}
