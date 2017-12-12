using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;
using System.Web;

namespace FTOPApp
{
    public class WebWorker
    {

        public DYPServiceReference.DYP_WebserviceSoapClient SoapClient;
        public CbCpsIotDataManager.CpsIotDataManagerClient CpsClient;
        public string MWIP = "172.18.8.24";
        public string CpsIP = "172.17.2.22"; // 미지정  "172.17.2.22"
        
        public WebWorker()
        {
            SoapClient = new DYPServiceReference.DYP_WebserviceSoapClient();
            CpsClient = new CbCpsIotDataManager.CpsIotDataManagerClient(CpsIP);
            
        }

        /// <summary>
        /// MES 전송을 위한 중간 단계의 M/W의 WebService를 호출한다.
        /// 1. FTOPApp 우클릭 -> Add -> Service Reference -> Address 입력
        /// 2. 입력 내용: 172.18.8.24 : 8070
        /// 3. DYP_MW_Webservice.DYP_WebserviceSoapClient 인스턴스 생성하여 함수 호출
        /// </summary>
        /// <param name="gtrid"></param>
        /// <param name="maketime"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string SendLogDataToMESBySoap(string gtrid, string maketime, string key)
        {

            string result = string.Empty;
            try
            {
                result = SoapClient.Set_LogData(gtrid, maketime, key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = "1";
            }

            return result;

        }

        /// <summary>
        /// CPS 전송 
        /// 1. CbCpsIotDataManager.dll 참조하여 SendIotStatus 함수를 호출한다
        /// </summary>
        /// <param name="gtrid"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SendLogDataToCPSByTCPIP(string gtrid , string value , string eqm)
        {
            string result = string.Empty;
            try
            {
                //result = CpsClient.SendIotStatus(gtrid, eqm, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = "1";
            }

            return result;

        }

        //http://stackoverflow.com/questions/4791794/client-to-send-soap-request-and-received-response
        #region WebService

        public static string CallWebService()
        {
            var url = "http://xxxxxxxxx/Service1.asmx";
            var action = "http://xxxxxxxx/Service1.asmx?op=HelloWorld";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(url, action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();

                }
               
                Console.Write(soapResult);
                return soapResult;
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        #endregion  
       



    }
}
