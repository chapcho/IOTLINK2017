using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public interface IMES
    {
        /// <summary> Name of 회사코드 </summary>
        string CORP_CD { get; set; }

        /// <summary> Name of 수집ID </summary>
        string GTR_ID { get; set; }

        /// <summary> Name of 공장코드 </summary>
        string PLANT_CD { get; set; }

        /// <summary> Name of 라인코드 </summary>
        string LINE_CD { get; set; }

        /// <summary> Name of 공정코드 </summary>
        string OP_CD { get; set; }

        /// <summary> Name of 설비코드 </summary>
        string EQM_CD { get; set; }

        /// <summary> Name of 관리 항목 코드 </summary>
        string ITEM_CD { get; set; }

        /// <summary> Name of 관리 세부 항목 코드 </summary>
        string ITEM_DETAIL_CD { get; set; }

        /// <summary> Name of 관리 세부 항목 명칭 </summary>
        string ITEM_DETAIL_NM { get; set; }

        /// <summary> Name of 사용유무 </summary>
        bool USE_YN { get; set; }

        /// <summary> Name of 사용유무 </summary>
        DateTime REG_DATE { get; set; }

        /// <summary> Name of 사용유무 </summary>
        DateTime UP_DATE { get; set; }
    }

}
