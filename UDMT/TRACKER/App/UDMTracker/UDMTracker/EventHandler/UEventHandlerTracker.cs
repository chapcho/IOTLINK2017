using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Monitor.Plc;

namespace UDMTracker
{
    public delegate void UEventHandlerTrackerCycleStarted(string sGroupKey);
    public delegate void UEventHandlerTrackerErrorDetected(CGroupLog cLog, CMonitorErrorInfo cErrorInfo);
}
