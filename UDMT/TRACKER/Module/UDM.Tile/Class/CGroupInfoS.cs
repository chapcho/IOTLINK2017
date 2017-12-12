using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Tile
{
	public class CGroupInfoS : Dictionary<string, CGroupInfo>, IDisposable
	{
		#region IDisposable Members

		public void Dispose()
		{
			Clear();
		}

		private CSymbol CopySymbol(CSymbol paramSymbol)
		{
			CSymbol cSymbol = paramSymbol;
			cSymbol.Address = paramSymbol.Address;
			cSymbol.Description = paramSymbol.Description;
			cSymbol.Name = paramSymbol.Name;
			cSymbol.Key = paramSymbol.Key;

			return cSymbol;
		}

		#endregion
	}
}
