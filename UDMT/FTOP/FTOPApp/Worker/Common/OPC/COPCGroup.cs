using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using UDM.Common;
using UDM.Log;

namespace FTOPApp
{
    public class COPCGroup : IDisposable
    {

        #region Member Variables

		protected string m_sKey = "";
		protected bool m_bReady = false;
		protected bool m_bUseEvent = true;
		protected bool m_bFirstEvent = true;		
		protected COPCItemS m_cOPCItemS = null;

        public OPCAutomation.OPCGroup m_exOPCGroup = null;

        public event UEventHandlerValueChanged UEventValueChanged;

        #endregion


        #region Initialize/Dispose

		public COPCGroup(string sKey, OPCAutomation.OPCGroups exOPCGroupS, int iUpdateRate, bool bUseEvent)
        {
			m_sKey = sKey;
			m_bUseEvent = bUseEvent;
			m_bReady = Initialize(exOPCGroupS, iUpdateRate);
        }

        public void Dispose()
        {
            Stop();
            Clear();
        }

        #endregion


        #region Public Properties

		public bool IsReady
		{
			get { return m_bReady; }
			set { m_bReady = value; }
		}

        public COPCItemS ItemS
        {
            get { return m_cOPCItemS; }
            set { m_cOPCItemS = value; }
        }

        #endregion


        #region Public Methods

        public bool AddItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bAbOpc)
		{
			if (m_bReady == false)
				return false;

			bool bOK = m_cOPCItemS.AddItemS(lstTag, bLsOpc, bAbOpc);
			if (bOK == false)
				m_cOPCItemS.Clear();

			return bOK;
		}

        public bool RemoveItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return false;

			return m_cOPCItemS.RemoveItemS(lstTag, bLsOpc, bABOpc);
		}

        public List<string> ValidateItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
        {
            if (m_bReady == false)
                return null;

            return m_cOPCItemS.ValidateItemS(lstTag, bLsOpc, bABOpc);
        }
		
        public bool Run()
		{
			if (m_bReady == false)
				return false;

			m_bFirstEvent = true;

			if(m_bUseEvent)
				m_exOPCGroup.DataChange += new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(m_exOPCGroup_DataChange);

			return true;
		}

		public bool Stop()
		{
			if (m_bReady == false)
				return false;

			if(m_bUseEvent)
				m_exOPCGroup.DataChange -= new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(m_exOPCGroup_DataChange);

			return true;
		}

        public List<FTag> ReadInstant(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return null;

			List<COPCItem> lstOPCItem = m_cOPCItemS.AddInstantItemS(lstTag, bLsOpc, bABOpc);
			if (lstOPCItem == null)
				return null;

            List<FTag> tagS = new List<FTag>();

			try
			{
				Array arValue = null;
				Array arResult = null;
				object oQuality = null;
				object oTimeStamp = null;


                m_exOPCGroup.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, lstOPCItem.Count, ref  m_cOPCItemS.ServerHandles, out arValue, out arResult, out oQuality, out oTimeStamp);
				DateTime dtNow = DateTime.Now;

				COPCItem cItem;
				object oValue;
				int iResult = 0;
				for(int i=0;i<lstOPCItem.Count;i++)
				{
					cItem = lstOPCItem[i];

					iResult = (int)arResult.GetValue(i + 1);
					if(iResult == 0)
					{
						oValue = arValue.GetValue(i + 1);
						if (oValue != null)
						{
                            var tag = new FTag();
                            tag.Key = cItem.TagKey;
                            tag.Time = dtNow;
                            tag.Value = GetValue(cItem.TagDataType,oValue);  // 일단 초기값은 없다 일단..;;; 데이터 타입 작업 때문에 
                            tagS.Add(tag);
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			//m_cOPCItemS.RemoveInstantItemS(lstOPCItem);

			return tagS;
		}

		public void Clear()
		{
			if (m_bReady == false)
				return;

			if (m_cOPCItemS != null)
				m_cOPCItemS.Clear();

			m_exOPCGroup = null;
			m_cOPCItemS = null;
		}

        #endregion


        #region Private Methods

		protected bool Initialize(OPCAutomation.OPCGroups exOPCGroupS, int iUpdateRate)
		{
			bool bOK = false;

			try
			{
				Clear();

				m_exOPCGroup = exOPCGroupS.Add(m_sKey);
				if (m_exOPCGroup != null)
				{
					m_exOPCGroup.IsSubscribed = true;
					m_exOPCGroup.IsActive = true;
					m_exOPCGroup.UpdateRate = iUpdateRate;
					m_exOPCGroup.DeadBand = (float)0;


					if (m_cOPCItemS == null)
						m_cOPCItemS = new COPCItemS(m_exOPCGroup);

					bOK = m_cOPCItemS.IsReady;
					if (bOK == false)
						m_cOPCItemS = null;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			return bOK;
		}

		private Array GetServerHandleArray(List<COPCItem> lstItem)
		{
            Array arHandles = Array.CreateInstance(typeof(int), lstItem.Count + 1);
			arHandles.SetValue(0, 0);

			for (int i = 0; i < lstItem.Count; i++)
				arHandles.SetValue(lstItem[i].ServerHandle, i + 1);

			return arHandles;
		}

        private void GenerateValueChangeEvent(DateTime makeTime, string key, object value)
		{
			if (UEventValueChanged != null)
                UEventValueChanged(makeTime, key, value);
		}

        private object GetValue(EMPLCDataType type, object oValue)
		{

            object value = null;
            string temp = "";
            if(type == EMPLCDataType.Bool)
            {
                temp = ((bool)oValue).ToString();
                if (temp == "True" || temp == "true")
                    value = 1;
                else if (temp == "False" || temp == "false")
                    value = 0;
            }
            else
                value = oValue;

            return value;


            //float iValue = -1;

            //string sValue = oValue.ToString();
            //if (sValue == "True" || sValue == "true")
            //    iValue = 1;
            //else if (sValue == "False" || sValue == "false")
            //    iValue = 0;
            //else
            //    iValue = (float)oValue;

            //return iValue;

            
		}

        #endregion


        #region Event Methods

        private void m_exOPCGroup_DataChange(int iTransactionID, int iCount, ref System.Array arClientHandles, ref System.Array arItemValues, ref System.Array arItemQuality, ref System.Array arTimeStamp)
        {
			if (m_exOPCGroup == null || m_cOPCItemS == null)
				return;

            if (m_bFirstEvent)
            {
                m_bFirstEvent = false;
                return;
            }

            try
            {   
				string sKey = "";
                EMPLCDataType sDatatype = EMPLCDataType.Bool;
                object oValue = 0;
				int iHandle = 0;
                
                for (int i = 0; i < iCount; i++)
                {
                    iHandle = (int)arClientHandles.GetValue(i + 1);
					sKey = m_cOPCItemS.GetHandleKey(iHandle);
                    sDatatype = m_cOPCItemS.GetItemDataType(sKey);
                    
					if(sKey != "")
					{
						oValue = (object)arItemValues.GetValue(i + 1);
						if (oValue != null)
                        {
                            GenerateValueChangeEvent(DateTime.Now, sKey, GetValue(sDatatype, oValue));
                        }
                           
                           
					}
                }

                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion
    }
}
