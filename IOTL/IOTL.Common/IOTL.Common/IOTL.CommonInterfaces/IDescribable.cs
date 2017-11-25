using System.Runtime.InteropServices;

namespace IOTL.CommonInterfaces
{
    /// <summary>
    /// Description을 구현할 객체가 가져야 할 인터페이스
    /// </summary>
    /// 
    [Guid("AA0CA815-65C6-4292-80C5-594498CC8F08")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IDescribable
    {
        /// <summary>
        /// 주로 사용자 메모 : Note
        /// </summary>
        string Note { get; set; }
    }
}
