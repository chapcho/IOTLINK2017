using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public delegate void UEventHandlerGanttMouseDown(object sender, short iButton, short iShift, int iX, int iY);
    public delegate void UEventHandlerGanttMouseMove(object sender, short iButton, short iShift, int iX, int iY);
    public delegate void UEventHandlerGanttMouseUp(object sender, short iButton, short iShift, int iX, int iY);
    public delegate void UEventHandlerGanttFirstVisibleTimeChanged(object sender, DateTime dtTime);
    public delegate void UEventHandlerGanttZoomed(object sender, int iUnitWidth);
    public delegate void UEventHandlerGanttGridWidthChanged(object sender, int iGridWidth);

    public delegate void UEventHandlerGanttBarTimeChanged(object sender, CGanttBar cBar);
    public delegate void UEventHandlerGanttBarCreated(object sender, CGanttBar cBar);
    public delegate void UEventHandlerGanttBarRemoved(object sender, CGanttBar cBar);
    public delegate void UEventHandlerGanttLinkUpdated(object sender, CGanttLink cLink);
    public delegate void UEventHandlerGanttLinkCreated(object sender, CGanttLink cLink);
    public delegate void UEventHandlerGanttLinkRemoved(object sender, CGanttLink cLink);

    public delegate void UEventHandlerGanttBarClicked(object sender, CGanttBar cBar, int iHandle, ref bool bHandled);
    public delegate void UEventHandlerGanttBarDoubleClicked(object sender, CGanttBar cBar, int iHandle, ref bool bHandled);

    public delegate void UEventHandlerGanttLinkClicked(object sender, CGanttLink cLink, ref bool bHandled);
    public delegate void UEventHandlerGanttLinkDoubleClicked(object sender, CGanttLink cLink, ref bool bHandled);

    public delegate void UEventHandlerGanttBarExpandChanged(object sender, CGanttBar cBar, bool bExpand);
    public delegate void UEventHandlerGanttKeyDown(object sender, ref short iKey, short iShift);

    public delegate void UEVentHandlerGanttTimeIndicatorCreated(object sender, CGanttTimeIndicator cIndicator);
    public delegate void UEventHandlerGanttTimeIndicatorRemoved(object sender, CGanttTimeIndicator cIndicator);
    public delegate void UEventHandlerGanttTimeIndicatorMoved(object sender, CGanttTimeIndicator cIndicator);
    public delegate void UEventHandlerGanttTimeIndicatorIntervalChanged(object sender, double nMillsecond);

	public delegate void UEventHandlerGanttAfterExpandItem(object sender, int index, CGanttItem cGanttItem);
    
}
