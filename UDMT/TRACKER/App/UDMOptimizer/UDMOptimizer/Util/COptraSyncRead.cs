using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using TrackerSPD.DDEA;
using TrackerSPD.LS;
using TrackerSPD.OPC;
using UDM.Common;
using UDM.Log;

namespace UDMOptimizer
{
    public class COptraSyncRead
    {
        #region Member Variables

        private Dictionary<string, object> m_dicReaderObj = new Dictionary<string, object>();

        #endregion


        #region Initialize

        #endregion


        #region Properties

        #endregion


        #region Public Method

        public void ConnectReader(CPlcConfigS cConfigS)
        {
            foreach (var who in cConfigS)
            {
                CPlcConfig cConfig = who.Value;
                if (cConfig.CollectType == EMCollectType.DDEA)
                {
                    CReadFunction cDDEAReader = new CReadFunction(cConfig.MelsecConfig);
                    cDDEAReader.Connect();
                    m_dicReaderObj.Add(who.Key, cDDEAReader);
                }
                else if (cConfig.CollectType == EMCollectType.OPC)
                {
                    COPCServer cOPCServer = new COPCServer();
                    cOPCServer.Config = cConfig.OPCConfig;
                    cOPCServer.Config.Use = true;
                    cOPCServer.Connect();
                    m_dicReaderObj.Add(who.Key, cOPCServer);
                }
                else
                {
                    CLsReader cLsReader = new CLsReader();
                    cLsReader.Config = cConfig.LsConfig;
                    cLsReader.Config.Use = true;
                    cLsReader.Connect();
                    m_dicReaderObj.Add(who.Key, cLsReader);
                }
            }
        }

        public void DisconectReader()
        {
            foreach (var who in m_dicReaderObj)
            {
                object oReader = who.Value;
                if (oReader.GetType() == typeof(CReadFunction))
                {
                    CReadFunction cDDEAReader = (CReadFunction)oReader;
                    cDDEAReader.Disconnect();
                }
                else if (oReader.GetType() == typeof(COPCServer))
                {
                    COPCServer cOPCServer = (COPCServer)oReader;
                    cOPCServer.Disconnect();
                }
                else
                {
                    CLsReader cLsReader = (CLsReader)oReader;
                    cLsReader.Disconnect();
                }
            }
        }

        public CTimeLogS ReadTagValue(string sPlcID, List<CTag> lstTag)
        {
            CTimeLogS cLogS = new CTimeLogS();

            //foreach (var who in m_dicReaderObj)
            if(m_dicReaderObj.ContainsKey(sPlcID))
            {
                object oReader = m_dicReaderObj[sPlcID];
                if (oReader.GetType() == typeof(CReadFunction))
                {
                    CReadFunction cDDEAReader = (CReadFunction)oReader;
                    if (cDDEAReader.IsConnection)
                        cLogS = CollectSubDepthDDEA(lstTag, cDDEAReader);
                }
                else if (oReader.GetType() == typeof(COPCServer))
                {
                    COPCServer cOPCServer = (COPCServer)oReader;
                    if (cOPCServer.IsConnect)
                    {
                        cLogS = cOPCServer.ReadInstant(lstTag);
                    }
                }
                else
                {
                    CLsReader cLsReader = (CLsReader)oReader;
                    if (cLsReader.IsConnected)
                    {
                        cLogS = cLsReader.ReadInstant(lstTag);
                    }
                }
            }

            return cLogS;
        }

        #endregion


        #region Private Method


        private CDDEASymbolS CreateSymbolS(CTag cTag)
        {
            if (cTag == null) return null;
            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            if (cSymbol.DataType == EMDataType.Word)
                cSymbol.BaseAddress = cSymbol.Address;
            cSymbol.AddressCount = cTag.Size;
            cSymbolS.AddSymbol(cSymbol);
            if (cSymbol.DataType != EMDataType.Word)
                return cSymbolS;

            for (int i = 1; i < cTag.Size; i++)
            {
                cSymbol.DataType = EMDataType.DWord;
                int iAddress = cSymbol.AddressMajor + i;
                string sSubAddress = cSymbol.AddressHeader + iAddress.ToString();
                if (cSymbol.CheckAddressHexa(sSubAddress))
                {
                    string sHexa = string.Format("{0:x}", iAddress);
                    sSubAddress = cSymbol.AddressHeader + sHexa;
                }

                CDDEASymbol cSubSymbol = new CDDEASymbol(sSubAddress, false);
                cSubSymbol.CreateMelsecDDEASymbol(sSubAddress);
                cSymbol.DWordSecondAddress = sSubAddress;
                cSubSymbol.BaseAddress = cSymbol.Address;
                cSubSymbol.AddressCount = 0;
                cSymbolS.AddSymbol(cSubSymbol);
            }

            return cSymbolS;
        }

        private CDDEASymbolS ChangeDDEASymbolS(List<CTag> lstTag)
        {
            if (lstTag == null || lstTag.Count == 0)
                return null;
            CDDEASymbolS cDDEASymbolS = new CDDEASymbolS();

            foreach (CTag cTag in lstTag)
            {
                CDDEASymbolS cSymbolS = CreateSymbolS(cTag);
                if (cSymbolS != null && cSymbolS.Count > 0)
                    cDDEASymbolS.AddSymbolS(cSymbolS);
            }

            return cDDEASymbolS;
        }

        private CTimeLogS CollectSubDepthDDEA(List<CTag> lstTag, CReadFunction cReader)
        {
            CTimeLogS cLogS = new CTimeLogS();

            CDDEASymbolS cDDEASymbolS = ChangeDDEASymbolS(lstTag);
            List<CDDEASymbolList> lstSymbol = new List<CDDEASymbolList>();
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            Dictionary<string, int> dicSendData = new Dictionary<string, int>();
            int iCount = 0;
            string sAddressList = "";
            try
            {
                foreach (var who in cDDEASymbolS)
                {
                    cSymbolList.AddSymbol(who.Value);
                    sAddressList += who.Value.Address + "\n";
                    iCount++;
                    if (iCount >= 90)
                    {
                        lstSymbol.Add(cSymbolList);
                        cSymbolList = new CDDEASymbolList();
                        dicSendData.Add(sAddressList, iCount);
                        sAddressList = "";
                        iCount = 0;
                    }
                }
                if (iCount > 0)
                {
                    lstSymbol.Add(cSymbolList);
                    dicSendData.Add(sAddressList, iCount);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("분석", "하위 Depth 재수집 접점분석에 문제가 있습니다. : " + ex.Message);
            }

            try
            {
                DateTime dtNow = DateTime.Now;

                int iReadNumber = 0;
                foreach (var who in dicSendData)
                {
                    int[] iReadData = cReader.ReadRandomData(who.Key, who.Value);
                    if (iReadData == null)
                        UpdateSystemMessage("하위 Depth 수집", "수집에 실패했습니다.");
                    else
                    {
                        //분석
                        string[] saAddress = who.Key.Split('\n');
                        for (int i = 0; i < saAddress.Length; i++)
                        {
                            if (saAddress[i] == "")
                                continue;

                            CDDEASymbol cSymbol = lstSymbol[iReadNumber].FindEqulAddressSymbol(saAddress[i]);
                            if (cSymbol != null)
                            {
                                CTimeLog cLog = new CTimeLog();
                                cLog.Key = cSymbol.Key;
                                cLog.Time = dtNow;
                                cLog.Value = iReadData[i];
                                cLog.SValue = iReadData[i].ToString();
                                cLogS.Add(cLog);
                            }
                            else
                                UpdateSystemMessage("하위 Depth 수집분석", saAddress[i] + " 해당접점을 찾을 수 없습니다.");
                        }
                    }
                    iReadNumber++;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("수집", "하위 Depth 재수집에 문제가 있습니다. : " + ex.Message);
            }
            return cLogS;
        }

        private void UpdateSystemMessage(string sSender, string sMessage)
        {

        }

        #endregion
    }
}
