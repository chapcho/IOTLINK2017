using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Log;
using System.Data;

namespace FTOPApp
{
    public delegate void UEventHandlerOPCItemValueChanged(object sender, string sGroupName, int iCount, Array arHandles, Array arValues, Array arTimeStamp);
    public delegate void UEventHandlerOPCServerInitialized(object sender, COPCServer cOPCServer);
    public delegate void UEventHandlerValueChanged(DateTime makeTime, string key, object value);
    public delegate void UEventHandlerThreadDequeEvent(object sender, FTag tag);

    public delegate void UEventHandlerMESSendedEvent(object sender, ProcedureTag tag);
    public delegate void UEventHandlerThreadDequeServerEvent(object sender, ProcedureTag row);

    public delegate void UEventHandlerDBReadedDelegator(object sender, object data);

    public delegate void UEventHandlerConnectEvent(EMConnectType type, EMConnectStatus status);

    public delegate void UEventHandlerRestCount(object sender, int count);
    public delegate void UEventHandlerMessage(object sender, string message);
    public delegate void UEventHandlerLogMessage(object sender, LogEventArgs e);
    public class LogEventArgs : EventArgs
    {
        public FTOPLog fTopLog { get; set; }
    }

    public delegate void UEventHandlerRibbonMenu(object sender, string message);
    public delegate void UEventHandlerObserverStatus(object sender, string message);
}
