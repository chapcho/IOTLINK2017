using System;
using System.Runtime.InteropServices;

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
