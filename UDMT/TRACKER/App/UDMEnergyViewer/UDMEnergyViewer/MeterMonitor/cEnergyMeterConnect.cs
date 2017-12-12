using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace UDMEnergyViewer
{
    public class cEnergyMeterConnect
    {
        protected DataTable m_dOriginalDataTable = null;
        protected DataSet m_dAnalisysedDataSet = null;
        protected DataTable m_dAnalysisedDatatable = null;
        protected cModBusTCPIPWrapper m_ctcpIpWrapper = null;
        protected Thread m_thread = null;
        protected bool m_Getting = false;
        protected string m_sAddress = "192.168.1.254";
        protected int m_iPort = 502;
        protected int m_iScanInterval = 50;

        #region Initialze/Dispose
        public cEnergyMeterConnect()
        {
            m_dOriginalDataTable = new DataTable();
            m_dAnalysisedDatatable = new DataTable();
        }
        #endregion

        #region Public Properites
        public DataTable OriginalDataTable
        {
            get { return m_dOriginalDataTable; }
        }
        public DataSet AnalysisedDataSet
        {
            get { return m_dAnalisysedDataSet; }
        }
        public DataTable AnalysisedDataTable
        {
            get { return m_dAnalysisedDatatable; }
        }
        public bool IsGetting
        {
            get { return m_Getting; }
            set { m_Getting = value; }
        }
        public string IPAddress
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }
        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }
        public int ScanInterval
        {
            get { return m_iScanInterval; }
            set { m_iScanInterval = value; }
        }
        #endregion

        #region Public Methods

        public void ConnectSetting(string IP, int iport,int scaninteral)
        {
            m_sAddress = IP;
            m_iPort = iport;
            m_iScanInterval = scaninteral;

            m_ctcpIpWrapper = new cModBusTCPIPWrapper(m_sAddress, m_iPort);
            DataGettingDatatableFormat();
        }
        /// <summary>
        /// Override when nothing is changed
        /// </summary>
        public void ConnectSetting()
        {
            m_ctcpIpWrapper = new cModBusTCPIPWrapper(m_sAddress, m_iPort);
            DataGettingDatatableFormat();
        }

        public bool ReadConnectState()
        {
            return m_ctcpIpWrapper.ConnectCheck();
        }

        public void StartDataGetting()
        {
            m_Getting = true;
            m_thread = new Thread(new ThreadStart(DataGet));
            m_thread.IsBackground = true;
            m_thread.Start();
        }

        public void StopDataGetting()
        {
            m_Getting = false;
            m_thread.Abort();

            ShowDataTableMake(m_dOriginalDataTable);
        }

        public void ReadOriginalDataCSV()
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile = new OpenFileDialog();
            oFile.Multiselect = false;
            oFile.Filter = "CSV Files(*.CSV)|*.CSV";

            oFile.ShowDialog();

            string sFilePath = oFile.FileName;

            DataTable tempDT = OpenOrigCSV(sFilePath);
            ShowDataTableMake(tempDT);
        }

        public void ReadAnalysisedCSV()
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile = new OpenFileDialog();
            oFile.Multiselect = false;
            oFile.Filter = "CSV Files(*.CSV)|*.CSV";

            oFile.ShowDialog();

            string sFilePath = oFile.FileName;
            DataTable tempDT = OpenAnalysisedCSV(sFilePath);
            m_dAnalysisedDatatable = tempDT;
        }

        public void WriteOriginalDataToCSV()
        {
            string strFile = "";
            //File info initialization
            strFile = "OriginalData";
            strFile = strFile + DateTime.Now.ToString("yyyyMMddhhmmss");
            strFile = strFile + ".csv";

            SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.Filter = "CSV Files(*.CSV)|*.CSV";
            saveDia.FileName = strFile;

            saveDia.ShowDialog();

            strFile = saveDia.FileName;

            SaveToCSVFile(m_dOriginalDataTable, strFile);
        }
        
        public void WriteAnalysisedDataToCSV()
        {
            string strFile = "";
            //File info initialization
            strFile = "AnalysisedData";
            strFile = strFile + DateTime.Now.ToString("yyyyMMddhhmmss");
            strFile = strFile + ".csv";

            SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.Filter = "CSV Files(*.CSV)|*.CSV";
            saveDia.FileName = strFile;

            saveDia.ShowDialog();

            strFile = saveDia.FileName;

            SaveToCSVFile(m_dAnalysisedDatatable, strFile);
        }

        public void DetachAnalysisDatasByChannal()
        {
            m_dAnalisysedDataSet = new DataSet("Total Datas");
            int iColumnCount = m_dAnalysisedDatatable.Columns.Count;

            for(int i = 1;i<=9;i++)
            {
                string datatableName = "Channel" + i.ToString();
                DataTable dt = new DataTable(datatableName);

                dt.Columns.Add("Time", Type.GetType("System.String"));

                string sCurrent = "Channel " + i.ToString() + " Current";
                string sRealPower = "Channel " + i.ToString() + " Real Power";
                string sReactive = "Channel " + i.ToString() + " Reactive Power";
                string sApparent = "Channel " + i.ToString() + " Apparent Power";
                string sPowerFactor = "Channel " + i.ToString() + " Power Factor";
                string sLoadNature = "Channel " + i.ToString() + " Load Nature";

                dt.Columns.Add(sCurrent, Type.GetType("System.Single"));
                dt.Columns.Add(sRealPower, Type.GetType("System.Single"));
                dt.Columns.Add(sReactive, Type.GetType("System.Single"));
                dt.Columns.Add(sApparent, Type.GetType("System.Single"));
                dt.Columns.Add(sPowerFactor, Type.GetType("System.Single"));
                dt.Columns.Add(sLoadNature, Type.GetType("System.Single"));

                m_dAnalisysedDataSet.Tables.Add(dt);
            }

            foreach(DataRow dr in m_dAnalysisedDatatable.Rows)
            {
                DataRow tempDR = null;
                DataTable temptable = null;

                for(int i =1;i<iColumnCount;i++)
                {
                    int iTemp = i/6;                    

                    if(i%6==1)
                    {
                        switch(iTemp)
                        {
                            case 0: temptable = m_dAnalisysedDataSet.Tables[0]; break;
                            case 1: temptable = m_dAnalisysedDataSet.Tables[1]; break;
                            case 2: temptable = m_dAnalisysedDataSet.Tables[2]; break;
                            case 3: temptable = m_dAnalisysedDataSet.Tables[3]; break;
                            case 4: temptable = m_dAnalisysedDataSet.Tables[4]; break;
                            case 5: temptable = m_dAnalisysedDataSet.Tables[5]; break;
                            case 6: temptable = m_dAnalisysedDataSet.Tables[6]; break;
                            case 7: temptable = m_dAnalisysedDataSet.Tables[7]; break;
                            case 8: temptable = m_dAnalisysedDataSet.Tables[8]; break;
                        }
                        tempDR = temptable.NewRow();
                        tempDR[0] = dr[0];
                    }

                    switch(i%6)
                    {
                        case 1: tempDR[1] = dr[i]; break;
                        case 2: tempDR[2] = dr[i]; break;
                        case 3: tempDR[3] = dr[i]; break;
                        case 4: tempDR[4] = dr[i]; break;
                        case 5: tempDR[5] = dr[i]; break;
                        case 0: tempDR[6] = dr[i]; break;
                    }

                    if (i % 6 == 0)
                        temptable.Rows.Add(tempDR);
                }
            }
        }

        #endregion

        #region Private Methods

        private void DataGettingDatatableFormat()
        {
            m_dOriginalDataTable.Columns.Add("Time", Type.GetType("System.String"));

            for (int i = 8448; i <= 8555; i++)
            {
                string loName = i.ToString() + "_LO";
                string hiName = i.ToString() + "_HI";

                m_dOriginalDataTable.Columns.Add(loName, Type.GetType("System.Byte"));
                m_dOriginalDataTable.Columns.Add(hiName, Type.GetType("System.Byte"));
            }
        }

        private void DataGet()
        {
            while (m_Getting)
            {
                bool bbroken = false;
                byte[] test = m_ctcpIpWrapper.Receive(out bbroken);
                if(test.Length>1)
                {
                    WriteToDatatable(test);
                }
                
                System.Threading.Thread.Sleep(m_iScanInterval);
            }
        }

        private void WriteToDatatable(byte[] informations)
        {
            DataRow tempRow = m_dOriginalDataTable.NewRow();
            DateTime time = DateTime.Now;

            string sTime = time.ToString("yyyy-MM-dd hh:mm:ss fff");
            tempRow[0] = sTime;
            int iCount = informations.Length;
            for (int i = 0; i < iCount; i++)
            {
                tempRow[i + 1] = informations[i];
            }

            m_dOriginalDataTable.Rows.Add(tempRow);
        }

        private void SaveToCSVFile(DataTable tempDatatype,string strFile)
        {
            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }

            StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();

            StreamWriter sw = new StreamWriter(new FileStream(strFile, FileMode.CreateNew));

            for (int i = 0; i < tempDatatype.Columns.Count; i++)
            {
                strColu.Append(tempDatatype.Columns[i].ColumnName);
                strColu.Append(",");
            }

            strColu.Remove(strColu.Length - 1, 1);

            sw.WriteLine(strColu);

            foreach (DataRow dr in tempDatatype.Rows)
            {
                strValue.Remove(0, strValue.Length);

                for (int i = 0; i < tempDatatype.Columns.Count; i++)
                {
                    strValue.Append(dr[i].ToString());
                    strValue.Append(",");
                }

                strValue.Remove(strValue.Length - 1, 1);
                sw.WriteLine(strValue);
            }
            sw.Close();
        }

        private void ShowDataTableMake(DataTable tempDT)
        {
            try
            {
                ShowDatatableFormat();

                int iCount = tempDT.Columns.Count;

                foreach (DataRow dr in tempDT.Rows)
                {
                    int iIndex = 0;
                    DataRow TempShowDataRow = m_dAnalysisedDatatable.NewRow();
                    for (int i = 0; i < iCount; i++)
                    {
                        if (i == 0)
                        {
                            TempShowDataRow[iIndex] = dr[i];
                            iIndex = iIndex + 1;
                        }
                        else
                        {
                            if (i < iCount - 3)
                            {
                                byte[] tempDatas = new byte[4];

                                tempDatas[0] = (byte)dr[i];
                                tempDatas[1] = (byte)dr[i + 1];
                                tempDatas[2] = (byte)dr[i + 2];
                                tempDatas[3] = (byte)dr[i + 3];
                                i = i + 3;
                                float tempFloat = GetFloatValue(tempDatas);
                                TempShowDataRow[iIndex] = tempFloat;
                                iIndex = iIndex + 1;
                            }
                        }
                    }
                    m_dAnalysisedDatatable.Rows.Add(TempShowDataRow);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void ShowDatatableFormat()
        {
            m_dAnalysisedDatatable.Columns.Add("Time", Type.GetType("System.String"));

            for (int i = 1; i <= 9; i++)
            {
                string sCurrent = "Channel " + i.ToString() + " Current";
                string sRealPower = "Channel " + i.ToString() + " Real Power";
                string sReactive = "Channel " + i.ToString() + " Reactive Power";
                string sApparent = "Channel " + i.ToString() + " Apparent Power";
                string sPowerFactor = "Channel " + i.ToString() + " Power Factor";
                string sLoadNature = "Channel " + i.ToString() + " Load Nature";

                m_dAnalysisedDatatable.Columns.Add(sCurrent, Type.GetType("System.Single"));
                m_dAnalysisedDatatable.Columns.Add(sRealPower, Type.GetType("System.Single"));
                m_dAnalysisedDatatable.Columns.Add(sReactive, Type.GetType("System.Single"));
                m_dAnalysisedDatatable.Columns.Add(sApparent, Type.GetType("System.Single"));
                m_dAnalysisedDatatable.Columns.Add(sPowerFactor, Type.GetType("System.Single"));
                m_dAnalysisedDatatable.Columns.Add(sLoadNature, Type.GetType("System.Single"));
            }

        }        

        private float GetFloatValue(byte[] datas)
        {
            float tempFloat = (float)0.0;

            byte[] tempDatas = new byte[4];

            tempDatas[0] = datas[3];
            tempDatas[1] = datas[2];
            tempDatas[2] = datas[1];
            tempDatas[3] = datas[0];

            tempFloat = BitConverter.ToSingle(tempDatas, 0);

            return tempFloat;
        }

        private DataTable OpenOrigCSV(string filePath)
        {
            DataTable DataS = new DataTable();

            Encoding enconding = Encoding.ASCII;

            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            StreamReader sReader = new StreamReader(fs, enconding);

            string strLine = "";

            string[] sAryLine = null;
            string[] sTableHead = null;

            int colCount = 0;
            bool isFirst = true;

            while ((strLine = sReader.ReadLine()) != null)
            {
                if (isFirst)
                {
                    sTableHead = strLine.Split(',');

                    colCount = sTableHead.Length;

                    for (int i = 0; i < colCount; i++)
                    {
                        DataColumn dc = new DataColumn(sTableHead[i]);
                        if (i == 0)
                            dc.DataType = Type.GetType("System.String");
                        else
                            dc.DataType = Type.GetType("System.Byte");


                        DataS.Columns.Add(dc);
                    }
                    isFirst = false;
                }
                else
                {
                    sAryLine = strLine.Split(',');
                    DataRow dr = DataS.NewRow();

                    for (int i = 0; i < colCount; i++)
                    {
                        if (i == 0)
                        {
                            dr[i] = sAryLine[i];
                        }
                        else
                        {
                            if(sAryLine[i]!="")
                            {
                                short tempInt = Convert.ToInt16(sAryLine[i]);
                                dr[i] = (byte)tempInt;
                            }                            
                        }
                    }
                    DataS.Rows.Add(dr);
                }
            }
            sReader.Close();
            fs.Close();

            return DataS;
        }

        private DataTable OpenAnalysisedCSV(string filePath)
        {
            DataTable DataS = new DataTable();

            Encoding enconding = Encoding.ASCII;

            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            StreamReader sReader = new StreamReader(fs, enconding);

            string strLine = "";

            string[] sAryLine = null;
            string[] sTableHead = null;

            int colCount = 0;
            bool isFirst = true;

            while ((strLine = sReader.ReadLine()) != null)
            {
                if (isFirst)
                {
                    sTableHead = strLine.Split(',');

                    colCount = sTableHead.Length;

                    for (int i = 0; i < colCount; i++)
                    {
                        DataColumn dc = new DataColumn(sTableHead[i]);
                        if (i == 0)
                            dc.DataType = Type.GetType("System.String");
                        else
                            dc.DataType = Type.GetType("System.Single");


                        DataS.Columns.Add(dc);
                    }
                    isFirst = false;
                }
                else
                {
                    sAryLine = strLine.Split(',');
                    DataRow dr = DataS.NewRow();

                    for (int i = 0; i < colCount; i++)
                    {
                        if (i == 0)
                        {
                            dr[i] = sAryLine[i];
                        }
                        else
                        {
                            if(sAryLine[i]!="")
                            {
                                float tempInt = Convert.ToSingle(sAryLine[i]);
                                dr[i] = tempInt;
                            }                            
                        }
                    }
                    DataS.Rows.Add(dr);
                }
            }
            sReader.Close();
            fs.Close();

            return DataS;
        }
        #endregion
    }
}
