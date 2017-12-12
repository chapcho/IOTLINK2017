using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.DDEA;
using UDM.Common;
using UDM.Monitor.Plc.Source.OPC;
using UDM.Monitor.Plc.Source;

namespace UDMDDEA
{
    public class CMain
    {

        #region Member Variables

        private UDM.General.Remote.CServer<IMyService, CMyService> m_cServer = null;
        private CDDEASymbolS m_cDDEAReadSymbolS = new CDDEASymbolS();

        public event UEventHandlerTrackerSymbolReceive UEventReceiveSymbolS;
        public event UEventHandlerTrackerResearchSymbolReceive UEventResearchSymbolS;
        public event UEventHandlerMainMessage UEventMainMessage;

        #endregion


        #region Intialize/Dispose


        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { if(m_cServer == null ) {return false;} else {return m_cServer.IsRunning;}}
        }

        public CDDEASymbolS ReadSymbolS
        {
            get { return m_cDDEAReadSymbolS; }
            set { m_cDDEAReadSymbolS = value; }
        }



        #endregion


        #region Public Methods 

        public bool StartServer()
        {
            bool bOK = true;

            try
            {
                if (m_cServer == null)
                    m_cServer = new UDM.General.Remote.CServer<IMyService, CMyService>();

                if(m_cServer.IsRunning == false)
                    bOK = m_cServer.Start();

                if (bOK)
                {
                    m_cServer.Service.UEventConstantItemRecieved += new UEventHandlerConstantItemRecieved(Service_UEventConstantItemRecieved);
                    m_cServer.Service.UEventInstantItemRecieved += new UEventHandlerInstantItemRecieved(Service_UEventInstanceItemRecieved);
                    m_cServer.Service.UEventConnectSetting += Service_UEventConnectSetting;
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public void StopServer()
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                m_cServer.Stop();
                m_cServer.Dispose();
                m_cServer = null;
            }
        }

        public void SendToClient(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendLogData(saData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        #endregion


        #region Private Methods

        private CDDEASymbolS CresteSymbolS(string sKey, string sAddress, int iLength)
        {
            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            CDDEASymbol cSymbol = new CDDEASymbol(sKey, false);
            cSymbol.CreateMelsecDDEASymbol(sAddress);
            if (cSymbol.DataType == EMDataType.Word)
                cSymbol.BaseAddress = cSymbol.Address;
            cSymbol.AddressCount = iLength;
            cSymbolS.AddSymbol(cSymbol);
            if (cSymbol.DataType != EMDataType.Word)
                return cSymbolS;

            for (int i = 1; i < iLength; i++)
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
        
        private void SetEventMessage(string sMessage)
        {
            if (UEventMainMessage != null)
                UEventMainMessage(this, "Tracker 연결", sMessage);
        }

        #endregion


        #region Event Mehtods

        private void Service_UEventConstantItemRecieved(object sender, string[] saData)
        {
            SetEventMessage("접점 수신");
            m_cDDEAReadSymbolS.Clear();
            string sMsg = "";
            int iCount = 0;
            for (int i = 0; i < saData.Length; i++)
            {
                CDDEASymbolS cSymbolS = new CDDEASymbolS();
                string[] sSplit = saData[i].Split(',');
                if (sSplit.Length != 3)
                {
                    SetEventMessage("Error : " + saData[i] + " 형식이 틀렸습니다.");
                    continue;
                }
                else
                {
                    int iLength = -1;
                    bool bOK = int.TryParse(sSplit[2], out iLength);
                    if (bOK)
                    {
                        cSymbolS = CresteSymbolS(sSplit[0], sSplit[1], iLength);
                        m_cDDEAReadSymbolS.AddSymbolS(cSymbolS);
                        iCount++;
                        sMsg += sSplit[0] + ", ";
                    }
                    else
                    {
                        SetEventMessage("Error : " + saData[i] + " 숫자 파싱에 실패했습니다.");
                    }
                }
            }
            string sMessage = string.Format("추가 접점 : {0} {1} 개가 추가 되었습니다.", sMsg, iCount);
            SetEventMessage(sMessage);

            if (UEventReceiveSymbolS != null && iCount > 0)
                UEventReceiveSymbolS(sender);

        }

        private void Service_UEventInstanceItemRecieved(object sender, string[] saTagData, out string[] saLogData)
        {
            saLogData = null;

            CDDEASymbolS researchSymbolS = new CDDEASymbolS();

            for (int i = 0; i < saTagData.Length; i++)
            {
                CDDEASymbolS cSymbolS = new CDDEASymbolS();
                string[] sSplit = saTagData[i].Split(',');
                if (sSplit.Length != 3)
                {
                    SetEventMessage("Error : " + saTagData[i] + " 형식이 틀렸습니다.");
                    continue;
                }
                else
                {
                    int iLength = -1;
                    bool bOK = int.TryParse(sSplit[2], out iLength);
                    if (bOK)
                    {
                        cSymbolS = CresteSymbolS(sSplit[0], sSplit[1], iLength);
                        researchSymbolS.AddSymbolS(cSymbolS);
                    }
                    else
                    {
                        SetEventMessage("Error : " + saTagData[i] + " 숫자 파싱에 실패했습니다.");
                    }
                }
            }

            string[] saData = null;
            if (UEventResearchSymbolS != null)
                UEventResearchSymbolS(sender, researchSymbolS, out saData);

            saLogData = saData;
        }

        void Service_UEventConnectSetting(object sender, string[] saData)
        {
            int a = 0;
        }

        #endregion
    }
}
