using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace UDM.PLCActionPattern
{
    [Serializable]
    /// <summary>
    /// PLC 신호 발생 디바이스 정보
    /// </summary>

    public class CPLCActionDevice : IObject, IPatternDevice<CPLCActionDevice>
    {
        #region Member Variables

        private string _key;
        private string _deviceAddress;
        private string _deviceComment;
        private string _deviceNote;
        private CUniqueStringList _lstDeviceRefProgram = new CUniqueStringList();
        private EMGroupRoleType _deviceRoleType = EMGroupRoleType.General;

        /// <summary>
        /// 디바이스의 최종값과 이전값
        /// </summary>
        private string _deviceCurValue;
        private string _devicePrevValue;
        private DateTime _lastValueChangeDt;
        private DateTime _prevValueChangeDt;

        private EMDataType _emDataType;
        private EMAddressType _emAddressType;
        private int _size;

        #endregion

        #region Initialize/Dispose
        public CPLCActionDevice()
        {
            _key = string.Empty;
            _deviceAddress = string.Empty;
            _deviceComment = string.Empty;
            _deviceNote = string.Empty;
            _deviceCurValue = string.Empty;
            _devicePrevValue = string.Empty;

            _lastValueChangeDt = DateTime.MinValue;
            _prevValueChangeDt = DateTime.MinValue;
            _size = 1;

            _emDataType = EMDataType.Bool;
            _emAddressType = EMAddressType.Decimal;

        }

        public CPLCActionDevice(string sKey, string sAddress, string sComment, EMGroupRoleType roleType, EMDataType dataType, EMAddressType emAddressType)
        {
            _key = sKey;
            _deviceAddress = sAddress;
            _deviceComment = sComment;
            _deviceNote = string.Empty;
            _deviceCurValue = string.Empty;
            _devicePrevValue = string.Empty;
            
            _lastValueChangeDt = DateTime.MinValue;
            _prevValueChangeDt = DateTime.MinValue;
            _size = 1;

            _deviceRoleType = roleType;
            _emDataType = dataType;
            _emAddressType = emAddressType;
        }

        ~CPLCActionDevice()
        {
            //
        }

        #endregion

        #region Events
        public event EventHandler<CPLCActionDevice> UEventDeviceValueChange = delegate { };
        public event EventHandler<CPLCActionDevice> UEventKeyDeviceValueChange = delegate { };
        public event EventHandler<CPLCActionDevice> UEventAbnormalDeviceValueChange = delegate { };
        public event EventHandler<CPLCActionDevice> UEventTrendDeviceValueChange = delegate { };
        #endregion

        #region Public Properties
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string DeviceAddress
        {
            get { return _deviceAddress; }
            set { _deviceAddress = value; }
        }
        public string DeviceComment
        {
            get { return _deviceComment; }
            set { _deviceComment = value; }
        }
        public string DeviceNote
        {
            get { return _deviceNote; }
            set { _deviceNote = value; }
        }
        public EMGroupRoleType DeviceRoleType
        {
            get { return _deviceRoleType; }
            set { _deviceRoleType = value; }
        }

        public CUniqueStringList DeviceRefProgramList
        {
            get { return _lstDeviceRefProgram; }
            private set { _lstDeviceRefProgram = value; }
        }

        /// <summary>
        /// 디바이스의 값이 변경된 경우는 이벤트 발생
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="logDt"></param>
        public void UpdateDeviceValue(string dt, DateTime logDt)
        {
            if (_deviceCurValue.Equals(dt) && _lastValueChangeDt != DateTime.MinValue)
            {
                Console.WriteLine("No Changed!!!");
                return; // 값의 변화가 없을때는 이벤트를 발생하지 않습니다.
            }
            else
            {
                _devicePrevValue = _deviceCurValue;
                _prevValueChangeDt = _lastValueChangeDt;

                _deviceCurValue = dt;
                LastDeviceValueChangeDt = logDt;

                switch (_deviceRoleType)
                {
                    case EMGroupRoleType.Key:
                        if (UEventKeyDeviceValueChange != null) UEventKeyDeviceValueChange(this, this);
                        break;
                    case EMGroupRoleType.Abnormal:
                        if (UEventAbnormalDeviceValueChange != null) UEventAbnormalDeviceValueChange(this, this);
                        break;
                    case EMGroupRoleType.Trend:
                        if (UEventTrendDeviceValueChange != null) UEventTrendDeviceValueChange(this, this);
                        break;
                    default:
                        if (UEventDeviceValueChange != null) UEventDeviceValueChange(this, this);
                        break;
                }
            }
        }

        public string DeviceCurValue
        {
            get 
            {
                return _deviceCurValue;
            }
            private set 
            {   
                //
                // 디바이스 값의 변화시에 시간값이 없어 이벤트 호출이 되지 않습니다.
                // 이벤트 호출 : UpdateDeviceValue() 
                //
                if(_deviceCurValue.Equals(value))
                {
                    return;
                }
                _devicePrevValue = _deviceCurValue;
                _prevValueChangeDt = _lastValueChangeDt;
                _deviceCurValue = value;
            }
        }

        public string DevicePrevValue
        {
            get { return _devicePrevValue; }
        }
        public DateTime LastDeviceValueChangeDt
        {
            get { return _lastValueChangeDt; }
            set { _lastValueChangeDt = value; }
        }
        public DateTime PrevDeviceValueChangeDt
        {
            get { return _prevValueChangeDt; }
        }

        #endregion

    }

}