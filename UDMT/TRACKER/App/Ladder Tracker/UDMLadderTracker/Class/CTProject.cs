using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UDM.Project;
using UDM.Log;
using UDM.Log.DB;
using UDM.Common;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CTProject : CProject
    {
        #region Member Variables

        protected Dictionary<string, CUserDevice> m_dicUserDevice = new Dictionary<string, CUserDevice>();
        protected Dictionary<string, CSymbolS> m_dicGroupErrorSymbol = new Dictionary<string, CSymbolS>();
        //protected List<int> m_lstErrorID = new List<int>();
        protected int m_iErrorCur = -1;
        protected int m_iCycleCur = -1;
        protected string m_sProjectID = "00000000";
        [NonSerialized]
        protected Dictionary<string, CCycleInfo> m_dicGroupCycleInfo = new Dictionary<string, CCycleInfo>();
        [NonSerialized]
        protected CErrorInfoS m_cErrorInfoS = null;

        #endregion

        #region Initialize

        #endregion


        #region Properties

        public Dictionary<string, CUserDevice> UserDevice
        {
            get { return m_dicUserDevice; }
            set { m_dicUserDevice = value; }
        }

        public Dictionary<string, CSymbolS> GroupErrorSymbolS
        {
            get { return m_dicGroupErrorSymbol; }
            set { m_dicGroupErrorSymbol = value; }
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set { m_cErrorInfoS = value; }
        }

        //public List<int> lstErrorID 
        //{
        //    get {  return m_lstErrorID;}
        //    set { m_lstErrorID = value; }
        //}

        public int ErrorIDCur
        {
            get { return m_iErrorCur;}
            set { m_iErrorCur = value; }
        }

        public int CycleIDCur
        {
            get { return m_iCycleCur; }
            set { m_iCycleCur = value; }
        }

        public string ProjectID
        {
            get { return m_sProjectID; }
            set { m_sProjectID = value; }
        }

        public Dictionary<string, CCycleInfo> GroupCycleInfo
        {
            get { return m_dicGroupCycleInfo; }
            set { m_dicGroupCycleInfo = value; }
        }

        #endregion


        #region Public Method

        public CSymbol GetSymbol(string sSymbolKey)
        {
            CSymbol cSymbol = null;

            if (this.m_cSymbolS.ContainsKey(sSymbolKey))
                cSymbol = this.m_cSymbolS[sSymbolKey];

            return cSymbol;
        }

        public List<CTag> GetTagList(CStep cStep)
        {
            List<CTag> lstTag = new List<CTag>();

            CTag cTag;
            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                if (cTag.DataType == EMDataType.Bool)
                    lstTag.Add(cTag);
            }

            return lstTag;
        }

        #endregion


        #region Private Method

        #endregion
    }
}
