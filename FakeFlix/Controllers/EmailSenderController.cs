using FakeFlix.Models;
using Sitecore.Configuration;
using Sitecore.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class EmailSenderController : Controller
    {
        [HttpPost]
        public JsonResult SendEmail(EmailSenderModel model)
        {
            try
            {
                string MailServer = Settings.GetSetting("MailServer");
                string MailServerPort = Settings.GetSetting("MailServerPort");
                string MailServerUseSsl = Settings.GetSetting("MailServerUseSsl");
                string MailServerUserName = Settings.GetSetting("MailServerUserName");
                string MailServerPassword = Settings.GetSetting("MailServerPassword");
                string senderEmail = MailServerUserName;
                string ReceiverEmail = model.To;
                string password = MailServerPassword;
                string subject = model.Subject;
                var Body = model.Body;

                MailMessage Mail = new MailMessage(senderEmail, ReceiverEmail, subject, Body);

                Mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                smtp.Host = MailServer;
                smtp.Port = Convert.ToInt16(MailServerPort);
                smtp.EnableSsl = MailServerUseSsl.ToBool();

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmail, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(Mail);
                return new JsonResult()
                {
                    Data = new { success = true, data = "Mail Sent Successfully" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
            catch (Exception exception)
            {
                return new JsonResult()
                {
                    Data = new { success = false, data = exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }
    }
}