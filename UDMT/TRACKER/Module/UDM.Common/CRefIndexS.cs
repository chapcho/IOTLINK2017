using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CRefIndexS<T>
    {

        #region Member Variables

        protected List<int> m_lstIndex = new List<int>();

        [NonSerialized]
        protected Dictionary<int, T> m_lstObject = new Dictionary<int, T>();
        
        #endregion


        #region Initialize/Dispose

        public CRefIndexS()
        {
            m_lstObject = new Dictionary<int, T>();
        }

        #endregion


        #region Public Properties

        public List<int> IndexList
        {
            get { return m_lstIndex; }
            set { m_lstIndex = value; }
        }

        public int Count
        {
            get { return m_lstObject.Count; }
        }

        public T this[int iIndex]
        {
            get { return m_lstObject[iIndex]; }
        }

        #endregion


        #region Pubilc Methods

        public bool ContainsKey(int iIndex)
        {
            return m_lstObject.ContainsKey(iIndex);
        }

        public void Add(int iIndex, T oValue)
        {
            if (m_lstObject.ContainsKey(iIndex) == false)
            {
                m_lstObject.Add(iIndex, oValue);
                m_lstIndex.Add(iIndex);
            }
        }

        public int GetIndexAt(int iOrder)
        {
            return m_lstObject.ElementAt(iOrder).Key;
        }

        public T GetValueAt(int iOrder)
        {
            return m_lstObject.ElementAt(iOrder).Value;
        }

        public T GetValue(int iIndex)
        {
            return m_lstObject[iIndex];
        }

        public void Remove(int iIndex)
        {
            if (m_lstObject.ContainsKey(iIndex))
            {
                m_lstObject.Remove(iIndex);
                m_lstIndex.Remove(iIndex);
            }
        }

        public void RemoveAt(int iOrder)
        {
            int iIndex = m_lstObject.ElementAt(iOrder).Key;
            Remove(iIndex);
        }

        public void Clear()
        {
            m_lstIndex.Clear();
            m_lstObject.Clear();
        }

        public void Compose(List<T> lstTotal)
        {
            m_lstObject.Clear();

            int iIndex = -1;
            T oValue;
            for (int i = 0; i < m_lstIndex.Count; i++)
            {
                iIndex = m_lstIndex[i];
                oValue = lstTotal[iIndex];
                m_lstObject.Add(iIndex, oValue);
            }
        }

        public void Compose(CRefIndexS<T> lstTotal)
        {
            m_lstObject.Clear();

            int iIndex = -1;
            T oValue;
            for (int i = 0; i < m_lstIndex.Count; i++)
            {
                iIndex = m_lstIndex[i];
                oValue = lstTotal.GetValue(iIndex);
                m_lstObject.Add(iIndex, oValue);
            }
        }

        #endregion
    }
}
