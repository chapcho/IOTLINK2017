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

namespace UDMTracker
{
    public class CTracker : IDisposable
    {

        #region Member Variables

        private bool m_bRun = false;
        private CMonitor m_cMonitor = new CMonitor();
        private CMySqlLogWriter m_cWriter = new CMySqlLogWriter();
        private UCProjectManager m_ucProjectManager = null;
        private UCGroupStateTable m_ucMonitorGroupState = null;
        private UCMonitorStatus m_ucMonitorStatusView = null;
		private UCGroupCycleBoardS m_ucGroupCycleView = null;
        private EMMonitorType m_emMonitorType = EMMonitorType.Detection;
        private DevExpress.XtraGrid.GridControl m_Grid = null;
        private List<CCollectTag> m_lstCollectTag = new List<CCollectTag>();
        public event UEventHandlerTrackerCycleStarted UEventCycleStarted;
        public event UEventHandlerTrackerErrorDetected UEventErrorDetected;

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

        public UCProjectManager ProjectManager
        {
            get { return m_ucProjectManager; }
            set { m_ucProjectManager = value; }
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
            set { m_Grid = value; }
        }

        #endregion


        #region Public Methods

        public bool Run()
        {
            if (m_bRun)
                return true;

            if (m_ucProjectManager.Project == null)
                return false;

            m_ucProjectManager.Project.Editable = false;

            bool bOK = true;           

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
                m_ucMonitorGroupState.GroupS = m_ucProjectManager.Project.GroupS;
                m_ucMonitorGroupState.MonitorViewer = m_cMonitor.Viewer;
                m_ucMonitorGroupState.Run();
            }

            if (m_ucMonitorStatusView != null)
            {
                m_ucMonitorStatusView.Run();
			}

			// 20150729 MH Kim
			if (m_ucGroupCycleView != null)
			{
				m_ucGroupCycleView.Clear();
				m_ucGroupCycleView.GroupS = m_ucProjectManager.Project.GroupS;
                m_ucGroupCycleView.MonitorViewer = m_cMonitor.Viewer;

				m_ucGroupCycleView.Run();
			}

            m_cMonitor.TagS = GetMonitorTagS(m_ucProjectManager.Project, m_emMonitorType);
            m_cMonitor.GroupS = m_ucProjectManager.Project.GroupS;

            if (m_ucProjectManager.Project.OPCConfig.Use)
            {
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.OPC;
                m_cMonitor.Source.OPCConfig = m_ucProjectManager.Project.OPCConfig;
            }
            else if (m_ucProjectManager.Project.LsConfig.Use)
            {
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.LS;
                m_cMonitor.Source.LsConfig = m_ucProjectManager.Project.LsConfig;
            }
            else
                m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.DDEA;

            m_cMonitor.Viewer.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorViewer_UEventValueChanged);
            m_cMonitor.Viewer.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(MonitorViewer_UEventGroupStateChanged);

            m_cMonitor.Logger.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
            m_cMonitor.Logger.UEventValueChanged += new UEventHandlerMonitorValueChanged(PatternMonitor_UEventValueChanged);
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
            m_Grid.DataSource = m_lstCollectTag;
            m_Grid.RefreshDataSource();
            bOK = m_cMonitor.Run();

            m_bRun = bOK;

            if (bOK == false)
            {
                Stop();
                return false;
            }
            
            return bOK;
        }

        public bool Simulate(CTimeLogS cLogS)
        {
            if (m_bRun)
                return true;

            if (m_ucProjectManager.Project == null)
                return false;

            m_ucProjectManager.Project.Editable = false;

            bool bOK = true;

            bOK = m_cWriter.Connect();
            if (bOK == false)
                return false;

            if (m_cMonitor == null)
                m_cMonitor = new CMonitor();


            m_bRun = true;

            if (m_ucMonitorGroupState != null)
            {
                m_ucMonitorGroupState.Clear();
                m_ucMonitorGroupState.GroupS = m_ucProjectManager.Project.GroupS;
                m_ucMonitorGroupState.MonitorViewer = m_cMonitor.Viewer;
                m_ucMonitorGroupState.Run();
            }

			// 20150729 MH Kim
			if (m_ucGroupCycleView != null)
			{
				m_ucGroupCycleView.Clear();
				m_ucGroupCycleView.GroupS = m_ucProjectManager.Project.GroupS;
                m_ucGroupCycleView.MonitorViewer = m_cMonitor.Viewer;
				m_ucGroupCycleView.Run();
			}

            if (m_ucMonitorStatusView != null)
            {
                m_ucMonitorStatusView.Run();
            }

            m_cMonitor.MonitorType = m_emMonitorType;
            m_cMonitor.TagS = GetMonitorTagS(m_ucProjectManager.Project, m_emMonitorType);
            m_cMonitor.GroupS = m_ucProjectManager.Project.GroupS;
            m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.Simulator;
            m_cMonitor.Source.SimulatorConfig.LogS = cLogS;

            m_cMonitor.Viewer.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorViewer_UEventValueChanged);
            m_cMonitor.Viewer.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(MonitorViewer_UEventGroupStateChanged);

            m_cMonitor.Logger.UEventValueChanged += new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
            m_cMonitor.Logger.UEventValueChanged += new UEventHandlerMonitorValueChanged(PatternMonitor_UEventValueChanged);
            m_cMonitor.Logger.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(MonitorLogger_UEventGroupStateChanged);

            bOK = m_cMonitor.Run();

            if (bOK == false)
            {
                m_cMonitor.Stop();

                m_cMonitor.Viewer.UEventValueChanged -= new UEventHandlerMonitorValueChanged(MonitorViewer_UEventValueChanged);
                m_cMonitor.Viewer.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(MonitorViewer_UEventGroupStateChanged);

                m_cMonitor.Logger.UEventValueChanged -= new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
                m_cMonitor.Logger.UEventValueChanged -= new UEventHandlerMonitorValueChanged(PatternMonitor_UEventValueChanged);
                m_cMonitor.Logger.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(MonitorLogger_UEventGroupStateChanged);

                m_cWriter.Disconnect();

                if (m_ucMonitorGroupState != null)
                    m_ucMonitorGroupState.Stop();

                if (m_ucMonitorStatusView != null)
                    m_ucMonitorStatusView.Stop();

				// 20150729 MH Kim
				if (m_ucGroupCycleView != null)
					m_ucGroupCycleView.Stop();
            }

            return bOK;
        }

        public bool OPCTest()
        {
            bool bOK = true;

            if (m_cMonitor == null)
                m_cMonitor = new CMonitor();

            m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.OPC;

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
                m_cMonitor.Logger.UEventValueChanged -= new UEventHandlerMonitorValueChanged(PatternMonitor_UEventValueChanged);
                m_cMonitor.Logger.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(MonitorLogger_UEventGroupStateChanged);

                m_cMonitor.Dispose();
                m_cMonitor = null;
            }

            m_cWriter.Disconnect();

            if (m_ucMonitorGroupState != null)
                m_ucMonitorGroupState.Stop();

            if (m_ucMonitorStatusView != null)
                m_ucMonitorStatusView.Stop();

			// 20150729 MH Kim
			if (m_ucGroupCycleView != null)
				m_ucGroupCycleView.Stop();

            m_ucProjectManager.Project.Editable = true;
        }

        #endregion


        #region Private Methods

        private CTagS GetMonitorTagS(CProject cProject, EMMonitorType emMonitorType)
        {
            CTagS cTotalTagS = new CTagS();

            CGroup cGroup;
            bool bOK = false;
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

            return cTotalTagS;
        }

        private CMonitorErrorInfo CreateErrorInfo(CGroupLog cLog)
        {
            CMonitorErrorInfo cInfo = null;

            CGroup cGroup = m_ucProjectManager.Project.GroupS[cLog.Key];
            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(cLog.Key, cGroup.KeySymbolS, cLog.CycleStart, cLog.CycleEnd, cLog.TimeLogS, false);
            if (cItemS == null || cItemS.Count == 0)
                return null;

            CFlowCompareResultS cResultS = m_ucProjectManager.Project.MasterPatternS.Compare(cGroup.Key, cLog.Recipe, cItemS, false);
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

        private void GenerateErrorDetectedEvent(CGroupLog cGroupLog, CMonitorErrorInfo cErrorInfo)
        {
            if(UEventErrorDetected != null)
            {
                CGroupLog cLogClone = (CGroupLog)cGroupLog.Clone();
                CMonitorErrorInfo cInfoClone = (CMonitorErrorInfo)cErrorInfo.Clone();

                UEventErrorDetected(cLogClone, cInfoClone);
            }
        }

        #endregion
        

        #region Event Methods

        private void MonitorLogger_UEventGroupStateChanged(object sender, CGroupLog cLog)
        {
            if (m_cWriter != null && m_cWriter.IsConnected)
            {
                if (cLog.StateType == EMGroupStateType.End || cLog.StateType == EMGroupStateType.ErrorEnd)
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

            // cLogS.Clear();
            // cLogS = null;
        }

        private void MonitorViewer_UEventGroupStateChanged(object sender, CGroupLog cLog)
        {
			if(cLog.StateType == EMGroupStateType.Start)
            {
                GenerateCycleStartEvent(cLog.Key);
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
            foreach (CTimeLog log in cLogS)
            {
                CCollectTag cTag = m_lstCollectTag.Find(b => b.Key == log.Key);
                if (cTag != null)
                {
                    cTag.CurrentValue = log.Value;
                    cTag.ChangeCount++;
                }
            }
            m_Grid.RefreshDataSource();
            cLogS.Clear();
            cLogS = null;
        }

        /// <summary>
        /// 디바이스 주소를 인자로 디바이스가 할당된 그룹을 조회합니다.
        /// 한 디바이스는 하나의 그룹에만 할당되어야 합니다.
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="groupKey"></param>
        /// <returns></returns>
        private bool FindGroupKeyWithAddress(string sKey, out string groupKey)
        {
            CTag tag;
            groupKey = string.Empty;

            foreach(CGroup srcGroup in m_ucProjectManager.Project.GroupS.Values)
            {
                if(srcGroup.GetTotalTagS().TryGetValue(sKey, out tag))
                {
                    groupKey = srcGroup.Key;
                    break;
                }
            }

            return string.IsNullOrEmpty(groupKey) ? false : true;
        }

        /// <summary>
        /// Abnormal Device의 값을 모니터링 합니다.
        /// </summary>
        /// <param name="timeLog"></param>
        private void AbnormalDeviceTracker(CTimeLog timeLog)
        {
            string groupKey = string.Empty;

            if (FindGroupKeyWithAddress(timeLog.Key, out groupKey))
            {
                CSymbol targetSymbol = new CSymbol();
                if (m_ucProjectManager.Project.GroupS[groupKey].AbnormalSymbolS.TryGetValue(timeLog.Key, out targetSymbol))
                {
                    Console.WriteLine("Find Abnormal Device group = [{0}], key = [{1}], value = [{2}]", groupKey, timeLog.Key, timeLog.Value);
                    return;
                }
            }
        }

        /// <summary>
        ///  Trend 디바이스의 값을 모니터링 합니다.
        /// </summary>
        /// <param name="timeLog"></param>
        private void TrendDeviceTracker(CTimeLog timeLog)
        {
            string groupKey = string.Empty;

            if (FindGroupKeyWithAddress(timeLog.Key, out groupKey))
            {
                CSymbol targetSymbol = new CSymbol();
                if (m_ucProjectManager.Project.GroupS[groupKey].TrendSymbolS.TryGetValue(timeLog.Key, out targetSymbol))
                {
                    if (timeLog.Value > targetSymbol.UpperBound || timeLog.Value < targetSymbol.LowerBound)
                    {
                        Console.WriteLine("Find Trend Device Out Of Range group = [{0}], key = {1}, value = [{2}]", groupKey, timeLog.Key, timeLog.Value);
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// ijsong@udmtek
        /// 로그 수신시에 패턴 일치율 계산.
        /// 특정 접점은 하나의 공정에 속한다. ==> 접점의 주소만으로도 공정을 검색할 수 있어야 한다.
        /// 사이클 시작과 종료는 현재 수신된 접점의 상태로 파악되어야 한다. ==> 사이클 조건을 포함해야 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cLogS"></param>
        private void PatternMonitor_UEventValueChanged(object sender, CTimeLogS cLogS)
        {

            foreach (CTimeLog log in cLogS)
            {
                // Console.WriteLine("key = {0}, value = {1} , time= {2}", log.Key, log.Value, log.Time.ToString("yyyy/MM/dd hh:mm:ss.fff"));

                // 패턴에 대한 정보가 있다.
                // 디바이스의 On/Off를 검토하여 사이클 시작과 종료를 파악한다.
                // 해당 디바이스가 속한 공정을 선택하여 모니터링 한다.
                // 
                // 현재 사이클의 값을 넣으면, 계산되어 모니터링 되어야 한다.
                // 사이클이 완료되면, 패턴 일치율을 계산하여, 저장 처리 한다. 
                TrendDeviceTracker(log);
                AbnormalDeviceTracker(log);

            }

            if (cLogS != null)
                cLogS.Clear();

            cLogS = null;
        }

        #endregion
    }
}
