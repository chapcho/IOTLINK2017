using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UDM.General.Remote
{
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string sClient);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string sClient);
    }
}
