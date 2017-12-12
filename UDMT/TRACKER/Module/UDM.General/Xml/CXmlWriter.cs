using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace UDM.General.Xml
{
    public class CXmlWriter : IDisposable
    {

        #region Member Variables

        private XmlTextWriter m_xmlWriter = null;
        private bool m_bWritable = false;
        private EMFileState m_emState = EMFileState.Closed;

        #endregion


        #region Initialize/Dispose

        public CXmlWriter()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

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
                m_xmlWriter = new XmlTextWriter(sPath, Encoding.UTF8);
                m_xmlWriter.Formatting = Formatting.Indented;
                m_xmlWriter.Indentation = 4;
                m_bWritable = true;
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

            m_bWritable = false;

            try
            {
                if (m_xmlWriter != null)
                {
                    m_xmlWriter.Close();
                    m_xmlWriter = null;
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


        public void WriteStart(CXmlElement cHeader)
        {
            if (m_bWritable == false || cHeader == null || cHeader.Name == "")
                return;

            try
            {
                m_xmlWriter.WriteStartDocument();
                WriteElement(cHeader);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void WriteEnd()
        {
            if (m_bWritable == false)
                return;

            try
            {
                m_xmlWriter.WriteEndDocument();
                m_bWritable = false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void WriteElement(string sValue)
        {
            if (m_bWritable == false || sValue == "")
                return;

            m_xmlWriter.WriteStartElement(sValue);
        }

        public void WriteElement(CXmlElement cData)
        {
            if (m_bWritable == false || cData == null || cData.Name == "")
                return;

            try
            {
                m_xmlWriter.WriteStartElement(cData.Name);

                string sName;
                string sValue;
                for (int i = 0; i < cData.Count; i++)
                {
                    sName = cData.GetAttributeName(i);
                    sValue = cData.GetValue(i);

                    m_xmlWriter.WriteAttributeString(sName, sValue);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void WriteEndElement()
        {
            if (m_bWritable == false)
                return;

            try
            {
                m_xmlWriter.WriteEndElement();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
