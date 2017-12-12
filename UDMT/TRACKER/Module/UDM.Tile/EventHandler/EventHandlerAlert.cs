using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Tile
{
	public delegate void UEventHandlerAlertButtonAdd(object sender, EventArgs args);
	public delegate void UEventHandlerAlertButtonDelete(object sender, EventArgs args);
	public delegate void UEventHandlerAlertButtonClick(object Sender, CGroupInfo cGroupInfo);
}
