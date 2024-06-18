using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class MovieDetailsModel
    {
        public string MovieParentName { get; set; }
        public Item MovieItem { get; set; }

    }
}