using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public class OPCTag
    {
        public string Channel { get; set; }
        public string Device { get; set; }

        public string PLCName { get; set; }
        public string EthernetAdapter { get; set; }
        public int CommunicationInterval { get; set; }

        public string IPAddress { get; set; }

        public OPCTag() 
        {

        }

    }
}
