using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.LS
{
	internal class CLsHeaderGroup : List<CLsSymbol>, IDisposable
	{

		#region Member Variables

		protected string m_sHeader = "";
		
		#endregion


		#region Initialize/Dispose

		public CLsHeaderGroup()
		{

		}

		public CLsHeaderGroup(string sAddressHeader)
		{
			m_sHeader = sAddressHeader;
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public string Header
		{
			get { return m_sHeader; }
			set { m_sHeader = value; }
		}

		#endregion


		#region Public Methods

		public new void Sort()
		{
			base.Sort(new CLsSymbolComparer());
		}

		#endregion


		#region Private Methods


		#endregion
	}
}
