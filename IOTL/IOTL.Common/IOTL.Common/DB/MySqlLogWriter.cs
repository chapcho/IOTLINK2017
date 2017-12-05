using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using IOTL.Common.Log;
using IOTL.Common.Framework;


namespace IOTL.Common.DB
{

    public class MySqlLogWriter : IDisposable
    {
        private ConfigMariaDB dbConnectionInfo;
        private int iTagStatusIndex = 0;
        private MySqlLogReader objDBReader = new MySqlLogReader();
        public event UEventHandlerFileLog UEventFileLog = null;

        #region Member Variables

        protected bool dbConnected = false;
        protected bool m_bDatabaseCheck = false;
        protected string m_sProjectName = null;
        protected MySqlConnection dbConnection = null;

        // protected string dbConnectionString = @"DATA SOURCE=localhost;PORT=3306;INITIAL CATALOG=IOTLINK;USER ID=root;PASSWORD=iotl;charset=utf8";
        // delegate string deleKeyAddressBracket(string sKey);
        #endregion


        #region Intialize/Dispose

        public MySqlLogWriter()
        {
            dbConnectionInfo = new ConfigMariaDB();
        }

        public MySqlLogWriter(string databaseName)
        {
            dbConnectionInfo = new ConfigMariaDB();
            dbConnectionInfo.InitialDatabaseName = databaseName;
        }

        public MySqlLogWriter(ConfigMariaDB connectionInfo)
        {
            dbConnectionInfo = connectionInfo;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool IsConnected
        {
            get { return dbConnected; }
        }

        #endregion


        #region Public Methods

        #region DB Connection

        public string GetConnectionString()
        {
            return dbConnectionInfo.GetDBConnectionString();
        }

        public bool Connect()
        {
            bool bOK = true;

            try
            {
                if (dbConnection == null)
                {
                    dbConnection = new MySqlConnection(dbConnectionInfo.GetDBConnectionString());
                    dbConnection.Open();
                    dbConnected = true;

                }
                else if (dbConnection.State == ConnectionState.Closed || dbConnection.State == ConnectionState.Broken)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                    dbConnection = null;

                    dbConnection = new MySqlConnection(dbConnectionInfo.GetDBConnectionString());
                    dbConnection.Open();
                    dbConnected = true;

                }
            }
            catch (System.Exception ex)
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
                dbConnected = false;

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
                if (dbConnection != null)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                    dbConnection = null;

                    dbConnected = false;
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


        /// <summary>
        /// 테이블 생성을 위한 순서를 위한  Enumerate
        /// </summary>
        public enum EMIotlinkDBTable
        {
            CREATEIOTLINKDB = 0,
            USEIOTLINKDB = 1,
            EnumDef = 2,
            EnumDefValue,
            MachineInfo,
            MachineState,
            MachineStateLog,
            Manager,
            MachineManager,
            spUpdateMachineState,
        }


        /// <summary>
        /// 모니터링에 필요한 테이블을 생성합니다.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetTableCreateScript(string tableName)
        {
            string generatedSQL;

            switch(tableName.ToUpper())
            {
                case "ENUMDEF":
                    generatedSQL = @"CREATE TABLE EnumDef
                                                (
                                                    EnumName VARCHAR(50) NOT NULL,
                                                    Description VARCHAR(200) NULL,                                                    
                                                    AccessType VARCHAR(10) NULL,
                                                    Purpose VARCHAR(100) NULL,
                                                    ConstantFlag VARCHAR(100) NULL,
                                                    PRIMARY KEY (EnumName)
                                                );";
                    break;
                case "ENUMDEFVALUE":
                    generatedSQL = @"CREATE TABLE EnumDefValue
                                                (
                                                    EnumName VARCHAR(50) NOT NULL,
                                                    EnumValue VARCHAR(50) NOT NULL,
                                                    Description VARCHAR(200) NULL, 
                                                    DisplayOrder INT NULL,
                                                    DefaultValue VARCHAR(100) NULL,
                                                    DisplayColor VARCHAR(20) NULL,
                                                    AdditionalValue VARCHAR(100) NULL,
                                                    PRIMARY KEY (EnumName, EnumValue),
                                                    CONSTRAINT EnumDefValue_FK_EnumName FOREIGN KEY(EnumName) REFERENCES ENUMDEF(EnumName) ON DELETE RESTRICT
                                                );";
                    break;
                case "MACHINEINFO":
                    generatedSQL = @"CREATE TABLE MachineInfo
                                                (
                                                    MachineName VARCHAR(50) NOT NULL,
                                                    Description VARCHAR(200) NULL,
                                                    CreateTime DECIMAL(17,3) NULL,
                                                    UpdateTime DECIMAL(17,3) NULL,
                                                    CreateUser VARCHAR(100) NULL,
                                                    UpdateUser VARCHAR(100) NULL,
                                                    UpdateReason VARCHAR(200) NULL,
                                                    PRIMARY KEY(MachineName)
                                                );";
                    break;
                case "MACHINESTATE":
                    generatedSQL = @"CREATE TABLE MachineState
                                                (
                                                    MachineName VARCHAR(50) NOT NULL,
                                                    LastEventTime VARCHAR(18) NULL,
                                                    CurState VARCHAR(10) NULL,
                                                    MachineData VARCHAR(200) NULL,
                                                    Updated DECIMAL(17,3) NULL,
                                                    Description VARCHAR(200) NULL, 
                                                    PRIMARY KEY (MachineName),
                                                    CONSTRAINT MachineState_FK_MachineName FOREIGN KEY(MachineName) REFERENCES MACHINEINFO(MachineName) ON DELETE RESTRICT
                                                );";
                    break;
                case "MACHINESTATELOG":
                    generatedSQL = @"CREATE TABLE MachineStateLog
                                                (
                                                    MachineName VARCHAR(50) NOT NULL,
                                                    LastEventTime VARCHAR(18) NOT NULL,
                                                    CurState VARCHAR(10) NULL,
                                                    MachineData VARCHAR(200) NULL,
                                                    Updated DECIMAL(17,3) NULL,
                                                    Description VARCHAR(200) NULL, 
                                                    PRIMARY KEY (MachineName,LastEventTime)
                                                );";
                    break;
                case "MANAGER":
                    generatedSQL = @"CREATE TABLE Manager
                                                (
                                                    ManagerID VARCHAR(50) NOT NULL,
                                                    ManagerName VARCHAR(200) NULL,
                                                    ManagerPhoneNo VARCHAR(50) NULL,
                                                    ManagerEmail VARCHAR(50) NULL,
                                                    Updated DECIMAL(17,3) NULL,
                                                    Description VARCHAR(200) NULL, 
                                                    PRIMARY KEY (ManagerID)
                                                );";
                    break;
                case "MACHINEMANAGER":
                    generatedSQL = @"CREATE TABLE MachineManager
                                                (
                                                    ManagerID VARCHAR(50) NOT NULL,
                                                    MachineName VARCHAR(50) NOT NULL, 
                                                    Description VARCHAR(200) NULL,
                                                    CreateTime DECIMAL(17,3) NULL,
                                                    UpdateTime DECIMAL(17,3) NULL,
                                                    CreateUser VARCHAR(100) NULL,
                                                    UpdateUser VARCHAR(100) NULL,
                                                    UpdateReason VARCHAR(200) NULL,
                                                    PRIMARY KEY (ManagerID,MachineName),
                                                    CONSTRAINT MachineManager_FK_ManagerId FOREIGN KEY(ManagerID) REFERENCES Manager(ManagerID) ON DELETE RESTRICT,
                                                    CONSTRAINT MachineManager_FK_MachineName FOREIGN KEY(MachineName) REFERENCES MACHINEINFO(MachineName) ON DELETE RESTRICT
                                                );";
                    break;
                case "spUPDATEMACHINESTATE": // 프로시져를 스크립트로 생성할때는 Delimeter 를 사용해서 문의 구분이 ; 이 아니라 Delimeter를 만날때까지 연결된다는 것을 알려야 한다.
                    generatedSQL = @"
                                    DELIMITER $$
                                    CREATE PROCEDURE spUpdateMachineState(IN machineName VARCHAR(50), IN lastEventTime VARCHAR(19), IN curState VARCHAR(10), IN machineData VARCHAR(200), IN updatedDt DECIMAL(17,3), IN description VARCHAR(200))
                                    BEGIN
	                                    INSERT INTO MACHINESTATE(MachineName,LastEventTime,CurState,MachineData,Updated,Description) VALUES(machineName,lastEventTime,curState,machineData,updatedDt,description)
	                                    ON DUPLICATE KEY UPDATE 	LastEventTime = lastEventTime,CurState = curState,MachineData = machineData,Updated = updatedDt,Description = description;

	                                    INSERT INTO MACHINESTATELOG(MachineName,LastEventTime,CurState,MachineData,Updated,Description) VALUES(machineName,lastEventTime,curState,machineData,updatedDt,description);
                                    END$$
                                     ";
                    break;
                case "USEIOTLINKDB":
                    generatedSQL = @"USE IOTLINK;";
                    break;
                case "CREATEIOTLINKDB":
                    generatedSQL = @"CREATE DATABASE IF NOT EXISTS IOTLINK default character set utf8;";
                    break;
                default:
                    generatedSQL = @"USE IOTLINK;";
                    break;
            }

            return generatedSQL;
        }

        public bool CreateIOTLinkTable()
        {
            MySqlConnection dbConn = null;
            MySqlCommand dbComm = null;
            bool bOK = true;


            /// Table  생성순서를 지켜서 생성합니다.
            /// Enum을 활용하면 순서를 강제로 지킬수 있습니다.
            /// 향후 변경하도록 합시다.
            /// 데이터 베이스 삭제 후 재 생성을 하고 있습니다.
            /// EMIotlinkDBTable : 참고...
            string[] arrCommonTables = { "CreateIotlinkDB", "USEIOTLINKDB", "ENUMDEF", "ENUMDEFVALUE" , "MACHINEINFO" , "MACHINESTATE" , "MACHINESTATELOG", "Manager","MachineManager", "spUpdateMachineState" };

            DropDataBase();

            try
            {
                dbConn = new MySqlConnection(dbConnectionInfo.GetServerConnectoinString());
                dbConn.Open();

                dbComm = new MySqlCommand();

                dbComm.Connection = dbConn;

                string sQuery = string.Empty;

                foreach(string query in arrCommonTables)
                {
                    sQuery = GetTableCreateScript(query);

                    Console.WriteLine("ExecuteSQL : [{0}]", sQuery);

                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();
                    
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

        public bool CreateDB()
        {
            

            return CreateIOTLinkTable();

            #region 참고용 테이블 생성 쿼리.
            /*
            MySqlConnection dbConn = null;
            MySqlCommand dbComm = null;

            bool bOK = true;

            string sQueryCreateDataBase = @"CREATE DATABASE IF NOT EXISTS IOTLINK default character set utf8;";
            string sQueryUseDataBase = @"USE IOTLINK;";
            string sQueryCreateSymbolLogTable = @"CREATE TABLE tblTimeLog
                                                (
                                                    cTime DECIMAL(17,3) NOT NULL,
                                                    cKey VARCHAR(100) NOT NULL,                                                    
                                                    cValue VARCHAR(100) NOT NULL,
                                                    cParent VARCHAR(100) NOT NULL
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



            string sQueryCreateLadderLogTable = @"CREATE TABLE tblladdertimelog
                                                (
                                                     sProjectID  VARCHAR(100) NOT NULL,
	                                                 iLadderID  INT(11) NOT NULL,
	                                                 cTime  DECIMAL(17,3) NOT NULL,
	                                                 cKey  VARCHAR(100) NOT NULL,
	                                                 cValue  VARCHAR(100) NOT NULL,
	                                                 cParent  VARCHAR(100) NOT NULL,
	                                                INDEX  idx_tblLadderTimeLog_cTime  (cTime)
                                                );";

            string sQueryCreateTagStatusTable = @"CREATE TABLE tblTagStatus
                                                (
                                                    iIndex INT(11) NOT NULL,
                                                    cItemType VARCHAR(50) NOT NULL,
                                                    cKey VARCHAR(50) NOT NULL,
                                                    cProjectKey VARCHAR(11) NOT NULL,
                                                    dLastTime DECIMAL(17,3) NOT NULL,
                                                    iValue INT(11) NOT NULL,
                                                    iChangedCount INT(11) NOT NULL,
                                                    INDEX idx_tblTagStatus_iIndex (iIndex)
                                                );";



            string sQueryCreateSymbolLogIndex = @"CREATE INDEX idx_tblTimeLog_cTime on IOTLINK.tblTimeLog(cTime);";

            try
            {
                dbConn = new MySqlConnection(dbConnectionInfo.GetServerConnectoinString());
                dbConn.Open();

                dbComm = new MySqlCommand();

                dbComm.Connection = dbConn;

                dbComm.CommandText = sQueryCreateDataBase;
                dbComm.ExecuteNonQuery();

            }

            return bOK;
            */
            #endregion
        }

        public bool DropDataBase()
        {
            MySqlConnection dbCon = null;
            MySqlCommand dbComm = null;

            bool bOK = true;

            string sQueryDropDataBase = @"DROP DATABASE IOTLINK;";

            try
            {
                dbCon = new MySqlConnection(dbConnectionInfo.GetDBConnectionString());
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

        public bool WriteTimeLog(CTimeLog timeLog)
        {
            bool bOK = false;
            MySqlCommand dbComm = null;


            try
            {
                if (dbConnected)
                {
                    CTimeLog cLog = new CTimeLog(timeLog.Key, timeLog.Description);

                    cLog.ReceiveData = timeLog.ReceiveData;

                    // 수신한 클래스의 데이터 내용을 기록하기 좋은 방식으로 변경해야 합니다. 2017.11.25

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
                    // 프로시져를 이용한 업데이트 실행.
                    dbComm.CommandType = CommandType.StoredProcedure;



                    dbComm.CommandText = "iotlink.spUpdateMachineState";
                    dbComm.CommandType = CommandType.StoredProcedure;

                    dbComm.Parameters.Add("machineName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 50);
                    dbComm.Parameters["machineName"].Value = cLog.Key;
                    dbComm.Parameters["machineName"].Direction = ParameterDirection.Input;

                    dbComm.Parameters.Add("lastEventTime", MySql.Data.MySqlClient.MySqlDbType.VarChar, 19);
                    dbComm.Parameters["lastEventTime"].Value = ToTimeString(cLog.LogTime);
                    dbComm.Parameters["lastEventTime"].Direction = ParameterDirection.Input;

                    dbComm.Parameters.Add("curState", MySql.Data.MySqlClient.MySqlDbType.VarChar, 10);
                    dbComm.Parameters["curState"].Value = "Normal";
                    dbComm.Parameters["curState"].Direction = ParameterDirection.Input;

                    StringBuilder sb = new StringBuilder();
                    foreach(byte data in (byte[])cLog.ReceiveData)
                    {
                        sb.Append(data);
                    }

                    dbComm.Parameters.Add("machineData", MySql.Data.MySqlClient.MySqlDbType.VarChar, 200);
                    // dbComm.Parameters["machineData"].Value = cLog.ReceiveData.ReceiveData.ToString();
                    // dbComm.Parameters["machineData"].Value = sb.ToString();
                    dbComm.Parameters["machineData"].Value = cLog.GetReceiveDataToHex();
                    dbComm.Parameters["machineData"].Direction = ParameterDirection.Input;

                    dbComm.Parameters.Add("updatedDt", MySql.Data.MySqlClient.MySqlDbType.Decimal, 17);
                    dbComm.Parameters["updatedDt"].Value = ToTimeString(DateTime.Now);
                    dbComm.Parameters["updatedDt"].Direction = ParameterDirection.Input;

                    dbComm.Parameters.Add("description", MySql.Data.MySqlClient.MySqlDbType.VarChar, 200);
                    dbComm.Parameters["description"].Value = cLog.Description;
                    dbComm.Parameters["description"].Direction = ParameterDirection.Input;

                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);

                UEventFileLog?.Invoke(EMFileLogType.DatabaseLog, EMFileLogDepth.Error, ex.Message);

                ex.Data.Clear();


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
                if (dbConnected)
                {
                    // 한번에 많은 로그를 기록하려면 Insert 문장을 연결해서 기록할 수 있다.
                    // sQuery = @"Insert Into IOTLINK.MachineStateLog VALUES "; 

                    CTimeLog cLog;

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
                    // 프로시져를 이용한 업데이트 실행.
                    dbComm.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < cLogS.Count; i++)
                    {
                        cLog = cLogS[i];

                        // 수신한 데이터
                        
                        StringBuilder sb = new StringBuilder();
                        foreach (byte data in cLog.ReceiveData)
                            sb.Append(data);

                        // MachineName
                        // LastEventTime
                        // CurState
                        // MachineData
                        // UpdateDt
                        // Description

                        sQuery = @"call iotlink.spUpdateMachineState ";
                        sDataSet = @"('"
                                        + cLog.Key + "','"
                                        + ToTimeString(cLog.LogTime) + "','"
                                        + "NORMAL" + "','"
                                        + sb.ToString() + "',"
                                        + ToTimeString(DateTime.Now) + ",'"
                                        + cLog.Description  + "')";

                        sQuery += sDataSet;

                        Console.WriteLine(sQuery);

                        dbComm.CommandText = sQuery;
                        dbComm.ExecuteNonQuery();
                    }

                    bOK = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                UEventFileLog?.Invoke(EMFileLogType.DatabaseLog, EMFileLogDepth.Error, ex.Message);
                ex.Data.Clear();

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

        //public bool WriteOrgTimeLogS(CTimeLogS cLogS)
        //{
        //    if (cLogS == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblTimeLogOptra VALUES ";

        //            CTimeLog cLog;
        //            for (int i = 0; i < cLogS.Count; i++)
        //            {
        //                cLog = cLogS[i];

        //                sDataSet = @"("
        //                                + ToTimeString(cLog.Time) + ",'"
        //                                + cLog.Key + "',"
        //                                + cLog.Value.ToString() + ",'"
        //                                + cLog.Parent + "')";

        //                if (i < cLogS.Count - 1)
        //                    sQuery += sDataSet + " , ";
        //                else
        //                    sQuery += sDataSet;
        //            }

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        public bool ClearTimeLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblTimeLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
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

        public bool ClearTimeLogS(DateTime dtFrom)
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblTimeLog "
                                  + "Where cTime <= " + ToTimeString(dtFrom) + ";";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
                dbComm.CommandText = sQuery;
                dbComm.CommandTimeout = 3600;
                dbComm.ExecuteNonQuery();

                sQuery = @"optimize table IOTLINK.tblTimeLog; analyze table IOTLINK.tblTimeLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
                dbComm.CommandText = sQuery;
                dbComm.CommandTimeout = 60;
                dbComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                UEventFileLog?.Invoke(EMFileLogType.DatabaseLog, EMFileLogDepth.Error, ex.Message);
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

        //public bool WriteGroupLog(CGroupLog cLog)
        //{
        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            string sQuery = @"INSERT INTO PLCMS.tblGroupLog VALUES ("
        //                                      + ToTimeString(cLog.CycleStart) + ","
        //                                      + ToTimeString(cLog.CycleEnd) + ",'"
        //                                      + cLog.Key + "','"
        //                                      + cLog.Product + "','"
        //                                      + cLog.Recipe + "','"
        //                                      + cLog.StateType.ToString() + "','"
        //                                      + cLog.MonitorType.ToString() + "','"
        //                                      + cLog.Note + "');";

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    if (cLog.StateType == EMGroupStateType.Error || cLog.StateType == EMGroupStateType.ErrorEnd)
        //    {
        //        WriteMonitoringHistLog(cLog);
        //    }

        //    return bOK;
        //}

        //public bool WriteMonitoringHistLog(CGroupLog cLog)
        //{
        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            string sQuery = @"INSERT INTO PLCMS.tbaMntrHist(cStartTime,cEndTime,cKey,cProduct,cRecipe,cMonitorMode,fstUpdDt,fnlUpdDt,fnlUpder) VALUES ('"
        //                                          + ToTimeString(cLog.CycleStart) + "','"
        //                                          + ToTimeString(cLog.CycleEnd) + "','"
        //                                          + cLog.Key + "','"
        //                                          + cLog.Product + "','"
        //                                          + cLog.Recipe + "','"
        //                                          + cLog.MonitorType.ToString() + "','"
        //                                          + ToTimeString(DateTime.Now) + "','"
        //                                          + ToTimeString(DateTime.Now) + "','"
        //                                          + "tracker" + "');";

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        public bool ClearGroupLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM IOTLINK.tblGroupLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
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

        //public bool WriteSystemLog(CSystemLog cLog)
        //{
        //    if (cLog == null)
        //        return false;

        //    bool bOK = false;
        //    MySqlCommand dbComm = null;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            string sQuery = @"INSERT INTO PLCMS.tblSystemLog VALUES ("
        //                                      + ToTimeString(cLog.Time) + ","
        //                                      + cLog.StateType.ToString() + ");";

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        #endregion

        #region Cycle Information Table

        //public bool WriteCycleInfo(CCycleInfo cCycleInfo)
        //{
        //    if (cCycleInfo == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblCycleInfo VALUES ";

        //            sDataSet = @"('" + cCycleInfo.ProjectID + "','"
        //                            + cCycleInfo.GroupKey + "','"
        //                            + cCycleInfo.CycleID + "','"
        //                            + cCycleInfo.CycleType.ToString() + "','"
        //                            + cCycleInfo.CurrentRecipe + "','"
        //                            + ToTimeString(cCycleInfo.CycleStart) + "','"
        //                            + ToTimeString(cCycleInfo.CycleEnd) + "','"
        //                            + ToTimeSpanString(cCycleInfo.CycleTimeValue) + "','"
        //                            + ToTimeSpanString(cCycleInfo.TactTimeValue) + "','"
        //                            + ToTimeSpanString(cCycleInfo.IdleTimeValue) + "')";

        //            sQuery += sDataSet;

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        #endregion

        #region Production Information Table

        //public bool WriteProductionInfo(CProductionInfo cProductionInfo, string sProjectID)
        //{
        //    if (cProductionInfo == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblProductionInfo VALUES ";

        //            sDataSet = @"('" + sProjectID + "','"
        //                       + cProductionInfo.TeamName + "','"
        //                       + cProductionInfo.TargetCount + "','"
        //                       + cProductionInfo.TagKey + "','"
        //                       + ToTimeString(cProductionInfo.ProductionTime) + "','"
        //                       + cProductionInfo.UPH.ToString() + "','"
        //                       + cProductionInfo.CurrentCount + "','"
        //                       + cProductionInfo.CurrentRecipe + "')";

        //            sQuery += sDataSet;

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        public bool ClearProductionInfoS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblProductionInfo;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
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

        //public bool WriteErrorInfo(CErrorInfo cErrorInfo)
        //{
        //    if (cErrorInfo == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblErrorInfo VALUES ";

        //            sDataSet = @"('" + cErrorInfo.ProjectID + "','" 
        //                            + cErrorInfo.GroupKey + "','"
        //                            + cErrorInfo.CycleID+ "','" 
        //                            + cErrorInfo.ErrorID + "','"
        //                            + cErrorInfo.ErrorType + "','"
        //                            + cErrorInfo.SymbolKey + "','"
        //                            + cErrorInfo.Value.ToString() + "','" 
        //                            + ToTimeString(cErrorInfo.ErrorTime) + "','"
        //                            + ToTimeString(cErrorInfo.CycleStart) + "','"
        //                            + cErrorInfo.DetailErrorMessage + "','"
        //                            + cErrorInfo.CurrentRecipe + "','"
        //                            + cErrorInfo.InputSymbolKey + "','"
        //                            + cErrorInfo.AbnormalSymbolKey + "','"
        //                            + cErrorInfo.CoilKey + "','"
        //                            + cErrorInfo.ErrorMessage + "','"
        //                            + (cErrorInfo.IsVisible == true? 1 : 0) + "')";

        //            sQuery += sDataSet;

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        public bool ClearErrorInfoS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblErrorInfo;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
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

        //public bool WriteErrorLogS(int iErrorID, CTimeLogS cLogS)
        //{
        //    if (cLogS == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblErrorLog VALUES ";

        //            CTimeLog cLog;
        //            for (int i = 0; i < cLogS.Count; i++)
        //            {
        //                cLog = cLogS[i];

        //                sDataSet = @"("
        //                                + iErrorID + ","
        //                                + ToTimeString(cLog.Time) + ",'"
        //                                + cLog.Key + "',"
        //                                + cLog.Value.ToString() + ",'"
        //                                + cLog.Parent + "')";

        //                if (i < cLogS.Count - 1)
        //                    sQuery += sDataSet + " , ";
        //                else
        //                    sQuery += sDataSet;
        //            }

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        public bool ClearErrorLogS()
        {
            MySqlCommand dbComm = null;

            try
            {
                string sQuery = @"DELETE FROM tblErrorLog;";

                dbComm = new MySqlCommand();
                dbComm.Connection = dbConnection;
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

        #region LadderView Table

        /*

        public bool WriteLadderInfo(string sProjectID, int iLadderID)
        {
            bool bOK = false;
            string sQuery;
            MySqlCommand dbComm = null;

            try
            {
                if (dbConnected)
                {
                    sQuery = @"INSERT INTO IOTLINK.tblladderinfo VALUES "
                            + "('"
                            + sProjectID + "','"
                            + iLadderID + "',"
                            + ToTimeString(DateTime.Now) + ","
                            + ToTimeString(DateTime.Now) + ")";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
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
        public bool WriteLadderDetailInfo(string sProjectID, int iLadderID, string sMainStepKey, string sMainStepCoil, string sStepKeyS, string sPlcID)
        {
            bool bOK = false;
            string sQuery;
            MySqlCommand dbComm = null;

            try
            {
                if (dbConnected)
                {
                    sQuery = @"INSERT INTO IOTLINK.tblladderdetailinfo VALUES "
                            + "('"
                            + sProjectID + "','"
                            + iLadderID + "','"
                            + sMainStepKey + "','"
                            + sMainStepCoil + "','"
                            + sStepKeyS + "','"
                            + sPlcID + "')";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
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

        public bool WriteLadderViewInfo_CollectEndTime(string sProjectID, int iLadderID)
        {
            bool bOK = false;
            string sQuery;
            MySqlCommand dbComm = null;

            try
            {
                if (dbConnected)
                {
                    sQuery = @"UPDATE IOTLINK.tblladderinfo "
                            + "SET   dtCollectEndTime = " + ToTimeString(DateTime.Now)
                            + "WHERE sProjectID = '"      + sProjectID + "'"
                            + "  AND iLadderID = "        + iLadderID + ";";

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
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

        */


        //public bool WriteLadderViewTimeLogS(string sProjectID, int iLadderID, CTimeLogS cLogS)
        //{
        //    if (cLogS == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            sQuery = @"INSERT INTO PLCMS.tblladdertimelog VALUES ";

        //            CTimeLog cLog;
        //            for (int i = 0; i < cLogS.Count; i++)
        //            {
        //                cLog = cLogS[i];

        //                sDataSet = @"('"
        //                               + sProjectID + "','"
        //                               + iLadderID + "',"
        //                               + ToTimeString(cLog.Time) + ",'"
        //                               + cLog.Key + "',"
        //                               + cLog.Value.ToString() + ",'"
        //                               + cLog.Parent + "')";

        //                if (i < cLogS.Count - 1)
        //                    sQuery += sDataSet + " , ";
        //                else
        //                    sQuery += sDataSet;
        //            }

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();

        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }

        //    return bOK;
        //}

        #endregion

        #region TagStatusTable

        //public bool WriteTagStatus_Start(string sProjectID, CTimeLogS cLogS, CTagS cTagS)
        //{
        //    //TagStatus Insert
        //    if (cLogS == null)
        //        return false;

        //    bool bOK = false;

        //    MySqlCommand dbComm = null;

        //    string sQuery;
        //    string sDataSet;
        //    int iCount = 0;
        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            m_sProjectName = sProjectID;
        //            // Insert Query
        //            sQuery = @"INSERT INTO PLCMS.tblTagStatus VALUES";

        //            CTag cTag = null;

        //            iTagStatusIndex = m_cReader.GetIndex() + 1;

        //            // Index 어떻게 반영? symbol도 .....
        //            sDataSet = @"('"
        //                + iTagStatusIndex + "','"
        //                + "Start" + "','"
        //                + "NonKey" + "','"
        //                + sProjectID + "','"
        //                + ToTimeString(DateTime.Now) + "','"
        //                + 0 + "','"
        //                + 0 + "')";

        //            sQuery += sDataSet + " , ";

        //            foreach(var who in cTagS)
        //            {
        //                cTag = who.Value;

        //                sDataSet = @"('"
        //                    + iTagStatusIndex + "','"
        //                    + "Symbol" + "','"
        //                    + cTag.Key + "','"
        //                    + sProjectID + "','"
        //                    + ToTimeString(DateTime.Now) + "','"
        //                    + 0 + "','"
        //                    + 0 + "')";

        //                if (iCount < cTagS.Count - 1)
        //                {
        //                    sQuery += sDataSet + " , ";
        //                    iCount++;
        //                }
        //                else
        //                    sQuery += sDataSet;
        //            }

        //            dbComm = new MySqlCommand();
        //            dbComm.Connection = dbConnection;
        //            dbComm.CommandText = sQuery;
        //            dbComm.ExecuteNonQuery();

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName); ex.Data.Clear();
                
        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }
        //    return bOK;
        //}

        public bool WriteTagStatus_Stop()
        {
            bool bOK = false;

            MySqlCommand dbComm = null;

            string sQuery;
            string sDataSet;

            Connect();

            try
            {
                if (dbConnected)
                {
                    sQuery = @"INSERT INTO IOTLINK.tblTagStatus VALUES";

                    iTagStatusIndex = objDBReader.GetIndex();
                    m_sProjectName = objDBReader.GetProjectname();

                    sDataSet = @"('"
                        + iTagStatusIndex + "','"
                        + "Stop" + "','"
                        + "NonKey" + "','"
                        + m_sProjectName + "','"
                        + ToTimeString(DateTime.Now) + "','"
                        + 0 + "','"
                        + 0 + "')";

                    sQuery += sDataSet;

                    dbComm = new MySqlCommand();
                    dbComm.Connection = dbConnection;
                    dbComm.CommandText = sQuery;
                    dbComm.ExecuteNonQuery();

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
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

        //public bool WriteTagStatus_Update(string sProjectID, CTimeLogS cLogS)
        //{
        //    //Table Update
        //    bool bOK = false;
        //    string sQuery;
        //    MySqlCommand dbComm = null;

        //    try
        //    {
        //        if (m_bConnected)
        //        {
        //            CTimeLog cLog = new CTimeLog();

        //            for (int i = 0; i < cLogS.Count; i++)
        //            {
        //                cLog = cLogS[i];

        //                sQuery = @"UPDATE PLCMS.tblTagStatus "
        //                    + "SET dLastTime = " + ToTimeString(cLog.Time) + ","
        //                    + " iValue = " + cLog.Value + ","
        //                    + " iChangedCount = iChangedCount + 1"
        //                    + " WHERE cKey = '" + cLog.Key + "'"
        //                    + " AND iIndex = " + iTagStatusIndex + ";";

        //                dbComm = new MySqlCommand();
        //                dbComm.Connection = dbConnection;
        //                dbComm.CommandText = sQuery;
        //                dbComm.ExecuteNonQuery();
        //            }

        //            bOK = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ObjectName);
        //        ex.Data.Clear();
        //        bOK = false;
        //    }
        //    finally
        //    {
        //        if (dbComm != null)
        //        {
        //            dbComm.Dispose();
        //            dbComm = null;
        //        }
        //    }
        //    return bOK;
        //}

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
