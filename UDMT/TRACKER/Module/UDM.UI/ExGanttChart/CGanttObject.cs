using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
	public class CGanttObject
	{
		protected string m_sKey = "";

		public string Key
		{
			get { return m_sKey; }
			set { m_sKey = value; }
		}
	}
}
