using System;
using System.Collections.Generic;
using System.Linq;
using UDM.Log;

namespace UDM.Flow
{
    public class CPatternMatchRateS : List<CPatternMatchRate>
    {
        Dictionary<string, CDeviceStepRunningInfoS> _processPatternS = new Dictionary<string, CDeviceStepRunningInfoS>();

        #region Member Method
        /// <summary>
        /// 프로세스명,시작디바이스주소,사이클시작시간을 파라미터로 패턴 분석 결과를 조회합니다.
        /// 조건에 부합하는 데이터는 1건이어야 합니다.
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="startAddress"></param>
        /// <param name="startDt"></param>
        /// <returns></returns>
        private CPatternMatchRate FindTargetPatternMatchRate(string processName, string startAddress, DateTime startDt)
        {
            List<CPatternMatchRate> listPatternMatchRate = this.Where(x => x.ProcessName.Equals(processName))
                                                            .Where(x => x.CycleStartAddress.Equals(startAddress))
                                                            .Where(x => DateTime.Compare(x.CycleStartDt, startDt) == 0).ToList();

            return listPatternMatchRate != null ? listPatternMatchRate[0] : null;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 공정 패턴 매치율 조회
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="startAddress"></param>
        /// <param name="startDt"></param>
        /// <returns></returns>
        public float RetrivePatternMatchRate(string processName, string startAddress, DateTime startDt)
        {
            CPatternMatchRate targetPatternMatchRate = FindTargetPatternMatchRate(processName, startAddress, startDt);

            if(targetPatternMatchRate != null)
            {
                List<string> listPatternItem = new List<string>();

                targetPatternMatchRate.DeviceRunningTimeResolve(listPatternItem);
                // 패턴 일치율을 계산하려면, 공정의 패턴정보가 전달되어 있어야 한다.

                if(_processPatternS[processName] != null)
                {
                    // return _processPatternS[processName].CompareMatchRate( targetPatternMatchRate.ListTimeDifferenceReport );
                    return 0;
                }

            }

            return targetPatternMatchRate != null ? targetPatternMatchRate.PatternMatchRate : 0;
        }

        public void AddProcessTimeLog(string processName, CTimeLog log)
        {
            foreach(CPatternMatchRate target in this.Where(x => x.ProcessName.Equals(processName)).ToList())
            {
                target.AddTimeLog( log );

                // 현재의 로그가 사이클 종료 조건에 해당한다면, 패턴 일치율을 계산합니다.
                if(target.CycleStartDt != DateTime.MinValue)
                {
                    if ( log.Key.Contains( "]"+target.CycleEndAddress + "[" ) ) // if(target.CycleEndAddress.CompareTo(log.Key) == 0)
                    {
                        if(target.CycleEndValue.ToString().CompareTo(log.Value.ToString()) == 0)
                        {
                            // CycleEnd Process..
                        }
                    }
                }
            }
        }
        #endregion
    }
}
