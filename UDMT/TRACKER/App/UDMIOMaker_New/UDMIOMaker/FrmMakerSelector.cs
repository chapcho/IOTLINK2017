using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.General.Csv;
using UDM.UDLImport;

namespace UDMIOMaker
{
    public partial class FrmMakerSelector : DevExpress.XtraEditors.XtraForm
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private string m_sChannel = string.Empty;
        private CTagS m_cTagS = null;

        public FrmMakerSelector()
        {
            InitializeComponent();
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS;}
            set { m_cTagS = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }

        private bool ImportPLCTag()
        {
            bool bOK = false;

            try
            {
                CUDLImport cLogic = new CUDLImport(m_emPLCMaker, true);
                cLogic.Channel = m_sChannel;

                if (!cLogic.FileOpenCheck)
                {
                    XtraMessageBox.Show("File Open Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = cLogic.MakeGlobelAndLocalTags();
                }
                SplashScreenManager.CloseForm(false);

                if (!bOK)
                {
                    XtraMessageBox.Show("Not Support File Format!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                m_cTagS = cLogic.GlobalTags;
                m_emPLCMaker = cLogic.GlobalTags.GetFirst().PLCMaker;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Tag Import", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool ImportLSPLCTag()
        {
            bool bOK = false;

            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = "LS TAG Files(*.csv)|*.CSV";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return false;
                }

                DataTable DT = OpenLSTagCSV(dlgOpen.FileName);

                if (DT == null || DT.Columns.Count == 0)
                    return false;

                m_cTagS = GetLSTag(DT);
                m_emPLCMaker = EMPLCMaker.LS;

                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("LS PLC Tag Import", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private CTagS GetLSTag(DataTable DT)
        {
            CTagS cTagS = new CTagS();
            string sName = string.Empty;
            string sDataType = string.Empty;
            string sAddress = string.Empty;
            string sDescription = string.Empty;

            DataRow drRow = null;
            CTag cTag = null;
            foreach (var who in DT.Rows)
            {
                drRow = (DataRow) who;
                cTag = new CTag();

                sName = drRow[0].ToString();
                sDataType = drRow[1].ToString();
                sAddress = drRow[2].ToString();
                sDescription = drRow[4].ToString();

                cTag.Name = sName;
                cTag.DataType = GetLSDataType(sDataType);
                cTag.PLCMaker = EMPLCMaker.LS;
                cTag.Address = GetLSDDEAAddress(sAddress, cTag.DataType);
                cTag.Description = sDescription;
                cTag.Channel = m_sChannel;
                cTag.Key = string.Format("[{0}]{1}[{2}]", m_sChannel, cTag.Address, 1);

                if(!cTagS.ContainsKey(cTag.Key))
                    cTagS.Add(cTag.Key, cTag);
            }

            return cTagS;
        }

        private string GetLSDDEAAddress(string sAddress, EMDataType emDataType)
        {
            //Word는 Header 포함 6자리, Bit는 Header 포함 7자리 - HeaderOne 기준

            string sDDEAAddress = string.Empty;

            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sIndexBit = string.Empty;
            string sDigit = string.Empty;
            int iIndexCount = 5;


            if (CLSPlc.IsLSHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

            if (sHeader.Equals("F"))
                return sAddress;

            if (sIndex.Contains("."))
            {
                sIndexBit = "." + sIndex.Split('.')[1];
                sIndex = sIndex.Split('.')[0];
            }

            if (emDataType == EMDataType.Bool && sIndexBit == string.Empty)
                iIndexCount = 6;

            for (int i = sIndex.Length; i < iIndexCount; i++)
                sDigit += "0";

            sDDEAAddress = string.Format("{0}{1}{2}{3}", sHeader, sDigit, sIndex, sIndexBit);

            return sDDEAAddress;
        }


        private EMDataType GetLSDataType(string sDataType)
        {
            EMDataType emDataType = EMDataType.None;

            try
            {
                if (sDataType.Contains("/"))
                {
                    int index = sDataType.IndexOf("/");
                    sDataType = sDataType.Remove(0, index + 1);
                }

                if (sDataType.Contains("TIMER"))
                    emDataType = EMDataType.Timer;
                else if (sDataType.Contains("COUNTER"))
                    emDataType = EMDataType.Counter;
                else
                {
                    switch (sDataType)
                    {
                        case "BIT": emDataType = EMDataType.Bool; break;
                        case "WORD": emDataType = EMDataType.Word; break;
                        case "DWORD": emDataType = EMDataType.DWord; break;
                        case "DINT": emDataType = EMDataType.DInt; break;
                        case "INT": emDataType = EMDataType.Int; break;
                        case "REAL": emDataType = EMDataType.Real; break;
                        case "BYTE": emDataType = EMDataType.Byte; break;
                        case "STRING": emDataType = EMDataType.String; break;
                        default: emDataType = EMDataType.UserDefDataType; break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return emDataType;
        }

        private DataTable OpenLSTagCSV(string sPath)
        {
            DataTable DT = new DataTable(Path.GetFileName(sPath));
            CCsvReader cHelper = new CCsvReader();

            bool bOK = false;

            //StreamReader cReader = new StreamReader(sPath, Encoding.Default);
            //string sLine = cReader.ReadLine();

            bOK = cHelper.Open(sPath, true);

            if (bOK)
                bOK = cHelper.Fill(DT);

            cHelper.Dispose();
            cHelper = null;

            return DT;
        }


        private void chkLSMaker_CheckedChanged(object sender, EventArgs e)
        {
            m_emPLCMaker = EMPLCMaker.LS;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkMelsecMaker_CheckedChanged(object sender, EventArgs e)
        {
            m_emPLCMaker = EMPLCMaker.Mitsubishi;
        }

        private void chkSiemensMaker_CheckedChanged(object sender, EventArgs e)
        {
            m_emPLCMaker = EMPLCMaker.Siemens;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOK = false;

                if (!m_emPLCMaker.Equals(EMPLCMaker.LS))
                    bOK = ImportPLCTag();
                else
                    bOK = ImportLSPLCTag();

                if (bOK)
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;

                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Maker Selector OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}