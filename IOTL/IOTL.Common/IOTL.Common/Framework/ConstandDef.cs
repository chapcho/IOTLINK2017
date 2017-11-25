using IOTL.Common.Clients;
using System;
using System.Collections.ObjectModel;

namespace IOTL.Common.Framework
{
    public static class ConstantDef
    {
        public const string DATETIME_FORMAT = "yyyy-MM-dd hh:mm:ss";
        public const string DATE_FORMAT = "yyyy-MM-dd";
        public const string DATETIMEMS_FORMAT = "yyyy-MM-dd hh:mm:ss.fff";

        public const string IOTL_ICEMACHINE_CLIENT = "IOTL Ice Machine Client";

        public static Collection<CIceMachine> lstIceMachine = new Collection<CIceMachine>();
    }

    public class NumericBingingWrapper
    {
        private string strName;
        private int numValue;
        public event EventHandler UnitChanged; // or via the "Events" list

        public NumericBingingWrapper(string sName)
        {
            strName = sName;
            numValue = 0;
        }
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        public int NumValue
        {
            get { return numValue; }
            set {

                numValue = value;
                if (value != numValue)
                {
                    numValue = value;
                    //EventHandler handler = UnitChanged;
                    //if (handler != null) handler(this, EventArgs.Empty);
                }
            }
        }
    }
}
