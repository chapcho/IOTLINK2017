using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CMelsecCommand
    {
        #region Member Variavles

        private string _sCommand = string.Empty;
        private int _iFactorCount = 0;
        private int _iStepNumberCount = 0;

        #endregion


        #region Properties

        public string Command
        {
            get { return _sCommand; }
            set { _sCommand = value; }
        }

        public int FactorCount
        {
            get { return _iFactorCount; }
            set { _iFactorCount = value; }
        }

        public int StepNumberCount
        {
            get { return _iStepNumberCount; }
            set { _iStepNumberCount = value; }
        }

        #endregion
    }
}
