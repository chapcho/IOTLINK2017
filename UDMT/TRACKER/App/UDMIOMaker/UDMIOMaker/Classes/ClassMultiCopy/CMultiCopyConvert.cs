using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.Class_MultiCopy
{
    class CMultiCopy_Convert
    {

        protected List<string> _lstShortCut = new List<string>();

        #region Initialize/Dispose

        public CMultiCopy_Convert(List<string> value)
        {
            ShortCutConvertFC(value);
        }

        #endregion

        #region Public Properites

        public List<string> ShortCut
        {
            get { return _lstShortCut; }
            set { _lstShortCut = value; }
        }

        #endregion

        #region Private Mehtods

        public void ShortCutConvertFC(List<string> value)
        {
            foreach (string values in value)
            {
                string sEmpty1 = string.Empty;
                string sEmpty2 = string.Empty;
                sEmpty1 = values.Replace("{", "");
                sEmpty2 = sEmpty1.Replace("}", "");

                _lstShortCut.Add(sEmpty2);
            }
        }

        #endregion
    }
}
