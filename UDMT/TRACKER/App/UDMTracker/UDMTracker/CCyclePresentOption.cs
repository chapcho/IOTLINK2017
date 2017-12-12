using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMTracker
{
	public class CCyclePresentOption
	{

		#region Member Variables

		private bool m_bUseFilter = true;
		private bool m_bFirstActive = true;
		private int m_iActiveCount = 1;
		private int m_iLogCount = 1;

		#endregion


		#region Intialize/Dispose

		public CCyclePresentOption()
		{

		}

		#endregion


		#region Public Properties

		public bool UseFilter
		{
			get { return m_bUseFilter; }
			set { m_bUseFilter = value; }
		}

		public bool UseFirstActive
		{
			get { return m_bFirstActive; }
			set { m_bFirstActive = value; }
		}

		public int MinimnumActiveCount
		{
			get { return m_iActiveCount; }
			set { m_iActiveCount = value; }
		}

		public int MinimumLogCount
		{
			get { return m_iLogCount; }
			set { m_iLogCount = value; }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods


		#endregion
		
	}
}
