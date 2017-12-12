using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    public class CPlcTypeConverter
    {

        #region Public Method

        public EMConnectAppType GetConnectApplication(string sSource)
        {
            if (CheckConnectApplicationString(sSource) == false)
                return EMConnectAppType.None;

            return (EMConnectAppType)Enum.Parse(typeof(EMConnectAppType), sSource);
        }

        public EMPlcMaker GetPlcMaker(string sSource)
        {
            if (CheckPlcMakerString(sSource) == false)
                return EMPlcMaker.MITSUBISHI;
            
            return (EMPlcMaker)Enum.Parse(typeof(EMPlcMaker), sSource);
        }

        public EMConnectTypeMS GetConnectType(string sSource)
        {
            if (CheckConnectTypeString(sSource) == false)
                return EMConnectTypeMS.MNetG;

            return (EMConnectTypeMS)Enum.Parse(typeof(EMConnectTypeMS), sSource);
        }

        public EMCpuTypeMS GetPlcCpuType(string sSource)
        {
            if (CheckPlcCpuTypeString(sSource) == false)
                return EMCpuTypeMS.Q00;

            return (EMCpuTypeMS)Enum.Parse(typeof(EMCpuTypeMS), sSource);
        }

        public EMStationTypeMS GetStationType(string sSource)
        {
            if (CheckStationTypeString(sSource) == false)
                return EMStationTypeMS.Host;

            return (EMStationTypeMS)Enum.Parse(typeof(EMStationTypeMS), sSource);
        }

        public EMMultiCPUTypeMS GetMultiCpuType(string sSource)
        {
            if (CheckMultiCpuTypeString(sSource) == false)
                return EMMultiCPUTypeMS.None;

            return (EMMultiCPUTypeMS)Enum.Parse(typeof(EMMultiCPUTypeMS), sSource);
        }

        public EMMNetPCSlotTypeMS GetMnetPcSlotType(string sSource)
        {
            if (CheckMnetPcSlotTypeString(sSource) == false)
                return EMMNetPCSlotTypeMS.Slot1;

            return (EMMNetPCSlotTypeMS)Enum.Parse(typeof(EMMNetPCSlotTypeMS), sSource);
        }

        public EMENetModuleTypeMS GetEthernetModuleType(string sSource)
        {
            if (CheckEthernetModuleTypeString(sSource) == false)
                return EMENetModuleTypeMS.QJ71E71;

            return (EMENetModuleTypeMS)Enum.Parse(typeof(EMENetModuleTypeMS), sSource);
        }

        public EMENetProtocolTypeMS GetEthernetProtocolType(string sSource)
        {
            if (CheckEthernetProtocolTypeString(sSource) == false)
                return EMENetProtocolTypeMS.TCP;

            return (EMENetProtocolTypeMS)Enum.Parse(typeof(EMENetProtocolTypeMS), sSource);
        }

        public EMENetPacketTypeMS GetEthernetPacketType(string sSource)
        {
            if (CheckEthernetPacketTypeString(sSource) == false)
                return EMENetPacketTypeMS.ASCII;

            return (EMENetPacketTypeMS)Enum.Parse(typeof(EMENetPacketTypeMS), sSource);
        }

        public EMCollectMode GetCollectModeType(string sSource)
        {
            if (CheckCollectModeTypeString(sSource) == false)
                return EMCollectMode.Normal;

            return (EMCollectMode)Enum.Parse(typeof(EMCollectMode), sSource);
        }

        #region Enum -> String List


        public List<string> GetPlcMakerStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMPlcMaker.MITSUBISHI.ToString());
            //lstResult.Add(EMPLCMaker.SIEMENS.ToString());
            //lstResult.Add(EMPLCMaker.AB.ToString());
            //lstResult.Add(EMPLCMaker.OMRON.ToString());

            return lstResult;
        }

        public List<string> GetPlcMakerFullStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMPlcMaker.MITSUBISHI.ToString());
            lstResult.Add(EMPlcMaker.SIEMENS.ToString());
            lstResult.Add(EMPlcMaker.AB.ToString());
            lstResult.Add(EMPlcMaker.OMRON.ToString());

            return lstResult;
        }

        public List<string> GetConnectTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMConnectTypeMS.None.ToString());
            lstResult.Add(EMConnectTypeMS.MNetG.ToString());
            lstResult.Add(EMConnectTypeMS.MNetH.ToString());
            lstResult.Add(EMConnectTypeMS.Ethernet.ToString());
            //lstResult.Add(EMConnectType.USB.ToString());
            //lstResult.Add(EMConnectType.GXSim.ToString());

            return lstResult;
        }

        public List<string> GetConnectTypeFullStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMConnectTypeMS.None.ToString());
            lstResult.Add(EMConnectTypeMS.MNetG.ToString());
            lstResult.Add(EMConnectTypeMS.MNetH.ToString());
            lstResult.Add(EMConnectTypeMS.Ethernet.ToString());
            lstResult.Add(EMConnectTypeMS.USB.ToString());
            lstResult.Add(EMConnectTypeMS.GXSim.ToString());
            lstResult.Add(EMConnectTypeMS.GOT.ToString());

            return lstResult;
        }

        public List<string> GetStationTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMStationTypeMS.Host.ToString());
            lstResult.Add(EMStationTypeMS.Other.ToString());

            return lstResult;
        }

        public List<string> GetPlcCpuStringList()
        {
            List<string> lstResult = new List<string>();
            /* Sort안됨
            string[] arrCpu = Enum.GetNames(typeof(EMPlcCpuType));

            for (int i = 0; i < arrCpu.Length; i++)
            {
                lstResult.Add(arrCpu[i]);
            }*/
            lstResult.Add(EMCpuTypeMS.Q00.ToString());
            lstResult.Add(EMCpuTypeMS.Q00J.ToString());
            lstResult.Add(EMCpuTypeMS.Q01.ToString());
            lstResult.Add(EMCpuTypeMS.Q02H.ToString());
            lstResult.Add(EMCpuTypeMS.Q02H_A.ToString());
            lstResult.Add(EMCpuTypeMS.Q02PH.ToString());
            lstResult.Add(EMCpuTypeMS.Q02U.ToString());
            lstResult.Add(EMCpuTypeMS.Q03UD.ToString());
            lstResult.Add(EMCpuTypeMS.Q03UDE.ToString());
            lstResult.Add(EMCpuTypeMS.Q04UDEH.ToString());
            lstResult.Add(EMCpuTypeMS.Q04UDH.ToString());
            lstResult.Add(EMCpuTypeMS.Q06H.ToString());
            lstResult.Add(EMCpuTypeMS.Q06H_A.ToString());
            lstResult.Add(EMCpuTypeMS.Q06PH.ToString());
            lstResult.Add(EMCpuTypeMS.Q06UDEH.ToString());
            lstResult.Add(EMCpuTypeMS.Q06UDH.ToString());
            lstResult.Add(EMCpuTypeMS.Q12H.ToString());
            lstResult.Add(EMCpuTypeMS.Q12PH.ToString());
            lstResult.Add(EMCpuTypeMS.Q12PRH.ToString());
            lstResult.Add(EMCpuTypeMS.Q13UDEH.ToString());
            lstResult.Add(EMCpuTypeMS.Q13UDH.ToString());
            lstResult.Add(EMCpuTypeMS.Q25H.ToString());
            lstResult.Add(EMCpuTypeMS.Q25PH.ToString());
            lstResult.Add(EMCpuTypeMS.Q25PRH.ToString());
            lstResult.Add(EMCpuTypeMS.Q26UDEH.ToString());
            lstResult.Add(EMCpuTypeMS.Q26UDH.ToString());
            lstResult.Add(EMCpuTypeMS.Q2A.ToString());
            lstResult.Add(EMCpuTypeMS.Q2A_S1.ToString());
            lstResult.Add(EMCpuTypeMS.Q3A.ToString());
            lstResult.Add(EMCpuTypeMS.Q4A.ToString());
            lstResult.Add(EMCpuTypeMS.QS001.ToString());

            lstResult.Add(EMCpuTypeMS.A0J2H.ToString());
            lstResult.Add(EMCpuTypeMS.A171SH.ToString());
            lstResult.Add(EMCpuTypeMS.A172SH.ToString());
            lstResult.Add(EMCpuTypeMS.A173UH.ToString());
            lstResult.Add(EMCpuTypeMS.A1FX.ToString());
            lstResult.Add(EMCpuTypeMS.A1N.ToString());
            lstResult.Add(EMCpuTypeMS.A1S.ToString());
            lstResult.Add(EMCpuTypeMS.A1SH.ToString());
            lstResult.Add(EMCpuTypeMS.A273UH.ToString());
            lstResult.Add(EMCpuTypeMS.A2A.ToString());
            lstResult.Add(EMCpuTypeMS.A2C.ToString());
            lstResult.Add(EMCpuTypeMS.A2N.ToString());
            lstResult.Add(EMCpuTypeMS.A2SH.ToString());
            lstResult.Add(EMCpuTypeMS.A2U.ToString());
            lstResult.Add(EMCpuTypeMS.A2USH.ToString());
            lstResult.Add(EMCpuTypeMS.A3A.ToString());
            lstResult.Add(EMCpuTypeMS.A3N.ToString());
            lstResult.Add(EMCpuTypeMS.A3U.ToString());
            lstResult.Add(EMCpuTypeMS.A4U.ToString());
            lstResult.Add(EMCpuTypeMS.FX0.ToString());
            lstResult.Add(EMCpuTypeMS.FX0N.ToString());
            lstResult.Add(EMCpuTypeMS.FX1.ToString());
            lstResult.Add(EMCpuTypeMS.FX1N.ToString());
            lstResult.Add(EMCpuTypeMS.FX1S.ToString());
            lstResult.Add(EMCpuTypeMS.FX2.ToString());
            lstResult.Add(EMCpuTypeMS.FX2N.ToString());
            lstResult.Add(EMCpuTypeMS.FX3U.ToString());
            lstResult.Add(EMCpuTypeMS.CPU.ToString());

            return lstResult;
        }

        public List<string> GetMultiCpuTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMMultiCPUTypeMS.None.ToString());
            lstResult.Add(EMMultiCPUTypeMS.No1.ToString());
            lstResult.Add(EMMultiCPUTypeMS.No2.ToString());
            lstResult.Add(EMMultiCPUTypeMS.No3.ToString());
            lstResult.Add(EMMultiCPUTypeMS.No4.ToString());

            return lstResult;
        }

        public List<string> GetEthernetModuleTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMENetModuleTypeMS.QJ71E71.ToString());
            lstResult.Add(EMENetModuleTypeMS.CPU.ToString());
            lstResult.Add(EMENetModuleTypeMS.AJ71E71.ToString());
            lstResult.Add(EMENetModuleTypeMS.AJ71QE71.ToString());
            lstResult.Add(EMENetModuleTypeMS.GOT.ToString());

            return lstResult;
        }

        public List<string> GetEthernetProtocolTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMENetProtocolTypeMS.TCP.ToString());
            lstResult.Add(EMENetProtocolTypeMS.UDP.ToString());

            return lstResult;
        }

        public List<string> GetEthernetPacketTypeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMENetPacketTypeMS.ASCII.ToString());
            lstResult.Add(EMENetPacketTypeMS.Binary.ToString());

            return lstResult;
        }

        public List<string> GetMnetPcSlotStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMMNetPCSlotTypeMS.Slot1.ToString());
            lstResult.Add(EMMNetPCSlotTypeMS.Slot2.ToString());
            lstResult.Add(EMMNetPCSlotTypeMS.Slot3.ToString());
            lstResult.Add(EMMNetPCSlotTypeMS.Slot4.ToString());

            return lstResult;
        }

        public List<string> GetCollectModeStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMCollectMode.Normal.ToString());
            lstResult.Add(EMCollectMode.Frag.ToString());
            lstResult.Add(EMCollectMode.StandardCoil.ToString());
            lstResult.Add(EMCollectMode.LOB.ToString());

            return lstResult;
        }

        public List<string> GetConnectApplicationStringList()
        {
            List<string> lstResult = new List<string>();

            lstResult.Add(EMConnectAppType.Profiler.ToString());
            lstResult.Add(EMConnectAppType.Manager.ToString());
            lstResult.Add(EMConnectAppType.Tracker.ToString());

            return lstResult;
        }

        public int GetPlcCpuIndexNumber(EMCpuTypeMS emCpu)
        {
            int iResult = 0;

            switch (emCpu)
            {
                case EMCpuTypeMS.Q00:     iResult = 0; break;
                case EMCpuTypeMS.Q00J:    iResult = 1; break;
                case EMCpuTypeMS.Q01:     iResult = 2; break;
                case EMCpuTypeMS.Q02H:    iResult = 3; break;
                case EMCpuTypeMS.Q02H_A:  iResult = 4; break;
                case EMCpuTypeMS.Q02PH:   iResult = 5; break;
                case EMCpuTypeMS.Q02U:    iResult = 6; break;
                case EMCpuTypeMS.Q03UD:   iResult = 7; break;
                case EMCpuTypeMS.Q03UDE:  iResult = 8; break;
                case EMCpuTypeMS.Q04UDEH: iResult = 9; break;
                case EMCpuTypeMS.Q04UDH:  iResult = 10; break;
                case EMCpuTypeMS.Q06H:    iResult = 11; break;
                case EMCpuTypeMS.Q06H_A:  iResult = 12; break;
                case EMCpuTypeMS.Q06PH:   iResult = 13; break;
                case EMCpuTypeMS.Q06UDEH: iResult = 14; break;
                case EMCpuTypeMS.Q06UDH:  iResult = 15; break;
                case EMCpuTypeMS.Q12H:    iResult = 16; break;
                case EMCpuTypeMS.Q12PH:   iResult = 17; break;
                case EMCpuTypeMS.Q12PRH:  iResult = 18; break;
                case EMCpuTypeMS.Q13UDEH: iResult = 19; break;
                case EMCpuTypeMS.Q13UDH:  iResult = 20; break;
                case EMCpuTypeMS.Q25H:    iResult = 21; break;
                case EMCpuTypeMS.Q25PH:   iResult = 22; break;
                case EMCpuTypeMS.Q25PRH:  iResult = 23; break;
                case EMCpuTypeMS.Q26UDEH: iResult = 24; break;
                case EMCpuTypeMS.Q26UDH:  iResult = 25; break;
                case EMCpuTypeMS.Q2A:     iResult = 26; break;
                case EMCpuTypeMS.Q2A_S1:  iResult = 27; break;
                case EMCpuTypeMS.Q3A:     iResult = 28; break;
                case EMCpuTypeMS.Q4A:     iResult = 29; break;
                case EMCpuTypeMS.QS001:   iResult = 30; break;
                case EMCpuTypeMS.A0J2H:   iResult = 31; break;
                case EMCpuTypeMS.A171SH:  iResult = 32; break;
                case EMCpuTypeMS.A172SH:  iResult = 33; break;
                case EMCpuTypeMS.A173UH:  iResult = 34; break;
                case EMCpuTypeMS.A1FX:    iResult = 35; break;
                case EMCpuTypeMS.A1N:     iResult = 36; break;
                case EMCpuTypeMS.A1S:     iResult = 37; break;
                case EMCpuTypeMS.A1SH:    iResult = 38; break;
                case EMCpuTypeMS.A273UH:  iResult = 39; break;
                case EMCpuTypeMS.A2A:     iResult = 40; break;
                case EMCpuTypeMS.A2C:     iResult = 41; break;
                case EMCpuTypeMS.A2N:     iResult = 42; break;
                case EMCpuTypeMS.A2SH:    iResult = 43; break;
                case EMCpuTypeMS.A2U:     iResult = 44; break;
                case EMCpuTypeMS.A2USH:   iResult = 45; break;
                case EMCpuTypeMS.A3A:     iResult = 46; break;
                case EMCpuTypeMS.A3N:     iResult = 47; break;
                case EMCpuTypeMS.A3U:     iResult = 48; break;
                case EMCpuTypeMS.A4U:     iResult = 49; break;
                case EMCpuTypeMS.FX0:     iResult = 50; break;
                case EMCpuTypeMS.FX0N:    iResult = 51; break;
                case EMCpuTypeMS.FX1:     iResult = 52; break;
                case EMCpuTypeMS.FX1N:    iResult = 53; break;
                case EMCpuTypeMS.FX1S:    iResult = 54; break;
                case EMCpuTypeMS.FX2:     iResult = 55; break;
                case EMCpuTypeMS.FX2N:    iResult = 56; break;
                case EMCpuTypeMS.FX3U:    iResult = 57; break;
                case EMCpuTypeMS.CPU:     iResult = 58; break;
            }

            return iResult;
        }

        public int GetMutiCpuIndexNumber(EMMultiCPUTypeMS emCpu)
        {
            int iResult = 0;
            switch (emCpu)
            {
                case EMMultiCPUTypeMS.None: iResult = 0; break;
                case EMMultiCPUTypeMS.No1:  iResult = 1; break;
                case EMMultiCPUTypeMS.No2:  iResult = 2; break;
                case EMMultiCPUTypeMS.No3:  iResult = 3; break;
                case EMMultiCPUTypeMS.No4:  iResult = 4; break;
            }

            return iResult;
        }

        public int GetMutiCpuIndexNumber(int iValue)
        {
            int iResult = 0;
            switch (iValue)
            {
                case 0x3FF: iResult = 0; break;
                case 0x3E0: iResult = 1; break;
                case 0x3E1: iResult = 2; break;
                case 0x3E2: iResult = 3; break;
                case 0x3E3: iResult = 4; break;
            }

            return iResult;
        }

        public int GetStringToInt(string sSource)
        {
            int iResult = 0;
            bool bOK = int.TryParse(sSource, out iResult);
            if (bOK == false)
                return 0;
            return iResult;
        }

        #endregion

        #endregion

        #region Private Method

        public bool CheckConnectApplicationString(string sSource)
        {
            List<string> lstString = GetConnectApplicationStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckPlcMakerString(string sSource)
        {
            List<string> lstString = GetPlcMakerStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckConnectTypeString(string sSource)
        {
            List<string> lstString = GetConnectTypeFullStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckPlcCpuTypeString(string sSource)
        {
            List<string> lstString = GetPlcCpuStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckStationTypeString(string sSource)
        {
            List<string> lstString = GetStationTypeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckMultiCpuTypeString(string sSource)
        {
            List<string> lstString = GetMultiCpuTypeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckMnetPcSlotTypeString(string sSource)
        {
            List<string> lstString = GetMnetPcSlotStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckEthernetModuleTypeString(string sSource)
        {
            List<string> lstString = GetEthernetModuleTypeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckEthernetProtocolTypeString(string sSource)
        {
            List<string> lstString = GetEthernetProtocolTypeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckEthernetPacketTypeString(string sSource)
        {
            List<string> lstString = GetEthernetPacketTypeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }

        public bool CheckCollectModeTypeString(string sSource)
        {
            List<string> lstString = GetCollectModeStringList();
            foreach (string name in lstString)
            {
                if (sSource == name)
                    return true;
            }

            return false;
        }


        #endregion

    }
}
