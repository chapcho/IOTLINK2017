using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CTagItem : IDisposable
    {
        #region Member Variables

        protected bool m_bVisible = false;
        protected CTag m_cTag = null;
        protected CTimeLogS m_cLogS = new CTimeLogS();

        #endregion


        #region Initialize/Dispose

        public CTagItem()
        {

        }

        public CTagItem(CTag cTag)
        {
            m_cTag = cTag;
        }

        public void Dispose()
        {
            if (m_cLogS != null)
                m_cLogS.Clear();
        }

        #endregion


        #region Public Properties

        public bool IsVisible
        {
            get { return m_bVisible; }
            set { m_bVisible = value; }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }


        public string Key
        {
            get { return m_cTag.Key;}
        }

        public string Address
        {
            get { return m_cTag.Address; }
        }

        public string Description
        {
            get { return m_cTag.Description; }
        }

        public CTimeLogS LogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }

        public int LogCount
        {
            get { return m_cLogS.Count; }
        }

        #endregion


        #region Public Methods

        public void UpdateLogKey()
        {
            foreach (CTimeLog cLog in m_cLogS)
                cLog.Key = m_cTag.Key;
        }

        #endregion


        #region Private Methods
        

        #endregion
    }
}
