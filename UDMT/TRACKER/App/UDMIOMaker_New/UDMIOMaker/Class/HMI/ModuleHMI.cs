using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UDMIOMaker;


namespace UDMIOMaker
{
    /// <summary>
    /// HMI DataTable을 생성하는 클래스
    /// </summary>
    /// 
    public class ModuleHMI
    {
        protected DataTable _dbHMI = new DataTable();
        private bool m_bFileOpen = false;

        #region Intialize/Dispose

        public ModuleHMI(string HMIType)
        {
            FileReader(HMIType);
        }

        #endregion

        #region Public Properites

        public bool IsFileOpen
        {
            get { return m_bFileOpen;}
            set { m_bFileOpen = value; }
        }

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

            m_bFileOpen = bOK;

            if (bOK)
            {
                cReader.Fill(_dbHMI);
                ConfirmHMI();
            }
        }

        protected void ConfirmHMI()
        {
            CXPBuilder format = new CXPBuilder();

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
