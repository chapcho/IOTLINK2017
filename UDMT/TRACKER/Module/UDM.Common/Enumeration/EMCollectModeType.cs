using System;

namespace UDM.Common
{
    public enum EMCollectModeType
    {
        //Normal = 0,        // 부분수집
        //Fragment = 1,      // 전체수집
        //LOB = 2,           // LOB 수집
        //StandardTag = 3,   // 출력수집

        Normal = 0,  // 부분수집
        Output = 1,  // 출력수집
    }
}
