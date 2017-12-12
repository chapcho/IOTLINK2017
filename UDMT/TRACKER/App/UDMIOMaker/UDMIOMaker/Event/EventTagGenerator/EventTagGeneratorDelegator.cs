using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Event.Event_TagGenerator
{

    public delegate void ThresholdReachedEventHandler(TagGeneratorPLCMenuEventArgs e);

    public delegate void delGridImportAfter(string Temp);
    public delegate void delGridIHMIDataConfirm(string Temp);

    public delegate void delHomeNewClick(object sender);
    public delegate void delHomeOpenClick(object sender);
    public delegate void delHomeSaveClick(object sender);

    public delegate void delPLCawlClick(object sender);
    public delegate void delPLCsdfClick(object sender);
    public delegate void delPLCcsvClick(object sender);
    public delegate void delPLCl5kClick(object sender);
    public delegate void delPLCdeveloperClick(object sender);
    public delegate void delPLCworks2Click(object sender);
    public delegate void delPLCworks3Click(object sender);
    public delegate void delPLCxg5000Click(object sender);
    public delegate void delPLCcxClick(object sender);
    public delegate void delPLCsxClick(object sender);
    public delegate void delPLCfpwinClick(object sender);
    public delegate void delPLCwingpcClick(object sender);
    public delegate void delPLCkvClick(object sender);

    public delegate void delHMILSISClick(object sender , string HMI);
    public delegate void delHMILSImportTagClick(object sender);
    public delegate void delHMILSExportTagClick(object sender);
    public delegate void delHMILSExportAlarmClick(object sender);

    public delegate void delPLCSelectedEvent(object sender, string PLC, int CPU);

}
