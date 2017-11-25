using System;
using System.Runtime.InteropServices;

namespace IOTL.Common.Framework
{
    [Guid("92AEA640-2FA8-4C73-B784-7EE72D202530")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IClient
    {
        string ClientName { get; set; }
    }
}
