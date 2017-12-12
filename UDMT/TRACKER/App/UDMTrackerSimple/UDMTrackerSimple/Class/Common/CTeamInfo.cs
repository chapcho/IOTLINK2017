using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CTeamInfo
    {
        private string m_sTeamName = string.Empty;
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private string m_sTagKey = string.Empty;
        private int m_iTargetCount = 0;
        private double m_dUPH = 0;
        private int m_iCurrentCount = 0;
        private DateTime m_dtEndTime = DateTime.MinValue;
        private float m_fRatio = 0;
        private string m_sDuration = string.Empty;

        private List<string> m_lstRecipeWordKeyS = new List<string>();
        private string m_sSelectedRecipeKey = string.Empty;

        #region Properties

        public string TeamName
        {
            get { return m_sTeamName; }
            set { m_sTeamName = value; }
        }

        public DateTime From
        {
            get { return m_dtFrom; }
            set { m_dtFrom = value; }
        }

        public DateTime To
        {
            get { return m_dtTo;}
            set { m_dtTo = value; }
        }

        public string TagKey
        {
            get { return m_sTagKey; }
            set { m_sTagKey = value; }
        }

        public int TargetCount
        {
            get { return m_iTargetCount;}
            set { m_iTargetCount = value; }
        }

        public double UPH
        {
            get { return m_dUPH;}
            set { m_dUPH = value; SetEndTime(); }
        }

        public int CurrentCount
        {
            get { return m_iCurrentCount; }
            set { m_iCurrentCount = value; SetRatio();}
        }

        public string EndTime
        {
            get { return m_dtEndTime.ToString(" hh : mm : ss"); }
            //set { m_dtEndTime = value; }
        }

        public float Ratio
        {
            get { return m_fRatio; }
        }

        public string Duration
        {
            get { return GetDuration(); }
        }

        public string CurrentRecipe { get; set; }

        public List<string> RecipeWordKeyS
        {
            get { return m_lstRecipeWordKeyS; }
            set { m_lstRecipeWordKeyS = value; }
        }

        public string SelectedRecipeKey
        {
            get { return m_sSelectedRecipeKey;}
            set { m_sSelectedRecipeKey = value; }
        }

        #endregion

        #region Private Methods

        public void Clear()
        {
            m_dUPH = 0;
            m_iCurrentCount = 0;
            m_dtEndTime = DateTime.Now;
            m_fRatio = 0;
        }

        private void SetRatio()
        {
            if (m_iTargetCount != 0)
            {
                m_fRatio = Convert.ToSingle((Convert.ToDouble(m_iCurrentCount) * 100) / m_iTargetCount);
            }
        }

        private void SetEndTime()
        {
            if (m_dUPH == 0 || m_iTargetCount == 0)
                return;

            int iRemainProductionCount = m_iTargetCount - m_iCurrentCount;
            double dProductionTimePerUnit = 60/m_dUPH;

            double dRemainTime = dProductionTimePerUnit*iRemainProductionCount;

            m_dtEndTime = DateTime.Now.AddMinutes(dRemainTime);
        }

        private string GetDuration()
        {
            string sDuration = string.Empty;

            //if (m_dtFrom == DateTime.MinValue || m_dtTo == DateTime.MinValue)
            //    return sDuration;

            sDuration = string.Format("{0}시{1}분 ~\r\n {2}시{3}분", m_dtFrom.Hour, m_dtFrom.Minute, m_dtTo.Hour, m_dtTo.Minute);

            return sDuration;
        }

        #endregion

    }
}

