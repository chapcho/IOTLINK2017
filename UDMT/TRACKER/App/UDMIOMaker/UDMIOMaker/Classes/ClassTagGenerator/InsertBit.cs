using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Enumeration;
using System.Text.RegularExpressions;
using System.Globalization;
using UDM.Common;


namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class InsertBit
    {
        protected string m_sAddressConver = null;
        protected double dConver = 0.0;
        protected int m_dConver = 0;
        protected List<string> m_lstConverBit = new List<string>();
        protected CommonMessage cMessage = new CommonMessage();
        
        #region Initialize/Dispose

        public InsertBit(EMPLCMaker PLCMaker, string address, int size)
        {

            if (PLCMaker == EMPLCMaker.Siemens)
                SiemenseInsert(address, size);

            else if (PLCMaker == EMPLCMaker.Mitsubishi)
                Mitsubishi(address, size);

            else if (PLCMaker == EMPLCMaker.Rockwell)
                ABInsert(address, size);

            else if (PLCMaker == EMPLCMaker.LS)
                Mitsubishi(address, size);
          
        }

        #endregion

        #region Public Properites

        public List<string> Bit
        {
            get { return m_lstConverBit; }
            set { m_lstConverBit = value; }
        }

        #endregion

        #region Private Methods

        protected bool SiemenseInsert(string sConvertAddress, int nSelectedHMI)
        {
            string sAdd = null;
            string sDelete = null;
            double dNumber = 0.0;
            string fmt = "0000.0##";

            if (sConvertAddress.StartsWith("I"))
            {
                sDelete = sConvertAddress.Replace("I", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);
                dConver = double.Parse(sDelete);

                if (bCanConvert == true)
                {
                    for (int i = 0; i < nSelectedHMI - 1; i++)
                    {
                        dConver = dConver + 0.1;
                        dConver = Math.Round(dConver, 1);

                        string sConver = dConver.ToString();
                        {
                            if (sConver.EndsWith("8"))
                            {
                                dConver = Math.Ceiling(dConver);
                            }
                        }

                        sAdd = "I";
                        m_lstConverBit.Add(sAdd + dConver.ToString(fmt));
                    }
                }
                else
                {
                    m_lstConverBit.Add(sConvertAddress);
                }

            }
            else if (sConvertAddress.StartsWith("Q"))
            {
                sDelete = sConvertAddress.Replace("Q", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);
                dConver = double.Parse(sDelete);

                if (bCanConvert == true)
                {
                    for (int i = 0; i < nSelectedHMI - 1; i++)
                    {
                        dConver = dConver + 0.1;
                        dConver = Math.Round(dConver, 1);

                        string sConver = dConver.ToString();
                        {
                            if (sConver.EndsWith("8"))
                            {
                                dConver = Math.Ceiling(dConver);
                            }
                        }

                        sAdd = "Q";
                        m_lstConverBit.Add(sAdd + dConver.ToString(fmt));
                    }
                }
                else
                {
                    m_lstConverBit.Add(sConvertAddress);
                }

            }
            else if (sConvertAddress.StartsWith("M"))
            {
                sDelete = sConvertAddress.Replace("M", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);
                dConver = double.Parse(sDelete);

                if (bCanConvert == true)
                {
                    for (int i = 0; i < nSelectedHMI - 1; i++)
                    {
                        dConver = dConver + 0.1;
                        dConver = Math.Round(dConver, 1);

                        string sConver = dConver.ToString();
                        {
                            if (sConver.EndsWith("8"))
                            {
                                dConver = Math.Ceiling(dConver);
                            }
                        }

                        sAdd = "M";
                        m_lstConverBit.Add(sAdd + dConver.ToString(fmt));
                    }
                }
                else
                {
                    m_lstConverBit.Add(sConvertAddress);
                }

            }
            else
            {
                MessageBox.Show("The type is not supported.. \n\n Please use the I or Q or M Address..", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }
        
        protected bool ABInsert(string sConvertAddress, int nSelectedHMI)
        {
            if (sConvertAddress.Contains("."))
            {
                string[] arr = sConvertAddress.Split('.');
                string sData = arr[0];

                if (arr[1].Length > 2 || Convert.ToInt32(arr[1]) > 30)
                {
                    cMessage.NotSupport();
                    return false;
                }

                string sIntData = arr[1];

                m_dConver = int.Parse(sIntData);

                for (int i = 0; i < nSelectedHMI - 1; i++)
                {
                    m_dConver = m_dConver + 1;


                    string sConver = m_dConver.ToString();

                    if (sConver.EndsWith("32"))
                    {
                        return false;
                    }
                  
                    string str = Convert.ToString(m_dConver);
                    m_lstConverBit.Add(sData + "." + str);
                }

            }

            return true;

        }

        protected bool Mitsubishi(string Address, int num)
        {
            try
            {
                if(Address.StartsWith("X") || Address.StartsWith("Y"))
                {
                    var value = Address.ToCharArray()[0];
                    var hex = Address.Replace("X", "").Replace("Y", "");
                    var decValue = Convert.ToInt32(hex, 16);

                    for(int i = 0 ; i < num - 1  ; i++)
                    {
                        var hexValue = string.Format("{0:x}", ++decValue);
                        m_lstConverBit.Add(value + hexValue);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Mitsubishi의 Insert Bit는 X or Y 영역만 가능합니다.");
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Not Supported" + ex);

                return false;
            }
        }

        public string[] DataParse(string temp)
        {
            string[] data = new string[3];

            if (!temp.Contains("."))
                return null;

            string[] Point = temp.Split('.');

            string sOriginal = Point[0];

            string sPointLeft = Point[1];
            string sPointRight = Regex.Replace(sOriginal, @"\D", "");
            string sDataType = sOriginal.Replace(sPointRight, "");

            data[0] = sDataType;
            data[1] = sPointRight;
            data[2] = sPointLeft;

            return data;
        }

        public static string IncrementHexNumber(string hexNumber, int increment)
        {
            return Regex.Replace(hexNumber, "[A-F|0-9]{4}", m => (Int32.Parse(m.Value, NumberStyles.HexNumber) + increment).ToString("X4"));
        } 

        #endregion
    }
}
