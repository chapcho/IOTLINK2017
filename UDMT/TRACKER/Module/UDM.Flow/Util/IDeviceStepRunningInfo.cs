using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Flow
{
    interface IDeviceStepRunningInfo
    {
        string Key { get; set; }    // address
        int ColorRGB { get; set; }  // color
        int OrderNo { get; set; }   // order
        int StepMs { get; set; }    // step ms
        int RunningMs { get; set; } // running ms
        int RunningTimes { get; set; }  // running times
        float AvgRunningMs { get; set; }    // avg running ms
    }
}
