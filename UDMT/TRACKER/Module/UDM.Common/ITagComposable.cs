using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    public interface ITagComposable
    {

        #region Public Properties


        #endregion


        #region Public Methods

        void Compose(CTagS cTagS);
        void Compose(CRefTagS cRefTagS);

        #endregion
    }
}
