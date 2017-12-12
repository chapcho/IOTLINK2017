using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public delegate void UEventHandlerSeriesChartPointClicked(object sender, CSeriesPoint cPoint);
	public delegate void UEventHandlerSeriesChartPointDoubleClicked(object sender, CSeriesPoint cPoint);
	public delegate void UEventHandlerSeriesChartAxisScrollChanged(object sender);

}
