using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewIOMaker.Event
{
    public delegate void delTagHMIExportMenuEvent(string part);
    public delegate void delTagGeneratorMenuEvent(object sender);
    public delegate void delTagGeneratorOpenSaveEvent(string option);
    public delegate void delTagGeneratorColorEvent(Color color);
    public delegate void delTagGeneratorColorDataSourceInputEvent(int row);

    public delegate void ThresholdReachedEventHandler(TagGeneratorPLCMenuEventArgs e);
    public delegate void delGridImportAfter(string Temp);
    public delegate void delGridIHMIDataConfirm(string Temp);

    public delegate void delPLCSelectedEvent(object sender, string PLC, int CPU);
    public delegate void delBackupCallEvent(object sender);
    public delegate void delBackupTimeEvent(object sender);

}
