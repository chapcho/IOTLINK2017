using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public enum EMLadderBlockTpye
    {
        NONE,
        COMMAND,
        STATEMENT,
        CONTACT,
        DOT,
        OTHER,
        Header_K,
        Header_AT,
        Index_Z
    }
}
