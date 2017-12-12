using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewIOMaker.Enumeration.Enum_Common;

namespace NewIOMaker.Classes.Class_TagGenerator.Core
{
    /// <summary>
    /// 지원하는 HMI 프로그램에 대한 파일 포멧 정보 클래스
    /// 해더 유무, 라인 수 , 확장자
    /// </summary>
    /// 

    public class InfoHMI
    {

        protected bool _Header = false;
        protected int _HeaderLine = 0;
        protected string _Extension = string.Empty;

        #region Intialize/Dispose

        public InfoHMI(string HMI)
        {
            InputInfoHMI(HMI);
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

        #region Public Methods

        protected void InputInfoHMI(string HMI)
        {
            if (EMCommonHMIPrograms.XP_Builder.ToString().Equals(HMI))
            {
                _Header = true;
                _HeaderLine = 3;
                _Extension = "*.csv|*.csv|*.txt|*.txt";
            }
            else
                return;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
