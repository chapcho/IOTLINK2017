using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public enum EMActionType
	{
		None,
		AddBar,
		MoveBar,
		ResizeBarStart,
		ResizeBarEnd,
		DeleteBar,
		AddLink,
		MoveTimeIndicator,
		MoveTime,
		ChangeFocusedItem,
		Zoom
	}
}
