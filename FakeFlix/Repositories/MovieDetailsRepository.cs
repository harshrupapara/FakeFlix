using FakeFlix.Models;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Repositories
{
    public class MovieDetailsRepository
    {
        public MovieDetailsModel GetMovieDetails(Item PageItem)
        {
            try
            {
                if (PageItem == null)
                {
                    Sitecore.Diagnostics.Log.Error("Page Item found to be Null! Provide A Page Item in Moive Details Repositoy!", this);
                }
                MovieDetailsModel model = new MovieDetailsModel();
                model.MovieItem = PageItem;
                return model;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("An exception error is occured, please resolve it!", ex, this);
                return null;
            }
            
        }
    }

}
