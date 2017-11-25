using System;

namespace IOTL.Common.Xml
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
