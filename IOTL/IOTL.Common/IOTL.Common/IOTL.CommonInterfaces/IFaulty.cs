
using System.Runtime.InteropServices;
namespace IOTL.CommonInterfaces
{
    /// <summary>
    /// 고장 날수 있는 객체가 구현해야할 인터페이스
    /// </summary>
    [Guid("941418E5-A034-4997-B626-D49AB6BA14FB")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IFaulty
    {
        /// <summary>
        /// 이 객체가 고장나 있는지
        /// </summary>
        bool IsOutOfOrder { get; set; }
    }
}
