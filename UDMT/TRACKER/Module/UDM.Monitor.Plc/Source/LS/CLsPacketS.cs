using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Monitor.Plc.Source.LS
{
	internal class CLsPacketS : List<CLsPacket>, IDisposable
	{

		#region Member Variables

		protected int m_iBufferSize = 0;
		#endregion


		#region Initialize/Dispose

		public CLsPacketS()
		{ 

		}

		public CLsPacketS(List<CTag> lstTag)
		{
			Create(lstTag);
		}


		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		public int BufferSize
		{
			get { return m_iBufferSize; }
		}

		#endregion


		#region Public Methods

		public void Create(List<CTag> lstTag)
		{
			Clear();

			CLsHeaderGroupS cGroupS = new CLsHeaderGroupS(lstTag);

			List<CLsPacket> lstPacket = null;
			CLsPacket cLastPacket = null;
			CLsHeaderGroup cGroup = null;
			int iBufferIndex = 0;
			for(int i=0;i<cGroupS.Count;i++)
			{	
				cGroup = cGroupS.ElementAt(i).Value;
				lstPacket = CreatePacketList(cGroup, iBufferIndex);
				if(lstPacket != null)
				{
					int iCount = lstPacket.Count;
					cLastPacket = lstPacket[iCount - 1];
					iBufferIndex = cLastPacket.BufferIndex + cLastPacket.BufferSize;

					for (int j = 0; j < lstPacket.Count;j++ )
					{
						m_iBufferSize += lstPacket[j].BufferSize;
						this.Add(lstPacket[j]);
					}
					lstPacket.Clear();
				}
			}
		}

		
		public new void Clear()
		{
			base.Clear();

			m_iBufferSize = 0;
		}

		#endregion


		#region Private Methods

		protected List<CLsPacket> CreatePacketList(CLsHeaderGroup cGroup, int iStartIndex)
		{
			if (cGroup.Count == 0)
				return null;

			List<CLsPacket> lstPacket = new List<CLsPacket>();
			CLsSymbol cSymbol = null;
			CLsPacket cPacket = null;

			cSymbol = cGroup[0];
			int iBufferIndex = iStartIndex;
			int iMajorIndex = cSymbol.AddressMajorIndex;

			cPacket = new CLsPacket(cGroup.Header, iMajorIndex, iBufferIndex);
			cPacket.Add(cSymbol);
			lstPacket.Add(cPacket);

			for(int i=1;i<cGroup.Count;i++)
			{
				cSymbol = cGroup[i];
				if(cSymbol.AddressMajorIndex == iMajorIndex)
				{
					cPacket.Add(cSymbol);
				}
				else
				{
					if(cPacket != null)
					{
						cPacket.UpdateBuffer();
						iBufferIndex += cPacket.BufferSize;
					}

					iMajorIndex = cSymbol.AddressMajorIndex;
					cPacket = new CLsPacket(cGroup.Header, iMajorIndex, iBufferIndex);
					cPacket.Add(cSymbol);
					lstPacket.Add(cPacket);
				}	
			}

			if(cPacket != null)
				cPacket.UpdateBuffer();

			return lstPacket;
		}

		#endregion

	}
}
