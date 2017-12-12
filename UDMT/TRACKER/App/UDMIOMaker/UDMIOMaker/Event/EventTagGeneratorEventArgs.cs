using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Event
{

    public class TagGeneratorPLCMenuEventArgs : EventArgs
    {
        public int iPLC  { get; set; }
        public string sPLC { get; set; }
    }

    public class TagGeneratorHMIMenuEventArgs : EventArgs
    {
        public int iHMI { get; set; }
        public string sHMI { get; set; }
    }

    public class TagGeneratorHOMEMenuEventArgs : EventArgs
    {
        public int iHome { get; set; }
        public string sHome { get; set; }
    }

    public class TagGeneratorToolMenuEventArgs : EventArgs
    {
        public int iTool { get; set; }
        public string sTool { get; set; }
    }
}
