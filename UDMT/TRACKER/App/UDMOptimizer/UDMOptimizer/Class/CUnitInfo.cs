using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMOptimizer
{
    [Serializable]
    public class CUnitInfo
    {
        #region Member Veriables

        protected string m_sName = "";
        protected List<string> m_lstInputTagKey = new List<string>();
        protected List<string> m_lstOutputTagKey = new List<string>();
        protected List<string> m_lstCoilTagKey = new List<string>();
        protected List<string> m_lstTotalTagKey = new List<string>();
        [NonSerialized]
        protected string m_sFilterName = "";
        [NonSerialized]
        protected CTagS m_cTotalTagS = new CTagS();
        [NonSerialized]
        protected string m_sProcessKey = "";

        #endregion


        #region Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }
        
        public CTagS TotalTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        public List<string> CoilTagKeyList
        {
            get { return m_lstCoilTagKey; }
        }

        public List<string> InputTagKeyList
        {
            get { return m_lstInputTagKey; }
        }

        public List<string> OutputTagKeyList
        {
            get { return m_lstOutputTagKey; }
        }

        public List<string> TotalTagKeyList
        {
            get { return m_lstTotalTagKey; }
            set { m_lstTotalTagKey = value; }
        }

        public string FilterName
        {
            get { return m_sFilterName; }
            set { m_sFilterName = value; }
        }

        public string ProcessKey
        {
            get { return m_sProcessKey; }
            set { m_sProcessKey = value; }
        }

        #endregion


        #region Public Method

        public void AddUnitTagS(List<CTag> lstTag)
        {
            if (lstTag == null || lstTag.Count == 0)
                return;
            for (int i = 0; i < lstTag.Count; i++)
            {
                if (m_cTotalTagS.ContainsKey(lstTag[i].Key) == false)
                {
                    m_cTotalTagS.Add(lstTag[i].Key, lstTag[i]);
                }
            }
            //if (lstTag.First().PLCMaker == EMPLCMaker.Siemens)
            //{
            //    m_lstInputTagKey.AddRange(m_cTotalTagS.Values.Where(b => b.DataType == EMDataType.Bool && b.IsCollectUsed && b.Address.Contains("I")).Select(a => a.Key).ToList());
            //    m_lstOutputTagKey.AddRange(m_cTotalTagS.Values.Where(b => b.DataType == EMDataType.Bool && b.IsCollectUsed && b.Address.Contains("Q")).Select(a => a.Key).ToList());
            //    m_lstInputTagKey.AddRange(m_cTotalTagS.Values.Where(b => b.DataType == EMDataType.Bool && b.IsCollectUsed && b.Address.Contains("I")).Select(a => a.Key).ToList());
            //}
        }

        public void AddUnitCoilTagS(List<CTag> lstTag)
        {
            if (lstTag == null || lstTag.Count == 0)
                return;
            for (int i = 0; i < lstTag.Count; i++)
            {
                if (m_cTotalTagS.ContainsKey(lstTag[i].Key) == false)
                {
                    m_cTotalTagS.Add(lstTag[i].Key, lstTag[i]);
                    m_lstCoilTagKey.Add(lstTag[i].Key);
                }
            }
        }

        #endregion
    }
}
