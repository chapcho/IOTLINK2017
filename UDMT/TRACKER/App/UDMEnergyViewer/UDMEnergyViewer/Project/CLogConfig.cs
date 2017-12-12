using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source;
using UDM.Monitor.Plc.Source.OPC;

namespace UDMEnergyViewer
{
    [Serializable]
	public class CLogConfig : IDisposable
	{

		#region Member Varialbes

		private string m_sSavePath = @"C:\UDMLog";
        private string m_sEnergySavePath = @"C:\UDMEnergyLog";
        

		#endregion


		#region Inialize/Dispose

		public CLogConfig()
		{
            
		}

		public void Dispose()
		{
			
		}

		#endregion


		#region Public Properties

		public string SavePath
		{
			get { return m_sSavePath; }
			set { m_sSavePath = value; }
		}

        public string EnergySavePath
        {
            get { return m_sEnergySavePath; }
            set { m_sEnergySavePath = value; }
        }

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods


		#endregion

	}
}
