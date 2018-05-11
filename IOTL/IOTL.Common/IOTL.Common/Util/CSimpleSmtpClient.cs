using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // 참고사이트 codeproject : https://www.codeproject.com/Questions/545481/SendplussmsplususingplusInternetplusinplusc
        // 2018.05.10 금일 오전 5시 50분경 전송했으나, 6시 현재 아직 도착 하지 않음.
        public void SendTextMessage(string subject, string message, long telephoneNumer)
        {
            // login details for gmail acct.
            // const string sender = "me@gmail.com";
            // const string password = "mypassword4gmailacct";

            // find the carriers sms gateway for the recipent. txt.att.net is for AT&T customers.
            string carrierGateway = "txt.att.net";

            // this is the recipents number @ carrierGateway that gmail use to deliver message.
            string recipent = string.Concat(new object[]{
            telephoneNumer,
            '@',
            carrierGateway
            });

            // form the text message and send
            using (MailMessage textMessage = new MailMessage(getMailAddress(), recipent, subject, message))
            {
                using (SmtpClient textMessageClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    textMessageClient.UseDefaultCredentials = false;
                    textMessageClient.EnableSsl = true;
                    textMessageClient.Credentials = new NetworkCredential(getMailAddress(), gmailUserPassword);
                    textMessageClient.Send(textMessage);
                }
            }
        }

        public async Task SendGMail(string mailSubject, string mailToUser, string mailMessage, string attachmentFilename)
        {
            if (!bUserInitialized)
            {
                Console.WriteLine("Need Gmail User Information Initialize!");
                return;
            }

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
            message.Body += Environment.NewLine +  "Time :" + DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToShortTimeString();
            message.Body += Environment.NewLine + "Message =========================================";
            message.Body += Environment.NewLine + mailMessage;
            message.Body += Environment.NewLine + "End =========================================";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            if (attachmentFilename != null)
                message.Attachments.Add(new Attachment(attachmentFilename));

            try
            {
                // 동기로 메일을 보낸다.
                // client.Send(message);
                await client.SendMailAsync(message);

                // Clean up.
                message.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }
}
