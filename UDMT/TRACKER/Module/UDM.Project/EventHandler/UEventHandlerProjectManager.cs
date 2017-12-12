using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Project
{
    public delegate void UEventHandlerProjectCreated(object sender);
    public delegate void UEventHandlerProjectOpened(object sender);
    public delegate void UEventHandlerProjectSaved(object sender);
    public delegate void UEventHandlerProjectCleared(object sender);
}
