using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMOptimizer
{
    public delegate void UEventHandlerTrackerCycleStarted(string sGroupKey);
    public delegate void UEventHandlerTrackerAbnormalSymbolS(Dictionary<string, CSymbolS> dicErrSymbol);
    public delegate void UEventHandlerTrackerCycleInfo(CCycleInfo cCycleInfo);
    public delegate void UEventHandlerTrackerMessage(string sSender, string sMessage);
    public delegate void UEventHandlerTrackerTimeLogS(EMOptraLogType emLogType, CTimeLogS cLogS);
    public delegate void UEventHandlerTrackerLadderViewTimeLogS(EMOptraLogType emLogType, CTimeLogS cLogS);
    public delegate void UEventHandlerTrackerEmergTimeLogS(EMOptraLogType emLogType, string sKey, CTimeLogS cLogS);
    public delegate void UEventHandlerTrackerRecipeLogS(CTimeLogS cLogS);
    public delegate void UEventHandlerTrackerCycleChange(string sProcessKey, DateTime dtActTime);
    public delegate void UEventHandlerTrackerMaxCycleOver(string sProcessKey, CTimeLogS cLogS, bool bAuto);
    public delegate void UEventHandlerTrackerInterlockError(CAbnormalSymbol cAbnormalSymbol, CErrorInfo cErrorInfo);
    public delegate void UEventHandlerTrackerRobotCycleActive(string sTagKey, string sState);
    public delegate void UEventHandlerTrackerProductionEndActive(string sTagKey, DateTime dtActTime);
    public delegate void UEventHandlerTrackerSPDStatus(string[] saData);
    public delegate void UEventHandlerTrackerLadderViewSPDStatus(string[] saData);
    public delegate void UEventHandlerTrackerClientStatus(bool bConnect);
    public delegate void UEventHandlerTrackerMainRecipeValue(string sValue);

    public delegate void UEventHandlerGridUpdated();

    public delegate void UEventHandlerTrackerMonitoringStart(bool bConnect);
    public delegate void UEventHandlerTrackerMonitoringStop(bool bConnect);

    public delegate void UEventHandlerTrackerPatternResult(string sProcessName, int iCycleID, int iTotalCount, int iSatisfiedCount);
}
