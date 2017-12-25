using System;
using System.Diagnostics;
using System.Reflection;

namespace IOTL.Common.Util
{
    public static class LogUtil
    {
        public static int[] ToValueArray(string sValue)
        {
            string[] saValue = sValue.Split('|');
            int iLength = saValue.Length;

            int[] iaValue = new int[iLength];

            for (int i = 0; i < iLength; i++)
            {
                iaValue[i] = IOTL.Common.CTypeConverter.ToInteger(saValue[i]);
            }

            return iaValue;
        }

        public static string ToStringValue(int[] iaValue)
        {
            if (iaValue == null || iaValue.Length == 0)
                return "";

            string sValue = iaValue[0].ToString();
            for (int i = 1; i < iaValue.Length; i++)
            {
                sValue += "|" + iaValue[i].ToString();
            }

            return sValue;
        }

        public static DateTime ToDateTime(decimal nTime)
        {
            DateTime dtTime = DateTime.MinValue;

            try
            {
                dtTime = DateTime.ParseExact(nTime.ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return dtTime;
        }

        public static string ToTimeString(DateTime dtTime)
        {
            return dtTime.ToString("yyyyMMddHHmmss.fff");
        }

        public  static string ToTimeSpanString(TimeSpan dtTime)
        {
            return dtTime.TotalSeconds.ToString("#.000");
        }

        public static string GetApplicationExceptionMethonName()
        {
            string debugMessage;

            MethodBase methodBase = new StackTrace(new StackFrame(1)).GetFrame(0).GetMethod();
            string className = methodBase.ReflectedType.ToString();
            string procName = methodBase.Module.ToString();

            debugMessage = string.Format("Debug Position : [{0}]:Func:{1}", className, procName);

            return debugMessage;
        }


        //public static EMGroupStateType ToGroupStateType(string sValue)
        //{
        //    if (sValue == "Start" || sValue == "START" || sValue == "start")
        //        return EMGroupStateType.Start;
        //    else if (sValue == "End" || sValue == "END" || sValue == "end")
        //        return EMGroupStateType.End;
        //    else if (sValue == "Error" || sValue == "ERROR" || sValue == "error")
        //        return EMGroupStateType.Error;
        //    else if (sValue == "ErrorEnd" || sValue == "ERROREND" || sValue == "errorend")
        //        return EMGroupStateType.ErrorEnd;
        //    else
        //        return EMGroupStateType.None;
        //}

        //public static EMMonitorType ToMonitorType(string sValue)
        //{
        //    if (sValue == "PatternItem" || sValue == "PATTERNITEM" || sValue == "patternitem")
        //        return EMMonitorType.PatternItem;
        //    else if (sValue == "MasterPattern" || sValue == "MASTERPATTERN" || sValue == "masterpattern")
        //        return EMMonitorType.MasterPattern;
        //    else
        //        return EMMonitorType.Detection;
        //}

        //public static EMCycleRunType ToCycleRunType(string sValue)
        //{
        //    if (sValue == "Start")
        //        return EMCycleRunType.Start;
        //    else if (sValue == "End")
        //        return EMCycleRunType.End;
        //    else if (sValue == "Error")
        //        return EMCycleRunType.Error;
        //    else if (sValue == "ErrorEnd")
        //        return EMCycleRunType.ErrorEnd;
        //    else if (sValue == "Complete")
        //        return EMCycleRunType.Complete;

        //    return EMCycleRunType.None;
        //}
    }
}
