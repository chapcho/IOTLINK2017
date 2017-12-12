using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    public class CPatternMatchRate
    {
        #region Member Variables

        protected string _processName;
        protected string _cycleStartAddress;
        protected int _cycleStartValue;
        protected string _cycleEndAddress;
        protected int _cycleEndValue;
        protected DateTime _cycleStartDt;
        protected DateTime _cycleEndDt;
        protected float _patternMatchRate;

        /// <summary>
        /// 프로세스 디바이스 신호 발생 분석.
        /// </summary>
        protected List<CDeviceTimeDiffenceReport> _listTimeDefferenceReport = new List<CDeviceTimeDiffenceReport>();
        /// <summary>
        /// 프로세스 디바이스의 신호 발생 이력.
        /// </summary>
        protected List<CTimeLog> _timeLogS = new List<CTimeLog>();

        #endregion

        #region Initialize
        public CPatternMatchRate()
        {
            _processName = string.Empty;
            _cycleStartAddress = string.Empty;
            _cycleEndAddress = string.Empty;
            _cycleStartDt = DateTime.MinValue;
            _patternMatchRate = 0;
        }

        public CPatternMatchRate(string processName, string startAddress, string endAddress, DateTime startDt) : this()
        {
            _processName = processName;
            _cycleStartAddress = startAddress;
            _cycleEndAddress = endAddress;
            _cycleStartDt = startDt;
        }
        #endregion

        #region Public Properties

        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }
        public string CycleStartAddress
        {
            get { return _cycleStartAddress; }
            set { _cycleStartAddress = value; }
        }
        public string CycleEndAddress
        {
            get { return _cycleEndAddress; }
            set { _cycleEndAddress = value; }
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
        public float PatternMatchRate
        {
            get { return _patternMatchRate; }
            set { _patternMatchRate = value; }
        }
        public int CycleStartValue
        {
            get { return _cycleStartValue; }
            set { _cycleStartValue = value; }
        }
        public int CycleEndValue
        {
            get { return _cycleEndValue; }
            set { _cycleEndValue = value; }
        }
        public List<CTimeLog>ProcessTimeLogS
        {
            get { return _timeLogS; }
            set { _timeLogS = value; }
        }
        public List<CDeviceTimeDiffenceReport> ListTimeDifferenceReport
        {
            get { return _listTimeDefferenceReport; }
            set { _listTimeDefferenceReport = value; }
        }

        #endregion

        #region Public Method

        public void AddTimeLog(CTimeLog log)
        {
            // 사이클 시작이라면, 신호 이력과 매치Rate를 초기화 합니다.
            if(log.Key.Contains("]"+CycleStartAddress+"["))
            {
                if(log.Value.ToString().Equals(CycleStartValue.ToString()))
                {
                    PatternMatchRate = 0;
                    CycleStartDt = log.Time;
                    ProcessTimeLogS.Clear();
                }
            }
            ProcessTimeLogS.Add(log);
        }

        public void DeviceRunningTimeResolve(List<string> listPatternItem)
        {
            DateTime dtNextTimePoint = CycleStartDt;
            bool bStartTimeCheck = false;

            ListTimeDifferenceReport.Clear();

            for(int i = 0; i < listPatternItem.Count; i++)
            {
                CDeviceTimeDiffenceReport src = new CDeviceTimeDiffenceReport();
                List<CTimeLog> listTimeLog = new List<CTimeLog>();

                src.Key = listPatternItem[i];
                listTimeLog = (from timeLog in ProcessTimeLogS
                               where timeLog.Key.Equals(src.Key) && timeLog.Time >= CycleStartDt
                               orderby timeLog.Time
                               select timeLog).ToList();

                bStartTimeCheck = false;
                for(int j = 0; j < listTimeLog.Count;j++)
                {
                    if (listTimeLog[j].Value.ToString().Equals("0")) continue;
                    else
                    {
                        src.StepTime = listTimeLog[j].Time.Subtract(dtNextTimePoint).TotalMilliseconds;
                        src.CycleStepTime = listTimeLog[j].Time.Subtract(CycleStartDt).TotalMilliseconds;
                        src.StartTime = listTimeLog[j].Time;

                        if(listTimeLog.Count > j + 1)
                        {
                            src.RunningTime = listTimeLog[j + 1].Time.Subtract(listTimeLog[j].Time).TotalMilliseconds;
                            src.EndTime = listTimeLog[j + 1].Time;
                        }
                        else
                        {
                            src.RunningTime = CycleEndDt.Subtract(listTimeLog[j].Time).TotalMilliseconds;
                            src.EndTime = CycleEndDt;
                        }

                        if(src.EndTime > CycleEndDt)
                        {
                            src.SumRunningTime = src.CalcDeviceRunningTime(listTimeLog, src.StartTime, src.EndTime);
                        }
                        else
                        {
                            src.SumRunningTime = src.CalcDeviceRunningTime(listTimeLog, src.StartTime, CycleEndDt);
                        }

                        src.LogCount = listTimeLog.Where(x => x.Time >= CycleStartDt && x.Time <= CycleEndDt).Count();

                        if(!bStartTimeCheck)
                        {
                            dtNextTimePoint = listTimeLog[j].Time;
                            bStartTimeCheck = !bStartTimeCheck;
                        }
                    }
                    break; // 첫번째 신호에 대해서만 분석 후 루프 종료.
                }

                // 상위 loop에서 의미있는 4개의 시계열 값을 구하여 배열에 추가합니다.
                ListTimeDifferenceReport.Add(src);

                listTimeLog = null;
                src = null;
            }
        }

        #endregion
    }
}
