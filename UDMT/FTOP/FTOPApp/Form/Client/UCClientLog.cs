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
    public partial class UCClientLog : UserControl
    {

        public BindingList<FTOPLog> LogS = new BindingList<FTOPLog>();

        public DevExpress.XtraGrid.Views.Grid.GridView GridAddView;

        public UCClientLog()
        {
            InitializeComponent();

            GridAddView = exGridAddView;

            exGridAll.DataSource = LogS;

            try
            {
                exGridAddView.Columns["Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                exGridAddView.Columns["Time"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm:ss";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            exGridAddView.MouseUp += (o, e) => 
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    contextMenuStrip1.Show(CurrentPoint);
                }
            };

            btnClear.Click += (o, e) => 
            {
                try
                {
                    LogS.Clear(); 
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            };
        }


    }
}
