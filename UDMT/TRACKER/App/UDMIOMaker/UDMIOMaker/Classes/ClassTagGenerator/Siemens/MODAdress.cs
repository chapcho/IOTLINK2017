using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class MODAdress
    {
        #region Member Variables

        protected string m_sAddressConver = null;
        protected double dConver = 0.0;
        protected List<string> m_lstConverBit = new List<string>();


        #endregion

        #region Initialize/Dispose

        public MODAdress()
        {
         
        }

        public MODAdress(string sConvertAddress, int nSelectedHMI)
        {
            InsertBit(sConvertAddress, nSelectedHMI);
        }
        public void Dipose()
        {
            if (m_sAddressConver != null)
            {
                m_sAddressConver = null;
            }

            if (m_lstConverBit != null)
            {
                m_lstConverBit.Clear();

            }

        }

        #endregion

        #region Public Properites

        public string SDFAddress
        {
            get { return m_sAddressConver; }
            set { m_sAddressConver = value; }
        }
        
        public List<string> ConvertBit
        {
            get { return m_lstConverBit; }
            set { m_lstConverBit = value; }
        }


        #endregion

        #region Public Methods

        public bool AddCpu(string sCpuNumber)
        {
            double dNumber = 0.0;
            bool bCanConvert = Double.TryParse(sCpuNumber, out dNumber);

            if (bCanConvert == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddressConvertor(string sAddressConvertor)
        {
            string sAdd = null;
            string sDelete = null;
            double dConver = 0.0;
            double dNumber = 0.0;
            string fmt = "0000.0##";

            if (sAddressConvertor.StartsWith("I"))
            {

                sDelete = sAddressConvertor.Replace("I", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);

                if (bCanConvert == true)
                {
                    dConver = double.Parse(sDelete);
                    sAdd = "I";
                    m_sAddressConver = sAdd + dConver.ToString(fmt);
                }
                else
                {
                    m_sAddressConver = sAddressConvertor;
                }
            }

            else if (sAddressConvertor.StartsWith("Q"))
            {
                sDelete = sAddressConvertor.Replace("Q", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);

                if (bCanConvert == true)
                {
                    dConver = double.Parse(sDelete);
                    sAdd = "Q";
                    m_sAddressConver = sAdd + dConver.ToString(fmt);
                }
                else
                {
                    m_sAddressConver = sAddressConvertor;
                }
            }
            else if (sAddressConvertor.StartsWith("M"))
            {
                sDelete = sAddressConvertor.Replace("M", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);

                if (bCanConvert == true)
                {
                    dConver = double.Parse(sDelete);
                    sAdd = "M";
                    m_sAddressConver = sAdd + dConver.ToString(fmt);
                }
                else
                {
                    m_sAddressConver = sAddressConvertor;
                }
            }
            else if (sAddressConvertor.StartsWith("DB"))
            {
                sDelete = sAddressConvertor.Replace("DB", "");

                bool bCanConvert = Double.TryParse(sDelete, out dNumber);

                if (bCanConvert == true)
                {
                    dConver = double.Parse(sDelete);
                    sAdd = "DB";
                    m_sAddressConver = sAdd + dConver.ToString(fmt);
                }
                else
                {
                    m_sAddressConver = sAddressConvertor;
                }
            }
            else
            {
                m_sAddressConver = sAddressConvertor;
            }
            return true;
        }

        public bool InsertBit(string sConvertAddress, int nSelectedHMI)
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
                    for(int i=0; i< nSelectedHMI-1 ;i++)
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
                    for (int i = 0; i < nSelectedHMI-1; i++)
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
                    for (int i = 0; i < nSelectedHMI-1; i++)
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

        #endregion

        #region Private Methods


        #endregion
    }
}
