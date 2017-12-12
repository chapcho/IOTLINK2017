using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Project
{
    public delegate string UEventHandlerGroupTreeInputTextRequest(object sender);

	public delegate void UEventHandlerGroupTreeSymbolAdding(object sender, string sGroup, CTagS cTagS, EMGroupRoleType emRoleType);
    public delegate void UEventHandlerGroupTreeSymbolAdded(object sender, string sGroup, CSymbolS cSymbolS);
    public delegate void UEventHandlerGroupTreeSymbolRemoved(object sender, string sGroup, CSymbolS cSymbolS);
    public delegate void UEventHandlerGroupTreeSymbolUpdated(object sender, string sGroup, CSymbolS cSymbolS);
    public delegate void UEventHandlerGroupTreeSymbolDoubleClicked(object sender, string sGroup, CSymbol cSymbol);

    public delegate void UEventHandlerGroupTreeGroupAdded(object sender, CGroup cGroup);
    public delegate void UEventHandlerGroupTreeGroupRemove(object sender, CGroup cGroup);
    public delegate void UEventHandlerGroupTreeGroupUpdate(object sender, CGroup cGroup);
    public delegate void UEventHandlerGroupTreeGroupDoubleClicked(object sender, CGroup cGroup);
}
