using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common
{
    public static class GenericUtil
    {
        public static bool Compare<T>(T value, T value2)
        {
            return value.Equals(value2);
        }
    }
}
