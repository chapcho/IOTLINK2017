using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDMIOMaker;

namespace UDMIOMaker
{
    [Serializable]
    public class CStdTag
    {
        private string m_sKey = string.Empty;
        private string m_sCurrentDesc = string.Empty;
        private string m_sTargetDesc = string.Empty;
        private string m_sAddress = string.Empty;

        private bool m_bStandardization = false;

        private CLevel m_cLv1 = new CLevel();
        private CLevel m_cLv2 = new CLevel();
        private CLevel m_cLv3 = new CLevel();
        private CLevel m_cLv4 = new CLevel();
        private CLevel m_cLv5 = new CLevel();
        private CLevel m_cLv6 = new CLevel();
        private CLevel m_cLv7 = new CLevel();
        private CLevel m_cLv8 = new CLevel();
        private CLevel m_cLv9 = new CLevel();
        private CLevel m_cLv10 = new CLevel();

        private List<CLevel> m_lstContainLevel = new List<CLevel>();

        #region Initialize/Dispose

        public CStdTag()
        {
            m_lstContainLevel.Add(m_cLv1);
            m_lstContainLevel.Add(m_cLv2);
            m_lstContainLevel.Add(m_cLv3);
            m_lstContainLevel.Add(m_cLv4);
            m_lstContainLevel.Add(m_cLv5);
            m_lstContainLevel.Add(m_cLv6);
            m_lstContainLevel.Add(m_cLv7);
            m_lstContainLevel.Add(m_cLv8);
            m_lstContainLevel.Add(m_cLv9);
            m_lstContainLevel.Add(m_cLv10);
        }

        #endregion

        #region Properties

        public bool IsStdLNotExist
        {
            get { return CheckStdLNotExist(); }
        }

        public bool IsStandardization
        {
            get { return CheckStandardization(); }
        }

        public List<CLevel> LevelS
        {
            get { return m_lstContainLevel;}  
        }

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public bool IsStandard
        {
            get { return m_bStandardization; }
            set { m_bStandardization = value; }
        }

        public string CurrentDesc
        {
            get { return m_sCurrentDesc;}
            set { m_sCurrentDesc = value; }
        }

        public string TargetDesc
        {
            get { return m_sTargetDesc;}
            set { m_sTargetDesc = value; }
        }

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Lv1Name
        {
            get { return GetLv1Name(); }
            set { SetLv1Name(value); }
        }

        public string Lv2Name
        {
            get { return GetLv2Name(); }
            set { SetLv2Name(value); }
        }

        public string Lv3Name
        {
            get { return GetLv3Name(); }
            set { SetLv3Name(value); }
        }

        public string Lv4Name
        {
            get { return GetLv4Name(); }
            set { SetLv4Name(value); }
        }

        public string Lv5Name
        {
            get { return GetLv5Name(); }
            set { SetLv5Name(value); }
        }

        public string Lv6Name
        {
            get { return GetLv6Name(); }
            set { SetLv6Name(value); }
        }

        public string Lv7Name
        {
            get { return GetLv7Name(); }
            set { SetLv7Name(value); }
        }

        public string Lv8Name
        {
            get { return GetLv8Name(); }
            set { SetLv8Name(value); }
        }

        public string Lv9Name
        {
            get { return GetLv9Name(); }
            set { SetLv9Name(value); }
        }

        public string Lv10Name
        {
            get { return GetLv10Name(); }
            set { SetLv10Name(value); }
        }

        public CLevel Lv1
        {
            get { return m_cLv1;}
            set { m_cLv1 = value; }
        }

        public CLevel Lv2
        {
            get { return m_cLv2; }
            set { m_cLv2 = value; }
        }

        public CLevel Lv3
        {
            get { return m_cLv3; }
            set { m_cLv3 = value; }
        }

        public CLevel Lv4
        {
            get { return m_cLv4; }
            set { m_cLv4 = value; }
        }

        public CLevel Lv5
        {
            get { return m_cLv5; }
            set { m_cLv5 = value; }
        }

        public CLevel Lv6
        {
            get { return m_cLv6; }
            set { m_cLv6 = value; }
        }

        public CLevel Lv7
        {
            get { return m_cLv7; }
            set { m_cLv7 = value; }
        }

        public CLevel Lv8
        {
            get { return m_cLv8; }
            set { m_cLv8 = value; }
        }

        public CLevel Lv9
        {
            get { return m_cLv9; }
            set { m_cLv9 = value; }
        }

        public CLevel Lv10
        {
            get { return m_cLv10; }
            set { m_cLv10 = value; }
        }


        #endregion

        public CLevel GetLevel(int iIndex)
        {
            CLevel cLv = null;

            switch (iIndex)
            {
                case 1: cLv = m_cLv1; break;
                case 2: cLv = m_cLv2; break;
                case 3: cLv = m_cLv3; break;
                case 4: cLv = m_cLv4; break;
                case 5: cLv = m_cLv5; break;
                case 6: cLv = m_cLv6; break;
                case 7: cLv = m_cLv7; break;
                case 8: cLv = m_cLv8; break;
                case 9: cLv = m_cLv9; break;
                case 10: cLv = m_cLv10; break;
            }

            return cLv;
        }


        #region Private Methods

        private bool CheckStandardization()
        {
            bool bOK = false;

            foreach (var who in m_lstContainLevel)
            {
                if (who.CurrentParse != string.Empty && who.IsChanged)
                {
                    bOK = true;
                    break;
                }
                else bOK = false;
            }

            return bOK;
        }

        private bool CheckStdLNotExist()
        {
            bool bOK = false;

            foreach (var who in m_lstContainLevel)
            {
                if (who.CurrentParse != string.Empty && !who.IsStdExist)
                {
                    bOK = true;
                    break;
                }
                else
                    bOK = false;
            }

            return bOK;
        }

        private string GetLv1Name()
        {
            string sName = string.Empty;

            if (m_cLv1 == null)
                return string.Empty;

            if (m_cLv1.IsCurrentView)
                sName = m_cLv1.CurrentParse;
            else
                sName = m_cLv1.TargetParse;

            return sName;
        }

        private string GetLv2Name()
        {
            string sName = string.Empty;

            if (m_cLv2 == null)
                return string.Empty;

            if (m_cLv2.IsCurrentView)
                sName = m_cLv2.CurrentParse;
            else
                sName = m_cLv2.TargetParse;

            return sName;
        }

        private string GetLv3Name()
        {
            string sName = string.Empty;

            if (m_cLv3 == null)
                return string.Empty;

            if (m_cLv3.IsCurrentView)
                sName = m_cLv3.CurrentParse;
            else
                sName = m_cLv3.TargetParse;

            return sName;
        }

        private string GetLv4Name()
        {
            string sName = string.Empty;

            if (m_cLv4 == null)
                return string.Empty;

            if (m_cLv4.IsCurrentView)
                sName = m_cLv4.CurrentParse;
            else
                sName = m_cLv4.TargetParse;

            return sName;
        }

        private string GetLv5Name()
        {
            string sName = string.Empty;

            if (m_cLv5 == null)
                return string.Empty;

            if (m_cLv5.IsCurrentView)
                sName = m_cLv5.CurrentParse;
            else
                sName = m_cLv5.TargetParse;

            return sName;
        }

        private string GetLv6Name()
        {
            string sName = string.Empty;

            if (m_cLv6 == null)
                return string.Empty;

            if (m_cLv6.IsCurrentView)
                sName = m_cLv6.CurrentParse;
            else
                sName = m_cLv6.TargetParse;

            return sName;
        }

        private string GetLv7Name()
        {
            string sName = string.Empty;

            if (m_cLv7 == null)
                return string.Empty;

            if (m_cLv7.IsCurrentView)
                sName = m_cLv7.CurrentParse;
            else
                sName = m_cLv7.TargetParse;

            return sName;
        }

        private string GetLv8Name()
        {
            string sName = string.Empty;

            if (m_cLv8 == null)
                return string.Empty;

            if (m_cLv8.IsCurrentView)
                sName = m_cLv8.CurrentParse;
            else
                sName = m_cLv8.TargetParse;

            return sName;
        }

        private string GetLv9Name()
        {
            string sName = string.Empty;

            if (m_cLv9 == null)
                return string.Empty;

            if (m_cLv9.IsCurrentView)
                sName = m_cLv9.CurrentParse;
            else
                sName = m_cLv9.TargetParse;

            return sName;
        }

        private string GetLv10Name()
        {
            string sName = string.Empty;

            if (m_cLv10 == null)
                return string.Empty;

            if (m_cLv10.IsCurrentView)
                sName = m_cLv10.CurrentParse;
            else
                sName = m_cLv10.TargetParse;

            return sName;
        }

        private void SetLv1Name(string sName)
        {
            if (m_cLv1 != null)
            {
                m_cLv1.Clear();
                m_cLv1.CurrentParse = sName;
            }
        }

        private void SetLv2Name(string sName)
        {
            if (m_cLv2 != null)
            {
                m_cLv2.Clear();
                m_cLv2.CurrentParse = sName;
            }
        }

        private void SetLv3Name(string sName)
        {
            if (m_cLv3 != null)
            {
                m_cLv3.Clear();
                m_cLv3.CurrentParse = sName;
            }
        }

        private void SetLv4Name(string sName)
        {
            if (m_cLv4 != null)
            {
                m_cLv4.Clear();
                m_cLv4.CurrentParse = sName;
            }
        }

        private void SetLv5Name(string sName)
        {
            if (m_cLv5 != null)
            {
                m_cLv5.Clear();
                m_cLv5.CurrentParse = sName;
            }
        }

        private void SetLv6Name(string sName)
        {
            if (m_cLv6 != null)
            {
                m_cLv6.Clear();
                m_cLv6.CurrentParse = sName;
            }
        }

        private void SetLv7Name(string sName)
        {
            if (m_cLv7 != null)
            {
                m_cLv7.Clear();
                m_cLv7.CurrentParse = sName;
            }
        }

        private void SetLv8Name(string sName)
        {
            if (m_cLv8 != null)
            {
                m_cLv8.Clear();
                m_cLv8.CurrentParse = sName;
            }
        }

        private void SetLv9Name(string sName)
        {
            if (m_cLv9 != null)
            {
                m_cLv9.Clear();
                m_cLv9.CurrentParse = sName;
            }
        }

        private void SetLv10Name(string sName)
        {
            if (m_cLv10 != null)
            {
                m_cLv10.Clear();
                m_cLv10.CurrentParse = sName;
            }
        }




        #endregion

        public void ClearLevel()
        {
            foreach(var who in m_lstContainLevel)
                who.Clear();
        }

    }
}
