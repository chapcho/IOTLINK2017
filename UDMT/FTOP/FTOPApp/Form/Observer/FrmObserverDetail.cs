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

namespace FTOPApp
{
    public partial class FrmObserverDetail : DevExpress.XtraEditors.XtraForm
    {
        public FrmObserverDetail(DataTable dt)
        {
            InitializeComponent();

            groupControl1.CustomButtonClick += groupControl1_CustomButtonClick;

            try
            {
                exGrid.DataSource = SetData(dt);
                GridViewOnOff(false);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
           try
           {
               if (e.Button.Properties.Caption == "전체 보기")
               {
                   GridViewOnOff(true);
               }
               else if (e.Button.Properties.Caption == "일부 보기")
               {
                   GridViewOnOff(false);
               }
               else if (e.Button.Properties.Caption == "컬럼 최적화")
               {
                   exGridView.BestFitColumns();
               }
               else if (e.Button.Properties.Caption == "내보내기 ( 엑셀 )")
               {
                   ExportToExcel();
               }
           }
           catch(Exception ex)
           {
              
           }

        }

        private void ExportToExcel()
        {
            try
            {
                var saveDig = new SaveFileDialog();
                saveDig.Filter = "Excel File|*.Xls";
                saveDig.Title = "Save an Excel File";
                if (saveDig.ShowDialog() == DialogResult.OK)
                {
                    exGridView.ExportToXls(saveDig.FileName);
                    
                }
            }
            catch (Exception ex)
            {
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
                    exGridView.ExportToPdf(saveDig.FileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private DataTable SetData(DataTable dt)
        {
            //string startTime = "7:00";
            //string endTime = "14:00";

            //TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            //dtDate = DateTime.ParseExact(strDate, "yyyyMMdd", null);
            try
            {
                dt.Columns.Add("Different Time");

                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    DateTime t1;
                    DateTime t2;
                    var afterTime = dt.Rows[i + 1][2].ToString();
                    if (afterTime.Contains("."))
                        t1 = DateTime.ParseExact(afterTime.Split('.')[0], "yyyyMMddHHmmss", null);
                    else
                        t1 = DateTime.ParseExact(afterTime, "yyyyMMddHHmmss", null);

                    var beforTime = dt.Rows[i][2].ToString();
                    if (beforTime.Contains("."))
                        t2 = DateTime.ParseExact(beforTime.Split('.')[0], "yyyyMMddHHmmss", null);
                    else
                        t2 = DateTime.ParseExact(beforTime, "yyyyMMddHHmmss", null);

                    var result = t2 - t1;

                    dt.Rows[i]["Different Time"] = result;
                }

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return dt;
            }

            
        }

        private void GridViewOnOff(bool select)
        {
            if(select)
            {
                exGridView.Columns[0].Visible = true;
                exGridView.Columns[4].Visible = true;
                exGridView.Columns[6].Visible = true;
                exGridView.Columns[7].Visible = true;
                exGridView.Columns[9].Visible = true;
                exGridView.Columns[10].Visible = true;
                exGridView.Columns[11].Visible = true;
                exGridView.Columns[12].Visible = true;
                exGridView.Columns[13].Visible = true;

                exGridView.Columns[1].GroupIndex = 0;
                exGridView.ExpandAllGroups();
            }
            else
            {
                exGridView.Columns[0].Visible = false;
                exGridView.Columns[4].Visible = false;
                exGridView.Columns[6].Visible = false;
                exGridView.Columns[7].Visible = false;
                exGridView.Columns[9].Visible = false;
                exGridView.Columns[10].Visible = false;
                exGridView.Columns[11].Visible = false;
                exGridView.Columns[12].Visible = false;
                exGridView.Columns[13].Visible = false;

                exGridView.Columns[1].GroupIndex = 0;
                exGridView.ExpandAllGroups();
            }

        }
    }
}