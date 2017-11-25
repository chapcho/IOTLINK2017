using System.ComponentModel;

namespace IOTL.Common
{
    public enum  EMFileLogType
    {
        [Description("프로그램로그")]
        ApplicationLog,
        [Description("통신관련로그")]
        CommunicationLog,
        [Description("데이터베이스관련로그")]
        DatabaseLog,
    }
}
