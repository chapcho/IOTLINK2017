using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CILStepDataS : List<CILStepData>
    {
        #region Member Variables

        protected string _WPGFilePath = string.Empty;
        protected string _WPGFileName = string.Empty;
        protected string _sTilte = string.Empty;
        protected List<string> _lstStepString = new List<string>();

        #endregion


        #region Initialze

        #endregion


        #region Properties

        public string Tilte
        {
            get { return _sTilte; }
            set { _sTilte = value; }
        }

        public List<string> StepStringList
        {
            get { return _lstStepString; }
            set { _lstStepString = value; }
        }

        #endregion


        #region Public Method

        #endregion
    }
}
