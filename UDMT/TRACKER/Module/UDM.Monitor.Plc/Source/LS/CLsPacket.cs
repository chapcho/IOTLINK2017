using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.LS
{
	internal class CLsPacket : List<CLsSymbol>, IDisposable
	{

		#region Member Variables

		protected string m_sHeader = "";
		protected int m_iAddressIndex = -1;
		protected int m_iBufferIndex = -1;
		protected int m_iBufferSize = 2;
		protected int m_iValue = -1;

		#endregion


		#region Initialize/Dispose

		public CLsPacket()
		{

		}

		public CLsPacket(string sHeader, int iAddressIndex, int iBufferIndex)
		{
			m_sHeader = sHeader;
			m_iAddressIndex = iAddressIndex;
			m_iBufferIndex = iBufferIndex;
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		public string Header
		{
			get { return m_sHeader; }
			set { m_sHeader = value; }
		}

		public int AddressIndex
		{
			get { return m_iAddressIndex; }
		}

		public int BufferIndex
		{
			get { return m_iBufferIndex; }
			set { m_iBufferIndex = value; }
		}

		public int BufferSize
		{
			get { return m_iBufferSize; }
			set { m_iBufferSize = value; }
		}

		public int Value
		{
			get { return m_iValue; }
			set { m_iValue = value; }
		}

		#endregion


		#region Public Methods

		public void UpdateBuffer()
		{	
			// Buffer Size
			m_iBufferSize = 2;

			CLsSymbol cSymbol;
			int iBufferSize = 0;
			for(int i=0;i<this.Count;i++)
			{
				cSymbol = this[i];
				if (cSymbol.IsBitType == false)
				{
					iBufferSize = cSymbol.Size * 2;
				}

				if (iBufferSize > m_iBufferSize)
					m_iBufferSize = iBufferSize;
			}

			// Mask
			for (int i = 0; i < this.Count; i++)
			{
				cSymbol = this[i];
				cSymbol.UpdateMask(m_iBufferSize);
			}
		}

		public List<CLsSymbol> UpdateValue(int iPacketValue)
		{
			if (m_iValue != iPacketValue)
			{	
				List<CLsSymbol> lstSymbol = new List<CLsSymbol>();

				CLsSymbol cSymbol;
				for(int i = 0;i<this.Count;i++)
				{
					cSymbol = this[i];
					if(cSymbol.UpdateValue(iPacketValue))
						lstSymbol.Add(cSymbol);
				}

				m_iValue = iPacketValue;

				return lstSymbol;
			}
			else
			{
				return null;
			}
		}

		#endregion


		#region Private Methods


		#endregion

	}
}
