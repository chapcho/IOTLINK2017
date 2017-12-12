using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Monitor;
using UDM.Monitor.Plc.Source;
using UDM.Monitor.Plc.Source.OPC;
using UDM.Monitor.Plc.Source.LS;

namespace UDMEnergyViewer
{
    [Serializable]
	public class CProject : IDisposable
	{

		#region Member Varialbes

		protected string m_sName = "";
		protected string m_sPath = "";
        protected CTagS m_cTagS = new CTagS();
        protected CStepS m_cStepS = new CStepS();
		protected CSymbolS m_cSymbolS = new CSymbolS();
        protected CLsConfig m_cPlcConfig = new CLsConfig();
		protected CLogConfig m_cLogConfig = new CLogConfig();
        protected List<CTag> m_lstCoilList = new List<CTag>();
        protected Dictionary<string, CTagItemS> m_DicUnitTagItemS = new Dictionary<string, CTagItemS>();
        protected CMeterConfig m_cMeterConfig = new CMeterConfig();

        protected CMeterItemS m_cMeterItemS = new CMeterItemS();
        protected CTagItemS m_cTagItemS = new CTagItemS();
        protected CTagItemS m_cCoilTagItemS = new CTagItemS();

        protected CRegressionUnitS m_cRegressgionUnitS = new CRegressionUnitS();

		#endregion


		#region Inialize/Dispose

		public CProject()
		{
            m_cMeterConfig.IP = "192.168.1.254";
            m_cMeterConfig.Port = "502";
            m_cMeterConfig.ChannelNum = 9;
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

        public CRegressionUnitS RegressionUnitS
        {
            get { return m_cRegressgionUnitS; }
            set { m_cRegressgionUnitS = value; }
        }

        public CMeterItemS MeterItemS
        {
            get { return m_cMeterItemS; }
            set { m_cMeterItemS = value; }
        }

        public CTagItemS CoilTagItemS
        {
            get { return m_cCoilTagItemS; }
            set { m_cCoilTagItemS = value; }
        }

        public CTagItemS TagItemS
        {
            get { return m_cTagItemS; }
            set { m_cTagItemS = value; }
        }

        public Dictionary<string, CTagItemS> UnitTagItemS
        {
            get { return m_DicUnitTagItemS; }
            set { m_DicUnitTagItemS = value; }
        }        

        public List<CTag> StepCoilList
        {
            get { return m_lstCoilList; }
            set { m_lstCoilList = value; }
        }

		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}

		public string Path
		{
			get { return m_sPath; }
			set { m_sPath = value; }
		}

		public CTagS TagS
		{
			get { return m_cTagS; }
			set { m_cTagS = value; }
		}

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

		public CSymbolS SymbolS
		{
			get { return m_cSymbolS; }
			set { m_cSymbolS = value; }
		}

        public CLsConfig PlcConfig
		{
            get { return m_cPlcConfig; }
            set { m_cPlcConfig = value; }
		}

		public CLogConfig LogConfig
		{
			get { return m_cLogConfig; }
			set { m_cLogConfig = value; }
		}

        public CMeterConfig MeterConfig
        {
            get { return m_cMeterConfig; }
            set { m_cMeterConfig = value; }
        }

		#endregion


		#region Public Methods

		public void Clear()
		{
			if (m_cStepS != null)
				m_cStepS.Clear();

			if(m_cTagS != null)
				m_cTagS.Clear();

			if(m_cSymbolS != null)
				m_cSymbolS.Clear();
		}

		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
