using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using UDM.General.Csv;
using UDM.Log;

namespace UDMEnergyViewer
{
    public class CMeterLogReader : IDisposable
    {

        #region Member Variables
        protected DataTable m_dtDataTable = null;
        #endregion


        #region Initialize/Dispose

        public CMeterLogReader()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        
        #endregion


        #region Public Methods

        public bool Open(string sPath)
        {
            bool bOK = false;

            m_dtDataTable = OpenOrigCSV(sPath);

            if(m_dtDataTable!=null)
                bOK = true;

            return bOK;
        }

        public bool Close()
        {            

            return true;
        }

        /// <summary>
        /// 0:Time(yyyyMMddHHmmss.fff), 1:value1, 2:value2, ~
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public CMeterItem Read(string sKey)
        {
            if (m_dtDataTable == null)
                return null;

            CMeterItem cItem = new CMeterItem();
            cItem.Key = sKey;
            try
            {
                FormatItem(cItem);
                int iPos = sKey.IndexOf("_");
                string sTemp = sKey.Substring(iPos+1);
                int iChannel = Convert.ToInt32(sTemp);

                int iStartCol = (iChannel - 1) * 24 + 1;

                int iColumnsCount = m_dtDataTable.Columns.Count;
                int iRowsCount = m_dtDataTable.Rows.Count;

                DateTime tFirst = DateTime.MinValue;
                DateTime tLast = DateTime.MinValue;

                for(int i =0;i<iRowsCount;i++)
                {
                    DataRow dr = m_dtDataTable.Rows[i];

                    DateTime tempDataTime = DateTime.ParseExact(dr[0].ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    //DateTime tempDataTime = DateTime.ParseExact(dr[0].ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    if (i == 0)
                        tFirst = tempDataTime;
                    else if (i == iRowsCount - 1)
                        tLast = tempDataTime;

                    for (int j = iStartCol; j < iStartCol+24; j = j + 4)
                    {
                        byte[] tempDatas = new byte[4];
                        tempDatas[0] = (byte)dr[j];
                        tempDatas[1] = (byte)dr[j + 1];
                        tempDatas[2] = (byte)dr[j + 2];
                        tempDatas[3] = (byte)dr[j + 3];

                        float tempFloat = GetFloatValue(tempDatas);

                        LogItemGenerator(j,cItem, tempDataTime, tempFloat);
                    }
                }
                WriteFirstAndLastTime(cItem, tFirst, tLast);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }


            return cItem;
        }

        public CMeterItemS Read()
        {
            CMeterItemS cMeterItems = null;

            try
            {
                if (m_dtDataTable == null)
                    return null;

                int iColumnsCount = m_dtDataTable.Columns.Count;

                cMeterItems = FormatItemS(iColumnsCount);
                DateTime tFirst = DateTime.MinValue;
                DateTime tLast = DateTime.MinValue;

                int iRowsCount = m_dtDataTable.Rows.Count;
                for(int i =0;i<iRowsCount;i++)
                {
                    DataRow dr = m_dtDataTable.Rows[i];

                    try
                    {
                        DateTime tempDataTime = DateTime.ParseExact(dr[0].ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);

                        if (i == 0)
                            tFirst = tempDataTime;
                        else if (i == iRowsCount - 1)
                            tLast = tempDataTime;


                        for (int j = 1; j < iColumnsCount - 3; j = j + 4)
                        {
                            byte[] tempDatas = new byte[4];
                            tempDatas[0] = (byte)dr[j];
                            tempDatas[1] = (byte)dr[j + 1];
                            tempDatas[2] = (byte)dr[j + 2];
                            tempDatas[3] = (byte)dr[j + 3];

                            float tempFloat = GetFloatValue(tempDatas);

                            LogItemGenerator(j, cMeterItems, tempDataTime, tempFloat);
                        }
                    }
                    catch(System.Exception ex)
                    {
                        ex.Data.Clear();
                    }
                }

                cMeterItems.FirstTime = tFirst;
                cMeterItems.LastTime = tLast;

                foreach(CMeterItem mItem in cMeterItems.Values)
                {
                    WriteFirstAndLastTime(mItem, tFirst, tLast);

                    foreach (CMeterUnit cUnit in mItem)
                        cUnit.UpdateLogKey();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cMeterItems;
        }

        #endregion


        #region Private Methods

        private DateTime GetTime(List<string> lstValue)
        {
            DateTime dtTime = DateTime.MinValue;

            dtTime = DateTime.ParseExact(lstValue[0], "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);

            return dtTime;
        }

        private int GetValue(string sValue)
        {
            int iValue = int.Parse(sValue);

            return iValue;;
        }

        private float GetFloatValue(string sValue)
        {
            float fValue = Convert.ToSingle(sValue);
            return fValue;
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
            int heColCount = 0;
            bool isFirst = true;

            while ((strLine = sReader.ReadLine()) != null)
            {
                if (isFirst)
                {
                    sTableHead = strLine.Split(',');

                    heColCount = sTableHead.Length;

                    for (int i = 0; i < heColCount; i++)
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
                    int RowColCount = sAryLine.Length;
                    if (RowColCount > heColCount)
                        colCount = heColCount;
                    else
                        colCount = RowColCount;

                    for (int i = 0; i < colCount; i++)
                    {
                        if (i == 0)
                        {
                            dr[i] = sAryLine[i];
                        }
                        else
                        {
                            if (sAryLine[i] != "")
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

        private CMeterItemS FormatItemS(int iCount)
        {
            CMeterItemS cMeterItems = new CMeterItemS();

            try
            {

                int iUnitCount = (iCount - 1) / 4;
                int iChannelCount = iUnitCount / 6;

                for(int i=1;i<=iChannelCount;i++)
                {
                    CMeterItem cMeterItem = new CMeterItem();
                    cMeterItem.Key = "Channel_" + i.ToString();

                    for(int j =0;j<6;j++)
                    {
                        CMeterUnit cTempUnit = new CMeterUnit();
                        cTempUnit.Parent = cMeterItem.Key;
                        switch(j)
                        {
                            case 0: cTempUnit.Key = cMeterItem.Key + "_Current"; break;
                            case 1: cTempUnit.Key = cMeterItem.Key + "_Real_Power"; break;
                            case 2: cTempUnit.Key = cMeterItem.Key + "_Reactive_Power"; break;
                            case 3: cTempUnit.Key = cMeterItem.Key + "_Apparent_Power"; break;
                            case 4: cTempUnit.Key = cMeterItem.Key + "_Power_Factor"; break;
                            case 5: cTempUnit.Key = cMeterItem.Key + "_Load_Nature"; break;
                        }
                        cMeterItem.Add(cTempUnit);
                    }

                    cMeterItems.Add(cMeterItem.Key, cMeterItem);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cMeterItems;
        }

        private void FormatItem(CMeterItem cMeterItem)
        {
            for (int i = 0; i < 6; i++)
            {
                CMeterUnit cTempUnit = new CMeterUnit();
                cTempUnit.Parent = cMeterItem.Key;
                switch (i)
                {
                    case 0: cTempUnit.Key = cMeterItem.Key + "_Current"; break;
                    case 1: cTempUnit.Key = cMeterItem.Key + "_Real_Power"; break;
                    case 2: cTempUnit.Key = cMeterItem.Key + "_Reactive_Power"; break;
                    case 3: cTempUnit.Key = cMeterItem.Key + "_Apparent_Power"; break;
                    case 4: cTempUnit.Key = cMeterItem.Key + "_Power_Factor"; break;
                    case 5: cTempUnit.Key = cMeterItem.Key + "_Load_Nature"; break;
                }

                cMeterItem.Add(cTempUnit);
            }
        }

        private void LogItemGenerator(int iCellIndex, CMeterItemS tempItemS, DateTime tempDate, float tempValue )
        {
            try
            {
                iCellIndex = iCellIndex-1;

                iCellIndex = iCellIndex / 4;
                int iChannel= iCellIndex/6+1;

                string sChannel = "Channel_" + iChannel.ToString();

                int iUnit = iCellIndex%6;
                if (iUnit > 0)
                    tempValue = tempValue * 1000;

                CTimeLog tempLog = new CTimeLog();

                tempLog.FValue = tempValue;
                tempLog.SValue = tempValue.ToString();
                tempLog.Time = tempDate;
                tempLog.Parent = tempItemS[sChannel][iUnit].Key;

                tempItemS[sChannel][iUnit].LogS.Add(tempLog);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void LogItemGenerator(int iCellIndex, CMeterItem tempItem, DateTime tempDate,float tempValue)
        {
            try
            {
                iCellIndex = iCellIndex - 1;

                iCellIndex = iCellIndex / 4;
                int iUnit = iCellIndex % 6;

                CTimeLog tempLog = new CTimeLog();
                if (iUnit > 0)
                    tempValue = tempValue * 1000;

                tempLog.FValue = tempValue;
                tempLog.SValue = tempValue.ToString();
                tempLog.Time = tempDate;
                tempLog.Parent = tempItem[iUnit].Key;

                tempItem[iUnit].LogS.Add(tempLog);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void WriteFirstAndLastTime(CMeterItem cMeterItem, DateTime FirstTime, DateTime LastTime)
        {
            try
            {
                cMeterItem.FirstTime = FirstTime;
                cMeterItem.LastTime = LastTime;

                foreach(CMeterUnit tempUnit in cMeterItem)
                {
                    tempUnit.LogS.FirstTime = FirstTime;
                    tempUnit.LogS.LastTime = LastTime;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

    }
}
