using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMPLCLogicAnalyzer
{
    public delegate void UEventHandlerMessage(string sSender, string sMessage);
    public delegate void UEventHandlerStepTableDoubleClicked(object sender, CStep cStep);
    public delegate void UEventHandlerDoubleCoilLadderView(object sender, string sTagKey, List<CStep> lstStep);
}
