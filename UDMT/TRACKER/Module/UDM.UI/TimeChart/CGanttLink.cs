using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.TimeChart
{
	public class CGanttLink : IDisposable
	{
		#region Member Variables

		protected CGanttBar m_cBarFrom = null;
		protected CGanttBar m_cBarTo = null;
		protected Color m_cColor = Color.Black;
		protected EMGanttLinkPointType m_emPointTypeFrom = EMGanttLinkPointType.End;
		protected EMGanttLinkPointType m_emPointTypeTo = EMGanttLinkPointType.Start;
		protected EMGanttLinkCapType m_emCapTypeFrom = EMGanttLinkCapType.Square;
		protected EMGanttLinkCapType m_emCapTypeTo = EMGanttLinkCapType.Arrow;
		protected EMGanttLinkLineType m_emLineType = EMGanttLinkLineType.Dot;
		protected string m_sText = "";
		protected object m_oData = null;

		#endregion


		#region Initialize/Dispose

		public CGanttLink()
		{	
			
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public CGanttBar BarFrom
		{
			get { return m_cBarFrom; }
			set { m_cBarFrom = value; }
		}

		public CGanttBar BarTo
		{
			get { return m_cBarTo; }
			set { m_cBarTo = value; }
		}

		public Color Color
		{
			get { return m_cColor; }
			set { m_cColor = value; }
		}

		public EMGanttLinkPointType PointTypeFrom
		{
			get { return m_emPointTypeFrom; }
			set { m_emPointTypeFrom = value; }
		}

		public EMGanttLinkPointType PointTypeTo
		{
			get { return m_emPointTypeTo; }
			set { m_emPointTypeTo = value; }
		}

		public EMGanttLinkCapType CapTypeFrom
		{
			get { return m_emCapTypeFrom; }
			set { m_emCapTypeFrom = value; }
		}

		public EMGanttLinkCapType CapTypeTo
		{
			get { return m_emCapTypeTo; }
			set { m_emCapTypeTo = value; }
		}

		public EMGanttLinkLineType LineType
		{
			get { return m_emLineType; }
			set { m_emLineType = value; }
		}

		public string Text
		{
			get { return m_sText; }
			set { m_sText = value; }
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
