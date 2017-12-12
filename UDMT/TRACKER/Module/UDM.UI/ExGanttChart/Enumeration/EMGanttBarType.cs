using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public enum EMGanttBarType
    {
        BTask = 0,
        GTask = 1,
        RTask = 2,
        LGTask = 3,
		LBTask = 4,
        StartlessBTask = 5,        
        StartlessGTask = 6,
        StartlessRTask = 7,
		StartlessLGTask = 8,
        StartlessLBTask = 9,
        EndlessBTask = 10,
        EndlessGTask = 11,        
        EndlessRTask = 12,
		EndlessLGTask = 13,
        EndlessLBTask = 14,
        FocusedBTask = 15,
        FocusedGTask = 16,
        FocusedRTask = 17,
		FocusedLGTask = 18,
        FocusedLBTask = 19,
        BlankTask = 20,
        Count = 21
    }
}
