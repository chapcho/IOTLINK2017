using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace UDMEnergyViewer
{
    public class CMeterReader : IDisposable
    {

        #region Member Variables

        protected CMeterConfig m_cConfig = new CMeterConfig();
        //protected static short m_sStartingAddress = 8448;
        protected cModBusTCPIPWrapper m_cModBusTCPIPWrapper = null;


        #endregion


        #region Initialize/Dispose

        public CMeterReader()
        {
           
        }

        public void Dispose()
        {
            Disconnect();
        }

        #endregion


        #region Public Properties

        public CMeterConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        #endregion


        #region Public Methods

        public bool Connect()
        {
            bool bOK = false;

            string sIp = m_cConfig.IP;
            int iPort = Convert.ToInt16(m_cConfig.Port);
            int iChannelS = m_cConfig.ChannelNum;

            m_cModBusTCPIPWrapper = new cModBusTCPIPWrapper(sIp, iPort,iChannelS);

            bOK = m_cModBusTCPIPWrapper.ConnectCheck();

            return bOK;
        }

        public void Disconnect()
        {
            try
            {

                if (m_cModBusTCPIPWrapper != null)
                {
                    m_cModBusTCPIPWrapper.DisConnect();
                    m_cModBusTCPIPWrapper.Dispose();
                    m_cModBusTCPIPWrapper = null;
                }
            }
            catch(System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public CMeterData ReadData(out bool bBroken)
        {
            CMeterData cData = null;
            byte[] bReadDatas = m_cModBusTCPIPWrapper.Receive(out bBroken);
            try
            {  
                DateTime time = DateTime.Now;

                cData = new CMeterData(time,bReadDatas);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                cData = null;
            }

            return cData;
        }


        #endregion


        #region Private Methods


        #endregion
    }
}
