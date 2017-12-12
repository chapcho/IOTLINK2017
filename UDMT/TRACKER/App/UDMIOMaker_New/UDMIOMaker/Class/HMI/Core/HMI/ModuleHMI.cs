using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NewIOMaker.Classes.Class_TagGenerator.Base;
using NewIOMaker.Classes.Class_Common.Util;
using NewIOMaker.Enumeration.Enum_Common;

namespace NewIOMaker.Classes.Class_TagGenerator.Core
{
    /// <summary>
    /// HMI DataTable을 생성하는 클래스
    /// </summary>
    /// 
    class ModuleHMI
    {
        protected DataTable _dbHMI = new DataTable();

        #region Intialize/Dispose

        public ModuleHMI(string HMIType)
        {
            FileReader(HMIType);
        }

        #endregion

        #region Public Properites

        public DataTable dbHMI
        {
            get { return _dbHMI; }
            set { _dbHMI = value; }
        }

        #endregion

        #region Public Methods

        protected void FileReader(string HMIType)
        {
            OpenHMI cHmi = new OpenHMI(HMIType);

            Class_CommonReader cReader = new Class_CommonReader();

            cReader.CsvType = EMCommonCsvType.Tab;

            bool bOK = cReader.Open(cHmi.HMIPath, cHmi.Header, cHmi.Line);

            cReader.Fill(_dbHMI);

        }

        #endregion

        #region Private Methods

        #endregion

    }
}
