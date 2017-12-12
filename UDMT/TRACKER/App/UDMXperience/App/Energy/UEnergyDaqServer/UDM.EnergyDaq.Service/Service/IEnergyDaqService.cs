using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using UDM.General.RemoteService;

namespace UDM.EnergyDaq.Service
{
    [ServiceContract(CallbackContract = typeof(IEnergyDaqServiceCallBack))]
    public interface IEnergyDaqService : IService
    {
        [OperationContract()]
        List<string> RequireLogKeyList(string sClient);

    }
}
