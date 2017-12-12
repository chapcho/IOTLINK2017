using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMPresenter
{
    [Serializable]
    public class CStepTagList
    {
        #region Member Variables

        protected string m_sStepKey = "";
        protected CTag m_cCoilTag = null;
        protected List<CTag> m_lstContactTag = new List<CTag>();
        protected string m_sProgram = "";
        protected int m_iNetworkNumber = -1;
        protected int m_iStepNumber = -1;
        protected bool m_bUsed = false;
        protected string m_sCommand = "";

        #endregion

        #region Properties

        public string StepKey
        {
            get { return m_sStepKey; }
            set { m_sStepKey = value; }
        }

        public CTag CoilTag
        {
            get { return m_cCoilTag; }
            set { m_cCoilTag = value; }
        }

        public List<CTag> ContactTagList
        {
            get { return m_lstContactTag; }
            set { m_lstContactTag = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public int NetworkNumber
        {
            get { return m_iNetworkNumber; }
            set { m_iNetworkNumber = value; }
        }

        public int StepNumber
        {
            get { return m_iStepNumber; }
            set { m_iStepNumber = value; }
        }

        public string CoilAddress
        {
            get { return m_cCoilTag.Address; }
        }

        public string CoilComment
        {
            get { return m_cCoilTag.Description; }
        }

        public EMDataType CoilDataType
        {
            get { return m_cCoilTag.DataType; }
        }

        public bool CoilCollectUsed
        {
            get { return m_bUsed; }
            set { m_bUsed = value; }
        }

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        #endregion
    }
}
