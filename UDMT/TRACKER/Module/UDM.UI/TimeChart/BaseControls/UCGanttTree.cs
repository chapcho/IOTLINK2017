using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.TimeChart
{
	public partial class UCGanttTree : UCItemTree
	{

		#region Member Variables

		protected CGanttLinkS m_cLinkS = null;
		protected int m_iDefaultBarHeight = 15;

		#endregion


		#region Initialize/Dispose

		public UCGanttTree()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCGanttTree(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public CGanttLinkS LinkS
		{
			get { return m_cLinkS; }
		}

		public int DefaultBarHeight
		{
			get { return m_iDefaultBarHeight; }
			set { m_iDefaultBarHeight = value; }
		}

		#endregion

		#region Public Methods

		#region Layout


		#endregion

		#region Item

		#endregion

		#endregion


		#region Private Methods

		#region Layout

		protected new void InitVariables()
		{
			base.InitVariables();
			m_cLinkS = new CGanttLinkS();
		}

		#endregion

		#region Item

		
		#endregion

		#region User Action

		#endregion

		#region Util


		#endregion

		#region Raising Event
		
		#endregion

		#region Drawing


		#endregion

		#endregion


		#region Event Methods


		#endregion
	}
}
