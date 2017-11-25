using IOTL.Common.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IOTL.Common.Log
{
    public class CTimeLogS : List<CTimeLog>, IDisposable, ICloneable
    {
        #region Member Variables

        // Log는 하나의 단말 정보를 가지고 있습니다.
        IClient _clientConnection = null;

        protected DateTime _dtFirstTime = DateTime.MinValue;
        protected DateTime _dtLastTime = DateTime.MinValue;

        #endregion

        public CTimeLogS()
        {
            _clientConnection = null;
        }

        public CTimeLogS(IClient clientInfo)
        {
            _clientConnection = clientInfo;
        }

        /// <summary>
        /// 로그가 정상적인지 검토
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (_clientConnection == null)
            {
                Debug.WriteLine("\r\n\r\n연결된 단말 정보가 없습니다.\r\n\r\n");

                return false;
            }
            return true;
        }

        public void SetClientInfo(IClient clientInfo)
        {
            _clientConnection = clientInfo;
        }


        /// <summary>
        /// Log의 시간 간격을 갱신 합니다.
        /// </summary>
        public void UpdateTimeRange()
        {
            if (!Validation())
            {
                return;
            }

            if (this.Count == 0)
            {
                _dtFirstTime = DateTime.MinValue;
                _dtLastTime = DateTime.MinValue;
            }
            else
            {
                _dtFirstTime = this.First().LogTime;
                _dtLastTime = this.Last().LogTime;
            }
        }

        public LogBase GetFirstTimeLog()
        {
            if (!Validation())
            {
                return null;
            }

            if (this.Count == 0) return null;
            else return this.First();
        }


        /// <summary>
        /// 특정 시점이후에 첫 데이터를 찾습니다.
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <returns></returns>
        public LogBase GetFirstTimeLog(DateTime dtFrom)
        {
            LogBase logFound = null;
            CTimeLog timeLog = null;

            if (!Validation())
            {
                return null;
            }

            for (int i = 0; i < this.Count; i++)
            {
                timeLog = this[i];
                if(timeLog.LogTime > dtFrom)
                {
                    logFound = this[i];
                    break;
                }
            }

            return logFound;
        }

        /// <summary>
        /// 수집된 최종 로그
        /// </summary>
        /// <returns></returns>
        public LogBase GetLastLog()
        {
            if (!Validation())
            {
                return null;
            }
            if (this.Count == 0) return null;
            else return this.Last();
        }

        public LogBase GetLastLog(DateTime dtTo)
        {
            LogBase logFound = null;
            CTimeLog timeLog = null;
            for (int i = this.Count - 1; i > -1; i--)
            {
                timeLog = this[i];
                if (timeLog.LogTime < dtTo)
                {
                    logFound = timeLog;
                    break;
                }
            }

            return logFound;
        }


        object ICloneable.Clone()
        {
            CTimeLogS cLogS = new CTimeLogS();
            CTimeLog cLog;
            for (int i = 0; i < this.Count; i++)
            {
                cLog = (CTimeLog)this[i].Clone();
                cLogS.Add(cLog);
            }

            cLogS._clientConnection = _clientConnection;
            cLogS._dtFirstTime = _dtFirstTime;
            cLogS._dtLastTime = _dtLastTime;

            return cLogS;
        }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            Clear();
        }


        public List<CTimeLog> FilterTimeLog(string sKey)
        {
            if(!Validation())
            {
                return null;
            }
            return this.Where(p => p.Key.Equals(sKey)).ToList();
        }

        // 로그가 기록되어야 하는지 검토 하고 필요시 기록해야 한다.

    }
}
