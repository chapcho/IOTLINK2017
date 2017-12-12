using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDMTracker
{
    internal class CCyclePresentUnit : IDisposable
    {

        #region Member Variables

        private string m_sRecipe = "";
        private int m_iActiveCount = 0;
        private int m_iFirstValue = -1;
        private int m_iLogCount = 0;

        #endregion


        #region Initialize/Dispose

        public CCyclePresentUnit(string sRecipe, int iActiveCount)
        {
            m_sRecipe = sRecipe;
            m_iActiveCount = iActiveCount;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Recipe
        {
            get { return m_sRecipe; }
            set { m_sRecipe = value; }
        }

        public int FirstValue
        {
            get { return m_iFirstValue; }
            set { m_iFirstValue = value; }
        }

        public int ActiveCount
        {
            get { return m_iActiveCount; }
            set { m_iActiveCount = value; }
        }

        public int LogCount
        {
            get { return m_iLogCount; }
            set { m_iLogCount = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
