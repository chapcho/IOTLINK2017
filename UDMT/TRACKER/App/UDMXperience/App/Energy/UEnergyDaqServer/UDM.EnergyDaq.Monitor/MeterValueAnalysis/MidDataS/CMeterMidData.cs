using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;

namespace UDM.EnergyDaq.Monitor
{
    public class CMeterMidData
    {
        protected string m_sKey = string.Empty;
        protected EMMeterModel m_emModel = EMMeterModel.DummyMeter;

        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public EMMeterModel MeterModel
        {
            get { return m_emModel; }
            set { m_emModel = value; }
        }

        #endregion
    }
}
