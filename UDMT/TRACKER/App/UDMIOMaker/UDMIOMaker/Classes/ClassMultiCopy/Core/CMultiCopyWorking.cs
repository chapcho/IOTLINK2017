﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace NewIOMaker.Classes.ClassMultiCopy
{
    public partial class CMultiCopyWorking
    {

        protected string _Richbox = string.Empty;

        #region Initialize/Dispose

        public CMultiCopyWorking(List<string> value)
        {
            KeySetting(value);
        }

        #region Public Properites

        public string RichBoxText
        {
            get { return _Richbox; }
            set { _Richbox = value; }
        }

        #endregion

        #endregion

        #region Public Methods

        public void KeySetting(List<string> value)
        {
            foreach(string values in value)
            {
                SendKeys.SendWait(values);
                Thread.Sleep(3);
            }
        }

        public void KeyRichText(List<string> value)
        {
            foreach (string values in value)
            {
                _Richbox = _Richbox + values;
            }

        }

        #endregion
    }
}