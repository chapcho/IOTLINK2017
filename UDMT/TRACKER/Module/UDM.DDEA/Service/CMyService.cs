using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.DDEA
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CMyService : UDM.General.Remote.CService, IMyService
    {

        #region Member Variables

        public event UEventHandlerConstantItemRecieved UEventConstantItemRecieved;
        public event UEventHandlerInstantItemRecieved UEventInstantItemRecieved;
        public event UEventHandlerConnectSetting UEventConnectSetting;

        #endregion


        #region Intialize/Dispose

        public CMyService()
        {

        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public string Hello()
        {
            return "Hello";
        }

        public void AddItems(string[] saTagData)
        {
            if (UEventConstantItemRecieved != null)
                UEventConstantItemRecieved(this, saTagData);
        }

        public string[] ReadInstant(string[] saTagData)
        {
            string[] saLogData = null;

            if (UEventInstantItemRecieved != null)
                UEventInstantItemRecieved(this, saTagData, out saLogData);

            return saLogData;
        }

        public void SendLogData(string[] saLogData)
        {
            for (int i = 0; i < m_lstClient.Count; i++)
            {
                try
                {
                    ((IMyServiceCallBack)(m_lstClient.ElementAt(i).Value)).RecieveLogData(saLogData);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                    Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                }
            }
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
