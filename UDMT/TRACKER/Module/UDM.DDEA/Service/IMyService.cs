using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.DDEA
{
    [ServiceContract(CallbackContract = typeof(IMyServiceCallBack))]
    public interface IMyService : UDM.General.Remote.IService
    {

        #region Public Properties


        #endregion


        #region Public Methods

        [OperationContract]
        string Hello();

        [OperationContract(IsOneWay = true)]
        void AddItems(string[] saTagData);

        [OperationContract]
        string[] ReadInstant(string[] saTagData);

        #endregion
    }
}
