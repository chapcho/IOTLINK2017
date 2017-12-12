using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using UDM.Common;
using UDM.Log;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CMeterUnit : IDisposable
    {
        #region Member Variables

        protected bool m_bVisible = false;
        protected string m_sParent = "";
        protected string m_sKey = "";
        protected CTimeLogS m_cLogS = new CTimeLogS();
        protected Color m_cColor = Color.DodgerBlue;

        #endregion


        #region Initialize/Dispose

        public CMeterUnit()
        {

        }

        public CMeterUnit(string sParent, string sKey)
        {
            m_sParent = sParent;
            m_sKey = sKey;
        }


        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties
        
        public bool IsVisible
        {
            get { return m_bVisible; }
            set { m_bVisible = value; }
        }

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string Parent
        {
            get { return m_sParent; }
            set { m_sParent = value; }
        }

        public CTimeLogS LogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }

        public Color Color
        {
            get { return m_cColor; }
            set { m_cColor = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            if (m_cLogS != null)
                m_cLogS.Clear();
        }

        public void UpdateLogKey()
        {
            foreach(CTimeLog cLog in m_cLogS)
                cLog.Key = Key;
        }

        #endregion


        #region Private Methods
        

        #endregion
    }
}
