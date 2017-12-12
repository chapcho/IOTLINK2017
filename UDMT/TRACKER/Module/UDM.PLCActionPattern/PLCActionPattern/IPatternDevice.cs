using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.PLCActionPattern
{
    public interface IPatternDevice
    {
        void InitIt();
        void UpdateDeviceValue(string dt, DateTime dtCur, int ordActivate);
    }
}
