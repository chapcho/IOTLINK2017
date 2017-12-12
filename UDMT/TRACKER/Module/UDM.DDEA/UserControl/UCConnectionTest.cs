using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDM.DDEA
{
    public partial class UCConnectionTest : UserControl
    {
        #region Member Veriables

        protected CDDEAConfigMS m_cConfig = null;
        protected CReadFunction m_cReadFunction = null;
        protected bool m_bConnect = false;
        protected bool m_bPlcInfoStart = false;
        protected bool m_bSelfStart = false;
        protected bool m_bSuccess = false;
        protected int m_iErrorCountPlcInfo = 0;
        protected EMPlcConnettionType _emPlcType = EMPlcConnettionType.Melsec_Normal;
        protected double m_fScanTime = 0;
        public event UEventHandlerConnect UEventConnect;

        #endregion


        #region Initialize

        public UCConnectionTest()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public EMPlcConnettionType PLCType
        {
            set { _emPlcType = value; }
        }

        public CDDEAConfigMS Config
        {
            get { return m_cConfig;}
            set { m_cConfig = value; }
        }

        public bool ConnectSuccess
        {
            get { return m_bSuccess; }
            set { m_bSuccess = value; }
        }

        public bool TestRunning
        {
            get
            {
                if (m_bPlcInfoStart || m_bSelfStart)
                    return true;
                return false;
            }
        }

        public double ScanTime
        {
            get { return m_fScanTime; }
        }

        #endregion


        #region Private Method

        private bool Connection()
        {
            if (m_cConfig == null) return false;
            if (m_cConfig.SelectedItem == EMConnectTypeMS.None && _emPlcType == EMPlcConnettionType.Melsec_Normal) return false;

            if (m_cReadFunction == null)
                m_cReadFunction = new CReadFunction(m_cConfig, _emPlcType);

            bool bOK = m_cReadFunction.Connect();

            return bOK;
        }

        private bool DisConnect()
        {
            if (m_cReadFunction == null) return false;

            bool bOK = m_cReadFunction.Disconnect();

            return bOK;
        }

        private string[] ScanValue(List<int> lstValue)
        {
            string[] saV = new string[6];

            saV[0] = lstValue[0].ToString() + "." + lstValue[1].ToString();   //D520 Now
            saV[1] = lstValue[2].ToString() + "." + lstValue[3].ToString();   //D526 Max
            saV[2] = lstValue[4].ToString() + "." + lstValue[5].ToString();   //D524 Min
            saV[3] = Convert.ToUInt32(lstValue[6]).ToString();//Count sd420
            saV[4] = lstValue[7].ToString() + "." + lstValue[8].ToString();   //D524 Min //EndToStart
            saV[5] = lstValue[9].ToString() + "." + lstValue[10].ToString();
            double fSacnNow = 0;
            bool bOK = double.TryParse(saV[0],out fSacnNow);
            if (bOK) m_fScanTime = fSacnNow;
            return saV;
        }

        private string[] StatusValue(List<int> lstValue)
        {
            string[] saV = new string[4];

            if (lstValue[0] == 0)        //SD200
            {
                saV[0] = "RUN";
            }
            else
            {
                saV[0] = "STOP";
            }

            byte[] bArray = new byte[2];
            bArray = BitConverter.GetBytes(lstValue[1]); //201
            System.Collections.BitArray myBA = new System.Collections.BitArray(bArray);


            if ((myBA[0]) || (myBA[1]))
                saV[1] = "RUN";
            else
                saV[1] = "STOP";
            if ((myBA[2]) || (myBA[3]))
                saV[2] = "ERROR";
            else
                saV[2] = "GOOD";
            if ((myBA[6]) || (myBA[7]))
                saV[3] = "BAT ERR";
            else
                saV[3] = "GOOD";

            return saV;
        }

        private string[] ModuleValue(List<int> lstValue)
        {
            string[] saV = new string[lstValue.Count];

            for (int i = 0; i < lstValue.Count; i++)
            {
                saV[i] = lstValue[i].ToString();
            }

            return saV;
        }

        private DataTable InsertDataTable(string[] saName, string[] saValue)
        {
            DataTable dbTable = new DataTable();

            dbTable.Columns.Add("Name");
            dbTable.Columns.Add("Value");
            if (saName.Length != saValue.Length)
                return dbTable;

            for (int i = 0; i < saName.Length; i++)
            {
                DataRow row = dbTable.NewRow();
                row[0] = saName[i];
                row[1] = saValue[i];
                dbTable.Rows.Add(row);
            }

            return dbTable;
        }

        private void ReadSelfData()
        {
            txtTestData.Clear();

            string sAddress = "";
            sAddress = "SM412\nSD520\nSD521\nSD524\nSD525\nSD526\nSD527\nSD540\nSD541\nSD548\nSD549";
            int iBufSize = 11;
            List<string> lstAddress = new List<string>();

            int[] iReadRandomData = new int[iBufSize];
            int[] iOldReadRandomData = new int[iBufSize];

            bool bSingle = false;
            if (txtTestAddress.Text != "")
            {
                if (txtTestAddress.Text.Contains("\r") == false)
                {
                    sAddress = txtTestAddress.Text;
                }
                bSingle = true;

                sAddress = txtTestAddress.Text.Replace("\r", "");
                iBufSize = GetAddressCount(sAddress);
                lstAddress = GetAddressList(sAddress);
                iReadRandomData = m_cReadFunction.ReadRandomData(sAddress, iBufSize);
                if (iReadRandomData != null)
                {
                    for (int i = 0; i < iBufSize; i++)
                    {
                        string sValue = string.Format("{0},   {1},   {2},   {3}", DateTime.Now.ToString("HH:mm:ss.fff"), lstAddress[i], iReadRandomData[i], "초기값");
                        txtTestData.AppendText(sValue + "\r\n");
                    }
                }
            }
            else
            {
                txtTestAddress.Text = sAddress.Replace("\n", "\r\n");

            }

            //string[] saName2 = { "Now Time", "Min Time", "Max Time", "End → Start", "Program" };
            int iErrorCount = 0;
            Dictionary<string, DateTime> dicOldTime = new Dictionary<string, DateTime>();
            while (m_bSelfStart)
            {
                iReadRandomData = m_cReadFunction.ReadRandomData(sAddress, iBufSize);
                if (iReadRandomData == null)
                {
                    if (m_cReadFunction.ReadErrorCode == 0x1801001)
                        continue;
                    string sError = string.Format("Error : 0x{0:x}\r\n", m_cReadFunction.ReadErrorCode);
                    txtTestData.AppendText(sError);
                    txtTestData.AppendText("Send Address : " + sAddress + "\r\n");
                    txtTestData.AppendText("Send Counter : " + iBufSize.ToString() + "\r\n");
                    Application.DoEvents();
                    iReadRandomData = new int[iBufSize];
                    iErrorCount++;
                }
                else
                {
                    if (bSingle == false)
                    {
                        txtTestData.AppendText(iReadRandomData[0].ToString() + ",  ");
                        txtTestData.AppendText(iReadRandomData[1].ToString() + "." + iReadRandomData[2].ToString() + ",  ");
                        txtTestData.AppendText(iReadRandomData[3].ToString() + "." + iReadRandomData[4].ToString() + ",  ");
                        txtTestData.AppendText(iReadRandomData[5].ToString() + "." + iReadRandomData[6].ToString() + ",  ");
                        txtTestData.AppendText(iReadRandomData[7].ToString() + "." + iReadRandomData[8].ToString() + ",  ");
                        txtTestData.AppendText(iReadRandomData[9].ToString() + "." + iReadRandomData[10].ToString() + "\r\n");
                    }
                    else
                    {
                        DateTime dtNow = DateTime.Now;
                        for (int i = 0; i < iBufSize; i++)
                        {
                            if (iOldReadRandomData[i] != iReadRandomData[i])
                            {
                                if (dicOldTime.ContainsKey(lstAddress[i]) == false)
                                    dicOldTime.Add(lstAddress[i], DateTime.Now);
                                else
                                {
                                    TimeSpan tSpan = dtNow.Subtract(dicOldTime[lstAddress[i]]);

                                    string sValue = string.Format("{0},   {1},   {2},   {3}", dtNow.ToString("HH:mm:ss.fff"), lstAddress[i], iReadRandomData[i], (long)tSpan.TotalMilliseconds);
                                    txtTestData.AppendText(sValue + "\r\n");
                                    dicOldTime[lstAddress[i]] = dtNow;
                                }
                            }
                        }
                        iOldReadRandomData = (int[])iReadRandomData.Clone();
                    }
                }
                if (iErrorCount > 10)
                {
                    txtTestData.AppendText("Error가 10번이상 발생하여 정지합니다. " + "\r\n");
                    m_bSelfStart = false;
                    break;
                }
                Application.DoEvents();
            }
        }

        private int GetAddressCount(string sAddress)
        {
            int iResult = 0;
            string[] sSplit = sAddress.Split('\n');

            if (sSplit.Length > 0)
            {
                for (int i = 0; i < sSplit.Length; i++)
                {
                    if (sSplit[i] == "")
                        continue;
                    iResult++;
                }
            }
            return iResult;
        }

        private List<string> GetAddressList(string sAddress)
        {
            List<string> lstResult = new List<string>();
            string[] sSplit = sAddress.Split('\n');

            if (sSplit.Length > 0)
            {
                for (int i = 0; i < sSplit.Length; i++)
                {
                    if (sSplit[i] == "")
                        continue;
                    lstResult.Add(sSplit[i]);
                }
            }
            return lstResult;
        }

        #endregion


        #region Public Method

        public void TestStop()
        {
            if (m_bConnect == false) return;

            if (m_bSelfStart)
                btnSelfStop_Click(null, null);

            if (m_bPlcInfoStart)
                btnPlcInfoStop_Click(null, null);

            m_bConnect = DisConnect();
        }

        public bool CheckConnect()
        {
            btnConnect_Click(null, null);
            return m_bSuccess;
        }

        #endregion

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UEventConnect(this);

            m_bSuccess = false;
            m_bConnect = Connection();

            if (m_bConnect == false)
            {
                MessageBox.Show("연결 실패\r\n통신 설정을 확인하세요", "DDEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            m_bSuccess = true;
            btnConnect.Enabled = false;
            btnDisConnect.Enabled = true;
            tabDataView.Enabled = true;
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if (m_bConnect == false) return;

            TestStop();

            if (m_bConnect == false)
            {
                MessageBox.Show("해제 실패\r\n통신 설정을 확인하세요", "DDEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabDataView.Enabled = false;
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;
            m_bConnect = false;
        }

        private void btnPlcInfoStart_Click(object sender, EventArgs e)
        {
            if (m_bConnect == false) return;

            if (m_bSelfStart)
                btnSelfStop_Click(sender, e);

            btnPlcInfoStop.Enabled = true;
            btnPlcInfoStart.Enabled = false;

            tmrPlcInfoStart.Interval = (int)spnCollectTime.Value;

            tmrPlcInfoStart.Start();
            m_bPlcInfoStart = true;
        }

        private void btnPlcInfoStop_Click(object sender, EventArgs e)
        {
            btnPlcInfoStop.Enabled = false;
            btnPlcInfoStart.Enabled = true;

            tmrPlcInfoStart.Stop();
            m_bPlcInfoStart = false;
        }

        private void btnSelfStart_Click(object sender, EventArgs e)
        {
            if (m_bConnect == false) return;

            if (m_bPlcInfoStart)
                btnPlcInfoStop_Click(sender, e);

            m_bSelfStart = true;
            btnSelfStart.Enabled = false;
            btnSelfStop.Enabled = true;

            ReadSelfData();
        }

        private void btnSelfStop_Click(object sender, EventArgs e)
        {
            btnSelfStart.Enabled = true;
            btnSelfStop.Enabled = false;

            m_bSelfStart = false;
        }

        private void tmrPlcInfoStart_Tick(object sender, EventArgs e)
        {
            tmrPlcInfoStart.Stop();

            string sAddress = "SD200\nSD201\nSD254\nSD255\nSD256\nSD257\nSD258\n";
            sAddress += "SD290\nSD291\nSD292\nSD293\nSD294\nSD295\nSD296\nSD297\nSD298\nSD299\nSD300\nSD301\nSD302\nSD303\nSD304\n";    //15ea
            sAddress += "SD315\nSD340\nSD341\nSD342\nSD343\nSD344\nSD420\nSD520\nSD521\nSD524\nSD525\nSD526\nSD527\nSD540\nSD541\nSD548\nSD549";
            int iBufSize = 39;
            int[] iReadRandomData = new int[iBufSize];

            iReadRandomData = m_cReadFunction.ReadRandomData(sAddress, iBufSize);

            if (iReadRandomData == null)
            {
                if (m_cReadFunction.ReadErrorCode != 0x1801001)
                {
                    int iErrorCode = m_cReadFunction.ReadErrorCode;
                    string sMsg = string.Format("수집 실패 Error Code : {0} Count = {1}", iErrorCode, m_iErrorCountPlcInfo++);
                    grpPlcInfoControl.Text = sMsg;
                }
            }
            else
            {
                string[] saValue = null;
                string[] saName2 = { "Now Time", "Min Time", "Max Time", "Count", "End → Start", "Program" };

                List<int> lstScanData = new List<int>();

                lstScanData.Add(iReadRandomData[29]);
                lstScanData.Add(iReadRandomData[30]);
                lstScanData.Add(iReadRandomData[31]);
                lstScanData.Add(iReadRandomData[32]);
                lstScanData.Add(iReadRandomData[33]);
                lstScanData.Add(iReadRandomData[34]);
                lstScanData.Add(iReadRandomData[28]);
                lstScanData.Add(iReadRandomData[35]);
                lstScanData.Add(iReadRandomData[36]);
                lstScanData.Add(iReadRandomData[37]);
                lstScanData.Add(iReadRandomData[38]);

                saValue = ScanValue(lstScanData);
                grdScan.DataSource = InsertDataTable(saName2, saValue);
                grdScan.RefreshDataSource();

                string[] saName3 = { "S/W", "Run Led", "BAT Alarm Led", "Error Led" };

                List<int> lstStatusData = new List<int>();
                lstStatusData.Add(iReadRandomData[0]);
                lstStatusData.Add(iReadRandomData[1]);
                saValue = StatusValue(lstStatusData);
                grdStatus.DataSource = InsertDataTable(saName3, saValue);
                grdStatus.RefreshDataSource();

                string[] saName4 = { "X", "Y", "M", "L", "B", "F", "SB", "V", "S", "T",
                               "ST", "C", "D", "W", "SW"};
                List<int> lstSymbolLimitData = new List<int>();

                lstSymbolLimitData.Add(iReadRandomData[7]);     //X
                lstSymbolLimitData.Add(iReadRandomData[8]);     //Y
                lstSymbolLimitData.Add(iReadRandomData[9]);     //M
                lstSymbolLimitData.Add(iReadRandomData[10]);    //L
                lstSymbolLimitData.Add(iReadRandomData[11]);    //B
                lstSymbolLimitData.Add(iReadRandomData[12]);    //F
                lstSymbolLimitData.Add(iReadRandomData[13]);    //SB
                lstSymbolLimitData.Add(iReadRandomData[14]);    //V
                lstSymbolLimitData.Add(iReadRandomData[15]);    //S
                lstSymbolLimitData.Add(iReadRandomData[16]);    //T
                lstSymbolLimitData.Add(iReadRandomData[17]);    //ST
                lstSymbolLimitData.Add(iReadRandomData[18]);    //C
                lstSymbolLimitData.Add(iReadRandomData[19]);    //D
                lstSymbolLimitData.Add(iReadRandomData[20]);    //W
                lstSymbolLimitData.Add(iReadRandomData[21]);    //SW

                saValue = ModuleValue(lstSymbolLimitData);
                grdSymbolLimit.DataSource = InsertDataTable(saName4, saValue);
                grdSymbolLimit.RefreshDataSource();
            }

            tmrPlcInfoStart.Start();
        }

    }
}
