using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public class SQLCommander
    {
        public string LastResult { get; set; }
        public string FTOP100 { get; set; }
        public string FTOP110 { get; set; }
        public string FTOP200 { get; set; }
        public string FTOP300 { get; set; }
        public string FTOP310 { get; set; }
        public string CountFTOP300 { get; set; }
        public string CountFTOP310 { get; set; }
        public string RecentResult { get; set; }
        public string RecentResult0 { get; set; }
        public string RecentResult6 { get; set; }

        public SQLCommander()
        {
            SetCommand();
        }


        private void SetCommand()
        {
            LastResult = "SELECT A.PLANT_NM,A.LINE_NM,A.OP_NM,A.EQM_CD,A.EQM_NM,A.ITEM_DETAIL_NM,A.GTR_ID, B.PLC_ADDR,C.VALUE_DATA,C.MAKE_TIME " +
                         "FROM dbo.FTOP100 as A INNER JOIN dbo.FTOP110 as B ON A.CORP_CD = B.CORP_CD AND A.GTR_ID = B.GTR_ID " +
                         "INNER JOIN dbo.FTOP200 as C ON A.GTR_ID = C.GTR_ID WHERE C.MAKE_TIME IS NOT NULL ORDER BY LINE_NM ,EQM_CD , MAKE_TIME";

            FTOP100 = "SELECT * FROM dbo.FTOP100";
            FTOP110 = "SELECT * FROM dbo.FTOP110";
            FTOP200 = "SELECT * FROM dbo.FTOP200";
            FTOP300 = "SELECT * FROM dbo.FTOP300";
            FTOP310 = "SELECT * FROM dbo.FTOP310";

            CountFTOP300 = "SELECT COUNT(*) FROM FTOP300";
            CountFTOP310 = "SELECT COUNT(*) FROM FTOP310";

            RecentResult = "select TOP(100)* From FTOP310 order by MAKE_TIME DESC";
            RecentResult0 = "select TOP(100)* From FTOP310 Where IF_MES_RSLT = '00 || 정상 처리 되었습니다.' order by MAKE_TIME DESC";
            RecentResult6 = "select TOP(100)* From FTOP310 Where IF_MES_RSLT = '6' order by MAKE_TIME DESC";
        }
    }
}
