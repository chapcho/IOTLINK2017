using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public class CGanttItem : CRowItem
	{

		#region Member Variables
		
		protected CGanttBarS m_cBarS = null;

		#endregion


		#region Initialize/Dispose

		public CGanttItem(object[] oaValue)
			: base(oaValue)
		{
			m_cBarS = new CGanttBarS(this);
		}

		public new void Dispose()
		{
			m_cBarS.Clear();
			base.Dispose();
		}

		#endregion


		#region Public Properties

		public CGanttBarS BarS
		{
			get { return m_cBarS; }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
