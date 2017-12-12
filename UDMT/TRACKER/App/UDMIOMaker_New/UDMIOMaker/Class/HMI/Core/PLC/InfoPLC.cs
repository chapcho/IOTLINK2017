using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewIOMaker.Enumeration.Enum_TagGenerator;

namespace NewIOMaker.Classes.Class_TagGenerator.Core
{
    /// <summary>
    /// 지원하는 PLC 프로그램에 대한 파일 포멧 정보 클래스
    /// </summary>
    /// 

    public class InfoPLC
    {

        protected bool _Header = false;
        protected int _HeaderLine = 0;
        protected string _Extension = string.Empty;

        #region Initialize/Dispose


        public InfoPLC(string PLC)
        {
            InputInfoPLC(PLC);
        }

        public void Dipose()
        {

        }

        #endregion

        #region Public Properites

        public bool Header
        {
            get { return _Header; }
            set { _Header = value; }
        }

        public int Line
        {
            get { return _HeaderLine; }
            set { _HeaderLine = value; }
        }


        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }


        #endregion

        protected void InputInfoPLC(string PLC)
        {

            if (EMTagGeneratorPLCHeader.Step7_SDF.ToString().Equals(PLC))
            {
                _Header = false;
                _HeaderLine = 0;
                _Extension = "SDF Files(*.SDF)|*.SDF";
            }
            else if (EMTagGeneratorPLCHeader.Step7_AWL.ToString().Equals(PLC))
            {
                _Header = true;
                _HeaderLine = 3;
                _Extension = "AWL Files(*.AWL)|*.AWL";
            }
            else if (EMTagGeneratorPLCHeader.RSLogix_CSV.ToString().Equals(PLC))
            {
                _Header = true;
                _HeaderLine = 3;
                _Extension = "CSV Files(*.CSV)|*.CSV";
            }
            else if (EMTagGeneratorPLCHeader.RSLogix_L5K.ToString().Equals(PLC))
            {
                _Header = true;
                _HeaderLine = 3;
                _Extension = "L5K Files(*.L5K)|*.L5K";
            }
            else if (EMTagGeneratorPLCHeader.Developer.ToString().Equals(PLC))
            {
                _Header = true;
                _HeaderLine = 0;
                _Extension = "Developer.csv|*.csv";
            }
            else if (EMTagGeneratorPLCHeader.Works2.ToString().Equals(PLC))
            {
                _Header = false;
                _HeaderLine = 2;
                _Extension = "Works2.csv|*.csv";
            }
            else if (EMTagGeneratorPLCHeader.Works3.ToString().Equals(PLC))
            {
                _Header = false;
                _HeaderLine = 2;
                _Extension = "Works3.csv|*.csv";
            }
            else
                return;

        }

        #region Private Methods

        #endregion

    }
}
