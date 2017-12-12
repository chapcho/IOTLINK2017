using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Event
{
    public class IOMakerEventArgs : EventArgs
    {
        public int iPLC { get; set; }
        public string sPLC { get; set; }
    }
}
