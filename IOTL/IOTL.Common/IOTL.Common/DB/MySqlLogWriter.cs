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

        public bool ExecUpdateQuery(string queryString)
        {
            bool bOK = false;

            using (MySqlCommand updateCommand = new MySqlCommand())
            {
                try
                {
                    if (dbConnected)
                    {
                        updateCommand.Connection = dbConnection;
                        updateCommand.CommandText = queryString;
                        updateCommand.ExecuteNonQuery();

                        bOK = true;
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    ex.Data.Clear();
                    bOK = false;
                }
            }

            return bOK;
        }

        public bool WriteIOTLCompDataSingle(CTimeLog oData)
        {
            bool bRet = true;

            try
            {
                string text = Encoding.Default.GetString(oData.ReceiveData);

                // =======================================
                // 시작 : "S" // 1byte
                // 컴프레셔ID : "00000000" // 8byte
                // 컴프레셔정보번호 : "00" // 2byte
                // 데이터 : "0000" // 4byte (데이터당)
                // 끝 : "E" // 1byte

                // [시작],[컴프ID],[정보],[토출온도],[토출압력],[주위온도],[유회수기압력],[유회수기온도]],[유회수기차압],
                // [총운전시간],[모터운전시간],[모터운전횟수],[부하운전시간],[부하운전횟수],[인버터출력],[압력전송],[온도전송],[끝]
                // ex) "S,00000000,00,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,E"

                // 컴프정보아이디 당 데이터 수
                // "00" : 14개
                // "01" : 10개
                // "02" : 7개
                // "04" : 6개
                // "05" : 5개
                // "06" : 6개
                // "07" : 2개
                // "08" : 9개

                if (text[0] == 'S' && text[text.Length - 2] == 'E')
                {
                    // S,id,data1,data2,data3,data4
                    string[] RecvDatas = text.Split(',');

                    if (RecvDatas[2].ToString() == "00")
                    {
                        DBSave00("compdata.comp_00_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "01")
                    {
                        DBSave01("compdata.comp_01_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "02")
                    {
                        DBSave02("compdata.comp_02_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "04")
                    {
                        DBSave04("compdata.comp_04_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "05")
                    {
                        DBSave05("compdata.comp_05_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "06")
                    {
                        DBSave06("compdata.comp_06_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "07")
                    {
                        DBSave07("compdata.comp_07_tb", RecvDatas, oData.LogTime);
                    }
                    else if (RecvDatas[2].ToString() == "08")
                    {
                        DBSave08("compdata.comp_08_tb", RecvDatas, oData.LogTime);
                    }

                    /*
                    string[] GotoDBData = new string[4];
                    GotoDBData[0] = RecvDatas[2];
                    GotoDBData[1] = RecvDatas[3];
                    GotoDBData[2] = RecvDatas[4];
                    GotoDBData[3] = RecvDatas[5];

                    DBSave(RecvDatas[1].ToString(), GotoDBData);
                    */
                }
            }
            catch(Exception ex)
            {
                bRet = false;
            }

            return bRet;

        }
        private void DBSave00(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data00_00 = RecvData[3].ToString();
                string data00_01 = RecvData[4].ToString();
                string data00_02 = RecvData[5].ToString();
                string data00_03 = RecvData[6].ToString();
                string data00_04 = RecvData[7].ToString();
                string data00_05 = RecvData[8].ToString();
                string data00_06 = RecvData[9].ToString();
                string data00_07 = RecvData[10].ToString();
                string data00_08 = RecvData[11].ToString();
                string data00_09 = RecvData[12].ToString();
                string data00_10 = RecvData[13].ToString();
                string data00_11 = RecvData[14].ToString();
                string data00_12 = RecvData[15].ToString();
                string data00_13 = RecvData[16].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 00_00, 00_01, 00_02, 00_03, 00_04, 00_05, 00_06, 00_07, 00_08, 00_09, 00_10, 00_11, 00_12, 00_13, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data00_00 + "," +
                    data00_01 + "," +
                    data00_02 + "," +
                    data00_03 + "," +
                    data00_04 + "," +
                    data00_05 + "," +
                    data00_06 + "," +
                    data00_07 + "," +
                    data00_08 + "," +
                    data00_09 + "," +
                    data00_10 + "," +
                    data00_11 + "," +
                    data00_12 + "," +
                    data00_13 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave01(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data01_00 = RecvData[3].ToString();
                string data01_01 = RecvData[4].ToString();
                string data01_02 = RecvData[5].ToString();
                string data01_03 = RecvData[6].ToString();
                string data01_04 = RecvData[7].ToString();
                string data01_05 = RecvData[8].ToString();
                string data01_06 = RecvData[9].ToString();
                string data01_07 = RecvData[10].ToString();
                string data01_08 = RecvData[11].ToString();
                string data01_09 = RecvData[12].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 01_00, 01_01, 01_02, 01_03, 01_04, 01_05, 01_06, 01_07, 01_08, 01_09, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data01_00 + "," +
                    data01_01 + "," +
                    data01_02 + "," +
                    data01_03 + "," +
                    data01_04 + "," +
                    data01_05 + "," +
                    data01_06 + "," +
                    data01_07 + "," +
                    data01_08 + "," +
                    data01_09 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave02(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data02_00 = RecvData[3].ToString();
                string data02_01 = RecvData[4].ToString();
                string data02_02 = RecvData[5].ToString();
                string data02_03 = RecvData[6].ToString();
                string data02_04 = RecvData[7].ToString();
                string data02_05 = RecvData[8].ToString();
                string data02_06 = RecvData[9].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 02_00, 02_01, 02_02, 02_03, 02_04, 02_05, 02_06, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data02_00 + "," +
                    data02_01 + "," +
                    data02_02 + "," +
                    data02_03 + "," +
                    data02_04 + "," +
                    data02_05 + "," +
                    data02_06 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave04(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data04_00 = RecvData[3].ToString();
                string data04_01 = RecvData[4].ToString();
                string data04_02 = RecvData[5].ToString();
                string data04_03 = RecvData[6].ToString();
                string data04_04 = RecvData[7].ToString();
                string data04_05 = RecvData[8].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 04_00, 04_01, 04_02, 04_03, 04_04, 04_05, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data04_00 + "," +
                    data04_01 + "," +
                    data04_02 + "," +
                    data04_03 + "," +
                    data04_04 + "," +
                    data04_05 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave05(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data05_00 = RecvData[3].ToString();
                string data05_01 = RecvData[4].ToString();
                string data05_02 = RecvData[5].ToString();
                string data05_03 = RecvData[6].ToString();
                string data05_04 = RecvData[7].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 05_00, 05_01, 05_02, 05_03, 05_04, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data05_00 + "," +
                    data05_01 + "," +
                    data05_02 + "," +
                    data05_03 + "," +
                    data05_04 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave06(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data06_00 = RecvData[3].ToString();
                string data06_01 = RecvData[4].ToString();
                string data06_02 = RecvData[5].ToString();
                string data06_03 = RecvData[6].ToString();
                string data06_04 = RecvData[7].ToString();
                string data06_05 = RecvData[8].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 06_00, 06_01, 06_02, 06_03, 06_04, 06_05, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data06_00 + "," +
                    data06_01 + "," +
                    data06_02 + "," +
                    data06_03 + "," +
                    data06_04 + "," +
                    data06_05 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave07(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data07_00 = RecvData[3].ToString();
                string data07_01 = RecvData[4].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 07_00, 07_01, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data07_00 + "," +
                    data07_01 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave08(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data08_00 = RecvData[3].ToString();
                string data08_01 = RecvData[4].ToString();
                string data08_02 = RecvData[5].ToString();
                string data08_03 = RecvData[6].ToString();
                string data08_04 = RecvData[7].ToString();
                string data08_05 = RecvData[8].ToString();
                string data08_06 = RecvData[9].ToString();
                string data08_07 = RecvData[10].ToString();
                string data08_08 = RecvData[11].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 08_00, 08_01, 08_02, 08_03, 08_04, 08_05, 08_06, 08_07, 08_08, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data08_00 + "," +
                    data08_01 + "," +
                    data08_02 + "," +
                    data08_03 + "," +
                    data08_04 + "," +
                    data08_05 + "," +
                    data08_06 + "," +
                    data08_07 + "," +
                    data08_08 + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private void DBSave(string TableName, string[] RecvData, DateTime logReceiveTime)
        {
            try
            {
                string outputairpressure = RecvData[0].ToString();
                string inoilpressure = RecvData[1].ToString();
                string outputairtemp = RecvData[2].ToString();
                string inoiltemp = RecvData[3].ToString();

                // DateTime dateValue = DateTime.Now;
                string savetime = logReceiveTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (outputairpressure, inoilpressure, outputairtemp, inoiltemp, savetime) " +
                    " values (" +
                    Convert.ToDouble(outputairpressure) + "," +
                    Convert.ToDouble(inoilpressure) + "," +
                    Convert.ToDouble(outputairtemp) + "," +
                    Convert.ToDouble(inoiltemp) + "," +
                    "'" + savetime + "')";

                SaveQueryToIOTLCompDataDB(query);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void SaveQueryToIOTLCompDataDB(string query)
        {
            MySqlCommand dbComm = null;
            try
            {
                dbComm = new MySqlCommand(query, dbConnection);
                dbComm.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);

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

                    //StringBuilder sb = new StringBuilder();
                    //foreach(byte data in (byte[])cLog.ReceiveData)
                    //{
                    //    sb.Append(data);
                    //}

                    dbComm.Parameters.Add("machineData", MySql.Data.MySqlClient.MySqlDbType.VarChar, 200);
                    // dbComm.Parameters["machineData"].Value = cLog.GetReceiveDataToHex();
                    dbComm.Parameters["machineData"].Value = Encoding.Default.GetString(cLog.ReceiveData);
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
