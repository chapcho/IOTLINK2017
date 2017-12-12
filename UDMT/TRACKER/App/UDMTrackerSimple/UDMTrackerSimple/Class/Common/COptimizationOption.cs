using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMTrackerSimple
{
    [Serializable]
    public class COptimizationOption
    {
        private bool m_bEachProcess = true;
        private int m_nTargetCount = 20;
        private bool m_bRemoveSameTime = true;
        private bool m_bRemoveFixValue = true;
        private int m_nSignalFrequency = 10;
        private int m_nOptimizationFrequency = 2;
        [NonSerialized] private string m_sCurrentProcess = string.Empty;


        public string CurrentProcess
        {
            get { return m_sCurrentProcess; }
            set { m_sCurrentProcess = value; }
        }

        public int OptimizationFrequency 
        {
            get { return m_nOptimizationFrequency; }
            set { m_nOptimizationFrequency = value; }
        }

        public bool IsEachProcessMonitor
        {
            get { return m_bEachProcess; }
            set { m_bEachProcess = value; }
        }

        public int CycleTargetCount
        {
            get { return m_nTargetCount; }
            set { m_nTargetCount = value; }
        }

        public bool RemoveSameTimeSignal
        {
            get { return m_bRemoveSameTime; }
            set { m_bRemoveSameTime = value; }
        }

        public bool RemoveFixValue
        {
            get { return m_bRemoveFixValue; }
            set { m_bRemoveFixValue = value; }
        }

        public int RemoveSignalFrequency
        {
            get { return m_nSignalFrequency;}
            set { m_nSignalFrequency = value; }
        }



}
}
