using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CPacketInfoS : List<CPacketInfo>, IDisposable
    {

        #region Member Variables

        #endregion


        #region Initialize/Dispose

        public CPacketInfoS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        #endregion


        #region Public Methods
        
        public void Compose(CStepS cStepS, CTagS cTagS)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Compose(cStepS, cTagS);
            }
        }

        public CPacketInfo GetPacketInfo(string sStep)
        {
            CPacketInfo cPacket = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RefStepS.ContainsKey(sStep))
                {
                    cPacket = this[i];
                    break;
                }
            }

            return cPacket;
        }

        public int GetPacketIndex(string sStep)
        {
            int iIndex = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RefStepS.ContainsKey(sStep))
                {
                    iIndex = i;
                    break;
                }
            }

            return iIndex;
        }

        public List<CPacketInfo> GetPacketInfoList(string sTag)
        {
            List<CPacketInfo> lstPacket = new List<CPacketInfo>();

            CPacketInfo cInfo = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RefTagS.ContainsKey(sTag))
                {
                    cInfo = this[i];
                    lstPacket.Add(cInfo);
                }
            }

            return lstPacket;
        }

        public List<int> GetPacketIndexList(string sTag)
        {
            List<int> lstIndex = new List<int>();

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RefTagS.ContainsKey(sTag))
                {
                    lstIndex.Add(i);
                }
            }

            return lstIndex;
        }

        #endregion

    }
}
