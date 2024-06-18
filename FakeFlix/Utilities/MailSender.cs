using FakeFlix.Models;
using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FakeFlix.Utilities
{
    public class MailSender
    {
        public void SendMail(EmailSenderModel model)
        {
            try
            {
                string MailServer = Settings.GetSetting("MailServer");
                string MailServerPort = Settings.GetSetting("MailServerPort");
                string MailServerUseSslString = Settings.GetSetting("MailServerUseSsl");
                string MailServerUserName = Settings.GetSetting("MailServerUserName");
                string MailServerPassword = Settings.GetSetting("MailServerPassword");
                string senderEmail = MailServerUserName.ToString();
                string receiverMail = model.To;
                string password = MailServerPassword;
                string subject = model.Subject;
                var body = model.Body;

                bool MailServerUseSsl = bool.Parse(MailServerUseSslString);


                if (receiverMail == null || subject == null || body == null)
                {
                    Sitecore.Diagnostics.Log.Error("Parameters cannot be null. Null found in anyone of these parameters \n RecieverEmail OR subject OR body", this);
                }


                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(senderEmail, senderEmail);
                    mailMessage.To.Add(new MailAddress(receiverMail, receiverMail));
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient smtpClient = new SmtpClient(MailServer, Int32.Parse(MailServerPort)))
                    {
                        smtpClient.EnableSsl = MailServerUseSsl;
                        smtpClient.Credentials = new NetworkCredential(senderEmail, password);
                        smtpClient.Send(mailMessage);
                    }
                }

            }catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("SOME ERROR OCCURED IN UTILITIES.MAILSENDER:  ", ex.Message);
            }
        }
    }
}