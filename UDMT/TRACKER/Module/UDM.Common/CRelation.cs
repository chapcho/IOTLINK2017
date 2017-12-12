using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CRelation : IDisposable
    {

        #region Member Variables

        protected List<int> m_lstNextContact = new List<int>();
        protected List<int> m_lstNextCoil = new List<int>();
        protected List<int> m_lstPrevContact = new List<int>();
        protected List<int> m_lstPrevCoil = new List<int>();

        #endregion


        #region Initialize/Dispose

        public CRelation()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public List<int> NextContactS
        {
            get { return m_lstNextContact; }
            set { m_lstNextContact = value; }
        }

        public List<int> NextCoilS
        {
            get { return m_lstNextCoil; }
            set { m_lstNextCoil = value; }
        }

        public List<int> PrevContactS
        {
            get { return m_lstPrevContact; }
            set { m_lstPrevContact = value; }
        }

        public List<int> PrevCoilS
        {
            get { return m_lstPrevCoil; }
            set { m_lstPrevCoil = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
        }

        #endregion
    }
}
