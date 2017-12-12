using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using UDM.Common;
using UDM.Log;

namespace FTOPApp
{
    public class MySqlLogReader : IDisposable
    {

        protected bool m_bConnected = false;
        protected MySqlConnection m_dbCon = null;
        protected string m_sConnServer = @"DATA SOURCE=localhost;PORT=3306;INITIAL CATALOG=PLCMS;USER ID=root;PASSWORD=udmt;charset=utf8";


        #region Intialize/Dispose

        public MySqlLogReader()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool IsConnected
        {
            get { return m_bConnected; }
        }

        #endregion


        #region Public Methods

        #region DB Connection

        public bool Connect()
        {
            bool bOK = true;

            try
            {
                if (m_dbCon == null)
                {
                    m_dbCon = new MySqlConnection(m_sConnServer);
                    m_dbCon.Open();
                    m_bConnected = true;

                }
                else if (m_dbCon.State == ConnectionState.Closed || m_dbCon.State == ConnectionState.Broken)
                {
                    m_dbCon.Close();
                    m_dbCon.Dispose();
                    m_dbCon = null;

                    m_dbCon = new MySqlConnection(m_sConnServer);
                    m_dbCon.Open();
                    m_bConnected = true;

                }
            }
            catch (System.Exception ex)
            {
                m_dbCon.Close();
                m_dbCon.Dispose();
                m_dbCon = null;
                m_bConnected = false;

                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Disconnect()
        {
            bool bOK = true;

            try
            {
                if (m_dbCon != null)
                {
                    m_dbCon.Close();
                    m_dbCon.Dispose();
                    m_dbCon = null;

                    m_bConnected = false;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        #endregion

        #region Time Log Table

        public CTimeLogS GetTimeLogS(string skey)
        {
            CTimeLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            string sQuery = @"SELECT * FROM PLCMS.tblTimeLog WHERE "
                                            + "cKey = '" + skey + "' ORDER BY cTime ASC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToTimeLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CTimeLogS GetTimeLogS(DateTime dtFrom, DateTime dtTo)
        {
            CTimeLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            string sQuery = @"SELECT * FROM PLCMS.tblTimeLog WHERE "
                                            + "cTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cTime <= " + CLogUtil.ToTimeString(dtTo) + " ORDER BY cTime ASC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToTimeLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }        

        public CTimeLogS GetTimeLogS(string sKey, DateTime dtFrom, DateTime dtTo)
        {
            CTimeLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            string sQuery = @"SELECT * FROM PLCMS.tblTimeLog WHERE "
                                            + "cTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cTime <= " + CLogUtil.ToTimeString(dtTo) + " AND "
                                            + "cKey = '" + sKey + "' ORDER BY cTime ASC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToTimeLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                if (cLogS != null)
                    cLogS.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CTimeLogS GetTimeLogS(string sKey, int iValue, DateTime dtFrom, DateTime dtTo)
        {
            CTimeLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            string sQuery = string.Empty;

            if (iValue == -1)
            {
                sQuery = @"SELECT * FROM tblTimeLog WHERE "
                                            + "cTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cTime <= " + CLogUtil.ToTimeString(dtTo) + " AND "
                                            + "cKey = '" + sKey + "' ORDER BY cTime ASC;";
            }
            else
            {
                sQuery = @"SELECT * FROM tblTimeLog WHERE "
                                            + "cTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cTime <= " + CLogUtil.ToTimeString(dtTo) + " AND "
                                            + "cKey = '" + sKey + "' AND "
                                            + "cValue = '" + iValue.ToString() + "' ORDER BY cTime ASC;";
            }

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToTimeLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CTimeLogS GetTimeLogS(List<string> lstKey, DateTime dtFrom, DateTime dtTo)
        {
            CTimeLogS cLogS = new CTimeLogS();

            try
            {
                if (m_bConnected)
                {
                    CTimeLogS cTotalLogS = GetTimeLogS(dtFrom, dtTo);
                    if (cTotalLogS == null)
                        return null;

                    CTimeLog cLog;
                    for(int i=0;i<cTotalLogS.Count;i++)
                    {
                        cLog = cTotalLogS[i];
                        if (lstKey.Contains(cLog.Key))
                            cLogS.Add(cLog);
                    }

                    cTotalLogS.Clear();
                    cTotalLogS = null;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                if (cLogS != null)
                    cLogS.Clear();
            }
            finally
            {
            }

            return cLogS;
        }

        public CGroupLogS GetGroupLogLatestTime(string sKey, DateTime dtFrom)
        {
            CGroupLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblGroupLog WHERE "
                                            + "cStartTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cKey = '" + sKey + "' ORDER BY cStartTime DESC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToGroupLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public DateTime GetLastTimeLogTime()
        {
            DateTime dtTime = DateTime.MinValue;

            DataSet dbSet = null;

            MySqlDataAdapter dbAdapter = null;

            try
            {
                string sQuery = "SELECT * FROM PLCMS.tblTimeLog ORDER BY cTime DESC LIMIT 1";

                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);

                    dbSet = new DataSet();

                    dbAdapter.Fill(dbSet);
                }

                if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                {
                    decimal nValue = (decimal)dbSet.Tables[0].Rows[0][0];
                    dtTime = CLogUtil.ToDateTime(nValue);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return dtTime;
        }

        #endregion     
   
        #region Monitor Log Table

        private CMonitorLogS DataSetToMonitorHistoryLogS(DataSet dbSet)
        {
            CMonitorLogS cLogS = null;

            if (dbSet != null && dbSet.Tables.Count > 0)
            {
                cLogS = new CMonitorLogS();

                CMonitorLog cLog;
                decimal nTime;

                foreach(DataRow dtRow in dbSet.Tables[0].Rows)
                {
                    cLog = new CMonitorLog();
                    foreach(DataColumn dtCol in dbSet.Tables[0].Columns)
                    {
                        var columnName = dtCol.ColumnName.ToString(); // dtRow[dtCol].ToString();
                        try
                        {
                            switch (columnName.ToUpper())
                            {
                                case "CSTARTTIME": nTime = (decimal)dtRow[dtCol]; cLog.StartTime = CLogUtil.ToDateTime(nTime); break;
                                case "CENDTIME": nTime = (decimal)dtRow[dtCol]; cLog.EndTime = CLogUtil.ToDateTime(nTime); break;
                                case "CKEY": cLog.Key = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "CPRODUCT": cLog.Product = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "CRECIPE": cLog.Recipe = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "CMONITORMODE": cLog.MonitorMode = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "FSTUPDDT": nTime = (decimal)dtRow[dtCol]; cLog.FirstUpdateDT = CLogUtil.ToDateTime(nTime); break;
                                case "FNLUPDDT": nTime = (decimal)dtRow[dtCol]; cLog.FinalUpdateDT = CLogUtil.ToDateTime(nTime); break;
                                case "FNLUPDER": cLog.FinalUpdater = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "CLRDT": nTime = (decimal)dtRow[dtCol]; cLog.ClearDT = CLogUtil.ToDateTime(nTime); break;
                                case "ERRCODE": cLog.ErrorCode = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "ERRDESC": cLog.ErrorDescription = (string)dtRow[dtCol].ToString().Trim(); break;
                                case "MNTRNOTE": cLog.MonitoringNote = (string)dtRow[dtCol].ToString().Trim(); break;
                                default:
                                    Console.WriteLine("columnName : [{0}] processing not found!!! -- {1}", columnName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                                    break;
                            }
                        }
                        catch(Exception ex)
                        {
                            ex.Data.Clear();
                            continue;
                        }
                    }
                    cLogS.Add(cLog);
                }

            }

            return cLogS;
        }

        public CMonitorLogS GetMonitorLogS(string sKey)
        {
            CMonitorLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT cStartTime, cEndTime, ckey, cProduct, cRecipe, cMonitorMode, fstUpdDt, fnlUpdDt,"
                            +"fnlUpder, IFNULL(clrDt,fstUpdDt) as clrDt,errCode,errDesc,mntrNote FROM PLCMS.tbaMntrHist "
                            +"WHERE cKey = '" + sKey + "' ORDER BY cStartTime ASC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToMonitorHistoryLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CMonitorLogS GetMonitorLogS(DateTime dtFrom, DateTime dtTo)
        {
            CMonitorLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT cStartTime, cEndTime, ckey, cProduct, cRecipe, cMonitorMode, fstUpdDt, fnlUpdDt, "
                            + "fnlUpder, IFNULL(clrDt,fstUpdDt) as clrDt,errCode,errDesc,mntrNote FROM PLCMS.tbaMntrHist "
                            + "WHERE  cStartTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                            + "cStartTime <= " + CLogUtil.ToTimeString(dtTo) + " ORDER BY cStartTime ASC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToMonitorHistoryLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }
        #endregion

        #region Group Log Table

        public CGroupLogS GetGroupLogS(string sKey)
        {
            CGroupLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblGroupLog WHERE "
                                            + "cKey = '" + sKey + "' ORDER BY cStartTime ASC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToGroupLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CGroupLogS GetGroupLogS(DateTime dtFrom, DateTime dtTo)
        {
            CGroupLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblGroupLog WHERE "
                                            + "cStartTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cStartTime <= " + CLogUtil.ToTimeString(dtTo) + " ORDER BY cStartTime ASC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToGroupLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public CGroupLogS GetGroupLogS(string sKey, DateTime dtFrom, DateTime dtTo)
        {
            CGroupLogS cLogS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = string.Empty;

            sQuery = @"SELECT * FROM PLCMS.tblGroupLog WHERE "
                                            + "cStartTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cStartTime <= " + CLogUtil.ToTimeString(dtTo) + " AND "
                                            + "cKey = '" + sKey + "' ORDER BY cStartTime ASC;";


            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToGroupLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        public DateTime GetLastGroupLogTime(EMMonitorType emMonitorType)
        {
            DateTime dtTime = DateTime.MinValue;

            DataSet dbSet = null;

            MySqlDataAdapter dbAdapter = null;

            try
            {
                string sQuery = "SELECT * FROM PLCMS.tblGroupLog where cMonitorMode = '" + emMonitorType.ToString() + "' ORDER BY cStartTime DESC LIMIT 1";

                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);

                    dbSet = new DataSet();

                    dbAdapter.Fill(dbSet);
                }

                if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                {
                    decimal nValue = (decimal)dbSet.Tables[0].Rows[0][1];
                    dtTime = CLogUtil.ToDateTime(nValue);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return dtTime;
        }

        #endregion

        #region System Log Table

        public CSystemLogS GetSystemLogS(DateTime dtFrom, DateTime dtTo)
        {
            CSystemLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblSystemLog WHERE "
                                            + "cTime >= " + CLogUtil.ToTimeString(dtFrom) + " AND "
                                            + "cTime <= " + CLogUtil.ToTimeString(dtTo) + " ORDER BY cTime ASC;";


            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToSystemLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        #endregion


        #region Cycle Log Table

        public CCycleInfoS GetCycleInfoS(string sProjectID)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}');", sProjectID);
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        public CCycleInfoS GetCycleInfoS(string sProjectID, DateTime dtFrom, DateTime dtTo)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND dtCycleStart >= {1} AND dtCycleStart <= {2} ORDER BY dtCycleStart ASC;", sProjectID, CLogUtil.ToTimeString(dtFrom), CLogUtil.ToTimeString(dtTo));
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        public CCycleInfoS GetCycleInfoS(string sProjectID, string sKey)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND sGroupKey = '{1}' ORDER BY dtCycleStart ASC ;", sProjectID, sKey);
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        public CCycleInfoS GetCycleInfoS(string sProjectID, string sKey, DateTime dtFrom, DateTime dtTo)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND sGroupKey = '{1}' AND dtCycleStart >= {2} AND dtCycleStart <= {3} ORDER BY dtCycleStart ASC ;", sProjectID, sKey, CLogUtil.ToTimeString(dtFrom), CLogUtil.ToTimeString(dtTo));
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        public CCycleInfoS GetCycleInfoS(string sProjectID, string sKey, DateTime dtTime)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND sGroupKey = '{1}' AND dtCycleStart <= {2} AND dtCycleEnd >= {3} ORDER BY dtCycleStart ASC ;", sProjectID, sKey, CLogUtil.ToTimeString(dtTime), CLogUtil.ToTimeString(dtTime));
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        public CCycleInfoS GetCycleInfoS(string sProjectID, string sKey, int iCycleID)
        {
            if (sProjectID == "")
                return null;

            CCycleInfoS cCycleInfoS = new CCycleInfoS();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND sGroupKey = '{1}' AND iCycleID = '{2}' ORDER BY dtCycleStart ASC ;", sProjectID, sKey, iCycleID);
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cCycleInfoS = DataSetToCycleInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cCycleInfoS;
        }

        #endregion

        #region Production Information Table

        public CProductionInfoS GetProductionInfoS(string sProjectID)
        {
            if (sProjectID == "")
                return null;

            CProductionInfoS cInfoS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblProductionInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}');", sProjectID);
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cInfoS = DataSetToProductionInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cInfoS;
        }

        public CProductionInfoS GetProductionInfoS(string sProjectID, DateTime dtFrom, DateTime dtTo)
        {
            if (sProjectID == "")
                return null;

            CProductionInfoS cInfoS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;


            string sQuery = @"SELECT * FROM PLCMS.tblProductionInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}') AND dtProductionTime >= {1} AND dtProductionTime <= {2} ORDER BY dtProductionTime ASC ;", sProjectID, CLogUtil.ToTimeString(dtFrom), CLogUtil.ToTimeString(dtTo));
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cInfoS = DataSetToProductionInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cInfoS;
        }

        #endregion

        #region Error Information Table

        public int GetLastCycleID(string sProjectID, string sGroupKey)
        {
            int iCycleID = -1;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE " + "sProjectID = '" + sProjectID + 
                                                   "' AND sGroupKey = '" + sGroupKey + "' ORDER BY iCycleID DESC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                        iCycleID = (int)dbSet.Tables[0].Rows[0][2];
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return iCycleID;
        }

        public DateTime GetFirstCycleStartTime(string sProjectID, int iZeroIndex)
        {
            DateTime dtStartTime = DateTime.MinValue;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            decimal nTime = 0;

            string sQuery = @"SELECT * FROM PLCMS.tblCycleInfo WHERE " + "sProjectID = '" + sProjectID +
                                                   "' AND iCycleID = '0' ORDER BY iCycleID DESC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                    {
                        if (dbSet.Tables[0].Rows.Count - 1 > iZeroIndex)
                        {
                            nTime = (decimal) dbSet.Tables[0].Rows[iZeroIndex][4];
                            dtStartTime = CLogUtil.ToDateTime(nTime);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return dtStartTime;
        }

        public CErrorInfoS GetErrorInfoS(List<int> lstErrorID)
        {
            if (lstErrorID.Count == 0)
                return null;

            CErrorInfoS cErrorInfoS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblErrorInfo WHERE "
                             + "iErrorID IN (";

            string sTemp = string.Empty;

            for(int i = 0 ; i < lstErrorID.Count ; i++)
            {
                if(i == lstErrorID.Count - 1)
                    sTemp = string.Format("'{0}');", lstErrorID[i]);
                else
                    sTemp = string.Format("'{0}', ", lstErrorID[i]);

                sQuery += sTemp;
            }

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cErrorInfoS = DataSetToErrorInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cErrorInfoS;
        }

        public CErrorInfoS GetErrorInfoS(string sProjectID)
        {
            if (sProjectID == "")
                return null;

            CErrorInfoS cErrorInfoS = null;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblErrorInfo WHERE "
                             + "sProjectID IN (";

            string sTemp = string.Format("'{0}');", sProjectID);
            sQuery += sTemp;
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cErrorInfoS = DataSetToErrorInfoS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cErrorInfoS;
        }

        public int GetLastErrorInfoID(string sProjectID)
        {
            int iErrorID = -1;
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblErrorInfo WHERE sProjectID IN (" + string.Format("'{0}')", sProjectID) + "ORDER BY iErrorID DESC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                        iErrorID = (int)dbSet.Tables[0].Rows[0][3];
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return iErrorID;
        }

        public List<string> GetUsedProjectIDList()
        {
            List<string> lstResult = new List<string>();
            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;

            string sQuery = @"SELECT * FROM PLCMS.tblErrorInfo ORDER BY sProjectID DESC;";

            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    if (dbSet != null && dbSet.Tables.Count > 0 && dbSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                            lstResult.Add((string)dbSet.Tables[0].Rows[0][1]);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                //Reconnect();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return lstResult;
        }

        #endregion

        #region Error Log Table

        public CTimeLogS GetErrorLogS(int iErrorID)
        {
            CTimeLogS cLogS = null;

            DataSet dbSet = null;
            MySqlDataAdapter dbAdapter = null;
            string sQuery = @"SELECT * FROM PLCMS.tblErrorLog WHERE "
                                            + "iErrorID = " + iErrorID + " ORDER BY cTime ASC;";
            try
            {
                if (m_bConnected)
                {
                    dbAdapter = new MySqlDataAdapter(sQuery, m_dbCon);
                    dbSet = new DataSet();
                    dbAdapter.Fill(dbSet);

                    cLogS = DataSetToErrorLogS(dbSet);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }

                if (dbSet != null)
                {
                    dbSet.Clear();
                    dbSet.Dispose();
                    dbSet = null;
                }
            }

            return cLogS;
        }

        #endregion

        #endregion


        #region Private Methods

        private CTimeLogS DataSetToTimeLogS(DataSet dbSet)
        {
            CTimeLogS cLogS = null;

            try
            {
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    cLogS = new CTimeLogS();

                    CTimeLog cLog;
                    decimal nTime;
                    for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                    {
                        cLog = new CTimeLog();

                        nTime = (decimal)dbSet.Tables[0].Rows[i][0];

                        cLog.Time = CLogUtil.ToDateTime(nTime);
                        cLog.Key = (string)dbSet.Tables[0].Rows[i][1];
                        cLog.Value = int.Parse( (string)dbSet.Tables[0].Rows[i][2] );
                        cLog.Parent = (string)dbSet.Tables[0].Rows[i][3];

                        cLogS.Add(cLog);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                if (cLogS != null)
                    cLogS.Clear();

                cLogS = null;
            }

            return cLogS;
        }

        private CTimeLogS DataSetToErrorLogS(DataSet dbSet)
        {
            CTimeLogS cLogS = null;

            try
            {
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    cLogS = new CTimeLogS();

                    CTimeLog cLog;
                    decimal nTime;
                    for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                    {
                        cLog = new CTimeLog();

                        nTime = (decimal)dbSet.Tables[0].Rows[i][1];

                        cLog.Time = CLogUtil.ToDateTime(nTime);
                        cLog.Key = (string)dbSet.Tables[0].Rows[i][2];
                        cLog.Value = int.Parse((string)dbSet.Tables[0].Rows[i][3]);
                        cLog.Parent = (string)dbSet.Tables[0].Rows[i][4];

                        cLogS.Add(cLog);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                if (cLogS != null)
                    cLogS.Clear();

                cLogS = null;
            }

            return cLogS;
        }

        private CGroupLogS DataSetToGroupLogS(DataSet dbSet)
        {
            CGroupLogS cLogS = null;

            if (dbSet != null && dbSet.Tables.Count > 0)
            {
                cLogS = new CGroupLogS();

                CGroupLog cLog;
                decimal nTime;
                for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                {
                    cLog = new CGroupLog();
                    nTime = (decimal)dbSet.Tables[0].Rows[i][0];
                    cLog.CycleStart = CLogUtil.ToDateTime(nTime);
                    nTime = (decimal)dbSet.Tables[0].Rows[i][1];
                    cLog.CycleEnd = CLogUtil.ToDateTime(nTime);
                    cLog.Key = (string)dbSet.Tables[0].Rows[i][2].ToString().Trim();
                    cLog.Product = (string)dbSet.Tables[0].Rows[i][3].ToString().Trim();
                    cLog.Recipe = (string)dbSet.Tables[0].Rows[i][4].ToString().Trim();
                    cLog.StateType = CLogUtil.ToGroupStateType((string)dbSet.Tables[0].Rows[i][5].ToString().Trim());
                    cLog.MonitorType = CLogUtil.ToMonitorType((string)dbSet.Tables[0].Rows[i][6].ToString().Trim());
                    cLogS.Add(cLog);
                }
            }

            return cLogS;
        }

        private CSystemLogS DataSetToSystemLogS(DataSet dbSet)
        {
            CSystemLogS cLogS = null;

            if (dbSet != null && dbSet.Tables.Count > 0)
            {
                cLogS = new CSystemLogS();

                CSystemLog cLog;
                decimal nTime;
                for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                {
                    nTime = (decimal)dbSet.Tables[0].Rows[i][0];
                    cLog = new CSystemLog();
                    cLog.Time = CLogUtil.ToDateTime(nTime);
                    cLog.StateType = (string)dbSet.Tables[0].Rows[i][1];

                    cLogS.Add(cLog);
                }
            }

            return cLogS;
        }

        private CErrorInfoS DataSetToErrorInfoS(DataSet dbSet)
        {
            CErrorInfoS cErrorInfoS = null;

            try
            {
                cErrorInfoS = new CErrorInfoS();

                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    CErrorInfo cErrorInfo;
                    decimal nTime;
                    decimal nCompare = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss.fff"));

                    for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                    {
                        cErrorInfo = new CErrorInfo();
                        cErrorInfo.ProjectID = (string)dbSet.Tables[0].Rows[i][0];
                        cErrorInfo.GroupKey = (string)dbSet.Tables[0].Rows[i][1];
                        cErrorInfo.CycleID = (int)dbSet.Tables[0].Rows[i][2];
                        cErrorInfo.ErrorID = (int)dbSet.Tables[0].Rows[i][3];
                        cErrorInfo.ErrorType = (string)dbSet.Tables[0].Rows[i][4];
                        cErrorInfo.SymbolKey = (string) dbSet.Tables[0].Rows[i][5];
                        cErrorInfo.Value = (int)dbSet.Tables[0].Rows[i][6];

                        nTime = (decimal)dbSet.Tables[0].Rows[i][7];
                        if (nTime != nCompare)
                            cErrorInfo.ErrorTime = CLogUtil.ToDateTime(nTime);

                        nTime = (decimal)dbSet.Tables[0].Rows[i][8];
                        if (nTime != nCompare)
                            cErrorInfo.CycleStart = CLogUtil.ToDateTime(nTime);

                        cErrorInfo.DetailErrorMessage = (string)dbSet.Tables[0].Rows[i][9];
                        cErrorInfo.CurrentRecipe = (string)dbSet.Tables[0].Rows[i][10];
                        cErrorInfo.InputSymbolKey = (string)dbSet.Tables[0].Rows[i][11];
                        cErrorInfo.AbnormalSymbolKey = (string) dbSet.Tables[0].Rows[i][12];
                        cErrorInfo.CoilKey = (string)dbSet.Tables[0].Rows[i][13];
                        cErrorInfo.ErrorMessage = (string)dbSet.Tables[0].Rows[i][14];
                        cErrorInfo.IsVisible = (bool)dbSet.Tables[0].Rows[i][15];
                        cErrorInfoS.Add(cErrorInfo);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                cErrorInfoS = null;
            }

            return cErrorInfoS;
        }

        private CCycleInfoS DataSetToCycleInfoS(DataSet dbSet)
        {
            CCycleInfoS cCycleInfoS = null;

            try
            {
                cCycleInfoS = new CCycleInfoS();

                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    CCycleInfo cCycleInfo;
                    decimal nTime;
                    decimal nCompare = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss.fff"));

                    for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                    {
                        cCycleInfo = new CCycleInfo();
                        cCycleInfo.ProjectID = (string)dbSet.Tables[0].Rows[i][0];
                        cCycleInfo.GroupKey = (string)dbSet.Tables[0].Rows[i][1];
                        cCycleInfo.CycleID = (int)dbSet.Tables[0].Rows[i][2];
                        cCycleInfo.CycleType = CLogUtil.ToCycleRunType((string)dbSet.Tables[0].Rows[i][3]);
                        cCycleInfo.CurrentRecipe = (string) dbSet.Tables[0].Rows[i][4];
                        nTime = (decimal)dbSet.Tables[0].Rows[i][5];
                        if (nTime != nCompare)
                            cCycleInfo.CycleStart = CLogUtil.ToDateTime(nTime);
                        nTime = (decimal)dbSet.Tables[0].Rows[i][6];
                        if (nTime != nCompare)
                            cCycleInfo.CycleEnd = CLogUtil.ToDateTime(nTime);
                        cCycleInfo.CycleTimeValue = ToTimeSpan((decimal)dbSet.Tables[0].Rows[i][7]);
                        cCycleInfo.TactTimeValue = ToTimeSpan((decimal)dbSet.Tables[0].Rows[i][8]);
                        cCycleInfo.IdleTimeValue = ToTimeSpan((decimal)dbSet.Tables[0].Rows[i][9]);

                        if (cCycleInfoS.ContainsKey(cCycleInfo.CycleID) == false)
                            cCycleInfoS.Add(cCycleInfo.CycleID, cCycleInfo);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                cCycleInfoS = null;
            }

            return cCycleInfoS;
        }

        private CProductionInfoS DataSetToProductionInfoS(DataSet dbSet)
        {
            CProductionInfoS cInfoS = null;

            try
            {
                cInfoS = new CProductionInfoS();

                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    CProductionInfo cInfo;
                    decimal nTime;
                    decimal nCompare = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
                    string sTemp = string.Empty;

                    for (int i = 0; i < dbSet.Tables[0].Rows.Count; i++)
                    {
                        cInfo = new CProductionInfo();
                        cInfo.TeamName = (string)dbSet.Tables[0].Rows[i][1];
                        cInfo.TargetCount = (int)dbSet.Tables[0].Rows[i][2];
                        cInfo.TagKey = (string)dbSet.Tables[0].Rows[i][3];
                        nTime = (decimal) dbSet.Tables[0].Rows[i][4];
                        if (nTime != nCompare)
                            cInfo.ProductionTime = CLogUtil.ToDateTime(nTime);
                        sTemp = (string) dbSet.Tables[0].Rows[i][5];
                        cInfo.UPH = Convert.ToDouble(sTemp);
                        cInfo.CurrentCount = (int) dbSet.Tables[0].Rows[i][6];
                        cInfo.CurrentRecipe = (string) dbSet.Tables[0].Rows[i][7];

                        if (!cInfoS.Contains(cInfo))
                            cInfoS.Add(cInfo);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                cInfoS = null;
            }

            return cInfoS;
        }

        private TimeSpan ToTimeSpan(decimal nTime)
        {
            TimeSpan tsTime = TimeSpan.MinValue;
            try
            {
                //tsTime = TimeSpan.ParseExact(nTime.ToString(), @"mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                tsTime = TimeSpan.FromSeconds((double)nTime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tsTime;
        }

        #endregion

    }


}
