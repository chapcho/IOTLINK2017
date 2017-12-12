using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.PLCActionPattern
{
    [Serializable]
    public class CUniqueStringList : List<string>
    {
        public void Add(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                if (!Contains(data))
                {
                    base.Add(data);
                }
            }
            else return;
        }
    }
}
