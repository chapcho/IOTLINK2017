using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Event.Event_IOMaker
{
    public delegate void delIOMakerMenuSelectEvent(object sender,string PLC);
    public delegate void delIOMakerMenuEvent(object sender);
    public delegate void delIOMakerExportEvent(object sender,string path);
}
