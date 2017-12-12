using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CGanttBar
	{

		#region Member Variables

		protected CGanttItem m_cItem = null;
		protected DateTime m_dtStart = DateTime.MinValue;
		protected DateTime m_dtEnd = DateTime.MinValue;
		protected Color m_cColor = Color.DodgerBlue;
		protected string m_sText = "";
		protected string m_sValue = "";
		protected int m_iHeight = 12;
		protected int m_iOffSet = 0;
		
		protected object m_oData = null;

		#endregion


		#region Initialize/Dispose


		#endregion


		#region Public Properties

		public CGanttItem Item
		{
			get { return m_cItem; }
			set { m_cItem = value; }
		}

		public DateTime StartTime
		{
			get { return m_dtStart; }
			set { m_dtStart = value; }
		}

		public DateTime EndTime
		{
			get { return m_dtEnd; }
			set { m_dtEnd = value; }
		}

		public Color Color
		{
			get { return m_cColor; }
			set { m_cColor = value; }
		}

		public string Text
		{
			get { return m_sText; }
			set { m_sText = value; }
		}

		public string Value
		{
			get { return m_sValue; }
			set { m_sValue = value; }
		}

		public int Height
		{
			get { return m_iHeight; }
			set { m_iHeight = value; }
		}

		public int OffSet
		{
			get { return m_iOffSet; }
			set { m_iOffSet = value; }
		}

		public object Data
		{
			get { return m_oData; }
			set { m_oData = value; }
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
