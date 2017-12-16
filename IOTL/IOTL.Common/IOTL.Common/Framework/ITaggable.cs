using System.Runtime.InteropServices;
namespace IOTL.Common.Framework
{
    /// <summary>
    /// Tag를 갖는 객체가 구현해야할 인터페이스
    /// </summary>
    [Guid("B0F20572-E2D6-4DDD-B1AE-0A52D3C5A4D9")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface ITaggable
    {
        /// <summary>
        /// 일반적인  C#의 Tag와 같은 기능을 수행함, name collision 방지를 위해 UserTag로 함.
        /// </summary>
        object UserTag { get; set; }
    }
}
