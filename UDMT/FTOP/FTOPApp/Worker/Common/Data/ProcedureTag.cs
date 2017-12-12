using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public class ProcedureTag : IObject
    {
        public string Key { get; set; }

        public string CORP_CD { get; set; }
        public string GTR_ID { get; set; }

        public string IF_MES_RSLT { get; set; }
        public string IF_CPS_RSLT { get; set; }

        public string EQM_CD { get; set; }
        public string PLANT_NM { get; set; }

        public string SendedTime { get; set; }
        public string Value { get; set; }

        public ProcedureTag()
        {

        }


    }
}
