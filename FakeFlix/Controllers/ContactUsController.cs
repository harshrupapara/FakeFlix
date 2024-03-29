﻿using FakeFlix.Models;
using FakeFlix.Repositories;
using Sitecore.Data;
using Sitecore.Data.Serialization.Model;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace FakeFlix.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult ContactUsComponent()
        {
            ContactUsRepository contactUsRepository = new ContactUsRepository();
            ContactUsModel model = contactUsRepository.GetContactData();
            return View("~/Views/ContactUs/ContactUsComponent.cshtml", model);
        }

        [HttpPost]
        public ActionResult PostContactForm(string name, string email, string message)
        {
            try
            {
                string formData = $"FORM DETAILS: \nFull Name: {name} \nEmail: {email} \nMessage: {message}";

                Log.Info($"FORM SUBMITTED SUCCESSFULLY: {formData}", "CONTACT US POST METHOD DATA");
                return new JsonResult()
                {
                    Data = name,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch(Exception ex)
            {
                return new JsonResult()
                {
                    Data = ex.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            
        }
    }
}