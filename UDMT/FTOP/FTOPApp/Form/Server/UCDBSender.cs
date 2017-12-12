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

namespace FTOPApp
{
    public partial class UCDBSender : UserControl ,IWorker
    {
        public BindingList<ProcedureTag> TagS = new BindingList<ProcedureTag>();
        public BindingList<FTOPLog> LogS = new BindingList<FTOPLog>();
        public CSystemLog SystemLog = null;
        private ServerWorker _serverWorker;
        public DevExpress.XtraGrid.Views.Grid.GridView LogGridView;
        public int MaximunLogsLine = 1000;

        public UCDBSender(UCServerLog FTOPLogS, string LogPath)
        {
            InitializeComponent();

            LogS = FTOPLogS.LogS;
            LogGridView = FTOPLogS.GridAddView;

            SystemLog = new CSystemLog(LogPath, "FTOP-Server");
 
            _serverWorker = new ServerWorker();
            _serverWorker.LogMessage += _serverWorker_LogMessage;
            _serverWorker.DataSended += _serverWorker_DataSended;
            _serverWorker.Counted += _serverWorker_Counted;

            exGrdiVeiw.MouseUp += exGrdiVeiw_MouseUp;
            btnGridViewClear.Click += btnGridViewClear_Click;
            GridGroup.CustomButtonClick += (o, s) => { MenuSelect(s.Button.Properties.Caption); };
         
        }

        private void btnGridViewClear_Click(object sender, EventArgs e)
        {
            try
            {
                TagS.Clear();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void exGrdiVeiw_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    contextMenuStrip1.Show(CurrentPoint);
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void _serverWorker_Counted(object sender, int count)
        {
            try
            {
                Invoke(new MethodInvoker(delegate()
                {
                    exGrdiVeiw.GroupPanelText = "전송 대기 포인트 : " + count;
                }));
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void _serverWorker_DataSended(object sender, ProcedureTag tag)
        {
            try
            {
                Invoke(new MethodInvoker(delegate()
                {
                    if (TagS.Count > MaximunLogsLine)
                        TagS.RemoveAt(0);
                    TagS.Add(tag);
                }));
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void _serverWorker_LogMessage(object sender, LogEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(delegate()
                {
                    if (LogS.Count > MaximunLogsLine)
                        LogS.RemoveAt(0);

                    if (e.fTopLog.IsException == true || e.fTopLog.IsWarning == true)
                        LogS.Add(e.fTopLog);
                    LogGridView.GroupPanelText = DateTime.Now.ToString() + " -> " + e.fTopLog.Message;

                }));
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void MenuSelect(string menu)
        {
            if(EMServerMenu.Run.ToString() == menu)
                Run();
            else if(EMServerMenu.Stop.ToString() == menu)
                Stop();
            else if (EMServerMenu.Option.ToString() == menu)
                ServerOption();
            else if (EMServerMenu.ReConnect.ToString() == menu)
                MWReconnect();
        }

        public void Run()
        {
            _serverWorker.Run();
            GetStandardData();
        }

        public void Stop()
        {
            _serverWorker.Stop();
        }

        public void Reset()
        {
            //reject
        }

        public void MWReconnect()
        {
            _serverWorker.ReConnectMW();
        }

        public void ServerOption()
        {
            if (_serverWorker == null) return;

            var frmOption = new FrmServerOption(_serverWorker.IntervalTime, _serverWorker.SendMode, _serverWorker.UseCPS, _serverWorker.UseMES, _serverWorker.UseASC, _serverWorker.TransCount);
            frmOption.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frmOption.ShowDialog();

            _serverWorker.IntervalTime = frmOption.Interval; //interval -> 100 defualt
            _serverWorker.SendMode = frmOption.TransportMode;
            _serverWorker.UseCPS = frmOption.UseCPS;
            _serverWorker.UseMES = frmOption.UseMES;
            _serverWorker.UseASC = frmOption.UseACS;
            _serverWorker.TransCount = frmOption.SendCount;

            frmOption.Dispose();
            frmOption = null;
        }

        private void GetStandardData()
        {      
            try
            {
                exGrid.DataSource = _serverWorker.FOTP110.DefaultView.ToTable(false, new string[] { "GTR_ID", "PLC_ADDR", "PLC_TYPE", "DATA_TYPE", "IF_TARGET" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog("FTOP-Server", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

    }
}
