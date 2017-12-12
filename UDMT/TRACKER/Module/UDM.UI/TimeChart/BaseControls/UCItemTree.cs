using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace UDM.UI.TimeChart
{
	public partial class UCItemTree : Panel
	{	
		
		#region Member Variables

		protected CColumnItemS m_cColumnS = null;
		protected CRowItemS m_cItemS = null;

		protected bool m_bSetChangeRequested = false;
		protected bool m_bIsItemMovable = true;
		protected bool m_bStartDragDrop = false;
		protected Point m_pntMousePos = new Point();

		protected int m_iScrollMaxValue = 1;
		protected int m_iScrollMinValue = 0;
		protected int m_iScrollValue = 0;
		protected int m_iScrollLargeChange = 10;

		public event UEventHandlerItemTreeCellValueChanged UEventCellValueChagned;
		public event UEventHandlerItemTreeItemCheckStateChanged UEventItemCheckStateChanged;
		public event UEventHandlerItemTreeFocusedItemChanged UEventFocusedItemChanged;
		public event UEventHandlerItemTreeItemScrollChanged UEventItemScrollChanged;
		public event UEventHandlerItemTreeItemExpanded UEventItemExpaned;
		public event UEventHandlerItemTreeItemCollapsed UEventItemCollapsed;
		public event UEventHandlerItemTreeItemMoved UEventItemMoved;
		public event UEventHandlerItemTreeColumnSorted UEventColumnSorted;
		public event UEventHandlerLayoutUpdated UEventLayoutUpdated;

		#endregion


		#region Initialize/Dispose

		public UCItemTree()
		{
			InitializeComponent();

			InitVariables();

		}

		public UCItemTree(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public new Font Font
		{
			get { return exTreeList.Font; }
			set { SetFont(value); }
		}
		
		public CColumnItemS ColumnS
		{
			get { return m_cColumnS; }
		}

		public CRowItemS ItemS
		{
			get { return m_cItemS; }
		}

		public CRowItem FocusedItem
		{
			get {return GetFocusedItem();}
			set {SetFocusedItem(value);}
		}

		public CColumnItem FocusedColumn
		{
			get {return GetFocusedColumn();}
		}

		public CRowItem FirstVisibleItem
		{
			get { return GetFirstVisibleItem(); }
			set { SetFirstVsibleItem(value); }
		}

		public int ScrollMaxValue
		{
			get { return m_iScrollMaxValue; }
		}

		public int ScrollMinValue
		{
			get { return m_iScrollMinValue; }
		}

		public int ScrollValue
		{
			get { return m_iScrollValue; }
			set { SetScrollValue(value); }
		}

		public int ScrollLargeChange
		{
			get { return m_iScrollLargeChange; }
		}

		public bool IsItemMovable
		{
			get { return m_bIsItemMovable; }
			set { m_bIsItemMovable = value; exTreeList.AllowDrop = value; }
		}

		public bool ShowCheckBox
		{
			get { return exTreeList.OptionsView.ShowCheckBoxes; }
			set { exTreeList.OptionsView.ShowCheckBoxes = value; }
		}

		public bool ShowAutoFilter
		{
			get { return exTreeList.OptionsView.ShowAutoFilterRow; }
			set { exTreeList.OptionsView.ShowAutoFilterRow = value; }
		}

		public bool ShowHScrollBarAlways
		{
			get { return GetHScrollBarAlways(); }
			set { SetHScrollBarAlways(value); }
		}

		public int ColumnHeight
		{
			get { return exTreeList.ColumnPanelRowHeight; }
			set { exTreeList.ColumnPanelRowHeight = value; }
		}

		public int ItemHeight
		{
			get { return exTreeList.RowHeight; }
			set { exTreeList.RowHeight = value; }
		}

		public int FirstVisibleItemIndex
		{
			get { return exTreeList.TopVisibleNodeIndex; }
			set { exTreeList.TopVisibleNodeIndex = value; }
		}

		public int TotalVisibleItemCount
		{
			get { return exTreeList.VisibleNodesCount; }
		}
		
		public int PageVisibleItemCount
		{
			get { return GetPageVisibleItemCount(); }
		}

		#endregion


		#region Public Methods

		#region Layout

		public void UpdateLayout()
		{
			exTreeList.Refresh();
            exTreeList.BestFitColumns();
		}

		public void BeginUpdate()
		{
			exTreeList.BeginUpdate();
		}

		public void EndUpdate()
		{	
			exTreeList.EndUpdate();
		}

		#endregion

		#region Item

		public List<CRowItem> GetViewItemList()
		{
			List<CRowItem> lstItem = new List<CRowItem>();

			RowsInfo exRowsInfo = exTreeList.ViewInfo.RowsInfo;
			foreach (RowInfo exRowInfo in exRowsInfo.Rows)
			{
				if (exRowInfo.Node.Tag != null)
					lstItem.Add((CRowItem)exRowInfo.Node.Tag);
			}

			return lstItem;
		}

		public int GetVisibleItemIndex(CRowItem cItem)
		{
			if (cItem == null)
				return -1;

			return exTreeList.GetVisibleIndexByNode(cItem.ExNode);
		}

		public CRowItem GetItem(int iIndex)
		{
			TreeListNode exNode = exTreeList.GetNodeByVisibleIndex(iIndex);
			if (exNode == null)
				return null;

			return (CRowItem)exNode.Tag;
		}

		public void ItemUp(List<CRowItem> lstItem)
		{
			exTreeList.BeginUpdate();
			{
				int iLimitIndex = 0;
				int iItemIndex = 0;
				TreeListNode exNode;
				for (int i = 0; i < lstItem.Count; i++)
				{
					exNode = lstItem[i].ExNode;
					iItemIndex = exTreeList.GetNodeIndex(exNode);
					if (iItemIndex == iLimitIndex)
						continue;

					exTreeList.SetNodeIndex(exNode, iItemIndex - 1);
				}
			}
			exTreeList.EndUpdate();
		}

		public void ItemDown(List<CRowItem> lstItem)
		{
			exTreeList.BeginUpdate();
			{
				int iLimitIndex = 0;
				int iItemIndex = 0;
				TreeListNode exNode;
				for (int i = 0; i < lstItem.Count; i++)
				{
					exNode = lstItem[i].ExNode;
					iItemIndex = exTreeList.GetNodeIndex(exNode);

					if(exNode.ParentNode == null)
						iLimitIndex = exTreeList.Nodes.Count - 1;
					else
						iLimitIndex = exNode.ParentNode.Nodes.Count - 1;

					if (iItemIndex == iLimitIndex)
						continue;

					exTreeList.SetNodeIndex(exNode, iItemIndex + 1);
				}
			}
			exTreeList.EndUpdate();
		}

		public List<CRowItem> GetSelectedItemList()
		{
			TreeListMultiSelection exSelectionList = exTreeList.Selection;
			if (exSelectionList == null)
				return null;

			List<CRowItem> lstItem = new List<CRowItem>();

			TreeListNode exNode;
			for(int i=0;i<exSelectionList.Count;i++)
			{
				exNode = exSelectionList[i];
				if(exNode.Tag != null)
					lstItem.Add((CRowItem)exNode.Tag);
			}

			return lstItem;
		}

		public void ExpandAll()
		{
			exTreeList.ExpandAll();
		}

		public void CollapseAll()
		{
			exTreeList.CollapseAll();
		}

		public CRowItem PickItem(int nPosY)
		{
			CRowItem cItem = null;

			TreeListHitInfo exInfo = exTreeList.CalcHitInfo(new Point(10, nPosY));
			TreeListNode exNode = exInfo.Node;
			if (exNode != null)
				cItem = (CRowItem)exNode.Tag;

			return cItem;
		}

		public float CalcPosition(CRowItem cItem)
		{
			if (cItem == null)
				return -1;

			float nPosY = -1;
			int nIndex = 0;

			int iTopNodeIndex = this.FirstVisibleItemIndex;
			nIndex = GetVisibleItemIndex(cItem);
			if (nIndex == -1)
				return -1;

			nPosY = (nIndex - iTopNodeIndex) * (this.ItemHeight + 1);

			return nPosY;
		}

		#endregion

		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{
			m_cColumnS = new CColumnItemS(exTreeList.Columns);
			m_cItemS = new CRowItemS(exTreeList.Nodes);
		}

		protected void SetFont(Font font)
		{
			base.Font = font;

			exTreeList.BeginUpdate();
			{
				exTreeList.Font = font;
				exTreeList.Appearance.Row.Options.UseFont = true;
				exTreeList.Appearance.Row.Font = font;
				exTreeList.Appearance.FilterPanel.Options.UseFont = true;
				exTreeList.Appearance.FilterPanel.Font = font;
				exTreeList.Appearance.Caption.Options.UseFont = true;
				exTreeList.Appearance.Caption.Font = font;
				exTreeList.Appearance.HeaderPanel.Options.UseFont = true;
				exTreeList.Appearance.HeaderPanel.Font = font;
			}
			exTreeList.EndUpdate();
		}

		protected bool GetHScrollBarAlways()
		{
			if (exTreeList.HorzScrollVisibility == ScrollVisibility.Always)
				return true;
			else
				return false;
		}

		protected void SetHScrollBarAlways(bool bValue)
		{
			if (bValue)
				exTreeList.HorzScrollVisibility = ScrollVisibility.Always;
			else
				exTreeList.HorzScrollVisibility = ScrollVisibility.Auto;
		}

		protected void SetScrollValue(int iValue)
		{
			if (m_iScrollValue != iValue)
			{
				if (iValue > m_iScrollMaxValue)
					m_iScrollValue = m_iScrollMaxValue;
				else if (iValue < m_iScrollMinValue)
					m_iScrollValue = m_iScrollMinValue;
				else
					m_iScrollValue = iValue;

				exTreeList.TopVisibleNodeIndex = iValue;
			}
		}

		#endregion

		#region Item

		protected CRowItem GetFirstVisibleItem()
		{
			int iIndex = exTreeList.TopVisibleNodeIndex;

			return GetItem(iIndex);
		}

		protected void SetFirstVsibleItem(CRowItem cItem)
		{
			int iIndex = GetVisibleItemIndex(cItem);

			if (iIndex < 0)
				return;

			exTreeList.TopVisibleNodeIndex = iIndex;
		}

		protected CRowItem GetFocusedItem()
		{
			TreeListNode exNode = exTreeList.FocusedNode;
			if (exNode == null)
				return null;

			return (CRowItem)exNode.Tag;
		}

		protected void SetFocusedItem(CRowItem cItem)
		{
			if (cItem == null)
				return;

			exTreeList.Selection.Clear();
			exTreeList.Selection.Add(cItem.ExNode);
			if (exTreeList.FocusedNode != cItem.ExNode)
			{
				m_bSetChangeRequested = true;
				exTreeList.SetFocusedNode(cItem.ExNode);
			}
		}

		protected CColumnItem GetFocusedColumn()
		{
			TreeListColumn exColumn = exTreeList.FocusedColumn;
			if (exColumn == null)
				return null;

			return (CColumnItem)exColumn.Tag;
		}

		protected int GetPageVisibleItemCount()
		{
			RowsInfo exRowsInfo = exTreeList.ViewInfo.RowsInfo;

			if (exRowsInfo == null || exRowsInfo.Rows == null)
				return 0;
			else
				return exRowsInfo.Rows.Count;
		}
		

		#endregion

		#region User Action


		#endregion

		#region Util


		#endregion

		#region Raising Event

		protected void GenerateCellValueChangeEvent(CColumnItem cColumn, CRowItem cItem, object oValue)
		{
			if (UEventCellValueChagned != null)
				UEventCellValueChagned(this, cColumn, cItem, oValue);
		}

		protected void GenerateItemCheckStateChanged(CRowItem cItem)
		{
			if (UEventItemCheckStateChanged != null)
				UEventItemCheckStateChanged(this, cItem);
		}

		protected void GenerateFocusedItemChangedEvent(CRowItem cItem)
		{
			if (UEventFocusedItemChanged != null)
				UEventFocusedItemChanged(this, cItem);
		}

		protected void GenerateItemExpanedEvent(CRowItem cItem)
		{
			if (UEventItemExpaned != null)
				UEventItemExpaned(this, cItem);
		}

		protected void GenerateItemCollapsedEvent(CRowItem cItem)
		{
			if (UEventItemCollapsed != null)
				UEventItemCollapsed(this, cItem);
		}

		protected void GenerateItemScrollChangedEvent()
		{
			if (UEventItemScrollChanged != null)
				UEventItemScrollChanged(this);
		}

		protected void GenerateColumnSortedEvent(CColumnItem cColumn)
		{
			if (UEventColumnSorted != null)
				UEventColumnSorted(this, cColumn);
		}

		protected void GenerateItemMovedEvent(List<CRowItem> cItemList)
		{
			if (UEventItemMoved != null)
				UEventItemMoved(this, cItemList);
		}

		protected void GenerateLayoutUpdatedEvent()
		{
			if (UEventLayoutUpdated != null)
				UEventLayoutUpdated(this);
		}

		#endregion

		#region Drawing

		protected void DrawLayout(Graphics g)
		{
			if(this.ShowHScrollBarAlways)
				g.DrawLine(Pens.LightGray, 0, this.Height - 19, this.Width - 1, this.Height - 19);
		}

		#endregion

		#endregion


		#region Event Methods


		#region Override

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		protected override void OnResize(EventArgs eventargs)
		{	
			base.OnResize(eventargs);

			exTreeList_LayoutUpdated(this, EventArgs.Empty);
		}

		#endregion


		#region TreeList

		protected void exTreeList_LayoutUpdated(object sender, EventArgs e)
		{
			int iMaxValue = exTreeList.VisibleNodesCount;
			int iValue = exTreeList.TopVisibleNodeIndex;
			int iPageCount = (this.ClientRectangle.Height - this.ColumnHeight - 4) / (this.ItemHeight + 1);

			if (iPageCount >= iMaxValue && m_iScrollLargeChange != iPageCount)
			{
				m_iScrollMaxValue = 0;
				m_iScrollValue = 0;
				m_iScrollLargeChange = 0;
				GenerateItemScrollChangedEvent();
			}
			else
			{
				if (m_iScrollMaxValue != iMaxValue)
				{
					m_iScrollMaxValue = iMaxValue;
					m_iScrollValue = iValue;
					m_iScrollLargeChange = iPageCount;
					GenerateItemScrollChangedEvent();
				}
				else if (m_iScrollValue != iValue)
				{
					m_iScrollMaxValue = iMaxValue;
					m_iScrollValue = iValue;
					m_iScrollLargeChange = iPageCount;
					GenerateItemScrollChangedEvent();
				}
				else if (m_iScrollLargeChange != iPageCount)
				{
					m_iScrollMaxValue = iMaxValue;
					m_iScrollValue = iValue;
					m_iScrollLargeChange = iPageCount;
					GenerateItemScrollChangedEvent();
				}
			}

			GenerateLayoutUpdatedEvent();
		}

		protected void exTreeList_TopVisibleNodeIndexChanged(object sender, EventArgs e)
		{
			m_iScrollValue = exTreeList.TopVisibleNodeIndex;

			
			GenerateItemScrollChangedEvent();
		}

		protected void exTreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
				return;

			GenerateFocusedItemChangedEvent((CRowItem)e.Node.Tag);

			if (m_bSetChangeRequested)
				m_bSetChangeRequested = false;
			else
				GenerateLayoutUpdatedEvent();
		}

		private void exTreeList_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			if (e.Column == null || e.Column.Tag == null || e.Node == null || e.Node.Tag == null)
				return;

			CRowItem cItem = (CRowItem)e.Node.Tag;
			int iColumnIndex = e.Column.AbsoluteIndex;
			if(cItem.Values.Length > iColumnIndex)
			{
				cItem.Values[iColumnIndex] = e.Value;

				GenerateCellValueChangeEvent((CColumnItem)e.Column.Tag, (CRowItem)e.Node.Tag, e.Value);
			}
		}

		protected void exTreeList_KeyDown(object sender, KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		private void exTreeList_KeyUp(object sender, KeyEventArgs e)
		{
			base.OnKeyUp(e);
		}

		protected void exTreeList_Paint(object sender, PaintEventArgs e)
		{
			DrawLayout(e.Graphics);
		}

		protected void exTreeList_AfterCheckNode(object sender, NodeEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
				return;

			CRowItem cItem = (CRowItem)e.Node.Tag;

			GenerateItemCheckStateChanged(cItem);
		}

		private void exTreeList_AfterExpand(object sender, NodeEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
				return;

			GenerateItemExpanedEvent((CRowItem)e.Node.Tag);
		}

		private void exTreeList_AfterCollapse(object sender, NodeEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
				return;

			GenerateItemCollapsedEvent((CRowItem)e.Node.Tag);
		}

		private void exTreeList_EndSorting(object sender, EventArgs e)
		{
			CColumnItem cColumn = this.FocusedColumn;
			if (cColumn == null)
				return;

			GenerateColumnSortedEvent(cColumn);
		}

		private void exTreeList_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (m_bIsItemMovable && m_bStartDragDrop == false)
				{
					m_pntMousePos = new Point(e.X, e.Y);
					DevExpress.XtraTreeList.TreeListHitInfo exInfo = exTreeList.CalcHitInfo(m_pntMousePos);
					if (exInfo.Node == null)
						return;

					DevExpress.XtraTreeList.TreeListMultiSelection exSelection = exTreeList.Selection;

					exTreeList.DoDragDrop(exSelection, DragDropEffects.Move);
					DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

					m_bStartDragDrop = true;
				}
			}
		}

		private void exTreeList_MouseUp(object sender, MouseEventArgs e)
		{
			m_bStartDragDrop = false;
		}

		private void exTreeList_DragOver(object sender, DragEventArgs e)
		{
			if (m_bIsItemMovable == false)
				return;

			object oData = e.Data;
			if (oData == null)
				return;

			if (e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.TreeListMultiSelection)))
			{
				e.Effect = DragDropEffects.Move;
			}
		}

		private void exTreeList_DragDrop(object sender, DragEventArgs e)
		{
			if (m_bIsItemMovable == false)
				return;

			object oData = e.Data;
			if (oData == null)
				return;

			if (e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.TreeListMultiSelection)))
			{
				e.Effect = DragDropEffects.None;

				Point pntTargetPos = exTreeList.PointToClient(new Point(e.X, e.Y));
				DevExpress.XtraTreeList.TreeListHitInfo exHitInfo = exTreeList.CalcHitInfo(pntTargetPos);
				if (exHitInfo.Node == null)
					return;

				bool bItemUp = true;
				if (pntTargetPos.Y > m_pntMousePos.Y)
					bItemUp = false;

				TreeListNode trnParent = exHitInfo.Node.ParentNode;
				TreeListMultiSelection exSelection = (DevExpress.XtraTreeList.TreeListMultiSelection)e.Data.GetData(typeof(DevExpress.XtraTreeList.TreeListMultiSelection));
				int iTargetIndex = exTreeList.GetNodeIndex(exHitInfo.Node);

				List<CRowItem> cItemList = new List<CRowItem>();

				exTreeList.BeginUpdate();
				{
					CRowItem cItem;
					TreeListNode trnNode;
					for (int i = 0; i < exSelection.Count; i++)
					{
						trnNode = exSelection[i];
						if (trnNode.Tag != null)
						{
							cItem = (CRowItem)trnNode.Tag;

							exTreeList.MoveNode(trnNode, exHitInfo.Node.ParentNode);
							exTreeList.SetNodeIndex(trnNode, iTargetIndex);
							if (bItemUp)
								iTargetIndex += 1;

							cItemList.Add(cItem);
						}
					}
				}
				exTreeList.EndUpdate();

				GenerateItemMovedEvent(cItemList);
			}
		}

		#endregion

		#endregion
	}
}
