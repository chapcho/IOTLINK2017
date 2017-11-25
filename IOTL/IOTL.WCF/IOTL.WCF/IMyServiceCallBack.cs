using System.ServiceModel;

namespace IOTL.WCF
{
    public interface IMyServiceCallBack : Common.Remote.IWcfServiceCallBack
    {

        #region Public Properties


        #endregion


        #region Public Methods

        [OperationContract(IsOneWay = true)]
        void ReceiveCommStart(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveCommStop(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveTagList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveEmergTagList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveCollectorList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveRecipeTagList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveAddTagList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveRemoveTagList(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveProjectInfo(string[] saData);

        [OperationContract(IsOneWay = true)]
        void ReceiveLadderViewTagList(string[] saData);
     
        #endregion
    }
}
