using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public delegate void UEventHandlerTimeLineFirstVisibleTimeChanged(object sender);
	public delegate void UEventHandlerTimeLineZoomIn(object sender);
	public delegate void UEventHandlerTimeLineZoomOut(object sender);
	public delegate void UEventHandlerTimeLineScrollChanged(object sender);
	public delegate void UEventHandlerTimeLineTimeIndicatorMoved(object sender, CTimeIndicator cIndicator);
	public delegate void UEventHandlerTimeLineTimeDoublClicked(object sender, DateTime dtTime);

	public delegate void UEVentHandlerTimeRangeChanged(object sender);
}
