using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace FTOPApp
{
	public class COPCItemS : Dictionary<string, COPCItem>, IDisposable
	{

		#region Member Variables

        public Array ServerHandles = null;
		protected bool m_bReady = false;
		protected int m_iMaxIndex = 0;
		protected Dictionary<int, string> m_lstClientHandle = new Dictionary<int,string>();

		public OPCAutomation.OPCItems m_exOPCItemS = null;

		#endregion


		#region Initialize/Dispose

		public COPCItemS(OPCAutomation.OPCGroup exOPCGroup)
		{
			m_bReady = Initialize(exOPCGroup);
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		public bool IsReady
		{
			get { return m_bReady; }
			set { m_bReady = value; }
		}

		#endregion


		#region Public Methods

        public bool AddItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bAbOpc)
		{
			if (m_bReady == false)
				return false;

			List<COPCItem> lstAddItem = new List<COPCItem>();

            FTOPTagFull cTag;
			COPCItem cItem;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];
				if (this.ContainsKey(cTag.Key) == false)
				{
                    cItem = new COPCItem(cTag, bLsOpc, bAbOpc);
					lstAddItem.Add(cItem);
				}
			}

			if (lstAddItem.Count == 0)
				return true;

			bool bOK = AddOPCItemS(lstAddItem);
			lstAddItem.Clear();

			return bOK;
		}

        public List<COPCItem> AddInstantItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return null;

			List<COPCItem> lstTotalItem = new List<COPCItem>();
			List<COPCItem> lstAddItem = new List<COPCItem>();

            FTOPTagFull cTag;
			COPCItem cItem;
			for(int i=0;i<lstTag.Count;i++)
			{
				cTag = lstTag[i];
				if (this.ContainsKey(cTag.Key))
				{
					cItem = this[cTag.Key];
					lstTotalItem.Add(cItem);
				}
				else
				{
                    cItem = new COPCItem(cTag, bLsOpc, bABOpc);
					cItem.IsInstantItem = true;
					lstAddItem.Add(cItem);
				}
			}

			bool bOK = AddOPCItemS(lstAddItem);
			if(bOK)
				lstTotalItem.AddRange(lstAddItem);

			lstAddItem.Clear();

			return lstTotalItem;
		}

        public bool RemoveItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return false;

			List<COPCItem> lstRemoveItem = new List<COPCItem>();

            FTOPTagFull cTag;
			COPCItem cItem;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];
				if (this.ContainsKey(cTag.Key))
				{
                    cItem = new COPCItem(cTag, bLsOpc, bABOpc);
					lstRemoveItem.Add(cItem);
				}
			}

			if (lstRemoveItem.Count == 0)
				return true;

			bool bOK = RemoveOPCItemS(lstRemoveItem);
			lstRemoveItem.Clear();

			return bOK;
		}

		public bool RemoveInstantItemS(List<COPCItem> lstItemS)
		{
			if (m_bReady == false)
				return false;

			List<COPCItem> lstRemoveItem = new List<COPCItem>();

			COPCItem cItem;
			for(int i=0;i<lstItemS.Count;i++)
			{
				cItem = lstItemS[i];
				if (cItem.IsInstantItem)
					lstRemoveItem.Add(cItem);
			}

			bool bOK = RemoveOPCItemS(lstRemoveItem);
			lstRemoveItem.Clear();

			return bOK;
		}

		public string GetHandleKey(int iHandle)
		{
			string sKey = "";
			if (m_lstClientHandle.ContainsKey(iHandle))
				sKey = m_lstClientHandle[iHandle];

			return sKey;
		}

        public EMPLCDataType GetItemDataType(string key)
        {
            var item = this.FirstOrDefault(i=> i.Key == key);

            return item.Value.TagDataType;
        }

		public new void Clear()
		{
			if (m_bReady == false)
				return;

			try
			{
				List<COPCItem> lstOPCItem = this.Values.ToList();
				bool bOK = RemoveOPCItemS(lstOPCItem);

				lstOPCItem.Clear();
			}
			catch(System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

        public List<string> ValidateItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
        {
            if (m_bReady == false)
                return null;

            List<string> lstResult = new List<string>();
            List<COPCItem> lstAddItem = new List<COPCItem>();

            FTOPTagFull cTag;
            COPCItem cItem;
            for (int i = 0; i < lstTag.Count; i++)
            {
                cTag = lstTag[i];
                //if (this.ContainsKey(cTag.Key) == false)
                {
                    cItem = new COPCItem(cTag, bLsOpc, bABOpc);
                    lstAddItem.Add(cItem);
                }
            }

            if (lstAddItem.Count == 0)
                return null;

            lstResult = ValidateOPCItemS(lstAddItem);
            lstAddItem.Clear();
            return lstResult;
        }

		#endregion


		#region Private Methods

		protected bool Initialize(OPCAutomation.OPCGroup exOPCGroup)
		{
			m_exOPCItemS = exOPCGroup.OPCItems;
			if (m_exOPCItemS == null)
				return false;

			m_exOPCItemS.DefaultIsActive = true;

			return true;
		}

		private bool AddOPCItemS(List<COPCItem> lstItem)
		{
			if (lstItem.Count == 0)
				return true;

			bool bOK = true;

			try
			{
				Array arItemKeys = GetItemKeyArray(lstItem);
				Array arClientHandles = CreateClientHandleArray(lstItem, m_iMaxIndex);
				Array arResult = null;

                m_exOPCItemS.AddItems(lstItem.Count, ref arItemKeys, ref arClientHandles, out ServerHandles, out arResult);
				if (arResult != null)
				{	
					int iResult = 0;
					COPCItem cItem;
					for (int i = 0; i < lstItem.Count; i++)
					{
						cItem = lstItem[i];

						iResult = (int)arResult.GetValue(i + 1);
						if (iResult == 0)
						{
                            cItem.ServerHandle = (int)ServerHandles.GetValue(i + 1);
							if (cItem.IsInstantItem == false)
							{
								m_lstClientHandle.Add(cItem.ClientHandle, cItem.TagKey);
								this.Add(cItem.TagKey, cItem);
							}

							m_iMaxIndex += 1;
							if (m_iMaxIndex == 1000000)
								m_iMaxIndex = this.Count;
						}
                        else
                        {
                            bOK = false;
                        }
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				lstItem.Clear();

				bOK = false;
			}

			return bOK;
		}

        private List<string> ValidateOPCItemS(List<COPCItem> lstItem)
        {
            if (lstItem.Count == 0)
                return null;

            List<string> lstErrorTag = new List<string>();
            try
            {
                Array arItemKeys = GetItemKeyArray(lstItem);
                Array arResult = null;

                m_exOPCItemS.Validate(lstItem.Count, ref arItemKeys, out arResult);
                if (arResult != null)
                {
                    int iResult = 0;
                    COPCItem cItem;
                    for (int i = 0; i < lstItem.Count; i++)
                    {
                        iResult = (int)arResult.GetValue(i + 1);
                        if (iResult != 0)
                        {
                            cItem = lstItem[i];
                            lstErrorTag.Add(cItem.TagKey);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                lstItem.Clear();
                return null;
            }

            return lstErrorTag;
        }
		private bool RemoveOPCItemS(List<COPCItem> lstItem)
		{
			if (lstItem.Count == 0)
				return true;

			bool bOK = true;

			try
			{
				//Array arServerHandles = GetServerHandleArray(lstItem);
				Array arResult = null;

                m_exOPCItemS.Remove(lstItem.Count, ref ServerHandles, out arResult);
				if (arResult != null)
				{
					int iResult = 0;
					COPCItem cItem;
					for (int i = 0; i < lstItem.Count; i++)
					{
						cItem = lstItem[i];

						iResult = (int)arResult.GetValue(i + 1);
						if (iResult == 0)
						{
							if (cItem.IsInstantItem == false)
							{
								m_lstClientHandle.Remove(cItem.ClientHandle);
								this.Remove(cItem.TagKey);
							}
						}
						else
						{
							bOK = false;
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				lstItem.Clear();

				bOK = false;
			}

			return bOK;
		}

		private Array GetItemKeyArray(List<COPCItem> lstItem)
		{
			Array arHandles = Array.CreateInstance(typeof(string), lstItem.Count + 1);
			arHandles.SetValue("", 0);

			for (int i = 0; i < lstItem.Count; i++)
				arHandles.SetValue(lstItem[i].Key, i + 1);

			return arHandles;
		}

		private Array GetServerHandleArray(List<COPCItem> lstItem)
		{
			Array arHandles = Array.CreateInstance(typeof(int), lstItem.Count + 1);
			arHandles.SetValue(0, 0);

			for (int i = 0; i < lstItem.Count; i++)
				arHandles.SetValue(lstItem[i].ServerHandle, i + 1);

			return arHandles;
		}

		private Array CreateClientHandleArray(List<COPCItem> lstItem, int iStartHandle)
		{
			Array arHandles = Array.CreateInstance(typeof(int), lstItem.Count + 1);
			arHandles.SetValue(0, 0);

			int iIndex = iStartHandle;
			for (int i = 0; i < lstItem.Count; i++)
			{
				lstItem[i].ClientHandle = iIndex;
				arHandles.SetValue(iIndex, i + 1);

				iIndex += 1;
			}

			return arHandles;
		}

		#endregion


		#region Event Methods


		#endregion
	}
}
