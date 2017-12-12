using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace NewIOMaker
{
    public class VerificationList
    {
        public int symbol = 0;
        public int logic = 0;
        public int memoryboth = 0;

        public int contact = 0;
        public int coil = 0;
        public int contactboth = 0;

        public int doubleCoil = 0;

        public Dictionary<string, BindingList<CTag>> data = new Dictionary<string, BindingList<CTag>>();

        public VerificationList()
        {
            
        }
    }
}
