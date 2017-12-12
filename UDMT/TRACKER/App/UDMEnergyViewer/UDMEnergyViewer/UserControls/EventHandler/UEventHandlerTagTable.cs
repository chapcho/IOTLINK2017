using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDMEnergyViewer
{
	public delegate string UEventHandlerTagTableInputTextRequest(object sender);

	public delegate void UEventHandlerTagTableTagAdded(object sender, List<CTag> lstTag);
	public delegate void UEventHandlerTagTableTagRemoved(object sender, List<CTag> lstTag);
	public delegate void UEventHandlerTagTableTagUpdated(object sender, List<CTag> lstTag);
	public delegate void UEventHandlerTagTableTagDoubleClicked(object sender, CTag cTag); 
}
