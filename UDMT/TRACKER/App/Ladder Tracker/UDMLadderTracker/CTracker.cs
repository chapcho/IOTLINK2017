using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source.DDEA;
using UDM.Monitor.Plc.Source.OPC;
using UDM.Flow;
using UDM.Project;
using UDM.UI;

namespace UDMTrackerSimple
{
    public class CTracker : IDisposable
    {

        #region Member Variables

        private bool m_bRun = false;
        private bool bFirstEvent = true;
        private CMonitor m_cMonitor = new CMonitor();
        private CMySqlLogWriter m_cWriter = new CMySqlLogWriter();
        private UCGroupStateTable m_ucMonitorGroupState = null;
        private UCMonitorStatus m_ucMonitorStatusView = null;
		private UCGroupCycleBoardS m_ucGroupCycleView = null;
        private UCSummary m_ucSummaryView = null;
        private EMMonitorType m_emMonitorType = EMMonitorType.Detection;
        private DevExpress.XtraGrid.GridControl m_CollectSymbolGrid = null;
        private DevExpress.XtraGrid.GridControl m_UserAllGrid = null;
        private DevExpress.XtraGrid.GridControl m_UserWordGrid = null;
        private List<CCollectTag> m_lstCollectTag = new List<CCollectTag>();
        public event UEventHandlerTrackerCycleStarted UEventCycleStarted;
        public event UEventHandlerTrackerCycleStarted UEventCycleEnded;
        public event UEventHandlerTrackerErrorDetected UEventErrorDetected;
        public event UEventHandlerTrackerErrorDetected UEventAbnormalDetected;
        public event UEventHandlerTrackerInterlockSymbolS UEventInterlckSymbolS;

        #endregion


        #region Initialize/Dispose

        public CTracker()
        {
            
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public UCSummary SummaryView
        {
            get { return m_ucSummaryView; }
            set { m_ucSummaryView = value; }
        }

        public UCGroupStateTable GroupStateTable
        {
            get { return m_ucMonitorGroupState; }
            set { m_ucMonitorGroupState = value; }
        }

        public UCMonitorStatus MonitorStatusView
        {
            get { return m_ucMonitorStatusView; }
            set { m_ucMonitorStatusView = value; }
        }

		public UCGroupCycleBoardS GroupCycleBoardS
		{
			get { return m_ucGroupCycleView; }
			set { m_ucGroupCycleView = value; }
		}

        public CMonitor Monitor
        {
            get { return m_cMonitor; }
        }

        public CMySqlLogWriter LogWriter
        {
            get { return m_cWriter; }
            set { m_cWriter = value; }
        }

        public EMMonitorType MonitorType
        {
            get { return m_emMonitorType; }
            set { m_emMonitorType = value; }
        }

        public DevExpress.XtraGrid.GridControl CollectGrid
        {
            set { m_CollectSymbolGrid = value; }
        }

        public DevExpress.XtraGrid.GridControl UserAllGrid
        {
            set { m_UserAllGrid = value; }
        }

        public DevExpress.XtraGrid.GridControl UserWordGrid
        {
            set { m_UserWordGrid = value; }
        }

        #endregion


        #region Public Methods

        public bool Run()
        {
            if (m_bRun)
                return true;

            if (CProjectManager.Project == null)
                return false;

            CProjectManager.Project.Editable = false;

            bool bOK = true;
            bFirstEvent = true;
            bOK = m_cWriter.Connect();
            if (bOK == false)
            {
                return false;
            }

            if (m_cMonitor == null)
                m_cMonitor = new CMonitor();

            if (m_ucMonitorGroupState != null)
            {
                m_ucMonitorGroupState.Clear();
                m_ucMonitorGroupState.GroupS = CProjectManager.Project.GroupS;
                m_ucMonitorGroupState.MonitorViewer = m_cMonitor.Viewer;
                m_ucMonitorGroupState.Run();
            }

            if (m_ucSummaryView != null)
            {
                m_ucSummaryView.MonitorViewer = m_cMonitor.Viewer;
                m_ucSummaryView.Run();
            }

            if (m_ucMonitorStatusView != null)
            {
                m_ucMonitorStatusView.Run();
			}

			// 20150729 MH Kim
			if (m_ucGroupCycleView != null)
			{
				m_ucGroupCycleView.Clear();
                m_ucGroupCycleView.GroupS = CProjectManager.Project.GroupS;
                m_ucGroupCycleView.MonitorViewer = m_cMonitor.Viewer;

				m_ucGroupCycleView.Run();
			}

            m_cMonitor.TagS = GetMonitorTagS(CProjectManager.Project, m_emMonitorType);
            m_cMonitor.GroupS = CProjectManager.Project.GroupS;

            if (CProjectManager.Project.OPCConfig.Use)
            {
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.OPC;
                m_cMonitor.Source.OPCConfig = CProjectManager.Project.OPCConfig;
            }
            else if (CProjectManager.Project.LsConfig.Use)
            {
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.LS;
                m_cMonitor.Source.LsConfig = CProjectManager.Project.LsConfig;
            }
            else
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.DDEA;

            m_cMonitor.Viewer.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorViewer_UEventValueChanged);
            m_cMonitor.Viewer.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(MonitorViewer_UEventGroupStateChanged);

            m_cMonitor.Logger.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
            m_cMonitor.Logger.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(MonitorLogger_UEventGroupStateChanged);

            m_cMonitor.MonitorType = m_emMonitorType;
            CTagS cTagS = m_cMonitor.TagS;
            m_lstCollectTag.Clear();
            foreach (var who in cTagS)
            {
                CCollectTag cCollTag = new CCollectTag();
                cCollTag.Address = who.Value.Address;
                cCollTag.DataType = who.Value.DataType;
                cCollTag.Key = who.Key;
                cCollTag.Description = who.Value.Description;

                m_lstCollectTag.Add(cCollTag);
            }
            m_CollectSymbolGrid.DataSource = m_lstCollectTag;
            m_CollectSymbolGrid.RefreshDataSource();
            bOK = m_cMonitor.Run();

            m_bRun = bOK;

            if (bOK == false)
            {
                Stop();
                return false;
            }
            
            return bOK;
        }

        public void Stop()
        {
            m_bRun = false;

            if (m_cMonitor != null)
            {
                m_cMonitor.Stop();

                m_cMonitor.Viewer.UEventValueChanged -= new UEventHandlerMonitorValueChanged(MonitorViewer_UEventValueChanged);
                m_cMonitor.Viewer.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(MonitorViewer_UEventGroupStateChanged);

                m_cMonitor.Logger.UEventValueChanged -= new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
                m_cMonitor.Logger.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(MonitorLogger_UEventGroupStateChanged);

                m_cMonitor.Dispose();
                m_cMonitor = null;
            }

            m_cWriter.Disconnect();

            if (m_ucMonitorGroupState != null)
                m_ucMonitorGroupState.Stop();

            if (m_ucSummaryView != null)
                m_ucSummaryView.Stop();

            if (m_ucMonitorStatusView != null)
                m_ucMonitorStatusView.Stop();

			// 20150729 MH Kim
			if (m_ucGroupCycleView != null)
				m_ucGroupCycleView.Stop();

            CProjectManager.Project.Editable = true;
        }

        #endregion


        #region Private Methods

        private void SetInterlockEvent(CTimeLog cLog)
        {
            Dictionary<string, CSymbolS> dicGroupError = new Dictionary<string, CSymbolS>();
            foreach (var who in CProjectManager.Project.GroupErrorSymbolS)
            {
                CSymbolS cSymbolS = who.Value;
                if (cSymbolS.ContainsKey(cLog.Key))
                {
                    CSymbol cSymbol = cSymbolS[cLog.Key];
                    if (cSymbol.Value == cLog.Value) continue;

                    cSymbol.Value = cLog.Value;
                    if (bFirstEvent == false)
                    {
                        if (cLog.Value == 1)
                        {
                            if (dicGroupError.ContainsKey(who.Key) == false)
                                dicGroupError.Add(who.Key, new CSymbolS());

                            cSymbol.ChangeCount++;
                            dicGroupError[who.Key].Add(cSymbol);
                        }
                        //이벤트 발생
                    }
                }
            }
            if (UEventInterlckSymbolS != null)
                UEventInterlckSymbolS(dicGroupError);
        }

        private CTagS GetMonitorTagS(CTProject cProject, EMMonitorType emMonitorType)
        {
            CTagS cTotalTagS = new CTagS();

            CGroup cGroup;
            for (int i = 0; i < cProject.GroupS.Count; i++)
            {
                cGroup = cProject.GroupS[i];

                if (cGroup.Product != null && cGroup.Product.Address != "")
                    cTotalTagS.Add(cGroup.Product.Tag);

                if (cGroup.Recipe != null && cGroup.Recipe.Address != "")
                    cTotalTagS.Add(cGroup.Recipe.Tag);

				if(emMonitorType == EMMonitorType.PatternItem)
				{
					CTagS cTagS = cGroup.KeySymbolS.GetTagS();
					cTotalTagS.AddRange(cTagS);
					cTagS.Clear();
				}
				else if(emMonitorType == EMMonitorType.MasterPattern)
				{
					CTagS cTagS = cGroup.KeySymbolS.GetTotalTagS();
					cTotalTagS.AddRange(cTagS);
					cTagS.Clear();
				}
				else
				{
					CTagS cTagS = cGroup.GetTotalTagS();
					cTotalTagS.AddRange(cTagS);
					cTagS.Clear();
				}
            }

            //Interlock Tag 추가
            foreach (var who in cProject.GroupErrorSymbolS)
            {
                List<CTag> lstTag = who.Value.Select(b => b.Value.Tag).ToList();
                for (int i = 0; i < lstTag.Count; i++)
                {
                    if (cTotalTagS.ContainsKey(lstTag[i].Key) == false)
                        cTotalTagS.Add(lstTag[i]);
                }
            }

            //User Device 추가
            foreach (var who in cProject.UserDevice)
            {
                if (cTotalTagS.ContainsKey(who.Key) == false)
                    cTotalTagS.Add(who.Value.Tag);
            }

            return cTotalTagS;
        }

        private CMonitorErrorInfo CreateErrorInfo(CGroupLog cLog)
        {
            CMonitorErrorInfo cInfo = null;

            CGroup cGroup = CProjectManager.Project.GroupS[cLog.Key];
            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(cLog.Key, cGroup.KeySymbolS, cLog.CycleStart, cLog.CycleEnd, cLog.TimeLogS, false);
            if (cItemS == null || cItemS.Count == 0)
                return null;

            CFlowCompareResultS cResultS = CProjectManager.Project.MasterPatternS.Compare(cGroup.Key, cLog.Recipe, cItemS, false);
            if (cResultS == null || cResultS.Count == 0)
                return null;

            CFlowCompareResult cResult;
            CFlowCompareResultUnit cResultUnit;
            CFlowCompareResultUnit cCriticalResult = null;
            for (int i = 0; i < cResultS.Count; i++)
            {
                cResult = cResultS[i];
                for (int j = 0; j < cResult.Count; j++)
                {
                    cResultUnit = cResult[j];
                    if (cCriticalResult == null)
                    {
                        cCriticalResult = cResultUnit;
                    }
                    else
                    {
                        if (cCriticalResult.DifferenceType == EMDifferenceType.Missing)
                        {
                            if (cResultUnit.DifferenceType == EMDifferenceType.Missing)
                            {
                                if (cCriticalResult.TimeNode.Start > cResultUnit.TimeNode.Start)
                                    cCriticalResult = cResultUnit;
                            }
                        }
                        else
                        {
                            if (cResultUnit.DifferenceType == EMDifferenceType.Missing)
                            {
                                cCriticalResult = cResultUnit;
                            }
                            else
                            {
                                if (cCriticalResult.TimeNode.Start > cResultUnit.TimeNode.Start)
                                    cCriticalResult = cResultUnit;
                            }
                        }
                    }
                }
            }

            if (cCriticalResult.TimeNode != null)
            {
                cInfo = new CMonitorErrorInfo(cLog.Key, EMMonitorGroupErrorType.CycleTime);
                cInfo.Symbol = cGroup.KeySymbolS[cCriticalResult.TimeNode.Key];
            }

            return cInfo;
        }

        private void GenerateCycleStartEvent(string sGroupKey)
        {
            if(UEventCycleStarted != null)
                UEventCycleStarted(sGroupKey);
        }

        private void GenerateCycleEndEvent(string sGroupKey)
        {
            if (UEventCycleEnded != null)
                UEventCycleEnded(sGroupKey);
        }

        private void GenerateErrorDetectedEvent(CGroupLog cGroupLog, CMonitorErrorInfo cErrorInfo)
        {
            if(UEventErrorDetected != null)
            {
                CGroupLog cLogClone = (CGroupLog)cGroupLog.Clone();
                CMonitorErrorInfo cInfoClone = (CMonitorErrorInfo)cErrorInfo.Clone();

                if (cErrorInfo.ErrorType != EMMonitorGroupErrorType.Abnormal)
                {
                    UEventErrorDetected(cLogClone, cInfoClone);
                }
                else
                {
                    if(UEventAbnormalDetected != null)
                        UEventAbnormalDetected(cLogClone, cInfoClone);
                }
            }
        }

        #endregion
        

        #region Event Methods

        private void MonitorLogger_UEventGroupStateChanged(object sender, CGroupLog cLog)
        {
            if (m_cWriter != null && m_cWriter.IsConnected)
            {
                if (cLog.StateType == EMGroupStateType.End || cLog.StateType == EMGroupStateType.ErrorEnd || cLog.StateType == EMGroupStateType.Error)
                    m_cWriter.WriteGroupLog(cLog);
            }

            if (cLog.TimeLogS != null)
                cLog.TimeLogS.Clear();

            cLog = null;
        }

        private void MonitorLogger_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            if (m_cWriter != null && m_cWriter.IsConnected)
            {
                m_cWriter.WriteTimeLogS(cLogS);
            }

            cLogS.Clear();
            cLogS = null;
        }

        private void MonitorViewer_UEventGroupStateChanged(object sender, CGroupLog cLog)
        {
			if(cLog.StateType == EMGroupStateType.Start)
            {
                GenerateCycleStartEvent(cLog.Key);
            }
            else if (cLog.StateType == EMGroupStateType.End)
            {
                GenerateCycleEndEvent(cLog.Key);
            }
            else if(cLog.StateType == EMGroupStateType.Error)
            {
                CMonitorErrorInfo cInfo = null;
                if(cLog.Data == null)
                    cInfo = CreateErrorInfo(cLog);
                else
                    cInfo = (CMonitorErrorInfo)cLog.Data;

                GenerateErrorDetectedEvent(cLog, cInfo);
            }
            if (cLog.TimeLogS != null)
                cLog.TimeLogS.Clear();

            cLog = null;
        }        

        private void MonitorViewer_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            bool bChange = false;
            foreach (CTimeLog log in cLogS)
            {
                CCollectTag cTag = m_lstCollectTag.Find(b => b.Key == log.Key);
                if (cTag != null)
                {
                    cTag.CurrentValue = log.Value;
                    cTag.ChangeCount++;
                }
                if (CProjectManager.Project.UserDevice.ContainsKey(log.Key))
                {
                    CProjectManager.Project.UserDevice[log.Key].Value = log.Value;
                    CProjectManager.Project.UserDevice[log.Key].LastTime = log.Time;
                    CProjectManager.Project.UserDevice[log.Key].ChangeCount++;
                    bChange = true;
                }
                SetInterlockEvent(log);
            }

            if (bFirstEvent)
                bFirstEvent = false;

            m_CollectSymbolGrid.RefreshDataSource();
            if (bChange)
            {
                m_UserAllGrid.RefreshDataSource();
                m_UserWordGrid.RefreshDataSource();
            }
            cLogS.Clear();
            cLogS = null;
        }

        #endregion
    }
}
