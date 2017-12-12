using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{

    //MES 기준 정보
    public enum EMFTOP100Columns
    {
        CORP_CD,
        GTR_ID,
        EQM_CD,
        ITEM_CD,
        ITEM_DETAIL_CD,
        ITEM_DETAIL_NM,
        EQM_NM,
        PLANT_CD,
        PLANT_NM,
        LINE_CD,
        LINE_NM,
        OP_CD,
        OP_NM,
        DESCR,
        REG_USER,
        REG_DATE,
        UPD_USER,
        UPD_DATE,
        USE_YN,
    }

    //LS 기준 정보
    public enum EMFTOP110Columns
    {
        CORP_CD,
        GTR_ID,
        PLC_NM,
        PLC_CHNL,
        PLC_ADDR,
        PLC_TYPE,
        EQM_IP_ADDR,
        EQM_IP_PORT,
        DATA_TYPE,
        IF_TARGET,
        ADDR_TAG,
        DESCR,
        REG_USER,
        REG_DATE,
        UPD_USER,
        UPD_DATE,
        USE_YN,
    }

    // 최신 기록 정보
    public enum EMFTOP200Columns
    {
        CORP_CD,
        GTR_ID,
        MAKE_TIME,
        VALUE_DATA,
        IF_MES_YN,
        IF_MES_RSLT,
        IF_MES_TIME,
        IF_CPS_YN,
        IF_CPS_RSLT,
        IF_CPS_TIME,
        REG_USER,
        REG_DATE,
        UPD_USER,
        UPD_DATE,
    }

    // 모든 데이터 기록 정보
    public enum EMFTOP300Columns
    {
        CORP_CD,
        GTR_ID,
        MAKE_TIME,
        VALUE_DATA,
        IF_MES_YN,
        IF_MES_RSLT,
        IF_MES_TIME,
        IF_CPS_YN,
        IF_CPS_RSLT,
        IF_CPS_TIME,
        REG_USER,
        REG_DATE,
        UPD_USER,
        UPD_DATE,
    }

    // FTOP 테이블 정보
    public enum EMFTOPTable
    {
        T100,
        T110,
        T200,
        T300,
    }
}
