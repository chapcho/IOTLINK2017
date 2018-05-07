using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Util
{
    public class CSimpleSmtpClient
    {
        private string gmailUserId = "";
        private string gmailUserPassword = "";
        private bool bUserInitialized = false;

        public CSimpleSmtpClient(string uid, string upwd)
        {
            gmailUserId = uid;
            gmailUserPassword = upwd;

            bUserInitialized = true;
        }

        public string getMailAddress()
        {
            return bUserInitialized ? gmailUserId + "@gmail.com" : "emptyuser@gmail.com";
        }

        public bool SendGMail(string mailSubject, string mailToUser, string mailMessage)
        {
            bool bRet = true;

            if (!bUserInitialized) return false;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            client.EnableSsl = true;  // SSL을 사용한다.
            client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential(gmailUserId, gmailUserPassword);

            MailAddress from = new MailAddress(getMailAddress(), "IOTLink", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(mailToUser);

            MailMessage message = new MailMessage(from, to);

            message.Subject = mailSubject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            message.Body = "==== IOTLink Monitoring Mail ====";
            message.Body += Environment.NewLine +  "Mail Send Date :" + DateTime.Now.ToShortDateString();
            message.Body += Environment.NewLine +  "          Time :" + DateTime.Now.ToShortTimeString();
            message.Body += Environment.NewLine + "Message ===";
            message.Body += Environment.NewLine + mailMessage;
            message.Body += Environment.NewLine + "=== End";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            try
            {
                // 동기로 메일을 보낸다.
                client.Send(message);

                // Clean up.
                message.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bRet = false;
            }

            return bRet;
        }

    }
}
