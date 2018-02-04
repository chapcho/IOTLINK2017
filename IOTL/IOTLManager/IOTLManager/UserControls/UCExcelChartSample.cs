using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IOTLManager.UserControls
{
    public partial class UCExcelChartSample : UserControl
    {
        public UCExcelChartSample()
        {
            InitializeComponent();
            
        }

        private void CreateExcelChartToPicture()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Add Data Columns

            xlWorkSheet.Cells[1, 1] = "SL";
            xlWorkSheet.Cells[1, 2] = "Name";
            xlWorkSheet.Cells[1, 3] = "CTC";
            xlWorkSheet.Cells[1, 4] = "DA";
            xlWorkSheet.Cells[1, 5] = "HRA";
            xlWorkSheet.Cells[1, 6] = "Conveyance";
            xlWorkSheet.Cells[1, 7] = "Special";
            xlWorkSheet.Cells[1, 7] = "Bonus";
            xlWorkSheet.Cells[1, 9] = "TA";
            xlWorkSheet.Cells[1, 10] = "TOTAL";

            Excel.Application xlApp1 = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp1.Workbooks.Open(@"C:\Sample\Employee.xlsx");
            Excel._Worksheet worksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    Console.WriteLine(xlRange.Cells[i, j]
                       .Value2.ToString());
                    xlWorkSheet.Cells[i, j] = xlRange.Cells[i, j]
                                      .Value2.ToString();

                }
            }
            Console.ReadLine();

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)
               xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)
               xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;
            chartRange = xlWorkSheet.get_Range("A1", "R22");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            // Export chart as picture file
            chartPage.Export(@"C:\Sample\EmployeeExportData.bmp","BMP", misValue);

            xlWorkBook.SaveAs("EmployeeExportData.xls",
                Excel.XlFileFormat.xlWorkbookNormal, misValue,
                misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            DeallocateObject(xlWorkSheet);
            DeallocateObject(xlWorkBook);
            DeallocateObject(xlApp);
            DeallocateObject(xlApp1);

        }

        private static void DeallocateObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExcelPic_Click(object sender, EventArgs e)
        {
            CreateExcelChartToPicture();
        }
    }
}
