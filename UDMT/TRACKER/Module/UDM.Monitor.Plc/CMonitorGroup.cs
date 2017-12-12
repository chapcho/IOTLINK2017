using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc
{
    public class CMonitorGroup : CObject
    {
        #region Member Variables

        protected CGroup m_cGroup = null;
        protected string m_sProduct = "";
        protected string m_sRecipe = "";
        protected DateTime m_dtCycleStart = DateTime.MinValue;
        protected DateTime m_dtCycleEnd = DateTime.MinValue;
        protected DateTime m_dtTimeOut = DateTime.MinValue;
        protected EMGroupStateType m_emStateType = EMGroupStateType.End;
        protected string m_sNote = "";

        protected CTimeLogS m_cTimeLogS = new CTimeLogS();

        #endregion


        #region Initialize/Dispose

        public CMonitorGroup(CGroup cGroup)
        {
            m_sKey = cGroup.Key;
            m_cGroup = cGroup;
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public CGroup Group
        {
            get { return m_cGroup; }
            set { m_cGroup = value; }
        }

        public string Product
        {
            get { return m_sProduct; }
        }

        public string Recipe
        {
            get { return m_sRecipe; }
        }

        public DateTime CycleStart
        {
            get { return m_dtCycleStart; }
        }

        public DateTime CycleEnd
        {
            get { return m_dtCycleEnd; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
        }

        #endregion


        #region Public Methods

        public CGroupLogS AddLog(CTimeLog cLog)
        {
            if (cLog == null || cLog.Key == "")
                return null;

			CSymbol cSymbol = m_cGroup.GetSymbol(cLog.Key);
			if (cSymbol == null)
				return null;

            CGroupLog cGroupLog;
            CGroupLogS cGroupLogS = new CGroupLogS();
            bool bStateChanged = false;
            bool bCycleSymbol = false;
            if (cSymbol.RoleType == EMGroupRoleType.Key)
            {
                if (m_cGroup.CycleStartConditionS.ContainsKey(cLog.Key))
                {
                    m_cGroup.CycleStartConditionS.Set(cLog.Key, cLog.Value);
                    bCycleSymbol = true;
                }

                if (m_cGroup.CycleEndConditionS.ContainsKey(cLog.Key))
                {
                    m_cGroup.CycleEndConditionS.Set(cLog.Key, cLog.Value);
                    bCycleSymbol = true;
                }

                if (bCycleSymbol)
                {
                    if (m_emStateType == EMGroupStateType.Start || m_emStateType == EMGroupStateType.Error)
                    {
                        bStateChanged = m_cGroup.CycleEndConditionS.CheckSatisfied();
                        if (bStateChanged)
                        {
                            m_dtCycleEnd = cLog.Time;

                            if(m_emStateType == EMGroupStateType.Error)
                                m_emStateType = EMGroupStateType.ErrorEnd;
                            else
                                m_emStateType = EMGroupStateType.End;

                            cGroupLog = CreateGroupLog(m_emStateType);
                            cGroupLogS.Add(cGroupLog);
                        }
                    }

                    if (m_emStateType == EMGroupStateType.End || m_emStateType == EMGroupStateType.Error || m_emStateType == EMGroupStateType.ErrorEnd)
                    {
                        bStateChanged = m_cGroup.CycleStartConditionS.CheckSatisfied();
                        if (bStateChanged)
                        {
                            if(m_emStateType == EMGroupStateType.Error)
                            {
                                m_dtCycleEnd = cLog.Time.AddSeconds(-1);
                                cGroupLog = CreateGroupLog(EMGroupStateType.ErrorEnd);
                                cGroupLogS.Add(cGroupLog);
                            }

                            m_dtCycleStart = cLog.Time;
                            m_emStateType = EMGroupStateType.Start;
                            m_dtTimeOut = DateTime.Now.AddMilliseconds(m_cGroup.MaxCycleTime);

                            if(m_cGroup.Recipe != null)
                                m_sRecipe = m_cGroup.Recipe.Value.ToString();

                            if(m_cGroup.Product != null)
                                m_sProduct = m_cGroup.Product.Value.ToString();

                            if (m_cTimeLogS == null)
                                m_cTimeLogS = new CTimeLogS();
                            else
                                m_cTimeLogS.Clear();

                            cGroupLog = CreateGroupLog(m_emStateType);
                            cGroupLogS.Add(cGroupLog);
                        }
                    }

                    if(bStateChanged)
                    {
                        m_cGroup.CycleStartConditionS.Reset();
                        m_cGroup.CycleEndConditionS.Reset();
                    }
                }

                m_cTimeLogS.Add(cLog);
            }
            else if (cSymbol.RoleType == EMGroupRoleType.Trend)
            {
                CMonitorErrorInfo cInfo = CheckTrendSymbol(cSymbol, cLog.Value);
                if(cInfo != null)
                {
                    m_emStateType = EMGroupStateType.Error;
                    m_dtCycleEnd = DateTime.Now;

                    cGroupLog = CreateGroupLog(m_emStateType);
                    cGroupLog.Data = cInfo;
                    cGroupLogS.Add(cGroupLog);
                }
            }
            else if (cSymbol.RoleType == EMGroupRoleType.Abnormal)
            {
                CMonitorErrorInfo cInfo = CheckAbnormalSymbol(cSymbol, cLog.Value);
                if (cInfo != null)
                {
                    m_emStateType = EMGroupStateType.Error;
                    m_dtCycleEnd = DateTime.Now;

                    cGroupLog = CreateGroupLog(m_emStateType);
                    cGroupLog.Data = cInfo;
                    cGroupLogS.Add(cGroupLog);
                }
            }

            return cGroupLogS;
        }

        public CGroupLog CheckCycleTimeOut(DateTime dtTime)
        {
            CGroupLog cGroupLog = null;
            if (m_emStateType == EMGroupStateType.Start)
            {
                if (dtTime > m_dtTimeOut)
                {
                    m_dtCycleEnd = m_dtCycleStart.AddMilliseconds(m_cGroup.MaxCycleTime);

                    cGroupLog = CreateGroupLog(EMGroupStateType.Error);
                    m_emStateType = EMGroupStateType.Error;
                }
            }

            return cGroupLog;
        }

        public CMonitorErrorInfo CheckTrendSymbol(CSymbol cSymbol, int iValue)
        {
            CMonitorErrorInfo cInfo = null;
            if (m_emStateType == EMGroupStateType.Start)
            {
                if (cSymbol.UpperBound != -1 && cSymbol.Value > cSymbol.UpperBound)
                {
                    cInfo = new CMonitorErrorInfo(m_sKey, EMMonitorGroupErrorType.Trend);
                    cInfo.Symbol = cSymbol;
                    cInfo.Value = iValue;
                }
                else if (cSymbol.LowerBound != -1 && cSymbol.Value < cSymbol.LowerBound)
                {
                    cInfo = new CMonitorErrorInfo(m_sKey, EMMonitorGroupErrorType.Trend);
                    cInfo.Symbol = cSymbol;
                    cInfo.Value = iValue;
                }
            }

            return cInfo;
        }

        public CMonitorErrorInfo CheckAbnormalSymbol(CSymbol cSymbol, int iValue)
        {
            CMonitorErrorInfo cInfo = null;
            if (m_emStateType == EMGroupStateType.Start)
            {
                if (iValue == 1)
                {
                    cInfo = new CMonitorErrorInfo(m_sKey, EMMonitorGroupErrorType.Abnormal);
                    cInfo.Symbol = cSymbol;
                    cInfo.Value = iValue;
                }
            }

            return cInfo;
        }

        public void Clear()
        {
            m_cGroup.CycleStartConditionS.Reset();
            m_cGroup.CycleEndConditionS.Reset();

            m_emStateType = EMGroupStateType.End;

            m_dtCycleStart = DateTime.MinValue;
            m_dtCycleEnd = DateTime.MinValue;
            m_dtTimeOut = DateTime.MinValue;
        }

        #endregion


        #region Private Methods

        private CGroupLog CreateGroupLog(EMGroupStateType emState)
        {
            CGroupLog cLog = new CGroupLog(m_sKey);

            cLog.CycleStart = m_dtCycleStart;
            cLog.CycleEnd = m_dtCycleEnd;
            cLog.Recipe = m_sRecipe;
            cLog.Product = m_sProduct;
            cLog.StateType = emState;

            if (emState == EMGroupStateType.End || emState == EMGroupStateType.Error || emState == EMGroupStateType.ErrorEnd)
                cLog.TimeLogS.AddRange(m_cTimeLogS);

            return cLog;
        }

        #endregion
    }
}
