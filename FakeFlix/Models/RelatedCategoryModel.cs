using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class RelatedCategoryModel
    {
        public List<RelatedCategoryItems> RelatedCategoyList { get; set; }
    }
    public class RelatedCategoryItems
    {
        public string CategoryItemUrl { get; set; }
        public Item CategoryItems { get; set; }
    }
}