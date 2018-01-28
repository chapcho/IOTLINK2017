using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Entity
{
    public class CPacketDefine : List<CPacketData>
    {
        private string m_sPacketName;
        private string m_sPacketDesc;
        private string m_sPacketStartIndicater;
        private string m_sPacketEndIndicater;
        private int m_iPacketMemberCount;
        private int m_iReceiveCount;
        private DateTime m_dLastReceiveDt;

        public CPacketDefine()
        {

        }

        public void Dispose()
        {
            this.Clear();
        }
    }
}
