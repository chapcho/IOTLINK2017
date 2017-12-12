using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Enumeration;


namespace NewIOMaker.Classes.ClassTagGenerator
{
    /// <summary>
    /// HMI DataTable을 생성하는 클래스
    /// </summary>
    /// 
    public class ModuleHMI
    {
        protected CommonMessage _cMessage = new CommonMessage();
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

            CommonReader cReader = new CommonReader();

            if (cHmi.HMIPath == "")
                return;

            cReader.CsvType = EMCommonCsvType.Tab;

            bool bOK = cReader.Open(cHmi.HMIPath, cHmi.Header, cHmi.Line);

            if (bOK)
            {
                cReader.Fill(_dbHMI);
                ConfirmHMI();
            }
            else
                _cMessage.InuseFile();

        }

        protected void ConfirmHMI()
        {
            XPbuilderFormat format = new XPbuilderFormat();

            if (_dbHMI.Columns.Count != format.ColumnCount || 
                _dbHMI.Columns[0].ToString() != format.XpBuilderColumn0)
            {
                _dbHMI = null;
            }
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
