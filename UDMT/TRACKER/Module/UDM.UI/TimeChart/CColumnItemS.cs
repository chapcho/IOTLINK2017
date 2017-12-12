using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Columns;

namespace UDM.UI.TimeChart
{
	public class CColumnItemS : List<CColumnItem>, IDisposable
	{

		#region Member Variables

		protected TreeListColumnCollection m_exColumnS = null;

		#endregion


		#region Initialize/Dispose

		public CColumnItemS()
		{

		}

		internal CColumnItemS(TreeListColumnCollection exColumnS)
		{
			m_exColumnS = exColumnS;
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		internal TreeListColumnCollection ExColumnS
		{
			get { return m_exColumnS; }
			set { m_exColumnS = value; }
		}

		#endregion


		#region Public Methods

		public new void Add(CColumnItem cColumn)
		{
			TreeListColumn exColumn = m_exColumnS.Add();
			cColumn.ExColumn = exColumn;

			base.Add(cColumn);
		}

		public new void Remove(CColumnItem cColumn)
		{
			if (cColumn.ExColumn != null)
				m_exColumnS.Remove(cColumn.ExColumn);

			base.Remove(cColumn);
		}

		public new void RemoveAt(int iIndex)
		{
			if (iIndex >= this.Count)
				return;

			CColumnItem cColumn = this[iIndex];
			Remove(cColumn);
		}

		public new void Clear()
		{
			m_exColumnS.Clear();
			base.Clear();
		}
		
		
		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
