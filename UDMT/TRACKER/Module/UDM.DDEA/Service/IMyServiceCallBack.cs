using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.DDEA
{
    public interface IMyServiceCallBack : UDM.General.Remote.IServiceCallBack
    {

        #region Public Properties

        
        #endregion


        #region Public Methods

        [OperationContract(IsOneWay = true)]
        void RecieveLogData(string[] saData);

        #endregion

    }
}
