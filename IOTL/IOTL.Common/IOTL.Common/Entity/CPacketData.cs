using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Entity
{
    public class CPacketData
    {
        private int m_iPositionInPacket;
        private int m_iPacketDataLength;
        private string m_sDataType;
        private string m_sValue;

        public CPacketData()
        {

        }

        public int PositionInPacket
        {
            get { return m_iPositionInPacket; }
            set { m_iPositionInPacket = value; }
        }

        public int DataLengthInPacket
        {
            get { return m_iPacketDataLength; }
            set { m_iPacketDataLength = value; }
        }

        public string DataTypeDesc
        {
            get { return m_sDataType; }
            set { m_sDataType = value; }
        }

        public string DataValue
        {
            get { return m_sValue; }
            set { m_sValue = value; }
        }
    }
}
