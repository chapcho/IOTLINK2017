using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTOPApp
{
    public partial class UCDBConnect : UserControl
    {

        private DBWorker _worker;
        public bool IsConnected = false;
       
        public UCDBConnect()
        {
            InitializeComponent();

            _worker = new DBWorker();

            IsConnected = _worker.Connect();
            labelStatus.Text = "Connenct Status : " + IsConnected.ToString();

            _worker.UEventDBDataReaded += (s, o) => { };

            btnCommand.Click += (o, s) => { CommandExcution(); };
            btnColumnAllShow.Click += (o, s) => { GridColumnOption(true); };
            btnColumnHide.Click += (o, s) => { GridColumnOption(false); };
            btnColumnBestFit.Click += (o, s) => { exGridView.BestFitColumns(); };
            btnViewMode.Click += (o, s) => { ViewModeChange(); };
            btnExport.Click += (o, s) => { ExcelExport(); };
            
            this.Disposed += (o, s) => { DisConnect(); };

            exGridView.MouseUp += (o, s) => { GrudMenuOpen(s); };
        }

        private void DisConnect()
        {
            if (_worker !=null)
                _worker.DisConnect();
        }

        private void CommandExcution()
        {
            if (IsConnected)
            {
                var bOK = false;
                if (_worker == null) return;
                var command = textBoxCommand.EditValue.ToString();
                if(command=="Report")
                {
                    command = "SELECT A.PLANT_NM,A.LINE_NM,A.OP_NM,A.EQM_CD,A.EQM_NM,A.ITEM_DETAIL_NM,A.GTR_ID, B.PLC_ADDR,C.VALUE_DATA,C.MAKE_TIME " + 
                              "FROM dbo.FTOP100 as A INNER JOIN dbo.FTOP110 as B ON A.CORP_CD = B.CORP_CD AND A.GTR_ID = B.GTR_ID "+
                              "INNER JOIN dbo.FTOP200 as C ON A.GTR_ID = C.GTR_ID WHERE C.MAKE_TIME IS NOT NULL ORDER BY LINE_NM ,EQM_CD , MAKE_TIME";
                    bOK = true;
                }

                var result = _worker.SQLCommandToDatatable(command);
                if (result != null)
                {
                    exGridView.Columns.Clear();
                    exGrid.DataSource = result;
                    labelStatus.Text = "Update Completed....";

                    if (exGridView.Columns.Count>6)
                    {
                        if (bOK)
                        {
                            exGridView.Columns[0].GroupIndex = 0;
                            exGridView.Columns[1].GroupIndex = 1;
                            exGridView.Columns[3].GroupIndex = 2;
                        }
                        else
                            exGridView.Columns[5].GroupIndex = 0; 
                    }

                    exGridView.ExpandAllGroups();   
                }
                else
                    labelStatus.Text = "Command Failed...Retry Please...";
            }
            else
            {
                IsConnected = _worker.Connect();
                labelStatus.Text = "Connenct Status : " + IsConnected.ToString();
            }

            
        }

        private void GrudMenuOpen(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                MenuGridView.Show(CurrentPoint);
            }
        }

        private void GridColumnOption(bool IsShow)
        {
            try
            {
                if (IsShow)
                {
                    //5 ~22
                    for (int i = 5; i < 22;i++ )
                    {
                        exGridView.Columns[i].Visible = true;
                    }
                        
                }
                else
                {
                    //5 ~22
                    for (int i = 5; i < 22; i++)
                    {
                        exGridView.Columns[i].Visible = false;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ViewModeChange()
        {
            exGridView.ExpandAllGroups();   
        }

        private void ExcelExport()
        {
            var open = new SaveFileDialog();
            open.Filter = "Excel File|*.Xls";
            open.Title = "Save an Excel File";
            
            if(open.ShowDialog() == DialogResult.OK)
            {
                exGridView.ExportToXls(open.FileName);
            }
        }

    }
}
