using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDLUDT
    {
        protected List<CUDLTag> m_lstMemTag = null;
        protected string m_sUDTName = string.Empty;
        protected int m_sUDTLength = 0;

        #region Intialize/Dispose
        public CUDLUDT(string udtName)
        {
            m_sUDTName = udtName;
            m_lstMemTag = new List<CUDLTag>();
        }
        public CUDLUDT()
        {
            m_lstMemTag = new List<CUDLTag>();
        }
        #endregion

        #region Public Properties

        public string UDTName
        {
            get { return m_sUDTName; }
            set { m_sUDTName = value; }
        }

        public int UDTLength
        {
            get { return m_sUDTLength; }
            set { m_sUDTLength = value; }
        }
        public List<CUDLTag> MemTags
        {
            get { return m_lstMemTag; }
            set { m_lstMemTag = value; }
        }
        #endregion

        #region Public Methods

        public List<string> GetStringUDT()
        {
            List<string> FullFile = new List<string>();
            try
            {
                FullFile.Add("UDT  " + m_sUDTName);
                int iCount = m_lstMemTag.Count;

                FullFile.Add("LOCAL_TAGS");

                string sTemp = string.Empty;

                for (int i = 0; i < iCount; i++)
                {
                    sTemp = m_lstMemTag[i].GetLocalTag();
                    FullFile.Add(sTemp);
                }

                FullFile.Add("END_LOCAL_TAGS");

                FullFile.Add("END_UDT");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return FullFile;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
