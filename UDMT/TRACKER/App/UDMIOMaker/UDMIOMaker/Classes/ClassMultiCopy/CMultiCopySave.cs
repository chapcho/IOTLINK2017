using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.Class_MultiCopy
{
    public partial class CMultiCopy_Save
    {


        protected Dictionary<string, List<string>> _DicKey = new Dictionary<string, List<string>>();


        #region Initialize/Dispose

        public CMultiCopy_Save(Dictionary<string, List<string>> DicKey)
        {
            _DicKey = DicKey;
        }

        public void Dispose()
        {

        }

        #endregion

        #region Public Properties

        public Dictionary<string, List<string>> Save
        {
            get { return _DicKey; }
            set { _DicKey = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Privat Methods

        #endregion
    }
}
