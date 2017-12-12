using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.General.Csv
{
    public class CCsvRecord : List<string>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CCsvRecord()
        {

        }


        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public object this[int i, Type t]
        {
            get { return GetValue(i, t); }
        }

        #endregion


        #region Public Methods

        public object GetValue(int iIndex, Type t)
        {
            object oValue = null;

            try
            {
                string sValue = this[iIndex];
                if (sValue != null)
                    oValue = GetObject(sValue, t);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return oValue;
        }

        public string GetValue(int iIndex)
        {
            object oValue = null;

            try
            {
                oValue = GetValue(iIndex, typeof(string));

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return (string)oValue;
        }

        #endregion


        #region Private Methods

        private object GetObject(string sValue, Type t)
        {
            object oValue = null;

            if (t == typeof(bool))
                oValue = CTypeConverter.ToBool(sValue);
            else if (t == typeof(int))
                oValue = CTypeConverter.ToInteger(sValue);
            else if (t == typeof(Color))
                oValue = CTypeConverter.ToColor(sValue);
            else if (t == typeof(DateTime))
                oValue = CTypeConverter.ToDateTime(sValue);
            else if (t == typeof(decimal))
                oValue = CTypeConverter.ToDecimal(sValue);
            else if (t.BaseType == typeof(Enum))
                oValue = CTypeConverter.ToEnum(t, sValue);            
            else
                oValue = sValue;

            return oValue;
        }

        #endregion
    }
}
