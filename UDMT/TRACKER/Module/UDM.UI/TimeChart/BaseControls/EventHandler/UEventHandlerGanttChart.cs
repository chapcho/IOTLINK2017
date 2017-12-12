using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public delegate void UEventHandlerGanttChartBarCreated(object sender, CGanttBar cBar);
	public delegate void UEventHandlerGanttChartBarMoved(object sender, CGanttBar cBar);
	public delegate void UEventHandlerGanttChartBarRemoved(object sender, CGanttBar cBar);
	public delegate void UEventHandlerGanttChartBarResized(object sender, CGanttBar cBar);

	public delegate void UEventHandlerGanttChartLinkCreated(object sender, CGanttLink cLink);
	public delegate void UEventHandlerGanttChartLinkRemoved(object sender, CGanttLink cLink);

	public delegate void UEventHandlerGanttChartBarClicked(object sender, CGanttBar cBar, EventArgs e);
	public delegate void UEventHandlerGanttChartLinkClicked(object sender, CGanttLink cLink);
    public delegate void UEventHandlerGanttChartBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e);
    public delegate void UEventHandlerGanttChartLinkDoubleClicked(object sender, CGanttLink cLink, EventArgs e);
}
