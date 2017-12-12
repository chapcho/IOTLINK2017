using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExpression
{
	public class CLayer
	{
		#region Member Variables

		private string m_sKey = string.Empty;
		private int m_iIndex = 0;

		private CLayerS m_cSubLayerS = null;

		private string m_sCurrentUnit = "kWh";
		private string m_sLeakUnit = "mA";
		private string m_sVoltage = "V";
		private string m_sCarbon = "kCO₂";

		private double m_nCurrent = 0;
		private double m_nLeak = 0;
		private double m_nVoltage = 0;
		private double m_nCarbon = 0;
		#endregion

		#region Properties
		public string Key
		{
			get { return m_sKey; }
			set { m_sKey = value; }
		}

		public int Index
		{
			get { return m_iIndex; }
			set { m_iIndex = value; }
		}

		public CLayerS SubLayerS
		{
			get { return m_cSubLayerS; }
			set { m_cSubLayerS = value; }
		}

		public double Current
		{
			get { return m_nCurrent; }
			set { m_nCurrent = value; }
		}

		public double Leak
		{
			get { return m_nLeak; }
			set { m_nLeak = value; }
		}

		public double Voltage
		{
			get { return m_nVoltage; }
			set { m_nVoltage = value; }
		}

		public double Carbon
		{
			get { return m_nCarbon; }
			set { m_nCarbon = value; }
		}
		#endregion

		#region Initilize/Dispose
		public CLayer()
		{
			m_cSubLayerS = new CLayerS();
			m_cSubLayerS.Index = m_iIndex + 1;
		}

		public CLayer(string skey)
		{
			this.m_sKey = skey;
			m_cSubLayerS = new CLayerS();
			m_cSubLayerS.Index = m_iIndex + 1;
		}
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		#endregion
	}
}
