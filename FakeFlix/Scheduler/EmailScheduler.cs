using Sitecore.Data.Items;
using System;
using Sitecore.Diagnostics;
using System.Net.Mail;
using FakeFlix.Models;
using FakeFlix.Utilities;

namespace FakeFlix.Scheduler
{
    public class EmailScheduler
    {
        public void ExecuteEmailScheduler(Item[] items, Sitecore.Tasks.CommandItem commandItem, Sitecore.Tasks.ScheduleItem scheduleItem)
        {
            try
            {
                EmailSenderModel emailModel = new EmailSenderModel
                {
                    To = "pintwala@horizontal.com",
                    Subject = "Thank you, Priyal",
                    Body = "This is a automated mail \n DO NOT REPLY \n 🤪🤪🤪"
                };

                MailSender mailSender = new MailSender();
                mailSender.SendMail(emailModel);
                //EmailSender emailSender = new EmailSender();
                //emailSender.SendEmail();
                Log.Info("[" + System.DateTime.Now + "] : " + "Mail is Sent Successfully!", this);
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("[" + System.DateTime.Now + "]" + "Some error found in EmailScheduler: " + ex.Message, this);
            }
        }
    }
}