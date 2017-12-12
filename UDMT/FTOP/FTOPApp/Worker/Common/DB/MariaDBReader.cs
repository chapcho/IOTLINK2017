using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;

namespace FTOPApp
{
    public class MariaDBReader
    {
        private string connServer = @"DATA SOURCE=localhost;PORT=3306;INITIAL CATALOG=DYPFTOP ;USER ID=root;PASSWORD=udmt;charset=utf8";
        public bool IsConnected = false;

        public MySqlConnection ConnectDB { get; set; }

        public MariaDBReader()
        {
            
        }

        public bool Connect()
        {
            try
            {
                if (ConnectDB == null)
                {
                    ConnectDB = new MySqlConnection(connServer);
                    ConnectDB.Open();
                    IsConnected = true;

                }
                else if (ConnectDB.State == ConnectionState.Closed || ConnectDB.State == ConnectionState.Broken)
                {
                    ConnectDB.Close();
                    ConnectDB.Dispose();
                    ConnectDB = null;

                    ConnectDB = new MySqlConnection(connServer);
                    ConnectDB.Open();
                    IsConnected = true;
           
                }

            }
            catch(Exception ex)
            {
                ConnectDB.Close();
                ConnectDB.Dispose();
                ConnectDB = null;
                IsConnected = false;
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return IsConnected;
        }

        public bool Disconnect()
        {
            bool bOK = true;

            try
            {
                if (ConnectDB != null)
                {
                    ConnectDB.Close();
                    ConnectDB.Dispose();
                    ConnectDB = null;
                    IsConnected = false;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

    }
}
