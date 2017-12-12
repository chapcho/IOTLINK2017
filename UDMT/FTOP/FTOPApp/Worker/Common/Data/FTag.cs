using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{

    /// <summary>
    /// FTOP-Client에서만 사용하는 Class 
    /// Thread -> EnQue , Deque 에서 사용
    /// <para/> - Default Setting....
    /// </summary>
    public class FTag : IObject
    {
        /* Real Event Time */
        public DateTime Time { get; set; }

        /* OPC Server Request Key */
        public string Key { get; set; }

        /* OPC Server Request Value */
        public object Value { get; set; }

        public bool used { get; set; }

        public FTag(DateTime t, string k, object i)
        {
            Time = t;
            Key = k;
            Value = i;

            used = false;
        }

        public FTag()
        {

        }
    }
}
