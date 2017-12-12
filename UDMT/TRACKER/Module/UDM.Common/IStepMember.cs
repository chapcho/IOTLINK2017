using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    public interface IStepMember
    {

        #region Public Properties

        string Step {get;set;}
        int StepIndex {get;set;}

        CRefTagS RefTagS {get;set;}

        #endregion


        #region Public Methods


        #endregion
    }
}
