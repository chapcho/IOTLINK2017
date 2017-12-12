using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Project
{
    public delegate void UEventHandlerModelTreeAdded(object sender, CSymbolS cSymbolS);
    public delegate void UEventHandlerModelTreeRemoved(object sender, CSymbolS cSymbolS);
    public delegate void UEventHandlerModelTreeUpdated(object sender, CSymbolS cSymbolS);
    public delegate void UEventHandlerModelTreeNodeDoubleClicked(object sender, CObject cNode); 
}
