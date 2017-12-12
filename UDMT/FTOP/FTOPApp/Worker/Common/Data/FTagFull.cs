using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public class FTOPTagFull : IObject, IPLC, IMES, ICPS, IOPC, ICloneable ,IDisposable
    {
        //base
        public string OPCChannel { get; set; }
        public string OPCDevice { get; set; }
        public string SendTarget { get; set; }

        public string REG_USER { get; set; }
        public string UPD_USER { get; set; }

        //IObject
        public string Key { get; set; }

        //IPLC
        public EMFTOPPLCMaker PLCMaker { get; set; }
        public EMPLCDataType PLCDataType { get; set; }
        public string PLCHardWareInfo { get; set; }
        public string PLCIPAddress { get; set; }
        public string PLCAddress { get; set; }
        public string PLCName { get; set; }
        public string PLCDESC { get; set; }
        public int PLCValue { get; set; }

        //IMES
        public string CORP_CD { get; set; }
        public string GTR_ID { get; set; }
        public string PLANT_CD { get; set; }
        public string LINE_CD { get; set; }
        public string OP_CD { get; set; }
        public string EQM_CD { get; set; }
        public string ITEM_CD { get; set; }
        public string ITEM_DETAIL_CD { get; set; }
        public string ITEM_DETAIL_NM { get; set; }
        public bool USE_YN { get; set; }
        public DateTime REG_DATE { get; set; }
        public DateTime UP_DATE { get; set; }
        public DateTime MAKE_TIME { get; set; }
        //ICPS

        //IOPCServer
        public EMOPCType OPCType { get; set; }
        public int OPCID { get; set; }

        public string Empty = "Empty";

        public FTOPTagFull()
        {
            //default Setting

            Key = Empty;

            PLCMaker = EMFTOPPLCMaker.LS;
            PLCDataType = EMPLCDataType.Bool;
            OPCType = EMOPCType.OPCWorkX;
            SendTarget = EMTarget.MES.ToString();

        }

        public void Dispose()
        {

        }

        public object Clone()
        {
            // Member Variable 확정되면 Clone 추가 예정임....

            var tag = new FTOPTagFull();

            tag.OPCChannel = OPCChannel;
            tag.OPCDevice = OPCDevice;
            tag.OPCID = OPCID;
            tag.OPCType = OPCType;
            tag.PLANT_CD = PLANT_CD;

            tag.PLCDESC = PLCDESC;
            tag.PLCValue = PLCValue;
            tag.PLCName = PLCName;
            tag.PLCAddress = PLCAddress;
            tag.OPCDevice = OPCDevice;

            tag.PLANT_CD = PLANT_CD;
            tag.LINE_CD = LINE_CD;
            tag.OP_CD = OP_CD;
            

            tag.CORP_CD = CORP_CD;
            tag.GTR_ID = GTR_ID;
            tag.ITEM_CD = ITEM_CD;
            tag.ITEM_DETAIL_CD = ITEM_DETAIL_CD;
            tag.ITEM_DETAIL_NM = ITEM_DETAIL_NM;
            tag.USE_YN = USE_YN;

            tag.REG_USER = REG_USER;
            tag.UPD_USER = UPD_USER;
            tag.REG_DATE = REG_DATE;
            tag.UP_DATE = UP_DATE;
            tag.SendTarget = SendTarget;
            tag.Key = Key;

            tag.MAKE_TIME = MAKE_TIME;

            return tag;
        }
    }
}
