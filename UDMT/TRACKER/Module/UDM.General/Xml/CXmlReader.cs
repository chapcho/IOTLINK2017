using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace UDM.General.Xml
{
    public class CXmlReader : IXmlIO
    {

        #region Member Variables

        private XmlTextReader m_xmlReader = null;
        private bool m_bReadable = false;
        private bool m_bEOF = false;
        private EMFileState m_emState = EMFileState.Closed;

        #endregion


        #region Initialize/Dispose

        public CXmlReader()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        public bool EOF
        {
            get { return m_bEOF; }
        }

        public EMFileState FileState
        {
            get { return m_emState; }
        }

        #endregion


        #region Public Methods
        
        public bool Open(string sPath)
        {
            bool bOK = true;

            Close();
            
            try
            {
                if (File.Exists(sPath) == false)
                    return false;

                m_xmlReader = new XmlTextReader(sPath);
                m_xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                m_bReadable = true;
                m_emState = EMFileState.Opened;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }
            
            return bOK;
        }

        public bool Close()
        {
            bool bOK = true;

            m_bReadable = false;
            m_bEOF = false;

            try
            {
                if (m_xmlReader != null)
                {
                    m_xmlReader.Close();
                    m_xmlReader = null;
                }

                m_emState = EMFileState.Closed;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public CXmlElement Read()
        {
            if (m_bReadable == false)
                return null;

            CXmlElement cData = null;

            try
            {
                bool bOK = m_xmlReader.Read();
                if (bOK)
                {
                    cData = new CXmlElement(m_xmlReader.LocalName, m_xmlReader.NodeType);
                    cData.IsEmpty = m_xmlReader.IsEmptyElement;
                    if (m_xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (m_xmlReader.AttributeCount > 0)
                        {
                            m_xmlReader.MoveToFirstAttribute();
                            for (int i = 0; i < m_xmlReader.AttributeCount; i++)
                            {
                                cData.Add(m_xmlReader.Name, m_xmlReader.Value);
                                m_xmlReader.MoveToNextAttribute();
                            }
                        }
                    }
                }
                else
                {
                    m_bEOF = true;
                    m_bReadable = false;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                cData = null;
            }

            return cData;
        }


        #endregion


        #region Private Methods


        #endregion
    }
}
