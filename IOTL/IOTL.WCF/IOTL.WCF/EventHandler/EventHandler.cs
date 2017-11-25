using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.WCF.EventHandler
{
    public delegate void UEventHandlerClientConnected(object sender, string sClient);
    public delegate void UEventHandlerClientDisconnected(object sender, string sClient);

    public delegate void UEventHandlerCollectorList(object sender, string[] saData);
    public delegate void UEventHandlerCommStart(object sender, string[] saData);
    public delegate void UEventHandlerCommStop(object sender, string[] saData);
    public delegate void UEventHandlerTagList(object sender, string[] saData);
    public delegate void UEventHandlerEmergTagList(object sender, string[] saData);
    public delegate void UEventHandlerRecipeTagList(object sender, string[] saData);
    public delegate void UEventHandlerTimeLogS(object sender, string[] saData);
    public delegate void UEventHandlerErrorTagList(object sender, string[] saData);
    public delegate void UEventHandlerStatus(object sender, string[] saData);
    public delegate void UEventHandlerClient(object sender, string[] saData);
    public delegate void UEventHandlerAddTagList(object sender, string[] saData);
    public delegate void UEventHandlerRemoveTagList(object sender, string[] saData);

    public delegate void UEventHandlerProjectinfo(object sender, string[] saData);
    public delegate void UEventHandlerLadderViewTagList(object sender, string[] saData);

}
