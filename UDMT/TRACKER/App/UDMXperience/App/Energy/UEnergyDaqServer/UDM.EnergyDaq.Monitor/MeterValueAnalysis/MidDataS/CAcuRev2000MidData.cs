using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public class CAcuRev2000MidData
    {
        protected List<CAcuRev2000ChannelData> m_lstChannelS = null;

        #region Initilaize /Dispose

        public CAcuRev2000MidData()
        {
            m_lstChannelS = new List<CAcuRev2000ChannelData>();
        }

        #endregion

        #region Public Properties


        public List<CAcuRev2000ChannelData> ChannelS
        {
            get { return m_lstChannelS; }
            set { m_lstChannelS = value; }
        }

        #endregion
    }
}
