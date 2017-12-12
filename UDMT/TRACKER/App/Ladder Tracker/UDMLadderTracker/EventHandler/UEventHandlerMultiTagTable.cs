using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMLadderTracker
{
    public delegate string UEventHandlerMultiTagTableInputTextRequest(object sender);

    public delegate void UEventHandlerMultiTagTableTagAdded(object sender, CTagS cTagS);
    public delegate void UEventHandlerMultiTagTableTagRemoved(object sender, CTagS cTagS);
    public delegate void UEventHandlerMultiTagTableTagUpdated(object sender, CTagS cTagS);
    public delegate void UEventHandlerMultiTagTableTagDoubleClicked(object sender, CTag cTag); 
}
