using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Util
{
    public class ConnectionInfo
    {
        public static string UserName = "";

        public static string GetLocalIp()
        {
            IPHostEntry getIpInfo = Dns.GetHostEntry(Dns.GetHostName());
            // string ipAddr = string.Empty;

            for(int i = 0; i < getIpInfo.AddressList.Length;i++)
            {
                if(getIpInfo.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // ipAddr = getIpInfo.AddressList[i].ToString();
                    return getIpInfo.AddressList[i].ToString();
                }
            }

            return "check your network setting!";
        }
    }
}
