using System.Runtime.InteropServices;

namespace IOTL.CommonInterfaces
{
    /// <summary>
    /// 이름을 갖는 객체가 구현해야 할 interface
    /// </summary>
    [Guid("C117D099-E649-4DC5-B52F-10DF64E42973")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface INamed
    {
        /// <summary> 객체의 이름 </summary>
        string Name { get; set; }
    }
}
