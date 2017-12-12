using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Tile
{
	public delegate void UEventHandlerTileGroupAdded(object Sender, DevExpress.XtraEditors.TileGroup Group);
	public delegate void UEventHandlerTileGroupRemoved(object Sender, DevExpress.XtraEditors.TileControl TileControl);
	public delegate void UEventHandlerTileGroupSRemoved(object Sender, DevExpress.XtraEditors.TileControl TileControl);
	public delegate void UEventHandlerTileItemAdded(object Sender, DevExpress.XtraEditors.TileItem Item);
	public delegate void UEventHandlerTileItemRemoved(object Sender, DevExpress.XtraEditors.TileGroup Group);
	public delegate void UEventHandlerTileItemSRemoved(object Sender, DevExpress.XtraEditors.TileGroup Group);
	public delegate void UEventHandlerTileItemNormalColorChanged(object Sender, DevExpress.XtraEditors.TileItem item, CMonitorEventArgs Args);
	public delegate void UEventHandlerTileItemErrorColorChaged(object Sender, DevExpress.XtraEditors.TileItem item, CMonitorEventArgs Args);
    public delegate void UEventHandlerTileItemClick(object Sender, DevExpress.XtraEditors.TileItem item); 
}
