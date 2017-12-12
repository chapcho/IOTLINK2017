using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;

namespace UDMLadderTracker
{
    public static class CTrackerHelper
    {

        #region Member Variables

        private static int m_iFlowOffSetTime = 1;

        #endregion


        #region Public Methods

		#region Flow ItemS

        //public static CFlowItemS CreateFlowItemS(CMySqlLogReader cLogReader, CGroup cGroup, CGroupLog cGroupLog)
        //{
        //    CFlowItemS cTotalItemS = new CFlowItemS();
        //    cTotalItemS.First = cGroupLog.CycleStart;
        //    cTotalItemS.Last = cGroupLog.CycleEnd;

        //    CFlowItem cItem;
        //    CFlowItemS cItemS = CreateGroupProcessFlowItemS(cGroup, cGroupLog);
        //    for (int i = 0; i < cItemS.Count; i++)
        //    {
        //        cItem = cItemS[i];
        //        if (cTotalItemS.ContainsKey(cItem.Key) == false)
        //            cTotalItemS.Add(cItem.Key, cItem);
        //    }

        //    cItemS.Clear();
        //    cItemS = CreateFlowItemS(cLogReader, cGroup.Key, cGroup.KeySymbolS, cGroupLog.CycleStart, cGroupLog.CycleEnd, true);
        //    for (int i = 0; i < cItemS.Count;i++ )
        //    {
        //        cItem = cItemS[i];
        //        if (cTotalItemS.ContainsKey(cItem.Key) == false)
        //            cTotalItemS.Add(cItem.Key, cItem);
        //    }

        //    //cItemS.Clear();
        //    //cItemS = CreateFlowItemS(cLogReader, cGroup.Key, cGroup.GeneralSymbolS, cGroupLog.CycleStart, cGroupLog.CycleEnd, false);
        //    //for (int i = 0; i < cItemS.Count; i++)
        //    //{
        //    //    cItem = cItemS[i];
        //    //    if (cTotalItemS.ContainsKey(cItem.Key) == false)
        //    //        cTotalItemS.Add(cItem.Key, cItem);
        //    //}

        //    //cItemS.Clear();
        //    //cItemS = CreateFlowItemS(cLogReader, cGroup.Key, cGroup.TrendSymbolS, cGroupLog.CycleStart, cGroupLog.CycleEnd, false);
        //    //for (int i = 0; i < cItemS.Count; i++)
        //    //{
        //    //    cItem = cItemS[i];
        //    //    if (cTotalItemS.ContainsKey(cItem.Key) == false)
        //    //        cTotalItemS.Add(cItem.Key, cItem);
        //    //}

        //    cItemS.Clear();
        //    cItemS = CreateFlowItemS(cLogReader, cGroup.Key, cGroup.AbnormalSymbolS, cGroupLog.CycleStart, cGroupLog.CycleEnd, false);
        //    for (int i = 0; i < cItemS.Count; i++)
        //    {
        //        cItem = cItemS[i];
        //        if (cTotalItemS.ContainsKey(cItem.Key) == false)
        //            cTotalItemS.Add(cItem.Key, cItem);
        //    }

        //    return cTotalItemS;
        //}

        public static CFlowItemS CreateFlowItemS(CMySqlLogReader cLogReader, string sGroup, CKeySymbolS cSymbolS, CCycleInfo cInfo, bool bSubSymbol)
        {
            CFlowItemS cItemS = CreateFlowItemS(cLogReader, sGroup, cSymbolS, cInfo.CycleStart, cInfo.CycleEnd, bSubSymbol);

            return cItemS;
        }

        public static CFlowItemS CreateFlowItemS(CMySqlLogReader cLogReader, string sGroup, CKeySymbolS cSymbolS, DateTime dtFrom, DateTime dtTo, bool bSubSymbol)
        {
            if (cLogReader == null || cLogReader.IsConnected == false)
                return null;

            CFlowItemS cItemS = new CFlowItemS();
            cItemS.First = dtFrom;
            cItemS.Last = dtTo;

            List<string> lstKey = cSymbolS.Keys.ToList();
            CTimeLogS cTotalLogS = cLogReader.GetTimeLogS(lstKey, dtFrom, dtTo);
            if (cTotalLogS == null)
                cTotalLogS = new CTimeLogS();

            CFlowItem cItem;
            CFlowItem cSubItem;
            CTimeLogS cLogS;
            CTimeLogS cSubLogS;
            CKeySymbol cSymbol;
            CTag cSubTag;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS.ElementAt(i).Value;
                cLogS = cTotalLogS.GetTimeLogS(cSymbol.Tag.Key);
                if (cLogS == null)
                    cLogS = new CTimeLogS();

                cItem = CreateFlowItem(sGroup, cSymbol.Tag, dtFrom, dtTo, cLogS);
                if (bSubSymbol)
                {
                    if (cSymbol.FirstTagList != null && cSymbol.FirstTagList.Count > 0)
                    {
                        cItem.SubFlow = new CFlow();
                        for (int j = 0; j < cSymbol.FirstTagList.Count; j++)
                        {
                            cSubTag = cSymbol.FirstTagList[j];
                            cSubLogS = cLogReader.GetTimeLogS(cSubTag.Key, dtFrom, dtTo);
                            if (cSubLogS == null)
                                cSubLogS = new CTimeLogS();

                            cSubItem = CreateFlowItem(sGroup, cSubTag, dtFrom, dtTo, cSubLogS);
                            if (cItem.SubFlow.FlowItemS.ContainsKey(cSubTag.Key) == false)
                                cItem.SubFlow.FlowItemS.Add(cSubTag.Key, cSubItem);
                        }
                    }
                }

                cItemS.Add(cSymbol.Tag.Key, cItem);

                cLogS.Clear();
            }

            cTotalLogS.Clear();
            cTotalLogS = null;

            return cItemS;
        }

		public static CFlowItemS CreateFlowItemS(CMySqlLogReader cLogReader, CTagS cTagS, DateTime dtFrom, DateTime dtTo)
		{
			if (cLogReader == null || cLogReader.IsConnected == false)
				return null;

			CFlowItemS cItemS = new CFlowItemS();
			cItemS.First = dtFrom;
			cItemS.Last = dtTo;

			List<string> lstKey = cTagS.Keys.ToList();
			CTimeLogS cTotalLogS = cLogReader.GetTimeLogS(lstKey, dtFrom, dtTo);
			if (cTotalLogS == null)
				cTotalLogS = new CTimeLogS();

			CFlowItem cItem;
			CTimeLogS cLogS;
			CTag cTag;
			for (int i = 0; i < cTagS.Count; i++)
			{
				cTag = cTagS[i];
				cLogS = cTotalLogS.GetTimeLogS(cTag.Key);
				if (cLogS == null)
					cLogS = new CTimeLogS();

				cItem = CreateFlowItem(cTag, dtFrom, dtTo, cLogS);

				cItemS.Add(cTag.Key, cItem);

				cLogS.Clear();
			}

			cTotalLogS.Clear();
			cTotalLogS = null;

			return cItemS;
		}

        public static CFlowItemS CreateFlowItemS(string sGroup, CKeySymbolS cSymbolS, DateTime dtFrom, DateTime dtTo, CTimeLogS cTotalLogS, bool bSubSymbol)
        {
            CFlowItemS cItemS = new CFlowItemS();
            cItemS.First = dtFrom;
            cItemS.Last = dtTo;

            CFlowItem cItem;
            CFlowItem cSubItem;
            CTimeLogS cLogS;
            CTimeLogS cSubLogS;
            CKeySymbol cSymbol;
            CTag cSubTag;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS.ElementAt(i).Value;
                cLogS = cTotalLogS.GetTimeLogS(cSymbol.Tag.Key, dtFrom, dtTo);
                if (cLogS == null)
                    cLogS = new CTimeLogS();

                cItem = CreateFlowItem(sGroup, cSymbol.Tag, dtFrom, dtTo, cLogS);
                if (bSubSymbol)
                {
                    if (cSymbol.FirstTagList != null && cSymbol.FirstTagList.Count > 0)
                    {
                        cItem.SubFlow = new CFlow();
                        for (int j = 0; j < cSymbol.FirstTagList.Count; j++)
                        {
                            cSubTag = cSymbol.FirstTagList[j];
                            cSubLogS = cTotalLogS.GetTimeLogS(cSubTag.Key, dtFrom, dtTo);

                            if (cSubLogS == null)
                                cSubLogS = new CTimeLogS();

                            cSubItem = CreateFlowItem(sGroup, cSubTag, dtFrom, dtTo, cSubLogS);
                            cItem.SubFlow.FlowItemS.Add(cSubTag.Key, cSubItem);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
                cItemS.Add(cSymbol.Tag.Key, cItem);

                cLogS.Clear();
            }

            return cItemS;
        }

		#endregion

		#region Filter

		public static bool IsAddressFiltered(CTag cTag, List<string> lstFilter)
		{
			bool bOK = false;
			for (int i = 0; i < lstFilter.Count; i++)
			{
				if (cTag.Address.StartsWith(lstFilter[i]))
				{
					bOK = true;
					break;
				}
			}

			return bOK;
		}

		public static bool IsDescriptionFiltered(CTag cTag, List<string> lstFilter)
		{
			string sDescription = cTag.Description.ToLower().Trim();

			bool bOK = false;
			for (int i = 0; i < lstFilter.Count; i++)
			{
				if (sDescription == "" || sDescription.Contains(lstFilter[i]))
				{
					bOK = true;
					break;
				}
			}

			return bOK;
		}

		#endregion

		#endregion


		#region Private Methods

		private static CFlowItemS CreateGroupProcessFlowItemS(CGroup cGroup, CGroupLog cGroupLog)
		{
			CFlowItemS cItemS = new CFlowItemS();
			CFlowItem cItem;
			CTimeNode cNode;

			cItem = new CFlowItem();
			if(cGroup.Product == null || cGroup.Product.Key == "")
				cItem.Key = cGroup.Product.Key;
			else
				cItem.Key = "[PRD]" + cGroup.Key;

			cItem.Description = cGroup.Key + " 제품정보";
			cNode = new CTimeNode();
			cNode.Start = cGroupLog.CycleStart;
			cNode.End = cGroupLog.CycleEnd;
			cNode.Text = "제품:" + cGroupLog.Product;
			cItem.TimeNodeS.Add(cNode);
			cItemS.Add(cItem.Key, cItem);

			cItem = new CFlowItem();
			if (cGroup.Recipe == null || cGroup.Recipe.Key == "")
				cItem.Key = cGroup.Recipe.Key;
			else
				cItem.Key = "[RCP]" + cGroup.Key;

			cItem.Description = cGroup.Key + " 차종정보";
			cNode = new CTimeNode();
			cNode.Start = cGroupLog.CycleStart;
			cNode.End = cGroupLog.CycleEnd;
			cNode.Text = "차종:" + cGroupLog.Recipe;
			cItem.TimeNodeS.Add(cNode);
			cItemS.Add(cItem.Key, cItem);

			return cItemS;
		}

        private static CFlowItem CreateFlowItem(string sGroup, CTag cTag, DateTime dtFrom, DateTime dtTo, CTimeLogS cLogS)
        {
            CFlowItem cItem = new CFlowItem();
            cItem.Key = cTag.Key;
            cItem.Group = sGroup;
            cItem.Description = cTag.Description;
            cItem.First = dtFrom;
            cItem.Last = dtTo;

            if (cLogS != null && cLogS.Count > 0)
            {
                cItem.TimeNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo.AddSeconds(m_iFlowOffSetTime));
                cLogS.Clear();
                cLogS = null;
            }

            return cItem;
        }

		private static CFlowItem CreateFlowItem(CTag cTag, DateTime dtFrom, DateTime dtTo, CTimeLogS cLogS)
		{
			CFlowItem cItem = new CFlowItem();
			cItem.Key = cTag.Key;
			cItem.Description = cTag.Description;
			cItem.First = dtFrom;
			cItem.Last = dtTo;

			if (cLogS != null && cLogS.Count > 0)
			{
				cItem.TimeNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo.AddSeconds(m_iFlowOffSetTime));
				cLogS.Clear();
				cLogS = null;
			}

			return cItem;
		}

        #endregion
    }
}
