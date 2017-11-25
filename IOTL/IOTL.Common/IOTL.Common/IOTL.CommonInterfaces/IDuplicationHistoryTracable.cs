
using System.Runtime.InteropServices;
namespace IOTL.CommonInterfaces
{
    /// <summary>
    /// source 로 부터 복사 생성된 객체가 원본 source 에 대한 정보를 담고 있다.
    /// 복사 source 및 target 모두 IDuplicationHistoryTracable 이어야 함
    /// </summary>
    /// 
    [Guid("F624DE2E-61F9-4DA3-BC98-C772FE6C626B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IDuplicationHistoryTracable
    {
        IDuplicationHistoryTracable Originator { get; }
    }
}
