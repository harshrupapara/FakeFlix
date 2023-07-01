using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class ProductListingModel
    {
        public string ProductListingTitle { get; set; }
        public List<MovieListingItems> ProductListingItems { get; set; }
    }
}