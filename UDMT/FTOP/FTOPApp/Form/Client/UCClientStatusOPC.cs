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
    public partial class UCClientStatusOPC : UserControl
    {
        private UCPLCRegister _register;

        public UCClientStatusOPC(UCPLCRegister register )
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

        private void ConnectStatus(EMConnectType type , EMConnectStatus status)
        {
            if(type == EMConnectType.OPC)
            {
                if(status == EMConnectStatus.Connenct)
                {
                    ComponentOPC.StateIndex = (int)EMStatusIndex.green;
                }
                else
                {
                    ComponentOPC.StateIndex = (int)EMStatusIndex.off;
                }
            }
        }
    }
}
