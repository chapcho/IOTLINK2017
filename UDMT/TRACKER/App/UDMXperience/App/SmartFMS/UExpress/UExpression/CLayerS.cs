using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExpression
{
	public class CLayerS : List<CLayer>
	{
		#region Member Variables
		private int m_iIndex = 0;
		#endregion

		#region Properties
		public int Index
		{
			get { return m_iIndex; }
			set { m_iIndex = value; }
		}
		#endregion

		#region Initilize/Dispose
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		#endregion
	}
}
