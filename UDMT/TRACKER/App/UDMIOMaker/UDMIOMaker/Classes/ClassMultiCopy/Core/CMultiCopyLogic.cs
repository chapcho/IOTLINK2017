using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassMultiCopy
{
    public partial class CMultiCopyLogic
    {


        protected Dictionary<string, string> _DicKeyConver = new Dictionary<string, string>();
        protected List<string> _lstKeyCombination = new List<string>();
        protected List<string> _lstKeyConvert = new List<string>();
        protected string _sKeyName = string.Empty;
    
        #region Initialize/Dispose

        public CMultiCopyLogic(Dictionary<string, List<string>> DicKey)
        {
            KeySeparation(DicKey);
        }

        #endregion

        #region Public Properites

        public List<string> KeyCombination
        {
            get { return _lstKeyCombination; }
            set { _lstKeyCombination = value; }
        }

        public List<string> KeyConvertList
        {
            get { return _lstKeyConvert; }
            set { _lstKeyConvert = value; }
        }

        public string KeyName
        {
            get { return _sKeyName; }
            set { _sKeyName = value; }
        }

        public Dictionary<string,string> DicConver
        {
            get { return _DicKeyConver; }
            set { _DicKeyConver = value; }
        }

        #endregion

        #region Public Methods

        public void KeySeparation(Dictionary<string,List<string>> DicKey)
        {

            List<KeyValuePair<string, List<string>>> list = DicKey.ToList();

            foreach (KeyValuePair<string, List<string>> pair in list)
            {
                _sKeyName = pair.Key;
                _lstKeyCombination = pair.Value;
            }

            _lstKeyConvert = KeyGenerator(_lstKeyCombination);

        }

        public List<string> KeyGenerator(List<string> KeyCombination)
        {
            List<string> lstConvert = new List<string>();

            foreach(string KeyCombinations in KeyCombination)
            {
                lstConvert.Add(KeyGenerator(KeyCombinations));
            }

            return lstConvert;
        }

        public string KeyGenerator(string sKey)
        {
            if (sKey.Contains("+"))
            {
                return KeyCalculator(sKey);
            }
            else
                return "{" + sKey + "}";

        }

        public string KeyCalculator(string sKey)
        {
            List<string> lstConvert = new List<string>();
            string sTotolKey = string.Empty;

            string[] Keys = sKey.Split('+');

            foreach (string Key in Keys)
            {
                lstConvert.Add(KeyConvertor(Key));
            }

            foreach (string lstConverts in lstConvert)
            {
                sTotolKey = sTotolKey + lstConverts;
            }

            return sTotolKey;
        }

        public string KeyConvertor(string sKey)
        {
            if (sKey.Equals("Ctrl"))
                return "^";
            else if (sKey.Equals("Alt"))
                return "+";
            else if (sKey.Equals("Shift"))
                return "%";
            else if (sKey.Equals("PageDown"))
                return "{PGDN}";
            else if (sKey.Equals("PageUP"))
                return "{PGUP}";
            else if (sKey.Equals("PrintScreen"))
                return "{PRTSC}";
            else
                return "{"+ sKey +"}" ;
        }
     
        #endregion
    }
}
