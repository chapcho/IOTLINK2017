using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CFB_Info : ITagComposable
    {
        #region Member Variables

        protected bool m_bLastFB = false;

        protected int m_iRowContactCnt = 0;
        protected int m_iFB_Index = 0;
        protected string m_sFBNumber = "";
        protected string m_sFBDescription = "";

        protected List<string> m_lstIn_ItemName = new List<string>();
        protected List<string> m_lstInOut_ItemName = new List<string>();
        protected List<string> m_lstOut_ItemName = new List<string>();
        protected Dictionary<string, string> m_dicItem = new Dictionary<string, string>();

        protected CRelation m_cRelation = new CRelation();
        protected CContactS m_cContactS = new CContactS();
        protected CCoilS m_cCoilS = new CCoilS();
        protected CCoil m_cMainCoil = new CCoil();
        #endregion


        #region Properties
        public int FB_Index
        {
            get { return m_iFB_Index; }
            set { m_iFB_Index = value; }
        }

        public int RowOccupied
        {
            get { return m_iRowContactCnt; }
            set { m_iRowContactCnt = value; }
        }

        public string FBNumber
        {
            get { return m_sFBNumber; }
            set { m_sFBNumber = value; }
        }

        public string FBDescription
        {
            get { return m_sFBDescription; }
            set { m_sFBDescription = value; }
        }

        public List<string> In_ItemNameList
        {
            get { return m_lstIn_ItemName; }
            set { m_lstIn_ItemName = value; }
        }

        public List<string> InOut_ItemNameList
        {
            get { return m_lstInOut_ItemName; }
            set { m_lstInOut_ItemName = value; }
        }

        public List<string> Out_ItemNameList
        {
            get { return m_lstOut_ItemName; }
            set { m_lstOut_ItemName = value; }
        }

        public bool LastFB
        {
            get { return m_bLastFB; }
            set { m_bLastFB = value; }
        }

        public CRelation Relation
        {
            get { return m_cRelation; }
            set { m_cRelation = value; }
        }

        public CContactS ContactS
        {
            get { return m_cContactS; }
            set { m_cContactS = value; }
        }

        public CCoilS CoilS
        {
            get { return m_cCoilS; }
            set { m_cCoilS = value; }
        }
        public CCoil MainCoil
        {
            get { return m_cMainCoil; }
            set { m_cMainCoil = value; }
        }

        public Dictionary<string, string> DicItem
        {
            get { return m_dicItem; }
            set { m_dicItem = value; }
        }
        #endregion

        public void Compose(CTagS cTagS)
        {
        }

        public void Compose(CRefTagS cRefTagS)
        {
        }
    }
}
