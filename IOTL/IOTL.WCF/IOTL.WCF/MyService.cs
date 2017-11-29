using IOTL.Common.Remote;
using IOTL.WCF.EventHandler;
using System;
using System.Linq;
using System.ServiceModel;

namespace IOTL.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CMyService : WcfService, IMyService
    {

        #region Member Variables

        public event UEventHandlerTimeLogS UEventReceiveTimeLogS;
        public event UEventHandlerTimeLogS UEventReceiveEmergTimeLogS;
        public event UEventHandlerErrorTagList UEventReceiveErrorTagList;
        public event UEventHandlerStatus UEventReceiveStatus;
        public event UEventHandlerClient UEventReceiveClientMessage;
        public event UEventHandlerTimeLogS UEventReceiveRecipeLogS;
        public event UEventHandlerProjectinfo UEventReceiveProjectInfo;

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

        /// <summary>
        /// Collector -> Manager -> Tracker
        /// </summary>
        /// <param name="saTagData"></param>
        public void SendTimeLogSToServer(string[] saLogData)
        {
            if (UEventReceiveTimeLogS != null)
                UEventReceiveTimeLogS(this, saLogData);
        }

        public void SendEmergTimeLogSToServer(string[] saLogData)
        {
            if (UEventReceiveEmergTimeLogS != null)
                UEventReceiveEmergTimeLogS(this, saLogData);
        }

        public void SendRecipeTimeLogSToServer(string[] saLogData)
        {
            if (UEventReceiveRecipeLogS != null)
                UEventReceiveRecipeLogS(this, saLogData);
        }

        /// <summary>
        /// Collector -> Manager -> Tracker
        /// </summary>
        /// <param name="saData"></param>
        public void SendErrorTagListToServer(string[] saData)
        {
            if (UEventReceiveErrorTagList != null)
                UEventReceiveErrorTagList(this, saData);
        }

        /// <summary>
        /// Collector -> Manager -> Tracker
        /// </summary>
        /// <param name="saData"></param>
        public void SendStatusToServer(string[] saData)
        {
            if (UEventReceiveStatus != null)
                UEventReceiveStatus(this, saData);
        }

        /// <summary>
        /// Collector -> Manager -> Tracker
        /// </summary>
        /// <param name="saData"></param>
        public void SendMessageToServer(string[] saData)
        {
            if (UEventReceiveClientMessage != null)
                UEventReceiveClientMessage(this, saData);
        }

        public void SendProjectInfoToServer(string[] saData)
        {
            if (UEventReceiveProjectInfo != null)
                UEventReceiveProjectInfo(this, saData);
        }

        /// <summary>
        /// Tracker -> Manager
        /// Manger -> Collector
        /// </summary>
        /// <param name="saLogData"></param>
        public void SendStartCommandToClient(string[] saLogData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saLogData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveCommStart(saLogData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveCommStart(saLogData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendStartCommandToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        /// <summary>
        /// Tracker -> Manager
        /// Manger -> Collector
        /// </summary>
        /// <param name="saLogData"></param>
        public void SendStopCommandToClient(string[] saLogData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;
             
                if (m_lstClient.ContainsKey(saLogData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveCommStop(saLogData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveCommStop(saLogData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendStopCommandToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        /// <summary>
        /// Tracker -> Manager Only
        /// </summary>
        /// <param name="saLogData"></param>
        public void SendCollectorListToClient(string[] saLogData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saLogData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveCollectorList(saLogData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveCollectorList(saLogData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendCollectorListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        /// <summary>
        /// Tracker -> Manager -> Collector
        /// </summary>
        /// <param name="saLogData"></param>
        public void SendTagListToClient(string[] saLogData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saLogData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveTagList(saLogData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveTagList(saLogData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void SendAddTagListToClient(string[] saData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saData[0]])).ReceiveAddTagList(saData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveAddTagList(saData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendAddTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendAddTagListToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void SendRemoveTagListToClient(string[] saData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saData[0]])).ReceiveRemoveTagList(saData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveRemoveTagList(saData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendRemoveTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendRemoveTagListToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void SendLadderViewTagListToClient(string[] saLogData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saLogData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveLadderViewTagList(saLogData);                    
                    //((IMyServiceCallBack)(m_lstClient[saLogData[0]])).ReceiveTagList(saLogData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }        
        public void SendEmergTagListToClient(string[] saData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saData[0]])).ReceiveEmergTagList(saData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveEmergTagList(saData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendEmergTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void SendRecipeTagListToClient(string[] saData)
        {
            try
            {
                if (m_lstClient.Count == 0) return;

                if (m_lstClient.ContainsKey(saData[0]))
                    ((IMyServiceCallBack)(m_lstClient[saData[0]])).ReceiveRecipeTagList(saData);
                else
                    ((IMyServiceCallBack)(m_lstClient.First().Value)).ReceiveRecipeTagList(saData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("SendRecipeTagListToClient Exception 발생 : " + ex.Message);
                Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void Connect(string sClient)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(string sClient)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
