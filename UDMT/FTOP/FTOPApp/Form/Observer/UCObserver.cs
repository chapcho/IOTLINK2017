using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.Log;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;

namespace FTOPApp
{
    public partial class UCObserver : UserControl
    {
        public event UEventHandlerObserverStatus ObserverStatus;
        public BindingList<FTOPLog> LogS = new BindingList<FTOPLog>();
        public CSystemLog SystemLog = null;

        private SQLCommander _commandText = new SQLCommander();
        private FrmObserver _frmOb;
        private DBWorker _worker;
        private System.Timers.Timer _timer;
        private System.Timers.Timer _reportTimer;

        private bool IsConnected = false;
        

        public UCObserver(FrmObserver frm , CSystemLog log)
        {
            InitializeComponent();

            _frmOb = frm;
            _frmOb.RibbonMenuClick += (s, e) => { MenuClick(e); };
            _timer = new System.Timers.Timer(1000);
            _reportTimer = new System.Timers.Timer(60 * 60 * 3);

            SystemLog = log;

            exLog.DataSource = LogS;
            exLogView.Columns["Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            exLogView.Columns["Time"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm:ss";

            _worker = new DBWorker();
            var isConnenct = _worker.Connect();
            LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.DB.ToString(), this.ToString(), "DB 연결 상태 : " + isConnenct.ToString(), false, false));
            SystemLog.WriteLog(this.ToString(), "DB 연결 상태 : " + isConnenct.ToString());

            var isGetList = GetList();
            LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), "FTOP 설비 정보 : " + isGetList.ToString(), false, false));
            SystemLog.WriteLog(this.ToString(), "DB 연결 상태 : " + isConnenct.ToString());

            ListGroup.CustomButtonClick += (o, s) => { ObserverMenu(s.Button.Properties.Caption); };
            
            exMainView.DoubleClick += (o, s) => { SelectItemDetail(); };
            exListGridView.DoubleClick += (o, s) => { SelectItem(); };
            splitContainerControl2.Resize += splitContainerControl2_Resize;

            _reportTimer.Elapsed += _reportTimer_Elapsed;

            CommandExcution("최신 수집 데이터",string.Empty);
            ReSizeUpdate();
     
        }

        private void MenuClick(string menu)
        {
            switch (menu)
            {
                case "확대":
                    ViewChange(ViewMode.Expand);
                    break;
                case "축소":
                    ViewChange(ViewMode.Collapse);
                    break;
                case "Excel":
                    ExportToExcel();
                    break;
                case "PDF":
                    ExportToPDF();
                    break;
                case "PLC Ping 테스트":
                    PLCPingTest();
                    break;
                case "적용하기":
                    SendReport();
                    break;
                case "중지":
                    StopReport();
                    break;
                default:
                    CommandExcution(menu, string.Empty);
                    break;
            } 
        }

        private void splitContainerControl2_Resize(object sender, EventArgs e)
        {
            ReSizeUpdate();
        }

        public void ReSizeUpdate()
        {
            var h = splitContainerControl2.Height * 0.7;

            splitContainerControl2.SplitterPosition = (int)h;

            var w = splitContainerControl1.Height * 0.4;

            splitContainerControl1.SplitterPosition = (int)w;
        }

        private void CommandExcution(string cmd, string searching)
        {
            if (IsConnected)
            {
                var bOK = false;
                var command = cmd;
              
                switch (command)
                {
                    case "최신 수집 데이터":
                        command = _commandText.LastResult;
                        exMainView.FindFilterText = searching;
                        bOK = true;
                        break;
                    case "실시간 데이터":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.FTOP300;
                        break;
                    case "설비 기준 정보 (FTOP100)":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.FTOP100;
                        break;
                    case "설비 기준 정보 (FTOP110)":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.FTOP110;
                        break;
                    case "최근 이력 데이터 (FTOP200)":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.FTOP200;
                        break;
                    case "전송 결과 데이터":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.RecentResult0;
                        break;
                    case "전송 결과 데이터 (온도)":
                        exMainView.FindFilterText = string.Empty;
                        command = _commandText.RecentResult6;
                        break;
                    default:
                        Console.WriteLine("Other");
                        break;
                }
                
                var result = _worker.SQLCommandToDatatable(command);
                if (result != null)
                {
                    exMainView.Columns.Clear();
                    exMainGrid.DataSource = result;
                    exMainView.GroupPanelText = "Update Completed : " + DateTime.Now.ToString();
                    if (ObserverStatus != null)
                        ObserverStatus(this, "Update Completed : " + DateTime.Now.ToString());
                   
                    
                    if (bOK)
                    {
                        exMainView.Columns[0].GroupIndex = 0;
                        exMainView.Columns[1].GroupIndex = 1;
                        exMainView.Columns[3].GroupIndex = 2;
                    }             
                }
                else
                {
                    if (ObserverStatus != null)
                        ObserverStatus(this, "Command Failed...Retry Please..." + DateTime.Now.ToString());
                    exMainView.GroupPanelText = "Command Failed...Retry Please..."+ DateTime.Now.ToString();
                    
                }
                    
            }
            else
            {
                IsConnected = _worker.Connect();
                
                exMainView.GroupPanelText = "Connenct Status : " + IsConnected.ToString();
                if (ObserverStatus != null)
                    ObserverStatus(this, "Connenct Status : " + IsConnected.ToString());
               
            }

            exMainView.ExpandAllGroups();

            SystemLog.WriteLog(this.ToString(), cmd);
        }

        private void ObserverMenu(string select)
        {
            if (select.Contains("설비"))
                GetList();
        }

        private bool GetList()
        {
          
            try
            {
                string[] columns = new string[]{"공장","설비","설비 코드"};
                var dt = new  DataTable();
                dt.Columns.Add(columns[0]);
                dt.Columns.Add(columns[1]);
                dt.Columns.Add(columns[2]);

                foreach (DataRow r in _worker.GetFTOP100DB().Rows)
                {
                    var dr = dt.NewRow();
                    dr[columns[0]] = r["PLANT_NM"];
                    dr[columns[1]] = r["EQM_NM"];
                    dr[columns[2]] = r["EQM_CD"];
                    dt.Rows.Add(dr);
                }

                exListGrid.DataSource = dt.DefaultView.ToTable(true, columns);
                exListGridView.Columns[0].GroupIndex = 0;

                return true;
            }
            catch(Exception ex)
            {
                LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), ex.Message, true, true));
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                return false;
            }
        }

        private void SelectItem()
        {
            try
            {
                var itemS = (DataRowView)exListGridView.GetFocusedRow();
                var item = itemS.Row[2].ToString();

                CommandExcution("최신 수집 데이터", item);

                LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), "설비 데이터 조회 : " + item, false, false));

            }
            catch(Exception ex)
            {
                LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), ex.Message, true, true));
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void SelectItemDetail()
        {
            try
            {
                var dt = new DataTable();
                var itemS = (DataRowView)exMainView.GetFocusedRow();
                var itemTemp = itemS.Row[5].ToString();
                var item = itemS.Row[6].ToString();
                string cmd = string.Empty;
                if(itemTemp.Contains("온도"))
                    cmd = "SELECT TOP(100) * From FTOP320 Where GTR_ID = '" + item + "' order by MAKE_TIME DESC";
                else
                    cmd = "SELECT TOP(100) * From FTOP310 Where GTR_ID = '" + item + "' order by MAKE_TIME DESC";

               

                dt = _worker.SQLCommandToDatatable(cmd);
                LogS.Add(new FTOPLog(DateTime.Now, "접점 이력 조회", item.ToString(), "TOP 100개만 조회 됩니다. 전체 카운트 : " + dt.Rows.Count, false, false));
                var frmDetail = new FrmObserverDetail(dt);
                frmDetail.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frmDetail.ShowDialog();

                frmDetail.Dispose();
                frmDetail = null;

            }
            catch (Exception ex)
            {
                LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), ex.Message, true, true));
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewChange(ViewMode mode)
        {
            try
            {
                if(mode == ViewMode.Collapse)
                    exMainView.CollapseAllGroups();
                else if (mode == ViewMode.Expand)
                    exMainView.ExpandAllGroups();
        
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void ExportToExcel()
        {
            try
            {
                var saveDig = new SaveFileDialog();
                saveDig.Filter = "Excel File|*.Xls";
                saveDig.Title = "Save an Excel File";
                if (saveDig.ShowDialog()== DialogResult.OK)
                {
                    exMainView.ExportToXls(saveDig.FileName);
                    SystemLog.WriteLog(this.ToString(), "Export : " + saveDig.FileName);
                }              
            }
            catch(Exception ex)
            {
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void ExportToPDF()
        {
            try
            {
                var saveDig = new SaveFileDialog();
                saveDig.Filter = "PDF File|*.pdf";
                saveDig.Title = "Save an PDF File";
                if (saveDig.ShowDialog() == DialogResult.OK)
                {
                    exMainView.ExportToPdf(saveDig.FileName);
                    SystemLog.WriteLog(this.ToString(), "Export : " + saveDig.FileName);
                    
                } 
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void ExportToRtf()
        {
            try
            {
                var saveDig = new SaveFileDialog();
                saveDig.Filter = "Rtf File|*.Rtf";
                saveDig.Title = "Save an Rtf File";
                if (saveDig.ShowDialog() == DialogResult.OK)
                {

                    exMainView.ExportToRtf(saveDig.FileName);
                    SystemLog.WriteLog(this.ToString(),"Export : "  + saveDig.FileName);
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void PLCPingTest()
        {
            try
            {
                var frmPLCPingTest = new FrmPLCPingTest();
                frmPLCPingTest.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frmPLCPingTest.Show();
            }
            catch (Exception ex)
            {
                LogS.Add(new FTOPLog(DateTime.Now, EMLogSenderType.Information.ToString(), this.ToString(), ex.Message, true, true));
                SystemLog.WriteLog("FOTP-Observer", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }


        private void SendReport()
        {
            var hour = Int16.Parse(_frmOb.ReportSendTime.Replace(" hour", ""));
            _reportTimer.Interval = (60 * 60 * 1000) * hour;
            _reportTimer.Start();

            _reportTimer_Elapsed(null, null);
        }

        private void StopReport()
        {
            _reportTimer.Stop();
        }

        private void _reportTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                exMainView.FindFilterText = string.Empty;

                var result = _worker.SQLCommandToDatatable(GetReportCmd());
                if (result != null)
                {
                    exMainView.Columns.Clear();
                    exMainGrid.DataSource = result;
                    exMainView.GroupPanelText = "Update Completed : " + DateTime.Now.ToString();
                    if (ObserverStatus != null)
                        ObserverStatus(this, "Update Completed : " + DateTime.Now.ToString());

                    var path = Application.StartupPath + "\\Report.xls";

                    FileInfo fileDel = new FileInfo(path);
                    if (fileDel.Exists)
                        fileDel.Delete();

                    exMainView.Columns[4].GroupIndex = 0;
                    exMainView.ExpandAllGroups();
                    exMainView.ExportToXls(path);

                    var id = "hochul8708@udmtek.com";
                    var senderName = "FTOP Reporter";
                    var title = "미신호 포인트 현황 리포트 (" + _frmOb.ReportCyleTime + " 동안 신호를 받지 못한 포인트)";
                    var body = "미신호 포인트 입니다. 현재 리포트 주기는 " + _frmOb.ReportSendTime + "입니다. 첨부 파일 확인 부탁드립니다.";


                    System.Threading.Thread.Sleep(300);
                    SendEmail(id, senderName, title, body, "ysjo@dypiston.co.kr", path);
                    System.Threading.Thread.Sleep(300);
                    SendEmail(id, senderName, title, body, "kdh@coever.com", path);
                    System.Threading.Thread.Sleep(300);
                    SendEmail(id, senderName, title, body, id, path);
                    System.Threading.Thread.Sleep(300);

                    LogS.Add(new FTOPLog(DateTime.Now, "미신호 포인트", this.ToString(), "이메일 전송 완료", true, true));
                }
                else
                {
                    if (ObserverStatus != null)
                        ObserverStatus(this, "Command Failed...Retry Please..." + DateTime.Now.ToString());
                    exMainView.GroupPanelText = "Command Failed...Retry Please..." + DateTime.Now.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private string GetReportCmd()
        {
            var hour = Int16.Parse(_frmOb.ReportCyleTime.Replace(" hour", ""));

            var standardTime = DateTime.Now - TimeSpan.FromHours(hour);
            var timeString = standardTime.ToString("yyyyMMddHHmmss.fff");

            var cmd = "SELECT * FROM dbo.FTOP200 WHERE MAkE_TIME < '" + timeString + "'";
            return cmd;
        }

        public bool SendEmail(string id, string sender, string title, string body, string reciver, string attachFilePath)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(id, sender, System.Text.Encoding.UTF8);
                message.To.Add(reciver);
                message.Subject = title;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Attachments.Add(new Attachment(attachFilePath));

                var server = new SmtpClient("smtp.gmail.com", 587);
                server.UseDefaultCredentials = false;
                server.EnableSsl = true;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                server.Credentials = new System.Net.NetworkCredential("hochul8708@gmail.com", "zpfhfh2017!");
                server.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
