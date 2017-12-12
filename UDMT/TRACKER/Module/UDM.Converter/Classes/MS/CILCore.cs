using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Converter
{
    public enum EILType
    {
        CONNECT,
        COIL,
        CONNECT_OPERATION,
        ROUTINE,
        LINE
    }

    public enum EILCoil
    {
        NORMAL,
        SET,
        RESET
    }

    public enum EILMonitor
    {
        ON,
        OFF
    }

    public enum EILGroup
    {
        C,
        O,
        M,
        BASE,
        COIL
    }


    [Serializable]
    public class CCell : ICloneable
    {
        private int m_Column = 0;
        private int m_Row = 0;

        public CCell(int col, int row)
        {
            m_Column = col;
            m_Row = row;

        }

        public int COL { get { return m_Column; } set { m_Column = value; } }
        public int ROW { get { return m_Row; } set { m_Row = value; } }
        public object Clone() { return this.MemberwiseClone(); }
    }


}
