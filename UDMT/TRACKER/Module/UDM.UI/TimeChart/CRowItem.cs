using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace UDM.UI.TimeChart
{
	public class CRowItem : IDisposable
	{
		#region Member Variables

		protected bool m_bVisible = true;
		protected object[] m_oaValue = null;
		protected object m_oData = null;
		protected CRowItemS m_cItemS = null;

		protected TreeListNode m_exNode = null;	

		#endregion


		#region Initialize/Dispose

		public CRowItem(object[] oaValue)
		{
			m_oaValue = oaValue;
		}

		public void Dispose()
		{
			m_exNode = null;
			m_oaValue = null;
			m_oData = null;
		}

		#endregion


		#region Public Properties

		public bool IsVisible
		{
			get { return m_bVisible; }
			set { SetVisible(value); }
		}

		public object[] Values
		{
			get { return m_oaValue; }
			set { SetValues(value); }
		}

		public CheckState CheckedState
		{
			get { return GetCheckState(); }
			set { SetCheckState(value); }
		}
		public CRowItemS ItemS
		{
			get { return m_cItemS; }
		}

		public CRowItem Parent
		{
			get { return GetParent(); }
		}

		public int Level
		{
			get { return GetLevel(); }
		}

		public object Data
		{
			get { return m_oData; }
			set { m_oData = value; }
		}

		internal TreeListNode ExNode
		{
			get { return m_exNode; }
			set { SetNode(value); }
		}

		#endregion


		#region Public Methods

		public void Expand()
		{
			if (m_exNode != null)
				m_exNode.Expanded = true;
		}

		public void ExpandAll()
		{
			if (m_exNode != null)
				m_exNode.ExpandAll();
		}

		public void Collapse()
		{
			if (m_exNode != null)
				m_exNode.Expanded = false;
		}

		#endregion


		#region Private Methods

		protected void SetNode(TreeListNode exNode)
		{
			m_exNode = exNode;
			if (m_exNode != null)
			{
				m_exNode.Visible = m_bVisible;
				m_exNode.Tag = this;

				if (m_exNode != null)
					m_cItemS = new CRowItemS(m_exNode.Nodes);
			}
		}

		protected void SetValues(object[] oaValue)
		{
			m_oaValue = oaValue;
			if (m_exNode != null)
			{
				if (oaValue == null)
				{
					for (int i = 0; i < m_exNode.TreeList.Columns.Count; i++)
						m_exNode.SetValue(i, null);
				}
				else
				{
					for (int i = 0; i < m_exNode.TreeList.Columns.Count; i++)
					{
						if (oaValue.Length > i)
							m_exNode.SetValue(i, oaValue[i]);
						else
							m_exNode.SetValue(i, null);
					}
				}
			}
		}

		protected void SetVisible(bool bValue)
		{
			m_bVisible = bValue;
			if (m_exNode != null)
				m_exNode.Visible = bValue;
		}

		protected CheckState GetCheckState()
		{
			if (m_exNode != null)
				return m_exNode.CheckState;
			else
				return m_exNode.CheckState = CheckState.Unchecked;
		}

		protected void SetCheckState(CheckState emValue)
		{
			if (m_exNode != null)
				m_exNode.CheckState = emValue;
		}

		protected CRowItem GetParent()
		{
			if (m_exNode == null || m_exNode.ParentNode == null)
				return null;

			CRowItem cParent = (CRowItem)m_exNode.ParentNode.Tag;
			return cParent;
		}

		protected int GetLevel()
		{
			if (m_exNode == null)
				return -1;
			else
				return m_exNode.Level;
		}

		#endregion


		#region Event Methods


		#endregion
	}
}
