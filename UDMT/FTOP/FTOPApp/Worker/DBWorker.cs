using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FTOPApp
{
    public class DBWorker : IDisposable
    {
        public event UEventHandlerDBReadedDelegator UEventDBDataReaded;
        public event UEventHandlerLogMessage LogMessage;

        private MSSqlReader _reader;
        private MSSqlReader _MWreader;
        private SqlConnection _connect;
        private SqlConnection _MWconnect;
        private SqlConnection _connect2;
        private SqlCommand _command;
        public bool IsConnected = false;

        public DBWorker()
        {
            _reader = new MSSqlReader();
            _MWreader = new MSSqlReader();
        }

        public void Dispose()
        {
            if (_reader != null)
                _reader.Disconnect();
       
            this.Dispose();
        }

        public bool Connect()
        {
            IsConnected = false;

            if (_reader.Connect())
            {
                _connect = _reader.SqlConnect;
                _connect2 = _reader.SqlConnect2;
                _command = _connect2.CreateCommand();

                IsConnected = true;
            }

            return IsConnected;
        }

        public bool Connect(string mwConnect)
        {
            IsConnected = false;

            if (_MWreader.Connect(mwConnect))
            {
                _MWconnect = _MWreader.SqlMWConnect;
                IsConnected = true;
            }

            return IsConnected;
        }

        public bool DisConnect()
        {

            _MWreader.Disconnect();
            return _reader.Disconnect();

        }

        #region Command

        public bool SQLCommand(string commandText)
        {
            try
            {
                if (Connect())
                {
                    using (var cmd = new SqlCommand(commandText, _connect))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            //finally
            //{
            //    _connect.Close();
            //    DisConnect();
            //}

        }

        public bool SQLConnamd(EMFTOPTable table, EMCommandType commandType, FTOPTagFull tag)
        {
            try
            {
                var bOK = true;

                if (table == EMFTOPTable.T100)
                {

                }
                else if (table == EMFTOPTable.T110)
                {

                }
                else if (table == EMFTOPTable.T200)
                {

                }
                else if (table == EMFTOPTable.T300)
                {
                    var command = GetCommandString(table, commandType);
                    using (var cmd = new SqlCommand(command, _connect))
                    {
                        cmd.Parameters.Add("@CORP_CD", tag.CORP_CD);
                        cmd.Parameters.Add("@GTR_ID", tag.GTR_ID);
                        cmd.Parameters.Add("@MAKE_TIME", tag.MAKE_TIME.ToString("yyyymmddHHmmss"));
                        cmd.Parameters.Add("@VALUE_DATA", tag.PLCValue);
                        cmd.Parameters.Add("@IF_MES_YN", GetTarget(tag.SendTarget, EMTarget.MES));
                        cmd.Parameters.Add("@IF_MES_RSLT", "N");
                        cmd.Parameters.Add("@IF_MES_TIME", "");
                        cmd.Parameters.Add("@IF_CPS_YN", GetTarget(tag.SendTarget, EMTarget.CPS));
                        cmd.Parameters.Add("@IF_CPS_RSLT", "N");
                        cmd.Parameters.Add("@IF_CPS_TIME", "");
                        cmd.Parameters.Add("@REG_USER", tag.REG_USER);
                        cmd.Parameters.Add("@REG_DATE", tag.REG_DATE);
                        cmd.Parameters.Add("@UPD_USER", tag.UPD_USER);
                        cmd.Parameters.Add("@UPD_DATE", tag.UP_DATE);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                    bOK = false;

                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, "DB", this.ToString(), "SQLConnamd -> @" + table.ToString() + " @" + commandType.ToString() + " -> " + bOK, false, false));

                return bOK;

            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, "DB", this.ToString(), ex.Message, true, true));

                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool SQLProcedureMW(string procedureName , string LogS)
        {
            //1.Enque 에서 _Command를 사용 중이기 때문에 공유 할 수 없다.... 
            //그러므로 Enque와 Deque에 사용 할 command를 따로 둔다. vs 2.새로 생성하기 
            //..... 일단 두 번째로
            //Timeout Add
            try
            {
                using (var cmd = new SqlCommand(procedureName, _MWconnect))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.Add("@v_log_data", LogS);
                    //cmd.CommandTimeout = 1;
                    cmd.ExecuteNonQuery();
                }

                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), "MW Procedure Call : " + LogS, false, false));

                return true;
            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), ex.Message, true, true));

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SQLProcedureServer(EMFTOPTable table, string procedureName, ProcedureTag tag)
        {
            //1.Enque 에서 _Command를 사용 중이기 때문에 공유 할 수 없다.... 
            //그러므로 Enque와 Deque에 사용 할 command를 따로 둔다. vs 2.새로 생성하기 
            //..... 일단 두 번째로
            //Timeout Add
            try
            {
                using (var cmd = new SqlCommand(procedureName, _connect))
                {                
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.Add("@corpcd", tag.CORP_CD);
                    cmd.Parameters.Add("@gtrId", tag.GTR_ID);
                    cmd.Parameters.Add("@valueData", tag.Value);
                    cmd.Parameters.Add("@makeTime", tag.SendedTime);
                    cmd.Parameters.Add("@ifMesRslt", tag.IF_MES_RSLT);
                    cmd.Parameters.Add("@ifCpsRslt", tag.IF_CPS_RSLT);
                    //cmd.CommandTimeout = 1;
                    cmd.ExecuteNonQuery();
                }

                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), "KEY : " + tag.Key + " -> @MES : " + tag.IF_MES_RSLT + " @CPS : " + tag.IF_CPS_RSLT, false, false));

                return true;
            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), ex.Message, true,true));

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SQLProcedureClient(EMFTOPTable table, string procedureName, FTag tag)
        {
            try
            {
                using (var cmd = new SqlCommand(procedureName, _connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.Add("@gtrId", tag.Key);
                    string sTime = tag.Time.ToString("yyyyMMddHHmmss.fff");
                    cmd.Parameters.Add("@makeTime", sTime);
                    cmd.Parameters.Add("@valueData", tag.Value);
                    cmd.ExecuteNonQuery();
                }

                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), "KEY : " + tag.Key + "-> Value : "+ tag.Value.ToString(), false, false));

                return true;
            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), ex.Message, true, true));

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SQLProcedureClien2(EMFTOPTable table, string procedureName, FTag tag)
        {
            try
            {
                using (var cmd = new SqlCommand(procedureName, _connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.Add("@gtrId", tag.Key);
                    string sTime = tag.Time.ToString("yyyyMMddHHmmss");
                    cmd.Parameters.Add("@makeTime", sTime);
                    cmd.Parameters.Add("@valueData", tag.Value);
                    cmd.ExecuteNonQuery();
                }

                //if (LogMessage != null)
                //    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), "SQLProcedure -> @" + table.ToString() + " @" + procedureName + " : true", false,false));

                return true;
            }
            catch (Exception ex)
            {
                //if (LogMessage != null)
                //    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), ex.Message, true,true));

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataTable SQLCommandToDatatable(string commandText)
        {
            try
            {
                var dataTable = new DataTable();
                using (var cmd = new SqlCommand(commandText, _connect))
                {
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }

                return dataTable;
            }
            catch (Exception ex) 
            {
                if (LogMessage !=null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), ex.Message, true, true));

                Console.WriteLine(ex.Message); return null; 
            }

        }

        #endregion

        #region Client Command

        public List<FTOPTagFull> GetFTOPDBStandard(EMClientNumber clientNum)
        {
            try
            {
                string command = string.Empty;
                if (clientNum == EMClientNumber.FTOPClient1)
                    command = "SELECT * FROM dbo.FTOP110 WHERE DESCR = 'FTOPClient1'";
                else if (clientNum == EMClientNumber.FTOPClient2)
                    command = "SELECT * FROM dbo.FTOP110 WHERE DESCR = 'FTOPClient2' OR PLC_TYPE = 'YOKOGAWA'";
                else if (clientNum == EMClientNumber.DemoFactory)
                    command = "SELECT * FROM dbo.FTOP110 WHERE DESCR = 'DemoFactory'";

                //command = "SELECT * FROM dbo.FTOP110 WHERE EQM_IP_ADDR = '172.18.8.161'";

                var cTagS = new List<FTOPTagFull>();
                var FTOP100Table = SQLCommandToDatatable(command);
                if (FTOP100Table != null)
                {
                    foreach (DataRow row in FTOP100Table.Rows)
                    {
                        var tag = SetFTagFull(row);
                        cTagS.Add(tag);
                    }
                }
                //ConnectEvent(EMConnectType.DB, EMConnectStatus.Connenct);
                return cTagS;

            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), ex.Message, true, true));
               
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<OPCTag> GetFTOPDBStandard(EMClientNumber clientNum , int interval , string adapter)
        {
            try
            {
                string command = string.Empty;
                if (clientNum == EMClientNumber.FTOPClient1)
                    command = "SELECT * FROM dbo.FTOP110 WHERE DESCR = 'FTOPClient1'";
                else if (clientNum == EMClientNumber.FTOPClient2)
                    command = "SELECT * FROM dbo.FTOP110 WHERE DESCR = 'FTOPClient2'";

                var cTagS = new List<OPCTag>();
                var FTOP100Table = SQLCommandToDatatable(command);
                if (FTOP100Table != null)
                {
                    foreach (DataRow row in FTOP100Table.Rows)
                    {
                        var tag = SetOPCTag(row, interval, adapter);
                        if (!cTagS.Exists(i => i.IPAddress == tag.IPAddress))
                            cTagS.Add(tag);                      
                    }
                }
               
                return cTagS;

            }
            catch (Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), ex.Message, true, true));
                
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private FTOPTagFull SetFTagFull(DataRow row)
        {
            try
            {
                var tag = new FTOPTagFull();

                tag.CORP_CD = row[(int)EMFTOP110Columns.CORP_CD] as string;
                tag.GTR_ID = row[(int)EMFTOP110Columns.GTR_ID] as string;
                tag.OPCDevice = row[(int)EMFTOP110Columns.PLC_NM] as string;
                tag.OPCChannel = row[(int)EMFTOP110Columns.PLC_CHNL] as string;
                tag.PLCAddress = row[(int)EMFTOP110Columns.PLC_ADDR] as string;
                tag.PLCMaker = GetPLCMaker(row[(int)EMFTOP110Columns.PLC_TYPE] as string);
                tag.PLCIPAddress = row[(int)EMFTOP110Columns.EQM_IP_ADDR] as string;
                tag.PLCDataType = GetDatatype(row[(int)EMFTOP110Columns.DATA_TYPE] as string);
                tag.SendTarget = row[(int)EMFTOP110Columns.IF_TARGET] as string;
                tag.PLCDESC = row[(int)EMFTOP110Columns.DESCR] as string;
                tag.REG_DATE = (DateTime)row[(int)EMFTOP110Columns.REG_DATE];
                tag.REG_USER = row[(int)EMFTOP110Columns.REG_USER] as string;
                tag.UP_DATE = (DateTime)row[(int)EMFTOP110Columns.UPD_DATE];
                tag.UPD_USER = row[(int)EMFTOP110Columns.UPD_USER] as string;

                tag.Key = tag.GTR_ID;

                return tag;
            }
            catch(Exception ex)
            {
                if (LogMessage != null)
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), ex.Message, true, true));
                
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private OPCTag SetOPCTag(DataRow row , int communicationInterval , string adapter )
        {
            var tag = new OPCTag();

            tag.Device = row[(int)EMFTOP110Columns.PLC_NM] as string;
            tag.Channel = row[(int)EMFTOP110Columns.PLC_CHNL] as string;
            tag.IPAddress = row[(int)EMFTOP110Columns.EQM_IP_ADDR] as string;

            tag.PLCName = GetPLCName(row[(int)EMFTOP110Columns.PLC_TYPE] as string);
            tag.CommunicationInterval = communicationInterval;
            tag.EthernetAdapter = adapter;

            return tag;
        }

        private EMFTOPPLCMaker GetPLCMaker(string plc)
        {
            if (plc.Contains("XGK-CPUS"))
                return EMFTOPPLCMaker.LS;
            else
                return EMFTOPPLCMaker.YOKOGAWA;
        }

        private EMPLCDataType GetDatatype(string datatype)
        {
            if (datatype.Contains("Bool") || datatype.Contains("Bit") || datatype.Contains("bit") || datatype.Contains("bool"))
                return EMPLCDataType.Bool;
            else if (datatype.Contains("Word") || datatype.Contains("word"))
                return EMPLCDataType.Word;
            else if (datatype.Contains("Dword") || datatype.Contains("DWord"))
                return EMPLCDataType.DWord;
            else if (datatype.Contains("Int") || datatype.Contains("int"))
                return EMPLCDataType.Int;
            else if (datatype.Contains("Float") || datatype.Contains("float"))
                return EMPLCDataType.Float;
            else
                return EMPLCDataType.Any;
        }

        private EMTarget GetTarget(string target)
        {
            if (target == EMTarget.MES.ToString())
                return EMTarget.MES;
            else if (target == EMTarget.CPS.ToString())
                return EMTarget.CPS;
            else
                return EMTarget.ALL;

        }

        private string GetPLCName(string name)
        {
            if (name.Contains("LS"))
                return "XGT_K_Enet(LS)";
            else
                return "";
        }

        #endregion

        #region Server Command

        public DataTable GetNotSendedMESFromT300(int count , bool asc)
        {
            try
            {
                if (_connect2.State != System.Data.ConnectionState.Closed || _connect2.State != System.Data.ConnectionState.Broken)
                {
                    string orderType = string.Empty;
                    if (asc)
                        orderType = "ASC";
                    else
                        orderType = "DESC";
             
                    var dataTable = new DataTable();
                    var commandText = "SELECT TOP " + count
                                    + " A.CORP_CD, A.GTR_ID,A.MAKE_TIME,A.VALUE_DATA, A.IF_CPS_RSLT,A.IF_MES_TIME, B.EQM_CD, B.PLANT_NM FROM dbo.FTOP300 A INNER JOIN dbo.FTOP100 B ON A.CORP_CD=B.CORP_CD AND A.GTR_ID = B.GTR_ID ORDER BY A.MAKE_TIME " + orderType;

                    _command.CommandText = commandText;

                    using (IDataReader reader = _command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public DataTable GetNotSendedCPSFromT300()
        {
            try
            {
                //IF_CPS_RSLT -> N , IF_CPS_YN -> Y 
                var commandText = "SELECT TOP(100) * FROM dbo.FTOP300 where IF_CPS_RSLT = '8' AND IF_CPS_YN = 'Y'";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable GetSendedMESFromT300()
        {
            try
            {
                //IF_MES_RSLT -> Y , IF_MES_YN -> Y 
                var commandText = "IF EXISTS (SELECT * FROM dbo.FTOP300 where IF_MES_YN LIKE 'Y') SELECT * FROM dbo.FTOP300 where IF_MES_YN LIKE 'Y'";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable GetSendedCPSFromT300()
        {
            try
            {
                //IF_CPS_RSLT -> Y , IF_CPS_YN -> Y 
                var commandText = "IF EXISTS (SELECT * FROM dbo.FTOP300 where IF_CPS_YN LIKE 'Y') SELECT * FROM dbo.FTOP300 where IF_CPS_YN LIKE 'Y'";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable GetFTOP300DB()
        {
            try
            {
                //IF_MES_RSLT -> N , IF_MES_YN -> Y 
                var commandText = "SELECT * FROM dbo.FTOP300 ";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable GetFTOP110DB()
        {
            try
            {
                //IF_MES_RSLT -> N , IF_MES_YN -> Y 
                var commandText = "SELECT * FROM dbo.FTOP110 ";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable GetFTOP100DB()
        {
            try
            {
                //IF_MES_RSLT -> N , IF_MES_YN -> Y 
                var commandText = "SELECT * FROM dbo.FTOP100 ";
                return SQLCommandToDatatable(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool MESUpdateFTOP300(int response, DataRow row)
        {
            try
            {
                var commandText = "UPDATE dbo.FTOP300 SET IF_MES_RSLT = 'Y' , UPD_USER = 'FTOPSERVER' ";
                return SQLCommand(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CPSUpdateFTOP300(int response, DataRow row)
        {
            try
            {
                var commandText = "UPDATE dbo.FTOP300 SET IF_CPS_RSLT = 'Y', UPD_USER = 'FTOPSERVER'";
                return SQLCommand(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool MESUpdateFTOP200(int response, DataRow row)
        {
            try
            {
                var commandText = "UPDATE dbo.FTOP200 SET IF_MES_RSLT = 'Y', UPD_USER = 'FTOPSERVER'";
                return SQLCommand(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CPSUpdateFTOP200(int response, DataRow row)
        {
            try
            {
                var commandText = "UPDATE dbo.FTOP200 SET IF_CPS_RSLT = 'Y', UPD_USER = 'FTOPSERVER'";
                return SQLCommand(commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion    

        #region ETC

        private string GetCommandString(EMFTOPTable t, EMCommandType type)
        {
            if (t == EMFTOPTable.T100)
            {
                if (type == EMCommandType.Insert)
                {
                    var cmd = "INSERT INTO dbo.FTOP100 (CORP_CD,GTR_ID,EQM_CD,ITEM_CD,ITEM_DETAIL_CD ,ITEM_DETAIL_NM , EQM_NM , PLANT_CD , PLANT_NM ,LINE_CD , LINE_NM , OP_CD , OP_NM , DESCR , REG_USER , REG_DATE, UPD_USER ,UPD_DATE , USE_YN) ";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @EQM_CD, @ITEM_CD, @ITEM_DETAIL_CD , @ITEM_DETAIL_NM , @EQM_NM , @PLANT_CD , @PLANT_NM , @LINE_CD , @LINE_NM , @OP_CD , @OP_NM , @DESCR , @REG_USER , @REG_DATE, @UPD_USER , @UPD_DATE , @USE_YN)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Update)
                {
                    var cmd = "UPDATE INTO dbo.FTOP100 (CORP_CD,GTR_ID,EQM_CD,ITEM_CD,ITEM_DETAIL_CD ,ITEM_DETAIL_NM , EQM_NM , PLANT_CD , PLANT_NM ,LINE_CD , LINE_NM , OP_CD , OP_NM , DESCR , REG_USER , REG_DATE, UPD_USER ,UPD_DATE , USE_YN) ";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @EQM_CD, @ITEM_CD, @ITEM_DETAIL_CD , @ITEM_DETAIL_NM , @EQM_NM , @PLANT_CD , @PLANT_NM , @LINE_CD , @LINE_NM , @OP_CD , @OP_NM , @DESCR , @REG_USER , @REG_DATE, @UPD_USER , @UPD_DATE , @USE_YN)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Delete)
                {
                    var cmd = "DELETE INTO dbo.FTOP100 (CORP_CD,GTR_ID,EQM_CD,ITEM_CD,ITEM_DETAIL_CD ,ITEM_DETAIL_NM , EQM_NM , PLANT_CD , PLANT_NM ,LINE_CD , LINE_NM , OP_CD , OP_NM , DESCR , REG_USER , REG_DATE, UPD_USER ,UPD_DATE , USE_YN) ";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @EQM_CD, @ITEM_CD, @ITEM_DETAIL_CD , @ITEM_DETAIL_NM , @EQM_NM , @PLANT_CD , @PLANT_NM , @LINE_CD , @LINE_NM , @OP_CD , @OP_NM , @DESCR , @REG_USER , @REG_DATE, @UPD_USER , @UPD_DATE , @USE_YN)";
                    return cmd + parameter;
                }
                else
                    return "";
            }
            else if (t == EMFTOPTable.T110)
            {
                if (type == EMCommandType.Insert)
                {
                    var cmd = "INSERT INTO dbo.FTOP110 (CORP_CD,GTR_ID,PLC_NM,PLC_ADDR,PLC_TYPE ,EQM_IP_ADDR , EQM_IP_PORT , IF_TARGET , ADDR_TAG ,DESCR , REG_USER , REG_DATE , UPD_USER , UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @PLC_NM, @PLC_ADDR, @PLC_TYPE , @EQM_IP_ADDR , @EQM_IP_PORT , @IF_TARGET , @ADDR_TAG , @DESCR , @REG_USER , @REG_DATE , @UPD_USER , @UPD_DATE)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Update)
                {
                    var cmd = "UPDATE INTO dbo.FTOP110 (CORP_CD,GTR_ID,PLC_NM,PLC_ADDR,PLC_TYPE ,EQM_IP_ADDR , EQM_IP_PORT , IF_TARGET , ADDR_TAG ,DESCR , REG_USER , REG_DATE , UPD_USER , UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @PLC_NM, @PLC_ADDR, @PLC_TYPE , @EQM_IP_ADDR , @EQM_IP_PORT , @IF_TARGET , @ADDR_TAG , @DESCR , @REG_USER , @REG_DATE , @UPD_USER , @UPD_DATE)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Delete)
                {
                    var cmd = "DELETE INTO dbo.FTOP110 (CORP_CD,GTR_ID,PLC_NM,PLC_ADDR,PLC_TYPE ,EQM_IP_ADDR , EQM_IP_PORT , IF_TARGET , ADDR_TAG ,DESCR , REG_USER , REG_DATE , UPD_USER , UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @PLC_NM, @PLC_ADDR, @PLC_TYPE , @EQM_IP_ADDR , @EQM_IP_PORT , @IF_TARGET , @ADDR_TAG , @DESCR , @REG_USER , @REG_DATE , @UPD_USER , @UPD_DATE)";
                    return cmd + parameter;
                }
                else
                    return "";
            }
            else if (t == EMFTOPTable.T200)
            {
                if (type == EMCommandType.Insert)
                {
                    var cmd = "INSERT INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Update)
                {
                    var cmd = "UPDATE INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Delete)
                {
                    var cmd = "DELETE INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER)";
                    return cmd + parameter;
                }
                else
                    return "";
            }
            else if (t == EMFTOPTable.T300)
            {
                if (type == EMCommandType.Insert)
                {
                    var cmd = "INSERT INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER , UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER , @UPD_DATE)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Update)
                {
                    var cmd = "UPDATE INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER, UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER, @UPD_DATE)";
                    return cmd + parameter;
                }
                else if (type == EMCommandType.Delete)
                {
                    var cmd = "DELETE INTO dbo.FTOP300 (CORP_CD,GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN ,IF_MES_RSLT , IF_MES_TIME , IF_CPS_YN , IF_CPS_RSLT ,IF_CPS_TIME , REG_USER , REG_DATE , UPD_USER , UPD_DATE)";
                    var parameter = "VALUES (@CORP_CD , @GTR_ID, @MAKE_TIME, @VALUE_DATA, @IF_MES_YN , @IF_MES_RSLT , @IF_MES_TIME , @IF_CPS_YN , @IF_CPS_RSLT , @IF_CPS_TIME , @REG_USER , @REG_DATE , @UPD_USER , @UPD_DATE)";
                    return cmd + parameter;
                }
                else
                    return "";
            }
            else
                return "";


        }

        private string GetTarget(string target, EMTarget type)
        {
            if (target == type.ToString())
            {
                return "Y";
            }
            else
                return "N";

        }

        public LogEventArgs SetLog(DateTime time, string type, string sender, string messgae, bool isException, bool isWarning)
        {
            var log = new LogEventArgs();
            var clientLog = new FTOPLog();

            clientLog.IsException = isException;
            clientLog.Time = time;
            clientLog.Sender = sender;
            clientLog.Type = type;
            clientLog.Message = messgae;
            clientLog.IsWarning = isWarning;

            log.fTopLog = clientLog;

            return log;

        }

        #endregion


    }
     
}
