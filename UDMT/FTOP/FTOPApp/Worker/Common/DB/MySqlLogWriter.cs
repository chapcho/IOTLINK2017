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
    class MySqlLogWriter
    {

        protected bool m_bConnected = false;
        protected MySqlConnection m_dbCon = null;
        protected string m_sConnServer = @"DATA SOURCE=localhost;PORT=3306;INITIAL CATALOG=PLCMS;USER ID=root;PASSWORD=udmt;charset=utf8";
        // delegate string deleKeyAddressBracket(string sKey);

        public MySqlLogWriter()
        {

        }

        public void Dispose()
        {

        }


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

        #region DB Schema

        public bool CreateDB()
        {
            DropDataBase();

            MySqlConnection dbConn = null;
            MySqlCommand dbComm = null;

            bool bOK = true;

            string sConnServer = "DATA SOURCE=localhost;USER ID=root;PASSWORD=udmt;";
            string sQueryCreateDataBase = @"CREATE DATABASE IF NOT EXISTS PLCMS default character set utf8;";
            string sQueryUseDataBase = @"USE PLCMS;";
            string sQueryCreateSymbolLogTable = @"CREATE TABLE tblTimeLog
                                                (
                                                    cTime DECIMAL(17,3) NOT NULL,
                                                    cKey VARCHAR(100) NOT NULL,                                                    
                                                    cValue VARCHAR(100) NOT NULL,
                                                    cParent VARCHAR(100) NOT NULL
                                                );";

            
            
            string sQueryCreateGroupLogTable = @"CREATE TABLE tblGroupLog
                                                (
                                                    cStartTime DECIMAL(17,3) NOT NULL, 
                                                    cEndTime DECIMAL(17,3) NOT NULL, 
                                                    cKey VARCHAR(50) NOT NULL,
                                                    cProduct VARCHAR(50),
                                                    cRecipe VARCHAR(50),
                                                    cStateType VARCHAR(50),
                                                    cMonitorMode VARCHAR(20),
                                                    Note VARCHAR(100)
                                                );";

            // 구현 : 조회(O), 수정(O), 삭제(X)
            // 
            string sQueryCreateMonitorHistory = @"CREATE TABLE tbaMntrHist
                                                (
                                                    cStartTime DECIMAL(17,3) NOT NULL, 
                                                    cEndTime DECIMAL(17,3) NOT NULL, 
                                                    cKey VARCHAR(50) NOT NULL,
                                                    cProduct VARCHAR(50) NULL,
                                                    cRecipe VARCHAR(50) NULL,
                                                    cMonitorMode VARCHAR(20),
                                                    fstUpdDt DECIMAL(17,3) NULL,
                                                    fnlUpdDt DECIMAL(17,3) NULL,
                                                    fnlUpder VARCHAR(200) NULL,
                                                    clrDt DECIMAL(17,3) NULL, 
                                                    errCode VARCHAR(20)  NULL,
                                                    errDesc VARCHAR(500) NULL,
                                                    mntrNote VARCHAR(500) NULL,
                                                    PRIMARY KEY (cStartTime,cKey)
                                                );";

            string sQueryCreateCycleInfo = @"CREATE TABLE tblCycleInfo
                                                (
                                                    sProjectID VARCHAR(10) NOT NULL,
                                                    sGroupKey VARCHAR(50) NOT NULL,
                                                    iCycleID INT NOT NULL,
                                                    sCycleType VARCHAR(50) NOT NULL,
                                                    sCurrentRecipe VARCHAR(50) NULL,
                                                    dtCycleStart DECIMAL(17,3) NOT NULL,
                                                    dtCycleEnd DECIMAL(17,3) NOT NULL,
                                                    nCycleTime DECIMAL(17,3) NOT NULL,
                                                    nTactTime DECIMAL(17,3) NOT NULL,
                                                    nIdleTime DECIMAL(17,3) NOT NULL,
                                                    PRIMARY KEY (sGroupKey, dtCycleStart)
                                                );";

            string sQueryCreatProductionInfo = @"CREATE TABLE tblProductionInfo
                                                (
                                                    sProjectID VARCHAR(10) NOT NULL,
                                                    sTeamName VARCHAR(50) NOT NULL,
                                                    iTargetCount INT NOT NULL,
                                                    sTagkey VARCHAR(50) NOT NULL,
                                                    dtProductionTime DECIMAL(17,3) NOT NULL,
                                                    dUPH VARCHAR(10) NOT NULL,
                                                    iCurrentCount INT NOT NULL,
                                                    sCurrentRecipe VARCHAR(50) NOT NULL,
                                                    PRIMARY KEY (sTeamName, dtProductionTime)
                                                );";

            string sQueryCreateErrorInfo = @"CREATE TABLE tblErrorInfo
                                                (
                                                    sProjectID VARCHAR(10) NOT NULL,
                                                    sGroupKey VARCHAR(50) NOT NULL,
                                                    iCycleID INT NOT NULL,
                                                    iErrorID INT NOT NULL,
                                                    sErrorType VARCHAR(50) NOT NULL,
                                                    sSymbolKey VARCHAR(50) NOT NULL,
                                                    iValue INT NOT NULL,
                                                    dtErrorTime DECIMAL(17,3) NOT NULL,
                                                    dtCycleStart DECIMAL(17,3) NOT NULL,
                                                    sDetailErrorMessage VARCHAR(100) NOT NULL,
                                                    sRecipe VARCHAR(50) NOT NULL,
                                                    sInputSymbolKeyList VARCHAR(500) NOT NULL,
                                                    sAbnormalSymbolKey VARCHAR(100) NOT NULL,
                                                    sCoilKey VARCHAR(50),
                                                    sErrorMessage VARCHAR(50) NOT NULL,
                                                    IsVisible BOOL NOT NULL,
                                                    PRIMARY KEY (iErrorID, dtErrorTime, sSymbolKey)
                                                );";

            string sQueryCreateErrorLogTable = @"CREATE TABLE tblErrorLog
                                                (
                                                    iErrorID INTEGER NOT NULL,
                                                    cTime DECIMAL(17,3) NOT NULL,
                                                    cKey VARCHAR(100) NOT NULL,                                                    
                                                    cValue VARCHAR(100) NOT NULL,
                                                    cParent VARCHAR(100) NOT NULL
                                                );";

            string sQueryCreateSystemLogTable = @"CREATE TABLE tblSystemLog
                                                (
                                                    cTime DECIMAL(17,3) NOT NULL,
                                                    cState INT NOT NULL
                                                );";
            // Index 생성 추가 ijsong 2015.04.10
            string sQueryCreateSymbolLogIndex = @"CREATE INDEX idx_tblTimeLog_cTime on PLCMS.tblTimeLog(cTime);";
            string sQueryCreateGroupLogIndex = @"CREATE INDEX idx_tblGroupLog_cTime on PLCMS.tblGroupLog(cKey,cStartTime);";
            string sQueryCreateSystemLogIndex = @"CREATE INDEX idx_tblSystemLog_cTime on PLCMS.tblSystemLog(cTime);";

            try
            {
                dbConn = new MySqlConnection(sConnServer);
                dbConn.Open();

                dbComm = new MySqlCommand();

                dbComm.Connection = dbConn;

                dbComm.CommandText = sQueryCreateDataBase;
                dbComm.ExecuteNonQuery();

                dbComm.CommandText = sQueryUseDataBase;
                dbComm.ExecuteNonQuery();

                dbComm.CommandText = sQueryCreateSymbolLogTable;
                dbComm.ExecuteNonQuery();

                dbComm.CommandText = sQueryCreateGroupLogTable;
                dbComm.ExecuteNonQuery();

                dbComm.CommandText = sQueryCreateSystemLogTable;
                dbComm.ExecuteNonQuery();
                
                // ijsong@udmtek 2016.01.07 모니터링 장애 이력
                dbComm.CommandText = sQueryCreateMonitorHistory;
                dbComm.ExecuteNonQuery();

                // Index 생성 추가 ijsong 2015.04.10
                dbComm.CommandText = sQueryCreateSymbolLogIndex;
                dbComm.ExecuteNonQuery();
                dbComm.CommandText = sQueryCreateGroupLogIndex;
                dbComm.ExecuteNonQuery();
                dbComm.CommandText = sQueryCreateSystemLogIndex;
                dbComm.ExecuteNonQuery();

                dbComm.CommandText = sQueryCreateCycleInfo;
                dbComm.ExecuteNonQuery();

                //Error Information/Log Table 추가 2016.01.15 Park Jun Pyo

                dbComm.CommandText = sQueryCreateErrorInfo;
                dbComm.ExecuteNonQuery();
                dbComm.CommandText = sQueryCreateErrorLogTable;
                dbComm.ExecuteNonQuery();

                //Production 정보 저장 Table 추가 PJP
                dbComm.CommandText = sQueryCreatProductionInfo;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;

            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }

                if (dbConn != null)
                {
                    if (dbConn.State == ConnectionState.Open)
                        dbConn.Close();

                    dbConn.Dispose();
                    dbConn = null;
                }

            }

            return bOK;
        }

        public bool DropDataBase()
        {
            MySqlConnection dbCon = null;
            MySqlCommand dbComm = null;

            bool bOK = true;

            string sConnServer = "DATA SOURCE=localhost;USER ID=root;PASSWORD=udmt;";
            string sQueryDropDataBase = @"DROP DATABASE PLCMS;";

            try
            {
                dbCon = new MySqlConnection(sConnServer);
                dbComm = new MySqlCommand();

                dbCon.Open();

                dbComm.Connection = dbCon;

                dbComm.CommandText = sQueryDropDataBase;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;

            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }

                if (dbCon != null)
                {
                    dbCon.Close();
                    dbCon = null;
                }
            }

            return bOK;
        }

        #endregion

        #region Time Log Table

        public bool WriteTimeLogS(CTimeLogS cLogS)
        {
            if (cLogS == null)
                return false;

            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            try
            {
                if (m_bConnected)
                {
                    sQuery = @"INSERT INTO PLCMS.tblTimeLog VALUES ";

                    CTimeLog cLog;
                    for (int i = 0; i < cLogS.Count; i++)
                    {
                        cLog = cLogS[i];

                        sDataSet = @"("
                                        + ToTimeString(cLog.Time) + ",'"
                                        + cLog.Key + "',"                                        
                                        + cLog.Value.ToString() + ",'"
                                        + cLog.Parent + "')";

                        if (i < cLogS.Count - 1)
                            sQuery += sDataSet + " , ";
                        else
                            sQuery += sDataSet;
                    }

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        public bool ClearTimeLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblTimeLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = m_dbCon;
                dbComm.CommandText = sQuery;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return true;
        }

        #endregion

        #region Group Log Table

        public bool WriteGroupLog(CGroupLog cLog)
        {
            bool bOK = false;

            MySqlCommand dbComm = null;

            try
            {
                if (m_bConnected)
                {
                    string sQuery = @"INSERT INTO PLCMS.tblGroupLog VALUES ("
                                              + ToTimeString(cLog.CycleStart) + ","
                                              + ToTimeString(cLog.CycleEnd) + ",'"
                                              + cLog.Key + "','"
                                              + cLog.Product + "','"
                                              + cLog.Recipe + "','"
                                              + cLog.StateType.ToString() + "','"
                                              + cLog.MonitorType.ToString() + "','"
                                              + cLog.Note + "');";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            if (cLog.StateType == EMGroupStateType.Error || cLog.StateType == EMGroupStateType.ErrorEnd)
            {
                WriteMonitoringHistLog(cLog);
            }

            return bOK;
        }

        public bool WriteMonitoringHistLog(CGroupLog cLog)
        {
            bool bOK = false;

            MySqlCommand dbComm = null;

            try
            {
                if (m_bConnected)
                {
                    string sQuery = @"INSERT INTO PLCMS.tbaMntrHist(cStartTime,cEndTime,cKey,cProduct,cRecipe,cMonitorMode,fstUpdDt,fnlUpdDt,fnlUpder) VALUES ('"
                                                  + ToTimeString(cLog.CycleStart) + "','"
                                                  + ToTimeString(cLog.CycleEnd) + "','"
                                                  + cLog.Key + "','"
                                                  + cLog.Product + "','"
                                                  + cLog.Recipe + "','"
                                                  + cLog.MonitorType.ToString() + "','"
                                                  + ToTimeString(DateTime.Now) + "','"
                                                  + ToTimeString(DateTime.Now) + "','"
                                                  + "tracker" + "');";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        public bool ClearGroupLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM PLCMS.tblGroupLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = m_dbCon;
                dbComm.CommandText = sQuery;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return true;
        }

        #endregion

        #region System Log Table

        public bool WriteSystemLog(CSystemLog cLog)
        {
            if (cLog == null)
                return false;

            bool bOK = false;
            MySqlCommand dbComm = null;

            try
            {
                if (m_bConnected)
                {
                    string sQuery = @"INSERT INTO PLCMS.tblSystemLog VALUES ("
                                              + ToTimeString(cLog.Time) + ","
                                              + cLog.StateType.ToString() + ");";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        #endregion

        #region Cycle Information Table

        public bool WriteCycleInfo(CCycleInfo cCycleInfo)
        {
            if (cCycleInfo == null)
                return false;

            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            try
            {
                if (m_bConnected)
                {
                    sQuery = @"INSERT INTO PLCMS.tblCycleInfo VALUES ";

                    sDataSet = @"('" + cCycleInfo.ProjectID + "','"
                                    + cCycleInfo.GroupKey + "','"
                                    + cCycleInfo.CycleID + "','"
                                    + cCycleInfo.CycleType.ToString() + "','"
                                    + cCycleInfo.CurrentRecipe + "','"
                                    + ToTimeString(cCycleInfo.CycleStart) + "','"
                                    + ToTimeString(cCycleInfo.CycleEnd) + "','"
                                    + ToTimeSpanString(cCycleInfo.CycleTimeValue) + "','"
                                    + ToTimeSpanString(cCycleInfo.TactTimeValue) + "','"
                                    + ToTimeSpanString(cCycleInfo.IdleTimeValue) + "')";

                    sQuery += sDataSet;

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        #endregion

        #region Production Information Table

        public bool WriteProductionInfo(CProductionInfo cProductionInfo, string sProjectID)
        {
            if (cProductionInfo == null)
                return false;

            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            try
            {
                if (m_bConnected)
                {
                    sQuery = @"INSERT INTO PLCMS.tblProductionInfo VALUES ";

                    sDataSet = @"('" + sProjectID + "','"
                               + cProductionInfo.TeamName + "','"
                               + cProductionInfo.TargetCount + "','"
                               + cProductionInfo.TagKey + "','"
                               + ToTimeString(cProductionInfo.ProductionTime) + "','"
                               + cProductionInfo.UPH.ToString() + "','"
                               + cProductionInfo.CurrentCount + "','"
                               + cProductionInfo.CurrentRecipe + "')";

                    sQuery += sDataSet;

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        public bool ClearProductionInfoS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblProductionInfo;";

                dbComm = new MySqlCommand();
                dbComm.Connection = m_dbCon;
                dbComm.CommandText = sQuery;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return true;
        }

        #endregion

        #region Error Information Table

        public bool WriteErrorInfo(CErrorInfo cErrorInfo)
        {
            if (cErrorInfo == null)
                return false;

            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            try
            {
                if (m_bConnected)
                {
                    sQuery = @"INSERT INTO PLCMS.tblErrorInfo VALUES ";

                    sDataSet = @"('" + cErrorInfo.ProjectID + "','" 
                                    + cErrorInfo.GroupKey + "','"
                                    + cErrorInfo.CycleID+ "','" 
                                    + cErrorInfo.ErrorID + "','"
                                    + cErrorInfo.ErrorType + "','"
                                    + cErrorInfo.SymbolKey + "','"
                                    + cErrorInfo.Value.ToString() + "','" 
                                    + ToTimeString(cErrorInfo.ErrorTime) + "','"
                                    + ToTimeString(cErrorInfo.CycleStart) + "','"
                                    + cErrorInfo.DetailErrorMessage + "','"
                                    + cErrorInfo.CurrentRecipe + "','"
                                    + cErrorInfo.InputSymbolKey + "','"
                                    + cErrorInfo.AbnormalSymbolKey + "','"
                                    + cErrorInfo.CoilKey + "','"
                                    + cErrorInfo.ErrorMessage + "','"
                                    + (cErrorInfo.IsVisible == true? 1 : 0) + "')";

                    sQuery += sDataSet;

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        public bool ClearErrorInfoS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblErrorInfo;";

                dbComm = new MySqlCommand();
                dbComm.Connection = m_dbCon;
                dbComm.CommandText = sQuery;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return true;
        }

        #endregion

        #region Error Log Table

        public bool WriteErrorLogS(int iErrorID, CTimeLogS cLogS)
        {
            if (cLogS == null)
                return false;

            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            try
            {
                if (m_bConnected)
                {
                    sQuery = @"INSERT INTO PLCMS.tblErrorLog VALUES ";

                    CTimeLog cLog;
                    for (int i = 0; i < cLogS.Count; i++)
                    {
                        cLog = cLogS[i];

                        sDataSet = @"("
                                        + iErrorID + ","
                                        + ToTimeString(cLog.Time) + ",'"
                                        + cLog.Key + "',"
                                        + cLog.Value.ToString() + ",'"
                                        + cLog.Parent + "')";

                        if (i < cLogS.Count - 1)
                            sQuery += sDataSet + " , ";
                        else
                            sQuery += sDataSet;
                    }

                    dbComm = new MySqlCommand();
                    dbComm.Connection = m_dbCon;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                bOK = false;
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return bOK;
        }

        public bool ClearErrorLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblErrorLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = m_dbCon;
                dbComm.CommandText = sQuery;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbComm != null)
                {
                    dbComm.Dispose();
                    dbComm = null;
                }
            }

            return true;
        }

        #endregion

        #endregion


        #region Private Methods

        private DateTime ToDateTime(decimal nTime)
        {
            DateTime dtTime = DateTime.MinValue;

            try
            {
                dtTime = DateTime.ParseExact(nTime.ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return dtTime;
        }

        private string ToTimeString(DateTime dtTime)
        {
            return dtTime.ToString("yyyyMMddHHmmss.fff");
        }

        
        private string ToTimeSpanString(TimeSpan dtTime)
        {
            return dtTime.TotalSeconds.ToString("#.000");
        }
        #endregion
    }
}
