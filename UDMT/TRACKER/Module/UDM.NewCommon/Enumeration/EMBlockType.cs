using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public enum EMBlockType
    {
        Datablock,
        FunctionBlock,
        Function,
        DummryBlock,
        OrganizationBlock,
        UserDefinedType
    }
}
