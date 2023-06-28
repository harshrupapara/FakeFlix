using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class MovieListingModel
    {
        public string MovieListingTitle { get; set; }
        public string MovieGenreName { get; set; }
        public List<MovieListingItems> MovieList { get; set; }
    }
    public class MovieListingItems
    {
        
        public string MovieTitle { get; set; }
        public string MovieCTALink { get; set; }
        public string MovieCTAText { get; set; }
        public string MoviePoster { get; set; }
        public Boolean IsMovieNew { get; set; }
        public int NewMovieTagDuration { get; set; }

        public string CurrentDateTime { get; set; }
        public string CheckedDateTime { get; set; }

        public string CheckTimeStamp { get; set; }
    }
}