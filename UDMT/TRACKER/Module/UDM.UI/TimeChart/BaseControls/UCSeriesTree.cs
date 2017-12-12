using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public partial class UCSeriesTree : UCItemTree
	{

		#region Member Variables

		
		#endregion


		#region Initialize/Dispose

		public UCSeriesTree()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCSeriesTree(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties
		

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
