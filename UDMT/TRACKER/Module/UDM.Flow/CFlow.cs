using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlow : CObject, ICloneable
    {
        #region Member Variables

        protected CFlowItemS m_cItemS = new CFlowItemS();
        protected CFlowLinkS m_cLinkS = new CFlowLinkS();
        protected DateTime m_dtFirst = DateTime.MinValue;
        protected DateTime m_dtLast = DateTime.MinValue;
        protected int m_iFrequency = 1;

        #endregion


        #region Initialize/Dispose

        public CFlow()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public CFlowItemS FlowItemS
        {
            get { return m_cItemS; }
            set { m_cItemS = value; }
        }

        public CFlowLinkS FlowLinkS
        {
            get { return m_cLinkS; }
            set { m_cLinkS = value; }
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

        public int Frequency
        {
            get { return m_iFrequency; }
            set { m_iFrequency = value; }
        }

        #endregion


        #region Public Methods

        public void Create(CSymbolS cSymbolS)
        {
            Clear();
            
            CSymbol cSymbol;
            CSymbol cSubSymbol;
            CTimeNode cNode;
            CTimeNode cSubNode;
            CFlowItem cItem;
            CFlowItem cSubItem;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                
                cItem = new CFlowItem();
                cItem.Key = cSymbol.Key;
                cItem.Description = cSymbol.Description;
                cItem.First = CMasterTime.BaseTime;

                cNode = new CTimeNode();
                cNode.Key = cSymbol.Key;
                cNode.Start = CMasterTime.BaseTime;
                cNode.End = CMasterTime.BaseTime.AddSeconds(10);
                cNode.Text = cSymbol.Name;
                cItem.TimeNodeS.Add(cNode);

                if (cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
                {
                    cItem.SubFlow = new CFlow();
                    for (int j = 0; j < cSymbol.SubSymbolS.Count; j++)
                    {
                        cSubSymbol = cSymbol.SubSymbolS[j];

                        cSubItem = new CFlowItem();
                        cSubItem.Key = cSubSymbol.Key;
                        cSubItem.Description = cSubSymbol.Description;
                        cSubItem.First = CMasterTime.BaseTime;

                        cSubNode = new CTimeNode();
                        cSubNode.Key = cSubSymbol.Key;
                        cSubNode.Start = CMasterTime.BaseTime;
                        cSubNode.End = CMasterTime.BaseTime.AddSeconds(10);
                        cSubNode.Text = cSubSymbol.Name;
                        cSubItem.TimeNodeS.Add(cSubNode);

                        cItem.SubFlow.FlowItemS.Add(cSubSymbol.Key, cSubItem);
                    }
                }

                m_cItemS.Add(cItem.Key, cItem);
            }
        }

        public void Create(CFlowItemS cItemS, CFlowRule cRule)
        {
            Clear();

            if (cItemS == null || cItemS.Count == 0)
                return;

            m_cItemS = (CFlowItemS)cItemS.Clone();
            m_dtFirst = m_cItemS.First;
            m_dtLast = m_cItemS.Last;

            m_cItemS.Sort();

            Normalize(CMasterTime.BaseTime);

            if (cRule.HasLink)
                CreateLink(cRule.PointTypeFrom, cRule.PointTypeTo, cRule.Interval);
        }

        public bool Update(CFlow cFlow)
        {
            if (cFlow == null || cFlow.FlowItemS == null || cFlow.FlowItemS.Count == 0)
                return false;

            bool bOK = CheckSameStructure(cFlow);
            if (bOK)
            {
                UpdateFlow(cFlow);
                m_iFrequency++;
            }

            return bOK;
        }

        public void FinalizeLinkS()
        {
            List<string> lstFromKey = GetLinkFromKeyList();
            List<CFlowLink> lstLink = null;
            CFlowLink cLink;
            CFlowLink cFirstLink = null;
            string sKey = "";
            for(int i=0;i<lstFromKey.Count;i++)
            {
                sKey = lstFromKey[i];
                lstLink = GetLinkListFromWith(sKey);
                if(lstLink.Count < 2)
                    continue;

                for(int j=0;j<lstLink.Count;j++)
                {
                    cLink = lstLink[j];
                    
                    if(j==0)
                    {
                        cFirstLink = cLink;
                    }
                    else
                    {
                        if(cFirstLink.PointTypeTo == EMLinkPointType.Start)
                        {
                            if(cFirstLink.NodeTo.Start > cLink.NodeTo.Start)
                            {
                                m_cLinkS.Remove(cFirstLink);
                                cFirstLink = cLink;
                            }
                            else
                            {
                                m_cLinkS.Remove(cLink);
                            }
                        }
                        else if(cFirstLink.PointTypeTo == EMLinkPointType.End)
                        {
                            if (cFirstLink.NodeTo.End > cLink.NodeTo.End)
                            {
                                m_cLinkS.Remove(cFirstLink);
                                cFirstLink = cLink;
                            }
                            else
                            {
                                m_cLinkS.Remove(cLink);
                            }
                        }
                    }                    
                }

                lstLink.Clear();
            }

            lstFromKey.Clear();
        }
        
        public CFlowCompareResultS Compare(CFlowItemS cItemS, bool bSubItem)
        {
            if (cItemS == null)
                cItemS = new CFlowItemS();

            CFlow cFlowClone = (CFlow)Clone();

            DateTime dtFirst = cItemS.First;
            if (dtFirst != DateTime.MinValue)
                cFlowClone.Normalize(dtFirst);

            // Mapping Nodes with this items and that cItems -> Add error item with not mapping nodes 
            CFlowCompareResultS cResultS = MappingNodeS(cFlowClone.FlowItemS, cItemS, bSubItem);
            cResultS.MasterFlow = cFlowClone;
            cResultS.FlowItemS = cItemS;

            try
            {
                // Check link sequence
                CFlowLink cLink;
                CTimeNode cNodeFrom;
                CTimeNode cNodeTo;
                CFlowCompareResultUnit cResultUnit = null;
                for (int i = 0; i < cFlowClone.FlowLinkS.Count; i++)
                {
                    cLink = cFlowClone.FlowLinkS[i];
                    cNodeFrom = cLink.NodeFrom.Indirect;
                    cNodeTo = cLink.NodeTo.Indirect;

                    cResultUnit = null;
                    if (cLink.Interval != 0 && cNodeFrom != null && cNodeTo != null)
                    {
                        if (cLink.PointTypeFrom == EMLinkPointType.Start && cLink.PointTypeTo == EMLinkPointType.Start)
                        {
                            if (cNodeTo.Start > cNodeFrom.Start)
                            {
                                TimeSpan tsSpan = cNodeTo.Start.Subtract(cNodeFrom.Start);
                                double nInterval = tsSpan.TotalMilliseconds;
                                if ((long)nInterval > cLink.Interval)
                                    cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.TimeOut);
                            }
                            else
                            {
                                cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.Link);
                            }
                        }
                        else if (cLink.PointTypeFrom == EMLinkPointType.Start && cLink.PointTypeTo == EMLinkPointType.End)
                        {
                            if (cNodeTo.End > cNodeFrom.Start)
                            {
                                TimeSpan tsSpan = cNodeTo.End.Subtract(cNodeFrom.Start);
                                double nInterval = tsSpan.TotalMilliseconds;
                                if ((long)nInterval > cLink.Interval)
                                    cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.TimeOut);
                            }
                            else
                            {
                                cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.Link);
                            }
                        }
                        else if (cLink.PointTypeFrom == EMLinkPointType.End && cLink.PointTypeTo == EMLinkPointType.Start)
                        {
                            if (cNodeTo.Start > cNodeFrom.End)
                            {
                                TimeSpan tsSpan = cNodeTo.Start.Subtract(cNodeFrom.End);
                                double nInterval = tsSpan.TotalMilliseconds;
                                if ((long)nInterval > cLink.Interval)
                                    cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.TimeOut);
                            }
                            else
                            {
                                cResultUnit = new CFlowCompareResultUnit(cLink.NodeTo, EMDifferenceType.Link);
                            }
                        }
                        else
                        {
                            if (cNodeTo.End > cNodeFrom.End)
                            {
                                TimeSpan tsSpan = cNodeTo.End.Subtract(cNodeFrom.End);
                                double nInterval = tsSpan.TotalMilliseconds;
                                if ((long)nInterval > cLink.Interval)
                                    cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.TimeOut);
                            }
                            else
                            {
                                cResultUnit = new CFlowCompareResultUnit(cLink, EMDifferenceType.Link);
                            }
                        }
                    }

                    if(cResultUnit != null)
                    {
                        CFlowCompareResult cResult = cResultS.GetResult(cResultUnit.TimeNode.Key);
                        if (cResult == null)
                        {
                            cResult = new CFlowCompareResult(cResultUnit.TimeNode.Key, null);
                            cResultS.Add(cResult);
                        }

                        cResult.Add(cResultUnit);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                cResultS = null;
            }

            return cResultS;
        }

        public int GetDifferenceScore(CFlowItemS cItemS)
        {
            int iValue = 0;

            CTimeNode cThisNode;
            CTimeNodeS cThisNodeS;
            CTimeNode cThatNode;
            CTimeNodeS cThatNodeS;
            string sKey;
            for (int i = 0; i < m_cItemS.Count; i++)
            {
                sKey = m_cItemS[i].Key;
                cThisNodeS = m_cItemS[i].TimeNodeS;

                if (cItemS.ContainsKey(sKey))
                {
                    cThatNodeS = cItemS[sKey].TimeNodeS;
                    
                    iValue += Math.Abs(cThatNodeS.Count - cThisNodeS.Count) * 10;

                    int iNodeCount = (cThisNodeS.Count > cThatNodeS.Count) ? cThatNodeS.Count : cThisNodeS.Count;
                    for (int j = 0; j < iNodeCount; j++)
                    {
                        cThisNode = cThisNodeS[j];
                        cThatNode = cThatNodeS[j];

                        TimeSpan tsSpan = cThatNode.Start.Subtract(cThisNode.Start);
                        double nInterval = tsSpan.TotalSeconds;
                        if (nInterval < 0)
                            nInterval = -1 * nInterval;

                        iValue += (int)nInterval;
                    }
                }
                else
                {
                    iValue += 50 * cThisNodeS.Count;
                }

            }

            return iValue;
        }

        public void Clear()
        {
            if (m_cItemS != null)
                m_cItemS.Clear();

            if (m_cLinkS != null)
                m_cLinkS.Clear();
        }

        public void Normalize(DateTime dtTime)
        {
            if (m_cItemS == null)
                return;

            TimeSpan tsOffSet = dtTime.Subtract(m_dtFirst);
            Normalize(tsOffSet);
        }

        public void Normalize(TimeSpan tsOffset)
        {
            if (m_cItemS == null)
                return;

            m_cItemS.Normalize(tsOffset);

            m_dtFirst = m_cItemS.First;
            m_dtLast = m_cItemS.Last;
        }

        public object Clone()
        {
            CFlow cFlowClone = new CFlow();

            cFlowClone.FlowItemS = (CFlowItemS)m_cItemS.Clone();
            cFlowClone.FlowLinkS = (CFlowLinkS)m_cLinkS.Clone(cFlowClone.FlowItemS);
            cFlowClone.First = m_dtFirst;
            cFlowClone.Last = m_dtLast;

            return cFlowClone;
        }

        #endregion


        #region Private Methtods

        protected void UpdateFlow(CFlow cFlow)
        {
            double nThisDuration = m_dtLast.Subtract(m_dtFirst).TotalMilliseconds;
            double nThatDuration = cFlow.Last.Subtract(cFlow.First).TotalMilliseconds;

            CFlow cBaseFlow = null;
            CFlow cTargetFlow = null;

            if (nThisDuration > nThatDuration)
            {
                cBaseFlow = (CFlow)cFlow.Clone();
                cTargetFlow = (CFlow)this.Clone();
                cBaseFlow.Frequency = cTargetFlow.Frequency + 1;
            }
            else
            {
                cBaseFlow = (CFlow)this.Clone();
                cTargetFlow = (CFlow)cFlow.Clone();
                cBaseFlow.Frequency += 1;
            }
            
            CFlowLink cBaseLink = null;
            CFlowLink cTargetLink = null;
            bool bExists = false;
            for (int i = 0; i < cBaseFlow.FlowLinkS.Count; i++)
            {
                cBaseLink = cBaseFlow.FlowLinkS[i];

                bExists = false;
                for (int j = 0; j < cTargetFlow.FlowLinkS.Count; j++)
                {
                    cTargetLink = cTargetFlow.FlowLinkS[j];

                    if (cBaseLink.PointTypeFrom != cTargetLink.PointTypeFrom || cBaseLink.PointTypeTo != cTargetLink.PointTypeTo)
                        continue;

                    if (cBaseLink.NodeFrom.Key == cTargetLink.NodeFrom.Key && cBaseLink.NodeTo.Key == cTargetLink.NodeTo.Key)
                    {
                        bExists = true;
                        break;
                    }
                }

                if (bExists)
                {
                    if (cTargetLink.Interval > cBaseLink.Interval)
                        cBaseLink.Interval = cTargetLink.Interval;
                }
                else
                {
                    cBaseFlow.FlowLinkS.Remove(cBaseLink);
                    i--;
                }
            }

            Clear();

            m_cItemS = cBaseFlow.FlowItemS;
            m_cLinkS = cBaseFlow.FlowLinkS;
            m_dtFirst = cBaseFlow.First;
            m_dtLast = cBaseFlow.Last;

            if (m_iFrequency < cBaseFlow.Frequency)
                m_iFrequency = cBaseFlow.Frequency;

        }

        protected void CreateLink(EMLinkPointType emPointFrom, EMLinkPointType emPointTo, double nMinInterval)
        {
            CFlowItem cItemFrom;
            CTimeNode cNodeFrom;
            for (int i = 0; i < m_cItemS.Count; i++)
            {
                cItemFrom = m_cItemS[i];

                if (cItemFrom.TimeNodeS.Count > 0)
                {
                    cNodeFrom = cItemFrom.TimeNodeS[0];
                    CreateLink(cNodeFrom, emPointFrom, emPointTo, nMinInterval);
                }
            }
        }

        protected void CreateLink(CTimeNode cNodeFrom, EMLinkPointType emPointFrom, EMLinkPointType emPointTo, double nMinInterval)
        {
            CFlowLink cLink = null;

            CFlowItem cItemFrom;
            CFlowItem cItemTo;
            CTimeNode cNodeTo = null;
            string sKey = "";
            double ninterval = -1;

            cItemFrom = m_cItemS[cNodeFrom.Key];
            for (int i = 0; i < m_cItemS.Count; i++)
            {
                sKey = m_cItemS[i].Key;
                cItemTo = m_cItemS[i];
                if (sKey == cItemFrom.Key)
                    continue;

                if (cItemFrom.Group != cItemTo.Group)
                    continue;

                if (cItemTo.TimeNodeS.Count > 0)
                {
                    cNodeTo = cItemTo.TimeNodeS[0];

                    ninterval = GetInterval(cNodeFrom, cNodeTo, emPointFrom, emPointTo);
                    if (ninterval >= 0 && ninterval > nMinInterval)
                    {
                        cLink = CreateLink(cNodeFrom, cNodeTo, emPointFrom, emPointTo, ninterval);
                        m_cLinkS.Add(cLink);
                    }
                }
            }
        }

        protected CFlowLink CreateLink(CTimeNode cNodeFrom, CTimeNode cNodeTo, EMLinkPointType emPointFrom, EMLinkPointType emPointTo, double nInterval)
        {
            CFlowLink cLink = new CFlowLink();
            cLink.NodeFrom = cNodeFrom;
            cLink.NodeTo = cNodeTo;
            cLink.PointTypeFrom = emPointFrom;
            cLink.PointTypeTo = emPointTo;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;
            if (emPointFrom == EMLinkPointType.Start)
                dtFrom = cNodeFrom.Start;
            else
                dtFrom = cNodeFrom.End;

            if (emPointTo == EMLinkPointType.Start)
                dtTo = cNodeTo.Start;
            else
                dtTo = cNodeTo.End;

            cLink.Interval = nInterval;

            return cLink;
        }

        protected List<string> GetLinkFromKeyList()
        {
            List<string> lstKey = new List<string>();

            string sKey = "";
            for (int i = 0; i < m_cLinkS.Count; i++)
            {
                sKey = m_cLinkS[i].NodeFrom.Key;
                if (lstKey.Contains(sKey) == false)
                    lstKey.Add(sKey);
            }

            return lstKey;
        }

        protected List<CFlowLink> GetLinkListFromWith(string sKey)
        {
            List<CFlowLink> lstLink = new List<CFlowLink>();

            CFlowLink cLink;
            for (int i = 0; i < m_cLinkS.Count; i++)
            {
                cLink = m_cLinkS[i];
                if (cLink.NodeFrom.Key == sKey)
                    lstLink.Add(cLink);
            }

            return lstLink;
        }

        protected CFlowCompareResultS MappingNodeS(CFlowItemS cSourceItemS, CFlowItemS cTargetItemS, bool bSubItem)
        {
            CFlowCompareResultS cResultS = new CFlowCompareResultS();
            CFlowCompareResult cResult = null;
            CFlowCompareResultUnit cResultUnit = null;

            CFlowItem cSourceItem;
            CFlowItem cTargetItem;
            CTimeNodeS cTargetNodeS;
            CTimeNodeS cSourceNodeS;
            CTimeNode cTargetNode;
            CTimeNode cSourceNode;
            int iNodeCount = 0;

            try
            {
                for (int i = 0; i < cSourceItemS.Count; i++)
                {
                    cSourceItem = cSourceItemS[i];
                    cResult = new CFlowCompareResult(cSourceItem.Key, null);

                    cSourceNodeS = cSourceItemS[i].TimeNodeS;
                    
                    // Pattern Indirect Node Clear
                    for (int j = 0; j < cSourceNodeS.Count; j++)
                        cSourceNodeS[j].Indirect = null;

                    cTargetItem = null;
                    if (cTargetItemS.ContainsKey(cSourceItem.Key))
                    {
                        cTargetItem = cTargetItemS[cSourceItem.Key];
                        cTargetNodeS = cTargetItemS[cSourceItem.Key].TimeNodeS;

                        // Mapping
                        iNodeCount = (cSourceNodeS.Count > cTargetNodeS.Count) ? cTargetNodeS.Count : cSourceNodeS.Count;
                        for (int j = 0; j < iNodeCount; j++)
                        {
                            cSourceNode = cSourceNodeS[j];
                            cTargetNode = cTargetNodeS[j];
                            cSourceNode.Indirect = cTargetNode;
                        }

                        if (cTargetNodeS.Count > cSourceNodeS.Count)
                        {
                            for (int j = iNodeCount; j < cTargetNodeS.Count; j++)
                            {
                                cResultUnit = new CFlowCompareResultUnit(cTargetNodeS[j], EMDifferenceType.OverCount);
                                cResult.Add(cResultUnit);
                            }
                        }
                        else if (cSourceNodeS.Count > cTargetNodeS.Count)
                        {
                            for (int j = iNodeCount; j < cSourceNodeS.Count; j++)
                            {
                                cResultUnit = new CFlowCompareResultUnit(cSourceNodeS[j], EMDifferenceType.Missing);
                                cResult.Add(cResultUnit);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < cSourceNodeS.Count; j++)
                        {
                            cResultUnit = new CFlowCompareResultUnit(cSourceNodeS[j], EMDifferenceType.Missing);
                            cResult.Add(cResultUnit);
                        }
                    }

                    if (bSubItem)
                    {
                        if (cSourceItem.SubFlow != null)
                        {
                            if (cTargetItem == null)
                            {
                                cTargetItem = new CFlowItem();
                                cTargetItem.Key = cSourceItem.Key;
                            }

                            if (cTargetItem.SubFlow == null)
                                cTargetItem.SubFlow = new CFlow();

                            CFlowCompareResultS cSubResultS = MappingNodeS(cSourceItem.SubFlow.FlowItemS, cTargetItem.SubFlow.FlowItemS, bSubItem);
                            cSubResultS.MasterFlow = cSourceItem.SubFlow;
                            cSubResultS.FlowItemS = cTargetItem.SubFlow.FlowItemS;
                            cResult.SubResultS = cSubResultS;
                        }
                    }

                    cResultS.Add(cResult);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cResultS;
        }

        protected bool CheckSameStructure(CFlow cFlow)
        {
            if (m_cItemS.Count != cFlow.FlowItemS.Count)
                return false;

            bool bOK = true;

            // Check Appearance
            string sKey;
            CFlowItem cThisItem;
            CFlowItem cThatItem;
            for (int i = 0; i < m_cItemS.Count; i++)
            {
                sKey = m_cItemS[i].Key;
                cThisItem = m_cItemS[i];

                if (cFlow.FlowItemS.ContainsKey(sKey))
                {
                    cThatItem = cFlow.FlowItemS[sKey];
                    if (cThisItem.TimeNodeS.Count != cThatItem.TimeNodeS.Count)
                    {
                        bOK = false;
                        break;
                    }
                }
                else
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        protected double GetInterval(CTimeNode cNodeFrom, CTimeNode cNodeTo, EMLinkPointType emPointTypeFrom, EMLinkPointType emPointTypeTo)
        {
            double nInterval = -1;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;

            if (emPointTypeFrom == EMLinkPointType.Start)
                dtFrom = cNodeFrom.Start;
            else
                dtFrom = cNodeFrom.End;

            if (emPointTypeTo == EMLinkPointType.Start)
                dtTo = cNodeTo.Start;
            else
                dtTo = cNodeTo.End;

            if (dtFrom >= dtTo)
                return nInterval;

            nInterval = dtTo.Subtract(dtFrom).TotalMilliseconds;

            return nInterval;
        }

        #endregion
    }
}
