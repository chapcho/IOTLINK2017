using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UDMIOMaker
{

    /// <summary>
    /// Key = PLC Name(Channel)
    /// </summary>
    [Serializable]
    public class CPlcLogicDataS : Dictionary<string, CPlcLogicData>, IDisposable
    {


        #region Initialize/Dispose

        public CPlcLogicDataS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CPlcLogicDataS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
