
using System;
using System.Runtime.InteropServices;
namespace IOTL.Common.Framework
{
    /// <summary>
    /// Configuation 인터페이스
    /// </summary>
    [Guid("AE56BD12-7B83-434C-9F12-E8D4131BEDD9")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IConfiguration : ICloneable
    {
        /// <summary>
        /// Save Configuration to file
        /// </summary>
        /// <param name="fileName"></param>
        void QSave(string fileName);
        /// <summary>
        /// Load Configuration from file
        /// </summary>
        /// <param name="fileName"></param>
        void QLoad(string fileName);
    }

    /// <summary>
    /// Configurable Interface : Configuration을 갖는 객체가 구현해야할 인터페이스
    /// </summary>
    [Guid("6AFA51C4-688B-406C-8F38-99A2180F8FC7")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IConfiguable
    {
        IConfiguration Configuration { get; }
    }
}
