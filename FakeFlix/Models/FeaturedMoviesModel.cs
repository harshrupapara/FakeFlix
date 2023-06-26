using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class FeaturedMoviesModel
    {
        public string FeaturedMovieTitle { get; set; }
        public List<FeaturedMoviesItem> FeaturedMovieList { get; set; }
    }
    public class FeaturedMoviesItem
    {
        public Item FeaturedMovieDetails { get; set; }
    }

}