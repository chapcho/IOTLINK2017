using IOTL.Common.Framework;
using System;
using System.Text;

namespace IOTL.Common.Log
{
    /// <summary>
    /// 시간순으로 기록되는 로그를 저장한 기본 구조 정의
    /// </summary>
    public class CTimeLog : LogBase
    {
        #region Member Variables

        protected DateTime _dtTime = DateTime.MinValue;    // Log 수신시간
        protected IReceiveData _objReceiveData;

        private EMDataType _logDataType = EMDataType.BytesData; // 양식이 정해진 문자열 데이터

        private byte[] _dataLog = new byte[1024];
        private string _dataString = String.Empty;
        private int _dataValue = -1;
        private int _dataLength = 0;

        public CTimeLog(string sKey, string sDescription, EMDataType dataType) : base(sKey, sDescription)
        {
            this._logDataType = dataType;
            // 초기에는 접속된 단말도,수신한 데이터도 없다.
            _objReceiveData = null;
        }

        #endregion

        public DateTime LogTime
        {
            get { return _dtTime; }
            set { _dtTime = value; }
        }

        /// <summary>
        /// 로그 데이터 타입에 따라서, 길이를 설정하는 방법이 달라질 수 있다.
        /// </summary>
        public IReceiveData SetReceiveData
        {
            set
            {
                _objReceiveData = value;
                switch(this._logDataType)
                {
                    case EMDataType.ByteData:
                        _dataLength = value.Length;
                        break;
                    case EMDataType.BytesData:
                        _dataLength = value.Length;
                        break;
                    case EMDataType.StringData:
                        _dataLength = value.Length;
                        break;
                    case EMDataType.HexaData:
                        _dataLength = value.Length;
                        break;
                    case EMDataType.NumericData:
                        _dataLength = value.Length;
                        break;
                }
            }
        }

        public IReceiveData GetReceiveData
        {
            get { return _objReceiveData; }
        }

        public string GetReceiveDataToHex()
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        /// <summary>
        /// 수신 로그의 길이
        /// </summary>
        public int Length
        {
            get { return _dataLength; }
        }

        public override object Clone()
        {
            // Make swallow copy
            CTimeLog log = new CTimeLog(Key, Description,_logDataType);

            log.SetReceiveData = this._objReceiveData;
            log.LogTime = this._dtTime;

            return log; 
        }
    }
}
