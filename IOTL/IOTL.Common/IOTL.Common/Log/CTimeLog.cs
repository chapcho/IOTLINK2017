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

        // 사용자 데이터 클래스로 오면, 소켓의 원데이터는 이제 필요 없다.
        // 여기서는 데이터를 파싱해서 넣도록 한다.

        protected DateTime _dtTime = DateTime.MinValue;    // Log 수신시간
        protected bool _readFromCsv = false; // CSV에서 읽은 데이터를 다시 CSV로 저장하지 않기 위한 구분 필드

        //protected string 
        protected byte[] _objReceiveData = null;
        public CTimeLog(string sKey, string sDescription) : base(sKey, sDescription)
        {

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
        public byte[] ReceiveData
        {
            get { return _objReceiveData; }
            set {
                _objReceiveData = value;
                _dtTime = DateTime.Now;
            }
        }

        public bool ReadFromCSV
        {
            get { return _readFromCsv; }
            set { _readFromCsv = value; }
        }

        public string GetReceiveDataToHex()
        {
            StringBuilder sb = new StringBuilder();

            if(ReceiveData != null)
            {
                foreach(byte data in ReceiveData)
                {
                    sb.Append(string.Format("{0:X2}",data));
                }
                return sb.ToString();
            }
            return string.Empty;
        }

        public override string ToString()
        {
            if(ReceiveData != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach(byte data in ReceiveData)
                {
                    sb.Append(data);
                }
                return sb.ToString();
            }
            return base.ToString();
        }

        /// <summary>
        /// 수신 로그의 길이
        /// </summary>
        public int Length
        {
            get { return _objReceiveData.Length; }
        }

        public override object Clone()
        {
            // Make swallow copy
            CTimeLog log = new CTimeLog(Key, Description);

            log.ReceiveData = this._objReceiveData;
            log.LogTime = this._dtTime;

            return log; 
        }
    }
}
