using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Flow;

namespace UDM.Project
{
    public delegate void UEventHandlerFlowRemvoed(object sender, CFlow cFlow);
	public delegate void UEventHandlerFlowEditorNodeDoubleClicked(object sender, CTimeNode cNode);
	public delegate void UEventHandlerFlowEditorLinkDoubleClicked(object sender, CTimeNodeLink cLink);
}
