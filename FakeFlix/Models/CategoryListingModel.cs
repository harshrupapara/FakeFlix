using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class CategoryListingModel
    {
        public string CategoryListTitle { get; set; }
        public string CategoryListDescription { get; set; }
        public int ResultPerLoadMore { get; set; }
        public int DefaultResult { get; set; }
        public List<Categories> CategoriesList { get; set; }
    }
    public class Categories
    {
        public string CategoryTitle { get; set; }
        public string CategoryCTALink { get; set; }
        public string CategoryImageLink { get; set; }
    }
}