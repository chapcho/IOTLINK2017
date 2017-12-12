using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace FTOPApp
{
    public partial class FrmPLCPingTest : DevExpress.XtraEditors.XtraForm
    {
        public DataTable PLCDB = new DataTable();

        public FrmPLCPingTest()
        {
            InitializeComponent();

            this.Load += FrmPLCPingTest_Load;
            this.groupControl1.CustomButtonClick += groupControl1_CustomButtonClick;
            this.exGridView.RowCellStyle += exGridView_RowCellStyle;
        }

        private void exGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var View = sender as GridView;
            if (e.Column.FieldName == "테스트 결과")
            {
                var result = View.GetRowCellDisplayText(e.RowHandle, View.Columns["테스트 결과"]);
                if (result == "True")
                {
                    e.Appearance.BackColor = System.Drawing.Color.SkyBlue;
                }
                else if (result == "False")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Salmon;
                    e.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
                }
            }
        }



        private void FrmPLCPingTest_Load(object sender, EventArgs e)
        {

            var dt = new DataTable();
            dt.Columns.Add("PLC");
            dt.Columns.Add("IP");
            dt.Columns.Add("테스트 결과");

            var sr = new StreamReader(Application.StartupPath + "\\DYPFTOP_PLC_IP.csv", Encoding.GetEncoding("euc-kr"));
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');

                var dr = dt.NewRow();
                dr[0] = temp[0];
                dr[1] = temp[1];

                dt.Rows.Add(dr);
            }

            PLCDB = dt;

            exGrid.DataSource = PLCDB;
        }

        private async void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

            exGridView.GroupPanelText = "조회 시간 : " + DateTime.Now.ToString();

            ClearResult();

            var ping = new Ping();

            foreach (DataRow r in PLCDB.Rows)
            {
                var reply = await ping.SendPingAsync(r["IP"].ToString());
                if(reply.Status == IPStatus.Success)
                {
                    r["테스트 결과"] = "True";
                }
                else
                {
                    r["테스트 결과"] = "False";
                }

                ping.SendAsyncCancel();
            }

            ping = null;
            
        }

        private void ClearResult()
        {
            foreach (DataRow r in PLCDB.Rows)
            {
                r["테스트 결과"] = "";
            }
        }

    }
}