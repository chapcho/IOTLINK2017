using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UDM.General.Xml
{
    public interface IXmlIO : IDisposable
    {

        #region Public Properties

        EMFileState FileState {get;}

        #endregion


        #region Public Methods

        bool Open(string sPath);

        bool Close();

        #endregion
    }
}
