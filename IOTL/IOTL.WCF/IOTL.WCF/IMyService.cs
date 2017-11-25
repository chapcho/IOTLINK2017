using IOTL.Common.Remote;
using System.ServiceModel;

namespace IOTL.WCF
{
    [ServiceContract(CallbackContract = typeof(IMyServiceCallBack))]
    public interface IMyService : IWcfService
    {

        #region Public Properties


        #endregion


        #region Public Methods

        [OperationContract(IsOneWay = true)]
        void SendTimeLogSToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendEmergTimeLogSToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendRecipeTimeLogSToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendErrorTagListToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendStatusToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendMessageToServer(string[] saData);

        [OperationContract(IsOneWay = true)]
        void SendProjectInfoToServer(string[] saData);

        #endregion
    }
}
