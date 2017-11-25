using IOTL.Common;
using IOTL.Common.Framework;
using IOTL.Common.Log;

namespace IOTL.Common
{
    /// <summary>
    /// 일반적인 메시지를 전달하기 위한  delegate
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="message"></param>
    public delegate void UEventHandlerIOTLMessage(string sender, string message);
    /// <summary>
    /// 장비의 로그를 전달하기 위한 델리게이트
    /// </summary>
    /// <param name="emLogType"></param>
    /// <param name="cLogS"></param>
    public delegate void UEventHandlerMachineStateTimeLogS(EMMachineStateLogType emLogType, CTimeLogS cLogS);
    public delegate void UEventHandlerMachineStateTimeLog(EMMachineStateLogType emLogType, CTimeLog cLog);
    /// <summary>
    /// 장비의 로그를 전달하기 위한 델리게이트 추가(아직 용도는 없음)
    /// </summary>
    /// <param name="emLogType"></param>
    /// <param name="objReceiveData"></param>
    public delegate void UEventHandlerMachineLog(EMMachineStateLogType emLogType, IReceiveData objReceiveData);

    public delegate void UEventHandlerFileLog(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string logMessage);
    public delegate void LogFuncDelegate(string sMessage);
}
