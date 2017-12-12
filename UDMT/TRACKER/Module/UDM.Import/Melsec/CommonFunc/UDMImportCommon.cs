using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;

namespace UDM.Import.ME
{
    public class UDMImportCommon
    {
        public static Int64 Hex2Int(String str)
        {
            Int64[] powerNum = { 0, 1, 16, 256, 4096, 65536, 1048576, 16777216, 268435456 };
            str = str.ToUpper();

            if (str.Length > 1 && str[0] == '0') str = str.Substring(1);

            Int64 iRet = 0;

            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 'A') iRet += (str[i] - 'A' + 10) * powerNum[str.Length - i];
                    else iRet += (str[i] - '0') * powerNum[str.Length - i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return iRet;
        }

        public static void Invoke<T>(string methodName) where T : new()
        {
            T instance = new T();
            MethodInfo method = typeof(T).GetMethod(methodName);
            method.Invoke(instance, null);
        }

        public static string endianProcess(String src)
        {
            String result = "";
            for (int i = src.Length; i > 0; i -= 2) result += src.Substring(i - 2, 2);
            return result;
        }

        public static Int64 Hex2Int(String str, bool endian)
        {
            Int64[] powerNum = { 0, 1, 16, 256, 4096, 65536, 1048576, 16777216, 268435456 };

            str = str.ToUpper();
            if (endian) str = endianProcess(str);
            Int64 iRet = Hex2Int(str);
            return iRet;
        }

        public static string CutOffPoint(String source)
        {
            string sRet = String.Empty;

            sRet = source;

            if ( source.IndexOf('.') < 0 ) return sRet;

            for (int i = source.Length - 1; i > 1; i--)
            {
                if (sRet[i] == '0') sRet = sRet.Substring(0, i);
                else break;
            }

            if (sRet[sRet.Length - 1] == '.')
            {
                sRet = sRet.Substring(0, sRet.Length - 1 );
            }

            return sRet;
        }

        public static string ToEntity(string strs)
        {
            StringBuilder sb = new StringBuilder(strs);
            sb.Replace("&", "&amp");
            sb.Replace(">", "&gt;");
            sb.Replace("<", "&lt;");
            sb.Replace("\"", "&quot;");
            sb.Replace("\'", "&apos;");

            return sb.ToString();
        }

        public static string FromEntity(string strs)
        {
            StringBuilder sb = new StringBuilder(strs);
            sb.Replace("&apos;", "\'");
            sb.Replace("&quot;", "\"");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp", "&");
            return sb.ToString();
        }

        public static bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static string endianConversion(String strData)
        {
            String strRet = "";
            String strFront, strRear;

            switch (strData.Length)
            {
                case 4:
                    strFront = strData.Substring(2, 2);
                    if (strFront.Substring(0, 1) == "0") strFront = strFront.Substring(1, 1);
                    strRet = String.Format("{0}{1}", strData.Substring(0, 2), strFront);
                    break;
                case 6:
                    strRear = strData.Substring(2, 2);
                    strFront = strData.Substring(4, 2);
                    if (strFront.Substring(0, 1) == "0") strFront = strFront.Substring(1, 1);
                    strRet = String.Format("{0}{1}{2}", strData.Substring(0, 2), strFront, strRear);
                    break;
                case 8:
                    strRet = String.Format("{0}{1}{2}{3}", strData.Substring(6, 2), strData.Substring(4, 2), strData.Substring(2, 2), strData.Substring(0, 2));
                    break;
                default:
                    return strData;
            }

            return strRet;
        }

        public static String GetFilePath(string filePath)
        {
            if (filePath.Trim().EndsWith(@"\"))
                return String.Empty;

            int position = filePath.LastIndexOf('\\');

            if (position == -1)
            {
                return "C:\\";
            }
            else
            {
                if (File.Exists(filePath))
                {
                    return filePath.Substring(0, position);
                }
                else
                {
                    return "C:\\";
                }
            }
        }

        public static String GetFileName(string filePath)
        {
            String fileName;
            int position = filePath.LastIndexOf('\\');
            if (position > 0)
            {
                fileName = filePath.Substring(position + 1);
                position = fileName.LastIndexOf(".");
                if (position > 0)
                {
                    fileName = fileName.Substring(0, position);
                }
                else
                {
                    fileName = "UDMPLCImportME";
                }
            }
            else
            {
                fileName = "UDMPLCImportME";
            }
            return fileName;
        }

        public static string Pad(string s, int len)
        {
            string temp = s;
            for (int i = s.Length; i < len; ++i)
                temp = "0" + temp;
            return temp;
        }

        public static bool IsNetworkAvailable()
        {
            bool bRet;

            bRet = NetworkInterface.GetIsNetworkAvailable();
            return bRet;
        }

        private const int PING_TIMEOUT = 1000;
        private static bool IsHostAccessible(string hostNameOrAddress)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(hostNameOrAddress, PING_TIMEOUT);
            return reply.Status == IPStatus.Success;
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;
            string strRet = "";

            if (addr.Length > 0)
            {
                for (int i = 0; i < addr.Length; i++)
                {
                    //
                    // IPAddress Separator is /
                    //
                    if (i > 0) strRet += "/";
                    strRet += addr[i].ToString();
                }
                return strRet;

            }
            else return String.Empty;
        }

        public static bool IsHexaString(string sValue)
        {
            Regex regex = new Regex(@"^[0-9A-F]+$", RegexOptions.IgnoreCase);

            if (regex.IsMatch(sValue))
                return true;
            else
                return false;
        }

        public static bool IsDigitString(string sValue)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(sValue))
                return true;
            else
                return false;
        }
    }
}
