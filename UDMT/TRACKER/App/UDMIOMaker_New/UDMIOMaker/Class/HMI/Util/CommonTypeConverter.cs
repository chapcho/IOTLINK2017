using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace UDMIOMaker
{
    public static class CommonTypeConverter
    {

        #region Public Methods
        
        public static DateTime ToDateTime(decimal nDateTime)
        {
            DateTime dtTime = DateTime.MinValue;

            try
            {
                dtTime = DateTime.ParseExact(nDateTime.ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return dtTime;
        }

        public static DateTime ToDateTime(string sDateTime)
        {
            DateTime dtTime = DateTime.MinValue;

            try
            {
                if (sDateTime.Contains('/'))
                    dtTime = DateTime.ParseExact(sDateTime, "yy/MM/dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
                else if (sDateTime.Contains('.'))
                    //dtTime = DateTime.ParseExact(sDateTime, "yy.MM.dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
                    dtTime = DateTime.ParseExact(sDateTime, "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);
                else if (sDateTime.Contains('-'))
                    dtTime = DateTime.ParseExact(sDateTime, "yy-MM-dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
                else
                    dtTime = DateTime.Parse(sDateTime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return dtTime;
        }

        public static string ToDateTimeFormat(DateTime dtTime)
        {
            string sDateTime = dtTime.ToString("yyyyMMddHHmmss.fff");


            return sDateTime;
        }

        public static Color ToColor(string sArgb)
        {
            Color cColor = Color.LightGray;

            int iArgb = ToInteger(sArgb);
            
            try
            {
                cColor = Color.FromArgb(iArgb);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                cColor = Color.LightGray;
            }

            return cColor;
        }

        public static object ToEnum(Type typeEnum, string sValue)
        {
            object oValue = null;

            try
            {
                oValue = Enum.Parse(typeEnum, sValue);                
            }
            catch (System.Exception ex)
            {
                oValue = null;
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return oValue;

        }

        public static int ToInteger(string sNumber)
        {   
            int iValue = -1;

            try
            {
                double dValue = double.Parse(sNumber);

                iValue = (int)dValue;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return iValue;
        }

        public static double ToDouble(string sNumber)
        {
            double dValue = 0;

            try
            {
                dValue = double.Parse(sNumber);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return dValue;
        }

        public static bool ToBool(string sBool)
        {
            bool bValue = true;

            if (sBool == null)
                return false;

            if (sBool == "false" || sBool == "FALSE" || sBool == "False" || sBool == "0" || sBool == "00")
                bValue = false;

            return bValue;
        }

        public static bool ToBool(int iBool)
        {
            bool bValue = true;

            if (iBool == 0)
                bValue = false;

            return bValue;
        }

        public static decimal ToDecimal(string sValue)
        {
            decimal nValue = -1;

            try
            {
                nValue = decimal.Parse(sValue);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return nValue;
        }
        
        public static long ToLong(string sValue)
        {
            long nValue = 0;

            try
            {
                nValue = long.Parse(sValue);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return nValue;
        }

        public static string ToBinary(int iValue)
        {
            if (iValue == -1)
                return "NULL";

            string sValue = string.Empty;

            string sLine = Convert.ToString(iValue, 2);

            int iCount = sLine.Length;

            for (int i = iCount; i < 16; i++)
            {
                sLine = "0" + sLine;
            }

            sValue = sLine;

            return sValue;
        }

        public static int ToIntegerHexString(string sValue)
        {
            int iValue = -1;

            try
            {
                iValue = int.Parse(sValue, System.Globalization.NumberStyles.HexNumber);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return iValue;

        }

        public static string ToHex(int iValue)
        {
            if (iValue == -1)
                return "NULL";

            string sValue = Convert.ToString(iValue, 16);

            return sValue;
        }

        public static string ToAscii(int iValue)
        {
            if (iValue == -1)
                return "NULL";

            string sValue = string.Empty;

            string sLine = Convert.ToString(iValue, 2);

            int iCount = sLine.Length;

            for (int i = iCount; i < 16; i++)
            {
                sLine = "0" + sLine;
            }

            if (sLine.Length == 16)
            {
                string sHigh = sLine.Substring(0, 8);
                string sLow = sLine.Substring(8, 8);

                byte bHigh = Convert.ToByte(sHigh, 2);
                byte bLow = Convert.ToByte(sLow, 2);

                char cHigh = Convert.ToChar(bHigh);
                char cLow = Convert.ToChar(bLow);

                sValue = new string(new char[] { cHigh, cLow });
            }

            return sValue;
        }

        public static string ToCrossAscii(int iValue)
        {
            string sValue = string.Empty;

            string sLine = Convert.ToString(iValue, 2);

            int iCount = sLine.Length;

            for (int i = iCount; i < 16; i++)
            {
                sLine = "0" + sLine;
            }

            if (sLine.Length == 16)
            {
                string sHigh = sLine.Substring(0, 8);
                string sLow = sLine.Substring(8, 8);

                byte bHigh = Convert.ToByte(sHigh, 2);
                byte bLow = Convert.ToByte(sLow, 2);

                char cHigh = Convert.ToChar(bHigh);
                char cLow = Convert.ToChar(bLow);

                sValue = new string(new char[] { cLow, cHigh });
            }

            return sValue;
        }

        #endregion
    
    }
}
