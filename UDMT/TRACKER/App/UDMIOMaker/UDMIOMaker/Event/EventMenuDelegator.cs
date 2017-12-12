using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewIOMaker.Enums;

namespace NewIOMaker.Event
{
    public delegate void delMenuClickEvent(object sender);

    public delegate void delPageClickEvent(EMCommonPageInfo sender);

    public delegate void delLogInputEvent(LogEventArgs e);
}
