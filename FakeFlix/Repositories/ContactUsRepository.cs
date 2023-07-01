using FakeFlix.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FakeFlix.Repositories
{
    public class ContactUsRepository
    {
        public ContactUsModel GetContactData()
        {
            Item dataSourceItem = RenderingContext.Current.Rendering.Item;
            try
            {
                if (dataSourceItem == null)
                {
                    Sitecore.Diagnostics.Log.Error("Datasource Item is null in Contact Us Repository", this);
                    return null;
                }
                ContactUsModel model = new ContactUsModel();
                model.ContactFormDetails = dataSourceItem;

                MultilistField multilist = dataSourceItem.Fields["ContactDetails"];
                if (multilist == null)
                {
                    Sitecore.Diagnostics.Log.Error("Multilist field is empty or null in Contact Us Repo!", this);
                    return null;
                }
                Item[] contactItems = multilist.GetItems();
                List<ContactDetails> contactDetails = new List<ContactDetails>();
                foreach (Item item in contactItems)
                {
                    ContactDetails list = new ContactDetails()
                    {
                        ContactDetailsItem = item
                    };
                    contactDetails.Add(list);
                }
                model.ContactDetailsList = contactDetails;
                return model;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured in Contact Us Repository", ex, typeof(ContactUsModel));
                return null;
            }
        }
    }
}