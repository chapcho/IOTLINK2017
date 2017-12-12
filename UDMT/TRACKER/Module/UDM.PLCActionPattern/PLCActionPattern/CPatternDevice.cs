using System;

namespace UDM.PLCActionPattern
{
    /// <summary>
    /// PLC 출력 신호로 구성되는 동작 패턴 정보
    /// 이 디바이스는 scanRate에 의해 패턴의 값의 역전될 수 있다.
    /// </summary>
    public class CPatternDevice : IPatternDevice, ICloneable
    {
        #region Member Variables

        private string _deviceAddress;
        private DateTime _firstDeviceActivateDt;    // 최초 수정 시간 0->1로
        private DateTime _latestDeviceActivateDt;   // 
        private int _ordActivate;   // 디바이스가 패턴에서 동작한 순서.
        private int _cntActivate;   // 디바이스가 동작한 횟수 1->0
        private DateTime _dtCycleStart;             // 사이클 시작 시간 (표시용)
        private DateTime _dtCycleEnd;               // 사이클 종료 시간 (표시용)
        private string _deviceCurValue;

        #endregion
        // 신호 발생 순서만 가지고는 정보량이 많아 질수 있으므로, 신호 수집시간도 함께 검토한다. 검토 우선 순위는 발생순서이다.
        #region Initialize
        public CPatternDevice()
        {
            InitIt();
        }
        #endregion

        #region Public Properties
        public string DeviceAddress
        {
            get { return _deviceAddress; }
            set { _deviceAddress = value; }
        }
        public DateTime CycleStartTime
        {
            get { return _dtCycleStart; }
            set { _dtCycleStart = value; }
        }
        public DateTime CycleEndTime
        {
            get { return _dtCycleEnd; }
            set { _dtCycleEnd = value; }
        }
        public DateTime FirstActivateTime
        {
            get { return _firstDeviceActivateDt; }
            set { _firstDeviceActivateDt = value; }
        }
        public DateTime LatestActivateTime
        {
            get { return _latestDeviceActivateDt; }
            set { _latestDeviceActivateDt = value; }
        }
        public int DeviceActivateOrder
        {
            get { return _ordActivate; }
            set { _ordActivate = value; }
        }
        public int DeviceActivateCnt
        {
            get { return _cntActivate; }
        }
        public string CurValue
        {
            get { return _deviceCurValue; }
        }
        #endregion

        #region Public Method

        #endregion

        #region Interface Method
        public void InitIt()
        {
            _dtCycleStart = (_dtCycleEnd = (_firstDeviceActivateDt = (_latestDeviceActivateDt = DateTime.MinValue)));
            _ordActivate = (_cntActivate = 0);
            _deviceCurValue = string.Empty;
        }

        public void UpdateDeviceValue(string dt, DateTime dtCur, int ordActivate)
        {
            _firstDeviceActivateDt = _firstDeviceActivateDt == DateTime.MinValue ? dtCur : _firstDeviceActivateDt;
            if (!_deviceCurValue.Equals(dt))
            {
                _latestDeviceActivateDt = dtCur;
                _deviceCurValue = dt;
                if (_deviceCurValue.Equals("1"))
                {
                    _cntActivate++;
                    _ordActivate = _ordActivate == 0 ? ordActivate : _ordActivate;
                }
            }
        }

        public object Clone()
        {
            CPatternDevice obj = new CPatternDevice();

            obj.DeviceAddress = DeviceAddress;
            obj.CycleStartTime = CycleStartTime;
            obj.CycleEndTime = CycleEndTime;
            obj.FirstActivateTime = FirstActivateTime;
            obj.DeviceActivateOrder = DeviceActivateOrder;
            obj._deviceCurValue = CurValue;
            obj._cntActivate = _cntActivate;
            obj.LatestActivateTime = LatestActivateTime;

            return obj;
        }
        #endregion


    }
}
