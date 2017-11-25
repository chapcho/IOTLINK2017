using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace IOTL.Common.Remote
{
    public interface IWcfServiceCallBack
    {

        #region Public Properties

        #endregion


        #region Public Methods

        [OperationContract(IsOneWay = true)]
        void Terminate();

        #endregion
    }
}
