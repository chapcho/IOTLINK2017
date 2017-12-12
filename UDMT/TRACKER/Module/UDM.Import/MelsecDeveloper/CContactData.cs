using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CContactData
    {

        #region Member Variables

        protected EMContactType _emContactType = EMContactType.NONE;
        protected byte[] _nHeadExcludeByte = null;
        protected int _iMajor = -1;
        protected string _sHeader = string.Empty;
        protected string _sResult = string.Empty;
        protected string _sFusionResult = string.Empty;
        protected string _sNote = string.Empty;

        #endregion


        #region Initialze

        #endregion


        #region Properties

        public EMContactType ContactType
        {
            get { return _emContactType; }
            set { _emContactType = value; }
        }

        public byte[] HeadExcludeByte
        {
            set { _nHeadExcludeByte = value; }
        }

        /// <summary>
        /// @, ., Z, K를 붙에 인자를 완성시킨 값
        /// 위의 헤드를 갖는 Contact는 비어 있어야 함.
        /// </summary>
        public string FusionResultString
        {
            get { return _sFusionResult; }
            set { _sFusionResult = value; }
        }

        /// <summary>
        /// Byte를 분석한 그대로의 값
        /// </summary>
        public string ResultString
        {
            get { return _sResult; }
        }

        public string Header
        {
            get { return _sHeader; }
        }

        public string LadderNote
        {
            get { return _sNote; }
            set { _sNote = value; }
        }

        #endregion


        #region Public Method

        public bool SetAnanlyze(out string sNote)
        {
            sNote = "";
            if (_nHeadExcludeByte == null) return false;

            CLadderAnalyzer cAnalyzer = new CLadderAnalyzer();
            int iValue = 0;
            _sResult = cAnalyzer.AnalyzeContactByte(_nHeadExcludeByte, out iValue);
        
            if (_sResult == "") return false;

            if (_sResult.Contains("."))
                _emContactType = EMContactType.DOT;
            else if (_sResult.Contains("@"))
                _emContactType = EMContactType.Header_AT;
            else if (cAnalyzer.CheckContactHeader(_nHeadExcludeByte[0]))
            {
                string sHeader = cAnalyzer.GetHeader(_nHeadExcludeByte[0]);
                if (sHeader == ";") //노트
                {
                    byte[] nNote = new byte[_nHeadExcludeByte.Length - 2];
                    for (int i = 0; i < nNote.Length; i++)
                        nNote[i] = _nHeadExcludeByte[i + 2];

                    sNote = Encoding.Default.GetString(nNote);
                    if (sNote != "")
                        sNote = ",,,,," + Encoding.Default.GetString(nNote) + ",,";
                    else
                    {
                        if (_nHeadExcludeByte.Length == 2)
                        {
                            if (_nHeadExcludeByte[0] == 0x82 && _nHeadExcludeByte[1] == 0x01)
                            {
                                sNote = ",,,,,*,,";
                            }
                        }
                    }

                    return false;
                }

                if (sHeader != "Z" && sHeader != "K")
                    _emContactType = EMContactType.Address;
                else if (sHeader == "K" && iValue > 8)
                    _emContactType = EMContactType.Constant_K;
                else if (sHeader == "K" && iValue < 0)
                    _emContactType = EMContactType.Constant_K;
                else if (sHeader == "H")
                    _emContactType = EMContactType.Constant_K;

                _sHeader = sHeader;
                _iMajor = iValue;
            }
            
            return true;
        }

        #endregion
    }
}
