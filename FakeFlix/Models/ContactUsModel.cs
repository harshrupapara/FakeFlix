using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Sitecore.Data.Items;

namespace FakeFlix.Models
{
    public class ContactUsModel
    {
        public Item ContactFormDetails { get; set; }
        public List<ContactDetails> ContactDetailsList { get; set; }
    }

    public class ContactDetails
    {
        public Item ContactDetailsItem { get; set; }
    }
}