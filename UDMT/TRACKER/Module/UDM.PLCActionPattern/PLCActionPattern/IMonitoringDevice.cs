using System;

namespace UDM.PLCActionPattern
{
    public interface IPatternDevice<T>
    {
        event EventHandler<T> UEventDeviceValueChange;
        event EventHandler<T> UEventKeyDeviceValueChange;
        event EventHandler<T> UEventAbnormalDeviceValueChange;
        event EventHandler<T> UEventTrendDeviceValueChange;
    }
}
