using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.General.RemoteService
{
    /// <summary>
    /// Attribute : [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string sClient);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string sClient);
    }
}
