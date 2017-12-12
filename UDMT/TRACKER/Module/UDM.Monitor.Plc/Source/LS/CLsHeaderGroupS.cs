using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Monitor.Plc.Source.LS
{
	internal class CLsHeaderGroupS : Dictionary<string, CLsHeaderGroup>, IDisposable
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public CLsHeaderGroupS()
		{ 

		}

		public CLsHeaderGroupS(List<CTag> lstTag)
		{
			Create(lstTag);
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties


		#endregion


		#region Public Methods

		public void Create(List<CTag> lstTag)
		{
			this.Clear();

			CTag cTag;
			CLsSymbol cSymbol;
			CLsHeaderGroup cGroup;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];

				cSymbol = new CLsSymbol(cTag.Key, cTag.Address);
				if (this.ContainsKey(cSymbol.AddressHeader))
				{
					cGroup = this[cSymbol.AddressHeader];
					cGroup.Add(cSymbol);
				}
				else
				{
					cGroup = new CLsHeaderGroup(cSymbol.AddressHeader);
					cGroup.Add(cSymbol);

					this.Add(cSymbol.AddressHeader, cGroup);
				}
			}

			for(int i=0;i<this.Count;i++)
			{
				cGroup = this.ElementAt(i).Value;
				cGroup.Sort();
			}
		}

		#endregion


		#region Private Methods

		

		#endregion

	}
}
