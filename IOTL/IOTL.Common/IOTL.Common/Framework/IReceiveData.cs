using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Framework
{
    [Guid("2BB70B7D-D19B-47CC-B17D-C551C92BD6AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IReceiveData
    {
        int Length { get; }
        object ReceiveData { get; set; }

    }
}
