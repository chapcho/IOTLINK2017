using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewIOMaker.Enumeration;

namespace NewIOMaker.Event
{
    public delegate void delIOMakerMenuEvent(object sender);
    public delegate void delIOMakerExportEvent(object sender);
    public delegate void delIOMakerIOListLoad(object sender);
    public delegate void delIOMakerExcelExportProcess(object sender, int nProcess);

    public delegate void delIOMakerMenuSelectEvent(object sender,string PLC);
    public delegate void delIOMakerPLCVerificationEvent(object sender, EMPLCVerificationMenu menu);
}
