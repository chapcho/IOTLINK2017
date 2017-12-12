using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using UDM.General.RemoteService;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Service
{
    public interface IEnergyDaqServiceCallBack : IServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RecieveData(CEnergyLogS cLogS);
    }
}
