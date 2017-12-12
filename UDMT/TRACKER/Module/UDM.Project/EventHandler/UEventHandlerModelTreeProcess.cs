using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Model;

namespace UDM.Project
{
	public delegate void UEventHandlerModelTreeProcessAdded(object sender, CProcess cProcess);
	public delegate void UEventHandlerModelTreeProcessRemove(object sender, CProcess cProcess);
	public delegate void UEventHandlerModelTreeProcessUpdate(object sender, CProcess cProcess);
}
