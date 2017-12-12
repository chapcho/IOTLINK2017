using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CHMITag
    {
        private int m_iNumber = -1;
        private string m_sGroup = string.Empty;
        private string m_sName = string.Empty;
        private string m_sAddress = string.Empty;
        private string m_sDataType = string.Empty;
        private EMDataType m_emDataType = EMDataType.None;
        private string m_sDescription = string.Empty;

        private string m_sConvertName = string.Empty;
        private List<string> m_lstConvertNameParse = new List<string>();
        private string m_sGroupKey = string.Empty;
        private bool m_bHMIInput = false;
        private bool m_bHMIOutput = false;

        private int m_iIndex = -1;

        private string m_sPLCKey = string.Empty;
        private bool m_bMatch = false;
        private bool m_bInsert = false;
        private bool m_bConvert = false;
        private bool m_bEmpty = false;

        private bool m_bRedundancy = false;
        private bool m_bEdit = false;
        private bool m_bExistedMatch = false;

        #region Initialize/Dispose

        public CHMITag()
        {
            
        }

        public CHMITag(int iNumber, string sGroup, string sName, string sDataType, string sAddress, string sDescription)
        {
            m_iNumber = iNumber;
            m_sGroup = sGroup;
            m_sName = sName;
            m_sDataType = sDataType;
            m_emDataType = GetDataType(sDataType);
            m_sAddress = sAddress;
            m_sDescription = sDescription;
        }

        #endregion

        #region Properties

        public bool IsExistedMatch
        {
            get { return m_bExistedMatch;}
            set { m_bExistedMatch = value; }
        }

        public bool IsEdit
        {
            get { return m_bEdit; }
            set { m_bEdit = value; }
        }

        public int HMIIndex
        {
            get { return m_iIndex;}
            set { m_iIndex = value; }
        }

        public bool IsEmpty
        {
            get { return m_bEmpty; }
            set { m_bEmpty = value; }
        }
        public bool IsHMIInput
        {
            get { return m_bHMIInput;}
            set { m_bHMIInput = value; }
        }

        public bool IsHMIOutput
        {
            get { return m_bHMIOutput;}
            set { m_bHMIOutput = value; }
        }

        /// <summary>
        /// '_'로 Split했을 때 가장 앞에 나오는 Key ( ex : S173 )
        /// </summary>
        public string GroupKey
        {
            get { return m_sGroupKey;}
            set { m_sGroupKey = value; }
        }

        public List<string> ConvertNameParseS
        {
            get { return m_lstConvertNameParse; }
            set { m_lstConvertNameParse = value; }
        }

        public string ConvertName
        {
            get { return m_sConvertName; }
            set { m_sConvertName = value; }
        }

        public bool IsRedundancy
        {
            get { return m_bRedundancy; }
            set { m_bRedundancy = value; }
        }

        public bool IsMatch
        {
            get { return m_bMatch;}
            set { m_bMatch = value; }
        }

        public bool IsConvert
        {
            get { return m_bConvert;}
            set { m_bConvert = value; }
        }

        public bool IsInsert
        {
            get { return m_bInsert;}
            set { m_bInsert = value; }
        }

        public string PLCTagKey
        {
            get { return m_sPLCKey; }
            set { m_sPLCKey = value; }
        }

        public int Number
        {
            get { return m_iNumber; }
            set { m_iNumber = value; }
        }

        public string Group
        {
            get { return m_sGroup; }
            set { m_sGroup = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string DataType
        {
            get { return m_sDataType; }
            set
            {
                m_sDataType = value;
                m_emDataType = GetDataType(m_sDataType);
            }
        }

        public EMDataType EMDataType
        {
            get { return m_emDataType;}
            set { m_emDataType = value; }
        }

        public string Address
        {
            get { return m_sAddress;}
            set { m_sAddress = value; }
        }

        public string Description
        {
            get { return m_sDescription;}
            set { m_sDescription = value; }
        }

        #endregion

        #region Public Methods

        public void ClearPLCData()
        {
            m_bMatch = false;
            m_bInsert = false;
            m_bEdit = false;
            m_bConvert = false;
            m_bRedundancy = false;
            m_bHMIInput = false;
            m_bHMIOutput = false;

            //m_sPLCKey = string.Empty;
            //m_sAddress = string.Empty;
            //m_sDescription = string.Empty;
        }

        #endregion

        #region Private Methods

        public EMDataType GetDataType(string sDataType)
        {
            EMDataType tempType = EMDataType.Bool;
            try
            {
                sDataType = sDataType.ToUpper();

                if (sDataType.Contains("BOOL") || sDataType.Contains("BIT"))
                    tempType = EMDataType.Bool;
                else if(sDataType.Contains("WORD"))
                    tempType = EMDataType.Word;
                else if(sDataType.Contains("DWORD"))
                    tempType = EMDataType.DWord;
                else if (sDataType.Contains("BYTE"))
                    tempType = EMDataType.Byte;
                else if (sDataType.Contains("DINT"))
                    tempType = EMDataType.DInt;
                else if (sDataType.Contains("SINT"))
                    tempType = EMDataType.SInt;
                else if (sDataType.Contains("INT"))
                    tempType = EMDataType.Int;
                else if (sDataType.Contains("REAL"))
                    tempType = EMDataType.Real;
                else if (sDataType.Contains("CONTROL"))
                    tempType = EMDataType.Control;
                else if (sDataType.Contains("COUNTER"))
                    tempType = EMDataType.Counter;
                else if (sDataType.Contains("TIMER"))
                    tempType = EMDataType.Timer;
                else if (sDataType.Contains("MESSAGE"))
                    tempType = EMDataType.Message;
                else if (sDataType.Contains("STRING"))
                    tempType = EMDataType.String;
                else
                    tempType = EMDataType.UserDefDataType;

                if (sDataType == string.Empty)
                    m_emDataType = EMDataType.None;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMI Tag Data Type", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
            return tempType;
        }


        #endregion

    }
}
