using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.LS
{
	internal class CLsSymbolComparer : IComparer<CLsSymbol>
	{
		public int Compare(CLsSymbol cValue1, CLsSymbol cValue2)
		{
			return cValue1.Address.CompareTo(cValue2.Address);
		}
	}
}
