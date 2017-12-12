using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Flow
{
    [Serializable]
    public class CDeviceStepRunningInfo : IDeviceStepRunningInfo
    {
        #region Private Value

        protected string _key;
        protected int _colorRGB;
        protected int _orderNo;
        protected int _stepMs;   // 평균 지연시간
        protected int _runningMs;    // 평균 동작시간
        protected int _runningTimes; // 동작 횟수
        protected float _avgRunningMs;

        #endregion

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public int ColorRGB
        {
            get { return _colorRGB; }
            set { _colorRGB = value; }
        }

        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public int StepMs
        {
            get { return _stepMs; }
            set { _stepMs = value; }
        }

        public int RunningMs
        {
            get { return _runningMs; }
            set { 
                _runningMs = value;
                if (_runningTimes != 0)
                    _avgRunningMs = _runningMs / _runningTimes;
            }
        }

        public int RunningTimes
        {
            get { return _runningTimes; }
            set { 
                _runningTimes = value;
                if (_runningTimes != 0)
                    _avgRunningMs = _runningMs / _runningTimes;
            }
        }

        public float AvgRunningMs
        {
            get { return _avgRunningMs; }
            set { _avgRunningMs = value; }
        }
    }
}
