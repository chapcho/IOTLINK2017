using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CRelation:IDisposable,ICloneable
    {
        #region Member Variables

        protected List<int> m_lstNextUnit = null;
        protected List<int> m_lstPrevUnit = null;

        #endregion

        #region Initialize/Dispose

        public CRelation()
        {
            m_lstNextUnit = new List<int>();
            m_lstPrevUnit = new List<int>();
        }

        public void Dispose()
        {
            m_lstPrevUnit.Clear();
            m_lstNextUnit.Clear();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Next UnitS
        /// 우측 위치의 Unit index
        /// </summary>
        public List<int> NextUnit
        {
            get { return m_lstNextUnit; }
            set { m_lstNextUnit = value; }
        }

        /// <summary>
        /// Prev unit
        /// 좌측 위치의 Unit Index
        /// </summary>
        public List<int> PrevUnit
        {
            get { return m_lstPrevUnit; }
            set { m_lstPrevUnit = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CRelation cTemp = new CRelation();

            foreach (int iTemp in m_lstNextUnit)
            {
                cTemp.NextUnit.Add(iTemp);
            }

            foreach(int iTemp in m_lstPrevUnit)
            {
                cTemp.PrevUnit.Add(iTemp);
            }

            return cTemp;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
