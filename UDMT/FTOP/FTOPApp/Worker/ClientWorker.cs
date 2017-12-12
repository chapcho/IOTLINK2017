using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using UDM.Common;
using UDM.Log;
using Microsoft.Win32;
using FtopManager;

namespace FTOPApp
{
    public class ClientWorker : IWorker, IDisposable
    {
        public FtopManagerServer FtopManger = null;

        private CThreadWorker _threadWorker;
        public COPCServer OpcServer;
        private DBWorker _dbWorker;
        public Dictionary<string, string> DicFTOP110;


        public List<FTOPTagFull> TagS = new List<FTOPTagFull>();
        public Dictionary<string, object> dicValue = new Dictionary<string, object>();
        public CSystemLog SystemLog = null;
        

        public string ServerName = string.Empty;
        public EMClientNumber ClientNumber;

        public event UEventHandlerLogMessage LogMessage;


        public List<string> OPCServerList { get { return OpcServer.GetOPCServerList(); } }

        public ClientWorker(CSystemLog log)
        {
            OpcServer = new COPCServer();
            SystemLog = log;

            FtopManger = new FtopManagerServer();
            FtopManger.Start();

            FtopManger.GtridReceived += FtopManger_GtridReceived;
            
        }

        public void Dispose()
        {
            _threadWorker.UEventTheredDeque -= _threadWorker_UEventTheredDeque;
            OpcServer.UEventValueChanged -= _opcServer_UEventValueChanged;

            if (_dbWorker != null) _dbWorker.DisConnect();
        }

        #region Main Method

        public bool TagRegister()
        {

            OpcServer.Config.Use = true;
            OpcServer.Config.ServerName = ServerName;
            OpcServer.Config.LsOpc = true;
            OpcServer.Connect();

            _threadWorker = new CThreadWorker();
            
            _dbWorker = new DBWorker();      
            _dbWorker.LogMessage += (o, e) => { LogMessage(o, e); };



            var isConnent = _dbWorker.Connect();
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "OPC Server Connect -> " + isConnent.ToString(), false, true));

            var ok = AddOPCDeviceS(ClientNumber);
            if (ok)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "OPC Tag Register -> OK", false, true));
            }
            else
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "OPC Tag Register -> False", true, true));

            return isConnent;
        }

        public void Run()
        {
            SetDicFTOP100();

            if (_threadWorker == null)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "OPC Tag를 먼저 등록하세요..", false, true));
                return;
            }


            var Tok = _threadWorker.Run();
            if(Tok)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Thread.ToString(), this.ToString(), "Run -> OK", false, true));
                _threadWorker.UEventTheredDeque += _threadWorker_UEventTheredDeque;
            }
            else
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Thread.ToString(), this.ToString(), "Run -> false", false, true));
            }

            var ok = OpcServer.Run();
            if (ok)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "Run -> OK", false, true));
                OpcServer.UEventValueChanged += _opcServer_UEventValueChanged;

            }
            else
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "Run -> false", false, true));
            }

   

        }

        public void Stop()
        {
            if (_threadWorker == null) return;

            var ok = _threadWorker.Stop();
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Thread.ToString(), ok.ToString(), "Thread was Stoped....", false, true));
            _threadWorker.UEventTheredDeque -= _threadWorker_UEventTheredDeque;

            OpcServer.Stop();
            OpcServer.UEventValueChanged -= _opcServer_UEventValueChanged;
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.OPC.ToString(), this.ToString(), "OPC was Stoped....", false, true));
        }

        public void Reset()
        {
            // 
        }

        #endregion

        #region OPC Tag ADD

        private bool AddOPCDeviceS(EMClientNumber clientNumber)
        {
            //데이터 중복여부 확인 // --> DB 에서 이미 중복 체크 한거 아니냐능....
            TagS = _dbWorker.GetFTOPDBStandard(ClientNumber);
            var addOK = OPCItemAdd(TagS);
            var instantTagS = OpcServer.ReadInstant(TagS);

            foreach (var tag in instantTagS)
            {
                var procedure = _dbWorker.SQLProcedureClient(EMFTOPTable.T300, "dbo.usp_FTOP200_CU_001", tag);
            }

            foreach (var tag in TagS)
            {
                if (!dicValue.ContainsKey(tag.Key))
                    dicValue.Add(tag.Key, -1);
            }

            return addOK;
        }

        public bool OPCItemAdd(List<FTOPTagFull> tagS)
        {
            // Unique ID -> GTR_ID
            var addOK = OpcServer.AddItemS(tagS);
            if (addOK)
            {
                return true;
            }
            else
                return false;       
        }

        #endregion

        #region Thread EnQue DeQue

        private void _opcServer_UEventValueChanged(DateTime time, string key, object value)
        {
            _threadWorker.EnQue(new FTag(time,key,value));

            //var findKey = dicValue.FirstOrDefault(d => d.Key.Equals(key));
            //if (findKey.Value != value)
            //{
            //    dicValue[findKey.Key] = value;
            //    await AsyncProcedure(new FTag(time, key, value));
            //}

        }

        //private async Task AsyncProcedure(FTag tag)
        //{
        //    _dbWorker.SQLProcedureClient(EMFTOPTable.T300, "dbo.usp_FTOP300_C_001", tag);
        //}

        private void _threadWorker_UEventTheredDeque(object sender, FTag tag)
        {

            //key = GTR_ID
            // OPC로 부터 이벤트 수신후 FTOP 200/300 에 Value Change에 대한 값을 Write 한다. ex) 200 -> Pulling Data , 300 -> Pushing Data
            var findKey = dicValue.FirstOrDefault(d => d.Key.Equals(tag.Key));
            if (findKey.Key != null)
            {
                if (findKey.Value != tag.Value)
                {
                    dicValue[findKey.Key] = tag.Value;
                    var procedure = _dbWorker.SQLProcedureClient(EMFTOPTable.T300, "dbo.usp_FTOP300_C_001", tag);
                    
                    //Demo전용
                    //LogMessage(this, SetLog(DateTime.Now, "PLC", DicFTOP110[tag.Key].ToString(), "KEY :" + tag.Key + " - > " + "VALUE : " + tag.Value, false, true));
                }
            }
        }

        private void _threadWorker_UEventMessage(object sender, string message)
        {

        }

        #endregion

        #region ETC

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

        private void SetDicFTOP100()
        {
            DicFTOP110 = new Dictionary<string, string>();
            var dt = _dbWorker.GetFTOP100DB();
            foreach(DataRow dr in dt.Rows)
            {

                string a = dr.ItemArray[1].ToString();
                string b = dr.ItemArray[13].ToString();
                DicFTOP110.Add(dr.ItemArray[1].ToString(), dr.ItemArray[13].ToString());
            }
        }

        #endregion

        // MW Add GtrID
        private void FtopManger_GtridReceived(string gtrid)
        {

            if (gtrid == "") return;

            if(gtrid.Contains("@Remove")) // remove
            {
                var addString = gtrid.Replace("@Remove", "");

                var removeTag = GetTagFromGtriId(addString);
                var removeOK = OpcServer.RemoveItemS(removeTag);
                LogMessage(this, SetLog(DateTime.Now, "GTRID Removed", this.ToString(), addString + " -> " + removeOK, true, true));

            }
            else // add
            {
                var addTag = GetTagFromGtriId(gtrid);
                var addOK = OPCItemAdd(addTag);
                LogMessage(this, SetLog(DateTime.Now, "GTRID Added", this.ToString(), gtrid + " -> " + addOK, true, true));

                var instantTagS = OpcServer.ReadInstant(addTag);
                if (instantTagS == null) return;

                foreach (var tag in instantTagS)
                {
                    var procedure = _dbWorker.SQLProcedureClient(EMFTOPTable.T300, "dbo.usp_FTOP200_CU_001", tag);
                }

                foreach (var tag in addTag)
                {
                    if (!dicValue.ContainsKey(tag.Key))
                        dicValue.Add(tag.Key, -1);
                }
            }

        }

        private List<FTOPTagFull> GetTagFromGtriId(string gtrid)
        {

            try
            {
                var temp = new List<FTOPTagFull>();
                var tag = new FTOPTagFull();

                tag.CORP_CD = "A0001";
                tag.GTR_ID = gtrid.Split(',')[0];
                tag.Key = gtrid.Split(',')[0];

                tag.OPCChannel = gtrid.Split(',')[1];
                tag.OPCDevice = "Device";

                tag.MAKE_TIME = DateTime.Now;
                tag.OPCType = EMOPCType.OPCWorkX;
                tag.PLCDataType = GetDatatype2(gtrid.Split(',')[3]);

                tag.PLCAddress = GetAddress(gtrid.Split(',')[2], tag.PLCDataType);

                tag.PLCDESC = "MWWareClient";

                tag.PLCMaker = GetPLCMaker2(tag.OPCChannel);
                temp.Add(tag);
                return temp;
            }
            catch(Exception ex)
            {
                LogMessage(this, SetLog(DateTime.Now, "MW GtrID ADD", this.ToString(), "gtrid Parse -> False", true, true));
                return null;
            }

        }

        private EMFTOPPLCMaker GetPLCMaker2(string ip)
        {
            if (ip.Split('.')[3].Contains("160") || ip.Split('.')[3].Contains("161") || ip.Split('.')[3].Contains("162") || ip.Split('.')[3].Contains("163")
                || ip.Split('.')[3].Contains("164") || ip.Split('.')[3].Contains("165") || ip.Split('.')[3].Contains("166"))
            {
                return EMFTOPPLCMaker.YOKOGAWA;
            }
            else
            {
                return EMFTOPPLCMaker.LS;
            }

        }

        private EMPLCDataType GetDatatype2(string datatype)
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

        private string GetAddress(string address, EMPLCDataType type)
        {
            string ConvertAddress = string.Empty;
            if (type == EMPLCDataType.Bool)
            {
                ConvertAddress = address.Replace("M0", "MX");
            }
            else if (type == EMPLCDataType.Float)
            {
                ConvertAddress = address.Replace("M", "MW") + ":F";
            }
            else
                ConvertAddress = address;

            return ConvertAddress;
        }

    }
}
