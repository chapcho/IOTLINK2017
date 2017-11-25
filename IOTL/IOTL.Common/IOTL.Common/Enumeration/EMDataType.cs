using System.ComponentModel;

namespace IOTL.Common
{
    public enum EMDataType
    {
        [Description("문자열로 구성된 데이터")]
        StringData = 0,
        [Description("하나의 문자 데이터")]
        ByteData = 1,
        [Description("16진수 값을 문자열로 기록한 데이터")]
        HexaData = 2,
        [Description("여러개의 문자로 구성된 데이터")]
        BytesData = 3,
        [Description("숫자로 구성된 데이터")]
        NumericData = 4,      

    }
}
