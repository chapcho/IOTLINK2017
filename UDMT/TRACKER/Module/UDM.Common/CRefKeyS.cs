using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CRefKeyS<T>
    {

        #region Member Variables

        protected List<string> m_lstKey = new List<string>();

        [NonSerialized]
        protected Dictionary<string, T> m_lstObject = null;
        
        #endregion


        #region Initialize/Dispose

        public CRefKeyS()
        {
            m_lstObject = new Dictionary<string, T>();
        }

        #endregion


        #region Public Properties

        public List<string> KeyList
        {
            get { return m_lstKey; }
            set { m_lstKey = value; }
        }

        public int Count
        {
            get { return m_lstObject.Count; }
        }

        public T this[string sValue]
        {
            get { return GetValue(sValue); }
        }

        public T this[int iIndex]
        {
            get {return GetValueAt(iIndex);}
        }

        #endregion


        #region Pubilc Methods

        public bool ContainsKey(string sKey)
        {
            return m_lstObject.ContainsKey(sKey);
        }

        public void Add(string sKey, T oValue)
        {
            if (m_lstObject.ContainsKey(sKey) == false)
            {   
                m_lstObject.Add(sKey, oValue);
                m_lstKey.Add(sKey);
            }
        }

        public void Remove(string sKey)
        {
            if (m_lstObject.ContainsKey(sKey))
            {
                m_lstObject.Remove(sKey);
                m_lstKey.Remove(sKey);
            }
        }

        public void RemoveAt(int iIndex)
        {
            string sKey = m_lstObject.ElementAt(iIndex).Key;
            Remove(sKey);
        }

        public string GetKeyAt(int iIndex)
        {
            return m_lstObject.ElementAt(iIndex).Key;
        }

        public T GetValueAt(int iIndex)
        {
            return m_lstObject.ElementAt(iIndex).Value;
        }

        public T GetValue(string sKey)
        {
            return m_lstObject[sKey];
        }

        public void Clear()
        {
            m_lstKey.Clear();
            m_lstObject.Clear();
        }

        public void Compose(Dictionary<string, T> lstTotal)
        {
            if (m_lstObject != null)
                m_lstObject.Clear();
            else
                m_lstObject = new Dictionary<string, T>();
            
            string sKey = "";
            T oValue;
            for(int i=0;i<m_lstKey.Count;i++)
            {
                sKey = m_lstKey[i];
                if (lstTotal.ContainsKey(sKey))
                {
                    oValue = lstTotal[sKey];
                    m_lstObject.Add(sKey, oValue);
                }
            }
        }

        public void Compose(CRefKeyS<T> lstTotal)
        {
            if (m_lstObject != null)
                m_lstObject.Clear();
            else
                m_lstObject = new Dictionary<string, T>();
            

            string sKey = "";
            T oValue;
            for (int i = 0; i < m_lstKey.Count; i++)
            {
                sKey = m_lstKey[i];
                if (lstTotal.ContainsKey(sKey))
                {
                    oValue = lstTotal.GetValue(sKey);
                    m_lstObject.Add(sKey, oValue);
                }
            }
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
