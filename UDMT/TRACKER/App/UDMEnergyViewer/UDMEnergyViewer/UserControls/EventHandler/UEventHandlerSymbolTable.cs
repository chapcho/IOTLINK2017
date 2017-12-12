using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDMEnergyViewer
{
	public delegate string UEventHandlerSymbolTableInputTextRequest(object sender);
	public delegate void UEventHandlerSymbolTableSymbolAdded(object sender, List<CSymbol> lstSymbol);
	public delegate void UEventHandlerSymbolTableSymbolRemoved(object sender, List<CSymbol> lstSymbol);
	public delegate void UEventHandlerSymbolTableSymbolUpdated(object sender, List<CSymbol> lstSymbol);
	public delegate void UEventHandlerSymbolTableSymbolDoubleClicked(object sender, CSymbol cSymbol); 
}
