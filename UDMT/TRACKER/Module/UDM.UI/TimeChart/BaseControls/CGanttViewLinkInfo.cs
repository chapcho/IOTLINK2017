using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UDM.UI.TimeChart
{
	public class CGanttViewLinkInfo : IDisposable
	{

		#region Member Variables

		private GraphicsPath m_gPath = new GraphicsPath();

		#endregion


		#region Initialize/Dispose

		public CGanttViewLinkInfo()
		{
			
		}

		public void Dispose()
		{
			
		}

		#endregion


		#region Public Properties

		public GraphicsPath PathInfo
		{
			get { return m_gPath; }
			set { m_gPath = value; }
		}

		#endregion


		#region Public Methods
		
		
		#endregion
	}
}
