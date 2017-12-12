using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.UDL
{
    public class CUDLTag : IEquatable<CUDLTag>, IComparable<CUDLTag>, ICloneable
    {

        protected string m_sName = string.Empty;
        protected string m_sAddress = string.Empty;
        protected string m_sDescription = string.Empty;
        protected string m_sAlias = string.Empty;
        protected string m_sProgram = string.Empty;
        protected string m_sNote = string.Empty;
        protected EMDataType m_emDataType =  EMDataType.Bool;
        protected EMPLCMaker m_emPLCMaker;

        protected int m_iLength = 0;
        protected int m_iArrayCount = 0;
        protected string m_sArrayStartPoint = string.Empty;
        protected string m_sArrayEndPoint = string.Empty;
        protected string m_sUDTType = string.Empty;
        protected string m_sTagValue = string.Empty;
        protected List<string> m_lstArrayValue = new List<string>();

        protected bool m_bLSFBInOutTagCheck = false;

        #region Intialize/Dispose

        //Melsec Constructor

        #endregion

        #region Public Properties

        public string Note
        {
            get { return m_sNote;}
            set { m_sNote = value; }
        }

        /// <summary>
        /// Name Siemens Symbol
        /// </summary>
        ///
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }
        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }
        /// <summary>
        /// Description or Comment
        /// </summary>
        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }
        /// <summary>
        /// Datatype
        /// </summary>
        public EMDataType Datatype
        {
            get { return m_emDataType; }
            set { m_emDataType = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }
        public string Alias
        {
            get { return m_sAlias; }
            set { m_sAlias = value; }
        }
        /// <summary>
        /// Tag Length
        /// </summary>
        public int Length
        {
            get { return m_iLength; }
            set { m_iLength = value; }
        }
        /// <summary>
        /// Array element count
        /// </summary>
        public int ArrayCount
        {
            get { return m_iArrayCount; }
            set { m_iArrayCount = value; }
        }
        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }
        /// <summary>
        /// Array first element Index
        /// </summary>
        public string ArrayStartPoint
        {
            get { return m_sArrayStartPoint; }
            set { m_sArrayStartPoint = value; }
        }

        public string ArrayEndPoint
        {
            get { return m_sArrayEndPoint; }
            set { m_sArrayEndPoint = value; }
        }

        public string UDTType
        {
            get { return m_sUDTType; }
            set { m_sUDTType = value; }
        }
        public string TagValue
        {
            get { return m_sTagValue; }
            set { m_sTagValue = value; }
        }
        public List<string> ArrayValues
        {
            get { return m_lstArrayValue; }
            set { m_lstArrayValue = value; }
        }

        public bool LSFBInOutTagCheck
        {
            get { return m_bLSFBInOutTagCheck; }
            set { m_bLSFBInOutTagCheck = value; }
        }


        #endregion

        #region Public Methods

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            CUDLTag objAsTag = obj as CUDLTag;

            if (objAsTag == null)
                return false;
            else
                return Equals(objAsTag);
        }

        public int CompareTo(CUDLTag compareTag)
        {
            if (compareTag == null)
                return 1;
            else
                return this.Address.CompareTo(compareTag.Address);
        }

        public bool Equals(CUDLTag other)
        {
            if (other == null)
                return false;

            return (this.Address.Equals(other.Address));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetFullTag()
        {
            string tagInfor = string.Empty;
            try
            {
                tagInfor = "\"" + m_sName + "\";\"";
                tagInfor = tagInfor + m_sAddress + "\";\"";

                string sDatatype = string.Empty;

                if (m_emDataType != EMDataType.UserDefDataType)
                    sDatatype = m_emDataType.ToString();
                else
                    sDatatype = m_sUDTType;

                if (m_iArrayCount==0)
                {
                    tagInfor = tagInfor + sDatatype + "\";\"";
                }
                else
                {                    
                    sDatatype = sDatatype + "[" + m_sArrayStartPoint.ToString() + "..." + (m_sArrayStartPoint + m_iArrayCount).ToString() + "]";
                    tagInfor = tagInfor + sDatatype + "\";\"";
                }
                tagInfor = tagInfor + m_sDescription + "\";\"";

                if (m_iArrayCount == 0)
                {
                    tagInfor = tagInfor + m_sTagValue+ "\"";
                }
                else
                {
                    
                    for (int i = 0; i < m_iArrayCount; i++)
                    {
                        if (i == m_iArrayCount - 1)
                        {
                            tagInfor = tagInfor + m_lstArrayValue[i] + "\"";
                        }
                        else
                            tagInfor = tagInfor + m_lstArrayValue[i] + ",";
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tagInfor;
        }

        public string GetLocalTag()
        {
            string tagInfor = string.Empty;
            try
            {
                tagInfor = "\"" + m_sName + "\";\"";
                tagInfor = tagInfor + m_sAddress + "\";\"";

                string sDatatype = string.Empty;

                if (m_emDataType != EMDataType.UserDefDataType)
                    sDatatype = m_emDataType.ToString();
                else
                    sDatatype = m_sUDTType;

                if (m_iArrayCount == 0)
                {
                    tagInfor = tagInfor + sDatatype + "\";\"";
                }
                else
                {
                    sDatatype = sDatatype + "[" + m_sArrayStartPoint.ToString() + "..." + (m_sArrayStartPoint + m_iArrayCount).ToString() + "]";
                    tagInfor = tagInfor + sDatatype + "\";\"";
                }
                tagInfor = tagInfor + m_sDescription + "\"";

                if (m_iArrayCount == 0)
                {
                    tagInfor = tagInfor + m_sTagValue + "\"";
                }
                else
                {

                    for (int i = 0; i < m_iArrayCount; i++)
                    {
                        if (i == m_iArrayCount - 1)
                        {
                            tagInfor = tagInfor + m_lstArrayValue[i] + "\"";
                        }
                        else
                            tagInfor = tagInfor + m_lstArrayValue[i] + ",";
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tagInfor;
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
