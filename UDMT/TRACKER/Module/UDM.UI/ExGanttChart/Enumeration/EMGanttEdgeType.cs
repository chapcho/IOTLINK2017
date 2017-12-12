using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public enum EMGanttEdgeShapeType
    {
        Empty = 0,
        FillRhombus = 3,
        FillArrowUp = 5,
        FillArrowDown = 6,
        FillArrowLeft = 7,
        FillArrowRight = 8,
        FillSquare = 18,
        FillCircle = 19,
        FillStar = 20,
        Rhombus = 61443,
        ArrowUp = 61445,
        ArrowDown = 61446,
        ArrowLeft = 61447,
        ArrowRight = 61448,
        Square = 61458,
        Circle = 61459,
        Star = 61460
    }

    public enum EMGanttEdgeType
    {
        Start = 0,
        End = 1,
        Both = 2
    }
}
