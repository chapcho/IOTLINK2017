using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.DB
{
    [Serializable]
    public class ConfigMariaDB : IMySQLDBConnect
    {
        private string databaseServerIp;
        private string initialDatabaseName;
        private uint databaseServerPort = 3306;
        private string loginUserID;
        private string loginUserPassword;
        private string databaseCharset;
        private string dbConnectionString;

        /// <summary>
        /// MariaDB Connection은 MySQLDBConnection과 동일합니다.
        /// </summary>
        //public ConfigMariaDB()
        //{
        //    // Default DB Connecion String
        //    databaseServerIp = "localhost";
        //    databaseServerPort = 3306;
        //    initialDatabaseName = "comp";
        //    loginUserID = "root";
        //    loginUserPassword = "amin!!";
        //    databaseCharset = "utf8";
        //}

        public ConfigMariaDB(string dbIp, uint dbPort, string dbName, string loginUser, string userPassword, string dbCharset)
        {
            databaseServerIp = dbIp;
            databaseServerPort = dbPort;
            initialDatabaseName = dbName;
            loginUserID = string.IsNullOrEmpty(loginUser) ? "root" : loginUser;
            loginUserPassword = userPassword;
            databaseCharset = string.IsNullOrEmpty(dbCharset) ? "utf8" : dbCharset;
        }

        public ConfigMariaDB(ConfigMariaDB connInfo)
        {
            this.DatabaseServerIp = connInfo.DatabaseServerIp;
            this.DatabaseServerPort = connInfo.DatabaseServerPort;
            this.InitialDatabaseName = connInfo.InitialDatabaseName;
            this.LoginUserID = connInfo.LoginUserID;
            this.LoginUserPassword = connInfo.LoginUserPassword;
            this.DatabaseCharset = string.IsNullOrEmpty(connInfo.DatabaseCharset) ? "utf8" : connInfo.DatabaseCharset;
        }

        #region MySQLDB Connect Interface 구현

        public string DatabaseServerIp
        {
            get
            {
                return databaseServerIp;
            }
            set
            {
                databaseServerIp = value;
            }
        }

        public string InitialDatabaseName
        {
            get
            {
                return initialDatabaseName;
            }
            set
            {
                initialDatabaseName = value;
            }
        }

        public uint DatabaseServerPort
        {
            get
            {
                return databaseServerPort;
            }
            set
            {
                databaseServerPort = value;
            }
        }

        public string LoginUserID
        {
            get
            {
                return loginUserID;
            }
            set
            {
                loginUserID = value;
            }
        }

        public string LoginUserPassword
        {
            get
            {
                return loginUserPassword;
            }
            set
            {
                loginUserPassword = value;
            }
        }

        public string DatabaseCharset
        {
            get
            {
                return databaseCharset;
            }
            set
            {
                databaseCharset = value;
            }
        }
        
        #endregion

        private void UpdateDBConnectString()
        {
            if(databaseServerIp == string.Empty 
                || initialDatabaseName == string.Empty
                || loginUserID == string.Empty
                || loginUserPassword == string.Empty
                || databaseCharset == string.Empty)
            {
                return;
            }

            dbConnectionString = string.Format("DATA SOURCE={0};PORT={1};INITIAL CATALOG={2};USER ID={3};PASSWORD={4};charset={5};pooling = false; convert zero datetime=True",
                databaseServerIp, databaseServerPort, initialDatabaseName, loginUserID, loginUserPassword, databaseCharset);
        }

        public string GetDBConnectionString()
        {
            UpdateDBConnectString();

            return dbConnectionString;
        }

        public string GetServerConnectoinString()
        {
            return string.Format("DATA SOURCE={0};PORT={1};USER ID={2};PASSWORD={3}",
                databaseServerIp, databaseServerPort, loginUserID, loginUserPassword);
        }
    }
}
