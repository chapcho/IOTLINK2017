using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowItem : CObject, ICloneable
    {

        #region Member Variables

        protected string m_sGroup = "";
        protected string m_sDescription = "";
        protected DateTime m_dtFirst = CMasterTime.BaseTime;
        protected DateTime m_dtLast = CMasterTime.BaseTime.AddMinutes(1);        
        protected CTimeNodeS m_cNodeS = new CTimeNodeS();
        protected CFlow m_cSubFlow = null;
        protected object m_oData = null;
        protected bool m_bManualAdd = false;
        protected bool m_bRecipeElement = false;
        protected bool m_bConditionElement = false;

        #endregion


        #region Initialize/Dispose

        public CFlowItem()
        {

        }

        public new void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public bool RecipeElement
        {
            get { return m_bRecipeElement;}
            set { m_bRecipeElement = value; }
        }

        public bool ConditionElement
        {
            get { return m_bConditionElement;}
            set { m_bConditionElement = value; }
        }

        public bool IsManualAdd
        {
            get { return m_bManualAdd;}
            set { m_bManualAdd = value; }
        }

        public string Group
        {
            get { return m_sGroup; }
            set { m_sGroup = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public CTimeNodeS TimeNodeS
        {
            get { return m_cNodeS; }
            set { m_cNodeS = value; }
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

        public CFlow SubFlow
        {
            get { return m_cSubFlow; }
            set { m_cSubFlow = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        #endregion


        #region Public Methods

        public CTimeNode GetNode(DateTime dtStart)
        {
            CTimeNode cNode = null;
            CTimeNode cNodeTemp;
            for (int i = 0; i < m_cNodeS.Count; i++)
            {
                cNodeTemp = m_cNodeS[i];
                if (cNodeTemp.Start == dtStart)
                {
                    cNode = cNodeTemp;
                    break;
                }
            }

            return cNode;
        }

        public CTimeNode GetNode(int iIndex)
        {
            CTimeNode cNode = m_cNodeS[iIndex];

            return cNode;
        }

        public int GetNodeIndex(CTimeNode cNode)
        {
            int iIndex = -1;

            CTimeNode cNodeTemp;
            for (int i = 0; i < m_cNodeS.Count; i++)
            {
                cNodeTemp = m_cNodeS[i];
                if (cNode == cNodeTemp)
                {
                    iIndex = i;
                    break;
                }
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
            m_dtFirst = m_dtFirst.Add(tsOffSet);
            m_dtLast = m_dtLast.Add(tsOffSet);

            if (m_cNodeS != null)
                m_cNodeS.Normalize(tsOffSet);

            if(m_cSubFlow != null)
                m_cSubFlow.Normalize(tsOffSet);
        }

        public void Clear()
        {
            if (m_cNodeS != null)
                m_cNodeS.Clear();
        }

        public object Clone()
        {
            CFlowItem cItemClone = new CFlowItem();
            cItemClone.Key = m_sKey;
            cItemClone.TimeNodeS = (CTimeNodeS)m_cNodeS.Clone();
            cItemClone.Description = m_sDescription;
            cItemClone.Data = m_oData;

            if (m_cSubFlow != null)
                cItemClone.SubFlow = (CFlow)m_cSubFlow.Clone();

            return cItemClone;
        }

        #endregion


        #region Private Methods

        
        #endregion
    }
}
