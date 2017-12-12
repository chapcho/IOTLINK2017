using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;

namespace UDM.UI.TimeChart
{
	public class CColumnItem : IDisposable
	{
		#region Member Variables

		protected string m_sName = "";
		protected string m_sCaption = "";
		protected int m_iIndex = -1;
		protected int m_iWidth = 20;
		protected bool m_bReadOnly = false;
		protected bool m_bVisible = true;
		protected object m_oData = null;
	    protected bool m_bAllowSort = false;

		protected TreeListColumn m_exColumn = null;
		protected RepositoryItem m_exEditor = null;

		#endregion


		#region Initialize/Dispose

		public CColumnItem()
		{
			
		}

		public CColumnItem(string sName)
		{
			m_sName = sName;
		}

		public CColumnItem(string sName, string sCaption)
		{
			m_sName = sName;
			m_sCaption = sCaption;
		}

		public void Dispose()
		{
			if (m_exColumn != null)
			{
				m_exColumn.Dispose();
				m_exColumn = null;
			}

			m_oData = null;
		}

		#endregion


		#region Public Properties

		public string Name
		{
			get { return m_sName; }
			set { SetName(value); }
		}

	    public bool AllowSort
	    {
            get { return m_bAllowSort;}
            set { SetSort(value); }
	    }

		public string Caption
		{
			get { return m_sCaption; }
			set { SetCaption(value); }
		}

		public int Index
		{
			get { return m_iIndex; }
		}

		public int Width
		{
			get { return m_iWidth; }
			set { SetWidth(value); }
		}

		public bool IsReadOnly
		{
			get { return m_bReadOnly; }
			set { SetReadOnly(value); }
		}

		public bool IsVisible
		{
			get { return m_bVisible; }
			set { SetVisible(value); }
		}

		public RepositoryItem Editor
		{
			get { return m_exEditor; }
			set { SetEditor(value); }
		}

		public object Data
		{
			get { return m_oData; }
			set { m_oData = value; }
		}

		internal TreeListColumn ExColumn
		{
			get { return m_exColumn; }
			set { SetExColumn(value); }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		private void SetExColumn(TreeListColumn exValue)
		{
			m_exColumn = exValue;
			if(m_exColumn != null)
			{
				m_exColumn.Name = m_sName;
				m_exColumn.Caption = m_sCaption;
				m_exColumn.Width = m_iWidth;
				m_exColumn.MinWidth = m_iWidth;
				m_exColumn.OptionsColumn.FixedWidth = false;
				m_exColumn.OptionsColumn.AllowEdit = !m_bReadOnly;
				m_exColumn.OptionsColumn.ReadOnly = m_bReadOnly;
				m_exColumn.ColumnEdit = m_exEditor;
				m_exColumn.Visible = m_bVisible;
				m_exColumn.Tag = this;

				m_iIndex = m_exColumn.AbsoluteIndex;
			}
		}

		private void SetName(string sValue)
		{
			m_sName = sValue;
			if (m_exColumn != null)
				m_exColumn.Name = sValue;
		}

        private void SetSort(bool bAllowSort)
        {
            m_bAllowSort = bAllowSort;

            if (m_exColumn != null)
                m_exColumn.OptionsColumn.AllowSort = m_bAllowSort;
        }

		private void SetCaption(string sValue)
		{
			m_sCaption = sValue;
			if (m_exColumn != null)
				m_exColumn.Caption = sValue;
		}

		private void SetWidth(int iValue)
		{
			m_iWidth = iValue;
			if (m_exColumn != null)
			{
				m_exColumn.Width = iValue;
				m_exColumn.Width = iValue;
				m_exColumn.MinWidth = iValue;
				m_exColumn.OptionsColumn.FixedWidth = true;
			}
		}

		private void SetReadOnly(bool bValue)
		{
			m_bReadOnly = bValue;
			if (m_exColumn != null)
			{
				m_exColumn.OptionsColumn.AllowEdit = !bValue;
				m_exColumn.OptionsColumn.ReadOnly = bValue;
			}
		}

		private void SetVisible(bool bValue)
		{
			m_bVisible = bValue;
			if (m_exColumn != null)
				m_exColumn.Visible = bValue;
		}

		private void SetEditor(RepositoryItem exValue)
		{
			m_exEditor = exValue;
			if (m_exColumn != null)
			{
				m_exColumn.ColumnEdit = exValue;
			}
		}

		#endregion


		#region Event Methods


		#endregion
	}
}
