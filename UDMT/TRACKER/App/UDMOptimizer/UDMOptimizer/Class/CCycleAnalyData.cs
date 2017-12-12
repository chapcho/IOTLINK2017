using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDMOptimizer
{
    public class CCycleAnalyData
    {
        #region Member Veriables

        private bool m_bLogEmpty = false;
        private bool m_bCycleOver = false;
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private string m_sProcessKey = "";
        private CTimeLogS m_cCycleLogS = new CTimeLogS();
        private List<string> m_lstEmptyLogKey = new List<string>();
        private TimeSpan m_tsDuration = TimeSpan.MinValue;
        private int m_iRecipeValue = 0;
        private string m_sRecipeKey = "";

        #endregion


        #region Properties

        public DateTime StartTime
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }
        
        public DateTime EndTime
        {
            get { return m_dtEnd; }
            set { m_dtEnd = value; }
        }

        public CTimeLogS CycleLogS
        {
            get { return m_cCycleLogS; }
            set { m_cCycleLogS = value; }
        }

        public List<string> EmptyLogKeyList
        {
            get { return m_lstEmptyLogKey; }
            set { m_lstEmptyLogKey = value; }
        }

        public bool IsLogEmpty
        {
            get { return m_bLogEmpty; }
            set { m_bLogEmpty = value; }
        }

        public bool IsCycleOver
        {
            get { return m_bCycleOver; }
            set { m_bCycleOver = value; }
        }

        public string ProcessKey
        {
            get { return m_sProcessKey; }
            set { m_sProcessKey = value; }
        }

        public TimeSpan Duration
        {
            get { return m_tsDuration; }
            set { m_tsDuration = value; }
        }

        public int RecipeValue
        {
            get { return m_iRecipeValue; }
            set { m_iRecipeValue = value; }
        }

        public string RecipeKey
        {
            get { return m_sRecipeKey; }
            set { m_sRecipeKey = value; }
        }

        #endregion


        #region Public Method

        #endregion
    }
}
