using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UDM.Common;
using OPCAutomation;
using System.Threading;
using UDM.Log;

namespace FTOPApp
{
    public partial class UCPLCRegister : UserControl , IWorker
    {

        public event UEventHandlerConnectEvent ConnectEvent;
        public CSystemLog SystemLog = null;
        private ClientWorker _clientWorker;

        public DevExpress.XtraGrid.Views.Grid.GridView GridAddView;
        public BindingList<FTOPLog> LogS;
        public int MaximunLogsLine = 50;

        public UCPLCRegister(UCClientLog FTOPLogS, string LogPath)
        {
            InitializeComponent();

            SystemLog = new CSystemLog(LogPath,"FTOP-Client");
            
            LogS = FTOPLogS.LogS;
            GridAddView = FTOPLogS.GridAddView;

            _clientWorker = new ClientWorker(SystemLog);
            _clientWorker.LogMessage += (o, s) =>  
            { 
                try
                {
                    Invoke(new MethodInvoker(delegate()
                    {
                        if (LogS.Count > MaximunLogsLine)
                            LogS.RemoveAt(0);

                        if (s.fTopLog.IsException == true || s.fTopLog.IsWarning == true)
                            LogS.Add(s.fTopLog);

                        GridAddView.GroupPanelText = DateTime.Now.ToString() + " -> " + s.fTopLog.Message;
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    SystemLog.WriteLog("FTOP-Client", ex.Message);
                }

            };

            this.Load += UCPLCRegister_Load;
            this.Disposed += UCPLCRegister_Disposed;
        }

        private void UCPLCRegister_Load(object sender, EventArgs e)
        {
            LogS.Add(SetLog(DateTime.Now, "Information", this.ToString(), "FTOP Client Mode -> ON", false));

            GridGroup.CustomButtonClick += GridGroup_CustomButtonClick;
        }

        private void UCPLCRegister_Disposed(object sender, EventArgs e)
        {
            
        }

        private void GridGroup_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Tag Register")
                TagRegister();
            if (e.Button.Properties.Caption == "RUN")
                Run();
            if (e.Button.Properties.Caption == "STOP")
                Stop();
            if (e.Button.Properties.Caption == "DCOM")
                DCOMSetting();
        }

        private void TagRegister()
        {
            
            var frmOPC = new FrmOPCSetting(_clientWorker.OPCServerList);
            frmOPC.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frmOPC.ShowDialog();

            if (frmOPC.SelectedServer != string.Empty)
            {
                _clientWorker.ServerName = frmOPC.SelectedServer;
                _clientWorker.ClientNumber = frmOPC.SelectedopcNum;
                var dbOK = _clientWorker.TagRegister();

                GridGroup.Text = "  Working FTOP Client Number  : " + _clientWorker.ClientNumber.ToString();
                exGrid.DataSource = _clientWorker.TagS;
                //exGrdiVeiw.ExpandAllGroups();

                ConnectEvent(EMConnectType.OPC, EMConnectStatus.Connenct);

                if(dbOK)
                    ConnectEvent(EMConnectType.DB, EMConnectStatus.Connenct);
            }

            frmOPC.Dispose();
            frmOPC = null;
        }

        public void Run()
        {
            if (_clientWorker !=null)
            {
                _clientWorker.Run();
                ConnectEvent(EMConnectType.DB, EMConnectStatus.Connenct);
                ConnectEvent(EMConnectType.OPC, EMConnectStatus.Connenct);
            }
                         
        }

        public void Stop()
        {
            if(_clientWorker != null)
            {
                _clientWorker.Stop();
                ConnectEvent(EMConnectType.DB, EMConnectStatus.DisConnect);
                ConnectEvent(EMConnectType.OPC, EMConnectStatus.DisConnect);
            }

        }

        public void Reset()
        {

        }

        public void DCOMSetting()
        {
            var dcomUsed = _clientWorker.OpcServer.Config.DCOM;
            var remoteAddress = _clientWorker.OpcServer.Config.RemoteAddress;
            var frmDCOM = new FrmDcomSetting(dcomUsed, remoteAddress);
            frmDCOM.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frmDCOM.ShowDialog();

            _clientWorker.OpcServer.Config.DCOM = frmDCOM.IsDCOMUsed;
            _clientWorker.OpcServer.Config.RemoteAddress = frmDCOM.RemoteAddress;

            frmDCOM.Dispose();
            frmDCOM = null;
        }

        private FTOPLog SetLog(DateTime time, string type, string sender, string messgae, bool isException)
        {

            var clientLog = new FTOPLog();

            clientLog.IsException = isException;
            clientLog.Time = time;
            clientLog.Sender = sender;
            clientLog.Type = type;
            clientLog.Message = messgae;

            return clientLog;

        }

    }
}
