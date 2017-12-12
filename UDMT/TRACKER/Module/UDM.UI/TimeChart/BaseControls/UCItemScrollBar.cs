using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCItemScrollBar : Panel
	{
		
		#region Member Varaibles

		protected UCItemTree m_ucItemTree = null;

		#endregion


		#region Initalize/Dispose

		public UCItemScrollBar()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCItemScrollBar(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public UCItemTree ItemTree
		{
			get { return m_ucItemTree; }
			set { SetItemTree(value);}
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{

		}

		protected void SetItemTree(UCItemTree ucItemTree)
		{
			if(m_ucItemTree != null)
			{
				m_ucItemTree.UEventItemScrollChanged -= m_ucItemTree_UEventItemScrollChanged;
			}

			m_ucItemTree = ucItemTree;
			if(m_ucItemTree != null)
			{
				m_ucItemTree.UEventItemScrollChanged += m_ucItemTree_UEventItemScrollChanged;
			}
		}

		#endregion

		#region Util


		#endregion

		#endregion


		#region Event Methods

		#region Override


		#endregion

		#region Others

		protected void m_ucItemTree_UEventItemScrollChanged(object sender)
		{
			scbItem.BeginUpdate();
			{	
				scbItem.Minimum = 0;
				scbItem.Maximum = m_ucItemTree.ScrollMaxValue;
				scbItem.Value = m_ucItemTree.ScrollValue;
				scbItem.LargeChange = m_ucItemTree.ScrollLargeChange;
			}
			scbItem.EndUpdate();
		}

		protected void scbItem_Scroll(object sender, ScrollEventArgs e)
		{
			if (m_ucItemTree == null)
				return;

			m_ucItemTree.ScrollValue = scbItem.Value;
		}

		#endregion

		#endregion
	}
}
