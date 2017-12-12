using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowItemS : Dictionary<string, CFlowItem>, ICloneable
    {

        #region Member Variables

        protected string m_sDescription = "";
        protected DateTime m_dtFirst = CMasterTime.BaseTime;
        protected DateTime m_dtLast = CMasterTime.BaseTime.AddMinutes(1);        
        protected object m_oData = null;        

        #endregion


        #region Initialize/Dispose

        public CFlowItemS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CFlowItemS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public DateTime First
        {
            get { return m_dtFirst; }
            set { m_dtFirst = value; }
        }

        public DateTime Last
        {
            get { return m_dtLast; }
            set { m_dtLast = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        public CFlowItem this[int iIndex]
        {
            get { return GetItem(iIndex); }
        }

        #endregion


        #region Public Methods

        public CTimeNode GetNode(string sKey, DateTime dtStart)
        {
            CTimeNode cNode = null;
            
            if (this.ContainsKey(sKey))
            {
                CFlowItem cItem = this[sKey];
                cNode = cItem.GetNode(dtStart);
            }

            return cNode;
        }

        public CTimeNode GetNode(string sKey, int iIndex)
        {
            CTimeNode cNode = null;

            if (this.ContainsKey(sKey))
            {
                CFlowItem cItem = this[sKey];
                cNode = cItem.GetNode(iIndex);
            }

            return cNode;
        }

        public int GetNodeIndex(string sKey, CTimeNode cNode)
        {
            int iIndex = -1;

            if (this.ContainsKey(sKey))
            {
                CFlowItem cItem = this[sKey];
                iIndex = cItem.GetNodeIndex(cNode);
            }

            return iIndex;
        }

        public void Normalize(DateTime dtTime)
        {
            TimeSpan tsOffSet = dtTime.Subtract(m_dtFirst);
            Normalize(tsOffSet);
        }

        public void Normalize(TimeSpan tsOffSet)
        {
            if (m_dtFirst != DateTime.MinValue)
                m_dtFirst = m_dtFirst.Add(tsOffSet);

            if (m_dtLast != DateTime.MinValue)
                m_dtLast = m_dtLast.Add(tsOffSet);

            CFlowItem cItem;
            for (int i = 0; i < this.Count; i++)
            {
                cItem = this[i];
                cItem.Normalize(tsOffSet);
            }
        }

        public object Clone()
        {
            CFlowItemS cItemSClone = new CFlowItemS();
            
            string sKey = "";
            CFlowItem cItem;
            CFlowItem cItemClone;
            for (int i = 0; i < this.Count; i++)
            {
                sKey = this.ElementAt(i).Key;
                cItem = this.ElementAt(i).Value;
                cItemClone = (CFlowItem)cItem.Clone();
                cItemSClone.Add(sKey, cItemClone);
            }

            cItemSClone.First = m_dtFirst;
            cItemSClone.Last = m_dtLast;

            return cItemSClone;
        }
        
        public void Sort()
        {
            List<CFlowItem> lstFlowItem = this.Values.ToList();
            lstFlowItem.Sort(new CFlowItemComparer());

            this.Clear();

            CFlowItem cItem;
            for(int i=0;i<lstFlowItem.Count;i++)
            {
                cItem = lstFlowItem[i];
                this.Add(cItem.Key, cItem);
            }
        }

        #endregion


        #region Private Methods

        protected CFlowItem GetItem(int iIndex)
        {
            CFlowItem cItem = null;

            if (this.Count > iIndex)
                cItem = this.ElementAt(iIndex).Value;

            return cItem;
        }

        #endregion

    }
}
