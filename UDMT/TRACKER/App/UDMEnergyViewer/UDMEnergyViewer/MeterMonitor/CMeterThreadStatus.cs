using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMEnergyViewer
{
    public static class CMeterThreadStatus
    {
        private static int m_iCount = 0;

        public static int Count
        {
            get { return m_iCount; }
            set { m_iCount = value; }
        }
    }
}
