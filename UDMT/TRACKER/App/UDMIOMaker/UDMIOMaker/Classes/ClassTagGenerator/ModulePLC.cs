using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    /// <summary>
    /// PLC DataTable을 생성하는 클래스
    /// </summary>
    /// 
    public class ModulePLC
    {
        protected DataTable _dbPLC = new DataTable();
        protected string _Extension = string.Empty;

        #region Intialize/Dispose

        public ModulePLC(int Cpu , string PLCInfo)
        {

            FileReader(Cpu, PLCInfo);

        }

        #endregion

        #region Public Properites

        public DataTable dbPLC
        {
            get { return _dbPLC; }
            set { _dbPLC = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }


        #endregion

        #region Public Methods

        protected void FileReader(int Cpu ,string PLCType)
        {
            DataTable db = new DataTable();

            OpenPLC cPlc = new OpenPLC(PLCType);

            CommonReader cReader = new CommonReader();

            bool bOK = cReader.Open(cPlc.PLCPath, cPlc.Header, cPlc.Line);

            cReader.Fill(db);

            if (!PLCType.Equals("Developer"))
            {
                HeaderPLC cHeaderPLC = new HeaderPLC(PLCType, Cpu, db);
                _dbPLC = cHeaderPLC.db;
            }
            else
                _dbPLC = db;
           
            _Extension = cPlc.Extension;

        }

        #endregion
    }
}
