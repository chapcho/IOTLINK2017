using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NewIOMaker.Event
{
    public delegate void delMultiCopyMenuEvent(object sender);

    public delegate void delMultiCopyRunorStop();
    public delegate void delMultiCopyUseImport(string value);
    public delegate void delMultiCopyKey(object sender1, object sender2);
    public delegate void delMultiCopyKeyLoad(object sender);
    public delegate void delMultiKeyListUpdate(DataTable KeyDB);
    public delegate void delStatusBarChanged(string status);
    public delegate void delKeyListInputAfter(Dictionary<string, List<string>> dicKey);
    public delegate void delKeyListSelectAfter(string SelectKey, Dictionary<string, List<string>> dicKey);

}
