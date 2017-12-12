using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.Tree;
using UDM.Common;

namespace UDM.LogicViewer
{
    public delegate void UEventHandlerExpandSubAll(object sender, Node selectNode);
    public delegate void UEventHandlerLogicViewerTimeIndicatorChanged(object sender, DateTime dtTime);
    public delegate void UEventHandlerNameChanged(object sender, string sName);
    public delegate void UEventHandlerFocusedDiagramChanged(object sender, UCLogicDiagram ucDiagram);
    public delegate void UEventHandlerDrawDiagram(Node selectNode, CLDRung cLDRung, DateTime dtCurrent);
    public delegate void UEventHandlerDeviceSubDepthRetrive(object sendder,CSymbol targetSymbol);
}
