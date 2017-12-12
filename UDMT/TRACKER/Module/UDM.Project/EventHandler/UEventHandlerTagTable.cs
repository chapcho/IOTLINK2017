using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Project
{
    public delegate string UEventHandlerTagTableInputTextRequest(object sender);

    public delegate void UEventHandlerTagTableTagAdded(object sender, CTagS cTagS);
    public delegate void UEventHandlerTagTableTagRemoved(object sender, CTagS cTagS);
    public delegate void UEventHandlerTagTableTagUpdated(object sender, CTagS cTagS);
    public delegate void UEventHandlerTagTableTagDoubleClicked(object sender, CTag cTag); 
}
