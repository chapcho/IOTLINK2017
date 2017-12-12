using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UDM.DDEA
{
    [Serializable]
    public class CDDEAConfigMS : ICloneable
    {
        #region Member Veriables

        protected CUSB m_cUSB = new CUSB();
        protected CMNet m_cMNet = new CMNet();
        protected CENet m_cEnet = new CENet();
        protected CGXSim m_cGxSim = new CGXSim();
        protected EMConnectTypeMS m_emSelectedItem = EMConnectTypeMS.None;
        protected CGOT m_cGOT = new CGOT();

        protected const string REGBASE = @"Software\UDMtek\DDEA_Setting";
        protected string m_sPlcSetRegPath = "";
        protected int m_iMxCom4Selected = -1;
        protected bool m_bFindReg = false;
        protected EMPlcConnettionType m_emConnectionType = EMPlcConnettionType.Melsec_Normal;
        protected Dictionary<int, CMxCom4> m_dicMxCom4 = null;

        #endregion


        #region Initialize

        public CDDEAConfigMS(EMPlcConnettionType emType = EMPlcConnettionType.Melsec_Normal)
        {
            m_emConnectionType = emType;
            if (emType == EMPlcConnettionType.Melsec_RSeries)
                CreateMxCom4();
            else
            {
                if (m_dicMxCom4 != null && m_dicMxCom4.Count > 0) m_dicMxCom4.Clear();
            }
        }

        #endregion


        #region Properties
        
        public EMConnectTypeMS SelectedItem
        {
            get { return m_emSelectedItem; }
            set { m_emSelectedItem = value; }
        }

        public CUSB USB
        {
            get { return m_cUSB; }
            set { m_cUSB = value; }
        }

        public CMNet MNet
        {
            get { return m_cMNet; }
            set { m_cMNet = value; }
        }

        public CENet ENet
        {
            get { return m_cEnet; }
            set { m_cEnet = value; }
        }

        public CGXSim GxSim
        {
            get { return m_cGxSim; }
            set { m_cGxSim = value; }
        }

        public CGOT GOT
        {
            get { return m_cGOT; }
            set { m_cGOT = value; }
        }

        public int MxCom4SelectedIndex
        {
            get { return m_iMxCom4Selected; }
            set { m_iMxCom4Selected = value; }
        }

        public Dictionary<int, CMxCom4> MxCom4SettingList
        {
            get { return m_dicMxCom4; }
            set { m_dicMxCom4 = value; }
        }

        public EMPlcConnettionType MelsecCpuType
        {
            get { return m_emConnectionType; }
            set { m_emConnectionType = value; }
        }

        #endregion


        #region Private Method

        private void SearchSubKeys(RegistryKey root, String searchKey)
        {
            foreach (string keyname in root.GetSubKeyNames())
            {
                try
                {
                    using (RegistryKey key = root.OpenSubKey(keyname))
                    {
                        if (keyname == searchKey)
                        {
                            m_sPlcSetRegPath = key.Name;
                            m_bFindReg = true;
                            return;
                        }

                        SearchSubKeys(key, searchKey);
                    }
                }
                catch (System.Security.SecurityException)
                {
                    Console.WriteLine("Registry찾기 실패");
                }
            }
        }

        public bool CheckMxComponentVer()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(REGBASE, true);
            string sWizSet = "MXComponentSetting";
            if (regKey == null)
            {
                m_bFindReg = true;
                m_sPlcSetRegPath = @"SOFTWARE\MITSUBISHI\SWnD5-ACT\COMMUTL";
                regKey = Registry.LocalMachine.OpenSubKey(m_sPlcSetRegPath);
                if (regKey == null)
                    return false;
                string sFindString = "COMMUTL";

                //SearchSubKeys(regKey, sFindString);
                if (m_bFindReg == false)
                {
                    return false;
                }
                else
                {
                    //한번더 체크 버전이 맞는지!!
                    string sBuff = m_sPlcSetRegPath.Replace(sFindString, "CurrentVersion");
                    sBuff = sBuff.Replace("HKEY_LOCAL_MACHINE\\", "");
                    regKey = Registry.LocalMachine.OpenSubKey(sBuff);

                    if (regKey == null)
                    {
                        return false;
                    }
                    else
                    {
                        int iVer = (int)regKey.GetValue("MajorVersion");
                        string sMinorVer = (string)regKey.GetValue("MinorVersion");
                        string sMinorVerBuf = Regex.Replace(sMinorVer, @"\D", "");
                        int iMinor = int.Parse(sMinorVerBuf);

                        if (iVer < 4 || iMinor < 10)
                        {
                            System.Windows.Forms.MessageBox.Show(string.Format("MX Component 버전이 맞지 않습니다.\r\n 현재 설치된 버전 {0}.{1}", iVer, iMinor));
                            return false;
                        }
                    }
                    regKey = Registry.LocalMachine.CreateSubKey(REGBASE);
                    m_sPlcSetRegPath = m_sPlcSetRegPath.Replace("HKEY_LOCAL_MACHINE\\", "");
                    regKey.SetValue(sWizSet, m_sPlcSetRegPath);
                }
            }
            else
            {
                m_sPlcSetRegPath = (string)regKey.GetValue(sWizSet);
            }

            regKey = Registry.LocalMachine.OpenSubKey(m_sPlcSetRegPath);
            if (regKey != null && m_bFindReg == false)
                m_bFindReg = true;

            bool bFirst = true;
            if (m_bFindReg)
            {
                int iRegCount = regKey.GetSubKeyNames().Length;
                foreach (string keyname in regKey.GetSubKeyNames())
                {
                    string[] sSplit = keyname.Split('_');
                    int iStationNum = -1;
                    bool bOK = int.TryParse(sSplit[sSplit.Length - 1], out iStationNum);
                    if (bOK)
                    {
                        CMxCom4 cPlcInfo = new CMxCom4();
                        cPlcInfo.ConnectionNumber = iStationNum;
                        cPlcInfo.RegistryPath = m_sPlcSetRegPath + "\\" + keyname;
                        cPlcInfo.Name = keyname;
                        if (bFirst)
                        {
                            m_iMxCom4Selected = iStationNum;
                            bFirst = false;
                        }
                        cPlcInfo.SetDetailInfo();
                        m_dicMxCom4.Add(iStationNum, cPlcInfo);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        #endregion


        #region Public Method

        /// <summary>
        /// Registry에서 설정 정보를 다시 읽어 온다.
        /// </summary>
        /// <returns></returns>
        public bool CreateMxCom4()
        {
            bool bOK = false;
            try
            {
                if (m_dicMxCom4 == null)
                {
                    m_dicMxCom4 = new Dictionary<int, CMxCom4>();
                }
                if (m_dicMxCom4.Count > 0)
                    m_dicMxCom4.Clear();

                bOK = CheckMxComponentVer();
                if (bOK == false) System.Windows.Forms.MessageBox.Show("MX Component 설치가 올바르지 않습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MX Coponent에 문제가 있습니다." + ex.Message);
            }
            return bOK;
        }

        public object Clone()
        {
            CDDEAConfigMS config = new CDDEAConfigMS();

            config.ENet = (CENet)ENet.Clone();
            config.MNet = (CMNet)MNet.Clone();
            config.USB = (CUSB)USB.Clone();
            config.GxSim = (CGXSim)GxSim.Clone();
            config.GOT = (CGOT)GOT.Clone();
            config.SelectedItem = (EMConnectTypeMS)SelectedItem;

            return config;
        }

        public override bool Equals(object obj)
        {
            CDDEAConfigMS config = (CDDEAConfigMS)obj;

            if (SelectedItem != config.SelectedItem) return false;
            if (!MNet.Equals(config.MNet)) return false;
            if (!USB.Equals(config.USB)) return false;
            if (!GxSim.Equals(config.GxSim)) return false;
            if (!ENet.Equals(config.ENet)) return false;
            if (!GOT.Equals(config.GOT)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
