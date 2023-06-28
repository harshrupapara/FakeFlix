using FakeFlix.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Repositories
{
    public class FeaturedMoviesRepository
    {
        public FeaturedMoviesModel GetFeaturedMoviesData()
        {
            try
            {
                Item dataSourceItem = RenderingContext.Current.Rendering.Item;
                if (dataSourceItem == null)
                {
                    Sitecore.Diagnostics.Log.Error("Error Ocurred in FeaturedMoviesRepository!", this);
                    return null;
                }

                MultilistField multiList = dataSourceItem.Fields["FeaturedMovieList"];
                Item[] movieItems = multiList.GetItems();
                List<FeaturedMoviesItem> featuredMoviesItems = new List<FeaturedMoviesItem>();
                foreach (Item item in movieItems)
                {
                    FeaturedMoviesItem list = new FeaturedMoviesItem
                    {
                        FeaturedMovieDetails = item
                    };
                    featuredMoviesItems.Add(list);
                }
                FeaturedMoviesModel model = new FeaturedMoviesModel
                {
                    FeaturedMovieList = featuredMoviesItems
                };
                return model;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured in Featured Movies Repository", ex, typeof(FeaturedMoviesModel));
                return null;
            }
        }
    }
}