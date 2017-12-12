using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    /// <summary>
    /// Z인덱스는 Log로 남길때 D100Z0+Z0의 현재 값으로 표현되므로 구분이 필요함.
    /// </summary>
    public enum EMTagIndexType
    {
        None,
        Read,                    //읽어서 Log에 찍음.
        //CreateIndex,             //리스트에 없는 Z인덱스 생성, Symbol Table 표시안됨
        IndexSource,             //리스트에 있는 Z인덱스
        IndexTarget              //D100Z0
    }
}
