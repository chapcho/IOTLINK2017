using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UDM.General.Csv
{
    public interface ICsvIO : IDisposable
    {

        #region Public Properties

        List<string> Header {get;set;}

        EMFileState State {get;}

        EMCsvType CsvType {get;set;}

        #endregion


        #region Public Methods

        bool Open(string sPath);

        bool Close();

        #endregion
    }
}
