using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using System.Windows.Forms;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class CABL5KConvertor
    {
        #region Member Variables

        protected List<string> m_BaseConver = new List<string>();
        protected List<string> m_AliasConver = new List<string>();
        protected List<string> m_CommentConver = new List<string>();

        protected List<string> m_CommentCheck = new List<string>();
        protected List<string> m_Temp = new List<string>();

        #endregion

        #region Initialize/Dispose

        public CABL5KConvertor()
        {

        }

        #endregion

        #region Public Properites


        public List<string> BaseCov
        {
            get { return m_BaseConver; }
            set { m_BaseConver = value; }
        }

        public List<string> AliasCov
        {
            get { return m_AliasConver; }
            set { m_AliasConver = value; }
        }

        public List<string> CommentCoV
        {
            get { return m_CommentConver; }
            set { m_CommentConver = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods


        public void BaseConvertor(List<string> BaseFile)
        {
            foreach (string BaseFiles in BaseFile)
            {
                string[] basetags = BaseFiles.Split('(');
                string str = basetags[0].Replace(" ", "");

                if (str.Contains(":="))
                {
                    string temp = str.Replace(":=", "*");
                    string[] arrtemp = temp.Split('*');
                    str = arrtemp[0];
                }

                string sData = str.Replace("Base:Global:", "");
                //sData = sData.Replace("Base:Local:", "");
                m_BaseConver.Add(arrayCheck(sData));
                m_CommentCheck.Add(arrayCheck(sData));
            }
        }

        public void AliasConvertor(List<string> AliasFile)
        {
            string Btype = string.Empty;

            foreach (string AliasFiles in AliasFile)
            {
                bool EmptyCheck = false;
                string[] aliastags = AliasFiles.Split('(');
                string sAlias = aliastags[0].Replace("Alias:Global:", "");
                string sAliasData = sAlias.Replace(" OF ", "*");

                string[] arrData = sAliasData.Split('*');

                if (arrData[1].Contains(":"))
                {
                    string[] arr = arrData[1].Split('.');
                    if (arr.Length == 3)
                    {
                        Btype = "BOOL";
                        EmptyCheck = true;
                    }
                }
                else if (arrData[1].Contains("."))
                {
                    Btype = "BOOL";
                    EmptyCheck = true;
                }


                string AliasData = arrData[0];

                if (EmptyCheck) // DataType 없는것은 뺀다
                {
                    m_CommentCheck.Add(AliasData + " : " + Btype);
                    m_AliasConver.Add(AliasData + " : " + Btype);
                }

                Btype = string.Empty;
            }
        }

        public void CommentConvertor(List<string> CommentFile)
        {
            foreach (string CommentFiles in CommentFile)
            {
                string[] arr = CommentFiles.Split(':');
                string str = arr[2].Replace(" ", "");
                //m_Temp.Add(str);
                m_Temp.Add(str);
            }

            DataTypeCheck();
            //CommentDataTypeCheck();
        }

        public string arrayCheck(string data)
        {

            if (data.Contains(","))
            {
                data = data.Replace(",", "+");
            }

            return data;
        }

        public void DataTypeCheck()
        {
            foreach (string aa in m_Temp)
            {
                if (aa.Contains("."))
                {
                    m_CommentConver.Add(aa + ":BOOL");
                }
            }
        }

        public void CommentDataTypeCheck()
        {
            string str = string.Empty;

            foreach (string Temps in m_Temp)
            {
                if (Temps.Contains("["))
                {
                    string[] arr = Temps.Split('[');
                    str = arr[0];
                }
                else if (Temps.Contains("."))
                {
                    string[] arr = Temps.Split('.');
                    str = arr[0];
                }
                else
                {
                    MessageBox.Show("Not Supported..");
                }

                foreach (string CommentChecks in m_CommentCheck)
                {
                    string[] temp = CommentChecks.Split(':');
                    if (temp[0].Replace(" ", "").Equals(str))
                    {
                        string[] arr = CommentChecks.Split(':');
                        m_CommentConver.Add(Temps + ":" + arr[1]);

                    }

                }


            }
        }

        #endregion
    }
}
