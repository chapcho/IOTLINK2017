using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Flow
{
    public static class CMasterTime
    {
        private static DateTime m_dtBaseTime = new DateTime(2000, 1, 1);

        public static DateTime BaseTime
        {
            get { return m_dtBaseTime; }
        }
    }
}
