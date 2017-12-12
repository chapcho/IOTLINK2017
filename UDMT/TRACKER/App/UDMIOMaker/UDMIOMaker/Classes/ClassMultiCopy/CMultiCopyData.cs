using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.Class_MultiCopy
{
    public partial class CMultiCopy_Data
    {

        protected Dictionary<string, string> _dicData = new Dictionary<string, string>();

        #region Initialize/Dispose

        public CMultiCopy_Data()
        {

        }

        public void Dispose()
        {
            _dicData.Clear();
        }

        #endregion

        #region Public Properites

        public Dictionary<string, string> Data
        {
            get { return _dicData; }
            set { _dicData = value; }
        }

        #endregion

        #region Public Methods

        public void InputDragData(object ofile)
        {
            foreach (string file in (string[])ofile)
            {
                string FileName = file.Substring(file.LastIndexOf('\\') + 1);

                _dicData.Add(FileName, file);

            }

        }

        #endregion

        #region Private Mehtods

        #endregion
    }
}
