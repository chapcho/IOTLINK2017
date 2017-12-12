using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using CoFAS.Core;
using System.Net.Sockets;


namespace FTOPApp
{
    public class ServerWorker : IWorker, IDisposable
    {
        public DYPServiceReference.DYP_WebserviceSoapClient SoapClient = new DYPServiceReference.DYP_WebserviceSoapClient();
        public CbCpsIotDataManager.CpsIotDataManagerClient CpsClient = new CbCpsIotDataManager.CpsIotDataManagerClient("172.17.2.22");

        public int IntervalTime = 50;
        public bool UseCPS = true;
        public bool UseMES = true;
        public bool UseASC = true;
        public int TransCount = 10;
        public EMFTOPServerSendMode SendMode = EMFTOPServerSendMode.Array;

        public event UEventHandlerRestCount Counted;
        public event UEventHandlerLogMessage LogMessage;
        public event UEventHandlerMESSendedEvent DataSended;

        private System.Timers.Timer _timer;
        private CThreadWorker _threadWorker;
        private DBWorker _dbWorker;
        //private DBWorker _dbWorkerMW;

        private WebWorker _webWorker;

        public DataTable FOTP100 { get { return _dbWorker.GetFTOP100DB(); } }
        public DataTable FOTP110 { get { return _dbWorker.GetFTOP110DB(); } }

        public Stopwatch Watch = new Stopwatch();

        private CoFASSocketClient _pCoFASSocketClient = null;

        //public string connServerMW = @"Data Source=172.18.8.24,1433;INITIAL CATALOG=FASDYP; User ID=ftopuser;Password=ftopuser1!;";

        public ServerWorker()
        {  
            _dbWorker = new DBWorker();
            //_dbWorkerMW = new DBWorker();
            _dbWorker.LogMessage += (o, e) => { LogMessage(o, e); };

            _pCoFASSocketClient = new CoFASSocketClient("172.18.8.24", 8999);


        }

        public void Dispose()
        {
            if (_dbWorker != null)
                _dbWorker.Dispose();

            if (_threadWorker != null)
                _threadWorker.Dispose();

        }

        #region Main Method

        public void Run()
        {
            _webWorker = new WebWorker();

            var dbOK = _dbWorker.Connect();

            //add MW
            //_dbWorkerMW.Connect(connServerMW);
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), "DB Connect -> " + dbOK, false, true));

            var threadOK = _threadWorker = new CThreadWorker();
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Thread.ToString(), this.ToString(), "Thread Ready -> " + threadOK, false, true));

            _threadWorker.Run();
            _threadWorker.UEventTheredServerDeque += _threadWorker_UEventTheredServerDeque;
            
            _timer = new System.Timers.Timer(IntervalTime);
            _timer.Elapsed += (o, e) => { Worker(); };

            _timer.Start();     
            LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.ScanTimer.ToString(), this.ToString()," FTOP-Server Started!!", false,true));

            if(_pCoFASSocketClient.Open())
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.ScanTimer.ToString(), this.ToString(), " CoFASSocketClient Started!!", false, true));
            else
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.ScanTimer.ToString(), this.ToString(), " CoFASSocketClient Error!!", true, true));

        }

        public void Stop()
        {
            if (_threadWorker !=null)
            {
                _threadWorker.ClearQue();
                _threadWorker.Stop();
                _threadWorker.UEventTheredServerDeque -= _threadWorker_UEventTheredServerDeque;
            }


            if (_timer !=null)
            {
                _timer.Stop();
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.ScanTimer.ToString(), this.ToString(), "FTOP-Server Stopped!!", false, true));
            }
        }

        public void Reset()
        {
            //reject 
        }

        #endregion

        #region Working Method 

        private void Worker()
        {
            _timer.Stop();
            try { PLCDataEnQue(); }
            catch (Exception ex)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Information.ToString(), "PLCDataEnQue", "데이터 전송 예외", true, true));
                Console.WriteLine(ex.Message);
            }
            _timer.Start();
        }

        //private object lockObject = new object();
        private void PLCDataEnQue()
        {
            var mesDT = _dbWorker.GetNotSendedMESFromT300(TransCount, UseASC);
            if (mesDT != null)
            {
                if (mesDT.Rows.Count != 0)
                {
                    //SendPLCDataZero(GetOffTagS(mesDT));
                    bool mwResult = false;
                    var tagS = GetAllTagS(mesDT);

                    if (tagS.Count <= 0) return; 
                    
                    if (UseCPS)
                        CpsClient.SendIotStatus(GetGTRID(tagS).ToArray(), GetEQM(tagS).ToArray(), GetValue(tagS).ToArray());

                 
                    if (UseMES)
                    {
                        //Watch.Start();

                        //SoapClient.Set_LogData2(GetCORPID(tagS).ToArray(), GetGTRID(tagS).ToArray(), GetKey(tagS).ToArray());


                        mwResult = _pCoFASSocketClient.Send(GetMWProcedureKey(tagS));
                        if (!mwResult)
                        {
                            _pCoFASSocketClient = new CoFASSocketClient("172.18.8.24", 8999);
                        }
                            
                        //await Task.Run(() =>
                        //{
                        //    // do lot of work here
                        //    SoapClient.Set_LogData2(GetCORPID(tagS).ToArray(), GetGTRID(tagS).ToArray(), GetKey(tagS).ToArray());

                        //});

                        //var ok = _dbWorkerMW.SQLProcedureMW("usp_set_LogData4", GetMWProcedureKey(tagS));
                        //Console.WriteLine(ok + "  MES 전송시간 Time : " + Watch.ElapsedMilliseconds.ToString());
                        
                        //Watch.Stop();
                        //Watch.Reset();

                    }

                    foreach (var t in tagS)
                    {
                        if (!UseCPS) { t.IF_CPS_RSLT = "1"; }
                        if (!mwResult) { t.IF_MES_RSLT = "1"; }
                        var Update300 = _dbWorker.SQLProcedureServer(EMFTOPTable.T300, "dbo.usp_FTOP300_U_001", t);

                    }

                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), "전송 성공 Count =>" + mesDT.Rows.Count, false, false));

                }
                else
                    LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), "MES로 미 전송된 데이터가 없습니다.", false, false));
            }
            else
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), "F300 데이터 가져오기 실패", true, true));       
        }

        private void SendPLCDataZero(List<ProcedureTag> tagS)
        {
            foreach (var t in tagS)
            {
                t.IF_CPS_RSLT = "1";
                t.IF_MES_RSLT = "1";
                var Update300 = _dbWorker.SQLProcedureServer(EMFTOPTable.T300, "dbo.usp_FTOP300_U_001", t);
            }
        }

        public void ReConnectMW()
        {
            _pCoFASSocketClient = null;
            _pCoFASSocketClient = new CoFASSocketClient("172.18.8.24", 8999);
            _pCoFASSocketClient.Open();
        }

        #region Regacy Mode

        /// <summary>
        /// Thread Mode and Sequence Mode .... 네트워크 처리 속도가 너무 느림.... MES 와 CPS 
        /// 둘다 300ms 이상 시간 소요로 Array Mode로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tag"></param>
        private void _threadWorker_UEventTheredServerDeque(object sender, ProcedureTag tag)
        {
            try
            {
                Watch.Start();
                tag.IF_MES_RSLT = _webWorker.SendLogDataToMESBySoap(tag.CORP_CD, tag.GTR_ID, tag.Key);
                Watch.Stop();
                Console.WriteLine("MES 전송시간 Time : " + Watch.ElapsedMilliseconds.ToString());

                Watch.Reset();

                Watch.Start();
                tag.IF_CPS_RSLT = _webWorker.SendLogDataToCPSByTCPIP(tag.GTR_ID, tag.Value, tag.EQM_CD);
                Watch.Stop();
                Console.WriteLine("CPS 전송시간 Time : " + Watch.ElapsedMilliseconds.ToString());

                Watch.Reset();

                var Update300 = _dbWorker.SQLProcedureServer(EMFTOPTable.T300, "dbo.usp_FTOP300_U_001", tag);
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Procedure.ToString(), this.ToString(), "dbo.FTOP300 Update : " + Update300, false, false));
                //DataSended(this, tag);
            }
            catch(Exception ex)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Information.ToString(), "ServerDeque", "예외 발생...", true, true));
                Console.WriteLine(ex.Message);
            }



        }

        int count고장 = 0;
        int count대기 = 0;
        int count가동 = 0;
        object sync = new Object();
        private void ServerSendExcution(ProcedureTag tag)
        {

            Watch.Start();
            try
            {
                //tag.IF_CPS_RSLT = CpsClient.SendIotStatus(tag.GTR_ID, tag.EQM_CD, tag.Value);
                //tag.IF_MES_RSLT = SoapClient.Set_LogData(tag.CORP_CD, tag.GTR_ID, tag.Key);
                tag.IF_MES_RSLT = "1";
                tag.IF_CPS_RSLT = "3";
                if (UseCPS)
                {
                    if (tag.PLANT_NM.Contains("A동"))
                    {
                        //tag.IF_CPS_RSLT = CpsClient.SendIotStatus(tag.GTR_ID, tag.EQM_CD, tag.Value);
                        if (tag.GTR_ID == " ASF---104M00100")
                        {
                            if (tag.Value=="1")
                                count고장++;
                           
                        }
                        if (tag.GTR_ID == "ASW---104M00101")
                        {
                            if (tag.Value == "1")
                                count대기++;

                        }
                        if (tag.GTR_ID == "ASO---104M00102")
                        {
                            if (tag.Value == "1")
                                count가동++;
                        }
                    }
                    else
                        tag.IF_CPS_RSLT = "2";
                }

                var Update300 = _dbWorker.SQLProcedureServer(EMFTOPTable.T300, "dbo.usp_FTOP300_U_001", tag);
                Watch.Stop();
                Console.WriteLine("전송 유뮤 :  " + Update300 + "-> Time : " + Watch.ElapsedMilliseconds.ToString());
                Watch.Reset();
            }
            catch (Exception ex)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.Information.ToString(), "ServerDeque", "예외 발생...", true, true));
                Console.WriteLine(ex.Message);
            }
        }

        private void ThreadWorker()
        {
            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();
        }

        private void ThreadTask()
        {
            //bool boK = true;
            //while (true)
            //{
            //    //var mesDT = _dbWorker.GetNotSendedMESFromT300(10);
            //    if (mesDT != null)
            //    {
            //        if (mesDT.Rows.Count != 0)
            //        {

            //        }
            //    }

            //    Thread.Sleep(100);
            //}
        }

        #endregion

        #endregion

        #region ETC

        private List<string> GetGTRID(List<ProcedureTag> tagS)
        {
            var list = new List<string>();
            foreach (ProcedureTag t in tagS)
            {
                list.Add(t.GTR_ID);
            }
            return list;
        }

        private List<string> GetCORPID(List<ProcedureTag> tagS)
        {
            var list = new List<string>();
            foreach (ProcedureTag t in tagS)
            {
                list.Add(t.CORP_CD);
            }
            return list;
        }

        private List<string> GetEQM(List<ProcedureTag> tagS)
        {
            var list = new List<string>();
            foreach (ProcedureTag t in tagS)
            {
                list.Add(t.EQM_CD);
            }
            return list;
        }

        private List<string> GetValue(List<ProcedureTag> tagS)
        {
            var list = new List<string>();
            foreach (ProcedureTag t in tagS)
            {
                list.Add(t.Value);
            }
            return list;
        }

        private List<string> GetKey(List<ProcedureTag> tagS)
        {
            var list = new List<string>();
            foreach (ProcedureTag t in tagS)
            {
                list.Add(t.Key);
            }
            return list;
        }

        private string GetMWProcedureKey(List<ProcedureTag> tagS)
        {
            string temp = tagS[0].Key;

            for (int i = 0; i < tagS.Count - 1; i ++ )
            {
                temp = temp + "," + tagS[i + 1].Key;
            }

            return temp + ",";
        }

        private List<ProcedureTag> GetOnTagS(DataTable dt)
        {
            var list = new List<ProcedureTag>();
            foreach (DataRow row in dt.Rows)
            {
                if (GetProcedureTag(row).Value =="1")
                    list.Add(GetProcedureTag(row));        
            }
            return list;
        }

        private List<ProcedureTag> GetOffTagS(DataTable dt)
        {
            var list = new List<ProcedureTag>();
            foreach (DataRow row in dt.Rows)
            {
                if (GetProcedureTag(row).Value == "0")
                    list.Add(GetProcedureTag(row));  
            }
            return list;
        }

        private List<ProcedureTag> GetAllTagS(DataTable dt)
        {
            var list = new List<ProcedureTag>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetProcedureTag(row));
            }
            return list;
        }

        private ProcedureTag GetProcedureTag(DataRow row)
        {
            var tag = new ProcedureTag();
            try
            {
                tag.CORP_CD = row[0] as string;
                tag.GTR_ID = row[1] as string;
                tag.SendedTime = row[2] as string;
                tag.Value = row[3] as string;
                tag.IF_MES_RSLT = "0";//row[4] as string;
                tag.IF_CPS_RSLT = "0";//row[5] as string;
                tag.EQM_CD = row[6] as string;
                tag.PLANT_NM = row[7] as string;
                string key = String.Format("{0:00000000}", int.Parse(tag.Value));
                tag.Key = tag.SendedTime + tag.GTR_ID + key;
                return tag;
            }
            catch(Exception ex)
            {
                LogMessage(this, SetLog(DateTime.Now, EMLogSenderType.ETC.ToString(), this.ToString(), ex.Message, true, true));
                return tag;
            }

            
        }

        private LogEventArgs SetLog(DateTime time, string type, string sender, string messgae, bool isException , bool isWarning)
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
