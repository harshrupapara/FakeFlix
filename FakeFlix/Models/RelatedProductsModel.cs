using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class RelatedProductsModel
    {
        public List<RelatedProductsItems> RelatedProductList { get; set; }
    }
    public class RelatedProductsItems
    {
        public string ProductItemURL { get; set; }
        public string ProductGenre { get; set; }
        public Item ProductItem { get; set; }
    }
}