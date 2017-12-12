using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Event
{
    public class MutiCopyEventArgs : EventArgs
    {
        public int iKey { get; set; }
        public string sKey { get; set; }
    }
}
