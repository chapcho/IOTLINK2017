using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    public delegate void UEventHandlerConnectSetting(object sender, string[] saData);
    public delegate void UEventHandlerConstantItemRecieved(object sender, string[] saData);
    public delegate void UEventHandlerInstantItemRecieved(object sender, string[] saRequestData, out string[] saReadData); 
    public delegate void UEventHandlerLogDataRecieved(object sender, string[] saData);
}
