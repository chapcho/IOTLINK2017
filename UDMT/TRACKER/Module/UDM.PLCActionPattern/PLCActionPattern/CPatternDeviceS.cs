using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.PLCActionPattern
{
    public delegate void UEventHandlerCyclePattern(string sSender, CPatternDeviceS obj);

    public class CPatternDeviceS : List<CPatternDevice>, IDisposable, IEquipActionPatternCycleReGen, ICloneable
    {
        public const int DEVICE_ADDRESS_LENGTH_MAX = 6;

        #region Variables
        private string _cycleStartAddress;
        private string _cycleEndAddress;

        private DateTime _cycleStartDt;
        private DateTime _cycleEndDt;
        private DateTime _latestDeviceValueChangeDt;
        private int _maxCycleDurationMs;
        private int _ordNo;
        private string _cycleCollectState;
        private bool _cycleOverEventCalled = false;
        /// <summary>
        /// 리포트를 위한 항목 추가..
        /// </summary>
        private float _patternMatchRate;
        private float _tackTimeMatchRate;
        private DateTime _reportDt;

        public event UEventHandlerCyclePattern UEventCyclePatternProcessor;

        #endregion

        /// <summary>
        /// 설비의 동작 패턴을 나타내는 디바이스의 목록이다.
        /// 설비명, 레시피, 사이클시작을 키로 가진다.
        /// </summary>

        #region Initialize
        public CPatternDeviceS()
        {
            _cycleStartAddress = string.Empty;
            _cycleEndAddress = string.Empty;
            _maxCycleDurationMs = 1000*60;  // 60초
            InitIt();
        }
        
        ~CPatternDeviceS()
        {
        }

        #endregion

        #region Interface method
        public void Dispose()
        {
            this.Clear();
        }

        public void ReGenCycleInfo(DateTime cycleStart, DateTime cycleEnd)
        {
            foreach (CPatternDevice device in this)
            {
                device.CycleStartTime = cycleStart;
                device.CycleEndTime = cycleEnd;
            }
            _cycleEndDt = cycleEnd;
        }
        #endregion

        #region Public Properties

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
            set 
            {
                _cycleStartDt = value;
                foreach (CPatternDevice ss in this)
                    ss.CycleStartTime = value;
            }
        }
        public DateTime CycleEndDt
        {
            get { return _cycleEndDt; }
            set { 
                _cycleEndDt = value;
                foreach (CPatternDevice ss in this)
                    ss.CycleEndTime = value;
            }
        }
        public List<CPatternDevice>PatternDeviceList()
        {
            return this.OrderBy(x => x.DeviceActivateOrder).ToList();
        }
        public int MaxCycleDurationMs
        {
            get { return _maxCycleDurationMs; }
            set { _maxCycleDurationMs = value; }
        }

        public float PatternMatchRate
        {
            get { return _patternMatchRate; }
            set { _patternMatchRate = value; }
        }

        public float TackTimeMatchRate
        {
            get { return _tackTimeMatchRate; }
            set { _tackTimeMatchRate = value; }
        }

        public DateTime ReportDt
        {
            get { return _reportDt; }
            set { _reportDt = value; }
        }

        public string GetCycleCollectState
        {
            get { return _cycleCollectState; }
        }

        #endregion

        #region Public Method

        public bool IsCycleDurationOver()
        {
            if(_cycleStartDt == DateTime.MinValue) return false; // 사이클이 시작되지 않았다.

            // 사이클 종료가 들어오지 않았다면..현재 시간과 비교해야 하지 않을까?
            if(_cycleEndDt != DateTime.MinValue)
            {
                if ((int)_cycleEndDt.Subtract(_cycleStartDt).TotalMilliseconds > _maxCycleDurationMs)
                {
                    _cycleCollectState = "CMDO"; // Cycle Max Duration Over

                    // 사이클 Over에 대한 Report가 전달되지 않았다면..
                    if (!_cycleOverEventCalled)
                    {
                        if (UEventCyclePatternProcessor != null)
                            UEventCyclePatternProcessor("Pattern Monitor!!", (CPatternDeviceS)this.Clone());

                        _cycleOverEventCalled = true;
                    }

                    return true;
                }
            }
            else
            {
                if((int)DateTime.Now.Subtract(_cycleStartDt).TotalMilliseconds > _maxCycleDurationMs)
                {
                    _cycleCollectState = "CMDO"; // Cycle Max Duration Over

                    // 사이클 Over에 대한 Report가 전달되지 않았다면..
                    if (!_cycleOverEventCalled)
                    {
                        if (UEventCyclePatternProcessor != null)
                            UEventCyclePatternProcessor("Pattern Monitor!!", (CPatternDeviceS)this.Clone());

                        _cycleOverEventCalled = true;
                    }

                    return true;
                }
            }

            return false;
        }

        public double CycleDuration
        {
            get
            {
                if (_cycleEndDt != DateTime.MinValue && _cycleStartDt != DateTime.MinValue)
                {
                    return _cycleEndDt.Subtract(_cycleStartDt).TotalMilliseconds;
                }
                return -1;
            }
        }
        public string GetPatternDeviceStr()
        {
            StringBuilder sb = new StringBuilder();
            // 패턴을 비교할때는 동작순서와 주소로 정렬..
            List<CPatternDevice> lstPatternDevice = this.OrderBy(x => x.DeviceActivateOrder).ThenBy(xy => xy.DeviceAddress).ToList();
            foreach (CPatternDevice pd in lstPatternDevice)
            {
                sb.Append(String.Format("{0}{1}{2}", pd.DeviceActivateCnt.ToString().PadLeft(2,' '),pd.DeviceActivateOrder.ToString().PadLeft(3,' '), pd.DeviceAddress.PadLeft(DEVICE_ADDRESS_LENGTH_MAX, ' ')));
            }
            // 사이클 동작시간에 대한 정보도 포함한다.
            if(_cycleEndDt != DateTime.MinValue && _cycleStartDt != DateTime.MinValue)
            {
                sb.Append(string.Format(" RunningMs:{0:p0}", (Int32)_cycleEndDt.Subtract(_cycleStartDt).TotalMilliseconds));
            }
            return sb.ToString();
        }

        public void UpdatePatternDeviceValue(string sAddress, string sDt, DateTime dtTime)
        {
            bool bUpdaeted = false;

            if(string.IsNullOrEmpty(CycleStartAddress) || string.IsNullOrEmpty(CycleEndAddress))
            {
                throw new Exception("설비 동작신호를 구분할 시작주소와 종료주소가 설정되지 않았습니다.");
            }

            if (this.Where(x => x.DeviceAddress.Equals(sAddress)).ToList().Count() > 0)
            {
                CPatternDevice src = this.Where(x => x.DeviceAddress.Equals(sAddress)).ToList()[0];

                src.UpdateDeviceValue(sDt, dtTime, _ordNo);
                if (src.CurValue.Equals("1")) bUpdaeted = true;
            }
            else
            {
                /// 패턴 디바이스 목록에 포함되지 않은 디바이스 신호가 수신되면
                /// 목록에 추가한다.
                CPatternDevice src = new CPatternDevice();
                src.DeviceAddress = sAddress;
                src.InitIt();
                src.UpdateDeviceValue(sDt, dtTime, _ordNo);

                if (src.CurValue.Equals("1")) bUpdaeted = true;
                this.Add(src);
            }

            // 패턴의 최종 변경시간과 다르다면 Ord를 증가시킨다.
            if (bUpdaeted && _latestDeviceValueChangeDt < dtTime)
            {
                _ordNo++;
                _latestDeviceValueChangeDt = dtTime;
            }

            if(bUpdaeted)
            {
                if(sAddress.Equals(CycleEndAddress))    // 사이클 종료.
                {
                    CycleEndDt = dtTime;
                    ReGenCycleInfo(CycleStartDt, CycleEndDt);

                    // 처리자로 메시지로 던진다.
                    if (UEventCyclePatternProcessor != null)
                        UEventCyclePatternProcessor("Pattern Monitor!!", (CPatternDeviceS)this.Clone());

                    // 패턴 기록지를 초기화 한다.
                    this.InitIt();
                }
                else if (sAddress.Equals(CycleStartAddress))
                {
                    CycleStartDt = dtTime;
                }
            }
        }

        public CPatternDevice GetPatternDevice(string sAddress)
        {
            if (this.Where(x => x.DeviceAddress.Contains(sAddress)).ToList().Count > 0)
            {
                CPatternDevice rst = this.Where(x => x.DeviceAddress.Contains(sAddress)).ToList()[0];
                return rst;
            }
            else
            {
                return null;
            }
        }

        #endregion


        public void InitIt()
        {
            foreach (CPatternDevice src in this)
                src.InitIt();

            _latestDeviceValueChangeDt = (_cycleEndDt = (_cycleStartDt = DateTime.MinValue));
            _ordNo = 0;
            _cycleCollectState = "NORMAL";
            _cycleOverEventCalled = false;
        }

        public object Clone()
        {
            CPatternDeviceS obj = new CPatternDeviceS();
            foreach(CPatternDevice src in this)
            {
                obj.Add((CPatternDevice)src.Clone());
            }

            obj._ordNo = _ordNo;
            obj._cycleStartDt = _cycleStartDt;
            obj._cycleEndDt = _cycleEndDt;
            obj._cycleStartAddress = _cycleStartAddress;
            obj._cycleEndAddress = _cycleEndAddress;
            obj._maxCycleDurationMs = _maxCycleDurationMs;
            obj._patternMatchRate = _patternMatchRate;
            obj._reportDt = _reportDt;
            obj._cycleCollectState = _cycleCollectState;
            obj._tackTimeMatchRate = _tackTimeMatchRate;

            return obj;
        }

        public void AddKeyDevice(string p)
        {
            string[] lstAddress = p.Split(',');

            for(int i = 0; i < lstAddress.Length; i++)
            {
                if (string.IsNullOrEmpty(lstAddress[i].Trim())) continue;

                if (this.Find(x => x.DeviceAddress.Equals(lstAddress[i])) == null)
                {
                    CPatternDevice src = new CPatternDevice();
                    src.DeviceAddress = lstAddress[i];
                    src.InitIt();
                    this.Add(src);
                }
                else
                {
                    Console.WriteLine("추가하는 패턴 수집 목록에 해당 디바이스가 이미 포함되어 있습니다.{0}" ,lstAddress[i]);
                }
            }
        }
    }
}
