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
    public partial class UCClientStatusDB : UserControl
    {
        private UCPLCRegister _register;

        public UCClientStatusDB(UCPLCRegister register)
        {
            InitializeComponent();

            _register = register;

            _register.ConnectEvent += (o, s) => 
            { 
                try
                {
                    ConnectStatus(o, s); 
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            };
        }

        private void ConnectStatus(EMConnectType type, EMConnectStatus status)
        {
            if (type == EMConnectType.DB)
            {
                if (status == EMConnectStatus.Connenct)
                {

                    ComponentDB.StateIndex = (int)EMStatusIndex.green;
                }
                else
                {
                    ComponentDB.StateIndex = (int)EMStatusIndex.off;
                }
            }
        }
    }
}
