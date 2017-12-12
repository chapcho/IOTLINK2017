using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;

namespace UDM.UI.TimeChart
{
	public class CRowItemS : List<CRowItem>, IDisposable
	{

		#region Member Variables

		protected TreeListNodes m_exNodeS = null;

		#endregion


		#region Initialize/Dispose

		public CRowItemS()
		{

		}

		internal CRowItemS(TreeListNodes exNodeS)
		{
			m_exNodeS = exNodeS;
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties


		#endregion


		#region Public Methods

		public new void Add(CRowItem cItem)
		{
			if (m_exNodeS != null)
			{
				TreeListNode exNode = m_exNodeS.Add(cItem.Values);
				cItem.ExNode = exNode;
			}

			base.Add(cItem);
		}

		public new void Remove(CRowItem cItem)
		{
			if (m_exNodeS != null)
			{
				if (cItem.ExNode != null)
					m_exNodeS.Remove(cItem.ExNode);
			}

			base.Remove(cItem);
		}

		public new void Insert(int iIndex, CRowItem cItem)
		{
			if (m_exNodeS != null)
			{
				TreeListNode exNode = m_exNodeS.Add(cItem.Values);
				cItem.ExNode = exNode;
			}

			base.Insert(iIndex, cItem);
		}

		public new void RemoveAt(int iIndex)
		{
			if (iIndex >= this.Count)
				return;

			CRowItem cItem = this[iIndex];
			Remove(cItem);
		}

		public CRowItem Find(int iColumnIndex, string sValue)
		{
			CRowItem cItem = null;
			CRowItem cTemp = null;
			for (int i = 0; i < this.Count; i++)
			{
				cTemp = this[i];
				if (cTemp.Values != null && cTemp.Values.Length > iColumnIndex)
				{
					if(cTemp.Values[iColumnIndex].ToString() == sValue)
					{
						cItem = cTemp;
						break;
					}
				}
			}

			return cItem;
		}

		public CRowItem FindHasData(object oData)
		{
			CRowItem cItem = null;
			CRowItem cTemp = null;
			for(int i=0;i<this.Count;i++)
			{
				cTemp = this[i];
				if (cTemp.Data == oData)
				{
					cItem = cTemp;
					break;
				}
			}

			return cItem;
		}

		public CRowItem TraceHasData(object oData)
		{
			CRowItem cItem = null;
			CRowItem cTemp = null;
			for (int i = 0; i < this.Count; i++)
			{
				cTemp = this[i];
				if(cTemp.Data == oData)
				{
					cItem = cTemp;
					break;
				}
			}

			if (cItem != null)
				return cItem;

			for (int i = 0; i < this.Count; i++)
			{
				cTemp = this[i];
				cItem = TraceChildItemHasData(cTemp, oData);
				if (cItem != null)
					break;
			}

			return cItem;
		}
		
		public new void Clear()
		{
			m_exNodeS.Clear();
			base.Clear();
		}

		#endregion


		#region Private Methods

		protected CRowItem TraceChildItemHasData(CRowItem cParent, object oData)
		{
			CRowItem cItem = null;
			CRowItem cTemp = null;

			for (int i = 0; i < cParent.ItemS.Count; i++)
			{
				cTemp = cParent.ItemS[i];
				if (cTemp.Data == oData)
				{
					cItem = cTemp;
					break;
				}
			}

			if (cItem != null)
				return cItem;

			for (int i = 0; i < cParent.ItemS.Count; i++)
			{
				cTemp = cParent.ItemS[i];
				cItem = TraceChildItemHasData(cTemp, oData);
				if (cItem != null)
					break;
			}

			return cItem;
		}

		#endregion


		#region Event Methods


		#endregion
	}
}
