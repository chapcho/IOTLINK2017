using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public delegate void UEventHandlerItemTreeCellValueChanged(object sender, CColumnItem cColumn, CRowItem cItem, object oValue);
	public delegate void UEventHandlerItemTreeItemScrollChanged(object sender);
	public delegate void UEventHandlerItemTreeFocusedItemChanged(object sender, CRowItem cItem);
	public delegate void UEventHandlerItemTreeKeyDown(object sender, KeyEventArgs cKey);
	public delegate void UEventHandlerItemTreeItemCheckStateChanged(object sender, CRowItem cItem);

	public delegate void UEventHandlerItemTreeItemExpanded(object sender, CRowItem cItem);
	public delegate void UEventHandlerItemTreeItemCollapsed(object sender, CRowItem cItem);
	public delegate void UEventHandlerItemTreeItemMoved(object sender, List<CRowItem> cItemList);
	public delegate void UEventHandlerItemTreeColumnSorted(object sender, CColumnItem cColumn);

}
