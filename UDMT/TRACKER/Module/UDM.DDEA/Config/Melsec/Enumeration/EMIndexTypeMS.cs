using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    /// <summary>
    /// Melsec Index Type 
    /// 주소가 Index를 갖으면 IncludeAddress, 
    /// Index만 따로 떼어서 만든 접점은 CreateIndex
    /// 심볼리스트에 있고 Index로도 사용한 주소는 OverlapIndex
    /// </summary>
    public enum EMIndexTypeMS
    {
        None            = 0,
        IncludeAddress  = 1,
        CreateIndex     = 2,
        OverlapIndex    = 3
    }
}
