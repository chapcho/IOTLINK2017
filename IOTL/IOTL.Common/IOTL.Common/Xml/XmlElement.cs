using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace IOTL.Common.Xml
{
    public class XmlElement
    {

        #region Member Variables

        private string m_sName = string.Empty;
        private XmlNodeType m_emNodeType = XmlNodeType.Element;
        private Dictionary<string, string> m_lstAttribute = null;
        private bool m_bEmpty = true;

        #endregion


        #region Initialize/Dispose

        public XmlElement(string sName)
        {
            m_sName = sName;
        }

        public XmlElement(string sName, XmlNodeType emNodeType)
        {
            m_sName = sName;
            m_emNodeType = emNodeType;
        }

        public void Dispose()
        {
            if (m_lstAttribute != null)
                m_lstAttribute.Clear();
        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set {m_sName = value;}
        }

        public XmlNodeType NodeType
        {
            get {return m_emNodeType;}
            set {m_emNodeType = value;}
        }

        public bool IsEmpty
        {
            get { return m_bEmpty; }
            set { m_bEmpty = value; }
        }

        public int Count
        {
            get
            {
                if (m_lstAttribute == null)
                    return 0;
                else
                    return m_lstAttribute.Count;
            }
        }

        #endregion


        #region Public Methods

        public bool Add(string sAtrributeName, string sValue)
        {
            bool bOK = true;
            
            try
            {
                if (m_lstAttribute == null)
                    m_lstAttribute = new Dictionary<string, string>();

                m_lstAttribute.Add(sAtrributeName, sValue);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public string GetAttributeName(int iIndex)
        {
            if (m_lstAttribute == null || m_lstAttribute.Count <= iIndex)
                return string.Empty;

            string sAttr = m_lstAttribute.ElementAt(iIndex).Key;
            return sAttr;
        }

        public string GetValue(int iIndex)
        {
            if (m_lstAttribute == null || m_lstAttribute.Count <= iIndex)
                return string.Empty;

            string sValue = m_lstAttribute.ElementAt(iIndex).Value;
            return sValue;
        }

        public string GetValue(string sAtrributeName)
        {
            if (m_lstAttribute == null || m_lstAttribute.ContainsKey(sAtrributeName) == false)
                return string.Empty;

            string sValue = m_lstAttribute[sAtrributeName];
            return sValue;
        }


        public object GetValue(int iIndex, Type t)
        {
            string sValue = GetValue(iIndex);
            if (sValue == "")
                return null;

            object oValue = GetObject(sValue, t);

            return oValue;
        }

        public object GetValue(string sAtrributeName, Type t)
        {
            string sValue = GetValue(sAtrributeName);
            if (sValue == "")
                return null;

            object oValue = GetObject(sValue, t);

            return oValue;
        }

        public void Clear()
        {
            if (m_lstAttribute != null)
                m_lstAttribute.Clear();
        }

        #endregion


        #region Private Methods

        private object GetObject(string sValue, Type t)
        {
            object oValue = null;

            if (t == typeof(bool))
                oValue = TypeConverter.ToBool(sValue);
            else if (t == typeof(int))
                oValue = TypeConverter.ToInteger(sValue);
            else if (t == typeof(Color))
                oValue = TypeConverter.ToColor(sValue);
            else if (t == typeof(DateTime))
                oValue = TypeConverter.ToDateTime(sValue);
            else if (t.BaseType == typeof(Enum))
                oValue = TypeConverter.ToEnum(t, sValue);            
            else
                oValue = sValue;

            return oValue;
        }

        #endregion
    }
}
