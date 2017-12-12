using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.LS
{
    internal class CLsSymbol : IDisposable
	{

		#region Member Variables

		protected string m_sKey = "";
		protected string m_sAddress = "";
		protected int m_iSize = 1;
		protected bool m_bBitType = true;
		protected string m_sAddressHeader = "";
		protected int m_iAddressMajor = -1;
		protected int m_iAddressMinor = -1;
		protected int m_iMask = -1;
		protected int m_iValue = -1;

		#endregion


		#region Intialize/Dispose

		public CLsSymbol()
		{

		}

		public CLsSymbol(string sKey, string sAddress)
		{
			m_sKey = sKey;
			SetAddress(sAddress);
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public string Key
		{
			get { return m_sKey; }
			set { m_sKey = value; }
		}

		public string Address
		{
			get { return m_sAddress; }
			set { SetAddress(value); }
		}		

		public int Size
		{
			get { return m_iSize; }
			set { m_iSize = value; }
		}

		public bool IsBitType
		{
			get { return m_bBitType; }
		}

		public string AddressHeader
		{
			get { return m_sAddressHeader; }
		}

		public int AddressMajorIndex
		{
			get { return m_iAddressMajor; }
		}

		public int AddressMinorIndex
		{
			get { return m_iAddressMinor; }
		}

		public int Mask
		{
			get { return m_iMask; }
			set { m_iMask = value; }
		}

		public int Value
		{
			get { return m_iValue; }
			set { m_iValue = value; }
		}

		#endregion


		#region Public Methods

		public void UpdateMask(int iBufferSize)
		{
			if (m_bBitType == false)	// word
			{
				if (iBufferSize == m_iSize * 2)
					m_iMask = -1;
				else
					m_iMask = (int)(Math.Pow(2, m_iSize * 16)) - 1;
			}
			else
			{
				m_iMask = (int)(Math.Pow(2, m_iAddressMinor));
			}
		}

		public bool UpdateValue(int iValue)
		{
			bool bOK = false;

			if (m_iMask > 0)
			{
				int iMaskValue = m_iMask & iValue;
				if(m_bBitType)
				{
					if (iMaskValue == m_iMask)
						iMaskValue = 1;
					else
						iMaskValue = 0;
				}

				if (m_iValue != iMaskValue)
				{
					m_iValue = iMaskValue;
					bOK = true;
				}
			}
			else
			{
				if (m_iValue != iValue)
				{
					m_iValue = iValue;
					bOK = true;
				}
			}

			return bOK;
		}

		#endregion


		#region Private Methods

		protected void SetAddress(string sAddress)
		{
			m_sAddress = sAddress;

			m_sAddressHeader = "";
			m_iAddressMajor = -1;
			m_iAddressMinor = -1;
			m_bBitType = false;
			if (sAddress.Length < 5)
				return;

			string sTemp = sAddress;
			m_sAddressHeader = sTemp[0].ToString();

			sTemp = sAddress.Substring(1, 4);
			m_iAddressMajor = Convert.ToInt32(sTemp);
			sTemp = sAddress.Substring(5);
			if(sTemp.Length > 0)
			{
				if(sTemp[0] == '.')
					sTemp = sTemp.Remove(0, 1);

				m_iAddressMinor = Convert.ToInt32(sTemp, 16);
				m_bBitType = true;
			}
		}

		#endregion
	}
}
