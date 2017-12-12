using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CRegressionUnit
    {
        private CTag m_cTag = null;
        private string m_sDisaggregation = string.Empty;
        private string m_sEnergyUnit = string.Empty;
        private int m_iMergeDepth = 1;
        private double m_dTimeSpan = 0.0;
        private int m_iRegressionDegree = 1;

        private double[] m_dThetaArray = null;
        private double m_dBaseEnergy = 0.0;

        private CTimeLogS m_cEnergyLogS = new CTimeLogS();

        #region Initialize/Dispose

        #endregion

        #region Properties

        public CTimeLogS EnergyLogS
        {
            get { return m_cEnergyLogS; }
            set { m_cEnergyLogS = value; }
        }

        public string Key
        {
            get { return m_cTag.Key; }
        }

        public string Address
        {
            get { return m_cTag.Address; }
        }

        public string Description
        {
            get { return m_cTag.Description; }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public string Disaggregation
        {
            get { return m_sDisaggregation; }
            set { m_sDisaggregation = value; }
        }

        public string EnergyUnit
        {
            get { return m_sEnergyUnit; }
            set { m_sEnergyUnit = value; }
        }

        public int MergeDepth
        {
            get { return m_iMergeDepth; }
            set { m_iMergeDepth = value; }
        }

        public double TimeSpan
        {
            get { return m_dTimeSpan; }
            set { m_dTimeSpan = value; }
        }

        public int Degree
        {
            get { return m_iRegressionDegree; }
            set { m_iRegressionDegree = value; }
        }

        public double[] Theta
        {
            get { return m_dThetaArray; }
            set { m_dThetaArray = value; }
        }

        public double BaseEnergy
        {
            get { return m_dBaseEnergy; }
            set { m_dBaseEnergy = value; }
        }

        #endregion


        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
