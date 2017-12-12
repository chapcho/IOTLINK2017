using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    
    /*
     * 디바이스 신호이력 목록
     * 프로세스에 속한 디바이스 신호이력 수집 정보.
     */
    public class CDeviceStepRunningInfoS : List<CDeviceStepRunningInfo>, ICloneable, IDisposable
    {
        #region Member Variables...

        private string _processName; // 디바이스의 신호이력을 모아두면, 공정을 구성하는 디바이스들의 정보가 된다.

        private CCondition _cycleStartCond;
        private CCondition _cycleEndCond;

        private DateTime _cycleStartDt;
        private DateTime _cycleEndDt;

        private int _stepTimeNormalRange;
        private int _runningTimeNormalRange;

        #endregion

        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }

        public DateTime CycleStartDt
        {
            get { return _cycleStartDt; }
            set { _cycleStartDt = value; }
        }

        public DateTime CycleEndDt
        {
            get { return _cycleEndDt; }
            set { _cycleEndDt = value; }
        }
        public CCondition CycleStartCond
        {
            get { return _cycleStartCond; }
            set { _cycleStartCond = value; }
        }

        public CCondition CycleEndCond
        {
            get { return _cycleEndCond; }
            set { _cycleEndCond = value; }
        }

        public CDeviceStepRunningInfoS()
        {
            _stepTimeNormalRange = 200;
            _runningTimeNormalRange = 100;

            _processName = string.Empty;
            _cycleStartDt = DateTime.MinValue;
            _cycleEndDt = DateTime.MinValue;
        }

        public CDeviceStepRunningInfoS(string processNm, DateTime startDt) 
            : this()
        {
            _processName = processNm;
            _cycleStartDt = startDt;
        }

        public void Dispose()
        {
            Clear();
        }

        public object Clone()
        {
            CDeviceStepRunningInfoS target = new CDeviceStepRunningInfoS();

            foreach(CDeviceStepRunningInfo item in this)
            {
                CDeviceStepRunningInfo src = new CDeviceStepRunningInfo();
                src = item;
                target.Add(src);
            }

            return target;
        }

        public int GetKeyIndex(string key)
        {
            for (int i = 0; i < this.Count; i++)
                if (this[i].Key.Equals(key)) return i;

            return -1;
        }

        /// <summary>
        /// 기준이 되는 디바이스 신호 목록(패턴)과 비교 대상과 신호 발생 시점 차이를 목록화
        /// 정의된 패턴과 비교하는 신호를 함께 표현할때, 상이한 디바이스 목록 생성.
        /// </summary>
        /// <param name="comparisonTarget"></param>
        /// <returns></returns>
        public List<string> GetPatternDiffDeviceList(CDeviceStepRunningInfoS comparisonTarget)
        {
            List<string> diffDeviceList = new List<string>();
            bool signalOccure = false;

            foreach(CDeviceStepRunningInfo src in this)
            {
                signalOccure = false;
                foreach(CDeviceStepRunningInfo target in comparisonTarget)
                {
                    if(target.Key.Equals(src.Key))
                    {
                        signalOccure = true;
                        if(  Math.Abs(target.StepMs - src.StepMs) > this._stepTimeNormalRange)
                        {
                            diffDeviceList.Add(src.Key);
                        }
                        else 
                        {
                            if(Math.Abs(target.RunningMs - src.RunningMs) > this._runningTimeNormalRange)
                            {
                                diffDeviceList.Add(src.Key);
                            }
                        }
                    }
                }

                if(!signalOccure)
                {
                    diffDeviceList.Add(src.Key);
                }
            }

            return diffDeviceList;
        }

        #region 패턴 일치율 계산
        /// <summary>
        /// 패턴의 일치율을 계산합니다.
        /// 신호가 누락된 경우 : 패턴을 구성하는 디바이스수를 참고하여 1/n 삭감.
        /// 신호가 지연 또는 선행한 경우 : 옵션으로 설정된 비율 만큼 삭감
        /// </summary>
        /// <param name="comparisonTarget"></param>
        /// <returns></returns>
        public float CompareMatchRate(CDeviceStepRunningInfoS comparisonTarget)
        {
            float matchRate = 0;

            foreach(CDeviceStepRunningInfo src in this)
            {
                if(comparisonTarget.GetKeyIndex(src.Key) != -1)
                {
                    matchRate += (float)(CompareStepRunningMs( src, comparisonTarget[comparisonTarget.GetKeyIndex(src.Key)] ) / this.Count());
                }
            }

            return matchRate;
        }

        /// <summary>
        /// 디바이스의 StepRunningMs를 비교하여 겹치는 정도를 계산한다.
        /// 정확하게 일치하면 100을 불일치하면 0을 리턴한다.
        /// 
        /// 2015.12.18 ijsong@udmtek 구현 필요
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private float CompareStepRunningMs(CDeviceStepRunningInfo src, CDeviceStepRunningInfo target)
        {
            float result = 0;
            int diffMs = src.StepMs - target.StepMs;
            
            if(src.OrderNo == target.OrderNo) // 신호상의 순서가 중요하다면..
            {
                if (diffMs > 0) return 100;
                else
                {
                    if ((-diffMs) > src.RunningMs) result = 50;
                    else result = 20;
                }
            }
            else
            {
                if (diffMs > 0) return 100;
                else
                {
                    if ((-diffMs) > src.RunningMs) result = 50;
                    else result = 20;
                }
            }

            return result;
        }

        #endregion
    }

    public class CDeviceTimeDiffenceReport
    {
        string _address;
        string _description;
        double _runningTime = 0;
        double _stepTime = 0;
        double _cycleStepTime = 0;
        double _logCount = 0;
        double _sumRunningTime = 0;

        DateTime _startDt;
        DateTime _endDt;

        public string Key
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double RunningTime
        {
            get { return _runningTime; }
            set { _runningTime = value; }
        }

        public double StepTime
        {
            get { return _stepTime; }
            set { _stepTime = value; }
        }

        public double CycleStepTime
        {
            get { return _cycleStepTime; }
            set { _cycleStepTime = value; }
        }

        public double LogCount
        {
            get { return _logCount; }
            set { _logCount = value; }
        }

        public double SumRunningTime
        {
            get { return _sumRunningTime; }
            set { _sumRunningTime = value; }
        }

        public DateTime StartTime
        {
            get { return _startDt; }
            set { _startDt = value; }
        }

        public DateTime EndTime
        {
            get { return _endDt; }
            set { _endDt = value; }
        }

        public double CalcDeviceRunningTime(List<CTimeLog> lstTimeLog, DateTime dtCheckStart, DateTime dtCheckEnd)
        {
            double dRunningTime = 0;

            for (int i = 0; i < lstTimeLog.Count; i++)
            {
                if (lstTimeLog[i].Time < dtCheckStart) continue;
                if (lstTimeLog[i].Time > dtCheckEnd) continue;

                if (lstTimeLog.Count > i + 1)
                {
                    dRunningTime += lstTimeLog[i + 1].Time.Subtract(lstTimeLog[i].Time).TotalMilliseconds;
                    i += 1;
                }
                else
                {
                    if (lstTimeLog[i].Time < dtCheckEnd)
                    {
                        dRunningTime += dtCheckEnd.Subtract(lstTimeLog[i].Time).TotalMilliseconds;
                    }
                    else
                        dRunningTime += lstTimeLog[i].Time.Subtract(dtCheckEnd).TotalMilliseconds;

                    i += 1;
                }
            }
            return dRunningTime;
        }
    }

    public class CReportTimePeriod
    {
        private DateTime _startDt = DateTime.MinValue;
        private DateTime _endDt = DateTime.MinValue;

        public DateTime StartDt
        {
            get { return _startDt; }
            set { _startDt = value; }
        }

        public DateTime EndDt
        {
            get { return _endDt; }
            set { _endDt = value; }
        }

        public CReportTimePeriod(DateTime startDt, DateTime endDt)
        {
            StartDt = startDt;
            EndDt = endDt;
        }
    }

    /// <summary>
    /// 하나의 Tag에 대한 의미 있는 값들의 리스트.
    /// 스탭시간,동작시간,로그수,동작시간합 목록화.
    /// Chart에 표현하기 위해 목록화
    /// 
    /// </summary>
    public class CTagCycleRunningStepMsS : List<double>
    {
        private CTag m_cTag = null;

        public CTagCycleRunningStepMsS(CTag tag)
        {
            m_cTag = tag;
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }
    }
}
