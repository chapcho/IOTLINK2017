using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FTOPApp
{
    public class MSSqlReader
    {
        /* DPY Client */
        public string connServer = @"Data Source=172.18.8.21,1433;INITIAL CATALOG=DYPFTOP; User ID=Administrator;Password=qwe123!@#;";

        /* DPY Server */
        //public string connServer = @"Data Source=FTOP_DB;INITIAL CATALOG=DYPFTOP; User ID=Administrator;Password=qwe123!@#;";

        /* DEMO Factory SERVER */
        //public string connServer = @"Data Source= 192.168.1.40 ;INITIAL CATALOG=DYPFTOP; User ID=ftop ;Password=ftop123!@#;";

        /* UDMTEK LOCAL SERVER */
        //public string connServer = @"Data Source=UDMTEK-PC\SQLEXPRESS;INITIAL CATALOG=DYPFTOP; User ID=root;Password=udmt1888;";

        /* ParkPC SERVER */
        //public string connServer = @"Data Source=192.168.0.156,1433;INITIAL CATALOG=DYPFTOP; User ID=udmt ;Password=udmt1888;";

        public bool IsConnected = false;

        public SqlConnection SqlConnect { get; set; }
        public SqlConnection SqlConnect2 { get; set; }
        public SqlConnection SqlMWConnect { get; set; }

        public MSSqlReader()
        {

        }

        public bool Connect()
        {
            try
            {
                if (SqlConnect == null && SqlConnect2 == null)
                {
                    SqlConnect = new SqlConnection(connServer);
                    SqlConnect.Open();
                    SqlConnect2 = new SqlConnection(connServer);
                    SqlConnect2.Open();
                    IsConnected = true;

                }
                else if (SqlConnect.State == System.Data.ConnectionState.Closed || SqlConnect.State == System.Data.ConnectionState.Broken)
                {
                    SqlConnect.Close();
                    SqlConnect.Dispose();
                    SqlConnect = null;

                    SqlConnect2.Close();
                    SqlConnect2.Dispose();
                    SqlConnect2 = null;

                    SqlConnect = new SqlConnection(connServer);
                    SqlConnect.Open();

                    SqlConnect2 = new SqlConnection(connServer);
                    SqlConnect2.Open();

                    IsConnected = true;

                }

            }
            catch (Exception ex)
            {
                SqlConnect.Close();
                SqlConnect.Dispose();
                SqlConnect = null;

                if (SqlConnect2!=null)
                {
                    SqlConnect2.Close();
                    SqlConnect2.Dispose();
                    SqlConnect2 = null;
                }

                IsConnected = false;
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return IsConnected;
        }

        public bool Connect(string mwConnect )
        {
            try
            {
                if (SqlMWConnect == null)
                {
                    SqlMWConnect = new SqlConnection(mwConnect);
                    SqlMWConnect.Open();

                }
                else if (SqlMWConnect.State == System.Data.ConnectionState.Closed || SqlMWConnect.State == System.Data.ConnectionState.Broken)
                {
                    SqlMWConnect.Close();
                    SqlMWConnect.Dispose();
                    SqlMWConnect = null;

                    SqlMWConnect = new SqlConnection(mwConnect);
                    SqlMWConnect.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (SqlMWConnect != null)
                {
                    SqlMWConnect.Close();
                    SqlMWConnect.Dispose();
                    SqlMWConnect = null;
                }

                IsConnected = false;
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

                return IsConnected;
            }
        }

        public bool Disconnect()
        {
            bool bOK = true;

            try
            {
                if (SqlConnect != null)
                {
                    SqlConnect.Close();
                    SqlConnect.Dispose();
                    SqlConnect = null;

                    SqlConnect2.Close();
                    SqlConnect2.Dispose();
                    SqlConnect2 = null;

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
