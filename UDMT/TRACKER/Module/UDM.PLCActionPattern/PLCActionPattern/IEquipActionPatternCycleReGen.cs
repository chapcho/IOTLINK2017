using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.PLCActionPattern
{
    public interface IEquipActionPatternCycleReGen
    {
        #region public Methods
        void ReGenCycleInfo(DateTime cycleStart, DateTime cycleEnd);
        #endregion
    }
}
